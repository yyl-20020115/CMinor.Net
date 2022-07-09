



namespace java_cup;

public class reduce_action : parse_action
{
	protected internal production _reduce_with;

	public virtual production reduce_with()
	{
		return _reduce_with;
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	
	public reduce_action(production prod)
	{
		if (prod == null)
		{
			
			throw new internal_error("Attempt to create a reduce_action with a null production");
		}
		_reduce_with = prod;
	}

	
	
	public virtual bool equals(reduce_action other)
	{
		return (other != null && other.reduce_with() == reduce_with()) ? true : false;
	}

	public override int kind()
	{
		return 2;
	}

	
	
	public override bool equals(object other)
	{
		if (other is reduce_action)
		{
			bool result = equals((reduce_action)other);
			
			return result;
		}
		return false;
	}

	
	
	public override int hashCode()
	{
		int result = reduce_with().hashCode();
		
		return result;
	}

	
	
	public override string ToString()
	{
		string result = ("REDUCE(with prod ")+(reduce_with().index())+(")")
			.ToString();
		
		return result;
	}
}
