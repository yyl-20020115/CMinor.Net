



namespace JavaCUP;

public abstract class production_part
{
	protected internal string _label;

	public virtual string label()
	{
		return _label;
	}

	
	
	public virtual bool Equals(production_part other)
	{
		if (other == null)
		{
			return false;
		}
		if (label() != null)
		{
			bool result = String.instancehelper_equals(label(), other.label());
			
			return result;
		}
		return other.label() == null;
	}

	
	
	public production_part(string lab)
	{
		_label = lab;
	}

	public abstract bool is_action();

	
	
	public override bool Equals(object other)
	{
		if (!(other is production_part))
		{
			return false;
		}
		bool result = Equals((production_part)other);
		
		return result;
	}

	
	
	public override int GetHashCode()
	{
		int result = ((label() != null) ? String.instancehelper_hashCode(label()) : 0);
		
		return result;
	}

	
	
	public override string ToString()
	{
		if (label() != null)
		{
			string result = (label())+(":");
			
			return result;
		}
		return " ";
	}
}
