using CMinor.Parser;
using CMinor.Visit;

namespace CMinor.AST;

public class CharacterLiteral : ConstantExpression
{	
	public CharacterLiteral(LocationInfo info, char value)
		: base(info, value)
	{
	}	
	
	public override void Accept(Visitor v)
	{
		v.Visit(this);
	}
}
