




using System.Collections.Generic;

namespace JavaCUP;

public class lalr_item : lr_item_core
{
	protected internal terminal_set _lookahead;

	protected internal Stack<terminal_set> _propagate_items;

	protected internal bool needs_propagation;

	
	public lalr_item(production prod, int pos, terminal_set look)
		: base(prod, pos)
	{
		_lookahead = look;
		_propagate_items = new ();
		needs_propagation = true;
	}

	public virtual terminal_set lookahead()
	{
		return _lookahead;
	}

	public virtual Stack<terminal_set> propagate_items()
	{
		return _propagate_items;
	}

	
	public virtual void propagate_lookaheads(terminal_set incoming)
	{
		int num = 0;
		if (!needs_propagation && (incoming == null || incoming.IsEmpty))
		{
			return;
		}
		if (incoming != null)
		{
			num = (lookahead().Add(incoming) ? 1 : 0);
		}
		if (num != 0 || needs_propagation)
		{
			needs_propagation = false;
			for (int i = 0; i < propagate_items().Count; i++)
			{
				((lalr_item)propagate_items()[i]).propagate_lookaheads(lookahead());
			}
		}
	}

	
	
	public virtual void add_propagate(lalr_item prop_to)
	{
		_propagate_items.push(prop_to);
		needs_propagation = true;
	}

	
	
	public virtual bool Equals(lalr_item other)
	{
		if (other == null)
		{
			return false;
		}
		bool result = base.Equals(other);
		
		return result;
	}

	
	
	
	public lalr_item(production prod, terminal_set look)
		: this(prod, 0, look)
	{
	}

	
	
	
	public lalr_item(production prod)
		: this(prod, 0, new terminal_set())
	{
	}

	
	
	
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
					terminal_set2.Add((terminal)symbol2);
					return terminal_set2;
				}
				terminal_set2.Add(((non_terminal)symbol2).first_set());
				if (!((non_terminal)symbol2).nullable())
				{
					return terminal_set2;
				}
			}
		}
		terminal_set2.Add(lookahead_after);
		return terminal_set2;
	}

	
	
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

	
	
	public override bool Equals(object other)
	{
		if (!(other is lalr_item))
		{
			return false;
		}
		bool result = Equals((lalr_item)other);
		
		return result;
	}

	
	
	public override int GetHashCode()
	{
		int result = base.GetHashCode();
		
		return result;
	}

	
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
				if (lookahead().Contains(i))
				{
					str = (str)+(terminal.find(i).name())+(" ")
						;
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
