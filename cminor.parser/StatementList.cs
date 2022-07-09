using System;

using System.Runtime.Serialization;




namespace CMinor.Parser;



internal class StatementList : LinkedList
{
	
	
	internal StatementList()
	{
	}

	
	
	protected StatementList(SerializationInfo P_0, StreamingContext P_1)
		: base(P_0, P_1)
	{
	}
}
