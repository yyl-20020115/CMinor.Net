

using java.lang;


namespace java_cup.runtime;

public class virtual_parse_stack
{
	protected internal Stack real_stack;

	protected internal int real_next;

	protected internal Stack vstack;

	
	[Throws(new string[] { "System.Exception" })]
	
	public virtual_parse_stack(Stack shadowing_stack)
	{
		if (shadowing_stack == null)
		{
			
			throw new Exception("Internal parser error: attempt to create null virtual stack");
		}
		real_stack = shadowing_stack;
		vstack = new Stack();
		real_next = 0;
		get_from_real();
	}

	
	[Throws(new string[] { "System.Exception" })]
	
	public virtual int top()
	{
		if (vstack.empty())
		{
			
			throw new Exception("Internal parser error: top() called on empty virtual stack");
		}
		int result = ((Integer)vstack.peek()).intValue();
		
		return result;
	}

	
	
	public virtual void push(int state_num)
	{
		vstack.push(new Integer(state_num));
	}

	
	[Throws(new string[] { "System.Exception" })]
	
	public virtual void pop()
	{
		if (vstack.empty())
		{
			
			throw new Exception("Internal parser error: pop from empty virtual stack");
		}
		vstack.pop();
		if (vstack.empty())
		{
			get_from_real();
		}
	}

	
	
	protected internal virtual void get_from_real()
	{
		if (real_next < real_stack.size())
		{
			Symbol symbol = (Symbol)real_stack.elementAt(real_stack.size() - 1 - real_next);
			real_next++;
			Stack stack = vstack;
			
			stack.push(new Integer(symbol.parse_state));
		}
	}

	
	
	public virtual bool empty()
	{
		bool result = vstack.empty();
		
		return result;
	}
}
