using System;
using CMinor.Parser;

namespace CMinor.Semantic;

public class ErrorLogger
{
	private int numErrors = 0;

	public ErrorLogger() { }

    public virtual bool HasErrors => numErrors > 0;

    public virtual void log(LocationInfo info, string msg)
	{
		this.numErrors++;
		Console.Error.WriteLine((info)+(": ")+(msg));
	}
}
