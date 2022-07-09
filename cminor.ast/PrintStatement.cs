using CMinor.Parser;
using CMinor.Symbol;
using CMinor.Visit;
using System.Collections;
using System.Collections.Generic;

namespace CMinor.AST;

public class PrintStatement : Statement
{
    public const string TRUE_STRING = "true";

    public const string FALSE_STRING = "false";

    public const string BOOL_STRING = "false\0true";

    internal static int offset;

    public const string CHAR_FORMAT = "%c";

    public const string INT_FORMAT = "%d";

    public const string STRING_FORMAT = "%s";

    private List<AstNode> arguments;

    private StringSymbol symbol;

    private IList actualArguments;

    public static int OFFSET => offset;

    public PrintStatement(LocationInfo info, List<AstNode> arguments)
        : base(info)
    {
        this.arguments = arguments;
    }

    public virtual List<AstNode> Arguments => arguments;

    public virtual StringSymbol Symbol { get => symbol; set => this.symbol = value; }


    public virtual IList ActualArguments { get => actualArguments; set => this.actualArguments = value; }

    public override void Accept(Visitor v)
    {
        v.visit(this);
    }


    static PrintStatement()
    {
        offset = ("false").Length + 1;
    }
}
