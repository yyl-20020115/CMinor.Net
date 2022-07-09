using CMinor.Parser;
using CMinor.Visit;

namespace CMinor.AST;

public class IntegerLiteral : ConstantExpression
{
	public IntegerLiteral(LocationInfo info, int value)
		: base(info, value)
	{
	}
	
	public override void Accept(Visitor v)
	{
		v.Visit(this);
	}
}
