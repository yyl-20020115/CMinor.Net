



namespace JavaCUP;

public class ParseReduceRow
{
	protected internal static int _size;

	public LalrState[] under_non_term;

	public static int Count => _size;
		
	public ParseReduceRow()
	{
		if (_size <= 0)
		{
			_size = NonTerminal.number();
		}
		under_non_term = new LalrState[Count];
	}
}
