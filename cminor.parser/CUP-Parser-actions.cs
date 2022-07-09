using CMinor.AST;
using CMinor.Semantic;
using JavaCUP.Runtime;
using System.Collections.Generic;

namespace CMinor.Parser;

internal class CUP_0024Parser_0024actions
{
	
	private Parser parser;

	
	
	private LocationInfo info()
	{
		LocationInfo result = parser.info();
		
		return result;
	}

	
	
	internal CUP_0024Parser_0024actions(Parser P_0)
	{
		parser = P_0;
	}

	public JavaCUP.Runtime.Symbol CUP_0024Parser_0024do_action(int P_0, LRParser P_1, Stack<JavaCUP.Runtime.Symbol> _P_2, int P_3)
	{
		var P_2 = _P_2.ToArray();
		switch (P_0)
		{
		case 74:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			Expression condition = (Expression)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			ArgumentList argumentList = new ArgumentList();
			argumentList.Add(condition);
			ArgumentList o45 = argumentList;
			return new JavaCUP.Runtime.Symbol(16, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o45);
		}
		case 73:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).right;
			ArgumentList arguments = (ArgumentList)((JavaCUP.Runtime.Symbol)P_2[P_3-2]).value;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			Expression right = (Expression)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			arguments.Add(right);
			ArgumentList o45 = arguments;
			return new JavaCUP.Runtime.Symbol(16, ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o45);
		}
		case 72:
		{
			
			ArgumentList o45 = new ArgumentList();
			return new JavaCUP.Runtime.Symbol(15, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o45);
		}
		case 71:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			ArgumentList arguments = (ArgumentList)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			ArgumentList o45 = arguments;
			return new JavaCUP.Runtime.Symbol(15, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o45);
		}
		case 70:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).right;
			TypeSpecifier type = (TypeSpecifier)((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).value;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			string name3 = (string)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			Parameter o44 = new Parameter(info(), type, new Identifier(info(), name3));
			return new JavaCUP.Runtime.Symbol(14, ((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o44);
		}
		case 69:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			Parameter e5 = (Parameter)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			ParameterList parameterList2 = new ParameterList();
			parameterList2.Add(e5);
			ParameterList o43 = parameterList2;
			return new JavaCUP.Runtime.Symbol(13, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o43);
		}
		case 68:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).right;
			ParameterList parameterList = (ParameterList)((JavaCUP.Runtime.Symbol)P_2[P_3-2]).value;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			Parameter e4 = (Parameter)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			parameterList.Add(e4);
			ParameterList o43 = parameterList;
			return new JavaCUP.Runtime.Symbol(13, ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o43);
		}
		case 67:
		{
			
			ParameterList o43 = new ParameterList();
			return new JavaCUP.Runtime.Symbol(10, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o43);
		}
		case 66:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			ParameterList parameterList = (ParameterList)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			ParameterList o43 = parameterList;
			return new JavaCUP.Runtime.Symbol(10, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o43);
		}
		case 65:
		{
			
			BooleanLiteral o42 = new BooleanLiteral(info(), ( false));
			return new JavaCUP.Runtime.Symbol(6, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o42);
		}
		case 64:
		{
			
			BooleanLiteral o42 = new BooleanLiteral(info(), ( true));
			return new JavaCUP.Runtime.Symbol(6, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o42);
		}
		case 63:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			string name2 = (string)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			StringLiteral o41 = new StringLiteral(info(), name2);
			return new JavaCUP.Runtime.Symbol(6, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o41);
		}
		case 62:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			int value3 = (int)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			IntegerLiteral o40 = new IntegerLiteral(info(), value3);
			return new JavaCUP.Runtime.Symbol(6, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o40);
		}
		case 61:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			char value2 = (char)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			CharacterLiteral o39 = new CharacterLiteral(info(), value2);
			return new JavaCUP.Runtime.Symbol(6, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o39);
		}
		case 60:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			string name2 = (string)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			Identifier o38 = new Identifier(info(), name2);
			return new JavaCUP.Runtime.Symbol(9, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o38);
		}
		case 59:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3 - 3]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3 - 3]).right;
			Identifier left = (Identifier)((JavaCUP.Runtime.Symbol)P_2[P_3 - 3]).value;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).right;
			ArgumentList arguments2 = (ArgumentList)((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).value;
			FunctionCall o37 = new FunctionCall(info(), left, arguments2);
			return new JavaCUP.Runtime.Symbol(27, ((JavaCUP.Runtime.Symbol)P_2[P_3 - 3]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o37);
		}
		case 58:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			ConstantExpression constantExpression = (ConstantExpression)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			ConstantExpression o36 = constantExpression;
			return new JavaCUP.Runtime.Symbol(27, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o36);
		}
		case 57:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			Identifier left = (Identifier)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			IdentifierExpression o35 = new IdentifierExpression(info(), left);
			return new JavaCUP.Runtime.Symbol(27, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o35);
		}
		case 56:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).right;
			Expression condition = (Expression)((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).value;
			Expression o14 = condition;
			return new JavaCUP.Runtime.Symbol(27, ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o14);
		}
		case 55:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			Expression condition = (Expression)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			Expression o14 = condition;
			return new JavaCUP.Runtime.Symbol(26, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o14);
		}
		case 54:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			Expression condition = (Expression)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			Negative o34 = new Negative(info(), condition);
			return new JavaCUP.Runtime.Symbol(26, ((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o34);
		}
		case 53:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			Expression condition = (Expression)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			LogicalNot o33 = new LogicalNot(info(), condition);
			return new JavaCUP.Runtime.Symbol(26, ((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o33);
		}
		case 52:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			Expression condition = (Expression)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			Expression o14 = condition;
			return new JavaCUP.Runtime.Symbol(25, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o14);
		}
		case 51:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).right;
			Expression condition = (Expression)((JavaCUP.Runtime.Symbol)P_2[P_3-2]).value;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			Expression right = (Expression)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			Division o32 = new Division(info(), condition, right);
			return new JavaCUP.Runtime.Symbol(25, ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o32);
		}
		case 50:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).right;
			Expression condition = (Expression)((JavaCUP.Runtime.Symbol)P_2[P_3-2]).value;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			Expression right = (Expression)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			Multiplication o31 = new Multiplication(info(), condition, right);
			return new JavaCUP.Runtime.Symbol(25, ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o31);
		}
		case 49:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			Expression condition = (Expression)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			Expression o14 = condition;
			return new JavaCUP.Runtime.Symbol(24, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o14);
		}
		case 48:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).right;
			Expression condition = (Expression)((JavaCUP.Runtime.Symbol)P_2[P_3-2]).value;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			Expression right = (Expression)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			Subtraction o30 = new Subtraction(info(), condition, right);
			return new JavaCUP.Runtime.Symbol(24, ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o30);
		}
		case 47:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).right;
			Expression condition = (Expression)((JavaCUP.Runtime.Symbol)P_2[P_3-2]).value;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			Expression right = (Expression)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			Addition o29 = new Addition(info(), condition, right);
			return new JavaCUP.Runtime.Symbol(24, ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o29);
		}
		case 46:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			Expression condition = (Expression)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			Expression o14 = condition;
			return new JavaCUP.Runtime.Symbol(23, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o14);
		}
		case 45:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).right;
			Expression condition = (Expression)((JavaCUP.Runtime.Symbol)P_2[P_3-2]).value;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			Expression right = (Expression)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			GreaterThanOrEqualTo o28 = new GreaterThanOrEqualTo(info(), condition, right);
			return new JavaCUP.Runtime.Symbol(23, ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o28);
		}
		case 44:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).right;
			Expression condition = (Expression)((JavaCUP.Runtime.Symbol)P_2[P_3-2]).value;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			Expression right = (Expression)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			LessThanOrEqualTo o27 = new LessThanOrEqualTo(info(), condition, right);
			return new JavaCUP.Runtime.Symbol(23, ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o27);
		}
		case 43:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).right;
			Expression condition = (Expression)((JavaCUP.Runtime.Symbol)P_2[P_3-2]).value;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			Expression right = (Expression)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			GreaterThan o26 = new GreaterThan(info(), condition, right);
			return new JavaCUP.Runtime.Symbol(23, ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o26);
		}
		case 42:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).right;
			Expression condition = (Expression)((JavaCUP.Runtime.Symbol)P_2[P_3-2]).value;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			Expression right = (Expression)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			LessThan o25 = new LessThan(info(), condition, right);
			return new JavaCUP.Runtime.Symbol(23, ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o25);
		}
		case 41:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			Expression condition = (Expression)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			Expression o14 = condition;
			return new JavaCUP.Runtime.Symbol(22, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o14);
		}
		case 40:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).right;
			Expression condition = (Expression)((JavaCUP.Runtime.Symbol)P_2[P_3-2]).value;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			Expression right = (Expression)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			NotEqualTo o24 = new NotEqualTo(info(), condition, right);
			return new JavaCUP.Runtime.Symbol(22, ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o24);
		}
		case 39:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).right;
			Expression condition = (Expression)((JavaCUP.Runtime.Symbol)P_2[P_3-2]).value;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			Expression right = (Expression)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			EqualTo o23 = new EqualTo(info(), condition, right);
			return new JavaCUP.Runtime.Symbol(22, ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o23);
		}
		case 38:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			Expression condition = (Expression)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			Expression o14 = condition;
			return new JavaCUP.Runtime.Symbol(21, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o14);
		}
		case 37:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).right;
			Expression condition = (Expression)((JavaCUP.Runtime.Symbol)P_2[P_3-2]).value;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			Expression right = (Expression)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			LogicalAnd o22 = new LogicalAnd(info(), condition, right);
			return new JavaCUP.Runtime.Symbol(21, ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o22);
		}
		case 36:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			Expression condition = (Expression)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			Expression o14 = condition;
			return new JavaCUP.Runtime.Symbol(20, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o14);
		}
		case 35:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).right;
			Expression condition = (Expression)((JavaCUP.Runtime.Symbol)P_2[P_3-2]).value;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			Expression right = (Expression)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			LogicalOr o21 = new LogicalOr(info(), condition, right);
			return new JavaCUP.Runtime.Symbol(20, ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o21);
		}
		case 34:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			Expression condition = (Expression)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			Expression o14 = condition;
			return new JavaCUP.Runtime.Symbol(19, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o14);
		}
		case 33:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).right;
			Identifier left = (Identifier)((JavaCUP.Runtime.Symbol)P_2[P_3-2]).value;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			Expression right = (Expression)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			Assignment o20 = new Assignment(info(), left, right);
			return new JavaCUP.Runtime.Symbol(19, ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o20);
		}
		case 32:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3 - 4]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3 - 4]).right;
			Expression condition = (Expression)((JavaCUP.Runtime.Symbol)P_2[P_3 - 4]).value;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).right;
			Statement e3 = (Statement)((JavaCUP.Runtime.Symbol)P_2[P_3-2]).value;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			Statement elseStatement = (Statement)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			IfElseStatement o13 = new IfElseStatement(info(), condition, e3, elseStatement);
			return new JavaCUP.Runtime.Symbol(18, ((JavaCUP.Runtime.Symbol)P_2[P_3 - 6]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o13);
		}
		case 31:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).right;
			Expression condition = (Expression)((JavaCUP.Runtime.Symbol)P_2[P_3-2]).value;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			Statement e3 = (Statement)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			IfStatement o19 = new IfStatement(info(), condition, e3);
			return new JavaCUP.Runtime.Symbol(18, ((JavaCUP.Runtime.Symbol)P_2[P_3 - 4]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o19);
		}
		case 30:
		{
			
			ReturnVoidStatement o18 = new ReturnVoidStatement(info());
			return new JavaCUP.Runtime.Symbol(17, ((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o18);
		}
		case 29:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).right;
			Expression condition = (Expression)((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).value;
			ReturnValueStatement o17 = new ReturnValueStatement(info(), condition);
			return new JavaCUP.Runtime.Symbol(17, ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o17);
		}
		case 28:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).right;
			Expression condition = (Expression)((JavaCUP.Runtime.Symbol)P_2[P_3-2]).value;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			Statement e3 = (Statement)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			WhileStatement o16 = new WhileStatement(info(), condition, e3);
			return new JavaCUP.Runtime.Symbol(17, ((JavaCUP.Runtime.Symbol)P_2[P_3 - 4]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o16);
		}
		case 27:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).right;
			ArgumentList arguments = (ArgumentList)((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).value;
			PrintStatement o15 = new PrintStatement(info(), arguments);
			return new JavaCUP.Runtime.Symbol(17, ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o15);
		}
		case 26:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			BlockStatement blockStatement = (BlockStatement)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			BlockStatement o7 = blockStatement;
			return new JavaCUP.Runtime.Symbol(17, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o7);
		}
		case 25:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).right;
			Expression condition = (Expression)((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).value;
			Expression o14 = condition;
			return new JavaCUP.Runtime.Symbol(17, ((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o14);
		}
		case 24:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3 - 4]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3 - 4]).right;
			Expression condition = (Expression)((JavaCUP.Runtime.Symbol)P_2[P_3 - 4]).value;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).right;
			Statement e3 = (Statement)((JavaCUP.Runtime.Symbol)P_2[P_3-2]).value;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			Statement elseStatement = (Statement)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			IfElseStatement o13 = new IfElseStatement(info(), condition, e3, elseStatement);
			return new JavaCUP.Runtime.Symbol(17, ((JavaCUP.Runtime.Symbol)P_2[P_3 - 6]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o13);
		}
		case 23:
			
			return new JavaCUP.Runtime.Symbol(12, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, null);
		case 22:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			Statement statement = (Statement)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			Statement o12 = statement;
			return new JavaCUP.Runtime.Symbol(12, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o12);
		}
		case 21:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			Statement statement = (Statement)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			Statement o12 = statement;
			return new JavaCUP.Runtime.Symbol(12, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o12);
		}
		case 20:
		{
			
			StatementList o11 = new StatementList();
			return new JavaCUP.Runtime.Symbol(11, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o11);
		}
		case 19:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).right;
			StatementList statementList = (StatementList)((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).value;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			Statement e3 = (Statement)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			statementList.Add(e3);
			StatementList o11 = statementList;
			return new JavaCUP.Runtime.Symbol(11, ((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o11);
		}
		case 18:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3 - 4]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3 - 4]).right;
			TypeSpecifier type = (TypeSpecifier)((JavaCUP.Runtime.Symbol)P_2[P_3 - 4]).value;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3 - 3]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3 - 3]).right;
			Identifier name = (Identifier)((JavaCUP.Runtime.Symbol)P_2[P_3 - 3]).value;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).right;
			ConstantExpression value = (ConstantExpression)((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).value;
			Initialization o10 = new Initialization(info(), type, name, value);
			return new JavaCUP.Runtime.Symbol(8, ((JavaCUP.Runtime.Symbol)P_2[P_3 - 4]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o10);
		}
		case 17:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).right;
			TypeSpecifier type = (TypeSpecifier)((JavaCUP.Runtime.Symbol)P_2[P_3-2]).value;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).right;
			Identifier name = (Identifier)((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).value;
			Declaration o9 = new Declaration(info(), type, name);
			return new JavaCUP.Runtime.Symbol(8, ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o9);
		}
		case 16:
		{
			
			DeclarationList o8 = new DeclarationList();
			return new JavaCUP.Runtime.Symbol(7, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o8);
		}
		case 15:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).right;
			DeclarationList declarations2 = (DeclarationList)((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).value;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			Declaration e2 = (Declaration)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			declarations2.Add(e2);
			DeclarationList o8 = declarations2;
			return new JavaCUP.Runtime.Symbol(7, ((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o8);
		}
		case 14:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).right;
			DeclarationList declarations2 = (DeclarationList)((JavaCUP.Runtime.Symbol)P_2[P_3-2]).value;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).right;
			StatementList statements = (StatementList)((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).value;
			BlockStatement o7 = new BlockStatement(info(), declarations2, statements);
			return new JavaCUP.Runtime.Symbol(5, ((JavaCUP.Runtime.Symbol)P_2[P_3 - 3]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o7);
		}
		case 13:
		{
			
			TypeSpecifier o6 = new TypeSpecifier(info(), Types.void_type);
			return new JavaCUP.Runtime.Symbol(4, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o6);
		}
		case 12:
		{
			
			TypeSpecifier o6 = new TypeSpecifier(info(), Types.string_type);
			return new JavaCUP.Runtime.Symbol(4, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o6);
		}
		case 11:
		{
			
			TypeSpecifier o6 = new TypeSpecifier(info(), Types.integer_type);
			return new JavaCUP.Runtime.Symbol(4, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o6);
		}
		case 10:
		{
			
			TypeSpecifier o6 = new TypeSpecifier(info(), Types.char_type);
			return new JavaCUP.Runtime.Symbol(4, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o6);
		}
		case 9:
		{
			
			TypeSpecifier o6 = new TypeSpecifier(info(), Types.boolean_type);
			return new JavaCUP.Runtime.Symbol(4, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o6);
		}
		case 8:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-5]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-5]).right;
			TypeSpecifier type = (TypeSpecifier)((JavaCUP.Runtime.Symbol)P_2[P_3-5]).value;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3 - 4]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3 - 4]).right;
			Identifier name = (Identifier)((JavaCUP.Runtime.Symbol)P_2[P_3 - 4]).value;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).right;
			ParameterList parameters = (ParameterList)((JavaCUP.Runtime.Symbol)P_2[P_3-2]).value;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			BlockStatement body = (BlockStatement)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			FunctionDefinition o5 = new FunctionDefinition(info(), type, name, parameters, body);
			return new JavaCUP.Runtime.Symbol(3, ((JavaCUP.Runtime.Symbol)P_2[P_3-5]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o5);
		}
		case 7:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3 - 4]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3 - 4]).right;
			TypeSpecifier type = (TypeSpecifier)((JavaCUP.Runtime.Symbol)P_2[P_3 - 4]).value;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3 - 3]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3 - 3]).right;
			Identifier name = (Identifier)((JavaCUP.Runtime.Symbol)P_2[P_3 - 3]).value;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).right;
			ConstantExpression value = (ConstantExpression)((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).value;
			GlobalVariableInitialization o4 = new GlobalVariableInitialization(info(), type, name, value);
			return new JavaCUP.Runtime.Symbol(3, ((JavaCUP.Runtime.Symbol)P_2[P_3 - 4]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o4);
		}
		case 6:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).right;
			TypeSpecifier type = (TypeSpecifier)((JavaCUP.Runtime.Symbol)P_2[P_3-2]).value;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).right;
			Identifier name = (Identifier)((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).value;
			GlobalVariableDeclaration o3 = new GlobalVariableDeclaration(info(), type, name);
			return new JavaCUP.Runtime.Symbol(3, ((JavaCUP.Runtime.Symbol)P_2[P_3-2]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o3);
		}
		case 5:
			
			return new JavaCUP.Runtime.Symbol(2, ((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, null);
		case 4:
		{
			
			ExternalDeclarationList o2 = new ExternalDeclarationList();
			return new JavaCUP.Runtime.Symbol(2, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o2);
		}
		case 3:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).right;
			ExternalDeclarationList declarations = (ExternalDeclarationList)((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).value;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			ExternalDeclaration e = (ExternalDeclaration)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			declarations.Add(e);
			ExternalDeclarationList o2 = declarations;
			return new JavaCUP.Runtime.Symbol(2, ((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o2);
		}
		case 2:
			
			return new JavaCUP.Runtime.Symbol(1, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, null);
		case 1:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right;
			ExternalDeclarationList declarations = (ExternalDeclarationList)((JavaCUP.Runtime.Symbol)P_2[P_3-0]).value;
			Program o = new Program(info(), declarations);
			return new JavaCUP.Runtime.Symbol(1, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o);
		}
		case 0:
		{
			
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).left;
			_ = ((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).right;
			Program program = (Program)((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).value;
			Program o = program;
			JavaCUP.Runtime.Symbol result = new JavaCUP.Runtime.Symbol(0, ((JavaCUP.Runtime.Symbol)P_2[P_3 - 1]).left, ((JavaCUP.Runtime.Symbol)P_2[P_3-0]).right, o);
			P_1.done_parsing();
			return result;
		}
		default:
			
			throw new System.Exception("Invalid action number found in internal parse table");
		}
	}
}
