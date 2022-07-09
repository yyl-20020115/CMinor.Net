
using System.Text;

using java.lang;


namespace java_cup.runtime;

public abstract class lr_parser
{
	protected internal const int _error_sync_size = 3;

	protected internal bool _done_parsing;

	protected internal int tos;

	protected internal Symbol cur_token;

	protected internal Stack stack;

	protected internal short[][] production_tab;

	protected internal short[][] action_tab;

	protected internal short[][] reduce_tab;

	private Scanner _scanner;

	protected internal Symbol[] lookahead;

	protected internal int lookahead_pos;

	
	[Throws(new string[] { "System.Exception" })]
	[LineNumberTable(new byte[]
	{
		161, 146, 226, 71, 108, 108, 172, 166, 166, 172,
		107, 120, 167, 178, 109, 240, 69, 191, 8, 164,
		110, 108, 114, 174, 177, 167, 184, 110, 174, 136,
		108, 238, 61, 232, 71, 189, 103, 103, 109, 179,
		166, 172, 169, 172, 139, 214
	})]
	public virtual Symbol parse()
	{
		Symbol symbol = null;
		production_tab = production_table();
		action_tab = action_table();
		reduce_tab = reduce_table();
		init_actions();
		user_init();
		cur_token = scan();
		stack.removeAllElements();
		stack.push(new Symbol(0, start_state()));
		tos = 0;
		_done_parsing = false;
		while (!_done_parsing)
		{
			if (cur_token.used_by_parser)
			{
				
				throw new Error("Symbol recycling detected (fix your scanner).");
			}
			int num = get_action(((Symbol)stack.peek()).parse_state, cur_token.sym);
			if (num > 0)
			{
				cur_token.parse_state = num - 1;
				cur_token.used_by_parser = true;
				stack.push(cur_token);
				tos++;
				cur_token = scan();
			}
			else if (num < 0)
			{
				symbol = do_action(-num - 1, this, stack, tos);
				int sym = production_tab[-num - 1][0];
				int num2 = production_tab[-num - 1][1];
				for (int i = 0; i < num2; i++)
				{
					stack.pop();
					tos--;
				}
				num = (symbol.parse_state = get_reduce(((Symbol)stack.peek()).parse_state, sym));
				symbol.used_by_parser = true;
				stack.push(symbol);
				tos++;
			}
			else if (num == 0)
			{
				syntax_error(cur_token);
				if (!error_recovery(debug: false))
				{
					unrecovered_syntax_error(cur_token);
					done_parsing();
				}
				else
				{
					symbol = (Symbol)stack.peek();
				}
			}
		}
		return symbol;
	}

	public virtual void done_parsing()
	{
		_done_parsing = true;
	}

	
	
	public lr_parser()
	{
		_done_parsing = false;
		stack = new Stack();
	}

	public virtual void setScanner(Scanner s)
	{
		_scanner = s;
	}

	public virtual Scanner getScanner()
	{
		return _scanner;
	}

	public abstract int EOF_sym();

	
	
	public virtual void report_error(string message, object info)
	{
		java.lang.System.err.print(message);
		if (info is Symbol)
		{
			if (((Symbol)info).left != -1)
			{
				java.lang.System.err.println(new StringBuilder().append(" at character ").append(((Symbol)info).left).append(" of input")
					.toString());
			}
			else
			{
				java.lang.System.err.println("");
			}
		}
		else
		{
			java.lang.System.err.println("");
		}
	}

	
	[Throws(new string[] { "System.Exception" })]
	
	public virtual void report_fatal_error(string message, object info)
	{
		done_parsing();
		report_error(message, info);
		
		throw new Exception("Can't recover from previous error(s)");
	}

	public abstract short[][] production_table();

	public abstract short[][] action_table();

	public abstract short[][] reduce_table();

	[Throws(new string[] { "System.Exception" })]
	protected internal abstract void init_actions();

	[Throws(new string[] { "System.Exception" })]
	public virtual void user_init()
	{
	}

	
	[Throws(new string[] { "System.Exception" })]
	
	public virtual Symbol scan()
	{
		Symbol symbol = getScanner().next_token();
		Symbol result = ((symbol == null) ? new Symbol(EOF_sym()) : symbol);
		
		return result;
	}

	public abstract int start_state();

	[LineNumberTable(new byte[]
	{
		161, 58, 169, 102, 170, 104, 168, 228, 57, 230,
		77, 98, 106, 133, 103, 104, 104, 104, 134, 199,
		231, 69
	})]
	protected internal short get_action(int state, int sym)
	{
		short[] array = action_tab[state];
		if ((nint)array.LongLength < 20)
		{
			int num;
			for (num = 0; num < (nint)array.LongLength; num++)
			{
				int num2 = num;
				num++;
				int num3 = array[num2];
				if (num3 == sym || num3 == -1)
				{
					return array[num];
				}
			}
			return 0;
		}
		int num4 = 0;
		int num5 = (int)(((nint)array.LongLength - 1) / 2 - 1);
		while (num4 <= num5)
		{
			int num = (num4 + num5) / 2;
			if (sym == array[num * 2])
			{
				return array[num * 2 + 1];
			}
			if (sym > array[num * 2])
			{
				num4 = num + 1;
			}
			else
			{
				num5 = num - 1;
			}
		}
		return array[(nint)array.LongLength - 1];
	}

	[Throws(new string[] { "System.Exception" })]
	public abstract Symbol do_action(int i1, lr_parser P_1, Stack s, int i2);

	[LineNumberTable(new byte[]
	{
		161, 112, 169, 99, 130, 167, 104, 168, 228, 57,
		230, 75
	})]
	protected internal short get_reduce(int state, int sym)
	{
		short[] array = reduce_tab[state];
		if (array == null)
		{
			return -1;
		}
		int num;
		for (num = 0; num < (nint)array.LongLength; num++)
		{
			int num2 = num;
			num++;
			int num3 = array[num2];
			if (num3 == sym || num3 == -1)
			{
				return array[num];
			}
		}
		return -1;
	}

	
	
	public virtual void syntax_error(Symbol cur_token)
	{
		report_error("Syntax error", cur_token);
	}

	
	[Throws(new string[] { "System.Exception" })]
	[LineNumberTable(new byte[]
	{
		158, 188, 130, 206, 137, 110, 194, 230, 70, 110,
		137, 194, 149, 110, 226, 73, 99, 127, 13, 203,
		174, 167
	})]
	protected internal virtual bool error_recovery(bool debug)
	{
		if (debug)
		{
			debug_message("# Attempting error recovery");
		}
		if (!find_recovery_config(debug))
		{
			if (debug)
			{
				debug_message("# Error recovery fails");
			}
			return false;
		}
		read_lookahead();
		while (true)
		{
			if (debug)
			{
				debug_message("# Trying to parse ahead");
			}
			if (try_parse_ahead(debug))
			{
				break;
			}
			if (lookahead[0].sym == EOF_sym())
			{
				if (debug)
				{
					debug_message("# Error recovery fails at EOF");
				}
				return false;
			}
			if (debug)
			{
				debug_message(new StringBuilder().append("# Consuming Symbol #").append(lookahead[0].sym).toString());
			}
			restart_lookahead();
		}
		if (debug)
		{
			debug_message("# Parse-ahead ok, going back to normal parse");
		}
		parse_lookahead(debug);
		return true;
	}

	
	[Throws(new string[] { "System.Exception" })]
	
	public virtual void unrecovered_syntax_error(Symbol cur_token)
	{
		report_fatal_error("Couldn't repair and continue parse", cur_token);
	}

	
	
	public virtual void debug_message(string mess)
	{
		java.lang.System.err.println(mess);
	}

	
	
	public virtual void debug_shift(Symbol shift_tkn)
	{
		debug_message(new StringBuilder().append("# Shift under term #").append(shift_tkn.sym).append(" to state #")
			.append(shift_tkn.parse_state)
			.toString());
	}

	
	
	public virtual void debug_reduce(int prod_num, int nt_num, int rhs_size)
	{
		debug_message(new StringBuilder().append("# Reduce with prod #").append(prod_num).append(" [NT=")
			.append(nt_num)
			.append(", ")
			.append("SZ=")
			.append(rhs_size)
			.append("]")
			.toString());
	}

	
	[LineNumberTable(new byte[]
	{
		158, 169, 130, 174, 118, 182, 171, 99, 159, 21,
		118, 174, 141, 110, 226, 69, 127, 3, 131, 159,
		31, 223, 3, 111, 106, 104, 110, 142
	})]
	protected internal virtual bool find_recovery_config(bool debug)
	{
		if (debug)
		{
			debug_message("# Finding recovery state on stack");
		}
		int right = ((Symbol)stack.peek()).right;
		int left = ((Symbol)stack.peek()).left;
		while (!shift_under_error())
		{
			if (debug)
			{
				debug_message(new StringBuilder().append("# Pop stack by one, state was # ").append(((Symbol)stack.peek()).parse_state).toString());
			}
			left = ((Symbol)stack.pop()).left;
			tos--;
			if (stack.empty())
			{
				if (debug)
				{
					debug_message("# No recovery state found on stack");
				}
				return false;
			}
		}
		int num = get_action(((Symbol)stack.peek()).parse_state, error_sym());
		if (debug)
		{
			debug_message(new StringBuilder().append("# Recover state found (#").append(((Symbol)stack.peek()).parse_state).append(")")
				.toString());
			debug_message(new StringBuilder().append("# Shifting on error to state #").append(num - 1).toString());
		}
		Symbol symbol = new Symbol(error_sym(), left, right);
		symbol.parse_state = num - 1;
		symbol.used_by_parser = true;
		stack.push(symbol);
		tos++;
		return true;
	}

	
	[Throws(new string[] { "System.Exception" })]
	
	protected internal virtual void read_lookahead()
	{
		lookahead = new Symbol[error_sync_size()];
		for (int i = 0; i < error_sync_size(); i++)
		{
			lookahead[i] = cur_token;
			cur_token = scan();
		}
		lookahead_pos = 0;
	}

	
	[Throws(new string[] { "System.Exception" })]
	[LineNumberTable(new byte[]
	{
		158, 136, 130, 236, 70, 184, 165, 164, 137, 223,
		32, 237, 70, 140, 110, 194, 110, 175, 105, 38,
		168, 99, 223, 39, 115, 102
	})]
	protected internal virtual bool try_parse_ahead(bool debug)
	{
		virtual_parse_stack virtual_parse_stack2 = new virtual_parse_stack(stack);
		while (true)
		{
			int num = get_action(virtual_parse_stack2.top(), cur_err_token().sym);
			if (num == 0)
			{
				return false;
			}
			if (num > 0)
			{
				virtual_parse_stack2.push(num - 1);
				if (debug)
				{
					debug_message(new StringBuilder().append("# Parse-ahead shifts Symbol #").append(cur_err_token().sym).append(" into state #")
						.append(num - 1)
						.toString());
				}
				if (!advance_lookahead())
				{
					return true;
				}
				continue;
			}
			if (-num - 1 == start_production())
			{
				break;
			}
			int num2 = production_tab[-num - 1][0];
			int num3 = production_tab[-num - 1][1];
			for (int i = 0; i < num3; i++)
			{
				virtual_parse_stack2.pop();
			}
			if (debug)
			{
				debug_message(new StringBuilder().append("# Parse-ahead reduces: handle size = ").append(num3).append(" lhs = #")
					.append(num2)
					.append(" from state #")
					.append(virtual_parse_stack2.top())
					.toString());
			}
			virtual_parse_stack2.push(get_reduce(virtual_parse_stack2.top(), num2));
			if (debug)
			{
				debug_message(new StringBuilder().append("# Goto state #").append(virtual_parse_stack2.top()).toString());
			}
		}
		if (debug)
		{
			debug_message("# Parse-ahead accepts");
		}
		return true;
	}

	
	[Throws(new string[] { "System.Exception" })]
	
	protected internal virtual void restart_lookahead()
	{
		for (int i = 1; i < error_sync_size(); i++)
		{
			lookahead[i - 1] = lookahead[i];
		}
		lookahead[error_sync_size() - 1] = cur_token;
		cur_token = scan();
		lookahead_pos = 0;
	}

	
	[Throws(new string[] { "System.Exception" })]
	[LineNumberTable(new byte[]
	{
		158,
		118,
		98,
		226,
		70,
		135,
		131,
		107,
		127,
		11,
		byte.MaxValue,
		21,
		69,
		235,
		69,
		223,
		8,
		167,
		110,
		108,
		111,
		114,
		174,
		136,
		240,
		73,
		161,
		102,
		191,
		16,
		167,
		184,
		110,
		143,
		176,
		137,
		108,
		238,
		61,
		232,
		71,
		189,
		103,
		103,
		109,
		142,
		byte.MaxValue,
		12,
		69,
		134,
		110,
		225,
		69
	})]
	protected internal virtual void parse_lookahead(bool debug)
	{
		Symbol symbol = null;
		lookahead_pos = 0;
		if (debug)
		{
			debug_message("# Reparsing saved input with actions");
			debug_message(new StringBuilder().append("# Current Symbol is #").append(cur_err_token().sym).toString());
			debug_message(new StringBuilder().append("# Current state is #").append(((Symbol)stack.peek()).parse_state).toString());
		}
		while (!_done_parsing)
		{
			int num = get_action(((Symbol)stack.peek()).parse_state, cur_err_token().sym);
			if (num > 0)
			{
				cur_err_token().parse_state = num - 1;
				cur_err_token().used_by_parser = true;
				if (debug)
				{
					debug_shift(cur_err_token());
				}
				stack.push(cur_err_token());
				tos++;
				if (!advance_lookahead())
				{
					if (debug)
					{
						debug_message("# Completed reparse");
					}
					break;
				}
				if (debug)
				{
					debug_message(new StringBuilder().append("# Current Symbol is #").append(cur_err_token().sym).toString());
				}
			}
			else if (num < 0)
			{
				symbol = do_action(-num - 1, this, stack, tos);
				int num2 = production_tab[-num - 1][0];
				int num3 = production_tab[-num - 1][1];
				if (debug)
				{
					debug_reduce(-num - 1, num2, num3);
				}
				for (int i = 0; i < num3; i++)
				{
					stack.pop();
					tos--;
				}
				num = (symbol.parse_state = get_reduce(((Symbol)stack.peek()).parse_state, num2));
				symbol.used_by_parser = true;
				stack.push(symbol);
				tos++;
				if (debug)
				{
					debug_message(new StringBuilder().append("# Goto state #").append(num).toString());
				}
			}
			else if (num == 0)
			{
				report_fatal_error("Syntax error", symbol);
				break;
			}
		}
	}

	public abstract int error_sym();

	
	
	protected internal virtual bool shift_under_error()
	{
		return get_action(((Symbol)stack.peek()).parse_state, error_sym()) > 0;
	}

	protected internal virtual int error_sync_size()
	{
		return 3;
	}

	
	protected internal virtual Symbol cur_err_token()
	{
		return lookahead[lookahead_pos];
	}

	
	
	protected internal virtual bool advance_lookahead()
	{
		lookahead_pos++;
		return lookahead_pos < error_sync_size();
	}

	public abstract int start_production();

	
	
	public lr_parser(Scanner s)
		: this()
	{
		setScanner(s);
	}

	
	[LineNumberTable(new byte[]
	{
		162, 4, 136, 109, 161, 171, 144, 31, 59, 230,
		69, 109
	})]
	public virtual void dump_stack()
	{
		if (stack == null)
		{
			debug_message("# Stack dump requested, but stack is null");
			return;
		}
		debug_message("============ Parse Stack Dump ============");
		for (int i = 0; i < stack.size(); i++)
		{
			debug_message(new StringBuilder().append("Symbol: ").append(((Symbol)stack.elementAt(i)).sym).append(" State: ")
				.append(((Symbol)stack.elementAt(i)).parse_state)
				.toString());
		}
		debug_message("==========================================");
	}

	
	[LineNumberTable(new byte[]
	{
		162, 52, 107, 115, 114, 127, 38, 127, 0, 108,
		235, 59, 233, 72
	})]
	public virtual void debug_stack()
	{
		StringBuilder stringBuffer = new StringBuilder("## STACK:");
		for (int i = 0; i < stack.size(); i++)
		{
			Symbol symbol = (Symbol)stack.elementAt(i);
			stringBuffer.append(new StringBuilder().append(" <state ").append(symbol.parse_state).append(", sym ")
				.append(symbol.sym)
				.append(">")
				.toString());
			int num = i;
			if (((3 != -1) ? (num % 3) : 0) == 2 || i == stack.size() - 1)
			{
				debug_message(stringBuffer.toString());
				stringBuffer = new StringBuilder("         ");
			}
		}
	}

	
	[Throws(new string[] { "System.Exception" })]
	[LineNumberTable(new byte[]
	{
		162,
		77,
		226,
		70,
		108,
		108,
		140,
		171,
		166,
		166,
		140,
		191,
		11,
		107,
		120,
		167,
		178,
		109,
		240,
		70,
		191,
		8,
		167,
		110,
		108,
		108,
		114,
		174,
		108,
		191,
		11,
		167,
		184,
		110,
		142,
		172,
		136,
		108,
		238,
		61,
		232,
		71,
		125,
		byte.MaxValue,
		53,
		69,
		103,
		103,
		109,
		142,
		191,
		6,
		166,
		172,
		169,
		172,
		139,
		214
	})]
	public virtual Symbol debug_parse()
	{
		Symbol symbol = null;
		production_tab = production_table();
		action_tab = action_table();
		reduce_tab = reduce_table();
		debug_message("# Initializing parser");
		init_actions();
		user_init();
		cur_token = scan();
		debug_message(new StringBuilder().append("# Current Symbol is #").append(cur_token.sym).toString());
		stack.removeAllElements();
		stack.push(new Symbol(0, start_state()));
		tos = 0;
		_done_parsing = false;
		while (!_done_parsing)
		{
			if (cur_token.used_by_parser)
			{
				
				throw new Error("Symbol recycling detected (fix your scanner).");
			}
			int num = get_action(((Symbol)stack.peek()).parse_state, cur_token.sym);
			if (num > 0)
			{
				cur_token.parse_state = num - 1;
				cur_token.used_by_parser = true;
				debug_shift(cur_token);
				stack.push(cur_token);
				tos++;
				cur_token = scan();
				debug_message(new StringBuilder().append("# Current token is ").append(cur_token).toString());
			}
			else if (num < 0)
			{
				symbol = do_action(-num - 1, this, stack, tos);
				int num2 = production_tab[-num - 1][0];
				int num3 = production_tab[-num - 1][1];
				debug_reduce(-num - 1, num2, num3);
				for (int i = 0; i < num3; i++)
				{
					stack.pop();
					tos--;
				}
				num = get_reduce(((Symbol)stack.peek()).parse_state, num2);
				debug_message(new StringBuilder().append("# Reduce rule: top state ").append(((Symbol)stack.peek()).parse_state).append(", lhs sym ")
					.append(num2)
					.append(" -> state ")
					.append(num)
					.toString());
				symbol.parse_state = num;
				symbol.used_by_parser = true;
				stack.push(symbol);
				tos++;
				debug_message(new StringBuilder().append("# Goto state #").append(num).toString());
			}
			else if (num == 0)
			{
				syntax_error(cur_token);
				if (!error_recovery(debug: true))
				{
					unrecovered_syntax_error(cur_token);
					done_parsing();
				}
				else
				{
					symbol = (Symbol)stack.peek();
				}
			}
		}
		return symbol;
	}

	
	[LineNumberTable(new byte[]
	{
		164, 85, 110, 103, 42, 134, 98, 121, 103, 107,
		122, 107, 105, 53, 232, 61, 235, 70
	})]
	protected internal static short[][] unpackFromStrings(string[] sa)
	{
		StringBuilder stringBuffer = new StringBuilder(sa[0]);
		int i;
		for (i = 1; i < (nint)sa.LongLength; i++)
		{
			stringBuffer.append(sa[i]);
		}
		i = 0;
		int num = (int)(((uint)stringBuffer.charAt(i) << 16) | stringBuffer.charAt(i + 1));
		i += 2;
		short[][] array = new short[num][];
		for (int j = 0; j < num; j++)
		{
			int num2 = (int)(((uint)stringBuffer.charAt(i) << 16) | stringBuffer.charAt(i + 1));
			i += 2;
			array[j] = new short[num2];
			for (int k = 0; k < num2; k++)
			{
				short[] obj = array[j];
				int num3 = k;
				int index = i;
				i++;
				obj[num3] = (short)(stringBuffer.charAt(index) - 2);
			}
		}
		return array;
	}
}
