
using CMinor.Parser;
using CMinor.semantic;
using CMinor.Visit;

using java.lang;

namespace CMinor.Symbol;

public class GlobalVariableSymbol : Symbol
{
	
	
	public GlobalVariableSymbol(LocationInfo info, string identifier, Type type)
		: base(info, identifier, type)
	{
	}

	
	
	public virtual string getLabel()
	{
		string result = new StringBuilder().append("global_").append(getIdentifier()).toString();
		
		return result;
	}

	
	
	public override void accept(SymbolVisitor v)
	{
		v.visit(this);
	}
}
