using CMinor.Parser;
using CMinor.Visit;

namespace CMinor.AST;

public class BooleanLiteral : ConstantExpression
{
    public BooleanLiteral(LocationInfo info, bool value)
        : base(info, value)
    {
    }
    public new bool Value => base.value is bool b ? b : false;

    public override void Accept(Visitor v)
    {
        v.Visit(this);
    }
}
