



namespace java_cup;

public class action_part : production_part
{
	protected internal string _code_string;

	public virtual string code_string()
	{
		return _code_string;
	}

	
	
	public virtual bool equals(action_part other)
	{
		return (other != null && base.equals(other) && String.instancehelper_equals(other.code_string(), code_string())) ? true : false;
	}

	
	
	public action_part(string code_str)
		: base(null)
	{
		_code_string = code_str;
	}

	public virtual void set_code_string(string new_str)
	{
		_code_string = new_str;
	}

	public override bool is_action()
	{
		return true;
	}

	
	
	public override bool equals(object other)
	{
		if (!(other is action_part))
		{
			return false;
		}
		bool result = equals((action_part)other);
		
		return result;
	}

	
	
	public override int hashCode()
	{
		return base.hashCode() ^ ((code_string() != null) ? String.instancehelper_hashCode(code_string()) : 0);
	}

	
	
	public override string ToString()
	{
		string result = (base.ToString())+("{")+(code_string())
			+("}")
			.ToString();
		
		return result;
	}
}
