
using CMinor.Parser;
using CMinor.Symbol;
using CMinor.Visit;



namespace CMinor.AST;

public class Program : AstNode
{
	public const string MAIN_FUNCTION_NAME = "main";

	private List declarations;

	private FunctionDefinition mainFunction;

	private List functions;

	private List globalVariables;

	private List stringSymbols;

	private StringSymbol boolStringSymbol;

	public Program(LocationInfo info, List declarations)
		: base(info)
	{
		this.declarations = declarations;
	}

	public virtual List getDeclarations()
	{
		return declarations;
	}

	public virtual FunctionDefinition getMainFunction()
	{
		return mainFunction;
	}

	public virtual void setMainFunction(FunctionDefinition mainFunction)
	{
		this.mainFunction = mainFunction;
	}

	public virtual void setGlobalVariables(List globalVariables)
	{
		this.globalVariables = globalVariables;
	}

	
	public virtual List getGlobalVariables()
	{
		return globalVariables;
	}

	
	public virtual void setFunctions(List functions)
	{
		this.functions = functions;
	}

	
	public virtual List getFunctions()
	{
		return functions;
	}

	
	public virtual void setStringSymbols(List stringSymbols)
	{
		this.stringSymbols = stringSymbols;
	}

	
	public virtual List getStringSymbols()
	{
		return stringSymbols;
	}

	public virtual void setBooleanStringSymbol(StringSymbol symbol)
	{
		boolStringSymbol = symbol;
	}

	public virtual StringSymbol getBooleanStringSymbol()
	{
		return boolStringSymbol;
	}

	
	
	public override void Accept(Visitor v)
	{
		v.visit(this);
	}
}
