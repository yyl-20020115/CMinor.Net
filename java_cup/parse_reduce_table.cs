

using java.lang;

namespace java_cup;

public class parse_reduce_table
{
	protected internal int _num_states;

	public parse_reduce_row[] under_state;

	public virtual int num_states()
	{
		return _num_states;
	}

	
	
	public parse_reduce_table()
	{
		_num_states = lalr_state.number();
		under_state = new parse_reduce_row[_num_states];
		for (int i = 0; i < _num_states; i++)
		{
			under_state[i] = new parse_reduce_row();
		}
	}

	
	[LineNumberTable(new byte[]
	{
		13, 102, 142, 127, 12, 98, 182, 177, 135, 127,
		12, 191, 18, 100, 132, 123, 226, 48, 233, 85,
		254, 39, 233, 91, 155
	})]
	public override string toString()
	{
		string str = "-------- REDUCE_TABLE --------\n";
		for (int i = 0; i < num_states(); i++)
		{
			str = new StringBuilder().append(str).append("From state #").append(i)
				.append("\n")
				.toString();
			int num = 0;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				_ = under_state[i];
				if (num3 >= parse_reduce_row.size())
				{
					break;
				}
				lalr_state lalr_state2 = under_state[i].under_non_term[num2];
				if (lalr_state2 != null)
				{
					str = new StringBuilder().append(str).append(" [non term ").append(num2)
						.append("->")
						.toString();
					str = new StringBuilder().append(str).append("state ").append(lalr_state2.index())
						.append("]")
						.toString();
					num++;
					if (num == 3)
					{
						str = new StringBuilder().append(str).append("\n").toString();
						num = 0;
					}
				}
				num2++;
			}
			if (num != 0)
			{
				str = new StringBuilder().append(str).append("\n").toString();
			}
		}
		return new StringBuilder().append(str).append("-----------------------------").toString();
	}
}
