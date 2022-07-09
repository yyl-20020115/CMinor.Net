
using CMinor.AST;
using CMinor.Semantic;
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
			return P_0 == Type.integer_type;
		}

		public override string desc()
		{
			return "arithmetic";
		}

		
		
		public override Type synth()
		{
			return Type.integer_type;
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
			return (P_0 == Type.integer_type || P_0 == Type.char_type || P_0 == Type.boolean_type) ? true : false;
		}

		public override string desc()
		{
			return "equatable";
		}

		
		
		public override Type synth()
		{
			return Type.boolean_type;
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
			return P_0 == Type.integer_type;
		}

		public override string desc()
		{
			return "comparable";
		}

		
		
		public override Type synth()
		{
			return Type.boolean_type;
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
			return P_0 == Type.boolean_type;
		}

		public override string desc()
		{
			return "logical";
		}

		
		
		public override Type synth()
		{
			return Type.boolean_type;
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
		int num = (P_1.Type.isVariableType? 1 : 0);
		if (num == 0)
		{
			logger.log(P_0.getLocation(), ("a ")+(P_2)+(" may not have type ")
				+(Type.void_type.Name)
				);
		}
		return (byte)num != 0;
	}

	
	
	private void checkMatch(AstNode P_0, Type P_1, Type P_2, string P_3)
	{
		if (P_1 != P_2)
		{
			logger.log(P_0.getLocation(), ("type mismatch in ")+(P_3)+(" (got ")
				+(P_1.Name)
				+(" and ")
				+(P_2.Name)
				+(")")
				);
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
		Iterator iterator = P_0.Arguments.iterator();
		while (iterator.hasNext())
		{
			Expression expression = (Expression)iterator.next();
			expression.Accept(formatStringVisitor);
		}
		formatStringVisitor.finish();
		P_0.ActualArguments = arrayList;
		string result = stringBuffer.ToString();
		
		return result;
	}

	
	
	private void checkCondition(AstNode P_0, Expression P_1, string P_2)
	{
		P_1.Accept(this);
		Type type = P_1.Type;
		if (type != Type.boolean_type)
		{
			logger.log(P_0.getLocation(), ("condition in ")+(P_2)+(" must be of type ")
				+(type.Name)
				);
		}
	}

	
	
	
	private string typeListString(IList P_0)
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
			stringBuffer+(type.Name);
		}
		string result = stringBuffer.ToString();
		
		return result;
	}

	
	
	private void requireType(UnaryExpression P_0, string P_1, TypeTester P_2)
	{
		requireType(P_0, P_0.Arg1, P_1, P_2);
		P_0.Type = P_2.synth();
	}

	
	
	private void requireTypes(BinaryExpression P_0, string P_1, TypeTester P_2)
	{
		requireType(P_0, P_0.Arg1, P_1, P_2);
		requireType(P_0, P_0.Arg2, P_1, P_2);
		Type type = P_0.Arg1.Type;
		Type type2 = P_0.Arg2.Type;
		checkMatch(P_0, type, type2, P_1);
		P_0.Type = P_2.synth();
	}

	
	
	private void requireType(Expression P_0, Expression P_1, string P_2, TypeTester P_3)
	{
		inPrintStatement = false;
		P_1.Accept(this);
		Type type = P_1.Type;
		if (!P_3.test(type))
		{
			logger.log(P_0.getLocation(), (P_2)+(" operator requires operands of ")+(P_3.desc())
				+(" type (got ")
				+(type.Name)
				+(")")
				);
		}
	}

	
	
	public override void visit(AstNode n)
	{
		logger.log(n.getLocation(), ("type checking in ")+(n.DotLabel)+(" is a stub")
			);
	}

	
	[LineNumberTable(new byte[]
	{
		30, 135, 107, 167, 108, 109, 191, 21, 109, 246,
		69, 191, 10, 147
	})]
	public override void Visit(Program n)
	{
		program = n;
		stringTable = new StringTable();
		inPrintStatement = false;
		FunctionSymbol symbol = n.MainFunction.Symbol;
		if (symbol.ReturnType != Type.integer_type)
		{
			logger.log(n.getLocation(), ("main function must have return type ")+(Type.integer_type.Name));
		}
		if (symbol.Parameters.size() != 0)
		{
			logger.log(n.getLocation(), "main function must take no parameters");
		}
		Iterator iterator = n.Declarations.iterator();
		while (iterator.hasNext())
		{
			ExternalDeclaration externalDeclaration = (ExternalDeclaration)iterator.next();
			externalDeclaration.Accept(this);
		}
		n.StringSymbols = stringTable.Symbols;
	}

	
	
	public override void Visit(Parameter n)
	{
		checkVariableType(n, n.Type, "parameter");
	}

	
	[LineNumberTable(new byte[]
	{
		60, 191, 10, 172, 167, 204, 103, 122, 223, 27,
		140, 135
	})]
	public override void Visit(FunctionDefinition n)
	{
		Iterator iterator = n.Parameters.iterator();
		while (iterator.hasNext())
		{
			Parameter parameter = (Parameter)iterator.next();
			parameter.Accept(this);
		}
		currentFunction = n.Symbol;
		endsWithReturn = false;
		n.Body.Accept(this);
		FunctionSymbol symbol = n.Symbol;
		if (!endsWithReturn && currentFunction.ReturnType.isVariableType)
		{
			logger.log(n.getLocation(), ("non-void function ")+(symbol.Identifier)+(" does not return a value in all paths of execution")
				);
		}
		n.EndsWithReturn = endsWithReturn;
		currentFunction = null;
	}

	
	
	public override void Visit(GlobalVariableDeclaration n)
	{
		checkVariableType(n, n.Type, "variable");
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
	public override void Visit(GlobalVariableInitialization n)
	{
		n.Value.Accept(this);
		if (checkVariableType(n, n.Type, "variable"))
		{
			checkMatch(n, n.Type.Type, n.Value.Type, "global variable initialization");
		}
	}

	
	
	public override void Visit(Declaration n)
	{
		checkVariableType(n, n.Type, "variable");
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
	public override void Visit(Initialization n)
	{
		n.Value.Accept(this);
		if (checkVariableType(n, n.Type, "variable"))
		{
			checkMatch(n, n.Type.Type, n.Value.Type, "local variable initialization");
		}
	}

	
	
	public override void visit(PrintStatement n)
	{
		Iterator iterator = n.Arguments.iterator();
		while (iterator.hasNext())
		{
			Expression expression = (Expression)iterator.next();
			inPrintStatement = true;
			expression.Accept(this);
		}
		inPrintStatement = false;
		string value = makeFormatString(n);
		StringSymbol symbol = stringTable.getSymbol(value);
		n.Symbol = symbol;
	}

	
	[LineNumberTable(new byte[]
	{
		160, 65, 159, 10, 127, 1, 104, 118, 130, 103,
		98
	})]
	public override void Visit(BlockStatement n)
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
			if (endsWithReturn)
			{
				logger.log(statement.getLocation(), "unreachable statement");
				break;
			}
			statement.Accept(this);
		}
	}

	
	
	public override void Visit(IfStatement n)
	{
		checkCondition(n, n.Condition, "if statement");
		n.IfClause.Accept(this);
	}

	
	
	public override void Visit(IfElseStatement n)
	{
		checkCondition(n, n.Condition, "if statement");
		n.IfClause.Accept(this);
		int num = (endsWithReturn ? 1 : 0);
		endsWithReturn = false;
		n.ElseClause.Accept(this);
		endsWithReturn = ((num != 0 && endsWithReturn) ? true : false);
	}

	
	
	public override void Visit(WhileStatement n)
	{
		checkCondition(n, n.Condition, "while statement");
		n.Body.Accept(this);
	}

	
	
	public override void Visit(ReturnVoidStatement n)
	{
		Type returnType = currentFunction.ReturnType;
		if (returnType != Type.void_type)
		{
			logger.log(n.getLocation(), ("return statement missing value in function ")+(currentFunction.Identifier));
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
	public override void Visit(ReturnValueStatement n)
	{
		n.Value.Accept(this);
		Type returnType = currentFunction.ReturnType;
		Type type = n.Value.Type;
		if (returnType != type)
		{
			string msg = ((returnType != Type.void_type) ? ("return statement in function ")+(currentFunction.Identifier)+(" requires expression of type ")
				+(returnType.Name)
				+(", got ")
				+(type.Name)
				.ToString() : ("function with ")+(Type.void_type.Name)+(" return type cannot return a value")
				);
			logger.log(n.getLocation(), msg);
		}
		endsWithReturn = true;
	}

	
	
	public override void visit(Assignment n)
	{
		inPrintStatement = false;
		Expression value = n.Value;
		value.Accept(this);
		Type type = n.Identifier.Symbol.Type;
		Type type2 = value.Type;
		checkMatch(n, type, type2, "variable assignment");
		n.Type = type;
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
	public override void Visit(FunctionCall n)
	{
		inPrintStatement = false;
		IList arguments = n.Arguments;
		Iterator iterator = arguments.iterator();
		while (iterator.hasNext())
		{
			Expression expression = (Expression)iterator.next();
			expression.Accept(this);
		}
		Symbol symbol = n.getIdentifier().Symbol;
		Type type = symbol.getType();
		if (type != Type.function_type)
		{
			logger.log(n.getLocation(), ("symbol ")+(symbol.getIdentifier())+(" called as function but is of type ")
				+(type.Name)
				);
			n.Type = type;
			return;
		}
		FunctionSymbol functionSymbol = (FunctionSymbol)symbol;
		n.Symbol = functionSymbol;
		IList parameters = functionSymbol.Parameters;
		int initialCapacity = arguments.size();
		int initialCapacity2 = parameters.size();
		ArrayList arrayList = new ArrayList(initialCapacity);
		ArrayList arrayList2 = new ArrayList(initialCapacity2);
		Iterator iterator2 = arguments.iterator();
		while (iterator2.hasNext())
		{
			Expression expression2 = (Expression)iterator2.next();
			((IList)arrayList).Add((object)expression2.Type);
		}
		iterator2 = parameters.iterator();
		while (iterator2.hasNext())
		{
			ParameterSymbol parameterSymbol = (ParameterSymbol)iterator2.next();
			((IList)arrayList2).Add((object)parameterSymbol.Type);
		}
		if (!((IList)arrayList).equals((object)arrayList2))
		{
			logger.log(n.getLocation(), ("actual and formal parameters in function call do not match\n\treceived: ")+(typeListString(arrayList))+("\n\texpected: ")
				+(typeListString(arrayList2))
				);
		}
		n.Type = functionSymbol.ReturnType;
	}

	
	
	public override void Visit(IdentifierExpression n)
	{
		n.Type = n.Identifier.Symbol.Type;
	}

	
	
	public override void Visit(BooleanLiteral n)
	{
		n.Type = Type.boolean_type;
	}

	
	
	public override void Visit(CharacterLiteral n)
	{
		n.Type = Type.char_type;
	}

	
	
	public override void Visit(IntegerLiteral n)
	{
		n.Type = Type.integer_type;
	}

	
	
	public override void Visit(StringLiteral n)
	{
		if (!inPrintStatement)
		{
			n.Symbol = stringTable.getSymbol((string)n.Value);
		}
		n.Type = Type.string_type;
	}

	
	
	public override void Visit(Negative n)
	{
		requireType(n, "unary -", IS_ARITHMETIC);
	}

	
	
	public override void Visit(LogicalNot n)
	{
		requireType(n, "!", IS_LOGICAL);
	}

	
	
	public override void Visit(Addition n)
	{
		requireTypes(n, "+", IS_ARITHMETIC);
	}

	
	
	public override void Visit(Subtraction n)
	{
		requireTypes(n, "-", IS_ARITHMETIC);
	}

	
	
	public override void Visit(Multiplication n)
	{
		requireTypes(n, "*", IS_ARITHMETIC);
	}

	
	
	public override void Visit(Division n)
	{
		requireTypes(n, "/", IS_ARITHMETIC);
	}

	
	
	public override void Visit(EqualTo n)
	{
		requireTypes(n, "==", IS_EQUATABLE);
	}

	
	
	public override void Visit(NotEqualTo n)
	{
		requireTypes(n, "!=", IS_EQUATABLE);
	}

	
	
	public override void Visit(GreaterThan n)
	{
		requireTypes(n, ">", IS_COMPARABLE);
	}

	
	
	public override void Visit(GreaterThanOrEqualTo n)
	{
		requireTypes(n, ">=", IS_COMPARABLE);
	}

	
	
	public override void Visit(LessThan n)
	{
		requireTypes(n, "<", IS_COMPARABLE);
	}

	
	
	public override void Visit(LessThanOrEqualTo n)
	{
		requireTypes(n, "<=", IS_COMPARABLE);
	}

	
	
	public override void Visit(LogicalAnd n)
	{
		requireTypes(n, "&&", IS_LOGICAL);
	}

	
	
	public override void Visit(LogicalOr n)
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
