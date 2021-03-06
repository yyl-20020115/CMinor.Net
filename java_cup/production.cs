using System.Collections.Generic;

namespace JavaCUP;

public class Production
{
	protected internal static Dictionary<int, Production> _all = new();

	protected internal static int next_index;

	protected internal SymbolPart _lhs;

	protected internal int _rhs_prec;

	protected internal int _rhs_assoc;

	protected internal ProductionPart[] _rhs;

	protected internal int _rhs_length;

	protected internal ActionPart _action;

	protected internal int _index;

	protected internal int _num_reductions;

	protected internal bool _nullable_known;

	protected internal bool _nullable;

	protected internal TerminalSet _first_set;

	
	protected internal virtual string declare_labels(ProductionPart[] rhs, int rhs_len, string final_action)
	{
		string text = "";
		for (int i = 0; i < rhs_len; i++)
		{
			if (!rhs[i].is_action())
			{
				SymbolPart symbol_part2 = (SymbolPart)rhs[i];
				if (symbol_part2.Label!= null)
				{
					text = (text)+(make_declaration(symbol_part2.Label, symbol_part2.the_symbol().StackType, rhs_len - i - 1));
				}
			}
		}
		return text;
	}

	
	protected internal virtual int merge_adjacent_actions(ProductionPart[] rhs_parts, int len)
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
					rhs_parts[num2] = new ActionPart((((ActionPart)rhs_parts[num2]).CodeString)+(((ActionPart)rhs_parts[i]).CodeString));
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

	
	
	protected internal virtual ActionPart strip_trailing_action(ProductionPart[] rhs_parts, int len)
	{
		if (rhs_parts == null || len == 0)
		{
			return null;
		}
		if (rhs_parts[len - 1].is_action())
		{
			ActionPart result = (ActionPart)rhs_parts[len - 1];
			rhs_parts[len - 1] = null;
			return result;
		}
		return null;
	}

	
	
	protected internal virtual void remove_embedded_actions()
	{
		for (int i = 0; i < rhs_length(); i++)
		{
			if (rhs(i).is_action())
			{
				string str = declare_labels(_rhs, i, "");
				NonTerminal non_terminal2 = NonTerminal.create_new();
				non_terminal2.is_embedded_action = true;
				new ActionProduction(this, non_terminal2, null, 0, (str)+(((ActionPart)rhs(i)).CodeString));
				_rhs[i] = new SymbolPart(non_terminal2);
			}
		}
	}

	
	
	public Production(NonTerminal lhs_sym, ProductionPart[] rhs_parts, int rhs_l, string action_str)
	{
		_rhs_prec = -1;
		_rhs_assoc = -1;
		_num_reductions = 0;
		_nullable_known = false;
		_nullable = false;
		_first_set = new TerminalSet();
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
			
			throw new InternalError("Attempt to construct a production with a null LHS");
		}
		if (rhs_l > 0)
		{
			rhs_len = ((!rhs_parts[rhs_l - 1].is_action()) ? rhs_l : (rhs_l - 1));
		}
		string text = declare_labels(rhs_parts, rhs_len, action_str);
		action_str = ((action_str != null) ? (text)+(action_str).ToString() : text);
		lhs_sym.NoteUse();
		_lhs = new SymbolPart(lhs_sym);
		_rhs_length = merge_adjacent_actions(rhs_parts, _rhs_length);
		ActionPart action_part2 = strip_trailing_action(rhs_parts, _rhs_length);
		if (action_part2 != null)
		{
			_rhs_length--;
		}
		_rhs = new ProductionPart[_rhs_length];
		for (int i = 0; i < _rhs_length; i++)
		{
			_rhs[i] = rhs_parts[i];
			if (!_rhs[i].is_action())
			{
				((SymbolPart)_rhs[i]).the_symbol().NoteUse();
				if (((SymbolPart)_rhs[i]).the_symbol() is Terminal)
				{
					_rhs_prec = ((Terminal)((SymbolPart)_rhs[i]).the_symbol()).precedence_num();
					_rhs_assoc = ((Terminal)((SymbolPart)_rhs[i]).the_symbol()).precedence_side();
				}
			}
		}
		if (action_str == null)
		{
			action_str = "";
		}
		if (action_part2 != null && action_part2.CodeString!= null)
		{
			action_str = (action_str)+("\t\t")+(action_part2.CodeString)
				;
		}
		_action = new ActionPart(action_str);
		remove_embedded_actions();
		_index = next_index++;
		var hashtable = _all;
		
		hashtable.Add((_index), this);
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

	
	
	
	public virtual ProductionPart rhs(int indx)
	{
		if (indx >= 0 && indx < _rhs_length)
		{
			return _rhs[indx];
		}
		
		throw new InternalError("Index out of range for right hand side of production");
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

	public virtual TerminalSet first_set()
	{
		return _first_set;
	}

	
	public virtual bool Equals(Production other)
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

	public virtual SymbolPart lhs()
	{
		return _lhs;
	}

	public virtual ActionPart action()
	{
		return _action;
	}

	
	
	
	public Production(NonTerminal lhs_sym, ProductionPart[] rhs_parts, int rhs_l)
		: this(lhs_sym, rhs_parts, rhs_l, null)
	{
	}

	
	
	
	public Production(NonTerminal lhs_sym, ProductionPart[] rhs_parts, int rhs_l, string action_str, int prec_num, int prec_side)
		: this(lhs_sym, rhs_parts, rhs_l, action_str)
	{
		set_precedence_num(prec_num);
		set_precedence_side(prec_side);
	}

	
	
	
	public Production(NonTerminal lhs_sym, ProductionPart[] rhs_parts, int rhs_l, int prec_num, int prec_side)
		: this(lhs_sym, rhs_parts, rhs_l, null)
	{
		set_precedence_num(prec_num);
		set_precedence_side(prec_side);
	}

	
	
	public static IEnumerable<Production> all()
	{
		return _all.Values;
	}

	
	
	public static Production find(int indx)
	{
		return _all.TryGetValue(indx, out var p) ? p : null;
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
			ProductionPart production_part2 = rhs(i);
			if (!production_part2.is_action())
			{
				_Symbol symbol2 = ((SymbolPart)production_part2).the_symbol();
				if (!symbol2.IsNonTerminal)
				{
					bool result3 = set_nullable(false);
					
					return result3;
				}
				if (!((NonTerminal)symbol2).nullable())
				{
					return false;
				}
			}
		}
		bool result4 = set_nullable(true);
		
		return result4;
	}

	
	
	public virtual TerminalSet check_first_set()
	{
		for (int i = 0; i < rhs_length(); i++)
		{
			if (!rhs(i).is_action())
			{
				_Symbol symbol2 = ((SymbolPart)rhs(i)).the_symbol();
				if (!symbol2.IsNonTerminal)
				{
					_first_set.Add((Terminal)symbol2);
					break;
				}
				_first_set.Add(((NonTerminal)symbol2).first_set());
				if (!((NonTerminal)symbol2).nullable())
				{
					break;
				}
			}
		}
		TerminalSet result = first_set();
		
		return result;
	}

	
	
	public override bool Equals(object other)
	{
		if (!(other is Production))
		{
			return false;
		}
		bool result = Equals((Production)other);
		
		return result;
	}

	public override int GetHashCode()
	{
		return _index * 13;
	}

	
	public override string ToString()
	{
		InternalError internal_error2;
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
			if (action() != null && action().CodeString!= null)
			{
				str = (str)+(" {")+(action().CodeString)
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
		catch (InternalError x)
		{
			internal_error2 = x;// ByteCodeHelper.MapException<internal_error>(x, ByteCodeHelper.MapFlags.NoRemapping);
		}
		InternalError internal_error3 = internal_error2;
		internal_error3.crash();
		return null;
	}

	
	
	
	public virtual string to_simple_string()
	{
		string str = ((lhs() == null) ? "NULL_LHS" : lhs().the_symbol().Name);
		str = (str)+(" ::= ");
		for (int i = 0; i < rhs_length(); i++)
		{
			if (!rhs(i).is_action())
			{
				str = (str)+(((SymbolPart)rhs(i)).the_symbol().Name)+(" ")
					;
			}
		}
		return str;
	}
}
