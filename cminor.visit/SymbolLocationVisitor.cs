
using CMinor.Symbol;



namespace CMinor.Visit;

public class SymbolLocationVisitor : SymbolVisitor
{
	private string result;

	
	
	public static string get(Symbol.Symbol s)
	{
		SymbolLocationVisitor symbolLocationVisitor = new SymbolLocationVisitor();
		s.accept(symbolLocationVisitor);
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

	
	
	public override void visit(GlobalVariableSymbol s)
	{
		result = s.getLabel();
	}

	
	
	public override void visit(StackVariableSymbol s)
	{
		result = (s.getOffset())+("(%ebp)");
	}
}
