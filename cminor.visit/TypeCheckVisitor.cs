using CMinor.AST;
using CMinor.Semantic;
using CMinor.Symbol;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CMinor.Visit;

public class TypeCheckVisitor : Visitor
{

    internal sealed class _1 : TypeTester
    {


        internal _1()
            : base(null)
        {
        }


        public override bool test(Types P_0)
        {
            return P_0 == Types.integer_type;
        }

        public override string desc()
        {
            return "arithmetic";
        }



        public override Types synth()
        {
            return Types.integer_type;
        }
    }



    internal sealed class _2 : TypeTester
    {

        internal _2()
            : base(null)
        {
        }



        public override bool test(Types P_0)
        {
            return (P_0 == Types.integer_type || P_0 == Types.char_type || P_0 == Types.boolean_type) ? true : false;
        }

        public override string desc()
        {
            return "equatable";
        }



        public override Types synth()
        {
            return Types.boolean_type;
        }
    }



    internal sealed class _3 : TypeTester
    {


        internal _3()
            : base(null)
        {
        }



        public override bool test(Types P_0)
        {
            return P_0 == Types.integer_type;
        }

        public override string desc()
        {
            return "comparable";
        }



        public override Types synth()
        {
            return Types.boolean_type;
        }
    }



    internal sealed class _4 : TypeTester
    {


        internal _4()
            : base(null)
        {
        }



        public override bool test(Types P_0)
        {
            return P_0 == Types.boolean_type;
        }

        public override string desc()
        {
            return "logical";
        }



        public override Types synth()
        {
            return Types.boolean_type;
        }
    }


    internal abstract class TypeTester
    {


        private TypeTester()
        {
        }

        public abstract bool test(Types P_0);

        public abstract string desc();

        public abstract Types synth();




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


    public TypeCheckVisitor(ErrorLogger logger)
    {
        this.logger = logger;
    }



    private bool checkVariableType(AstNode P_0, TypeSpecifier P_1, string P_2)
    {
        int num = (P_1.Type.isVariableType ? 1 : 0);
        if (num == 0)
        {
            logger.log(P_0.getLocation(), ("a ") + (P_2) + (" may not have type ")
                + (Types.void_type.Name)
                );
        }
        return (byte)num != 0;
    }



    private void checkMatch(AstNode P_0, Types P_1, Types P_2, string P_3)
    {
        if (P_1 != P_2)
        {
            logger.log(P_0.getLocation(), ("type mismatch in ") + (P_3) + (" (got ")
                + (P_1.Name)
                + (" and ")
                + (P_2.Name)
                + (")")
                );
        }
    }


    private string MakeFormatString(PrintStatement P_0)
    {
        StringBuilder stringBuilder = new StringBuilder();

        var arrayList = new List<Expression>();
        var formatStringVisitor = new FormatStringVisitor(stringBuilder, arrayList, stringTable, program, logger);

        foreach (var expression in P_0.Arguments)
        {
            expression.Accept(formatStringVisitor);
        }
        formatStringVisitor.Finish();
        P_0.ActualArguments = arrayList;
        return stringBuilder.ToString();
    }



    private void checkCondition(AstNode P_0, Expression P_1, string P_2)
    {
        P_1.Accept(this);
        Types type = P_1.Type;
        if (type != Types.boolean_type)
        {
            logger.log(P_0.getLocation(), ("condition in ") + (P_2) + (" must be of type ")
                + (type.Name)
                );
        }
    }




    private string typeListString(List<Types> P_0)
    {
        var stringBuilder = new StringBuilder();
        int num = 0;
        foreach (var type in P_0)
        {
            if (num != 0)
            {
                stringBuilder.Append(", ");
            }
            else
            {
                num = 1;
            }
            stringBuilder.Append(type.Name);
        }
        return stringBuilder.ToString();
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
        Types type = P_0.Arg1.Type;
        Types type2 = P_0.Arg2.Type;
        checkMatch(P_0, type, type2, P_1);
        P_0.Type = P_2.synth();
    }



    private void requireType(Expression P_0, Expression P_1, string P_2, TypeTester P_3)
    {
        inPrintStatement = false;
        P_1.Accept(this);
        Types type = P_1.Type;
        if (!P_3.test(type))
        {
            logger.log(P_0.getLocation(), (P_2) + (" operator requires operands of ") + (P_3.desc())
                + (" type (got ")
                + (type.Name)
                + (")")
                );
        }
    }



    public override void Visit(AstNode n)
    {
        logger.log(n.getLocation(), ("type checking in ") + (n.DotLabel) + (" is a stub")
            );
    }


    public override void Visit(Program n)
    {
        program = n;
        stringTable = new StringTable();
        inPrintStatement = false;
        FunctionSymbol symbol = n.MainFunction.Symbol;
        if (symbol.ReturnType != Types.integer_type)
        {
            logger.log(n.getLocation(), ("main function must have return type ") + (Types.integer_type.Name));
        }
        if (symbol.Parameters.Count != 0)
        {
            logger.log(n.getLocation(), "main function must take no parameters");
        }
        foreach (var externalDeclaration in n.Declarations)
        {
            externalDeclaration.Accept(this);
        }
        n.StringSymbols = stringTable.Symbols;
    }



    public override void Visit(Parameter n)
    {
        checkVariableType(n, n.Type, "parameter");
    }


    public override void Visit(FunctionDefinition n)
    {
        foreach (var parameter in n.Parameters)
        {
            parameter.Accept(this);
        }
        currentFunction = n.Symbol;
        endsWithReturn = false;
        n.Body.Accept(this);
        FunctionSymbol symbol = n.Symbol;
        if (!endsWithReturn && currentFunction.ReturnType.isVariableType)
        {
            logger.log(n.getLocation(), ("non-void function ") + (symbol.Identifier) + (" does not return a value in all paths of execution")
                );
        }
        n.EndsWithReturn = endsWithReturn;
        currentFunction = null;
    }



    public override void Visit(GlobalVariableDeclaration n)
    {
        checkVariableType(n, n.Type, "variable");
    }


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
        foreach (var expression in n.Arguments)
        {
            inPrintStatement = true;
            expression.Accept(this);
        }
        inPrintStatement = false;
        string value = MakeFormatString(n);
        StringSymbol symbol = stringTable.GetSymbol(value);
        n.Symbol = symbol;
    }


    public override void Visit(BlockStatement n)
    {
        foreach (var declaration in n.Declarations)
        {
            declaration.Accept(this);
        }

        foreach (var statement in n.Statements)
        {
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
        Types returnType = currentFunction.ReturnType;
        if (returnType != Types.void_type)
        {
            logger.log(n.getLocation(), ("return statement missing value in function ") + (currentFunction.Identifier));
        }
        endsWithReturn = true;
    }


    public override void Visit(ReturnValueStatement n)
    {
        n.Value.Accept(this);
        Types returnType = currentFunction.ReturnType;
        Types type = n.Value.Type;
        if (returnType != type)
        {
            string msg = ((returnType != Types.void_type) ? ("return statement in function ") + (currentFunction.Identifier) + (" requires expression of type ")
                + (returnType.Name)
                + (", got ")
                + (type.Name)
                .ToString() : ("function with ") + (Types.void_type.Name) + (" return type cannot return a value")
                );
            logger.log(n.getLocation(), msg);
        }
        endsWithReturn = true;
    }



    public override void Visit(Assignment n)
    {
        inPrintStatement = false;
        Expression value = n.Value;
        value.Accept(this);
        Types type = n.Identifier.Symbol.Type;
        Types type2 = value.Type;
        checkMatch(n, type, type2, "variable assignment");
        n.Type = type;
    }


    public override void Visit(FunctionCall n)
    {
        inPrintStatement = false;

        foreach (var expression in n.Arguments)
        {
            expression.Accept(this);
        }
        var symbol = n.Identifier.Symbol;
        var type = symbol.Type;
        if (type != Types.function_type)
        {
            logger.log(n.getLocation(), ("symbol ") + (symbol.Identifier) + (" called as function but is of type ")
                + (type.Name)
                );
            n.Type = type;
            return;
        }
        FunctionSymbol functionSymbol = (FunctionSymbol)symbol;
        n.Symbol = functionSymbol;
        var parameters = functionSymbol.Parameters;
        int initialCapacity = n.Arguments.Count;
        int initialCapacity2 = parameters.Count;
        var arrayList = new List<Types>(initialCapacity);
        var arrayList2 = new List<Types>(initialCapacity2);

        foreach (var expression2 in n.Arguments)
        {
            arrayList.Add(expression2.Type);
        }

        foreach (var parameterSymbol in parameters)
        {
            arrayList2.Add(parameterSymbol.Type);
        }
        if (!arrayList.Equals(arrayList2))
        {
            logger.log(n.getLocation(), ("actual and formal parameters in function call do not match\n\treceived: ") + (typeListString(arrayList)) + ("\n\texpected: ")
                + (typeListString(arrayList2))
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
        n.Type = Types.boolean_type;
    }



    public override void Visit(CharacterLiteral n)
    {
        n.Type = Types.char_type;
    }



    public override void Visit(IntegerLiteral n)
    {
        n.Type = Types.integer_type;
    }



    public override void Visit(StringLiteral n)
    {
        if (!inPrintStatement)
        {
            n.Symbol = stringTable.GetSymbol((string)n.Value);
        }
        n.Type = Types.string_type;
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
