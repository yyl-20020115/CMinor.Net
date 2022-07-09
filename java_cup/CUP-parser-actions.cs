

using java_cup.runtime;
using java.lang;


namespace java_cup;

[SourceFile("parser.java")]
internal class CUP_0024parser_0024actions
{
	[Modifiers(Modifiers.Protected | Modifiers.Final)]
	protected internal int MAX_RHS;

	protected internal production_part[] rhs_parts;

	protected internal int rhs_pos;

	protected internal string multipart_name;

	protected internal Hashtable symbols;

	protected internal Hashtable non_terms;

	protected internal non_terminal start_nt;

	protected internal non_terminal lhs_nt;

	internal int _cur_prec;

	internal int _cur_side;

	[Modifiers(Modifiers.Private | Modifiers.Final)]
	private parser parser;

	
	
	protected internal virtual void append_multipart(string P_0)
	{
		string str = "";
		if (String.instancehelper_length(multipart_name) != 0)
		{
			str = ".";
		}
		multipart_name = String.instancehelper_concat(multipart_name, new StringBuilder().append(str).append(P_0).toString());
	}

	
	[Throws(new string[] { "System.Exception" })]
	
	protected internal virtual void add_rhs_part(production_part P_0)
	{
		if (rhs_pos >= 200)
		{
			
			throw new Exception("Internal Error: Productions limited to 200 symbols and actions");
		}
		rhs_parts[rhs_pos] = P_0;
		rhs_pos++;
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	
	protected internal virtual production_part add_lab(production_part P_0, string P_1)
	{
		if (P_1 == null || P_0.is_action())
		{
			return P_0;
		}
		symbol_part result = new symbol_part(((symbol_part)P_0).the_symbol(), P_1);
		
		return result;
	}

	protected internal virtual void new_rhs()
	{
		rhs_pos = 0;
	}

	
	[LineNumberTable(new byte[]
	{
		161, 102, 99, 148, 114, 99, 159, 17, 103, 104,
		121, 191, 7
	})]
	protected internal virtual void add_precedence(string P_0)
	{
		if (P_0 == null)
		{
			java.lang.System.err.println("Unable to add precedence to nonexistent terminal");
			return;
		}
		symbol_part symbol_part2 = (symbol_part)symbols.get(P_0);
		if (symbol_part2 == null)
		{
			java.lang.System.err.println(new StringBuilder().append("Could find terminal ").append(P_0).append(" while declaring precedence")
				.toString());
			return;
		}
		symbol symbol2 = symbol_part2.the_symbol();
		if (symbol2 is terminal)
		{
			((terminal)symbol2).set_precedence(_cur_side, _cur_prec);
		}
		else
		{
			java.lang.System.err.println(new StringBuilder().append("Precedence declaration: Can't find terminal ").append(P_0).toString());
		}
	}

	
	protected internal virtual void update_precedence(int P_0)
	{
		_cur_side = P_0;
		_cur_prec++;
	}

	
	[LineNumberTable(new byte[]
	{
		161, 120, 232, 159, 177, 171, 176, 231, 81, 235,
		78, 171, 171, 231, 70, 167, 231, 92, 103
	})]
	internal CUP_0024parser_0024actions(parser P_0)
	{
		MAX_RHS = 200;
		rhs_parts = new production_part[200];
		rhs_pos = 0;
		multipart_name = String.newhelper();
		symbols = new Hashtable();
		non_terms = new Hashtable();
		start_nt = null;
		_cur_prec = 0;
		_cur_side = -1;
		parser = P_0;
	}

	
	[Throws(new string[] { "System.Exception" })]
	[LineNumberTable(new byte[]
	{
		161,
		136,
		byte.MaxValue,
		161,
		88,
		69,
		130,
		159,
		18,
		226,
		69,
		130,
		159,
		17,
		226,
		69,
		130,
		159,
		17,
		226,
		69,
		130,
		159,
		17,
		226,
		69,
		130,
		159,
		17,
		226,
		69,
		130,
		106,
		134,
		159,
		18,
		226,
		69,
		98,
		102,
		159,
		18,
		226,
		69,
		98,
		102,
		159,
		18,
		226,
		69,
		98,
		102,
		159,
		18,
		226,
		69,
		98,
		102,
		159,
		18,
		226,
		69,
		98,
		102,
		159,
		18,
		226,
		69,
		98,
		102,
		159,
		18,
		226,
		69,
		98,
		102,
		159,
		18,
		226,
		69,
		98,
		102,
		159,
		18,
		226,
		69,
		98,
		102,
		159,
		18,
		226,
		69,
		98,
		102,
		159,
		18,
		226,
		69,
		98,
		102,
		159,
		18,
		226,
		69,
		98,
		102,
		159,
		18,
		226,
		69,
		98,
		102,
		159,
		18,
		226,
		69,
		98,
		102,
		159,
		18,
		226,
		69,
		98,
		117,
		117,
		122,
		98,
		159,
		18,
		226,
		69,
		98,
		117,
		117,
		122,
		98,
		159,
		18,
		226,
		69,
		130,
		106,
		134,
		159,
		18,
		226,
		69,
		98,
		117,
		117,
		122,
		98,
		159,
		18,
		226,
		69,
		130,
		106,
		134,
		159,
		18,
		226,
		69,
		98,
		117,
		117,
		122,
		98,
		159,
		18,
		226,
		69,
		98,
		117,
		117,
		186,
		174,
		byte.MaxValue,
		12,
		69,
		114,
		171,
		210,
		174,
		179,
		159,
		18,
		226,
		69,
		98,
		117,
		117,
		186,
		174,
		byte.MaxValue,
		12,
		70,
		114,
		171,
		223,
		4,
		159,
		18,
		226,
		69,
		98,
		118,
		159,
		18,
		226,
		69,
		130,
		159,
		18,
		226,
		69,
		130,
		159,
		18,
		226,
		69,
		98,
		107,
		159,
		18,
		226,
		69,
		98,
		117,
		117,
		122,
		103,
		159,
		18,
		226,
		69,
		98,
		117,
		117,
		122,
		103,
		159,
		18,
		226,
		69,
		98,
		98,
		159,
		18,
		226,
		69,
		98,
		117,
		117,
		122,
		98,
		159,
		18,
		226,
		69,
		98,
		117,
		117,
		186,
		140,
		159,
		18,
		226,
		69,
		98,
		117,
		117,
		122,
		117,
		117,
		187,
		179,
		132,
		103,
		byte.MaxValue,
		12,
		70,
		176,
		159,
		18,
		226,
		69,
		130,
		159,
		18,
		226,
		69,
		130,
		159,
		18,
		226,
		69,
		130,
		171,
		253,
		69,
		136,
		172,
		102,
		124,
		112,
		112,
		191,
		1,
		230,
		69,
		134,
		159,
		18,
		226,
		69,
		98,
		117,
		117,
		154,
		98,
		171,
		99,
		111,
		133,
		216,
		109,
		191,
		22,
		157,
		159,
		15,
		253,
		70,
		139,
		172,
		102,
		124,
		112,
		112,
		109,
		byte.MaxValue,
		27,
		69,
		191,
		1,
		230,
		69,
		134,
		159,
		18,
		226,
		69,
		130,
		159,
		18,
		226,
		69,
		130,
		159,
		18,
		226,
		69,
		131,
		118,
		150,
		159,
		19,
		226,
		69,
		98,
		106,
		159,
		18,
		226,
		69,
		131,
		118,
		150,
		118,
		118,
		117,
		117,
		154,
		159,
		19,
		226,
		69,
		98,
		117,
		117,
		154,
		159,
		18,
		226,
		69,
		98,
		117,
		117,
		186,
		183,
		136,
		103,
		byte.MaxValue,
		10,
		69,
		134,
		159,
		18,
		226,
		69,
		130,
		159,
		18,
		226,
		69,
		130,
		159,
		18,
		226,
		69,
		130,
		159,
		18,
		226,
		69,
		131,
		118,
		118,
		117,
		117,
		154,
		159,
		19,
		226,
		69,
		98,
		117,
		117,
		186,
		114,
		131,
		byte.MaxValue,
		12,
		70,
		167,
		102,
		124,
		112,
		112,
		159,
		1,
		166,
		159,
		18,
		226,
		69,
		98,
		117,
		117,
		186,
		174,
		191,
		10,
		130,
		159,
		18,
		226,
		69,
		98,
		117,
		117,
		154,
		103,
		130,
		159,
		18,
		226,
		69,
		130,
		159,
		18,
		226,
		69,
		130,
		159,
		18,
		226,
		69,
		131,
		118,
		150,
		159,
		19,
		226,
		69,
		130,
		135,
		159,
		18,
		226,
		69,
		131,
		118,
		150,
		159,
		19,
		226,
		69,
		130,
		135,
		159,
		18,
		226,
		69,
		131,
		118,
		150,
		159,
		19,
		226,
		69,
		130,
		135,
		159,
		18,
		226,
		69,
		130,
		159,
		18,
		226,
		69,
		130,
		159,
		18,
		226,
		69,
		130,
		159,
		18,
		226,
		69,
		130,
		159,
		18,
		226,
		69,
		130,
		159,
		18,
		226,
		69,
		130,
		159,
		18,
		226,
		69,
		130,
		159,
		18,
		226,
		69,
		130,
		159,
		18,
		226,
		69,
		131,
		118,
		150,
		159,
		19,
		226,
		69,
		162,
		139,
		159,
		18,
		226,
		69,
		131,
		118,
		150,
		159,
		19,
		226,
		69,
		162,
		139,
		159,
		18,
		226,
		69,
		131,
		118,
		150,
		159,
		19,
		226,
		69,
		162,
		139,
		159,
		18,
		226,
		69,
		131,
		118,
		150,
		159,
		19,
		226,
		69,
		162,
		139,
		159,
		18,
		226,
		69,
		130,
		159,
		18,
		226,
		69,
		130,
		159,
		18,
		226,
		69,
		130,
		159,
		18,
		226,
		69,
		130,
		159,
		18,
		226,
		69,
		130,
		159,
		18,
		226,
		69,
		130,
		159,
		18,
		226,
		69,
		98,
		117,
		117,
		154,
		103,
		140,
		134,
		159,
		18,
		226,
		69,
		98,
		117,
		117,
		154,
		103,
		140,
		134,
		159,
		18,
		226,
		69,
		98,
		117,
		117,
		154,
		103,
		140,
		134,
		159,
		18,
		226,
		69,
		98,
		117,
		117,
		154,
		103,
		140,
		134,
		159,
		17,
		226,
		69,
		130,
		159,
		17,
		226,
		69,
		130,
		159,
		17,
		226,
		69,
		130,
		159,
		17,
		226,
		69,
		130,
		159,
		17,
		226,
		69,
		130,
		159,
		17,
		226,
		69,
		130,
		159,
		17,
		226,
		69,
		131,
		118,
		150,
		159,
		19,
		226,
		69,
		162,
		177,
		139,
		159,
		18,
		226,
		69,
		130,
		159,
		17,
		226,
		69,
		130,
		159,
		17,
		226,
		69,
		130,
		159,
		17,
		226,
		69,
		131,
		118,
		150,
		159,
		18,
		226,
		69,
		162,
		171,
		139,
		159,
		18,
		226,
		69,
		130,
		159,
		17,
		226,
		69,
		131,
		118,
		150,
		159,
		18,
		226,
		69,
		162,
		187,
		150,
		159,
		18,
		226,
		69,
		98,
		117,
		117,
		118,
		100,
		191,
		18,
		102,
		194
	})]
	public Symbol CUP_0024parser_0024do_action(int P_0, lr_parser P_1, Stack P_2, int P_3)
	{
		switch (P_0)
		{
		case 106:
			
			return new Symbol(29, ((Symbol)P_2.elementAt(P_3 - 0)).right, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 105:
			
			return new Symbol(7, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 104:
			
			return new Symbol(7, ((Symbol)P_2.elementAt(P_3 - 0)).right, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 103:
			
			return new Symbol(8, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 102:
			
			return new Symbol(8, ((Symbol)P_2.elementAt(P_3 - 1)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 101:
		{
			
			lexer.emit_error("Illegal use of reserved word");
			string o2 = "ILLEGAL";
			return new Symbol(42, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, o2);
		}
		case 100:
		{
			
			string o2 = "nonassoc";
			return new Symbol(42, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, o2);
		}
		case 99:
		{
			
			string o2 = "right";
			return new Symbol(42, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, o2);
		}
		case 98:
		{
			
			string o2 = "left";
			return new Symbol(42, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, o2);
		}
		case 97:
		{
			
			string o2 = "precedence";
			return new Symbol(42, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, o2);
		}
		case 96:
		{
			
			string o2 = "start";
			return new Symbol(42, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, o2);
		}
		case 95:
		{
			
			string o2 = "with";
			return new Symbol(42, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, o2);
		}
		case 94:
		{
			
			string o2 = "scan";
			return new Symbol(42, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, o2);
		}
		case 93:
		{
			
			string o2 = "init";
			return new Symbol(42, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, o2);
		}
		case 92:
		{
			
			string o2 = "nonterminal";
			return new Symbol(42, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, o2);
		}
		case 91:
		{
			
			string o2 = "non";
			return new Symbol(42, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, o2);
		}
		case 90:
		{
			
			string o2 = "terminal";
			return new Symbol(42, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, o2);
		}
		case 89:
		{
			
			string o2 = "parser";
			return new Symbol(42, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, o2);
		}
		case 88:
		{
			
			string o2 = "action";
			return new Symbol(42, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, o2);
		}
		case 87:
		{
			
			string o2 = "code";
			return new Symbol(42, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, o2);
		}
		case 86:
		{
			
			_ = ((Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((Symbol)P_2.elementAt(P_3 - 0)).right;
			string text = (string)((Symbol)P_2.elementAt(P_3 - 0)).value;
			string o2 = text;
			return new Symbol(42, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, o2);
		}
		case 85:
		{
			
			_ = ((Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((Symbol)P_2.elementAt(P_3 - 0)).right;
			string text = (string)((Symbol)P_2.elementAt(P_3 - 0)).value;
			string o2 = text;
			return new Symbol(38, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, o2);
		}
		case 84:
		{
			
			lexer.emit_error("Illegal use of reserved word");
			string o2 = "ILLEGAL";
			return new Symbol(37, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, o2);
		}
		case 83:
		{
			
			_ = ((Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((Symbol)P_2.elementAt(P_3 - 0)).right;
			string text = (string)((Symbol)P_2.elementAt(P_3 - 0)).value;
			string o2 = text;
			return new Symbol(37, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, o2);
		}
		case 82:
		{
			
			lexer.emit_error("Illegal use of reserved word");
			string o2 = "ILLEGAL";
			return new Symbol(36, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, o2);
		}
		case 81:
		{
			
			_ = ((Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((Symbol)P_2.elementAt(P_3 - 0)).right;
			string text = (string)((Symbol)P_2.elementAt(P_3 - 0)).value;
			string o2 = text;
			return new Symbol(36, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, o2);
		}
		case 80:
		{
			
			_ = ((Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((Symbol)P_2.elementAt(P_3 - 0)).right;
			string text = (string)((Symbol)P_2.elementAt(P_3 - 0)).value;
			if (symbols.get(text) != null)
			{
				lexer.emit_error(new StringBuilder().append("java_cup.runtime.Symbol \"").append(text).append("\" has already been declared")
					.toString());
			}
			else
			{
				if (String.instancehelper_equals(multipart_name, ""))
				{
					append_multipart("Object");
				}
				non_terminal.___003Cclinit_003E();
				non_terminal value2 = new non_terminal(text, multipart_name);
				non_terms.put(text, value2);
				symbols.put(text, new symbol_part(value2));
			}
			return new Symbol(26, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		}
		case 79:
		{
			
			_ = ((Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((Symbol)P_2.elementAt(P_3 - 0)).right;
			string text = (string)((Symbol)P_2.elementAt(P_3 - 0)).value;
			if (symbols.get(text) != null)
			{
				lexer.emit_error(new StringBuilder().append("java_cup.runtime.Symbol \"").append(text).append("\" has already been declared")
					.toString());
			}
			else
			{
				if (String.instancehelper_equals(multipart_name, ""))
				{
					append_multipart("Object");
				}
				Hashtable hashtable = symbols;
				string key = text;
				terminal.___003Cclinit_003E();
				hashtable.put(key, new symbol_part(new terminal(text, multipart_name)));
			}
			return new Symbol(25, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		}
		case 78:
			
			multipart_name = String.instancehelper_concat(multipart_name, "[]");
			return new Symbol(19, ((Symbol)P_2.elementAt(P_3 - 2)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 77:
			
			return new Symbol(19, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 76:
			
			return new Symbol(15, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 75:
			
			append_multipart("*");
			return new Symbol(15, ((Symbol)P_2.elementAt(P_3 - 2)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 74:
		{
			
			_ = ((Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((Symbol)P_2.elementAt(P_3 - 0)).right;
			string text = (string)((Symbol)P_2.elementAt(P_3 - 0)).value;
			append_multipart(text);
			return new Symbol(13, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		}
		case 73:
		{
			
			_ = ((Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((Symbol)P_2.elementAt(P_3 - 0)).right;
			string text = (string)((Symbol)P_2.elementAt(P_3 - 0)).value;
			append_multipart(text);
			return new Symbol(13, ((Symbol)P_2.elementAt(P_3 - 2)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		}
		case 72:
			
			
			return new Symbol(39, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 71:
		{
			
			_ = ((Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((Symbol)P_2.elementAt(P_3 - 0)).right;
			string text = (string)((Symbol)P_2.elementAt(P_3 - 0)).value;
			string o2 = text;
			return new Symbol(39, ((Symbol)P_2.elementAt(P_3 - 1)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, o2);
		}
		case 70:
		{
			
			_ = ((Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((Symbol)P_2.elementAt(P_3 - 0)).right;
			string text = (string)((Symbol)P_2.elementAt(P_3 - 0)).value;
			add_rhs_part(new action_part(text));
			return new Symbol(24, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		}
		case 69:
		{
			
			_ = ((Symbol)P_2.elementAt(P_3 - 1)).left;
			_ = ((Symbol)P_2.elementAt(P_3 - 1)).right;
			string text = (string)((Symbol)P_2.elementAt(P_3 - 1)).value;
			_ = ((Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((Symbol)P_2.elementAt(P_3 - 0)).right;
			string text2 = (string)((Symbol)P_2.elementAt(P_3 - 0)).value;
			production_part production_part2 = (production_part)symbols.get(text);
			if (production_part2 == null)
			{
				if (lexer.error_count == 0)
				{
					lexer.emit_error(new StringBuilder().append("java_cup.runtime.Symbol \"").append(text).append("\" has not been declared")
						.toString());
				}
			}
			else
			{
				add_rhs_part(add_lab(production_part2, text2));
			}
			return new Symbol(24, ((Symbol)P_2.elementAt(P_3 - 1)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		}
		case 68:
			
			return new Symbol(23, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 67:
			
			return new Symbol(23, ((Symbol)P_2.elementAt(P_3 - 1)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 66:
			
			if (lhs_nt != null)
			{
				production.___003Cclinit_003E();
				new production(lhs_nt, rhs_parts, rhs_pos);
				if (start_nt == null)
				{
					start_nt = lhs_nt;
					new_rhs();
					add_rhs_part(add_lab(new symbol_part(start_nt), "start_val"));
					add_rhs_part(new symbol_part(terminal.___003C_003EEOF));
					add_rhs_part(new action_part("RESULT = start_val;"));
					production.___003Cclinit_003E();
					emit.start_production = new production(non_terminal.___003C_003ESTART_nt, rhs_parts, rhs_pos);
					new_rhs();
				}
			}
			new_rhs();
			return new Symbol(28, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 65:
		{
			
			_ = ((Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((Symbol)P_2.elementAt(P_3 - 0)).right;
			string text = (string)((Symbol)P_2.elementAt(P_3 - 0)).value;
			
			if (lhs_nt != null)
			{
				symbol symbol2;
				if (text == null)
				{
					java.lang.System.err.println("No terminal for contextual precedence");
					symbol2 = null;
				}
				else
				{
					symbol2 = ((symbol_part)symbols.get(text)).the_symbol();
				}
				if (symbol2 != null && symbol2 is terminal)
				{
					production.___003Cclinit_003E();
					new production(lhs_nt, rhs_parts, rhs_pos, ((terminal)symbol2).precedence_num(), ((terminal)symbol2).precedence_side());
					((symbol_part)symbols.get(text)).the_symbol().note_use();
				}
				else
				{
					java.lang.System.err.println(new StringBuilder().append("Invalid terminal ").append(text).append(" for contextual precedence assignment")
						.toString());
					production.___003Cclinit_003E();
					new production(lhs_nt, rhs_parts, rhs_pos);
				}
				if (start_nt == null)
				{
					start_nt = lhs_nt;
					new_rhs();
					add_rhs_part(add_lab(new symbol_part(start_nt), "start_val"));
					add_rhs_part(new symbol_part(terminal.___003C_003EEOF));
					add_rhs_part(new action_part("RESULT = start_val;"));
					if (symbol2 != null && symbol2 is terminal)
					{
						production.___003Cclinit_003E();
						emit.start_production = new production(non_terminal.___003C_003ESTART_nt, rhs_parts, rhs_pos, ((terminal)symbol2).precedence_num(), ((terminal)symbol2).precedence_side());
					}
					else
					{
						production.___003Cclinit_003E();
						emit.start_production = new production(non_terminal.___003C_003ESTART_nt, rhs_parts, rhs_pos);
					}
					new_rhs();
				}
			}
			new_rhs();
			return new Symbol(28, ((Symbol)P_2.elementAt(P_3 - 2)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		}
		case 64:
			
			return new Symbol(27, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 63:
			
			return new Symbol(27, ((Symbol)P_2.elementAt(P_3 - 2)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 62:
		{
			object o = null;
			if (((Symbol)P_2.elementAt(P_3 - 1)).value != null)
			{
				o = ((Symbol)P_2.elementAt(P_3 - 1)).value;
			}
			return new Symbol(22, ((Symbol)P_2.elementAt(P_3 - 2)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, o);
		}
		case 61:
			
			lexer.emit_error("Syntax Error");
			return new Symbol(56, ((Symbol)P_2.elementAt(P_3 - 0)).right, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 60:
		{
			object o = null;
			if (((Symbol)P_2.elementAt(P_3 - 4)).value != null)
			{
				o = ((Symbol)P_2.elementAt(P_3 - 4)).value;
			}
			if (((Symbol)P_2.elementAt(P_3 - 2)).value != null)
			{
				o = ((Symbol)P_2.elementAt(P_3 - 2)).value;
			}
			_ = ((Symbol)P_2.elementAt(P_3 - 5)).left;
			_ = ((Symbol)P_2.elementAt(P_3 - 5)).right;
			_ = (string)((Symbol)P_2.elementAt(P_3 - 5)).value;
			return new Symbol(22, ((Symbol)P_2.elementAt(P_3 - 5)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, o);
		}
		case 59:
			
			_ = ((Symbol)P_2.elementAt(P_3 - 2)).left;
			_ = ((Symbol)P_2.elementAt(P_3 - 2)).right;
			_ = (string)((Symbol)P_2.elementAt(P_3 - 2)).value;
			return new Symbol(55, ((Symbol)P_2.elementAt(P_3 - 0)).right, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 58:
		{
			
			_ = ((Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((Symbol)P_2.elementAt(P_3 - 0)).right;
			string text = (string)((Symbol)P_2.elementAt(P_3 - 0)).value;
			lhs_nt = (non_terminal)non_terms.get(text);
			if (lhs_nt == null && lexer.error_count == 0)
			{
				lexer.emit_error(new StringBuilder().append("LHS non terminal \"").append(text).append("\" has not been declared")
					.toString());
			}
			new_rhs();
			return new Symbol(54, ((Symbol)P_2.elementAt(P_3 - 0)).right, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		}
		case 57:
			
			return new Symbol(12, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 56:
			
			return new Symbol(12, ((Symbol)P_2.elementAt(P_3 - 1)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 55:
			
			return new Symbol(11, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 54:
		{
			object o = null;
			if (((Symbol)P_2.elementAt(P_3 - 1)).value != null)
			{
				o = ((Symbol)P_2.elementAt(P_3 - 1)).value;
			}
			_ = ((Symbol)P_2.elementAt(P_3 - 2)).left;
			_ = ((Symbol)P_2.elementAt(P_3 - 2)).right;
			_ = (string)((Symbol)P_2.elementAt(P_3 - 2)).value;
			return new Symbol(11, ((Symbol)P_2.elementAt(P_3 - 4)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, o);
		}
		case 53:
		{
			
			_ = ((Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((Symbol)P_2.elementAt(P_3 - 0)).right;
			string text = (string)((Symbol)P_2.elementAt(P_3 - 0)).value;
			non_terminal value2 = (non_terminal)non_terms.get(text);
			if (value2 == null)
			{
				lexer.emit_error(new StringBuilder().append("Start non terminal \"").append(text).append("\" has not been declared")
					.toString());
			}
			else
			{
				start_nt = value2;
				new_rhs();
				add_rhs_part(add_lab(new symbol_part(start_nt), "start_val"));
				add_rhs_part(new symbol_part(terminal.___003C_003EEOF));
				add_rhs_part(new action_part("RESULT = start_val;"));
				production.___003Cclinit_003E();
				emit.start_production = new production(non_terminal.___003C_003ESTART_nt, rhs_parts, rhs_pos);
				new_rhs();
			}
			return new Symbol(53, ((Symbol)P_2.elementAt(P_3 - 0)).right, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		}
		case 52:
		{
			
			_ = ((Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((Symbol)P_2.elementAt(P_3 - 0)).right;
			string text = (string)((Symbol)P_2.elementAt(P_3 - 0)).value;
			if (symbols.get(text) == null)
			{
				lexer.emit_error(new StringBuilder().append("Terminal \"").append(text).append("\" has not been declared")
					.toString());
			}
			string o2 = text;
			return new Symbol(41, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, o2);
		}
		case 51:
		{
			
			_ = ((Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((Symbol)P_2.elementAt(P_3 - 0)).right;
			string text = (string)((Symbol)P_2.elementAt(P_3 - 0)).value;
			add_precedence(text);
			string o2 = text;
			return new Symbol(40, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, o2);
		}
		case 50:
			
			return new Symbol(32, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 49:
			
			return new Symbol(32, ((Symbol)P_2.elementAt(P_3 - 2)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 48:
		{
			object o = null;
			if (((Symbol)P_2.elementAt(P_3 - 2)).value != null)
			{
				o = ((Symbol)P_2.elementAt(P_3 - 2)).value;
			}
			return new Symbol(31, ((Symbol)P_2.elementAt(P_3 - 4)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, o);
		}
		case 47:
			
			update_precedence(2);
			return new Symbol(52, ((Symbol)P_2.elementAt(P_3 - 0)).right, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 46:
		{
			object o = null;
			if (((Symbol)P_2.elementAt(P_3 - 2)).value != null)
			{
				o = ((Symbol)P_2.elementAt(P_3 - 2)).value;
			}
			return new Symbol(31, ((Symbol)P_2.elementAt(P_3 - 4)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, o);
		}
		case 45:
			
			update_precedence(1);
			return new Symbol(51, ((Symbol)P_2.elementAt(P_3 - 0)).right, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 44:
		{
			object o = null;
			if (((Symbol)P_2.elementAt(P_3 - 2)).value != null)
			{
				o = ((Symbol)P_2.elementAt(P_3 - 2)).value;
			}
			return new Symbol(31, ((Symbol)P_2.elementAt(P_3 - 4)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, o);
		}
		case 43:
			
			update_precedence(0);
			return new Symbol(50, ((Symbol)P_2.elementAt(P_3 - 0)).right, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 42:
			
			return new Symbol(33, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 41:
			
			return new Symbol(33, ((Symbol)P_2.elementAt(P_3 - 1)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 40:
			
			return new Symbol(30, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 39:
			
			return new Symbol(30, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 38:
			
			return new Symbol(21, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 37:
			
			return new Symbol(21, ((Symbol)P_2.elementAt(P_3 - 2)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 36:
			
			return new Symbol(20, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 35:
			
			return new Symbol(20, ((Symbol)P_2.elementAt(P_3 - 2)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 34:
		{
			object o = null;
			if (((Symbol)P_2.elementAt(P_3 - 1)).value != null)
			{
				o = ((Symbol)P_2.elementAt(P_3 - 1)).value;
			}
			return new Symbol(35, ((Symbol)P_2.elementAt(P_3 - 2)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, o);
		}
		case 33:
			
			multipart_name = String.newhelper();
			return new Symbol(49, ((Symbol)P_2.elementAt(P_3 - 0)).right, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 32:
		{
			object o = null;
			if (((Symbol)P_2.elementAt(P_3 - 1)).value != null)
			{
				o = ((Symbol)P_2.elementAt(P_3 - 1)).value;
			}
			return new Symbol(34, ((Symbol)P_2.elementAt(P_3 - 2)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, o);
		}
		case 31:
			
			multipart_name = String.newhelper();
			return new Symbol(48, ((Symbol)P_2.elementAt(P_3 - 0)).right, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 30:
		{
			object o = null;
			if (((Symbol)P_2.elementAt(P_3 - 1)).value != null)
			{
				o = ((Symbol)P_2.elementAt(P_3 - 1)).value;
			}
			return new Symbol(18, ((Symbol)P_2.elementAt(P_3 - 3)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, o);
		}
		case 29:
			
			multipart_name = String.newhelper();
			return new Symbol(47, ((Symbol)P_2.elementAt(P_3 - 0)).right, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 28:
		{
			object o = null;
			if (((Symbol)P_2.elementAt(P_3 - 1)).value != null)
			{
				o = ((Symbol)P_2.elementAt(P_3 - 1)).value;
			}
			return new Symbol(18, ((Symbol)P_2.elementAt(P_3 - 3)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, o);
		}
		case 27:
			
			multipart_name = String.newhelper();
			return new Symbol(46, ((Symbol)P_2.elementAt(P_3 - 0)).right, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 26:
			
			return new Symbol(18, ((Symbol)P_2.elementAt(P_3 - 1)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 25:
			
			return new Symbol(18, ((Symbol)P_2.elementAt(P_3 - 2)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 24:
			
			return new Symbol(18, ((Symbol)P_2.elementAt(P_3 - 1)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 23:
			
			return new Symbol(18, ((Symbol)P_2.elementAt(P_3 - 2)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 22:
			
			return new Symbol(10, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 21:
			
			return new Symbol(10, ((Symbol)P_2.elementAt(P_3 - 1)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 20:
		{
			
			_ = ((Symbol)P_2.elementAt(P_3 - 1)).left;
			_ = ((Symbol)P_2.elementAt(P_3 - 1)).right;
			string text = (string)((Symbol)P_2.elementAt(P_3 - 1)).value;
			if (emit.scan_code != null)
			{
				lexer.emit_error("Redundant scan code (skipping)");
			}
			else
			{
				emit.scan_code = text;
			}
			return new Symbol(17, ((Symbol)P_2.elementAt(P_3 - 3)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		}
		case 19:
		{
			
			_ = ((Symbol)P_2.elementAt(P_3 - 1)).left;
			_ = ((Symbol)P_2.elementAt(P_3 - 1)).right;
			string text = (string)((Symbol)P_2.elementAt(P_3 - 1)).value;
			if (emit.init_code != null)
			{
				lexer.emit_error("Redundant init code (skipping)");
			}
			else
			{
				emit.init_code = text;
			}
			return new Symbol(16, ((Symbol)P_2.elementAt(P_3 - 3)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		}
		case 18:
		{
			
			_ = ((Symbol)P_2.elementAt(P_3 - 1)).left;
			_ = ((Symbol)P_2.elementAt(P_3 - 1)).right;
			string text = (string)((Symbol)P_2.elementAt(P_3 - 1)).value;
			if (emit.parser_code != null)
			{
				lexer.emit_error("Redundant parser code (skipping)");
			}
			else
			{
				emit.parser_code = text;
			}
			return new Symbol(9, ((Symbol)P_2.elementAt(P_3 - 3)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		}
		case 17:
		{
			
			_ = ((Symbol)P_2.elementAt(P_3 - 1)).left;
			_ = ((Symbol)P_2.elementAt(P_3 - 1)).right;
			string text = (string)((Symbol)P_2.elementAt(P_3 - 1)).value;
			if (emit.action_code != null)
			{
				lexer.emit_error("Redundant action code (skipping)");
			}
			else
			{
				emit.action_code = text;
			}
			return new Symbol(4, ((Symbol)P_2.elementAt(P_3 - 3)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		}
		case 16:
			
			return new Symbol(5, ((Symbol)P_2.elementAt(P_3 - 1)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 15:
			
			return new Symbol(5, ((Symbol)P_2.elementAt(P_3 - 0)).right, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 14:
			
			return new Symbol(6, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 13:
			
			return new Symbol(6, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 12:
			
			return new Symbol(6, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 11:
			
			return new Symbol(6, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 10:
		{
			object o = null;
			if (((Symbol)P_2.elementAt(P_3 - 1)).value != null)
			{
				o = ((Symbol)P_2.elementAt(P_3 - 1)).value;
			}
			return new Symbol(14, ((Symbol)P_2.elementAt(P_3 - 3)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, o);
		}
		case 9:
			
			emit.import_list.push(multipart_name);
			multipart_name = String.newhelper();
			return new Symbol(45, ((Symbol)P_2.elementAt(P_3 - 0)).right, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 8:
			
			return new Symbol(3, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 7:
			
			return new Symbol(3, ((Symbol)P_2.elementAt(P_3 - 1)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 6:
			
			return new Symbol(2, ((Symbol)P_2.elementAt(P_3 - 0)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 5:
		{
			object o = null;
			if (((Symbol)P_2.elementAt(P_3 - 1)).value != null)
			{
				o = ((Symbol)P_2.elementAt(P_3 - 1)).value;
			}
			return new Symbol(2, ((Symbol)P_2.elementAt(P_3 - 3)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, o);
		}
		case 4:
			
			emit.package_name = multipart_name;
			multipart_name = String.newhelper();
			return new Symbol(44, ((Symbol)P_2.elementAt(P_3 - 0)).right, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 3:
			
			return new Symbol(1, ((Symbol)P_2.elementAt(P_3 - 4)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 2:
		{
			object o = null;
			if (((Symbol)P_2.elementAt(P_3 - 7)).value != null)
			{
				o = ((Symbol)P_2.elementAt(P_3 - 7)).value;
			}
			return new Symbol(1, ((Symbol)P_2.elementAt(P_3 - 7)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, o);
		}
		case 1:
			
			symbols.put("error", new symbol_part(terminal.___003C_003Eerror));
			non_terms.put("$START", non_terminal.___003C_003ESTART_nt);
			return new Symbol(43, ((Symbol)P_2.elementAt(P_3 - 0)).right, ((Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 0:
		{
			
			_ = ((Symbol)P_2.elementAt(P_3 - 1)).left;
			_ = ((Symbol)P_2.elementAt(P_3 - 1)).right;
			object value = ((Symbol)P_2.elementAt(P_3 - 1)).value;
			object o = value;
			Symbol result = new Symbol(0, ((Symbol)P_2.elementAt(P_3 - 1)).left, ((Symbol)P_2.elementAt(P_3 - 0)).right, o);
			P_1.done_parsing();
			return result;
		}
		default:
			
			throw new Exception("Invalid action number found in internal parse table");
		}
	}
}
