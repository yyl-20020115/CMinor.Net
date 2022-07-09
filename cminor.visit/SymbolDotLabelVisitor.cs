using CMinor.Symbol;

namespace CMinor.Visit;

public class SymbolDotLabelVisitor : SymbolVisitor
{
    private string label;

    public SymbolDotLabelVisitor()
    {
    }

    public virtual string Label => label;

    public override void Visit(FunctionSymbol s)
    {
        label = ("FUNCTION ") + (s.Identifier);
    }

    public override void Visit(GlobalVariableSymbol s)
    {
        label = ("GLOBAL ") + (s.Identifier);
    }

    public override void Visit(LocalVariableSymbol s)
    {
        label = ("LOCAL ") + (s.Identifier);
    }
    public override void Visit(ParameterSymbol s)
    {
        label = ("PARAM ") + (s.Identifier);
    }
}
