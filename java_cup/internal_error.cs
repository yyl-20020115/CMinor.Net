using System;

using System.Runtime.Serialization;


using java.lang;

namespace java_cup;


public class internal_error : System.Exception
{
	
	
	public internal_error(string msg)
		: base(msg)
	{
	}

	
	
	public virtual void crash()
	{
		java.lang.System.err.println("JavaCUP Fatal Internal Error Detected");
		java.lang.System.err.println(Throwable.instancehelper_getMessage(this));
		Throwable.instancehelper_printStackTrace(this);
		java.lang.System.exit(-1);
	}

	
	
	protected internal_error(SerializationInfo P_0, StreamingContext P_1)
		: base(P_0, P_1)
	{
	}
}
