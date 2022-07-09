
using CMinor.Parser;

using java.lang;

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
		java.lang.System.err.println(new StringBuilder().append(info).append(": ").append(msg)
			.toString());
	}
}
