using CMinor.Parser;
using CMinor.Semantic;
using CMinor.Visit;
using System.Collections;

namespace CMinor.Symbol;

public class FunctionSymbol : Symbol
{
	private Types returnType;	
	private IList parameters;

	public FunctionSymbol(LocationInfo info, string identifier, Types returnType, IList parameters)
		: base(info, identifier, Types.function_type)
	{
		this.returnType = returnType;
		this.parameters = parameters;
	}

    public virtual Types ReturnType => returnType;
    public virtual IList Parameters => parameters;
    public virtual string Label => ("function_") + (Identifier);
    public override void Accept(SymbolVisitor v)
	{
		v.Visit(this);
	}
}
