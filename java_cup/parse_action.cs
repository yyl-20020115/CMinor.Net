

using java.lang;

namespace java_cup;

public class parse_action
{
	public const int ERROR = 0;

	public const int SHIFT = 1;

	public const int REDUCE = 2;

	public const int NONASSOC = 3;

	public virtual int kind()
	{
		return 0;
	}

	
	
	public virtual bool equals(parse_action other)
	{
		return (other != null && other.kind() == 0) ? true : false;
	}

	
	
	public parse_action()
	{
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
		return 212853027;
	}

	public override string toString()
	{
		return "ERROR";
	}
}
