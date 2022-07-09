using CMinor.Parser;
using CMinor.Visit;

namespace CMinor.AST;

public class CharacterLiteral : ConstantExpression
{	
	public CharacterLiteral(LocationInfo info, char value)
		: base(info, value)
	{
	}
	public new char Value => base.value is char c ? c : '\0';
	public override void Accept(Visitor v)
	{
		v.Visit(this);
	}
}
