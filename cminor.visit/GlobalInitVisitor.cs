
using CMinor.AST;

using java.lang;

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
		result = new StringBuilder().append("").append((int)((Character)n.getValue()).charValue()).toString();
	}

	
	
	public override void visit(IntegerLiteral n)
	{
		result = ((Integer)n.getValue()).toString();
	}

	
	
	public override void visit(StringLiteral n)
	{
		result = n.getSymbol().getLabel();
	}
}
