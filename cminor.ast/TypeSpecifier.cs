using CMinor.Parser;
using CMinor.Semantic;
using CMinor.Visit;

namespace CMinor.AST;

public class TypeSpecifier : AstNode
{
    internal Types type;

    public TypeSpecifier(LocationInfo info, Types type)
        : base(info)
    {
        this.type = type;
    }

    public virtual Types Type => type;

    public override void Accept(Visitor v)
    {
        v.Visit(this);
    }
}
