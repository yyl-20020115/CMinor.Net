using System.Collections.Generic;

namespace JavaCUP;

public class SymbolSet
{
	protected internal Dictionary<string, _Symbol> _all = new(11);

	public SymbolSet()
	{
	}
	
	public SymbolSet Clone()
    {
		return new SymbolSet() { _all = new Dictionary<string, _Symbol>(this._all) };
    }
	public virtual bool Add(_Symbol sym)
	{
		NotNull(sym);
		var b = _all.ContainsKey(sym.Name);
		_all.Add(sym.Name, sym);
		return !b;
	}

	
	public virtual IEnumerable<_Symbol> All()
	{
		return _all.Values;
	}

	
	
	
	protected internal virtual void NotNull(object obj)
	{
		if (obj == null)
		{
			
			throw new InternalError("Null object used in set operation");
		}
	}

	
	
	public virtual bool Contains(_Symbol sym)
	{
		return _all.ContainsKey(sym.Name);
	}

	
	
	
	public virtual bool IsSubSetOf(SymbolSet other)
	{
		NotNull(other);
		foreach(var s in this.All())
        {
			if (!other.Contains(s))
				return false;
        }
		return true;
	}

	
	
	
	public virtual void Remove(_Symbol sym)
	{
		NotNull(sym);
		_all.Remove(sym.Name);
	}



    public virtual int Count => _all.Count;



    public virtual bool Equals(SymbolSet other)
	{
		//Discarded unreachable code: IL_001c
		if (other == null || other.Count != Count)
		{
			return false;
		}
		InternalError internal_error2;
		try
		{
			return IsSubSetOf(other);
		}
		catch (InternalError x)
		{
			internal_error2 = x;
		}
		InternalError internal_error3 = internal_error2;
		internal_error3.crash();
		return false;
	}

	
	
	
	public SymbolSet(SymbolSet other)
	{
		_all = new (11);
		NotNull(other);
		_all = new Dictionary<string, _Symbol>(other._all);// other._all.clone();
	}

	
	
	
	public virtual bool IsSuperSetOf(SymbolSet other)
	{
		NotNull(other);
		return other.IsSubSetOf(this);
	}

	
	
	
	public virtual bool Add(SymbolSet other)
	{
		int num = 0;
		NotNull(other);
		foreach (var s in other.All())
		{
			num = (this.Add(s)||num!=0)?1:0;
		}
		return num != 0;
	}

	
	
	
	public virtual void remove(SymbolSet other)
	{
		NotNull(other);
		foreach(var s in other.All())
        {
			this.Remove(s);
        }
	}

	
	
	public override bool Equals(object other)
	{
		if (!(other is SymbolSet))
		{
			return false;
		}
		bool result = Equals((SymbolSet)other);
		
		return result;
	}

	
	
	public override int GetHashCode()
	{
		int num = 0;
		int num2 = 0;
		foreach(var s in this.All())
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
		
		foreach(var symbol in this.All())
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
