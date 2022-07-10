using System.Collections.Generic;
using System.Text;

namespace JavaCUP;

public class LalrItemSet
{
	protected internal Dictionary<LalrItem, LalrItem> _all=new();

	protected internal int? hashcode_cache;
	
	
	protected internal virtual void not_null(object obj)
	{
		if (obj == null)
		{
			
			throw new InternalError("Null object used in set operation");
		}
	}

	
	
	public virtual IEnumerable<LalrItem> all()
	{
		return _all.Values;
	}

	
	
	public virtual bool Contains(LalrItem itm)
	{
		return _all.ContainsKey(itm);
	}

	
	
	
	public virtual bool is_subset_of(LalrItemSet other)
	{
		not_null(other);
		foreach(var i in all())
		{
			if (!other.Contains(i))
			{
				return false;
			}
		}
		return true;
	}

	
	
	
	public virtual LalrItem Add(LalrItem itm)
	{
		not_null(itm);
		if (_all.TryGetValue(itm,out var lalr_item2))
		{
			lalr_item2.lookahead().Add(itm.lookahead());
			return lalr_item2;
		}
		hashcode_cache = null;
		_all.Add(itm, itm);
		return itm;
	}

	
	
	
	public virtual void Remove(LalrItem itm)
	{
		not_null(itm);
		hashcode_cache = null;
		_all.Remove(itm);
	}

	
	
	
	public LalrItemSet(LalrItemSet other)
	{
		_all = new (11);
		hashcode_cache = null;
		not_null(other);
		_all = new(other._all);
	}



	public virtual int Count => _all.Count;

	
	
	public virtual LalrItem GetOne()
	{
		foreach(var i in all())
		{
			Remove(i);
			return i;
		}
		return null;
	}

	
	
	public virtual bool Equals(LalrItemSet other)
	{
		//Discarded unreachable code: IL_001c
		if (other == null || other.Count != Count)
		{
			return false;
		}
		InternalError internal_error2;
		try
		{
			return is_subset_of(other);
		}
		catch (InternalError x)
		{
			internal_error2 = x;

		}
		InternalError internal_error3 = internal_error2;
		internal_error3.crash();
		return false;
	}

	
	
	public LalrItemSet()
	{
		_all = new (11);
		hashcode_cache = null;
	}

	
	
	public virtual LalrItem find(LalrItem itm)
	{
		return _all.TryGetValue(itm, out var l) ? l : null;
	}

	
	
	
	public virtual bool is_superset_of(LalrItemSet other)
	{
		not_null(other);
		bool result = other.is_subset_of(this);
		
		return result;
	}

	
	
	
	public virtual void Add(LalrItemSet other)
	{
		not_null(other);
		foreach (var l in other.all())
		{
			Add(l);
		}
	}

	
	
	
	public virtual void Remove(LalrItemSet other)
	{
		not_null(other);
		foreach(var l in other.all())
		{
			Remove(l);
		}
	}

	public virtual void compute_closure()
	{
		hashcode_cache = null;
		LalrItemSet lalr_item_set2 = new LalrItemSet(this);
		while (lalr_item_set2.Count > 0)
		{
			LalrItem one = lalr_item_set2.GetOne();
			NonTerminal non_terminal2 = one.dot_before_nt();
			if (non_terminal2 == null)
			{
				continue;
			}
			var other = one.calc_lookahead(one.lookahead());
			int num = (one.lookahead_visible() ? 1 : 0);

			foreach(var prod in non_terminal2.productions())
			{
				LalrItem lalr_item2 = new LalrItem(prod, new TerminalSet(other));
				LalrItem lalr_item3 = Add(lalr_item2);
				if (num != 0)
				{
					one.add_propagate(lalr_item3);
				}
				if (lalr_item3 == lalr_item2)
				{
					lalr_item_set2.Add(lalr_item2);
				}
			}
		}
	}

	
	
	public override bool Equals(object other)
	{
		if (!(other is LalrItemSet))
		{
			return false;
		}
		bool result = Equals((LalrItemSet)other);
		
		return result;
	}

	
	
	public override int GetHashCode()
	{
		int num = 0;
		if (hashcode_cache == null)
		{
			int num2 = 0;
			foreach(var i in all())
			{
				num ^= (i).GetHashCode();
				num2++;
			}
			hashcode_cache = (num);
		}
		int result = hashcode_cache.GetValueOrDefault();
		
		return result;
	}

	
	
	public override string ToString()
	{
		var stringBuilder = new StringBuilder();
		stringBuilder.Append("{\n");
		foreach(var v in all())
		{
			stringBuilder.Append(("  ")+(v)+("\n")
				);
		}
		stringBuilder.Append("}");
		return stringBuilder.ToString();
	}
}
