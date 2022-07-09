using CMinor.Parser;
using CMinor.Visit;

namespace CMinor.AST;

public class GlobalVariableInitialization : GlobalVariableDeclaration
{
    private ConstantExpression value;

    public GlobalVariableInitialization(LocationInfo info, TypeSpecifier type, Identifier name, ConstantExpression value)
        : base(info, type, name)
    {
        this.value = value;
    }

    public virtual ConstantExpression Value => value;

    public override void Accept(Visitor v)
    {
        v.Visit(this);
    }
}
