using System;
using System.Collections.Generic;

namespace JavaCUP;

public class BitSet
{
	protected List<bool> bits;

	public int Count => this.bits.Count;
	public BitSet()
	{
		bits = new List<bool>();
	}

	public BitSet(int size)
	{
		bits = new List<bool>(size);
	}
    public BitSet Clone() => new () { bits = new List<bool>(this.bits) };
    public void Set(int index)
	{
		int d = index - bits.Count;
        while (d++ >= 0)
        {
			bits.Add(false);
        }
		bits[index] = true;
	}
	public void Clear(int index)
	{
		int d = index - bits.Count;
		while (d++ >= 0)
		{
			bits.Add(false);
		}
		bits[index] = false;
	}

	public bool Get(int index) => index >= bits.Count ? false : bits[index];
	public BitSet Not()
	{
		for(int i = 0; i < bits.Count; i++)
        {
			bits[i] = !bits[i];
        }

		return this;
	}

	public BitSet And(BitSet other)
	{
		var m = Math.Max(this.Count, other.Count);
		for (int i = 0; i < bits.Count; i++)
		{
			int a = this.bits[i] ? 1 : 0;
			int b = other.bits[i] ? 1 : 0;
			int c = a & b;
			this.bits[i] = a == 0 ? false : true;
		}

		return this;
	}

	public BitSet Or(BitSet other)
    {
		var m = Math.Max(this.Count, other.Count);
		for (int i = 0; i < bits.Count; i++)
		{
			int a = this.bits[i] ? 1 : 0;
			int b = other.bits[i] ? 1 : 0;
			int c = a | b;
			this.bits[i] = a == 0 ? false : true;
		}

		return this;
	}
	public BitSet Xor(BitSet other)
	{
		var m = Math.Max(this.Count, other.Count);
		for (int i = 0; i < bits.Count; i++)
		{
			int a = this.bits[i] ? 1 : 0;
			int b = other.bits[i] ? 1 : 0;
			int c = a ^ b;
			this.bits[i] = a == 0 ? false : true;
		}

		return this;
	}
}

