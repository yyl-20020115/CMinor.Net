



namespace java_cup;

public class shift_action : parse_action
{
	protected internal lalr_state _shift_to;

	public virtual lalr_state shift_to()
	{
		return _shift_to;
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	
	public shift_action(lalr_state shft_to)
	{
		if (shft_to == null)
		{
			
			throw new internal_error("Attempt to create a shift_action to a null state");
		}
		_shift_to = shft_to;
	}

	
	
	public virtual bool equals(shift_action other)
	{
		return (other != null && other.shift_to() == shift_to()) ? true : false;
	}

	public override int kind()
	{
		return 1;
	}

	
	
	public override bool equals(object other)
	{
		if (other is shift_action)
		{
			bool result = equals((shift_action)other);
			
			return result;
		}
		return false;
	}

	
	
	public override int hashCode()
	{
		int result = shift_to().hashCode();
		
		return result;
	}

	
	
	public override string ToString()
	{
		string result = ("SHIFT(to state ")+(shift_to().index())+(")")
			.ToString();
		
		return result;
	}
}
