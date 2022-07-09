

using java.lang;

namespace java_cup;

public class lalr_transition
{
	protected internal symbol _on_symbol;

	protected internal lalr_state _to_state;

	protected internal lalr_transition _next;

	
	[Throws(new string[] { "java_cup.internal_error" })]
	
	public lalr_transition(symbol on_sym, lalr_state to_st, lalr_transition nxt)
	{
		if (on_sym == null)
		{
			
			throw new internal_error("Attempt to create transition on null symbol");
		}
		if (to_st == null)
		{
			
			throw new internal_error("Attempt to create transition to null state");
		}
		_on_symbol = on_sym;
		_to_state = to_st;
		_next = nxt;
	}

	public virtual symbol on_symbol()
	{
		return _on_symbol;
	}

	public virtual lalr_state to_state()
	{
		return _to_state;
	}

	public virtual lalr_transition next()
	{
		return _next;
	}

	
	[Throws(new string[] { "java_cup.internal_error" })]
	
	public lalr_transition(symbol on_sym, lalr_state to_st)
		: this(on_sym, to_st, null)
	{
	}

	
	
	public override string toString()
	{
		string str = new StringBuilder().append("transition on ").append(on_symbol().name()).append(" to state [")
			.toString();
		str = new StringBuilder().append(str).append(_to_state.index()).toString();
		return new StringBuilder().append(str).append("]").toString();
	}
}
