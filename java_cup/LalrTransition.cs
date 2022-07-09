



namespace JavaCUP;

public class LalrTransition
{
	protected internal _Symbol _on_symbol;

	protected internal LalrState _to_state;

	protected internal LalrTransition _next;

	
	
	
	public LalrTransition(_Symbol on_sym, LalrState to_st, LalrTransition nxt)
	{
		if (on_sym == null)
		{
			
			throw new InternalError("Attempt to create transition on null symbol");
		}
		if (to_st == null)
		{
			
			throw new InternalError("Attempt to create transition to null state");
		}
		_on_symbol = on_sym;
		_to_state = to_st;
		_next = nxt;
	}

	public virtual _Symbol on_symbol()
	{
		return _on_symbol;
	}

	public virtual LalrState to_state()
	{
		return _to_state;
	}

	public virtual LalrTransition next()
	{
		return _next;
	}

	
	
	
	public LalrTransition(_Symbol on_sym, LalrState to_st)
		: this(on_sym, to_st, null)
	{
	}

	
	
	public override string ToString()
	{
		string str = ("transition on ")+(on_symbol().Name)+(" to state [")
			;
		str = (str)+(_to_state.Index());
		return (str)+("]");
	}
}
