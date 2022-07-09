
using CMinor.AST;

using java.lang;

namespace CMinor.Visit;

public class ExpressionLocationVisitor : Visitor
{
	private string result;

	
	
	public static string get(AstNode n)
	{
		ExpressionLocationVisitor expressionLocationVisitor = new ExpressionLocationVisitor();
		n.Accept(expressionLocationVisitor);
		string text = expressionLocationVisitor.getResult();
		
		return text;
	}

	
	
	public ExpressionLocationVisitor()
	{
	}

	public virtual string getResult()
	{
		return result;
	}

	
	
	public override void visit(IdentifierExpression n)
	{
		result = SymbolLocationVisitor.get(n.getIdentifier().getSymbol());
	}

	
	
	public override void visit(ConstantExpression n)
	{
		result = new StringBuilder().append("$").append(GlobalInitVisitor.get(n)).toString();
	}
}
