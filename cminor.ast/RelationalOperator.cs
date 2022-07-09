using CMinor.Parser;
using CMinor.Visit;

namespace CMinor.AST;

public class RelationalOperator : BinaryExpression
{	
	public RelationalOperator(LocationInfo info, Expression left, Expression right)
		: base(info, left, right)
	{
	}	
	
	public override void Accept(Visitor v)
	{
		v.Visit(this);
	}
}
