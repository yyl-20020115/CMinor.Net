

using java.lang;


namespace java_cup;

public class lalr_state
{
	protected internal static Hashtable _all;

	protected internal static Hashtable _all_kernels;

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

	
	
	public static Enumeration all()
	{
		Enumeration result = _all.elements();
		
		return result;
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	
	protected internal virtual void propagate_lookaheads()
	{
		Enumeration enumeration = items().all();
		while (enumeration.hasMoreElements())
		{
			((lalr_item)enumeration.nextElement()).propagate_lookaheads(null);
		}
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	[LineNumberTable(new byte[]
	{
		11, 232, 160, 78, 231, 159, 180, 99, 176, 104,
		208, 179, 167, 114
	})]
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
		_all.put(_items, this);
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	
	public virtual void add_transition(symbol on_sym, lalr_state to_st)
	{
		lalr_transition lalr_transition2 = (_transitions = new lalr_transition(on_sym, to_st, _transitions));
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	
	protected internal static void propagate_all_lookaheads()
	{
		Enumeration enumeration = all();
		while (enumeration.hasMoreElements())
		{
			((lalr_state)enumeration.nextElement()).propagate_lookaheads();
		}
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	[LineNumberTable(new byte[]
	{
		161, 222, 167, 172, 110, 152, 194, 110, 152, 226,
		70, 105, 152, 194, 104, 152, 226, 69, 105, 109,
		162, 240, 70, 105, 152, 226, 69
	})]
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

	
	[Throws(new string[] { "java_cup.internal_error" })]
	[LineNumberTable(new byte[]
	{
		162, 81, 151, 236, 69, 168, 162, 148, 173, 167,
		165, 169, 131, 148, 238, 69, 108, 106, 9, 237,
		69
	})]
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
				if (lalr_item2 != lalr_item3 && lalr_item3.dot_at_end() && num != 0 && lalr_item3.lookahead().intersects(lalr_item2.lookahead()))
				{
					report_reduce_reduce(lalr_item2, lalr_item3);
				}
			}
			for (int i = 0; i < terminal.number(); i++)
			{
				if (conflict_set.contains(i))
				{
					report_shift_reduce(lalr_item2, i);
				}
			}
		}
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	
	protected internal virtual parse_action insert_reduce(parse_action a1, parse_action a2)
	{
		parse_action result = insert_action(a1, a2, 2);
		
		return result;
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	
	protected internal virtual parse_action insert_shift(parse_action a1, parse_action a2)
	{
		parse_action result = insert_action(a1, a2, 1);
		
		return result;
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	
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

	
	[Throws(new string[] { "java_cup.internal_error" })]
	[LineNumberTable(new byte[]
	{
		162, 134, 130, 127, 10, 111, 112, 111, 112, 111,
		138, 156, 118, 245, 59, 230, 72, 111, 111, 120,
		145, 175, 108, 108
	})]
	protected internal virtual void report_reduce_reduce(lalr_item itm1, lalr_item itm2)
	{
		int num = 0;
		java.lang.System.err.println(new StringBuilder().append("*** Reduce/Reduce conflict found in state #").append(index()).toString());
		java.lang.System.err.print("  between ");
		java.lang.System.err.println(itm1.to_simple_string());
		java.lang.System.err.print("  and     ");
		java.lang.System.err.println(itm2.to_simple_string());
		java.lang.System.err.print("  under symbols: {");
		for (int i = 0; i < terminal.number(); i++)
		{
			if (itm1.lookahead().contains(i) && itm2.lookahead().contains(i))
			{
				if (num != 0)
				{
					java.lang.System.err.print(", ");
				}
				else
				{
					num = 1;
				}
				java.lang.System.err.print(terminal.find(i).name());
			}
		}
		java.lang.System.err.println("}");
		java.lang.System.err.print("  Resolved in favor of ");
		if (itm1.the_production().index() < itm2.the_production().index())
		{
			java.lang.System.err.println("the first production.\n");
		}
		else
		{
			java.lang.System.err.println("the second production.\n");
		}
		emit.num_conflicts++;
		lexer.warning_count++;
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	[LineNumberTable(new byte[]
	{
		162, 178, 127, 10, 111, 176, 151, 172, 172, 103,
		177, 223, 15, 127, 15, 175, 108, 108
	})]
	protected internal virtual void report_shift_reduce(lalr_item red_itm, int conflict_sym)
	{
		java.lang.System.err.println(new StringBuilder().append("*** Shift/Reduce conflict found in state #").append(index()).toString());
		java.lang.System.err.print("  between ");
		java.lang.System.err.println(red_itm.to_simple_string());
		Enumeration enumeration = items().all();
		while (enumeration.hasMoreElements())
		{
			lalr_item lalr_item2 = (lalr_item)enumeration.nextElement();
			if (lalr_item2 != red_itm && !lalr_item2.dot_at_end())
			{
				symbol symbol2 = lalr_item2.symbol_after_dot();
				if (!symbol2.is_non_term() && symbol2.index() == conflict_sym)
				{
					java.lang.System.err.println(new StringBuilder().append("  and     ").append(lalr_item2.to_simple_string()).toString());
				}
			}
		}
		java.lang.System.err.println(new StringBuilder().append("  under symbol ").append(terminal.find(conflict_sym).name()).toString());
		java.lang.System.err.println("  Resolved in favor of shifting.\n");
		emit.num_conflicts++;
		lexer.warning_count++;
	}

	
	
	public virtual bool equals(lalr_state other)
	{
		return (other != null && items().equals(other.items())) ? true : false;
	}

	
	
	public static int number()
	{
		int result = _all.size();
		
		return result;
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	[LineNumberTable(new byte[]
	{
		115,
		131,
		113,
		161,
		127,
		20,
		103,
		146,
		108,
		111,
		127,
		0,
		111,
		147,
		120,
		110,
		105,
		145,
		byte.MaxValue,
		21,
		57,
		233,
		73,
		119,
		148,
		113
	})]
	protected internal static void dump_state(lalr_state st)
	{
		if (st == null)
		{
			java.lang.System.@out.println("NULL lalr_state");
			return;
		}
		java.lang.System.@out.println(new StringBuilder().append("lalr_state [").append(st.index()).append("] {")
			.toString());
		lalr_item_set lalr_item_set2 = st.items();
		Enumeration enumeration = lalr_item_set2.all();
		while (enumeration.hasMoreElements())
		{
			lalr_item lalr_item2 = (lalr_item)enumeration.nextElement();
			java.lang.System.@out.print("  [");
			java.lang.System.@out.print(lalr_item2.the_production().lhs().the_symbol()
				.name());
			java.lang.System.@out.print(" ::= ");
			for (int i = 0; i < lalr_item2.the_production().rhs_length(); i++)
			{
				if (i == lalr_item2.dot_pos())
				{
					java.lang.System.@out.print("(*) ");
				}
				production_part production_part2 = lalr_item2.the_production().rhs(i);
				if (production_part2.is_action())
				{
					java.lang.System.@out.print("{action} ");
				}
				else
				{
					java.lang.System.@out.print(new StringBuilder().append(((symbol_part)production_part2).the_symbol().name()).append(" ").toString());
				}
			}
			if (lalr_item2.dot_at_end())
			{
				java.lang.System.@out.print("(*) ");
			}
			java.lang.System.@out.println("]");
		}
		java.lang.System.@out.println("}");
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	[LineNumberTable(new byte[]
	{
		160, 165, 230, 72, 99, 208, 134, 103, 145, 168,
		167, 166, 104, 169, 174, 171, 173, 103, 151, 173,
		104, 208, 149, 174, 199, 103, 151, 173, 104, 171,
		174, 235, 69, 168, 178, 164, 167, 169, 169, 243,
		70, 149, 174, 179, 213, 176, 100, 240, 53, 237,
		81, 240, 71, 133
	})]
	public static lalr_state build_machine(production start_prod)
	{
		Stack stack = new Stack();
		if (start_prod == null)
		{
			
			throw new internal_error("Attempt to build viable prefix recognizer using a null production");
		}
		lalr_item_set lalr_item_set2 = new lalr_item_set();
		lalr_item lalr_item2 = new lalr_item(start_prod);
		lalr_item2.lookahead().add(terminal.___003C_003EEOF);
		lalr_item_set2.add(lalr_item2);
		lalr_item_set key = new lalr_item_set(lalr_item_set2);
		lalr_item_set2.compute_closure();
		lalr_state lalr_state2 = new lalr_state(lalr_item_set2);
		stack.push(lalr_state2);
		_all_kernels.put(key, lalr_state2);
		while (!stack.empty())
		{
			lalr_state lalr_state3 = (lalr_state)stack.pop();
			symbol_set symbol_set2 = new symbol_set();
			Enumeration enumeration = lalr_state3.items().all();
			while (enumeration.hasMoreElements())
			{
				lalr_item2 = (lalr_item)enumeration.nextElement();
				symbol symbol2 = lalr_item2.symbol_after_dot();
				if (symbol2 != null)
				{
					symbol_set2.add(symbol2);
				}
			}
			Enumeration enumeration2 = symbol_set2.all();
			while (enumeration2.hasMoreElements())
			{
				symbol symbol2 = (symbol)enumeration2.nextElement();
				lalr_item_set lalr_item_set3 = new lalr_item_set();
				lalr_item_set lalr_item_set4 = new lalr_item_set();
				enumeration = lalr_state3.items().all();
				while (enumeration.hasMoreElements())
				{
					lalr_item2 = (lalr_item)enumeration.nextElement();
					symbol obj = lalr_item2.symbol_after_dot();
					if (Object.instancehelper_equals(symbol2, obj))
					{
						lalr_item_set4.add(lalr_item2.shift());
						lalr_item_set3.add(lalr_item2);
					}
				}
				key = new lalr_item_set(lalr_item_set4);
				lalr_state lalr_state4 = (lalr_state)_all_kernels.get(key);
				if (lalr_state4 == null)
				{
					lalr_item_set4.compute_closure();
					lalr_state4 = new lalr_state(lalr_item_set4);
					stack.push(lalr_state4);
					_all_kernels.put(key, lalr_state4);
				}
				else
				{
					Enumeration enumeration3 = lalr_item_set3.all();
					while (enumeration3.hasMoreElements())
					{
						lalr_item lalr_item3 = (lalr_item)enumeration3.nextElement();
						for (int i = 0; i < lalr_item3.propagate_items().size(); i++)
						{
							lalr_item itm = (lalr_item)lalr_item3.propagate_items().elementAt(i);
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

	
	[Throws(new string[] { "java_cup.internal_error" })]
	[LineNumberTable(new byte[]
	{
		161, 91, 166, 110, 174, 151, 205, 137, 174, 175,
		181, 176, 240, 69, 105, 171, 212, 223, 0, 205,
		148, 163, 132, 233, 27, 240, 109, 175, 105, 140,
		174, 181, 245, 69, 186, 116, 112, 147, 226, 69,
		245, 35, 238, 98, 104, 105
	})]
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
				if (!lalr_item2.lookahead().contains(i))
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
					terminal_set2.add(terminal2);
				}
			}
		}
		for (lalr_transition lalr_transition2 = transitions(); lalr_transition2 != null; lalr_transition2 = lalr_transition2.next())
		{
			symbol symbol2 = lalr_transition2.on_symbol();
			if (!symbol2.is_non_term())
			{
				shift_action shift_action2 = new shift_action(lalr_transition2.to_state());
				if (parse_action_row2.under_term[symbol2.index()].kind() == 0)
				{
					parse_action_row2.under_term[symbol2.index()] = shift_action2;
				}
				else
				{
					production p = ((reduce_action)parse_action_row2.under_term[symbol2.index()]).reduce_with();
					if (!fix_with_precedence(p, symbol2.index(), parse_action_row2, shift_action2))
					{
						parse_action_row2.under_term[symbol2.index()] = shift_action2;
						terminal_set2.add(terminal.find(symbol2.index()));
					}
				}
			}
			else
			{
				parse_reduce_row2.under_non_term[symbol2.index()] = lalr_transition2.to_state();
			}
		}
		if (!terminal_set2.empty())
		{
			report_conflicts(terminal_set2);
		}
	}

	
	
	public override bool equals(object other)
	{
		if (!(other is lalr_state))
		{
			return false;
		}
		bool result = equals((lalr_state)other);
		
		return result;
	}

	
	
	public override int hashCode()
	{
		int result = items().hashCode();
		
		return result;
	}

	
	
	public override string toString()
	{
		string text = new StringBuilder().append("lalr_state [").append(index()).append("]: ")
			.append(_items)
			.append("\n")
			.toString();
		for (lalr_transition lalr_transition2 = transitions(); lalr_transition2 != null; lalr_transition2 = lalr_transition2.next())
		{
			text = new StringBuilder().append(text).append(lalr_transition2).toString();
			text = new StringBuilder().append(text).append("\n").toString();
		}
		return text;
	}

	
	static lalr_state()
	{
		_all = new Hashtable();
		_all_kernels = new Hashtable();
		next_index = 0;
	}
}
