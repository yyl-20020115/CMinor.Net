



namespace JavaCUP;

public class symbol_part : production_part
{
	protected internal _Symbol _the_symbol;

	
	
	
	public symbol_part(_Symbol sym)
		: this(sym, null)
	{
	}

	public virtual _Symbol the_symbol()
	{
		return _the_symbol;
	}

	
	
	public override string ToString()
	{
		if (the_symbol() != null)
		{
			string result = (base.ToString())+(the_symbol());
			
			return result;
		}
		string result2 = (base.ToString()) +("$$MISSING-SYMBOL$$");
		
		return result2;
	}

	
	
	
	public symbol_part(_Symbol sym, string lab)
		: base(lab)
	{
		if (sym == null)
		{
			
			throw new internal_error("Attempt to construct a symbol_part with a null symbol");
		}
		_the_symbol = sym;
	}

	
	
	public virtual bool Equals(symbol_part other)
	{
		return (other != null && base.Equals(other) && object.Equals(the_symbol(), other.the_symbol())) ? true : false;
	}

	public override bool is_action()
	{
		return false;
	}

	
	
	public override bool Equals(object other)
	{
		if (!(other is symbol_part))
		{
			return false;
		}
		bool result = Equals((symbol_part)other);
		
		return result;
	}

	
	
	public override int GetHashCode()
	{
		return base.GetHashCode() ^ ((the_symbol() != null) ? (the_symbol().GetHashCode()) : 0);
	}
}
