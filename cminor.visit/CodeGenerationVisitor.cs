
using CMinor.AST;
using CMinor.semantic;
using CMinor.Symbol;

using java.io;
using java.lang;


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
			output.println(new StringBuilder().append("subl $").append(4 * numLocals).append(", %esp")
				.toString());
		}
	}

	
	
	private void printReturnCode()
	{
		output.println("movl %ebp, %esp\npopl %ebp\nret");
	}

	
	
	private void arith(BinaryArithmeticOperator P_0, string P_1)
	{
		P_0.Arg2.Accept(this);
		output.println("pushl %eax");
		P_0.getArg1().Accept(this);
		output.println(new StringBuilder().append(P_1).append(" (%esp), %eax\naddl $4, %esp").toString());
	}

	
	
	private void comp(RelationalOperator P_0, string P_1)
	{
		P_0.Arg2.Accept(this);
		output.println("pushl %eax");
		P_0.getArg1().Accept(this);
		string label = labeler.getLabel();
		string label2 = labeler.getLabel();
		output.println(new StringBuilder().append("popl %ebx\ncmpl %ebx, %eax\n").append(P_1).append(" ")
			.append(label)
			.append("\nmovl $0, %eax\njmp ")
			.append(label2)
			.append("\n")
			.append(label)
			.append(":\nmovl $1, %eax\n")
			.append(label2)
			.append(":")
			.toString());
	}

	
	
	private void logical(BinaryLogicalOperator P_0, string P_1)
	{
		P_0.getArg1().Accept(this);
		string label = labeler.getLabel();
		output.println(new StringBuilder().append("cmpl $0, %eax\n").append(P_1).append(" ")
			.append(label)
			.toString());
		P_0.Arg2.Accept(this);
		output.println(new StringBuilder().append(label).append(":").toString());
	}

	
	
	public override void visit(AstNode n)
	{
		java.lang.System.err.println(new StringBuilder().append("code generation in ").append(n.getDotLabel()).append(" is a stub")
			.toString());
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
		output.println(".data");
		Iterator iterator = n.getStringSymbols().iterator();
		while (iterator.hasNext())
		{
			StringSymbol stringSymbol = (StringSymbol)iterator.next();
			output.println(new StringBuilder().append(stringSymbol.getLabel()).append(": .asciz \"").append(StringLiteral.escape(stringSymbol.getValue()))
				.append("\"")
				.toString());
		}
		iterator = n.getGlobalVariables().iterator();
		while (iterator.hasNext())
		{
			GlobalVariableDeclaration globalVariableDeclaration = (GlobalVariableDeclaration)iterator.next();
			globalVariableDeclaration.Accept(this);
		}
		output.println(".section .text\n.globl _start\n_start:");
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
				output.println("movl %esp, %ebp");
			}
			allocateLocals(n);
			n.getBody().Accept(this);
			return;
		}
		output.println(new StringBuilder().append(n.getSymbol().getLabel()).append(":\npushl %ebp\nmovl %esp, %ebp").toString());
		allocateLocals(n);
		n.getBody().Accept(this);
		if (!n.endsWithReturn())
		{
			printReturnCode();
		}
	}

	
	
	public override void visit(GlobalVariableDeclaration n)
	{
		output.println(new StringBuilder().append(n.getSymbol().getLabel()).append(": .long").toString());
	}

	
	
	public override void visit(GlobalVariableInitialization n)
	{
		output.println(new StringBuilder().append(n.getSymbol().getLabel()).append(": .long ").append(GlobalInitVisitor.get(n.getValue()))
			.toString());
	}

	public override void visit(Declaration n)
	{
	}

	
	
	public override void visit(Initialization n)
	{
		output.println(new StringBuilder().append("movl ").append(ExpressionLocationVisitor.get(n.getValue())).append(", ")
			.append(SymbolLocationVisitor.get(n.getIdentifier().getSymbol()))
			.toString());
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
				output.println(new StringBuilder().append("imull $").append(PrintStatement.___003C_003EOFFSET).append(", %eax\naddl $")
					.append(program.getBooleanStringSymbol().getLabel())
					.append(", %eax")
					.toString());
			}
			output.println("pushl %eax");
		}
		output.println(new StringBuilder().append("pushl $").append(n.getSymbol().getLabel()).append("\ncall printf")
			.toString());
		output.println(new StringBuilder().append("addl $").append(4 * (num + 1)).append(", %esp")
			.toString());
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
		output.println(new StringBuilder().append("cmpl $0, %eax\nje ").append(label).toString());
		n.getIfClause().Accept(this);
		output.println(new StringBuilder().append(label).append(":").toString());
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
		output.println(new StringBuilder().append("cmpl $0, %eax\nje ").append(label).toString());
		n.getIfClause().Accept(this);
		output.println(new StringBuilder().append("jmp ").append(label2).append("\n")
			.append(label)
			.append(":")
			.toString());
		n.getElseClause().Accept(this);
		output.println(new StringBuilder().append(label2).append(":").toString());
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
		output.println(new StringBuilder().append(label).append(":").toString());
		n.getCondition().Accept(this);
		output.println(new StringBuilder().append("cmpl $0, %eax\nje ").append(label2).toString());
		n.getBody().Accept(this);
		output.println(new StringBuilder().append("jmp ").append(label).append("\n")
			.append(label2)
			.append(":")
			.toString());
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
			output.println("pushl %eax\ncall exit");
		}
		else
		{
			printReturnCode();
		}
	}

	
	
	public override void visit(Assignment n)
	{
		n.Value.Accept(this);
		output.println(new StringBuilder().append("movl %eax, ").append(SymbolLocationVisitor.get(n.Identifier.getSymbol())).toString());
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
			output.println("pushl %eax");
		}
		output.println(new StringBuilder().append("call ").append(n.getSymbol().getLabel()).toString());
		if (num != 0)
		{
			output.println(new StringBuilder().append("addl $").append(num * 4).append(", %esp")
				.toString());
		}
	}

	
	
	public override void visit(IdentifierExpression n)
	{
		output.println(new StringBuilder().append("movl ").append(SymbolLocationVisitor.get(n.getIdentifier().getSymbol())).append(", %eax")
			.toString());
	}

	
	
	public override void visit(ConstantExpression n)
	{
		output.println(new StringBuilder().append("movl ").append(ExpressionLocationVisitor.get(n)).append(", %eax")
			.toString());
	}

	
	
	public override void visit(Negative n)
	{
		n.getArg1().Accept(this);
		output.println("negl %eax");
	}

	
	
	public override void visit(LogicalNot n)
	{
		n.getArg1().Accept(this);
		output.println("negl %eax\nincl %eax");
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
