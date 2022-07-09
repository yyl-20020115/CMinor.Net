



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
		StringBuilder stringBuilder = (prefix)+("_");
		int num = counter;
		counter = num + 1;
		string result = stringBuilder+(num);
		
		return result;
	}
}
