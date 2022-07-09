using CMinor.Parser;
using CMinor.Visit;

namespace CMinor.AST;

public class Identifier : AstNode
{
    private string name;
    private CMinor.Symbol.Symbol symbol;

    public Identifier(LocationInfo info, string name)
        : base(info)
    {
        this.name = name;
        symbol = null;
    }

    public virtual string Name => name;

    public virtual CMinor.Symbol.Symbol Symbol { get => symbol; set => this.symbol = value; }

    public override void Accept(Visitor v)
    {
        v.Visit(this);
    }
}
