using CMinor.Parser;
using CMinor.semantic;
using CMinor.Visit;
using System.Text;

namespace CMinor.Symbol;

public abstract class Symbol : DotNode
{
	private static int numInstances;

	private int instanceNumber;

	private LocationInfo info;

	private string identifier;

	private Type type;

	
	
	public virtual void accept(SymbolVisitor v)
	{
		v.visit(this);
	}

	
	
	public virtual string getDotId()
	{
		string result = ("Symbol")+(instanceNumber);
		
		return result;
	}

	
	
	protected internal Symbol(LocationInfo info, string identifier, Type type)
	{
		instanceNumber = numInstances++;
		this.identifier = identifier;
		this.info = info;
		this.type = type;
	}

	public virtual LocationInfo getLocation()
	{
		return info;
	}

	public virtual string getIdentifier()
	{
		return identifier;
	}

	public virtual Type getType()
	{
		return type;
	}

	
	
	public virtual string getDotLabel()
	{
		SymbolDotLabelVisitor symbolDotLabelVisitor = new SymbolDotLabelVisitor();
		accept(symbolDotLabelVisitor);
		string label = symbolDotLabelVisitor.getLabel();
		
		return label;
	}
}
