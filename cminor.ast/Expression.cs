
using CMinor.Parser;
using CMinor.semantic;
using CMinor.Visit;


namespace CMinor.AST;

public abstract class Expression : Statement
{
	private Type type;

	
	
	protected internal Expression(LocationInfo info)
		: base(info)
	{
	}

	public virtual Type getType()
	{
		return type;
	}

	public virtual void setType(Type type)
	{
		this.type = type;
	}

	
	
	public override void Accept(Visitor v)
	{
		v.visit(this);
	}
}
