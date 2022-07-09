using System;
using System.Collections.Generic;

namespace JavaCUP.Runtime;

public class virtual_parse_stack
{
	protected internal Stack<symbol> real_stack;

	protected internal int real_next;

	protected internal Stack<int> vstack;

	
	public virtual_parse_stack(Stack<symbol> shadowing_stack)
	{
		if (shadowing_stack == null)
		{
			
			throw new Exception("Internal parser error: attempt to create null virtual stack");
		}
		real_stack = shadowing_stack;
		vstack = new Stack<int>();
		real_next = 0;
		get_from_real();
	}

	
	
	
	public virtual int top()
	{
		if (vstack.Count == 0)
		{
			
			throw new Exception("Internal parser error: top() called on empty virtual stack");
		}
		int result = ((int)vstack.Peek());
		
		return result;
	}

	
	
	public virtual void push(int state_num)
	{
		vstack.Push((state_num));
	}

	
	
	
	public virtual void pop()
	{
		if (vstack.Count == 0)
		{
			
			throw new Exception("Internal parser error: pop from empty virtual stack");
		}
		vstack.Pop();
		if (vstack.Count == 0)
		{
			get_from_real();
		}
	}

	
	
	protected internal virtual void get_from_real()
	{
		if (real_next < real_stack.Count)
		{
			Symbol symbol =
				real_stack.elementAt(real_stack.size() - 1 - real_next);
			
			real_next++;
			Stack<int> stack = vstack;
			
			stack.Push((symbol.parse_state));
		}
	}

	
	
	public virtual bool empty()
	{		
		return vstack.Count == 0;
	}
}
