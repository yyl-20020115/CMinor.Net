using CMinor.Parser;
using CMinor.Symbol;
using CMinor.Visit;
using System.Collections;

namespace CMinor.AST;

public class Program : AstNode
{
    public const string MAIN_FUNCTION_NAME = "main";
    private IList declarations;
    private FunctionDefinition mainFunction;
    private IList functions;
    private IList globalVariables;
    private IList stringSymbols;
    private StringSymbol boolStringSymbol;

    public Program(LocationInfo info, IList declarations)
        : base(info)
    {
        this.declarations = declarations;
    }

    public virtual IList Declarations => declarations;
    public virtual FunctionDefinition MainFunction { get => mainFunction; set => this.mainFunction = value; }
    public virtual IList GlobalVariables { get => globalVariables; set => this.globalVariables = value; }
    public virtual IList Functions { get => functions; set => this.functions = value; }
    public virtual IList StringSymbols { get => stringSymbols; set => this.stringSymbols = value; }
    public virtual StringSymbol BooleanStringSymbol { get => boolStringSymbol; set => boolStringSymbol = value; }

    public override void Accept(Visitor v)
    {
        v.Visit(this);
    }
}
