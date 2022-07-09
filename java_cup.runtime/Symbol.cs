namespace JavaCUP.Runtime;

public class Symbol
{
	public int sym;
	public int parse_state;
	internal bool used_by_parser;
	public int left;
	public int right;
	public object value;
	
	public Symbol(int sym_num)
		: this(sym_num, -1)
	{
		left = -1;
		right = -1;
		value = null;
	}
	public Symbol(int id, object o)
		: this(id, -1, -1, o)
	{
	}

	public Symbol(int id, int l, int r, object o)
		: this(id)
	{
		left = l;
		right = r;
		value = o;
	}

	internal Symbol(int P_0, int P_1)
	{
		used_by_parser = false;
		sym = P_0;
		parse_state = P_1;
	}

	public Symbol(int id, int l, int r)
		: this(id, l, r, null)
	{
	}

    public override string ToString() => ("#") + (sym);
}
