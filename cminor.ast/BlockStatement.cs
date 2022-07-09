using CMinor.Parser;
using CMinor.Visit;
using System.Collections;
using System.Collections.Generic;

namespace CMinor.AST;

public class BlockStatement : Statement
{
    private DeclarationList declarations;

    private StatementList statements;

    public BlockStatement(LocationInfo info, DeclarationList declarations, StatementList statements)
        : base(info)
    {
        this.declarations = declarations;
        this.statements = statements;
    }


    public virtual DeclarationList Declarations => declarations;
    public virtual StatementList Statements => statements;

    public override void Accept(Visitor v)
    {
        v.Visit(this);
    }
}
