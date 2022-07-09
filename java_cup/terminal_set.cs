
using System.Collections.Generic;

namespace JavaCUP;

public class terminal_set
{
	internal static terminal_set empty_set = new();

	protected internal BitSet _elements = new();

    public static terminal_set EMPTY => empty_set;


    public terminal_set()
	{
		_elements = new BitSet(terminal.number());
	}

	
	public virtual bool Add(terminal_set other)
	{
		IsNotNull(other);
		var obj = _elements.Clone();
		_elements.Or(other._elements);
		return (!_elements.Equals(obj)) ? true : false;
	}

	
	
	
	public virtual bool Add(terminal sym)
	{
		IsNotNull(sym);
		int num = (_elements.Get(sym.index()) ? 1 : 0);
		if (num == 0)
		{
			_elements.Set(sym.index());
		}
		return num != 0;
	}

    public virtual bool IsEmpty => Equals(empty_set);

    public terminal_set(terminal_set other)
	{
		IsNotNull(other);
		_elements = other._elements.Clone();
	}



    public virtual bool Contains(int indx) => _elements.Get(indx);

    public virtual bool InterestWith(terminal_set other)
	{
		IsNotNull(other);
		var bitSet = other._elements.Clone();
		bitSet.Xor(this._elements);
		return !bitSet.Equals(other._elements);
	}

	
	
	
	public virtual bool IsSubsetOf(terminal_set other)
	{
		IsNotNull(other);
		var bitSet = other._elements.Clone();
		bitSet.Or(_elements);
		return bitSet.Equals(other._elements);
	}

	
	
	
	protected internal virtual bool IsNotNull(object obj)
	{
		if (obj == null)
		{	
			throw new internal_error("Null object used in set operation");
		}
		return true;
	}



    public virtual bool Equals(terminal_set other) => other != null && _elements.Equals(other._elements);


    public virtual bool Contains(terminal sym) => IsNotNull(sym) && _elements.Get(sym.index());

    public virtual bool IsSuperSetOf(terminal_set other) => IsNotNull(other) && other.IsSubsetOf(this);




    public virtual void Remove(terminal sym)
	{
		IsNotNull(sym);
		_elements.Clear(sym.index());
	}

    public override bool Equals(object other) => other is terminal_set t && Equals(t);

    public override string ToString()
	{
		string str = "{";
		int num = 0;
		for (int i = 0; i < terminal.number(); i++)
		{
			if (_elements.Get(i))
			{
				if (num != 0)
				{
					str = (str)+(", ");
				}
				else
				{
					num = 1;
				}
				str = (str)+(terminal.find(i).name());
			}
		}
		return (str)+("}");
	}

    public override int GetHashCode()
    {
        int hashCode = -1660102523;
        hashCode = hashCode * -1521134295 + EqualityComparer<BitSet>.Default.GetHashCode(_elements);
        hashCode = hashCode * -1521134295 + IsEmpty.GetHashCode();
        return hashCode;
    }
}
