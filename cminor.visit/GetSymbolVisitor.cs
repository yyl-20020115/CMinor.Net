using CMinor.AST;
using System.Collections.Generic;

namespace CMinor.Visit;

public class GetSymbolVisitor : Visitor
{

    private List<CMinor.Symbol.Symbol> symbols = new();

    public GetSymbolVisitor()
    {
    }

    public virtual List<CMinor.Symbol.Symbol> Symbols { get => symbols; set => this.symbols = value; }

    public override void Visit(AstNode n)
    {
    }



    public override void Visit(Program n)
    {
        var mainFunction = n.MainFunction;
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
