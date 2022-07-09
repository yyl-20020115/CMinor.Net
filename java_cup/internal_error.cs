using System;

namespace JavaCUP;


public class internal_error : System.Exception
{
	
	
	public internal_error(string msg)
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
