

using java.lang;

namespace java_cup;

public abstract class production_part
{
	protected internal string _label;

	public virtual string label()
	{
		return _label;
	}

	
	
	public virtual bool equals(production_part other)
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

	
	
	public override bool equals(object other)
	{
		if (!(other is production_part))
		{
			return false;
		}
		bool result = equals((production_part)other);
		
		return result;
	}

	
	
	public override int hashCode()
	{
		int result = ((label() != null) ? String.instancehelper_hashCode(label()) : 0);
		
		return result;
	}

	
	
	public override string toString()
	{
		if (label() != null)
		{
			string result = new StringBuilder().append(label()).append(":").toString();
			
			return result;
		}
		return " ";
	}
}
