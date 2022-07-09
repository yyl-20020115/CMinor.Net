using System;
using System.Collections.Generic;

namespace JavaCUP;

public class lalr_state
{
	protected internal static Dictionary<lalr_item_set, lalr_state> _all = new();

	protected internal static Dictionary<lalr_item_set, lalr_state> _all_kernels = new();

	protected internal static int next_index;

	protected internal lalr_item_set _items;

	protected internal lalr_transition _transitions;

	protected internal int _index;

	
	
	public static void ___003Cclinit_003E()
	{
	}

	public virtual int index()
	{
		return _index;
	}

	
	
	public static lalr_state find_state(lalr_item_set itms)
	{
		if (itms == null)
		{
			return null;
		}
		return (lalr_state)_all.get(itms);
	}

	public virtual lalr_item_set items()
	{
		return _items;
	}

	
	
	public static IEnumerable<lalr_state> all()
	{
		return _all.Values;
	}

	
	
	
	protected internal virtual void propagate_lookaheads()
	{
		Enumeration enumeration = items().all();
		while (enumeration.hasMoreElements())
		{
			((lalr_item)enumeration.nextElement()).propagate_lookaheads(null);
		}
	}

	
	
	public lalr_state(lalr_item_set itms)
	{
		_transitions = null;
		if (itms == null)
		{
			
			throw new internal_error("Attempt to construct an LALR state from a null item set");
		}
		if (find_state(itms) != null)
		{
			
			throw new internal_error("Attempt to construct a duplicate LALR state");
		}
		_index = next_index++;
		_items = itms;
		_all.Add(_items, this);
	}

	
	
	
	public virtual void add_transition(_Symbol on_sym, lalr_state to_st)
	{
		lalr_transition lalr_transition2 = (_transitions = new lalr_transition(on_sym, to_st, _transitions));
	}

	
	
	
	protected internal static void propagate_all_lookaheads()
	{
		Enumeration enumeration = all();
		while (enumeration.hasMoreElements())
		{
			((lalr_state)enumeration.nextElement()).propagate_lookaheads();
		}
	}

	
	
	protected internal virtual bool fix_with_precedence(production p, int term_index, parse_action_row table_row, parse_action act)
	{
		terminal terminal2 = terminal.find(term_index);
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
				table_row.under_term[term_index] = new nonassoc_action();
				return true;
			}
			
			throw new internal_error("Unable to resolve conflict correctly");
		}
		if (terminal2.precedence_num() > -1)
		{
			table_row.under_term[term_index] = insert_shift(table_row.under_term[term_index], act);
			return true;
		}
		return false;
	}

	public virtual lalr_transition transitions()
	{
		return _transitions;
	}

	protected internal virtual void report_conflicts(terminal_set conflict_set)
	{
		Enumeration enumeration = items().all();
		while (enumeration.hasMoreElements())
		{
			lalr_item lalr_item2 = (lalr_item)enumeration.nextElement();
			if (!lalr_item2.dot_at_end())
			{
				continue;
			}
			int num = 0;
			Enumeration enumeration2 = items().all();
			while (enumeration2.hasMoreElements())
			{
				lalr_item lalr_item3 = (lalr_item)enumeration2.nextElement();
				if (lalr_item2 == lalr_item3)
				{
					num = 1;
				}
				if (lalr_item2 != lalr_item3 && lalr_item3.dot_at_end() && num != 0 && lalr_item3.lookahead().InterestWith(lalr_item2.lookahead()))
				{
					report_reduce_reduce(lalr_item2, lalr_item3);
				}
			}
			for (int i = 0; i < terminal.number(); i++)
			{
				if (conflict_set.Contains(i))
				{
					report_shift_reduce(lalr_item2, i);
				}
			}
		}
	}

	
	
	
	protected internal virtual parse_action insert_reduce(parse_action a1, parse_action a2)
	{
		parse_action result = insert_action(a1, a2, 2);
		
		return result;
	}

	
	
	
	protected internal virtual parse_action insert_shift(parse_action a1, parse_action a2)
	{
		parse_action result = insert_action(a1, a2, 1);
		
		return result;
	}

	
	
	
	protected internal virtual parse_action insert_action(parse_action a1, parse_action a2, int act_type)
	{
		if (a1.kind() == act_type && a2.kind() == act_type)
		{
			
			throw new internal_error("Conflict resolution of bogus actions");
		}
		if (a1.kind() == act_type)
		{
			return a1;
		}
		if (a2.kind() == act_type)
		{
			return a2;
		}
		
		throw new internal_error("Conflict resolution of bogus actions");
	}

	protected internal virtual void report_reduce_reduce(lalr_item itm1, lalr_item itm2)
	{
		int num = 0;
		Console.Error.WriteLine(("*** Reduce/Reduce conflict found in state #")+(index()));
		Console.Error.Write("  between ");
		Console.Error.WriteLine(itm1.to_simple_string());
		Console.Error.Write("  and     ");
		Console.Error.WriteLine(itm2.to_simple_string());
		Console.Error.Write("  under symbols: {");
		for (int i = 0; i < terminal.number(); i++)
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
				Console.Error.Write(terminal.find(i).Name);
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
		lexer.warning_count++;
	}

	
	protected internal virtual void report_shift_reduce(lalr_item red_itm, int conflict_sym)
	{
		Console.Error.WriteLine(("*** Shift/Reduce conflict found in state #")+(index()));
		Console.Error.Write("  between ");
		Console.Error.WriteLine(red_itm.to_simple_string());
		Enumeration enumeration = items().all();
		while (enumeration.hasMoreElements())
		{
			lalr_item lalr_item2 = (lalr_item)enumeration.nextElement();
			if (lalr_item2 != red_itm && !lalr_item2.dot_at_end())
			{
				_Symbol symbol2 = lalr_item2.symbol_after_dot();
				if (!symbol2.IsNonTerminal&& symbol2.Index== conflict_sym)
				{
					Console.Error.WriteLine(("  and     ")+(lalr_item2.to_simple_string()));
				}
			}
		}
		Console.Error.WriteLine(("  under symbol ")+(terminal.find(conflict_sym).Name));
		Console.Error.WriteLine("  Resolved in favor of shifting.\n");
		emit.num_conflicts++;
		lexer.warning_count++;
	}

	
	
	public virtual bool Equals(lalr_state other)
	{
		return (other != null && items().Equals(other.items())) ? true : false;
	}

	
	
	public static int number()
	{
		int result = _all.Count;
		
		return result;
	}

	
	
	protected internal static void dump_state(lalr_state st)
	{
		if (st == null)
		{
			Console.Out.WriteLine("NULL lalr_state");
			return;
		}
		Console.Out.WriteLine(("lalr_state [")+(st.index())+("] {")
			);
		lalr_item_set lalr_item_set2 = st.items();
		Enumeration enumeration = lalr_item_set2.all();
		while (enumeration.hasMoreElements())
		{
			lalr_item lalr_item2 = (lalr_item)enumeration.nextElement();
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
				production_part production_part2 = lalr_item2.the_production().rhs(i);
				if (production_part2.is_action())
				{
					Console.Out.Write("{action} ");
				}
				else
				{
					Console.Out.Write((((symbol_part)production_part2).the_symbol().Name)+(" "));
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

	
	public static lalr_state build_machine(production start_prod)
	{
		Stack stack = new Stack();
		if (start_prod == null)
		{
			
			throw new internal_error("Attempt to build viable prefix recognizer using a null production");
		}
		lalr_item_set lalr_item_set2 = new lalr_item_set();
		lalr_item lalr_item2 = new lalr_item(start_prod);
		lalr_item2.lookahead().Add(terminal.___003C_003EEOF);
		lalr_item_set2.Add(lalr_item2);
		lalr_item_set key = new lalr_item_set(lalr_item_set2);
		lalr_item_set2.compute_closure();
		lalr_state lalr_state2 = new lalr_state(lalr_item_set2);
		stack.Push(lalr_state2);
		_all_kernels.Add(key, lalr_state2);
		while (!stack.empty())
		{
			lalr_state lalr_state3 = (lalr_state)stack.Pop();
			symbol_set symbol_set2 = new symbol_set();
			Enumeration enumeration = lalr_state3.items().all();
			while (enumeration.hasMoreElements())
			{
				lalr_item2 = (lalr_item)enumeration.nextElement();
				_Symbol symbol2 = lalr_item2.symbol_after_dot();
				if (symbol2 != null)
				{
					symbol_set2.Add(symbol2);
				}
			}
			Enumeration enumeration2 = symbol_set2.all();
			while (enumeration2.hasMoreElements())
			{
				_Symbol symbol2 = (_Symbol)enumeration2.nextElement();
				lalr_item_set lalr_item_set3 = new lalr_item_set();
				lalr_item_set lalr_item_set4 = new lalr_item_set();
				enumeration = lalr_state3.items().all();
				while (enumeration.hasMoreElements())
				{
					lalr_item2 = (lalr_item)enumeration.nextElement();
					_Symbol obj = lalr_item2.symbol_after_dot();
					if (Object.instancehelper_equals(symbol2, obj))
					{
						lalr_item_set4.Add(lalr_item2.shift());
						lalr_item_set3.Add(lalr_item2);
					}
				}
				key = new lalr_item_set(lalr_item_set4);
				lalr_state lalr_state4 = (lalr_state)_all_kernels.get(key);
				if (lalr_state4 == null)
				{
					lalr_item_set4.compute_closure();
					lalr_state4 = new lalr_state(lalr_item_set4);
					stack.Push(lalr_state4);
					_all_kernels.Add(key, lalr_state4);
				}
				else
				{
					Enumeration enumeration3 = lalr_item_set3.all();
					while (enumeration3.hasMoreElements())
					{
						lalr_item lalr_item3 = (lalr_item)enumeration3.nextElement();
						for (int i = 0; i < lalr_item3.propagate_items().Count; i++)
						{
							lalr_item itm = (lalr_item)lalr_item3.propagate_items()[i];
							lalr_item lalr_item4 = lalr_state4.items().find(itm);
							if (lalr_item4 != null)
							{
								lalr_item3.propagate_items().setElementAt(lalr_item4, i);
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

	
	public virtual void build_table_entries(parse_action_table act_table, parse_reduce_table reduce_table)
	{
		terminal_set terminal_set2 = new terminal_set();
		parse_action_row parse_action_row2 = act_table.under_state[index()];
		parse_reduce_row parse_reduce_row2 = reduce_table.under_state[index()];
		Enumeration enumeration = items().all();
		while (enumeration.hasMoreElements())
		{
			lalr_item lalr_item2 = (lalr_item)enumeration.nextElement();
			if (!lalr_item2.dot_at_end())
			{
				continue;
			}
			reduce_action reduce_action2 = new reduce_action(lalr_item2.the_production());
			for (int i = 0; i < terminal.number(); i++)
			{
				if (!lalr_item2.lookahead().Contains(i))
				{
					continue;
				}
				if (parse_action_row2.under_term[i].kind() == 0)
				{
					parse_action_row2.under_term[i] = reduce_action2;
					continue;
				}
				terminal terminal2 = terminal.find(i);
				parse_action parse_action2 = parse_action_row2.under_term[i];
				if (parse_action2.kind() != 1 && parse_action2.kind() != 3)
				{
					if (lalr_item2.the_production().index() < ((reduce_action)parse_action2).reduce_with().index())
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
		for (lalr_transition lalr_transition2 = transitions(); lalr_transition2 != null; lalr_transition2 = lalr_transition2.next())
		{
			_Symbol symbol2 = lalr_transition2.on_symbol();
			if (!symbol2.IsNonTerminal)
			{
				shift_action shift_action2 = new shift_action(lalr_transition2.to_state());
				if (parse_action_row2.under_term[symbol2.Index].kind() == 0)
				{
					parse_action_row2.under_term[symbol2.Index] = shift_action2;
				}
				else
				{
					production p = ((reduce_action)parse_action_row2.under_term[symbol2.Index]).reduce_with();
					if (!fix_with_precedence(p, symbol2.Index, parse_action_row2, shift_action2))
					{
						parse_action_row2.under_term[symbol2.Index] = shift_action2;
						terminal_set2.Add(terminal.find(symbol2.Index));
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
		if (!(other is lalr_state))
		{
			return false;
		}
		bool result = Equals((lalr_state)other);
		
		return result;
	}

	
	
	public override int GetHashCode()
	{
		int result = items().GetHashCode();
		
		return result;
	}

	
	
	public override string ToString()
	{
		string text = ("lalr_state [")+(index())+("]: ")
			+(_items)
			+("\n")
			;
		for (lalr_transition lalr_transition2 = transitions(); lalr_transition2 != null; lalr_transition2 = lalr_transition2.next())
		{
			text = (text)+(lalr_transition2);
			text = (text)+("\n");
		}
		return text;
	}

	
	static lalr_state()
	{
		_all = new ();
		_all_kernels = new ();
		next_index = 0;
	}
}
