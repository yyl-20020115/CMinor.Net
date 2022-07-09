
using CMinor.Parser;
using CMinor.Symbol;
using CMinor.Visit;



namespace CMinor.AST;

public class FunctionDefinition : ExternalDeclaration
{
	private TypeSpecifier returnType;

	private List parameters;

	private BlockStatement body;

	private FunctionSymbol symbol;

	private bool doesEndWithReturn;

	private int numLocals;

	public FunctionDefinition(LocationInfo info, TypeSpecifier returnType, Identifier name, List parameters, BlockStatement body)
		: base(info, name)
	{
		this.returnType = returnType;
		this.parameters = parameters;
		this.body = body;
		numLocals = 0;
	}

	public virtual TypeSpecifier getReturnType()
	{
		return returnType;
	}

	
	public virtual List getParameters()
	{
		return parameters;
	}

	public virtual BlockStatement getBody()
	{
		return body;
	}

	public virtual FunctionSymbol getSymbol()
	{
		return symbol;
	}

	public virtual void setSymbol(FunctionSymbol symbol)
	{
		this.symbol = symbol;
	}

	public virtual bool endsWithReturn()
	{
		return doesEndWithReturn;
	}

	public virtual void setEndsWithReturn(bool endsWithReturn)
	{
		int num = ((doesEndWithReturn = endsWithReturn) ? 1 : 0);
	}

	public virtual int getNumLocals()
	{
		return numLocals;
	}

	public virtual void raiseNumLocals(int max)
	{
		if (max > numLocals)
		{
			numLocals = max;
		}
	}

	
	
	public override void Accept(Visitor v)
	{
		v.visit(this);
	}
}
