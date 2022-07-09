
using CMinor.Parser;
using CMinor.semantic;
using CMinor.Visit;


namespace CMinor.AST;

public class TypeSpecifier : AstNode
{
	internal Type type;

	
	
	public TypeSpecifier(LocationInfo info, Type type)
		: base(info)
	{
		this.type = type;
	}

	public virtual Type getType()
	{
		return type;
	}

	
	
	public override void Accept(Visitor v)
	{
		v.visit(this);
	}
}
