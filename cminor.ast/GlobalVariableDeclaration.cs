
using CMinor.Parser;
using CMinor.Symbol;
using CMinor.Visit;


namespace CMinor.AST;

public class GlobalVariableDeclaration : ExternalDeclaration
{
	private TypeSpecifier type;

	private GlobalVariableSymbol symbol;

	
	
	public GlobalVariableDeclaration(LocationInfo info, TypeSpecifier type, Identifier name)
		: base(info, name)
	{
		this.type = type;
	}

	public virtual TypeSpecifier getType()
	{
		return type;
	}

	public virtual GlobalVariableSymbol getSymbol()
	{
		return symbol;
	}

	public virtual void setSymbol(GlobalVariableSymbol symbol)
	{
		this.symbol = symbol;
	}

	
	
	public override void Accept(Visitor v)
	{
		v.visit(this);
	}
}
