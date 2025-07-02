// Decompiled with JetBrains decompiler
// Type: ES3Lexer
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using Antlr.Runtime;
using System;
using System.CodeDom.Compiler;

#nullable disable
[CLSCompliant(false)]
[GeneratedCode("ANTLR", "3.3.1.7705")]
public class ES3Lexer : Lexer
{
  public const int EOF = -1;
  public const int ABSTRACT = 4;
  public const int ADD = 5;
  public const int ADDASS = 6;
  public const int AND = 7;
  public const int ANDASS = 8;
  public const int ARGS = 9;
  public const int ARRAY = 10;
  public const int ASSIGN = 11;
  public const int BLOCK = 12;
  public const int BOOLEAN = 13;
  public const int BREAK = 14;
  public const int BSLASH = 15;
  public const int BYFIELD = 16 /*0x10*/;
  public const int BYINDEX = 17;
  public const int BYTE = 18;
  public const int BackslashSequence = 19;
  public const int CALL = 20;
  public const int CASE = 21;
  public const int CATCH = 22;
  public const int CEXPR = 23;
  public const int CHAR = 24;
  public const int CLASS = 25;
  public const int COLON = 26;
  public const int COMMA = 27;
  public const int CONST = 28;
  public const int CONTINUE = 29;
  public const int CR = 30;
  public const int CharacterEscapeSequence = 31 /*0x1F*/;
  public const int DEBUGGER = 32 /*0x20*/;
  public const int DEC = 33;
  public const int DEFAULT = 34;
  public const int DELETE = 35;
  public const int DIV = 36;
  public const int DIVASS = 37;
  public const int DO = 38;
  public const int DOT = 39;
  public const int DOUBLE = 40;
  public const int DQUOTE = 41;
  public const int DecimalDigit = 42;
  public const int DecimalIntegerLiteral = 43;
  public const int DecimalLiteral = 44;
  public const int ELSE = 45;
  public const int ENUM = 46;
  public const int EOL = 47;
  public const int EQ = 48 /*0x30*/;
  public const int EXPORT = 49;
  public const int EXPR = 50;
  public const int EXTENDS = 51;
  public const int EscapeSequence = 52;
  public const int ExponentPart = 53;
  public const int FALSE = 54;
  public const int FF = 55;
  public const int FINAL = 56;
  public const int FINALLY = 57;
  public const int FLOAT = 58;
  public const int FOR = 59;
  public const int FORITER = 60;
  public const int FORSTEP = 61;
  public const int FUNCTION = 62;
  public const int GOTO = 63 /*0x3F*/;
  public const int GT = 64 /*0x40*/;
  public const int GTE = 65;
  public const int HexDigit = 66;
  public const int HexEscapeSequence = 67;
  public const int HexIntegerLiteral = 68;
  public const int IF = 69;
  public const int IMPLEMENTS = 70;
  public const int IMPORT = 71;
  public const int IN = 72;
  public const int INC = 73;
  public const int INSTANCEOF = 74;
  public const int INT = 75;
  public const int INTERFACE = 76;
  public const int INV = 77;
  public const int ITEM = 78;
  public const int Identifier = 79;
  public const int IdentifierNameASCIIStart = 80 /*0x50*/;
  public const int IdentifierPart = 81;
  public const int IdentifierStartASCII = 82;
  public const int LABELLED = 83;
  public const int LAND = 84;
  public const int LBRACE = 85;
  public const int LBRACK = 86;
  public const int LF = 87;
  public const int LONG = 88;
  public const int LOR = 89;
  public const int LPAREN = 90;
  public const int LS = 91;
  public const int LT = 92;
  public const int LTE = 93;
  public const int LineTerminator = 94;
  public const int MOD = 95;
  public const int MODASS = 96 /*0x60*/;
  public const int MUL = 97;
  public const int MULASS = 98;
  public const int MultiLineComment = 99;
  public const int NAMEDVALUE = 100;
  public const int NATIVE = 101;
  public const int NBSP = 102;
  public const int NEG = 103;
  public const int NEQ = 104;
  public const int NEW = 105;
  public const int NOT = 106;
  public const int NSAME = 107;
  public const int NULL = 108;
  public const int OBJECT = 109;
  public const int OR = 110;
  public const int ORASS = 111;
  public const int OctalDigit = 112 /*0x70*/;
  public const int OctalEscapeSequence = 113;
  public const int OctalIntegerLiteral = 114;
  public const int PACKAGE = 115;
  public const int PAREXPR = 116;
  public const int PDEC = 117;
  public const int PINC = 118;
  public const int POS = 119;
  public const int PRIVATE = 120;
  public const int PROTECTED = 121;
  public const int PS = 122;
  public const int PUBLIC = 123;
  public const int QUE = 124;
  public const int RBRACE = 125;
  public const int RBRACK = 126;
  public const int RETURN = 127 /*0x7F*/;
  public const int RPAREN = 128 /*0x80*/;
  public const int RegularExpressionChar = 129;
  public const int RegularExpressionFirstChar = 130;
  public const int RegularExpressionLiteral = 131;
  public const int SAME = 132;
  public const int SEMIC = 133;
  public const int SHL = 134;
  public const int SHLASS = 135;
  public const int SHORT = 136;
  public const int SHR = 137;
  public const int SHRASS = 138;
  public const int SHU = 139;
  public const int SHUASS = 140;
  public const int SP = 141;
  public const int SQUOTE = 142;
  public const int STATIC = 143;
  public const int SUB = 144 /*0x90*/;
  public const int SUBASS = 145;
  public const int SUPER = 146;
  public const int SWITCH = 147;
  public const int SYNCHRONIZED = 148;
  public const int SingleLineComment = 149;
  public const int StringLiteral = 150;
  public const int TAB = 151;
  public const int THIS = 152;
  public const int THROW = 153;
  public const int THROWS = 154;
  public const int TRANSIENT = 155;
  public const int TRUE = 156;
  public const int TRY = 157;
  public const int TYPEOF = 158;
  public const int USP = 159;
  public const int UnicodeEscapeSequence = 160 /*0xA0*/;
  public const int VAR = 161;
  public const int VOID = 162;
  public const int VOLATILE = 163;
  public const int VT = 164;
  public const int WHILE = 165;
  public const int WITH = 166;
  public const int WhiteSpace = 167;
  public const int XOR = 168;
  public const int XORASS = 169;
  public const int ZeroToThree = 170;
  private IToken last;
  private ES3Lexer.DFA19 dfa19;
  private ES3Lexer.DFA32 dfa32;

  private bool AreRegularExpressionsEnabled()
  {
    if (this.last == null)
      return true;
    switch (this.last.Type)
    {
      case 44:
      case 54:
      case 68:
      case 79:
      case 108:
      case 114:
      case 126:
      case 128 /*0x80*/:
      case 150:
      case 152:
      case 156:
        return false;
      default:
        return true;
    }
  }

  private void ConsumeIdentifierUnicodeStart()
  {
    if (!this.IsIdentifierStartUnicode(((IIntStream) this.input).LA(1)))
      throw new NoViableAltException();
    this.MatchAny();
    while (true)
    {
      int ch = ((IIntStream) this.input).LA(1);
      if (ch == 36 || ch >= 48 /*0x30*/ && ch <= 57 || ch >= 65 && ch <= 90 || ch == 92 || ch == 95 || ch >= 97 && ch <= 122 || this.IsIdentifierPartUnicode(ch))
        this.mIdentifierPart();
      else
        break;
    }
  }

  private bool IsIdentifierPartUnicode(int ch) => char.IsLetterOrDigit((char) ch);

  private bool IsIdentifierStartUnicode(int ch) => char.IsLetter((char) ch);

  public virtual IToken NextToken()
  {
    IToken itoken = base.NextToken();
    if (itoken.Channel == 0)
      this.last = itoken;
    return itoken;
  }

  public ES3Lexer()
  {
  }

  public ES3Lexer(ICharStream input)
    : this(input, new RecognizerSharedState())
  {
  }

  public ES3Lexer(ICharStream input, RecognizerSharedState state)
    : base(input, state)
  {
  }

  public virtual string GrammarFileName => "ES3.g";

  [GrammarRule("ABSTRACT")]
  private void mABSTRACT()
  {
    int num1 = 4;
    int num2 = 0;
    this.Match("abstract");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("ADD")]
  private void mADD()
  {
    int num1 = 5;
    int num2 = 0;
    this.Match(43);
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("ADDASS")]
  private void mADDASS()
  {
    int num1 = 6;
    int num2 = 0;
    this.Match("+=");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("AND")]
  private void mAND()
  {
    int num1 = 7;
    int num2 = 0;
    this.Match(38);
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("ANDASS")]
  private void mANDASS()
  {
    int num1 = 8;
    int num2 = 0;
    this.Match("&=");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("ASSIGN")]
  private void mASSIGN()
  {
    int num1 = 11;
    int num2 = 0;
    this.Match(61);
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("BOOLEAN")]
  private void mBOOLEAN()
  {
    int num1 = 13;
    int num2 = 0;
    this.Match("boolean");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("BREAK")]
  private void mBREAK()
  {
    int num1 = 14;
    int num2 = 0;
    this.Match("break");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("BYTE")]
  private void mBYTE()
  {
    int num1 = 18;
    int num2 = 0;
    this.Match("byte");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("CASE")]
  private void mCASE()
  {
    int num1 = 21;
    int num2 = 0;
    this.Match("case");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("CATCH")]
  private void mCATCH()
  {
    int num1 = 22;
    int num2 = 0;
    this.Match("catch");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("CHAR")]
  private void mCHAR()
  {
    int num1 = 24;
    int num2 = 0;
    this.Match("char");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("CLASS")]
  private void mCLASS()
  {
    int num1 = 25;
    int num2 = 0;
    this.Match("class");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("COLON")]
  private void mCOLON()
  {
    int num1 = 26;
    int num2 = 0;
    this.Match(58);
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("COMMA")]
  private void mCOMMA()
  {
    int num1 = 27;
    int num2 = 0;
    this.Match(44);
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("CONST")]
  private void mCONST()
  {
    int num1 = 28;
    int num2 = 0;
    this.Match("const");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("CONTINUE")]
  private void mCONTINUE()
  {
    int num1 = 29;
    int num2 = 0;
    this.Match("continue");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("DEBUGGER")]
  private void mDEBUGGER()
  {
    int num1 = 32 /*0x20*/;
    int num2 = 0;
    this.Match("debugger");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("DEC")]
  private void mDEC()
  {
    int num1 = 33;
    int num2 = 0;
    this.Match("--");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("DEFAULT")]
  private void mDEFAULT()
  {
    int num1 = 34;
    int num2 = 0;
    this.Match("default");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("DELETE")]
  private void mDELETE()
  {
    int num1 = 35;
    int num2 = 0;
    this.Match("delete");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("DIV")]
  private void mDIV()
  {
    int num1 = 36;
    int num2 = 0;
    this.Match(47);
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("DIVASS")]
  private void mDIVASS()
  {
    int num1 = 37;
    int num2 = 0;
    this.Match("/=");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("DO")]
  private void mDO()
  {
    int num1 = 38;
    int num2 = 0;
    this.Match("do");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("DOT")]
  private void mDOT()
  {
    int num1 = 39;
    int num2 = 0;
    this.Match(46);
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("DOUBLE")]
  private void mDOUBLE()
  {
    int num1 = 40;
    int num2 = 0;
    this.Match("double");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("ELSE")]
  private void mELSE()
  {
    int num1 = 45;
    int num2 = 0;
    this.Match("else");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("ENUM")]
  private void mENUM()
  {
    int num1 = 46;
    int num2 = 0;
    this.Match("enum");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("EQ")]
  private void mEQ()
  {
    int num1 = 48 /*0x30*/;
    int num2 = 0;
    this.Match("==");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("EXPORT")]
  private void mEXPORT()
  {
    int num1 = 49;
    int num2 = 0;
    this.Match("export");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("EXTENDS")]
  private void mEXTENDS()
  {
    int num1 = 51;
    int num2 = 0;
    this.Match("extends");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("FALSE")]
  private void mFALSE()
  {
    int num1 = 54;
    int num2 = 0;
    this.Match("false");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("FINAL")]
  private void mFINAL()
  {
    int num1 = 56;
    int num2 = 0;
    this.Match("final");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("FINALLY")]
  private void mFINALLY()
  {
    int num1 = 57;
    int num2 = 0;
    this.Match("finally");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("FLOAT")]
  private void mFLOAT()
  {
    int num1 = 58;
    int num2 = 0;
    this.Match("float");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("FOR")]
  private void mFOR()
  {
    int num1 = 59;
    int num2 = 0;
    this.Match("for");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("FUNCTION")]
  private void mFUNCTION()
  {
    int num1 = 62;
    int num2 = 0;
    this.Match("function");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("GOTO")]
  private void mGOTO()
  {
    int num1 = 63 /*0x3F*/;
    int num2 = 0;
    this.Match("goto");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("GT")]
  private void mGT()
  {
    int num1 = 64 /*0x40*/;
    int num2 = 0;
    this.Match(62);
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("GTE")]
  private void mGTE()
  {
    int num1 = 65;
    int num2 = 0;
    this.Match(">=");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("IF")]
  private void mIF()
  {
    int num1 = 69;
    int num2 = 0;
    this.Match("if");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("IMPLEMENTS")]
  private void mIMPLEMENTS()
  {
    int num1 = 70;
    int num2 = 0;
    this.Match("implements");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("IMPORT")]
  private void mIMPORT()
  {
    int num1 = 71;
    int num2 = 0;
    this.Match("import");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("IN")]
  private void mIN()
  {
    int num1 = 72;
    int num2 = 0;
    this.Match("in");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("INC")]
  private void mINC()
  {
    int num1 = 73;
    int num2 = 0;
    this.Match("++");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("INSTANCEOF")]
  private void mINSTANCEOF()
  {
    int num1 = 74;
    int num2 = 0;
    this.Match("instanceof");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("INT")]
  private void mINT()
  {
    int num1 = 75;
    int num2 = 0;
    this.Match("int");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("INTERFACE")]
  private void mINTERFACE()
  {
    int num1 = 76;
    int num2 = 0;
    this.Match("interface");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("INV")]
  private void mINV()
  {
    int num1 = 77;
    int num2 = 0;
    this.Match(126);
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("LAND")]
  private void mLAND()
  {
    int num1 = 84;
    int num2 = 0;
    this.Match("&&");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("LBRACE")]
  private void mLBRACE()
  {
    int num1 = 85;
    int num2 = 0;
    this.Match(123);
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("LBRACK")]
  private void mLBRACK()
  {
    int num1 = 86;
    int num2 = 0;
    this.Match(91);
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("LONG")]
  private void mLONG()
  {
    int num1 = 88;
    int num2 = 0;
    this.Match("long");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("LOR")]
  private void mLOR()
  {
    int num1 = 89;
    int num2 = 0;
    this.Match("||");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("LPAREN")]
  private void mLPAREN()
  {
    int num1 = 90;
    int num2 = 0;
    this.Match(40);
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("LT")]
  private void mLT()
  {
    int num1 = 92;
    int num2 = 0;
    this.Match(60);
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("LTE")]
  private void mLTE()
  {
    int num1 = 93;
    int num2 = 0;
    this.Match("<=");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("MOD")]
  private void mMOD()
  {
    int num1 = 95;
    int num2 = 0;
    this.Match(37);
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("MODASS")]
  private void mMODASS()
  {
    int num1 = 96 /*0x60*/;
    int num2 = 0;
    this.Match("%=");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("MUL")]
  private void mMUL()
  {
    int num1 = 97;
    int num2 = 0;
    this.Match(42);
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("MULASS")]
  private void mMULASS()
  {
    int num1 = 98;
    int num2 = 0;
    this.Match("*=");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("NATIVE")]
  private void mNATIVE()
  {
    int num1 = 101;
    int num2 = 0;
    this.Match("native");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("NEQ")]
  private void mNEQ()
  {
    int num1 = 104;
    int num2 = 0;
    this.Match("!=");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("NEW")]
  private void mNEW()
  {
    int num1 = 105;
    int num2 = 0;
    this.Match("new");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("NOT")]
  private void mNOT()
  {
    int num1 = 106;
    int num2 = 0;
    this.Match(33);
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("NSAME")]
  private void mNSAME()
  {
    int num1 = 107;
    int num2 = 0;
    this.Match("!==");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("NULL")]
  private void mNULL()
  {
    int num1 = 108;
    int num2 = 0;
    this.Match("null");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("OR")]
  private void mOR()
  {
    int num1 = 110;
    int num2 = 0;
    this.Match(124);
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("ORASS")]
  private void mORASS()
  {
    int num1 = 111;
    int num2 = 0;
    this.Match("|=");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("PACKAGE")]
  private void mPACKAGE()
  {
    int num1 = 115;
    int num2 = 0;
    this.Match("package");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("PRIVATE")]
  private void mPRIVATE()
  {
    int num1 = 120;
    int num2 = 0;
    this.Match("private");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("PROTECTED")]
  private void mPROTECTED()
  {
    int num1 = 121;
    int num2 = 0;
    this.Match("protected");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("PUBLIC")]
  private void mPUBLIC()
  {
    int num1 = 123;
    int num2 = 0;
    this.Match("public");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("QUE")]
  private void mQUE()
  {
    int num1 = 124;
    int num2 = 0;
    this.Match(63 /*0x3F*/);
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("RBRACE")]
  private void mRBRACE()
  {
    int num1 = 125;
    int num2 = 0;
    this.Match(125);
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("RBRACK")]
  private void mRBRACK()
  {
    int num1 = 126;
    int num2 = 0;
    this.Match(93);
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("RETURN")]
  private void mRETURN()
  {
    int maxValue = (int) sbyte.MaxValue;
    int num = 0;
    this.Match("return");
    ((BaseRecognizer) this).state.type = maxValue;
    ((BaseRecognizer) this).state.channel = num;
  }

  [GrammarRule("RPAREN")]
  private void mRPAREN()
  {
    int num1 = 128 /*0x80*/;
    int num2 = 0;
    this.Match(41);
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("SAME")]
  private void mSAME()
  {
    int num1 = 132;
    int num2 = 0;
    this.Match("===");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("SEMIC")]
  private void mSEMIC()
  {
    int num1 = 133;
    int num2 = 0;
    this.Match(59);
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("SHL")]
  private void mSHL()
  {
    int num1 = 134;
    int num2 = 0;
    this.Match("<<");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("SHLASS")]
  private void mSHLASS()
  {
    int num1 = 135;
    int num2 = 0;
    this.Match("<<=");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("SHORT")]
  private void mSHORT()
  {
    int num1 = 136;
    int num2 = 0;
    this.Match("short");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("SHR")]
  private void mSHR()
  {
    int num1 = 137;
    int num2 = 0;
    this.Match(">>");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("SHRASS")]
  private void mSHRASS()
  {
    int num1 = 138;
    int num2 = 0;
    this.Match(">>=");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("SHU")]
  private void mSHU()
  {
    int num1 = 139;
    int num2 = 0;
    this.Match(">>>");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("SHUASS")]
  private void mSHUASS()
  {
    int num1 = 140;
    int num2 = 0;
    this.Match(">>>=");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("STATIC")]
  private void mSTATIC()
  {
    int num1 = 143;
    int num2 = 0;
    this.Match("static");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("SUB")]
  private void mSUB()
  {
    int num1 = 144 /*0x90*/;
    int num2 = 0;
    this.Match(45);
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("SUBASS")]
  private void mSUBASS()
  {
    int num1 = 145;
    int num2 = 0;
    this.Match("-=");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("SUPER")]
  private void mSUPER()
  {
    int num1 = 146;
    int num2 = 0;
    this.Match("super");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("SWITCH")]
  private void mSWITCH()
  {
    int num1 = 147;
    int num2 = 0;
    this.Match("switch");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("SYNCHRONIZED")]
  private void mSYNCHRONIZED()
  {
    int num1 = 148;
    int num2 = 0;
    this.Match("synchronized");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("THIS")]
  private void mTHIS()
  {
    int num1 = 152;
    int num2 = 0;
    this.Match("this");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("THROW")]
  private void mTHROW()
  {
    int num1 = 153;
    int num2 = 0;
    this.Match("throw");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("THROWS")]
  private void mTHROWS()
  {
    int num1 = 154;
    int num2 = 0;
    this.Match("throws");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("TRANSIENT")]
  private void mTRANSIENT()
  {
    int num1 = 155;
    int num2 = 0;
    this.Match("transient");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("TRUE")]
  private void mTRUE()
  {
    int num1 = 156;
    int num2 = 0;
    this.Match("true");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("TRY")]
  private void mTRY()
  {
    int num1 = 157;
    int num2 = 0;
    this.Match("try");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("TYPEOF")]
  private void mTYPEOF()
  {
    int num1 = 158;
    int num2 = 0;
    this.Match("typeof");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("VAR")]
  private void mVAR()
  {
    int num1 = 161;
    int num2 = 0;
    this.Match("var");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("VOID")]
  private void mVOID()
  {
    int num1 = 162;
    int num2 = 0;
    this.Match("void");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("VOLATILE")]
  private void mVOLATILE()
  {
    int num1 = 163;
    int num2 = 0;
    this.Match("volatile");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("WHILE")]
  private void mWHILE()
  {
    int num1 = 165;
    int num2 = 0;
    this.Match("while");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("WITH")]
  private void mWITH()
  {
    int num1 = 166;
    int num2 = 0;
    this.Match("with");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("XOR")]
  private void mXOR()
  {
    int num1 = 168;
    int num2 = 0;
    this.Match(94);
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("XORASS")]
  private void mXORASS()
  {
    int num1 = 169;
    int num2 = 0;
    this.Match("^=");
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("BSLASH")]
  private void mBSLASH() => this.Match(92);

  [GrammarRule("DQUOTE")]
  private void mDQUOTE() => this.Match(34);

  [GrammarRule("SQUOTE")]
  private void mSQUOTE() => this.Match(39);

  [GrammarRule("TAB")]
  private void mTAB() => this.Match(9);

  [GrammarRule("VT")]
  private void mVT() => this.Match(11);

  [GrammarRule("FF")]
  private void mFF() => this.Match(12);

  [GrammarRule("SP")]
  private void mSP() => this.Match(32 /*0x20*/);

  [GrammarRule("NBSP")]
  private void mNBSP() => this.Match(160 /*0xA0*/);

  [GrammarRule("USP")]
  private void mUSP()
  {
    if (((IIntStream) this.input).LA(1) == 5760 || ((IIntStream) this.input).LA(1) == 6158 || ((IIntStream) this.input).LA(1) >= 8192 /*0x2000*/ && ((IIntStream) this.input).LA(1) <= 8202 || ((IIntStream) this.input).LA(1) == 8239 || ((IIntStream) this.input).LA(1) == 8287 || ((IIntStream) this.input).LA(1) == 12288 /*0x3000*/)
    {
      ((IIntStream) this.input).Consume();
    }
    else
    {
      MismatchedSetException mismatchedSetException = new MismatchedSetException((BitSet) null, (IIntStream) this.input);
      this.Recover((RecognitionException) mismatchedSetException);
      throw mismatchedSetException;
    }
  }

  [GrammarRule("WhiteSpace")]
  private void mWhiteSpace()
  {
    int num1 = 167;
    int num2 = 0;
    while (true)
    {
      int num3 = 2;
      int num4 = ((IIntStream) this.input).LA(1);
      if (num4 == 9 || num4 >= 11 && num4 <= 12 || num4 == 32 /*0x20*/ || num4 == 160 /*0xA0*/ || num4 == 5760 || num4 == 6158 || num4 >= 8192 /*0x2000*/ && num4 <= 8202 || num4 == 8239 || num4 == 8287 || num4 == 12288 /*0x3000*/)
        num3 = 1;
      if (num3 == 1)
      {
        ((IIntStream) this.input).Consume();
        ++num2;
      }
      else
        break;
    }
    if (num2 < 1)
      throw new EarlyExitException(1, (IIntStream) this.input);
    int num5 = 99;
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num5;
  }

  [GrammarRule("LF")]
  private void mLF() => this.Match(10);

  [GrammarRule("CR")]
  private void mCR() => this.Match(13);

  [GrammarRule("LS")]
  private void mLS() => this.Match(8232);

  [GrammarRule("PS")]
  private void mPS() => this.Match(8233);

  [GrammarRule("LineTerminator")]
  private void mLineTerminator()
  {
    if (((IIntStream) this.input).LA(1) == 10 || ((IIntStream) this.input).LA(1) == 13 || ((IIntStream) this.input).LA(1) >= 8232 && ((IIntStream) this.input).LA(1) <= 8233)
    {
      ((IIntStream) this.input).Consume();
    }
    else
    {
      MismatchedSetException mismatchedSetException = new MismatchedSetException((BitSet) null, (IIntStream) this.input);
      this.Recover((RecognitionException) mismatchedSetException);
      throw mismatchedSetException;
    }
  }

  [GrammarRule("EOL")]
  private void mEOL()
  {
    int num1 = 47;
    int num2;
    switch (((IIntStream) this.input).LA(1))
    {
      case 10:
        num2 = 2;
        break;
      case 13:
        num2 = 1;
        break;
      case 8232:
        num2 = 3;
        break;
      case 8233:
        num2 = 4;
        break;
      default:
        throw new NoViableAltException("", 2, 0, (IIntStream) this.input);
    }
    switch (num2)
    {
      case 1:
        this.mCR();
        this.mLF();
        break;
      case 2:
        this.mLF();
        break;
      case 3:
        this.mLS();
        break;
      case 4:
        this.mPS();
        break;
    }
    int num3 = 99;
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num3;
  }

  [GrammarRule("MultiLineComment")]
  private void mMultiLineComment()
  {
    int num1 = 99;
    this.Match("/*");
    while (true)
    {
      int num2 = 2;
      int num3 = ((IIntStream) this.input).LA(1);
      if (num3 == 42)
      {
        int num4 = ((IIntStream) this.input).LA(2);
        if (num4 == 47)
          num2 = 2;
        else if (num4 >= 0 && num4 <= 46 || num4 >= 48 /*0x30*/ && num4 <= (int) ushort.MaxValue)
          num2 = 1;
      }
      else if (num3 >= 0 && num3 <= 41 || num3 >= 43 && num3 <= (int) ushort.MaxValue)
        num2 = 1;
      if (num2 == 1)
        this.MatchAny();
      else
        break;
    }
    this.Match("*/");
    int num5 = 99;
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num5;
  }

  [GrammarRule("SingleLineComment")]
  private void mSingleLineComment()
  {
    int num1 = 149;
    this.Match("//");
    while (true)
    {
      int num2 = 2;
      int num3 = ((IIntStream) this.input).LA(1);
      if (num3 >= 0 && num3 <= 9 || num3 >= 11 && num3 <= 12 || num3 >= 14 && num3 <= 8231 || num3 >= 8234 && num3 <= (int) ushort.MaxValue)
        num2 = 1;
      if (num2 == 1)
        ((IIntStream) this.input).Consume();
      else
        break;
    }
    int num4 = 99;
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num4;
  }

  [GrammarRule("IdentifierStartASCII")]
  private void mIdentifierStartASCII()
  {
    int num;
    switch (((IIntStream) this.input).LA(1))
    {
      case 36:
        num = 3;
        break;
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
      case 80 /*0x50*/:
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
        num = 2;
        break;
      case 92:
        num = 5;
        break;
      case 95:
        num = 4;
        break;
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
      case 112 /*0x70*/:
      case 113:
      case 114:
      case 115:
      case 116:
      case 117:
      case 118:
      case 119:
      case 120:
      case 121:
      case 122:
        num = 1;
        break;
      default:
        throw new NoViableAltException("", 5, 0, (IIntStream) this.input);
    }
    switch (num)
    {
      case 1:
        this.MatchRange(97, 122);
        break;
      case 2:
        this.MatchRange(65, 90);
        break;
      case 3:
        this.Match(36);
        break;
      case 4:
        this.Match(95);
        break;
      case 5:
        this.mBSLASH();
        this.Match(117);
        this.mHexDigit();
        this.mHexDigit();
        this.mHexDigit();
        this.mHexDigit();
        break;
    }
  }

  [GrammarRule("IdentifierPart")]
  private void mIdentifierPart()
  {
    int num;
    switch (((IIntStream) this.input).LA(1))
    {
      case 36:
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
      case 80 /*0x50*/:
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
      case 92:
      case 95:
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
      case 112 /*0x70*/:
      case 113:
      case 114:
      case 115:
      case 116:
      case 117:
      case 118:
      case 119:
      case 120:
      case 121:
      case 122:
        num = 2;
        break;
      case 48 /*0x30*/:
      case 49:
      case 50:
      case 51:
      case 52:
      case 53:
      case 54:
      case 55:
      case 56:
      case 57:
        num = 1;
        break;
      default:
        num = 3;
        break;
    }
    switch (num)
    {
      case 1:
        this.mDecimalDigit();
        break;
      case 2:
        this.mIdentifierStartASCII();
        break;
      case 3:
        if (!this.IsIdentifierPartUnicode(((IIntStream) this.input).LA(1)))
          throw new FailedPredicateException((IIntStream) this.input, "IdentifierPart", " IsIdentifierPartUnicode(input.LA(1)) ");
        this.MatchAny();
        break;
    }
  }

  [GrammarRule("IdentifierNameASCIIStart")]
  private void mIdentifierNameASCIIStart()
  {
    this.mIdentifierStartASCII();
    while (true)
    {
      int num1 = 2;
      int num2 = ((IIntStream) this.input).LA(1);
      if (num2 == 36 || num2 >= 48 /*0x30*/ && num2 <= 57 || num2 >= 65 && num2 <= 90 || num2 == 92 || num2 == 95 || num2 >= 97 && num2 <= 122)
        num1 = 1;
      else if (this.IsIdentifierPartUnicode(((IIntStream) this.input).LA(1)))
        num1 = 1;
      if (num1 == 1)
        this.mIdentifierPart();
      else
        break;
    }
  }

  [GrammarRule("Identifier")]
  private void mIdentifier()
  {
    int num1 = 79;
    int num2 = 0;
    int num3 = ((IIntStream) this.input).LA(1);
    switch (num3 == 36 || num3 >= 65 && num3 <= 90 || num3 == 92 || num3 == 95 || num3 >= 97 && num3 <= 122 ? 1 : 2)
    {
      case 1:
        this.mIdentifierNameASCIIStart();
        break;
      case 2:
        this.ConsumeIdentifierUnicodeStart();
        break;
    }
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("DecimalDigit")]
  private void mDecimalDigit()
  {
    if (((IIntStream) this.input).LA(1) >= 48 /*0x30*/ && ((IIntStream) this.input).LA(1) <= 57)
    {
      ((IIntStream) this.input).Consume();
    }
    else
    {
      MismatchedSetException mismatchedSetException = new MismatchedSetException((BitSet) null, (IIntStream) this.input);
      this.Recover((RecognitionException) mismatchedSetException);
      throw mismatchedSetException;
    }
  }

  [GrammarRule("HexDigit")]
  private void mHexDigit()
  {
    if (((IIntStream) this.input).LA(1) >= 48 /*0x30*/ && ((IIntStream) this.input).LA(1) <= 57 || ((IIntStream) this.input).LA(1) >= 65 && ((IIntStream) this.input).LA(1) <= 70 || ((IIntStream) this.input).LA(1) >= 97 && ((IIntStream) this.input).LA(1) <= 102)
    {
      ((IIntStream) this.input).Consume();
    }
    else
    {
      MismatchedSetException mismatchedSetException = new MismatchedSetException((BitSet) null, (IIntStream) this.input);
      this.Recover((RecognitionException) mismatchedSetException);
      throw mismatchedSetException;
    }
  }

  [GrammarRule("OctalDigit")]
  private void mOctalDigit()
  {
    if (((IIntStream) this.input).LA(1) >= 48 /*0x30*/ && ((IIntStream) this.input).LA(1) <= 55)
    {
      ((IIntStream) this.input).Consume();
    }
    else
    {
      MismatchedSetException mismatchedSetException = new MismatchedSetException((BitSet) null, (IIntStream) this.input);
      this.Recover((RecognitionException) mismatchedSetException);
      throw mismatchedSetException;
    }
  }

  [GrammarRule("ExponentPart")]
  private void mExponentPart()
  {
    if (((IIntStream) this.input).LA(1) == 69 || ((IIntStream) this.input).LA(1) == 101)
    {
      ((IIntStream) this.input).Consume();
      int num1 = 2;
      switch (((IIntStream) this.input).LA(1))
      {
        case 43:
        case 45:
          num1 = 1;
          break;
      }
      if (num1 == 1)
        ((IIntStream) this.input).Consume();
      int num2 = 0;
      while (true)
      {
        int num3 = 2;
        switch (((IIntStream) this.input).LA(1))
        {
          case 48 /*0x30*/:
          case 49:
          case 50:
          case 51:
          case 52:
          case 53:
          case 54:
          case 55:
          case 56:
          case 57:
            num3 = 1;
            break;
        }
        if (num3 == 1)
        {
          ((IIntStream) this.input).Consume();
          ++num2;
        }
        else
          break;
      }
      if (num2 < 1)
        throw new EarlyExitException(10, (IIntStream) this.input);
    }
    else
    {
      MismatchedSetException mismatchedSetException = new MismatchedSetException((BitSet) null, (IIntStream) this.input);
      this.Recover((RecognitionException) mismatchedSetException);
      throw mismatchedSetException;
    }
  }

  [GrammarRule("DecimalIntegerLiteral")]
  private void mDecimalIntegerLiteral()
  {
    int num1;
    switch (((IIntStream) this.input).LA(1))
    {
      case 48 /*0x30*/:
        num1 = 1;
        break;
      case 49:
      case 50:
      case 51:
      case 52:
      case 53:
      case 54:
      case 55:
      case 56:
      case 57:
        num1 = 2;
        break;
      default:
        throw new NoViableAltException("", 12, 0, (IIntStream) this.input);
    }
    switch (num1)
    {
      case 1:
        this.Match(48 /*0x30*/);
        break;
      case 2:
        this.MatchRange(49, 57);
        while (true)
        {
          int num2 = 2;
          switch (((IIntStream) this.input).LA(1))
          {
            case 48 /*0x30*/:
            case 49:
            case 50:
            case 51:
            case 52:
            case 53:
            case 54:
            case 55:
            case 56:
            case 57:
              num2 = 1;
              break;
          }
          if (num2 == 1)
            ((IIntStream) this.input).Consume();
          else
            break;
        }
        break;
    }
  }

  [GrammarRule("OctalIntegerLiteral")]
  private void mOctalIntegerLiteral()
  {
    int num1 = 114;
    int num2 = 0;
    this.Match(48 /*0x30*/);
    int num3 = 0;
    while (true)
    {
      int num4 = 2;
      switch (((IIntStream) this.input).LA(1))
      {
        case 48 /*0x30*/:
        case 49:
        case 50:
        case 51:
        case 52:
        case 53:
        case 54:
        case 55:
          num4 = 1;
          break;
      }
      if (num4 == 1)
      {
        ((IIntStream) this.input).Consume();
        ++num3;
      }
      else
        break;
    }
    if (num3 < 1)
      throw new EarlyExitException(13, (IIntStream) this.input);
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("DecimalLiteral")]
  private void mDecimalLiteral()
  {
    int num1 = 44;
    int num2 = 0;
    int num3;
    try
    {
      num3 = this.dfa19.Predict((IIntStream) this.input);
    }
    catch (NoViableAltException ex)
    {
      throw;
    }
    switch (num3)
    {
      case 1:
        this.mDecimalIntegerLiteral();
        this.Match(46);
        while (true)
        {
          int num4 = 2;
          switch (((IIntStream) this.input).LA(1))
          {
            case 48 /*0x30*/:
            case 49:
            case 50:
            case 51:
            case 52:
            case 53:
            case 54:
            case 55:
            case 56:
            case 57:
              num4 = 1;
              break;
          }
          if (num4 == 1)
            ((IIntStream) this.input).Consume();
          else
            break;
        }
        int num5 = 2;
        switch (((IIntStream) this.input).LA(1))
        {
          case 69:
          case 101:
            num5 = 1;
            break;
        }
        if (num5 == 1)
        {
          this.mExponentPart();
          break;
        }
        break;
      case 2:
        this.Match(46);
        int num6 = 0;
        while (true)
        {
          int num7 = 2;
          switch (((IIntStream) this.input).LA(1))
          {
            case 48 /*0x30*/:
            case 49:
            case 50:
            case 51:
            case 52:
            case 53:
            case 54:
            case 55:
            case 56:
            case 57:
              num7 = 1;
              break;
          }
          if (num7 == 1)
          {
            ((IIntStream) this.input).Consume();
            ++num6;
          }
          else
            break;
        }
        if (num6 < 1)
          throw new EarlyExitException(16 /*0x10*/, (IIntStream) this.input);
        int num8 = 2;
        switch (((IIntStream) this.input).LA(1))
        {
          case 69:
          case 101:
            num8 = 1;
            break;
        }
        if (num8 == 1)
        {
          this.mExponentPart();
          break;
        }
        break;
      case 3:
        while (true)
        {
          int num9 = 2;
          if (((IIntStream) this.input).LA(1) == 48 /*0x30*/)
          {
            switch (((IIntStream) this.input).LA(2))
            {
              case 48 /*0x30*/:
              case 49:
              case 50:
              case 51:
              case 52:
              case 53:
              case 54:
              case 55:
              case 56:
              case 57:
                num9 = 1;
                break;
            }
          }
          if (num9 == 1)
            this.Match(48 /*0x30*/);
          else
            break;
        }
        this.mDecimalIntegerLiteral();
        break;
      case 4:
        this.mDecimalIntegerLiteral();
        this.mExponentPart();
        break;
    }
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("HexIntegerLiteral")]
  private void mHexIntegerLiteral()
  {
    int num1 = 68;
    int num2 = 0;
    if (((IIntStream) this.input).LA(1) != 48 /*0x30*/)
      throw new NoViableAltException("", 20, 0, (IIntStream) this.input);
    int num3;
    switch (((IIntStream) this.input).LA(2))
    {
      case 88:
        num3 = 2;
        break;
      case 120:
        num3 = 1;
        break;
      default:
        throw new NoViableAltException("", 20, 1, (IIntStream) this.input);
    }
    switch (num3)
    {
      case 1:
        this.Match("0x");
        break;
      case 2:
        this.Match("0X");
        break;
    }
    int num4 = 0;
    while (true)
    {
      int num5 = 2;
      int num6 = ((IIntStream) this.input).LA(1);
      if (num6 >= 48 /*0x30*/ && num6 <= 57 || num6 >= 65 && num6 <= 70 || num6 >= 97 && num6 <= 102)
        num5 = 1;
      if (num5 == 1)
      {
        ((IIntStream) this.input).Consume();
        ++num4;
      }
      else
        break;
    }
    if (num4 < 1)
      throw new EarlyExitException(21, (IIntStream) this.input);
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("CharacterEscapeSequence")]
  private void mCharacterEscapeSequence()
  {
    if (((IIntStream) this.input).LA(1) >= 0 && ((IIntStream) this.input).LA(1) <= 9 || ((IIntStream) this.input).LA(1) >= 11 && ((IIntStream) this.input).LA(1) <= 12 || ((IIntStream) this.input).LA(1) >= 14 && ((IIntStream) this.input).LA(1) <= 47 || ((IIntStream) this.input).LA(1) >= 58 && ((IIntStream) this.input).LA(1) <= 116 || ((IIntStream) this.input).LA(1) >= 118 && ((IIntStream) this.input).LA(1) <= 119 || ((IIntStream) this.input).LA(1) >= 121 && ((IIntStream) this.input).LA(1) <= 8231 || ((IIntStream) this.input).LA(1) >= 8234 && ((IIntStream) this.input).LA(1) <= (int) ushort.MaxValue)
    {
      ((IIntStream) this.input).Consume();
    }
    else
    {
      MismatchedSetException mismatchedSetException = new MismatchedSetException((BitSet) null, (IIntStream) this.input);
      this.Recover((RecognitionException) mismatchedSetException);
      throw mismatchedSetException;
    }
  }

  [GrammarRule("ZeroToThree")]
  private void mZeroToThree()
  {
    if (((IIntStream) this.input).LA(1) >= 48 /*0x30*/ && ((IIntStream) this.input).LA(1) <= 51)
    {
      ((IIntStream) this.input).Consume();
    }
    else
    {
      MismatchedSetException mismatchedSetException = new MismatchedSetException((BitSet) null, (IIntStream) this.input);
      this.Recover((RecognitionException) mismatchedSetException);
      throw mismatchedSetException;
    }
  }

  [GrammarRule("OctalEscapeSequence")]
  private void mOctalEscapeSequence()
  {
    int num1 = ((IIntStream) this.input).LA(1);
    int num2;
    if (num1 >= 48 /*0x30*/ && num1 <= 51)
    {
      switch (((IIntStream) this.input).LA(2))
      {
        case 48 /*0x30*/:
        case 49:
        case 50:
        case 51:
        case 52:
        case 53:
        case 54:
        case 55:
          switch (((IIntStream) this.input).LA(3))
          {
            case 48 /*0x30*/:
            case 49:
            case 50:
            case 51:
            case 52:
            case 53:
            case 54:
            case 55:
              num2 = 4;
              break;
            default:
              num2 = 2;
              break;
          }
          break;
        default:
          num2 = 1;
          break;
      }
    }
    else
    {
      if (num1 < 52 || num1 > 55)
        throw new NoViableAltException("", 22, 0, (IIntStream) this.input);
      switch (((IIntStream) this.input).LA(2))
      {
        case 48 /*0x30*/:
        case 49:
        case 50:
        case 51:
        case 52:
        case 53:
        case 54:
        case 55:
          num2 = 3;
          break;
        default:
          num2 = 1;
          break;
      }
    }
    switch (num2)
    {
      case 1:
        this.mOctalDigit();
        break;
      case 2:
        this.mZeroToThree();
        this.mOctalDigit();
        break;
      case 3:
        this.MatchRange(52, 55);
        this.mOctalDigit();
        break;
      case 4:
        this.mZeroToThree();
        this.mOctalDigit();
        this.mOctalDigit();
        break;
    }
  }

  [GrammarRule("HexEscapeSequence")]
  private void mHexEscapeSequence()
  {
    this.Match(120);
    this.mHexDigit();
    this.mHexDigit();
  }

  [GrammarRule("UnicodeEscapeSequence")]
  private void mUnicodeEscapeSequence()
  {
    this.Match(117);
    this.mHexDigit();
    this.mHexDigit();
    this.mHexDigit();
    this.mHexDigit();
  }

  [GrammarRule("EscapeSequence")]
  private void mEscapeSequence()
  {
    this.mBSLASH();
    int num1 = ((IIntStream) this.input).LA(1);
    int num2;
    if (num1 >= 0 && num1 <= 9 || num1 >= 11 && num1 <= 12 || num1 >= 14 && num1 <= 47 || num1 >= 58 && num1 <= 116 || num1 >= 118 && num1 <= 119 || num1 >= 121 && num1 <= 8231 || num1 >= 8234 && num1 <= (int) ushort.MaxValue)
      num2 = 1;
    else if (num1 >= 48 /*0x30*/ && num1 <= 55)
    {
      num2 = 2;
    }
    else
    {
      switch (num1)
      {
        case 117:
          num2 = 4;
          break;
        case 120:
          num2 = 3;
          break;
        default:
          if (num1 != 10 && num1 != 13)
            throw new NoViableAltException("", 24, 0, (IIntStream) this.input);
          num2 = 5;
          break;
      }
    }
    switch (num2)
    {
      case 1:
        this.mCharacterEscapeSequence();
        break;
      case 2:
        this.mOctalEscapeSequence();
        break;
      case 3:
        this.mHexEscapeSequence();
        break;
      case 4:
        this.mUnicodeEscapeSequence();
        break;
      case 5:
        int num3 = 2;
        if (((IIntStream) this.input).LA(1) == 13)
          num3 = 1;
        if (num3 == 1)
          ((IIntStream) this.input).Consume();
        this.mLF();
        break;
    }
  }

  [GrammarRule("StringLiteral")]
  private void mStringLiteral()
  {
    int num1 = 150;
    int num2 = 0;
    int num3;
    switch (((IIntStream) this.input).LA(1))
    {
      case 34:
        num3 = 2;
        break;
      case 39:
        num3 = 1;
        break;
      default:
        throw new NoViableAltException("", 27, 0, (IIntStream) this.input);
    }
    switch (num3)
    {
      case 1:
        this.mSQUOTE();
        while (true)
        {
          int num4 = 3;
          int num5 = ((IIntStream) this.input).LA(1);
          if (num5 >= 0 && num5 <= 9 || num5 >= 11 && num5 <= 12 || num5 >= 14 && num5 <= 38 || num5 >= 40 && num5 <= 91 || num5 >= 93 && num5 <= 8231 || num5 >= 8234 && num5 <= (int) ushort.MaxValue)
            num4 = 1;
          else if (num5 == 92)
            num4 = 2;
          switch (num4)
          {
            case 1:
              ((IIntStream) this.input).Consume();
              continue;
            case 2:
              this.mEscapeSequence();
              continue;
            default:
              goto label_13;
          }
        }
label_13:
        this.mSQUOTE();
        break;
      case 2:
        this.mDQUOTE();
        while (true)
        {
          int num6 = 3;
          int num7 = ((IIntStream) this.input).LA(1);
          if (num7 >= 0 && num7 <= 9 || num7 >= 11 && num7 <= 12 || num7 >= 14 && num7 <= 33 || num7 >= 35 && num7 <= 91 || num7 >= 93 && num7 <= 8231 || num7 >= 8234 && num7 <= (int) ushort.MaxValue)
            num6 = 1;
          else if (num7 == 92)
            num6 = 2;
          switch (num6)
          {
            case 1:
              ((IIntStream) this.input).Consume();
              continue;
            case 2:
              this.mEscapeSequence();
              continue;
            default:
              goto label_22;
          }
        }
label_22:
        this.mDQUOTE();
        break;
    }
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  [GrammarRule("BackslashSequence")]
  private void mBackslashSequence()
  {
    this.mBSLASH();
    if (((IIntStream) this.input).LA(1) >= 0 && ((IIntStream) this.input).LA(1) <= 9 || ((IIntStream) this.input).LA(1) >= 11 && ((IIntStream) this.input).LA(1) <= 12 || ((IIntStream) this.input).LA(1) >= 14 && ((IIntStream) this.input).LA(1) <= 8231 || ((IIntStream) this.input).LA(1) >= 8234 && ((IIntStream) this.input).LA(1) <= (int) ushort.MaxValue)
    {
      ((IIntStream) this.input).Consume();
    }
    else
    {
      MismatchedSetException mismatchedSetException = new MismatchedSetException((BitSet) null, (IIntStream) this.input);
      this.Recover((RecognitionException) mismatchedSetException);
      throw mismatchedSetException;
    }
  }

  [GrammarRule("RegularExpressionFirstChar")]
  private void mRegularExpressionFirstChar()
  {
    int num1 = ((IIntStream) this.input).LA(1);
    int num2;
    if (num1 >= 0 && num1 <= 9 || num1 >= 11 && num1 <= 12 || num1 >= 14 && num1 <= 41 || num1 >= 43 && num1 <= 46 || num1 >= 48 /*0x30*/ && num1 <= 91 || num1 >= 93 && num1 <= 8231 || num1 >= 8234 && num1 <= (int) ushort.MaxValue)
    {
      num2 = 1;
    }
    else
    {
      if (num1 != 92)
        throw new NoViableAltException("", 28, 0, (IIntStream) this.input);
      num2 = 2;
    }
    switch (num2)
    {
      case 1:
        ((IIntStream) this.input).Consume();
        break;
      case 2:
        this.mBackslashSequence();
        break;
    }
  }

  [GrammarRule("RegularExpressionChar")]
  private void mRegularExpressionChar()
  {
    int num1 = ((IIntStream) this.input).LA(1);
    int num2;
    if (num1 >= 0 && num1 <= 9 || num1 >= 11 && num1 <= 12 || num1 >= 14 && num1 <= 46 || num1 >= 48 /*0x30*/ && num1 <= 91 || num1 >= 93 && num1 <= 8231 || num1 >= 8234 && num1 <= (int) ushort.MaxValue)
    {
      num2 = 1;
    }
    else
    {
      if (num1 != 92)
        throw new NoViableAltException("", 29, 0, (IIntStream) this.input);
      num2 = 2;
    }
    switch (num2)
    {
      case 1:
        ((IIntStream) this.input).Consume();
        break;
      case 2:
        this.mBackslashSequence();
        break;
    }
  }

  [GrammarRule("RegularExpressionLiteral")]
  private void mRegularExpressionLiteral()
  {
    int num1 = 131;
    int num2 = 0;
    if (!this.AreRegularExpressionsEnabled())
      throw new FailedPredicateException((IIntStream) this.input, "RegularExpressionLiteral", " AreRegularExpressionsEnabled() ");
    this.mDIV();
    this.mRegularExpressionFirstChar();
    while (true)
    {
      int num3 = 2;
      int num4 = ((IIntStream) this.input).LA(1);
      if (num4 >= 0 && num4 <= 9 || num4 >= 11 && num4 <= 12 || num4 >= 14 && num4 <= 46 || num4 >= 48 /*0x30*/ && num4 <= 8231 || num4 >= 8234 && num4 <= (int) ushort.MaxValue)
        num3 = 1;
      if (num3 == 1)
        this.mRegularExpressionChar();
      else
        break;
    }
    this.mDIV();
    while (true)
    {
      int num5 = 2;
      int num6 = ((IIntStream) this.input).LA(1);
      if (num6 == 36 || num6 >= 48 /*0x30*/ && num6 <= 57 || num6 >= 65 && num6 <= 90 || num6 == 92 || num6 == 95 || num6 >= 97 && num6 <= 122)
        num5 = 1;
      else if (this.IsIdentifierPartUnicode(((IIntStream) this.input).LA(1)))
        num5 = 1;
      if (num5 == 1)
        this.mIdentifierPart();
      else
        break;
    }
    ((BaseRecognizer) this).state.type = num1;
    ((BaseRecognizer) this).state.channel = num2;
  }

  public virtual void mTokens()
  {
    int num;
    try
    {
      num = this.dfa32.Predict((IIntStream) this.input);
    }
    catch (NoViableAltException ex)
    {
      throw;
    }
    switch (num)
    {
      case 1:
        this.mABSTRACT();
        break;
      case 2:
        this.mADD();
        break;
      case 3:
        this.mADDASS();
        break;
      case 4:
        this.mAND();
        break;
      case 5:
        this.mANDASS();
        break;
      case 6:
        this.mASSIGN();
        break;
      case 7:
        this.mBOOLEAN();
        break;
      case 8:
        this.mBREAK();
        break;
      case 9:
        this.mBYTE();
        break;
      case 10:
        this.mCASE();
        break;
      case 11:
        this.mCATCH();
        break;
      case 12:
        this.mCHAR();
        break;
      case 13:
        this.mCLASS();
        break;
      case 14:
        this.mCOLON();
        break;
      case 15:
        this.mCOMMA();
        break;
      case 16 /*0x10*/:
        this.mCONST();
        break;
      case 17:
        this.mCONTINUE();
        break;
      case 18:
        this.mDEBUGGER();
        break;
      case 19:
        this.mDEC();
        break;
      case 20:
        this.mDEFAULT();
        break;
      case 21:
        this.mDELETE();
        break;
      case 22:
        this.mDIV();
        break;
      case 23:
        this.mDIVASS();
        break;
      case 24:
        this.mDO();
        break;
      case 25:
        this.mDOT();
        break;
      case 26:
        this.mDOUBLE();
        break;
      case 27:
        this.mELSE();
        break;
      case 28:
        this.mENUM();
        break;
      case 29:
        this.mEQ();
        break;
      case 30:
        this.mEXPORT();
        break;
      case 31 /*0x1F*/:
        this.mEXTENDS();
        break;
      case 32 /*0x20*/:
        this.mFALSE();
        break;
      case 33:
        this.mFINAL();
        break;
      case 34:
        this.mFINALLY();
        break;
      case 35:
        this.mFLOAT();
        break;
      case 36:
        this.mFOR();
        break;
      case 37:
        this.mFUNCTION();
        break;
      case 38:
        this.mGOTO();
        break;
      case 39:
        this.mGT();
        break;
      case 40:
        this.mGTE();
        break;
      case 41:
        this.mIF();
        break;
      case 42:
        this.mIMPLEMENTS();
        break;
      case 43:
        this.mIMPORT();
        break;
      case 44:
        this.mIN();
        break;
      case 45:
        this.mINC();
        break;
      case 46:
        this.mINSTANCEOF();
        break;
      case 47:
        this.mINT();
        break;
      case 48 /*0x30*/:
        this.mINTERFACE();
        break;
      case 49:
        this.mINV();
        break;
      case 50:
        this.mLAND();
        break;
      case 51:
        this.mLBRACE();
        break;
      case 52:
        this.mLBRACK();
        break;
      case 53:
        this.mLONG();
        break;
      case 54:
        this.mLOR();
        break;
      case 55:
        this.mLPAREN();
        break;
      case 56:
        this.mLT();
        break;
      case 57:
        this.mLTE();
        break;
      case 58:
        this.mMOD();
        break;
      case 59:
        this.mMODASS();
        break;
      case 60:
        this.mMUL();
        break;
      case 61:
        this.mMULASS();
        break;
      case 62:
        this.mNATIVE();
        break;
      case 63 /*0x3F*/:
        this.mNEQ();
        break;
      case 64 /*0x40*/:
        this.mNEW();
        break;
      case 65:
        this.mNOT();
        break;
      case 66:
        this.mNSAME();
        break;
      case 67:
        this.mNULL();
        break;
      case 68:
        this.mOR();
        break;
      case 69:
        this.mORASS();
        break;
      case 70:
        this.mPACKAGE();
        break;
      case 71:
        this.mPRIVATE();
        break;
      case 72:
        this.mPROTECTED();
        break;
      case 73:
        this.mPUBLIC();
        break;
      case 74:
        this.mQUE();
        break;
      case 75:
        this.mRBRACE();
        break;
      case 76:
        this.mRBRACK();
        break;
      case 77:
        this.mRETURN();
        break;
      case 78:
        this.mRPAREN();
        break;
      case 79:
        this.mSAME();
        break;
      case 80 /*0x50*/:
        this.mSEMIC();
        break;
      case 81:
        this.mSHL();
        break;
      case 82:
        this.mSHLASS();
        break;
      case 83:
        this.mSHORT();
        break;
      case 84:
        this.mSHR();
        break;
      case 85:
        this.mSHRASS();
        break;
      case 86:
        this.mSHU();
        break;
      case 87:
        this.mSHUASS();
        break;
      case 88:
        this.mSTATIC();
        break;
      case 89:
        this.mSUB();
        break;
      case 90:
        this.mSUBASS();
        break;
      case 91:
        this.mSUPER();
        break;
      case 92:
        this.mSWITCH();
        break;
      case 93:
        this.mSYNCHRONIZED();
        break;
      case 94:
        this.mTHIS();
        break;
      case 95:
        this.mTHROW();
        break;
      case 96 /*0x60*/:
        this.mTHROWS();
        break;
      case 97:
        this.mTRANSIENT();
        break;
      case 98:
        this.mTRUE();
        break;
      case 99:
        this.mTRY();
        break;
      case 100:
        this.mTYPEOF();
        break;
      case 101:
        this.mVAR();
        break;
      case 102:
        this.mVOID();
        break;
      case 103:
        this.mVOLATILE();
        break;
      case 104:
        this.mWHILE();
        break;
      case 105:
        this.mWITH();
        break;
      case 106:
        this.mXOR();
        break;
      case 107:
        this.mXORASS();
        break;
      case 108:
        this.mWhiteSpace();
        break;
      case 109:
        this.mEOL();
        break;
      case 110:
        this.mMultiLineComment();
        break;
      case 111:
        this.mSingleLineComment();
        break;
      case 112 /*0x70*/:
        this.mIdentifier();
        break;
      case 113:
        this.mOctalIntegerLiteral();
        break;
      case 114:
        this.mDecimalLiteral();
        break;
      case 115:
        this.mHexIntegerLiteral();
        break;
      case 116:
        this.mStringLiteral();
        break;
      case 117:
        this.mRegularExpressionLiteral();
        break;
    }
  }

  protected virtual void InitDFAs()
  {
    ((BaseRecognizer) this).InitDFAs();
    this.dfa19 = new ES3Lexer.DFA19((BaseRecognizer) this);
    // ISSUE: method pointer
    this.dfa32 = new ES3Lexer.DFA32((BaseRecognizer) this, new SpecialStateTransitionHandler((object) this, __methodptr(SpecialStateTransition32)));
  }

  private int SpecialStateTransition32(DFA dfa, int s, IIntStream _input)
  {
    IIntStream iintStream = _input;
    int num1 = s;
    switch (s)
    {
      case 0:
        int num2 = iintStream.LA(1);
        int index1 = iintStream.Index;
        iintStream.Rewind();
        s = -1;
        s = num2 != 61 ? (num2 != 42 ? (num2 != 47 ? ((num2 < 0 || num2 > 9) && (num2 < 11 || num2 > 12) && (num2 < 14 || num2 > 41) && (num2 < 43 || num2 > 46) && (num2 < 48 /*0x30*/ || num2 > 60) && (num2 < 62 || num2 > 8231) && (num2 < 8234 || num2 > (int) ushort.MaxValue) || !this.AreRegularExpressionsEnabled() ? 71 : 72) : 70) : 69) : 68;
        iintStream.Seek(index1);
        if (s >= 0)
          return s;
        break;
      case 1:
        int num3 = iintStream.LA(1);
        int index2 = iintStream.Index;
        iintStream.Rewind();
        s = -1;
        s = (num3 < 0 || num3 > 9) && (num3 < 11 || num3 > 12) && (num3 < 14 || num3 > 8231) && (num3 < 8234 || num3 > (int) ushort.MaxValue) || !this.AreRegularExpressionsEnabled() ? 142 : 72;
        iintStream.Seek(index2);
        if (s >= 0)
          return s;
        break;
    }
    NoViableAltException viableAltException = new NoViableAltException(dfa.Description, 32 /*0x20*/, num1, iintStream);
    dfa.Error(viableAltException);
    throw viableAltException;
  }

  private class DFA19 : DFA
  {
    private const string DFA19_eotS = "\u0001\uFFFF\u0002\u0004\u0004\uFFFF\u0001\u0004";
    private const string DFA19_eofS = "\b\uFFFF";
    private const string DFA19_minS = "\u0003.\u0004\uFFFF\u0001.";
    private const string DFA19_maxS = "\u00019\u0002e\u0004\uFFFF\u0001e";
    private const string DFA19_acceptS = "\u0003\uFFFF\u0001\u0002\u0001\u0003\u0001\u0001\u0001\u0004\u0001\uFFFF";
    private const string DFA19_specialS = "\b\uFFFF}>";
    private static readonly string[] DFA19_transitionS = new string[8]
    {
      "\u0001\u0003\u0001\uFFFF\u0001\u0001\t\u0002",
      "\u0001\u0005\u0016\uFFFF\u0001\u0006\u001F\uFFFF\u0001\u0006",
      "\u0001\u0005\u0001\uFFFF\n\a\v\uFFFF\u0001\u0006\u001F\uFFFF\u0001\u0006",
      "",
      "",
      "",
      "",
      "\u0001\u0005\u0001\uFFFF\n\a\v\uFFFF\u0001\u0006\u001F\uFFFF\u0001\u0006"
    };
    private static readonly short[] DFA19_eot = DFA.UnpackEncodedString("\u0001\uFFFF\u0002\u0004\u0004\uFFFF\u0001\u0004");
    private static readonly short[] DFA19_eof = DFA.UnpackEncodedString("\b\uFFFF");
    private static readonly char[] DFA19_min = DFA.UnpackEncodedStringToUnsignedChars("\u0003.\u0004\uFFFF\u0001.");
    private static readonly char[] DFA19_max = DFA.UnpackEncodedStringToUnsignedChars("\u00019\u0002e\u0004\uFFFF\u0001e");
    private static readonly short[] DFA19_accept = DFA.UnpackEncodedString("\u0003\uFFFF\u0001\u0002\u0001\u0003\u0001\u0001\u0001\u0004\u0001\uFFFF");
    private static readonly short[] DFA19_special = DFA.UnpackEncodedString("\b\uFFFF}>");
    private static readonly short[][] DFA19_transition;

    static DFA19()
    {
      int length = ES3Lexer.DFA19.DFA19_transitionS.Length;
      ES3Lexer.DFA19.DFA19_transition = new short[length][];
      for (int index = 0; index < length; ++index)
        ES3Lexer.DFA19.DFA19_transition[index] = DFA.UnpackEncodedString(ES3Lexer.DFA19.DFA19_transitionS[index]);
    }

    public DFA19(BaseRecognizer recognizer)
    {
      this.recognizer = recognizer;
      this.decisionNumber = 19;
      this.eot = ES3Lexer.DFA19.DFA19_eot;
      this.eof = ES3Lexer.DFA19.DFA19_eof;
      this.min = ES3Lexer.DFA19.DFA19_min;
      this.max = ES3Lexer.DFA19.DFA19_max;
      this.accept = ES3Lexer.DFA19.DFA19_accept;
      this.special = ES3Lexer.DFA19.DFA19_special;
      this.transition = ES3Lexer.DFA19.DFA19_transition;
    }

    public virtual string Description
    {
      get
      {
        return "893:1: DecimalLiteral : ( DecimalIntegerLiteral '.' ( DecimalDigit )* ( ExponentPart )? | '.' ( DecimalDigit )+ ( ExponentPart )? | ( '0' )* DecimalIntegerLiteral | DecimalIntegerLiteral ExponentPart );";
      }
    }

    public virtual void Error(NoViableAltException nvae)
    {
    }
  }

  private class DFA32 : DFA
  {
    private const string DFA32_eotS = "\u0002+\u00012\u00015\u00017\u0002+\u0002\uFFFF\u0001+\u0001C\u0001G\u0001I\u0003+\u0001U\u0001+\u0003\uFFFF\u0001+\u0001\\\u0001\uFFFF\u0001_\u0001a\u0001c\u0001+\u0001h\u0001+\u0003\uFFFF\u0001+\u0002\uFFFF\u0004+\u0001z\u0003\uFFFF\u0001-\u0002\uFFFF\u0001+\u0006\uFFFF\u0001\u0080\u0001\uFFFF\b+\u0001\u008D\u0003\uFFFF\u0001\u008E\u0005\uFFFF\t+\u0001\uFFFF\u0001\u009B\u0001\uFFFF\u0001\u009C\u0001+\u0001 \u0001+\u0004\uFFFF\u0001£\u0005\uFFFF\u0003+\u0001¨\u0001\uFFFF\u0010+\u0003\uFFFF\u0002\u00BE\u0001+\u0002\uFFFF\f+\u0002\uFFFF\a+\u0001Õ\u0002+\u0001\uFFFF\u0001Ù\u0002\uFFFF\u0002+\u0001Þ\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001á\u0001+\u0002\uFFFF\u000E+\u0001ñ\u0001+\u0001ó\u0004+\u0001\uFFFF\u0001\u00BE\u0003+\u0001û\u0001ü\u0001+\u0001þ\a+\u0001Ć\u0001ć\u0005+\u0001\uFFFF\u0001+\u0001Ď\u0002\uFFFF\u0004+\u0001\uFFFF\u0001ē\u0001+\u0001\uFFFF\u0001ĕ\n+\u0001Ġ\u0002+\u0001ģ\u0001\uFFFF\u0001+\u0001\uFFFF\u0001ĥ\u0002+\u0001Ĩ\u0002+\u0001ī\u0002\uFFFF\u0001Ĭ\u0001\uFFFF\u0001ĭ\u0001Į\u0005+\u0002\uFFFF\u0002+\u0001Ķ\u0001ĸ\u0001Ĺ\u0001+\u0001\uFFFF\u0004+\u0001\uFFFF\u0001+\u0001\uFFFF\u0005+\u0001Ņ\u0001+\u0001Ň\u0002+\u0001\uFFFF\u0001ŋ\u0001+\u0001\uFFFF\u0001+\u0001\uFFFF\u0001+\u0001ŏ\u0001\uFFFF\u0002+\u0004\uFFFF\u0003+\u0001ŕ\u0001Ŗ\u0001ŗ\u0001+\u0001\uFFFF\u0001+\u0002\uFFFF\u0002+\u0001Ŝ\u0002+\u0001ş\u0003+\u0001ţ\u0001Ť\u0001\uFFFF\u0001ť\u0001\uFFFF\u0001Ŧ\u0001+\u0001Ũ\u0001\uFFFF\u0001+\u0001Ū\u0001+\u0001\uFFFF\u0001+\u0001ŭ\u0002+\u0001Ű\u0003\uFFFF\u0001ű\u0001Ų\u0002+\u0001\uFFFF\u0002+\u0001\uFFFF\u0001ŷ\u0001Ÿ\u0001+\u0004\uFFFF\u0001+\u0001\uFFFF\u0001+\u0001\uFFFF\u0001+\u0001Ž\u0001\uFFFF\u0001ž\u0001ſ\u0003\uFFFF\u0001ƀ\u0003+\u0002\uFFFF\u0003+\u0001Ƈ\u0004\uFFFF\u0002+\u0001Ɗ\u0001Ƌ\u0001+\u0001ƍ\u0001\uFFFF\u0001Ǝ\u0001Ə\u0002\uFFFF\u0001+\u0003\uFFFF\u0001+\u0001ƒ\u0001\uFFFF";
    private const string DFA32_eofS = "Ɠ\uFFFF";
    private const string DFA32_minS = "\u0001\t\u0001b\u0001+\u0001&\u0001=\u0001o\u0001a\u0002\uFFFF\u0001e\u0001-\u0001\0\u00010\u0001l\u0001a\u0001o\u0001=\u0001f\u0003\uFFFF\u0001o\u0001=\u0001\uFFFF\u0001<\u0002=\u0001a\u0001=\u0001a\u0003\uFFFF\u0001e\u0002\uFFFF\u0002h\u0001a\u0001h\u0001=\u0003\uFFFF\u00010\u0002\uFFFF\u0001s\u0006\uFFFF\u0001=\u0001\uFFFF\u0001o\u0001e\u0001t\u0001s\u0002a\u0001n\u0001b\u0001$\u0003\uFFFF\u0001\0\u0005\uFFFF\u0001s\u0001u\u0001p\u0001l\u0001n\u0001o\u0001r\u0001n\u0001t\u0001\uFFFF\u0001=\u0001\uFFFF\u0001$\u0001p\u0001$\u0001n\u0004\uFFFF\u0001=\u0005\uFFFF\u0001t\u0001w\u0001l\u0001=\u0001\uFFFF\u0001c\u0001i\u0001b\u0001t\u0001o\u0001a\u0001p\u0001i\u0001n\u0001i\u0001a\u0001p\u0001r\u0002i\u0001t\u0003\uFFFF\u00020\u0001t\u0002\uFFFF\u0001l\u0001a\u0002e\u0001c\u0001r\u0002s\u0001u\u0001a\u0001e\u0001b\u0002\uFFFF\u0001e\u0001m\u0001o\u0001e\u0001s\u0002a\u0001$\u0001c\u0001o\u0001\uFFFF\u0001=\u0002\uFFFF\u0001l\u0001t\u0001$\u0001\uFFFF\u0001g\u0002\uFFFF\u0001i\u0001$\u0001l\u0002\uFFFF\u0001k\u0001v\u0001t\u0001l\u0001u\u0001r\u0001t\u0001e\u0001t\u0001c\u0001s\u0001o\u0001n\u0001e\u0001$\u0001e\u0001$\u0001d\u0001a\u0001l\u0001h\u0001\uFFFF\u00010\u0001r\u0001e\u0001k\u0002$\u0001h\u0001$\u0001s\u0001t\u0001i\u0001g\u0001u\u0001t\u0001l\u0002$\u0001r\u0001n\u0001e\u0001l\u0001t\u0001\uFFFF\u0001t\u0001$\u0002\uFFFF\u0001e\u0001r\u0001a\u0001r\u0001\uFFFF\u0001$\u0001v\u0001\uFFFF\u0001$\u0002a\u0001e\u0001i\u0001r\u0001t\u0001i\u0001r\u0001c\u0001h\u0001$\u0001w\u0001s\u0001$\u0001\uFFFF\u0001o\u0001\uFFFF\u0001$\u0001t\u0001e\u0001$\u0002a\u0001$\u0002\uFFFF\u0001$\u0001\uFFFF\u0002$\u0001n\u0001g\u0001l\u0002e\u0002\uFFFF\u0001t\u0001d\u0003$\u0001i\u0001\uFFFF\u0001m\u0001t\u0001n\u0001f\u0001\uFFFF\u0001e\u0001\uFFFF\u0001g\u0001t\u0002c\u0001n\u0001$\u0001c\u0001$\u0001h\u0001r\u0001\uFFFF\u0001$\u0001i\u0001\uFFFF\u0001f\u0001\uFFFF\u0001i\u0001$\u0001\uFFFF\u0001c\u0001n\u0004\uFFFF\u0001u\u0001e\u0001t\u0003$\u0001s\u0001\uFFFF\u0001y\u0002\uFFFF\u0001o\u0001e\u0001$\u0001c\u0001a\u0001$\u0002e\u0001t\u0002$\u0001\uFFFF\u0001$\u0001\uFFFF\u0001$\u0001o\u0001$\u0001\uFFFF\u0001e\u0001$\u0001l\u0001\uFFFF\u0001t\u0001$\u0001e\u0001r\u0001$\u0003\uFFFF\u0002$\u0002n\u0001\uFFFF\u0001e\u0001c\u0001\uFFFF\u0002$\u0001e\u0004\uFFFF\u0001n\u0001\uFFFF\u0001n\u0001\uFFFF\u0001e\u0001$\u0001\uFFFF\u0002$\u0003\uFFFF\u0001$\u0001t\u0001o\u0001e\u0002\uFFFF\u0001d\u0001i\u0001t\u0001$\u0004\uFFFF\u0001s\u0001f\u0002$\u0001z\u0001$\u0001\uFFFF\u0002$\u0002\uFFFF\u0001e\u0003\uFFFF\u0001d\u0001$\u0001\uFFFF";
    private const string DFA32_maxS = "\u0001　\u0001b\u0003=\u0001y\u0001o\u0002\uFFFF\u0001o\u0001=\u0001\uFFFF\u00019\u0001x\u0001u\u0001o\u0001>\u0001n\u0003\uFFFF\u0001o\u0001|\u0001\uFFFF\u0003=\u0001u\u0001=\u0001u\u0003\uFFFF\u0001e\u0002\uFFFF\u0002y\u0001o\u0001i\u0001=\u0003\uFFFF\u0001x\u0002\uFFFF\u0001s\u0006\uFFFF\u0001=\u0001\uFFFF\u0001o\u0001e\u0002t\u0002a\u0001n\u0001l\u0001z\u0003\uFFFF\u0001\uFFFF\u0005\uFFFF\u0001s\u0001u\u0001t\u0001l\u0001n\u0001o\u0001r\u0001n\u0001t\u0001\uFFFF\u0001>\u0001\uFFFF\u0001z\u0001p\u0001z\u0001n\u0004\uFFFF\u0001=\u0005\uFFFF\u0001t\u0001w\u0001l\u0001=\u0001\uFFFF\u0001c\u0001o\u0001b\u0001t\u0001o\u0001a\u0001p\u0001i\u0001n\u0001r\u0001y\u0001p\u0001r\u0001l\u0001i\u0001t\u0003\uFFFF\u00029\u0001t\u0002\uFFFF\u0001l\u0001a\u0002e\u0001c\u0001r\u0001s\u0001t\u0001u\u0001a\u0001e\u0001b\u0002\uFFFF\u0001e\u0001m\u0001o\u0001e\u0001s\u0002a\u0001z\u0001c\u0001o\u0001\uFFFF\u0001=\u0002\uFFFF\u0001o\u0001t\u0001z\u0001\uFFFF\u0001g\u0002\uFFFF\u0001i\u0001z\u0001l\u0002\uFFFF\u0001k\u0001v\u0001t\u0001l\u0001u\u0001r\u0001t\u0001e\u0001t\u0001c\u0001s\u0001o\u0001n\u0001e\u0001z\u0001e\u0001z\u0001d\u0001a\u0001l\u0001h\u0001\uFFFF\u00019\u0001r\u0001e\u0001k\u0002z\u0001h\u0001z\u0001s\u0001t\u0001i\u0001g\u0001u\u0001t\u0001l\u0002z\u0001r\u0001n\u0001e\u0001l\u0001t\u0001\uFFFF\u0001t\u0001z\u0002\uFFFF\u0001e\u0001r\u0001a\u0001r\u0001\uFFFF\u0001z\u0001v\u0001\uFFFF\u0001z\u0002a\u0001e\u0001i\u0001r\u0001t\u0001i\u0001r\u0001c\u0001h\u0001z\u0001w\u0001s\u0001z\u0001\uFFFF\u0001o\u0001\uFFFF\u0001z\u0001t\u0001e\u0001z\u0002a\u0001z\u0002\uFFFF\u0001z\u0001\uFFFF\u0002z\u0001n\u0001g\u0001l\u0002e\u0002\uFFFF\u0001t\u0001d\u0003z\u0001i\u0001\uFFFF\u0001m\u0001t\u0001n\u0001f\u0001\uFFFF\u0001e\u0001\uFFFF\u0001g\u0001t\u0002c\u0001n\u0001z\u0001c\u0001z\u0001h\u0001r\u0001\uFFFF\u0001z\u0001i\u0001\uFFFF\u0001f\u0001\uFFFF\u0001i\u0001z\u0001\uFFFF\u0001c\u0001n\u0004\uFFFF\u0001u\u0001e\u0001t\u0003z\u0001s\u0001\uFFFF\u0001y\u0002\uFFFF\u0001o\u0001e\u0001z\u0001c\u0001a\u0001z\u0002e\u0001t\u0002z\u0001\uFFFF\u0001z\u0001\uFFFF\u0001z\u0001o\u0001z\u0001\uFFFF\u0001e\u0001z\u0001l\u0001\uFFFF\u0001t\u0001z\u0001e\u0001r\u0001z\u0003\uFFFF\u0002z\u0002n\u0001\uFFFF\u0001e\u0001c\u0001\uFFFF\u0002z\u0001e\u0004\uFFFF\u0001n\u0001\uFFFF\u0001n\u0001\uFFFF\u0001e\u0001z\u0001\uFFFF\u0002z\u0003\uFFFF\u0001z\u0001t\u0001o\u0001e\u0002\uFFFF\u0001d\u0001i\u0001t\u0001z\u0004\uFFFF\u0001s\u0001f\u0004z\u0001\uFFFF\u0002z\u0002\uFFFF\u0001e\u0003\uFFFF\u0001d\u0001z\u0001\uFFFF";
    private const string DFA32_acceptS = "\a\uFFFF\u0001\u000E\u0001\u000F\t\uFFFF\u00011\u00013\u00014\u0002\uFFFF\u00017\u0006\uFFFF\u0001J\u0001K\u0001L\u0001\uFFFF\u0001N\u0001P\u0005\uFFFF\u0001l\u0001m\u0001p\u0001\uFFFF\u0001r\u0001t\u0001\uFFFF\u0001\u0003\u0001-\u0001\u0002\u0001\u0005\u00012\u0001\u0004\u0001\uFFFF\u0001\u0006\t\uFFFF\u0001\u0013\u0001Z\u0001Y\u0001\uFFFF\u0001n\u0001o\u0001\u0016\u0001u\u0001\u0019\t\uFFFF\u0001(\u0001\uFFFF\u0001'\u0004\uFFFF\u00016\u0001E\u0001D\u00019\u0001\uFFFF\u00018\u0001;\u0001:\u0001=\u0001<\u0004\uFFFF\u0001A\u0010\uFFFF\u0001k\u0001j\u0001s\u0003\uFFFF\u0001O\u0001\u001D\f\uFFFF\u0001\u0018\u0001\u0017\n\uFFFF\u0001U\u0001\uFFFF\u0001T\u0001)\u0003\uFFFF\u0001,\u0001\uFFFF\u0001R\u0001Q\u0003\uFFFF\u0001B\u0001?\u0015\uFFFF\u0001q\u0016\uFFFF\u0001$\u0002\uFFFF\u0001W\u0001V\u0004\uFFFF\u0001/\u0002\uFFFF\u0001@\u000F\uFFFF\u0001c\u0001\uFFFF\u0001e\a\uFFFF\u0001\t\u0001\n\u0001\uFFFF\u0001\f\a\uFFFF\u0001\u001B\u0001\u001C\u0006\uFFFF\u0001&\u0004\uFFFF\u00015\u0001\uFFFF\u0001C\n\uFFFF\u0001^\u0002\uFFFF\u0001b\u0001\uFFFF\u0001f\u0002\uFFFF\u0001i\u0002\uFFFF\u0001\b\u0001\v\u0001\r\u0001\u0010\a\uFFFF\u0001 \u0001\uFFFF\u0001!\u0001#\v\uFFFF\u0001S\u0001\uFFFF\u0001[\u0003\uFFFF\u0001_\u0003\uFFFF\u0001h\u0005\uFFFF\u0001\u0015\u0001\u001A\u0001\u001E\u0004\uFFFF\u0001+\u0002\uFFFF\u0001>\u0003\uFFFF\u0001I\u0001M\u0001X\u0001\\\u0001\uFFFF\u0001`\u0001\uFFFF\u0001d\u0002\uFFFF\u0001\a\u0002\uFFFF\u0001\u0014\u0001\u001F\u0001\"\u0004\uFFFF\u0001F\u0001G\u0004\uFFFF\u0001\u0001\u0001\u0011\u0001\u0012\u0001%\u0006\uFFFF\u0001g\u0002\uFFFF\u00010\u0001H\u0001\uFFFF\u0001a\u0001*\u0001.\u0002\uFFFF\u0001]";
    private const string DFA32_specialS = "\v\uFFFF\u0001\08\uFFFF\u0001\u0001Ŏ\uFFFF}>";
    private static readonly string[] DFA32_transitionS = new string[403]
    {
      "\u0001)\u0001*\u0002)\u0001*\u0012\uFFFF\u0001)\u0001\u001C\u0001.\u0002\uFFFF\u0001\u0019\u0001\u0003\u0001.\u0001\u0017\u0001\"\u0001\u001A\u0001\u0002\u0001\b\u0001\n\u0001\f\u0001\v\u0001,\t-\u0001\a\u0001#\u0001\u0018\u0001\u0004\u0001\u0010\u0001\u001E\u001B\uFFFF\u0001\u0014\u0001\uFFFF\u0001 \u0001(\u0002\uFFFF\u0001\u0001\u0001\u0005\u0001\u0006\u0001\t\u0001\r\u0001\u000E\u0001\u000F\u0001\uFFFF\u0001\u0011\u0002\uFFFF\u0001\u0015\u0001\uFFFF\u0001\u001B\u0001\uFFFF\u0001\u001D\u0001\uFFFF\u0001!\u0001$\u0001%\u0001\uFFFF\u0001&\u0001'\u0003\uFFFF\u0001\u0013\u0001\u0016\u0001\u001F\u0001\u0012!\uFFFF\u0001)ᗟ\uFFFF\u0001)ƍ\uFFFF\u0001)߱\uFFFF\v)\u001D\uFFFF\u0002*\u0005\uFFFF\u0001)/\uFFFF\u0001)ྠ\uFFFF\u0001)",
      "\u0001/",
      "\u00011\u0011\uFFFF\u00010",
      "\u00014\u0016\uFFFF\u00013",
      "\u00016",
      "\u00018\u0002\uFFFF\u00019\u0006\uFFFF\u0001:",
      "\u0001;\u0006\uFFFF\u0001<\u0003\uFFFF\u0001=\u0002\uFFFF\u0001>",
      "",
      "",
      "\u0001?\t\uFFFF\u0001@",
      "\u0001A\u000F\uFFFF\u0001B",
      "\nH\u0001\uFFFF\u0002H\u0001\uFFFF\u001CH\u0001E\u0004H\u0001F\rH\u0001DῪH\u0002\uFFFF\uDFD6H",
      "\n-",
      "\u0001J\u0001\uFFFF\u0001K\t\uFFFF\u0001L",
      "\u0001M\a\uFFFF\u0001N\u0002\uFFFF\u0001O\u0002\uFFFF\u0001P\u0005\uFFFF\u0001Q",
      "\u0001R",
      "\u0001S\u0001T",
      "\u0001V\u0006\uFFFF\u0001W\u0001X",
      "",
      "",
      "",
      "\u0001Y",
      "\u0001[>\uFFFF\u0001Z",
      "",
      "\u0001^\u0001]",
      "\u0001`",
      "\u0001b",
      "\u0001d\u0003\uFFFF\u0001e\u000F\uFFFF\u0001f",
      "\u0001g",
      "\u0001i\u0010\uFFFF\u0001j\u0002\uFFFF\u0001k",
      "",
      "",
      "",
      "\u0001l",
      "",
      "",
      "\u0001m\v\uFFFF\u0001n\u0001o\u0001\uFFFF\u0001p\u0001\uFFFF\u0001q",
      "\u0001r\t\uFFFF\u0001s\u0006\uFFFF\u0001t",
      "\u0001u\r\uFFFF\u0001v",
      "\u0001w\u0001x",
      "\u0001y",
      "",
      "",
      "",
      "\u0001|\a} \uFFFF\u0001{\u001F\uFFFF\u0001{",
      "",
      "",
      "\u0001~",
      "",
      "",
      "",
      "",
      "",
      "",
      "\u0001\u007F",
      "",
      "\u0001\u0081",
      "\u0001\u0082",
      "\u0001\u0083",
      "\u0001\u0084\u0001\u0085",
      "\u0001\u0086",
      "\u0001\u0087",
      "\u0001\u0088",
      "\u0001\u0089\u0003\uFFFF\u0001\u008A\u0005\uFFFF\u0001\u008B",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u0014+\u0001\u008C\u0005+",
      "",
      "",
      "",
      "\nH\u0001\uFFFF\u0002H\u0001\uFFFF‚H\u0002\uFFFF\uDFD6H",
      "",
      "",
      "",
      "",
      "",
      "\u0001\u008F",
      "\u0001\u0090",
      "\u0001\u0091\u0003\uFFFF\u0001\u0092",
      "\u0001\u0093",
      "\u0001\u0094",
      "\u0001\u0095",
      "\u0001\u0096",
      "\u0001\u0097",
      "\u0001\u0098",
      "",
      "\u0001\u0099\u0001\u009A",
      "",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "\u0001\u009D",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u0012+\u0001\u009E\u0001\u009F\u0006+",
      "\u0001¡",
      "",
      "",
      "",
      "",
      "\u0001¢",
      "",
      "",
      "",
      "",
      "",
      "\u0001¤",
      "\u0001¥",
      "\u0001¦",
      "\u0001§",
      "",
      "\u0001©",
      "\u0001ª\u0005\uFFFF\u0001«",
      "\u0001¬",
      "\u0001\u00AD",
      "\u0001®",
      "\u0001¯",
      "\u0001°",
      "\u0001±",
      "\u0001\u00B2",
      "\u0001\u00B3\b\uFFFF\u0001´",
      "\u0001µ\u0013\uFFFF\u0001¶\u0003\uFFFF\u0001·",
      "\u0001¸",
      "\u0001\u00B9",
      "\u0001º\u0002\uFFFF\u0001»",
      "\u0001\u00BC",
      "\u0001\u00BD",
      "",
      "",
      "",
      "\u0001|\a}\u0002-",
      "\b¿\u0002-",
      "\u0001À",
      "",
      "",
      "\u0001Á",
      "\u0001Â",
      "\u0001Ã",
      "\u0001Ä",
      "\u0001Å",
      "\u0001Æ",
      "\u0001Ç",
      "\u0001È\u0001É",
      "\u0001Ê",
      "\u0001Ë",
      "\u0001Ì",
      "\u0001Í",
      "",
      "",
      "\u0001Î",
      "\u0001Ï",
      "\u0001Ð",
      "\u0001Ñ",
      "\u0001Ò",
      "\u0001Ó",
      "\u0001Ô",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "\u0001Ö",
      "\u0001×",
      "",
      "\u0001Ø",
      "",
      "",
      "\u0001Ú\u0002\uFFFF\u0001Û",
      "\u0001Ü",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u0004+\u0001Ý\u0015+",
      "",
      "\u0001ß",
      "",
      "",
      "\u0001à",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "\u0001â",
      "",
      "",
      "\u0001ã",
      "\u0001ä",
      "\u0001å",
      "\u0001æ",
      "\u0001ç",
      "\u0001è",
      "\u0001é",
      "\u0001ê",
      "\u0001ë",
      "\u0001ì",
      "\u0001í",
      "\u0001î",
      "\u0001ï",
      "\u0001ð",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "\u0001ò",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "\u0001ô",
      "\u0001õ",
      "\u0001ö",
      "\u0001÷",
      "",
      "\b¿\u0002-",
      "\u0001ø",
      "\u0001ù",
      "\u0001ú",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "\u0001ý",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "\u0001ÿ",
      "\u0001Ā",
      "\u0001ā",
      "\u0001Ă",
      "\u0001ă",
      "\u0001Ą",
      "\u0001ą",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "\u0001Ĉ",
      "\u0001ĉ",
      "\u0001Ċ",
      "\u0001ċ",
      "\u0001Č",
      "",
      "\u0001č",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "",
      "",
      "\u0001ď",
      "\u0001Đ",
      "\u0001đ",
      "\u0001Ē",
      "",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "\u0001Ĕ",
      "",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "\u0001Ė",
      "\u0001ė",
      "\u0001Ę",
      "\u0001ę",
      "\u0001Ě",
      "\u0001ě",
      "\u0001Ĝ",
      "\u0001ĝ",
      "\u0001Ğ",
      "\u0001ğ",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "\u0001ġ",
      "\u0001Ģ",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "",
      "\u0001Ĥ",
      "",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "\u0001Ħ",
      "\u0001ħ",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "\u0001ĩ",
      "\u0001Ī",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "",
      "",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "\u0001į",
      "\u0001İ",
      "\u0001ı",
      "\u0001Ĳ",
      "\u0001ĳ",
      "",
      "",
      "\u0001Ĵ",
      "\u0001ĵ",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\v+\u0001ķ\u000E+",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "\u0001ĺ",
      "",
      "\u0001Ļ",
      "\u0001ļ",
      "\u0001Ľ",
      "\u0001ľ",
      "",
      "\u0001Ŀ",
      "",
      "\u0001ŀ",
      "\u0001Ł",
      "\u0001ł",
      "\u0001Ń",
      "\u0001ń",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "\u0001ņ",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "\u0001ň",
      "\u0001ŉ",
      "",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u0012+\u0001Ŋ\a+",
      "\u0001Ō",
      "",
      "\u0001ō",
      "",
      "\u0001Ŏ",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "",
      "\u0001Ő",
      "\u0001ő",
      "",
      "",
      "",
      "",
      "\u0001Œ",
      "\u0001œ",
      "\u0001Ŕ",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "\u0001Ř",
      "",
      "\u0001ř",
      "",
      "",
      "\u0001Ś",
      "\u0001ś",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "\u0001ŝ",
      "\u0001Ş",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "\u0001Š",
      "\u0001š",
      "\u0001Ţ",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "\u0001ŧ",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "",
      "\u0001ũ",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "\u0001ū",
      "",
      "\u0001Ŭ",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "\u0001Ů",
      "\u0001ů",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "",
      "",
      "",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "\u0001ų",
      "\u0001Ŵ",
      "",
      "\u0001ŵ",
      "\u0001Ŷ",
      "",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "\u0001Ź",
      "",
      "",
      "",
      "",
      "\u0001ź",
      "",
      "\u0001Ż",
      "",
      "\u0001ż",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "",
      "",
      "",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "\u0001Ɓ",
      "\u0001Ƃ",
      "\u0001ƃ",
      "",
      "",
      "\u0001Ƅ",
      "\u0001ƅ",
      "\u0001Ɔ",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "",
      "",
      "",
      "",
      "\u0001ƈ",
      "\u0001Ɖ",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "\u0001ƌ",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      "",
      "",
      "\u0001Ɛ",
      "",
      "",
      "",
      "\u0001Ƒ",
      "\u0001+\v\uFFFF\n+\a\uFFFF\u001A+\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001\uFFFF\u001A+",
      ""
    };
    private static readonly short[] DFA32_eot = DFA.UnpackEncodedString("\u0002+\u00012\u00015\u00017\u0002+\u0002\uFFFF\u0001+\u0001C\u0001G\u0001I\u0003+\u0001U\u0001+\u0003\uFFFF\u0001+\u0001\\\u0001\uFFFF\u0001_\u0001a\u0001c\u0001+\u0001h\u0001+\u0003\uFFFF\u0001+\u0002\uFFFF\u0004+\u0001z\u0003\uFFFF\u0001-\u0002\uFFFF\u0001+\u0006\uFFFF\u0001\u0080\u0001\uFFFF\b+\u0001\u008D\u0003\uFFFF\u0001\u008E\u0005\uFFFF\t+\u0001\uFFFF\u0001\u009B\u0001\uFFFF\u0001\u009C\u0001+\u0001 \u0001+\u0004\uFFFF\u0001£\u0005\uFFFF\u0003+\u0001¨\u0001\uFFFF\u0010+\u0003\uFFFF\u0002\u00BE\u0001+\u0002\uFFFF\f+\u0002\uFFFF\a+\u0001Õ\u0002+\u0001\uFFFF\u0001Ù\u0002\uFFFF\u0002+\u0001Þ\u0001\uFFFF\u0001+\u0002\uFFFF\u0001+\u0001á\u0001+\u0002\uFFFF\u000E+\u0001ñ\u0001+\u0001ó\u0004+\u0001\uFFFF\u0001\u00BE\u0003+\u0001û\u0001ü\u0001+\u0001þ\a+\u0001Ć\u0001ć\u0005+\u0001\uFFFF\u0001+\u0001Ď\u0002\uFFFF\u0004+\u0001\uFFFF\u0001ē\u0001+\u0001\uFFFF\u0001ĕ\n+\u0001Ġ\u0002+\u0001ģ\u0001\uFFFF\u0001+\u0001\uFFFF\u0001ĥ\u0002+\u0001Ĩ\u0002+\u0001ī\u0002\uFFFF\u0001Ĭ\u0001\uFFFF\u0001ĭ\u0001Į\u0005+\u0002\uFFFF\u0002+\u0001Ķ\u0001ĸ\u0001Ĺ\u0001+\u0001\uFFFF\u0004+\u0001\uFFFF\u0001+\u0001\uFFFF\u0005+\u0001Ņ\u0001+\u0001Ň\u0002+\u0001\uFFFF\u0001ŋ\u0001+\u0001\uFFFF\u0001+\u0001\uFFFF\u0001+\u0001ŏ\u0001\uFFFF\u0002+\u0004\uFFFF\u0003+\u0001ŕ\u0001Ŗ\u0001ŗ\u0001+\u0001\uFFFF\u0001+\u0002\uFFFF\u0002+\u0001Ŝ\u0002+\u0001ş\u0003+\u0001ţ\u0001Ť\u0001\uFFFF\u0001ť\u0001\uFFFF\u0001Ŧ\u0001+\u0001Ũ\u0001\uFFFF\u0001+\u0001Ū\u0001+\u0001\uFFFF\u0001+\u0001ŭ\u0002+\u0001Ű\u0003\uFFFF\u0001ű\u0001Ų\u0002+\u0001\uFFFF\u0002+\u0001\uFFFF\u0001ŷ\u0001Ÿ\u0001+\u0004\uFFFF\u0001+\u0001\uFFFF\u0001+\u0001\uFFFF\u0001+\u0001Ž\u0001\uFFFF\u0001ž\u0001ſ\u0003\uFFFF\u0001ƀ\u0003+\u0002\uFFFF\u0003+\u0001Ƈ\u0004\uFFFF\u0002+\u0001Ɗ\u0001Ƌ\u0001+\u0001ƍ\u0001\uFFFF\u0001Ǝ\u0001Ə\u0002\uFFFF\u0001+\u0003\uFFFF\u0001+\u0001ƒ\u0001\uFFFF");
    private static readonly short[] DFA32_eof = DFA.UnpackEncodedString("Ɠ\uFFFF");
    private static readonly char[] DFA32_min = DFA.UnpackEncodedStringToUnsignedChars("\u0001\t\u0001b\u0001+\u0001&\u0001=\u0001o\u0001a\u0002\uFFFF\u0001e\u0001-\u0001\0\u00010\u0001l\u0001a\u0001o\u0001=\u0001f\u0003\uFFFF\u0001o\u0001=\u0001\uFFFF\u0001<\u0002=\u0001a\u0001=\u0001a\u0003\uFFFF\u0001e\u0002\uFFFF\u0002h\u0001a\u0001h\u0001=\u0003\uFFFF\u00010\u0002\uFFFF\u0001s\u0006\uFFFF\u0001=\u0001\uFFFF\u0001o\u0001e\u0001t\u0001s\u0002a\u0001n\u0001b\u0001$\u0003\uFFFF\u0001\0\u0005\uFFFF\u0001s\u0001u\u0001p\u0001l\u0001n\u0001o\u0001r\u0001n\u0001t\u0001\uFFFF\u0001=\u0001\uFFFF\u0001$\u0001p\u0001$\u0001n\u0004\uFFFF\u0001=\u0005\uFFFF\u0001t\u0001w\u0001l\u0001=\u0001\uFFFF\u0001c\u0001i\u0001b\u0001t\u0001o\u0001a\u0001p\u0001i\u0001n\u0001i\u0001a\u0001p\u0001r\u0002i\u0001t\u0003\uFFFF\u00020\u0001t\u0002\uFFFF\u0001l\u0001a\u0002e\u0001c\u0001r\u0002s\u0001u\u0001a\u0001e\u0001b\u0002\uFFFF\u0001e\u0001m\u0001o\u0001e\u0001s\u0002a\u0001$\u0001c\u0001o\u0001\uFFFF\u0001=\u0002\uFFFF\u0001l\u0001t\u0001$\u0001\uFFFF\u0001g\u0002\uFFFF\u0001i\u0001$\u0001l\u0002\uFFFF\u0001k\u0001v\u0001t\u0001l\u0001u\u0001r\u0001t\u0001e\u0001t\u0001c\u0001s\u0001o\u0001n\u0001e\u0001$\u0001e\u0001$\u0001d\u0001a\u0001l\u0001h\u0001\uFFFF\u00010\u0001r\u0001e\u0001k\u0002$\u0001h\u0001$\u0001s\u0001t\u0001i\u0001g\u0001u\u0001t\u0001l\u0002$\u0001r\u0001n\u0001e\u0001l\u0001t\u0001\uFFFF\u0001t\u0001$\u0002\uFFFF\u0001e\u0001r\u0001a\u0001r\u0001\uFFFF\u0001$\u0001v\u0001\uFFFF\u0001$\u0002a\u0001e\u0001i\u0001r\u0001t\u0001i\u0001r\u0001c\u0001h\u0001$\u0001w\u0001s\u0001$\u0001\uFFFF\u0001o\u0001\uFFFF\u0001$\u0001t\u0001e\u0001$\u0002a\u0001$\u0002\uFFFF\u0001$\u0001\uFFFF\u0002$\u0001n\u0001g\u0001l\u0002e\u0002\uFFFF\u0001t\u0001d\u0003$\u0001i\u0001\uFFFF\u0001m\u0001t\u0001n\u0001f\u0001\uFFFF\u0001e\u0001\uFFFF\u0001g\u0001t\u0002c\u0001n\u0001$\u0001c\u0001$\u0001h\u0001r\u0001\uFFFF\u0001$\u0001i\u0001\uFFFF\u0001f\u0001\uFFFF\u0001i\u0001$\u0001\uFFFF\u0001c\u0001n\u0004\uFFFF\u0001u\u0001e\u0001t\u0003$\u0001s\u0001\uFFFF\u0001y\u0002\uFFFF\u0001o\u0001e\u0001$\u0001c\u0001a\u0001$\u0002e\u0001t\u0002$\u0001\uFFFF\u0001$\u0001\uFFFF\u0001$\u0001o\u0001$\u0001\uFFFF\u0001e\u0001$\u0001l\u0001\uFFFF\u0001t\u0001$\u0001e\u0001r\u0001$\u0003\uFFFF\u0002$\u0002n\u0001\uFFFF\u0001e\u0001c\u0001\uFFFF\u0002$\u0001e\u0004\uFFFF\u0001n\u0001\uFFFF\u0001n\u0001\uFFFF\u0001e\u0001$\u0001\uFFFF\u0002$\u0003\uFFFF\u0001$\u0001t\u0001o\u0001e\u0002\uFFFF\u0001d\u0001i\u0001t\u0001$\u0004\uFFFF\u0001s\u0001f\u0002$\u0001z\u0001$\u0001\uFFFF\u0002$\u0002\uFFFF\u0001e\u0003\uFFFF\u0001d\u0001$\u0001\uFFFF");
    private static readonly char[] DFA32_max = DFA.UnpackEncodedStringToUnsignedChars("\u0001　\u0001b\u0003=\u0001y\u0001o\u0002\uFFFF\u0001o\u0001=\u0001\uFFFF\u00019\u0001x\u0001u\u0001o\u0001>\u0001n\u0003\uFFFF\u0001o\u0001|\u0001\uFFFF\u0003=\u0001u\u0001=\u0001u\u0003\uFFFF\u0001e\u0002\uFFFF\u0002y\u0001o\u0001i\u0001=\u0003\uFFFF\u0001x\u0002\uFFFF\u0001s\u0006\uFFFF\u0001=\u0001\uFFFF\u0001o\u0001e\u0002t\u0002a\u0001n\u0001l\u0001z\u0003\uFFFF\u0001\uFFFF\u0005\uFFFF\u0001s\u0001u\u0001t\u0001l\u0001n\u0001o\u0001r\u0001n\u0001t\u0001\uFFFF\u0001>\u0001\uFFFF\u0001z\u0001p\u0001z\u0001n\u0004\uFFFF\u0001=\u0005\uFFFF\u0001t\u0001w\u0001l\u0001=\u0001\uFFFF\u0001c\u0001o\u0001b\u0001t\u0001o\u0001a\u0001p\u0001i\u0001n\u0001r\u0001y\u0001p\u0001r\u0001l\u0001i\u0001t\u0003\uFFFF\u00029\u0001t\u0002\uFFFF\u0001l\u0001a\u0002e\u0001c\u0001r\u0001s\u0001t\u0001u\u0001a\u0001e\u0001b\u0002\uFFFF\u0001e\u0001m\u0001o\u0001e\u0001s\u0002a\u0001z\u0001c\u0001o\u0001\uFFFF\u0001=\u0002\uFFFF\u0001o\u0001t\u0001z\u0001\uFFFF\u0001g\u0002\uFFFF\u0001i\u0001z\u0001l\u0002\uFFFF\u0001k\u0001v\u0001t\u0001l\u0001u\u0001r\u0001t\u0001e\u0001t\u0001c\u0001s\u0001o\u0001n\u0001e\u0001z\u0001e\u0001z\u0001d\u0001a\u0001l\u0001h\u0001\uFFFF\u00019\u0001r\u0001e\u0001k\u0002z\u0001h\u0001z\u0001s\u0001t\u0001i\u0001g\u0001u\u0001t\u0001l\u0002z\u0001r\u0001n\u0001e\u0001l\u0001t\u0001\uFFFF\u0001t\u0001z\u0002\uFFFF\u0001e\u0001r\u0001a\u0001r\u0001\uFFFF\u0001z\u0001v\u0001\uFFFF\u0001z\u0002a\u0001e\u0001i\u0001r\u0001t\u0001i\u0001r\u0001c\u0001h\u0001z\u0001w\u0001s\u0001z\u0001\uFFFF\u0001o\u0001\uFFFF\u0001z\u0001t\u0001e\u0001z\u0002a\u0001z\u0002\uFFFF\u0001z\u0001\uFFFF\u0002z\u0001n\u0001g\u0001l\u0002e\u0002\uFFFF\u0001t\u0001d\u0003z\u0001i\u0001\uFFFF\u0001m\u0001t\u0001n\u0001f\u0001\uFFFF\u0001e\u0001\uFFFF\u0001g\u0001t\u0002c\u0001n\u0001z\u0001c\u0001z\u0001h\u0001r\u0001\uFFFF\u0001z\u0001i\u0001\uFFFF\u0001f\u0001\uFFFF\u0001i\u0001z\u0001\uFFFF\u0001c\u0001n\u0004\uFFFF\u0001u\u0001e\u0001t\u0003z\u0001s\u0001\uFFFF\u0001y\u0002\uFFFF\u0001o\u0001e\u0001z\u0001c\u0001a\u0001z\u0002e\u0001t\u0002z\u0001\uFFFF\u0001z\u0001\uFFFF\u0001z\u0001o\u0001z\u0001\uFFFF\u0001e\u0001z\u0001l\u0001\uFFFF\u0001t\u0001z\u0001e\u0001r\u0001z\u0003\uFFFF\u0002z\u0002n\u0001\uFFFF\u0001e\u0001c\u0001\uFFFF\u0002z\u0001e\u0004\uFFFF\u0001n\u0001\uFFFF\u0001n\u0001\uFFFF\u0001e\u0001z\u0001\uFFFF\u0002z\u0003\uFFFF\u0001z\u0001t\u0001o\u0001e\u0002\uFFFF\u0001d\u0001i\u0001t\u0001z\u0004\uFFFF\u0001s\u0001f\u0004z\u0001\uFFFF\u0002z\u0002\uFFFF\u0001e\u0003\uFFFF\u0001d\u0001z\u0001\uFFFF");
    private static readonly short[] DFA32_accept = DFA.UnpackEncodedString("\a\uFFFF\u0001\u000E\u0001\u000F\t\uFFFF\u00011\u00013\u00014\u0002\uFFFF\u00017\u0006\uFFFF\u0001J\u0001K\u0001L\u0001\uFFFF\u0001N\u0001P\u0005\uFFFF\u0001l\u0001m\u0001p\u0001\uFFFF\u0001r\u0001t\u0001\uFFFF\u0001\u0003\u0001-\u0001\u0002\u0001\u0005\u00012\u0001\u0004\u0001\uFFFF\u0001\u0006\t\uFFFF\u0001\u0013\u0001Z\u0001Y\u0001\uFFFF\u0001n\u0001o\u0001\u0016\u0001u\u0001\u0019\t\uFFFF\u0001(\u0001\uFFFF\u0001'\u0004\uFFFF\u00016\u0001E\u0001D\u00019\u0001\uFFFF\u00018\u0001;\u0001:\u0001=\u0001<\u0004\uFFFF\u0001A\u0010\uFFFF\u0001k\u0001j\u0001s\u0003\uFFFF\u0001O\u0001\u001D\f\uFFFF\u0001\u0018\u0001\u0017\n\uFFFF\u0001U\u0001\uFFFF\u0001T\u0001)\u0003\uFFFF\u0001,\u0001\uFFFF\u0001R\u0001Q\u0003\uFFFF\u0001B\u0001?\u0015\uFFFF\u0001q\u0016\uFFFF\u0001$\u0002\uFFFF\u0001W\u0001V\u0004\uFFFF\u0001/\u0002\uFFFF\u0001@\u000F\uFFFF\u0001c\u0001\uFFFF\u0001e\a\uFFFF\u0001\t\u0001\n\u0001\uFFFF\u0001\f\a\uFFFF\u0001\u001B\u0001\u001C\u0006\uFFFF\u0001&\u0004\uFFFF\u00015\u0001\uFFFF\u0001C\n\uFFFF\u0001^\u0002\uFFFF\u0001b\u0001\uFFFF\u0001f\u0002\uFFFF\u0001i\u0002\uFFFF\u0001\b\u0001\v\u0001\r\u0001\u0010\a\uFFFF\u0001 \u0001\uFFFF\u0001!\u0001#\v\uFFFF\u0001S\u0001\uFFFF\u0001[\u0003\uFFFF\u0001_\u0003\uFFFF\u0001h\u0005\uFFFF\u0001\u0015\u0001\u001A\u0001\u001E\u0004\uFFFF\u0001+\u0002\uFFFF\u0001>\u0003\uFFFF\u0001I\u0001M\u0001X\u0001\\\u0001\uFFFF\u0001`\u0001\uFFFF\u0001d\u0002\uFFFF\u0001\a\u0002\uFFFF\u0001\u0014\u0001\u001F\u0001\"\u0004\uFFFF\u0001F\u0001G\u0004\uFFFF\u0001\u0001\u0001\u0011\u0001\u0012\u0001%\u0006\uFFFF\u0001g\u0002\uFFFF\u00010\u0001H\u0001\uFFFF\u0001a\u0001*\u0001.\u0002\uFFFF\u0001]");
    private static readonly short[] DFA32_special = DFA.UnpackEncodedString("\v\uFFFF\u0001\08\uFFFF\u0001\u0001Ŏ\uFFFF}>");
    private static readonly short[][] DFA32_transition;

    static DFA32()
    {
      int length = ES3Lexer.DFA32.DFA32_transitionS.Length;
      ES3Lexer.DFA32.DFA32_transition = new short[length][];
      for (int index = 0; index < length; ++index)
        ES3Lexer.DFA32.DFA32_transition[index] = DFA.UnpackEncodedString(ES3Lexer.DFA32.DFA32_transitionS[index]);
    }

    public DFA32(
      BaseRecognizer recognizer,
      SpecialStateTransitionHandler specialStateTransition)
      : base(specialStateTransition)
    {
      this.recognizer = recognizer;
      this.decisionNumber = 32 /*0x20*/;
      this.eot = ES3Lexer.DFA32.DFA32_eot;
      this.eof = ES3Lexer.DFA32.DFA32_eof;
      this.min = ES3Lexer.DFA32.DFA32_min;
      this.max = ES3Lexer.DFA32.DFA32_max;
      this.accept = ES3Lexer.DFA32.DFA32_accept;
      this.special = ES3Lexer.DFA32.DFA32_special;
      this.transition = ES3Lexer.DFA32.DFA32_transition;
    }

    public virtual string Description
    {
      get
      {
        return "1:1: Tokens : ( ABSTRACT | ADD | ADDASS | AND | ANDASS | ASSIGN | BOOLEAN | BREAK | BYTE | CASE | CATCH | CHAR | CLASS | COLON | COMMA | CONST | CONTINUE | DEBUGGER | DEC | DEFAULT | DELETE | DIV | DIVASS | DO | DOT | DOUBLE | ELSE | ENUM | EQ | EXPORT | EXTENDS | FALSE | FINAL | FINALLY | FLOAT | FOR | FUNCTION | GOTO | GT | GTE | IF | IMPLEMENTS | IMPORT | IN | INC | INSTANCEOF | INT | INTERFACE | INV | LAND | LBRACE | LBRACK | LONG | LOR | LPAREN | LT | LTE | MOD | MODASS | MUL | MULASS | NATIVE | NEQ | NEW | NOT | NSAME | NULL | OR | ORASS | PACKAGE | PRIVATE | PROTECTED | PUBLIC | QUE | RBRACE | RBRACK | RETURN | RPAREN | SAME | SEMIC | SHL | SHLASS | SHORT | SHR | SHRASS | SHU | SHUASS | STATIC | SUB | SUBASS | SUPER | SWITCH | SYNCHRONIZED | THIS | THROW | THROWS | TRANSIENT | TRUE | TRY | TYPEOF | VAR | VOID | VOLATILE | WHILE | WITH | XOR | XORASS | WhiteSpace | EOL | MultiLineComment | SingleLineComment | Identifier | OctalIntegerLiteral | DecimalLiteral | HexIntegerLiteral | StringLiteral | RegularExpressionLiteral );";
      }
    }

    public virtual void Error(NoViableAltException nvae)
    {
    }
  }
}
