

using java.lang;


namespace java_cup;

public class terminal_set
{
	internal static terminal_set ___003C_003EEMPTY;

	protected internal BitSet _elements;

	[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static terminal_set EMPTY
	{
		
		get
		{
			return ___003C_003EEMPTY;
		}
	}

	
	
	public terminal_set()
	{
		_elements = new BitSet(terminal.number());
	}

	
	public virtual bool add(terminal_set other)
	{
		not_null(other);
		BitSet obj = (BitSet)_elements.clone();
		_elements.or(other._elements);
		return (!_elements.equals(obj)) ? true : false;
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	
	public virtual bool add(terminal sym)
	{
		not_null(sym);
		int num = (_elements.get(sym.index()) ? 1 : 0);
		if (num == 0)
		{
			_elements.set(sym.index());
		}
		return (byte)num != 0;
	}

	
	
	public virtual bool empty()
	{
		bool result = equals(___003C_003EEMPTY);
		
		return result;
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	
	public terminal_set(terminal_set other)
	{
		not_null(other);
		_elements = (BitSet)other._elements.clone();
	}

	
	
	public virtual bool contains(int indx)
	{
		bool result = _elements.get(indx);
		
		return result;
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	
	public virtual bool intersects(terminal_set other)
	{
		not_null(other);
		BitSet bitSet = (BitSet)other._elements.clone();
		bitSet.xor(_elements);
		return (!bitSet.equals(other._elements)) ? true : false;
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	
	public virtual bool is_subset_of(terminal_set other)
	{
		not_null(other);
		BitSet bitSet = (BitSet)other._elements.clone();
		bitSet.or(_elements);
		bool result = bitSet.equals(other._elements);
		
		return result;
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	
	protected internal virtual void not_null(object obj)
	{
		if (obj == null)
		{
			
			throw new internal_error("Null object used in set operation");
		}
	}

	
	
	public virtual bool equals(terminal_set other)
	{
		if (other == null)
		{
			return false;
		}
		bool result = _elements.equals(other._elements);
		
		return result;
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	
	public virtual bool contains(terminal sym)
	{
		not_null(sym);
		bool result = _elements.get(sym.index());
		
		return result;
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	
	public virtual bool is_superset_of(terminal_set other)
	{
		not_null(other);
		bool result = other.is_subset_of(this);
		
		return result;
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	
	public virtual void remove(terminal sym)
	{
		not_null(sym);
		_elements.clear(sym.index());
	}

	
	
	public override bool equals(object other)
	{
		if (!(other is terminal_set))
		{
			return false;
		}
		bool result = equals((terminal_set)other);
		
		return result;
	}

	
	[LineNumberTable(new byte[]
	{
		160,
		117,
		102,
		98,
		141,
		142,
		99,
		157,
		130,
		byte.MaxValue,
		2,
		55,
		233,
		76,
		155
	})]
	public override string toString()
	{
		string str = "{";
		int num = 0;
		for (int i = 0; i < terminal.number(); i++)
		{
			if (_elements.get(i))
			{
				if (num != 0)
				{
					str = new StringBuilder().append(str).append(", ").toString();
				}
				else
				{
					num = 1;
				}
				str = new StringBuilder().append(str).append(terminal.find(i).name()).toString();
			}
		}
		return new StringBuilder().append(str).append("}").toString();
	}

	
	static terminal_set()
	{
		___003C_003EEMPTY = new terminal_set();
	}
}