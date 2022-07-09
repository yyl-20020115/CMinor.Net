using CMinor.Parser;
using CMinor.Visit;

namespace CMinor.AST;

public abstract class BinaryArithmeticOperator : BinaryExpression
{
	public BinaryArithmeticOperator(LocationInfo info, Expression arg1, Expression arg2)
		: base(info, arg1, arg2)
	{
	}
	public override void Accept(Visitor v)
	{
		v.Visit(this);
	}
}
