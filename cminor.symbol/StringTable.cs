using System.Collections.Generic;
using System.Linq;

namespace CMinor.Symbol;

public class StringTable
{
    private Dictionary<string, StringSymbol> dict = new();
    private LabelGenerator labeler = new("string");

    public StringTable()
    {
    }

    public virtual StringSymbol GetSymbol(string value)
    {
        if (!this.dict.TryGetValue(value, out var symbol))
        {
            this.dict.Add(value, symbol = new StringSymbol(value, labeler.GetCurrentLabel()));
        }
        return symbol;
    }

    public virtual List<StringSymbol> Symbols => this.dict.Values.ToList();
}
