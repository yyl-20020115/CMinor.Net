
using CMinor.Parser;
using CMinor.semantic;
using CMinor.Visit;


namespace CMinor.Symbol;

public class StackVariableSymbol : Symbol
{
	private int offset;

	
	
	public StackVariableSymbol(LocationInfo info, string identifier, Type type)
		: base(info, identifier, type)
	{
	}

	public virtual int getOffset()
	{
		return offset;
	}

	public virtual void setOffset(int offset)
	{
		this.offset = offset;
	}

	
	
	public override void accept(SymbolVisitor v)
	{
		v.visit(this);
	}
}
