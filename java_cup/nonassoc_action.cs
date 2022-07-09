namespace JavaCUP;

public class nonassoc_action : parse_action
{
	public nonassoc_action()
	{
	}

	public override bool Equals(parse_action other)
	{
		return (other != null && other.kind() == 3) ? true : false;
	}

	public override int kind()
	{
		return 3;
	}

	
	
	public override bool Equals(object other)
	{
		if (other is parse_action)
		{
			bool result = Equals((parse_action)other);
			
			return result;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return 212853537;
	}

	public override string ToString()
	{
		return "NONASSOC";
	}
}
