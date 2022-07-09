using CMinor.Parser;
using CMinor.Symbol;
using CMinor.Visit;

namespace CMinor.AST;

public class GlobalVariableDeclaration : ExternalDeclaration
{
    private TypeSpecifier type;

    private GlobalVariableSymbol symbol;

    public GlobalVariableDeclaration(LocationInfo info, TypeSpecifier type, Identifier name)
        : base(info, name)
    {
        this.type = type;
    }

    public virtual TypeSpecifier Type => type;

    public virtual GlobalVariableSymbol Symbol { get => symbol; set => this.symbol = value; }

    public override void Accept(Visitor v)
    {
        v.Visit(this);
    }
}
