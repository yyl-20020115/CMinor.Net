
using CMinor.Parser;
using CMinor.Symbol;
using CMinor.Visit;


namespace CMinor.AST;

public class Identifier : AstNode
{
	private string name;

	private CMinor.Symbol.Symbol symbol;

	
	
	public Identifier(LocationInfo info, string name)
		: base(info)
	{
		this.name = name;
		symbol = null;
	}

	public virtual string getString()
	{
		return name;
	}

	public virtual CMinor.Symbol.Symbol getSymbol()
	{
		return symbol;
	}

	public virtual void setSymbol(CMinor.Symbol.Symbol symbol)
	{
		this.symbol = symbol;
	}

	
	
	public override void Accept(Visitor v)
	{
		v.visit(this);
	}
}