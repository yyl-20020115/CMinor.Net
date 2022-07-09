



namespace JavaCUP;

public class ParseActionRow
{
	protected internal static int _size;

	protected internal static int[] reduction_count;

	public ParseAction[] under_term;

	public int default_reduce;

	public virtual void compute_default()
	{
		if (reduction_count == null)
		{
			reduction_count = new int[Production.number()];
		}
		for (int i = 0; i < Production.number(); i++)
		{
			reduction_count[i] = 0;
		}
		int num = -1;
		int num2 = 0;
		for (int i = 0; i < Count; i++)
		{
			if (under_term[i].Kind== 2)
			{
				int num3 = ((ReduceAction)under_term[i]).reduce_with().index();
				int[] array = reduction_count;
				int num4 = num3;
				int[] array2 = array;
				array2[num4]++;
				if (reduction_count[num3] > num2)
				{
					num2 = reduction_count[num3];
					num = num3;
				}
			}
		}
		default_reduce = num;
	}

	public static int Count => _size;

	
	
	public ParseActionRow()
	{
		if (_size <= 0)
		{
			_size = Terminal.number();
		}
		under_term = new ParseAction[Count];
		for (int i = 0; i < _size; i++)
		{
			under_term[i] = new ParseAction();
		}
	}
}
