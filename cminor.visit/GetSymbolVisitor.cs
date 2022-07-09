
using CMinor.AST;



namespace CMinor.Visit;

public class GetSymbolVisitor : Visitor
{
	
	private List symbols;

	
	
	public GetSymbolVisitor()
	{
	}

	
	public virtual void setSymbols(List symbols)
	{
		this.symbols = symbols;
	}

	
	public virtual List getSymbols()
	{
		return symbols;
	}

	public override void visit(AstNode n)
	{
	}

	
	
	public override void visit(Program n)
	{
		FunctionDefinition mainFunction = n.getMainFunction();
		if (mainFunction != null)
		{
			symbols.add(mainFunction.getSymbol());
		}
	}

	
	
	public override void visit(Identifier n)
	{
		symbols.add(n.getSymbol());
	}
}
