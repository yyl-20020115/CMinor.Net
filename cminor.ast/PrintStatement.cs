
using CMinor.Parser;
using CMinor.Symbol;
using CMinor.Visit;

using java.lang;


namespace CMinor.AST;

public class PrintStatement : Statement
{
	public const string TRUE_STRING = "true";

	public const string FALSE_STRING = "false";

	public const string BOOL_STRING = "false\0true";

	internal static int ___003C_003EOFFSET;

	public const string CHAR_FORMAT = "%c";

	public const string INT_FORMAT = "%d";

	public const string STRING_FORMAT = "%s";

	private List arguments;

	private StringSymbol symbol;

	private List actualArguments;

	public static int OFFSET
	{
		get
		{
			return ___003C_003EOFFSET;
		}
	}

	public static void ___003Cclinit_003E()
	{
	}

	public PrintStatement(LocationInfo info, List arguments)
		: base(info)
	{
		this.arguments = arguments;
	}

	public virtual List getArguments()
	{
		return arguments;
	}

	public virtual StringSymbol getSymbol()
	{
		return symbol;
	}

	public virtual void setSymbol(StringSymbol symbol)
	{
		this.symbol = symbol;
	}

	
	public virtual List getActualArguments()
	{
		return actualArguments;
	}

	
	public virtual void setActualArguments(List actualArguments)
	{
		this.actualArguments = actualArguments;
	}

	
	
	public override void Accept(Visitor v)
	{
		v.visit(this);
	}

	
	static PrintStatement()
	{
		___003C_003EOFFSET = String.instancehelper_length("false") + 1;
	}
}
