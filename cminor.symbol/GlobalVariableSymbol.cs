
using CMinor.Parser;
using CMinor.semantic;
using CMinor.Visit;



namespace CMinor.Symbol;

public class GlobalVariableSymbol : Symbol
{
	
	
	public GlobalVariableSymbol(LocationInfo info, string identifier, Type type)
		: base(info, identifier, type)
	{
	}

	
	
	public virtual string getLabel()
	{
		string result = ("global_")+(getIdentifier());
		
		return result;
	}

	
	
	public override void accept(SymbolVisitor v)
	{
		v.visit(this);
	}
}
