
using CMinor.Parser;
using CMinor.Visit;


namespace CMinor.AST;

public class Parameter : AstNode
{
	internal TypeSpecifier type;

	internal Identifier name;

	
	
	public Parameter(LocationInfo info, TypeSpecifier type, Identifier name)
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
