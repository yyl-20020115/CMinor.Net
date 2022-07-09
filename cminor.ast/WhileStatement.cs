
using CMinor.Parser;
using CMinor.Visit;


namespace CMinor.AST;

public class WhileStatement : Statement
{
	private Expression condition;

	private Statement body;

	
	
	public WhileStatement(LocationInfo info, Expression condition, Statement body)
		: base(info)
	{
		this.condition = condition;
		this.body = body;
	}

	public virtual Expression getCondition()
	{
		return condition;
	}

	public virtual Statement getBody()
	{
		return body;
	}

	
	
	public override void Accept(Visitor v)
	{
		v.visit(this);
	}
}
