using System;
using System.Runtime.Serialization;

using CMinor.AST;
using CMinor.lexer;
using CMinor.Parser;
using CMinor.semantic;

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

	[Modifiers(Modifiers.Private | Modifiers.Static | Modifiers.Final)]
	
	private static HashSet flags;

	private bool helpMode;

	private bool treeMode;

	private bool symbolMode;

	private bool checkMode;

	private string inputName;

	private string outputName;

	
	
	public static void ___003Cclinit_003E()
	{
	}

	
	[Throws(new string[] { "cminor.Compiler$UsageError" })]
	[LineNumberTable(new byte[]
	{
		11,
		98,
		98,
		98,
		98,
		99,
		131,
		123,
		107,
		121,
		142,
		110,
		110,
		144,
		110,
		115,
		135,
		110,
		115,
		135,
		110,
		116,
		136,
		110,
		116,
		133,
		105,
		104,
		144,
		byte.MaxValue,
		17,
		35,
		235,
		96,
		99,
		125,
		176,
		103,
		176,
		110,
		176,
		103,
		103,
		104,
		104,
		135
	})]
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
			if (arrayList != null && ((List)arrayList).size() == 0)
			{
				if (isFlag(text2))
				{
					
					throw new UsageError("-o flag missing argument");
				}
				((List)arrayList).add((object)text2);
				continue;
			}
			if (java.lang.String.instancehelper_equals(text2, "-o"))
			{
				if (arrayList == null)
				{
					arrayList = new ArrayList();
					continue;
				}
				
				throw new UsageError("-o flag given more than once");
			}
			if (java.lang.String.instancehelper_equals(text2, "-h"))
			{
				if (num != 0)
				{
					
					throw new UsageError("-h flag given more than once");
				}
				num = 1;
				continue;
			}
			if (java.lang.String.instancehelper_equals(text2, "-t"))
			{
				if (num2 != 0)
				{
					
					throw new UsageError("-t flag given more than once");
				}
				num2 = 1;
				continue;
			}
			if (java.lang.String.instancehelper_equals(text2, "-s"))
			{
				if (num3 != 0)
				{
					
					throw new UsageError("-s flag given more than once");
				}
				num3 = 1;
				continue;
			}
			if (java.lang.String.instancehelper_equals(text2, "-l"))
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
			string message = new StringBuilder().append("cannot recognize argument \"").append(text2).append("\"")
				.toString();
			
			throw new UsageError(message);
		}
		if (arrayList != null)
		{
			if (((List)arrayList).size() <= 0)
			{
				
				throw new UsageError("-o flag missing argument");
			}
			outputName = (string)((List)arrayList).get(0);
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
		bool result = flags.contains(P_0);
		
		return result;
	}

	
	
	private static bool isInputFile(string P_0)
	{
		return (hasSuffix(P_0, "cm") || hasSuffix(P_0, "cminor") || java.lang.String.instancehelper_equals(P_0, "-")) ? true : false;
	}

	
	
	public static void printUsage(TextWriter output)
	{
		output.println("Usage: cminor [-h] [-t] [-s] [-l] [-o <output>] [<input.{cm,cminor}>]\n    <input>      Specifies the input file. If omitted or given as \"-\", the\n                 input is stdin.\n    -o <output>  Specifies the output file. Upon error no output file is\n                 created. If omitted, the output file has the name of the input\n                 file with its suffix replaced. If omitted and the input is\n                 stdin, or if the output file is given as \"-\", the output is\n                 stdout.\n    -t           Abstract syntax tree mode. Instead of compiling the program,\n                 generates dot code representing the abstract syntax tree of\n                 the input program.\n    -s           Symbol resolution mode. Generates dot code representing the\n                 abstract syntax tree of the input program, including nodes for\n                 resolved symbols.\n    -l           Only validates the input program for semantic correctness;\n                 does not generate any code.\n    -h           Prints this help message.");
	}

	
	
	public static void printUsage()
	{
		printUsage(java.lang.System.@out);
	}

	
	[Throws(new string[] { "cminor.parser.ParsingError", "java.io.IOException" })]
	[LineNumberTable(new byte[]
	{
		160, 126, 103, 103, 103, 135, 113, 245, 70, 77,
		236, 60, 98, 191, 3
	})]
	private static AstNode getRootNode(FileReader P_0, string P_1, ErrorLogger P_2)
	{
		Lexer lexer = new Lexer(P_0);
		lexer.setFilename(P_1);
		lexer.setErrorLogger(P_2);
		Parser parser = new Parser(lexer);
		AstNode result;
		System.Exception ex2;
		try
		{
			try
			{
				AstNode astNode = (AstNode)parser.parse().value;
				result = astNode;
			}
			catch (System.Exception x)
			{
				System.Exception ex = ByteCodeHelper.MapException<System.Exception>(x, ByteCodeHelper.MapFlags.None);
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
			P_0.close();
			throw;
		}
		P_0.close();
		return result;
		IL_004b:
		System.Exception ex3 = ex2;
		try
		{
			System.Exception @this = ex3;
			string msg = ((Throwable.instancehelper_getMessage(@this) != null) ? Throwable.instancehelper_getMessage(@this) : "parsing error");
			
			throw new ParsingError(msg);
		}
		catch
		{
			//try-fault
			P_0.close();
			throw;
		}
	}

	
	
	private static string replaceSuffix(string P_0, string P_1)
	{
		string result = new StringBuilder().append(java.lang.String.instancehelper_substring(P_0, 0, java.lang.String.instancehelper_lastIndexOf(P_0, 46) + 1)).append(P_1).toString();
		
		return result;
	}

	
	[Throws(new string[] { "cminor.Compiler$UsageError" })]
	
	public Compiler(string[] args)
	{
		parseArgs(args);
	}

	
	[Throws(new string[] { "System.Exception", "cminor.Compiler$CompilationError" })]
	[LineNumberTable(new byte[]
	{
		97, 178, 100, 122, 130, 127, 6, 130, 113, 187,
		103, 139, 104, 121, 105, 153, 105, 252, 69, 105,
		208, 107, 191, 4, 168, 104, 120, 105, 101, 104,
		105, 120, 105, 103, 165, 105, 121, 105, 121, 120,
		105, 201
	})]
	public virtual void execute()
	{
		if (helpMode)
		{
			printUsage();
			return;
		}
		int num = 0;
		int num2 = 0;
		if (inputName == null || java.lang.String.instancehelper_equals(inputName, "-"))
		{
			num = 1;
		}
		if ((outputName == null && num != 0) || (outputName != null && java.lang.String.instancehelper_equals(outputName, "-")))
		{
			num2 = 1;
		}
		string text = ((num == 0) ? inputName : "stdin");
		FileReader fileReader = ((num == 0) ? new FileReader(inputName) : new FileReader(FileDescriptor.@in));
		ErrorLogger errorLogger = new ErrorLogger();
		AstNode rootNode = getRootNode(fileReader, text, errorLogger);
		if (checkMode)
		{
			if (errorLogger.hasErrors())
			{
				
				throw new ParsingError("parsing phase failed");
			}
			rootNode.resolveSymbols(errorLogger);
			if (errorLogger.hasErrors())
			{
				
				throw new CompilationError("symbol resolution phase failed");
			}
			rootNode.typeCheck(errorLogger);
			if (!errorLogger.hasErrors())
			{
				return;
			}
			
			throw new CompilationError("type checking phase failed");
		}
		if (errorLogger.hasErrors())
		{
			
			throw new ParsingError("compilation aborted");
		}
		string name = ((num2 != 0 || outputName != null) ? outputName : replaceSuffix(inputName, (!treeMode) ? "s" : "dot"));
		TextWriter output;
		if (treeMode)
		{
			output = ((num2 == 0) ? new TextWriter(new FileOutputStream(name)) : java.lang.System.@out);
			rootNode.printDotCode(output);
			return;
		}
		if (symbolMode)
		{
			rootNode.resolveSymbols(errorLogger);
			output = ((num2 == 0) ? new TextWriter(new FileOutputStream(name)) : java.lang.System.@out);
			rootNode.printDotCode(output);
			output.close();
			return;
		}
		rootNode.resolveSymbols(errorLogger);
		if (errorLogger.hasErrors())
		{
			
			throw new CompilationError("compilation aborted");
		}
		rootNode.typeCheck(errorLogger);
		if (errorLogger.hasErrors())
		{
			
			throw new CompilationError("compilation aborted");
		}
		output = ((num2 == 0) ? new TextWriter(new FileOutputStream(name)) : java.lang.System.@out);
		rootNode.generateCode(output);
		output.close();
	}

	
	
	private static bool hasSuffix(string P_0, string P_1)
	{
		bool result = java.lang.String.instancehelper_endsWith(P_0, new StringBuilder().append(".").append(P_1).toString());
		
		return result;
	}

	
	[LineNumberTable(new byte[]
	{
		160,
		100,
		103,
		byte.MaxValue,
		53,
		83,
		229,
		47,
		98,
		113,
		101,
		230,
		78,
		229,
		52,
		98,
		113,
		230,
		74,
		229,
		56,
		98,
		127,
		11,
		230,
		70,
		226,
		60,
		98,
		127,
		11,
		108,
		166
	})]
	public static void main(string[] args)
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
							usageError = ByteCodeHelper.MapException<UsageError>(x, ByteCodeHelper.MapFlags.NoRemapping);
						}
					}
					catch (CompilationError x2)
					{
						compilationError = ByteCodeHelper.MapException<CompilationError>(x2, ByteCodeHelper.MapFlags.NoRemapping);
						goto IL_004a;
					}
				}
				catch (ParsingError x3)
				{
					parsingError = ByteCodeHelper.MapException<ParsingError>(x3, ByteCodeHelper.MapFlags.NoRemapping);
					goto IL_004d;
				}
			}
			catch (FileNotFoundException x4)
			{
				ex = ByteCodeHelper.MapException<FileNotFoundException>(x4, ByteCodeHelper.MapFlags.NoRemapping);
				goto IL_0050;
			}
		}
		catch (System.Exception x5)
		{
			System.Exception ex2 = ByteCodeHelper.MapException<System.Exception>(x5, ByteCodeHelper.MapFlags.None);
			if (ex2 == null)
			{
				throw;
			}
			ex3 = ex2;
			goto IL_0054;
		}
		UsageError @this = usageError;
		java.lang.System.err.println(Throwable.instancehelper_getMessage(@this));
		printUsage();
		java.lang.System.exit(1);
		return;
		IL_0054:
		System.Exception this2 = ex3;
		java.lang.System.err.println(new StringBuilder().append("internal compiler error (crap!): ").append(Throwable.instancehelper_getMessage(this2)).toString());
		Throwable.instancehelper_printStackTrace(this2, java.lang.System.err);
		java.lang.System.exit(1);
		return;
		IL_0050:
		FileNotFoundException this3 = ex;
		java.lang.System.err.println(new StringBuilder().append("error when using file: ").append(Throwable.instancehelper_getMessage(this3)).toString());
		java.lang.System.exit(1);
		return;
		IL_004d:
		object obj = parsingError;
		goto IL_0083;
		IL_004a:
		obj = compilationError;
		goto IL_0083;
		IL_0083:
		this2 = (System.Exception)obj;
		java.lang.System.err.println(Throwable.instancehelper_getMessage(this2));
		java.lang.System.exit(1);
	}

	
	static Compiler()
	{
		flags = new HashSet();
		flags.add("-o");
		flags.add("-h");
		flags.add("-t");
		flags.add("-s");
		flags.add("-l");
	}
}
