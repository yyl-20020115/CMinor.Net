using CMinor.Parser;
using CMinor.Symbol;
using CMinor.Visit;
using System.Collections.Generic;

namespace CMinor.AST;

public class FunctionCall : Expression
{
    private Identifier name;
    private List<Expression> arguments = new();
    private FunctionSymbol symbol;

    public FunctionCall(LocationInfo info, Identifier name, List<Expression> arguments)
        : base(info)
    {
        this.name = name;
        this.arguments = arguments;
    }

    public virtual Identifier Identifier => name;

    public virtual List<Expression> Arguments => arguments;

    public virtual FunctionSymbol Symbol { get => symbol; set => this.symbol = value; }

    public override void Accept(Visitor v)
    {
        v.Visit(this);
    }
}
