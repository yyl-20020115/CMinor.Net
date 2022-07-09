
using System.Collections.Generic;

namespace JavaCUP;

public class TerminalSet
{
	internal static TerminalSet empty_set = new();

	protected internal BitSet _elements = new();

    public static TerminalSet EMPTY => empty_set;


    public TerminalSet()
	{
		_elements = new BitSet(Terminal.number());
	}

	
	public virtual bool Add(TerminalSet other)
	{
		IsNotNull(other);
		var obj = _elements.Clone();
		_elements.Or(other._elements);
		return (!_elements.Equals(obj)) ? true : false;
	}

	
	
	
	public virtual bool Add(Terminal sym)
	{
		IsNotNull(sym);
		int num = (_elements.Get(sym.Index) ? 1 : 0);
		if (num == 0)
		{
			_elements.Set(sym.Index);
		}
		return num != 0;
	}

    public virtual bool IsEmpty => Equals(empty_set);

    public TerminalSet(TerminalSet other)
	{
		IsNotNull(other);
		_elements = other._elements.Clone();
	}



    public virtual bool Contains(int indx) => _elements.Get(indx);

    public virtual bool InterestWith(TerminalSet other)
	{
		IsNotNull(other);
		var bitSet = other._elements.Clone();
		bitSet.Xor(this._elements);
		return !bitSet.Equals(other._elements);
	}

	
	
	
	public virtual bool IsSubsetOf(TerminalSet other)
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
			throw new InternalError("Null object used in set operation");
		}
		return true;
	}



    public virtual bool Equals(TerminalSet other) => other != null && _elements.Equals(other._elements);


    public virtual bool Contains(Terminal sym) => IsNotNull(sym) && _elements.Get(sym.Index);

    public virtual bool IsSuperSetOf(TerminalSet other) => IsNotNull(other) && other.IsSubsetOf(this);




    public virtual void Remove(Terminal sym)
	{
		IsNotNull(sym);
		_elements.Clear(sym.Index);
	}

    public override bool Equals(object other) => other is TerminalSet t && Equals(t);

    public override string ToString()
	{
		string str = "{";
		int num = 0;
		for (int i = 0; i < Terminal.number(); i++)
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
				str = (str)+(Terminal.find(i).Name);
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
