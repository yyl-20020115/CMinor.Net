namespace JavaCUP;

public class ActionPart : ProductionPart
{
	protected internal string codeString;

    public virtual string CodeString => codeString;

    public virtual bool Equals(ActionPart other)
	{
		return (other != null && base.Equals(other) && string.Equals(other.CodeString, CodeString)) ? true : false;
	}

	
	public ActionPart(string code_str)
		: base(null)
	{
		codeString = code_str;
	}

	public virtual void set_code_string(string new_str)
	{
		codeString = new_str;
	}

	public override bool is_action()
	{
		return true;
	}

	
	
	public override bool Equals(object other)
	{
		if (!(other is ActionPart))
		{
			return false;
		}
		bool result = Equals((ActionPart)other);
		
		return result;
	}

	
	
	public override int GetHashCode()
	{
		var cs = CodeString;
		return base.GetHashCode() ^ ((cs != null) ? (cs.GetHashCode()) : 0);
	}

	
	
	public override string ToString()
	{
		return (base.ToString())+("{")+(CodeString)
			+("}")
			;
	}
}
