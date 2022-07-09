using CMinor.Parser;
using CMinor.Semantic;
using CMinor.Visit;

namespace CMinor.Symbol;

public class StackVariableSymbol : Symbol
{
	private int offset;
	
	public StackVariableSymbol(LocationInfo info, string identifier, Types type)
		: base(info, identifier, type)
	{
	}

    public virtual int Offset { get => offset; set => this.offset = value; }

    public override void Accept(SymbolVisitor v)
	{
		v.Visit(this);
	}
}
