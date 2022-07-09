
using CMinor.AST;
using CMinor.Semantic;
using CMinor.Symbol;
using System.Collections.Generic;

namespace CMinor.Visit;

public class SymbolResolutionVisitor : Visitor
{
	private ErrorLogger logger;

	private SymbolTable table;

	private FunctionDefinition mainFunction;

	
	private IList<object> globalVariables;

	
	private IList<object> functions;

	private int numLocals;

	private FunctionDefinition currentFunction;

	
	
	public SymbolResolutionVisitor(ErrorLogger logger)
	{
		this.logger = logger;
		table = new SymbolTable(logger);
	}

	
	
	public virtual void visitInSameScope(BlockStatement n)
	{
		Iterator iterator = n.Declarations.iterator();
		while (iterator.hasNext())
		{
			Declaration declaration = (Declaration)iterator.next();
			declaration.Accept(this);
		}
		iterator = n.Statements.iterator();
		while (iterator.hasNext())
		{
			Statement statement = (Statement)iterator.next();
			statement.Accept(this);
		}
		numLocals -= n.Declarations.Count;
	}

	
	
	public override void Visit(GlobalVariableDeclaration n)
	{
		GlobalVariableSymbol symbol = new GlobalVariableSymbol(n.getLocation(), n.Identifier.Name, n.Type.Type);
		table.declareSymbol(n.Identifier, symbol);
		n.Symbol = symbol;
		globalVariables.Add(n);
	}

	
	
	public override void Visit(Declaration n)
	{
		LocalVariableSymbol localVariableSymbol = new LocalVariableSymbol(n.getLocation(), n.Identifier.Name, n.Type.Type);
		table.declareSymbol(n.Identifier, localVariableSymbol);
		FunctionDefinition functionDefinition = currentFunction;
		int max = numLocals + 1;
		numLocals = max;
		functionDefinition.RaiseNumLocals(max);
		localVariableSymbol.Offset = -4 * numLocals;
	}

	
	
	public override void Visit(IfStatement n)
	{
		n.Condition.Accept(this);
		n.IfClause.Accept(this);
	}

	
	
	public override void Visit(BinaryExpression n)
	{
		n.Arg1.Accept(this);
		n.Arg2.Accept(this);
	}

	
	
	public override void Visit(AstNode n)
	{
		logger.log(n.getLocation(), ("symbol resolution in ")+(n.DotLabel)+(" is a stub")
			);
	}

	
	public override void Visit(Program n)
	{
		mainFunction = null;
		globalVariables = new ();
		functions = new ();
		Iterator iterator = n.Declarations.iterator();
		while (iterator.hasNext())
		{
			ExternalDeclaration externalDeclaration = (ExternalDeclaration)iterator.next();
			externalDeclaration.Accept(this);
		}
		if (mainFunction == null)
		{
			logger.log(n.getLocation(), "missing main function");
		}
		else
		{
			n.MainFunction = mainFunction;
		}
		n.GlobalVariables = globalVariables;
		n.Functions = functions;
		globalVariables = null;
		functions = null;
	}

	
	public override void Visit(FunctionDefinition n)
	{
		IList parameters = n.Parameters;
		
		ArrayList arrayList = new ArrayList(parameters.Count);
		int num = 8;
		Iterator iterator = parameters.iterator();
		while (iterator.hasNext())
		{
			Parameter parameter = (Parameter)iterator.next();
			ParameterSymbol parameterSymbol = new ParameterSymbol(parameter.getLocation(), parameter.Identifier.Name, parameter.Type.Type);
			((IList)arrayList).Add((object)parameterSymbol);
			parameterSymbol.Offset = num;
			num += 4;
		}
		string @string = n.Identifier.Name;
		FunctionSymbol symbol = new FunctionSymbol(n.getLocation(), @string, n.ReturnType.Type, arrayList);
		table.declareSymbol(n.Identifier, symbol);
		n.Symbol = symbol;
		if (string.Equals(@string, "main"))
		{
			mainFunction = n;
		}
		else
		{
			functions.Add(n);
		}
		table.enterScope();
		int i = 0;
		for (int num2 = parameters.Count; i < num2; i++)
		{
            table.declareSymbol(((Parameter)parameters.get(i)).Identifier, (Symbol.Symbol)((IList)arrayList).get(i));
		}
		numLocals = 0;
		currentFunction = n;
		visitInSameScope(n.Body);
		table.exitScope();
	}

	
	
	public override void Visit(GlobalVariableInitialization n)
	{
		Visit((GlobalVariableDeclaration)n);
		n.Value.Accept(this);
	}

	
	
	public override void Visit(Initialization n)
	{
		Visit((Declaration)n);
		n.Value.Accept(this);
	}

	
	
	public override void visit(PrintStatement n)
	{
		Iterator iterator = n.Arguments.iterator();
		while (iterator.hasNext())
		{
			Expression expression = (Expression)iterator.next();
			expression.Accept(this);
		}
	}

	
	
	public override void Visit(BlockStatement n)
	{
		table.enterScope();
		visitInSameScope(n);
		table.exitScope();
	}

	
	
	public override void Visit(IfElseStatement n)
	{
		Visit((IfStatement)n);
		n.ElseClause.Accept(this);
	}

	
	
	public override void Visit(WhileStatement n)
	{
		n.Condition.Accept(this);
		n.Body.Accept(this);
	}

	public override void Visit(ReturnVoidStatement n)
	{
	}

	
	
	public override void Visit(ReturnValueStatement n)
	{
		n.Value.Accept(this);
	}

	
	
	public override void Visit(Assignment n)
	{
		table.lookupIdentifier(n.Identifier);
		n.Value.Accept(this);
	}

	
	
	public override void Visit(FunctionCall n)
	{
		table.lookupIdentifier(n.Identifier);
		Iterator iterator = n.Arguments.iterator();
		while (iterator.hasNext())
		{
			Expression expression = (Expression)iterator.next();
			expression.Accept(this);
		}
	}

	
	
	public override void Visit(IdentifierExpression n)
	{
		table.lookupIdentifier(n.Identifier);
	}

	public override void Visit(ConstantExpression n)
	{
	}

	
	
	public override void Visit(UnaryExpression n)
	{
		n.Arg1.Accept(this);
	}

	
	
	public override void Visit(Division n)
	{
		logger.log(n.getLocation(), "/ operator not supported");
		Visit((BinaryExpression)n);
	}
}
