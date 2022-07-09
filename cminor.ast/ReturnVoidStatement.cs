using CMinor.Parser;
using CMinor.Visit;

namespace CMinor.AST;

public class ReturnVoidStatement : Statement
{
    public ReturnVoidStatement(LocationInfo info)
        : base(info)
    {
    }

    public override void Accept(Visitor v)
    {
        v.Visit(this);
    }
}
