using System;

using System.Runtime.Serialization;




namespace CMinor.Parser;



internal class ArgumentList : LinkedList
{
	
	
	internal ArgumentList()
	{
	}

	
	
	protected ArgumentList(SerializationInfo P_0, StreamingContext P_1)
		: base(P_0, P_1)
	{
	}
}
