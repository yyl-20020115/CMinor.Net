
using CMinor.Parser;
using CMinor.Visit;


namespace CMinor.AST;

public class Declaration : AstNode
{
	private TypeSpecifier type;

	private Identifier name;

	
	
	public Declaration(LocationInfo info, TypeSpecifier type, Identifier name)
		: base(info)
	{
		this.type = type;
		this.name = name;
	}

	public virtual TypeSpecifier getType()
	{
		return type;
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
