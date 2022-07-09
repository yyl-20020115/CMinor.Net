using CMinor.AST;
using System.Collections.Generic;

namespace CMinor.Visit;

public class ChildVisitor : Visitor
{
	
	private List<AstNode> children;

	public ChildVisitor()
	{
	}

    public virtual List<AstNode> Children { get => children; set => this.children = value; }

    public override void Visit(Program n)
	{
		children.AddRange(n.Declarations);
	}
	
	public override void Visit(Parameter n)
	{
		children.Add(n.Type);
		children.Add(n.Identifier);
	}

	
	public override void Visit(FunctionDefinition n)
	{
		children.Add(n.ReturnType);
		children.Add(n.Identifier);
		children.AddRange(n.Parameters);
		children.Add(n.Body);
	}

	
	
	public override void Visit(GlobalVariableDeclaration n)
	{
		children.Add(n.Type);
		children.Add(n.Identifier);
	}

	
	
	public override void Visit(GlobalVariableInitialization n)
	{
		children.Add(n.Type);
		children.Add(n.Identifier);
		children.Add(n.Value);
	}

	
	
	public override void Visit(Declaration n)
	{
		children.Add(n.Type);
		children.Add(n.Identifier);
	}

	
	
	public override void Visit(Initialization n)
	{
		children.Add(n.Type);
		children.Add(n.Identifier);
		children.Add(n.Value);
	}

	
	
	public override void visit(PrintStatement n)
	{
		children.AddRange(n.Arguments);
	}

	
	
	public override void Visit(BlockStatement n)
	{
		children.AddRange(n.Declarations);
		children.AddRange(n.Statements);
	}

	
	
	public override void Visit(IfStatement n)
	{
		children.Add(n.Condition);
		children.Add(n.IfClause);
	}

	
	
	public override void Visit(IfElseStatement n)
	{
		children.Add(n.Condition);
		children.Add(n.IfClause);
		children.Add(n.ElseClause);
	}

	
	
	public override void Visit(WhileStatement n)
	{
		children.Add(n.Condition);
		children.Add(n.Body);
	}

	
	
	public override void Visit(ReturnValueStatement n)
	{
		children.Add(n.Value);
	}

	
	
	public override void Visit(Assignment n)
	{
		children.Add(n.Identifier);
		children.Add(n.Value);
	}

	
	
	public override void Visit(FunctionCall n)
	{
		children.Add(n.Identifier);
		children.AddRange(n.Arguments);
	}

	
	
	public override void Visit(IdentifierExpression n)
	{
		children.Add(n.Identifier);
	}

	
	
	public override void Visit(UnaryExpression n)
	{
		children.Add(n.Arg1);
	}

	
	
	public override void Visit(BinaryExpression n)
	{
		children.Add(n.Arg1);
		children.Add(n.Arg2);
	}
}
