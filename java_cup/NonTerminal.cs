using System.Collections.Generic;

namespace JavaCUP;

public class NonTerminal : _Symbol
{
	protected internal static Dictionary<string, NonTerminal> _all = new();

	protected internal static Dictionary<int,NonTerminal> _all_by_index = new();

	protected internal static int next_index;

	protected internal static int next_nt;

	internal static NonTerminal _START_SYMBOL;

	public bool is_embedded_action;

	protected internal Dictionary<Production, Production> _productions = new();

	protected internal bool _nullable;

	protected internal TerminalSet _first_set;

	
	public static NonTerminal START_nt
	{
		
		get
		{
			return _START_SYMBOL;
		}
	}

	public virtual void add_production(Production prod)
	{
		if (prod == null || prod.lhs() == null || prod.lhs().the_symbol() != this)
		{
			
			throw new InternalError("Attempt to add invalid production to non terminal production table");
		}
		_productions.Add(prod, prod);
	}

	
	
	
	internal static NonTerminal create_new()
	{
		NonTerminal result = create_new(null);
		
		return result;
	}

	public virtual bool nullable()
	{
		return _nullable;
	}

	public virtual TerminalSet first_set()
	{
		return _first_set;
	}

	public NonTerminal(string nm, string tp)
		: base(nm, tp)
	{
		is_embedded_action = false;
		_productions = new (11);
		_first_set = new TerminalSet();
		var b = _all.ContainsKey(nm);
		_all.Add(nm, this);
		if (b)
		{
			new InternalError(("Duplicate non-terminal (")+(nm)+(") created")
				).crash();
		}
		_index = next_index++;
		var all_by_index = _all_by_index;
		
		all_by_index.Add((_index), this);
	}

	
	
	public static IEnumerable<NonTerminal> all()
	{
		return _all.Values;
		
	}

	
	
	public virtual IEnumerable<Production> productions()
	{
		return _productions.Values;		
	}

	
	public static void compute_nullability()
	{
		int num = 1;
		while (num != 0)
		{
			num = 0;
			foreach(var non_terminal2 in all())
			{
				if (!non_terminal2.nullable() && non_terminal2.looks_nullable())
				{
					non_terminal2._nullable = true;
					num = 1;
				}
			}
		}
		foreach(var production2 in Production.all())
        {
			production2.set_nullable(production2.check_nullable());
		}
	}

	
	
	public static void compute_first_sets()
	{
		int num = 1;
		while (num != 0)
		{
			num = 0;
			foreach(var non_terminal2 in all())
			{
				foreach(var production2 in non_terminal2.productions())
				{
					var terminal_set2 = production2.check_first_set();
					if (!terminal_set2.IsSubsetOf(non_terminal2._first_set))
					{
						num = 1;
						non_terminal2._first_set.Add(terminal_set2);
					}
				}
			}
		}
	}

	
	
	public static int number()
	{
		int result = _all.Count;
		
		return result;
	}

	
	
	public static NonTerminal find(int indx)
	{
		return _all_by_index.TryGetValue(indx, out var t) ? t : null;
	}

	
	
	public NonTerminal(string nm)
		: this(nm, null)
	{
	}

	
	
	
	internal static NonTerminal create_new(string P_0)
	{
		if (P_0 == null)
		{
			P_0 = "NT$";
		}
		NonTerminal result = new NonTerminal((P_0)+(next_nt++));
		
		return result;
	}

	
	
	
	protected internal virtual bool looks_nullable()
	{
		foreach(var p in productions())
        {
            if (p.check_nullable())
            {
				return true;
            }
        }
		return false;
	}

	
	
	public static NonTerminal find(string with_name)
	{
		return with_name != null && _all.TryGetValue(with_name, out var r) ? r : null;		
	}

	
	
	public virtual int num_productions()
	{
		int result = _productions.Count;
		
		return result;
	}

    public override bool IsNonTerminal => true;



    public override string ToString()
	{
		return (base.ToString())+("[")+(Index)
			+("]")
			+((!nullable()) ? "" : "*")
			;
	}

	
	static NonTerminal()
	{
		next_index = 0;
		next_nt = 0;
		_START_SYMBOL = new NonTerminal("$START");
	}
}
