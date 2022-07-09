
using CMinor.AST;
using CMinor.Semantic;
using CMinor.Symbol;




namespace CMinor.Visit;

internal class FormatStringVisitor : Visitor
{
	private StringBuilder result;

	private StringBuilder literalContent;

	
	private IList actualArguments;

	private StringTable stringTable;

	private Program program;

	private ErrorLogger logger;

	
	
	private string escape(string P_0)
	{
		string text = String.instancehelper_replace(P_0, "%%", "%");
		
		return text;
	}

	
	
	
	public FormatStringVisitor(StringBuilder P_0, IList P_1, StringTable P_2, Program P_3, ErrorLogger P_4)
	{
		result = P_0;
		literalContent = new StringBuilder();
		actualArguments = P_1;
		stringTable = P_2;
		program = P_3;
		logger = P_4;
	}

	
	
	public override void visit(AstNode P_0)
	{
		logger.log(P_0.getLocation(), ("format string visitor in ")+(P_0.DotLabel)+(" is a stub")
			);
	}

	
	[LineNumberTable(new byte[]
	{
		159, 188, 173, 125, 172, 103, 126, 136, 145, 189,
		123, 121
	})]
	public override void Visit(Expression P_0)
	{
		actualArguments.Add(P_0);
		result+(escape(literalContent));
		literalContent.setLength(0);
		Type type = P_0.Type;
		if (type == Type.char_type)
		{
			result+("%c");
		}
		else if (type == Type.boolean_type)
		{
			result+("%s");
			program.BooleanStringSymbol = stringTable.getSymbol("false\0true");
		}
		else if (type == Type.integer_type)
		{
			result+("%d");
		}
		else if (type == Type.string_type)
		{
			result+("%s");
		}
	}

	
	
	public override void Visit(ConstantExpression P_0)
	{
		literalContent+(P_0.Value);
	}

	
	
	public override void Visit(BooleanLiteral P_0)
	{
		literalContent+((!((Boolean)P_0.Value).booleanValue()) ? "false" : "true");
	}

	
	
	public virtual void finish()
	{
		result+(escape(literalContent));
	}
}
