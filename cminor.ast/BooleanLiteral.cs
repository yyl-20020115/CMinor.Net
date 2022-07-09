
using CMinor.Parser;
using CMinor.Visit;

using java.lang;

namespace CMinor.AST;


public class BooleanLiteral : ConstantExpression
{
	
	
	public BooleanLiteral(LocationInfo info, Boolean value)
		: base(info, value)
	{
	}

	
	
	public override void Accept(Visitor v)
	{
		v.visit(this);
	}
}
