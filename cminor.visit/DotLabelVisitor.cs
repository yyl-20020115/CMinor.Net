
using CMinor.AST;

using java.lang;

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

	public override void visit(Program n)
	{
		label = "PROGRAM";
	}

	
	
	public override void visit(Identifier n)
	{
		label = n.getString();
	}

	
	
	public override void visit(TypeSpecifier n)
	{
		label = n.getType().getName();
	}

	public override void visit(Parameter n)
	{
		label = "PARAM";
	}

	public override void visit(FunctionDefinition n)
	{
		label = "FUNCTION";
	}

	public override void visit(GlobalVariableDeclaration n)
	{
		label = "GLOBAL";
	}

	public override void visit(Declaration n)
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

	public override void visit(IfStatement n)
	{
		label = "IF";
	}

	public override void visit(WhileStatement n)
	{
		label = "WHILE";
	}

	public override void visit(ReturnVoidStatement n)
	{
		label = "RETURN";
	}

	public override void visit(Assignment n)
	{
		label = "=";
	}

	public override void visit(FunctionCall n)
	{
		label = "CALL";
	}

	public override void visit(IdentifierExpression n)
	{
		label = "ID";
	}

	
	
	public override void visit(BooleanLiteral n)
	{
		label = ((!((Boolean)n.getValue()).booleanValue()) ? "false" : "true");
	}

	
	[LineNumberTable(new byte[]
	{
		74,
		byte.MaxValue,
		36,
		69
	})]
	public override void visit(CharacterLiteral n)
	{
		label = new StringBuilder().append("\\'").append(StringLiteral.escape(StringLiteral.escape(((Character)n.getValue()).toString()))).append("\\'")
			.toString();
	}

	
	
	public override void visit(IntegerLiteral n)
	{
		label = ((Integer)n.getValue()).toString();
	}

	
	
	public override void visit(StringLiteral n)
	{
		label = new StringBuilder().append("\\\"").append(StringLiteral.escape(StringLiteral.escape((string)n.getValue()))).append("\\\"")
			.toString();
	}

	public override void visit(Negative n)
	{
		label = "-";
	}

	public override void visit(LogicalNot n)
	{
		label = "!";
	}

	public override void Visit(Addition n)
	{
		label = "+";
	}

	public override void visit(Subtraction n)
	{
		label = "-";
	}

	public override void visit(Multiplication n)
	{
		label = "*";
	}

	public override void visit(Division n)
	{
		label = "/";
	}

	public override void visit(EqualTo n)
	{
		label = "==";
	}

	public override void visit(NotEqualTo n)
	{
		label = "!=";
	}

	public override void visit(GreaterThan n)
	{
		label = ">";
	}

	public override void visit(GreaterThanOrEqualTo n)
	{
		label = ">=";
	}

	public override void visit(LessThan n)
	{
		label = "<";
	}

	public override void visit(LessThanOrEqualTo n)
	{
		label = "<=";
	}

	public override void visit(LogicalAnd n)
	{
		label = "&&";
	}

	public override void visit(LogicalOr n)
	{
		label = "||";
	}
}
