



namespace JavaCUP;

public abstract class symbol
{
	protected internal string _name;

	protected internal string _stack_type;

	protected internal int _use_count;

	protected internal int _index;

	
	public virtual void note_use()
	{
		_use_count++;
	}

	public virtual string stack_type()
	{
		return _stack_type;
	}

	public abstract bool is_non_term();

	public virtual string name()
	{
		return _name;
	}

	public virtual int index()
	{
		return _index;
	}

	public virtual int use_count()
	{
		return _use_count;
	}

	
	
	public symbol(string nm, string tp)
	{
		_use_count = 0;
		if (nm == null)
		{
			nm = "";
		}
		if (tp == null)
		{
			tp = "Object";
		}
		_name = nm;
		_stack_type = tp;
	}

	
	
	public symbol(string nm)
		: this(nm, null)
	{
	}

	
	
	public override string ToString()
	{
		string result = name();
		
		return result;
	}
}
