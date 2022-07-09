

using java.lang;


namespace CMinor.Symbol;

public class StringTable
{
	
	private Map map;

	private LabelGenerator labeler;

	
	
	public StringTable()
	{
		map = new HashMap();
		labeler = new LabelGenerator("string");
	}

	
	
	public virtual StringSymbol getSymbol(string value)
	{
		StringSymbol stringSymbol = (StringSymbol)map.get(value);
		if (stringSymbol == null)
		{
			stringSymbol = new StringSymbol(value, labeler.getLabel());
			map.put(value, stringSymbol);
		}
		return stringSymbol;
	}

	
	
	
	public virtual List getSymbols()
	{
		
		ArrayList result = new ArrayList(map.values());
		
		return result;
	}
}
