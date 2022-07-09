using System;


using IKVM.Runtime;
using java.io;
using java.lang;


namespace java_cup;

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

	protected internal static PrintWriter parser_class_file;

	protected internal static PrintWriter symbol_class_file;

	protected internal static lalr_state start_state;

	protected internal static parse_action_table action_table;

	protected internal static parse_reduce_table reduce_table;

	
	[LineNumberTable(new byte[]
	{
		160,
		159,
		195,
		169,
		175,
		159,
		7,
		170,
		141,
		175,
		159,
		7,
		170,
		141,
		175,
		159,
		7,
		170,
		141,
		143,
		139,
		178,
		159,
		7,
		202,
		184,
		5,
		97,
		106,
		133,
		122,
		122,
		122,
		122,
		122,
		122,
		122,
		111,
		119,
		122,
		154,
		154,
		154,
		154,
		111,
		111,
		171,
		181,
		189,
		2,
		97,
		127,
		12,
		194,
		byte.MaxValue,
		12,
		159,
		172,
		233,
		160,
		87
	})]
	protected internal static void parse_args(string[] argv)
	{
		int num = argv.Length;
		for (int i = 0; i < num; i++)
		{
			if (java.lang.String.instancehelper_equals(argv[i], "-package"))
			{
				i++;
				if (i >= num || java.lang.String.instancehelper_startsWith(argv[i], "-") || java.lang.String.instancehelper_endsWith(argv[i], ".cup"))
				{
					usage("-package must have a name argument");
				}
				emit.package_name = argv[i];
			}
			else if (java.lang.String.instancehelper_equals(argv[i], "-parser"))
			{
				i++;
				if (i >= num || java.lang.String.instancehelper_startsWith(argv[i], "-") || java.lang.String.instancehelper_endsWith(argv[i], ".cup"))
				{
					usage("-parser must have a name argument");
				}
				emit.parser_class_name = argv[i];
			}
			else if (java.lang.String.instancehelper_equals(argv[i], "-symbols"))
			{
				i++;
				if (i >= num || java.lang.String.instancehelper_startsWith(argv[i], "-") || java.lang.String.instancehelper_endsWith(argv[i], ".cup"))
				{
					usage("-symbols must have a name argument");
				}
				emit.symbol_const_class_name = argv[i];
			}
			else if (java.lang.String.instancehelper_equals(argv[i], "-nonterms"))
			{
				include_non_terms = true;
			}
			else if (java.lang.String.instancehelper_equals(argv[i], "-expect"))
			{
				i++;
				if (i >= num || java.lang.String.instancehelper_startsWith(argv[i], "-") || java.lang.String.instancehelper_endsWith(argv[i], ".cup"))
				{
					usage("-expect must have a name argument");
				}
				try
				{
					expect_conflicts = Integer.parseInt(argv[i]);
				}
				catch (NumberFormatException)
				{
					goto IL_0161;
				}
			}
			else if (java.lang.String.instancehelper_equals(argv[i], "-compact_red"))
			{
				opt_compact_red = true;
			}
			else if (java.lang.String.instancehelper_equals(argv[i], "-nosummary"))
			{
				no_summary = true;
			}
			else if (java.lang.String.instancehelper_equals(argv[i], "-nowarn"))
			{
				emit.nowarn = true;
			}
			else if (java.lang.String.instancehelper_equals(argv[i], "-dump_states"))
			{
				opt_dump_states = true;
			}
			else if (java.lang.String.instancehelper_equals(argv[i], "-dump_tables"))
			{
				opt_dump_tables = true;
			}
			else if (java.lang.String.instancehelper_equals(argv[i], "-progress"))
			{
				print_progress = true;
			}
			else if (java.lang.String.instancehelper_equals(argv[i], "-dump_grammar"))
			{
				opt_dump_grammar = true;
			}
			else if (java.lang.String.instancehelper_equals(argv[i], "-dump"))
			{
				opt_dump_states = (opt_dump_tables = (opt_dump_grammar = true));
			}
			else if (java.lang.String.instancehelper_equals(argv[i], "-time"))
			{
				opt_show_timing = true;
			}
			else if (java.lang.String.instancehelper_equals(argv[i], "-debug"))
			{
				opt_do_debug = true;
			}
			else if (java.lang.String.instancehelper_equals(argv[i], "-nopositions"))
			{
				lr_values = false;
			}
			else if (java.lang.String.instancehelper_equals(argv[i], "-interface"))
			{
				sym_interface = true;
			}
			else if (java.lang.String.instancehelper_equals(argv[i], "-noscanner"))
			{
				suppress_scanner = true;
			}
			else if (java.lang.String.instancehelper_equals(argv[i], "-version"))
			{
				java.lang.System.@out.println("CUP v0.10k");
				java.lang.System.exit(1);
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
				usage(new StringBuilder().append("Unrecognized option \"").append(argv[i]).append("\"")
					.toString());
			}
			continue;
			IL_0161:
			
			usage("-expect must be followed by a decimal integer");
			continue;
			IL_032f:
			
			usage(new StringBuilder().append("Unable to open \"").append(argv[i]).append("\" for input")
				.toString());
		}
	}

	
	[Throws(new string[] { "System.Exception" })]
	[LineNumberTable(new byte[]
	{
		161, 67, 134, 103, 137, 254, 71, 226, 58, 193,
		106, 135
	})]
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
				parser2.parse();
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

	
	[LineNumberTable(new byte[]
	{
		161, 93, 145, 172, 170, 170, 168, 108, 135, 159,
		20, 241, 70, 145, 172, 168, 108, 135, 159, 20,
		241, 69
	})]
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
					java.lang.System.err.println(new StringBuilder().append("Warning: Terminal \"").append(terminal2.name()).append("\" was declared but never used")
						.toString());
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
					java.lang.System.err.println(new StringBuilder().append("Warning: Non terminal \"").append(non_terminal2.name()).append("\" was declared but never used")
						.toString());
					lexer.warning_count++;
				}
			}
		}
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	[LineNumberTable(new byte[]
	{
		161, 165, 110, 111, 133, 170, 110, 111, 133, 170,
		110, 111, 143, 170, 110, 111, 106, 106, 142, 108,
		144, 130, 170, 110, 111, 138, 170, 140, 143, 172
	})]
	protected internal static void build_parser()
	{
		if (opt_do_debug || print_progress)
		{
			java.lang.System.err.println("  Computing non-terminal nullability...");
		}
		non_terminal.compute_nullability();
		nullability_end = java.lang.System.currentTimeMillis();
		if (opt_do_debug || print_progress)
		{
			java.lang.System.err.println("  Computing first sets...");
		}
		non_terminal.compute_first_sets();
		first_end = java.lang.System.currentTimeMillis();
		if (opt_do_debug || print_progress)
		{
			java.lang.System.err.println("  Building state machine...");
		}
		start_state = lalr_state.build_machine(emit.start_production);
		machine_end = java.lang.System.currentTimeMillis();
		if (opt_do_debug || print_progress)
		{
			java.lang.System.err.println("  Filling in tables...");
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
			java.lang.System.err.println("  Checking for non-reduced productions...");
		}
		action_table.check_reductions();
		reduce_check_end = java.lang.System.currentTimeMillis();
		if (emit.num_conflicts > expect_conflicts)
		{
			java.lang.System.err.println("*** More conflicts encountered than expected -- parser generation aborted");
			lexer.error_count++;
		}
	}

	
	[LineNumberTable(new byte[]
	{
		161,
		22,
		127,
		0,
		135,
		byte.MaxValue,
		16,
		69,
		226,
		61,
		97,
		127,
		15,
		198,
		127,
		0,
		135,
		byte.MaxValue,
		16,
		69,
		226,
		61,
		97,
		127,
		15,
		134
	})]
	protected internal static void open_files()
	{
		string text = new StringBuilder().append(emit.parser_class_name).append(".java").toString();
		File file = new File(text);
		try
		{
			parser_class_file = new PrintWriter(new BufferedOutputStream(new FileOutputStream(file), 4096));
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
		
		java.lang.System.err.println(new StringBuilder().append("Can't open \"").append(text).append("\" for output")
			.toString());
		java.lang.System.exit(3);
		goto IL_008c;
		IL_008c:
		text = new StringBuilder().append(emit.symbol_const_class_name).append(".java").toString();
		file = new File(text);
		try
		{
			symbol_class_file = new PrintWriter(new BufferedOutputStream(new FileOutputStream(file), 4096));
			return;
		}
		catch (System.Exception x2)
		{
			if (ByteCodeHelper.MapException<System.Exception>(x2, ByteCodeHelper.MapFlags.Unused) == null)
			{
				throw;
			}
		}
		
		java.lang.System.err.println(new StringBuilder().append("Can't open \"").append(text).append("\" for output")
			.toString());
		java.lang.System.exit(4);
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	
	protected internal static void emit_parser()
	{
		emit.symbols(symbol_class_file, include_non_terms, sym_interface);
		emit.parser(parser_class_file, action_table, reduce_table, start_state.index(), emit.start_production, opt_compact_red, suppress_scanner);
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
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
		java.lang.System.err.println("===== Terminals =====");
		int num = 0;
		int num2 = 0;
		while (num < terminal.number())
		{
			java.lang.System.err.print(new StringBuilder().append("[").append(num).append("]")
				.append(terminal.find(num).name())
				.append(" ")
				.toString());
			int num3 = num2 + 1;
			if (5 == -1 || num3 % 5 == 0)
			{
				java.lang.System.err.println();
			}
			num++;
			num2++;
		}
		java.lang.System.err.println();
		java.lang.System.err.println();
		java.lang.System.err.println("===== Non terminals =====");
		num = 0;
		num2 = 0;
		while (num < non_terminal.number())
		{
			java.lang.System.err.print(new StringBuilder().append("[").append(num).append("]")
				.append(non_terminal.find(num).name())
				.append(" ")
				.toString());
			int num4 = num2 + 1;
			if (5 == -1 || num4 % 5 == 0)
			{
				java.lang.System.err.println();
			}
			num++;
			num2++;
		}
		java.lang.System.err.println();
		java.lang.System.err.println();
		java.lang.System.err.println("===== Productions =====");
		for (num = 0; num < production.number(); num++)
		{
			production production2 = production.find(num);
			java.lang.System.err.print(new StringBuilder().append("[").append(num).append("] ")
				.append(production2.lhs().the_symbol().name())
				.append(" ::= ")
				.toString());
			for (int i = 0; i < production2.rhs_length(); i++)
			{
				if (production2.rhs(i).is_action())
				{
					java.lang.System.err.print("{action} ");
				}
				else
				{
					java.lang.System.err.print(new StringBuilder().append(((symbol_part)production2.rhs(i)).the_symbol().name()).append(" ").toString());
				}
			}
			java.lang.System.err.println();
		}
		java.lang.System.err.println();
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
		java.lang.System.err.println("===== Viable Prefix Recognizer =====");
		for (int i = 0; i < lalr_state.number(); i++)
		{
			if (array[i] == start_state)
			{
				java.lang.System.err.print("START ");
			}
			java.lang.System.err.println(array[i]);
			java.lang.System.err.println("-------------------");
		}
	}

	
	
	public static void dump_tables()
	{
		java.lang.System.err.println(action_table);
		java.lang.System.err.println(reduce_table);
	}

	
	[Throws(new string[] { "java.io.IOException" })]
	
	protected internal static void close_files()
	{
		if (input_file != null)
		{
			input_file.close();
		}
		if (parser_class_file != null)
		{
			parser_class_file.close();
		}
		if (symbol_class_file != null)
		{
			symbol_class_file.close();
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
			java.lang.System.err.println("------- CUP v0.10k Parser Generation Summary -------");
			java.lang.System.err.println(new StringBuilder().append("  ").append(lexer.error_count).append(" error")
				.append(plural(lexer.error_count))
				.append(" and ")
				.append(lexer.warning_count)
				.append(" warning")
				.append(plural(lexer.warning_count))
				.toString());
			java.lang.System.err.print(new StringBuilder().append("  ").append(terminal.number()).append(" terminal")
				.append(plural(terminal.number()))
				.append(", ")
				.toString());
			java.lang.System.err.print(new StringBuilder().append(non_terminal.number()).append(" non-terminal").append(plural(non_terminal.number()))
				.append(", and ")
				.toString());
			java.lang.System.err.println(new StringBuilder().append(production.number()).append(" production").append(plural(production.number()))
				.append(" declared, ")
				.toString());
			java.lang.System.err.println(new StringBuilder().append("  producing ").append(lalr_state.number()).append(" unique parse states.")
				.toString());
			java.lang.System.err.println(new StringBuilder().append("  ").append(emit.unused_term).append(" terminal")
				.append(plural(emit.unused_term))
				.append(" declared but not used.")
				.toString());
			java.lang.System.err.println(new StringBuilder().append("  ").append(emit.unused_non_term).append(" non-terminal")
				.append(plural(emit.unused_term))
				.append(" declared but not used.")
				.toString());
			java.lang.System.err.println(new StringBuilder().append("  ").append(emit.not_reduced).append(" production")
				.append(plural(emit.not_reduced))
				.append(" never reduced.")
				.toString());
			java.lang.System.err.println(new StringBuilder().append("  ").append(emit.num_conflicts).append(" conflict")
				.append(plural(emit.num_conflicts))
				.append(" detected")
				.append(" (")
				.append(expect_conflicts)
				.append(" expected).")
				.toString());
			if (output_produced)
			{
				java.lang.System.err.println(new StringBuilder().append("  Code written to \"").append(emit.parser_class_name).append(".java\", and \"")
					.append(emit.symbol_const_class_name)
					.append(".java\".")
					.toString());
			}
			else
			{
				java.lang.System.err.println("  No code produced.");
			}
			if (opt_show_timing)
			{
				show_times();
			}
			java.lang.System.err.println("---------------------------------------------------- (v0.10k)");
		}
	}

	
	
	protected internal static void usage(string message)
	{
		java.lang.System.err.println();
		java.lang.System.err.println(message);
		java.lang.System.err.println();
		java.lang.System.err.println("Usage: java_cup [options] [filename]\n  and expects a specification file on standard input if no filename is given.\n  Legal options include:\n    -package name  specify package generated classes go in [default none]\n    -parser name   specify parser class name [default \"parser\"]\n    -symbols name  specify name for symbol constant class [default \"sym\"]\n    -interface     put symbols in an interface, rather than a class\n    -nonterms      put non terminals in symbol constant class\n    -expect #      number of conflicts expected/allowed [default 0]\n    -compact_red   compact tables by defaulting to most frequent reduce\n    -nowarn        don't warn about useless productions, etc.\n    -nosummary     don't print the usual summary of parse states, etc.\n    -nopositions   don't propagate the left and right token position values\n    -noscanner     don't refer to java_cup.runtime.Scanner\n    -progress      print messages to indicate progress of the system\n    -time          print time usage summary\n    -dump_grammar  produce a human readable dump of the symbols and grammar\n    -dump_states   produce a dump of parse state machine\n    -dump_tables   produce a dump of the parse tables\n    -dump          produce a dump of all of the above\n    -version       print the version information for CUP and exit\n");
		java.lang.System.exit(1);
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
		java.lang.System.err.println(". . . . . . . . . . . . . . . . . . . . . . . . . ");
		java.lang.System.err.println("  Timing Summary");
		java.lang.System.err.println(new StringBuilder().append("    Total time       ").append(timestr(final_time - start_time, total_time)).toString());
		java.lang.System.err.println(new StringBuilder().append("      Startup        ").append(timestr(prelim_end - start_time, total_time)).toString());
		java.lang.System.err.println(new StringBuilder().append("      Parse          ").append(timestr(parse_end - prelim_end, total_time)).toString());
		if (check_end != 0)
		{
			java.lang.System.err.println(new StringBuilder().append("      Checking       ").append(timestr(check_end - parse_end, total_time)).toString());
		}
		if (check_end != 0 && build_end != 0)
		{
			java.lang.System.err.println(new StringBuilder().append("      Parser Build   ").append(timestr(build_end - check_end, total_time)).toString());
		}
		if (nullability_end != 0 && check_end != 0)
		{
			java.lang.System.err.println(new StringBuilder().append("        Nullability  ").append(timestr(nullability_end - check_end, total_time)).toString());
		}
		if (first_end != 0 && nullability_end != 0)
		{
			java.lang.System.err.println(new StringBuilder().append("        First sets   ").append(timestr(first_end - nullability_end, total_time)).toString());
		}
		if (machine_end != 0 && first_end != 0)
		{
			java.lang.System.err.println(new StringBuilder().append("        State build  ").append(timestr(machine_end - first_end, total_time)).toString());
		}
		if (table_end != 0 && machine_end != 0)
		{
			java.lang.System.err.println(new StringBuilder().append("        Table build  ").append(timestr(table_end - machine_end, total_time)).toString());
		}
		if (reduce_check_end != 0 && table_end != 0)
		{
			java.lang.System.err.println(new StringBuilder().append("        Checking     ").append(timestr(reduce_check_end - table_end, total_time)).toString());
		}
		if (emit_end != 0 && build_end != 0)
		{
			java.lang.System.err.println(new StringBuilder().append("      Code Output    ").append(timestr(emit_end - build_end, total_time)).toString());
		}
		if (emit.symbols_time != 0)
		{
			java.lang.System.err.println(new StringBuilder().append("        Symbols      ").append(timestr(emit.symbols_time, total_time)).toString());
		}
		if (emit.parser_time != 0)
		{
			java.lang.System.err.println(new StringBuilder().append("        Parser class ").append(timestr(emit.parser_time, total_time)).toString());
		}
		if (emit.action_code_time != 0)
		{
			java.lang.System.err.println(new StringBuilder().append("          Actions    ").append(timestr(emit.action_code_time, total_time)).toString());
		}
		if (emit.production_table_time != 0)
		{
			java.lang.System.err.println(new StringBuilder().append("          Prod table ").append(timestr(emit.production_table_time, total_time)).toString());
		}
		if (emit.action_table_time != 0)
		{
			java.lang.System.err.println(new StringBuilder().append("          Action tab ").append(timestr(emit.action_table_time, total_time)).toString());
		}
		if (emit.goto_table_time != 0)
		{
			java.lang.System.err.println(new StringBuilder().append("          Reduce tab ").append(timestr(emit.goto_table_time, total_time)).toString());
		}
		java.lang.System.err.println(new StringBuilder().append("      Dump Output    ").append(timestr(dump_end - emit_end, total_time)).toString());
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
		StringBuilder stringBuilder = new StringBuilder().append((num == 0) ? "" : "-").append(str).append(num5)
			.append(".");
		long num8 = 1000L;
		StringBuilder stringBuilder2 = stringBuilder.append(((num8 != -1) ? (num4 % num8) : 0) / 100L);
		long num9 = 100L;
		StringBuilder stringBuilder3 = stringBuilder2.append(((num9 != -1) ? (num4 % num9) : 0) / 10L);
		long num10 = 10L;
		StringBuilder stringBuilder4 = stringBuilder3.append((num10 != -1) ? (num4 % num10) : 0).append("sec").append(" (")
			.append(num7 / 10L)
			.append(".");
		long num11 = 10L;
		string result = stringBuilder4.append((num11 != -1) ? (num7 % num11) : 0).append("%)").toString();
		
		return result;
	}

	
	
	private Main()
	{
	}

	
	[Throws(new string[] { "java_cup.internal_error", "java.io.IOException", "System.Exception" })]
	[LineNumberTable(new byte[]
	{
		105, 130, 170, 198, 138, 150, 148, 170, 103, 111,
		133, 170, 170, 118, 133, 170, 118, 133, 170, 135,
		136, 118, 101, 101, 194, 170, 108, 108, 140, 170,
		118, 165, 205, 103, 105
	})]
	public static void main(string[] argv)
	{
		int output_produced = 0;
		start_time = java.lang.System.currentTimeMillis();
		parse_args(argv);
		emit.set_lr_values(lr_values);
		if (print_progress)
		{
			java.lang.System.err.println("Opening files...");
		}
		input_file = new BufferedInputStream(java.lang.System.@in);
		prelim_end = java.lang.System.currentTimeMillis();
		if (print_progress)
		{
			java.lang.System.err.println("Parsing specification from standard input...");
		}
		parse_grammar_spec();
		parse_end = java.lang.System.currentTimeMillis();
		if (lexer.error_count == 0)
		{
			if (print_progress)
			{
				java.lang.System.err.println("Checking specification...");
			}
			check_unused();
			check_end = java.lang.System.currentTimeMillis();
			if (print_progress)
			{
				java.lang.System.err.println("Building parse tables...");
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
					java.lang.System.err.println("Writing parser...");
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
			java.lang.System.err.println("Closing files...");
		}
		close_files();
		if (!no_summary)
		{
			emit_summary((byte)output_produced != 0);
		}
		if (lexer.error_count != 0)
		{
			java.lang.System.exit(100);
		}
	}
}
