using CMinor.Parser;
using CMinor.Visit;
using System.Collections;
using System.Collections.Generic;

namespace CMinor.AST;

public class BlockStatement : Statement
{
	private IList declarations;

	private IList statements;

	public BlockStatement(LocationInfo info, IList declarations, IList statements)
		: base(info)
	{
		this.declarations = declarations;
		this.statements = statements;
	}

	
	public virtual IList getDeclarations()
	{
		return declarations;
	}

	
	public virtual IList getStatements()
	{
		return statements;
	}

	
	
	public override void Accept(Visitor v)
	{
		v.Visit(this);
	}
}
