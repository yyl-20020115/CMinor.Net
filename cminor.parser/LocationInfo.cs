



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

	
	
	public override string ToString()
	{
		string result = (file)+(':')+(line)
			+(':')
			+(col)
			.ToString();
		
		return result;
	}
}
