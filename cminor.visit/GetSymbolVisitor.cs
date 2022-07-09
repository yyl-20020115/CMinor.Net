
using CMinor.AST;



namespace CMinor.Visit;

public class GetSymbolVisitor : Visitor
{
	
	private IList symbols;

	
	
	public GetSymbolVisitor()
	{
	}

	
	public virtual void setSymbols(IList symbols)
	{
		this.symbols = symbols;
	}

	
	public virtual IList getSymbols()
	{
		return symbols;
	}

	public override void visit(AstNode n)
	{
	}

	
	
	public override void Visit(Program n)
	{
		FunctionDefinition mainFunction = n.MainFunction;
		if (mainFunction != null)
		{
			symbols.Add(mainFunction.Symbol);
		}
	}

	
	
	public override void Visit(Identifier n)
	{
		symbols.Add(n.Symbol);
	}
}
