using System;
using System.Collections.Generic;

namespace JavaCUP.Runtime;

public class virtual_parse_stack
{
	protected internal Stack<Symbol> real_stack;

	protected internal int real_next;

	protected internal Stack<int> vstack;

	
	public virtual_parse_stack(Stack<Symbol> shadowing_stack)
	{
		if (shadowing_stack == null)
		{
			
			throw new Exception("Internal parser error: attempt to create null virtual stack");
		}
		real_stack = shadowing_stack;
		vstack = new Stack<int>();
		real_next = 0;
		GetFromReal();
	}

	
	
	
	public virtual int Top()
	{
		if (vstack.Count == 0)
		{
			
			throw new Exception("Internal parser error: top() called on empty virtual stack");
		}
		return ((int)vstack.Peek());
	}

	
	
	public virtual void Push(int state_num)
	{
		vstack.Push((state_num));
	}

	
	
	
	public virtual void Pop()
	{
		if (vstack.Count == 0)
		{	
			throw new Exception("Internal parser error: pop from empty virtual stack");
		}
		vstack.Pop();
		if (vstack.Count == 0)
		{
			GetFromReal();
		}
	}

	
	
	protected internal virtual void GetFromReal()
	{
		if (real_next < real_stack.Count)
		{
			Symbol symbol = this.real_stack.ToArray()[this.real_stack.Count - 1 - real_next];
				//real_stack.elementAt(real_stack.Count - 1 - real_next);
			
			real_next++;

			vstack.Push(symbol.parse_state);
		}
	}

    public virtual bool IsEmpty => vstack.Count == 0;
}
