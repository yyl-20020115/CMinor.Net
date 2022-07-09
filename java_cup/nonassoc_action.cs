


namespace java_cup;

public class nonassoc_action : parse_action
{
	
	[Throws(new string[] { "java_cup.internal_error" })]
	
	public nonassoc_action()
	{
	}

	
	
	public override bool equals(parse_action other)
	{
		return (other != null && other.kind() == 3) ? true : false;
	}

	public override int kind()
	{
		return 3;
	}

	
	
	public override bool equals(object other)
	{
		if (other is parse_action)
		{
			bool result = equals((parse_action)other);
			
			return result;
		}
		return false;
	}

	public override int hashCode()
	{
		return 212853537;
	}

	public override string toString()
	{
		return "NONASSOC";
	}
}
