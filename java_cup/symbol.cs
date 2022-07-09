namespace JavaCUP;

public abstract class _Symbol
{
	protected internal string _name;
	protected internal string _stack_type;
	protected internal int _use_count;
	protected internal int _index;
	
	public virtual void NoteUse()
	{
		_use_count++;
	}

    public virtual string StackType => _stack_type;

    public abstract bool IsNonTerminal { get; }

    public virtual string Name => _name;

    public virtual int Index => _index;

    public virtual int UseCount => _use_count;



    public _Symbol(string nm, string tp)
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
	
	public _Symbol(string nm)
		: this(nm, null)
	{
	}

    public override string ToString() => this.Name;
}
