
using CMinor.Parser;
using CMinor.Symbol;
using CMinor.Visit;



namespace CMinor.AST;

public class FunctionCall : Expression
{
	private Identifier name;

	
	private List arguments;

	private FunctionSymbol symbol;

	
	
	
	public FunctionCall(LocationInfo info, Identifier name, List arguments)
		: base(info)
	{
		this.name = name;
		this.arguments = arguments;
	}

	public virtual Identifier getIdentifier()
	{
		return name;
	}

	
	public virtual List getArguments()
	{
		return arguments;
	}

	public virtual FunctionSymbol getSymbol()
	{
		return symbol;
	}

	public virtual void setSymbol(FunctionSymbol symbol)
	{
		this.symbol = symbol;
	}

	
	
	public override void Accept(Visitor v)
	{
		v.visit(this);
	}
}
