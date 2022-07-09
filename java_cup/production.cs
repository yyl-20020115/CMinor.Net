

using IKVM.Runtime;



namespace JavaCUP;

public class production
{
	protected internal static Hashtable _all;

	protected internal static int next_index;

	protected internal symbol_part _lhs;

	protected internal int _rhs_prec;

	protected internal int _rhs_assoc;

	protected internal production_part[] _rhs;

	protected internal int _rhs_length;

	protected internal action_part _action;

	protected internal int _index;

	protected internal int _num_reductions;

	protected internal bool _nullable_known;

	protected internal bool _nullable;

	protected internal terminal_set _first_set;

	
	
	public static void ___003Cclinit_003E()
	{
	}

	
	[LineNumberTable(new byte[]
	{
		161,
		50,
		230,
		71,
		137,
		138,
		169,
		136,
		byte.MaxValue,
		19,
		55,
		233,
		79
	})]
	protected internal virtual string declare_labels(production_part[] rhs, int rhs_len, string final_action)
	{
		string text = "";
		for (int i = 0; i < rhs_len; i++)
		{
			if (!rhs[i].is_action())
			{
				symbol_part symbol_part2 = (symbol_part)rhs[i];
				if (symbol_part2.label() != null)
				{
					text = (text)+(make_declaration(symbol_part2.label(), symbol_part2.the_symbol().stack_type(), rhs_len - i - 1));
				}
			}
		}
		return text;
	}

	
	[LineNumberTable(new byte[]
	{
		161, 89, 136, 98, 98, 169, 216, 164, 200, 167,
		217, 191, 23, 230, 69, 230, 35, 233, 99
	})]
	protected internal virtual int merge_adjacent_actions(production_part[] rhs_parts, int len)
	{
		if (rhs_parts == null || len == 0)
		{
			return 0;
		}
		int num = 0;
		int num2 = -1;
		for (int i = 0; i < len; i++)
		{
			if (num2 < 0 || !rhs_parts[num2].is_action() || !rhs_parts[i].is_action())
			{
				num2++;
				if (num2 != i)
				{
					rhs_parts[num2] = null;
				}
			}
			if (num2 != i)
			{
				if (rhs_parts[num2] != null && rhs_parts[num2].is_action() && rhs_parts[i].is_action())
				{
					rhs_parts[num2] = new action_part((((action_part)rhs_parts[num2]).code_string())+(((action_part)rhs_parts[i]).code_string()));
					num++;
				}
				else
				{
					rhs_parts[num2] = rhs_parts[i];
				}
			}
		}
		return len - num;
	}

	
	
	protected internal virtual action_part strip_trailing_action(production_part[] rhs_parts, int len)
	{
		if (rhs_parts == null || len == 0)
		{
			return null;
		}
		if (rhs_parts[len - 1].is_action())
		{
			action_part result = (action_part)rhs_parts[len - 1];
			rhs_parts[len - 1] = null;
			return result;
		}
		return null;
	}

	
	
	[LineNumberTable(new byte[]
	{
		161, 187, 110, 209, 179, 102, 167, 223, 22, 238,
		48, 233, 82
	})]
	protected internal virtual void remove_embedded_actions()
	{
		for (int i = 0; i < rhs_length(); i++)
		{
			if (rhs(i).is_action())
			{
				string str = declare_labels(_rhs, i, "");
				non_terminal non_terminal2 = non_terminal.create_new();
				non_terminal2.is_embedded_action = true;
				action_production.___003Cclinit_003E();
				new action_production(this, non_terminal2, null, 0, (str)+(((action_part)rhs(i)).code_string()));
				_rhs[i] = new symbol_part(non_terminal2);
			}
		}
	}

	
	
	[LineNumberTable(new byte[]
	{
		12,
		232,
		160,
		191,
		103,
		231,
		124,
		231,
		75,
		231,
		72,
		231,
		74,
		235,
		158,
		235,
		162,
		100,
		105,
		99,
		138,
		167,
		99,
		240,
		77,
		100,
		108,
		134,
		226,
		69,
		171,
		100,
		133,
		185,
		166,
		172,
		179,
		110,
		241,
		72,
		113,
		112,
		109,
		115,
		120,
		122,
		159,
		4,
		byte.MaxValue,
		4,
		57,
		235,
		79,
		107,
		107,
		191,
		9,
		173,
		166,
		179,
		188,
		105
	})]
	public production(non_terminal lhs_sym, production_part[] rhs_parts, int rhs_l, string action_str)
	{
		_rhs_prec = -1;
		_rhs_assoc = -1;
		_num_reductions = 0;
		_nullable_known = false;
		_nullable = false;
		_first_set = new terminal_set();
		int rhs_len = rhs_l;
		if (rhs_l >= 0)
		{
			_rhs_length = rhs_l;
		}
		else if (rhs_parts != null)
		{
			_rhs_length = rhs_parts.Length;
		}
		else
		{
			_rhs_length = 0;
		}
		if (lhs_sym == null)
		{
			
			throw new internal_error("Attempt to construct a production with a null LHS");
		}
		if (rhs_l > 0)
		{
			rhs_len = ((!rhs_parts[rhs_l - 1].is_action()) ? rhs_l : (rhs_l - 1));
		}
		string text = declare_labels(rhs_parts, rhs_len, action_str);
		action_str = ((action_str != null) ? (text)+(action_str).ToString() : text);
		lhs_sym.note_use();
		_lhs = new symbol_part(lhs_sym);
		_rhs_length = merge_adjacent_actions(rhs_parts, _rhs_length);
		action_part action_part2 = strip_trailing_action(rhs_parts, _rhs_length);
		if (action_part2 != null)
		{
			_rhs_length--;
		}
		_rhs = new production_part[_rhs_length];
		for (int i = 0; i < _rhs_length; i++)
		{
			_rhs[i] = rhs_parts[i];
			if (!_rhs[i].is_action())
			{
				((symbol_part)_rhs[i]).the_symbol().note_use();
				if (((symbol_part)_rhs[i]).the_symbol() is terminal)
				{
					_rhs_prec = ((terminal)((symbol_part)_rhs[i]).the_symbol()).precedence_num();
					_rhs_assoc = ((terminal)((symbol_part)_rhs[i]).the_symbol()).precedence_side();
				}
			}
		}
		if (action_str == null)
		{
			action_str = "";
		}
		if (action_part2 != null && action_part2.code_string() != null)
		{
			action_str = (action_str)+("\t\t")+(action_part2.code_string())
				;
		}
		_action = new action_part(action_str);
		remove_embedded_actions();
		_index = next_index++;
		Hashtable hashtable = _all;
		
		hashtable.put((_index), this);
		lhs_sym.add_production(this);
	}

	public virtual void set_precedence_num(int prec_num)
	{
		_rhs_prec = prec_num;
	}

	public virtual void set_precedence_side(int prec_side)
	{
		_rhs_assoc = prec_side;
	}

	protected internal static bool is_id_start(char c)
	{
		return ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || c == '_') ? true : false;
	}

	
	[LineNumberTable(new byte[]
	{
		161,
		22,
		106,
		byte.MaxValue,
		160,
		102,
		70,
		166
	})]
	protected internal virtual string make_declaration(string labelname, string stack_type, int offset)
	{
		string str = ((!emit.lr_values()) ? "" : ("\t\tint ")+(labelname)+("left = ((java_cup.runtime.Symbol)")
			+(emit.pre("stack"))
			+(".elementAt(")
			+(emit.pre("top"))
			+("-")
			+(offset)
			+(")).left;\n")
			+("\t\tint ")
			+(labelname)
			+("right = ((java_cup.runtime.Symbol)")
			+(emit.pre("stack"))
			+(".elementAt(")
			+(emit.pre("top"))
			+("-")
			+(offset)
			+(")).right;\n")
			);
		string result = (str)+("\t\t")+(stack_type)
			+(" ")
			+(labelname)
			+(" = (")
			+(stack_type)
			+(")((")
			+("java_cup.runtime.Symbol) ")
			+(emit.pre("stack"))
			+(".elementAt(")
			+(emit.pre("top"))
			+("-")
			+(offset)
			+(")).value;\n")
			;
		
		return result;
	}

	public virtual int rhs_length()
	{
		return _rhs_length;
	}

	
	
	
	public virtual production_part rhs(int indx)
	{
		if (indx >= 0 && indx < _rhs_length)
		{
			return _rhs[indx];
		}
		
		throw new internal_error("Index out of range for right hand side of production");
	}

	public virtual bool nullable_known()
	{
		return _nullable_known;
	}

	public virtual bool nullable()
	{
		return _nullable;
	}

	internal virtual bool set_nullable(bool P_0)
	{
		_nullable_known = true;
		_nullable = P_0;
		return P_0;
	}

	public virtual terminal_set first_set()
	{
		return _first_set;
	}

	
	public virtual bool Equals(production other)
	{
		if (other == null)
		{
			return false;
		}
		return other._index == _index;
	}

	public virtual int index()
	{
		return _index;
	}

	public virtual symbol_part lhs()
	{
		return _lhs;
	}

	public virtual action_part action()
	{
		return _action;
	}

	
	
	
	public production(non_terminal lhs_sym, production_part[] rhs_parts, int rhs_l)
		: this(lhs_sym, rhs_parts, rhs_l, null)
	{
	}

	
	
	
	public production(non_terminal lhs_sym, production_part[] rhs_parts, int rhs_l, string action_str, int prec_num, int prec_side)
		: this(lhs_sym, rhs_parts, rhs_l, action_str)
	{
		set_precedence_num(prec_num);
		set_precedence_side(prec_side);
	}

	
	
	
	public production(non_terminal lhs_sym, production_part[] rhs_parts, int rhs_l, int prec_num, int prec_side)
		: this(lhs_sym, rhs_parts, rhs_l, null)
	{
		set_precedence_num(prec_num);
		set_precedence_side(prec_side);
	}

	
	
	public static Enumeration all()
	{
		Enumeration result = _all.elements();
		
		return result;
	}

	
	
	public static production find(int indx)
	{
		return (production)_all.get((indx));
	}

	
	
	public static int number()
	{
		int result = _all.Count;
		
		return result;
	}

	public virtual int precedence_num()
	{
		return _rhs_prec;
	}

	public virtual int precedence_side()
	{
		return _rhs_assoc;
	}

	public virtual int num_reductions()
	{
		return _num_reductions;
	}

	
	public virtual void note_reduction_use()
	{
		_num_reductions++;
	}

	
	
	protected internal static bool is_id_char(char c)
	{
		return (is_id_start(c) || (c >= '0' && c <= '9')) ? true : false;
	}

	
	
	[LineNumberTable(new byte[]
	{
		161, 221, 177, 168, 202, 139, 168, 136, 172, 104,
		138, 141, 226, 49, 230, 84
	})]
	public virtual bool check_nullable()
	{
		if (nullable_known())
		{
			bool result = nullable();
			
			return result;
		}
		if (rhs_length() == 0)
		{
			bool result2 = set_nullable(true);
			
			return result2;
		}
		for (int i = 0; i < rhs_length(); i++)
		{
			production_part production_part2 = rhs(i);
			if (!production_part2.is_action())
			{
				symbol symbol2 = ((symbol_part)production_part2).the_symbol();
				if (!symbol2.is_non_term())
				{
					bool result3 = set_nullable(false);
					
					return result3;
				}
				if (!((non_terminal)symbol2).nullable())
				{
					return false;
				}
			}
		}
		bool result4 = set_nullable(true);
		
		return result4;
	}

	
	
	[LineNumberTable(new byte[]
	{
		162, 18, 174, 142, 178, 168, 183, 109, 226, 69,
		178, 226, 41, 233, 93
	})]
	public virtual terminal_set check_first_set()
	{
		for (int i = 0; i < rhs_length(); i++)
		{
			if (!rhs(i).is_action())
			{
				symbol symbol2 = ((symbol_part)rhs(i)).the_symbol();
				if (!symbol2.is_non_term())
				{
					_first_set.Add((terminal)symbol2);
					break;
				}
				_first_set.Add(((non_terminal)symbol2).first_set());
				if (!((non_terminal)symbol2).nullable())
				{
					break;
				}
			}
		}
		terminal_set result = first_set();
		
		return result;
	}

	
	
	public override bool Equals(object other)
	{
		if (!(other is production))
		{
			return false;
		}
		bool result = Equals((production)other);
		
		return result;
	}

	public override int GetHashCode()
	{
		return _index * 13;
	}

	
	[LineNumberTable(new byte[]
	{
		162,
		88,
		127,
		11,
		127,
		17,
		123,
		107,
		63,
		8,
		134,
		123,
		117,
		159,
		22,
		104,
		104,
		157,
		byte.MaxValue,
		14,
		70,
		226,
		59,
		161,
		102,
		162
	})]
	public override string ToString()
	{
		internal_error internal_error2;
		try
		{
			string str = ("production [")+(index())+("]: ")
				;
			str = (str)+((lhs() == null) ? "$$NULL-LHS$$" : lhs());
			str = (str)+(" :: = ");
			for (int i = 0; i < rhs_length(); i++)
			{
				str = (str)+(rhs(i))+(" ")
					;
			}
			str = (str)+(";");
			if (action() != null && action().code_string() != null)
			{
				str = (str)+(" {")+(action().code_string())
					+("}")
					;
			}
			if (nullable_known())
			{
				if (nullable())
				{
					return (str)+("[NULLABLE]");
				}
				return (str)+("[NOT NULLABLE]");
			}
			return str;
		}
		catch (internal_error x)
		{
			internal_error2 = ByteCodeHelper.MapException<internal_error>(x, ByteCodeHelper.MapFlags.NoRemapping);
		}
		internal_error internal_error3 = internal_error2;
		internal_error3.crash();
		return null;
	}

	
	
	
	public virtual string to_simple_string()
	{
		string str = ((lhs() == null) ? "NULL_LHS" : lhs().the_symbol().name());
		str = (str)+(" ::= ");
		for (int i = 0; i < rhs_length(); i++)
		{
			if (!rhs(i).is_action())
			{
				str = (str)+(((symbol_part)rhs(i)).the_symbol().name())+(" ")
					;
			}
		}
		return str;
	}

	
	static production()
	{
		_all = new Hashtable();
	}
}
