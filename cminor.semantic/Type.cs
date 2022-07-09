



namespace CMinor.semantic;

public class Type
{
	private string name;

	private bool variableType;

	internal static Type ___003C_003ECHAR;

	internal static Type ___003C_003EBOOLEAN;

	internal static Type ___003C_003EINT;

	internal static Type ___003C_003ESTRING;

	internal static Type ___003C_003EVOID;

	internal static Type ___003C_003EFUNCTION;

	[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Type CHAR
	{
		
		get
		{
			return ___003C_003ECHAR;
		}
	}

	[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Type BOOLEAN
	{
		
		get
		{
			return ___003C_003EBOOLEAN;
		}
	}

	[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Type INT
	{
		
		get
		{
			return ___003C_003EINT;
		}
	}

	[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Type STRING
	{
		
		get
		{
			return ___003C_003ESTRING;
		}
	}

	[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Type VOID
	{
		
		get
		{
			return ___003C_003EVOID;
		}
	}

	[Modifiers(Modifiers.Public | Modifiers.Static | Modifiers.Final)]
	public static Type FUNCTION
	{
		
		get
		{
			return ___003C_003EFUNCTION;
		}
	}

	
	
	public static void ___003Cclinit_003E()
	{
	}

	
	
	private Type(string P_0, bool P_1)
	{
		name = P_0;
		variableType = P_1;
	}

	public virtual string getName()
	{
		return name;
	}

	public virtual bool isVariableType()
	{
		return variableType;
	}

	
	static Type()
	{
		___003C_003ECHAR = new Type("char", true);
		___003C_003EBOOLEAN = new Type("boolean", true);
		___003C_003EINT = new Type("int", true);
		___003C_003ESTRING = new Type("string", true);
		___003C_003EVOID = new Type("void", false);
		___003C_003EFUNCTION = new Type("function", false);
	}
}
