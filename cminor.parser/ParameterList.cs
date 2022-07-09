using System;

using System.Runtime.Serialization;




namespace CMinor.Parser;



internal class ParameterList : LinkedList
{
	
	
	internal ParameterList()
	{
	}

	
	
	protected ParameterList(SerializationInfo P_0, StreamingContext P_1)
		: base(P_0, P_1)
	{
	}
}
