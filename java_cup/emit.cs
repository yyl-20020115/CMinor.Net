

using IKVM.Runtime;
using java.io;
using java.lang;


namespace java_cup;

public class emit
{
	public static string prefix;

	public static string package_name;

	public static string symbol_const_class_name;

	public static string parser_class_name;

	public static string action_code;

	public static string parser_code;

	public static string init_code;

	public static string scan_code;

	public static production start_production;

	public static Stack import_list;

	public static int num_conflicts;

	public static bool nowarn;

	public static int not_reduced;

	public static int unused_term;

	public static int unused_non_term;

	public static long symbols_time;

	public static long parser_time;

	public static long action_code_time;

	public static long production_table_time;

	public static long action_table_time;

	public static long goto_table_time;

	protected internal static bool _lr_values;

	
	
	public static void ___003Cclinit_003E()
	{
	}

	public static bool lr_values()
	{
		return _lr_values;
	}

	
	
	protected internal static string pre(string str)
	{
		string result = new StringBuilder().append(prefix).append(parser_class_name).append("$")
			.append(str)
			.toString();
		
		return result;
	}

	
	
	protected internal static void emit_package(PrintWriter @out)
	{
		if (package_name != null)
		{
			@out.println(new StringBuilder().append("package ").append(package_name).append(";")
				.toString());
			@out.println();
		}
	}

	
	[LineNumberTable(new byte[]
	{
		162, 72, 107, 107, 100, 111, 105, 114, 105, 106,
		113, 105, 116, 105, 169, 113, 233, 60, 230, 59,
		233, 76, 109
	})]
	protected internal static void do_table_as_string(PrintWriter @out, short[][] sa)
	{
		@out.println("new String[] {");
		@out.print("    \"");
		int nchar = 0;
		int num = 0;
		num += do_escaped(@out, (char)((nint)sa.LongLength >> 16));
		nchar = do_newline(@out, nchar, num);
		num += do_escaped(@out, (char)((nint)sa.LongLength & 0xFFFF));
		nchar = do_newline(@out, nchar, num);
		for (int i = 0; i < (nint)sa.LongLength; i++)
		{
			num += do_escaped(@out, (char)((nint)sa[i].LongLength >> 16));
			nchar = do_newline(@out, nchar, num);
			num += do_escaped(@out, (char)((nint)sa[i].LongLength & 0xFFFF));
			nchar = do_newline(@out, nchar, num);
			for (int j = 0; j < (nint)sa[i].LongLength; j++)
			{
				num += do_escaped(@out, (char)(2 + sa[i][j]));
				nchar = do_newline(@out, nchar, num);
			}
		}
		@out.print("\" }");
	}

	
	[LineNumberTable(new byte[]
	{
		158, 216, 66, 102, 104, 109, 149, 109, 117, 138,
		106, 172, 101, 107, 114
	})]
	protected internal static int do_escaped(PrintWriter @out, char c)
	{
		StringBuilder stringBuffer = new StringBuilder();
		if (c <= 'ÿ')
		{
			stringBuffer.append(Integer.toOctalString(c));
			while (stringBuffer.length() < 3)
			{
				stringBuffer.insert(0, '0');
			}
		}
		else
		{
			stringBuffer.append(Integer.toHexString(c));
			while (stringBuffer.length() < 4)
			{
				stringBuffer.insert(0, '0');
			}
			stringBuffer.insert(0, 'u');
		}
		stringBuffer.insert(0, '\\');
		@out.print(stringBuffer.toString());
		if (c == '\0')
		{
			return 2;
		}
		if (c >= '\u0001' && c <= '\u007f')
		{
			return 1;
		}
		if (c >= '\u0080' && c <= '߿')
		{
			return 2;
		}
		return 3;
	}

	
	
	protected internal static int do_newline(PrintWriter @out, int nchar, int nbytes)
	{
		if (nbytes > 65500)
		{
			@out.println("\", ");
			@out.print("    \"");
		}
		else
		{
			if (nchar <= 11)
			{
				return nchar + 1;
			}
			@out.println("\" +");
			@out.print("    \"");
		}
		return 0;
	}

	
	[LineNumberTable(new byte[]
	{
		161, 121, 166, 107, 142, 108, 203, 127, 18, 140,
		133, 120, 238, 59, 232, 72, 102, 107, 107, 107,
		104, 171, 102, 107, 171, 108
	})]
	protected internal static void emit_production_table(PrintWriter @out)
	{
		long num = java.lang.System.currentTimeMillis();
		production[] array = new production[production.number()];
		Enumeration enumeration = production.all();
		while (enumeration.hasMoreElements())
		{
			production production2 = (production)enumeration.nextElement();
			array[production2.index()] = production2;
		}
		int num2 = production.number();
		int[] array2 = new int[2];
		int num3 = (array2[1] = 2);
		num3 = (array2[0] = num2);
		short[][] array3 = (short[][])ByteCodeHelper.multianewarray(typeof(short[][]).TypeHandle, array2);
		for (int i = 0; i < production.number(); i++)
		{
			production production2 = array[i];
			array3[i][0] = (short)production2.lhs().the_symbol().index();
			array3[i][1] = (short)production2.rhs_length();
		}
		@out.println();
		@out.println("  /** Production table. */");
		@out.println("  protected static final short _production_table[][] = ");
		@out.print("    unpackFromStrings(");
		do_table_as_string(@out, array3);
		@out.println(");");
		@out.println();
		@out.println("  /** Access to production table. */");
		@out.println("  public short[][] production_table() {return _production_table;}");
		production_table_time = java.lang.System.currentTimeMillis() - num;
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	[LineNumberTable(new byte[]
	{
		159,
		6,
		66,
		166,
		140,
		174,
		170,
		99,
		137,
		168,
		113,
		163,
		178,
		172,
		236,
		69,
		170,
		110,
		byte.MaxValue,
		5,
		69,
		170,
		115,
		142,
		110,
		147,
		236,
		70,
		byte.MaxValue,
		22,
		29,
		235,
		105,
		108,
		174,
		109,
		106,
		153,
		237,
		159,
		191,
		233,
		160,
		69,
		102,
		107,
		107,
		107,
		103,
		171,
		102,
		107,
		139,
		108
	})]
	protected internal static void do_action_table(PrintWriter @out, parse_action_table act_tab, bool compact_reduces)
	{
		long num = java.lang.System.currentTimeMillis();
		short[][] array = new short[act_tab.num_states()][];
		for (int i = 0; i < act_tab.num_states(); i++)
		{
			parse_action_row parse_action_row2 = act_tab.under_state[i];
			if (compact_reduces)
			{
				parse_action_row2.compute_default();
			}
			else
			{
				parse_action_row2.default_reduce = -1;
			}
			short[] array2 = new short[2 * parse_action_row.size()];
			int num2 = 0;
			for (int j = 0; j < parse_action_row.size(); j++)
			{
				parse_action parse_action2 = parse_action_row2.under_term[j];
				if (parse_action2.kind() == 0)
				{
					continue;
				}
				if (parse_action2.kind() == 1)
				{
					int num3 = num2;
					num2++;
					array2[num3] = (short)j;
					int num4 = num2;
					num2++;
					array2[num4] = (short)(((shift_action)parse_action2).shift_to().index() + 1);
				}
				else if (parse_action2.kind() == 2)
				{
					int num5 = ((reduce_action)parse_action2).reduce_with().index();
					if (num5 != parse_action_row2.default_reduce)
					{
						int num6 = num2;
						num2++;
						array2[num6] = (short)j;
						int num7 = num2;
						num2++;
						array2[num7] = (short)(-(num5 + 1));
					}
				}
				else if (parse_action2.kind() != 3)
				{
					string msg = new StringBuilder().append("Unrecognized action code ").append(parse_action2.kind()).append(" found in parse table")
						.toString();
					
					throw new internal_error(msg);
				}
			}
			array[i] = new short[num2 + 2];
			ByteCodeHelper.arraycopy_primitive_2(array2, 0, array[i], 0, num2);
			short[] obj = array[i];
			int num8 = num2;
			num2++;
			obj[num8] = -1;
			if (parse_action_row2.default_reduce != -1)
			{
				short[] obj2 = array[i];
				int num9 = num2;
				num2++;
				obj2[num9] = (short)(-(parse_action_row2.default_reduce + 1));
			}
			else
			{
				short[] obj3 = array[i];
				int num10 = num2;
				num2++;
				obj3[num10] = 0;
			}
		}
		@out.println();
		@out.println("  /** Parse-action table. */");
		@out.println("  protected static final short[][] _action_table = ");
		@out.print("    unpackFromStrings(");
		do_table_as_string(@out, array);
		@out.println(");");
		@out.println();
		@out.println("  /** Access to parse-action table. */");
		@out.println("  public short[][] action_table() {return _action_table;}");
		action_table_time = java.lang.System.currentTimeMillis() - num;
	}

	
	[LineNumberTable(new byte[]
	{
		162, 20, 166, 140, 174, 118, 131, 181, 178, 164,
		109, 242, 54, 232, 78, 108, 173, 109, 237, 39,
		233, 93, 102, 107, 107, 107, 103, 171, 102, 107,
		107, 134, 108
	})]
	protected internal static void do_reduce_table(PrintWriter @out, parse_reduce_table red_tab)
	{
		long num = java.lang.System.currentTimeMillis();
		short[][] array = new short[red_tab.num_states()][];
		for (int i = 0; i < red_tab.num_states(); i++)
		{
			_ = red_tab.under_state[i];
			short[] array2 = new short[2 * parse_reduce_row.size()];
			int num2 = 0;
			int num3 = 0;
			while (true)
			{
				int num4 = num3;
				_ = red_tab.under_state[i];
				if (num4 >= parse_reduce_row.size())
				{
					break;
				}
				lalr_state lalr_state2 = red_tab.under_state[i].under_non_term[num3];
				if (lalr_state2 != null)
				{
					int num5 = num2;
					num2++;
					array2[num5] = (short)num3;
					int num6 = num2;
					num2++;
					array2[num6] = (short)lalr_state2.index();
				}
				num3++;
			}
			array[i] = new short[num2 + 2];
			ByteCodeHelper.arraycopy_primitive_2(array2, 0, array[i], 0, num2);
			short[] obj = array[i];
			int num7 = num2;
			num2++;
			obj[num7] = -1;
			short[] obj2 = array[i];
			int num8 = num2;
			num2++;
			obj2[num8] = -1;
		}
		@out.println();
		@out.println("  /** <code>reduce_goto</code> table. */");
		@out.println("  protected static final short[][] _reduce_table = ");
		@out.print("    unpackFromStrings(");
		do_table_as_string(@out, array);
		@out.println(");");
		@out.println();
		@out.println("  /** Access to <code>reduce_goto</code> table. */");
		@out.println("  public short[][] reduce_table() {return _reduce_table;}");
		@out.println();
		goto_table_time = java.lang.System.currentTimeMillis() - num;
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	[LineNumberTable(new byte[]
	{
		160,
		203,
		166,
		102,
		171,
		191,
		20,
		135,
		102,
		203,
		191,
		15,
		102,
		107,
		127,
		40,
		107,
		171,
		102,
		107,
		159,
		20,
		127,
		10,
		127,
		10,
		127,
		10,
		127,
		10,
		107,
		235,
		69,
		107,
		127,
		20,
		166,
		107,
		127,
		20,
		171,
		145,
		172,
		107,
		223,
		27,
		235,
		70,
		byte.MaxValue,
		26,
		71,
		142,
		115,
		115,
		174,
		147,
		108,
		159,
		7,
		191,
		62,
		byte.MaxValue,
		103,
		49,
		233,
		86,
		159,
		8,
		241,
		72,
		170,
		99,
		159,
		58,
		104,
		134,
		105,
		191,
		57,
		223,
		126,
		101,
		byte.MaxValue,
		92,
		71,
		171,
		132,
		107,
		223,
		20,
		127,
		20,
		203,
		107,
		107,
		107,
		139,
		102,
		171,
		171,
		107,
		134,
		108
	})]
	protected internal static void emit_action_code(PrintWriter @out, production start_prod)
	{
		long num = java.lang.System.currentTimeMillis();
		@out.println();
		@out.println("/** Cup generated class to encapsulate user supplied action code.*/");
		@out.println(new StringBuilder().append("class ").append(pre("actions")).append(" {")
			.toString());
		if (action_code != null)
		{
			@out.println();
			@out.println(action_code);
		}
		@out.println(new StringBuilder().append("  private final ").append(parser_class_name).append(" parser;")
			.toString());
		@out.println();
		@out.println("  /** Constructor */");
		@out.println(new StringBuilder().append("  ").append(pre("actions")).append("(")
			.append(parser_class_name)
			.append(" parser) {")
			.toString());
		@out.println("    this.parser = parser;");
		@out.println("  }");
		@out.println();
		@out.println("  /** Method with the actual generated action code. */");
		@out.println(new StringBuilder().append("  public final java_cup.runtime.Symbol ").append(pre("do_action")).append("(")
			.toString());
		@out.println(new StringBuilder().append("    int                        ").append(pre("act_num,")).toString());
		@out.println(new StringBuilder().append("    java_cup.runtime.lr_parser ").append(pre("parser,")).toString());
		@out.println(new StringBuilder().append("    java.util.Stack            ").append(pre("stack,")).toString());
		@out.println(new StringBuilder().append("    int                        ").append(pre("top)")).toString());
		@out.println("    throws System.Exception");
		@out.println("    {");
		@out.println("      /* Symbol object for return from actions */");
		@out.println(new StringBuilder().append("      java_cup.runtime.Symbol ").append(pre("result")).append(";")
			.toString());
		@out.println();
		@out.println("      /* select the action based on the action number */");
		@out.println(new StringBuilder().append("      switch (").append(pre("act_num")).append(")")
			.toString());
		@out.println("        {");
		Enumeration enumeration = production.all();
		while (enumeration.hasMoreElements())
		{
			production production2 = (production)enumeration.nextElement();
			@out.println("          /*. . . . . . . . . . . . . . . . . . . .*/");
			@out.println(new StringBuilder().append("          case ").append(production2.index()).append(": // ")
				.append(production2.to_simple_string())
				.toString());
			@out.println("            {");
			@out.println(new StringBuilder().append("              ").append(production2.lhs().the_symbol().stack_type()).append(" RESULT = null;")
				.toString());
			for (int i = 0; i < production2.rhs_length(); i++)
			{
				if (production2.rhs(i) is symbol_part)
				{
					symbol symbol2 = ((symbol_part)production2.rhs(i)).the_symbol();
					if (symbol2 is non_terminal && ((non_terminal)symbol2).is_embedded_action)
					{
						int i2 = production2.rhs_length() - i - 1;
						@out.println(new StringBuilder().append("              // propagate RESULT from ").append(symbol2.name()).toString());
						@out.println(new StringBuilder().append("              if ( ((java_cup.runtime.Symbol) ").append(pre("stack")).append(".elementAt(")
							.append(pre("top"))
							.append("-")
							.append(i2)
							.append(")).value != null )")
							.toString());
						@out.println(new StringBuilder().append("                RESULT = (").append(production2.lhs().the_symbol().stack_type()).append(") ")
							.append("((java_cup.runtime.Symbol) ")
							.append(pre("stack"))
							.append(".elementAt(")
							.append(pre("top"))
							.append("-")
							.append(i2)
							.append(")).value;")
							.toString());
					}
				}
			}
			if (production2.action() != null && production2.action().code_string() != null && !production2.action().equals(""))
			{
				@out.println(production2.action().code_string());
			}
			if (lr_values())
			{
				int i3 = 0;
				string text = new StringBuilder().append("((java_cup.runtime.Symbol)").append(pre("stack")).append(".elementAt(")
					.append(pre("top"))
					.append("-")
					.append(i3)
					.append(")).right")
					.toString();
				string str;
				if (production2.rhs_length() == 0)
				{
					str = text;
				}
				else
				{
					int i = production2.rhs_length() - 1;
					str = new StringBuilder().append("((java_cup.runtime.Symbol)").append(pre("stack")).append(".elementAt(")
						.append(pre("top"))
						.append("-")
						.append(i)
						.append(")).left")
						.toString();
				}
				@out.println(new StringBuilder().append("              ").append(pre("result")).append(" = new java_cup.runtime.Symbol(")
					.append(production2.lhs().the_symbol().index())
					.append("/*")
					.append(production2.lhs().the_symbol().name())
					.append("*/")
					.append(", ")
					.append(str)
					.append(", ")
					.append(text)
					.append(", RESULT);")
					.toString());
			}
			else
			{
				@out.println(new StringBuilder().append("              ").append(pre("result")).append(" = new java_cup.runtime.Symbol(")
					.append(production2.lhs().the_symbol().index())
					.append("/*")
					.append(production2.lhs().the_symbol().name())
					.append("*/")
					.append(", RESULT);")
					.toString());
			}
			@out.println("            }");
			if (production2 == start_prod)
			{
				@out.println("          /* ACCEPT */");
				@out.println(new StringBuilder().append("          ").append(pre("parser")).append(".done_parsing();")
					.toString());
			}
			@out.println(new StringBuilder().append("          return ").append(pre("result")).append(";")
				.toString());
			@out.println();
		}
		@out.println("          /* . . . . . .*/");
		@out.println("          default:");
		@out.println("            throw new Exception(");
		@out.println("               \"Invalid action number found in internal parse table\");");
		@out.println();
		@out.println("        }");
		@out.println("    }");
		@out.println("}");
		@out.println();
		action_code_time = java.lang.System.currentTimeMillis() - num;
	}

	
	
	private emit()
	{
	}

	protected internal static void set_lr_values(bool b)
	{
		int num = ((_lr_values = b) ? 1 : 0);
	}

	
	[LineNumberTable(new byte[]
	{
		159,
		80,
		132,
		144,
		166,
		102,
		107,
		139,
		127,
		5,
		107,
		102,
		166,
		159,
		11,
		191,
		31,
		171,
		144,
		174,
		byte.MaxValue,
		41,
		69,
		134,
		102,
		171,
		144,
		174,
		byte.MaxValue,
		41,
		70,
		107,
		134,
		108
	})]
	public static void symbols(PrintWriter @out, bool emit_non_terms, bool sym_interface)
	{
		string str = ((!sym_interface) ? "class" : "interface");
		long num = java.lang.System.currentTimeMillis();
		@out.println();
		@out.println("//----------------------------------------------------");
		@out.println("// The following code was generated by CUP v0.10k");
		@out.println(new StringBuilder().append("// ").append(new Date()).toString());
		@out.println("//----------------------------------------------------");
		@out.println();
		emit_package(@out);
		@out.println(new StringBuilder().append("/** CUP generated ").append(str).append(" containing symbol constants. */")
			.toString());
		@out.println(new StringBuilder().append("public ").append(str).append(" ")
			.append(symbol_const_class_name)
			.append(" {")
			.toString());
		@out.println("  /* terminals */");
		Enumeration enumeration = terminal.all();
		while (enumeration.hasMoreElements())
		{
			terminal terminal2 = (terminal)enumeration.nextElement();
			@out.println(new StringBuilder().append("  public static final int ").append(terminal2.name()).append(" = ")
				.append(terminal2.index())
				.append(";")
				.toString());
		}
		if (emit_non_terms)
		{
			@out.println();
			@out.println("  /* non terminals */");
			enumeration = non_terminal.all();
			while (enumeration.hasMoreElements())
			{
				non_terminal non_terminal2 = (non_terminal)enumeration.nextElement();
				@out.println(new StringBuilder().append("  static final int ").append(non_terminal2.name()).append(" = ")
					.append(non_terminal2.index())
					.append(";")
					.toString());
			}
		}
		@out.println("}");
		@out.println();
		symbols_time = java.lang.System.currentTimeMillis() - num;
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	[LineNumberTable(new byte[]
	{
		158,
		206,
		70,
		166,
		102,
		107,
		139,
		127,
		5,
		107,
		102,
		166,
		111,
		63,
		21,
		198,
		102,
		107,
		127,
		5,
		107,
		223,
		15,
		102,
		107,
		127,
		15,
		99,
		102,
		107,
		byte.MaxValue,
		15,
		69,
		102,
		104,
		167,
		107,
		127,
		20,
		166,
		107,
		107,
		107,
		127,
		20,
		107,
		166,
		107,
		107,
		107,
		107,
		107,
		107,
		107,
		107,
		107,
		159,
		20,
		107,
		203,
		107,
		191,
		11,
		107,
		159,
		20,
		166,
		107,
		159,
		20,
		102,
		107,
		159,
		20,
		166,
		135,
		102,
		107,
		107,
		107,
		107,
		203,
		135,
		102,
		107,
		107,
		107,
		107,
		107,
		203,
		135,
		102,
		203,
		171,
		136,
		108
	})]
	public static void parser(PrintWriter @out, parse_action_table action_table, parse_reduce_table reduce_table, int start_st, production start_prod, bool compact_reduces, bool suppress_scanner)
	{
		long num = java.lang.System.currentTimeMillis();
		@out.println();
		@out.println("//----------------------------------------------------");
		@out.println("// The following code was generated by CUP v0.10k");
		@out.println(new StringBuilder().append("// ").append(new Date()).toString());
		@out.println("//----------------------------------------------------");
		@out.println();
		emit_package(@out);
		for (int i = 0; i < import_list.size(); i++)
		{
			@out.println(new StringBuilder().append("import ").append(import_list.elementAt(i)).append(";")
				.toString());
		}
		@out.println();
		@out.println("/** CUP v0.10k generated parser.");
		@out.println(new StringBuilder().append("  * @version ").append(new Date()).toString());
		@out.println("  */");
		@out.println(new StringBuilder().append("public class ").append(parser_class_name).append(" extends java_cup.runtime.lr_parser {")
			.toString());
		@out.println();
		@out.println("  /** Default constructor. */");
		@out.println(new StringBuilder().append("  public ").append(parser_class_name).append("() {super();}")
			.toString());
		if (!suppress_scanner)
		{
			@out.println();
			@out.println("  /** Constructor which sets the default scanner. */");
			@out.println(new StringBuilder().append("  public ").append(parser_class_name).append("(java_cup.runtime.Scanner s) {super(s);}")
				.toString());
		}
		emit_production_table(@out);
		do_action_table(@out, action_table, compact_reduces);
		do_reduce_table(@out, reduce_table);
		@out.println("  /** Instance of action encapsulation class. */");
		@out.println(new StringBuilder().append("  protected ").append(pre("actions")).append(" action_obj;")
			.toString());
		@out.println();
		@out.println("  /** Action encapsulation object initializer. */");
		@out.println("  protected void init_actions()");
		@out.println("    {");
		@out.println(new StringBuilder().append("      action_obj = new ").append(pre("actions")).append("(this);")
			.toString());
		@out.println("    }");
		@out.println();
		@out.println("  /** Invoke a user supplied parse action. */");
		@out.println("  public java_cup.runtime.Symbol do_action(");
		@out.println("    int                        act_num,");
		@out.println("    java_cup.runtime.lr_parser parser,");
		@out.println("    java.util.Stack            stack,");
		@out.println("    int                        top)");
		@out.println("    throws System.Exception");
		@out.println("  {");
		@out.println("    /* call code in generated class */");
		@out.println(new StringBuilder().append("    return action_obj.").append(pre("do_action(")).append("act_num, parser, stack, top);")
			.toString());
		@out.println("  }");
		@out.println("");
		@out.println("  /** Indicates start state. */");
		@out.println(new StringBuilder().append("  public int start_state() {return ").append(start_st).append(";}")
			.toString());
		@out.println("  /** Indicates start production. */");
		@out.println(new StringBuilder().append("  public int start_production() {return ").append(start_production.index()).append(";}")
			.toString());
		@out.println();
		@out.println("  /** <code>EOF</code> Symbol index. */");
		@out.println(new StringBuilder().append("  public int EOF_sym() {return ").append(terminal.___003C_003EEOF.index()).append(";}")
			.toString());
		@out.println();
		@out.println("  /** <code>error</code> Symbol index. */");
		@out.println(new StringBuilder().append("  public int error_sym() {return ").append(terminal.___003C_003Eerror.index()).append(";}")
			.toString());
		@out.println();
		if (init_code != null)
		{
			@out.println();
			@out.println("  /** User initialization code. */");
			@out.println("  public void user_init() throws System.Exception");
			@out.println("    {");
			@out.println(init_code);
			@out.println("    }");
		}
		if (scan_code != null)
		{
			@out.println();
			@out.println("  /** Scan to get the next Symbol. */");
			@out.println("  public java_cup.runtime.Symbol scan()");
			@out.println("    throws System.Exception");
			@out.println("    {");
			@out.println(scan_code);
			@out.println("    }");
		}
		if (parser_code != null)
		{
			@out.println();
			@out.println(parser_code);
		}
		@out.println("}");
		emit_action_code(@out, start_prod);
		parser_time = java.lang.System.currentTimeMillis() - num;
	}

	[LineNumberTable(new byte[]
	{
		62, 234, 69, 230, 69, 234, 69, 234, 69, 230,
		69, 230, 69, 230, 69, 230, 69, 230, 69, 234,
		69, 230, 69, 230, 69, 230, 69, 230, 69, 230,
		71, 167, 167, 167, 167, 167
	})]
	static emit()
	{
		prefix = "CUP$";
		package_name = null;
		symbol_const_class_name = "sym";
		parser_class_name = "parser";
		action_code = null;
		parser_code = null;
		init_code = null;
		scan_code = null;
		start_production = null;
		import_list = new Stack();
		num_conflicts = 0;
		nowarn = false;
		not_reduced = 0;
		unused_term = 0;
		unused_non_term = 0;
		symbols_time = 0L;
		parser_time = 0L;
		action_code_time = 0L;
		production_table_time = 0L;
		action_table_time = 0L;
		goto_table_time = 0L;
	}
}
