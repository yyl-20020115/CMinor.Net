using CMinor.Symbol;

namespace CMinor.Visit;

public class SymbolLocationVisitor : SymbolVisitor
{
    private string result;

    public static string Get(Symbol.Symbol s)
    {
        var symbolLocationVisitor = new SymbolLocationVisitor();
        s.Accept(symbolLocationVisitor);
        return symbolLocationVisitor.Result;
    }

    public SymbolLocationVisitor()
    {
    }

    public virtual string Result => result;


    public override void Visit(GlobalVariableSymbol s)
    {
        result = s.Label;
    }

    public override void Visit(StackVariableSymbol s)
    {
        result = (s.Offset) + ("(%ebp)");
    }
}
