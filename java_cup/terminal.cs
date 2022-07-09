

using java.lang;


namespace java_cup;

public class terminal : symbol
{
	private int _precedence_num;

	private int _precedence_side;

	protected internal static Hashtable _all;

	protected internal static Hashtable _all_by_index;

	protected internal static int next_index;

	internal static terminal ___003C_003EEOF;

	internal static terminal ___003C_003Eerror;

	[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static terminal EOF
	{
		
		get
		{
			return ___003C_003EEOF;
		}
	}

	[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static terminal error
	{
		
		get
		{
			return ___003C_003Eerror;
		}
	}

	
	
	public static void ___003Cclinit_003E()
	{
	}

	public virtual int precedence_num()
	{
		return _precedence_num;
	}

	public virtual int precedence_side()
	{
		return _precedence_side;
	}

	public virtual void set_precedence(int p, int new_prec)
	{
		_precedence_side = p;
		_precedence_num = new_prec;
	}

	
	
	public terminal(string nm, string tp)
		: this(nm, tp, -1, -1)
	{
	}

	
	
	public static Enumeration all()
	{
		Enumeration result = _all.elements();
		
		return result;
	}

	
	
	public static int number()
	{
		int result = _all.size();
		
		return result;
	}

	
	
	public static terminal find(int indx)
	{
		Integer key = new Integer(indx);
		return (terminal)_all_by_index.get(key);
	}

	
	[LineNumberTable(new byte[]
	{
		159, 171, 170, 109, 227, 69, 191, 15, 179, 104,
		167, 124
	})]
	public terminal(string nm, string tp, int precedence_side, int precedence_num)
		: base(nm, tp)
	{
		object obj = _all.put(nm, this);
		if (obj != null)
		{
			new internal_error(new StringBuilder().append("Duplicate terminal (").append(nm).append(") created")
				.toString()).crash();
		}
		_index = next_index++;
		_precedence_num = precedence_num;
		_precedence_side = precedence_side;
		Hashtable all_by_index = _all_by_index;
		
		all_by_index.put(new Integer(_index), this);
	}

	
	
	public terminal(string nm)
		: this(nm, null)
	{
	}

	
	
	public static terminal find(string with_name)
	{
		if (with_name == null)
		{
			return null;
		}
		return (terminal)_all.get(with_name);
	}

	public override bool is_non_term()
	{
		return false;
	}

	
	
	public override string toString()
	{
		string result = new StringBuilder().append(base.toString()).append("[").append(index())
			.append("]")
			.toString();
		
		return result;
	}

	
	static terminal()
	{
		_all = new Hashtable();
		_all_by_index = new Hashtable();
		next_index = 0;
		___003C_003EEOF = new terminal("EOF");
		___003C_003Eerror = new terminal("error");
	}
}
