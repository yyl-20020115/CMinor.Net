
using CMinor.Parser;
using CMinor.semantic;
using CMinor.Visit;


namespace CMinor.Symbol;

public class ParameterSymbol : StackVariableSymbol
{
	
	
	public ParameterSymbol(LocationInfo info, string identifier, Type type)
		: base(info, identifier, type)
	{
	}

	
	
	public override void accept(SymbolVisitor v)
	{
		v.visit(this);
	}
}
