

using java.lang;

namespace CMinor.Symbol;

public class StringSymbol
{
	private string value;

	private string label;

	
	
	public StringSymbol(string value, string label)
	{
		this.value = value;
		this.label = label;
	}

	public virtual string getValue()
	{
		return value;
	}

	public virtual string getLabel()
	{
		return label;
	}
}
