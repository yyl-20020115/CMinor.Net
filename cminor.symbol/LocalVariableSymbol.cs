
using CMinor.Parser;
using CMinor.semantic;
using CMinor.Visit;


namespace CMinor.Symbol;

public class LocalVariableSymbol : StackVariableSymbol
{
	
	
	public LocalVariableSymbol(LocationInfo info, string identifier, Type type)
		: base(info, identifier, type)
	{
	}

	
	
	public override void accept(SymbolVisitor v)
	{
		v.visit(this);
	}
}
