using CMinor.Parser;
using CMinor.Semantic;
using CMinor.Visit;

namespace CMinor.Symbol;

public class GlobalVariableSymbol : Symbol
{
	public GlobalVariableSymbol(LocationInfo info, string identifier, Type type)
		: base(info, identifier, type)
	{
	}

    public virtual string Label => ("global_") + (Identifier);

    public override void Accept(SymbolVisitor v)
	{
		v.Visit(this);
	}
}
