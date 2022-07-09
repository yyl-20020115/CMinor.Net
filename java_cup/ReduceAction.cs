namespace JavaCUP;

public class ReduceAction : ParseAction
{
	protected internal Production _reduce_with;

	public virtual Production reduce_with()
	{
		return _reduce_with;
	}

	
	
	
	public ReduceAction(Production prod)
	{
		if (prod == null)
		{
			
			throw new InternalError("Attempt to create a reduce_action with a null production");
		}
		_reduce_with = prod;
	}

	
	
	public virtual bool Equals(ReduceAction other)
	{
		return (other != null && other.reduce_with() == reduce_with()) ? true : false;
	}

    public override int Kind => 2;



    public override bool Equals(object other)
	{
		if (other is ReduceAction)
		{
			bool result = Equals((ReduceAction)other);
			
			return result;
		}
		return false;
	}

	
	
	public override int GetHashCode()
	{
		return reduce_with().GetHashCode();
	}

	
	
	public override string ToString()
	{
		string result = ("REDUCE(with prod ")+(reduce_with().index())+(")")
			;
		
		return result;
	}
}
