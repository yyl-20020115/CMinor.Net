using CMinor.Parser;
using CMinor.Semantic;
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

    public virtual Type Type => type;

    public override void Accept(Visitor v)
	{
		v.Visit(this);
	}
}
