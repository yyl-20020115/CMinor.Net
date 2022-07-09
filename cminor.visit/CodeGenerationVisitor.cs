
using CMinor.AST;
using CMinor.semantic;
using CMinor.Symbol;

using java.io;



namespace CMinor.Visit;

public class CodeGenerationVisitor : Visitor
{
	private const string ACCUM = "%eax";

	private const string STACKP = "%esp";

	private const string BASEP = "%ebp";

	private const string TEMP = "%ebx";

	private TextWriter output;

	private Program program;

	private bool inMainFunction;

	private LabelGenerator labeler;

	
	
	public CodeGenerationVisitor(TextWriter output)
	{
		this.output = output;
	}

	
	
	private void allocateLocals(FunctionDefinition P_0)
	{
		int numLocals = P_0.getNumLocals();
		if (numLocals != 0)
		{
			output.WriteLine(("subl $")+(4 * numLocals)+(", %esp")
				.ToString());
		}
	}

	
	
	private void printReturnCode()
	{
		output.WriteLine("movl %ebp, %esp\npopl %ebp\nret");
	}

	
	
	private void arith(BinaryArithmeticOperator P_0, string P_1)
	{
		P_0.Arg2.Accept(this);
		output.WriteLine("pushl %eax");
		P_0.getArg1().Accept(this);
		output.WriteLine((P_1)+(" (%esp), %eax\naddl $4, %esp").ToString());
	}

	
	
	private void comp(RelationalOperator P_0, string P_1)
	{
		P_0.Arg2.Accept(this);
		output.WriteLine("pushl %eax");
		P_0.getArg1().Accept(this);
		string label = labeler.getLabel();
		string label2 = labeler.getLabel();
		output.WriteLine(("popl %ebx\ncmpl %ebx, %eax\n")+(P_1)+(" ")
			+(label)
			+("\nmovl $0, %eax\njmp ")
			+(label2)
			+("\n")
			+(label)
			+(":\nmovl $1, %eax\n")
			+(label2)
			+(":")
			.ToString());
	}

	
	
	private void logical(BinaryLogicalOperator P_0, string P_1)
	{
		P_0.getArg1().Accept(this);
		string label = labeler.getLabel();
		output.WriteLine(("cmpl $0, %eax\n")+(P_1)+(" ")
			+(label)
			.ToString());
		P_0.Arg2.Accept(this);
		output.WriteLine((label)+(":").ToString());
	}

	
	
	public override void visit(AstNode n)
	{
		java.lang.System.err.WriteLine(("code generation in ")+(n.getDotLabel())+(" is a stub")
			.ToString());
	}

	
	[LineNumberTable(new byte[]
	{
		29, 103, 144, 144, 127, 1, 127, 37, 130, 127,
		1, 103, 130, 144, 103, 108, 103, 127, 1, 103,
		130
	})]
	public override void visit(Program n)
	{
		program = n;
		labeler = new LabelGenerator("control");
		output.WriteLine(".data");
		Iterator iterator = n.getStringSymbols().iterator();
		while (iterator.hasNext())
		{
			StringSymbol stringSymbol = (StringSymbol)iterator.next();
			output.WriteLine((stringSymbol.getLabel())+(": .asciz \"")+(StringLiteral.escape(stringSymbol.getValue()))
				+("\"")
				.ToString());
		}
		iterator = n.getGlobalVariables().iterator();
		while (iterator.hasNext())
		{
			GlobalVariableDeclaration globalVariableDeclaration = (GlobalVariableDeclaration)iterator.next();
			globalVariableDeclaration.Accept(this);
		}
		output.WriteLine(".section .text\n.globl _start\n_start:");
		inMainFunction = true;
		n.getMainFunction().Accept(this);
		inMainFunction = false;
		iterator = n.getFunctions().iterator();
		while (iterator.hasNext())
		{
			FunctionDefinition functionDefinition = (FunctionDefinition)iterator.next();
			functionDefinition.Accept(this);
		}
	}

	
	
	public override void visit(FunctionDefinition n)
	{
		if (inMainFunction)
		{
			if (n.getNumLocals() != 0)
			{
				output.WriteLine("movl %esp, %ebp");
			}
			allocateLocals(n);
			n.getBody().Accept(this);
			return;
		}
		output.WriteLine((n.getSymbol().getLabel())+(":\npushl %ebp\nmovl %esp, %ebp").ToString());
		allocateLocals(n);
		n.getBody().Accept(this);
		if (!n.endsWithReturn())
		{
			printReturnCode();
		}
	}

	
	
	public override void visit(GlobalVariableDeclaration n)
	{
		output.WriteLine((n.getSymbol().getLabel())+(": .long").ToString());
	}

	
	
	public override void visit(GlobalVariableInitialization n)
	{
		output.WriteLine((n.getSymbol().getLabel())+(": .long ")+(GlobalInitVisitor.get(n.getValue()))
			.ToString());
	}

	public override void visit(Declaration n)
	{
	}

	
	
	public override void visit(Initialization n)
	{
		output.WriteLine(("movl ")+(ExpressionLocationVisitor.get(n.getValue()))+(", ")
			+(SymbolLocationVisitor.get(n.getIdentifier().getSymbol()))
			.ToString());
	}

	
	[LineNumberTable(new byte[]
	{
		109,
		103,
		103,
		107,
		109,
		167,
		141,
		byte.MaxValue,
		51,
		69,
		240,
		52,
		233,
		80,
		223,
		26,
		159,
		22
	})]
	public override void visit(PrintStatement n)
	{
		List actualArguments = n.getActualArguments();
		int num = actualArguments.size();
		for (int i = num - 1; i >= 0; i += -1)
		{
			Expression expression = (Expression)actualArguments.get(i);
			expression.Accept(this);
			if (expression.getType() == Type.___003C_003EBOOLEAN)
			{
				output.WriteLine(("imull $")+(PrintStatement.___003C_003EOFFSET)+(", %eax\naddl $")
					+(program.getBooleanStringSymbol().getLabel())
					+(", %eax")
					.ToString());
			}
			output.WriteLine("pushl %eax");
		}
		output.WriteLine(("pushl $")+(n.getSymbol().getLabel())+("\ncall printf")
			.ToString());
		output.WriteLine(("addl $")+(4 * (num + 1))+(", %esp")
			.ToString());
	}

	
	
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
			statement.Accept(this);
		}
	}

	
	
	public override void visit(IfStatement n)
	{
		string label = labeler.getLabel();
		n.getCondition().Accept(this);
		output.WriteLine(("cmpl $0, %eax\nje ")+(label).ToString());
		n.getIfClause().Accept(this);
		output.WriteLine((label)+(":").ToString());
	}

	
	[LineNumberTable(new byte[]
	{
		160, 85, 120, 108, 127, 6, 108, 127, 32, 108,
		127, 8
	})]
	public override void visit(IfElseStatement n)
	{
		string label = labeler.getLabel();
		string label2 = labeler.getLabel();
		n.getCondition().Accept(this);
		output.WriteLine(("cmpl $0, %eax\nje ")+(label).ToString());
		n.getIfClause().Accept(this);
		output.WriteLine(("jmp ")+(label2)+("\n")
			+(label)
			+(":")
			.ToString());
		n.getElseClause().Accept(this);
		output.WriteLine((label2)+(":").ToString());
	}

	
	[LineNumberTable(new byte[]
	{
		160, 95, 120, 127, 6, 108, 127, 6, 108, 127,
		34
	})]
	public override void visit(WhileStatement n)
	{
		string label = labeler.getLabel();
		string label2 = labeler.getLabel();
		output.WriteLine((label)+(":").ToString());
		n.getCondition().Accept(this);
		output.WriteLine(("cmpl $0, %eax\nje ")+(label2).ToString());
		n.getBody().Accept(this);
		output.WriteLine(("jmp ")+(label)+("\n")
			+(label2)
			+(":")
			.ToString());
	}

	
	
	public override void visit(ReturnVoidStatement n)
	{
		printReturnCode();
	}

	
	
	public override void visit(ReturnValueStatement n)
	{
		n.getValue().Accept(this);
		if (inMainFunction)
		{
			output.WriteLine("pushl %eax\ncall exit");
		}
		else
		{
			printReturnCode();
		}
	}

	
	
	public override void visit(Assignment n)
	{
		n.Value.Accept(this);
		output.WriteLine(("movl %eax, ")+(SymbolLocationVisitor.get(n.Identifier.getSymbol())).ToString());
	}

	
	[LineNumberTable(new byte[]
	{
		160, 128, 103, 103, 104, 114, 16, 230, 70, 191,
		16, 159, 23
	})]
	public override void visit(FunctionCall n)
	{
		List arguments = n.getArguments();
		int num = arguments.size();
		for (int i = num - 1; i >= 0; i += -1)
		{
			((Expression)arguments.get(i)).Accept(this);
			output.WriteLine("pushl %eax");
		}
		output.WriteLine(("call ")+(n.getSymbol().getLabel()).ToString());
		if (num != 0)
		{
			output.WriteLine(("addl $")+(num * 4)+(", %esp")
				.ToString());
		}
	}

	
	
	public override void visit(IdentifierExpression n)
	{
		output.WriteLine(("movl ")+(SymbolLocationVisitor.get(n.getIdentifier().getSymbol()))+(", %eax")
			.ToString());
	}

	
	
	public override void visit(ConstantExpression n)
	{
		output.WriteLine(("movl ")+(ExpressionLocationVisitor.get(n))+(", %eax")
			.ToString());
	}

	
	
	public override void visit(Negative n)
	{
		n.getArg1().Accept(this);
		output.WriteLine("negl %eax");
	}

	
	
	public override void visit(LogicalNot n)
	{
		n.getArg1().Accept(this);
		output.WriteLine("negl %eax\nincl %eax");
	}

	
	
	public override void Visit(Addition n)
	{
		arith(n, "addl");
	}

	
	
	public override void visit(Subtraction n)
	{
		arith(n, "subl");
	}

	
	
	public override void visit(Multiplication n)
	{
		arith(n, "imull");
	}

	
	
	public override void visit(EqualTo n)
	{
		comp(n, "je");
	}

	
	
	public override void visit(NotEqualTo n)
	{
		comp(n, "jne");
	}

	
	
	public override void visit(GreaterThan n)
	{
		comp(n, "jg");
	}

	
	
	public override void visit(GreaterThanOrEqualTo n)
	{
		comp(n, "jge");
	}

	
	
	public override void visit(LessThan n)
	{
		comp(n, "jl");
	}

	
	
	public override void visit(LessThanOrEqualTo n)
	{
		comp(n, "jle");
	}

	
	
	public override void visit(LogicalAnd n)
	{
		logical(n, "je");
	}

	
	
	public override void visit(LogicalOr n)
	{
		logical(n, "jne");
	}
}
