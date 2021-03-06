using CMinor.Parser;
using CMinor.Visit;

namespace CMinor.AST;

public class IfStatement : Statement
{
    private Expression condition;

    private Statement ifClause;

    public IfStatement(LocationInfo info, Expression condition, Statement ifClause)
        : base(info)
    {
        this.condition = condition;
        this.ifClause = ifClause;
    }

    public virtual Expression Condition => condition;

    public virtual Statement IfClause => ifClause;

    public override void Accept(Visitor v)
    {
        v.Visit(this);
    }
}
