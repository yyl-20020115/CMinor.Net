using CMinor.Parser;
using CMinor.Semantic;
using CMinor.Visit;

namespace CMinor.Symbol;

public class LocalVariableSymbol : StackVariableSymbol
{	
	public LocalVariableSymbol(LocationInfo info, string identifier, Type type)
		: base(info, identifier, type)
	{
	}
	
	public override void Accept(SymbolVisitor v)
	{
		v.Visit(this);
	}
}
