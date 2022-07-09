
using CMinor.AST;
using CMinor.semantic;

using java_cup.runtime;



namespace CMinor.Parser;

[SourceFile("Parser.java")]
internal class CUP_0024Parser_0024actions
{
	[Modifiers(Modifiers.Private | Modifiers.Final)]
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

	
	[Throws(new string[] { "System.Exception" })]
	[LineNumberTable(new byte[]
	{
		161,
		156,
		byte.MaxValue,
		160,
		216,
		69,
		98,
		117,
		117,
		122,
		112,
		159,
		18,
		226,
		69,
		98,
		117,
		117,
		123,
		117,
		117,
		123,
		109,
		159,
		18,
		226,
		69,
		98,
		102,
		159,
		18,
		226,
		69,
		98,
		117,
		117,
		123,
		99,
		159,
		18,
		226,
		69,
		98,
		117,
		117,
		123,
		117,
		117,
		123,
		124,
		159,
		19,
		226,
		69,
		98,
		117,
		117,
		123,
		117,
		159,
		19,
		226,
		69,
		98,
		117,
		117,
		123,
		117,
		117,
		123,
		110,
		159,
		19,
		226,
		69,
		98,
		103,
		159,
		19,
		226,
		69,
		98,
		117,
		117,
		123,
		100,
		159,
		19,
		226,
		69,
		98,
		115,
		159,
		18,
		226,
		69,
		98,
		115,
		159,
		18,
		226,
		69,
		98,
		117,
		117,
		123,
		111,
		159,
		18,
		226,
		69,
		98,
		117,
		117,
		123,
		111,
		159,
		18,
		226,
		69,
		98,
		117,
		117,
		123,
		111,
		159,
		18,
		226,
		69,
		98,
		117,
		117,
		123,
		111,
		159,
		19,
		226,
		69,
		98,
		117,
		117,
		123,
		117,
		117,
		123,
		113,
		159,
		19,
		226,
		69,
		98,
		117,
		117,
		123,
		100,
		159,
		19,
		226,
		69,
		98,
		117,
		117,
		123,
		111,
		159,
		19,
		226,
		69,
		98,
		117,
		117,
		122,
		99,
		159,
		19,
		226,
		69,
		98,
		117,
		117,
		122,
		99,
		159,
		19,
		226,
		69,
		98,
		117,
		117,
		122,
		110,
		159,
		19,
		226,
		69,
		98,
		117,
		117,
		122,
		110,
		159,
		19,
		226,
		69,
		98,
		117,
		117,
		122,
		99,
		159,
		19,
		226,
		69,
		98,
		117,
		117,
		122,
		117,
		117,
		123,
		112,
		159,
		19,
		226,
		69,
		98,
		117,
		117,
		122,
		117,
		117,
		123,
		112,
		159,
		19,
		226,
		69,
		98,
		117,
		117,
		122,
		99,
		159,
		19,
		226,
		69,
		98,
		117,
		117,
		122,
		117,
		117,
		123,
		112,
		159,
		19,
		226,
		69,
		98,
		117,
		117,
		122,
		117,
		117,
		123,
		112,
		159,
		19,
		226,
		69,
		98,
		117,
		117,
		122,
		99,
		159,
		19,
		226,
		69,
		98,
		117,
		117,
		122,
		117,
		117,
		123,
		112,
		159,
		19,
		226,
		69,
		98,
		117,
		117,
		122,
		117,
		117,
		123,
		112,
		159,
		19,
		226,
		69,
		98,
		117,
		117,
		122,
		117,
		117,
		123,
		112,
		159,
		19,
		226,
		69,
		98,
		117,
		117,
		122,
		117,
		117,
		123,
		112,
		159,
		19,
		226,
		69,
		98,
		117,
		117,
		122,
		99,
		159,
		19,
		226,
		69,
		98,
		117,
		117,
		122,
		117,
		117,
		123,
		112,
		159,
		19,
		226,
		69,
		98,
		117,
		117,
		122,
		117,
		117,
		123,
		112,
		159,
		19,
		226,
		69,
		98,
		117,
		117,
		122,
		99,
		159,
		19,
		226,
		69,
		98,
		117,
		117,
		122,
		117,
		117,
		123,
		112,
		159,
		19,
		226,
		69,
		98,
		117,
		117,
		122,
		99,
		159,
		19,
		226,
		69,
		98,
		117,
		117,
		122,
		117,
		117,
		123,
		112,
		159,
		19,
		226,
		69,
		98,
		117,
		117,
		122,
		99,
		159,
		19,
		226,
		69,
		98,
		117,
		117,
		123,
		117,
		117,
		123,
		113,
		159,
		19,
		226,
		69,
		98,
		117,
		117,
		122,
		117,
		117,
		123,
		117,
		117,
		123,
		114,
		159,
		19,
		226,
		69,
		98,
		117,
		117,
		122,
		117,
		117,
		123,
		112,
		159,
		19,
		226,
		69,
		98,
		109,
		159,
		19,
		226,
		69,
		98,
		117,
		117,
		122,
		110,
		159,
		19,
		226,
		69,
		98,
		117,
		117,
		122,
		117,
		117,
		123,
		112,
		159,
		19,
		226,
		69,
		98,
		117,
		117,
		123,
		116,
		159,
		19,
		226,
		69,
		98,
		117,
		117,
		123,
		100,
		159,
		19,
		226,
		69,
		98,
		117,
		117,
		122,
		99,
		159,
		19,
		226,
		69,
		98,
		117,
		117,
		122,
		117,
		117,
		123,
		117,
		117,
		123,
		114,
		159,
		19,
		226,
		69,
		130,
		159,
		18,
		226,
		69,
		98,
		117,
		117,
		123,
		100,
		159,
		19,
		226,
		69,
		98,
		117,
		117,
		123,
		100,
		159,
		19,
		226,
		69,
		98,
		103,
		159,
		19,
		226,
		69,
		98,
		117,
		117,
		123,
		117,
		117,
		123,
		110,
		159,
		19,
		226,
		69,
		98,
		117,
		117,
		123,
		117,
		117,
		123,
		117,
		117,
		123,
		115,
		159,
		18,
		226,
		69,
		98,
		117,
		117,
		123,
		117,
		117,
		123,
		113,
		159,
		18,
		226,
		69,
		98,
		103,
		159,
		18,
		226,
		69,
		98,
		117,
		117,
		123,
		117,
		117,
		123,
		110,
		159,
		18,
		226,
		69,
		98,
		117,
		117,
		123,
		117,
		117,
		123,
		113,
		159,
		18,
		226,
		69,
		98,
		114,
		159,
		18,
		226,
		69,
		98,
		114,
		159,
		18,
		226,
		69,
		98,
		114,
		159,
		18,
		226,
		69,
		98,
		114,
		159,
		18,
		226,
		69,
		98,
		114,
		159,
		18,
		226,
		69,
		98,
		117,
		117,
		123,
		117,
		117,
		123,
		117,
		117,
		123,
		117,
		117,
		123,
		117,
		159,
		18,
		226,
		69,
		98,
		117,
		117,
		123,
		117,
		117,
		123,
		117,
		117,
		123,
		115,
		159,
		18,
		226,
		69,
		98,
		117,
		117,
		123,
		117,
		117,
		123,
		113,
		159,
		18,
		226,
		69,
		130,
		159,
		17,
		226,
		69,
		98,
		103,
		159,
		18,
		226,
		69,
		98,
		117,
		117,
		123,
		117,
		117,
		123,
		109,
		159,
		18,
		226,
		69,
		130,
		159,
		17,
		226,
		69,
		98,
		117,
		117,
		123,
		111,
		159,
		18,
		226,
		69,
		98,
		117,
		117,
		123,
		100,
		191,
		18,
		102,
		194
	})]
	public java_cup.runtime.Symbol CUP_0024Parser_0024do_action(int P_0, lr_parser P_1, Stack P_2, int P_3)
	{
		switch (P_0)
		{
		case 74:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			Expression condition = (Expression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			ArgumentList argumentList = new ArgumentList();
			argumentList.add(condition);
			ArgumentList o45 = argumentList;
			return new java_cup.runtime.Symbol(16, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o45);
		}
		case 73:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).right;
			ArgumentList arguments = (ArgumentList)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).value;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			Expression right = (Expression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			arguments.add(right);
			ArgumentList o45 = arguments;
			return new java_cup.runtime.Symbol(16, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o45);
		}
		case 72:
		{
			
			ArgumentList o45 = new ArgumentList();
			return new java_cup.runtime.Symbol(15, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o45);
		}
		case 71:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			ArgumentList arguments = (ArgumentList)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			ArgumentList o45 = arguments;
			return new java_cup.runtime.Symbol(15, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o45);
		}
		case 70:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).right;
			TypeSpecifier type = (TypeSpecifier)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).value;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			string name3 = (string)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			Parameter o44 = new Parameter(info(), type, new Identifier(info(), name3));
			return new java_cup.runtime.Symbol(14, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o44);
		}
		case 69:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			Parameter e5 = (Parameter)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			ParameterList parameterList2 = new ParameterList();
			parameterList2.add(e5);
			ParameterList o43 = parameterList2;
			return new java_cup.runtime.Symbol(13, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o43);
		}
		case 68:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).right;
			ParameterList parameterList = (ParameterList)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).value;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			Parameter e4 = (Parameter)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			parameterList.add(e4);
			ParameterList o43 = parameterList;
			return new java_cup.runtime.Symbol(13, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o43);
		}
		case 67:
		{
			
			ParameterList o43 = new ParameterList();
			return new java_cup.runtime.Symbol(10, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o43);
		}
		case 66:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			ParameterList parameterList = (ParameterList)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			ParameterList o43 = parameterList;
			return new java_cup.runtime.Symbol(10, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o43);
		}
		case 65:
		{
			
			BooleanLiteral o42 = new BooleanLiteral(info(), Boolean.valueOf(b: false));
			return new java_cup.runtime.Symbol(6, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o42);
		}
		case 64:
		{
			
			BooleanLiteral o42 = new BooleanLiteral(info(), Boolean.valueOf(b: true));
			return new java_cup.runtime.Symbol(6, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o42);
		}
		case 63:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			string name2 = (string)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			StringLiteral o41 = new StringLiteral(info(), name2);
			return new java_cup.runtime.Symbol(6, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o41);
		}
		case 62:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			Integer value3 = (Integer)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			IntegerLiteral o40 = new IntegerLiteral(info(), value3);
			return new java_cup.runtime.Symbol(6, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o40);
		}
		case 61:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			Character value2 = (Character)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			CharacterLiteral o39 = new CharacterLiteral(info(), value2);
			return new java_cup.runtime.Symbol(6, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o39);
		}
		case 60:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			string name2 = (string)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			Identifier o38 = new Identifier(info(), name2);
			return new java_cup.runtime.Symbol(9, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o38);
		}
		case 59:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 3)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 3)).right;
			Identifier left = (Identifier)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 3)).value;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).right;
			ArgumentList arguments2 = (ArgumentList)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).value;
			FunctionCall o37 = new FunctionCall(info(), left, arguments2);
			return new java_cup.runtime.Symbol(27, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 3)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o37);
		}
		case 58:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			ConstantExpression constantExpression = (ConstantExpression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			ConstantExpression o36 = constantExpression;
			return new java_cup.runtime.Symbol(27, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o36);
		}
		case 57:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			Identifier left = (Identifier)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			IdentifierExpression o35 = new IdentifierExpression(info(), left);
			return new java_cup.runtime.Symbol(27, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o35);
		}
		case 56:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).right;
			Expression condition = (Expression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).value;
			Expression o14 = condition;
			return new java_cup.runtime.Symbol(27, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o14);
		}
		case 55:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			Expression condition = (Expression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			Expression o14 = condition;
			return new java_cup.runtime.Symbol(26, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o14);
		}
		case 54:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			Expression condition = (Expression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			Negative o34 = new Negative(info(), condition);
			return new java_cup.runtime.Symbol(26, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o34);
		}
		case 53:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			Expression condition = (Expression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			LogicalNot o33 = new LogicalNot(info(), condition);
			return new java_cup.runtime.Symbol(26, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o33);
		}
		case 52:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			Expression condition = (Expression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			Expression o14 = condition;
			return new java_cup.runtime.Symbol(25, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o14);
		}
		case 51:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).right;
			Expression condition = (Expression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).value;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			Expression right = (Expression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			Division o32 = new Division(info(), condition, right);
			return new java_cup.runtime.Symbol(25, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o32);
		}
		case 50:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).right;
			Expression condition = (Expression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).value;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			Expression right = (Expression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			Multiplication o31 = new Multiplication(info(), condition, right);
			return new java_cup.runtime.Symbol(25, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o31);
		}
		case 49:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			Expression condition = (Expression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			Expression o14 = condition;
			return new java_cup.runtime.Symbol(24, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o14);
		}
		case 48:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).right;
			Expression condition = (Expression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).value;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			Expression right = (Expression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			Subtraction o30 = new Subtraction(info(), condition, right);
			return new java_cup.runtime.Symbol(24, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o30);
		}
		case 47:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).right;
			Expression condition = (Expression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).value;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			Expression right = (Expression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			Addition o29 = new Addition(info(), condition, right);
			return new java_cup.runtime.Symbol(24, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o29);
		}
		case 46:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			Expression condition = (Expression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			Expression o14 = condition;
			return new java_cup.runtime.Symbol(23, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o14);
		}
		case 45:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).right;
			Expression condition = (Expression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).value;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			Expression right = (Expression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			GreaterThanOrEqualTo o28 = new GreaterThanOrEqualTo(info(), condition, right);
			return new java_cup.runtime.Symbol(23, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o28);
		}
		case 44:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).right;
			Expression condition = (Expression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).value;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			Expression right = (Expression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			LessThanOrEqualTo o27 = new LessThanOrEqualTo(info(), condition, right);
			return new java_cup.runtime.Symbol(23, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o27);
		}
		case 43:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).right;
			Expression condition = (Expression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).value;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			Expression right = (Expression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			GreaterThan o26 = new GreaterThan(info(), condition, right);
			return new java_cup.runtime.Symbol(23, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o26);
		}
		case 42:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).right;
			Expression condition = (Expression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).value;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			Expression right = (Expression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			LessThan o25 = new LessThan(info(), condition, right);
			return new java_cup.runtime.Symbol(23, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o25);
		}
		case 41:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			Expression condition = (Expression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			Expression o14 = condition;
			return new java_cup.runtime.Symbol(22, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o14);
		}
		case 40:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).right;
			Expression condition = (Expression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).value;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			Expression right = (Expression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			NotEqualTo o24 = new NotEqualTo(info(), condition, right);
			return new java_cup.runtime.Symbol(22, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o24);
		}
		case 39:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).right;
			Expression condition = (Expression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).value;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			Expression right = (Expression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			EqualTo o23 = new EqualTo(info(), condition, right);
			return new java_cup.runtime.Symbol(22, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o23);
		}
		case 38:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			Expression condition = (Expression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			Expression o14 = condition;
			return new java_cup.runtime.Symbol(21, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o14);
		}
		case 37:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).right;
			Expression condition = (Expression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).value;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			Expression right = (Expression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			LogicalAnd o22 = new LogicalAnd(info(), condition, right);
			return new java_cup.runtime.Symbol(21, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o22);
		}
		case 36:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			Expression condition = (Expression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			Expression o14 = condition;
			return new java_cup.runtime.Symbol(20, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o14);
		}
		case 35:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).right;
			Expression condition = (Expression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).value;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			Expression right = (Expression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			LogicalOr o21 = new LogicalOr(info(), condition, right);
			return new java_cup.runtime.Symbol(20, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o21);
		}
		case 34:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			Expression condition = (Expression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			Expression o14 = condition;
			return new java_cup.runtime.Symbol(19, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o14);
		}
		case 33:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).right;
			Identifier left = (Identifier)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).value;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			Expression right = (Expression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			Assignment o20 = new Assignment(info(), left, right);
			return new java_cup.runtime.Symbol(19, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o20);
		}
		case 32:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 4)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 4)).right;
			Expression condition = (Expression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 4)).value;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).right;
			Statement e3 = (Statement)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).value;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			Statement elseStatement = (Statement)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			IfElseStatement o13 = new IfElseStatement(info(), condition, e3, elseStatement);
			return new java_cup.runtime.Symbol(18, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 6)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o13);
		}
		case 31:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).right;
			Expression condition = (Expression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).value;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			Statement e3 = (Statement)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			IfStatement o19 = new IfStatement(info(), condition, e3);
			return new java_cup.runtime.Symbol(18, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 4)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o19);
		}
		case 30:
		{
			
			ReturnVoidStatement o18 = new ReturnVoidStatement(info());
			return new java_cup.runtime.Symbol(17, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o18);
		}
		case 29:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).right;
			Expression condition = (Expression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).value;
			ReturnValueStatement o17 = new ReturnValueStatement(info(), condition);
			return new java_cup.runtime.Symbol(17, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o17);
		}
		case 28:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).right;
			Expression condition = (Expression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).value;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			Statement e3 = (Statement)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			WhileStatement o16 = new WhileStatement(info(), condition, e3);
			return new java_cup.runtime.Symbol(17, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 4)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o16);
		}
		case 27:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).right;
			ArgumentList arguments = (ArgumentList)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).value;
			PrintStatement.___003Cclinit_003E();
			PrintStatement o15 = new PrintStatement(info(), arguments);
			return new java_cup.runtime.Symbol(17, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o15);
		}
		case 26:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			BlockStatement blockStatement = (BlockStatement)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			BlockStatement o7 = blockStatement;
			return new java_cup.runtime.Symbol(17, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o7);
		}
		case 25:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).right;
			Expression condition = (Expression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).value;
			Expression o14 = condition;
			return new java_cup.runtime.Symbol(17, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o14);
		}
		case 24:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 4)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 4)).right;
			Expression condition = (Expression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 4)).value;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).right;
			Statement e3 = (Statement)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).value;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			Statement elseStatement = (Statement)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			IfElseStatement o13 = new IfElseStatement(info(), condition, e3, elseStatement);
			return new java_cup.runtime.Symbol(17, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 6)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o13);
		}
		case 23:
			
			return new java_cup.runtime.Symbol(12, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 22:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			Statement statement = (Statement)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			Statement o12 = statement;
			return new java_cup.runtime.Symbol(12, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o12);
		}
		case 21:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			Statement statement = (Statement)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			Statement o12 = statement;
			return new java_cup.runtime.Symbol(12, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o12);
		}
		case 20:
		{
			
			StatementList o11 = new StatementList();
			return new java_cup.runtime.Symbol(11, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o11);
		}
		case 19:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).right;
			StatementList statementList = (StatementList)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).value;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			Statement e3 = (Statement)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			statementList.add(e3);
			StatementList o11 = statementList;
			return new java_cup.runtime.Symbol(11, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o11);
		}
		case 18:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 4)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 4)).right;
			TypeSpecifier type = (TypeSpecifier)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 4)).value;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 3)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 3)).right;
			Identifier name = (Identifier)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 3)).value;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).right;
			ConstantExpression value = (ConstantExpression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).value;
			Initialization o10 = new Initialization(info(), type, name, value);
			return new java_cup.runtime.Symbol(8, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 4)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o10);
		}
		case 17:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).right;
			TypeSpecifier type = (TypeSpecifier)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).value;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).right;
			Identifier name = (Identifier)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).value;
			Declaration o9 = new Declaration(info(), type, name);
			return new java_cup.runtime.Symbol(8, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o9);
		}
		case 16:
		{
			
			DeclarationList o8 = new DeclarationList();
			return new java_cup.runtime.Symbol(7, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o8);
		}
		case 15:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).right;
			DeclarationList declarations2 = (DeclarationList)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).value;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			Declaration e2 = (Declaration)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			declarations2.add(e2);
			DeclarationList o8 = declarations2;
			return new java_cup.runtime.Symbol(7, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o8);
		}
		case 14:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).right;
			DeclarationList declarations2 = (DeclarationList)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).value;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).right;
			StatementList statements = (StatementList)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).value;
			BlockStatement o7 = new BlockStatement(info(), declarations2, statements);
			return new java_cup.runtime.Symbol(5, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 3)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o7);
		}
		case 13:
		{
			
			TypeSpecifier o6 = new TypeSpecifier(info(), Type.___003C_003EVOID);
			return new java_cup.runtime.Symbol(4, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o6);
		}
		case 12:
		{
			
			TypeSpecifier o6 = new TypeSpecifier(info(), Type.___003C_003ESTRING);
			return new java_cup.runtime.Symbol(4, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o6);
		}
		case 11:
		{
			
			TypeSpecifier o6 = new TypeSpecifier(info(), Type.___003C_003EINT);
			return new java_cup.runtime.Symbol(4, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o6);
		}
		case 10:
		{
			
			TypeSpecifier o6 = new TypeSpecifier(info(), Type.___003C_003ECHAR);
			return new java_cup.runtime.Symbol(4, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o6);
		}
		case 9:
		{
			
			TypeSpecifier o6 = new TypeSpecifier(info(), Type.___003C_003EBOOLEAN);
			return new java_cup.runtime.Symbol(4, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o6);
		}
		case 8:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 5)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 5)).right;
			TypeSpecifier type = (TypeSpecifier)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 5)).value;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 4)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 4)).right;
			Identifier name = (Identifier)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 4)).value;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).right;
			ParameterList parameters = (ParameterList)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).value;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			BlockStatement body = (BlockStatement)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			FunctionDefinition o5 = new FunctionDefinition(info(), type, name, parameters, body);
			return new java_cup.runtime.Symbol(3, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 5)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o5);
		}
		case 7:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 4)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 4)).right;
			TypeSpecifier type = (TypeSpecifier)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 4)).value;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 3)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 3)).right;
			Identifier name = (Identifier)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 3)).value;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).right;
			ConstantExpression value = (ConstantExpression)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).value;
			GlobalVariableInitialization o4 = new GlobalVariableInitialization(info(), type, name, value);
			return new java_cup.runtime.Symbol(3, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 4)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o4);
		}
		case 6:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).right;
			TypeSpecifier type = (TypeSpecifier)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).value;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).right;
			Identifier name = (Identifier)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).value;
			GlobalVariableDeclaration o3 = new GlobalVariableDeclaration(info(), type, name);
			return new java_cup.runtime.Symbol(3, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 2)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o3);
		}
		case 5:
			
			return new java_cup.runtime.Symbol(2, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 4:
		{
			
			ExternalDeclarationList o2 = new ExternalDeclarationList();
			return new java_cup.runtime.Symbol(2, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o2);
		}
		case 3:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).right;
			ExternalDeclarationList declarations = (ExternalDeclarationList)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).value;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			ExternalDeclaration e = (ExternalDeclaration)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			declarations.addLast(e);
			ExternalDeclarationList o2 = declarations;
			return new java_cup.runtime.Symbol(2, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o2);
		}
		case 2:
			
			return new java_cup.runtime.Symbol(1, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, null);
		case 1:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right;
			ExternalDeclarationList declarations = (ExternalDeclarationList)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).value;
			Program o = new Program(info(), declarations);
			return new java_cup.runtime.Symbol(1, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o);
		}
		case 0:
		{
			
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).left;
			_ = ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).right;
			Program program = (Program)((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).value;
			Program o = program;
			java_cup.runtime.Symbol result = new java_cup.runtime.Symbol(0, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 1)).left, ((java_cup.runtime.Symbol)P_2.elementAt(P_3 - 0)).right, o);
			P_1.done_parsing();
			return result;
		}
		default:
			
			throw new Exception("Invalid action number found in internal parse table");
		}
	}
}
