using CMinor.Parser;
using CMinor.Visit;


namespace CMinor.AST;

public class GreaterThan : RelationalOperator
{	
	public GreaterThan(LocationInfo info, Expression left, Expression right)
		: base(info, left, right)
	{
	}	
	
	public override void Accept(Visitor v)
	{
		v.Visit(this);
	}
}
