namespace JavaCUP;

public class ParseAction
{
	public const int ERROR = 0;

	public const int SHIFT = 1;

	public const int REDUCE = 2;

	public const int NONASSOC = 3;

    public virtual int Kind => 0;



    public virtual bool Equals(ParseAction other)
	{
		return (other != null && other.Kind== 0) ? true : false;
	}

	
	
	public ParseAction()
	{
	}

	
	
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
		return 212853027;
	}

	public override string ToString()
	{
		return "ERROR";
	}
}
