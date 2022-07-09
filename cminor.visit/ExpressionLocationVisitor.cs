using CMinor.AST;

namespace CMinor.Visit;

public class ExpressionLocationVisitor : Visitor
{
    private string result;

    public static string get(AstNode n)
    {
        var expressionLocationVisitor = new ExpressionLocationVisitor();
        n.Accept(expressionLocationVisitor);
        string text = expressionLocationVisitor.Result;

        return text;
    }



    public ExpressionLocationVisitor()
    {
    }

    public virtual string Result => result;



    public override void Visit(IdentifierExpression n)
    {
        result = SymbolLocationVisitor.Get(n.Identifier.Symbol);
    }



    public override void Visit(ConstantExpression n)
    {
        result = ("$") + (GlobalInitVisitor.Get(n));
    }
}
