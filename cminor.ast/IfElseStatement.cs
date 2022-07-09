
using CMinor.Parser;
using CMinor.Visit;


namespace CMinor.AST;

public class IfElseStatement : IfStatement
{
	private Statement elseStatement;

	
	
	public IfElseStatement(LocationInfo info, Expression condition, Statement ifStatement, Statement elseStatement)
		: base(info, condition, ifStatement)
	{
		this.elseStatement = elseStatement;
	}

	public virtual Statement getElseClause()
	{
		return elseStatement;
	}

	
	
	public override void Accept(Visitor v)
	{
		v.visit(this);
	}
}
