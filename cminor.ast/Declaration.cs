using CMinor.Parser;
using CMinor.Visit;

namespace CMinor.AST;

public class Declaration : AstNode
{
    private TypeSpecifier type;
    private Identifier name;

    public Declaration(LocationInfo info, TypeSpecifier type, Identifier name)
        : base(info)
    {
        this.type = type;
        this.name = name;
    }

    public virtual TypeSpecifier Type => type;

    public virtual Identifier Identifier => name;

    public override void Accept(Visitor v)
    {
        v.Visit(this);
    }
}
