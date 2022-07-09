using CMinor.Parser;
using CMinor.Symbol;
using CMinor.Visit;
using System.Collections;
using System.Collections.Generic;

namespace CMinor.AST;

public class FunctionCall : Expression
{
    private Identifier name;
    private List<AstNode> arguments;
    private FunctionSymbol symbol;

    public FunctionCall(LocationInfo info, Identifier name, List<AstNode> arguments)
        : base(info)
    {
        this.name = name;
        this.arguments = arguments;
    }

    public virtual Identifier Identifier => name;

    public virtual List<AstNode> Arguments => arguments;

    public virtual FunctionSymbol Symbol { get => symbol; set => this.symbol = value; }

    public override void Accept(Visitor v)
    {
        v.Visit(this);
    }
}
