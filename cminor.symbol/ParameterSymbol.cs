using CMinor.Parser;
using CMinor.Semantic;
using CMinor.Visit;

namespace CMinor.Symbol;

public class ParameterSymbol : StackVariableSymbol
{
	public ParameterSymbol(LocationInfo info, string identifier, Type type)
		: base(info, identifier, type)
	{
	}

	public override void Accept(SymbolVisitor v)
	{
		v.Visit(this);
	}
}
