using CMinor.Parser;
using CMinor.Semantic;
using CMinor.Visit;

namespace CMinor.AST;

public abstract class Expression : Statement
{
	private Type type;
	
	protected internal Expression(LocationInfo info)
		: base(info)
	{
	}

    public virtual Type Type { get => type; set => this.type = value; }

    public override void Accept(Visitor v)
	{
		v.Visit(this);
	}
}
