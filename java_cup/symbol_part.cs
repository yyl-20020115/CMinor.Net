

using java.lang;

namespace java_cup;

public class symbol_part : production_part
{
	protected internal symbol _the_symbol;

	
	[Throws(new string[] { "java_cup.internal_error" })]
	
	public symbol_part(symbol sym)
		: this(sym, null)
	{
	}

	public virtual symbol the_symbol()
	{
		return _the_symbol;
	}

	
	
	public override string toString()
	{
		if (the_symbol() != null)
		{
			string result = new StringBuilder().append(base.toString()).append(the_symbol()).toString();
			
			return result;
		}
		string result2 = new StringBuilder().append(base.toString()).append("$$MISSING-SYMBOL$$").toString();
		
		return result2;
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	
	public symbol_part(symbol sym, string lab)
		: base(lab)
	{
		if (sym == null)
		{
			
			throw new internal_error("Attempt to construct a symbol_part with a null symbol");
		}
		_the_symbol = sym;
	}

	
	
	public virtual bool equals(symbol_part other)
	{
		return (other != null && base.equals(other) && Object.instancehelper_equals(the_symbol(), other.the_symbol())) ? true : false;
	}

	public override bool is_action()
	{
		return false;
	}

	
	
	public override bool equals(object other)
	{
		if (!(other is symbol_part))
		{
			return false;
		}
		bool result = equals((symbol_part)other);
		
		return result;
	}

	
	
	public override int hashCode()
	{
		return base.hashCode() ^ ((the_symbol() != null) ? Object.instancehelper_hashCode(the_symbol()) : 0);
	}
}
