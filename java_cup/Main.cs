using System;
using System.IO;
using IKVM.Runtime;
using java.io;



namespace JavaCUP;

public class Main
{
	protected internal static bool print_progress = true;

	protected internal static bool opt_dump_states = false;

	protected internal static bool opt_dump_tables = false;

	protected internal static bool opt_dump_grammar = false;

	protected internal static bool opt_show_timing = false;

	protected internal static bool opt_do_debug = false;

	protected internal static bool opt_compact_red = false;

	protected internal static bool include_non_terms = false;

	protected internal static bool no_summary = false;

	protected internal static int expect_conflicts = 0;

	protected internal static bool lr_values = true;

	protected internal static bool sym_interface = false;

	protected internal static bool suppress_scanner = false;

	protected internal static long start_time = 0L;

	protected internal static long prelim_end = 0L;

	protected internal static long parse_end = 0L;

	protected internal static long check_end = 0L;

	protected internal static long dump_end = 0L;

	protected internal static long build_end = 0L;

	protected internal static long nullability_end = 0L;

	protected internal static long first_end = 0L;

	protected internal static long machine_end = 0L;

	protected internal static long table_end = 0L;

	protected internal static long reduce_check_end = 0L;

	protected internal static long emit_end = 0L;

	protected internal static long final_time = 0L;

	protected internal static BufferedInputStream input_file;

	protected internal static TextWriter parser_class_file;

	protected internal static TextWriter symbol_class_file;

	protected internal static lalr_state start_state;

	protected internal static parse_action_table action_table;

	protected internal static parse_reduce_table reduce_table;

	
	protected internal static void parse_args(string[] argv)
	{
		int num = argv.Length;
		for (int i = 0; i < num; i++)
		{
			if (String.Equals(argv[i], "-package"))
			{
				i++;
				if (i >= num || java.lang.String.instancehelper_startsWith(argv[i], "-") || java.lang.String.instancehelper_endsWith(argv[i], ".cup"))
				{
					usage("-package must have a name argument");
				}
				emit.package_name = argv[i];
			}
			else if (String.Equals(argv[i], "-parser"))
			{
				i++;
				if (i >= num || java.lang.String.instancehelper_startsWith(argv[i], "-") || java.lang.String.instancehelper_endsWith(argv[i], ".cup"))
				{
					usage("-parser must have a name argument");
				}
				emit.parser_class_name = argv[i];
			}
			else if (String.Equals(argv[i], "-symbols"))
			{
				i++;
				if (i >= num || java.lang.String.instancehelper_startsWith(argv[i], "-") || java.lang.String.instancehelper_endsWith(argv[i], ".cup"))
				{
					usage("-symbols must have a name argument");
				}
				emit.symbol_const_class_name = argv[i];
			}
			else if (String.Equals(argv[i], "-nonterms"))
			{
				include_non_terms = true;
			}
			else if (String.Equals(argv[i], "-expect"))
			{
				i++;
				if (i >= num || java.lang.String.instancehelper_startsWith(argv[i], "-") || java.lang.String.instancehelper_endsWith(argv[i], ".cup"))
				{
					usage("-expect must have a name argument");
				}
				try
				{
					expect_conflicts = int.parseInt(argv[i]);
				}
				catch (NumberFormatException)
				{
					goto IL_0161;
				}
			}
			else if (String.Equals(argv[i], "-compact_red"))
			{
				opt_compact_red = true;
			}
			else if (String.Equals(argv[i], "-nosummary"))
			{
				no_summary = true;
			}
			else if (String.Equals(argv[i], "-nowarn"))
			{
				emit.nowarn = true;
			}
			else if (String.Equals(argv[i], "-dump_states"))
			{
				opt_dump_states = true;
			}
			else if (String.Equals(argv[i], "-dump_tables"))
			{
				opt_dump_tables = true;
			}
			else if (String.Equals(argv[i], "-progress"))
			{
				print_progress = true;
			}
			else if (String.Equals(argv[i], "-dump_grammar"))
			{
				opt_dump_grammar = true;
			}
			else if (String.Equals(argv[i], "-dump"))
			{
				opt_dump_states = (opt_dump_tables = (opt_dump_grammar = true));
			}
			else if (String.Equals(argv[i], "-time"))
			{
				opt_show_timing = true;
			}
			else if (String.Equals(argv[i], "-debug"))
			{
				opt_do_debug = true;
			}
			else if (String.Equals(argv[i], "-nopositions"))
			{
				lr_values = false;
			}
			else if (String.Equals(argv[i], "-interface"))
			{
				sym_interface = true;
			}
			else if (String.Equals(argv[i], "-noscanner"))
			{
				suppress_scanner = true;
			}
			else if (String.Equals(argv[i], "-version"))
			{
				Console.Out.WriteLine("CUP v0.10k");
				Environment.Exit(1);
			}
			else if (!java.lang.String.instancehelper_startsWith(argv[i], "-") && i == num - 1)
			{
				try
				{
					java.lang.System.setIn(new FileInputStream(argv[i]));
				}
				catch (FileNotFoundException)
				{
					goto IL_032f;
				}
			}
			else
			{
				usage(("Unrecognized option \"")+(argv[i])+("\"")
					);
			}
			continue;
			IL_0161:
			
			usage("-expect must be followed by a decimal integer");
			continue;
			IL_032f:
			
			usage(("Unable to open \"")+(argv[i])+("\" for input")
				);
		}
	}

	
	protected internal static void parse_grammar_spec()
	{
		parser parser2 = new parser();
		System.Exception ex2;
		try
		{
			if (opt_do_debug)
			{
				parser2.debug_parse();
			}
			else
			{
				parser2.Parse();
			}
			return;
		}
		catch (System.Exception x)
		{
			System.Exception ex = ByteCodeHelper.MapException<System.Exception>(x, ByteCodeHelper.MapFlags.None);
			if (ex == null)
			{
				throw;
			}
			ex2 = ex;
		}
		System.Exception ex3 = ex2;
		lexer.emit_error("Internal error: Unexpected exception");
		throw ex3;
	}

	
	protected internal static void check_unused()
	{
		Enumeration enumeration = terminal.all();
		while (enumeration.hasMoreElements())
		{
			terminal terminal2 = (terminal)enumeration.nextElement();
			if (terminal2 != terminal.___003C_003EEOF && terminal2 != terminal.___003C_003Eerror && terminal2.use_count() == 0)
			{
				emit.unused_term++;
				if (!emit.nowarn)
				{
					Console.System.Exception.WriteLine(("Warning: Terminal \"")+(terminal2.name())+("\" was declared but never used")
						);
					lexer.warning_count++;
				}
			}
		}
		enumeration = non_terminal.all();
		while (enumeration.hasMoreElements())
		{
			non_terminal non_terminal2 = (non_terminal)enumeration.nextElement();
			if (non_terminal2.use_count() == 0)
			{
				emit.unused_term++;
				if (!emit.nowarn)
				{
					Console.System.Exception.WriteLine(("Warning: Non terminal \"")+(non_terminal2.name())+("\" was declared but never used")
						);
					lexer.warning_count++;
				}
			}
		}
	}

	
	
	protected internal static void build_parser()
	{
		if (opt_do_debug || print_progress)
		{
			Console.System.Exception.WriteLine("  Computing non-terminal nullability...");
		}
		non_terminal.compute_nullability();
		nullability_end = java.lang.System.currentTimeMillis();
		if (opt_do_debug || print_progress)
		{
			Console.System.Exception.WriteLine("  Computing first sets...");
		}
		non_terminal.compute_first_sets();
		first_end = java.lang.System.currentTimeMillis();
		if (opt_do_debug || print_progress)
		{
			Console.System.Exception.WriteLine("  Building state machine...");
		}
		start_state = lalr_state.build_machine(emit.start_production);
		machine_end = java.lang.System.currentTimeMillis();
		if (opt_do_debug || print_progress)
		{
			Console.System.Exception.WriteLine("  Filling in tables...");
		}
		action_table = new parse_action_table();
		reduce_table = new parse_reduce_table();
		Enumeration enumeration = lalr_state.all();
		while (enumeration.hasMoreElements())
		{
			lalr_state lalr_state2 = (lalr_state)enumeration.nextElement();
			lalr_state2.build_table_entries(action_table, reduce_table);
		}
		table_end = java.lang.System.currentTimeMillis();
		if (opt_do_debug || print_progress)
		{
			Console.System.Exception.WriteLine("  Checking for non-reduced productions...");
		}
		action_table.check_reductions();
		reduce_check_end = java.lang.System.currentTimeMillis();
		if (emit.num_conflicts > expect_conflicts)
		{
			Console.System.Exception.WriteLine("*** More conflicts encountered than expected -- parser generation aborted");
			lexer.error_count++;
		}
	}

	
	protected internal static void open_files()
	{
		string text = (emit.parser_class_name)+(".java");
		File file = new File(text);
		try
		{
			parser_class_file = new TextWriter(new BufferedOutputStream(new FileOutputStream(file), 4096));
		}
		catch (System.Exception x)
		{
			if (ByteCodeHelper.MapException<System.Exception>(x, ByteCodeHelper.MapFlags.Unused) == null)
			{
				throw;
			}
			goto IL_0052;
		}
		goto IL_008c;
		IL_0052:
		
		Console.System.Exception.WriteLine(("Can't open \"")+(text)+("\" for output")
			);
		Environment.Exit(3);
		goto IL_008c;
		IL_008c:
		text = (emit.symbol_const_class_name)+(".java");
		file = new File(text);
		try
		{
			symbol_class_file = new TextWriter(new BufferedOutputStream(new FileOutputStream(file), 4096));
			return;
		}
		catch (System.Exception x2)
		{
			if (ByteCodeHelper.MapException<System.Exception>(x2, ByteCodeHelper.MapFlags.Unused) == null)
			{
				throw;
			}
		}
		
		Console.System.Exception.WriteLine(("Can't open \"")+(text)+("\" for output")
			);
		Environment.Exit(4);
	}

	
	
	
	protected internal static void emit_parser()
	{
		emit.symbols(symbol_class_file, include_non_terms, sym_interface);
		emit.parser(parser_class_file, action_table, reduce_table, start_state.index(), emit.start_production, opt_compact_red, suppress_scanner);
	}

	
	
	[LineNumberTable(new byte[]
	{
		162,
		156,
		111,
		143,
		127,
		41,
		250,
		61,
		237,
		69,
		106,
		138,
		111,
		143,
		127,
		41,
		250,
		61,
		237,
		69,
		106,
		170,
		111,
		141,
		103,
		127,
		46,
		107,
		110,
		145,
		byte.MaxValue,
		26,
		60,
		233,
		70,
		234,
		54,
		233,
		76,
		108
	})]
	public static void dump_grammar()
	{
		Console.System.Exception.WriteLine("===== Terminals =====");
		int num = 0;
		int num2 = 0;
		while (num < terminal.number())
		{
			Console.System.Exception.Write(("[")+(num)+("]")
				+(terminal.find(num).name())
				+(" ")
				);
			int num3 = num2 + 1;
			if (5 == -1 || num3 % 5 == 0)
			{
				Console.System.Exception.WriteLine();
			}
			num++;
			num2++;
		}
		Console.System.Exception.WriteLine();
		Console.System.Exception.WriteLine();
		Console.System.Exception.WriteLine("===== Non terminals =====");
		num = 0;
		num2 = 0;
		while (num < non_terminal.number())
		{
			Console.System.Exception.Write(("[")+(num)+("]")
				+(non_terminal.find(num).name())
				+(" ")
				);
			int num4 = num2 + 1;
			if (5 == -1 || num4 % 5 == 0)
			{
				Console.System.Exception.WriteLine();
			}
			num++;
			num2++;
		}
		Console.System.Exception.WriteLine();
		Console.System.Exception.WriteLine();
		Console.System.Exception.WriteLine("===== Productions =====");
		for (num = 0; num < production.number(); num++)
		{
			production production2 = production.find(num);
			Console.System.Exception.Write(("[")+(num)+("] ")
				+(production2.lhs().the_symbol().name())
				+(" ::= ")
				);
			for (int i = 0; i < production2.rhs_length(); i++)
			{
				if (production2.rhs(i).is_action())
				{
					Console.System.Exception.Write("{action} ");
				}
				else
				{
					Console.System.Exception.Write((((symbol_part)production2.rhs(i)).the_symbol().name())+(" "));
				}
			}
			Console.System.Exception.WriteLine();
		}
		Console.System.Exception.WriteLine();
	}

	
	[LineNumberTable(new byte[]
	{
		162, 198, 171, 142, 108, 105, 130, 111, 138, 121,
		109, 239, 60, 230, 70
	})]
	public static void dump_machine()
	{
		lalr_state[] array = new lalr_state[lalr_state.number()];
		Enumeration enumeration = lalr_state.all();
		while (enumeration.hasMoreElements())
		{
			lalr_state lalr_state2 = (lalr_state)enumeration.nextElement();
			array[lalr_state2.index()] = lalr_state2;
		}
		Console.System.Exception.WriteLine("===== Viable Prefix Recognizer =====");
		for (int i = 0; i < lalr_state.number(); i++)
		{
			if (array[i] == start_state)
			{
				Console.System.Exception.Write("START ");
			}
			Console.System.Exception.WriteLine(array[i]);
			Console.System.Exception.WriteLine("-------------------");
		}
	}

	
	
	public static void dump_tables()
	{
		Console.System.Exception.WriteLine(action_table);
		Console.System.Exception.WriteLine(reduce_table);
	}

	
	
	
	protected internal static void close_files()
	{
		if (input_file != null)
		{
			input_file.Close();
		}
		if (parser_class_file != null)
		{
			parser_class_file.Close();
		}
		if (symbol_class_file != null)
		{
			symbol_class_file.Close();
		}
	}

	
	[LineNumberTable(new byte[]
	{
		158,
		243,
		66,
		138,
		136,
		207,
		byte.MaxValue,
		79,
		69,
		159,
		44,
		159,
		34,
		159,
		34,
		223,
		19,
		159,
		44,
		223,
		44,
		223,
		44,
		byte.MaxValue,
		74,
		69,
		99,
		191,
		41,
		143,
		140,
		177
	})]
	protected internal static void emit_summary(bool output_produced)
	{
		final_time = java.lang.System.currentTimeMillis();
		if (!no_summary)
		{
			Console.System.Exception.WriteLine("------- CUP v0.10k Parser Generation Summary -------");
			Console.System.Exception.WriteLine(("  ")+(lexer.error_count)+(" error")
				+(plural(lexer.error_count))
				+(" and ")
				+(lexer.warning_count)
				+(" warning")
				+(plural(lexer.warning_count))
				);
			Console.System.Exception.Write(("  ")+(terminal.number())+(" terminal")
				+(plural(terminal.number()))
				+(", ")
				);
			Console.System.Exception.Write((non_terminal.number())+(" non-terminal")+(plural(non_terminal.number()))
				+(", and ")
				);
			Console.System.Exception.WriteLine((production.number())+(" production")+(plural(production.number()))
				+(" declared, ")
				);
			Console.System.Exception.WriteLine(("  producing ")+(lalr_state.number())+(" unique parse states.")
				);
			Console.System.Exception.WriteLine(("  ")+(emit.unused_term)+(" terminal")
				+(plural(emit.unused_term))
				+(" declared but not used.")
				);
			Console.System.Exception.WriteLine(("  ")+(emit.unused_non_term)+(" non-terminal")
				+(plural(emit.unused_term))
				+(" declared but not used.")
				);
			Console.System.Exception.WriteLine(("  ")+(emit.not_reduced)+(" production")
				+(plural(emit.not_reduced))
				+(" never reduced.")
				);
			Console.System.Exception.WriteLine(("  ")+(emit.num_conflicts)+(" conflict")
				+(plural(emit.num_conflicts))
				+(" detected")
				+(" (")
				+(expect_conflicts)
				+(" expected).")
				);
			if (output_produced)
			{
				Console.System.Exception.WriteLine(("  Code written to \"")+(emit.parser_class_name)+(".java\", and \"")
					+(emit.symbol_const_class_name)
					+(".java\".")
					);
			}
			else
			{
				Console.System.Exception.WriteLine("  No code produced.");
			}
			if (opt_show_timing)
			{
				show_times();
			}
			Console.System.Exception.WriteLine("---------------------------------------------------- (v0.10k)");
		}
	}

	
	
	protected internal static void usage(string message)
	{
		Console.System.Exception.WriteLine();
		Console.System.Exception.WriteLine(message);
		Console.System.Exception.WriteLine();
		Console.System.Exception.WriteLine("Usage: java_cup [options] [filename]\n  and expects a specification file on standard input if no filename is given.\n  Legal options include:\n    -package name  specify package generated classes go in [default none]\n    -parser name   specify parser class name [default \"parser\"]\n    -symbols name  specify name for symbol constant class [default \"sym\"]\n    -interface     put symbols in an interface, rather than a class\n    -nonterms      put non terminals in symbol constant class\n    -expect #      number of conflicts expected/allowed [default 0]\n    -compact_red   compact tables by defaulting to most frequent reduce\n    -nowarn        don't warn about useless productions, etc.\n    -nosummary     don't Write the usual summary of parse states, etc.\n    -nopositions   don't propagate the left and right token position values\n    -noscanner     don't refer to java_cup.runtime.Scanner\n    -progress      Write messages to indicate progress of the system\n    -time          Write time usage summary\n    -dump_grammar  produce a human readable dump of the symbols and grammar\n    -dump_states   produce a dump of parse state machine\n    -dump_tables   produce a dump of the parse tables\n    -dump          produce a dump of all of the above\n    -version       Write the version information for CUP and exit\n");
		Environment.Exit(1);
	}

	protected internal static string plural(int val)
	{
		if (val == 1)
		{
			return "";
		}
		return "s";
	}

	
	[LineNumberTable(new byte[]
	{
		162, 50, 140, 111, 111, 159, 21, 159, 21, 159,
		21, 105, 159, 21, 114, 159, 21, 114, 159, 21,
		114, 159, 21, 114, 159, 21, 114, 159, 21, 114,
		159, 21, 114, 159, 21, 105, 159, 15, 105, 159,
		15, 105, 159, 15, 105, 159, 15, 105, 159, 15,
		105, 191, 15, 159, 23
	})]
	protected internal static void show_times()
	{
		long total_time = final_time - start_time;
		Console.System.Exception.WriteLine(". . . . . . . . . . . . . . . . . . . . . . . . . ");
		Console.System.Exception.WriteLine("  Timing Summary");
		Console.System.Exception.WriteLine(("    Total time       ")+(timestr(final_time - start_time, total_time)));
		Console.System.Exception.WriteLine(("      Startup        ")+(timestr(prelim_end - start_time, total_time)));
		Console.System.Exception.WriteLine(("      Parse          ")+(timestr(parse_end - prelim_end, total_time)));
		if (check_end != 0)
		{
			Console.System.Exception.WriteLine(("      Checking       ")+(timestr(check_end - parse_end, total_time)));
		}
		if (check_end != 0 && build_end != 0)
		{
			Console.System.Exception.WriteLine(("      Parser Build   ")+(timestr(build_end - check_end, total_time)));
		}
		if (nullability_end != 0 && check_end != 0)
		{
			Console.System.Exception.WriteLine(("        Nullability  ")+(timestr(nullability_end - check_end, total_time)));
		}
		if (first_end != 0 && nullability_end != 0)
		{
			Console.System.Exception.WriteLine(("        First sets   ")+(timestr(first_end - nullability_end, total_time)));
		}
		if (machine_end != 0 && first_end != 0)
		{
			Console.System.Exception.WriteLine(("        State build  ")+(timestr(machine_end - first_end, total_time)));
		}
		if (table_end != 0 && machine_end != 0)
		{
			Console.System.Exception.WriteLine(("        Table build  ")+(timestr(table_end - machine_end, total_time)));
		}
		if (reduce_check_end != 0 && table_end != 0)
		{
			Console.System.Exception.WriteLine(("        Checking     ")+(timestr(reduce_check_end - table_end, total_time)));
		}
		if (emit_end != 0 && build_end != 0)
		{
			Console.System.Exception.WriteLine(("      Code Output    ")+(timestr(emit_end - build_end, total_time)));
		}
		if (emit.symbols_time != 0)
		{
			Console.System.Exception.WriteLine(("        Symbols      ")+(timestr(emit.symbols_time, total_time)));
		}
		if (emit.parser_time != 0)
		{
			Console.System.Exception.WriteLine(("        Parser class ")+(timestr(emit.parser_time, total_time)));
		}
		if (emit.action_code_time != 0)
		{
			Console.System.Exception.WriteLine(("          Actions    ")+(timestr(emit.action_code_time, total_time)));
		}
		if (emit.production_table_time != 0)
		{
			Console.System.Exception.WriteLine(("          Prod table ")+(timestr(emit.production_table_time, total_time)));
		}
		if (emit.action_table_time != 0)
		{
			Console.System.Exception.WriteLine(("          Action tab ")+(timestr(emit.action_table_time, total_time)));
		}
		if (emit.goto_table_time != 0)
		{
			Console.System.Exception.WriteLine(("          Reduce tab ")+(timestr(emit.goto_table_time, total_time)));
		}
		Console.System.Exception.WriteLine(("      Dump Output    ")+(timestr(dump_end - emit_end, total_time)));
	}

	
	[LineNumberTable(new byte[]
	{
		162, 119, 99, 227, 69, 102, 167, 116, 169, 102,
		104, 102, 104, 105, 136, 166, 181
	})]
	protected internal static string timestr(long time_val, long total_time)
	{
		_ = 0;
		_ = 0;
		int num = ((time_val < 0) ? 1 : 0);
		if (num != 0)
		{
			time_val = -time_val;
		}
		long num2 = time_val;
		long num3 = 1000L;
		long num4 = ((num3 != -1) ? (num2 % num3) : 0);
		long num5 = time_val / 1000L;
		string str = ((num5 < 10u) ? "   " : ((num5 < 100u) ? "  " : ((num5 >= 1000u) ? "" : " ")));
		long num6 = time_val * 1000u;
		long num7 = ((total_time != -1) ? (num6 / total_time) : (-num6));
		StringBuilder stringBuilder = ((num == 0) ? "" : "-")+(str)+(num5)
			+(".");
		long num8 = 1000L;
		StringBuilder stringBuilder2 = stringBuilder+(((num8 != -1) ? (num4 % num8) : 0) / 100L);
		long num9 = 100L;
		StringBuilder stringBuilder3 = stringBuilder2+(((num9 != -1) ? (num4 % num9) : 0) / 10L);
		long num10 = 10L;
		StringBuilder stringBuilder4 = stringBuilder3+((num10 != -1) ? (num4 % num10) : 0)+("sec")+(" (")
			+(num7 / 10L)
			+(".");
		long num11 = 10L;
		string result = stringBuilder4+((num11 != -1) ? (num7 % num11) : 0)+("%)");
		
		return result;
	}

	
	
	private Main()
	{
	}

	
	
	public static void main(string[] argv)
	{
		int output_produced = 0;
		start_time = java.lang.System.currentTimeMillis();
		parse_args(argv);
		emit.set_lr_values(lr_values);
		if (print_progress)
		{
			Console.System.Exception.WriteLine("Opening files...");
		}
		input_file = new BufferedInputStream(java.lang.System.@in);
		prelim_end = java.lang.System.currentTimeMillis();
		if (print_progress)
		{
			Console.System.Exception.WriteLine("Parsing specification from standard input...");
		}
		parse_grammar_spec();
		parse_end = java.lang.System.currentTimeMillis();
		if (lexer.error_count == 0)
		{
			if (print_progress)
			{
				Console.System.Exception.WriteLine("Checking specification...");
			}
			check_unused();
			check_end = java.lang.System.currentTimeMillis();
			if (print_progress)
			{
				Console.System.Exception.WriteLine("Building parse tables...");
			}
			build_parser();
			build_end = java.lang.System.currentTimeMillis();
			if (lexer.error_count != 0)
			{
				opt_dump_tables = false;
			}
			else
			{
				if (print_progress)
				{
					Console.System.Exception.WriteLine("Writing parser...");
				}
				open_files();
				emit_parser();
				output_produced = 1;
			}
		}
		emit_end = java.lang.System.currentTimeMillis();
		if (opt_dump_grammar)
		{
			dump_grammar();
		}
		if (opt_dump_states)
		{
			dump_machine();
		}
		if (opt_dump_tables)
		{
			dump_tables();
		}
		dump_end = java.lang.System.currentTimeMillis();
		if (print_progress)
		{
			Console.System.Exception.WriteLine("Closing files...");
		}
		close_files();
		if (!no_summary)
		{
			emit_summary((byte)output_produced != 0);
		}
		if (lexer.error_count != 0)
		{
			Environment.Exit(100);
		}
	}
}
