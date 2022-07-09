using CMinor.Parser;
using CMinor.Visit;

namespace CMinor.AST;

public class IdentifierExpression : Expression
{
	private Identifier name;

	public IdentifierExpression(LocationInfo info, Identifier name)
		: base(info)
	{
		this.name = name;
	}

    public virtual Identifier Identifier => name;

    public override void Accept(Visitor v)
	{
		v.Visit(this);
	}
}
