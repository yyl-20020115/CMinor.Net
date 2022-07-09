using CMinor.AST;
using CMinor.Semantic;
using CMinor.Symbol;
using System;
using System.Collections;
using System.IO;

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
		int numLocals = P_0.NumLocals;
		if (numLocals != 0)
		{
			output.WriteLine(("subl $")+(4 * numLocals)+(", %esp")
				);
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
		P_0.Arg1.Accept(this);
		output.WriteLine((P_1)+(" (%esp), %eax\naddl $4, %esp"));
	}

	
	
	private void comp(RelationalOperator P_0, string P_1)
	{
		P_0.Arg2.Accept(this);
		output.WriteLine("pushl %eax");
		P_0.Arg1.Accept(this);
		string label = labeler.GetCurrentLabel();
		string label2 = labeler.GetCurrentLabel();
		output.WriteLine(("popl %ebx\ncmpl %ebx, %eax\n")+(P_1)+(" ")
			+(label)
			+("\nmovl $0, %eax\njmp ")
			+(label2)
			+("\n")
			+(label)
			+(":\nmovl $1, %eax\n")
			+(label2)
			+(":")
			);
	}

	
	
	private void logical(BinaryLogicalOperator P_0, string P_1)
	{
		P_0.Arg1.Accept(this);
		string label = labeler.GetCurrentLabel();
		output.WriteLine(("cmpl $0, %eax\n")+(P_1)+(" ")
			+(label)
			);
		P_0.Arg2.Accept(this);
		output.WriteLine((label)+(":"));
	}

	
	
	public override void Visit(AstNode n)
	{
		Console.Error.WriteLine(("code generation in ")+(n.DotLabel)+(" is a stub")
			);
	}

	public override void Visit(Program n)
	{
		program = n;
		labeler = new LabelGenerator("control");
		output.WriteLine(".data");
		Iterator iterator = n.StringSymbols.iterator();
		while (iterator.hasNext())
		{
			StringSymbol stringSymbol = (StringSymbol)iterator.next();
			output.WriteLine((stringSymbol.Label)+(": .asciz \"")+(StringLiteral.escape(stringSymbol.Value))
				+("\"")
				);
		}
		iterator = n.GlobalVariables.iterator();
		while (iterator.hasNext())
		{
			GlobalVariableDeclaration globalVariableDeclaration = (GlobalVariableDeclaration)iterator.next();
			globalVariableDeclaration.Accept(this);
		}
		output.WriteLine(".section .text\n.globl _start\n_start:");
		inMainFunction = true;
		n.MainFunction.Accept(this);
		inMainFunction = false;
		iterator = n.Functions.iterator();
		while (iterator.hasNext())
		{
			FunctionDefinition functionDefinition = (FunctionDefinition)iterator.next();
			functionDefinition.Accept(this);
		}
	}

	
	
	public override void Visit(FunctionDefinition n)
	{
		if (inMainFunction)
		{
			if (n.NumLocals != 0)
			{
				output.WriteLine("movl %esp, %ebp");
			}
			allocateLocals(n);
			n.Body.Accept(this);
			return;
		}
		output.WriteLine((n.Symbol.Label)+(":\npushl %ebp\nmovl %esp, %ebp"));
		allocateLocals(n);
		n.Body.Accept(this);
		if (!n.EndsWithReturn)
		{
			printReturnCode();
		}
	}

	
	
	public override void Visit(GlobalVariableDeclaration n)
	{
		output.WriteLine((n.Symbol.Label)+(": .long"));
	}

	
	
	public override void Visit(GlobalVariableInitialization n)
	{
		output.WriteLine((n.Symbol.Label)+(": .long ")+(GlobalInitVisitor.get(n.Value))
			);
	}

	public override void Visit(Declaration n)
	{
	}

	
	
	public override void Visit(Initialization n)
	{
		output.WriteLine(("movl ")+(ExpressionLocationVisitor.get(n.Value))+(", ")
			+(SymbolLocationVisitor.get(n.Identifier.Symbol))
			);
	}

	
	public override void visit(PrintStatement n)
	{
		IList actualArguments = n.ActualArguments;
		int num = actualArguments.Count;
		for (int i = num - 1; i >= 0; i += -1)
		{
			Expression expression = (Expression)actualArguments[i];
			expression.Accept(this);
			if (expression.Type == Type.boolean_type)
			{
				output.WriteLine(("imull $")+(PrintStatement.offset)+(", %eax\naddl $")
					+(program.BooleanStringSymbol.Label)
					+(", %eax")
					);
			}
			output.WriteLine("pushl %eax");
		}
		output.WriteLine(("pushl $")+(n.Symbol.Label)+("\ncall printf")
			);
		output.WriteLine(("addl $")+(4 * (num + 1))+(", %esp")
			);
	}

	
	
	public override void Visit(BlockStatement n)
	{
		foreach(Declaration declaration in n.Declarations)
		{
			declaration.Accept(this);
		}
		foreach(Statement statement in n.Statements)
		{
			statement.Accept(this);
		}
	}

	
	
	public override void Visit(IfStatement n)
	{
		string label = labeler.GetCurrentLabel();
		n.Condition.Accept(this);
		output.WriteLine(("cmpl $0, %eax\nje ")+(label));
		n.IfClause.Accept(this);
		output.WriteLine((label)+(":"));
	}
	
	public override void Visit(IfElseStatement n)
	{
		string label = labeler.GetCurrentLabel();
		string label2 = labeler.GetCurrentLabel();
		n.Condition.Accept(this);
		output.WriteLine(("cmpl $0, %eax\nje ")+(label));
		n.IfClause.Accept(this);
		output.WriteLine(("jmp ")+(label2)+("\n")
			+(label)
			+(":")
			);
		n.ElseClause.Accept(this);
		output.WriteLine((label2)+(":"));
	}

	public override void Visit(WhileStatement n)
	{
		string label = labeler.GetCurrentLabel();
		string label2 = labeler.GetCurrentLabel();
		output.WriteLine((label)+(":"));
		n.Condition.Accept(this);
		output.WriteLine(("cmpl $0, %eax\nje ")+(label2));
		n.Body.Accept(this);
		output.WriteLine(("jmp ")+(label)+("\n")
			+(label2)
			+(":")
			);
	}

	
	
	public override void Visit(ReturnVoidStatement n)
	{
		printReturnCode();
	}

	
	
	public override void Visit(ReturnValueStatement n)
	{
		n.Value.Accept(this);
		if (inMainFunction)
		{
			output.WriteLine("pushl %eax\ncall exit");
		}
		else
		{
			printReturnCode();
		}
	}

	
	
	public override void Visit(Assignment n)
	{
		n.Value.Accept(this);
		output.WriteLine(("movl %eax, ")+(SymbolLocationVisitor.get(n.Identifier.Symbol)));
	}

	
	public override void Visit(FunctionCall n)
	{
		IList arguments = n.Arguments;
		int num = arguments.Count;
		for (int i = num - 1; i >= 0; i += -1)
		{
            ((Expression)arguments[i]).Accept(this);
			output.WriteLine("pushl %eax");
		}
		output.WriteLine(("call ")+(n.Symbol.Label));
		if (num != 0)
		{
			output.WriteLine(("addl $")+(num * 4)+(", %esp")
				);
		}
	}
	
	public override void Visit(IdentifierExpression n)
	{
		output.WriteLine(("movl ")+(SymbolLocationVisitor.get(n.Identifier.Symbol))+(", %eax")
			);
	}

	
	
	public override void Visit(ConstantExpression n)
	{
		output.WriteLine(("movl ")+(ExpressionLocationVisitor.get(n))+(", %eax")
			);
	}

	
	
	public override void Visit(Negative n)
	{
		n.Arg1.Accept(this);
		output.WriteLine("negl %eax");
	}

	
	
	public override void Visit(LogicalNot n)
	{
		n.Arg1.Accept(this);
		output.WriteLine("negl %eax\nincl %eax");
	}

	
	
	public override void Visit(Addition n)
	{
		arith(n, "addl");
	}

	
	
	public override void Visit(Subtraction n)
	{
		arith(n, "subl");
	}

	
	
	public override void Visit(Multiplication n)
	{
		arith(n, "imull");
	}

	
	
	public override void Visit(EqualTo n)
	{
		comp(n, "je");
	}

	
	
	public override void Visit(NotEqualTo n)
	{
		comp(n, "jne");
	}

	
	
	public override void Visit(GreaterThan n)
	{
		comp(n, "jg");
	}

	
	
	public override void Visit(GreaterThanOrEqualTo n)
	{
		comp(n, "jge");
	}

	
	
	public override void Visit(LessThan n)
	{
		comp(n, "jl");
	}

	
	
	public override void Visit(LessThanOrEqualTo n)
	{
		comp(n, "jle");
	}

	
	
	public override void Visit(LogicalAnd n)
	{
		logical(n, "je");
	}

	
	
	public override void Visit(LogicalOr n)
	{
		logical(n, "jne");
	}
}
