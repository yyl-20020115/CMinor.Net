using System;

using System.Runtime.Serialization;


using java.lang;

namespace CMinor.Parser;


public class ParsingError : System.Exception
{
	
	
	public ParsingError(string msg)
		: base(msg)
	{
	}

	
	
	protected ParsingError(SerializationInfo P_0, StreamingContext P_1)
		: base(P_0, P_1)
	{
	}
}
