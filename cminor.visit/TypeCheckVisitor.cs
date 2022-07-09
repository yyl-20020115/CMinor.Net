
using CMinor.AST;
using CMinor.semantic;
using CMinor.Symbol;




namespace CMinor.Visit;

public class TypeCheckVisitor : Visitor
{
	
	[EnclosingMethod(null, null, null)]
	internal sealed class _1 : TypeTester
	{
		
		
		internal _1()
			: base(null)
		{
		}

		
		
		public override bool test(Type P_0)
		{
			return P_0 == Type.___003C_003EINT;
		}

		public override string desc()
		{
			return "arithmetic";
		}

		
		
		public override Type synth()
		{
			return Type.___003C_003EINT;
		}
	}

	
	[EnclosingMethod(null, null, null)]
	internal sealed class _2 : TypeTester
	{
		
		
		internal _2()
			: base(null)
		{
		}

		
		
		public override bool test(Type P_0)
		{
			return (P_0 == Type.___003C_003EINT || P_0 == Type.___003C_003ECHAR || P_0 == Type.___003C_003EBOOLEAN) ? true : false;
		}

		public override string desc()
		{
			return "equatable";
		}

		
		
		public override Type synth()
		{
			return Type.___003C_003EBOOLEAN;
		}
	}

	
	[EnclosingMethod(null, null, null)]
	internal sealed class _3 : TypeTester
	{
		
		
		internal _3()
			: base(null)
		{
		}

		
		
		public override bool test(Type P_0)
		{
			return P_0 == Type.___003C_003EINT;
		}

		public override string desc()
		{
			return "comparable";
		}

		
		
		public override Type synth()
		{
			return Type.___003C_003EBOOLEAN;
		}
	}

	
	[EnclosingMethod(null, null, null)]
	internal sealed class _4 : TypeTester
	{
		
		
		internal _4()
			: base(null)
		{
		}

		
		
		public override bool test(Type P_0)
		{
			return P_0 == Type.___003C_003EBOOLEAN;
		}

		public override string desc()
		{
			return "logical";
		}

		
		
		public override Type synth()
		{
			return Type.___003C_003EBOOLEAN;
		}
	}

	
	internal abstract class TypeTester
	{
		
		
		private TypeTester()
		{
		}

		public abstract bool test(Type P_0);

		public abstract string desc();

		public abstract Type synth();

		
		[Modifiers(Modifiers.Synthetic)]
		
		internal TypeTester(_1 P_0)
			: this()
		{
		}
	}

	private ErrorLogger logger;

	private StringTable stringTable;

	private FunctionSymbol currentFunction;

	private bool endsWithReturn;

	private Program program;

	private bool inPrintStatement;

	
	private static TypeTester IS_ARITHMETIC;

	
	private static TypeTester IS_EQUATABLE;

	
	private static TypeTester IS_COMPARABLE;

	
	private static TypeTester IS_LOGICAL;

	
	
	public static void ___003Cclinit_003E()
	{
	}

	
	
	public TypeCheckVisitor(ErrorLogger logger)
	{
		this.logger = logger;
	}

	
	
	private bool checkVariableType(AstNode P_0, TypeSpecifier P_1, string P_2)
	{
		int num = (P_1.getType().isVariableType() ? 1 : 0);
		if (num == 0)
		{
			logger.log(P_0.getLocation(), ("a ")+(P_2)+(" may not have type ")
				+(Type.___003C_003EVOID.getName())
				.ToString());
		}
		return (byte)num != 0;
	}

	
	
	private void checkMatch(AstNode P_0, Type P_1, Type P_2, string P_3)
	{
		if (P_1 != P_2)
		{
			logger.log(P_0.getLocation(), ("type mismatch in ")+(P_3)+(" (got ")
				+(P_1.getName())
				+(" and ")
				+(P_2.getName())
				+(")")
				.ToString());
		}
	}

	
	[LineNumberTable(new byte[]
	{
		161, 114, 102, 134, 186, 127, 2, 104, 98, 134,
		103
	})]
	private string makeFormatString(PrintStatement P_0)
	{
		StringBuilder stringBuffer = new StringBuilder();
		ArrayList arrayList = new ArrayList();
		FormatStringVisitor formatStringVisitor = new FormatStringVisitor(stringBuffer, arrayList, stringTable, program, logger);
		Iterator iterator = P_0.getArguments().iterator();
		while (iterator.hasNext())
		{
			Expression expression = (Expression)iterator.next();
			expression.Accept(formatStringVisitor);
		}
		formatStringVisitor.finish();
		P_0.setActualArguments(arrayList);
		string result = stringBuffer.ToString();
		
		return result;
	}

	
	
	private void checkCondition(AstNode P_0, Expression P_1, string P_2)
	{
		P_1.Accept(this);
		Type type = P_1.getType();
		if (type != Type.___003C_003EBOOLEAN)
		{
			logger.log(P_0.getLocation(), ("condition in ")+(P_2)+(" must be of type ")
				+(type.getName())
				.ToString());
		}
	}

	
	
	
	private string typeListString(List P_0)
	{
		StringBuilder stringBuffer = new StringBuilder();
		int num = 0;
		Iterator iterator = P_0.iterator();
		while (iterator.hasNext())
		{
			Type type = (Type)iterator.next();
			if (num != 0)
			{
				stringBuffer+(", ");
			}
			else
			{
				num = 1;
			}
			stringBuffer+(type.getName());
		}
		string result = stringBuffer.ToString();
		
		return result;
	}

	
	
	private void requireType(UnaryExpression P_0, string P_1, TypeTester P_2)
	{
		requireType(P_0, P_0.getArg1(), P_1, P_2);
		P_0.setType(P_2.synth());
	}

	
	
	private void requireTypes(BinaryExpression P_0, string P_1, TypeTester P_2)
	{
		requireType(P_0, P_0.getArg1(), P_1, P_2);
		requireType(P_0, P_0.Arg2, P_1, P_2);
		Type type = P_0.getArg1().getType();
		Type type2 = P_0.Arg2.getType();
		checkMatch(P_0, type, type2, P_1);
		P_0.setType(P_2.synth());
	}

	
	
	private void requireType(Expression P_0, Expression P_1, string P_2, TypeTester P_3)
	{
		inPrintStatement = false;
		P_1.Accept(this);
		Type type = P_1.getType();
		if (!P_3.test(type))
		{
			logger.log(P_0.getLocation(), (P_2)+(" operator requires operands of ")+(P_3.desc())
				+(" type (got ")
				+(type.getName())
				+(")")
				.ToString());
		}
	}

	
	
	public override void visit(AstNode n)
	{
		logger.log(n.getLocation(), ("type checking in ")+(n.getDotLabel())+(" is a stub")
			.ToString());
	}

	
	[LineNumberTable(new byte[]
	{
		30, 135, 107, 167, 108, 109, 191, 21, 109, 246,
		69, 191, 10, 147
	})]
	public override void visit(Program n)
	{
		program = n;
		stringTable = new StringTable();
		inPrintStatement = false;
		FunctionSymbol symbol = n.getMainFunction().getSymbol();
		if (symbol.getReturnType() != Type.___003C_003EINT)
		{
			logger.log(n.getLocation(), ("main function must have return type ")+(Type.___003C_003EINT.getName()).ToString());
		}
		if (symbol.getParameters().size() != 0)
		{
			logger.log(n.getLocation(), "main function must take no parameters");
		}
		Iterator iterator = n.getDeclarations().iterator();
		while (iterator.hasNext())
		{
			ExternalDeclaration externalDeclaration = (ExternalDeclaration)iterator.next();
			externalDeclaration.Accept(this);
		}
		n.setStringSymbols(stringTable.getSymbols());
	}

	
	
	public override void visit(Parameter n)
	{
		checkVariableType(n, n.getType(), "parameter");
	}

	
	[LineNumberTable(new byte[]
	{
		60, 191, 10, 172, 167, 204, 103, 122, 223, 27,
		140, 135
	})]
	public override void visit(FunctionDefinition n)
	{
		Iterator iterator = n.getParameters().iterator();
		while (iterator.hasNext())
		{
			Parameter parameter = (Parameter)iterator.next();
			parameter.Accept(this);
		}
		currentFunction = n.getSymbol();
		endsWithReturn = false;
		n.getBody().Accept(this);
		FunctionSymbol symbol = n.getSymbol();
		if (!endsWithReturn && currentFunction.getReturnType().isVariableType())
		{
			logger.log(n.getLocation(), ("non-void function ")+(symbol.getIdentifier())+(" does not return a value in all paths of execution")
				.ToString());
		}
		n.setEndsWithReturn(endsWithReturn);
		currentFunction = null;
	}

	
	
	public override void visit(GlobalVariableDeclaration n)
	{
		checkVariableType(n, n.getType(), "variable");
	}

	
	[LineNumberTable(new byte[]
	{
		90,
		108,
		116,
		byte.MaxValue,
		5,
		69
	})]
	public override void visit(GlobalVariableInitialization n)
	{
		n.getValue().Accept(this);
		if (checkVariableType(n, n.getType(), "variable"))
		{
			checkMatch(n, n.getType().getType(), n.getValue().getType(), "global variable initialization");
		}
	}

	
	
	public override void visit(Declaration n)
	{
		checkVariableType(n, n.getType(), "variable");
	}

	
	[LineNumberTable(new byte[]
	{
		104,
		108,
		116,
		byte.MaxValue,
		5,
		69
	})]
	public override void visit(Initialization n)
	{
		n.getValue().Accept(this);
		if (checkVariableType(n, n.getType(), "variable"))
		{
			checkMatch(n, n.getType().getType(), n.getValue().getType(), "local variable initialization");
		}
	}

	
	
	public override void visit(PrintStatement n)
	{
		Iterator iterator = n.getArguments().iterator();
		while (iterator.hasNext())
		{
			Expression expression = (Expression)iterator.next();
			inPrintStatement = true;
			expression.Accept(this);
		}
		inPrintStatement = false;
		string value = makeFormatString(n);
		StringSymbol symbol = stringTable.getSymbol(value);
		n.setSymbol(symbol);
	}

	
	[LineNumberTable(new byte[]
	{
		160, 65, 159, 10, 127, 1, 104, 118, 130, 103,
		98
	})]
	public override void Visit(BlockStatement n)
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
			if (endsWithReturn)
			{
				logger.log(statement.getLocation(), "unreachable statement");
				break;
			}
			statement.Accept(this);
		}
	}

	
	
	public override void visit(IfStatement n)
	{
		checkCondition(n, n.getCondition(), "if statement");
		n.getIfClause().Accept(this);
	}

	
	
	public override void visit(IfElseStatement n)
	{
		checkCondition(n, n.getCondition(), "if statement");
		n.getIfClause().Accept(this);
		int num = (endsWithReturn ? 1 : 0);
		endsWithReturn = false;
		n.getElseClause().Accept(this);
		endsWithReturn = ((num != 0 && endsWithReturn) ? true : false);
	}

	
	
	public override void visit(WhileStatement n)
	{
		checkCondition(n, n.getCondition(), "while statement");
		n.getBody().Accept(this);
	}

	
	
	public override void visit(ReturnVoidStatement n)
	{
		Type returnType = currentFunction.getReturnType();
		if (returnType != Type.___003C_003EVOID)
		{
			logger.log(n.getLocation(), ("return statement missing value in function ")+(currentFunction.getIdentifier()).ToString());
		}
		endsWithReturn = true;
	}

	
	[LineNumberTable(new byte[]
	{
		160,
		114,
		172,
		108,
		108,
		103,
		byte.MaxValue,
		103,
		69,
		146,
		135
	})]
	public override void visit(ReturnValueStatement n)
	{
		n.getValue().Accept(this);
		Type returnType = currentFunction.getReturnType();
		Type type = n.getValue().getType();
		if (returnType != type)
		{
			string msg = ((returnType != Type.___003C_003EVOID) ? ("return statement in function ")+(currentFunction.getIdentifier())+(" requires expression of type ")
				+(returnType.getName())
				+(", got ")
				+(type.getName())
				.ToString() : ("function with ")+(Type.___003C_003EVOID.getName())+(" return type cannot return a value")
				.ToString());
			logger.log(n.getLocation(), msg);
		}
		endsWithReturn = true;
	}

	
	
	public override void visit(Assignment n)
	{
		inPrintStatement = false;
		Expression value = n.Value;
		value.Accept(this);
		Type type = n.Identifier.getSymbol().getType();
		Type type2 = value.getType();
		checkMatch(n, type, type2, "variable assignment");
		n.setType(type);
	}

	
	[LineNumberTable(new byte[]
	{
		160,
		146,
		135,
		167,
		191,
		5,
		108,
		104,
		105,
		223,
		39,
		173,
		104,
		168,
		137,
		113,
		114,
		127,
		17,
		159,
		18,
		107,
		byte.MaxValue,
		42,
		70,
		207
	})]
	public override void visit(FunctionCall n)
	{
		inPrintStatement = false;
		List arguments = n.getArguments();
		Iterator iterator = arguments.iterator();
		while (iterator.hasNext())
		{
			Expression expression = (Expression)iterator.next();
			expression.Accept(this);
		}
		Symbol symbol = n.getIdentifier().getSymbol();
		Type type = symbol.getType();
		if (type != Type.___003C_003EFUNCTION)
		{
			logger.log(n.getLocation(), ("symbol ")+(symbol.getIdentifier())+(" called as function but is of type ")
				+(type.getName())
				.ToString());
			n.setType(type);
			return;
		}
		FunctionSymbol functionSymbol = (FunctionSymbol)symbol;
		n.setSymbol(functionSymbol);
		List parameters = functionSymbol.getParameters();
		int initialCapacity = arguments.size();
		int initialCapacity2 = parameters.size();
		ArrayList arrayList = new ArrayList(initialCapacity);
		ArrayList arrayList2 = new ArrayList(initialCapacity2);
		Iterator iterator2 = arguments.iterator();
		while (iterator2.hasNext())
		{
			Expression expression2 = (Expression)iterator2.next();
			((List)arrayList).add((object)expression2.getType());
		}
		iterator2 = parameters.iterator();
		while (iterator2.hasNext())
		{
			ParameterSymbol parameterSymbol = (ParameterSymbol)iterator2.next();
			((List)arrayList2).add((object)parameterSymbol.getType());
		}
		if (!((List)arrayList).equals((object)arrayList2))
		{
			logger.log(n.getLocation(), ("actual and formal parameters in function call do not match\n\treceived: ")+(typeListString(arrayList))+("\n\texpected: ")
				+(typeListString(arrayList2))
				.ToString());
		}
		n.setType(functionSymbol.getReturnType());
	}

	
	
	public override void visit(IdentifierExpression n)
	{
		n.setType(n.getIdentifier().getSymbol().getType());
	}

	
	
	public override void visit(BooleanLiteral n)
	{
		n.setType(Type.___003C_003EBOOLEAN);
	}

	
	
	public override void visit(CharacterLiteral n)
	{
		n.setType(Type.___003C_003ECHAR);
	}

	
	
	public override void visit(IntegerLiteral n)
	{
		n.setType(Type.___003C_003EINT);
	}

	
	
	public override void visit(StringLiteral n)
	{
		if (!inPrintStatement)
		{
			n.setSymbol(stringTable.getSymbol((string)n.getValue()));
		}
		n.setType(Type.___003C_003ESTRING);
	}

	
	
	public override void visit(Negative n)
	{
		requireType(n, "unary -", IS_ARITHMETIC);
	}

	
	
	public override void visit(LogicalNot n)
	{
		requireType(n, "!", IS_LOGICAL);
	}

	
	
	public override void Visit(Addition n)
	{
		requireTypes(n, "+", IS_ARITHMETIC);
	}

	
	
	public override void visit(Subtraction n)
	{
		requireTypes(n, "-", IS_ARITHMETIC);
	}

	
	
	public override void visit(Multiplication n)
	{
		requireTypes(n, "*", IS_ARITHMETIC);
	}

	
	
	public override void visit(Division n)
	{
		requireTypes(n, "/", IS_ARITHMETIC);
	}

	
	
	public override void visit(EqualTo n)
	{
		requireTypes(n, "==", IS_EQUATABLE);
	}

	
	
	public override void visit(NotEqualTo n)
	{
		requireTypes(n, "!=", IS_EQUATABLE);
	}

	
	
	public override void visit(GreaterThan n)
	{
		requireTypes(n, ">", IS_COMPARABLE);
	}

	
	
	public override void visit(GreaterThanOrEqualTo n)
	{
		requireTypes(n, ">=", IS_COMPARABLE);
	}

	
	
	public override void visit(LessThan n)
	{
		requireTypes(n, "<", IS_COMPARABLE);
	}

	
	
	public override void visit(LessThanOrEqualTo n)
	{
		requireTypes(n, "<=", IS_COMPARABLE);
	}

	
	
	public override void visit(LogicalAnd n)
	{
		requireTypes(n, "&&", IS_LOGICAL);
	}

	
	
	public override void visit(LogicalOr n)
	{
		requireTypes(n, "||", IS_LOGICAL);
	}

	
	static TypeCheckVisitor()
	{
		IS_ARITHMETIC = new _1();
		IS_EQUATABLE = new _2();
		IS_COMPARABLE = new _3();
		IS_LOGICAL = new _4();
	}
}
