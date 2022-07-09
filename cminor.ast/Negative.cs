using CMinor.Parser;
using CMinor.Visit;

namespace CMinor.AST;

public class Negative : UnaryExpression
{
    public Negative(LocationInfo info, Expression arg)
        : base(info, arg)
    {
    }

    public override void Accept(Visitor v)
    {
        v.Visit(this);
    }
}
