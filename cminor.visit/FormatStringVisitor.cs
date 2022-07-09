using CMinor.AST;
using CMinor.Semantic;
using CMinor.Symbol;
using System.Collections;
using System.Text;

namespace CMinor.Visit;

internal class FormatStringVisitor : Visitor
{
	private StringBuilder result = new();

	private StringBuilder literalContent = new();

	private IList actualArguments;

	private StringTable stringTable = new();

	private Program program;

	private ErrorLogger logger;
	
	
	private string escape(string P_0)
	{		
		return P_0.Replace("%%","%");
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

	
	
	public override void Visit(AstNode node)
	{
		logger.log(node.getLocation(), ("format string visitor in ")+(node.DotLabel)+(" is a stub"));
	}

	
	public override void Visit(Expression exp)
	{
		actualArguments.Add(exp);
		result.Append(escape(literalContent.ToString()));
		literalContent.Length = 0;
		Types type = exp.Type;
		if (type == Types.char_type)
		{
			result.Append("%c");
		}
		else if (type == Types.boolean_type)
		{
			result.Append("%s");
			program.BooleanStringSymbol = stringTable.getSymbol("false\0true");
		}
		else if (type == Types.integer_type)
		{
			result.Append("%d");
		}
		else if (type == Types.string_type)
		{
			result.Append("%s");
		}
	}

	
	public override void Visit(ConstantExpression exp)
	{
		literalContent.Append(exp.Value);
	}

	
	
	public override void Visit(BooleanLiteral P_0)
	{
		literalContent.Append((!(P_0.Value)) ? "false" : "true");
	}

	
	public virtual void Finish()
	{
		result.Append(escape(literalContent.ToString()));
	}
}
