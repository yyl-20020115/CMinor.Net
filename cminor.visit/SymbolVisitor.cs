using CMinor.Symbol;

namespace CMinor.Visit;

public class SymbolVisitor
{
    public virtual void Visit(Symbol.Symbol s)
    {
    }


    public virtual void Visit(FunctionSymbol s)
    {
        Visit((Symbol.Symbol)s);
    }

    public virtual void Visit(GlobalVariableSymbol s)
    {
        Visit((Symbol.Symbol)s);
    }

    public virtual void Visit(StackVariableSymbol s)
    {
        Visit((Symbol.Symbol)s);
    }

    public virtual void Visit(LocalVariableSymbol s)
    {
        Visit((StackVariableSymbol)s);
    }

    public virtual void Visit(ParameterSymbol s)
    {
        Visit((StackVariableSymbol)s);
    }

    public SymbolVisitor()
    {
    }
}
