

using IKVM.Runtime;
using java.lang;


namespace java_cup;

public class lalr_item_set
{
	protected internal Hashtable _all;

	protected internal Integer hashcode_cache;

	
	[Throws(new string[] { "java_cup.internal_error" })]
	
	protected internal virtual void not_null(object obj)
	{
		if (obj == null)
		{
			
			throw new internal_error("Null object used in set operation");
		}
	}

	
	
	public virtual Enumeration all()
	{
		Enumeration result = _all.elements();
		
		return result;
	}

	
	
	public virtual bool contains(lalr_item itm)
	{
		bool result = _all.containsKey(itm);
		
		return result;
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	
	public virtual bool is_subset_of(lalr_item_set other)
	{
		not_null(other);
		Enumeration enumeration = all();
		while (enumeration.hasMoreElements())
		{
			if (!other.contains((lalr_item)enumeration.nextElement()))
			{
				return false;
			}
		}
		return true;
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	
	public virtual lalr_item add(lalr_item itm)
	{
		not_null(itm);
		lalr_item lalr_item2 = (lalr_item)_all.get(itm);
		if (lalr_item2 != null)
		{
			lalr_item2.lookahead().add(itm.lookahead());
			return lalr_item2;
		}
		hashcode_cache = null;
		_all.put(itm, itm);
		return itm;
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	
	public virtual void remove(lalr_item itm)
	{
		not_null(itm);
		hashcode_cache = null;
		_all.remove(itm);
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	
	public lalr_item_set(lalr_item_set other)
	{
		_all = new Hashtable(11);
		hashcode_cache = null;
		not_null(other);
		_all = (Hashtable)other._all.clone();
	}

	
	
	public virtual int size()
	{
		int result = _all.size();
		
		return result;
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	
	public virtual lalr_item get_one()
	{
		Enumeration enumeration = all();
		if (enumeration.hasMoreElements())
		{
			lalr_item lalr_item2 = (lalr_item)enumeration.nextElement();
			remove(lalr_item2);
			return lalr_item2;
		}
		return null;
	}

	
	
	public virtual bool equals(lalr_item_set other)
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

	
	
	public lalr_item_set()
	{
		_all = new Hashtable(11);
		hashcode_cache = null;
	}

	
	
	public virtual lalr_item find(lalr_item itm)
	{
		return (lalr_item)_all.get(itm);
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	
	public virtual bool is_superset_of(lalr_item_set other)
	{
		not_null(other);
		bool result = other.is_subset_of(this);
		
		return result;
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	
	public virtual void add(lalr_item_set other)
	{
		not_null(other);
		Enumeration enumeration = other.all();
		while (enumeration.hasMoreElements())
		{
			add((lalr_item)enumeration.nextElement());
		}
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	
	public virtual void remove(lalr_item_set other)
	{
		not_null(other);
		Enumeration enumeration = other.all();
		while (enumeration.hasMoreElements())
		{
			remove((lalr_item)enumeration.nextElement());
		}
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	[LineNumberTable(new byte[]
	{
		160, 138, 167, 167, 172, 167, 103, 163, 173, 168,
		145, 174, 207, 138, 100, 168, 166, 235, 69
	})]
	public virtual void compute_closure()
	{
		hashcode_cache = null;
		lalr_item_set lalr_item_set2 = new lalr_item_set(this);
		while (lalr_item_set2.size() > 0)
		{
			lalr_item one = lalr_item_set2.get_one();
			non_terminal non_terminal2 = one.dot_before_nt();
			if (non_terminal2 == null)
			{
				continue;
			}
			terminal_set other = one.calc_lookahead(one.lookahead());
			int num = (one.lookahead_visible() ? 1 : 0);
			Enumeration enumeration = non_terminal2.productions();
			while (enumeration.hasMoreElements())
			{
				production prod = (production)enumeration.nextElement();
				lalr_item lalr_item2 = new lalr_item(prod, new terminal_set(other));
				lalr_item lalr_item3 = add(lalr_item2);
				if (num != 0)
				{
					one.add_propagate(lalr_item3);
				}
				if (lalr_item3 == lalr_item2)
				{
					lalr_item_set2.add(lalr_item2);
				}
			}
		}
	}

	
	
	public override bool equals(object other)
	{
		if (!(other is lalr_item_set))
		{
			return false;
		}
		bool result = equals((lalr_item_set)other);
		
		return result;
	}

	
	
	public override int hashCode()
	{
		int num = 0;
		if (hashcode_cache == null)
		{
			Enumeration enumeration = all();
			int num2 = 0;
			while (enumeration.hasMoreElements())
			{
				num ^= ((lalr_item)enumeration.nextElement()).hashCode();
				num2++;
			}
			hashcode_cache = new Integer(num);
		}
		int result = hashcode_cache.intValue();
		
		return result;
	}

	
	
	public override string toString()
	{
		StringBuilder stringBuffer = new StringBuilder();
		stringBuffer.append("{\n");
		Enumeration enumeration = all();
		while (enumeration.hasMoreElements())
		{
			stringBuffer.append(new StringBuilder().append("  ").append((lalr_item)enumeration.nextElement()).append("\n")
				.toString());
		}
		stringBuffer.append("}");
		string result = stringBuffer.toString();
		
		return result;
	}
}