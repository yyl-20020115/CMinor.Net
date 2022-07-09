
using CMinor.Parser;
using CMinor.Visit;

using java.lang;

namespace CMinor.AST;


public class IntegerLiteral : ConstantExpression
{
	
	
	public IntegerLiteral(LocationInfo info, Integer value)
		: base(info, value)
	{
	}

	
	
	public override void Accept(Visitor v)
	{
		v.visit(this);
	}
}
