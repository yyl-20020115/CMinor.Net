
using CMinor.AST;

using java.lang;

namespace CMinor.Visit;

public class Visitor
{
	public virtual void visit(AstNode n)
	{
	}

	
	
	public virtual void visit(Statement n)
	{
		visit((AstNode)n);
	}

	
	
	public virtual void visit(Expression n)
	{
		visit((Statement)n);
	}

	
	
	public virtual void visit(UnaryExpression n)
	{
		visit((Expression)n);
	}

	
	
	public virtual void Visit(BinaryExpression n)
	{
		visit((UnaryExpression)n);
	}

	
	
	public virtual void Visit(BinaryArithmeticOperator n)
	{
		Visit((BinaryExpression)n);
	}

	
	
	public virtual void Visit(Addition n)
	{
		Visit((BinaryArithmeticOperator)n);
	}

	
	
	public virtual void visit(Assignment n)
	{
		visit((Expression)n);
	}

	
	
	public virtual void Visit(BinaryLogicalOperator n)
	{
		Visit((BinaryExpression)n);
	}

	
	
	public virtual void Visit(BlockStatement n)
	{
		visit((Statement)n);
	}

	
	
	public virtual void visit(ConstantExpression n)
	{
		visit((Expression)n);
	}

	
	
	public virtual void visit(BooleanLiteral n)
	{
		visit((ConstantExpression)n);
	}

	
	
	public virtual void visit(CharacterLiteral n)
	{
		visit((ConstantExpression)n);
	}

	
	
	public virtual void visit(Declaration n)
	{
		visit((AstNode)n);
	}

	
	
	public virtual void visit(Division n)
	{
		Visit((BinaryArithmeticOperator)n);
	}

	
	
	public virtual void visit(RelationalOperator n)
	{
		Visit((BinaryExpression)n);
	}

	
	
	public virtual void visit(EqualTo n)
	{
		visit((RelationalOperator)n);
	}

	
	
	public virtual void visit(ExternalDeclaration n)
	{
		visit((AstNode)n);
	}

	
	
	public virtual void visit(FunctionCall n)
	{
		visit((Expression)n);
	}

	
	
	public virtual void visit(FunctionDefinition n)
	{
		visit((ExternalDeclaration)n);
	}

	
	
	public virtual void visit(GlobalVariableDeclaration n)
	{
		visit((ExternalDeclaration)n);
	}

	
	
	public virtual void visit(GlobalVariableInitialization n)
	{
		visit((GlobalVariableDeclaration)n);
	}

	
	
	public virtual void visit(GreaterThan n)
	{
		visit((RelationalOperator)n);
	}

	
	
	public virtual void visit(GreaterThanOrEqualTo n)
	{
		visit((RelationalOperator)n);
	}

	
	
	public virtual void visit(Identifier n)
	{
		visit((AstNode)n);
	}

	
	
	public virtual void visit(IdentifierExpression n)
	{
		visit((Expression)n);
	}

	
	
	public virtual void visit(IfStatement n)
	{
		visit((Statement)n);
	}

	
	
	public virtual void visit(IfElseStatement n)
	{
		visit((IfStatement)n);
	}

	
	
	public virtual void visit(Initialization n)
	{
		visit((Declaration)n);
	}

	
	
	public virtual void visit(IntegerLiteral n)
	{
		visit((ConstantExpression)n);
	}

	
	
	public virtual void visit(LessThan n)
	{
		visit((RelationalOperator)n);
	}

	
	
	public virtual void visit(LessThanOrEqualTo n)
	{
		visit((RelationalOperator)n);
	}

	
	
	public virtual void visit(LogicalAnd n)
	{
		Visit((BinaryLogicalOperator)n);
	}

	
	
	public virtual void visit(LogicalNot n)
	{
		visit((UnaryExpression)n);
	}

	
	
	public virtual void visit(LogicalOr n)
	{
		Visit((BinaryLogicalOperator)n);
	}

	
	
	public virtual void visit(Multiplication n)
	{
		Visit((BinaryArithmeticOperator)n);
	}

	
	
	public virtual void visit(Negative n)
	{
		visit((UnaryExpression)n);
	}

	
	
	public virtual void visit(NotEqualTo n)
	{
		visit((RelationalOperator)n);
	}

	
	
	public virtual void visit(Parameter n)
	{
		visit((AstNode)n);
	}

	
	
	public virtual void visit(PrintStatement n)
	{
		visit((Statement)n);
	}

	
	
	public virtual void visit(Program n)
	{
		visit((AstNode)n);
	}

	
	
	public virtual void visit(ReturnVoidStatement n)
	{
		visit((Statement)n);
	}

	
	
	public virtual void visit(ReturnValueStatement n)
	{
		visit((ReturnVoidStatement)n);
	}

	
	
	public virtual void visit(StringLiteral n)
	{
		visit((ConstantExpression)n);
	}

	
	
	public virtual void visit(Subtraction n)
	{
		Visit((BinaryArithmeticOperator)n);
	}

	
	
	public virtual void visit(TypeSpecifier n)
	{
		visit((AstNode)n);
	}

	
	
	public virtual void visit(WhileStatement n)
	{
		visit((Statement)n);
	}

	
	
	public Visitor()
	{
	}
}
