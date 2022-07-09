using CMinor.Parser;
using CMinor.Semantic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CMinor.lexer;

public class Lexer : JavaCUP.Runtime.Scanner
{
	private const int YYEOF = -1;

	private const int ZZ_BUFFERSIZE = 16384;

	private const int LONG_COMMENT = 10;

	private const int STRINGLITERAL = 2;

	private const int STRING_RECOVER = 6;

	private const int YYINITIAL = 0;

	private const int SHORT_COMMENT = 12;

	private const int CHARLITERAL = 4;

	private const int CHAR_RECOVER = 8;

	
	private static int[] ZZ_LEXSTATE;

	private const string ZZ_CMAP_PACKED = "\t\0\u0001\u0005\u0001\u0002\u0001\0\u0001\u0005\u0001\u0001\u0012\0\u0001\a\u0001%\u0001+\u0003\u0006\u0001&\u0001,\u0001\u001b\u0001\u001c\u0001#\u0001!\u0001\u001f\u0001\"\u0001\u0006\u0001$\u0001.\t\u0004\u0001\u0006\u0001 \u0001)\u0001(\u0001*\u0002\u0006\u001a\u0003\u0001\u0006\u0001-\u0002\u0006\u0001\u0003\u0001\u0006\u0001\u0013\u0001\u0012\u0001\u0016\u0001\u0011\u0001\n\u0001\t\u0001\u0018\u0001\u000e\u0001\b\u0002\u0003\u0001\v\u0001\u0003\u0001\u0014\u0001\u0010\u0001\u001a\u0001\u0003\u0001\u0017\u0001\f\u0001\u0015\u0001\u0019\u0001\u000f\u0001\r\u0003\u0003\u0001\u001d\u0001'\u0001\u001e\u0001\u0006ﾁ\0";

	
	private static char[] ZZ_CMAP;

	
	private static int[] ZZ_ACTION;

	private const string ZZ_ACTION_PACKED_0 = "\a\0\u0001\u0001\u0002\u0002\u0001\u0003\u0001\u0004\v\u0003\u0001\u0005\u0001\u0006\u0001\a\u0001\b\u0001\t\u0001\n\u0001\v\u0001\f\u0001\r\u0001\u000e\u0001\u000f\u0002\u0001\u0001\u0010\u0001\u0011\u0001\u0012\u0001\u0013\u0001\u0014\u0001\u0015\u0002\u0016\u0001\u0017\u0001\u0018\u0001\u0017\u0001\u0019\u0001\u001a\u0001\u001b\u0001\u001a\u0001\u001c\u0001\u001d\u0001\u001c\u0003\u001e\u0001\u001d\u0001\u001f\v\u0003\u0001 \u0001!\u0001\"\u0001#\u0001$\u0001%\u0001&\u0001'\u0001(\u0001)\u0001*\u0001+\u0001,\u0001-\u0001.\v\u0003\u0001/\u0002\u0003\u00010\u0001\u0003\u00011\u00012\u0002\u0003\u00013\u0001\u0003\u00014\u0002\u0003\u00015\u00016\u0001\u0003\u00017\u00018";

	
	private static int[] ZZ_ROWMAP;

	private const string ZZ_ROWMAP_PACKED_0 = "\0\0\0/\0^\0\u008d\0¼\0ë\0Ě\0ŉ\0Ÿ\0ŉ\0Ƨ\0ǖ\0ȅ\0ȴ\0ɣ\0ʒ\0ˁ\0\u02f0\0\u031f\0\u034e\0ͽ\0ά\0ϛ\0ŉ\0ŉ\0ŉ\0ŉ\0ŉ\0ŉ\0ŉ\0ŉ\0Њ\0й\0Ѩ\0җ\0ӆ\0ӵ\0Ԥ\0Փ\0ŉ\0ŉ\0ŉ\0ւ\0ŉ\0ŉ\0ŉ\0\u05b1\0ŉ\0ŉ\0ŉ\0נ\0ŉ\0ŉ\0؏\0ŉ\0ؾ\0٭\0ڜ\0Ƨ\0ۋ\0ۺ\0ܩ\0ݘ\0އ\0\u07b6\0ߥ\0ࠔ\0ࡃ\0\u0872\0ࢡ\0ŉ\0ŉ\0ŉ\0ŉ\0ŉ\0ŉ\0ŉ\0ŉ\0ŉ\0ŉ\0ŉ\0ŉ\0ŉ\0ŉ\0Ƨ\0\u08d0\0\u08ff\0म\0ढ़\0ঌ\0\u09bb\0৪\0ਙ\0\u0a48\0\u0a77\0દ\0Ƨ\0\u0ad5\0\u0b04\0Ƨ\0ଳ\0Ƨ\0Ƨ\0\u0b62\0\u0b91\0Ƨ\0\u0bc0\0Ƨ\0௯\0ఞ\0Ƨ\0Ƨ\0\u0c4d\0Ƨ\0Ƨ";

	
	private static int[] ZZ_TRANS;

	private const string ZZ_TRANS_PACKED_0 = "\u0001\b\u0001\t\u0001\n\u0001\v\u0001\f\u0001\n\u0001\b\u0001\n\u0001\r\u0001\u000e\u0001\u000f\u0001\v\u0001\u0010\u0001\u0011\u0001\v\u0001\u0012\u0002\v\u0001\u0013\u0002\v\u0001\u0014\u0001\u0015\u0001\u0016\u0002\v\u0001\u0017\u0001\u0018\u0001\u0019\u0001\u001a\u0001\u001b\u0001\u001c\u0001\u001d\u0001\u001e\u0001\u001f\u0001 \u0001!\u0001\"\u0001#\u0001$\u0001%\u0001&\u0001'\u0001(\u0001)\u0001\b\u0001\f\u0001*\u0001+\u0001,\u0002-\u0001*%-\u0001.\u0001-\u0001/\u0001-\u00030\u00021\u00010&1\u00012\u00013\u00011+4\u00015\u00014\u00016\u00014,7\u00015\u00018$7\u00019\f7\u0001:\u00015,71\0\u0001\n/\0\u0002\v\u0003\0\u0013\v\u0013\0\u0001\v\u0004\0\u0001\f)\0\u0001\f\u0003\0\u0002\v\u0003\0\u0001\v\u0001;\n\v\u0001<\u0006\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\v\v\u0001=\a\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u0003\v\u0001>\u000f\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\r\v\u0001?\u0005\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u0006\v\u0001@\f\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\b\v\u0001A\n\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\b\v\u0001B\n\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u000f\v\u0001C\u0003\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u0006\v\u0001D\f\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u0002\v\u0001E\u0010\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u000f\v\u0001F\u0003\v\u0013\0\u0001\v$\0\u0001G-\0\u0001H\u0001I2\0\u0001J,\0\u0001K/\0\u0001L/\0\u0001M.\0\u0001N.\0\u0001O\b\0\u0001,/\0\u0002-\u0001\0\u000e-\u0001P\u0019-\u0001Q\u0003\0\u00021\u0001\0\u000e1\u0001R\u00191\u0001S/T/7$\0\u00015\f\0\u00015/\0\u0002\v\u0003\0\r\v\u0001U\u0005\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u0003\v\u0001V\u000f\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u0004\v\u0001W\u000e\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u000f\v\u0001X\u0003\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u0001Y\u0012\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u0001Z\u0012\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\b\v\u0001[\n\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u0011\v\u0001\\\u0001\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\v\v\u0001]\a\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\r\v\u0001^\u0005\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u0001_\u0012\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u0004\v\u0001`\u000e\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u0002\v\u0001a\u0010\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u0001b\u0012\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u0003\v\u0001c\u000f\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\t\v\u0001d\t\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u0003\v\u0001e\u000f\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u0002\v\u0001f\u0010\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u000f\v\u0001g\u0003\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u0011\v\u0001h\u0001\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\f\v\u0001i\u0006\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u0002\v\u0001j\u0010\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\f\v\u0001k\u0006\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u0002\v\u0001l\u0010\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u0002\v\u0001m\u0010\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u000f\v\u0001n\u0003\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\r\v\u0001o\u0005\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u0010\v\u0001p\u0002\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\v\v\u0001q\a\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\f\v\u0001r\u0006\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\f\v\u0001s\u0006\v\u0013\0\u0001\v";

	private const int ZZ_UNKNOWN_ERROR = 0;

	private const int ZZ_NO_MATCH = 1;

	private const int ZZ_PUSHBACK_2BIG = 2;

	
	private static string[] ZZ_ERROR_MSG;

	
	private static int[] ZZ_ATTRIBUTE;

	private const string ZZ_ATTRIBUTE_PACKED_0 = "\a\0\u0001\t\u0001\u0001\u0001\t\r\u0001\b\t\b\u0001\u0003\t\u0001\u0001\u0003\t\u0001\u0001\u0003\t\u0001\u0001\u0002\t\u0001\u0001\u0001\t\u000f\u0001\u000e\t\u001f\u0001";

	private TextReader zzReader;

	private int zzState;

	private int zzLexicalState;

	private char[] zzBuffer;

	private int zzMarkedPos;

	private int zzCurrentPos;

	private int zzStartRead;

	private int zzEndRead;

	private int yyline;

	private int yychar;

	private int yycolumn;

	private bool zzAtBOL;

	private bool zzAtEOF;

	private bool zzEOFDone;

	private const int MAX_STRING_LITERAL_LENGTH = 64;

	private StringBuilder stringBuffer;


	private Dictionary<string, string> stringTable = new();

	private ErrorLogger logger;

	private string filename;

	
	
	public static void ___003Cclinit_003E()
	{
	}

	
	public Lexer(TextReader input)
	{
		zzLexicalState = 0;
		zzBuffer = new char[16384];
		zzAtBOL = true;
		stringBuffer = new StringBuilder(64);
		stringTable = new ();
		yyline = 1;
		zzReader = input;
	}

	public virtual void setFilename(string filename)
	{
		this.filename = filename;
	}

	public virtual void setErrorLogger(ErrorLogger logger)
	{
		this.logger = logger;
	}

	
	
	private static int zzUnpackAction(string P_0, int P_1, int[] P_2)
	{
		int num = 0;
		int num2 = P_1;
		int num3 = P_0.Length;
		while (num < num3)
		{
			int index = num;
			num++;
			int num4 = P_0[index];
			int index2 = num;
			num++;
			int num5 = P_0[index2];
			do
			{
				int num6 = num2;
				num2++;
				P_2[num6] = num5;
				num4 += -1;
			}
			while (num4 > 0);
		}
		return num2;
	}

	
	
	private static int zzUnpackRowMap(string P_0, int P_1, int[] P_2)
	{
		int num = 0;
		int num2 = P_1;
		int num3 = P_0.Length;
		while (num < num3)
		{
			int index = num;
			num++;
			int num4 = (int)((uint)P_0[index] << 16);
			int num5 = num2;
			num2++;
			int index2 = num;
			num++;
			P_2[num5] = num4 | P_0[index2];
		}
		return num2;
	}

	
	private static int zzUnpackTrans(string P_0, int P_1, int[] P_2)
	{
		int num = 0;
		int num2 = P_1;
		int num3 = P_0.Length;
		while (num < num3)
		{
			int index = num;
			num++;
			int num4 = P_0[index];
			int index2 = num;
			num++;
			int num5 = P_0[index2];
			num5 += -1;
			do
			{
				int num6 = num2;
				num2++;
				P_2[num6] = num5;
				num4 += -1;
			}
			while (num4 > 0);
		}
		return num2;
	}

	
	
	private static int zzUnpackAttribute(string P_0, int P_1, int[] P_2)
	{
		int num = 0;
		int num2 = P_1;
		int num3 = P_0.Length;
		while (num < num3)
		{
			int index = num;
			num++;
			int num4 = P_0[index];
			int index2 = num;
			num++;
			int num5 = P_0[index2];
			do
			{
				int num6 = num2;
				num2++;
				P_2[num6] = num5;
				num4 += -1;
			}
			while (num4 > 0);
		}
		return num2;
	}

	
	private void yybegin(int P_0)
	{
		zzLexicalState = P_0;
	}

	
	
	private JavaCUP.Runtime.Symbol makeErrorToken(string P_0)
	{
		logger.log(info(), P_0);
		JavaCUP.Runtime.Symbol result = makeSymbol(38, P_0);
		
		return result;
	}

	
	
	public virtual LocationInfo info()
	{
		LocationInfo result = new LocationInfo(filename, yyline, yycolumn);
		
		return result;
	}

	
	
	private JavaCUP.Runtime.Symbol makeSymbol(int P_0, object P_1)
	{
		JavaCUP.Runtime.Symbol result = new JavaCUP.Runtime.Symbol(P_0, P_1);
		
		return result;
	}

	
	
	
	private string yytext()
	{
		string result = new string(zzBuffer, zzStartRead, zzMarkedPos - zzStartRead);
		
		return result;
	}

	
	
	private char getLastChar()
	{
		string @this = yytext();
		
		return @this[@this.Length-1];
	}

	
	private int yylength()
	{
		return zzMarkedPos - zzStartRead;
	}

	
	
	private void zzScanError(int P_0)
	{
		string text;
		try
		{
			text = ZZ_ERROR_MSG[P_0];
		}
		catch (System.Exception x)
		{
			goto IL_001a;
		}
		goto IL_0028;
		IL_001a:
		
		text = ZZ_ERROR_MSG[0];
		goto IL_0028;
		IL_0028:
		string message = text;
		
		throw new System.Exception(message);
	}

	
	
	
	
	private void yyclose()
	{
		zzAtEOF = true;
		zzEndRead = zzStartRead;
		if (zzReader != null)
		{
			zzReader.Close();
		}
	}

	
	private bool zzRefill()
	{
		if (zzStartRead > 0)
		{
			Array.Copy(zzBuffer, zzStartRead, zzBuffer, 0, zzEndRead - zzStartRead);
			zzEndRead -= zzStartRead;
			zzCurrentPos -= zzStartRead;
			zzMarkedPos -= zzStartRead;
			zzStartRead = 0;
		}
		if (zzCurrentPos >= (nint)zzBuffer.LongLength)
		{
			char[] dest = new char[zzCurrentPos * 2];
			Array.Copy(zzBuffer, 0, dest, 0, zzBuffer.Length);
			zzBuffer = dest;
		}
		int num = zzReader.Read(zzBuffer, zzEndRead, (int)((nint)zzBuffer.LongLength - zzEndRead));
		if (num > 0)
		{
			zzEndRead += num;
			return false;
		}
		if (num == 0)
		{
			int num2 = zzReader.Read();
			if (num2 == -1)
			{
				return true;
			}
			char[] array = zzBuffer;
			int num3 = zzEndRead;
			zzEndRead = num3 + 1;
			array[num3] = (char)num2;
			return false;
		}
		return true;
	}

	
	
	private JavaCUP.Runtime.Symbol makeSymbol(int P_0)
	{
		JavaCUP.Runtime.Symbol result = new JavaCUP.Runtime.Symbol(P_0);
		
		return result;
	}

	
	
	private JavaCUP.Runtime.Symbol checkCharLiteralLength()
	{
		if (stringBuffer.Length > 1)
		{
			yybegin(8);
			JavaCUP.Runtime.Symbol result = makeErrorToken("more than one character inside character literal");
			
			return result;
		}
		return null;
	}

	
	
	private string getIdentifierString()
	{
		string text = yytext();
		if (!stringTable.TryGetValue(text,out var text2))
		{
			stringTable.Add(text, text);
			return text;
		}
		return text2;
	}

	
	
	private JavaCUP.Runtime.Symbol checkStringLiteralLength()
	{
		if (stringBuffer.Length > 64)
		{
			yybegin(6);
			JavaCUP.Runtime.Symbol result = makeErrorToken("maximum string literal length exceeded (maximum number of characters allowed is 64)");
			
			return result;
		}
		return null;
	}

	private string charName()
	{
		int lastChar = getLastChar();
		if (32 <= lastChar && lastChar <= 126)
		{
			string result = ("'")+((char)lastChar)+("'")
				;
			
			return result;
		}
		switch (lastChar)
		{
		case 10:
			return "newline";
		case 9:
			return "tab";
		case 13:
			return "carriage return";
		default:
		{			
			return string.Format("byte 0x{X4}",lastChar);
		}
		}
	}

	
	
	private char getLastBufferChar()
	{		
		return stringBuffer[stringBuffer.Length-1];
	}

	
	
	
	private void zzDoEOF()
	{
		if (!zzEOFDone)
		{
			zzEOFDone = true;
			yyclose();
		}
	}

	
	private int yystate()
	{
		return zzLexicalState;
	}

	
	
	private static char[] zzUnpackCMap(string P_0)
	{
		char[] array = new char[65536];
		int num = 0;
		int num2 = 0;
		while (num < 126)
		{
			int index = num;
			num++;
			int num3 = P_0[index];
			int index2 = num;
			num++;
			int num4 = P_0[index2];
			do
			{
				int num5 = num2;
				num2++;
				array[num5] = (char)num4;
				num3 += -1;
			}
			while (num3 > 0);
		}
		return array;
	}

	
	
	private static int[] zzUnpackAction()
	{
		int[] array = new int[115];
		int num = 0;
		zzUnpackAction("\a\0\u0001\u0001\u0002\u0002\u0001\u0003\u0001\u0004\v\u0003\u0001\u0005\u0001\u0006\u0001\a\u0001\b\u0001\t\u0001\n\u0001\v\u0001\f\u0001\r\u0001\u000e\u0001\u000f\u0002\u0001\u0001\u0010\u0001\u0011\u0001\u0012\u0001\u0013\u0001\u0014\u0001\u0015\u0002\u0016\u0001\u0017\u0001\u0018\u0001\u0017\u0001\u0019\u0001\u001a\u0001\u001b\u0001\u001a\u0001\u001c\u0001\u001d\u0001\u001c\u0003\u001e\u0001\u001d\u0001\u001f\v\u0003\u0001 \u0001!\u0001\"\u0001#\u0001$\u0001%\u0001&\u0001'\u0001(\u0001)\u0001*\u0001+\u0001,\u0001-\u0001.\v\u0003\u0001/\u0002\u0003\u00010\u0001\u0003\u00011\u00012\u0002\u0003\u00013\u0001\u0003\u00014\u0002\u0003\u00015\u00016\u0001\u0003\u00017\u00018", num, array);
		return array;
	}

	
	
	private static int[] zzUnpackRowMap()
	{
		int[] array = new int[115];
		int num = 0;
		zzUnpackRowMap("\0\0\0/\0^\0\u008d\0¼\0ë\0Ě\0ŉ\0Ÿ\0ŉ\0Ƨ\0ǖ\0ȅ\0ȴ\0ɣ\0ʒ\0ˁ\0\u02f0\0\u031f\0\u034e\0ͽ\0ά\0ϛ\0ŉ\0ŉ\0ŉ\0ŉ\0ŉ\0ŉ\0ŉ\0ŉ\0Њ\0й\0Ѩ\0җ\0ӆ\0ӵ\0Ԥ\0Փ\0ŉ\0ŉ\0ŉ\0ւ\0ŉ\0ŉ\0ŉ\0\u05b1\0ŉ\0ŉ\0ŉ\0נ\0ŉ\0ŉ\0؏\0ŉ\0ؾ\0٭\0ڜ\0Ƨ\0ۋ\0ۺ\0ܩ\0ݘ\0އ\0\u07b6\0ߥ\0ࠔ\0ࡃ\0\u0872\0ࢡ\0ŉ\0ŉ\0ŉ\0ŉ\0ŉ\0ŉ\0ŉ\0ŉ\0ŉ\0ŉ\0ŉ\0ŉ\0ŉ\0ŉ\0Ƨ\0\u08d0\0\u08ff\0म\0ढ़\0ঌ\0\u09bb\0৪\0ਙ\0\u0a48\0\u0a77\0દ\0Ƨ\0\u0ad5\0\u0b04\0Ƨ\0ଳ\0Ƨ\0Ƨ\0\u0b62\0\u0b91\0Ƨ\0\u0bc0\0Ƨ\0௯\0ఞ\0Ƨ\0Ƨ\0\u0c4d\0Ƨ\0Ƨ", num, array);
		return array;
	}

	
	
	private static int[] zzUnpackTrans()
	{
		int[] array = new int[3196];
		int num = 0;
		zzUnpackTrans("\u0001\b\u0001\t\u0001\n\u0001\v\u0001\f\u0001\n\u0001\b\u0001\n\u0001\r\u0001\u000e\u0001\u000f\u0001\v\u0001\u0010\u0001\u0011\u0001\v\u0001\u0012\u0002\v\u0001\u0013\u0002\v\u0001\u0014\u0001\u0015\u0001\u0016\u0002\v\u0001\u0017\u0001\u0018\u0001\u0019\u0001\u001a\u0001\u001b\u0001\u001c\u0001\u001d\u0001\u001e\u0001\u001f\u0001 \u0001!\u0001\"\u0001#\u0001$\u0001%\u0001&\u0001'\u0001(\u0001)\u0001\b\u0001\f\u0001*\u0001+\u0001,\u0002-\u0001*%-\u0001.\u0001-\u0001/\u0001-\u00030\u00021\u00010&1\u00012\u00013\u00011+4\u00015\u00014\u00016\u00014,7\u00015\u00018$7\u00019\f7\u0001:\u00015,71\0\u0001\n/\0\u0002\v\u0003\0\u0013\v\u0013\0\u0001\v\u0004\0\u0001\f)\0\u0001\f\u0003\0\u0002\v\u0003\0\u0001\v\u0001;\n\v\u0001<\u0006\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\v\v\u0001=\a\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u0003\v\u0001>\u000f\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\r\v\u0001?\u0005\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u0006\v\u0001@\f\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\b\v\u0001A\n\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\b\v\u0001B\n\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u000f\v\u0001C\u0003\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u0006\v\u0001D\f\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u0002\v\u0001E\u0010\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u000f\v\u0001F\u0003\v\u0013\0\u0001\v$\0\u0001G-\0\u0001H\u0001I2\0\u0001J,\0\u0001K/\0\u0001L/\0\u0001M.\0\u0001N.\0\u0001O\b\0\u0001,/\0\u0002-\u0001\0\u000e-\u0001P\u0019-\u0001Q\u0003\0\u00021\u0001\0\u000e1\u0001R\u00191\u0001S/T/7$\0\u00015\f\0\u00015/\0\u0002\v\u0003\0\r\v\u0001U\u0005\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u0003\v\u0001V\u000f\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u0004\v\u0001W\u000e\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u000f\v\u0001X\u0003\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u0001Y\u0012\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u0001Z\u0012\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\b\v\u0001[\n\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u0011\v\u0001\\\u0001\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\v\v\u0001]\a\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\r\v\u0001^\u0005\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u0001_\u0012\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u0004\v\u0001`\u000e\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u0002\v\u0001a\u0010\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u0001b\u0012\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u0003\v\u0001c\u000f\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\t\v\u0001d\t\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u0003\v\u0001e\u000f\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u0002\v\u0001f\u0010\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u000f\v\u0001g\u0003\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u0011\v\u0001h\u0001\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\f\v\u0001i\u0006\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u0002\v\u0001j\u0010\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\f\v\u0001k\u0006\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u0002\v\u0001l\u0010\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u0002\v\u0001m\u0010\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u000f\v\u0001n\u0003\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\r\v\u0001o\u0005\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\u0010\v\u0001p\u0002\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\v\v\u0001q\a\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\f\v\u0001r\u0006\v\u0013\0\u0001\v\u0003\0\u0002\v\u0003\0\f\v\u0001s\u0006\v\u0013\0\u0001\v", num, array);
		return array;
	}

	
	
	private static int[] zzUnpackAttribute()
	{
		int[] array = new int[115];
		int num = 0;
		zzUnpackAttribute("\a\0\u0001\t\u0001\u0001\u0001\t\r\u0001\b\t\b\u0001\u0003\t\u0001\u0001\u0003\t\u0001\u0001\u0003\t\u0001\u0001\u0002\t\u0001\u0001\u0001\t\u000f\u0001\u000e\t\u001f\u0001", num, array);
		return array;
	}

	public virtual int currentLine()
	{
		return yyline;
	}

	public virtual int currentColumn()
	{
		return yycolumn;
	}

	public virtual ErrorLogger getErrorLogger()
	{
		return logger;
	}

	public virtual string getFilename()
	{
		return filename;
	}

	
	
	public Lexer(Stream @in)
		: this(new StreamReader(@in))
	{
	}

	
	
	private void yyreset(TextReader P_0)
	{
		zzReader = P_0;
		zzAtBOL = true;
		zzAtEOF = false;
		zzEOFDone = false;
		int num = 0;
		int num2 = num;
		zzStartRead = num;
		zzEndRead = num2;
		num = 0;
		int num3 = num;
		zzMarkedPos = num;
		zzCurrentPos = num3;
		num = 0;
		int num4 = num;
		yycolumn = num;
		num = num4;
		int num5 = num;
		yychar = num;
		yyline = num5;
		zzLexicalState = 0;
	}

	
	
	private char yycharat(int P_0)
	{
		return zzBuffer[zzStartRead + P_0];
	}

	
	
	private void yypushback(int P_0)
	{
		if (P_0 > yylength())
		{
			zzScanError(2);
		}
		zzMarkedPos -= P_0;
	}

	
	
	public virtual JavaCUP.Runtime.Symbol NextToken()
	{
		int num = zzEndRead;
		char[] array = zzBuffer;
		char[] zZ_CMAP = ZZ_CMAP;
		int[] zZ_TRANS = ZZ_TRANS;
		int[] zZ_ROWMAP = ZZ_ROWMAP;
		int[] zZ_ATTRIBUTE = ZZ_ATTRIBUTE;
		while (true)
		{
			int num2 = zzMarkedPos;
			int num3 = 0;
			int i;
			for (i = zzStartRead; i < num2; i++)
			{
				switch (array[i])
				{
				case '\v':
				case '\f':
				case '\u0085':
				case '\u2028':
				case '\u2029':
					yyline++;
					yycolumn = 0;
					num3 = 0;
					break;
				case '\r':
					yyline++;
					yycolumn = 0;
					num3 = 1;
					break;
				case '\n':
					if (num3 != 0)
					{
						num3 = 0;
						break;
					}
					yyline++;
					yycolumn = 0;
					break;
				default:
					num3 = 0;
					yycolumn++;
					break;
				}
			}
			if (num3 != 0)
			{
				int num4;
				if (num2 < num)
				{
					num4 = ((array[num2] == '\n') ? 1 : 0);
				}
				else if (zzAtEOF)
				{
					num4 = 0;
				}
				else
				{
					int num5 = (zzRefill() ? 1 : 0);
					num = zzEndRead;
					num2 = zzMarkedPos;
					array = zzBuffer;
					num4 = ((num5 == 0 && array[num2] == '\n') ? 1 : 0);
				}
				if (num4 != 0)
				{
					yyline--;
				}
			}
			int num6 = -1;
			int num7 = num2;
			int num8 = num7;
			zzStartRead = num7;
			num7 = num8;
			int num9 = num7;
			zzCurrentPos = num7;
			i = num9;
			zzState = ZZ_LEXSTATE[zzLexicalState];
			int num11;
			while (true)
			{
				int num4;
				if (i < num)
				{
					char[] array2 = array;
					int num10 = i;
					i++;
					num11 = array2[num10];
				}
				else
				{
					if (zzAtEOF)
					{
						num11 = -1;
						break;
					}
					zzCurrentPos = i;
					zzMarkedPos = num2;
					num4 = (zzRefill() ? 1 : 0);
					i = zzCurrentPos;
					num2 = zzMarkedPos;
					array = zzBuffer;
					num = zzEndRead;
					if (num4 != 0)
					{
						num11 = -1;
						break;
					}
					char[] array3 = array;
					int num12 = i;
					i++;
					num11 = array3[num12];
				}
				num4 = zZ_TRANS[zZ_ROWMAP[zzState] + zZ_CMAP[num11]];
				if (num4 == -1)
				{
					break;
				}
				zzState = num4;
				int num5 = zZ_ATTRIBUTE[zzState];
				if ((num5 & 1) == 1)
				{
					num6 = zzState;
					num2 = i;
					if ((num5 & 8) == 8)
					{
						break;
					}
				}
			}
			zzMarkedPos = num2;
			switch ((num6 >= 0) ? ZZ_ACTION[num6] : num6)
			{
			case 2:
			case 28:
			case 30:
			case 45:
			case 57:
			case 58:
			case 59:
			case 60:
			case 61:
			case 62:
			case 63:
			case 64:
			case 65:
			case 66:
			case 67:
			case 68:
			case 69:
			case 70:
			case 71:
			case 72:
			case 73:
			case 74:
			case 75:
			case 76:
			case 77:
			case 78:
			case 79:
			case 80:
			case 81:
			case 82:
			case 83:
			case 84:
			case 85:
			case 86:
			case 87:
			case 88:
			case 89:
			case 90:
			case 91:
			case 92:
			case 93:
			case 94:
			case 95:
			case 96:
			case 97:
			case 98:
			case 99:
			case 100:
			case 101:
			case 102:
			case 103:
			case 104:
			case 105:
			case 106:
			case 107:
			case 108:
			case 109:
			case 110:
			case 111:
			case 112:
				continue;
			case 56:
			{
				JavaCUP.Runtime.Symbol result36 = makeSymbol(27);
				
				return result36;
			}
			case 43:
			{
				stringBuffer.Append('\n');
				JavaCUP.Runtime.Symbol symbol = checkCharLiteralLength();
				if (symbol != null)
				{
					return symbol;
				}
				continue;
			}
			case 3:
			{
				JavaCUP.Runtime.Symbol result39 = makeSymbol(37, getIdentifierString());
				
				return result39;
			}
			case 44:
			{
				stringBuffer.Append('\0');
				JavaCUP.Runtime.Symbol symbol = checkCharLiteralLength();
				if (symbol != null)
				{
					return symbol;
				}
				continue;
			}
			case 42:
			{
				stringBuffer.Append('\0');
				JavaCUP.Runtime.Symbol symbol = checkStringLiteralLength();
				if (symbol != null)
				{
					return symbol;
				}
				continue;
			}
			case 31:
			{
				JavaCUP.Runtime.Symbol result = makeSymbol(30);
				
				return result;
			}
			case 25:
			{
				yybegin(8);
				JavaCUP.Runtime.Symbol result41 = makeErrorToken(("illegal ")+(charName())+(" in character literal")
					);
				
				return result41;
			}
			case 6:
			{
				JavaCUP.Runtime.Symbol result40 = makeSymbol(3);
				
				return result40;
			}
			case 26:
			{
				stringBuffer.Append(getLastChar());
				JavaCUP.Runtime.Symbol symbol = checkCharLiteralLength();
				if (symbol != null)
				{
					return symbol;
				}
				continue;
			}
			case 49:
			{
				JavaCUP.Runtime.Symbol result38 = makeSymbol(23);
				
				return result38;
			}
			case 37:
			{
				JavaCUP.Runtime.Symbol result37 = makeSymbol(14);
				
				return result37;
			}
			case 23:
			{
				stringBuffer.Append(getLastChar());
				JavaCUP.Runtime.Symbol symbol = checkStringLiteralLength();
				if (symbol != null)
				{
					return symbol;
				}
				continue;
			}
			case 38:
			{
				JavaCUP.Runtime.Symbol result35 = makeSymbol(15);
				
				return result35;
			}
			case 32:
			{
				JavaCUP.Runtime.Symbol result34 = makeErrorToken("stray comment terminator \"*/\"");
				
				return result34;
			}
			case 48:
			{
				JavaCUP.Runtime.Symbol result33 = makeSymbol(28);
				
				return result33;
			}
			case 21:
			{
				yybegin(6);
				JavaCUP.Runtime.Symbol result32 = makeErrorToken(("illegal ")+(charName())+(" in string literal")
					);
				
				return result32;
			}
			case 41:
			{
				stringBuffer.Append('\n');
				JavaCUP.Runtime.Symbol symbol = checkStringLiteralLength();
				if (symbol != null)
				{
					return symbol;
				}
				continue;
			}
			case 11:
			{
				JavaCUP.Runtime.Symbol result31 = makeSymbol(8);
				
				return result31;
			}
			case 52:
			{
				JavaCUP.Runtime.Symbol result30 = makeSymbol(32);
				
				return result30;
			}
			case 47:
			{
				JavaCUP.Runtime.Symbol result29 = makeSymbol(31);
				
				return result29;
			}
			case 7:
			{
				JavaCUP.Runtime.Symbol result28 = makeSymbol(4);
				
				return result28;
			}
			case 35:
			{
				JavaCUP.Runtime.Symbol result27 = makeSymbol(16);
				
				return result27;
			}
			case 46:
			{
				JavaCUP.Runtime.Symbol result26 = makeSymbol(25);
				
				return result26;
			}
			case 29:
				yybegin(0);
				continue;
			case 34:
				yybegin(12);
				continue;
			case 27:
			{
				yybegin(0);
				JavaCUP.Runtime.Symbol result25 = new JavaCUP.Runtime.Symbol(34, (char)(getLastBufferChar()));
				
				return result25;
			}
			case 36:
			{
				JavaCUP.Runtime.Symbol result24 = makeSymbol(13);
				
				return result24;
			}
			case 15:
			{
				JavaCUP.Runtime.Symbol result23 = makeSymbol(12);
				
				return result23;
			}
			case 16:
			{
				JavaCUP.Runtime.Symbol result22 = makeSymbol(21);
				
				return result22;
			}
			case 13:
			{
				JavaCUP.Runtime.Symbol result21 = makeSymbol(10);
				
				return result21;
			}
			case 14:
			{
				JavaCUP.Runtime.Symbol result20 = makeSymbol(11);
				
				return result20;
			}
			case 40:
			{
				JavaCUP.Runtime.Symbol result19 = makeSymbol(19);
				
				return result19;
			}
			case 55:
			{
				JavaCUP.Runtime.Symbol result18 = makeSymbol(33);
				
				return result18;
			}
			case 19:
				yybegin(2);
					stringBuffer.Length = 0;
				continue;
			case 50:
			{
				JavaCUP.Runtime.Symbol result17 = makeSymbol(24);
				
				return result17;
			}
			case 39:
			{
				JavaCUP.Runtime.Symbol result16 = makeSymbol(17);
				
				return result16;
			}
			case 10:
			{
				JavaCUP.Runtime.Symbol result15 = makeSymbol(7);
				
				return result15;
			}
			case 33:
				yybegin(10);
				continue;
			case 24:
			{
				yybegin(0);
				JavaCUP.Runtime.Symbol result14 = new JavaCUP.Runtime.Symbol(35, stringBuffer);
				
				return result14;
			}
			case 53:
			{
				JavaCUP.Runtime.Symbol result13 = makeSymbol(29);
				
				return result13;
			}
			case 12:
			{
				JavaCUP.Runtime.Symbol result12 = makeSymbol(9);
				
				return result12;
			}
			case 9:
			{
				JavaCUP.Runtime.Symbol result11 = makeSymbol(6);
				
				return result11;
			}
			case 20:
				yybegin(4);
					stringBuffer.Length = 0;
				continue;
			case 5:
			{
				JavaCUP.Runtime.Symbol result10 = makeSymbol(2);
				
				return result10;
			}
			case 51:
			{
				JavaCUP.Runtime.Symbol result9 = makeSymbol(22);
				
				return result9;
			}
			case 18:
			{
				JavaCUP.Runtime.Symbol result8 = makeSymbol(20);
				
				return result8;
			}
			case 4:
			{
				JavaCUP.Runtime.Symbol result7 = makeSymbol(36, int.TryParse(yytext(),out var ret)?ret:0);
				
				return result7;
			}
			case 17:
			{
				JavaCUP.Runtime.Symbol result6 = makeSymbol(18);
				
				return result6;
			}
			case 8:
			{
				JavaCUP.Runtime.Symbol result5 = makeSymbol(5);
				
				return result5;
			}
			case 1:
			{
				JavaCUP.Runtime.Symbol result4 = makeErrorToken(("stray ")+(charName()));
				
				return result4;
			}
			case 22:
			{
				yybegin(0);
				JavaCUP.Runtime.Symbol result3 = makeErrorToken("missing closing quote for string literal");
				
				return result3;
			}
			case 54:
			{
				JavaCUP.Runtime.Symbol result2 = makeSymbol(26);
				
				return result2;
			}
			}
			if (num11 == -1 && zzStartRead == zzCurrentPos)
			{
				zzAtEOF = true;
				zzDoEOF();
				switch (yystate())
				{
				case 2:
				case 6:
				{
					yybegin(0);
					JavaCUP.Runtime.Symbol result45 = makeErrorToken("unexpected EOF in string literal");
					
					return result45;
				}
				case 4:
				case 8:
				{
					yybegin(0);
					JavaCUP.Runtime.Symbol result44 = makeErrorToken("unexpected EOF in character literal");
					
					return result44;
				}
				case 10:
				{
					yybegin(0);
					JavaCUP.Runtime.Symbol result43 = makeErrorToken("unmatched '/*' (reached EOF)");
					
					return result43;
				}
				default:
				{
					JavaCUP.Runtime.Symbol result42 = new JavaCUP.Runtime.Symbol(0);
					
					return result42;
				}
				}
			}
			zzScanError(1);
		}
	}

	static Lexer()
	{
		ZZ_LEXSTATE = new int[14]
		{
			0, 0, 1, 1, 2, 2, 3, 3, 4, 4,
			5, 5, 6, 6
		};
		ZZ_CMAP = zzUnpackCMap("\t\0\u0001\u0005\u0001\u0002\u0001\0\u0001\u0005\u0001\u0001\u0012\0\u0001\a\u0001%\u0001+\u0003\u0006\u0001&\u0001,\u0001\u001b\u0001\u001c\u0001#\u0001!\u0001\u001f\u0001\"\u0001\u0006\u0001$\u0001.\t\u0004\u0001\u0006\u0001 \u0001)\u0001(\u0001*\u0002\u0006\u001a\u0003\u0001\u0006\u0001-\u0002\u0006\u0001\u0003\u0001\u0006\u0001\u0013\u0001\u0012\u0001\u0016\u0001\u0011\u0001\n\u0001\t\u0001\u0018\u0001\u000e\u0001\b\u0002\u0003\u0001\v\u0001\u0003\u0001\u0014\u0001\u0010\u0001\u001a\u0001\u0003\u0001\u0017\u0001\f\u0001\u0015\u0001\u0019\u0001\u000f\u0001\r\u0003\u0003\u0001\u001d\u0001'\u0001\u001e\u0001\u0006ﾁ\0");
		ZZ_ACTION = zzUnpackAction();
		ZZ_ROWMAP = zzUnpackRowMap();
		ZZ_TRANS = zzUnpackTrans();
		ZZ_ERROR_MSG = new string[3] { "Unkown internal scanner error", "System.Exception: could not match input", "System.Exception: pushback value was too large" };
		ZZ_ATTRIBUTE = zzUnpackAttribute();
	}
}
