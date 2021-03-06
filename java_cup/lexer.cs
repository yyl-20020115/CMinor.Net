using JavaCUP.Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JavaCUP;

public class Lexer
{
	protected internal static int next_char;

	protected internal static int next_char2;

	protected internal static int next_char3;

	protected internal static int next_char4;

	protected internal const int EOF_CHAR = -1;

	protected internal static Dictionary<string,int> keywords;

	protected internal static Dictionary<char, int> char_symbols;

	protected internal static int current_line;

	protected internal static int current_position;

	protected internal static int absolute_position;

	public static int error_count;

	public static int warning_count;

	public static TextReader reader = Console.In;
	
	public static void emit_error(string message)
	{
		Console.Error.WriteLine(("System.Exception at ")+(current_line)+("(")
			+(current_position)
			+("): ")
			+(message)
			);
		error_count++;
	}

	protected internal static bool id_start_char(int ch)
	{
		return ((ch >= 97 && ch <= 122) || (ch >= 65 && ch <= 90) || ch == 95) ? true : false;
	}

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
					next_char4 = Console.In.Read();
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

	
	protected internal static Symbol RealNextToken()
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
			var stringBuilder = ("Unrecognized character '");
			
			emit_warn(stringBuilder+(((char)next_char))+("'(")+(next_char)
				+(") -- ignored")
				);
			advance();
		}
		Symbol result8 = new Symbol(0);
		
		return result8;
	}



    protected internal static int find_single_char(int ch) 
		=> !char_symbols.TryGetValue((char)ch, out var i) ? -1 : i;


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

	protected internal static Symbol do_code_string()
	{
		StringBuilder stringBuilder = new StringBuilder();
		advance();
		advance();
		while (next_char != 58 || next_char2 != 125)
		{
			if (next_char == -1)
			{
				emit_error("Specification file ends inside a code string");
				break;
			}
			
			stringBuilder.Append(((char)next_char));
			advance();
		}
		advance();
		advance();
		Symbol result = new Symbol(29, stringBuilder);
		
		return result;
	}

	
	protected internal static Symbol do_id()
	{
		var stringBuilder = new StringBuilder();
		char[] array = new char[1] { (char)next_char };
		stringBuilder.Append(array, 0, 1);
		advance();
		while (id_char(next_char))
		{
			array[0] = (char)next_char;
			stringBuilder.Append(array, 0, 1);
			advance();
		}
		string text = stringBuilder.ToString();
        return keywords.TryGetValue(text,out var i) ? new Symbol(i) : new Symbol(28, text);
    }
	
	public static void emit_warn(string message)
	{
		Console.Out.WriteLine(("Warning at ")+(current_line)+("(")
			+(current_position)
			+("): ")
			+(message)
			);
		warning_count++;
	}

	
	
	private Lexer()
	{
	}

	public static void init()
	{
		keywords.Add("package", (2));
		keywords.Add("import", (3));
		keywords.Add("code", (4));
		keywords.Add("action", (5));
		keywords.Add("parser", (6));
		keywords.Add("terminal", (7));
		keywords.Add("non", (8));
		keywords.Add("nonterminal", (27));
		keywords.Add("init", (9));
		keywords.Add("scan", (10));
		keywords.Add("with", (11));
		keywords.Add("start", (12));
		keywords.Add("precedence", (20));
		keywords.Add("left", (21));
		keywords.Add("right", (22));
		keywords.Add("nonassoc", (23));
		char_symbols.Add((char)(59), (13));
		char_symbols.Add((char)(44), (14));
		char_symbols.Add((char)(42), (15));
		char_symbols.Add((char)(46), (16));
		char_symbols.Add((char)(124), (19));
		char_symbols.Add((char)(91), (25));
		char_symbols.Add((char)(93), (26));
		next_char = reader.Read();
		if (next_char == -1)
		{
			next_char2 = -1;
			next_char3 = -1;
			next_char4 = -1;
			return;
		}
		next_char2 = reader.Read();
		if (next_char2 == -1)
		{
			next_char3 = -1;
			next_char4 = -1;
			return;
		}
		next_char3 = reader.Read();
		if (next_char3 == -1)
		{
			next_char4 = -1;
		}
		else
		{
			next_char4 = reader.Read();
		}
	}

	
	
	
	public static Symbol NextToken()
	{
		return RealNextToken();
	}

	
	
	
	public static Symbol debug_next_token()
	{
		var symbol2 = RealNextToken();
		Console.Out.WriteLine(("# next_Symbol() => ")+(symbol2.sym));
		return symbol2;
	}

	static Lexer()
	{
		keywords = new (23);
		char_symbols = new (11);
		current_line = 1;
		current_position = 1;
		absolute_position = 1;
		error_count = 0;
		warning_count = 0;
	}
}
