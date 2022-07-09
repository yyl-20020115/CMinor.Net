using CMinor.Parser;
using CMinor.Symbol;
using CMinor.Visit;

namespace CMinor.AST;

public class StringLiteral : ConstantExpression
{
    private StringSymbol symbol;

    public StringLiteral(LocationInfo info, string value)
        : base(info, value)
    {
    }

    public virtual StringSymbol Symbol { get => symbol; set => this.symbol = value; }

    public override void Accept(Visitor v)
    {
        v.Visit(this);
    }

    public static string escape(string s)
        => s.Replace("\\", "\\\\")
        .Replace("\"", "\\\"")
        .Replace("'", "\\'")
        .Replace("\n", "\\n")
        .Replace("\0", "\\0")
        ;
}
