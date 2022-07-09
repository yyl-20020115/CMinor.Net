
using CMinor.AST;
using CMinor.Parser;
using CMinor.semantic;




namespace CMinor.Symbol;

public class SymbolTable
{
	
	internal class Scope
	{
		
		private HashMap symbols;

		private Scope m_parentScope;

		[Modifiers(Modifiers.Final | Modifiers.Synthetic)]
		internal SymbolTable this_00240;

		
		[LineNumberTable(new byte[]
		{
			159,
			183,
			104,
			99,
			176,
			byte.MaxValue,
			50,
			69
		})]
		private void declareSymbol(string P_0, Symbol P_1)
		{
			Symbol symbol = probe(P_0);
			if (symbol == null)
			{
				symbols.put(P_0, P_1);
			}
			else
			{
				access_0024000(this_00240).log(P_1.getLocation(), ("cannot re-declare symbol '")+(P_0)+("' in same scope (previously declared at ")
					+(symbol.getLocation())
					+(")")
					.ToString());
			}
		}

		
		
		public virtual Symbol probe(string P_0)
		{
			return (Symbol)symbols.get(P_0);
		}

		
		
		public Scope(SymbolTable P_0)
		{
			this_00240 = P_0;
			
			symbols = new HashMap();
			this.m_parentScope = null;
		}

		
		
		public Scope(SymbolTable P_0, Scope P_1)
		{
			this_00240 = P_0;
			
			symbols = new HashMap();
			this.m_parentScope = P_1;
		}

		
		
		public virtual bool containsKey(string P_0)
		{
			bool result = symbols.containsKey(P_0);
			
			return result;
		}

		public virtual Scope parentScope()
		{
			return this.m_parentScope;
		}

		public virtual bool hasParentScope()
		{
			return this.m_parentScope != null;
		}

		
		[Modifiers(Modifiers.Static | Modifiers.Synthetic)]
		
		internal static void access_0024100(Scope P_0, string P_1, Symbol P_2)
		{
			P_0.declareSymbol(P_1, P_2);
		}
	}

	private Scope currentScope;

	private ErrorLogger errorLogger;

	[Modifiers(Modifiers.Static | Modifiers.Synthetic)]
	
	internal static ErrorLogger access_0024000(SymbolTable P_0)
	{
		return P_0.errorLogger;
	}

	
	
	public virtual Symbol lookup(LocationInfo info, string identifier)
	{
		Scope scope = currentScope;
		while (true)
		{
			Symbol symbol = scope.probe(identifier);
			if (symbol != null)
			{
				return symbol;
			}
			if (!scope.hasParentScope())
			{
				break;
			}
			scope = scope.parentScope();
		}
		errorLogger.log(info, ("symbol '")+(identifier)+("' has not been declared")
			.ToString());
		return null;
	}

	
	
	public SymbolTable(ErrorLogger errorLogger)
	{
		currentScope = new Scope(this);
		this.errorLogger = errorLogger;
	}

	
	
	public virtual void enterScope()
	{
		currentScope = new Scope(this, currentScope);
	}

	
	
	public virtual void exitScope()
	{
		currentScope = currentScope.parentScope();
	}

	
	
	public virtual Symbol probe(LocationInfo info, string identifier)
	{
		Symbol symbol = currentScope.probe(identifier);
		if (symbol == null)
		{
			errorLogger.log(info, ("symbol '")+(identifier)+("' has not been declared")
				.ToString());
		}
		return symbol;
	}

	
	
	public virtual void lookupIdentifier(Identifier identifier)
	{
		identifier.setSymbol(lookup(identifier.getLocation(), identifier.getString()));
	}

	
	
	public virtual void declareSymbol(Identifier identifier, Symbol symbol)
	{
		Scope.access_0024100(currentScope, identifier.getString(), symbol);
		identifier.setSymbol(symbol);
	}
}
