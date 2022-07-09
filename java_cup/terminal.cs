using System.Collections.Generic;

namespace JavaCUP;

public class terminal : _Symbol
{
	private int _precedence_num;

	private int _precedence_side;

	protected internal static Dictionary<string,terminal> _all =new();

	protected internal static Dictionary<int,terminal> _all_by_index = new();

	protected internal static int next_index;

	internal static terminal ___003C_003EEOF;

	internal static terminal ___003C_003Eerror;

	
	public static terminal EOF
	{
		
		get
		{
			return ___003C_003EEOF;
		}
	}

	
	public static terminal error
	{
		
		get
		{
			return ___003C_003Eerror;
		}
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

	
	
	public static IEnumerable<terminal> all()
	{
		return _all.Values;
	}

	
	
	public static int number()
	{
		int result = _all.Count;
		
		return result;
	}

	
	
	public static terminal find(int idx)
	{
		return _all_by_index.TryGetValue(idx, out var t)?t: null;
	}

	
	public terminal(string nm, string tp, int precedence_side, int precedence_num)
		: base(nm, tp)
	{
		var c = _all.ContainsKey(nm);
		_all.Add(nm, this);
		if (c)
		{
			new internal_error(("Duplicate terminal (")+(nm)+(") created")
				).crash();
		}
		_index = next_index++;
		_precedence_num = precedence_num;
		_precedence_side = precedence_side;
		var all_by_index = _all_by_index;
		
		all_by_index.Add((_index), this);
	}

	
	
	public terminal(string nm)
		: this(nm, null)
	{
	}

	
	
	public static terminal find(string with_name)
	{
		return with_name!=null && _all.TryGetValue(with_name, out var t)?t: null;

	}

    public override bool IsNonTerminal => false;



    public override string ToString()
	{
		return (base.ToString())+("[")+(Index)
			+("]")
			;
		
	}

	
	static terminal()
	{
		_all = new ();
		_all_by_index = new ();
		next_index = 0;
		___003C_003EEOF = new terminal("EOF");
		___003C_003Eerror = new terminal("error");
	}
}
