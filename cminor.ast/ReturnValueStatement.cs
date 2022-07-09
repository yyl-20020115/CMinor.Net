using CMinor.Parser;
using CMinor.Visit;

namespace CMinor.AST;

public class ReturnValueStatement : ReturnVoidStatement
{
    private Expression value;

    public ReturnValueStatement(LocationInfo info, Expression value)
        : base(info)
    {
        this.value = value;
    }

    public virtual Expression Value => value;

    public override void Accept(Visitor v)
    {
        v.Visit(this);
    }
}
