namespace JavaCUP;

public class NonAssocActon : ParseAction
{
	public NonAssocActon()
	{
	}

	public override bool Equals(ParseAction other)
	{
		return (other != null && other.Kind== 3) ? true : false;
	}

    public override int Kind => 3;



    public override bool Equals(object other)
	{
		if (other is ParseAction)
		{
			bool result = Equals((ParseAction)other);
			
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
