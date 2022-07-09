
namespace JavaCUP;

public class action_production : production
{
	protected internal production _base_production;
	
	public action_production(production @base, non_terminal lhs_sym, production_part[] rhs_parts, int rhs_len, string action_str)
		: base(lhs_sym, rhs_parts, rhs_len, action_str)
	{
		_base_production = @base;
	}

	public virtual production base_production()
	{
		return _base_production;
	}

	
	static action_production()
	{
		
	}
}
