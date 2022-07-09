

using java.lang;


namespace java_cup;

public class parse_action_table
{
	protected internal int _num_states;

	public parse_action_row[] under_state;

	public virtual int num_states()
	{
		return _num_states;
	}

	
	
	public parse_action_table()
	{
		_num_states = lalr_state.number();
		under_state = new parse_action_row[_num_states];
		for (int i = 0; i < _num_states; i++)
		{
			under_state[i] = new parse_action_row();
		}
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	[LineNumberTable(new byte[]
	{
		17, 142, 179, 112, 172, 240, 57, 6, 233, 79,
		142, 173, 233, 70, 135, 159, 21, 206
	})]
	public virtual void check_reductions()
	{
		for (int i = 0; i < num_states(); i++)
		{
			int num = 0;
			while (true)
			{
				int num2 = num;
				_ = under_state[i];
				if (num2 >= parse_action_row.size())
				{
					break;
				}
				parse_action parse_action2 = under_state[i].under_term[num];
				if (parse_action2 != null && parse_action2.kind() == 2)
				{
					((reduce_action)parse_action2).reduce_with().note_reduction_use();
				}
				num++;
			}
		}
		Enumeration enumeration = production.all();
		while (enumeration.hasMoreElements())
		{
			production production2 = (production)enumeration.nextElement();
			if (production2.num_reductions() == 0 && !emit.nowarn)
			{
				java.lang.System.err.println(new StringBuilder().append("*** Production \"").append(production2.to_simple_string()).append("\" never reduced")
					.toString());
				lexer.warning_count++;
			}
		}
	}

	
	[LineNumberTable(new byte[]
	{
		61, 102, 142, 127, 12, 98, 182, 153, 191, 42,
		100, 132, 123, 226, 52, 233, 81, 254, 43, 233,
		87, 155
	})]
	public override string toString()
	{
		string str = "-------- ACTION_TABLE --------\n";
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
				if (num3 >= parse_action_row.size())
				{
					break;
				}
				if (under_state[i].under_term[num2].kind() != 0)
				{
					str = new StringBuilder().append(str).append(" [term ").append(num2)
						.append(":")
						.append(under_state[i].under_term[num2])
						.append("]")
						.toString();
					num++;
					if (num == 2)
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
		return new StringBuilder().append(str).append("------------------------------").toString();
	}
}
