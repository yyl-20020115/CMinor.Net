




namespace java_cup;

public class lalr_item : lr_item_core
{
	protected internal terminal_set _lookahead;

	protected internal Stack _propagate_items;

	protected internal bool needs_propagation;

	
	[Throws(new string[] { "java_cup.internal_error" })]
	
	public lalr_item(production prod, int pos, terminal_set look)
		: base(prod, pos)
	{
		_lookahead = look;
		_propagate_items = new Stack();
		needs_propagation = true;
	}

	public virtual terminal_set lookahead()
	{
		return _lookahead;
	}

	public virtual Stack propagate_items()
	{
		return _propagate_items;
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	[LineNumberTable(new byte[]
	{
		67, 162, 115, 161, 163, 205, 171, 167, 112, 60,
		198
	})]
	public virtual void propagate_lookaheads(terminal_set incoming)
	{
		int num = 0;
		if (!needs_propagation && (incoming == null || incoming.empty()))
		{
			return;
		}
		if (incoming != null)
		{
			num = (lookahead().add(incoming) ? 1 : 0);
		}
		if (num != 0 || needs_propagation)
		{
			needs_propagation = false;
			for (int i = 0; i < propagate_items().size(); i++)
			{
				((lalr_item)propagate_items().elementAt(i)).propagate_lookaheads(lookahead());
			}
		}
	}

	
	
	public virtual void add_propagate(lalr_item prop_to)
	{
		_propagate_items.push(prop_to);
		needs_propagation = true;
	}

	
	
	public virtual bool equals(lalr_item other)
	{
		if (other == null)
		{
			return false;
		}
		bool result = base.equals(other);
		
		return result;
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	
	public lalr_item(production prod, terminal_set look)
		: this(prod, 0, look)
	{
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	
	public lalr_item(production prod)
		: this(prod, 0, new terminal_set())
	{
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	
	public virtual lalr_item shift()
	{
		if (dot_at_end())
		{
			
			throw new internal_error("Attempt to shift past end of an lalr_item");
		}
		production prod = the_production();
		int pos = dot_pos() + 1;
		lalr_item lalr_item2 = new lalr_item(prod, pos, new terminal_set(lookahead()));
		add_propagate(lalr_item2);
		return lalr_item2;
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	[LineNumberTable(new byte[]
	{
		160, 68, 104, 208, 166, 154, 173, 136, 172, 136,
		109, 226, 69, 178, 109, 226, 42, 233, 93, 104
	})]
	public virtual terminal_set calc_lookahead(terminal_set lookahead_after)
	{
		if (dot_at_end())
		{
			
			throw new internal_error("Attempt to calculate a lookahead set with a completed item");
		}
		terminal_set terminal_set2 = new terminal_set();
		for (int i = dot_pos() + 1; i < the_production().rhs_length(); i++)
		{
			production_part production_part2 = the_production().rhs(i);
			if (!production_part2.is_action())
			{
				symbol symbol2 = ((symbol_part)production_part2).the_symbol();
				if (!symbol2.is_non_term())
				{
					terminal_set2.add((terminal)symbol2);
					return terminal_set2;
				}
				terminal_set2.add(((non_terminal)symbol2).first_set());
				if (!((non_terminal)symbol2).nullable())
				{
					return terminal_set2;
				}
			}
		}
		terminal_set2.add(lookahead_after);
		return terminal_set2;
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	[LineNumberTable(new byte[]
	{
		160, 125, 170, 151, 173, 136, 172, 170, 239, 51,
		230, 82
	})]
	public virtual bool lookahead_visible()
	{
		if (dot_at_end())
		{
			return true;
		}
		for (int i = dot_pos() + 1; i < the_production().rhs_length(); i++)
		{
			production_part production_part2 = the_production().rhs(i);
			if (!production_part2.is_action())
			{
				symbol symbol2 = ((symbol_part)production_part2).the_symbol();
				if (!symbol2.is_non_term())
				{
					return false;
				}
				if (!((non_terminal)symbol2).nullable())
				{
					return false;
				}
			}
		}
		return true;
	}

	
	
	public override bool equals(object other)
	{
		if (!(other is lalr_item))
		{
			return false;
		}
		bool result = equals((lalr_item)other);
		
		return result;
	}

	
	
	public override int hashCode()
	{
		int result = base.hashCode();
		
		return result;
	}

	
	[LineNumberTable(new byte[]
	{
		160, 187, 198, 123, 124, 123, 139, 123, 106, 110,
		31, 12, 166, 189, 123, 251, 73
	})]
	public override string ToString()
	{
		string str = "";
		str = (str)+("[");
		str = (str)+(base.ToString());
		str = (str)+(", ");
		if (lookahead() != null)
		{
			str = (str)+("{");
			for (int i = 0; i < terminal.number(); i++)
			{
				if (lookahead().contains(i))
				{
					str = (str)+(terminal.find(i).name())+(" ")
						.ToString();
				}
			}
			str = (str)+("}");
		}
		else
		{
			str = (str)+("NULL LOOKAHEAD!!");
		}
		return (str)+("]");
	}
}
