namespace JavaCUP;

public class ParseReduceTable
{
	protected internal int _num_states;

	public ParseReduceRow[] under_state;

	public virtual int num_states()
	{
		return _num_states;
	}

	
	
	public ParseReduceTable()
	{
		_num_states = LalrState.number();
		under_state = new ParseReduceRow[_num_states];
		for (int i = 0; i < _num_states; i++)
		{
			under_state[i] = new ParseReduceRow();
		}
	}

	
	public override string ToString()
	{
		string str = "-------- REDUCE_TABLE --------\n";
		for (int i = 0; i < num_states(); i++)
		{
			str = (str)+("From state #")+(i)
				+("\n")
				;
			int num = 0;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				_ = under_state[i];
				if (num3 >= ParseReduceRow.Count)
				{
					break;
				}
				LalrState lalr_state2 = under_state[i].under_non_term[num2];
				if (lalr_state2 != null)
				{
					str = (str)+(" [non term ")+(num2)
						+("->")
						;
					str = (str)+("state ")+(lalr_state2.Index())
						+("]")
						;
					num++;
					if (num == 3)
					{
						str = (str)+("\n");
						num = 0;
					}
				}
				num2++;
			}
			if (num != 0)
			{
				str = (str)+("\n");
			}
		}
		return (str)+("-----------------------------");
	}
}
