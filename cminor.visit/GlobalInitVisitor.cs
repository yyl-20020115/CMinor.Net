using CMinor.AST;

namespace CMinor.Visit;

public class GlobalInitVisitor : Visitor
{
    private string result;


    public static string Get(AstNode n)
    {
        var globalInitVisitor = new GlobalInitVisitor();
        n.Accept(globalInitVisitor);
        return globalInitVisitor.Result;
    }



    public GlobalInitVisitor()
    {
    }

    public virtual string Result => result;


    public override void Visit(BooleanLiteral n)
    {
        result = ((!(n.Value)) ? "0" : "1");
    }

    public override void Visit(CharacterLiteral n)
    {
        result = ("") + ((int)((char)n.Value));
    }

    public override void Visit(IntegerLiteral n)
    {
        result = n.Value.ToString();
    }

    public override void Visit(StringLiteral n)
    {
        result = n.Symbol.Label;
    }
}
