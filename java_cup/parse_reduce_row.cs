



namespace JavaCUP;

public class parse_reduce_row
{
	protected internal static int _size;

	public lalr_state[] under_non_term;

	public static int size()
	{
		return _size;
	}

	
	
	public parse_reduce_row()
	{
		if (_size <= 0)
		{
			_size = non_terminal.number();
		}
		under_non_term = new lalr_state[size()];
	}
}
