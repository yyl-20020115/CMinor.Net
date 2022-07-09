
using CMinor.Parser;
using CMinor.semantic;
using CMinor.Visit;

using java.lang;


namespace CMinor.Symbol;

public class FunctionSymbol : Symbol
{
	private Type returnType;

	
	private List parameters;

	
	
	
	public FunctionSymbol(LocationInfo info, string identifier, Type returnType, List parameters)
		: base(info, identifier, Type.___003C_003EFUNCTION)
	{
		this.returnType = returnType;
		this.parameters = parameters;
	}

	public virtual Type getReturnType()
	{
		return returnType;
	}

	
	public virtual List getParameters()
	{
		return parameters;
	}

	
	
	public virtual string getLabel()
	{
		string result = new StringBuilder().append("function_").append(getIdentifier()).toString();
		
		return result;
	}

	
	
	public override void accept(SymbolVisitor v)
	{
		v.visit(this);
	}
}