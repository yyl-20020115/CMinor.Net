using CMinor.Parser;
using CMinor.Symbol;
using CMinor.Visit;
using System.Collections;
using System.Collections.Generic;

namespace CMinor.AST;

public class FunctionDefinition : ExternalDeclaration
{
    private TypeSpecifier returnType;

    private List<Parameter> parameters;

    private BlockStatement body;

    private FunctionSymbol symbol;

    private bool doesEndWithReturn;

    private int numLocals;

    public FunctionDefinition(LocationInfo info, TypeSpecifier returnType, Identifier name, List<Parameter> parameters, BlockStatement body)
        : base(info, name)
    {
        this.returnType = returnType;
        this.parameters = parameters;
        this.body = body;
        numLocals = 0;
    }

    public virtual TypeSpecifier ReturnType => returnType;
    public virtual List<Parameter> Parameters => parameters;
    public virtual BlockStatement Body => body;
    public virtual FunctionSymbol Symbol { get => symbol; set => this.symbol = value; }

    public virtual bool EndsWithReturn
    {
        get => doesEndWithReturn;
        set
        {
            int num = ((doesEndWithReturn = value) ? 1 : 0);
        }
    }

    public virtual int NumLocals => numLocals;
    public virtual void RaiseNumLocals(int max)
    {
        if (max > numLocals)
        {
            numLocals = max;
        }
    }

    public override void Accept(Visitor v)
    {
        v.Visit(this);
    }
}
