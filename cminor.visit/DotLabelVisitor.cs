
using CMinor.AST;



namespace CMinor.Visit;

public class DotLabelVisitor : Visitor
{
	private string label;

	
	
	public DotLabelVisitor()
	{
	}

	public virtual string getLabel()
	{
		return label;
	}

	public override void Visit(Program n)
	{
		label = "PROGRAM";
	}

	
	
	public override void Visit(Identifier n)
	{
		label = n.Name;
	}

	
	
	public override void Visit(TypeSpecifier n)
	{
		label = n.Type.Name;
	}

	public override void Visit(Parameter n)
	{
		label = "PARAM";
	}

	public override void Visit(FunctionDefinition n)
	{
		label = "FUNCTION";
	}

	public override void Visit(GlobalVariableDeclaration n)
	{
		label = "GLOBAL";
	}

	public override void Visit(Declaration n)
	{
		label = "LOCAL";
	}

	public override void visit(PrintStatement n)
	{
		label = "PRINT";
	}

	public override void Visit(BlockStatement n)
	{
		label = "BLOCK";
	}

	public override void Visit(IfStatement n)
	{
		label = "IF";
	}

	public override void Visit(WhileStatement n)
	{
		label = "WHILE";
	}

	public override void Visit(ReturnVoidStatement n)
	{
		label = "RETURN";
	}

	public override void visit(Assignment n)
	{
		label = "=";
	}

	public override void Visit(FunctionCall n)
	{
		label = "CALL";
	}

	public override void Visit(IdentifierExpression n)
	{
		label = "ID";
	}

	
	
	public override void Visit(BooleanLiteral n)
	{
		label = ((!((Boolean)n.Value).booleanValue()) ? "false" : "true");
	}

	
	public override void Visit(CharacterLiteral n)
	{
		label = ("\\'")+(StringLiteral.escape(StringLiteral.escape(((char)n.Value))))+("\\'")
			.ToString();
	}

	
	
	public override void Visit(IntegerLiteral n)
	{
		label = ((int)n.Value);
	}

	
	
	public override void Visit(StringLiteral n)
	{
		label = ("\\\"")+(StringLiteral.escape(StringLiteral.escape((string)n.Value)))+("\\\"")
			.ToString();
	}

	public override void Visit(Negative n)
	{
		label = "-";
	}

	public override void Visit(LogicalNot n)
	{
		label = "!";
	}

	public override void Visit(Addition n)
	{
		label = "+";
	}

	public override void Visit(Subtraction n)
	{
		label = "-";
	}

	public override void Visit(Multiplication n)
	{
		label = "*";
	}

	public override void Visit(Division n)
	{
		label = "/";
	}

	public override void Visit(EqualTo n)
	{
		label = "==";
	}

	public override void Visit(NotEqualTo n)
	{
		label = "!=";
	}

	public override void Visit(GreaterThan n)
	{
		label = ">";
	}

	public override void Visit(GreaterThanOrEqualTo n)
	{
		label = ">=";
	}

	public override void Visit(LessThan n)
	{
		label = "<";
	}

	public override void Visit(LessThanOrEqualTo n)
	{
		label = "<=";
	}

	public override void Visit(LogicalAnd n)
	{
		label = "&&";
	}

	public override void Visit(LogicalOr n)
	{
		label = "||";
	}
}
