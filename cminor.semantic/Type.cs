namespace CMinor.Semantic;

public class Type
{
	private string name;
	private bool variableType;
	internal static Type char_type;
	internal static Type boolean_type;
	internal static Type integer_type;
	internal static Type string_type;
	internal static Type void_type;
	internal static Type function_type;

    public static Type CHAR => char_type;


    public static Type BOOLEAN => boolean_type;


    public static Type INT => integer_type;


    public static Type STRING => string_type;


    public static Type VOID
	=> void_type;

	
	public static Type FUNCTION
	=> function_type;

	
	private Type(string P_0, bool P_1)
	{
		name = P_0;
		variableType = P_1;
	}

    public virtual string Name => name;

    public virtual bool isVariableType => variableType;


    static Type()
	{
		char_type = new Type("char", true);
		boolean_type = new Type("bool", true);
		integer_type = new Type("int", true);
		string_type = new Type("string", true);
		void_type = new Type("void", false);
		function_type = new Type("function", false);
	}
}
