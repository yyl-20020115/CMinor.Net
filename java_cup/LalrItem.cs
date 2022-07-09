




using System.Collections.Generic;

namespace JavaCUP;

public class LalrItem : LRItemCore
{
	protected internal TerminalSet _lookahead;

	protected internal Stack<LalrItem> _propagate_items = new();

	protected internal bool needs_propagation;

	
	public LalrItem(Production prod, int pos, TerminalSet look)
		: base(prod, pos)
	{
		_lookahead = look;
		_propagate_items = new ();
		needs_propagation = true;
	}

	public virtual TerminalSet lookahead()
	{
		return _lookahead;
	}

	public virtual Stack<LalrItem> propagate_items()
	{
		return _propagate_items;
	}

	
	public virtual void propagate_lookaheads(TerminalSet incoming)
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
			var lt = propagate_items().ToArray();
			needs_propagation = false;
			for (int i = 0; i < lt.Length; i++)
			{
				lt[i].propagate_lookaheads(lookahead());
			}
		}
	}

	
	
	public virtual void add_propagate(LalrItem prop_to)
	{
		_propagate_items.Push(prop_to);
		needs_propagation = true;
	}

	
	
	public virtual bool Equals(LalrItem other)
	{
		if (other == null)
		{
			return false;
		}
		bool result = base.Equals(other);
		
		return result;
	}

	
	
	
	public LalrItem(Production prod, TerminalSet look)
		: this(prod, 0, look)
	{
	}

	
	
	
	public LalrItem(Production prod)
		: this(prod, 0, new TerminalSet())
	{
	}

	
	
	
	public virtual LalrItem shift()
	{
		if (dot_at_end())
		{
			
			throw new InternalError("Attempt to shift past end of an lalr_item");
		}
		Production prod = the_production();
		int pos = dot_pos() + 1;
		LalrItem lalr_item2 = new LalrItem(prod, pos, new TerminalSet(lookahead()));
		add_propagate(lalr_item2);
		return lalr_item2;
	}

	
	
	public virtual TerminalSet calc_lookahead(TerminalSet lookahead_after)
	{
		if (dot_at_end())
		{
			
			throw new InternalError("Attempt to calculate a lookahead set with a completed item");
		}
		TerminalSet terminal_set2 = new TerminalSet();
		for (int i = dot_pos() + 1; i < the_production().rhs_length(); i++)
		{
			ProductionPart production_part2 = the_production().rhs(i);
			if (!production_part2.is_action())
			{
				_Symbol symbol2 = ((SymbolPart)production_part2).the_symbol();
				if (!symbol2.IsNonTerminal)
				{
					terminal_set2.Add((Terminal)symbol2);
					return terminal_set2;
				}
				terminal_set2.Add(((NonTerminal)symbol2).first_set());
				if (!((NonTerminal)symbol2).nullable())
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
			ProductionPart production_part2 = the_production().rhs(i);
			if (!production_part2.is_action())
			{
				_Symbol symbol2 = ((SymbolPart)production_part2).the_symbol();
				if (!symbol2.IsNonTerminal)
				{
					return false;
				}
				if (!((NonTerminal)symbol2).nullable())
				{
					return false;
				}
			}
		}
		return true;
	}

	
	
	public override bool Equals(object other)
	{
		if (!(other is LalrItem))
		{
			return false;
		}
		bool result = Equals((LalrItem)other);
		
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
			for (int i = 0; i < Terminal.number(); i++)
			{
				if (lookahead().Contains(i))
				{
					str = (str)+(Terminal.find(i).Name)+(" ")
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
