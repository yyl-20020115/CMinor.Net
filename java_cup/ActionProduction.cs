
namespace JavaCUP;

public class ActionProduction : Production
{
	protected internal Production _base_production;
	
	public ActionProduction(Production @base, NonTerminal lhs_sym, ProductionPart[] rhs_parts, int rhs_len, string action_str)
		: base(lhs_sym, rhs_parts, rhs_len, action_str)
	{
		_base_production = @base;
	}

	public virtual Production base_production()
	{
		return _base_production;
	}

	
	static ActionProduction()
	{
		
	}
}
