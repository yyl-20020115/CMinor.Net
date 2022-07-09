using System.Collections.Generic;

namespace JavaCUP;

public class symbol_set
{
	protected internal Dictionary<string, _Symbol> _all = new(11);

	public symbol_set()
	{
	}
	
	public symbol_set Clone()
    {
		return new symbol_set() { _all = new Dictionary<string, _Symbol>(this._all) };
    }
	public virtual bool add(_Symbol sym)
	{
		not_null(sym);
		var b = _all.ContainsKey(sym.Name);
		_all.Add(sym.Name, sym);
		return !b;
	}

	
	
	public virtual IEnumerable<_Symbol> all()
	{
		return _all.Values;
	}

	
	
	
	protected internal virtual void not_null(object obj)
	{
		if (obj == null)
		{
			
			throw new internal_error("Null object used in set operation");
		}
	}

	
	
	public virtual bool contains(_Symbol sym)
	{
		return _all.ContainsKey(sym.Name);
	}

	
	
	
	public virtual bool is_subset_of(symbol_set other)
	{
		not_null(other);
		foreach(var s in this.all())
        {
			if (!other.contains(s))
				return false;
        }
		return true;
	}

	
	
	
	public virtual void remove(_Symbol sym)
	{
		not_null(sym);
		_all.Remove(sym.Name);
	}



    public virtual int Count => _all.Count;



    public virtual bool Equals(symbol_set other)
	{
		//Discarded unreachable code: IL_001c
		if (other == null || other.Count != Count)
		{
			return false;
		}
		internal_error internal_error2;
		try
		{
			return is_subset_of(other);
		}
		catch (internal_error x)
		{
			internal_error2 = x;
		}
		internal_error internal_error3 = internal_error2;
		internal_error3.crash();
		return false;
	}

	
	
	
	public symbol_set(symbol_set other)
	{
		_all = new (11);
		not_null(other);
		_all = new Dictionary<string, _Symbol>(other._all);// other._all.clone();
	}

	
	
	
	public virtual bool is_superset_of(symbol_set other)
	{
		not_null(other);
		bool result = other.is_subset_of(this);
		
		return result;
	}

	
	
	
	public virtual bool add(symbol_set other)
	{
		int num = 0;
		not_null(other);
		foreach (var s in other.all())
		{
			num = (this.add(s)||num!=0)?1:0;
		}
		return num != 0;
	}

	
	
	
	public virtual void remove(symbol_set other)
	{
		not_null(other);
		foreach(var s in other.all())
        {
			this.remove(s);
        }
	}

	
	
	public override bool Equals(object other)
	{
		if (!(other is symbol_set))
		{
			return false;
		}
		bool result = Equals((symbol_set)other);
		
		return result;
	}

	
	
	public override int GetHashCode()
	{
		int num = 0;
		int num2 = 0;
		foreach(var s in this.all())
        {
			if (num2++ >= 5) break;
			num ^= s.GetHashCode();
        }
		return num;
	}

	
	public override string ToString()
	{
		string str = "{";
		int num = 0;
		
		foreach(var symbol in this.all())
		{
			if (num != 0)
			{
				str = (str)+(", ");
			}
			else
			{
				num = 1;
			}
			str = (str)+symbol.Name;
		}
		return (str)+("}");
	}
}
