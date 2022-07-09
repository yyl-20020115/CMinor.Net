
using CMinor.Symbol;

using java.lang;

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
		label = new StringBuilder().append("FUNCTION ").append(s.getIdentifier()).toString();
	}

	
	
	public override void visit(GlobalVariableSymbol s)
	{
		label = new StringBuilder().append("GLOBAL ").append(s.getIdentifier()).toString();
	}

	
	
	public override void visit(LocalVariableSymbol s)
	{
		label = new StringBuilder().append("LOCAL ").append(s.getIdentifier()).toString();
	}

	
	
	public override void visit(ParameterSymbol s)
	{
		label = new StringBuilder().append("PARAM ").append(s.getIdentifier()).toString();
	}
}
