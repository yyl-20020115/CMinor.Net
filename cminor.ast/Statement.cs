
using CMinor.Parser;
using CMinor.Visit;


namespace CMinor.AST;

public abstract class Statement : AstNode
{
	
	
	protected internal Statement(LocationInfo info)
		: base(info)
	{
	}

	
	
	public override void Accept(Visitor v)
	{
		v.visit(this);
	}
}
