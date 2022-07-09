
using CMinor.AST;



namespace CMinor.Visit;

public class GlobalInitVisitor : Visitor
{
	private string result;

	
	
	public static string get(AstNode n)
	{
		GlobalInitVisitor globalInitVisitor = new GlobalInitVisitor();
		n.Accept(globalInitVisitor);
		string text = globalInitVisitor.getResult();
		
		return text;
	}

	
	
	public GlobalInitVisitor()
	{
	}

	public virtual string getResult()
	{
		return result;
	}

	
	
	public override void visit(BooleanLiteral n)
	{
		result = ((!((Boolean)n.getValue()).booleanValue()) ? "0" : "1");
	}

	
	
	public override void visit(CharacterLiteral n)
	{
		result = ("")+((int)((Character)n.getValue()).charValue());
	}

	
	
	public override void visit(IntegerLiteral n)
	{
		result = ((Integer)n.getValue());
	}

	
	
	public override void visit(StringLiteral n)
	{
		result = n.getSymbol().getLabel();
	}
}
