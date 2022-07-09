

using java.lang;


namespace java_cup;

public class non_terminal : symbol
{
	protected internal static Hashtable _all;

	protected internal static Hashtable _all_by_index;

	protected internal static int next_index;

	protected internal static int next_nt;

	internal static non_terminal ___003C_003ESTART_nt;

	public bool is_embedded_action;

	protected internal Hashtable _productions;

	protected internal bool _nullable;

	protected internal terminal_set _first_set;

	[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static non_terminal START_nt
	{
		
		get
		{
			return ___003C_003ESTART_nt;
		}
	}

	
	
	public static void ___003Cclinit_003E()
	{
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	
	public virtual void add_production(production prod)
	{
		if (prod == null || prod.lhs() == null || prod.lhs().the_symbol() != this)
		{
			
			throw new internal_error("Attempt to add invalid production to non terminal production table");
		}
		_productions.put(prod, prod);
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	
	internal static non_terminal create_new()
	{
		non_terminal result = create_new(null);
		
		return result;
	}

	public virtual bool nullable()
	{
		return _nullable;
	}

	public virtual terminal_set first_set()
	{
		return _first_set;
	}

	
	[LineNumberTable(new byte[]
	{
		159, 170, 234, 160, 85, 231, 160, 114, 237, 99,
		235, 159, 25, 109, 227, 69, 191, 15, 179, 124
	})]
	public non_terminal(string nm, string tp)
		: base(nm, tp)
	{
		is_embedded_action = false;
		_productions = new Hashtable(11);
		_first_set = new terminal_set();
		object obj = _all.put(nm, this);
		if (obj != null)
		{
			new internal_error(new StringBuilder().append("Duplicate non-terminal (").append(nm).append(") created")
				.toString()).crash();
		}
		_index = next_index++;
		Hashtable all_by_index = _all_by_index;
		
		all_by_index.put(new Integer(_index), this);
	}

	
	
	public static Enumeration all()
	{
		Enumeration result = _all.elements();
		
		return result;
	}

	
	
	public virtual Enumeration productions()
	{
		Enumeration result = _productions.elements();
		
		return result;
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	[LineNumberTable(new byte[]
	{
		92, 226, 70, 163, 162, 142, 172, 136, 136, 103,
		228, 71, 142, 108, 143
	})]
	public static void compute_nullability()
	{
		int num = 1;
		Enumeration enumeration;
		while (num != 0)
		{
			num = 0;
			enumeration = all();
			while (enumeration.hasMoreElements())
			{
				non_terminal non_terminal2 = (non_terminal)enumeration.nextElement();
				if (!non_terminal2.nullable() && non_terminal2.looks_nullable())
				{
					non_terminal2._nullable = true;
					num = 1;
				}
			}
		}
		enumeration = production.all();
		while (enumeration.hasMoreElements())
		{
			production production2 = (production)enumeration.nextElement();
			production2.set_nullable(production2.check_nullable());
		}
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	[LineNumberTable(new byte[]
	{
		160, 71, 226, 72, 166, 162, 142, 172, 143, 173,
		169, 143, 98, 240, 69
	})]
	public static void compute_first_sets()
	{
		int num = 1;
		while (num != 0)
		{
			num = 0;
			Enumeration enumeration = all();
			while (enumeration.hasMoreElements())
			{
				non_terminal non_terminal2 = (non_terminal)enumeration.nextElement();
				Enumeration enumeration2 = non_terminal2.productions();
				while (enumeration2.hasMoreElements())
				{
					production production2 = (production)enumeration2.nextElement();
					terminal_set terminal_set2 = production2.check_first_set();
					if (!terminal_set2.is_subset_of(non_terminal2._first_set))
					{
						num = 1;
						non_terminal2._first_set.add(terminal_set2);
					}
				}
			}
		}
	}

	
	
	public static int number()
	{
		int result = _all.size();
		
		return result;
	}

	
	
	public static non_terminal find(int indx)
	{
		Integer key = new Integer(indx);
		return (non_terminal)_all_by_index.get(key);
	}

	
	
	public non_terminal(string nm)
		: this(nm, null)
	{
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	
	internal static non_terminal create_new(string P_0)
	{
		if (P_0 == null)
		{
			P_0 = "NT$";
		}
		non_terminal result = new non_terminal(new StringBuilder().append(P_0).append(next_nt++).toString());
		
		return result;
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	
	protected internal virtual bool looks_nullable()
	{
		Enumeration enumeration = productions();
		while (enumeration.hasMoreElements())
		{
			if (((production)enumeration.nextElement()).check_nullable())
			{
				return true;
			}
		}
		return false;
	}

	
	
	public static non_terminal find(string with_name)
	{
		if (with_name == null)
		{
			return null;
		}
		return (non_terminal)_all.get(with_name);
	}

	
	
	public virtual int num_productions()
	{
		int result = _productions.size();
		
		return result;
	}

	public override bool is_non_term()
	{
		return true;
	}

	
	
	public override string toString()
	{
		string result = new StringBuilder().append(base.toString()).append("[").append(index())
			.append("]")
			.append((!nullable()) ? "" : "*")
			.toString();
		
		return result;
	}

	
	static non_terminal()
	{
		_all = new Hashtable();
		_all_by_index = new Hashtable();
		next_index = 0;
		next_nt = 0;
		___003C_003ESTART_nt = new non_terminal("$START");
	}
}
