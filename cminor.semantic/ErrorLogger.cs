
using CMinor.Parser;



namespace CMinor.semantic;

public class ErrorLogger
{
	private int numErrors;

	
	
	public ErrorLogger()
	{
		numErrors = 0;
	}

	public virtual bool hasErrors()
	{
		return numErrors > 0;
	}

	
	
	public virtual void log(LocationInfo info, string msg)
	{
		numErrors++;
		java.lang.System.err.WriteLine((info)+(": ")+(msg)
			.ToString());
	}
}
