using CMinor.Parser;
using CMinor.Visit;

namespace CMinor.AST;

public class Assignment : Expression
{
    private Identifier name;
    private Expression value;

    public Assignment(LocationInfo info, Identifier left, Expression right)
        : base(info)
    {
        name = left;
        value = right;
    }

    public virtual Identifier Identifier => name;
    public virtual Expression Value => value;

    public override void Accept(Visitor v)
    {
        v.Visit(this);
    }
}
