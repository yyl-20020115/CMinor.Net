using CMinor.Parser;
using CMinor.Visit;

namespace CMinor.AST;

public abstract class BinaryExpression : UnaryExpression
{
	private Expression arg2;

	public BinaryExpression(LocationInfo info, Expression arg1, Expression arg2)
		: base(info, arg1)
	{
		this.arg2 = arg2;
	}

    public virtual Expression Arg2 => arg2;

    public override void Accept(Visitor v)
	{
		v.Visit(this);
	}
}
