
using CMinor.Parser;
using CMinor.Symbol;
using CMinor.Visit;
using System.Collections;

namespace CMinor.AST;

public class FunctionCall : Expression
{
	private Identifier name;
	private IList arguments;
	private FunctionSymbol symbol;

	public FunctionCall(LocationInfo info, Identifier name, IList arguments)
		: base(info)
	{
		this.name = name;
		this.arguments = arguments;
	}

	public virtual Identifier getIdentifier()
	{
		return name;
	}


    public virtual IList Arguments => arguments;

    public virtual FunctionSymbol Symbol { get => symbol; set => this.symbol = value; }

    public override void Accept(Visitor v)
	{
		v.Visit(this);
	}
}
