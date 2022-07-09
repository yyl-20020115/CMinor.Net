
using CMinor.Parser;
using CMinor.Visit;


namespace CMinor.AST;

public abstract class ExternalDeclaration : AstNode
{
	private Identifier name;

	
	
	public ExternalDeclaration(LocationInfo info, Identifier name)
		: base(info)
	{
		this.name = name;
	}

	public virtual Identifier getIdentifier()
	{
		return name;
	}

	
	
	public override void Accept(Visitor v)
	{
		v.visit(this);
	}
}
