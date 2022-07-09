using System;
namespace JavaCUP;

public class InternalError : System.Exception
{
	
	
	public InternalError(string msg)
		: base(msg)
	{
	}

	
	
	public virtual void crash()
	{
		Console.Error.WriteLine("JavaCUP Fatal Internal System.Exception Detected");
		Console.Error.WriteLine(this.Message);
		
		Environment.Exit(-1);
	}

}
