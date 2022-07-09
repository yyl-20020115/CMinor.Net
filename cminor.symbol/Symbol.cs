using CMinor.Parser;
using CMinor.Semantic;
using CMinor.Visit;
using System.Text;

namespace CMinor.Symbol;

public abstract class Symbol : DotNode
{
	private static int numInstances;

	private int instanceNumber;

	private LocationInfo info;

	private string identifier;

	private Types type;
	
	public virtual void Accept(SymbolVisitor v)
	{
		v.Visit(this);
	}



    public virtual string DotId => ("Symbol") + (instanceNumber);

    protected internal Symbol(LocationInfo info, string identifier, Types type)
	{
		instanceNumber = numInstances++;
		this.identifier = identifier;
		this.info = info;
		this.type = type;
	}

    public virtual LocationInfo Location => info;

    public virtual string Identifier => identifier;

    public virtual Types Type => type;



    public virtual string DotLabel
    {
        get
        {
            var symbolDotLabelVisitor = new SymbolDotLabelVisitor();
            Accept(symbolDotLabelVisitor);
            return symbolDotLabelVisitor.Label;
		}
    }
}
