

using java_cup.runtime;
using java.lang;


namespace java_cup;

public class lexer
{
	protected internal static int next_char;

	protected internal static int next_char2;

	protected internal static int next_char3;

	protected internal static int next_char4;

	protected internal const int EOF_CHAR = -1;

	protected internal static Hashtable keywords;

	protected internal static Hashtable char_symbols;

	protected internal static int current_line;

	protected internal static int current_position;

	protected internal static int absolute_position;

	public static int error_count;

	public static int warning_count;

	
	
	public static void ___003Cclinit_003E()
	{
	}

	
	
	public static void emit_error(string message)
	{
		java.lang.System.err.println(new StringBuilder().append("Error at ").append(current_line).append("(")
			.append(current_position)
			.append("): ")
			.append(message)
			.toString());
		error_count++;
	}

	protected internal static bool id_start_char(int ch)
	{
		return ((ch >= 97 && ch <= 122) || (ch >= 65 && ch <= 90) || ch == 95) ? true : false;
	}

	
	[Throws(new string[] { "java.io.IOException" })]
	[LineNumberTable(new byte[]
	{
		160, 70, 102, 106, 104, 102, 102, 136, 106, 104,
		102, 136, 106, 104, 136, 239, 70, 108, 108, 147,
		108, 134
	})]
	protected internal static void advance()
	{
		int num = next_char;
		next_char = next_char2;
		if (next_char == -1)
		{
			next_char2 = -1;
			next_char3 = -1;
			next_char4 = -1;
		}
		else
		{
			next_char2 = next_char3;
			if (next_char2 == -1)
			{
				next_char3 = -1;
				next_char4 = -1;
			}
			else
			{
				next_char3 = next_char4;
				if (next_char3 == -1)
				{
					next_char4 = -1;
				}
				else
				{
					next_char4 = java.lang.System.@in.read();
				}
			}
		}
		absolute_position++;
		current_position++;
		switch (num)
		{
		case 13:
			if (next_char == 10)
			{
				break;
			}
			goto case 10;
		case 10:
			current_line++;
			current_position = 1;
			break;
		}
	}

	
	
	protected internal static bool id_char(int ch)
	{
		return (id_start_char(ch) || (ch >= 48 && ch <= 57)) ? true : false;
	}

	
	[Throws(new string[] { "java.io.IOException" })]
	[LineNumberTable(new byte[]
	{
		161,
		86,
		223,
		14,
		101,
		194,
		107,
		164,
		101,
		201,
		169,
		137,
		101,
		202,
		101,
		137,
		106,
		234,
		69,
		234,
		70,
		105,
		101,
		159,
		5,
		101,
		101,
		101,
		101,
		138,
		234,
		69,
		187,
		101,
		197,
		114,
		168,
		180,
		177,
		byte.MaxValue,
		45,
		69
	})]
	protected internal static Symbol real_next_token()
	{
		while (true)
		{
			if (next_char == 32 || next_char == 9 || next_char == 10 || next_char == 12 || next_char == 13)
			{
				advance();
				continue;
			}
			int num = find_single_char(next_char);
			if (num != -1)
			{
				advance();
				Symbol result = new Symbol(num);
				
				return result;
			}
			if (next_char == 58)
			{
				if (next_char2 != 58)
				{
					advance();
					Symbol result2 = new Symbol(17);
					
					return result2;
				}
				advance();
				if (next_char2 == 61)
				{
					advance();
					advance();
					Symbol result3 = new Symbol(18);
					
					return result3;
				}
				Symbol result4 = new Symbol(17);
				
				return result4;
			}
			if (next_char == 37)
			{
				advance();
				if (next_char == 112 && next_char2 == 114 && next_char3 == 101 && next_char4 == 99)
				{
					advance();
					advance();
					advance();
					advance();
					Symbol result5 = new Symbol(24);
					
					return result5;
				}
				emit_error("Found extraneous percent sign");
			}
			if (next_char == 47 && (next_char2 == 42 || next_char2 == 47))
			{
				swallow_comment();
				continue;
			}
			if (next_char == 123 && next_char2 == 58)
			{
				Symbol result6 = do_code_string();
				
				return result6;
			}
			if (id_start_char(next_char))
			{
				Symbol result7 = do_id();
				
				return result7;
			}
			if (next_char == -1)
			{
				break;
			}
			StringBuilder stringBuilder = new StringBuilder().append("Unrecognized character '");
			
			emit_warn(stringBuilder.append(new Character((char)next_char)).append("'(").append(next_char)
				.append(") -- ignored")
				.toString());
			advance();
		}
		Symbol result8 = new Symbol(0);
		
		return result8;
	}

	
	
	protected internal static int find_single_char(int ch)
	{
		Integer integer = (Integer)char_symbols.get(new Integer((ushort)ch));
		if (integer == null)
		{
			return -1;
		}
		int result = integer.intValue();
		
		return result;
	}

	
	[Throws(new string[] { "java.io.IOException" })]
	[LineNumberTable(new byte[]
	{
		160, 181, 169, 234, 70, 136, 108, 193, 146, 101,
		103, 193, 231, 69, 169, 170, 159, 4, 135, 225,
		69, 106, 103
	})]
	protected internal static void swallow_comment()
	{
		if (next_char2 == 42)
		{
			advance();
			advance();
			while (true)
			{
				if (next_char == -1)
				{
					emit_error("Specification file ends inside a comment");
					return;
				}
				if (next_char == 42 && next_char2 == 47)
				{
					break;
				}
				advance();
			}
			advance();
			advance();
		}
		else if (next_char2 == 47)
		{
			advance();
			advance();
			while (next_char != 10 && next_char != 13 && next_char != 12 && next_char != -1)
			{
				advance();
			}
		}
		else
		{
			emit_error("Malformed comment in specification -- ignored");
			advance();
		}
	}

	
	[Throws(new string[] { "java.io.IOException" })]
	[LineNumberTable(new byte[]
	{
		160, 238, 166, 170, 178, 136, 106, 194, 119, 199,
		106
	})]
	protected internal static Symbol do_code_string()
	{
		StringBuilder stringBuffer = new StringBuilder();
		advance();
		advance();
		while (next_char != 58 || next_char2 != 125)
		{
			if (next_char == -1)
			{
				emit_error("Specification file ends inside a code string");
				break;
			}
			
			stringBuffer.append(new Character((char)next_char));
			advance();
		}
		advance();
		advance();
		Symbol result = new Symbol(29, stringBuffer.toString());
		
		return result;
	}

	
	[Throws(new string[] { "java.io.IOException" })]
	[LineNumberTable(new byte[]
	{
		161, 16, 166, 167, 105, 106, 165, 140, 105, 106,
		199, 103, 177, 99, 174
	})]
	protected internal static Symbol do_id()
	{
		StringBuilder stringBuffer = new StringBuilder();
		char[] array = new char[1] { (char)next_char };
		stringBuffer.append(array, 0, 1);
		advance();
		while (id_char(next_char))
		{
			array[0] = (char)next_char;
			stringBuffer.append(array, 0, 1);
			advance();
		}
		string text = stringBuffer.toString();
		Integer integer = (Integer)keywords.get(text);
		if (integer != null)
		{
			Symbol result = new Symbol(integer.intValue());
			
			return result;
		}
		Symbol result2 = new Symbol(28, text);
		
		return result2;
	}

	
	
	public static void emit_warn(string message)
	{
		java.lang.System.err.println(new StringBuilder().append("Warning at ").append(current_line).append("(")
			.append(current_position)
			.append("): ")
			.append(message)
			.toString());
		warning_count++;
	}

	
	
	private lexer()
	{
	}

	
	[Throws(new string[] { "java.io.IOException" })]
	[LineNumberTable(new byte[]
	{
		77, 118, 118, 118, 118, 118, 118, 118, 119, 119,
		119, 119, 119, 119, 119, 119, 183, 121, 121, 121,
		121, 121, 121, 185, 111, 104, 102, 102, 136, 111,
		104, 102, 136, 111, 104, 136, 207
	})]
	public static void init()
	{
		keywords.put("package", new Integer(2));
		keywords.put("import", new Integer(3));
		keywords.put("code", new Integer(4));
		keywords.put("action", new Integer(5));
		keywords.put("parser", new Integer(6));
		keywords.put("terminal", new Integer(7));
		keywords.put("non", new Integer(8));
		keywords.put("nonterminal", new Integer(27));
		keywords.put("init", new Integer(9));
		keywords.put("scan", new Integer(10));
		keywords.put("with", new Integer(11));
		keywords.put("start", new Integer(12));
		keywords.put("precedence", new Integer(20));
		keywords.put("left", new Integer(21));
		keywords.put("right", new Integer(22));
		keywords.put("nonassoc", new Integer(23));
		char_symbols.put(new Integer(59), new Integer(13));
		char_symbols.put(new Integer(44), new Integer(14));
		char_symbols.put(new Integer(42), new Integer(15));
		char_symbols.put(new Integer(46), new Integer(16));
		char_symbols.put(new Integer(124), new Integer(19));
		char_symbols.put(new Integer(91), new Integer(25));
		char_symbols.put(new Integer(93), new Integer(26));
		next_char = java.lang.System.@in.read();
		if (next_char == -1)
		{
			next_char2 = -1;
			next_char3 = -1;
			next_char4 = -1;
			return;
		}
		next_char2 = java.lang.System.@in.read();
		if (next_char2 == -1)
		{
			next_char3 = -1;
			next_char4 = -1;
			return;
		}
		next_char3 = java.lang.System.@in.read();
		if (next_char3 == -1)
		{
			next_char4 = -1;
		}
		else
		{
			next_char4 = java.lang.System.@in.read();
		}
	}

	
	[Throws(new string[] { "java.io.IOException" })]
	
	public static Symbol next_token()
	{
		Symbol result = real_next_token();
		
		return result;
	}

	
	[Throws(new string[] { "java.io.IOException" })]
	
	public static Symbol debug_next_token()
	{
		Symbol symbol2 = real_next_token();
		java.lang.System.@out.println(new StringBuilder().append("# next_Symbol() => ").append(symbol2.sym).toString());
		return symbol2;
	}

	[LineNumberTable(new byte[]
	{
		30, 236, 74, 236, 69, 230, 69, 230, 69, 230,
		69, 230, 69
	})]
	static lexer()
	{
		keywords = new Hashtable(23);
		char_symbols = new Hashtable(11);
		current_line = 1;
		current_position = 1;
		absolute_position = 1;
		error_count = 0;
		warning_count = 0;
	}
}