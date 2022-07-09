using CMinor.Parser;
using CMinor.Visit;

namespace CMinor.AST;

public abstract class UnaryExpression : Expression
{
	private Expression arg1;
	
	public UnaryExpression(LocationInfo info, Expression arg1)
		: base(info)
	{
		this.arg1 = arg1;
	}

    public virtual Expression Arg1 => arg1;

    public override void Accept(Visitor v)
	{
		v.Visit(this);
	}
}
