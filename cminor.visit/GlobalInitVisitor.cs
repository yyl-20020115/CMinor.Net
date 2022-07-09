
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

	
	
	public override void Visit(BooleanLiteral n)
	{
		result = ((!((Boolean)n.Value).booleanValue()) ? "0" : "1");
	}

	
	
	public override void Visit(CharacterLiteral n)
	{
		result = ("")+((int)((char)n.Value).charValue());
	}

	
	
	public override void Visit(IntegerLiteral n)
	{
		result = ((int)n.Value);
	}

	
	
	public override void Visit(StringLiteral n)
	{
		result = n.Symbol.Label;
	}
}
