using System;
using System.Diagnostics;
using System.IO;

namespace JavaCUP;

public class MainProgram
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

	protected internal static TextReader input_file;

	protected internal static TextWriter parser_class_file;

	protected internal static TextWriter symbol_class_file;

	protected internal static LalrState start_state;

	protected internal static ParseActionTable action_table;

	protected internal static ParseReduceTable reduce_table;

	
	protected internal static void parse_args(string[] argv)
	{
		int num = argv.Length;
		for (int i = 0; i < num; i++)
		{
			if (String.Equals(argv[i], "-package"))
			{
				i++;
				if (i >= num || argv[i].StartsWith( "-") || argv[i].EndsWith(".cup"))
				{
					usage("-package must have a name argument");
				}
				emit.package_name = argv[i];
			}
			else if (String.Equals(argv[i], "-parser"))
			{
				i++;
				if (i >= num || (argv[i].StartsWith("-") || (argv[i].EndsWith(".cup"))))
				{
					usage("-parser must have a name argument");
				}
				emit.parser_class_name = argv[i];
			}
			else if (String.Equals(argv[i], "-symbols"))
			{
				i++;
				if (i >= num || (argv[i].StartsWith("-") || (argv[i].EndsWith(".cup"))))
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
				if (i >= num || (argv[i].StartsWith("-") || (argv[i].EndsWith(".cup"))))
				{
					usage("-expect must have a name argument");
				}
				if (!int.TryParse(argv[i], out expect_conflicts))
					goto IL_0161;
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
			else if (!(argv[i].StartsWith("-") && i == num - 1))
			{
				if(!File.Exists(argv[i]))
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
			ex2 = x;
		}
		System.Exception ex3 = ex2;
		Lexer.emit_error("Internal error: Unexpected exception");
		throw ex3;
	}

	
	protected internal static void check_unused()
	{
		foreach(var terminal2 in Terminal.all())
		{
			if (terminal2 != Terminal.___003C_003EEOF && terminal2 != Terminal.___003C_003Eerror && terminal2.UseCount== 0)
			{
				emit.unused_term++;
				if (!emit.nowarn)
				{
					Console.Error.WriteLine(("Warning: Terminal \"")+(terminal2.Name)+("\" was declared but never used")
						);
					Lexer.warning_count++;
				}
			}
		}
		foreach(var non_terminal2 in NonTerminal.all())
		{
			if (non_terminal2.UseCount== 0)
			{
				emit.unused_term++;
				if (!emit.nowarn)
				{
					Console.Error.WriteLine(("Warning: Non terminal \"")+(non_terminal2.Name)+("\" was declared but never used")
						);
					Lexer.warning_count++;
				}
			}
		}
	}

	
	
	protected internal static void build_parser()
	{
		if (opt_do_debug || print_progress)
		{
			Console.Error.WriteLine("  Computing non-terminal nullability...");
		}
		NonTerminal.compute_nullability();
		nullability_end = Stopwatch.GetTimestamp();
		if (opt_do_debug || print_progress)
		{
			Console.Error.WriteLine("  Computing first sets...");
		}
		NonTerminal.compute_first_sets();
		first_end = Stopwatch.GetTimestamp();
		if (opt_do_debug || print_progress)
		{
			Console.Error.WriteLine("  Building state machine...");
		}
		start_state = LalrState.build_machine(emit.start_production);
		machine_end = Stopwatch.GetTimestamp();
		if (opt_do_debug || print_progress)
		{
			Console.Error.WriteLine("  Filling in tables...");
		}
		action_table = new ParseActionTable();
		reduce_table = new ParseReduceTable();
		foreach(var lalr_state2 in LalrState.all())
		{
			lalr_state2.build_table_entries(action_table, reduce_table);
		}
		table_end = Stopwatch.GetTimestamp();
		if (opt_do_debug || print_progress)
		{
			Console.Error.WriteLine("  Checking for non-reduced productions...");
		}
		action_table.check_reductions();
		reduce_check_end = Stopwatch.GetTimestamp();
		if (emit.num_conflicts > expect_conflicts)
		{
			Console.Error.WriteLine("*** More conflicts encountered than expected -- parser generation aborted");
			Lexer.error_count++;
		}
	}

	
	protected internal static void open_files()
	{
		string text = (emit.parser_class_name)+(".java");
		FileInfo file = new FileInfo(text);
		try
		{
			parser_class_file = new StreamWriter(file.FullName);
		}
		catch
		{
			goto IL_0052;
		}
		goto IL_008c;
		IL_0052:
		
		Console.Error.WriteLine(("Can't open \"")+(text)+("\" for output")
			);
		Environment.Exit(3);
		goto IL_008c;
		IL_008c:
		text = (emit.symbol_const_class_name)+(".java");
		file = new FileInfo(text);
		try
		{
			symbol_class_file = new StreamWriter(file.FullName);
			return;
		}
		catch
		{
		}
		
		Console.Error.WriteLine(("Can't open \"")+(text)+("\" for output")
			);
		Environment.Exit(4);
	}

	
	
	
	protected internal static void emit_parser()
	{
		emit.symbols(symbol_class_file, include_non_terms, sym_interface);
		emit.parser(parser_class_file, action_table, reduce_table, start_state.Index(), emit.start_production, opt_compact_red, suppress_scanner);
	}

	
	public static void dump_grammar()
    {
		Console.Error.WriteLine("===== Terminals =====");
		int num = 0;
		int num2 = 0;
		while (num < Terminal.number())
		{
			Console.Error.Write(("[")+(num)+("]")
				+(Terminal.find(num).Name)
				+(" ")
				);
			int num3 = num2 + 1;
			if (5 == -1 || num3 % 5 == 0)
			{
				Console.Error.WriteLine();
			}
			num++;
			num2++;
		}
		Console.Error.WriteLine();
		Console.Error.WriteLine();
		Console.Error.WriteLine("===== Non terminals =====");
		num = 0;
		num2 = 0;
		while (num < NonTerminal.number())
		{
			Console.Error.Write(("[")+(num)+("]")
				+(NonTerminal.find(num).Name)
				+(" ")
				);
			int num4 = num2 + 1;
			if (5 == -1 || num4 % 5 == 0)
			{
				Console.Error.WriteLine();
			}
			num++;
			num2++;
		}
		Console.Error.WriteLine();
		Console.Error.WriteLine();
		Console.Error.WriteLine("===== Productions =====");
		for (num = 0; num < Production.number(); num++)
		{
			Production production2 = Production.find(num);
			Console.Error.Write(("[")+(num)+("] ")
				+(production2.lhs().the_symbol().Name)
				+(" ::= ")
				);
			for (int i = 0; i < production2.rhs_length(); i++)
			{
				if (production2.rhs(i).is_action())
				{
					Console.Error.Write("{action} ");
				}
				else
				{
					Console.Error.Write((((SymbolPart)production2.rhs(i)).the_symbol().Name)+(" "));
				}
			}
			Console.Error.WriteLine();
		}
		Console.Error.WriteLine();
	}

	
	public static void dump_machine()
	{
		LalrState[] array = new LalrState[LalrState.number()];
		foreach(var lalr_state2 in LalrState.all())
		{
			array[lalr_state2.Index()] = lalr_state2;
		}
		Console.Error.WriteLine("===== Viable Prefix Recognizer =====");
		for (int i = 0; i < LalrState.number(); i++)
		{
			if (array[i] == start_state)
			{
				Console.Error.Write("START ");
			}
			Console.Error.WriteLine(array[i]);
			Console.Error.WriteLine("-------------------");
		}
	}

	
	
	public static void dump_tables()
	{
		Console.Error.WriteLine(action_table);
		Console.Error.WriteLine(reduce_table);
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

	
	protected internal static void emit_summary(bool output_produced)
	{
		final_time = Stopwatch.GetTimestamp();
		if (!no_summary)
		{
			Console.Error.WriteLine("------- CUP v0.10k Parser Generation Summary -------");
			Console.Error.WriteLine(("  ")+(Lexer.error_count)+(" error")
				+(plural(Lexer.error_count))
				+(" and ")
				+(Lexer.warning_count)
				+(" warning")
				+(plural(Lexer.warning_count))
				);
			Console.Error.Write(("  ")+(Terminal.number())+(" terminal")
				+(plural(Terminal.number()))
				+(", ")
				);
			Console.Error.Write((NonTerminal.number())+(" non-terminal")+(plural(NonTerminal.number()))
				+(", and ")
				);
			Console.Error.WriteLine((Production.number())+(" production")+(plural(Production.number()))
				+(" declared, ")
				);
			Console.Error.WriteLine(("  producing ")+(LalrState.number())+(" unique parse states.")
				);
			Console.Error.WriteLine(("  ")+(emit.unused_term)+(" terminal")
				+(plural(emit.unused_term))
				+(" declared but not used.")
				);
			Console.Error.WriteLine(("  ")+(emit.unused_non_term)+(" non-terminal")
				+(plural(emit.unused_term))
				+(" declared but not used.")
				);
			Console.Error.WriteLine(("  ")+(emit.not_reduced)+(" production")
				+(plural(emit.not_reduced))
				+(" never reduced.")
				);
			Console.Error.WriteLine(("  ")+(emit.num_conflicts)+(" conflict")
				+(plural(emit.num_conflicts))
				+(" detected")
				+(" (")
				+(expect_conflicts)
				+(" expected).")
				);
			if (output_produced)
			{
				Console.Error.WriteLine(("  Code written to \"")+(emit.parser_class_name)+(".java\", and \"")
					+(emit.symbol_const_class_name)
					+(".java\".")
					);
			}
			else
			{
				Console.Error.WriteLine("  No code produced.");
			}
			if (opt_show_timing)
			{
				show_times();
			}
			Console.Error.WriteLine("---------------------------------------------------- (v0.10k)");
		}
	}

	
	
	protected internal static void usage(string message)
	{
		Console.Error.WriteLine();
		Console.Error.WriteLine(message);
		Console.Error.WriteLine();
		Console.Error.WriteLine("Usage: java_cup [options] [filename]\n  and expects a specification file on standard input if no filename is given.\n  Legal options include:\n    -package name  specify package generated classes go in [default none]\n    -parser name   specify parser class name [default \"parser\"]\n    -symbols name  specify name for symbol constant class [default \"sym\"]\n    -interface     put symbols in an interface, rather than a class\n    -nonterms      put non terminals in symbol constant class\n    -expect #      number of conflicts expected/allowed [default 0]\n    -compact_red   compact tables by defaulting to most frequent reduce\n    -nowarn        don't warn about useless productions, etc.\n    -nosummary     don't Write the usual summary of parse states, etc.\n    -nopositions   don't propagate the left and right token position values\n    -noscanner     don't refer to java_cup.runtime.Scanner\n    -progress      Write messages to indicate progress of the system\n    -time          Write time usage summary\n    -dump_grammar  produce a human readable dump of the symbols and grammar\n    -dump_states   produce a dump of parse state machine\n    -dump_tables   produce a dump of the parse tables\n    -dump          produce a dump of all of the above\n    -version       Write the version information for CUP and exit\n");
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

	
	protected internal static void show_times()
	{
		long total_time = final_time - start_time;
		Console.Error.WriteLine(". . . . . . . . . . . . . . . . . . . . . . . . . ");
		Console.Error.WriteLine("  Timing Summary");
		Console.Error.WriteLine(("    Total time       ")+(timestr(final_time - start_time, total_time)));
		Console.Error.WriteLine(("      Startup        ")+(timestr(prelim_end - start_time, total_time)));
		Console.Error.WriteLine(("      Parse          ")+(timestr(parse_end - prelim_end, total_time)));
		if (check_end != 0)
		{
			Console.Error.WriteLine(("      Checking       ")+(timestr(check_end - parse_end, total_time)));
		}
		if (check_end != 0 && build_end != 0)
		{
			Console.Error.WriteLine(("      Parser Build   ")+(timestr(build_end - check_end, total_time)));
		}
		if (nullability_end != 0 && check_end != 0)
		{
			Console.Error.WriteLine(("        Nullability  ")+(timestr(nullability_end - check_end, total_time)));
		}
		if (first_end != 0 && nullability_end != 0)
		{
			Console.Error.WriteLine(("        First sets   ")+(timestr(first_end - nullability_end, total_time)));
		}
		if (machine_end != 0 && first_end != 0)
		{
			Console.Error.WriteLine(("        State build  ")+(timestr(machine_end - first_end, total_time)));
		}
		if (table_end != 0 && machine_end != 0)
		{
			Console.Error.WriteLine(("        Table build  ")+(timestr(table_end - machine_end, total_time)));
		}
		if (reduce_check_end != 0 && table_end != 0)
		{
			Console.Error.WriteLine(("        Checking     ")+(timestr(reduce_check_end - table_end, total_time)));
		}
		if (emit_end != 0 && build_end != 0)
		{
			Console.Error.WriteLine(("      Code Output    ")+(timestr(emit_end - build_end, total_time)));
		}
		if (emit.symbols_time != 0)
		{
			Console.Error.WriteLine(("        Symbols      ")+(timestr(emit.symbols_time, total_time)));
		}
		if (emit.parser_time != 0)
		{
			Console.Error.WriteLine(("        Parser class ")+(timestr(emit.parser_time, total_time)));
		}
		if (emit.action_code_time != 0)
		{
			Console.Error.WriteLine(("          Actions    ")+(timestr(emit.action_code_time, total_time)));
		}
		if (emit.production_table_time != 0)
		{
			Console.Error.WriteLine(("          Prod table ")+(timestr(emit.production_table_time, total_time)));
		}
		if (emit.action_table_time != 0)
		{
			Console.Error.WriteLine(("          Action tab ")+(timestr(emit.action_table_time, total_time)));
		}
		if (emit.goto_table_time != 0)
		{
			Console.Error.WriteLine(("          Reduce tab ")+(timestr(emit.goto_table_time, total_time)));
		}
		Console.Error.WriteLine(("      Dump Output    ")+(timestr(dump_end - emit_end, total_time)));
	}

	
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
		string stringBuilder = ((num == 0) ? "" : "-")+(str)+(num5)
			+(".");
		long num8 = 1000L;
		string stringBuilder2 = stringBuilder+(((num8 != -1) ? (num4 % num8) : 0) / 100L);
		long num9 = 100L;
		string stringBuilder3 = stringBuilder2+(((num9 != -1) ? (num4 % num9) : 0) / 10L);
		long num10 = 10L;
		string stringBuilder4 = stringBuilder3+((num10 != -1) ? (num4 % num10) : 0)+("sec")+(" (")
			+(num7 / 10L)
			+(".");
		long num11 = 10L;
		string result = stringBuilder4+((num11 != -1) ? (num7 % num11) : 0)+("%)");
		
		return result;
	}
	
	
	public static void Main(string[] argv)
	{
		int output_produced = 0;
		start_time = Stopwatch.GetTimestamp();
		parse_args(argv);
		emit.set_lr_values(lr_values);
		if (print_progress)
		{
			Console.Error.WriteLine("Opening files...");
		}
		input_file = Console.In;
		prelim_end = Stopwatch.GetTimestamp();
		if (print_progress)
		{
			Console.Error.WriteLine("Parsing specification from standard input...");
		}
		parse_grammar_spec();
		parse_end = Stopwatch.GetTimestamp();
		if (Lexer.error_count == 0)
		{
			if (print_progress)
			{
				Console.Error.WriteLine("Checking specification...");
			}
			check_unused();
			check_end = Stopwatch.GetTimestamp();
			if (print_progress)
			{
				Console.Error.WriteLine("Building parse tables...");
			}
			build_parser();
			build_end = Stopwatch.GetTimestamp();
			if (Lexer.error_count != 0)
			{
				opt_dump_tables = false;
			}
			else
			{
				if (print_progress)
				{
					Console.Error.WriteLine("Writing parser...");
				}
				open_files();
				emit_parser();
				output_produced = 1;
			}
		}
		emit_end = Stopwatch.GetTimestamp();
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
		dump_end = Stopwatch.GetTimestamp();
		if (print_progress)
		{
			Console.Error.WriteLine("Closing files...");
		}
		close_files();
		if (!no_summary)
		{
			emit_summary((byte)output_produced != 0);
		}
		if (Lexer.error_count != 0)
		{
			Environment.Exit(100);
		}
	}
}
