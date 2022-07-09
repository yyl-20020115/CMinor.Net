using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

using CMinor.AST;
using CMinor.lexer;
using CMinor.Parser;
using CMinor.Semantic;

namespace CMinor;

public class Compiler
{
	
	public class CompilationError : System.Exception
	{
		
		
		public CompilationError(string message)
			: base(message)
		{
		}

		
		
		protected CompilationError(SerializationInfo P_0, StreamingContext P_1)
			: base(P_0, P_1)
		{
		}
	}

	
	public class UsageError : System.Exception
	{
		
		
		public UsageError(string message)
			: base(message)
		{
		}

		
		
		protected UsageError(SerializationInfo P_0, StreamingContext P_1)
			: base(P_0, P_1)
		{
		}
	}

	private const string PIPE_MARKER = "-";

	private const string OUTPUT_FLAG = "-o";

	private const string HELP_FLAG = "-h";

	private const string TREE_FLAG = "-t";

	private const string SYMBOL_FLAG = "-s";

	private const string CHECK_FLAG = "-l";

	private const string ASSEMBLY_SUFFIX = "s";

	private const string DOT_SUFFIX = "dot";

	
	
	private static HashSet<string> flags = new()
		{
			"-o",
			"-h",
			"-t",
			"-s",
			"-l"
		};


	private bool helpMode;

	private bool treeMode;

	private bool symbolMode;

	private bool checkMode;

	private string inputName;

	private string outputName;

	
	
	public static void ___003Cclinit_003E()
	{
	}

	
	
	public virtual void parseArgs(string[] args)
	{
		string text = null;
		ArrayList arrayList = null;
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = args.Length;
		for (int i = 0; i < num5; i++)
		{
			string text2 = args[i];
			if (arrayList != null && ((IList)arrayList).Count == 0)
			{
				if (isFlag(text2))
				{
					
					throw new UsageError("-o flag missing argument");
				}
				((IList)arrayList).Add((object)text2);
				continue;
			}
			if (String.Equals(text2, "-o"))
			{
				if (arrayList == null)
				{
					arrayList = new ArrayList();
					continue;
				}
				
				throw new UsageError("-o flag given more than once");
			}
			if (String.Equals(text2, "-h"))
			{
				if (num != 0)
				{
					
					throw new UsageError("-h flag given more than once");
				}
				num = 1;
				continue;
			}
			if (String.Equals(text2, "-t"))
			{
				if (num2 != 0)
				{
					
					throw new UsageError("-t flag given more than once");
				}
				num2 = 1;
				continue;
			}
			if (String.Equals(text2, "-s"))
			{
				if (num3 != 0)
				{
					
					throw new UsageError("-s flag given more than once");
				}
				num3 = 1;
				continue;
			}
			if (String.Equals(text2, "-l"))
			{
				if (num4 != 0)
				{
					
					throw new UsageError("-l flag given more than once");
				}
				num4 = 1;
				continue;
			}
			if (isInputFile(text2))
			{
				if (text == null)
				{
					text = text2;
					continue;
				}
				
				throw new UsageError("more than one input file given");
			}
			string message = ("cannot recognize argument \"")+(text2)+("\"")
				;
			
			throw new UsageError(message);
		}
		if (arrayList != null)
		{
			if (((IList)arrayList).Count <= 0)
			{
				
				throw new UsageError("-o flag missing argument");
			}
			outputName = (string)((IList)arrayList)[0];
		}
		if (num2 != 0 && num3 != 0)
		{
			
			throw new UsageError("-t and -s flags conflict");
		}
		if (num4 != 0 && (num2 != 0 || num3 != 0 || arrayList != null))
		{
			
			throw new UsageError("too many arguments for -l mode");
		}
		helpMode = (byte)num != 0;
		treeMode = (byte)num2 != 0;
		symbolMode = (byte)num3 != 0;
		checkMode = (byte)num4 != 0;
		inputName = text;
	}

	
	
	private static bool isFlag(string P_0)
	{
		bool result = flags.Contains(P_0);
		
		return result;
	}

	
	
	private static bool isInputFile(string P_0)
	{
		return (hasSuffix(P_0, "cm") || hasSuffix(P_0, "cminor") || String.Equals(P_0, "-")) ? true : false;
	}

	
	
	public static void printUsage(TextWriter output)
	{
		output.WriteLine("Usage: cminor [-h] [-t] [-s] [-l] [-o <output>] [<input.{cm,cminor}>]\n    <input>      Specifies the input file. If omitted or given as \"-\", the\n                 input is stdin.\n    -o <output>  Specifies the output file. Upon error no output file is\n                 created. If omitted, the output file has the name of the input\n                 file with its suffix replaced. If omitted and the input is\n                 stdin, or if the output file is given as \"-\", the output is\n                 stdout.\n    -t           Abstract syntax tree mode. Instead of compiling the program,\n                 generates dot code representing the abstract syntax tree of\n                 the input program.\n    -s           Symbol resolution mode. Generates dot code representing the\n                 abstract syntax tree of the input program, including nodes for\n                 resolved symbols.\n    -l           Only validates the input program for semantic correctness;\n                 does not generate any code.\n    -h           Prints this help message.");
	}

	
	
	public static void printUsage()
	{
		printUsage(Console.Out);
	}

	
	
	private static AstNode getRootNode(TextReader P_0, string P_1, ErrorLogger P_2)
	{
		Lexer lexer = new Lexer(P_0);
		lexer.setFilename(P_1);
		lexer.setErrorLogger(P_2);
		CMinor.Parser.Parser parser = new (lexer);
		AstNode result;
		System.Exception ex2;
		try
		{
			try
			{
				AstNode astNode = (AstNode)parser.Parse().value;
				result = astNode;
			}
			catch (System.Exception x)
			{
				System.Exception ex = x;
				if (ex == null)
				{
					throw;
				}
				ex2 = ex;
				goto IL_004b;
			}
		}
		catch
		{
			//try-fault
			P_0.Close();
			throw;
		}
		P_0.Close();
		return result;
		IL_004b:
		System.Exception ex3 = ex2;
		try
		{
			System.Exception @this = ex3;
			string msg = ((@this.Message != null) ? @this.Message : "parsing error");
			
			throw new ParsingError(msg);
		}
		catch
		{
			//try-fault
			P_0.Close();
			throw;
		}
	}

	
	
	private static string replaceSuffix(string P_0, string P_1)
	{
		return (P_0.Substring(0, (P_0.LastIndexOf((char)46)) + 1))+(P_1);
	}

	
	
	
	public Compiler(string[] args)
	{
		parseArgs(args);
	}

	public virtual void execute()
	{
		if (helpMode)
		{
			printUsage();
			return;
		}
		int num = 0;
		int num2 = 0;
		if (inputName == null || String.Equals(inputName, "-"))
		{
			num = 1;
		}
		if ((outputName == null && num != 0) || (outputName != null && String.Equals(outputName, "-")))
		{
			num2 = 1;
		}
		string text = ((num == 0) ? inputName : "stdin");
		var fileReader = ((num == 0) ? new StreamReader(inputName) : Console.In);
		var errorLogger = new ErrorLogger();
		var rootNode = getRootNode(fileReader, text, errorLogger);
		if (checkMode)
		{
			if (errorLogger.HasErrors)
			{
				
				throw new ParsingError("parsing phase failed");
			}
			rootNode.resolveSymbols(errorLogger);
			if (errorLogger.HasErrors)
			{
				
				throw new CompilationError("symbol resolution phase failed");
			}
			rootNode.typeCheck(errorLogger);
			if (!errorLogger.HasErrors)
			{
				return;
			}
			
			throw new CompilationError("type checking phase failed");
		}
		if (errorLogger.HasErrors)
		{
			
			throw new ParsingError("compilation aborted");
		}
		string name = ((num2 != 0 || outputName != null) ? outputName : replaceSuffix(inputName, (!treeMode) ? "s" : "dot"));
		TextWriter output;
		if (treeMode)
		{
			output = ((num2 == 0) ? new StreamWriter((name)) : Console.Out);
			rootNode.printDotCode(output);
			return;
		}
		if (symbolMode)
		{
			rootNode.resolveSymbols(errorLogger);
			output = ((num2 == 0) ? new StreamWriter((name)) : Console.Out);
			rootNode.printDotCode(output);
			output.Close();
			return;
		}
		rootNode.resolveSymbols(errorLogger);
		if (errorLogger.HasErrors)
		{
			
			throw new CompilationError("compilation aborted");
		}
		rootNode.typeCheck(errorLogger);
		if (errorLogger.HasErrors)
		{
			
			throw new CompilationError("compilation aborted");
		}
		output = ((num2 == 0) ? new StreamWriter((name)) : Console.Out);
		rootNode.generateCode(output);
		output.Close();
	}

	
	
	private static bool hasSuffix(string P_0, string P_1)
	{		
		return P_0.EndsWith("."+P_1);
	}

	public static void Mmain(string[] args)
	{
		UsageError usageError;
		CompilationError compilationError;
		ParsingError parsingError;
		FileNotFoundException ex;
		System.Exception ex3;
		try
		{
			try
			{
				try
				{
					try
					{
						try
						{
							Compiler compiler = new Compiler(args);
							compiler.execute();
							return;
						}
						catch (UsageError x)
						{
							usageError = x;
						}
					}
					catch (CompilationError x2)
					{
						compilationError = x2;
						goto IL_004a;
					}
				}
				catch (ParsingError x3)
				{
					parsingError = x3;
					goto IL_004d;
				}
			}
			catch (FileNotFoundException x4)
			{
				ex = x4;
				goto IL_0050;
			}
		}
		catch (System.Exception x5)
		{
			System.Exception ex2 = x5;
			if (ex2 == null)
			{
				throw;
			}
			ex3 = ex2;
			goto IL_0054;
		}
		UsageError @this = usageError;
		Console.Error.WriteLine(@this.Message);
		printUsage();
		Environment.Exit(1);
		return;
		IL_0054:
		System.Exception this2 = ex3;
		Console.Error.WriteLine(("internal compiler error (crap!): ")+(@this2.Message));
		
		Environment.Exit(1);
		return;
		IL_0050:
		FileNotFoundException this3 = ex;
		Console.Error.WriteLine(("error when using file: ")+(@this3.Message));
		Environment.Exit(1);
		return;
		IL_004d:
		object obj = parsingError;
		goto IL_0083;
		IL_004a:
		obj = compilationError;
		goto IL_0083;
		IL_0083:
		this2 = (System.Exception)obj;
		Console.Error.WriteLine(@this2.Message);
		Environment.Exit(1);
	}

}
