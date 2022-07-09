

using java.lang;

namespace CMinor.Parser;

public class LocationInfo
{
	private string file;

	private int line;

	private int col;

	
	
	public LocationInfo(string file, int line, int col)
	{
		this.file = file;
		this.line = line;
		this.col = col;
	}

	
	
	public override string toString()
	{
		string result = new StringBuilder().append(file).append(':').append(line)
			.append(':')
			.append(col)
			.toString();
		
		return result;
	}
}
