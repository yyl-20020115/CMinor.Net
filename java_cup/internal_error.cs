using System;

using System.Runtime.Serialization;




namespace java_cup;


public class internal_error : System.Exception
{
	
	
	public internal_error(string msg)
		: base(msg)
	{
	}

	
	
	public virtual void crash()
	{
		java.lang.System.err.WriteLine("JavaCUP Fatal Internal Error Detected");
		java.lang.System.err.WriteLine(Throwable.instancehelper_getMessage(this));
		Throwable.instancehelper_printStackTrace(this);
		java.lang.System.exit(-1);
	}

	
	
	protected internal_error(SerializationInfo P_0, StreamingContext P_1)
		: base(P_0, P_1)
	{
	}
}
