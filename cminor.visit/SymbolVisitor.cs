
using CMinor.Symbol;

using java.lang;

namespace CMinor.Visit;

public class SymbolVisitor
{
	public virtual void visit(Symbol.Symbol s)
	{
	}

	
	
	public virtual void visit(FunctionSymbol s)
	{
        visit((Symbol.Symbol)s);
	}

	
	
	public virtual void visit(GlobalVariableSymbol s)
	{
        visit((Symbol.Symbol)s);
	}

	
	
	public virtual void visit(StackVariableSymbol s)
	{
        visit((Symbol.Symbol)s);
	}

	
	
	public virtual void visit(LocalVariableSymbol s)
	{
		visit((StackVariableSymbol)s);
	}

	
	
	public virtual void visit(ParameterSymbol s)
	{
		visit((StackVariableSymbol)s);
	}

	
	
	public SymbolVisitor()
	{
	}
}
