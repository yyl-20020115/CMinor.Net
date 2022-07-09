
using CMinor.Parser;
using CMinor.Visit;


namespace CMinor.AST;

public abstract class ConstantExpression : Expression
{
	private object value;

	public ConstantExpression(LocationInfo info, object value)
		: base(info)
	{
		this.value = value;
	}

	
	public virtual object getValue()
	{
		return value;
	}

	
	
	public override void Accept(Visitor v)
	{
		v.visit(this);
	}
}
