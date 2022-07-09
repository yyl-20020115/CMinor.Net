
using CMinor.AST;



namespace CMinor.Visit;

public class ChildVisitor : Visitor
{
	
	private List children;

	
	
	public ChildVisitor()
	{
	}

	
	public virtual void setChildren(List children)
	{
		this.children = children;
	}

	
	public virtual List getChildren()
	{
		return children;
	}

	
	
	public override void visit(Program n)
	{
		children.addAll(n.getDeclarations());
	}

	
	
	public override void visit(Parameter n)
	{
		children.add(n.getType());
		children.add(n.getIdentifier());
	}

	
	
	public override void visit(FunctionDefinition n)
	{
		children.add(n.getReturnType());
		children.add(n.getIdentifier());
		children.addAll(n.getParameters());
		children.add(n.getBody());
	}

	
	
	public override void visit(GlobalVariableDeclaration n)
	{
		children.add(n.getType());
		children.add(n.getIdentifier());
	}

	
	
	public override void visit(GlobalVariableInitialization n)
	{
		children.add(n.getType());
		children.add(n.getIdentifier());
		children.add(n.getValue());
	}

	
	
	public override void visit(Declaration n)
	{
		children.add(n.getType());
		children.add(n.getIdentifier());
	}

	
	
	public override void visit(Initialization n)
	{
		children.add(n.getType());
		children.add(n.getIdentifier());
		children.add(n.getValue());
	}

	
	
	public override void visit(PrintStatement n)
	{
		children.addAll(n.getArguments());
	}

	
	
	public override void Visit(BlockStatement n)
	{
		children.addAll(n.getDeclarations());
		children.addAll(n.getStatements());
	}

	
	
	public override void visit(IfStatement n)
	{
		children.add(n.getCondition());
		children.add(n.getIfClause());
	}

	
	
	public override void visit(IfElseStatement n)
	{
		children.add(n.getCondition());
		children.add(n.getIfClause());
		children.add(n.getElseClause());
	}

	
	
	public override void visit(WhileStatement n)
	{
		children.add(n.getCondition());
		children.add(n.getBody());
	}

	
	
	public override void visit(ReturnValueStatement n)
	{
		children.add(n.getValue());
	}

	
	
	public override void visit(Assignment n)
	{
		children.add(n.Identifier);
		children.add(n.Value);
	}

	
	
	public override void visit(FunctionCall n)
	{
		children.add(n.getIdentifier());
		children.addAll(n.getArguments());
	}

	
	
	public override void visit(IdentifierExpression n)
	{
		children.add(n.getIdentifier());
	}

	
	
	public override void visit(UnaryExpression n)
	{
		children.add(n.getArg1());
	}

	
	
	public override void Visit(BinaryExpression n)
	{
		children.add(n.getArg1());
		children.add(n.Arg2);
	}
}
