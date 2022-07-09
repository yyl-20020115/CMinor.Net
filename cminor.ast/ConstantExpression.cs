using CMinor.Parser;
using CMinor.Visit;

namespace CMinor.AST;

public abstract class ConstantExpression : Expression
{
    protected object value;

    public ConstantExpression(LocationInfo info, object value)
        : base(info)
    {
        this.value = value;
    }

    public virtual object Value => value;


    public override void Accept(Visitor v)
    {
        v.Visit(this);
    }
}
