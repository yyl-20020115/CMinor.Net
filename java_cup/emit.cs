using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using utils;

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

	public static Production start_production;

	public static Stack<string> import_list =new();

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
			;
		
		return result;
	}

	
	
	protected internal static void emit_package(TextWriter @out)
	{
		if (package_name != null)
		{
			@out.WriteLine(("package ")+(package_name)+(";")
				);
			@out.WriteLine();
		}
	}

	
	protected internal static void do_table_as_string(TextWriter @out, short[][] sa)
	{
		@out.WriteLine("new String[] {");
		@out.Write("    \"");
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
		@out.Write("\" }");
	}

	protected internal static int do_escaped(TextWriter @out, char c)
	{
		var stringBuilder = new StringBuilder();
		if (c <= 'ÿ')
		{
			stringBuilder.Append(IntUtils.ToOctalString(c));
			while (stringBuilder.Length < 3)
			{
				stringBuilder.Insert(0, '0');
			}
		}
		else
		{
			stringBuilder.Append(IntUtils.ToHexString(c));
			while (stringBuilder.Length < 4)
			{
				stringBuilder.Insert(0, '0');
			}
			stringBuilder.Insert(0, 'u');
		}
		stringBuilder.Insert(0, '\\');
		@out.Write(stringBuilder);
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

	
	
	protected internal static int do_newline(TextWriter @out, int nchar, int nbytes)
	{
		if (nbytes > 65500)
		{
			@out.WriteLine("\", ");
			@out.Write("    \"");
		}
		else
		{
			if (nchar <= 11)
			{
				return nchar + 1;
			}
			@out.WriteLine("\" +");
			@out.Write("    \"");
		}
		return 0;
	}

	
	protected internal static void emit_production_table(TextWriter @out)
	{
		long num = Stopwatch.GetTimestamp();
		Production[] array = new Production[Production.number()];
		foreach( var production2 in Production.all())
		{
			array[production2.index()] = production2;
		}
		int num2 = Production.number();
		int[] array2 = new int[2];
		int num3 = (array2[1] = 2);
		num3 = (array2[0] = num2);
		short[][] array3 = new short[array2[0]][];// (short[][])ByteCodeHelper.multianewarray(typeof(short[][]).TypeHandle, array2);
		for(int i = 0; i < array3.Length; i++)
        {
			array3[i] = new short[array2[1]];
        }
		for (int i = 0; i < Production.number(); i++)
		{
			var production2 = array[i];
			array3[i][0] = (short)production2.lhs().the_symbol().Index;
			array3[i][1] = (short)production2.rhs_length();
		}
		@out.WriteLine();
		@out.WriteLine("  /** Production table. */");
		@out.WriteLine("  protected static final short _production_table[][] = ");
		@out.Write("    unpackFromStrings(");
		do_table_as_string(@out, array3);
		@out.WriteLine(");");
		@out.WriteLine();
		@out.WriteLine("  /** Access to production table. */");
		@out.WriteLine("  public short[][] production_table() {return _production_table;}");
		production_table_time =  Stopwatch.GetTimestamp() - num;
	}

	
	
	protected internal static void do_action_table(TextWriter @out, ParseActionTable act_tab, bool compact_reduces)
	{
		long num = Stopwatch.GetTimestamp();
		short[][] array = new short[act_tab.num_states()][];
		for (int i = 0; i < act_tab.num_states(); i++)
		{
			ParseActionRow parse_action_row2 = act_tab.under_state[i];
			if (compact_reduces)
			{
				parse_action_row2.compute_default();
			}
			else
			{
				parse_action_row2.default_reduce = -1;
			}
			short[] array2 = new short[2 * ParseActionRow.Count];
			int num2 = 0;
			for (int j = 0; j < ParseActionRow.Count; j++)
			{
				ParseAction parse_action2 = parse_action_row2.under_term[j];
				if (parse_action2.Kind== 0)
				{
					continue;
				}
				if (parse_action2.Kind== 1)
				{
					int num3 = num2;
					num2++;
					array2[num3] = (short)j;
					int num4 = num2;
					num2++;
					array2[num4] = (short)(((ShiftAction)parse_action2).ShiftTo.Index() + 1);
				}
				else if (parse_action2.Kind== 2)
				{
					int num5 = ((ReduceAction)parse_action2).reduce_with().index();
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
				else if (parse_action2.Kind!= 3)
				{
					string msg = ("Unrecognized action code ")+(parse_action2.Kind)+(" found in parse table")
						;
					
					throw new InternalError(msg);
				}
			}
			array[i] = new short[num2 + 2];
			Array.Copy(array2, 0, array[i], 0, num2);
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
		@out.Write("    unpackFromStrings(");
		do_table_as_string(@out, array);
		@out.WriteLine(");");
		@out.WriteLine();
		@out.WriteLine("  /** Access to parse-action table. */");
		@out.WriteLine("  public short[][] action_table() {return _action_table;}");
		action_table_time = Stopwatch.GetTimestamp() - num;
	}

	
	protected internal static void do_reduce_table(TextWriter @out, ParseReduceTable red_tab)
	{
		long num = Stopwatch.GetTimestamp();
		short[][] array = new short[red_tab.num_states()][];
		for (int i = 0; i < red_tab.num_states(); i++)
		{
			_ = red_tab.under_state[i];
			short[] array2 = new short[2 * ParseReduceRow.Count];
			int num2 = 0;
			int num3 = 0;
			while (true)
			{
				int num4 = num3;
				_ = red_tab.under_state[i];
				if (num4 >= ParseReduceRow.Count)
				{
					break;
				}
				LalrState lalr_state2 = red_tab.under_state[i].under_non_term[num3];
				if (lalr_state2 != null)
				{
					int num5 = num2;
					num2++;
					array2[num5] = (short)num3;
					int num6 = num2;
					num2++;
					array2[num6] = (short)lalr_state2.Index();
				}
				num3++;
			}
			array[i] = new short[num2 + 2];
			Array.Copy(array2, 0, array[i], 0, num2);
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
		@out.Write("    unpackFromStrings(");
		do_table_as_string(@out, array);
		@out.WriteLine(");");
		@out.WriteLine();
		@out.WriteLine("  /** Access to <code>reduce_goto</code> table. */");
		@out.WriteLine("  public short[][] reduce_table() {return _reduce_table;}");
		@out.WriteLine();
		goto_table_time = Stopwatch.GetTimestamp() - num;
	}

	
	
	protected internal static void emit_action_code(TextWriter @out, Production start_prod)
	{
		long num = Stopwatch.GetTimestamp();
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
		foreach(var production2 in Production.all())	
		{
			@out.WriteLine("          /*. . . . . . . . . . . . . . . . . . . .*/");
			@out.WriteLine(("          case ")+(production2.index())+(": // ")
				+(production2.to_simple_string())
				);
			@out.WriteLine("            {");
			@out.WriteLine(("              ")+(production2.lhs().the_symbol().StackType)+(" RESULT = null;")
				);
			for (int i = 0; i < production2.rhs_length(); i++)
			{
				if (production2.rhs(i) is SymbolPart)
				{
					_Symbol symbol2 = ((SymbolPart)production2.rhs(i)).the_symbol();
					if (symbol2 is NonTerminal && ((NonTerminal)symbol2).is_embedded_action)
					{
						int i2 = production2.rhs_length() - i - 1;
						@out.WriteLine(("              // propagate RESULT from ")+(symbol2.Name));
						@out.WriteLine(("              if ( ((java_cup.runtime.Symbol) ")+(pre("stack"))+(".elementAt(")
							+(pre("top"))
							+("-")
							+(i2)
							+(")).value != null )")
							);
						@out.WriteLine(("                RESULT = (")+(production2.lhs().the_symbol().StackType)+(") ")
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
			if (production2.action() != null && production2.action().CodeString!= null && !production2.action().Equals(""))
			{
				@out.WriteLine(production2.action().CodeString);
			}
			if (lr_values())
			{
				int i3 = 0;
				string text = ("((java_cup.runtime.Symbol)")+(pre("stack"))+(".elementAt(")
					+(pre("top"))
					+("-")
					+(i3)
					+(")).right")
					;
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
						;
				}
				@out.WriteLine(("              ")+(pre("result"))+(" = new java_cup.runtime.Symbol(")
					+(production2.lhs().the_symbol().Index)
					+("/*")
					+(production2.lhs().the_symbol().Name)
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
					+(production2.lhs().the_symbol().Index)
					+("/*")
					+(production2.lhs().the_symbol().Name)
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
		action_code_time = Stopwatch.GetTimestamp() - num;
	}

	
	
	private emit()
	{
	}

	protected internal static void set_lr_values(bool b)
	{
		int num = ((_lr_values = b) ? 1 : 0);
	}

	
	public static void symbols(TextWriter @out, bool emit_non_terms, bool sym_interface)
	{
		string str = ((!sym_interface) ? "class" : "interface");
		long num = Stopwatch.GetTimestamp();
		@out.WriteLine();
		@out.WriteLine("//----------------------------------------------------");
		@out.WriteLine("// The following code was generated by CUP v0.10k");
		@out.WriteLine(("// ")+(new DateTime()));
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

		foreach(var terminal2 in Terminal.all())
		{
			@out.WriteLine(("  public static final int ")+(terminal2.Name)+(" = ")
				+(terminal2.Index)
				+(";")
				);
		}
		if (emit_non_terms)
		{
			@out.WriteLine();
			@out.WriteLine("  /* non terminals */");
			foreach(var non_terminal2 in NonTerminal.all())
			{
				@out.WriteLine(("  static final int ")+(non_terminal2.Name)+(" = ")
					+(non_terminal2.Index)
					+(";")
					);
			}
		}
		@out.WriteLine("}");
		@out.WriteLine();
		symbols_time = Stopwatch.GetTimestamp() - num;
	}

	
	
	public static void parser(TextWriter @out, ParseActionTable action_table, ParseReduceTable reduce_table, int start_st, Production start_prod, bool compact_reduces, bool suppress_scanner)
	{
		long num = Stopwatch.GetTimestamp();
		@out.WriteLine();
		@out.WriteLine("//----------------------------------------------------");
		@out.WriteLine("// The following code was generated by CUP v0.10k");
		@out.WriteLine(("// ")+(new DateTime()));
		@out.WriteLine("//----------------------------------------------------");
		@out.WriteLine();
		emit_package(@out);
		var il = import_list.ToArray();
		for (int i = 0; i < import_list.Count; i++)
		{
			@out.WriteLine(("import ")+(il[i])+(";")
				);
		}
		@out.WriteLine();
		@out.WriteLine("/** CUP v0.10k generated parser.");
		@out.WriteLine(("  * @version ")+(new DateTime()));
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
		@out.WriteLine(("  public int EOF_sym() {return ")+(Terminal.___003C_003EEOF.Index)+(";}")
			);
		@out.WriteLine();
		@out.WriteLine("  /** <code>error</code> Symbol index. */");
		@out.WriteLine(("  public int error_sym() {return ")+(Terminal.___003C_003Eerror.Index)+(";}")
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
		parser_time = Stopwatch.GetTimestamp() - num;
	}

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
		import_list = new ();
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
