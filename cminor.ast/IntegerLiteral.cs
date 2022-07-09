using CMinor.Parser;
using CMinor.Visit;

namespace CMinor.AST;

public class IntegerLiteral : ConstantExpression
{
    public IntegerLiteral(LocationInfo info, int value)
        : base(info, value)
    {
    }

    public new int Value => base.value is int v ? v : 0;

    public override void Accept(Visitor v)
    {
        v.Visit(this);
    }
}
