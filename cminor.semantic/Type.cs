namespace CMinor.Semantic;

public class Types
{
	private string name;
	private bool variableType;
	internal static Types char_type;
	internal static Types boolean_type;
	internal static Types integer_type;
	internal static Types string_type;
	internal static Types void_type;
	internal static Types function_type;

    public static Types CHAR => char_type;


    public static Types BOOLEAN => boolean_type;


    public static Types INT => integer_type;


    public static Types STRING => string_type;


    public static Types VOID
	=> void_type;

	
	public static Types FUNCTION
	=> function_type;

	
	private Types(string P_0, bool P_1)
	{
		name = P_0;
		variableType = P_1;
	}

    public virtual string Name => name;

    public virtual bool isVariableType => variableType;


    static Types()
	{
		char_type = new Types("char", true);
		boolean_type = new Types("bool", true);
		integer_type = new Types("int", true);
		string_type = new Types("string", true);
		void_type = new Types("void", false);
		function_type = new Types("function", false);
	}
}
