
using CMinor.Parser;
using CMinor.Symbol;
using CMinor.Visit;

using java.lang;

namespace CMinor.AST;


public class StringLiteral : ConstantExpression
{
	private StringSymbol symbol;

	
	
	public StringLiteral(LocationInfo info, string value)
		: base(info, value)
	{
	}

	public virtual StringSymbol getSymbol()
	{
		return symbol;
	}

	public virtual void setSymbol(StringSymbol symbol)
	{
		this.symbol = symbol;
	}

	
	
	public override void Accept(Visitor v)
	{
		v.visit(this);
	}

	
	
	public static string escape(string s)
	{
		string @this = String.instancehelper_replace(s, "\\", "\\\\");
		string this2 = String.instancehelper_replace(@this, "\"", "\\\"");
		string this3 = String.instancehelper_replace(this2, "\\'", "'");
		string this4 = String.instancehelper_replace(this3, "\n", "\\n");
		string result = String.instancehelper_replace(this4, "\0", "\\0");
		
		return result;
	}
}
