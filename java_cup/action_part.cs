



namespace JavaCUP;

public class action_part : production_part
{
	protected internal string _code_string;

	public virtual string code_string()
	{
		return _code_string;
	}

	
	
	public virtual bool Equals(action_part other)
	{
		return (other != null && base.Equals(other) && String.instancehelper_equals(other.code_string(), code_string())) ? true : false;
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

	
	
	public override bool Equals(object other)
	{
		if (!(other is action_part))
		{
			return false;
		}
		bool result = Equals((action_part)other);
		
		return result;
	}

	
	
	public override int GetHashCode()
	{
		return base.GetHashCode() ^ ((code_string() != null) ? (code_string.GetHashCode()) : 0);
	}

	
	
	public override string ToString()
	{
		return (base.ToString())+("{")+(code_string())
			+("}")
			;
	}
}
