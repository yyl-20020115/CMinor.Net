

using IKVM.Runtime;
using java.io;



namespace JavaCUP;

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
		string result = (prefix)+(parser_class_name)+("$")
			+(str)
			.ToString();
		
		return result;
	}

	
	
	protected internal static void emit_package(PrintWriter @out)
	{
		if (package_name != null)
		{
			@out.WriteLine(("package ")+(package_name)+(";")
				);
			@out.WriteLine();
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
		@out.WriteLine("new String[] {");
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
			stringBuffer+(int.toOctalString(c));
			while (stringBuffer.length() < 3)
			{
				stringBuffer.insert(0, '0');
			}
		}
		else
		{
			stringBuffer+(int.toHexString(c));
			while (stringBuffer.length() < 4)
			{
				stringBuffer.insert(0, '0');
			}
			stringBuffer.insert(0, 'u');
		}
		stringBuffer.insert(0, '\\');
		@out.print(stringBuffer);
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
			@out.WriteLine("\", ");
			@out.print("    \"");
		}
		else
		{
			if (nchar <= 11)
			{
				return nchar + 1;
			}
			@out.WriteLine("\" +");
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
		@out.WriteLine();
		@out.WriteLine("  /** Production table. */");
		@out.WriteLine("  protected static final short _production_table[][] = ");
		@out.print("    unpackFromStrings(");
		do_table_as_string(@out, array3);
		@out.WriteLine(");");
		@out.WriteLine();
		@out.WriteLine("  /** Access to production table. */");
		@out.WriteLine("  public short[][] production_table() {return _production_table;}");
		production_table_time = java.lang.System.currentTimeMillis() - num;
	}

	
	
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
					string msg = ("Unrecognized action code ")+(parse_action2.kind())+(" found in parse table")
						.ToString();
					
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
		@out.WriteLine();
		@out.WriteLine("  /** Parse-action table. */");
		@out.WriteLine("  protected static final short[][] _action_table = ");
		@out.print("    unpackFromStrings(");
		do_table_as_string(@out, array);
		@out.WriteLine(");");
		@out.WriteLine();
		@out.WriteLine("  /** Access to parse-action table. */");
		@out.WriteLine("  public short[][] action_table() {return _action_table;}");
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
		@out.WriteLine();
		@out.WriteLine("  /** <code>reduce_goto</code> table. */");
		@out.WriteLine("  protected static final short[][] _reduce_table = ");
		@out.print("    unpackFromStrings(");
		do_table_as_string(@out, array);
		@out.WriteLine(");");
		@out.WriteLine();
		@out.WriteLine("  /** Access to <code>reduce_goto</code> table. */");
		@out.WriteLine("  public short[][] reduce_table() {return _reduce_table;}");
		@out.WriteLine();
		goto_table_time = java.lang.System.currentTimeMillis() - num;
	}

	
	
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
		@out.WriteLine();
		@out.WriteLine("/** Cup generated class to encapsulate user supplied action code.*/");
		@out.WriteLine(("class ")+(pre("actions"))+(" {")
			);
		if (action_code != null)
		{
			@out.WriteLine();
			@out.WriteLine(action_code);
		}
		@out.WriteLine(("  private final ")+(parser_class_name)+(" parser;")
			);
		@out.WriteLine();
		@out.WriteLine("  /** Constructor */");
		@out.WriteLine(("  ")+(pre("actions"))+("(")
			+(parser_class_name)
			+(" parser) {")
			);
		@out.WriteLine("    this.parser = parser;");
		@out.WriteLine("  }");
		@out.WriteLine();
		@out.WriteLine("  /** Method with the actual generated action code. */");
		@out.WriteLine(("  public final java_cup.runtime.Symbol ")+(pre("do_action"))+("(")
			);
		@out.WriteLine(("    int                        ")+(pre("act_num,")));
		@out.WriteLine(("    java_cup.runtime.lr_parser ")+(pre("parser,")));
		@out.WriteLine(("    java.util.Stack            ")+(pre("stack,")));
		@out.WriteLine(("    int                        ")+(pre("top)")));
		@out.WriteLine("    throws System.Exception");
		@out.WriteLine("    {");
		@out.WriteLine("      /* Symbol object for return from actions */");
		@out.WriteLine(("      java_cup.runtime.Symbol ")+(pre("result"))+(";")
			);
		@out.WriteLine();
		@out.WriteLine("      /* select the action based on the action number */");
		@out.WriteLine(("      switch (")+(pre("act_num"))+(")")
			);
		@out.WriteLine("        {");
		Enumeration enumeration = production.all();
		while (enumeration.hasMoreElements())
		{
			production production2 = (production)enumeration.nextElement();
			@out.WriteLine("          /*. . . . . . . . . . . . . . . . . . . .*/");
			@out.WriteLine(("          case ")+(production2.index())+(": // ")
				+(production2.to_simple_string())
				);
			@out.WriteLine("            {");
			@out.WriteLine(("              ")+(production2.lhs().the_symbol().stack_type())+(" RESULT = null;")
				);
			for (int i = 0; i < production2.rhs_length(); i++)
			{
				if (production2.rhs(i) is symbol_part)
				{
					symbol symbol2 = ((symbol_part)production2.rhs(i)).the_symbol();
					if (symbol2 is non_terminal && ((non_terminal)symbol2).is_embedded_action)
					{
						int i2 = production2.rhs_length() - i - 1;
						@out.WriteLine(("              // propagate RESULT from ")+(symbol2.name()));
						@out.WriteLine(("              if ( ((java_cup.runtime.Symbol) ")+(pre("stack"))+(".elementAt(")
							+(pre("top"))
							+("-")
							+(i2)
							+(")).value != null )")
							);
						@out.WriteLine(("                RESULT = (")+(production2.lhs().the_symbol().stack_type())+(") ")
							+("((java_cup.runtime.Symbol) ")
							+(pre("stack"))
							+(".elementAt(")
							+(pre("top"))
							+("-")
							+(i2)
							+(")).value;")
							);
					}
				}
			}
			if (production2.action() != null && production2.action().code_string() != null && !production2.action().equals(""))
			{
				@out.WriteLine(production2.action().code_string());
			}
			if (lr_values())
			{
				int i3 = 0;
				string text = ("((java_cup.runtime.Symbol)")+(pre("stack"))+(".elementAt(")
					+(pre("top"))
					+("-")
					+(i3)
					+(")).right")
					.ToString();
				string str;
				if (production2.rhs_length() == 0)
				{
					str = text;
				}
				else
				{
					int i = production2.rhs_length() - 1;
					str = ("((java_cup.runtime.Symbol)")+(pre("stack"))+(".elementAt(")
						+(pre("top"))
						+("-")
						+(i)
						+(")).left")
						.ToString();
				}
				@out.WriteLine(("              ")+(pre("result"))+(" = new java_cup.runtime.Symbol(")
					+(production2.lhs().the_symbol().index())
					+("/*")
					+(production2.lhs().the_symbol().name())
					+("*/")
					+(", ")
					+(str)
					+(", ")
					+(text)
					+(", RESULT);")
					);
			}
			else
			{
				@out.WriteLine(("              ")+(pre("result"))+(" = new java_cup.runtime.Symbol(")
					+(production2.lhs().the_symbol().index())
					+("/*")
					+(production2.lhs().the_symbol().name())
					+("*/")
					+(", RESULT);")
					);
			}
			@out.WriteLine("            }");
			if (production2 == start_prod)
			{
				@out.WriteLine("          /* ACCEPT */");
				@out.WriteLine(("          ")+(pre("parser"))+(".done_parsing();")
					);
			}
			@out.WriteLine(("          return ")+(pre("result"))+(";")
				);
			@out.WriteLine();
		}
		@out.WriteLine("          /* . . . . . .*/");
		@out.WriteLine("          default:");
		@out.WriteLine("            throw new Exception(");
		@out.WriteLine("               \"Invalid action number found in internal parse table\");");
		@out.WriteLine();
		@out.WriteLine("        }");
		@out.WriteLine("    }");
		@out.WriteLine("}");
		@out.WriteLine();
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
		@out.WriteLine();
		@out.WriteLine("//----------------------------------------------------");
		@out.WriteLine("// The following code was generated by CUP v0.10k");
		@out.WriteLine(("// ")+(new Date()));
		@out.WriteLine("//----------------------------------------------------");
		@out.WriteLine();
		emit_package(@out);
		@out.WriteLine(("/** CUP generated ")+(str)+(" containing symbol constants. */")
			);
		@out.WriteLine(("public ")+(str)+(" ")
			+(symbol_const_class_name)
			+(" {")
			);
		@out.WriteLine("  /* terminals */");
		Enumeration enumeration = terminal.all();
		while (enumeration.hasMoreElements())
		{
			terminal terminal2 = (terminal)enumeration.nextElement();
			@out.WriteLine(("  public static final int ")+(terminal2.name())+(" = ")
				+(terminal2.index())
				+(";")
				);
		}
		if (emit_non_terms)
		{
			@out.WriteLine();
			@out.WriteLine("  /* non terminals */");
			enumeration = non_terminal.all();
			while (enumeration.hasMoreElements())
			{
				non_terminal non_terminal2 = (non_terminal)enumeration.nextElement();
				@out.WriteLine(("  static final int ")+(non_terminal2.name())+(" = ")
					+(non_terminal2.index())
					+(";")
					);
			}
		}
		@out.WriteLine("}");
		@out.WriteLine();
		symbols_time = java.lang.System.currentTimeMillis() - num;
	}

	
	
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
		@out.WriteLine();
		@out.WriteLine("//----------------------------------------------------");
		@out.WriteLine("// The following code was generated by CUP v0.10k");
		@out.WriteLine(("// ")+(new Date()));
		@out.WriteLine("//----------------------------------------------------");
		@out.WriteLine();
		emit_package(@out);
		for (int i = 0; i < import_list.size(); i++)
		{
			@out.WriteLine(("import ")+(import_list.elementAt(i))+(";")
				);
		}
		@out.WriteLine();
		@out.WriteLine("/** CUP v0.10k generated parser.");
		@out.WriteLine(("  * @version ")+(new Date()));
		@out.WriteLine("  */");
		@out.WriteLine(("public class ")+(parser_class_name)+(" extends java_cup.runtime.lr_parser {")
			);
		@out.WriteLine();
		@out.WriteLine("  /** Default constructor. */");
		@out.WriteLine(("  public ")+(parser_class_name)+("() {super();}")
			);
		if (!suppress_scanner)
		{
			@out.WriteLine();
			@out.WriteLine("  /** Constructor which sets the default scanner. */");
			@out.WriteLine(("  public ")+(parser_class_name)+("(java_cup.runtime.Scanner s) {super(s);}")
				);
		}
		emit_production_table(@out);
		do_action_table(@out, action_table, compact_reduces);
		do_reduce_table(@out, reduce_table);
		@out.WriteLine("  /** Instance of action encapsulation class. */");
		@out.WriteLine(("  protected ")+(pre("actions"))+(" action_obj;")
			);
		@out.WriteLine();
		@out.WriteLine("  /** Action encapsulation object initializer. */");
		@out.WriteLine("  protected void init_actions()");
		@out.WriteLine("    {");
		@out.WriteLine(("      action_obj = new ")+(pre("actions"))+("(this);")
			);
		@out.WriteLine("    }");
		@out.WriteLine();
		@out.WriteLine("  /** Invoke a user supplied parse action. */");
		@out.WriteLine("  public java_cup.runtime.Symbol do_action(");
		@out.WriteLine("    int                        act_num,");
		@out.WriteLine("    java_cup.runtime.lr_parser parser,");
		@out.WriteLine("    java.util.Stack            stack,");
		@out.WriteLine("    int                        top)");
		@out.WriteLine("    throws System.Exception");
		@out.WriteLine("  {");
		@out.WriteLine("    /* call code in generated class */");
		@out.WriteLine(("    return action_obj.")+(pre("do_action("))+("act_num, parser, stack, top);")
			);
		@out.WriteLine("  }");
		@out.WriteLine("");
		@out.WriteLine("  /** Indicates start state. */");
		@out.WriteLine(("  public int start_state() {return ")+(start_st)+(";}")
			);
		@out.WriteLine("  /** Indicates start production. */");
		@out.WriteLine(("  public int start_production() {return ")+(start_production.index())+(";}")
			);
		@out.WriteLine();
		@out.WriteLine("  /** <code>EOF</code> Symbol index. */");
		@out.WriteLine(("  public int EOF_sym() {return ")+(terminal.___003C_003EEOF.index())+(";}")
			);
		@out.WriteLine();
		@out.WriteLine("  /** <code>error</code> Symbol index. */");
		@out.WriteLine(("  public int error_sym() {return ")+(terminal.___003C_003Eerror.index())+(";}")
			);
		@out.WriteLine();
		if (init_code != null)
		{
			@out.WriteLine();
			@out.WriteLine("  /** User initialization code. */");
			@out.WriteLine("  public void user_init() throws System.Exception");
			@out.WriteLine("    {");
			@out.WriteLine(init_code);
			@out.WriteLine("    }");
		}
		if (scan_code != null)
		{
			@out.WriteLine();
			@out.WriteLine("  /** Scan to get the next Symbol. */");
			@out.WriteLine("  public java_cup.runtime.Symbol scan()");
			@out.WriteLine("    throws System.Exception");
			@out.WriteLine("    {");
			@out.WriteLine(scan_code);
			@out.WriteLine("    }");
		}
		if (parser_code != null)
		{
			@out.WriteLine();
			@out.WriteLine(parser_code);
		}
		@out.WriteLine("}");
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
