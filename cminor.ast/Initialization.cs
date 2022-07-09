
using CMinor.Parser;
using CMinor.Visit;


namespace CMinor.AST;

public class Initialization : Declaration
{
	private ConstantExpression value;

	
	
	public Initialization(LocationInfo info, TypeSpecifier type, Identifier name, ConstantExpression value)
		: base(info, type, name)
	{
		this.value = value;
	}

	public virtual ConstantExpression getValue()
	{
		return value;
	}

	
	
	public override void Accept(Visitor v)
	{
		v.visit(this);
	}
}
