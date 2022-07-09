




using System;

namespace JavaCUP;

public class ParseActionTable
{
	protected internal int _num_states;

	public ParseActionRow[] under_state;

	public virtual int num_states()
	{
		return _num_states;
	}

	
	
	public ParseActionTable()
	{
		_num_states = LalrState.number();
		under_state = new ParseActionRow[_num_states];
		for (int i = 0; i < _num_states; i++)
		{
			under_state[i] = new ParseActionRow();
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
				if (num2 >= ParseActionRow.Count)
				{
					break;
				}
				ParseAction parse_action2 = under_state[i].under_term[num];
				if (parse_action2 != null && parse_action2.Kind== 2)
				{
					((ReduceAction)parse_action2).reduce_with().note_reduction_use();
				}
				num++;
			}
		}
		foreach(var production2 in Production.all())
		{
			if (production2.num_reductions() == 0 && !emit.nowarn)
			{
				Console.Error.WriteLine(("*** Production \"")+(production2.to_simple_string())+("\" never reduced")
					);
				Lexer.warning_count++;
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
				if (num3 >= ParseActionRow.Count)
				{
					break;
				}
				if (under_state[i].under_term[num2].Kind!= 0)
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
