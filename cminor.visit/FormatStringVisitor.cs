
using CMinor.AST;
using CMinor.semantic;
using CMinor.Symbol;

using java.lang;


namespace CMinor.Visit;

internal class FormatStringVisitor : Visitor
{
	private StringBuilder result;

	private StringBuilder literalContent;

	
	private List actualArguments;

	private StringTable stringTable;

	private Program program;

	private ErrorLogger logger;

	
	
	private string escape(string P_0)
	{
		string text = String.instancehelper_replace(P_0, "%%", "%");
		
		return text;
	}

	
	
	
	public FormatStringVisitor(StringBuilder P_0, List P_1, StringTable P_2, Program P_3, ErrorLogger P_4)
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
		logger.log(P_0.getLocation(), new StringBuilder().append("format string visitor in ").append(P_0.getDotLabel()).append(" is a stub")
			.toString());
	}

	
	[LineNumberTable(new byte[]
	{
		159, 188, 173, 125, 172, 103, 126, 136, 145, 189,
		123, 121
	})]
	public override void visit(Expression P_0)
	{
		actualArguments.add(P_0);
		result.append(escape(literalContent.toString()));
		literalContent.setLength(0);
		Type type = P_0.getType();
		if (type == Type.___003C_003ECHAR)
		{
			result.append("%c");
		}
		else if (type == Type.___003C_003EBOOLEAN)
		{
			result.append("%s");
			program.setBooleanStringSymbol(stringTable.getSymbol("false\0true"));
		}
		else if (type == Type.___003C_003EINT)
		{
			result.append("%d");
		}
		else if (type == Type.___003C_003ESTRING)
		{
			result.append("%s");
		}
	}

	
	
	public override void visit(ConstantExpression P_0)
	{
		literalContent.append(P_0.getValue());
	}

	
	
	public override void visit(BooleanLiteral P_0)
	{
		literalContent.append((!((Boolean)P_0.getValue()).booleanValue()) ? "false" : "true");
	}

	
	
	public virtual void finish()
	{
		result.append(escape(literalContent.toString()));
	}
}
