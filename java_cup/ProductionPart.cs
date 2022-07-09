namespace JavaCUP;

public abstract class ProductionPart
{
	protected internal string _label;

    public virtual string Label => _label;



    public virtual bool Equals(ProductionPart other)
	{
		if (other == null)
		{
			return false;
		}
		if (Label!= null)
		{
			bool result = string.Equals(Label, other.Label);
			
			return result;
		}
		return other.Label== null;
	}

	
	
	public ProductionPart(string lab)
	{
		_label = lab;
	}

	public abstract bool is_action();

	
	
	public override bool Equals(object other)
	{
		if (!(other is ProductionPart))
		{
			return false;
		}
		bool result = Equals((ProductionPart)other);
		
		return result;
	}

	
	
	public override int GetHashCode()
	{
		int result = ((Label!= null) ? (Label.GetHashCode()) : 0);
		
		return result;
	}

	
	
	public override string ToString()
	{
		if (Label!= null)
		{
			string result = (Label)+(":");
			
			return result;
		}
		return " ";
	}
}
