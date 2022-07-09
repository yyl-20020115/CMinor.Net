




using System;

namespace JavaCUP;

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

	
	
	
	public virtual void check_reductions()
	{
		for (int i = 0; i < num_states(); i++)
		{
			int num = 0;
			while (true)
			{
				int num2 = num;
				_ = under_state[i];
				if (num2 >= parse_action_row.Count)
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
				Console.Error.WriteLine(("*** Production \"")+(production2.to_simple_string())+("\" never reduced")
					);
				lexer.warning_count++;
			}
		}
	}

	
	
	public override string ToString()
	{
		string str = "-------- ACTION_TABLE --------\n";
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
				if (num3 >= parse_action_row.Count)
				{
					break;
				}
				if (under_state[i].under_term[num2].kind() != 0)
				{
					str = (str)+(" [term ")+(num2)
						+(":")
						+(under_state[i].under_term[num2])
						+("]")
						;
					num++;
					if (num == 2)
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
		return (str)+("------------------------------");
	}
}
