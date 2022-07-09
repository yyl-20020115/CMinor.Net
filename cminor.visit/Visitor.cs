
using CMinor.AST;



namespace CMinor.Visit;

public class Visitor
{
	public virtual void visit(AstNode n)
	{
	}

	
	
	public virtual void Visit(Statement n)
	{
		visit((AstNode)n);
	}

	
	
	public virtual void Visit(Expression n)
	{
		Visit((Statement)n);
	}

	
	
	public virtual void Visit(UnaryExpression n)
	{
		Visit((Expression)n);
	}

	
	
	public virtual void Visit(BinaryExpression n)
	{
		Visit((UnaryExpression)n);
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
		Visit((Expression)n);
	}

	
	
	public virtual void Visit(BinaryLogicalOperator n)
	{
		Visit((BinaryExpression)n);
	}

	
	
	public virtual void Visit(BlockStatement n)
	{
		Visit((Statement)n);
	}

	
	
	public virtual void Visit(ConstantExpression n)
	{
		Visit((Expression)n);
	}

	
	
	public virtual void Visit(BooleanLiteral n)
	{
		Visit((ConstantExpression)n);
	}

	
	
	public virtual void Visit(CharacterLiteral n)
	{
		Visit((ConstantExpression)n);
	}

	
	
	public virtual void Visit(Declaration n)
	{
		visit((AstNode)n);
	}

	
	
	public virtual void Visit(Division n)
	{
		Visit((BinaryArithmeticOperator)n);
	}

	
	
	public virtual void Visit(RelationalOperator n)
	{
		Visit((BinaryExpression)n);
	}

	
	
	public virtual void Visit(EqualTo n)
	{
		Visit((RelationalOperator)n);
	}

	
	
	public virtual void Visit(ExternalDeclaration n)
	{
		visit((AstNode)n);
	}

	
	
	public virtual void Visit(FunctionCall n)
	{
		Visit((Expression)n);
	}

	
	
	public virtual void Visit(FunctionDefinition n)
	{
		Visit((ExternalDeclaration)n);
	}

	
	
	public virtual void Visit(GlobalVariableDeclaration n)
	{
		Visit((ExternalDeclaration)n);
	}

	
	
	public virtual void Visit(GlobalVariableInitialization n)
	{
		Visit((GlobalVariableDeclaration)n);
	}

	
	
	public virtual void Visit(GreaterThan n)
	{
		Visit((RelationalOperator)n);
	}

	
	
	public virtual void Visit(GreaterThanOrEqualTo n)
	{
		Visit((RelationalOperator)n);
	}

	
	
	public virtual void Visit(Identifier n)
	{
		visit((AstNode)n);
	}

	
	
	public virtual void Visit(IdentifierExpression n)
	{
		Visit((Expression)n);
	}

	
	
	public virtual void Visit(IfStatement n)
	{
		Visit((Statement)n);
	}

	
	
	public virtual void Visit(IfElseStatement n)
	{
		Visit((IfStatement)n);
	}

	
	
	public virtual void Visit(Initialization n)
	{
		Visit((Declaration)n);
	}

	
	
	public virtual void Visit(IntegerLiteral n)
	{
		Visit((ConstantExpression)n);
	}

	
	
	public virtual void Visit(LessThan n)
	{
		Visit((RelationalOperator)n);
	}

	
	
	public virtual void Visit(LessThanOrEqualTo n)
	{
		Visit((RelationalOperator)n);
	}

	
	
	public virtual void Visit(LogicalAnd n)
	{
		Visit((BinaryLogicalOperator)n);
	}

	
	
	public virtual void Visit(LogicalNot n)
	{
		Visit((UnaryExpression)n);
	}

	
	
	public virtual void Visit(LogicalOr n)
	{
		Visit((BinaryLogicalOperator)n);
	}

	
	
	public virtual void Visit(Multiplication n)
	{
		Visit((BinaryArithmeticOperator)n);
	}

	
	
	public virtual void Visit(Negative n)
	{
		Visit((UnaryExpression)n);
	}

	
	
	public virtual void Visit(NotEqualTo n)
	{
		Visit((RelationalOperator)n);
	}

	
	
	public virtual void Visit(Parameter n)
	{
		visit((AstNode)n);
	}

	
	
	public virtual void visit(PrintStatement n)
	{
		Visit((Statement)n);
	}

	
	
	public virtual void Visit(Program n)
	{
		visit((AstNode)n);
	}

	
	
	public virtual void Visit(ReturnVoidStatement n)
	{
		Visit((Statement)n);
	}

	
	
	public virtual void Visit(ReturnValueStatement n)
	{
		Visit((ReturnVoidStatement)n);
	}

	
	
	public virtual void Visit(StringLiteral n)
	{
		Visit((ConstantExpression)n);
	}

	
	
	public virtual void Visit(Subtraction n)
	{
		Visit((BinaryArithmeticOperator)n);
	}

	
	
	public virtual void Visit(TypeSpecifier n)
	{
		visit((AstNode)n);
	}

	
	
	public virtual void Visit(WhileStatement n)
	{
		Visit((Statement)n);
	}

	
	
	public Visitor()
	{
	}
}
