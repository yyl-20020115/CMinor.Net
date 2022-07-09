
using CMinor.Symbol;



namespace CMinor.Visit;

public class SymbolLocationVisitor : SymbolVisitor
{
	private string result;

	
	
	public static string get(Symbol.Symbol s)
	{
		SymbolLocationVisitor symbolLocationVisitor = new SymbolLocationVisitor();
		s.Accept(symbolLocationVisitor);
		string text = symbolLocationVisitor.getResult();
		
		return text;
	}

	
	
	public SymbolLocationVisitor()
	{
	}

	public virtual string getResult()
	{
		return result;
	}

	
	
	public override void Visit(GlobalVariableSymbol s)
	{
		result = s.Label;
	}

	
	
	public override void Visit(StackVariableSymbol s)
	{
		result = (s.Offset)+("(%ebp)");
	}
}
