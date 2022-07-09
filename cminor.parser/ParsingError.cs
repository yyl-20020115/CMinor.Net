namespace CMinor.Parser;

public class ParsingError : System.Exception
{
	public ParsingError(string msg)
		: base(msg)
	{
	}
}
