

using IKVM.Runtime;



namespace java_cup;

public class symbol_set
{
	protected internal Hashtable _all;

	
	
	public symbol_set()
	{
		_all = new Hashtable(11);
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	
	public virtual bool add(symbol sym)
	{
		not_null(sym);
		object obj = _all.put(sym.name(), sym);
		return obj == null;
	}

	
	
	public virtual Enumeration all()
	{
		Enumeration result = _all.elements();
		
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

	
	
	public virtual bool contains(symbol sym)
	{
		bool result = _all.containsKey(sym.name());
		
		return result;
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	
	public virtual bool is_subset_of(symbol_set other)
	{
		not_null(other);
		Enumeration enumeration = all();
		while (enumeration.hasMoreElements())
		{
			if (!other.contains((symbol)enumeration.nextElement()))
			{
				return false;
			}
		}
		return true;
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	
	public virtual void remove(symbol sym)
	{
		not_null(sym);
		_all.remove(sym.name());
	}

	
	
	public virtual int size()
	{
		int result = _all.size();
		
		return result;
	}

	
	
	public virtual bool equals(symbol_set other)
	{
		//Discarded unreachable code: IL_001c
		if (other == null || other.size() != size())
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
			internal_error2 = ByteCodeHelper.MapException<internal_error>(x, ByteCodeHelper.MapFlags.NoRemapping);
		}
		internal_error internal_error3 = internal_error2;
		internal_error3.crash();
		return false;
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	
	public symbol_set(symbol_set other)
	{
		_all = new Hashtable(11);
		not_null(other);
		_all = (Hashtable)other._all.clone();
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	
	public virtual bool is_superset_of(symbol_set other)
	{
		not_null(other);
		bool result = other.is_subset_of(this);
		
		return result;
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	
	public virtual bool add(symbol_set other)
	{
		int num = 0;
		not_null(other);
		Enumeration enumeration = other.all();
		while (enumeration.hasMoreElements())
		{
			num = ((add((symbol)enumeration.nextElement()) || num != 0) ? 1 : 0);
		}
		return (byte)num != 0;
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	
	public virtual void remove(symbol_set other)
	{
		not_null(other);
		Enumeration enumeration = other.all();
		while (enumeration.hasMoreElements())
		{
			remove((symbol)enumeration.nextElement());
		}
	}

	
	
	public override bool equals(object other)
	{
		if (!(other is symbol_set))
		{
			return false;
		}
		bool result = equals((symbol_set)other);
		
		return result;
	}

	
	
	public override int hashCode()
	{
		int num = 0;
		Enumeration enumeration = all();
		int num2 = 0;
		while (enumeration.hasMoreElements() && num2 < 5)
		{
			num ^= Object.instancehelper_hashCode((symbol)enumeration.nextElement());
			num2++;
		}
		return num;
	}

	
	[LineNumberTable(new byte[]
	{
		160, 97, 102, 98, 143, 99, 157, 130, 159, 9,
		155
	})]
	public override string ToString()
	{
		string str = "{";
		int num = 0;
		Enumeration enumeration = all();
		while (enumeration.hasMoreElements())
		{
			if (num != 0)
			{
				str = (str)+(", ");
			}
			else
			{
				num = 1;
			}
			str = (str)+(((symbol)enumeration.nextElement()).name());
		}
		return (str)+("}");
	}
}
