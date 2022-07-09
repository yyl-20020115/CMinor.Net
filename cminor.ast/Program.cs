using CMinor.Parser;
using CMinor.Symbol;
using CMinor.Visit;
using System.Collections;
using System.Collections.Generic;

namespace CMinor.AST;

public class Program : AstNode
{
    public const string MAIN_FUNCTION_NAME = "main";
    private List<ExternalDeclaration> declarations = new();
    private FunctionDefinition mainFunction;
    private List<FunctionDefinition> functions = new();
    private List<GlobalVariableDeclaration> globalVariables = new();
    private List<StringSymbol> stringSymbols = new();
    private StringSymbol boolStringSymbol;

    public Program(LocationInfo info, List<ExternalDeclaration> declarations)
        : base(info)
    {
        this.declarations = declarations;
    }

    public virtual List<ExternalDeclaration> Declarations => declarations;
    public virtual FunctionDefinition MainFunction { get => mainFunction; set => this.mainFunction = value; }
    public virtual List<GlobalVariableDeclaration> GlobalVariables { get => globalVariables; set => this.globalVariables = value; }
    public virtual List<FunctionDefinition> Functions { get => functions; set => this.functions = value; }
    public virtual List<StringSymbol> StringSymbols { get => stringSymbols; set => this.stringSymbols = value; }
    public virtual StringSymbol BooleanStringSymbol { get => boolStringSymbol; set => boolStringSymbol = value; }

    public override void Accept(Visitor v)
    {
        v.Visit(this);
    }
}
