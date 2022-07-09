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

    public virtual string Value => value;

    public virtual string Label => label;
}
