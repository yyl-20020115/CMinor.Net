using System;
using System.Collections.Generic;

namespace JavaCUP;

public class LalrState
{
	protected internal static Dictionary<LalrItemSet, LalrState> _all = new();

	protected internal static Dictionary<LalrItemSet, LalrState> _all_kernels = new();

	protected internal static int next_index;

	protected internal LalrItemSet _items;

	protected internal LalrTransition _transitions;

	protected internal int _index;

	public virtual int Index()
	{
		return _index;
	}

	
	
	public static LalrState find_state(LalrItemSet itms)
	{
		return itms != null && _all.TryGetValue(itms, out var r) ? r : null;
	}

	public virtual LalrItemSet items()
	{
		return _items;
	}

	
	
	public static IEnumerable<LalrState> all()
	{
		return _all.Values;
	}

	
	
	
	protected internal virtual void propagate_lookaheads()
	{
		foreach(var item in items().all())
		{
			item.propagate_lookaheads(null);
		}
	}

	
	
	public LalrState(LalrItemSet itms)
	{
		_transitions = null;
		if (itms == null)
		{
			
			throw new InternalError("Attempt to construct an LALR state from a null item set");
		}
		if (find_state(itms) != null)
		{
			
			throw new InternalError("Attempt to construct a duplicate LALR state");
		}
		_index = next_index++;
		_items = itms;
		_all.Add(_items, this);
	}

	
	
	
	public virtual void add_transition(_Symbol on_sym, LalrState to_st)
	{
		LalrTransition lalr_transition2 = (_transitions = new LalrTransition(on_sym, to_st, _transitions));
	}

	
	
	
	protected internal static void propagate_all_lookaheads()
	{
		foreach(var item in all())
		{
			item.propagate_lookaheads();
		}
	}

	
	
	protected internal virtual bool fix_with_precedence(Production p, int term_index, ParseActionRow table_row, ParseAction act)
	{
		Terminal terminal2 = Terminal.find(term_index);
		if (p.precedence_num() > -1)
		{
			if (p.precedence_num() > terminal2.precedence_num())
			{
				table_row.under_term[term_index] = insert_reduce(table_row.under_term[term_index], act);
				return true;
			}
			if (p.precedence_num() < terminal2.precedence_num())
			{
				table_row.under_term[term_index] = insert_shift(table_row.under_term[term_index], act);
				return true;
			}
			if (terminal2.precedence_side() == 1)
			{
				table_row.under_term[term_index] = insert_shift(table_row.under_term[term_index], act);
				return true;
			}
			if (terminal2.precedence_side() == 0)
			{
				table_row.under_term[term_index] = insert_reduce(table_row.under_term[term_index], act);
				return true;
			}
			if (terminal2.precedence_side() == 2)
			{
				table_row.under_term[term_index] = new NonAssocActon();
				return true;
			}
			
			throw new InternalError("Unable to resolve conflict correctly");
		}
		if (terminal2.precedence_num() > -1)
		{
			table_row.under_term[term_index] = insert_shift(table_row.under_term[term_index], act);
			return true;
		}
		return false;
	}

	public virtual LalrTransition transitions()
	{
		return _transitions;
	}

	protected internal virtual void report_conflicts(TerminalSet conflict_set)
	{
		foreach(var lalr_item2 in items().all())
		{
			if (!lalr_item2.dot_at_end())
			{
				continue;
			}
			int num = 0;
			foreach(var lalr_item3 in items().all())
			{
				if (lalr_item2 == lalr_item3)
				{
					num = 1;
				}
				if (lalr_item2 != lalr_item3 && lalr_item3.dot_at_end() && num != 0 && lalr_item3.lookahead().InterestWith(lalr_item2.lookahead()))
				{
					report_reduce_reduce(lalr_item2, lalr_item3);
				}
			}
			for (int i = 0; i < Terminal.number(); i++)
			{
				if (conflict_set.Contains(i))
				{
					report_shift_reduce(lalr_item2, i);
				}
			}
		}
	}

	
	
	
	protected internal virtual ParseAction insert_reduce(ParseAction a1, ParseAction a2)
	{
		ParseAction result = insert_action(a1, a2, 2);
		
		return result;
	}

	
	
	
	protected internal virtual ParseAction insert_shift(ParseAction a1, ParseAction a2)
	{
		ParseAction result = insert_action(a1, a2, 1);
		
		return result;
	}

	
	
	
	protected internal virtual ParseAction insert_action(ParseAction a1, ParseAction a2, int act_type)
	{
		if (a1.Kind== act_type && a2.Kind== act_type)
		{
			
			throw new InternalError("Conflict resolution of bogus actions");
		}
		if (a1.Kind== act_type)
		{
			return a1;
		}
		if (a2.Kind== act_type)
		{
			return a2;
		}
		
		throw new InternalError("Conflict resolution of bogus actions");
	}

	protected internal virtual void report_reduce_reduce(LalrItem itm1, LalrItem itm2)
	{
		int num = 0;
		Console.Error.WriteLine(("*** Reduce/Reduce conflict found in state #")+(Index()));
		Console.Error.Write("  between ");
		Console.Error.WriteLine(itm1.to_simple_string());
		Console.Error.Write("  and     ");
		Console.Error.WriteLine(itm2.to_simple_string());
		Console.Error.Write("  under symbols: {");
		for (int i = 0; i < Terminal.number(); i++)
		{
			if (itm1.lookahead().Contains(i) && itm2.lookahead().Contains(i))
			{
				if (num != 0)
				{
					Console.Error.Write(", ");
				}
				else
				{
					num = 1;
				}
				Console.Error.Write(Terminal.find(i).Name);
			}
		}
		Console.Error.WriteLine("}");
		Console.Error.Write("  Resolved in favor of ");
		if (itm1.the_production().index() < itm2.the_production().index())
		{
			Console.Error.WriteLine("the first production.\n");
		}
		else
		{
			Console.Error.WriteLine("the second production.\n");
		}
		emit.num_conflicts++;
		Lexer.warning_count++;
	}

	
	protected internal virtual void report_shift_reduce(LalrItem red_itm, int conflict_sym)
	{
		Console.Error.WriteLine(("*** Shift/Reduce conflict found in state #")+(Index()));
		Console.Error.Write("  between ");
		Console.Error.WriteLine(red_itm.to_simple_string());
		foreach(var lalr_item2 in items().all())
		{
			if (lalr_item2 != red_itm && !lalr_item2.dot_at_end())
			{
				_Symbol symbol2 = lalr_item2.symbol_after_dot();
				if (!symbol2.IsNonTerminal&& symbol2.Index== conflict_sym)
				{
					Console.Error.WriteLine(("  and     ")+(lalr_item2.to_simple_string()));
				}
			}
		}
		Console.Error.WriteLine(("  under symbol ")+(Terminal.find(conflict_sym).Name));
		Console.Error.WriteLine("  Resolved in favor of shifting.\n");
		emit.num_conflicts++;
		Lexer.warning_count++;
	}

	
	
	public virtual bool Equals(LalrState other)
	{
		return (other != null && items().Equals(other.items())) ? true : false;
	}

	
	
	public static int number()
	{
		int result = _all.Count;
		
		return result;
	}

	
	
	protected internal static void dump_state(LalrState st)
	{
		if (st == null)
		{
			Console.Out.WriteLine("NULL lalr_state");
			return;
		}
		Console.Out.WriteLine(("lalr_state [")+(st.Index())+("] {")
			);
		LalrItemSet lalr_item_set2 = st.items();
		foreach(var lalr_item2 in lalr_item_set2.all())
		{
			Console.Out.Write("  [");
			Console.Out.Write(lalr_item2.the_production().lhs().the_symbol()
				.Name);
			Console.Out.Write(" ::= ");
			for (int i = 0; i < lalr_item2.the_production().rhs_length(); i++)
			{
				if (i == lalr_item2.dot_pos())
				{
					Console.Out.Write("(*) ");
				}
				ProductionPart production_part2 = lalr_item2.the_production().rhs(i);
				if (production_part2.is_action())
				{
					Console.Out.Write("{action} ");
				}
				else
				{
					Console.Out.Write((((SymbolPart)production_part2).the_symbol().Name)+(" "));
				}
			}
			if (lalr_item2.dot_at_end())
			{
				Console.Out.Write("(*) ");
			}
			Console.Out.WriteLine("]");
		}
		Console.Out.WriteLine("}");
	}

	
	public static LalrState build_machine(Production start_prod)
	{
		var stack = new Stack<LalrState>();
		if (start_prod == null)
		{
			
			throw new InternalError("Attempt to build viable prefix recognizer using a null production");
		}
		LalrItemSet lalr_item_set2 = new LalrItemSet();
		LalrItem lalr_item2 = new LalrItem(start_prod);
		lalr_item2.lookahead().Add(Terminal.___003C_003EEOF);
		lalr_item_set2.Add(lalr_item2);
		LalrItemSet key = new LalrItemSet(lalr_item_set2);
		lalr_item_set2.compute_closure();
		LalrState lalr_state2 = new LalrState(lalr_item_set2);
		stack.Push(lalr_state2);
		_all_kernels.Add(key, lalr_state2);
		while (stack.Count>0)
		{
			var lalr_state3 = (LalrState)stack.Pop();
			var symbol_set2 = new SymbolSet();
			foreach(var _lalr_item2 in lalr_state3.items().all())
			{
				_Symbol symbol2 = _lalr_item2.symbol_after_dot();
				if (symbol2 != null)
				{
					symbol_set2.Add(symbol2);
				}
			}
			foreach(var symbol2 in symbol_set2.All())
			{
				LalrItemSet lalr_item_set3 = new LalrItemSet();
				LalrItemSet lalr_item_set4 = new LalrItemSet();
				foreach(var lalr_item2_ in lalr_state3.items().all())
				{
					_Symbol obj = lalr_item2_.symbol_after_dot();
					if (object.ReferenceEquals(symbol2, obj))
					{
						lalr_item_set4.Add(lalr_item2_.shift());
						lalr_item_set3.Add(lalr_item2_);
					}
				}
				key = new LalrItemSet(lalr_item_set4);
				if (!_all_kernels.TryGetValue(key,out var lalr_state4))
				{
					lalr_item_set4.compute_closure();
					lalr_state4 = new LalrState(lalr_item_set4);
					stack.Push(lalr_state4);
					_all_kernels.Add(key, lalr_state4);
				}
				else
				{
					foreach (var lalr_item3 in lalr_item_set3.all())
					{
						var tp = lalr_item3.propagate_items();
						var ts = tp.ToArray();
						for (int i = 0; i < tp.Count; i++)
						{
							LalrItem itm = ts[i];
							LalrItem lalr_item4 = lalr_state4.items().find(itm);
							if (lalr_item4 != null)
							{
                                tp[i]=lalr_item4;
							}
						}
					}
				}
				lalr_state3.add_transition(symbol2, lalr_state4);
			}
		}
		propagate_all_lookaheads();
		return lalr_state2;
	}

	
	public virtual void build_table_entries(ParseActionTable act_table, ParseReduceTable reduce_table)
	{
		TerminalSet terminal_set2 = new TerminalSet();
		ParseActionRow parse_action_row2 = act_table.under_state[Index()];
		ParseReduceRow parse_reduce_row2 = reduce_table.under_state[Index()];
		foreach(var lalr_item2 in items().all())
		{
			if (!lalr_item2.dot_at_end())
			{
				continue;
			}
			ReduceAction reduce_action2 = new ReduceAction(lalr_item2.the_production());
			for (int i = 0; i < Terminal.number(); i++)
			{
				if (!lalr_item2.lookahead().Contains(i))
				{
					continue;
				}
				if (parse_action_row2.under_term[i].Kind== 0)
				{
					parse_action_row2.under_term[i] = reduce_action2;
					continue;
				}
				Terminal terminal2 = Terminal.find(i);
				ParseAction parse_action2 = parse_action_row2.under_term[i];
				if (parse_action2.Kind!= 1 && parse_action2.Kind!= 3)
				{
					if (lalr_item2.the_production().index() < ((ReduceAction)parse_action2).reduce_with().index())
					{
						parse_action_row2.under_term[i] = reduce_action2;
					}
				}
				else if (fix_with_precedence(lalr_item2.the_production(), i, parse_action_row2, reduce_action2))
				{
					terminal2 = null;
				}
				if (terminal2 != null)
				{
					terminal_set2.Add(terminal2);
				}
			}
		}
		for (LalrTransition lalr_transition2 = transitions(); lalr_transition2 != null; lalr_transition2 = lalr_transition2.next())
		{
			_Symbol symbol2 = lalr_transition2.on_symbol();
			if (!symbol2.IsNonTerminal)
			{
				ShiftAction shift_action2 = new ShiftAction(lalr_transition2.to_state());
				if (parse_action_row2.under_term[symbol2.Index].Kind== 0)
				{
					parse_action_row2.under_term[symbol2.Index] = shift_action2;
				}
				else
				{
					Production p = ((ReduceAction)parse_action_row2.under_term[symbol2.Index]).reduce_with();
					if (!fix_with_precedence(p, symbol2.Index, parse_action_row2, shift_action2))
					{
						parse_action_row2.under_term[symbol2.Index] = shift_action2;
						terminal_set2.Add(Terminal.find(symbol2.Index));
					}
				}
			}
			else
			{
				parse_reduce_row2.under_non_term[symbol2.Index] = lalr_transition2.to_state();
			}
		}
		if (!terminal_set2.IsEmpty)
		{
			report_conflicts(terminal_set2);
		}
	}

	
	
	public override bool Equals(object other)
	{
		if (!(other is LalrState))
		{
			return false;
		}
		bool result = Equals((LalrState)other);
		
		return result;
	}

	
	
	public override int GetHashCode()
	{
		int result = items().GetHashCode();
		
		return result;
	}

	
	
	public override string ToString()
	{
		string text = ("lalr_state [")+(Index())+("]: ")
			+(_items)
			+("\n")
			;
		for (LalrTransition lalr_transition2 = transitions(); lalr_transition2 != null; lalr_transition2 = lalr_transition2.next())
		{
			text = (text)+(lalr_transition2);
			text = (text)+("\n");
		}
		return text;
	}

	
	static LalrState()
	{
		_all = new ();
		_all_kernels = new ();
		next_index = 0;
	}
}
