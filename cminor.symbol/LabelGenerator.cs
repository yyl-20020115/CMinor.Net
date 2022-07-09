

using java.lang;

namespace CMinor.Symbol;

public class LabelGenerator
{
	private string prefix;

	private int counter;

	
	
	public LabelGenerator(string prefix)
	{
		this.prefix = prefix;
		counter = 0;
	}

	
	
	public virtual string getLabel()
	{
		StringBuilder stringBuilder = new StringBuilder().append(prefix).append("_");
		int num = counter;
		counter = num + 1;
		string result = stringBuilder.append(num).toString();
		
		return result;
	}
}
