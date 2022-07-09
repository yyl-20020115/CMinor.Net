
using CMinor.AST;
using CMinor.semantic;
using CMinor.Symbol;

using java.lang;


namespace CMinor.Visit;

public class SymbolResolutionVisitor : Visitor
{
	private ErrorLogger logger;

	private SymbolTable table;

	private FunctionDefinition mainFunction;

	
	private List globalVariables;

	
	private List functions;

	private int numLocals;

	private FunctionDefinition currentFunction;

	
	
	public SymbolResolutionVisitor(ErrorLogger logger)
	{
		this.logger = logger;
		table = new SymbolTable(logger);
	}

	
	
	public virtual void visitInSameScope(BlockStatement n)
	{
		Iterator iterator = n.getDeclarations().iterator();
		while (iterator.hasNext())
		{
			Declaration declaration = (Declaration)iterator.next();
			declaration.Accept(this);
		}
		iterator = n.getStatements().iterator();
		while (iterator.hasNext())
		{
			Statement statement = (Statement)iterator.next();
			statement.Accept(this);
		}
		numLocals -= n.getDeclarations().size();
	}

	
	
	public override void visit(GlobalVariableDeclaration n)
	{
		GlobalVariableSymbol symbol = new GlobalVariableSymbol(n.getLocation(), n.getIdentifier().getString(), n.getType().getType());
		table.declareSymbol(n.getIdentifier(), symbol);
		n.setSymbol(symbol);
		globalVariables.add(n);
	}

	
	
	public override void visit(Declaration n)
	{
		LocalVariableSymbol localVariableSymbol = new LocalVariableSymbol(n.getLocation(), n.getIdentifier().getString(), n.getType().getType());
		table.declareSymbol(n.getIdentifier(), localVariableSymbol);
		FunctionDefinition functionDefinition = currentFunction;
		int max = numLocals + 1;
		numLocals = max;
		functionDefinition.raiseNumLocals(max);
		localVariableSymbol.setOffset(-4 * numLocals);
	}

	
	
	public override void visit(IfStatement n)
	{
		n.getCondition().Accept(this);
		n.getIfClause().Accept(this);
	}

	
	
	public override void Visit(BinaryExpression n)
	{
		n.getArg1().Accept(this);
		n.Arg2.Accept(this);
	}

	
	
	public override void visit(AstNode n)
	{
		logger.log(n.getLocation(), new StringBuilder().append("symbol resolution in ").append(n.getDotLabel()).append(" is a stub")
			.toString());
	}

	
	[LineNumberTable(new byte[]
	{
		32, 103, 107, 139, 159, 10, 104, 184, 140, 108,
		140, 103, 103
	})]
	public override void visit(Program n)
	{
		mainFunction = null;
		globalVariables = new ArrayList();
		functions = new ArrayList();
		Iterator iterator = n.getDeclarations().iterator();
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
			n.setMainFunction(mainFunction);
		}
		n.setGlobalVariables(globalVariables);
		n.setFunctions(functions);
		globalVariables = null;
		functions = null;
	}

	
	[LineNumberTable(new byte[]
	{
		55, 103, 113, 98, 124, 159, 7, 105, 104, 100,
		162, 173, 251, 69, 179, 200, 110, 169, 237, 69,
		107, 113, 63, 11, 232, 69, 103, 103, 108, 141
	})]
	public override void visit(FunctionDefinition n)
	{
		List parameters = n.getParameters();
		
		ArrayList arrayList = new ArrayList(parameters.size());
		int num = 8;
		Iterator iterator = parameters.iterator();
		while (iterator.hasNext())
		{
			Parameter parameter = (Parameter)iterator.next();
			ParameterSymbol parameterSymbol = new ParameterSymbol(parameter.getLocation(), parameter.getIdentifier().getString(), parameter.getType().getType());
			((List)arrayList).add((object)parameterSymbol);
			parameterSymbol.setOffset(num);
			num += 4;
		}
		string @string = n.getIdentifier().getString();
		FunctionSymbol symbol = new FunctionSymbol(n.getLocation(), @string, n.getReturnType().getType(), arrayList);
		table.declareSymbol(n.getIdentifier(), symbol);
		n.setSymbol(symbol);
		if (String.instancehelper_equals(@string, "main"))
		{
			mainFunction = n;
		}
		else
		{
			functions.add(n);
		}
		table.enterScope();
		int i = 0;
		for (int num2 = parameters.size(); i < num2; i++)
		{
            table.declareSymbol(((Parameter)parameters.get(i)).getIdentifier(), (Symbol.Symbol)((List)arrayList).get(i));
		}
		numLocals = 0;
		currentFunction = n;
		visitInSameScope(n.getBody());
		table.exitScope();
	}

	
	
	public override void visit(GlobalVariableInitialization n)
	{
		visit((GlobalVariableDeclaration)n);
		n.getValue().Accept(this);
	}

	
	
	public override void visit(Initialization n)
	{
		visit((Declaration)n);
		n.getValue().Accept(this);
	}

	
	
	public override void visit(PrintStatement n)
	{
		Iterator iterator = n.getArguments().iterator();
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

	
	
	public override void visit(IfElseStatement n)
	{
		visit((IfStatement)n);
		n.getElseClause().Accept(this);
	}

	
	
	public override void visit(WhileStatement n)
	{
		n.getCondition().Accept(this);
		n.getBody().Accept(this);
	}

	public override void visit(ReturnVoidStatement n)
	{
	}

	
	
	public override void visit(ReturnValueStatement n)
	{
		n.getValue().Accept(this);
	}

	
	
	public override void visit(Assignment n)
	{
		table.lookupIdentifier(n.Identifier);
		n.Value.Accept(this);
	}

	
	
	public override void visit(FunctionCall n)
	{
		table.lookupIdentifier(n.getIdentifier());
		Iterator iterator = n.getArguments().iterator();
		while (iterator.hasNext())
		{
			Expression expression = (Expression)iterator.next();
			expression.Accept(this);
		}
	}

	
	
	public override void visit(IdentifierExpression n)
	{
		table.lookupIdentifier(n.getIdentifier());
	}

	public override void visit(ConstantExpression n)
	{
	}

	
	
	public override void visit(UnaryExpression n)
	{
		n.getArg1().Accept(this);
	}

	
	
	public override void visit(Division n)
	{
		logger.log(n.getLocation(), "/ operator not supported");
		Visit((BinaryExpression)n);
	}
}
