
using CMinor.Parser;
using CMinor.Visit;


namespace CMinor.AST;

public class Subtraction : BinaryArithmeticOperator
{
	
	
	public Subtraction(LocationInfo info, Expression left, Expression right)
		: base(info, left, right)
	{
	}

	
	
	public override void Accept(Visitor v)
	{
		v.visit(this);
	}
}
