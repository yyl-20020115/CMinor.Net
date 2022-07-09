namespace JavaCUP;

public class lr_item_core
{
	protected internal production _the_production;

	protected internal int _dot_pos;

	protected internal int _core_hash_cache;

	protected internal _Symbol _symbol_after_dot;

	public lr_item_core(production prod, int pos)
	{
		_symbol_after_dot = null;
		
		if (prod == null)
		{
			
			throw new internal_error("Attempt to create an lr_item_core with a null production");
		}
		_the_production = prod;
		if (pos < 0 || pos > _the_production.rhs_length())
		{
			
			throw new internal_error("Attempt to create an lr_item_core with a bad dot position");
		}
		_dot_pos = pos;
		_core_hash_cache = 13 * _the_production.GetHashCode() + pos;
		if (_dot_pos < _the_production.rhs_length())
		{
			production_part production_part2 = _the_production.rhs(_dot_pos);
			if (!production_part2.is_action())
			{
				_symbol_after_dot = ((symbol_part)production_part2).the_symbol();
			}
		}
	}

	public virtual _Symbol symbol_after_dot()
	{
		return _symbol_after_dot;
	}

	
	
	public virtual bool dot_at_end()
	{
		return _dot_pos >= _the_production.rhs_length();
	}

	
	
	public virtual bool core_equals(lr_item_core other)
	{
		return (other != null && _the_production.Equals(other._the_production) && _dot_pos == other._dot_pos) ? true : false;
	}

	
	
	public virtual bool Equals(lr_item_core other)
	{
		bool result = core_equals(other);
		
		return result;
	}

	
	public virtual string to_simple_string()
	{
		string str = ((_the_production.lhs() == null || _the_production.lhs().the_symbol() == null || _the_production.lhs().the_symbol().Name== null) ? "$$NULL$$" : _the_production.lhs().the_symbol().Name);
		str = (str)+(" ::= ");
		for (int i = 0; i < _the_production.rhs_length(); i++)
		{
			if (i == _dot_pos)
			{
				str = (str)+("(*) ");
			}
			if (_the_production.rhs(i) == null)
			{
				str = (str)+("$$NULL$$ ");
				continue;
			}
			production_part production_part2 = _the_production.rhs(i);
			str = ((production_part2 != null) ? ((!production_part2.is_action()) ? ((((symbol_part)production_part2).the_symbol() == null || ((symbol_part)production_part2).the_symbol().Name== null) ? (str)+("$$NULL$$ ").ToString() : (str)+(((symbol_part)production_part2).the_symbol().Name)+(" ")
				) : (str)+("{ACTION} ")) : (str)+("$$NULL$$ "));
		}
		if (_dot_pos == _the_production.rhs_length())
		{
			str = (str)+("(*) ");
		}
		return str;
	}

	
	
	
	public lr_item_core(production prod)
		: this(prod, 0)
	{
	}

	public virtual production the_production()
	{
		return _the_production;
	}

	public virtual int dot_pos()
	{
		return _dot_pos;
	}

	
	
	public virtual non_terminal dot_before_nt()
	{
		_Symbol symbol2 = symbol_after_dot();
		if (symbol2 != null && symbol2.IsNonTerminal)
		{
			return (non_terminal)symbol2;
		}
		return null;
	}

	
	
	
	public virtual lr_item_core shift_core()
	{
		if (dot_at_end())
		{
			
			throw new internal_error("Attempt to shift past end of an lr_item_core");
		}
		lr_item_core result = new lr_item_core(_the_production, _dot_pos + 1);
		
		return result;
	}

	
	
	public override bool Equals(object other)
	{
		if (!(other is lr_item_core))
		{
			return false;
		}
		bool result = Equals((lr_item_core)other);
		
		return result;
	}

	public virtual int core_hashCode()
	{
		return _core_hash_cache;
	}

	public override int GetHashCode()
	{
		return _core_hash_cache;
	}

	
	
	protected internal virtual int obj_hash()
	{
		int result = base.GetHashCode();
		
		return result;
	}

	
	
	public override string ToString()
	{
		//Discarded unreachable code: IL_0008
		internal_error internal_error2;
		try
		{
			return to_simple_string();
		}
		catch (internal_error x)
		{
			internal_error2 = x;
		}
		internal_error internal_error3 = internal_error2;
		internal_error3.crash();
		return null;
	}
}
