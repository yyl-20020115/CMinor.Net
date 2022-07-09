
using CMinor.Symbol;



namespace CMinor.Visit;

public class SymbolDotLabelVisitor : SymbolVisitor
{
	private string label;

	
	
	public SymbolDotLabelVisitor()
	{
	}

	public virtual string getLabel()
	{
		return label;
	}

	
	
	public override void visit(FunctionSymbol s)
	{
		label = ("FUNCTION ")+(s.getIdentifier());
	}

	
	
	public override void visit(GlobalVariableSymbol s)
	{
		label = ("GLOBAL ")+(s.getIdentifier());
	}

	
	
	public override void visit(LocalVariableSymbol s)
	{
		label = ("LOCAL ")+(s.getIdentifier());
	}

	
	
	public override void visit(ParameterSymbol s)
	{
		label = ("PARAM ")+(s.getIdentifier());
	}
}
