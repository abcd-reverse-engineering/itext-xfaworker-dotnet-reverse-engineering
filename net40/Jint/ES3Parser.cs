// Decompiled with JetBrains decompiler
// Type: ES3Parser
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using Antlr.Runtime;
using Antlr.Runtime.Tree;
using Jint.Debugger;
using Jint.Expressions;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

#nullable disable
[GeneratedCode("ANTLR", "3.3.1.7705")]
[CLSCompliant(false)]
public class ES3Parser : Parser
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
  private const char BS = '\\';
  internal static readonly string[] tokenNames = new string[171]
  {
    "<invalid>",
    "<EOR>",
    "<DOWN>",
    "<UP>",
    nameof (ABSTRACT),
    nameof (ADD),
    nameof (ADDASS),
    nameof (AND),
    nameof (ANDASS),
    nameof (ARGS),
    nameof (ARRAY),
    nameof (ASSIGN),
    nameof (BLOCK),
    nameof (BOOLEAN),
    nameof (BREAK),
    nameof (BSLASH),
    nameof (BYFIELD),
    nameof (BYINDEX),
    nameof (BYTE),
    nameof (BackslashSequence),
    nameof (CALL),
    nameof (CASE),
    nameof (CATCH),
    nameof (CEXPR),
    nameof (CHAR),
    nameof (CLASS),
    nameof (COLON),
    nameof (COMMA),
    nameof (CONST),
    nameof (CONTINUE),
    nameof (CR),
    nameof (CharacterEscapeSequence),
    nameof (DEBUGGER),
    nameof (DEC),
    nameof (DEFAULT),
    nameof (DELETE),
    nameof (DIV),
    nameof (DIVASS),
    nameof (DO),
    nameof (DOT),
    nameof (DOUBLE),
    nameof (DQUOTE),
    nameof (DecimalDigit),
    nameof (DecimalIntegerLiteral),
    nameof (DecimalLiteral),
    nameof (ELSE),
    nameof (ENUM),
    nameof (EOL),
    nameof (EQ),
    nameof (EXPORT),
    nameof (EXPR),
    nameof (EXTENDS),
    nameof (EscapeSequence),
    nameof (ExponentPart),
    nameof (FALSE),
    nameof (FF),
    nameof (FINAL),
    nameof (FINALLY),
    nameof (FLOAT),
    nameof (FOR),
    nameof (FORITER),
    nameof (FORSTEP),
    nameof (FUNCTION),
    nameof (GOTO),
    nameof (GT),
    nameof (GTE),
    nameof (HexDigit),
    nameof (HexEscapeSequence),
    nameof (HexIntegerLiteral),
    nameof (IF),
    nameof (IMPLEMENTS),
    nameof (IMPORT),
    nameof (IN),
    nameof (INC),
    nameof (INSTANCEOF),
    nameof (INT),
    nameof (INTERFACE),
    nameof (INV),
    nameof (ITEM),
    nameof (Identifier),
    nameof (IdentifierNameASCIIStart),
    nameof (IdentifierPart),
    nameof (IdentifierStartASCII),
    nameof (LABELLED),
    nameof (LAND),
    nameof (LBRACE),
    nameof (LBRACK),
    nameof (LF),
    nameof (LONG),
    nameof (LOR),
    nameof (LPAREN),
    nameof (LS),
    nameof (LT),
    nameof (LTE),
    nameof (LineTerminator),
    nameof (MOD),
    nameof (MODASS),
    nameof (MUL),
    nameof (MULASS),
    nameof (MultiLineComment),
    nameof (NAMEDVALUE),
    nameof (NATIVE),
    nameof (NBSP),
    nameof (NEG),
    nameof (NEQ),
    nameof (NEW),
    nameof (NOT),
    nameof (NSAME),
    nameof (NULL),
    nameof (OBJECT),
    nameof (OR),
    nameof (ORASS),
    nameof (OctalDigit),
    nameof (OctalEscapeSequence),
    nameof (OctalIntegerLiteral),
    nameof (PACKAGE),
    nameof (PAREXPR),
    nameof (PDEC),
    nameof (PINC),
    nameof (POS),
    nameof (PRIVATE),
    nameof (PROTECTED),
    nameof (PS),
    nameof (PUBLIC),
    nameof (QUE),
    nameof (RBRACE),
    nameof (RBRACK),
    nameof (RETURN),
    nameof (RPAREN),
    nameof (RegularExpressionChar),
    nameof (RegularExpressionFirstChar),
    nameof (RegularExpressionLiteral),
    nameof (SAME),
    nameof (SEMIC),
    nameof (SHL),
    nameof (SHLASS),
    nameof (SHORT),
    nameof (SHR),
    nameof (SHRASS),
    nameof (SHU),
    nameof (SHUASS),
    nameof (SP),
    nameof (SQUOTE),
    nameof (STATIC),
    nameof (SUB),
    nameof (SUBASS),
    nameof (SUPER),
    nameof (SWITCH),
    nameof (SYNCHRONIZED),
    nameof (SingleLineComment),
    nameof (StringLiteral),
    nameof (TAB),
    nameof (THIS),
    nameof (THROW),
    nameof (THROWS),
    nameof (TRANSIENT),
    nameof (TRUE),
    nameof (TRY),
    nameof (TYPEOF),
    nameof (USP),
    nameof (UnicodeEscapeSequence),
    nameof (VAR),
    nameof (VOID),
    nameof (VOLATILE),
    nameof (VT),
    nameof (WHILE),
    nameof (WITH),
    nameof (WhiteSpace),
    nameof (XOR),
    nameof (XORASS),
    nameof (ZeroToThree)
  };
  private ITreeAdaptor adaptor;
  private LinkedList<Statement> _currentBody;
  private bool _newExpressionIsUnary;
  private static NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
  private static Encoding Latin1 = Encoding.GetEncoding("iso-8859-1");
  private string[] script = new string[0];
  private ES3Parser.DFA58 dfa58;
  private ES3Parser.DFA59 dfa59;
  private ES3Parser.DFA89 dfa89;

  public ES3Parser(ITokenStream input)
    : this(input, new RecognizerSharedState())
  {
  }

  public ES3Parser(ITokenStream input, RecognizerSharedState state)
    : base(input, state)
  {
    this.TreeAdaptor = (ITreeAdaptor) ((object) (ITreeAdaptor) null ?? (object) new CommonTreeAdaptor());
  }

  public ITreeAdaptor TreeAdaptor
  {
    get => this.adaptor;
    set => this.adaptor = value;
  }

  public virtual string[] TokenNames => ES3Parser.tokenNames;

  public virtual string GrammarFileName => "ES3.g";

  private bool IsLeftHandSideAssign(Expression lhs, object[] cached)
  {
    if (cached[0] != null)
      return Convert.ToBoolean(cached[0]);
    bool flag;
    if (ES3Parser.IsLeftHandSideExpression(lhs))
    {
      switch (((IIntStream) this.input).LA(1))
      {
        case 6:
        case 8:
        case 11:
        case 37:
        case 96 /*0x60*/:
        case 98:
        case 111:
        case 135:
        case 138:
        case 140:
        case 145:
        case 169:
          flag = true;
          break;
        default:
          flag = false;
          break;
      }
    }
    else
      flag = false;
    cached[0] = (object) flag;
    return flag;
  }

  private static bool IsLeftHandSideExpression(Expression lhs)
  {
    switch (lhs)
    {
      case null:
        return true;
      case Jint.Expressions.Identifier _:
      case PropertyExpression _:
        return true;
      default:
        return lhs is MemberExpression;
    }
  }

  private bool IsLeftHandSideIn(Expression lhs, object[] cached)
  {
    if (cached[0] != null)
      return Convert.ToBoolean(cached[0]);
    bool flag = ES3Parser.IsLeftHandSideExpression(lhs) && ((IIntStream) this.input).LA(1) == 72;
    cached[0] = (object) flag;
    return flag;
  }

  private void PromoteEOL(ParserRuleReturnScope<IToken> rule)
  {
    IToken itoken1 = this.input.LT(1);
    switch (itoken1.Type)
    {
      case -1:
        break;
      case 47:
        break;
      case 99:
        break;
      case 125:
        break;
      case 133:
        break;
      default:
        for (int index = itoken1.TokenIndex - 1; index > 0; --index)
        {
          IToken itoken2 = this.input.Get(index);
          if (itoken2.Channel == 0)
            break;
          if (itoken2.Type == 47 || itoken2.Type == 99 && (itoken2.Text.EndsWith("\r") || itoken2.Text.EndsWith("\n")))
          {
            itoken2.Channel = 0;
            ((IIntStream) this.input).Seek(itoken2.TokenIndex);
            if (rule == null)
              break;
            rule.Start = itoken2;
            break;
          }
        }
        break;
    }
  }

  private string extractRegExpPattern(string text) => text.Substring(1, text.LastIndexOf('/') - 1);

  private string extractRegExpOption(string text)
  {
    return text[text.Length - 1] != '/' ? text.Substring(text.LastIndexOf('/') + 1) : string.Empty;
  }

  private string extractString(string text)
  {
    StringBuilder stringBuilder = new StringBuilder(text.Length);
    int startIndex = 1;
    int num;
    for (; (num = text.IndexOf('\\', startIndex)) != -1; startIndex = num)
    {
      stringBuilder.Append(text.Substring(startIndex, num - startIndex));
      char ch1 = text[num + 1];
      switch (ch1)
      {
        case '\n':
          num += 2;
          break;
        case '\r':
          if (text[num + 2] == '\n')
          {
            num += 3;
            break;
          }
          break;
        case '"':
          stringBuilder.Append('"');
          num += 2;
          break;
        case '\'':
          stringBuilder.Append('\'');
          num += 2;
          break;
        case '0':
        case '1':
        case '2':
        case '3':
        case '4':
        case '5':
        case '6':
        case '7':
        case '8':
        case '9':
          string str1 = text.Substring(num + 1, 3);
          char ch2 = ES3Parser.Latin1.GetChars(new byte[1]
          {
            Convert.ToByte(str1, 8)
          })[0];
          stringBuilder.Append(ch2);
          num += 4;
          break;
        case '\\':
          stringBuilder.Append('\\');
          num += 2;
          break;
        case 'b':
          stringBuilder.Append('\b');
          num += 2;
          break;
        case 'f':
          stringBuilder.Append('\f');
          num += 2;
          break;
        case 'n':
          stringBuilder.Append('\n');
          num += 2;
          break;
        case 'r':
          stringBuilder.Append('\r');
          num += 2;
          break;
        case 't':
          stringBuilder.Append('\t');
          num += 2;
          break;
        case 'u':
          char ch3 = Convert.ToChar(int.Parse(text.Substring(num + 2, 4), NumberStyles.AllowHexSpecifier));
          stringBuilder.Append(ch3);
          num += 6;
          break;
        case 'v':
          stringBuilder.Append('\v');
          num += 2;
          break;
        case 'x':
          string str2 = text.Substring(num + 2, 2);
          char ch4 = ES3Parser.Latin1.GetChars(new byte[1]
          {
            Convert.ToByte(str2, 16 /*0x10*/)
          })[0];
          stringBuilder.Append(ch4);
          num += 4;
          break;
        default:
          stringBuilder.Append(ch1);
          num += 2;
          break;
      }
    }
    if (stringBuilder.Length == 0)
      return text.Substring(1, text.Length - 2);
    stringBuilder.Append(text.Substring(startIndex, text.Length - startIndex - 1));
    return stringBuilder.ToString();
  }

  public List<string> Errors { get; private set; }

  public virtual void DisplayRecognitionError(string[] tokenNames, RecognitionException e)
  {
    ((BaseRecognizer) this).DisplayRecognitionError(tokenNames, e);
    if (this.Errors == null)
      this.Errors = new List<string>();
    string errorHeader = ((BaseRecognizer) this).GetErrorHeader(e);
    this.Errors.Add($"{((BaseRecognizer) this).GetErrorMessage(e, tokenNames)} at {errorHeader}");
  }

  public bool DebugMode { get; set; }

  private SourceCodeDescriptor ExtractSourceCode(CommonToken start, CommonToken stop)
  {
    if (!this.DebugMode)
      return new SourceCodeDescriptor(start.Line, start.CharPositionInLine, stop.Line, stop.CharPositionInLine, "No source code available.");
    try
    {
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = start.Line - 1; index <= stop.Line - 1; ++index)
      {
        int startIndex = 0;
        int num = this.script[index].Length;
        if (index == start.Line - 1)
          startIndex = start.CharPositionInLine;
        if (index == stop.Line - 1)
          num = stop.CharPositionInLine;
        int length = num - startIndex;
        stringBuilder.Append(this.script[index].Substring(startIndex, length)).Append(Environment.NewLine);
      }
      return new SourceCodeDescriptor(start.Line, start.CharPositionInLine, stop.Line, stop.CharPositionInLine, stringBuilder.ToString());
    }
    catch
    {
      return new SourceCodeDescriptor(start.Line, start.CharPositionInLine, stop.Line, stop.CharPositionInLine, "No source code available.");
    }
  }

  public AssignmentOperator ResolveAssignmentOperator(string op)
  {
    switch (op)
    {
      case "=":
        return AssignmentOperator.Assign;
      case "+=":
        return AssignmentOperator.Add;
      case "-=":
        return AssignmentOperator.Substract;
      case "*=":
        return AssignmentOperator.Multiply;
      case "%=":
        return AssignmentOperator.Modulo;
      case "<<=":
        return AssignmentOperator.ShiftLeft;
      case ">>=":
        return AssignmentOperator.ShiftRight;
      case ">>>=":
        return AssignmentOperator.UnsignedRightShift;
      case "&=":
        return AssignmentOperator.And;
      case "|=":
        return AssignmentOperator.Or;
      case "^=":
        return AssignmentOperator.XOr;
      case "/=":
        return AssignmentOperator.Divide;
      default:
        throw new NotSupportedException("Invalid assignment operator: " + op);
    }
  }

  [GrammarRule("token")]
  private ES3Parser.token_return token()
  {
    ES3Parser.token_return tokenReturn = new ES3Parser.token_return(this);
    tokenReturn.Start = this.input.LT(1);
    object obj1 = (object) null;
    try
    {
      int num;
      switch (((IIntStream) this.input).LA(1))
      {
        case 4:
        case 13:
        case 14:
        case 18:
        case 21:
        case 22:
        case 24:
        case 25:
        case 28:
        case 29:
        case 32 /*0x20*/:
        case 34:
        case 35:
        case 38:
        case 40:
        case 45:
        case 46:
        case 49:
        case 51:
        case 54:
        case 56:
        case 57:
        case 58:
        case 59:
        case 62:
        case 63 /*0x3F*/:
        case 69:
        case 70:
        case 71:
        case 72:
        case 74:
        case 75:
        case 76:
        case 88:
        case 101:
        case 105:
        case 108:
        case 115:
        case 120:
        case 121:
        case 123:
        case (int) sbyte.MaxValue:
        case 136:
        case 143:
        case 146:
        case 147:
        case 148:
        case 152:
        case 153:
        case 154:
        case 155:
        case 156:
        case 157:
        case 158:
        case 161:
        case 162:
        case 163:
        case 165:
        case 166:
          num = 1;
          break;
        case 5:
        case 6:
        case 7:
        case 8:
        case 11:
        case 26:
        case 27:
        case 33:
        case 36:
        case 37:
        case 39:
        case 48 /*0x30*/:
        case 64 /*0x40*/:
        case 65:
        case 73:
        case 77:
        case 84:
        case 85:
        case 86:
        case 89:
        case 90:
        case 92:
        case 93:
        case 95:
        case 96 /*0x60*/:
        case 97:
        case 98:
        case 104:
        case 106:
        case 107:
        case 110:
        case 111:
        case 124:
        case 125:
        case 126:
        case 128 /*0x80*/:
        case 132:
        case 133:
        case 134:
        case 135:
        case 137:
        case 138:
        case 139:
        case 140:
        case 144 /*0x90*/:
        case 145:
        case 168:
        case 169:
          num = 3;
          break;
        case 44:
        case 68:
        case 114:
          num = 4;
          break;
        case 79:
          num = 2;
          break;
        case 150:
          num = 5;
          break;
        default:
          throw new NoViableAltException("", 1, 0, (IIntStream) this.input);
      }
      switch (num)
      {
        case 1:
          obj1 = this.adaptor.Nil();
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._reservedWord_in_token1748);
          ES3Parser.reservedWord_return reservedWordReturn = this.reservedWord();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj1, reservedWordReturn.Tree);
          break;
        case 2:
          obj1 = this.adaptor.Nil();
          object obj2 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 79, ES3Parser.Follow._Identifier_in_token1753));
          this.adaptor.AddChild(obj1, obj2);
          break;
        case 3:
          obj1 = this.adaptor.Nil();
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._punctuator_in_token1758);
          ES3Parser.punctuator_return punctuatorReturn = this.punctuator();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj1, punctuatorReturn.Tree);
          break;
        case 4:
          obj1 = this.adaptor.Nil();
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._numericLiteral_in_token1763);
          ES3Parser.numericLiteral_return numericLiteralReturn = this.numericLiteral();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj1, numericLiteralReturn.Tree);
          break;
        case 5:
          obj1 = this.adaptor.Nil();
          object obj3 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 150, ES3Parser.Follow._StringLiteral_in_token1768));
          this.adaptor.AddChild(obj1, obj3);
          break;
      }
      tokenReturn.Stop = this.input.LT(-1);
      tokenReturn.Tree = this.adaptor.RulePostProcessing(obj1);
      this.adaptor.SetTokenBoundaries(tokenReturn.Tree, tokenReturn.Start, tokenReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      tokenReturn.Tree = this.adaptor.ErrorNode(this.input, tokenReturn.Start, this.input.LT(-1), ex);
    }
    return tokenReturn;
  }

  [GrammarRule("reservedWord")]
  private ES3Parser.reservedWord_return reservedWord()
  {
    ES3Parser.reservedWord_return reservedWordReturn1 = new ES3Parser.reservedWord_return(this);
    reservedWordReturn1.Start = this.input.LT(1);
    object obj1 = (object) null;
    try
    {
      int num;
      switch (((IIntStream) this.input).LA(1))
      {
        case 4:
        case 13:
        case 18:
        case 24:
        case 25:
        case 28:
        case 32 /*0x20*/:
        case 40:
        case 46:
        case 49:
        case 51:
        case 56:
        case 58:
        case 63 /*0x3F*/:
        case 70:
        case 71:
        case 75:
        case 76:
        case 88:
        case 101:
        case 115:
        case 120:
        case 121:
        case 123:
        case 136:
        case 143:
        case 146:
        case 148:
        case 154:
        case 155:
        case 163:
          num = 2;
          break;
        case 14:
        case 21:
        case 22:
        case 29:
        case 34:
        case 35:
        case 38:
        case 45:
        case 57:
        case 59:
        case 62:
        case 69:
        case 72:
        case 74:
        case 105:
        case (int) sbyte.MaxValue:
        case 147:
        case 152:
        case 153:
        case 157:
        case 158:
        case 161:
        case 162:
        case 165:
        case 166:
          num = 1;
          break;
        case 54:
        case 156:
          num = 4;
          break;
        case 108:
          num = 3;
          break;
        default:
          throw new NoViableAltException("", 2, 0, (IIntStream) this.input);
      }
      switch (num)
      {
        case 1:
          obj1 = this.adaptor.Nil();
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._keyword_in_reservedWord1781);
          ES3Parser.keyword_return keywordReturn = this.keyword();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj1, keywordReturn.Tree);
          break;
        case 2:
          obj1 = this.adaptor.Nil();
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._futureReservedWord_in_reservedWord1786);
          ES3Parser.futureReservedWord_return reservedWordReturn2 = this.futureReservedWord();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj1, reservedWordReturn2.Tree);
          break;
        case 3:
          obj1 = this.adaptor.Nil();
          object obj2 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 108, ES3Parser.Follow._NULL_in_reservedWord1791));
          this.adaptor.AddChild(obj1, obj2);
          break;
        case 4:
          obj1 = this.adaptor.Nil();
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._booleanLiteral_in_reservedWord1796);
          ES3Parser.booleanLiteral_return booleanLiteralReturn = this.booleanLiteral();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj1, booleanLiteralReturn.Tree);
          break;
      }
      reservedWordReturn1.Stop = this.input.LT(-1);
      reservedWordReturn1.Tree = this.adaptor.RulePostProcessing(obj1);
      this.adaptor.SetTokenBoundaries(reservedWordReturn1.Tree, reservedWordReturn1.Start, reservedWordReturn1.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      reservedWordReturn1.Tree = this.adaptor.ErrorNode(this.input, reservedWordReturn1.Start, this.input.LT(-1), ex);
    }
    return reservedWordReturn1;
  }

  [GrammarRule("keyword")]
  private ES3Parser.keyword_return keyword()
  {
    ES3Parser.keyword_return keywordReturn = new ES3Parser.keyword_return(this);
    keywordReturn.Start = this.input.LT(1);
    try
    {
      object obj = this.adaptor.Nil();
      IToken itoken = this.input.LT(1);
      if (((IIntStream) this.input).LA(1) != 14 && (((IIntStream) this.input).LA(1) < 21 || ((IIntStream) this.input).LA(1) > 22) && ((IIntStream) this.input).LA(1) != 29 && (((IIntStream) this.input).LA(1) < 34 || ((IIntStream) this.input).LA(1) > 35) && ((IIntStream) this.input).LA(1) != 38 && ((IIntStream) this.input).LA(1) != 45 && ((IIntStream) this.input).LA(1) != 57 && ((IIntStream) this.input).LA(1) != 59 && ((IIntStream) this.input).LA(1) != 62 && ((IIntStream) this.input).LA(1) != 69 && ((IIntStream) this.input).LA(1) != 72 && ((IIntStream) this.input).LA(1) != 74 && ((IIntStream) this.input).LA(1) != 105 && ((IIntStream) this.input).LA(1) != (int) sbyte.MaxValue && ((IIntStream) this.input).LA(1) != 147 && (((IIntStream) this.input).LA(1) < 152 || ((IIntStream) this.input).LA(1) > 153) && (((IIntStream) this.input).LA(1) < 157 || ((IIntStream) this.input).LA(1) > 158) && (((IIntStream) this.input).LA(1) < 161 || ((IIntStream) this.input).LA(1) > 162) && (((IIntStream) this.input).LA(1) < 165 || ((IIntStream) this.input).LA(1) > 166))
        throw new MismatchedSetException((BitSet) null, (IIntStream) this.input);
      ((IIntStream) this.input).Consume();
      this.adaptor.AddChild(obj, this.adaptor.Create(itoken));
      ((BaseRecognizer) this).state.errorRecovery = false;
      keywordReturn.Stop = this.input.LT(-1);
      keywordReturn.Tree = this.adaptor.RulePostProcessing(obj);
      this.adaptor.SetTokenBoundaries(keywordReturn.Tree, keywordReturn.Start, keywordReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      keywordReturn.Tree = this.adaptor.ErrorNode(this.input, keywordReturn.Start, this.input.LT(-1), ex);
    }
    return keywordReturn;
  }

  [GrammarRule("futureReservedWord")]
  private ES3Parser.futureReservedWord_return futureReservedWord()
  {
    ES3Parser.futureReservedWord_return reservedWordReturn = new ES3Parser.futureReservedWord_return(this);
    reservedWordReturn.Start = this.input.LT(1);
    try
    {
      object obj = this.adaptor.Nil();
      IToken itoken = this.input.LT(1);
      if (((IIntStream) this.input).LA(1) != 4 && ((IIntStream) this.input).LA(1) != 13 && ((IIntStream) this.input).LA(1) != 18 && (((IIntStream) this.input).LA(1) < 24 || ((IIntStream) this.input).LA(1) > 25) && ((IIntStream) this.input).LA(1) != 28 && ((IIntStream) this.input).LA(1) != 32 /*0x20*/ && ((IIntStream) this.input).LA(1) != 40 && ((IIntStream) this.input).LA(1) != 46 && ((IIntStream) this.input).LA(1) != 49 && ((IIntStream) this.input).LA(1) != 51 && ((IIntStream) this.input).LA(1) != 56 && ((IIntStream) this.input).LA(1) != 58 && ((IIntStream) this.input).LA(1) != 63 /*0x3F*/ && (((IIntStream) this.input).LA(1) < 70 || ((IIntStream) this.input).LA(1) > 71) && (((IIntStream) this.input).LA(1) < 75 || ((IIntStream) this.input).LA(1) > 76) && ((IIntStream) this.input).LA(1) != 88 && ((IIntStream) this.input).LA(1) != 101 && ((IIntStream) this.input).LA(1) != 115 && (((IIntStream) this.input).LA(1) < 120 || ((IIntStream) this.input).LA(1) > 121) && ((IIntStream) this.input).LA(1) != 123 && ((IIntStream) this.input).LA(1) != 136 && ((IIntStream) this.input).LA(1) != 143 && ((IIntStream) this.input).LA(1) != 146 && ((IIntStream) this.input).LA(1) != 148 && (((IIntStream) this.input).LA(1) < 154 || ((IIntStream) this.input).LA(1) > 155) && ((IIntStream) this.input).LA(1) != 163)
        throw new MismatchedSetException((BitSet) null, (IIntStream) this.input);
      ((IIntStream) this.input).Consume();
      this.adaptor.AddChild(obj, this.adaptor.Create(itoken));
      ((BaseRecognizer) this).state.errorRecovery = false;
      reservedWordReturn.Stop = this.input.LT(-1);
      reservedWordReturn.Tree = this.adaptor.RulePostProcessing(obj);
      this.adaptor.SetTokenBoundaries(reservedWordReturn.Tree, reservedWordReturn.Start, reservedWordReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      reservedWordReturn.Tree = this.adaptor.ErrorNode(this.input, reservedWordReturn.Start, this.input.LT(-1), ex);
    }
    return reservedWordReturn;
  }

  [GrammarRule("punctuator")]
  private ES3Parser.punctuator_return punctuator()
  {
    ES3Parser.punctuator_return punctuatorReturn = new ES3Parser.punctuator_return(this);
    punctuatorReturn.Start = this.input.LT(1);
    try
    {
      object obj = this.adaptor.Nil();
      IToken itoken = this.input.LT(1);
      if ((((IIntStream) this.input).LA(1) < 5 || ((IIntStream) this.input).LA(1) > 8) && ((IIntStream) this.input).LA(1) != 11 && (((IIntStream) this.input).LA(1) < 26 || ((IIntStream) this.input).LA(1) > 27) && ((IIntStream) this.input).LA(1) != 33 && (((IIntStream) this.input).LA(1) < 36 || ((IIntStream) this.input).LA(1) > 37) && ((IIntStream) this.input).LA(1) != 39 && ((IIntStream) this.input).LA(1) != 48 /*0x30*/ && (((IIntStream) this.input).LA(1) < 64 /*0x40*/ || ((IIntStream) this.input).LA(1) > 65) && ((IIntStream) this.input).LA(1) != 73 && ((IIntStream) this.input).LA(1) != 77 && (((IIntStream) this.input).LA(1) < 84 || ((IIntStream) this.input).LA(1) > 86) && (((IIntStream) this.input).LA(1) < 89 || ((IIntStream) this.input).LA(1) > 90) && (((IIntStream) this.input).LA(1) < 92 || ((IIntStream) this.input).LA(1) > 93) && (((IIntStream) this.input).LA(1) < 95 || ((IIntStream) this.input).LA(1) > 98) && ((IIntStream) this.input).LA(1) != 104 && (((IIntStream) this.input).LA(1) < 106 || ((IIntStream) this.input).LA(1) > 107) && (((IIntStream) this.input).LA(1) < 110 || ((IIntStream) this.input).LA(1) > 111) && (((IIntStream) this.input).LA(1) < 124 || ((IIntStream) this.input).LA(1) > 126) && ((IIntStream) this.input).LA(1) != 128 /*0x80*/ && (((IIntStream) this.input).LA(1) < 132 || ((IIntStream) this.input).LA(1) > 135) && (((IIntStream) this.input).LA(1) < 137 || ((IIntStream) this.input).LA(1) > 140) && (((IIntStream) this.input).LA(1) < 144 /*0x90*/ || ((IIntStream) this.input).LA(1) > 145) && (((IIntStream) this.input).LA(1) < 168 || ((IIntStream) this.input).LA(1) > 169))
        throw new MismatchedSetException((BitSet) null, (IIntStream) this.input);
      ((IIntStream) this.input).Consume();
      this.adaptor.AddChild(obj, this.adaptor.Create(itoken));
      ((BaseRecognizer) this).state.errorRecovery = false;
      punctuatorReturn.Stop = this.input.LT(-1);
      punctuatorReturn.Tree = this.adaptor.RulePostProcessing(obj);
      this.adaptor.SetTokenBoundaries(punctuatorReturn.Tree, punctuatorReturn.Start, punctuatorReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      punctuatorReturn.Tree = this.adaptor.ErrorNode(this.input, punctuatorReturn.Start, this.input.LT(-1), ex);
    }
    return punctuatorReturn;
  }

  [GrammarRule("literal")]
  private ES3Parser.literal_return literal()
  {
    ES3Parser.literal_return literalReturn = new ES3Parser.literal_return(this);
    literalReturn.Start = this.input.LT(1);
    object obj1 = (object) null;
    try
    {
      int num;
      switch (((IIntStream) this.input).LA(1))
      {
        case 44:
        case 68:
        case 114:
          num = 3;
          break;
        case 54:
        case 156:
          num = 2;
          break;
        case 108:
          num = 1;
          break;
        case 131:
          num = 5;
          break;
        case 150:
          num = 4;
          break;
        default:
          throw new NoViableAltException("", 3, 0, (IIntStream) this.input);
      }
      switch (num)
      {
        case 1:
          obj1 = this.adaptor.Nil();
          IToken itoken1 = (IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 108, ES3Parser.Follow._NULL_in_literal2483);
          object obj2 = this.adaptor.Create(itoken1);
          this.adaptor.AddChild(obj1, obj2);
          literalReturn.value = (Expression) new Jint.Expressions.Identifier(itoken1.Text);
          break;
        case 2:
          obj1 = this.adaptor.Nil();
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._booleanLiteral_in_literal2492);
          ES3Parser.booleanLiteral_return booleanLiteralReturn = this.booleanLiteral();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj1, booleanLiteralReturn.Tree);
          literalReturn.value = (Expression) new ValueExpression((object) booleanLiteralReturn.value, TypeCode.Boolean);
          break;
        case 3:
          obj1 = this.adaptor.Nil();
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._numericLiteral_in_literal2501);
          ES3Parser.numericLiteral_return numericLiteralReturn = this.numericLiteral();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj1, numericLiteralReturn.Tree);
          literalReturn.value = (Expression) new ValueExpression((object) numericLiteralReturn.value, TypeCode.Double);
          break;
        case 4:
          obj1 = this.adaptor.Nil();
          IToken itoken2 = (IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 150, ES3Parser.Follow._StringLiteral_in_literal2510);
          object obj3 = this.adaptor.Create(itoken2);
          this.adaptor.AddChild(obj1, obj3);
          literalReturn.value = (Expression) new ValueExpression((object) this.extractString(itoken2.Text), TypeCode.String);
          break;
        case 5:
          obj1 = this.adaptor.Nil();
          IToken itoken3 = (IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 131, ES3Parser.Follow._RegularExpressionLiteral_in_literal2520);
          object obj4 = this.adaptor.Create(itoken3);
          this.adaptor.AddChild(obj1, obj4);
          literalReturn.value = (Expression) new RegexpExpression(this.extractRegExpPattern(itoken3.Text), this.extractRegExpOption(itoken3.Text));
          break;
      }
      literalReturn.Stop = this.input.LT(-1);
      literalReturn.Tree = this.adaptor.RulePostProcessing(obj1);
      this.adaptor.SetTokenBoundaries(literalReturn.Tree, literalReturn.Start, literalReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      literalReturn.Tree = this.adaptor.ErrorNode(this.input, literalReturn.Start, this.input.LT(-1), ex);
    }
    return literalReturn;
  }

  [GrammarRule("booleanLiteral")]
  private ES3Parser.booleanLiteral_return booleanLiteral()
  {
    ES3Parser.booleanLiteral_return booleanLiteralReturn = new ES3Parser.booleanLiteral_return(this);
    booleanLiteralReturn.Start = this.input.LT(1);
    object obj1 = (object) null;
    try
    {
      int num;
      switch (((IIntStream) this.input).LA(1))
      {
        case 54:
          num = 2;
          break;
        case 156:
          num = 1;
          break;
        default:
          throw new NoViableAltException("", 4, 0, (IIntStream) this.input);
      }
      switch (num)
      {
        case 1:
          obj1 = this.adaptor.Nil();
          object obj2 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 156, ES3Parser.Follow._TRUE_in_booleanLiteral2537));
          this.adaptor.AddChild(obj1, obj2);
          booleanLiteralReturn.value = true;
          break;
        case 2:
          obj1 = this.adaptor.Nil();
          object obj3 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 54, ES3Parser.Follow._FALSE_in_booleanLiteral2544));
          this.adaptor.AddChild(obj1, obj3);
          booleanLiteralReturn.value = false;
          break;
      }
      booleanLiteralReturn.Stop = this.input.LT(-1);
      booleanLiteralReturn.Tree = this.adaptor.RulePostProcessing(obj1);
      this.adaptor.SetTokenBoundaries(booleanLiteralReturn.Tree, booleanLiteralReturn.Start, booleanLiteralReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      booleanLiteralReturn.Tree = this.adaptor.ErrorNode(this.input, booleanLiteralReturn.Start, this.input.LT(-1), ex);
    }
    return booleanLiteralReturn;
  }

  [GrammarRule("numericLiteral")]
  private ES3Parser.numericLiteral_return numericLiteral()
  {
    ES3Parser.numericLiteral_return numericLiteralReturn = new ES3Parser.numericLiteral_return(this);
    numericLiteralReturn.Start = this.input.LT(1);
    object obj1 = (object) null;
    try
    {
      int num;
      switch (((IIntStream) this.input).LA(1))
      {
        case 44:
          num = 2;
          break;
        case 68:
          num = 3;
          break;
        case 114:
          num = 1;
          break;
        default:
          throw new NoViableAltException("", 5, 0, (IIntStream) this.input);
      }
      switch (num)
      {
        case 1:
          obj1 = this.adaptor.Nil();
          IToken itoken1 = (IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 114, ES3Parser.Follow._OctalIntegerLiteral_in_numericLiteral2763);
          object obj2 = this.adaptor.Create(itoken1);
          this.adaptor.AddChild(obj1, obj2);
          numericLiteralReturn.value = (double) Convert.ToInt64(itoken1.Text, 8);
          break;
        case 2:
          obj1 = this.adaptor.Nil();
          IToken itoken2 = (IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 44, ES3Parser.Follow._DecimalLiteral_in_numericLiteral2772);
          object obj3 = this.adaptor.Create(itoken2);
          this.adaptor.AddChild(obj1, obj3);
          numericLiteralReturn.value = double.Parse(itoken2.Text, NumberStyles.Float, (IFormatProvider) ES3Parser.numberFormatInfo);
          break;
        case 3:
          obj1 = this.adaptor.Nil();
          IToken itoken3 = (IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 68, ES3Parser.Follow._HexIntegerLiteral_in_numericLiteral2781);
          object obj4 = this.adaptor.Create(itoken3);
          this.adaptor.AddChild(obj1, obj4);
          numericLiteralReturn.value = (double) Convert.ToInt64(itoken3.Text, 16 /*0x10*/);
          break;
      }
      numericLiteralReturn.Stop = this.input.LT(-1);
      numericLiteralReturn.Tree = this.adaptor.RulePostProcessing(obj1);
      this.adaptor.SetTokenBoundaries(numericLiteralReturn.Tree, numericLiteralReturn.Start, numericLiteralReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      numericLiteralReturn.Tree = this.adaptor.ErrorNode(this.input, numericLiteralReturn.Start, this.input.LT(-1), ex);
    }
    return numericLiteralReturn;
  }

  [GrammarRule("primaryExpression")]
  private ES3Parser.primaryExpression_return primaryExpression()
  {
    ES3Parser.primaryExpression_return expressionReturn1 = new ES3Parser.primaryExpression_return(this);
    expressionReturn1.Start = this.input.LT(1);
    object obj1 = (object) null;
    try
    {
      int num;
      switch (((IIntStream) this.input).LA(1))
      {
        case 44:
        case 54:
        case 68:
        case 108:
        case 114:
        case 131:
        case 150:
        case 156:
          num = 3;
          break;
        case 79:
          num = 2;
          break;
        case 85:
          num = 5;
          break;
        case 86:
          num = 4;
          break;
        case 90:
          num = 6;
          break;
        case 152:
          num = 1;
          break;
        default:
          throw new NoViableAltException("", 6, 0, (IIntStream) this.input);
      }
      switch (num)
      {
        case 1:
          obj1 = this.adaptor.Nil();
          IToken itoken1 = (IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 152, ES3Parser.Follow._THIS_in_primaryExpression3183);
          object obj2 = this.adaptor.Create(itoken1);
          this.adaptor.AddChild(obj1, obj2);
          expressionReturn1.value = (Expression) new Jint.Expressions.Identifier(itoken1.Text);
          break;
        case 2:
          obj1 = this.adaptor.Nil();
          IToken itoken2 = (IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 79, ES3Parser.Follow._Identifier_in_primaryExpression3192);
          object obj3 = this.adaptor.Create(itoken2);
          this.adaptor.AddChild(obj1, obj3);
          expressionReturn1.value = (Expression) new Jint.Expressions.Identifier(itoken2.Text);
          break;
        case 3:
          obj1 = this.adaptor.Nil();
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._literal_in_primaryExpression3201);
          ES3Parser.literal_return literalReturn = this.literal();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj1, literalReturn.Tree);
          expressionReturn1.value = literalReturn.value;
          break;
        case 4:
          obj1 = this.adaptor.Nil();
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._arrayLiteral_in_primaryExpression3210);
          ES3Parser.arrayLiteral_return arrayLiteralReturn = this.arrayLiteral();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj1, arrayLiteralReturn.Tree);
          expressionReturn1.value = (Expression) arrayLiteralReturn.value;
          break;
        case 5:
          obj1 = this.adaptor.Nil();
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._objectLiteral_in_primaryExpression3219);
          ES3Parser.objectLiteral_return objectLiteralReturn = this.objectLiteral();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj1, objectLiteralReturn.Tree);
          expressionReturn1.value = (Expression) objectLiteralReturn.value;
          break;
        case 6:
          obj1 = this.adaptor.Nil();
          object obj4 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 90, ES3Parser.Follow._LPAREN_in_primaryExpression3228));
          this.adaptor.AddChild(obj1, obj4);
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._expression_in_primaryExpression3232);
          ES3Parser.expression_return expressionReturn2 = this.expression();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj1, expressionReturn2.Tree);
          object obj5 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 128 /*0x80*/, ES3Parser.Follow._RPAREN_in_primaryExpression3235));
          this.adaptor.AddChild(obj1, obj5);
          expressionReturn1.value = expressionReturn2.value;
          this._newExpressionIsUnary = expressionReturn2.value is NewExpression;
          break;
      }
      expressionReturn1.Stop = this.input.LT(-1);
      expressionReturn1.Tree = this.adaptor.RulePostProcessing(obj1);
      this.adaptor.SetTokenBoundaries(expressionReturn1.Tree, expressionReturn1.Start, expressionReturn1.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      expressionReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionReturn1.Start, this.input.LT(-1), ex);
    }
    return expressionReturn1;
  }

  [GrammarRule("arrayLiteral")]
  private ES3Parser.arrayLiteral_return arrayLiteral()
  {
    ES3Parser.arrayLiteral_return arrayLiteralReturn = new ES3Parser.arrayLiteral_return(this);
    arrayLiteralReturn.Start = this.input.LT(1);
    arrayLiteralReturn.value = new ArrayDeclaration();
    try
    {
      object obj1 = this.adaptor.Nil();
      object obj2 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 86, ES3Parser.Follow._LBRACK_in_arrayLiteral3261));
      this.adaptor.AddChild(obj1, obj2);
      int num1 = 2;
      int num2 = ((IIntStream) this.input).LA(1);
      if (num2 == 5 || num2 == 27 || num2 == 33 || num2 == 35 || num2 == 44 || num2 == 54 || num2 == 62 || num2 == 68 || num2 == 73 || num2 == 77 || num2 == 79 || num2 >= 85 && num2 <= 86 || num2 == 90 || num2 >= 105 && num2 <= 106 || num2 == 108 || num2 == 114 || num2 == 131 || num2 == 144 /*0x90*/ || num2 == 150 || num2 == 152 || num2 == 156 || num2 == 158 || num2 == 162)
        num1 = 1;
      else if (num2 == 126)
      {
        ((IIntStream) this.input).LA(2);
        if (((IIntStream) this.input).LA(1) == 27 || ((IIntStream) this.input).LA(1) == 126)
          num1 = 1;
      }
      if (num1 == 1)
      {
        ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._arrayItem_in_arrayLiteral3267);
        ES3Parser.arrayItem_return arrayItemReturn1 = this.arrayItem();
        ((BaseRecognizer) this).PopFollow();
        this.adaptor.AddChild(obj1, arrayItemReturn1.Tree);
        if (arrayItemReturn1.value != null)
          arrayLiteralReturn.value.Parameters.Add(arrayItemReturn1.value);
        while (true)
        {
          ES3Parser.arrayItem_return arrayItemReturn2;
          do
          {
            int num3 = 2;
            if (((IIntStream) this.input).LA(1) == 27)
              num3 = 1;
            if (num3 == 1)
            {
              object obj3 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 27, ES3Parser.Follow._COMMA_in_arrayLiteral3273));
              this.adaptor.AddChild(obj1, obj3);
              ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._arrayItem_in_arrayLiteral3277);
              arrayItemReturn2 = this.arrayItem();
              ((BaseRecognizer) this).PopFollow();
              this.adaptor.AddChild(obj1, arrayItemReturn2.Tree);
            }
            else
              goto label_14;
          }
          while (arrayItemReturn2.value == null);
          arrayLiteralReturn.value.Parameters.Add(arrayItemReturn2.value);
        }
      }
label_14:
      object obj4 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 126, ES3Parser.Follow._RBRACK_in_arrayLiteral3287));
      this.adaptor.AddChild(obj1, obj4);
      arrayLiteralReturn.Stop = this.input.LT(-1);
      arrayLiteralReturn.Tree = this.adaptor.RulePostProcessing(obj1);
      this.adaptor.SetTokenBoundaries(arrayLiteralReturn.Tree, arrayLiteralReturn.Start, arrayLiteralReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      arrayLiteralReturn.Tree = this.adaptor.ErrorNode(this.input, arrayLiteralReturn.Start, this.input.LT(-1), ex);
    }
    return arrayLiteralReturn;
  }

  [GrammarRule("arrayItem")]
  private ES3Parser.arrayItem_return arrayItem()
  {
    ES3Parser.arrayItem_return arrayItemReturn = new ES3Parser.arrayItem_return(this);
    arrayItemReturn.Start = this.input.LT(1);
    try
    {
      object obj = this.adaptor.Nil();
      int num1 = ((IIntStream) this.input).LA(1);
      int num2;
      if (num1 <= 79)
      {
        if (num1 <= 44)
        {
          if (num1 <= 27)
          {
            if (num1 != 5)
            {
              if (num1 == 27)
              {
                ((IIntStream) this.input).LA(2);
                if (((IIntStream) this.input).LA(1) == 27)
                {
                  num2 = 2;
                  goto label_36;
                }
                if (((IIntStream) this.input).LA(1) != 126)
                  throw new NoViableAltException("", 9, 2, (IIntStream) this.input);
                num2 = 3;
                goto label_36;
              }
              goto label_35;
            }
          }
          else
          {
            switch (num1 - 33)
            {
              case 0:
              case 2:
                break;
              case 1:
                goto label_35;
              default:
                if (num1 == 44)
                  break;
                goto label_35;
            }
          }
        }
        else if (num1 <= 62)
        {
          if (num1 != 54 && num1 != 62)
            goto label_35;
        }
        else if (num1 != 68 && num1 != 73)
        {
          switch (num1)
          {
            case 77:
            case 79:
              break;
            default:
              goto label_35;
          }
        }
      }
      else if (num1 <= 126)
      {
        if (num1 <= 90)
        {
          switch (num1 - 85)
          {
            case 0:
            case 1:
              break;
            default:
              if (num1 == 90)
                break;
              goto label_35;
          }
        }
        else
        {
          switch (num1 - 105)
          {
            case 0:
            case 1:
            case 3:
              break;
            case 2:
              goto label_35;
            default:
              if (num1 != 114)
              {
                if (num1 == 126)
                {
                  ((IIntStream) this.input).LA(2);
                  if (((IIntStream) this.input).LA(1) == 27)
                  {
                    num2 = 2;
                    goto label_36;
                  }
                  if (((IIntStream) this.input).LA(1) != 126)
                    throw new NoViableAltException("", 9, 3, (IIntStream) this.input);
                  num2 = 3;
                  goto label_36;
                }
                goto label_35;
              }
              break;
          }
        }
      }
      else if (num1 <= 144 /*0x90*/)
      {
        if (num1 != 131 && num1 != 144 /*0x90*/)
          goto label_35;
      }
      else
      {
        switch (num1 - 150)
        {
          case 0:
          case 2:
            break;
          case 1:
            goto label_35;
          default:
            switch (num1 - 156)
            {
              case 0:
              case 2:
                break;
              case 1:
                goto label_35;
              default:
                if (num1 != 162)
                  goto label_35;
                break;
            }
            break;
        }
      }
      num2 = 1;
      goto label_36;
label_35:
      throw new NoViableAltException("", 9, 0, (IIntStream) this.input);
label_36:
      switch (num2)
      {
        case 1:
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._assignmentExpression_in_arrayItem3308);
          ES3Parser.assignmentExpression_return expressionReturn = this.assignmentExpression();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj, expressionReturn.Tree);
          arrayItemReturn.value = (Statement) expressionReturn.value;
          break;
        case 2:
          if (((IIntStream) this.input).LA(1) != 27)
            throw new FailedPredicateException((IIntStream) this.input, nameof (arrayItem), " input.LA(1) == COMMA ");
          arrayItemReturn.value = (Statement) new Jint.Expressions.Identifier("undefined");
          break;
        case 3:
          if (((IIntStream) this.input).LA(1) != 126)
            throw new FailedPredicateException((IIntStream) this.input, nameof (arrayItem), " input.LA(1) == RBRACK ");
          arrayItemReturn.value = (Statement) null;
          break;
      }
      arrayItemReturn.Stop = this.input.LT(-1);
      arrayItemReturn.Tree = this.adaptor.RulePostProcessing(obj);
      this.adaptor.SetTokenBoundaries(arrayItemReturn.Tree, arrayItemReturn.Start, arrayItemReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      arrayItemReturn.Tree = this.adaptor.ErrorNode(this.input, arrayItemReturn.Start, this.input.LT(-1), ex);
    }
    return arrayItemReturn;
  }

  [GrammarRule("objectLiteral")]
  private ES3Parser.objectLiteral_return objectLiteral()
  {
    ES3Parser.objectLiteral_return objectLiteralReturn = new ES3Parser.objectLiteral_return(this);
    objectLiteralReturn.Start = this.input.LT(1);
    objectLiteralReturn.value = new JsonExpression();
    try
    {
      object obj1 = this.adaptor.Nil();
      object obj2 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 85, ES3Parser.Follow._LBRACE_in_objectLiteral3349));
      this.adaptor.AddChild(obj1, obj2);
      int num1 = 2;
      switch (((IIntStream) this.input).LA(1))
      {
        case 44:
        case 68:
        case 79:
        case 114:
        case 150:
          num1 = 1;
          break;
      }
      if (num1 == 1)
      {
        ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._propertyAssignment_in_objectLiteral3355);
        ES3Parser.propertyAssignment_return assignmentReturn1 = this.propertyAssignment();
        ((BaseRecognizer) this).PopFollow();
        this.adaptor.AddChild(obj1, assignmentReturn1.Tree);
        objectLiteralReturn.value.Push(assignmentReturn1.value);
        while (true)
        {
          int num2 = 2;
          if (((IIntStream) this.input).LA(1) == 27)
          {
            switch (((IIntStream) this.input).LA(2))
            {
              case 44:
              case 68:
              case 79:
              case 114:
              case 150:
                num2 = 1;
                break;
            }
          }
          if (num2 == 1)
          {
            object obj3 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 27, ES3Parser.Follow._COMMA_in_objectLiteral3362));
            this.adaptor.AddChild(obj1, obj3);
            ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._propertyAssignment_in_objectLiteral3366);
            ES3Parser.propertyAssignment_return assignmentReturn2 = this.propertyAssignment();
            ((BaseRecognizer) this).PopFollow();
            this.adaptor.AddChild(obj1, assignmentReturn2.Tree);
            objectLiteralReturn.value.Push(assignmentReturn2.value);
          }
          else
            break;
        }
        int num3 = 2;
        if (((IIntStream) this.input).LA(1) == 27)
          num3 = 1;
        if (num3 == 1)
        {
          object obj4 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 27, ES3Parser.Follow._COMMA_in_objectLiteral3374));
          this.adaptor.AddChild(obj1, obj4);
        }
      }
      object obj5 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 125, ES3Parser.Follow._RBRACE_in_objectLiteral3381));
      this.adaptor.AddChild(obj1, obj5);
      objectLiteralReturn.Stop = this.input.LT(-1);
      objectLiteralReturn.Tree = this.adaptor.RulePostProcessing(obj1);
      this.adaptor.SetTokenBoundaries(objectLiteralReturn.Tree, objectLiteralReturn.Start, objectLiteralReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      objectLiteralReturn.Tree = this.adaptor.ErrorNode(this.input, objectLiteralReturn.Start, this.input.LT(-1), ex);
    }
    return objectLiteralReturn;
  }

  [GrammarRule("propertyAssignment")]
  private ES3Parser.propertyAssignment_return propertyAssignment()
  {
    ES3Parser.propertyAssignment_return assignmentReturn = new ES3Parser.propertyAssignment_return(this);
    assignmentReturn.Start = this.input.LT(1);
    object obj1 = (object) null;
    assignmentReturn.value = new PropertyDeclarationExpression();
    FunctionExpression functionExpression = new FunctionExpression();
    try
    {
      int num1;
      switch (((IIntStream) this.input).LA(1))
      {
        case 44:
        case 68:
        case 114:
        case 150:
          num1 = 2;
          break;
        case 79:
          switch (((IIntStream) this.input).LA(2))
          {
            case 26:
              num1 = 2;
              break;
            case 44:
            case 68:
            case 79:
            case 114:
            case 150:
              num1 = 1;
              break;
            default:
              throw new NoViableAltException("", 14, 1, (IIntStream) this.input);
          }
          break;
        default:
          throw new NoViableAltException("", 14, 0, (IIntStream) this.input);
      }
      switch (num1)
      {
        case 1:
          obj1 = this.adaptor.Nil();
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._accessor_in_propertyAssignment3404);
          ES3Parser.accessor_return accessorReturn = this.accessor();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj1, accessorReturn.Tree);
          assignmentReturn.value.Mode = accessorReturn.value;
          assignmentReturn.value.Expression = (Expression) functionExpression;
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._propertyName_in_propertyAssignment3412);
          ES3Parser.propertyName_return propertyNameReturn1 = this.propertyName();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj1, propertyNameReturn1.Tree);
          assignmentReturn.value.Name = functionExpression.Name = propertyNameReturn1.value;
          int num2 = 2;
          if (((IIntStream) this.input).LA(1) == 90)
            num2 = 1;
          if (num2 == 1)
          {
            ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._formalParameterList_in_propertyAssignment3419);
            ES3Parser.formalParameterList_return parameterListReturn = this.formalParameterList();
            ((BaseRecognizer) this).PopFollow();
            this.adaptor.AddChild(obj1, parameterListReturn.Tree);
            functionExpression.Parameters.AddRange((IEnumerable<string>) parameterListReturn.value);
          }
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._functionBody_in_propertyAssignment3427);
          ES3Parser.functionBody_return functionBodyReturn = this.functionBody();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj1, functionBodyReturn.Tree);
          functionExpression.Statement = (Statement) functionBodyReturn.value;
          break;
        case 2:
          obj1 = this.adaptor.Nil();
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._propertyName_in_propertyAssignment3437);
          ES3Parser.propertyName_return propertyNameReturn2 = this.propertyName();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj1, propertyNameReturn2.Tree);
          assignmentReturn.value.Name = propertyNameReturn2.value;
          object obj2 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 26, ES3Parser.Follow._COLON_in_propertyAssignment3441));
          this.adaptor.AddChild(obj1, obj2);
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._assignmentExpression_in_propertyAssignment3445);
          ES3Parser.assignmentExpression_return expressionReturn = this.assignmentExpression();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj1, expressionReturn.Tree);
          assignmentReturn.value.Expression = expressionReturn.value;
          break;
      }
      assignmentReturn.Stop = this.input.LT(-1);
      assignmentReturn.Tree = this.adaptor.RulePostProcessing(obj1);
      this.adaptor.SetTokenBoundaries(assignmentReturn.Tree, assignmentReturn.Start, assignmentReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      assignmentReturn.Tree = this.adaptor.ErrorNode(this.input, assignmentReturn.Start, this.input.LT(-1), ex);
    }
    return assignmentReturn;
  }

  [GrammarRule("accessor")]
  private ES3Parser.accessor_return accessor()
  {
    ES3Parser.accessor_return accessorReturn = new ES3Parser.accessor_return(this);
    accessorReturn.Start = this.input.LT(1);
    try
    {
      object obj1 = this.adaptor.Nil();
      IToken itoken = (IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 79, ES3Parser.Follow._Identifier_in_accessor3465);
      object obj2 = this.adaptor.Create(itoken);
      this.adaptor.AddChild(obj1, obj2);
      if (!(itoken.Text == "get") && !(itoken.Text == "set"))
        throw new FailedPredicateException((IIntStream) this.input, nameof (accessor), " ex1.Text==\"get\" || ex1.Text==\"set\" ");
      if (itoken.Text == "get")
        accessorReturn.value = PropertyExpressionType.Get;
      if (itoken.Text == "set")
        accessorReturn.value = PropertyExpressionType.Set;
      accessorReturn.Stop = this.input.LT(-1);
      accessorReturn.Tree = this.adaptor.RulePostProcessing(obj1);
      this.adaptor.SetTokenBoundaries(accessorReturn.Tree, accessorReturn.Start, accessorReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      accessorReturn.Tree = this.adaptor.ErrorNode(this.input, accessorReturn.Start, this.input.LT(-1), ex);
    }
    return accessorReturn;
  }

  [GrammarRule("propertyName")]
  private ES3Parser.propertyName_return propertyName()
  {
    ES3Parser.propertyName_return propertyNameReturn = new ES3Parser.propertyName_return(this);
    propertyNameReturn.Start = this.input.LT(1);
    object obj1 = (object) null;
    try
    {
      int num;
      switch (((IIntStream) this.input).LA(1))
      {
        case 44:
        case 68:
        case 114:
          num = 3;
          break;
        case 79:
          num = 1;
          break;
        case 150:
          num = 2;
          break;
        default:
          throw new NoViableAltException("", 15, 0, (IIntStream) this.input);
      }
      switch (num)
      {
        case 1:
          obj1 = this.adaptor.Nil();
          IToken itoken1 = (IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 79, ES3Parser.Follow._Identifier_in_propertyName3487);
          object obj2 = this.adaptor.Create(itoken1);
          this.adaptor.AddChild(obj1, obj2);
          propertyNameReturn.value = itoken1.Text;
          break;
        case 2:
          obj1 = this.adaptor.Nil();
          IToken itoken2 = (IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 150, ES3Parser.Follow._StringLiteral_in_propertyName3496);
          object obj3 = this.adaptor.Create(itoken2);
          this.adaptor.AddChild(obj1, obj3);
          propertyNameReturn.value = this.extractString(itoken2.Text);
          break;
        case 3:
          obj1 = this.adaptor.Nil();
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._numericLiteral_in_propertyName3505);
          ES3Parser.numericLiteral_return numericLiteralReturn = this.numericLiteral();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj1, numericLiteralReturn.Tree);
          propertyNameReturn.value = numericLiteralReturn.value.ToString();
          break;
      }
      propertyNameReturn.Stop = this.input.LT(-1);
      propertyNameReturn.Tree = this.adaptor.RulePostProcessing(obj1);
      this.adaptor.SetTokenBoundaries(propertyNameReturn.Tree, propertyNameReturn.Start, propertyNameReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      propertyNameReturn.Tree = this.adaptor.ErrorNode(this.input, propertyNameReturn.Start, this.input.LT(-1), ex);
    }
    return propertyNameReturn;
  }

  [GrammarRule("memberExpression")]
  private ES3Parser.memberExpression_return memberExpression()
  {
    ES3Parser.memberExpression_return expressionReturn1 = new ES3Parser.memberExpression_return(this);
    expressionReturn1.Start = this.input.LT(1);
    object obj = (object) null;
    try
    {
      int num;
      switch (((IIntStream) this.input).LA(1))
      {
        case 44:
        case 54:
        case 68:
        case 79:
        case 85:
        case 86:
        case 90:
        case 108:
        case 114:
        case 131:
        case 150:
        case 152:
        case 156:
          num = 1;
          break;
        case 62:
          num = 2;
          break;
        case 105:
          num = 3;
          break;
        default:
          throw new NoViableAltException("", 16 /*0x10*/, 0, (IIntStream) this.input);
      }
      switch (num)
      {
        case 1:
          obj = this.adaptor.Nil();
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._primaryExpression_in_memberExpression3531);
          ES3Parser.primaryExpression_return expressionReturn2 = this.primaryExpression();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj, expressionReturn2.Tree);
          expressionReturn1.value = expressionReturn2.value;
          break;
        case 2:
          obj = this.adaptor.Nil();
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._functionExpression_in_memberExpression3540);
          ES3Parser.functionExpression_return expressionReturn3 = this.functionExpression();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj, expressionReturn3.Tree);
          expressionReturn1.value = (Expression) expressionReturn3.value;
          break;
        case 3:
          obj = this.adaptor.Nil();
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._newExpression_in_memberExpression3549);
          ES3Parser.newExpression_return expressionReturn4 = this.newExpression();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj, expressionReturn4.Tree);
          expressionReturn1.value = (Expression) expressionReturn4.value;
          break;
      }
      expressionReturn1.Stop = this.input.LT(-1);
      expressionReturn1.Tree = this.adaptor.RulePostProcessing(obj);
      this.adaptor.SetTokenBoundaries(expressionReturn1.Tree, expressionReturn1.Start, expressionReturn1.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      expressionReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionReturn1.Start, this.input.LT(-1), ex);
    }
    return expressionReturn1;
  }

  [GrammarRule("newExpression")]
  private ES3Parser.newExpression_return newExpression()
  {
    ES3Parser.newExpression_return expressionReturn1 = new ES3Parser.newExpression_return(this);
    expressionReturn1.Start = this.input.LT(1);
    try
    {
      object obj1 = this.adaptor.Nil();
      object obj2 = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 105, ES3Parser.Follow._NEW_in_newExpression3566)), obj1);
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._memberExpression_in_newExpression3571);
      ES3Parser.memberExpression_return expressionReturn2 = this.memberExpression();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj2, expressionReturn2.Tree);
      expressionReturn1.value = new NewExpression(expressionReturn2.value);
      expressionReturn1.Stop = this.input.LT(-1);
      expressionReturn1.Tree = this.adaptor.RulePostProcessing(obj2);
      this.adaptor.SetTokenBoundaries(expressionReturn1.Tree, expressionReturn1.Start, expressionReturn1.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      expressionReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionReturn1.Start, this.input.LT(-1), ex);
    }
    return expressionReturn1;
  }

  [GrammarRule("arguments")]
  private ES3Parser.arguments_return arguments()
  {
    ES3Parser.arguments_return argumentsReturn = new ES3Parser.arguments_return(this);
    argumentsReturn.Start = this.input.LT(1);
    argumentsReturn.value = new List<Expression>();
    try
    {
      object obj1 = this.adaptor.Nil();
      object obj2 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 90, ES3Parser.Follow._LPAREN_in_arguments3594));
      this.adaptor.AddChild(obj1, obj2);
      int num1 = 2;
      int num2 = ((IIntStream) this.input).LA(1);
      if (num2 == 5 || num2 == 33 || num2 == 35 || num2 == 44 || num2 == 54 || num2 == 62 || num2 == 68 || num2 == 73 || num2 == 77 || num2 == 79 || num2 >= 85 && num2 <= 86 || num2 == 90 || num2 >= 105 && num2 <= 106 || num2 == 108 || num2 == 114 || num2 == 131 || num2 == 144 /*0x90*/ || num2 == 150 || num2 == 152 || num2 == 156 || num2 == 158 || num2 == 162)
        num1 = 1;
      if (num1 == 1)
      {
        ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._assignmentExpression_in_arguments3600);
        ES3Parser.assignmentExpression_return expressionReturn1 = this.assignmentExpression();
        ((BaseRecognizer) this).PopFollow();
        this.adaptor.AddChild(obj1, expressionReturn1.Tree);
        argumentsReturn.value.Add(expressionReturn1.value);
        while (true)
        {
          int num3 = 2;
          if (((IIntStream) this.input).LA(1) == 27)
            num3 = 1;
          if (num3 == 1)
          {
            object obj3 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 27, ES3Parser.Follow._COMMA_in_arguments3606));
            this.adaptor.AddChild(obj1, obj3);
            ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._assignmentExpression_in_arguments3610);
            ES3Parser.assignmentExpression_return expressionReturn2 = this.assignmentExpression();
            ((BaseRecognizer) this).PopFollow();
            this.adaptor.AddChild(obj1, expressionReturn2.Tree);
            argumentsReturn.value.Add(expressionReturn2.value);
          }
          else
            break;
        }
      }
      object obj4 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 128 /*0x80*/, ES3Parser.Follow._RPAREN_in_arguments3619));
      this.adaptor.AddChild(obj1, obj4);
      argumentsReturn.Stop = this.input.LT(-1);
      argumentsReturn.Tree = this.adaptor.RulePostProcessing(obj1);
      this.adaptor.SetTokenBoundaries(argumentsReturn.Tree, argumentsReturn.Start, argumentsReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      argumentsReturn.Tree = this.adaptor.ErrorNode(this.input, argumentsReturn.Start, this.input.LT(-1), ex);
    }
    return argumentsReturn;
  }

  [GrammarRule("generics")]
  private ES3Parser.generics_return generics()
  {
    ES3Parser.generics_return genericsReturn = new ES3Parser.generics_return(this);
    genericsReturn.Start = this.input.LT(1);
    genericsReturn.value = new List<Expression>();
    try
    {
      object obj1 = this.adaptor.Nil();
      object obj2 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 85, ES3Parser.Follow._LBRACE_in_generics3641));
      this.adaptor.AddChild(obj1, obj2);
      int num1 = 2;
      int num2 = ((IIntStream) this.input).LA(1);
      if (num2 == 5 || num2 == 33 || num2 == 35 || num2 == 44 || num2 == 54 || num2 == 62 || num2 == 68 || num2 == 73 || num2 == 77 || num2 == 79 || num2 >= 85 && num2 <= 86 || num2 == 90 || num2 >= 105 && num2 <= 106 || num2 == 108 || num2 == 114 || num2 == 131 || num2 == 144 /*0x90*/ || num2 == 150 || num2 == 152 || num2 == 156 || num2 == 158 || num2 == 162)
        num1 = 1;
      if (num1 == 1)
      {
        ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._assignmentExpression_in_generics3647);
        ES3Parser.assignmentExpression_return expressionReturn1 = this.assignmentExpression();
        ((BaseRecognizer) this).PopFollow();
        this.adaptor.AddChild(obj1, expressionReturn1.Tree);
        genericsReturn.value.Add(expressionReturn1.value);
        while (true)
        {
          int num3 = 2;
          if (((IIntStream) this.input).LA(1) == 27)
            num3 = 1;
          if (num3 == 1)
          {
            object obj3 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 27, ES3Parser.Follow._COMMA_in_generics3653));
            this.adaptor.AddChild(obj1, obj3);
            ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._assignmentExpression_in_generics3657);
            ES3Parser.assignmentExpression_return expressionReturn2 = this.assignmentExpression();
            ((BaseRecognizer) this).PopFollow();
            this.adaptor.AddChild(obj1, expressionReturn2.Tree);
            genericsReturn.value.Add(expressionReturn2.value);
          }
          else
            break;
        }
      }
      object obj4 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 125, ES3Parser.Follow._RBRACE_in_generics3666));
      this.adaptor.AddChild(obj1, obj4);
      genericsReturn.Stop = this.input.LT(-1);
      genericsReturn.Tree = this.adaptor.RulePostProcessing(obj1);
      this.adaptor.SetTokenBoundaries(genericsReturn.Tree, genericsReturn.Start, genericsReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      genericsReturn.Tree = this.adaptor.ErrorNode(this.input, genericsReturn.Start, this.input.LT(-1), ex);
    }
    return genericsReturn;
  }

  [GrammarRule("leftHandSideExpression")]
  private ES3Parser.leftHandSideExpression_return leftHandSideExpression()
  {
    ES3Parser.leftHandSideExpression_return expressionReturn1 = new ES3Parser.leftHandSideExpression_return(this);
    expressionReturn1.Start = this.input.LT(1);
    List<Expression> expressionList = new List<Expression>();
    try
    {
      object obj1 = this.adaptor.Nil();
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._memberExpression_in_leftHandSideExpression3702);
      ES3Parser.memberExpression_return expressionReturn2 = this.memberExpression();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj1, expressionReturn2.Tree);
      expressionReturn1.value = expressionReturn2.value;
      while (true)
      {
        int num1 = 4;
        switch (((IIntStream) this.input).LA(1))
        {
          case 39:
            num1 = 3;
            break;
          case 85:
          case 90:
            num1 = 1;
            break;
          case 86:
            num1 = 2;
            break;
        }
        switch (num1)
        {
          case 1:
            int num2 = 2;
            if (((IIntStream) this.input).LA(1) == 85)
              num2 = 1;
            if (num2 == 1)
            {
              ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._generics_in_leftHandSideExpression3718);
              ES3Parser.generics_return genericsReturn = this.generics();
              ((BaseRecognizer) this).PopFollow();
              this.adaptor.AddChild(obj1, genericsReturn.Tree);
              expressionList = genericsReturn.value;
            }
            ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._arguments_in_leftHandSideExpression3727);
            ES3Parser.arguments_return argumentsReturn = this.arguments();
            ((BaseRecognizer) this).PopFollow();
            this.adaptor.AddChild(obj1, argumentsReturn.Tree);
            if (expressionReturn1.value is NewExpression && !this._newExpressionIsUnary)
            {
              ((NewExpression) expressionReturn1.value).Generics = expressionList;
              ((NewExpression) expressionReturn1.value).Arguments = argumentsReturn.value;
              expressionReturn1.value = (Expression) new MemberExpression(expressionReturn1.value, (Expression) null);
              continue;
            }
            expressionReturn1.value = (Expression) new MemberExpression((Expression) new MethodCall(argumentsReturn.value)
            {
              Generics = expressionList
            }, expressionReturn1.value);
            continue;
          case 2:
            object obj2 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 86, ES3Parser.Follow._LBRACK_in_leftHandSideExpression3738));
            this.adaptor.AddChild(obj1, obj2);
            ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._expression_in_leftHandSideExpression3742);
            ES3Parser.expression_return expressionReturn3 = this.expression();
            ((BaseRecognizer) this).PopFollow();
            this.adaptor.AddChild(obj1, expressionReturn3.Tree);
            object obj3 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 126, ES3Parser.Follow._RBRACK_in_leftHandSideExpression3744));
            this.adaptor.AddChild(obj1, obj3);
            expressionReturn1.value = (Expression) new MemberExpression((Expression) new Indexer(expressionReturn3.value), expressionReturn1.value);
            continue;
          case 3:
            object obj4 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 39, ES3Parser.Follow._DOT_in_leftHandSideExpression3757));
            this.adaptor.AddChild(obj1, obj4);
            IToken itoken = this.input.LT(1);
            if (((IIntStream) this.input).LA(1) == 4 || ((IIntStream) this.input).LA(1) >= 13 && ((IIntStream) this.input).LA(1) <= 14 || ((IIntStream) this.input).LA(1) == 18 || ((IIntStream) this.input).LA(1) >= 21 && ((IIntStream) this.input).LA(1) <= 22 || ((IIntStream) this.input).LA(1) >= 24 && ((IIntStream) this.input).LA(1) <= 25 || ((IIntStream) this.input).LA(1) >= 28 && ((IIntStream) this.input).LA(1) <= 29 || ((IIntStream) this.input).LA(1) == 32 /*0x20*/ || ((IIntStream) this.input).LA(1) >= 34 && ((IIntStream) this.input).LA(1) <= 35 || ((IIntStream) this.input).LA(1) == 38 || ((IIntStream) this.input).LA(1) == 40 || ((IIntStream) this.input).LA(1) >= 45 && ((IIntStream) this.input).LA(1) <= 46 || ((IIntStream) this.input).LA(1) == 49 || ((IIntStream) this.input).LA(1) == 51 || ((IIntStream) this.input).LA(1) == 54 || ((IIntStream) this.input).LA(1) >= 56 && ((IIntStream) this.input).LA(1) <= 59 || ((IIntStream) this.input).LA(1) >= 62 && ((IIntStream) this.input).LA(1) <= 63 /*0x3F*/ || ((IIntStream) this.input).LA(1) >= 69 && ((IIntStream) this.input).LA(1) <= 72 || ((IIntStream) this.input).LA(1) >= 74 && ((IIntStream) this.input).LA(1) <= 76 || ((IIntStream) this.input).LA(1) == 79 || ((IIntStream) this.input).LA(1) == 88 || ((IIntStream) this.input).LA(1) == 101 || ((IIntStream) this.input).LA(1) == 105 || ((IIntStream) this.input).LA(1) == 108 || ((IIntStream) this.input).LA(1) == 115 || ((IIntStream) this.input).LA(1) >= 120 && ((IIntStream) this.input).LA(1) <= 121 || ((IIntStream) this.input).LA(1) == 123 || ((IIntStream) this.input).LA(1) == (int) sbyte.MaxValue || ((IIntStream) this.input).LA(1) == 136 || ((IIntStream) this.input).LA(1) == 143 || ((IIntStream) this.input).LA(1) >= 146 && ((IIntStream) this.input).LA(1) <= 148 || ((IIntStream) this.input).LA(1) >= 152 && ((IIntStream) this.input).LA(1) <= 158 || ((IIntStream) this.input).LA(1) >= 161 && ((IIntStream) this.input).LA(1) <= 163 || ((IIntStream) this.input).LA(1) >= 165 && ((IIntStream) this.input).LA(1) <= 166)
            {
              ((IIntStream) this.input).Consume();
              this.adaptor.AddChild(obj1, this.adaptor.Create(itoken));
              ((BaseRecognizer) this).state.errorRecovery = false;
              if (expressionReturn1.value is NewExpression && !this._newExpressionIsUnary)
              {
                ((NewExpression) expressionReturn1.value).Expression = (Expression) new MemberExpression((Expression) new PropertyExpression(itoken.Text), ((NewExpression) expressionReturn1.value).Expression);
                continue;
              }
              expressionReturn1.value = (Expression) new MemberExpression((Expression) new PropertyExpression(itoken.Text), expressionReturn1.value);
              continue;
            }
            goto label_17;
          default:
            goto label_20;
        }
      }
label_17:
      throw new MismatchedSetException((BitSet) null, (IIntStream) this.input);
label_20:
      expressionReturn1.Stop = this.input.LT(-1);
      expressionReturn1.Tree = this.adaptor.RulePostProcessing(obj1);
      this.adaptor.SetTokenBoundaries(expressionReturn1.Tree, expressionReturn1.Start, expressionReturn1.Stop);
      expressionReturn1.value.Source = this.ExtractSourceCode((CommonToken) expressionReturn1.Start, (CommonToken) expressionReturn1.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      expressionReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionReturn1.Start, this.input.LT(-1), ex);
    }
    return expressionReturn1;
  }

  [GrammarRule("postfixExpression")]
  private ES3Parser.postfixExpression_return postfixExpression()
  {
    ES3Parser.postfixExpression_return expressionReturn1 = new ES3Parser.postfixExpression_return(this);
    expressionReturn1.Start = this.input.LT(1);
    try
    {
      object obj = this.adaptor.Nil();
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._leftHandSideExpression_in_postfixExpression3915);
      ES3Parser.leftHandSideExpression_return expressionReturn2 = this.leftHandSideExpression();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj, expressionReturn2.Tree);
      expressionReturn1.value = expressionReturn2.value;
      if (((IIntStream) this.input).LA(1) == 73 || ((IIntStream) this.input).LA(1) == 33)
        this.PromoteEOL((ParserRuleReturnScope<IToken>) null);
      int num = 2;
      switch (((IIntStream) this.input).LA(1))
      {
        case 33:
        case 73:
          num = 1;
          break;
      }
      if (num == 1)
      {
        ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._postfixOperator_in_postfixExpression3923);
        ES3Parser.postfixOperator_return postfixOperatorReturn = this.postfixOperator();
        ((BaseRecognizer) this).PopFollow();
        obj = this.adaptor.BecomeRoot(postfixOperatorReturn.Tree, obj);
        expressionReturn1.value = (Expression) new UnaryExpression(postfixOperatorReturn.value, expressionReturn1.value);
      }
      expressionReturn1.Stop = this.input.LT(-1);
      expressionReturn1.Tree = this.adaptor.RulePostProcessing(obj);
      this.adaptor.SetTokenBoundaries(expressionReturn1.Tree, expressionReturn1.Start, expressionReturn1.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      expressionReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionReturn1.Start, this.input.LT(-1), ex);
    }
    return expressionReturn1;
  }

  [GrammarRule("postfixOperator")]
  private ES3Parser.postfixOperator_return postfixOperator()
  {
    ES3Parser.postfixOperator_return postfixOperatorReturn = new ES3Parser.postfixOperator_return(this);
    postfixOperatorReturn.Start = this.input.LT(1);
    object obj1 = (object) null;
    try
    {
      int num;
      switch (((IIntStream) this.input).LA(1))
      {
        case 33:
          num = 2;
          break;
        case 73:
          num = 1;
          break;
        default:
          throw new NoViableAltException("", 24, 0, (IIntStream) this.input);
      }
      switch (num)
      {
        case 1:
          obj1 = this.adaptor.Nil();
          IToken itoken1 = (IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 73, ES3Parser.Follow._INC_in_postfixOperator3946);
          object obj2 = this.adaptor.Create(itoken1);
          this.adaptor.AddChild(obj1, obj2);
          itoken1.Type = 118;
          postfixOperatorReturn.value = UnaryExpressionType.PostfixPlusPlus;
          break;
        case 2:
          obj1 = this.adaptor.Nil();
          IToken itoken2 = (IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 33, ES3Parser.Follow._DEC_in_postfixOperator3955);
          object obj3 = this.adaptor.Create(itoken2);
          this.adaptor.AddChild(obj1, obj3);
          itoken2.Type = 117;
          postfixOperatorReturn.value = UnaryExpressionType.PostfixMinusMinus;
          break;
      }
      postfixOperatorReturn.Stop = this.input.LT(-1);
      postfixOperatorReturn.Tree = this.adaptor.RulePostProcessing(obj1);
      this.adaptor.SetTokenBoundaries(postfixOperatorReturn.Tree, postfixOperatorReturn.Start, postfixOperatorReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      postfixOperatorReturn.Tree = this.adaptor.ErrorNode(this.input, postfixOperatorReturn.Start, this.input.LT(-1), ex);
    }
    return postfixOperatorReturn;
  }

  [GrammarRule("unaryExpression")]
  private ES3Parser.unaryExpression_return unaryExpression()
  {
    ES3Parser.unaryExpression_return expressionReturn1 = new ES3Parser.unaryExpression_return(this);
    expressionReturn1.Start = this.input.LT(1);
    object obj1 = (object) null;
    try
    {
      int num1 = ((IIntStream) this.input).LA(1);
      int num2;
      if (num1 == 44 || num1 == 54 || num1 == 62 || num1 == 68 || num1 == 79 || num1 >= 85 && num1 <= 86 || num1 == 90 || num1 == 105 || num1 == 108 || num1 == 114 || num1 == 131 || num1 == 150 || num1 == 152 || num1 == 156)
      {
        num2 = 1;
      }
      else
      {
        if (num1 != 5 && num1 != 33 && num1 != 35 && num1 != 73 && num1 != 77 && num1 != 106 && num1 != 144 /*0x90*/ && num1 != 158 && num1 != 162)
          throw new NoViableAltException("", 25, 0, (IIntStream) this.input);
        num2 = 2;
      }
      switch (num2)
      {
        case 1:
          obj1 = this.adaptor.Nil();
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._postfixExpression_in_unaryExpression3978);
          ES3Parser.postfixExpression_return expressionReturn2 = this.postfixExpression();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj1, expressionReturn2.Tree);
          expressionReturn1.value = expressionReturn2.value;
          break;
        case 2:
          object obj2 = this.adaptor.Nil();
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._unaryOperator_in_unaryExpression3987);
          ES3Parser.unaryOperator_return unaryOperatorReturn = this.unaryOperator();
          ((BaseRecognizer) this).PopFollow();
          obj1 = this.adaptor.BecomeRoot(unaryOperatorReturn.Tree, obj2);
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._unaryExpression_in_unaryExpression3992);
          ES3Parser.unaryExpression_return expressionReturn3 = this.unaryExpression();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj1, expressionReturn3.Tree);
          expressionReturn1.value = (Expression) new UnaryExpression(unaryOperatorReturn.value, expressionReturn3.value);
          break;
      }
      expressionReturn1.Stop = this.input.LT(-1);
      expressionReturn1.Tree = this.adaptor.RulePostProcessing(obj1);
      this.adaptor.SetTokenBoundaries(expressionReturn1.Tree, expressionReturn1.Start, expressionReturn1.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      expressionReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionReturn1.Start, this.input.LT(-1), ex);
    }
    return expressionReturn1;
  }

  [GrammarRule("unaryOperator")]
  private ES3Parser.unaryOperator_return unaryOperator()
  {
    ES3Parser.unaryOperator_return unaryOperatorReturn = new ES3Parser.unaryOperator_return(this);
    unaryOperatorReturn.Start = this.input.LT(1);
    object obj1 = (object) null;
    try
    {
      int num;
      switch (((IIntStream) this.input).LA(1))
      {
        case 5:
          num = 6;
          break;
        case 33:
          num = 5;
          break;
        case 35:
          num = 1;
          break;
        case 73:
          num = 4;
          break;
        case 77:
          num = 8;
          break;
        case 106:
          num = 9;
          break;
        case 144 /*0x90*/:
          num = 7;
          break;
        case 158:
          num = 3;
          break;
        case 162:
          num = 2;
          break;
        default:
          throw new NoViableAltException("", 26, 0, (IIntStream) this.input);
      }
      switch (num)
      {
        case 1:
          obj1 = this.adaptor.Nil();
          object obj2 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 35, ES3Parser.Follow._DELETE_in_unaryOperator4010));
          this.adaptor.AddChild(obj1, obj2);
          unaryOperatorReturn.value = UnaryExpressionType.Delete;
          break;
        case 2:
          obj1 = this.adaptor.Nil();
          object obj3 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 162, ES3Parser.Follow._VOID_in_unaryOperator4017));
          this.adaptor.AddChild(obj1, obj3);
          unaryOperatorReturn.value = UnaryExpressionType.Void;
          break;
        case 3:
          obj1 = this.adaptor.Nil();
          object obj4 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 158, ES3Parser.Follow._TYPEOF_in_unaryOperator4024));
          this.adaptor.AddChild(obj1, obj4);
          unaryOperatorReturn.value = UnaryExpressionType.TypeOf;
          break;
        case 4:
          obj1 = this.adaptor.Nil();
          object obj5 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 73, ES3Parser.Follow._INC_in_unaryOperator4031));
          this.adaptor.AddChild(obj1, obj5);
          unaryOperatorReturn.value = UnaryExpressionType.PrefixPlusPlus;
          break;
        case 5:
          obj1 = this.adaptor.Nil();
          object obj6 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 33, ES3Parser.Follow._DEC_in_unaryOperator4038));
          this.adaptor.AddChild(obj1, obj6);
          unaryOperatorReturn.value = UnaryExpressionType.PrefixMinusMinus;
          break;
        case 6:
          obj1 = this.adaptor.Nil();
          IToken itoken1 = (IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 5, ES3Parser.Follow._ADD_in_unaryOperator4047);
          object obj7 = this.adaptor.Create(itoken1);
          this.adaptor.AddChild(obj1, obj7);
          itoken1.Type = 119;
          unaryOperatorReturn.value = UnaryExpressionType.Positive;
          break;
        case 7:
          obj1 = this.adaptor.Nil();
          IToken itoken2 = (IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 144 /*0x90*/, ES3Parser.Follow._SUB_in_unaryOperator4056);
          object obj8 = this.adaptor.Create(itoken2);
          this.adaptor.AddChild(obj1, obj8);
          itoken2.Type = 103;
          unaryOperatorReturn.value = UnaryExpressionType.Negate;
          break;
        case 8:
          obj1 = this.adaptor.Nil();
          object obj9 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 77, ES3Parser.Follow._INV_in_unaryOperator4063));
          this.adaptor.AddChild(obj1, obj9);
          unaryOperatorReturn.value = UnaryExpressionType.Inv;
          break;
        case 9:
          obj1 = this.adaptor.Nil();
          object obj10 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 106, ES3Parser.Follow._NOT_in_unaryOperator4070));
          this.adaptor.AddChild(obj1, obj10);
          unaryOperatorReturn.value = UnaryExpressionType.Not;
          break;
      }
      unaryOperatorReturn.Stop = this.input.LT(-1);
      unaryOperatorReturn.Tree = this.adaptor.RulePostProcessing(obj1);
      this.adaptor.SetTokenBoundaries(unaryOperatorReturn.Tree, unaryOperatorReturn.Start, unaryOperatorReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      unaryOperatorReturn.Tree = this.adaptor.ErrorNode(this.input, unaryOperatorReturn.Start, this.input.LT(-1), ex);
    }
    return unaryOperatorReturn;
  }

  [GrammarRule("multiplicativeExpression")]
  private ES3Parser.multiplicativeExpression_return multiplicativeExpression()
  {
    ES3Parser.multiplicativeExpression_return expressionReturn1 = new ES3Parser.multiplicativeExpression_return(this);
    expressionReturn1.Start = this.input.LT(1);
    BinaryExpressionType type = BinaryExpressionType.Unknown;
    try
    {
      object obj1 = this.adaptor.Nil();
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._unaryExpression_in_multiplicativeExpression4098);
      ES3Parser.unaryExpression_return expressionReturn2 = this.unaryExpression();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj1, expressionReturn2.Tree);
      expressionReturn1.value = expressionReturn2.value;
      while (true)
      {
        int num1 = 2;
        switch (((IIntStream) this.input).LA(1))
        {
          case 36:
          case 95:
          case 97:
            num1 = 1;
            break;
        }
        if (num1 == 1)
        {
          int num2;
          switch (((IIntStream) this.input).LA(1))
          {
            case 36:
              num2 = 2;
              break;
            case 95:
              num2 = 3;
              break;
            case 97:
              num2 = 1;
              break;
            default:
              goto label_9;
          }
          switch (num2)
          {
            case 1:
              object obj2 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 97, ES3Parser.Follow._MUL_in_multiplicativeExpression4109));
              this.adaptor.AddChild(obj1, obj2);
              type = BinaryExpressionType.Times;
              break;
            case 2:
              object obj3 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 36, ES3Parser.Follow._DIV_in_multiplicativeExpression4118));
              this.adaptor.AddChild(obj1, obj3);
              type = BinaryExpressionType.Div;
              break;
            case 3:
              object obj4 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 95, ES3Parser.Follow._MOD_in_multiplicativeExpression4126));
              this.adaptor.AddChild(obj1, obj4);
              type = BinaryExpressionType.Modulo;
              break;
          }
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._unaryExpression_in_multiplicativeExpression4137);
          ES3Parser.unaryExpression_return expressionReturn3 = this.unaryExpression();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj1, expressionReturn3.Tree);
          expressionReturn1.value = (Expression) new BinaryExpression(type, expressionReturn1.value, expressionReturn3.value);
        }
        else
          goto label_15;
      }
label_9:
      throw new NoViableAltException("", 27, 0, (IIntStream) this.input);
label_15:
      expressionReturn1.Stop = this.input.LT(-1);
      expressionReturn1.Tree = this.adaptor.RulePostProcessing(obj1);
      this.adaptor.SetTokenBoundaries(expressionReturn1.Tree, expressionReturn1.Start, expressionReturn1.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      expressionReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionReturn1.Start, this.input.LT(-1), ex);
    }
    return expressionReturn1;
  }

  [GrammarRule("additiveExpression")]
  private ES3Parser.additiveExpression_return additiveExpression()
  {
    ES3Parser.additiveExpression_return expressionReturn1 = new ES3Parser.additiveExpression_return(this);
    expressionReturn1.Start = this.input.LT(1);
    BinaryExpressionType type = BinaryExpressionType.Unknown;
    try
    {
      object obj1 = this.adaptor.Nil();
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._multiplicativeExpression_in_additiveExpression4167);
      ES3Parser.multiplicativeExpression_return expressionReturn2 = this.multiplicativeExpression();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj1, expressionReturn2.Tree);
      expressionReturn1.value = expressionReturn2.value;
      while (true)
      {
        int num1 = 2;
        switch (((IIntStream) this.input).LA(1))
        {
          case 5:
          case 144 /*0x90*/:
            num1 = 1;
            break;
        }
        if (num1 == 1)
        {
          int num2;
          switch (((IIntStream) this.input).LA(1))
          {
            case 5:
              num2 = 1;
              break;
            case 144 /*0x90*/:
              num2 = 2;
              break;
            default:
              goto label_8;
          }
          switch (num2)
          {
            case 1:
              object obj2 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 5, ES3Parser.Follow._ADD_in_additiveExpression4178));
              this.adaptor.AddChild(obj1, obj2);
              type = BinaryExpressionType.Plus;
              break;
            case 2:
              object obj3 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 144 /*0x90*/, ES3Parser.Follow._SUB_in_additiveExpression4186));
              this.adaptor.AddChild(obj1, obj3);
              type = BinaryExpressionType.Minus;
              break;
          }
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._multiplicativeExpression_in_additiveExpression4197);
          ES3Parser.multiplicativeExpression_return expressionReturn3 = this.multiplicativeExpression();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj1, expressionReturn3.Tree);
          expressionReturn1.value = (Expression) new BinaryExpression(type, expressionReturn1.value, expressionReturn3.value);
        }
        else
          goto label_13;
      }
label_8:
      throw new NoViableAltException("", 29, 0, (IIntStream) this.input);
label_13:
      expressionReturn1.Stop = this.input.LT(-1);
      expressionReturn1.Tree = this.adaptor.RulePostProcessing(obj1);
      this.adaptor.SetTokenBoundaries(expressionReturn1.Tree, expressionReturn1.Start, expressionReturn1.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      expressionReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionReturn1.Start, this.input.LT(-1), ex);
    }
    return expressionReturn1;
  }

  [GrammarRule("shiftExpression")]
  private ES3Parser.shiftExpression_return shiftExpression()
  {
    ES3Parser.shiftExpression_return expressionReturn1 = new ES3Parser.shiftExpression_return(this);
    expressionReturn1.Start = this.input.LT(1);
    BinaryExpressionType type = BinaryExpressionType.Unknown;
    try
    {
      object obj1 = this.adaptor.Nil();
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._additiveExpression_in_shiftExpression4228);
      ES3Parser.additiveExpression_return expressionReturn2 = this.additiveExpression();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj1, expressionReturn2.Tree);
      expressionReturn1.value = expressionReturn2.value;
      while (true)
      {
        int num1 = 2;
        switch (((IIntStream) this.input).LA(1))
        {
          case 134:
          case 137:
          case 139:
            num1 = 1;
            break;
        }
        if (num1 == 1)
        {
          int num2;
          switch (((IIntStream) this.input).LA(1))
          {
            case 134:
              num2 = 1;
              break;
            case 137:
              num2 = 2;
              break;
            case 139:
              num2 = 3;
              break;
            default:
              goto label_9;
          }
          switch (num2)
          {
            case 1:
              object obj2 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 134, ES3Parser.Follow._SHL_in_shiftExpression4239));
              this.adaptor.AddChild(obj1, obj2);
              type = BinaryExpressionType.LeftShift;
              break;
            case 2:
              object obj3 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 137, ES3Parser.Follow._SHR_in_shiftExpression4247));
              this.adaptor.AddChild(obj1, obj3);
              type = BinaryExpressionType.RightShift;
              break;
            case 3:
              object obj4 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 139, ES3Parser.Follow._SHU_in_shiftExpression4255));
              this.adaptor.AddChild(obj1, obj4);
              type = BinaryExpressionType.UnsignedRightShift;
              break;
          }
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._additiveExpression_in_shiftExpression4266);
          ES3Parser.additiveExpression_return expressionReturn3 = this.additiveExpression();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj1, expressionReturn3.Tree);
          expressionReturn1.value = (Expression) new BinaryExpression(type, expressionReturn1.value, expressionReturn3.value);
        }
        else
          goto label_15;
      }
label_9:
      throw new NoViableAltException("", 31 /*0x1F*/, 0, (IIntStream) this.input);
label_15:
      expressionReturn1.Stop = this.input.LT(-1);
      expressionReturn1.Tree = this.adaptor.RulePostProcessing(obj1);
      this.adaptor.SetTokenBoundaries(expressionReturn1.Tree, expressionReturn1.Start, expressionReturn1.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      expressionReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionReturn1.Start, this.input.LT(-1), ex);
    }
    return expressionReturn1;
  }

  [GrammarRule("relationalExpression")]
  private ES3Parser.relationalExpression_return relationalExpression()
  {
    ES3Parser.relationalExpression_return expressionReturn1 = new ES3Parser.relationalExpression_return(this);
    expressionReturn1.Start = this.input.LT(1);
    BinaryExpressionType type = BinaryExpressionType.Unknown;
    try
    {
      object obj1 = this.adaptor.Nil();
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._shiftExpression_in_relationalExpression4297);
      ES3Parser.shiftExpression_return expressionReturn2 = this.shiftExpression();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj1, expressionReturn2.Tree);
      expressionReturn1.value = expressionReturn2.value;
      while (true)
      {
        int num1 = 2;
        int num2 = ((IIntStream) this.input).LA(1);
        if (num2 >= 64 /*0x40*/ && num2 <= 65 || num2 == 72 || num2 == 74 || num2 >= 92 && num2 <= 93)
          num1 = 1;
        if (num1 == 1)
        {
          int num3;
          switch (((IIntStream) this.input).LA(1))
          {
            case 64 /*0x40*/:
              num3 = 2;
              break;
            case 65:
              num3 = 4;
              break;
            case 72:
              num3 = 6;
              break;
            case 74:
              num3 = 5;
              break;
            case 92:
              num3 = 1;
              break;
            case 93:
              num3 = 3;
              break;
            default:
              goto label_12;
          }
          switch (num3)
          {
            case 1:
              object obj2 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 92, ES3Parser.Follow._LT_in_relationalExpression4308));
              this.adaptor.AddChild(obj1, obj2);
              type = BinaryExpressionType.Lesser;
              break;
            case 2:
              object obj3 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 64 /*0x40*/, ES3Parser.Follow._GT_in_relationalExpression4316));
              this.adaptor.AddChild(obj1, obj3);
              type = BinaryExpressionType.Greater;
              break;
            case 3:
              object obj4 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 93, ES3Parser.Follow._LTE_in_relationalExpression4324));
              this.adaptor.AddChild(obj1, obj4);
              type = BinaryExpressionType.LesserOrEqual;
              break;
            case 4:
              object obj5 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 65, ES3Parser.Follow._GTE_in_relationalExpression4332));
              this.adaptor.AddChild(obj1, obj5);
              type = BinaryExpressionType.GreaterOrEqual;
              break;
            case 5:
              object obj6 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 74, ES3Parser.Follow._INSTANCEOF_in_relationalExpression4340));
              this.adaptor.AddChild(obj1, obj6);
              type = BinaryExpressionType.InstanceOf;
              break;
            case 6:
              object obj7 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 72, ES3Parser.Follow._IN_in_relationalExpression4348));
              this.adaptor.AddChild(obj1, obj7);
              type = BinaryExpressionType.In;
              break;
          }
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._shiftExpression_in_relationalExpression4359);
          ES3Parser.shiftExpression_return expressionReturn3 = this.shiftExpression();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj1, expressionReturn3.Tree);
          expressionReturn1.value = (Expression) new BinaryExpression(type, expressionReturn1.value, expressionReturn3.value);
        }
        else
          goto label_21;
      }
label_12:
      throw new NoViableAltException("", 33, 0, (IIntStream) this.input);
label_21:
      expressionReturn1.Stop = this.input.LT(-1);
      expressionReturn1.Tree = this.adaptor.RulePostProcessing(obj1);
      this.adaptor.SetTokenBoundaries(expressionReturn1.Tree, expressionReturn1.Start, expressionReturn1.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      expressionReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionReturn1.Start, this.input.LT(-1), ex);
    }
    return expressionReturn1;
  }

  [GrammarRule("relationalExpressionNoIn")]
  private ES3Parser.relationalExpressionNoIn_return relationalExpressionNoIn()
  {
    ES3Parser.relationalExpressionNoIn_return expressionNoInReturn = new ES3Parser.relationalExpressionNoIn_return(this);
    expressionNoInReturn.Start = this.input.LT(1);
    BinaryExpressionType type = BinaryExpressionType.Unknown;
    try
    {
      object obj1 = this.adaptor.Nil();
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._shiftExpression_in_relationalExpressionNoIn4385);
      ES3Parser.shiftExpression_return expressionReturn1 = this.shiftExpression();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj1, expressionReturn1.Tree);
      expressionNoInReturn.value = expressionReturn1.value;
      while (true)
      {
        int num1 = 2;
        int num2 = ((IIntStream) this.input).LA(1);
        if (num2 >= 64 /*0x40*/ && num2 <= 65 || num2 == 74 || num2 >= 92 && num2 <= 93)
          num1 = 1;
        if (num1 == 1)
        {
          int num3;
          switch (((IIntStream) this.input).LA(1))
          {
            case 64 /*0x40*/:
              num3 = 2;
              break;
            case 65:
              num3 = 4;
              break;
            case 74:
              num3 = 5;
              break;
            case 92:
              num3 = 1;
              break;
            case 93:
              num3 = 3;
              break;
            default:
              goto label_11;
          }
          switch (num3)
          {
            case 1:
              object obj2 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 92, ES3Parser.Follow._LT_in_relationalExpressionNoIn4396));
              this.adaptor.AddChild(obj1, obj2);
              type = BinaryExpressionType.Lesser;
              break;
            case 2:
              object obj3 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 64 /*0x40*/, ES3Parser.Follow._GT_in_relationalExpressionNoIn4404));
              this.adaptor.AddChild(obj1, obj3);
              type = BinaryExpressionType.Greater;
              break;
            case 3:
              object obj4 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 93, ES3Parser.Follow._LTE_in_relationalExpressionNoIn4412));
              this.adaptor.AddChild(obj1, obj4);
              type = BinaryExpressionType.LesserOrEqual;
              break;
            case 4:
              object obj5 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 65, ES3Parser.Follow._GTE_in_relationalExpressionNoIn4420));
              this.adaptor.AddChild(obj1, obj5);
              type = BinaryExpressionType.GreaterOrEqual;
              break;
            case 5:
              object obj6 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 74, ES3Parser.Follow._INSTANCEOF_in_relationalExpressionNoIn4428));
              this.adaptor.AddChild(obj1, obj6);
              type = BinaryExpressionType.InstanceOf;
              break;
          }
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._shiftExpression_in_relationalExpressionNoIn4440);
          ES3Parser.shiftExpression_return expressionReturn2 = this.shiftExpression();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj1, expressionReturn2.Tree);
          expressionNoInReturn.value = (Expression) new BinaryExpression(type, expressionNoInReturn.value, expressionReturn2.value);
        }
        else
          goto label_19;
      }
label_11:
      throw new NoViableAltException("", 35, 0, (IIntStream) this.input);
label_19:
      expressionNoInReturn.Stop = this.input.LT(-1);
      expressionNoInReturn.Tree = this.adaptor.RulePostProcessing(obj1);
      this.adaptor.SetTokenBoundaries(expressionNoInReturn.Tree, expressionNoInReturn.Start, expressionNoInReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      expressionNoInReturn.Tree = this.adaptor.ErrorNode(this.input, expressionNoInReturn.Start, this.input.LT(-1), ex);
    }
    return expressionNoInReturn;
  }

  [GrammarRule("equalityExpression")]
  private ES3Parser.equalityExpression_return equalityExpression()
  {
    ES3Parser.equalityExpression_return expressionReturn1 = new ES3Parser.equalityExpression_return(this);
    expressionReturn1.Start = this.input.LT(1);
    BinaryExpressionType type = BinaryExpressionType.Unknown;
    try
    {
      object obj1 = this.adaptor.Nil();
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._relationalExpression_in_equalityExpression4471);
      ES3Parser.relationalExpression_return expressionReturn2 = this.relationalExpression();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj1, expressionReturn2.Tree);
      expressionReturn1.value = expressionReturn2.value;
      while (true)
      {
        int num1 = 2;
        switch (((IIntStream) this.input).LA(1))
        {
          case 48 /*0x30*/:
          case 104:
          case 107:
          case 132:
            num1 = 1;
            break;
        }
        if (num1 == 1)
        {
          int num2;
          switch (((IIntStream) this.input).LA(1))
          {
            case 48 /*0x30*/:
              num2 = 1;
              break;
            case 104:
              num2 = 2;
              break;
            case 107:
              num2 = 4;
              break;
            case 132:
              num2 = 3;
              break;
            default:
              goto label_10;
          }
          switch (num2)
          {
            case 1:
              object obj2 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 48 /*0x30*/, ES3Parser.Follow._EQ_in_equalityExpression4482));
              this.adaptor.AddChild(obj1, obj2);
              type = BinaryExpressionType.Equal;
              break;
            case 2:
              object obj3 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 104, ES3Parser.Follow._NEQ_in_equalityExpression4490));
              this.adaptor.AddChild(obj1, obj3);
              type = BinaryExpressionType.NotEqual;
              break;
            case 3:
              object obj4 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 132, ES3Parser.Follow._SAME_in_equalityExpression4498));
              this.adaptor.AddChild(obj1, obj4);
              type = BinaryExpressionType.Same;
              break;
            case 4:
              object obj5 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 107, ES3Parser.Follow._NSAME_in_equalityExpression4506));
              this.adaptor.AddChild(obj1, obj5);
              type = BinaryExpressionType.NotSame;
              break;
          }
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._relationalExpression_in_equalityExpression4517);
          ES3Parser.relationalExpression_return expressionReturn3 = this.relationalExpression();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj1, expressionReturn3.Tree);
          expressionReturn1.value = (Expression) new BinaryExpression(type, expressionReturn1.value, expressionReturn3.value);
        }
        else
          goto label_17;
      }
label_10:
      throw new NoViableAltException("", 37, 0, (IIntStream) this.input);
label_17:
      expressionReturn1.Stop = this.input.LT(-1);
      expressionReturn1.Tree = this.adaptor.RulePostProcessing(obj1);
      this.adaptor.SetTokenBoundaries(expressionReturn1.Tree, expressionReturn1.Start, expressionReturn1.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      expressionReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionReturn1.Start, this.input.LT(-1), ex);
    }
    return expressionReturn1;
  }

  [GrammarRule("equalityExpressionNoIn")]
  private ES3Parser.equalityExpressionNoIn_return equalityExpressionNoIn()
  {
    ES3Parser.equalityExpressionNoIn_return expressionNoInReturn1 = new ES3Parser.equalityExpressionNoIn_return(this);
    expressionNoInReturn1.Start = this.input.LT(1);
    BinaryExpressionType type = BinaryExpressionType.Unknown;
    try
    {
      object obj1 = this.adaptor.Nil();
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._relationalExpressionNoIn_in_equalityExpressionNoIn4543);
      ES3Parser.relationalExpressionNoIn_return expressionNoInReturn2 = this.relationalExpressionNoIn();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj1, expressionNoInReturn2.Tree);
      expressionNoInReturn1.value = expressionNoInReturn2.value;
      while (true)
      {
        int num1 = 2;
        switch (((IIntStream) this.input).LA(1))
        {
          case 48 /*0x30*/:
          case 104:
          case 107:
          case 132:
            num1 = 1;
            break;
        }
        if (num1 == 1)
        {
          int num2;
          switch (((IIntStream) this.input).LA(1))
          {
            case 48 /*0x30*/:
              num2 = 1;
              break;
            case 104:
              num2 = 2;
              break;
            case 107:
              num2 = 4;
              break;
            case 132:
              num2 = 3;
              break;
            default:
              goto label_10;
          }
          switch (num2)
          {
            case 1:
              object obj2 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 48 /*0x30*/, ES3Parser.Follow._EQ_in_equalityExpressionNoIn4554));
              this.adaptor.AddChild(obj1, obj2);
              type = BinaryExpressionType.Equal;
              break;
            case 2:
              object obj3 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 104, ES3Parser.Follow._NEQ_in_equalityExpressionNoIn4562));
              this.adaptor.AddChild(obj1, obj3);
              type = BinaryExpressionType.NotEqual;
              break;
            case 3:
              object obj4 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 132, ES3Parser.Follow._SAME_in_equalityExpressionNoIn4570));
              this.adaptor.AddChild(obj1, obj4);
              type = BinaryExpressionType.Same;
              break;
            case 4:
              object obj5 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 107, ES3Parser.Follow._NSAME_in_equalityExpressionNoIn4578));
              this.adaptor.AddChild(obj1, obj5);
              type = BinaryExpressionType.NotSame;
              break;
          }
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._relationalExpressionNoIn_in_equalityExpressionNoIn4589);
          ES3Parser.relationalExpressionNoIn_return expressionNoInReturn3 = this.relationalExpressionNoIn();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj1, expressionNoInReturn3.Tree);
          expressionNoInReturn1.value = (Expression) new BinaryExpression(type, expressionNoInReturn1.value, expressionNoInReturn3.value);
        }
        else
          goto label_17;
      }
label_10:
      throw new NoViableAltException("", 39, 0, (IIntStream) this.input);
label_17:
      expressionNoInReturn1.Stop = this.input.LT(-1);
      expressionNoInReturn1.Tree = this.adaptor.RulePostProcessing(obj1);
      this.adaptor.SetTokenBoundaries(expressionNoInReturn1.Tree, expressionNoInReturn1.Start, expressionNoInReturn1.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      expressionNoInReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionNoInReturn1.Start, this.input.LT(-1), ex);
    }
    return expressionNoInReturn1;
  }

  [GrammarRule("bitwiseANDExpression")]
  private ES3Parser.bitwiseANDExpression_return bitwiseANDExpression()
  {
    ES3Parser.bitwiseANDExpression_return expressionReturn1 = new ES3Parser.bitwiseANDExpression_return(this);
    expressionReturn1.Start = this.input.LT(1);
    try
    {
      object obj = this.adaptor.Nil();
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._equalityExpression_in_bitwiseANDExpression4616);
      ES3Parser.equalityExpression_return expressionReturn2 = this.equalityExpression();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj, expressionReturn2.Tree);
      expressionReturn1.value = expressionReturn2.value;
      while (true)
      {
        int num = 2;
        if (((IIntStream) this.input).LA(1) == 7)
          num = 1;
        if (num == 1)
        {
          obj = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 7, ES3Parser.Follow._AND_in_bitwiseANDExpression4622)), obj);
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._equalityExpression_in_bitwiseANDExpression4627);
          ES3Parser.equalityExpression_return expressionReturn3 = this.equalityExpression();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj, expressionReturn3.Tree);
          expressionReturn1.value = (Expression) new BinaryExpression(BinaryExpressionType.BitwiseAnd, expressionReturn1.value, expressionReturn3.value);
        }
        else
          break;
      }
      expressionReturn1.Stop = this.input.LT(-1);
      expressionReturn1.Tree = this.adaptor.RulePostProcessing(obj);
      this.adaptor.SetTokenBoundaries(expressionReturn1.Tree, expressionReturn1.Start, expressionReturn1.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      expressionReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionReturn1.Start, this.input.LT(-1), ex);
    }
    return expressionReturn1;
  }

  [GrammarRule("bitwiseANDExpressionNoIn")]
  private ES3Parser.bitwiseANDExpressionNoIn_return bitwiseANDExpressionNoIn()
  {
    ES3Parser.bitwiseANDExpressionNoIn_return expressionNoInReturn1 = new ES3Parser.bitwiseANDExpressionNoIn_return(this);
    expressionNoInReturn1.Start = this.input.LT(1);
    try
    {
      object obj = this.adaptor.Nil();
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._equalityExpressionNoIn_in_bitwiseANDExpressionNoIn4648);
      ES3Parser.equalityExpressionNoIn_return expressionNoInReturn2 = this.equalityExpressionNoIn();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj, expressionNoInReturn2.Tree);
      expressionNoInReturn1.value = expressionNoInReturn2.value;
      while (true)
      {
        int num = 2;
        if (((IIntStream) this.input).LA(1) == 7)
          num = 1;
        if (num == 1)
        {
          obj = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 7, ES3Parser.Follow._AND_in_bitwiseANDExpressionNoIn4654)), obj);
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._equalityExpressionNoIn_in_bitwiseANDExpressionNoIn4659);
          ES3Parser.equalityExpressionNoIn_return expressionNoInReturn3 = this.equalityExpressionNoIn();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj, expressionNoInReturn3.Tree);
          expressionNoInReturn1.value = (Expression) new BinaryExpression(BinaryExpressionType.BitwiseAnd, expressionNoInReturn1.value, expressionNoInReturn3.value);
        }
        else
          break;
      }
      expressionNoInReturn1.Stop = this.input.LT(-1);
      expressionNoInReturn1.Tree = this.adaptor.RulePostProcessing(obj);
      this.adaptor.SetTokenBoundaries(expressionNoInReturn1.Tree, expressionNoInReturn1.Start, expressionNoInReturn1.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      expressionNoInReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionNoInReturn1.Start, this.input.LT(-1), ex);
    }
    return expressionNoInReturn1;
  }

  [GrammarRule("bitwiseXORExpression")]
  private ES3Parser.bitwiseXORExpression_return bitwiseXORExpression()
  {
    ES3Parser.bitwiseXORExpression_return expressionReturn1 = new ES3Parser.bitwiseXORExpression_return(this);
    expressionReturn1.Start = this.input.LT(1);
    try
    {
      object obj = this.adaptor.Nil();
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._bitwiseANDExpression_in_bitwiseXORExpression4682);
      ES3Parser.bitwiseANDExpression_return expressionReturn2 = this.bitwiseANDExpression();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj, expressionReturn2.Tree);
      expressionReturn1.value = expressionReturn2.value;
      while (true)
      {
        int num = 2;
        if (((IIntStream) this.input).LA(1) == 168)
          num = 1;
        if (num == 1)
        {
          obj = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 168, ES3Parser.Follow._XOR_in_bitwiseXORExpression4688)), obj);
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._bitwiseANDExpression_in_bitwiseXORExpression4693);
          ES3Parser.bitwiseANDExpression_return expressionReturn3 = this.bitwiseANDExpression();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj, expressionReturn3.Tree);
          expressionReturn1.value = (Expression) new BinaryExpression(BinaryExpressionType.BitwiseXOr, expressionReturn1.value, expressionReturn3.value);
        }
        else
          break;
      }
      expressionReturn1.Stop = this.input.LT(-1);
      expressionReturn1.Tree = this.adaptor.RulePostProcessing(obj);
      this.adaptor.SetTokenBoundaries(expressionReturn1.Tree, expressionReturn1.Start, expressionReturn1.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      expressionReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionReturn1.Start, this.input.LT(-1), ex);
    }
    return expressionReturn1;
  }

  [GrammarRule("bitwiseXORExpressionNoIn")]
  private ES3Parser.bitwiseXORExpressionNoIn_return bitwiseXORExpressionNoIn()
  {
    ES3Parser.bitwiseXORExpressionNoIn_return expressionNoInReturn1 = new ES3Parser.bitwiseXORExpressionNoIn_return(this);
    expressionNoInReturn1.Start = this.input.LT(1);
    try
    {
      object obj = this.adaptor.Nil();
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._bitwiseANDExpressionNoIn_in_bitwiseXORExpressionNoIn4716);
      ES3Parser.bitwiseANDExpressionNoIn_return expressionNoInReturn2 = this.bitwiseANDExpressionNoIn();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj, expressionNoInReturn2.Tree);
      expressionNoInReturn1.value = expressionNoInReturn2.value;
      while (true)
      {
        int num = 2;
        if (((IIntStream) this.input).LA(1) == 168)
          num = 1;
        if (num == 1)
        {
          obj = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 168, ES3Parser.Follow._XOR_in_bitwiseXORExpressionNoIn4722)), obj);
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._bitwiseANDExpressionNoIn_in_bitwiseXORExpressionNoIn4727);
          ES3Parser.bitwiseANDExpressionNoIn_return expressionNoInReturn3 = this.bitwiseANDExpressionNoIn();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj, expressionNoInReturn3.Tree);
          expressionNoInReturn1.value = (Expression) new BinaryExpression(BinaryExpressionType.BitwiseXOr, expressionNoInReturn1.value, expressionNoInReturn3.value);
        }
        else
          break;
      }
      expressionNoInReturn1.Stop = this.input.LT(-1);
      expressionNoInReturn1.Tree = this.adaptor.RulePostProcessing(obj);
      this.adaptor.SetTokenBoundaries(expressionNoInReturn1.Tree, expressionNoInReturn1.Start, expressionNoInReturn1.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      expressionNoInReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionNoInReturn1.Start, this.input.LT(-1), ex);
    }
    return expressionNoInReturn1;
  }

  [GrammarRule("bitwiseORExpression")]
  private ES3Parser.bitwiseORExpression_return bitwiseORExpression()
  {
    ES3Parser.bitwiseORExpression_return expressionReturn1 = new ES3Parser.bitwiseORExpression_return(this);
    expressionReturn1.Start = this.input.LT(1);
    try
    {
      object obj = this.adaptor.Nil();
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._bitwiseXORExpression_in_bitwiseORExpression4749);
      ES3Parser.bitwiseXORExpression_return expressionReturn2 = this.bitwiseXORExpression();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj, expressionReturn2.Tree);
      expressionReturn1.value = expressionReturn2.value;
      while (true)
      {
        int num = 2;
        if (((IIntStream) this.input).LA(1) == 110)
          num = 1;
        if (num == 1)
        {
          obj = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 110, ES3Parser.Follow._OR_in_bitwiseORExpression4755)), obj);
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._bitwiseXORExpression_in_bitwiseORExpression4760);
          ES3Parser.bitwiseXORExpression_return expressionReturn3 = this.bitwiseXORExpression();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj, expressionReturn3.Tree);
          expressionReturn1.value = (Expression) new BinaryExpression(BinaryExpressionType.BitwiseOr, expressionReturn1.value, expressionReturn3.value);
        }
        else
          break;
      }
      expressionReturn1.Stop = this.input.LT(-1);
      expressionReturn1.Tree = this.adaptor.RulePostProcessing(obj);
      this.adaptor.SetTokenBoundaries(expressionReturn1.Tree, expressionReturn1.Start, expressionReturn1.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      expressionReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionReturn1.Start, this.input.LT(-1), ex);
    }
    return expressionReturn1;
  }

  [GrammarRule("bitwiseORExpressionNoIn")]
  private ES3Parser.bitwiseORExpressionNoIn_return bitwiseORExpressionNoIn()
  {
    ES3Parser.bitwiseORExpressionNoIn_return expressionNoInReturn1 = new ES3Parser.bitwiseORExpressionNoIn_return(this);
    expressionNoInReturn1.Start = this.input.LT(1);
    try
    {
      object obj = this.adaptor.Nil();
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._bitwiseXORExpressionNoIn_in_bitwiseORExpressionNoIn4782);
      ES3Parser.bitwiseXORExpressionNoIn_return expressionNoInReturn2 = this.bitwiseXORExpressionNoIn();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj, expressionNoInReturn2.Tree);
      expressionNoInReturn1.value = expressionNoInReturn2.value;
      while (true)
      {
        int num = 2;
        if (((IIntStream) this.input).LA(1) == 110)
          num = 1;
        if (num == 1)
        {
          obj = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 110, ES3Parser.Follow._OR_in_bitwiseORExpressionNoIn4788)), obj);
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._bitwiseXORExpressionNoIn_in_bitwiseORExpressionNoIn4793);
          ES3Parser.bitwiseXORExpressionNoIn_return expressionNoInReturn3 = this.bitwiseXORExpressionNoIn();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj, expressionNoInReturn3.Tree);
          expressionNoInReturn1.value = (Expression) new BinaryExpression(BinaryExpressionType.BitwiseOr, expressionNoInReturn1.value, expressionNoInReturn3.value);
        }
        else
          break;
      }
      expressionNoInReturn1.Stop = this.input.LT(-1);
      expressionNoInReturn1.Tree = this.adaptor.RulePostProcessing(obj);
      this.adaptor.SetTokenBoundaries(expressionNoInReturn1.Tree, expressionNoInReturn1.Start, expressionNoInReturn1.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      expressionNoInReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionNoInReturn1.Start, this.input.LT(-1), ex);
    }
    return expressionNoInReturn1;
  }

  [GrammarRule("logicalANDExpression")]
  private ES3Parser.logicalANDExpression_return logicalANDExpression()
  {
    ES3Parser.logicalANDExpression_return expressionReturn1 = new ES3Parser.logicalANDExpression_return(this);
    expressionReturn1.Start = this.input.LT(1);
    try
    {
      object obj = this.adaptor.Nil();
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._bitwiseORExpression_in_logicalANDExpression4819);
      ES3Parser.bitwiseORExpression_return expressionReturn2 = this.bitwiseORExpression();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj, expressionReturn2.Tree);
      expressionReturn1.value = expressionReturn2.value;
      while (true)
      {
        int num = 2;
        if (((IIntStream) this.input).LA(1) == 84)
          num = 1;
        if (num == 1)
        {
          obj = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 84, ES3Parser.Follow._LAND_in_logicalANDExpression4825)), obj);
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._bitwiseORExpression_in_logicalANDExpression4830);
          ES3Parser.bitwiseORExpression_return expressionReturn3 = this.bitwiseORExpression();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj, expressionReturn3.Tree);
          expressionReturn1.value = (Expression) new BinaryExpression(BinaryExpressionType.And, expressionReturn1.value, expressionReturn3.value);
        }
        else
          break;
      }
      expressionReturn1.Stop = this.input.LT(-1);
      expressionReturn1.Tree = this.adaptor.RulePostProcessing(obj);
      this.adaptor.SetTokenBoundaries(expressionReturn1.Tree, expressionReturn1.Start, expressionReturn1.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      expressionReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionReturn1.Start, this.input.LT(-1), ex);
    }
    return expressionReturn1;
  }

  [GrammarRule("logicalANDExpressionNoIn")]
  private ES3Parser.logicalANDExpressionNoIn_return logicalANDExpressionNoIn()
  {
    ES3Parser.logicalANDExpressionNoIn_return expressionNoInReturn1 = new ES3Parser.logicalANDExpressionNoIn_return(this);
    expressionNoInReturn1.Start = this.input.LT(1);
    try
    {
      object obj = this.adaptor.Nil();
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._bitwiseORExpressionNoIn_in_logicalANDExpressionNoIn4851);
      ES3Parser.bitwiseORExpressionNoIn_return expressionNoInReturn2 = this.bitwiseORExpressionNoIn();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj, expressionNoInReturn2.Tree);
      expressionNoInReturn1.value = expressionNoInReturn2.value;
      while (true)
      {
        int num = 2;
        if (((IIntStream) this.input).LA(1) == 84)
          num = 1;
        if (num == 1)
        {
          obj = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 84, ES3Parser.Follow._LAND_in_logicalANDExpressionNoIn4857)), obj);
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._bitwiseORExpressionNoIn_in_logicalANDExpressionNoIn4862);
          ES3Parser.bitwiseORExpressionNoIn_return expressionNoInReturn3 = this.bitwiseORExpressionNoIn();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj, expressionNoInReturn3.Tree);
          expressionNoInReturn1.value = (Expression) new BinaryExpression(BinaryExpressionType.And, expressionNoInReturn1.value, expressionNoInReturn3.value);
        }
        else
          break;
      }
      expressionNoInReturn1.Stop = this.input.LT(-1);
      expressionNoInReturn1.Tree = this.adaptor.RulePostProcessing(obj);
      this.adaptor.SetTokenBoundaries(expressionNoInReturn1.Tree, expressionNoInReturn1.Start, expressionNoInReturn1.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      expressionNoInReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionNoInReturn1.Start, this.input.LT(-1), ex);
    }
    return expressionNoInReturn1;
  }

  [GrammarRule("logicalORExpression")]
  private ES3Parser.logicalORExpression_return logicalORExpression()
  {
    ES3Parser.logicalORExpression_return expressionReturn1 = new ES3Parser.logicalORExpression_return(this);
    expressionReturn1.Start = this.input.LT(1);
    try
    {
      object obj = this.adaptor.Nil();
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._logicalANDExpression_in_logicalORExpression4884);
      ES3Parser.logicalANDExpression_return expressionReturn2 = this.logicalANDExpression();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj, expressionReturn2.Tree);
      expressionReturn1.value = expressionReturn2.value;
      while (true)
      {
        int num = 2;
        if (((IIntStream) this.input).LA(1) == 89)
          num = 1;
        if (num == 1)
        {
          obj = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 89, ES3Parser.Follow._LOR_in_logicalORExpression4890)), obj);
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._logicalANDExpression_in_logicalORExpression4895);
          ES3Parser.logicalANDExpression_return expressionReturn3 = this.logicalANDExpression();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj, expressionReturn3.Tree);
          expressionReturn1.value = (Expression) new BinaryExpression(BinaryExpressionType.Or, expressionReturn1.value, expressionReturn3.value);
        }
        else
          break;
      }
      expressionReturn1.Stop = this.input.LT(-1);
      expressionReturn1.Tree = this.adaptor.RulePostProcessing(obj);
      this.adaptor.SetTokenBoundaries(expressionReturn1.Tree, expressionReturn1.Start, expressionReturn1.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      expressionReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionReturn1.Start, this.input.LT(-1), ex);
    }
    return expressionReturn1;
  }

  [GrammarRule("logicalORExpressionNoIn")]
  private ES3Parser.logicalORExpressionNoIn_return logicalORExpressionNoIn()
  {
    ES3Parser.logicalORExpressionNoIn_return expressionNoInReturn1 = new ES3Parser.logicalORExpressionNoIn_return(this);
    expressionNoInReturn1.Start = this.input.LT(1);
    try
    {
      object obj = this.adaptor.Nil();
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._logicalANDExpressionNoIn_in_logicalORExpressionNoIn4917);
      ES3Parser.logicalANDExpressionNoIn_return expressionNoInReturn2 = this.logicalANDExpressionNoIn();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj, expressionNoInReturn2.Tree);
      expressionNoInReturn1.value = expressionNoInReturn2.value;
      while (true)
      {
        int num = 2;
        if (((IIntStream) this.input).LA(1) == 89)
          num = 1;
        if (num == 1)
        {
          obj = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 89, ES3Parser.Follow._LOR_in_logicalORExpressionNoIn4923)), obj);
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._logicalANDExpressionNoIn_in_logicalORExpressionNoIn4928);
          ES3Parser.logicalANDExpressionNoIn_return expressionNoInReturn3 = this.logicalANDExpressionNoIn();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj, expressionNoInReturn3.Tree);
          expressionNoInReturn1.value = (Expression) new BinaryExpression(BinaryExpressionType.Or, expressionNoInReturn1.value, expressionNoInReturn3.value);
        }
        else
          break;
      }
      expressionNoInReturn1.Stop = this.input.LT(-1);
      expressionNoInReturn1.Tree = this.adaptor.RulePostProcessing(obj);
      this.adaptor.SetTokenBoundaries(expressionNoInReturn1.Tree, expressionNoInReturn1.Start, expressionNoInReturn1.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      expressionNoInReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionNoInReturn1.Start, this.input.LT(-1), ex);
    }
    return expressionNoInReturn1;
  }

  [GrammarRule("conditionalExpression")]
  private ES3Parser.conditionalExpression_return conditionalExpression()
  {
    ES3Parser.conditionalExpression_return expressionReturn1 = new ES3Parser.conditionalExpression_return(this);
    expressionReturn1.Start = this.input.LT(1);
    try
    {
      object obj = this.adaptor.Nil();
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._logicalORExpression_in_conditionalExpression4955);
      ES3Parser.logicalORExpression_return expressionReturn2 = this.logicalORExpression();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj, expressionReturn2.Tree);
      expressionReturn1.value = expressionReturn2.value;
      int num = 2;
      if (((IIntStream) this.input).LA(1) == 124)
        num = 1;
      if (num == 1)
      {
        obj = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 124, ES3Parser.Follow._QUE_in_conditionalExpression4961)), obj);
        ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._assignmentExpression_in_conditionalExpression4966);
        ES3Parser.assignmentExpression_return expressionReturn3 = this.assignmentExpression();
        ((BaseRecognizer) this).PopFollow();
        this.adaptor.AddChild(obj, expressionReturn3.Tree);
        IToken itoken = (IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 26, ES3Parser.Follow._COLON_in_conditionalExpression4968);
        ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._assignmentExpression_in_conditionalExpression4973);
        ES3Parser.assignmentExpression_return expressionReturn4 = this.assignmentExpression();
        ((BaseRecognizer) this).PopFollow();
        this.adaptor.AddChild(obj, expressionReturn4.Tree);
        expressionReturn1.value = (Expression) new TernaryExpression(expressionReturn2.value, expressionReturn3.value, expressionReturn4.value);
      }
      expressionReturn1.Stop = this.input.LT(-1);
      expressionReturn1.Tree = this.adaptor.RulePostProcessing(obj);
      this.adaptor.SetTokenBoundaries(expressionReturn1.Tree, expressionReturn1.Start, expressionReturn1.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      expressionReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionReturn1.Start, this.input.LT(-1), ex);
    }
    return expressionReturn1;
  }

  [GrammarRule("conditionalExpressionNoIn")]
  private ES3Parser.conditionalExpressionNoIn_return conditionalExpressionNoIn()
  {
    ES3Parser.conditionalExpressionNoIn_return expressionNoInReturn1 = new ES3Parser.conditionalExpressionNoIn_return(this);
    expressionNoInReturn1.Start = this.input.LT(1);
    try
    {
      object obj = this.adaptor.Nil();
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._logicalORExpressionNoIn_in_conditionalExpressionNoIn4994);
      ES3Parser.logicalORExpressionNoIn_return expressionNoInReturn2 = this.logicalORExpressionNoIn();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj, expressionNoInReturn2.Tree);
      expressionNoInReturn1.value = expressionNoInReturn2.value;
      int num = 2;
      if (((IIntStream) this.input).LA(1) == 124)
        num = 1;
      if (num == 1)
      {
        obj = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 124, ES3Parser.Follow._QUE_in_conditionalExpressionNoIn5000)), obj);
        ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._assignmentExpressionNoIn_in_conditionalExpressionNoIn5005);
        ES3Parser.assignmentExpressionNoIn_return expressionNoInReturn3 = this.assignmentExpressionNoIn();
        ((BaseRecognizer) this).PopFollow();
        this.adaptor.AddChild(obj, expressionNoInReturn3.Tree);
        IToken itoken = (IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 26, ES3Parser.Follow._COLON_in_conditionalExpressionNoIn5007);
        ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._assignmentExpressionNoIn_in_conditionalExpressionNoIn5012);
        ES3Parser.assignmentExpressionNoIn_return expressionNoInReturn4 = this.assignmentExpressionNoIn();
        ((BaseRecognizer) this).PopFollow();
        this.adaptor.AddChild(obj, expressionNoInReturn4.Tree);
        expressionNoInReturn1.value = (Expression) new TernaryExpression(expressionNoInReturn2.value, expressionNoInReturn3.value, expressionNoInReturn4.value);
      }
      expressionNoInReturn1.Stop = this.input.LT(-1);
      expressionNoInReturn1.Tree = this.adaptor.RulePostProcessing(obj);
      this.adaptor.SetTokenBoundaries(expressionNoInReturn1.Tree, expressionNoInReturn1.Start, expressionNoInReturn1.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      expressionNoInReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionNoInReturn1.Start, this.input.LT(-1), ex);
    }
    return expressionNoInReturn1;
  }

  [GrammarRule("assignmentExpression")]
  private ES3Parser.assignmentExpression_return assignmentExpression()
  {
    ES3Parser.assignmentExpression_return expressionReturn1 = new ES3Parser.assignmentExpression_return(this);
    expressionReturn1.Start = this.input.LT(1);
    object[] cached = new object[1];
    AssignmentExpression assignmentExpression = new AssignmentExpression();
    try
    {
      object obj = this.adaptor.Nil();
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._conditionalExpression_in_assignmentExpression5045);
      ES3Parser.conditionalExpression_return expressionReturn2 = this.conditionalExpression();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj, expressionReturn2.Tree);
      expressionReturn1.value = assignmentExpression.Left = expressionReturn2.value;
      int num = 2;
      switch (((IIntStream) this.input).LA(1))
      {
        case 6:
        case 8:
        case 11:
        case 37:
        case 96 /*0x60*/:
        case 98:
        case 111:
        case 135:
        case 138:
        case 140:
        case 145:
        case 169:
          ((IIntStream) this.input).LA(2);
          if (this.IsLeftHandSideAssign(expressionReturn2.value, cached))
          {
            num = 1;
            break;
          }
          break;
      }
      if (num == 1)
      {
        if (!this.IsLeftHandSideAssign(expressionReturn2.value, cached))
          throw new FailedPredicateException((IIntStream) this.input, nameof (assignmentExpression), " IsLeftHandSideAssign(lhs.value, isLhs) ");
        ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._assignmentOperator_in_assignmentExpression5057);
        ES3Parser.assignmentOperator_return assignmentOperatorReturn = this.assignmentOperator();
        ((BaseRecognizer) this).PopFollow();
        obj = this.adaptor.BecomeRoot(assignmentOperatorReturn.Tree, obj);
        assignmentExpression.AssignmentOperator = this.ResolveAssignmentOperator(assignmentOperatorReturn != null ? this.input.ToString(assignmentOperatorReturn.Start, assignmentOperatorReturn.Stop) : (string) null);
        ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._assignmentExpression_in_assignmentExpression5064);
        ES3Parser.assignmentExpression_return expressionReturn3 = this.assignmentExpression();
        ((BaseRecognizer) this).PopFollow();
        this.adaptor.AddChild(obj, expressionReturn3.Tree);
        assignmentExpression.Right = expressionReturn3.value;
        expressionReturn1.value = (Expression) assignmentExpression;
      }
      expressionReturn1.Stop = this.input.LT(-1);
      expressionReturn1.Tree = this.adaptor.RulePostProcessing(obj);
      this.adaptor.SetTokenBoundaries(expressionReturn1.Tree, expressionReturn1.Start, expressionReturn1.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      expressionReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionReturn1.Start, this.input.LT(-1), ex);
    }
    return expressionReturn1;
  }

  [GrammarRule("assignmentOperator")]
  private ES3Parser.assignmentOperator_return assignmentOperator()
  {
    ES3Parser.assignmentOperator_return assignmentOperatorReturn = new ES3Parser.assignmentOperator_return(this);
    assignmentOperatorReturn.Start = this.input.LT(1);
    try
    {
      object obj = this.adaptor.Nil();
      IToken itoken = this.input.LT(1);
      if (((IIntStream) this.input).LA(1) != 6 && ((IIntStream) this.input).LA(1) != 8 && ((IIntStream) this.input).LA(1) != 11 && ((IIntStream) this.input).LA(1) != 37 && ((IIntStream) this.input).LA(1) != 96 /*0x60*/ && ((IIntStream) this.input).LA(1) != 98 && ((IIntStream) this.input).LA(1) != 111 && ((IIntStream) this.input).LA(1) != 135 && ((IIntStream) this.input).LA(1) != 138 && ((IIntStream) this.input).LA(1) != 140 && ((IIntStream) this.input).LA(1) != 145 && ((IIntStream) this.input).LA(1) != 169)
        throw new MismatchedSetException((BitSet) null, (IIntStream) this.input);
      ((IIntStream) this.input).Consume();
      this.adaptor.AddChild(obj, this.adaptor.Create(itoken));
      ((BaseRecognizer) this).state.errorRecovery = false;
      assignmentOperatorReturn.Stop = this.input.LT(-1);
      assignmentOperatorReturn.Tree = this.adaptor.RulePostProcessing(obj);
      this.adaptor.SetTokenBoundaries(assignmentOperatorReturn.Tree, assignmentOperatorReturn.Start, assignmentOperatorReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      assignmentOperatorReturn.Tree = this.adaptor.ErrorNode(this.input, assignmentOperatorReturn.Start, this.input.LT(-1), ex);
    }
    return assignmentOperatorReturn;
  }

  [GrammarRule("assignmentExpressionNoIn")]
  private ES3Parser.assignmentExpressionNoIn_return assignmentExpressionNoIn()
  {
    ES3Parser.assignmentExpressionNoIn_return expressionNoInReturn1 = new ES3Parser.assignmentExpressionNoIn_return(this);
    expressionNoInReturn1.Start = this.input.LT(1);
    object[] cached = new object[1];
    AssignmentExpression assignmentExpression = new AssignmentExpression();
    try
    {
      object obj = this.adaptor.Nil();
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._conditionalExpressionNoIn_in_assignmentExpressionNoIn5159);
      ES3Parser.conditionalExpressionNoIn_return expressionNoInReturn2 = this.conditionalExpressionNoIn();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj, expressionNoInReturn2.Tree);
      assignmentExpression.Left = expressionNoInReturn1.value = expressionNoInReturn2?.value;
      int num = 2;
      switch (((IIntStream) this.input).LA(1))
      {
        case 6:
        case 8:
        case 11:
        case 37:
        case 96 /*0x60*/:
        case 98:
        case 111:
        case 135:
        case 138:
        case 140:
        case 145:
        case 169:
          ((IIntStream) this.input).LA(2);
          if (this.IsLeftHandSideAssign(expressionNoInReturn2.value, cached))
          {
            num = 1;
            break;
          }
          break;
      }
      if (num == 1)
      {
        if (!this.IsLeftHandSideAssign(expressionNoInReturn2.value, cached))
          throw new FailedPredicateException((IIntStream) this.input, nameof (assignmentExpressionNoIn), " IsLeftHandSideAssign(lhs.value, isLhs) ");
        ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._assignmentOperator_in_assignmentExpressionNoIn5171);
        ES3Parser.assignmentOperator_return assignmentOperatorReturn = this.assignmentOperator();
        ((BaseRecognizer) this).PopFollow();
        obj = this.adaptor.BecomeRoot(assignmentOperatorReturn.Tree, obj);
        assignmentExpression.AssignmentOperator = this.ResolveAssignmentOperator(assignmentOperatorReturn != null ? this.input.ToString(assignmentOperatorReturn.Start, assignmentOperatorReturn.Stop) : (string) null);
        ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._assignmentExpressionNoIn_in_assignmentExpressionNoIn5178);
        ES3Parser.assignmentExpressionNoIn_return expressionNoInReturn3 = this.assignmentExpressionNoIn();
        ((BaseRecognizer) this).PopFollow();
        this.adaptor.AddChild(obj, expressionNoInReturn3.Tree);
        assignmentExpression.Right = expressionNoInReturn3.value;
        expressionNoInReturn1.value = (Expression) assignmentExpression;
      }
      expressionNoInReturn1.Stop = this.input.LT(-1);
      expressionNoInReturn1.Tree = this.adaptor.RulePostProcessing(obj);
      this.adaptor.SetTokenBoundaries(expressionNoInReturn1.Tree, expressionNoInReturn1.Start, expressionNoInReturn1.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      expressionNoInReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionNoInReturn1.Start, this.input.LT(-1), ex);
    }
    return expressionNoInReturn1;
  }

  [GrammarRule("expression")]
  private ES3Parser.expression_return expression()
  {
    ES3Parser.expression_return expressionReturn1 = new ES3Parser.expression_return(this);
    expressionReturn1.Start = this.input.LT(1);
    CommaOperatorStatement operatorStatement = new CommaOperatorStatement();
    try
    {
      object obj1 = this.adaptor.Nil();
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._assignmentExpression_in_expression5210);
      ES3Parser.assignmentExpression_return expressionReturn2 = this.assignmentExpression();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj1, expressionReturn2.Tree);
      expressionReturn1.value = expressionReturn2.value;
      while (true)
      {
        int num = 2;
        if (((IIntStream) this.input).LA(1) == 27)
          num = 1;
        if (num == 1)
        {
          object obj2 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 27, ES3Parser.Follow._COMMA_in_expression5216));
          this.adaptor.AddChild(obj1, obj2);
          if (operatorStatement.Statements.Count == 0)
          {
            operatorStatement.Statements.Add((Statement) expressionReturn1.value);
            expressionReturn1.value = (Expression) operatorStatement;
          }
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._assignmentExpression_in_expression5222);
          ES3Parser.assignmentExpression_return expressionReturn3 = this.assignmentExpression();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj1, expressionReturn3.Tree);
          operatorStatement.Statements.Add((Statement) expressionReturn3.value);
        }
        else
          break;
      }
      expressionReturn1.Stop = this.input.LT(-1);
      expressionReturn1.Tree = this.adaptor.RulePostProcessing(obj1);
      this.adaptor.SetTokenBoundaries(expressionReturn1.Tree, expressionReturn1.Start, expressionReturn1.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      expressionReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionReturn1.Start, this.input.LT(-1), ex);
    }
    return expressionReturn1;
  }

  [GrammarRule("expressionNoIn")]
  private ES3Parser.expressionNoIn_return expressionNoIn()
  {
    ES3Parser.expressionNoIn_return expressionNoInReturn1 = new ES3Parser.expressionNoIn_return(this);
    expressionNoInReturn1.Start = this.input.LT(1);
    CommaOperatorStatement operatorStatement = new CommaOperatorStatement();
    try
    {
      object obj1 = this.adaptor.Nil();
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._assignmentExpressionNoIn_in_expressionNoIn5250);
      ES3Parser.assignmentExpressionNoIn_return expressionNoInReturn2 = this.assignmentExpressionNoIn();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj1, expressionNoInReturn2.Tree);
      expressionNoInReturn1.value = expressionNoInReturn2.value;
      while (true)
      {
        int num = 2;
        if (((IIntStream) this.input).LA(1) == 27)
          num = 1;
        if (num == 1)
        {
          object obj2 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 27, ES3Parser.Follow._COMMA_in_expressionNoIn5256));
          this.adaptor.AddChild(obj1, obj2);
          if (operatorStatement.Statements.Count == 0)
          {
            operatorStatement.Statements.Add((Statement) expressionNoInReturn1.value);
            expressionNoInReturn1.value = (Expression) operatorStatement;
          }
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._assignmentExpressionNoIn_in_expressionNoIn5262);
          ES3Parser.assignmentExpressionNoIn_return expressionNoInReturn3 = this.assignmentExpressionNoIn();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj1, expressionNoInReturn3.Tree);
          operatorStatement.Statements.Add((Statement) expressionNoInReturn3.value);
        }
        else
          break;
      }
      expressionNoInReturn1.Stop = this.input.LT(-1);
      expressionNoInReturn1.Tree = this.adaptor.RulePostProcessing(obj1);
      this.adaptor.SetTokenBoundaries(expressionNoInReturn1.Tree, expressionNoInReturn1.Start, expressionNoInReturn1.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      expressionNoInReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionNoInReturn1.Start, this.input.LT(-1), ex);
    }
    return expressionNoInReturn1;
  }

  [GrammarRule("semic")]
  private ES3Parser.semic_return semic()
  {
    ES3Parser.semic_return rule = new ES3Parser.semic_return(this);
    rule.Start = this.input.LT(1);
    object obj1 = (object) null;
    int num1 = ((IIntStream) this.input).Mark();
    this.PromoteEOL((ParserRuleReturnScope<IToken>) rule);
    try
    {
      int num2;
      switch (((IIntStream) this.input).LA(1))
      {
        case -1:
          num2 = 2;
          break;
        case 47:
          num2 = 4;
          break;
        case 99:
          num2 = 5;
          break;
        case 125:
          num2 = 3;
          break;
        case 133:
          num2 = 1;
          break;
        default:
          throw new NoViableAltException("", 57, 0, (IIntStream) this.input);
      }
      switch (num2)
      {
        case 1:
          obj1 = this.adaptor.Nil();
          object obj2 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 133, ES3Parser.Follow._SEMIC_in_semic5296));
          this.adaptor.AddChild(obj1, obj2);
          break;
        case 2:
          obj1 = this.adaptor.Nil();
          object obj3 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, -1, ES3Parser.Follow._EOF_in_semic5301));
          this.adaptor.AddChild(obj1, obj3);
          break;
        case 3:
          obj1 = this.adaptor.Nil();
          object obj4 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 125, ES3Parser.Follow._RBRACE_in_semic5306));
          this.adaptor.AddChild(obj1, obj4);
          ((IIntStream) this.input).Rewind(num1);
          break;
        case 4:
          obj1 = this.adaptor.Nil();
          object obj5 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 47, ES3Parser.Follow._EOL_in_semic5313));
          this.adaptor.AddChild(obj1, obj5);
          break;
        case 5:
          obj1 = this.adaptor.Nil();
          object obj6 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 99, ES3Parser.Follow._MultiLineComment_in_semic5317));
          this.adaptor.AddChild(obj1, obj6);
          break;
      }
      rule.Stop = this.input.LT(-1);
      rule.Tree = this.adaptor.RulePostProcessing(obj1);
      this.adaptor.SetTokenBoundaries(rule.Tree, rule.Start, rule.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      rule.Tree = this.adaptor.ErrorNode(this.input, rule.Start, this.input.LT(-1), ex);
    }
    return rule;
  }

  [GrammarRule("statement")]
  private ES3Parser.statement_return statement()
  {
    ES3Parser.statement_return statementReturn = new ES3Parser.statement_return(this);
    statementReturn.Start = this.input.LT(1);
    object obj = (object) null;
    try
    {
      int num;
      try
      {
        num = this.dfa58.Predict((IIntStream) this.input);
      }
      catch (NoViableAltException ex)
      {
        throw;
      }
      switch (num)
      {
        case 1:
          obj = this.adaptor.Nil();
          if (((IIntStream) this.input).LA(1) != 85)
            throw new FailedPredicateException((IIntStream) this.input, nameof (statement), " input.LA(1) == LBRACE ");
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._block_in_statement5351);
          ES3Parser.block_return blockReturn = this.block();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj, blockReturn.Tree);
          statementReturn.value = (Statement) blockReturn?.value;
          break;
        case 2:
          obj = this.adaptor.Nil();
          if (((IIntStream) this.input).LA(1) != 62)
            throw new FailedPredicateException((IIntStream) this.input, nameof (statement), " input.LA(1) == FUNCTION ");
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._functionDeclaration_in_statement5362);
          ES3Parser.functionDeclaration_return declarationReturn = this.functionDeclaration();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj, declarationReturn.Tree);
          statementReturn.value = declarationReturn.value;
          break;
        case 3:
          obj = this.adaptor.Nil();
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._statementTail_in_statement5369);
          ES3Parser.statementTail_return statementTailReturn = this.statementTail();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj, statementTailReturn.Tree);
          statementReturn.value = statementTailReturn?.value;
          break;
      }
      statementReturn.Stop = this.input.LT(-1);
      statementReturn.Tree = this.adaptor.RulePostProcessing(obj);
      this.adaptor.SetTokenBoundaries(statementReturn.Tree, statementReturn.Start, statementReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      statementReturn.Tree = this.adaptor.ErrorNode(this.input, statementReturn.Start, this.input.LT(-1), ex);
    }
    return statementReturn;
  }

  [GrammarRule("statementTail")]
  private ES3Parser.statementTail_return statementTail()
  {
    ES3Parser.statementTail_return statementTailReturn = new ES3Parser.statementTail_return(this);
    statementTailReturn.Start = this.input.LT(1);
    object obj = (object) null;
    try
    {
      int num;
      try
      {
        num = this.dfa59.Predict((IIntStream) this.input);
      }
      catch (NoViableAltException ex)
      {
        throw;
      }
      switch (num)
      {
        case 1:
          obj = this.adaptor.Nil();
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._variableStatement_in_statementTail5392);
          ES3Parser.variableStatement_return variableStatementReturn = this.variableStatement();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj, variableStatementReturn.Tree);
          statementTailReturn.value = variableStatementReturn?.value;
          break;
        case 2:
          obj = this.adaptor.Nil();
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._emptyStatement_in_statementTail5399);
          ES3Parser.emptyStatement_return emptyStatementReturn = this.emptyStatement();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj, emptyStatementReturn.Tree);
          statementTailReturn.value = emptyStatementReturn?.value;
          break;
        case 3:
          obj = this.adaptor.Nil();
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._expressionStatement_in_statementTail5406);
          ES3Parser.expressionStatement_return expressionStatementReturn = this.expressionStatement();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj, expressionStatementReturn.Tree);
          statementTailReturn.value = expressionStatementReturn?.value;
          break;
        case 4:
          obj = this.adaptor.Nil();
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._ifStatement_in_statementTail5413);
          ES3Parser.ifStatement_return ifStatementReturn = this.ifStatement();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj, ifStatementReturn.Tree);
          statementTailReturn.value = ifStatementReturn?.value;
          break;
        case 5:
          obj = this.adaptor.Nil();
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._iterationStatement_in_statementTail5420);
          ES3Parser.iterationStatement_return iterationStatementReturn = this.iterationStatement();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj, iterationStatementReturn.Tree);
          statementTailReturn.value = iterationStatementReturn?.value;
          break;
        case 6:
          obj = this.adaptor.Nil();
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._continueStatement_in_statementTail5427);
          ES3Parser.continueStatement_return continueStatementReturn = this.continueStatement();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj, continueStatementReturn.Tree);
          statementTailReturn.value = continueStatementReturn?.value;
          break;
        case 7:
          obj = this.adaptor.Nil();
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._breakStatement_in_statementTail5434);
          ES3Parser.breakStatement_return breakStatementReturn = this.breakStatement();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj, breakStatementReturn.Tree);
          statementTailReturn.value = breakStatementReturn?.value;
          break;
        case 8:
          obj = this.adaptor.Nil();
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._returnStatement_in_statementTail5441);
          ES3Parser.returnStatement_return returnStatementReturn = this.returnStatement();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj, returnStatementReturn.Tree);
          statementTailReturn.value = (Statement) returnStatementReturn?.value;
          break;
        case 9:
          obj = this.adaptor.Nil();
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._withStatement_in_statementTail5448);
          ES3Parser.withStatement_return withStatementReturn = this.withStatement();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj, withStatementReturn.Tree);
          statementTailReturn.value = withStatementReturn?.value;
          break;
        case 10:
          obj = this.adaptor.Nil();
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._labelledStatement_in_statementTail5455);
          ES3Parser.labelledStatement_return labelledStatementReturn = this.labelledStatement();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj, labelledStatementReturn.Tree);
          statementTailReturn.value = labelledStatementReturn?.value;
          break;
        case 11:
          obj = this.adaptor.Nil();
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._switchStatement_in_statementTail5462);
          ES3Parser.switchStatement_return switchStatementReturn = this.switchStatement();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj, switchStatementReturn.Tree);
          statementTailReturn.value = switchStatementReturn?.value;
          break;
        case 12:
          obj = this.adaptor.Nil();
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._throwStatement_in_statementTail5469);
          ES3Parser.throwStatement_return throwStatementReturn = this.throwStatement();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj, throwStatementReturn.Tree);
          statementTailReturn.value = throwStatementReturn?.value;
          break;
        case 13:
          obj = this.adaptor.Nil();
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._tryStatement_in_statementTail5476);
          ES3Parser.tryStatement_return tryStatementReturn = this.tryStatement();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj, tryStatementReturn.Tree);
          statementTailReturn.value = (Statement) tryStatementReturn?.value;
          break;
      }
      statementTailReturn.Stop = this.input.LT(-1);
      statementTailReturn.Tree = this.adaptor.RulePostProcessing(obj);
      this.adaptor.SetTokenBoundaries(statementTailReturn.Tree, statementTailReturn.Start, statementTailReturn.Stop);
      if (!(statementTailReturn.value is ForStatement))
      {
        if (!(statementTailReturn.value is BlockStatement))
        {
          if (!(statementTailReturn.value is WhileStatement))
          {
            if (!(statementTailReturn.value is DoWhileStatement))
            {
              if (!(statementTailReturn.value is SwitchStatement))
              {
                if (!(statementTailReturn.value is TryStatement))
                {
                  if (!(statementTailReturn.value is IfStatement))
                    statementTailReturn.value.Source = this.ExtractSourceCode((CommonToken) statementTailReturn.Start, (CommonToken) statementTailReturn.Stop);
                }
              }
            }
          }
        }
      }
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      statementTailReturn.Tree = this.adaptor.ErrorNode(this.input, statementTailReturn.Start, this.input.LT(-1), ex);
    }
    return statementTailReturn;
  }

  [GrammarRule("block")]
  private ES3Parser.block_return block()
  {
    ES3Parser.block_return blockReturn = new ES3Parser.block_return(this);
    blockReturn.Start = this.input.LT(1);
    blockReturn.value = new BlockStatement();
    try
    {
      object obj1 = this.adaptor.Nil();
      object obj2 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 85, ES3Parser.Follow._LBRACE_in_block5506));
      this.adaptor.AddChild(obj1, obj2);
      while (true)
      {
        int num1 = 2;
        int num2 = ((IIntStream) this.input).LA(1);
        if (num2 == 5 || num2 == 14 || num2 == 29 || num2 == 33 || num2 == 35 || num2 == 38 || num2 == 44 || num2 == 54 || num2 == 59 || num2 == 62 || num2 >= 68 && num2 <= 69 || num2 == 73 || num2 == 77 || num2 == 79 || num2 >= 85 && num2 <= 86 || num2 == 90 || num2 >= 105 && num2 <= 106 || num2 == 108 || num2 == 114 || num2 == (int) sbyte.MaxValue || num2 == 131 || num2 == 133 || num2 == 144 /*0x90*/ || num2 == 147 || num2 == 150 || num2 >= 152 && num2 <= 153 || num2 >= 156 && num2 <= 158 || num2 >= 161 && num2 <= 162 || num2 >= 165 && num2 <= 166)
          num1 = 1;
        if (num1 == 1)
        {
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._statement_in_block5509);
          ES3Parser.statement_return statementReturn = this.statement();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj1, statementReturn.Tree);
          blockReturn.value.Statements.AddLast(statementReturn?.value);
        }
        else
          break;
      }
      object obj3 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 125, ES3Parser.Follow._RBRACE_in_block5515));
      this.adaptor.AddChild(obj1, obj3);
      blockReturn.Stop = this.input.LT(-1);
      blockReturn.Tree = this.adaptor.RulePostProcessing(obj1);
      this.adaptor.SetTokenBoundaries(blockReturn.Tree, blockReturn.Start, blockReturn.Stop);
      blockReturn.value.Source = this.ExtractSourceCode((CommonToken) blockReturn.Start, (CommonToken) blockReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      blockReturn.Tree = this.adaptor.ErrorNode(this.input, blockReturn.Start, this.input.LT(-1), ex);
    }
    return blockReturn;
  }

  [GrammarRule("variableStatement")]
  private ES3Parser.variableStatement_return variableStatement()
  {
    ES3Parser.variableStatement_return variableStatementReturn = new ES3Parser.variableStatement_return(this);
    variableStatementReturn.Start = this.input.LT(1);
    CommaOperatorStatement operatorStatement = new CommaOperatorStatement();
    try
    {
      object obj1 = this.adaptor.Nil();
      object obj2 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 161, ES3Parser.Follow._VAR_in_variableStatement5545));
      this.adaptor.AddChild(obj1, obj2);
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._variableDeclaration_in_variableStatement5549);
      ES3Parser.variableDeclaration_return declarationReturn1 = this.variableDeclaration();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj1, declarationReturn1.Tree);
      declarationReturn1.value.Global = false;
      variableStatementReturn.value = (Statement) declarationReturn1.value;
      while (true)
      {
        int num = 2;
        if (((IIntStream) this.input).LA(1) == 27)
          num = 1;
        if (num == 1)
        {
          object obj3 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 27, ES3Parser.Follow._COMMA_in_variableStatement5555));
          this.adaptor.AddChild(obj1, obj3);
          if (operatorStatement.Statements.Count == 0)
          {
            operatorStatement.Statements.Add(variableStatementReturn.value);
            variableStatementReturn.value = (Statement) operatorStatement;
          }
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._variableDeclaration_in_variableStatement5561);
          ES3Parser.variableDeclaration_return declarationReturn2 = this.variableDeclaration();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj1, declarationReturn2.Tree);
          operatorStatement.Statements.Add((Statement) declarationReturn2.value);
          declarationReturn2.value.Global = false;
        }
        else
          break;
      }
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._semic_in_variableStatement5569);
      ES3Parser.semic_return semicReturn = this.semic();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj1, semicReturn.Tree);
      variableStatementReturn.Stop = this.input.LT(-1);
      variableStatementReturn.Tree = this.adaptor.RulePostProcessing(obj1);
      this.adaptor.SetTokenBoundaries(variableStatementReturn.Tree, variableStatementReturn.Start, variableStatementReturn.Stop);
      if (operatorStatement.Statements.Count > 0)
      {
        foreach (Statement statement in operatorStatement.Statements)
          this._currentBody.AddFirst((Statement) new VariableDeclarationStatement()
          {
            Global = false,
            Identifier = ((VariableDeclarationStatement) statement).Identifier
          });
      }
      else
        this._currentBody.AddFirst((Statement) new VariableDeclarationStatement()
        {
          Global = false,
          Identifier = declarationReturn1.value.Identifier
        });
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      variableStatementReturn.Tree = this.adaptor.ErrorNode(this.input, variableStatementReturn.Start, this.input.LT(-1), ex);
    }
    return variableStatementReturn;
  }

  [GrammarRule("variableDeclaration")]
  private ES3Parser.variableDeclaration_return variableDeclaration()
  {
    ES3Parser.variableDeclaration_return declarationReturn = new ES3Parser.variableDeclaration_return(this);
    declarationReturn.Start = this.input.LT(1);
    declarationReturn.value = new VariableDeclarationStatement();
    declarationReturn.value.Global = true;
    try
    {
      object obj1 = this.adaptor.Nil();
      IToken itoken = (IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 79, ES3Parser.Follow._Identifier_in_variableDeclaration5593);
      object obj2 = this.adaptor.Create(itoken);
      this.adaptor.AddChild(obj1, obj2);
      declarationReturn.value.Identifier = itoken.Text;
      int num = 2;
      if (((IIntStream) this.input).LA(1) == 11)
        num = 1;
      if (num == 1)
      {
        obj1 = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 11, ES3Parser.Follow._ASSIGN_in_variableDeclaration5599)), obj1);
        ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._assignmentExpression_in_variableDeclaration5604);
        ES3Parser.assignmentExpression_return expressionReturn = this.assignmentExpression();
        ((BaseRecognizer) this).PopFollow();
        this.adaptor.AddChild(obj1, expressionReturn.Tree);
        declarationReturn.value.Expression = expressionReturn.value;
      }
      declarationReturn.Stop = this.input.LT(-1);
      declarationReturn.Tree = this.adaptor.RulePostProcessing(obj1);
      this.adaptor.SetTokenBoundaries(declarationReturn.Tree, declarationReturn.Start, declarationReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      declarationReturn.Tree = this.adaptor.ErrorNode(this.input, declarationReturn.Start, this.input.LT(-1), ex);
    }
    return declarationReturn;
  }

  [GrammarRule("variableDeclarationNoIn")]
  private ES3Parser.variableDeclarationNoIn_return variableDeclarationNoIn()
  {
    ES3Parser.variableDeclarationNoIn_return declarationNoInReturn = new ES3Parser.variableDeclarationNoIn_return(this);
    declarationNoInReturn.Start = this.input.LT(1);
    declarationNoInReturn.value = new VariableDeclarationStatement();
    declarationNoInReturn.value.Global = true;
    try
    {
      object obj1 = this.adaptor.Nil();
      IToken itoken = (IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 79, ES3Parser.Follow._Identifier_in_variableDeclarationNoIn5632);
      object obj2 = this.adaptor.Create(itoken);
      this.adaptor.AddChild(obj1, obj2);
      declarationNoInReturn.value.Identifier = itoken.Text;
      int num = 2;
      if (((IIntStream) this.input).LA(1) == 11)
        num = 1;
      if (num == 1)
      {
        obj1 = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 11, ES3Parser.Follow._ASSIGN_in_variableDeclarationNoIn5638)), obj1);
        ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._assignmentExpressionNoIn_in_variableDeclarationNoIn5643);
        ES3Parser.assignmentExpressionNoIn_return expressionNoInReturn = this.assignmentExpressionNoIn();
        ((BaseRecognizer) this).PopFollow();
        this.adaptor.AddChild(obj1, expressionNoInReturn.Tree);
        declarationNoInReturn.value.Expression = expressionNoInReturn.value;
      }
      declarationNoInReturn.Stop = this.input.LT(-1);
      declarationNoInReturn.Tree = this.adaptor.RulePostProcessing(obj1);
      this.adaptor.SetTokenBoundaries(declarationNoInReturn.Tree, declarationNoInReturn.Start, declarationNoInReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      declarationNoInReturn.Tree = this.adaptor.ErrorNode(this.input, declarationNoInReturn.Start, this.input.LT(-1), ex);
    }
    return declarationNoInReturn;
  }

  [GrammarRule("emptyStatement")]
  private ES3Parser.emptyStatement_return emptyStatement()
  {
    ES3Parser.emptyStatement_return emptyStatementReturn = new ES3Parser.emptyStatement_return(this);
    emptyStatementReturn.Start = this.input.LT(1);
    try
    {
      object obj = this.adaptor.Nil();
      IToken itoken = (IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 133, ES3Parser.Follow._SEMIC_in_emptyStatement5668);
      emptyStatementReturn.value = (Statement) new EmptyStatement();
      emptyStatementReturn.Stop = this.input.LT(-1);
      emptyStatementReturn.Tree = this.adaptor.RulePostProcessing(obj);
      this.adaptor.SetTokenBoundaries(emptyStatementReturn.Tree, emptyStatementReturn.Start, emptyStatementReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      emptyStatementReturn.Tree = this.adaptor.ErrorNode(this.input, emptyStatementReturn.Start, this.input.LT(-1), ex);
    }
    return emptyStatementReturn;
  }

  [GrammarRule("expressionStatement")]
  private ES3Parser.expressionStatement_return expressionStatement()
  {
    ES3Parser.expressionStatement_return expressionStatementReturn = new ES3Parser.expressionStatement_return(this);
    expressionStatementReturn.Start = this.input.LT(1);
    try
    {
      object obj = this.adaptor.Nil();
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._expression_in_expressionStatement5693);
      ES3Parser.expression_return expressionReturn = this.expression();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj, expressionReturn.Tree);
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._semic_in_expressionStatement5695);
      this.semic();
      ((BaseRecognizer) this).PopFollow();
      expressionStatementReturn.value = (Statement) new ExpressionStatement(expressionReturn?.value);
      expressionStatementReturn.Stop = this.input.LT(-1);
      expressionStatementReturn.Tree = this.adaptor.RulePostProcessing(obj);
      this.adaptor.SetTokenBoundaries(expressionStatementReturn.Tree, expressionStatementReturn.Start, expressionStatementReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      expressionStatementReturn.Tree = this.adaptor.ErrorNode(this.input, expressionStatementReturn.Start, this.input.LT(-1), ex);
    }
    return expressionStatementReturn;
  }

  [GrammarRule("ifStatement")]
  private ES3Parser.ifStatement_return ifStatement()
  {
    ES3Parser.ifStatement_return ifStatementReturn = new ES3Parser.ifStatement_return(this);
    ifStatementReturn.Start = this.input.LT(1);
    IfStatement ifStatement = new IfStatement();
    ifStatementReturn.value = (Statement) ifStatement;
    try
    {
      object obj1 = this.adaptor.Nil();
      object obj2 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 69, ES3Parser.Follow._IF_in_ifStatement5724));
      this.adaptor.AddChild(obj1, obj2);
      object obj3 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 90, ES3Parser.Follow._LPAREN_in_ifStatement5726));
      this.adaptor.AddChild(obj1, obj3);
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._expression_in_ifStatement5728);
      ES3Parser.expression_return expressionReturn = this.expression();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj1, expressionReturn.Tree);
      ifStatement.Expression = expressionReturn?.value;
      object obj4 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 128 /*0x80*/, ES3Parser.Follow._RPAREN_in_ifStatement5732));
      this.adaptor.AddChild(obj1, obj4);
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._statement_in_ifStatement5736);
      ES3Parser.statement_return statementReturn1 = this.statement();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj1, statementReturn1.Tree);
      ifStatement.Then = statementReturn1?.value;
      int num = 2;
      if (((IIntStream) this.input).LA(1) == 45)
      {
        ((IIntStream) this.input).LA(2);
        if (((IIntStream) this.input).LA(1) == 45)
          num = 1;
      }
      if (num == 1)
      {
        if (((IIntStream) this.input).LA(1) != 45)
          throw new FailedPredicateException((IIntStream) this.input, nameof (ifStatement), " input.LA(1) == ELSE ");
        object obj5 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 45, ES3Parser.Follow._ELSE_in_ifStatement5744));
        this.adaptor.AddChild(obj1, obj5);
        ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._statement_in_ifStatement5748);
        ES3Parser.statement_return statementReturn2 = this.statement();
        ((BaseRecognizer) this).PopFollow();
        this.adaptor.AddChild(obj1, statementReturn2.Tree);
        ifStatement.Else = statementReturn2?.value;
      }
      ifStatementReturn.Stop = this.input.LT(-1);
      ifStatementReturn.Tree = this.adaptor.RulePostProcessing(obj1);
      this.adaptor.SetTokenBoundaries(ifStatementReturn.Tree, ifStatementReturn.Start, ifStatementReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      ifStatementReturn.Tree = this.adaptor.ErrorNode(this.input, ifStatementReturn.Start, this.input.LT(-1), ex);
    }
    return ifStatementReturn;
  }

  [GrammarRule("iterationStatement")]
  private ES3Parser.iterationStatement_return iterationStatement()
  {
    ES3Parser.iterationStatement_return iterationStatementReturn = new ES3Parser.iterationStatement_return(this);
    iterationStatementReturn.Start = this.input.LT(1);
    object obj = (object) null;
    try
    {
      int num;
      switch (((IIntStream) this.input).LA(1))
      {
        case 38:
          num = 1;
          break;
        case 59:
          num = 3;
          break;
        case 165:
          num = 2;
          break;
        default:
          throw new NoViableAltException("", 65, 0, (IIntStream) this.input);
      }
      switch (num)
      {
        case 1:
          obj = this.adaptor.Nil();
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._doStatement_in_iterationStatement5778);
          ES3Parser.doStatement_return doStatementReturn = this.doStatement();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj, doStatementReturn.Tree);
          iterationStatementReturn.value = doStatementReturn.value;
          break;
        case 2:
          obj = this.adaptor.Nil();
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._whileStatement_in_iterationStatement5787);
          ES3Parser.whileStatement_return whileStatementReturn = this.whileStatement();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj, whileStatementReturn.Tree);
          iterationStatementReturn.value = whileStatementReturn.value;
          break;
        case 3:
          obj = this.adaptor.Nil();
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._forStatement_in_iterationStatement5797);
          ES3Parser.forStatement_return forStatementReturn = this.forStatement();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj, forStatementReturn.Tree);
          iterationStatementReturn.value = (Statement) forStatementReturn.value;
          break;
      }
      iterationStatementReturn.Stop = this.input.LT(-1);
      iterationStatementReturn.Tree = this.adaptor.RulePostProcessing(obj);
      this.adaptor.SetTokenBoundaries(iterationStatementReturn.Tree, iterationStatementReturn.Start, iterationStatementReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      iterationStatementReturn.Tree = this.adaptor.ErrorNode(this.input, iterationStatementReturn.Start, this.input.LT(-1), ex);
    }
    return iterationStatementReturn;
  }

  [GrammarRule("doStatement")]
  private ES3Parser.doStatement_return doStatement()
  {
    ES3Parser.doStatement_return doStatementReturn = new ES3Parser.doStatement_return(this);
    doStatementReturn.Start = this.input.LT(1);
    try
    {
      object obj1 = this.adaptor.Nil();
      object obj2 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 38, ES3Parser.Follow._DO_in_doStatement5816));
      this.adaptor.AddChild(obj1, obj2);
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._statement_in_doStatement5818);
      ES3Parser.statement_return statementReturn = this.statement();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj1, statementReturn.Tree);
      object obj3 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 165, ES3Parser.Follow._WHILE_in_doStatement5820));
      this.adaptor.AddChild(obj1, obj3);
      object obj4 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 90, ES3Parser.Follow._LPAREN_in_doStatement5822));
      this.adaptor.AddChild(obj1, obj4);
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._expression_in_doStatement5824);
      ES3Parser.expression_return expressionReturn = this.expression();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj1, expressionReturn.Tree);
      object obj5 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 128 /*0x80*/, ES3Parser.Follow._RPAREN_in_doStatement5826));
      this.adaptor.AddChild(obj1, obj5);
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._semic_in_doStatement5828);
      ES3Parser.semic_return semicReturn = this.semic();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj1, semicReturn.Tree);
      doStatementReturn.value = (Statement) new DoWhileStatement(expressionReturn?.value, statementReturn?.value);
      doStatementReturn.Stop = this.input.LT(-1);
      doStatementReturn.Tree = this.adaptor.RulePostProcessing(obj1);
      this.adaptor.SetTokenBoundaries(doStatementReturn.Tree, doStatementReturn.Start, doStatementReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      doStatementReturn.Tree = this.adaptor.ErrorNode(this.input, doStatementReturn.Start, this.input.LT(-1), ex);
    }
    return doStatementReturn;
  }

  [GrammarRule("whileStatement")]
  private ES3Parser.whileStatement_return whileStatement()
  {
    ES3Parser.whileStatement_return whileStatementReturn = new ES3Parser.whileStatement_return(this);
    whileStatementReturn.Start = this.input.LT(1);
    try
    {
      object obj1 = this.adaptor.Nil();
      object obj2 = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 165, ES3Parser.Follow._WHILE_in_whileStatement5848)), obj1);
      IToken itoken1 = (IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 90, ES3Parser.Follow._LPAREN_in_whileStatement5851);
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._expression_in_whileStatement5854);
      ES3Parser.expression_return expressionReturn = this.expression();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj2, expressionReturn.Tree);
      IToken itoken2 = (IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 128 /*0x80*/, ES3Parser.Follow._RPAREN_in_whileStatement5856);
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._statement_in_whileStatement5859);
      ES3Parser.statement_return statementReturn = this.statement();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj2, statementReturn.Tree);
      whileStatementReturn.value = (Statement) new WhileStatement(expressionReturn?.value, statementReturn?.value);
      whileStatementReturn.Stop = this.input.LT(-1);
      whileStatementReturn.Tree = this.adaptor.RulePostProcessing(obj2);
      this.adaptor.SetTokenBoundaries(whileStatementReturn.Tree, whileStatementReturn.Start, whileStatementReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      whileStatementReturn.Tree = this.adaptor.ErrorNode(this.input, whileStatementReturn.Start, this.input.LT(-1), ex);
    }
    return whileStatementReturn;
  }

  [GrammarRule("forStatement")]
  private ES3Parser.forStatement_return forStatement()
  {
    ES3Parser.forStatement_return forStatementReturn = new ES3Parser.forStatement_return(this);
    forStatementReturn.Start = this.input.LT(1);
    try
    {
      object obj1 = this.adaptor.Nil();
      object obj2 = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 59, ES3Parser.Follow._FOR_in_forStatement5878)), obj1);
      IToken itoken1 = (IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 90, ES3Parser.Follow._LPAREN_in_forStatement5881);
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._forControl_in_forStatement5886);
      ES3Parser.forControl_return forControlReturn = this.forControl();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj2, forControlReturn.Tree);
      forStatementReturn.value = forControlReturn.value;
      IToken itoken2 = (IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 128 /*0x80*/, ES3Parser.Follow._RPAREN_in_forStatement5891);
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._statement_in_forStatement5896);
      ES3Parser.statement_return statementReturn = this.statement();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj2, statementReturn.Tree);
      forStatementReturn.value.Statement = statementReturn.value;
      forStatementReturn.Stop = this.input.LT(-1);
      forStatementReturn.Tree = this.adaptor.RulePostProcessing(obj2);
      this.adaptor.SetTokenBoundaries(forStatementReturn.Tree, forStatementReturn.Start, forStatementReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      forStatementReturn.Tree = this.adaptor.ErrorNode(this.input, forStatementReturn.Start, this.input.LT(-1), ex);
    }
    return forStatementReturn;
  }

  [GrammarRule("forControl")]
  private ES3Parser.forControl_return forControl()
  {
    ES3Parser.forControl_return forControlReturn = new ES3Parser.forControl_return(this);
    forControlReturn.Start = this.input.LT(1);
    object obj = (object) null;
    try
    {
      int num1 = ((IIntStream) this.input).LA(1);
      int num2;
      if (num1 <= 79)
      {
        if (num1 <= 54)
        {
          if (num1 <= 35)
          {
            if (num1 != 5)
            {
              switch (num1 - 33)
              {
                case 0:
                case 2:
                  break;
                default:
                  goto label_25;
              }
            }
          }
          else if (num1 != 44 && num1 != 54)
            goto label_25;
        }
        else if (num1 <= 68)
        {
          if (num1 != 62 && num1 != 68)
            goto label_25;
        }
        else if (num1 != 73)
        {
          switch (num1 - 77)
          {
            case 0:
            case 2:
              break;
            default:
              goto label_25;
          }
        }
      }
      else if (num1 <= 114)
      {
        if (num1 <= 90)
        {
          switch (num1 - 85)
          {
            case 0:
            case 1:
              break;
            default:
              if (num1 == 90)
                break;
              goto label_25;
          }
        }
        else
        {
          switch (num1 - 105)
          {
            case 0:
            case 1:
            case 3:
              break;
            case 2:
              goto label_25;
            default:
              if (num1 == 114)
                break;
              goto label_25;
          }
        }
      }
      else if (num1 <= 144 /*0x90*/)
      {
        switch (num1 - 131)
        {
          case 0:
            break;
          case 1:
            goto label_25;
          case 2:
            num2 = 3;
            goto label_26;
          default:
            if (num1 == 144 /*0x90*/)
              break;
            goto label_25;
        }
      }
      else
      {
        switch (num1 - 150)
        {
          case 0:
          case 2:
            break;
          case 1:
            goto label_25;
          default:
            switch (num1 - 156)
            {
              case 0:
              case 2:
              case 6:
                break;
              case 5:
                num2 = 1;
                goto label_26;
              default:
                goto label_25;
            }
            break;
        }
      }
      num2 = 2;
      goto label_26;
label_25:
      throw new NoViableAltException("", 66, 0, (IIntStream) this.input);
label_26:
      switch (num2)
      {
        case 1:
          obj = this.adaptor.Nil();
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._forControlVar_in_forControl5915);
          ES3Parser.forControlVar_return controlVarReturn = this.forControlVar();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj, controlVarReturn.Tree);
          forControlReturn.value = controlVarReturn.value;
          break;
        case 2:
          obj = this.adaptor.Nil();
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._forControlExpression_in_forControl5924);
          ES3Parser.forControlExpression_return expressionReturn = this.forControlExpression();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj, expressionReturn.Tree);
          forControlReturn.value = expressionReturn.value;
          break;
        case 3:
          obj = this.adaptor.Nil();
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._forControlSemic_in_forControl5933);
          ES3Parser.forControlSemic_return controlSemicReturn = this.forControlSemic();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj, controlSemicReturn.Tree);
          forControlReturn.value = (IForStatement) controlSemicReturn.value;
          break;
      }
      forControlReturn.Stop = this.input.LT(-1);
      forControlReturn.Tree = this.adaptor.RulePostProcessing(obj);
      this.adaptor.SetTokenBoundaries(forControlReturn.Tree, forControlReturn.Start, forControlReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      forControlReturn.Tree = this.adaptor.ErrorNode(this.input, forControlReturn.Start, this.input.LT(-1), ex);
    }
    return forControlReturn;
  }

  [GrammarRule("forControlVar")]
  private ES3Parser.forControlVar_return forControlVar()
  {
    ES3Parser.forControlVar_return controlVarReturn = new ES3Parser.forControlVar_return(this);
    controlVarReturn.Start = this.input.LT(1);
    ForStatement forStatement = new ForStatement();
    ForEachInStatement forEachInStatement = new ForEachInStatement();
    CommaOperatorStatement operatorStatement = new CommaOperatorStatement();
    try
    {
      object obj1 = this.adaptor.Nil();
      object obj2 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 161, ES3Parser.Follow._VAR_in_forControlVar5961));
      this.adaptor.AddChild(obj1, obj2);
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._variableDeclarationNoIn_in_forControlVar5965);
      ES3Parser.variableDeclarationNoIn_return declarationNoInReturn1 = this.variableDeclarationNoIn();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj1, declarationNoInReturn1.Tree);
      forEachInStatement.InitialisationStatement = forStatement.InitialisationStatement = (Statement) declarationNoInReturn1.value;
      declarationNoInReturn1.value.Global = false;
      int num1;
      switch (((IIntStream) this.input).LA(1))
      {
        case 27:
        case 133:
          num1 = 2;
          break;
        case 72:
          num1 = 1;
          break;
        default:
          throw new NoViableAltException("", 70, 0, (IIntStream) this.input);
      }
      switch (num1)
      {
        case 1:
          object obj3 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 72, ES3Parser.Follow._IN_in_forControlVar5979));
          this.adaptor.AddChild(obj1, obj3);
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._expression_in_forControlVar5983);
          ES3Parser.expression_return expressionReturn1 = this.expression();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj1, expressionReturn1.Tree);
          controlVarReturn.value = (IForStatement) forEachInStatement;
          forEachInStatement.Expression = expressionReturn1?.value;
          break;
        case 2:
          while (true)
          {
            int num2 = 2;
            if (((IIntStream) this.input).LA(1) == 27)
              num2 = 1;
            if (num2 == 1)
            {
              object obj4 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 27, ES3Parser.Follow._COMMA_in_forControlVar6008));
              this.adaptor.AddChild(obj1, obj4);
              if (operatorStatement.Statements.Count == 0)
              {
                forEachInStatement.InitialisationStatement = forStatement.InitialisationStatement = (Statement) operatorStatement;
                operatorStatement.Statements.Add((Statement) declarationNoInReturn1.value);
              }
              ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._variableDeclarationNoIn_in_forControlVar6014);
              ES3Parser.variableDeclarationNoIn_return declarationNoInReturn2 = this.variableDeclarationNoIn();
              ((BaseRecognizer) this).PopFollow();
              this.adaptor.AddChild(obj1, declarationNoInReturn2.Tree);
              declarationNoInReturn2.value.Global = false;
              operatorStatement.Statements.Add((Statement) declarationNoInReturn2.value);
            }
            else
              break;
          }
          object obj5 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 133, ES3Parser.Follow._SEMIC_in_forControlVar6025));
          this.adaptor.AddChild(obj1, obj5);
          int num3 = 2;
          int num4 = ((IIntStream) this.input).LA(1);
          if (num4 == 5 || num4 == 33 || num4 == 35 || num4 == 44 || num4 == 54 || num4 == 62 || num4 == 68 || num4 == 73 || num4 == 77 || num4 == 79 || num4 >= 85 && num4 <= 86 || num4 == 90 || num4 >= 105 && num4 <= 106 || num4 == 108 || num4 == 114 || num4 == 131 || num4 == 144 /*0x90*/ || num4 == 150 || num4 == 152 || num4 == 156 || num4 == 158 || num4 == 162)
            num3 = 1;
          if (num3 == 1)
          {
            ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._expression_in_forControlVar6031);
            ES3Parser.expression_return expressionReturn2 = this.expression();
            ((BaseRecognizer) this).PopFollow();
            this.adaptor.AddChild(obj1, expressionReturn2.Tree);
            forStatement.ConditionExpression = (Statement) expressionReturn2?.value;
          }
          object obj6 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 133, ES3Parser.Follow._SEMIC_in_forControlVar6039));
          this.adaptor.AddChild(obj1, obj6);
          int num5 = 2;
          int num6 = ((IIntStream) this.input).LA(1);
          if (num6 == 5 || num6 == 33 || num6 == 35 || num6 == 44 || num6 == 54 || num6 == 62 || num6 == 68 || num6 == 73 || num6 == 77 || num6 == 79 || num6 >= 85 && num6 <= 86 || num6 == 90 || num6 >= 105 && num6 <= 106 || num6 == 108 || num6 == 114 || num6 == 131 || num6 == 144 /*0x90*/ || num6 == 150 || num6 == 152 || num6 == 156 || num6 == 158 || num6 == 162)
            num5 = 1;
          if (num5 == 1)
          {
            ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._expression_in_forControlVar6044);
            ES3Parser.expression_return expressionReturn3 = this.expression();
            ((BaseRecognizer) this).PopFollow();
            this.adaptor.AddChild(obj1, expressionReturn3.Tree);
            forStatement.IncrementExpression = (Statement) expressionReturn3?.value;
          }
          controlVarReturn.value = (IForStatement) forStatement;
          break;
      }
      controlVarReturn.Stop = this.input.LT(-1);
      controlVarReturn.Tree = this.adaptor.RulePostProcessing(obj1);
      this.adaptor.SetTokenBoundaries(controlVarReturn.Tree, controlVarReturn.Start, controlVarReturn.Stop);
      if (operatorStatement.Statements.Count > 0)
      {
        foreach (Statement statement in operatorStatement.Statements)
          this._currentBody.AddFirst((Statement) new VariableDeclarationStatement()
          {
            Global = false,
            Identifier = ((VariableDeclarationStatement) statement).Identifier
          });
      }
      else
        this._currentBody.AddFirst((Statement) new VariableDeclarationStatement()
        {
          Global = false,
          Identifier = declarationNoInReturn1.value.Identifier
        });
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      controlVarReturn.Tree = this.adaptor.ErrorNode(this.input, controlVarReturn.Start, this.input.LT(-1), ex);
    }
    return controlVarReturn;
  }

  [GrammarRule("forControlExpression")]
  private ES3Parser.forControlExpression_return forControlExpression()
  {
    ES3Parser.forControlExpression_return expressionReturn1 = new ES3Parser.forControlExpression_return(this);
    expressionReturn1.Start = this.input.LT(1);
    ForStatement forStatement = new ForStatement();
    ForEachInStatement forEachInStatement = new ForEachInStatement();
    object[] cached = new object[1];
    try
    {
      object obj1 = this.adaptor.Nil();
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._expressionNoIn_in_forControlExpression6083);
      ES3Parser.expressionNoIn_return expressionNoInReturn = this.expressionNoIn();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj1, expressionNoInReturn.Tree);
      forEachInStatement.InitialisationStatement = forStatement.InitialisationStatement = (Statement) expressionNoInReturn.value;
      int num1;
      switch (((IIntStream) this.input).LA(1))
      {
        case 72:
          num1 = 1;
          break;
        case 133:
          num1 = 2;
          break;
        default:
          throw new NoViableAltException("", 73, 0, (IIntStream) this.input);
      }
      switch (num1)
      {
        case 1:
          if (!this.IsLeftHandSideIn(expressionNoInReturn.value, cached))
            throw new FailedPredicateException((IIntStream) this.input, nameof (forControlExpression), " IsLeftHandSideIn(ex1.value, isLhs) ");
          object obj2 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 72, ES3Parser.Follow._IN_in_forControlExpression6100));
          this.adaptor.AddChild(obj1, obj2);
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._expression_in_forControlExpression6104);
          ES3Parser.expression_return expressionReturn2 = this.expression();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj1, expressionReturn2.Tree);
          expressionReturn1.value = (IForStatement) forEachInStatement;
          forEachInStatement.Expression = expressionReturn2.value;
          break;
        case 2:
          object obj3 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 133, ES3Parser.Follow._SEMIC_in_forControlExpression6127));
          this.adaptor.AddChild(obj1, obj3);
          int num2 = 2;
          int num3 = ((IIntStream) this.input).LA(1);
          if (num3 == 5 || num3 == 33 || num3 == 35 || num3 == 44 || num3 == 54 || num3 == 62 || num3 == 68 || num3 == 73 || num3 == 77 || num3 == 79 || num3 >= 85 && num3 <= 86 || num3 == 90 || num3 >= 105 && num3 <= 106 || num3 == 108 || num3 == 114 || num3 == 131 || num3 == 144 /*0x90*/ || num3 == 150 || num3 == 152 || num3 == 156 || num3 == 158 || num3 == 162)
            num2 = 1;
          if (num2 == 1)
          {
            ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._expression_in_forControlExpression6133);
            ES3Parser.expression_return expressionReturn3 = this.expression();
            ((BaseRecognizer) this).PopFollow();
            this.adaptor.AddChild(obj1, expressionReturn3.Tree);
            forStatement.ConditionExpression = (Statement) expressionReturn3.value;
          }
          object obj4 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 133, ES3Parser.Follow._SEMIC_in_forControlExpression6141));
          this.adaptor.AddChild(obj1, obj4);
          int num4 = 2;
          int num5 = ((IIntStream) this.input).LA(1);
          if (num5 == 5 || num5 == 33 || num5 == 35 || num5 == 44 || num5 == 54 || num5 == 62 || num5 == 68 || num5 == 73 || num5 == 77 || num5 == 79 || num5 >= 85 && num5 <= 86 || num5 == 90 || num5 >= 105 && num5 <= 106 || num5 == 108 || num5 == 114 || num5 == 131 || num5 == 144 /*0x90*/ || num5 == 150 || num5 == 152 || num5 == 156 || num5 == 158 || num5 == 162)
            num4 = 1;
          if (num4 == 1)
          {
            ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._expression_in_forControlExpression6146);
            ES3Parser.expression_return expressionReturn4 = this.expression();
            ((BaseRecognizer) this).PopFollow();
            this.adaptor.AddChild(obj1, expressionReturn4.Tree);
            forStatement.IncrementExpression = (Statement) expressionReturn4.value;
          }
          expressionReturn1.value = (IForStatement) forStatement;
          break;
      }
      expressionReturn1.Stop = this.input.LT(-1);
      expressionReturn1.Tree = this.adaptor.RulePostProcessing(obj1);
      this.adaptor.SetTokenBoundaries(expressionReturn1.Tree, expressionReturn1.Start, expressionReturn1.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      expressionReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionReturn1.Start, this.input.LT(-1), ex);
    }
    return expressionReturn1;
  }

  [GrammarRule("forControlSemic")]
  private ES3Parser.forControlSemic_return forControlSemic()
  {
    ES3Parser.forControlSemic_return controlSemicReturn = new ES3Parser.forControlSemic_return(this);
    controlSemicReturn.Start = this.input.LT(1);
    controlSemicReturn.value = new ForStatement();
    try
    {
      object obj1 = this.adaptor.Nil();
      object obj2 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 133, ES3Parser.Follow._SEMIC_in_forControlSemic6182));
      this.adaptor.AddChild(obj1, obj2);
      int num1 = 2;
      int num2 = ((IIntStream) this.input).LA(1);
      if (num2 == 5 || num2 == 33 || num2 == 35 || num2 == 44 || num2 == 54 || num2 == 62 || num2 == 68 || num2 == 73 || num2 == 77 || num2 == 79 || num2 >= 85 && num2 <= 86 || num2 == 90 || num2 >= 105 && num2 <= 106 || num2 == 108 || num2 == 114 || num2 == 131 || num2 == 144 /*0x90*/ || num2 == 150 || num2 == 152 || num2 == 156 || num2 == 158 || num2 == 162)
        num1 = 1;
      if (num1 == 1)
      {
        ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._expression_in_forControlSemic6188);
        ES3Parser.expression_return expressionReturn = this.expression();
        ((BaseRecognizer) this).PopFollow();
        this.adaptor.AddChild(obj1, expressionReturn.Tree);
        controlSemicReturn.value.ConditionExpression = (Statement) expressionReturn.value;
      }
      object obj3 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 133, ES3Parser.Follow._SEMIC_in_forControlSemic6196));
      this.adaptor.AddChild(obj1, obj3);
      int num3 = 2;
      int num4 = ((IIntStream) this.input).LA(1);
      if (num4 == 5 || num4 == 33 || num4 == 35 || num4 == 44 || num4 == 54 || num4 == 62 || num4 == 68 || num4 == 73 || num4 == 77 || num4 == 79 || num4 >= 85 && num4 <= 86 || num4 == 90 || num4 >= 105 && num4 <= 106 || num4 == 108 || num4 == 114 || num4 == 131 || num4 == 144 /*0x90*/ || num4 == 150 || num4 == 152 || num4 == 156 || num4 == 158 || num4 == 162)
        num3 = 1;
      if (num3 == 1)
      {
        ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._expression_in_forControlSemic6201);
        ES3Parser.expression_return expressionReturn = this.expression();
        ((BaseRecognizer) this).PopFollow();
        this.adaptor.AddChild(obj1, expressionReturn.Tree);
        controlSemicReturn.value.IncrementExpression = (Statement) expressionReturn.value;
      }
      controlSemicReturn.Stop = this.input.LT(-1);
      controlSemicReturn.Tree = this.adaptor.RulePostProcessing(obj1);
      this.adaptor.SetTokenBoundaries(controlSemicReturn.Tree, controlSemicReturn.Start, controlSemicReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      controlSemicReturn.Tree = this.adaptor.ErrorNode(this.input, controlSemicReturn.Start, this.input.LT(-1), ex);
    }
    return controlSemicReturn;
  }

  [GrammarRule("continueStatement")]
  private ES3Parser.continueStatement_return continueStatement()
  {
    ES3Parser.continueStatement_return continueStatementReturn1 = new ES3Parser.continueStatement_return(this);
    continueStatementReturn1.Start = this.input.LT(1);
    string str = string.Empty;
    try
    {
      object obj1 = this.adaptor.Nil();
      object obj2 = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 29, ES3Parser.Follow._CONTINUE_in_continueStatement6235)), obj1);
      if (((IIntStream) this.input).LA(1) == 79)
        this.PromoteEOL((ParserRuleReturnScope<IToken>) null);
      int num = 2;
      if (((IIntStream) this.input).LA(1) == 79)
        num = 1;
      if (num == 1)
      {
        IToken itoken = (IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 79, ES3Parser.Follow._Identifier_in_continueStatement6243);
        object obj3 = this.adaptor.Create(itoken);
        this.adaptor.AddChild(obj2, obj3);
        str = itoken.Text;
      }
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._semic_in_continueStatement6250);
      this.semic();
      ((BaseRecognizer) this).PopFollow();
      ES3Parser.continueStatement_return continueStatementReturn2 = continueStatementReturn1;
      ContinueStatement continueStatement1 = new ContinueStatement();
      continueStatement1.Label = str;
      ContinueStatement continueStatement2 = continueStatement1;
      continueStatementReturn2.value = (Statement) continueStatement2;
      continueStatementReturn1.Stop = this.input.LT(-1);
      continueStatementReturn1.Tree = this.adaptor.RulePostProcessing(obj2);
      this.adaptor.SetTokenBoundaries(continueStatementReturn1.Tree, continueStatementReturn1.Start, continueStatementReturn1.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      continueStatementReturn1.Tree = this.adaptor.ErrorNode(this.input, continueStatementReturn1.Start, this.input.LT(-1), ex);
    }
    return continueStatementReturn1;
  }

  [GrammarRule("breakStatement")]
  private ES3Parser.breakStatement_return breakStatement()
  {
    ES3Parser.breakStatement_return breakStatementReturn1 = new ES3Parser.breakStatement_return(this);
    breakStatementReturn1.Start = this.input.LT(1);
    string str = string.Empty;
    try
    {
      object obj1 = this.adaptor.Nil();
      object obj2 = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 14, ES3Parser.Follow._BREAK_in_breakStatement6280)), obj1);
      if (((IIntStream) this.input).LA(1) == 79)
        this.PromoteEOL((ParserRuleReturnScope<IToken>) null);
      int num = 2;
      if (((IIntStream) this.input).LA(1) == 79)
        num = 1;
      if (num == 1)
      {
        IToken itoken = (IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 79, ES3Parser.Follow._Identifier_in_breakStatement6288);
        object obj3 = this.adaptor.Create(itoken);
        this.adaptor.AddChild(obj2, obj3);
        str = itoken.Text;
      }
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._semic_in_breakStatement6295);
      this.semic();
      ((BaseRecognizer) this).PopFollow();
      ES3Parser.breakStatement_return breakStatementReturn2 = breakStatementReturn1;
      BreakStatement breakStatement1 = new BreakStatement();
      breakStatement1.Label = str;
      BreakStatement breakStatement2 = breakStatement1;
      breakStatementReturn2.value = (Statement) breakStatement2;
      breakStatementReturn1.Stop = this.input.LT(-1);
      breakStatementReturn1.Tree = this.adaptor.RulePostProcessing(obj2);
      this.adaptor.SetTokenBoundaries(breakStatementReturn1.Tree, breakStatementReturn1.Start, breakStatementReturn1.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      breakStatementReturn1.Tree = this.adaptor.ErrorNode(this.input, breakStatementReturn1.Start, this.input.LT(-1), ex);
    }
    return breakStatementReturn1;
  }

  [GrammarRule("returnStatement")]
  private ES3Parser.returnStatement_return returnStatement()
  {
    ES3Parser.returnStatement_return returnStatementReturn = new ES3Parser.returnStatement_return(this);
    returnStatementReturn.Start = this.input.LT(1);
    returnStatementReturn.value = new ReturnStatement();
    try
    {
      object obj1 = this.adaptor.Nil();
      object obj2 = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, (int) sbyte.MaxValue, ES3Parser.Follow._RETURN_in_returnStatement6325)), obj1);
      this.PromoteEOL((ParserRuleReturnScope<IToken>) null);
      int num1 = 2;
      int num2 = ((IIntStream) this.input).LA(1);
      if (num2 == 5 || num2 == 33 || num2 == 35 || num2 == 44 || num2 == 54 || num2 == 62 || num2 == 68 || num2 == 73 || num2 == 77 || num2 == 79 || num2 >= 85 && num2 <= 86 || num2 == 90 || num2 >= 105 && num2 <= 106 || num2 == 108 || num2 == 114 || num2 == 131 || num2 == 144 /*0x90*/ || num2 == 150 || num2 == 152 || num2 == 156 || num2 == 158 || num2 == 162)
        num1 = 1;
      if (num1 == 1)
      {
        ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._expression_in_returnStatement6333);
        ES3Parser.expression_return expressionReturn = this.expression();
        ((BaseRecognizer) this).PopFollow();
        this.adaptor.AddChild(obj2, expressionReturn.Tree);
        returnStatementReturn.value.Expression = expressionReturn.value;
      }
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._semic_in_returnStatement6339);
      this.semic();
      ((BaseRecognizer) this).PopFollow();
      returnStatementReturn.Stop = this.input.LT(-1);
      returnStatementReturn.Tree = this.adaptor.RulePostProcessing(obj2);
      this.adaptor.SetTokenBoundaries(returnStatementReturn.Tree, returnStatementReturn.Start, returnStatementReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      returnStatementReturn.Tree = this.adaptor.ErrorNode(this.input, returnStatementReturn.Start, this.input.LT(-1), ex);
    }
    return returnStatementReturn;
  }

  [GrammarRule("withStatement")]
  private ES3Parser.withStatement_return withStatement()
  {
    ES3Parser.withStatement_return withStatementReturn = new ES3Parser.withStatement_return(this);
    withStatementReturn.Start = this.input.LT(1);
    try
    {
      object obj1 = this.adaptor.Nil();
      object obj2 = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 166, ES3Parser.Follow._WITH_in_withStatement6360)), obj1);
      IToken itoken1 = (IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 90, ES3Parser.Follow._LPAREN_in_withStatement6363);
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._expression_in_withStatement6368);
      ES3Parser.expression_return expressionReturn = this.expression();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj2, expressionReturn.Tree);
      IToken itoken2 = (IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 128 /*0x80*/, ES3Parser.Follow._RPAREN_in_withStatement6370);
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._statement_in_withStatement6375);
      ES3Parser.statement_return statementReturn = this.statement();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj2, statementReturn.Tree);
      withStatementReturn.value = (Statement) new WithStatement(expressionReturn.value, statementReturn.value);
      withStatementReturn.Stop = this.input.LT(-1);
      withStatementReturn.Tree = this.adaptor.RulePostProcessing(obj2);
      this.adaptor.SetTokenBoundaries(withStatementReturn.Tree, withStatementReturn.Start, withStatementReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      withStatementReturn.Tree = this.adaptor.ErrorNode(this.input, withStatementReturn.Start, this.input.LT(-1), ex);
    }
    return withStatementReturn;
  }

  [GrammarRule("switchStatement")]
  private ES3Parser.switchStatement_return switchStatement()
  {
    ES3Parser.switchStatement_return switchStatementReturn = new ES3Parser.switchStatement_return(this);
    switchStatementReturn.Start = this.input.LT(1);
    SwitchStatement switchStatement = new SwitchStatement();
    switchStatementReturn.value = (Statement) switchStatement;
    int num1 = 0;
    int num2 = 0;
    try
    {
      object obj1 = this.adaptor.Nil();
      object obj2 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 147, ES3Parser.Follow._SWITCH_in_switchStatement6402));
      this.adaptor.AddChild(obj1, obj2);
      object obj3 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 90, ES3Parser.Follow._LPAREN_in_switchStatement6404));
      this.adaptor.AddChild(obj1, obj3);
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._expression_in_switchStatement6406);
      ES3Parser.expression_return expressionReturn = this.expression();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj1, expressionReturn.Tree);
      switchStatement.Expression = (Statement) expressionReturn?.value;
      object obj4 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 128 /*0x80*/, ES3Parser.Follow._RPAREN_in_switchStatement6410));
      this.adaptor.AddChild(obj1, obj4);
      object obj5 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 85, ES3Parser.Follow._LBRACE_in_switchStatement6415));
      this.adaptor.AddChild(obj1, obj5);
      while (true)
      {
        int num3 = 3;
        int num4 = ((IIntStream) this.input).LA(1);
        if (num4 == 34 && num1 == 0)
          num3 = 1;
        else if (num4 == 21)
          num3 = 2;
        switch (num3)
        {
          case 1:
            if (num1 == 0)
            {
              ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._defaultClause_in_switchStatement6422);
              ES3Parser.defaultClause_return defaultClauseReturn = this.defaultClause();
              ((BaseRecognizer) this).PopFollow();
              this.adaptor.AddChild(obj1, defaultClauseReturn.Tree);
              ++num1;
              switchStatement.DefaultStatements = (Statement) defaultClauseReturn?.value;
              switchStatement.DefaultClauseIndex = num2++;
              continue;
            }
            goto label_8;
          case 2:
            ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._caseClause_in_switchStatement6428);
            ES3Parser.caseClause_return caseClauseReturn = this.caseClause();
            ((BaseRecognizer) this).PopFollow();
            this.adaptor.AddChild(obj1, caseClauseReturn.Tree);
            switchStatement.CaseClauses.Add(caseClauseReturn?.value);
            ++num2;
            continue;
          default:
            goto label_11;
        }
      }
label_8:
      throw new FailedPredicateException((IIntStream) this.input, nameof (switchStatement), " defaultClauseCount == 0 ");
label_11:
      object obj6 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 125, ES3Parser.Follow._RBRACE_in_switchStatement6435));
      this.adaptor.AddChild(obj1, obj6);
      switchStatementReturn.Stop = this.input.LT(-1);
      switchStatementReturn.Tree = this.adaptor.RulePostProcessing(obj1);
      this.adaptor.SetTokenBoundaries(switchStatementReturn.Tree, switchStatementReturn.Start, switchStatementReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      switchStatementReturn.Tree = this.adaptor.ErrorNode(this.input, switchStatementReturn.Start, this.input.LT(-1), ex);
    }
    return switchStatementReturn;
  }

  [GrammarRule("caseClause")]
  private ES3Parser.caseClause_return caseClause()
  {
    ES3Parser.caseClause_return caseClauseReturn = new ES3Parser.caseClause_return(this);
    caseClauseReturn.Start = this.input.LT(1);
    caseClauseReturn.value = new CaseClause();
    try
    {
      object obj1 = this.adaptor.Nil();
      object obj2 = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 21, ES3Parser.Follow._CASE_in_caseClause6458)), obj1);
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._expression_in_caseClause6461);
      ES3Parser.expression_return expressionReturn = this.expression();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj2, expressionReturn.Tree);
      caseClauseReturn.value.Expression = expressionReturn?.value;
      IToken itoken = (IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 26, ES3Parser.Follow._COLON_in_caseClause6465);
      while (true)
      {
        int num1 = 2;
        int num2 = ((IIntStream) this.input).LA(1);
        if (num2 == 5 || num2 == 14 || num2 == 29 || num2 == 33 || num2 == 35 || num2 == 38 || num2 == 44 || num2 == 54 || num2 == 59 || num2 == 62 || num2 >= 68 && num2 <= 69 || num2 == 73 || num2 == 77 || num2 == 79 || num2 >= 85 && num2 <= 86 || num2 == 90 || num2 >= 105 && num2 <= 106 || num2 == 108 || num2 == 114 || num2 == (int) sbyte.MaxValue || num2 == 131 || num2 == 133 || num2 == 144 /*0x90*/ || num2 == 147 || num2 == 150 || num2 >= 152 && num2 <= 153 || num2 >= 156 && num2 <= 158 || num2 >= 161 && num2 <= 162 || num2 >= 165 && num2 <= 166)
          num1 = 1;
        if (num1 == 1)
        {
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._statement_in_caseClause6469);
          ES3Parser.statement_return statementReturn = this.statement();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj2, statementReturn.Tree);
          caseClauseReturn.value.Statements.Statements.AddLast(statementReturn?.value);
        }
        else
          break;
      }
      caseClauseReturn.Stop = this.input.LT(-1);
      caseClauseReturn.Tree = this.adaptor.RulePostProcessing(obj2);
      this.adaptor.SetTokenBoundaries(caseClauseReturn.Tree, caseClauseReturn.Start, caseClauseReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      caseClauseReturn.Tree = this.adaptor.ErrorNode(this.input, caseClauseReturn.Start, this.input.LT(-1), ex);
    }
    return caseClauseReturn;
  }

  [GrammarRule("defaultClause")]
  private ES3Parser.defaultClause_return defaultClause()
  {
    ES3Parser.defaultClause_return defaultClauseReturn = new ES3Parser.defaultClause_return(this);
    defaultClauseReturn.Start = this.input.LT(1);
    defaultClauseReturn.value = new BlockStatement();
    try
    {
      object obj1 = this.adaptor.Nil();
      object obj2 = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 34, ES3Parser.Follow._DEFAULT_in_defaultClause6494)), obj1);
      IToken itoken = (IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 26, ES3Parser.Follow._COLON_in_defaultClause6497);
      while (true)
      {
        int num1 = 2;
        int num2 = ((IIntStream) this.input).LA(1);
        if (num2 == 5 || num2 == 14 || num2 == 29 || num2 == 33 || num2 == 35 || num2 == 38 || num2 == 44 || num2 == 54 || num2 == 59 || num2 == 62 || num2 >= 68 && num2 <= 69 || num2 == 73 || num2 == 77 || num2 == 79 || num2 >= 85 && num2 <= 86 || num2 == 90 || num2 >= 105 && num2 <= 106 || num2 == 108 || num2 == 114 || num2 == (int) sbyte.MaxValue || num2 == 131 || num2 == 133 || num2 == 144 /*0x90*/ || num2 == 147 || num2 == 150 || num2 >= 152 && num2 <= 153 || num2 >= 156 && num2 <= 158 || num2 >= 161 && num2 <= 162 || num2 >= 165 && num2 <= 166)
          num1 = 1;
        if (num1 == 1)
        {
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._statement_in_defaultClause6501);
          ES3Parser.statement_return statementReturn = this.statement();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj2, statementReturn.Tree);
          defaultClauseReturn.value.Statements.AddLast(statementReturn?.value);
        }
        else
          break;
      }
      defaultClauseReturn.Stop = this.input.LT(-1);
      defaultClauseReturn.Tree = this.adaptor.RulePostProcessing(obj2);
      this.adaptor.SetTokenBoundaries(defaultClauseReturn.Tree, defaultClauseReturn.Start, defaultClauseReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      defaultClauseReturn.Tree = this.adaptor.ErrorNode(this.input, defaultClauseReturn.Start, this.input.LT(-1), ex);
    }
    return defaultClauseReturn;
  }

  [GrammarRule("labelledStatement")]
  private ES3Parser.labelledStatement_return labelledStatement()
  {
    ES3Parser.labelledStatement_return labelledStatementReturn = new ES3Parser.labelledStatement_return(this);
    labelledStatementReturn.Start = this.input.LT(1);
    try
    {
      object obj1 = this.adaptor.Nil();
      IToken itoken = (IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 79, ES3Parser.Follow._Identifier_in_labelledStatement6528);
      object obj2 = this.adaptor.Create(itoken);
      this.adaptor.AddChild(obj1, obj2);
      object obj3 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 26, ES3Parser.Follow._COLON_in_labelledStatement6530));
      this.adaptor.AddChild(obj1, obj3);
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._statement_in_labelledStatement6534);
      ES3Parser.statement_return statementReturn = this.statement();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj1, statementReturn.Tree);
      labelledStatementReturn.value = statementReturn.value;
      labelledStatementReturn.value.Label = itoken.Text;
      labelledStatementReturn.Stop = this.input.LT(-1);
      labelledStatementReturn.Tree = this.adaptor.RulePostProcessing(obj1);
      this.adaptor.SetTokenBoundaries(labelledStatementReturn.Tree, labelledStatementReturn.Start, labelledStatementReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      labelledStatementReturn.Tree = this.adaptor.ErrorNode(this.input, labelledStatementReturn.Start, this.input.LT(-1), ex);
    }
    return labelledStatementReturn;
  }

  [GrammarRule("throwStatement")]
  private ES3Parser.throwStatement_return throwStatement()
  {
    ES3Parser.throwStatement_return throwStatementReturn = new ES3Parser.throwStatement_return(this);
    throwStatementReturn.Start = this.input.LT(1);
    try
    {
      object obj1 = this.adaptor.Nil();
      object obj2 = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 153, ES3Parser.Follow._THROW_in_throwStatement6560)), obj1);
      this.PromoteEOL((ParserRuleReturnScope<IToken>) null);
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._expression_in_throwStatement6567);
      ES3Parser.expression_return expressionReturn = this.expression();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj2, expressionReturn.Tree);
      throwStatementReturn.value = (Statement) new ThrowStatement(expressionReturn.value);
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._semic_in_throwStatement6571);
      this.semic();
      ((BaseRecognizer) this).PopFollow();
      throwStatementReturn.Stop = this.input.LT(-1);
      throwStatementReturn.Tree = this.adaptor.RulePostProcessing(obj2);
      this.adaptor.SetTokenBoundaries(throwStatementReturn.Tree, throwStatementReturn.Start, throwStatementReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      throwStatementReturn.Tree = this.adaptor.ErrorNode(this.input, throwStatementReturn.Start, this.input.LT(-1), ex);
    }
    return throwStatementReturn;
  }

  [GrammarRule("tryStatement")]
  private ES3Parser.tryStatement_return tryStatement()
  {
    ES3Parser.tryStatement_return tryStatementReturn = new ES3Parser.tryStatement_return(this);
    tryStatementReturn.Start = this.input.LT(1);
    tryStatementReturn.value = new TryStatement();
    try
    {
      object obj1 = this.adaptor.Nil();
      object obj2 = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 157, ES3Parser.Follow._TRY_in_tryStatement6596)), obj1);
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._block_in_tryStatement6601);
      ES3Parser.block_return blockReturn = this.block();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj2, blockReturn.Tree);
      tryStatementReturn.value.Statement = (Statement) blockReturn.value;
      int num1;
      switch (((IIntStream) this.input).LA(1))
      {
        case 22:
          num1 = 1;
          break;
        case 57:
          num1 = 2;
          break;
        default:
          throw new NoViableAltException("", 83, 0, (IIntStream) this.input);
      }
      switch (num1)
      {
        case 1:
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._catchClause_in_tryStatement6610);
          ES3Parser.catchClause_return catchClauseReturn = this.catchClause();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj2, catchClauseReturn.Tree);
          tryStatementReturn.value.Catch = catchClauseReturn.value;
          int num2 = 2;
          if (((IIntStream) this.input).LA(1) == 57)
            num2 = 1;
          if (num2 == 1)
          {
            ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._finallyClause_in_tryStatement6617);
            ES3Parser.finallyClause_return finallyClauseReturn = this.finallyClause();
            ((BaseRecognizer) this).PopFollow();
            this.adaptor.AddChild(obj2, finallyClauseReturn.Tree);
            tryStatementReturn.value.Finally = finallyClauseReturn.value;
            break;
          }
          break;
        case 2:
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._finallyClause_in_tryStatement6627);
          ES3Parser.finallyClause_return finallyClauseReturn1 = this.finallyClause();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj2, finallyClauseReturn1.Tree);
          tryStatementReturn.value.Finally = finallyClauseReturn1.value;
          break;
      }
      tryStatementReturn.Stop = this.input.LT(-1);
      tryStatementReturn.Tree = this.adaptor.RulePostProcessing(obj2);
      this.adaptor.SetTokenBoundaries(tryStatementReturn.Tree, tryStatementReturn.Start, tryStatementReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      tryStatementReturn.Tree = this.adaptor.ErrorNode(this.input, tryStatementReturn.Start, this.input.LT(-1), ex);
    }
    return tryStatementReturn;
  }

  [GrammarRule("catchClause")]
  private ES3Parser.catchClause_return catchClause()
  {
    ES3Parser.catchClause_return catchClauseReturn = new ES3Parser.catchClause_return(this);
    catchClauseReturn.Start = this.input.LT(1);
    try
    {
      object obj1 = this.adaptor.Nil();
      object obj2 = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 22, ES3Parser.Follow._CATCH_in_catchClause6647)), obj1);
      IToken itoken1 = (IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 90, ES3Parser.Follow._LPAREN_in_catchClause6650);
      IToken itoken2 = (IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 79, ES3Parser.Follow._Identifier_in_catchClause6655);
      object obj3 = this.adaptor.Create(itoken2);
      this.adaptor.AddChild(obj2, obj3);
      IToken itoken3 = (IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 128 /*0x80*/, ES3Parser.Follow._RPAREN_in_catchClause6657);
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._block_in_catchClause6660);
      ES3Parser.block_return blockReturn = this.block();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj2, blockReturn.Tree);
      catchClauseReturn.value = new CatchClause(itoken2?.Text, (Statement) blockReturn?.value);
      catchClauseReturn.Stop = this.input.LT(-1);
      catchClauseReturn.Tree = this.adaptor.RulePostProcessing(obj2);
      this.adaptor.SetTokenBoundaries(catchClauseReturn.Tree, catchClauseReturn.Start, catchClauseReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      catchClauseReturn.Tree = this.adaptor.ErrorNode(this.input, catchClauseReturn.Start, this.input.LT(-1), ex);
    }
    return catchClauseReturn;
  }

  [GrammarRule("finallyClause")]
  private ES3Parser.finallyClause_return finallyClause()
  {
    ES3Parser.finallyClause_return finallyClauseReturn = new ES3Parser.finallyClause_return(this);
    finallyClauseReturn.Start = this.input.LT(1);
    try
    {
      object obj1 = this.adaptor.Nil();
      object obj2 = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 57, ES3Parser.Follow._FINALLY_in_finallyClause6678)), obj1);
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._block_in_finallyClause6681);
      ES3Parser.block_return blockReturn = this.block();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj2, blockReturn.Tree);
      finallyClauseReturn.value = new FinallyClause((Statement) blockReturn?.value);
      finallyClauseReturn.Stop = this.input.LT(-1);
      finallyClauseReturn.Tree = this.adaptor.RulePostProcessing(obj2);
      this.adaptor.SetTokenBoundaries(finallyClauseReturn.Tree, finallyClauseReturn.Start, finallyClauseReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      finallyClauseReturn.Tree = this.adaptor.ErrorNode(this.input, finallyClauseReturn.Start, this.input.LT(-1), ex);
    }
    return finallyClauseReturn;
  }

  [GrammarRule("functionDeclaration")]
  private ES3Parser.functionDeclaration_return functionDeclaration()
  {
    ES3Parser.functionDeclaration_return declarationReturn = new ES3Parser.functionDeclaration_return(this);
    declarationReturn.Start = this.input.LT(1);
    FunctionDeclarationStatement declarationStatement = new FunctionDeclarationStatement();
    declarationReturn.value = (Statement) new EmptyStatement();
    this._currentBody.AddFirst((Statement) declarationStatement);
    try
    {
      object obj1 = this.adaptor.Nil();
      object obj2 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 62, ES3Parser.Follow._FUNCTION_in_functionDeclaration6713));
      this.adaptor.AddChild(obj1, obj2);
      IToken itoken = (IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 79, ES3Parser.Follow._Identifier_in_functionDeclaration6718);
      object obj3 = this.adaptor.Create(itoken);
      this.adaptor.AddChild(obj1, obj3);
      declarationStatement.Name = itoken.Text;
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._formalParameterList_in_functionDeclaration6728);
      ES3Parser.formalParameterList_return parameterListReturn = this.formalParameterList();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj1, parameterListReturn.Tree);
      declarationStatement.Parameters.AddRange((IEnumerable<string>) parameterListReturn.value);
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._functionBody_in_functionDeclaration6737);
      ES3Parser.functionBody_return functionBodyReturn = this.functionBody();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj1, functionBodyReturn.Tree);
      declarationStatement.Statement = (Statement) functionBodyReturn.value;
      declarationReturn.Stop = this.input.LT(-1);
      declarationReturn.Tree = this.adaptor.RulePostProcessing(obj1);
      this.adaptor.SetTokenBoundaries(declarationReturn.Tree, declarationReturn.Start, declarationReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      declarationReturn.Tree = this.adaptor.ErrorNode(this.input, declarationReturn.Start, this.input.LT(-1), ex);
    }
    return declarationReturn;
  }

  [GrammarRule("functionExpression")]
  private ES3Parser.functionExpression_return functionExpression()
  {
    ES3Parser.functionExpression_return expressionReturn = new ES3Parser.functionExpression_return(this);
    expressionReturn.Start = this.input.LT(1);
    expressionReturn.value = new FunctionExpression();
    try
    {
      object obj1 = this.adaptor.Nil();
      object obj2 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 62, ES3Parser.Follow._FUNCTION_in_functionExpression6764));
      this.adaptor.AddChild(obj1, obj2);
      int num = 2;
      if (((IIntStream) this.input).LA(1) == 79)
        num = 1;
      if (num == 1)
      {
        IToken itoken = (IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 79, ES3Parser.Follow._Identifier_in_functionExpression6769);
        object obj3 = this.adaptor.Create(itoken);
        this.adaptor.AddChild(obj1, obj3);
        expressionReturn.value.Name = itoken.Text;
      }
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._formalParameterList_in_functionExpression6776);
      ES3Parser.formalParameterList_return parameterListReturn = this.formalParameterList();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj1, parameterListReturn.Tree);
      expressionReturn.value.Parameters.AddRange((IEnumerable<string>) parameterListReturn?.value);
      ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._functionBody_in_functionExpression6780);
      ES3Parser.functionBody_return functionBodyReturn = this.functionBody();
      ((BaseRecognizer) this).PopFollow();
      this.adaptor.AddChild(obj1, functionBodyReturn.Tree);
      expressionReturn.value.Statement = (Statement) functionBodyReturn?.value;
      expressionReturn.Stop = this.input.LT(-1);
      expressionReturn.Tree = this.adaptor.RulePostProcessing(obj1);
      this.adaptor.SetTokenBoundaries(expressionReturn.Tree, expressionReturn.Start, expressionReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      expressionReturn.Tree = this.adaptor.ErrorNode(this.input, expressionReturn.Start, this.input.LT(-1), ex);
    }
    return expressionReturn;
  }

  [GrammarRule("formalParameterList")]
  private ES3Parser.formalParameterList_return formalParameterList()
  {
    ES3Parser.formalParameterList_return parameterListReturn = new ES3Parser.formalParameterList_return(this);
    parameterListReturn.Start = this.input.LT(1);
    List<string> stringList = new List<string>();
    parameterListReturn.value = stringList;
    try
    {
      object obj1 = this.adaptor.Nil();
      object obj2 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 90, ES3Parser.Follow._LPAREN_in_formalParameterList6805));
      this.adaptor.AddChild(obj1, obj2);
      int num1 = 2;
      if (((IIntStream) this.input).LA(1) == 79)
        num1 = 1;
      if (num1 == 1)
      {
        IToken itoken1 = (IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 79, ES3Parser.Follow._Identifier_in_formalParameterList6811);
        object obj3 = this.adaptor.Create(itoken1);
        this.adaptor.AddChild(obj1, obj3);
        stringList.Add(itoken1?.Text);
        while (true)
        {
          int num2 = 2;
          if (((IIntStream) this.input).LA(1) == 27)
            num2 = 1;
          if (num2 == 1)
          {
            object obj4 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 27, ES3Parser.Follow._COMMA_in_formalParameterList6817));
            this.adaptor.AddChild(obj1, obj4);
            IToken itoken2 = (IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 79, ES3Parser.Follow._Identifier_in_formalParameterList6821);
            object obj5 = this.adaptor.Create(itoken2);
            this.adaptor.AddChild(obj1, obj5);
            stringList.Add(itoken2?.Text);
          }
          else
            break;
        }
      }
      object obj6 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 128 /*0x80*/, ES3Parser.Follow._RPAREN_in_formalParameterList6832));
      this.adaptor.AddChild(obj1, obj6);
      parameterListReturn.Stop = this.input.LT(-1);
      parameterListReturn.Tree = this.adaptor.RulePostProcessing(obj1);
      this.adaptor.SetTokenBoundaries(parameterListReturn.Tree, parameterListReturn.Start, parameterListReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      parameterListReturn.Tree = this.adaptor.ErrorNode(this.input, parameterListReturn.Start, this.input.LT(-1), ex);
    }
    return parameterListReturn;
  }

  [GrammarRule("functionBody")]
  private ES3Parser.functionBody_return functionBody()
  {
    ES3Parser.functionBody_return functionBodyReturn = new ES3Parser.functionBody_return(this);
    functionBodyReturn.Start = this.input.LT(1);
    BlockStatement blockStatement = new BlockStatement();
    LinkedList<Statement> currentBody = this._currentBody;
    this._currentBody = blockStatement.Statements;
    functionBodyReturn.value = blockStatement;
    try
    {
      object obj1 = this.adaptor.Nil();
      object obj2 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 85, ES3Parser.Follow._LBRACE_in_functionBody6859));
      this.adaptor.AddChild(obj1, obj2);
      while (true)
      {
        int num1 = 2;
        int num2 = ((IIntStream) this.input).LA(1);
        if (num2 == 5 || num2 == 14 || num2 == 29 || num2 == 33 || num2 == 35 || num2 == 38 || num2 == 44 || num2 == 54 || num2 == 59 || num2 == 62 || num2 >= 68 && num2 <= 69 || num2 == 73 || num2 == 77 || num2 == 79 || num2 >= 85 && num2 <= 86 || num2 == 90 || num2 >= 105 && num2 <= 106 || num2 == 108 || num2 == 114 || num2 == (int) sbyte.MaxValue || num2 == 131 || num2 == 133 || num2 == 144 /*0x90*/ || num2 == 147 || num2 == 150 || num2 >= 152 && num2 <= 153 || num2 >= 156 && num2 <= 158 || num2 >= 161 && num2 <= 162 || num2 >= 165 && num2 <= 166)
          num1 = 1;
        if (num1 == 1)
        {
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._sourceElement_in_functionBody6862);
          ES3Parser.sourceElement_return sourceElementReturn = this.sourceElement();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj1, sourceElementReturn.Tree);
          blockStatement.Statements.AddLast(sourceElementReturn?.value);
        }
        else
          break;
      }
      object obj3 = this.adaptor.Create((IToken) ((BaseRecognizer) this).Match((IIntStream) this.input, 125, ES3Parser.Follow._RBRACE_in_functionBody6869));
      this.adaptor.AddChild(obj1, obj3);
      functionBodyReturn.Stop = this.input.LT(-1);
      functionBodyReturn.Tree = this.adaptor.RulePostProcessing(obj1);
      this.adaptor.SetTokenBoundaries(functionBodyReturn.Tree, functionBodyReturn.Start, functionBodyReturn.Stop);
      this._currentBody = currentBody;
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      functionBodyReturn.Tree = this.adaptor.ErrorNode(this.input, functionBodyReturn.Start, this.input.LT(-1), ex);
    }
    return functionBodyReturn;
  }

  [GrammarRule("program")]
  internal ES3Parser.program_return program()
  {
    ES3Parser.program_return programReturn = new ES3Parser.program_return(this);
    programReturn.Start = this.input.LT(1);
    this.script = this.input.ToString().Split('\n');
    Program program = new Program();
    this._currentBody = program.Statements;
    try
    {
      object obj = this.adaptor.Nil();
      while (true)
      {
        int num1 = 2;
        int num2 = ((IIntStream) this.input).LA(1);
        if (num2 == 5 || num2 == 14 || num2 == 29 || num2 == 33 || num2 == 35 || num2 == 38 || num2 == 44 || num2 == 54 || num2 == 59 || num2 == 62 || num2 >= 68 && num2 <= 69 || num2 == 73 || num2 == 77 || num2 == 79 || num2 >= 85 && num2 <= 86 || num2 == 90 || num2 >= 105 && num2 <= 106 || num2 == 108 || num2 == 114 || num2 == (int) sbyte.MaxValue || num2 == 131 || num2 == 133 || num2 == 144 /*0x90*/ || num2 == 147 || num2 == 150 || num2 >= 152 && num2 <= 153 || num2 >= 156 && num2 <= 158 || num2 >= 161 && num2 <= 162 || num2 >= 165 && num2 <= 166)
          num1 = 1;
        if (num1 == 1)
        {
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._sourceElement_in_program6898);
          ES3Parser.sourceElement_return sourceElementReturn = this.sourceElement();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj, sourceElementReturn.Tree);
          program.Statements.AddLast(sourceElementReturn.value);
        }
        else
          break;
      }
      programReturn.value = program;
      programReturn.Stop = this.input.LT(-1);
      programReturn.Tree = this.adaptor.RulePostProcessing(obj);
      this.adaptor.SetTokenBoundaries(programReturn.Tree, programReturn.Start, programReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      programReturn.Tree = this.adaptor.ErrorNode(this.input, programReturn.Start, this.input.LT(-1), ex);
    }
    return programReturn;
  }

  [GrammarRule("sourceElement")]
  private ES3Parser.sourceElement_return sourceElement()
  {
    ES3Parser.sourceElement_return sourceElementReturn = new ES3Parser.sourceElement_return(this);
    sourceElementReturn.Start = this.input.LT(1);
    object obj = (object) null;
    try
    {
      int num;
      try
      {
        num = this.dfa89.Predict((IIntStream) this.input);
      }
      catch (NoViableAltException ex)
      {
        throw;
      }
      switch (num)
      {
        case 1:
          obj = this.adaptor.Nil();
          if (((IIntStream) this.input).LA(1) != 62)
            throw new FailedPredicateException((IIntStream) this.input, nameof (sourceElement), " input.LA(1) == FUNCTION ");
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._functionDeclaration_in_sourceElement6939);
          ES3Parser.functionDeclaration_return declarationReturn = this.functionDeclaration();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj, declarationReturn.Tree);
          sourceElementReturn.value = declarationReturn.value;
          break;
        case 2:
          obj = this.adaptor.Nil();
          ((BaseRecognizer) this).PushFollow(ES3Parser.Follow._statement_in_sourceElement6948);
          ES3Parser.statement_return statementReturn = this.statement();
          ((BaseRecognizer) this).PopFollow();
          this.adaptor.AddChild(obj, statementReturn.Tree);
          sourceElementReturn.value = statementReturn.value;
          break;
      }
      sourceElementReturn.Stop = this.input.LT(-1);
      sourceElementReturn.Tree = this.adaptor.RulePostProcessing(obj);
      this.adaptor.SetTokenBoundaries(sourceElementReturn.Tree, sourceElementReturn.Start, sourceElementReturn.Stop);
    }
    catch (RecognitionException ex)
    {
      ((BaseRecognizer) this).ReportError(ex);
      ((BaseRecognizer) this).Recover((IIntStream) this.input, ex);
      sourceElementReturn.Tree = this.adaptor.ErrorNode(this.input, sourceElementReturn.Start, this.input.LT(-1), ex);
    }
    return sourceElementReturn;
  }

  protected virtual void InitDFAs()
  {
    ((BaseRecognizer) this).InitDFAs();
    // ISSUE: method pointer
    this.dfa58 = new ES3Parser.DFA58((BaseRecognizer) this, new SpecialStateTransitionHandler((object) this, __methodptr(SpecialStateTransition58)));
    this.dfa59 = new ES3Parser.DFA59((BaseRecognizer) this);
    // ISSUE: method pointer
    this.dfa89 = new ES3Parser.DFA89((BaseRecognizer) this, new SpecialStateTransitionHandler((object) this, __methodptr(SpecialStateTransition89)));
  }

  private int SpecialStateTransition58(DFA dfa, int s, IIntStream _input)
  {
    ITokenStream itokenStream = (ITokenStream) _input;
    int num = s;
    switch (s)
    {
      case 0:
        ((IIntStream) itokenStream).LA(1);
        int index1 = ((IIntStream) itokenStream).Index;
        ((IIntStream) itokenStream).Rewind();
        s = -1;
        s = ((IIntStream) itokenStream).LA(1) != 85 ? 3 : 38;
        ((IIntStream) itokenStream).Seek(index1);
        if (s >= 0)
          return s;
        break;
      case 1:
        ((IIntStream) itokenStream).LA(1);
        int index2 = ((IIntStream) itokenStream).Index;
        ((IIntStream) itokenStream).Rewind();
        s = -1;
        s = ((IIntStream) itokenStream).LA(1) != 62 ? 3 : 39;
        ((IIntStream) itokenStream).Seek(index2);
        if (s >= 0)
          return s;
        break;
    }
    NoViableAltException viableAltException = new NoViableAltException(dfa.Description, 58, num, (IIntStream) itokenStream);
    dfa.Error(viableAltException);
    throw viableAltException;
  }

  private int SpecialStateTransition89(DFA dfa, int s, IIntStream _input)
  {
    ITokenStream itokenStream = (ITokenStream) _input;
    int num = s;
    if (s == 0)
    {
      ((IIntStream) itokenStream).LA(1);
      int index = ((IIntStream) itokenStream).Index;
      ((IIntStream) itokenStream).Rewind();
      s = -1;
      s = ((IIntStream) itokenStream).LA(1) != 62 ? 2 : 38;
      ((IIntStream) itokenStream).Seek(index);
      if (s >= 0)
        return s;
    }
    NoViableAltException viableAltException = new NoViableAltException(dfa.Description, 89, num, (IIntStream) itokenStream);
    dfa.Error(viableAltException);
    throw viableAltException;
  }

  private sealed class token_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public token_return(ES3Parser grammar)
    {
    }
  }

  private sealed class reservedWord_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public reservedWord_return(ES3Parser grammar)
    {
    }
  }

  private sealed class keyword_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public keyword_return(ES3Parser grammar)
    {
    }
  }

  private sealed class futureReservedWord_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public futureReservedWord_return(ES3Parser grammar)
    {
    }
  }

  private sealed class punctuator_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public punctuator_return(ES3Parser grammar)
    {
    }
  }

  private sealed class literal_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public literal_return(ES3Parser grammar)
    {
    }
  }

  private sealed class booleanLiteral_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public bool value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public booleanLiteral_return(ES3Parser grammar)
    {
    }
  }

  private sealed class numericLiteral_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public double value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public numericLiteral_return(ES3Parser grammar)
    {
    }
  }

  private sealed class primaryExpression_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public primaryExpression_return(ES3Parser grammar)
    {
    }
  }

  private sealed class arrayLiteral_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public ArrayDeclaration value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public arrayLiteral_return(ES3Parser grammar)
    {
    }
  }

  private sealed class arrayItem_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Statement value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public arrayItem_return(ES3Parser grammar)
    {
    }
  }

  private sealed class objectLiteral_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public JsonExpression value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public objectLiteral_return(ES3Parser grammar)
    {
    }
  }

  private sealed class propertyAssignment_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public PropertyDeclarationExpression value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public propertyAssignment_return(ES3Parser grammar)
    {
    }
  }

  private sealed class accessor_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public PropertyExpressionType value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public accessor_return(ES3Parser grammar)
    {
    }
  }

  private sealed class propertyName_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public string value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public propertyName_return(ES3Parser grammar)
    {
    }
  }

  private sealed class memberExpression_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public memberExpression_return(ES3Parser grammar)
    {
    }
  }

  private sealed class newExpression_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public NewExpression value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public newExpression_return(ES3Parser grammar)
    {
    }
  }

  private sealed class arguments_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public List<Expression> value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public arguments_return(ES3Parser grammar)
    {
    }
  }

  private sealed class generics_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public List<Expression> value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public generics_return(ES3Parser grammar)
    {
    }
  }

  private sealed class leftHandSideExpression_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public leftHandSideExpression_return(ES3Parser grammar)
    {
    }
  }

  private sealed class postfixExpression_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public postfixExpression_return(ES3Parser grammar)
    {
    }
  }

  private sealed class postfixOperator_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public UnaryExpressionType value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public postfixOperator_return(ES3Parser grammar)
    {
    }
  }

  private sealed class unaryExpression_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public unaryExpression_return(ES3Parser grammar)
    {
    }
  }

  private sealed class unaryOperator_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public UnaryExpressionType value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public unaryOperator_return(ES3Parser grammar)
    {
    }
  }

  private sealed class multiplicativeExpression_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public multiplicativeExpression_return(ES3Parser grammar)
    {
    }
  }

  private sealed class additiveExpression_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public additiveExpression_return(ES3Parser grammar)
    {
    }
  }

  private sealed class shiftExpression_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public shiftExpression_return(ES3Parser grammar)
    {
    }
  }

  private sealed class relationalExpression_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public relationalExpression_return(ES3Parser grammar)
    {
    }
  }

  private sealed class relationalExpressionNoIn_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public relationalExpressionNoIn_return(ES3Parser grammar)
    {
    }
  }

  private sealed class equalityExpression_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public equalityExpression_return(ES3Parser grammar)
    {
    }
  }

  private sealed class equalityExpressionNoIn_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public equalityExpressionNoIn_return(ES3Parser grammar)
    {
    }
  }

  private sealed class bitwiseANDExpression_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public bitwiseANDExpression_return(ES3Parser grammar)
    {
    }
  }

  private sealed class bitwiseANDExpressionNoIn_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public bitwiseANDExpressionNoIn_return(ES3Parser grammar)
    {
    }
  }

  private sealed class bitwiseXORExpression_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public bitwiseXORExpression_return(ES3Parser grammar)
    {
    }
  }

  private sealed class bitwiseXORExpressionNoIn_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public bitwiseXORExpressionNoIn_return(ES3Parser grammar)
    {
    }
  }

  private sealed class bitwiseORExpression_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public bitwiseORExpression_return(ES3Parser grammar)
    {
    }
  }

  private sealed class bitwiseORExpressionNoIn_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public bitwiseORExpressionNoIn_return(ES3Parser grammar)
    {
    }
  }

  private sealed class logicalANDExpression_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public logicalANDExpression_return(ES3Parser grammar)
    {
    }
  }

  private sealed class logicalANDExpressionNoIn_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public logicalANDExpressionNoIn_return(ES3Parser grammar)
    {
    }
  }

  private sealed class logicalORExpression_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public logicalORExpression_return(ES3Parser grammar)
    {
    }
  }

  private sealed class logicalORExpressionNoIn_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public logicalORExpressionNoIn_return(ES3Parser grammar)
    {
    }
  }

  private sealed class conditionalExpression_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public conditionalExpression_return(ES3Parser grammar)
    {
    }
  }

  private sealed class conditionalExpressionNoIn_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public conditionalExpressionNoIn_return(ES3Parser grammar)
    {
    }
  }

  private sealed class assignmentExpression_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public assignmentExpression_return(ES3Parser grammar)
    {
    }
  }

  private sealed class assignmentOperator_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public assignmentOperator_return(ES3Parser grammar)
    {
    }
  }

  private sealed class assignmentExpressionNoIn_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public assignmentExpressionNoIn_return(ES3Parser grammar)
    {
    }
  }

  private sealed class expression_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public expression_return(ES3Parser grammar)
    {
    }
  }

  private sealed class expressionNoIn_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public expressionNoIn_return(ES3Parser grammar)
    {
    }
  }

  private sealed class semic_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public semic_return(ES3Parser grammar)
    {
    }
  }

  private sealed class statement_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Statement value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public statement_return(ES3Parser grammar)
    {
    }
  }

  private sealed class statementTail_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Statement value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public statementTail_return(ES3Parser grammar)
    {
    }
  }

  private sealed class block_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public BlockStatement value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public block_return(ES3Parser grammar)
    {
    }
  }

  private sealed class variableStatement_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Statement value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public variableStatement_return(ES3Parser grammar)
    {
    }
  }

  private sealed class variableDeclaration_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public VariableDeclarationStatement value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public variableDeclaration_return(ES3Parser grammar)
    {
    }
  }

  private sealed class variableDeclarationNoIn_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public VariableDeclarationStatement value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public variableDeclarationNoIn_return(ES3Parser grammar)
    {
    }
  }

  private sealed class emptyStatement_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Statement value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public emptyStatement_return(ES3Parser grammar)
    {
    }
  }

  private sealed class expressionStatement_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Statement value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public expressionStatement_return(ES3Parser grammar)
    {
    }
  }

  private sealed class ifStatement_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Statement value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public ifStatement_return(ES3Parser grammar)
    {
    }
  }

  private sealed class iterationStatement_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Statement value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public iterationStatement_return(ES3Parser grammar)
    {
    }
  }

  private sealed class doStatement_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Statement value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public doStatement_return(ES3Parser grammar)
    {
    }
  }

  private sealed class whileStatement_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Statement value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public whileStatement_return(ES3Parser grammar)
    {
    }
  }

  private sealed class forStatement_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public IForStatement value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public forStatement_return(ES3Parser grammar)
    {
    }
  }

  private sealed class forControl_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public IForStatement value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public forControl_return(ES3Parser grammar)
    {
    }
  }

  private sealed class forControlVar_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public IForStatement value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public forControlVar_return(ES3Parser grammar)
    {
    }
  }

  private sealed class forControlExpression_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public IForStatement value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public forControlExpression_return(ES3Parser grammar)
    {
    }
  }

  private sealed class forControlSemic_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public ForStatement value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public forControlSemic_return(ES3Parser grammar)
    {
    }
  }

  private sealed class continueStatement_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Statement value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public continueStatement_return(ES3Parser grammar)
    {
    }
  }

  private sealed class breakStatement_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Statement value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public breakStatement_return(ES3Parser grammar)
    {
    }
  }

  private sealed class returnStatement_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public ReturnStatement value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public returnStatement_return(ES3Parser grammar)
    {
    }
  }

  private sealed class withStatement_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Statement value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public withStatement_return(ES3Parser grammar)
    {
    }
  }

  private sealed class switchStatement_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Statement value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public switchStatement_return(ES3Parser grammar)
    {
    }
  }

  private sealed class caseClause_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public CaseClause value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public caseClause_return(ES3Parser grammar)
    {
    }
  }

  private sealed class defaultClause_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public BlockStatement value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public defaultClause_return(ES3Parser grammar)
    {
    }
  }

  private sealed class labelledStatement_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Statement value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public labelledStatement_return(ES3Parser grammar)
    {
    }
  }

  private sealed class throwStatement_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Statement value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public throwStatement_return(ES3Parser grammar)
    {
    }
  }

  private sealed class tryStatement_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public TryStatement value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public tryStatement_return(ES3Parser grammar)
    {
    }
  }

  private sealed class catchClause_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public CatchClause value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public catchClause_return(ES3Parser grammar)
    {
    }
  }

  private sealed class finallyClause_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public FinallyClause value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public finallyClause_return(ES3Parser grammar)
    {
    }
  }

  private sealed class functionDeclaration_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Statement value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public functionDeclaration_return(ES3Parser grammar)
    {
    }
  }

  private sealed class functionExpression_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public FunctionExpression value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public functionExpression_return(ES3Parser grammar)
    {
    }
  }

  private sealed class formalParameterList_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public List<string> value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public formalParameterList_return(ES3Parser grammar)
    {
    }
  }

  private sealed class functionBody_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public BlockStatement value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public functionBody_return(ES3Parser grammar)
    {
    }
  }

  internal sealed class program_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Program value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public program_return(ES3Parser grammar)
    {
    }
  }

  private sealed class sourceElement_return : 
    ParserRuleReturnScope<IToken>,
    IAstRuleReturnScope<object>,
    IAstRuleReturnScope,
    IRuleReturnScope
  {
    public Statement value;
    private object _tree;

    public object Tree
    {
      get => this._tree;
      set => this._tree = value;
    }

    object IAstRuleReturnScope.Tree => this.Tree;

    public sourceElement_return(ES3Parser grammar)
    {
    }
  }

  private class DFA58 : DFA
  {
    private const string DFA58_eotS = "(\uFFFF";
    private const string DFA58_eofS = "(\uFFFF";
    private const string DFA58_minS = "\u0001\u0005\u0002\0%\uFFFF";
    private const string DFA58_maxS = "\u0001¦\u0002\0%\uFFFF";
    private const string DFA58_acceptS = "\u0003\uFFFF\u0001\u0003\"\uFFFF\u0001\u0001\u0001\u0002";
    private const string DFA58_specialS = "\u0001\uFFFF\u0001\0\u0001\u0001%\uFFFF}>";
    private static readonly string[] DFA58_transitionS = new string[40]
    {
      "\u0001\u0003\b\uFFFF\u0001\u0003\u000E\uFFFF\u0001\u0003\u0003\uFFFF\u0001\u0003\u0001\uFFFF\u0001\u0003\u0002\uFFFF\u0001\u0003\u0005\uFFFF\u0001\u0003\t\uFFFF\u0001\u0003\u0004\uFFFF\u0001\u0003\u0002\uFFFF\u0001\u0002\u0005\uFFFF\u0002\u0003\u0003\uFFFF\u0001\u0003\u0003\uFFFF\u0001\u0003\u0001\uFFFF\u0001\u0003\u0005\uFFFF\u0001\u0001\u0001\u0003\u0003\uFFFF\u0001\u0003\u000E\uFFFF\u0002\u0003\u0001\uFFFF\u0001\u0003\u0005\uFFFF\u0001\u0003\f\uFFFF\u0001\u0003\u0003\uFFFF\u0001\u0003\u0001\uFFFF\u0001\u0003\n\uFFFF\u0001\u0003\u0002\uFFFF\u0001\u0003\u0002\uFFFF\u0001\u0003\u0001\uFFFF\u0002\u0003\u0002\uFFFF\u0003\u0003\u0002\uFFFF\u0002\u0003\u0002\uFFFF\u0002\u0003",
      "\u0001\uFFFF",
      "\u0001\uFFFF",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      ""
    };
    private static readonly short[] DFA58_eot = DFA.UnpackEncodedString("(\uFFFF");
    private static readonly short[] DFA58_eof = DFA.UnpackEncodedString("(\uFFFF");
    private static readonly char[] DFA58_min = DFA.UnpackEncodedStringToUnsignedChars("\u0001\u0005\u0002\0%\uFFFF");
    private static readonly char[] DFA58_max = DFA.UnpackEncodedStringToUnsignedChars("\u0001¦\u0002\0%\uFFFF");
    private static readonly short[] DFA58_accept = DFA.UnpackEncodedString("\u0003\uFFFF\u0001\u0003\"\uFFFF\u0001\u0001\u0001\u0002");
    private static readonly short[] DFA58_special = DFA.UnpackEncodedString("\u0001\uFFFF\u0001\0\u0001\u0001%\uFFFF}>");
    private static readonly short[][] DFA58_transition;

    static DFA58()
    {
      int length = ES3Parser.DFA58.DFA58_transitionS.Length;
      ES3Parser.DFA58.DFA58_transition = new short[length][];
      for (int index = 0; index < length; ++index)
        ES3Parser.DFA58.DFA58_transition[index] = DFA.UnpackEncodedString(ES3Parser.DFA58.DFA58_transitionS[index]);
    }

    public DFA58(
      BaseRecognizer recognizer,
      SpecialStateTransitionHandler specialStateTransition)
      : base(specialStateTransition)
    {
      this.recognizer = recognizer;
      this.decisionNumber = 58;
      this.eot = ES3Parser.DFA58.DFA58_eot;
      this.eof = ES3Parser.DFA58.DFA58_eof;
      this.min = ES3Parser.DFA58.DFA58_min;
      this.max = ES3Parser.DFA58.DFA58_max;
      this.accept = ES3Parser.DFA58.DFA58_accept;
      this.special = ES3Parser.DFA58.DFA58_special;
      this.transition = ES3Parser.DFA58.DFA58_transition;
    }

    public virtual string Description
    {
      get
      {
        return "1421:1: statement returns [Statement value] options {k=1; } : ({...}? block |{...}?func= functionDeclaration | statementTail );";
      }
    }

    public virtual void Error(NoViableAltException nvae)
    {
    }
  }

  private class DFA59 : DFA
  {
    private const string DFA59_eotS = "\u000F\uFFFF";
    private const string DFA59_eofS = "\u0004\uFFFF\u0001\u0003\n\uFFFF";
    private const string DFA59_minS = "\u0001\u0005\u0003\uFFFF\u0001\u0005\n\uFFFF";
    private const string DFA59_maxS = "\u0001¦\u0003\uFFFF\u0001©\n\uFFFF";
    private const string DFA59_acceptS = "\u0001\uFFFF\u0001\u0001\u0001\u0002\u0001\u0003\u0001\uFFFF\u0001\u0004\u0001\u0005\u0001\u0006\u0001\a\u0001\b\u0001\t\u0001\v\u0001\f\u0001\r\u0001\n";
    private const string DFA59_specialS = "\u000F\uFFFF}>";
    private static readonly string[] DFA59_transitionS = new string[15]
    {
      "\u0001\u0003\b\uFFFF\u0001\b\u000E\uFFFF\u0001\a\u0003\uFFFF\u0001\u0003\u0001\uFFFF\u0001\u0003\u0002\uFFFF\u0001\u0006\u0005\uFFFF\u0001\u0003\t\uFFFF\u0001\u0003\u0004\uFFFF\u0001\u0006\u0002\uFFFF\u0001\u0003\u0005\uFFFF\u0001\u0003\u0001\u0005\u0003\uFFFF\u0001\u0003\u0003\uFFFF\u0001\u0003\u0001\uFFFF\u0001\u0004\u0005\uFFFF\u0002\u0003\u0003\uFFFF\u0001\u0003\u000E\uFFFF\u0002\u0003\u0001\uFFFF\u0001\u0003\u0005\uFFFF\u0001\u0003\f\uFFFF\u0001\t\u0003\uFFFF\u0001\u0003\u0001\uFFFF\u0001\u0002\n\uFFFF\u0001\u0003\u0002\uFFFF\u0001\v\u0002\uFFFF\u0001\u0003\u0001\uFFFF\u0001\u0003\u0001\f\u0002\uFFFF\u0001\u0003\u0001\r\u0001\u0003\u0002\uFFFF\u0001\u0001\u0001\u0003\u0002\uFFFF\u0001\u0006\u0001\n",
      "",
      "",
      "",
      "\u0004\u0003\u0002\uFFFF\u0001\u0003\u000E\uFFFF\u0001\u000E\u0001\u0003\u0005\uFFFF\u0001\u0003\u0002\uFFFF\u0002\u0003\u0001\uFFFF\u0001\u0003\a\uFFFF\u0002\u0003\u000F\uFFFF\u0002\u0003\u0006\uFFFF\u0003\u0003\t\uFFFF\u0003\u0003\u0002\uFFFF\u0002\u0003\u0001\uFFFF\u0002\u0003\u0001\uFFFF\u0005\u0003\u0004\uFFFF\u0001\u0003\u0002\uFFFF\u0001\u0003\u0002\uFFFF\u0002\u0003\f\uFFFF\u0002\u0003\u0006\uFFFF\u0004\u0003\u0001\uFFFF\u0004\u0003\u0003\uFFFF\u0002\u0003\u0016\uFFFF\u0002\u0003",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      ""
    };
    private static readonly short[] DFA59_eot = DFA.UnpackEncodedString("\u000F\uFFFF");
    private static readonly short[] DFA59_eof = DFA.UnpackEncodedString("\u0004\uFFFF\u0001\u0003\n\uFFFF");
    private static readonly char[] DFA59_min = DFA.UnpackEncodedStringToUnsignedChars("\u0001\u0005\u0003\uFFFF\u0001\u0005\n\uFFFF");
    private static readonly char[] DFA59_max = DFA.UnpackEncodedStringToUnsignedChars("\u0001¦\u0003\uFFFF\u0001©\n\uFFFF");
    private static readonly short[] DFA59_accept = DFA.UnpackEncodedString("\u0001\uFFFF\u0001\u0001\u0001\u0002\u0001\u0003\u0001\uFFFF\u0001\u0004\u0001\u0005\u0001\u0006\u0001\a\u0001\b\u0001\t\u0001\v\u0001\f\u0001\r\u0001\n");
    private static readonly short[] DFA59_special = DFA.UnpackEncodedString("\u000F\uFFFF}>");
    private static readonly short[][] DFA59_transition;

    static DFA59()
    {
      int length = ES3Parser.DFA59.DFA59_transitionS.Length;
      ES3Parser.DFA59.DFA59_transition = new short[length][];
      for (int index = 0; index < length; ++index)
        ES3Parser.DFA59.DFA59_transition[index] = DFA.UnpackEncodedString(ES3Parser.DFA59.DFA59_transitionS[index]);
    }

    public DFA59(BaseRecognizer recognizer)
    {
      this.recognizer = recognizer;
      this.decisionNumber = 59;
      this.eot = ES3Parser.DFA59.DFA59_eot;
      this.eof = ES3Parser.DFA59.DFA59_eof;
      this.min = ES3Parser.DFA59.DFA59_min;
      this.max = ES3Parser.DFA59.DFA59_max;
      this.accept = ES3Parser.DFA59.DFA59_accept;
      this.special = ES3Parser.DFA59.DFA59_special;
      this.transition = ES3Parser.DFA59.DFA59_transition;
    }

    public virtual string Description
    {
      get
      {
        return "1432:1: statementTail returns [Statement value] : ( variableStatement | emptyStatement | expressionStatement | ifStatement | iterationStatement | continueStatement | breakStatement | returnStatement | withStatement | labelledStatement | switchStatement | throwStatement | tryStatement );";
      }
    }

    public virtual void Error(NoViableAltException nvae)
    {
    }
  }

  private class DFA89 : DFA
  {
    private const string DFA89_eotS = "'\uFFFF";
    private const string DFA89_eofS = "'\uFFFF";
    private const string DFA89_minS = "\u0001\u0005\u0001\0%\uFFFF";
    private const string DFA89_maxS = "\u0001¦\u0001\0%\uFFFF";
    private const string DFA89_acceptS = "\u0002\uFFFF\u0001\u0002#\uFFFF\u0001\u0001";
    private const string DFA89_specialS = "\u0001\uFFFF\u0001\0%\uFFFF}>";
    private static readonly string[] DFA89_transitionS = new string[39]
    {
      "\u0001\u0002\b\uFFFF\u0001\u0002\u000E\uFFFF\u0001\u0002\u0003\uFFFF\u0001\u0002\u0001\uFFFF\u0001\u0002\u0002\uFFFF\u0001\u0002\u0005\uFFFF\u0001\u0002\t\uFFFF\u0001\u0002\u0004\uFFFF\u0001\u0002\u0002\uFFFF\u0001\u0001\u0005\uFFFF\u0002\u0002\u0003\uFFFF\u0001\u0002\u0003\uFFFF\u0001\u0002\u0001\uFFFF\u0001\u0002\u0005\uFFFF\u0002\u0002\u0003\uFFFF\u0001\u0002\u000E\uFFFF\u0002\u0002\u0001\uFFFF\u0001\u0002\u0005\uFFFF\u0001\u0002\f\uFFFF\u0001\u0002\u0003\uFFFF\u0001\u0002\u0001\uFFFF\u0001\u0002\n\uFFFF\u0001\u0002\u0002\uFFFF\u0001\u0002\u0002\uFFFF\u0001\u0002\u0001\uFFFF\u0002\u0002\u0002\uFFFF\u0003\u0002\u0002\uFFFF\u0002\u0002\u0002\uFFFF\u0002\u0002",
      "\u0001\uFFFF",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      ""
    };
    private static readonly short[] DFA89_eot = DFA.UnpackEncodedString("'\uFFFF");
    private static readonly short[] DFA89_eof = DFA.UnpackEncodedString("'\uFFFF");
    private static readonly char[] DFA89_min = DFA.UnpackEncodedStringToUnsignedChars("\u0001\u0005\u0001\0%\uFFFF");
    private static readonly char[] DFA89_max = DFA.UnpackEncodedStringToUnsignedChars("\u0001¦\u0001\0%\uFFFF");
    private static readonly short[] DFA89_accept = DFA.UnpackEncodedString("\u0002\uFFFF\u0001\u0002#\uFFFF\u0001\u0001");
    private static readonly short[] DFA89_special = DFA.UnpackEncodedString("\u0001\uFFFF\u0001\0%\uFFFF}>");
    private static readonly short[][] DFA89_transition;

    static DFA89()
    {
      int length = ES3Parser.DFA89.DFA89_transitionS.Length;
      ES3Parser.DFA89.DFA89_transition = new short[length][];
      for (int index = 0; index < length; ++index)
        ES3Parser.DFA89.DFA89_transition[index] = DFA.UnpackEncodedString(ES3Parser.DFA89.DFA89_transitionS[index]);
    }

    public DFA89(
      BaseRecognizer recognizer,
      SpecialStateTransitionHandler specialStateTransition)
      : base(specialStateTransition)
    {
      this.recognizer = recognizer;
      this.decisionNumber = 89;
      this.eot = ES3Parser.DFA89.DFA89_eot;
      this.eof = ES3Parser.DFA89.DFA89_eof;
      this.min = ES3Parser.DFA89.DFA89_min;
      this.max = ES3Parser.DFA89.DFA89_max;
      this.accept = ES3Parser.DFA89.DFA89_accept;
      this.special = ES3Parser.DFA89.DFA89_special;
      this.transition = ES3Parser.DFA89.DFA89_transition;
    }

    public virtual string Description
    {
      get
      {
        return "1910:1: sourceElement returns [Statement value] options {k=1; } : ({...}?func= functionDeclaration |stat= statement );";
      }
    }

    public virtual void Error(NoViableAltException nvae)
    {
    }
  }

  private static class Follow
  {
    public static readonly BitSet _reservedWord_in_token1748 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _Identifier_in_token1753 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _punctuator_in_token1758 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _numericLiteral_in_token1763 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _StringLiteral_in_token1768 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _keyword_in_reservedWord1781 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _futureReservedWord_in_reservedWord1786 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _NULL_in_reservedWord1791 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _booleanLiteral_in_reservedWord1796 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _set_in_keyword1810 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _set_in_futureReservedWord1945 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _set_in_punctuator2225 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _NULL_in_literal2483 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _booleanLiteral_in_literal2492 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _numericLiteral_in_literal2501 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _StringLiteral_in_literal2510 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _RegularExpressionLiteral_in_literal2520 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _TRUE_in_booleanLiteral2537 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _FALSE_in_booleanLiteral2544 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _OctalIntegerLiteral_in_numericLiteral2763 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _DecimalLiteral_in_numericLiteral2772 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _HexIntegerLiteral_in_numericLiteral2781 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _THIS_in_primaryExpression3183 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _Identifier_in_primaryExpression3192 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _literal_in_primaryExpression3201 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _arrayLiteral_in_primaryExpression3210 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _objectLiteral_in_primaryExpression3219 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _LPAREN_in_primaryExpression3228 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _expression_in_primaryExpression3232 = new BitSet(new ulong[3]
    {
      0UL,
      0UL,
      1UL
    });
    public static readonly BitSet _RPAREN_in_primaryExpression3235 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _LBRACK_in_arrayLiteral3261 = new BitSet(new ulong[3]
    {
      4629718052206805024UL /*0x4040100A08000020*/,
      4612836107663483408UL,
      18543083528UL
    });
    public static readonly BitSet _arrayItem_in_arrayLiteral3267 = new BitSet(new ulong[2]
    {
      134217728UL /*0x08000000*/,
      4611686018427387904UL /*0x4000000000000000*/
    });
    public static readonly BitSet _COMMA_in_arrayLiteral3273 = new BitSet(new ulong[3]
    {
      4629718052206805024UL /*0x4040100A08000020*/,
      4612836107663483408UL,
      18543083528UL
    });
    public static readonly BitSet _arrayItem_in_arrayLiteral3277 = new BitSet(new ulong[2]
    {
      134217728UL /*0x08000000*/,
      4611686018427387904UL /*0x4000000000000000*/
    });
    public static readonly BitSet _RBRACK_in_arrayLiteral3287 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _assignmentExpression_in_arrayItem3308 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _LBRACE_in_objectLiteral3349 = new BitSet(new ulong[3]
    {
      17592186044416UL /*0x100000000000*/,
      2306968909120569360UL /*0x2004000000008010*/,
      4194304UL /*0x400000*/
    });
    public static readonly BitSet _propertyAssignment_in_objectLiteral3355 = new BitSet(new ulong[2]
    {
      134217728UL /*0x08000000*/,
      2305843009213693952UL /*0x2000000000000000*/
    });
    public static readonly BitSet _COMMA_in_objectLiteral3362 = new BitSet(new ulong[3]
    {
      17592186044416UL /*0x100000000000*/,
      1125899906875408UL /*0x04000000008010*/,
      4194304UL /*0x400000*/
    });
    public static readonly BitSet _propertyAssignment_in_objectLiteral3366 = new BitSet(new ulong[2]
    {
      134217728UL /*0x08000000*/,
      2305843009213693952UL /*0x2000000000000000*/
    });
    public static readonly BitSet _COMMA_in_objectLiteral3374 = new BitSet(new ulong[2]
    {
      0UL,
      2305843009213693952UL /*0x2000000000000000*/
    });
    public static readonly BitSet _RBRACE_in_objectLiteral3381 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _accessor_in_propertyAssignment3404 = new BitSet(new ulong[3]
    {
      17592186044416UL /*0x100000000000*/,
      1125899906875408UL /*0x04000000008010*/,
      4194304UL /*0x400000*/
    });
    public static readonly BitSet _propertyName_in_propertyAssignment3412 = new BitSet(new ulong[2]
    {
      0UL,
      69206016UL /*0x04200000*/
    });
    public static readonly BitSet _formalParameterList_in_propertyAssignment3419 = new BitSet(new ulong[2]
    {
      0UL,
      69206016UL /*0x04200000*/
    });
    public static readonly BitSet _functionBody_in_propertyAssignment3427 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _propertyName_in_propertyAssignment3437 = new BitSet(new ulong[1]
    {
      67108864UL /*0x04000000*/
    });
    public static readonly BitSet _COLON_in_propertyAssignment3441 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _assignmentExpression_in_propertyAssignment3445 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _Identifier_in_accessor3465 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _Identifier_in_propertyName3487 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _StringLiteral_in_propertyName3496 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _numericLiteral_in_propertyName3505 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _primaryExpression_in_memberExpression3531 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _functionExpression_in_memberExpression3540 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _newExpression_in_memberExpression3549 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _NEW_in_newExpression3566 = new BitSet(new ulong[3]
    {
      4629718009122914304UL /*0x4040100000000000*/,
      1145691189575696UL,
      289406984UL
    });
    public static readonly BitSet _memberExpression_in_newExpression3571 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _LPAREN_in_arguments3594 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083529UL
    });
    public static readonly BitSet _assignmentExpression_in_arguments3600 = new BitSet(new ulong[3]
    {
      134217728UL /*0x08000000*/,
      0UL,
      1UL
    });
    public static readonly BitSet _COMMA_in_arguments3606 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _assignmentExpression_in_arguments3610 = new BitSet(new ulong[3]
    {
      134217728UL /*0x08000000*/,
      0UL,
      1UL
    });
    public static readonly BitSet _RPAREN_in_arguments3619 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _LBRACE_in_generics3641 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      2306993098449789456UL,
      18543083528UL
    });
    public static readonly BitSet _assignmentExpression_in_generics3647 = new BitSet(new ulong[2]
    {
      134217728UL /*0x08000000*/,
      2305843009213693952UL /*0x2000000000000000*/
    });
    public static readonly BitSet _COMMA_in_generics3653 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _assignmentExpression_in_generics3657 = new BitSet(new ulong[2]
    {
      134217728UL /*0x08000000*/,
      2305843009213693952UL /*0x2000000000000000*/
    });
    public static readonly BitSet _RBRACE_in_generics3666 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _memberExpression_in_leftHandSideExpression3702 = new BitSet(new ulong[2]
    {
      549755813890UL /*0x8000000002*/,
      73400320UL /*0x04600000*/
    });
    public static readonly BitSet _generics_in_leftHandSideExpression3718 = new BitSet(new ulong[2]
    {
      0UL,
      69206016UL /*0x04200000*/
    });
    public static readonly BitSet _arguments_in_leftHandSideExpression3727 = new BitSet(new ulong[2]
    {
      549755813890UL /*0x8000000002*/,
      73400320UL /*0x04600000*/
    });
    public static readonly BitSet _LBRACK_in_leftHandSideExpression3738 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _expression_in_leftHandSideExpression3742 = new BitSet(new ulong[2]
    {
      0UL,
      4611686018427387904UL /*0x4000000000000000*/
    });
    public static readonly BitSet _RBRACK_in_leftHandSideExpression3744 = new BitSet(new ulong[2]
    {
      549755813890UL /*0x8000000002*/,
      73400320UL /*0x04600000*/
    });
    public static readonly BitSet _DOT_in_leftHandSideExpression3757 = new BitSet(new ulong[3]
    {
      14936858098330263568UL,
      10018277299750739424UL,
      474578977024UL
    });
    public static readonly BitSet _set_in_leftHandSideExpression3761 = new BitSet(new ulong[2]
    {
      549755813890UL /*0x8000000002*/,
      73400320UL /*0x04600000*/
    });
    public static readonly BitSet _leftHandSideExpression_in_postfixExpression3915 = new BitSet(new ulong[2]
    {
      8589934594UL /*0x0200000002*/,
      512UL /*0x0200*/
    });
    public static readonly BitSet _postfixOperator_in_postfixExpression3923 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _INC_in_postfixOperator3946 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _DEC_in_postfixOperator3955 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _postfixExpression_in_unaryExpression3978 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _unaryOperator_in_unaryExpression3987 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _unaryExpression_in_unaryExpression3992 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _DELETE_in_unaryOperator4010 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _VOID_in_unaryOperator4017 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _TYPEOF_in_unaryOperator4024 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _INC_in_unaryOperator4031 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _DEC_in_unaryOperator4038 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _ADD_in_unaryOperator4047 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _SUB_in_unaryOperator4056 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _INV_in_unaryOperator4063 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _NOT_in_unaryOperator4070 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _unaryExpression_in_multiplicativeExpression4098 = new BitSet(new ulong[2]
    {
      68719476738UL /*0x1000000002*/,
      10737418240UL /*0x0280000000*/
    });
    public static readonly BitSet _MUL_in_multiplicativeExpression4109 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _DIV_in_multiplicativeExpression4118 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _MOD_in_multiplicativeExpression4126 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _unaryExpression_in_multiplicativeExpression4137 = new BitSet(new ulong[2]
    {
      68719476738UL /*0x1000000002*/,
      10737418240UL /*0x0280000000*/
    });
    public static readonly BitSet _multiplicativeExpression_in_additiveExpression4167 = new BitSet(new ulong[3]
    {
      34UL,
      0UL,
      65536UL /*0x010000*/
    });
    public static readonly BitSet _ADD_in_additiveExpression4178 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _SUB_in_additiveExpression4186 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _multiplicativeExpression_in_additiveExpression4197 = new BitSet(new ulong[3]
    {
      34UL,
      0UL,
      65536UL /*0x010000*/
    });
    public static readonly BitSet _additiveExpression_in_shiftExpression4228 = new BitSet(new ulong[3]
    {
      2UL,
      0UL,
      2624UL
    });
    public static readonly BitSet _SHL_in_shiftExpression4239 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _SHR_in_shiftExpression4247 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _SHU_in_shiftExpression4255 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _additiveExpression_in_shiftExpression4266 = new BitSet(new ulong[3]
    {
      2UL,
      0UL,
      2624UL
    });
    public static readonly BitSet _shiftExpression_in_relationalExpression4297 = new BitSet(new ulong[2]
    {
      2UL,
      805307651UL /*0x30000503*/
    });
    public static readonly BitSet _LT_in_relationalExpression4308 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _GT_in_relationalExpression4316 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _LTE_in_relationalExpression4324 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _GTE_in_relationalExpression4332 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _INSTANCEOF_in_relationalExpression4340 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _IN_in_relationalExpression4348 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _shiftExpression_in_relationalExpression4359 = new BitSet(new ulong[2]
    {
      2UL,
      805307651UL /*0x30000503*/
    });
    public static readonly BitSet _shiftExpression_in_relationalExpressionNoIn4385 = new BitSet(new ulong[2]
    {
      2UL,
      805307395UL /*0x30000403*/
    });
    public static readonly BitSet _LT_in_relationalExpressionNoIn4396 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _GT_in_relationalExpressionNoIn4404 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _LTE_in_relationalExpressionNoIn4412 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _GTE_in_relationalExpressionNoIn4420 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _INSTANCEOF_in_relationalExpressionNoIn4428 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _shiftExpression_in_relationalExpressionNoIn4440 = new BitSet(new ulong[2]
    {
      2UL,
      805307395UL /*0x30000403*/
    });
    public static readonly BitSet _relationalExpression_in_equalityExpression4471 = new BitSet(new ulong[3]
    {
      281474976710658UL /*0x01000000000002*/,
      9895604649984UL /*0x090000000000*/,
      16UL /*0x10*/
    });
    public static readonly BitSet _EQ_in_equalityExpression4482 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _NEQ_in_equalityExpression4490 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _SAME_in_equalityExpression4498 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _NSAME_in_equalityExpression4506 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _relationalExpression_in_equalityExpression4517 = new BitSet(new ulong[3]
    {
      281474976710658UL /*0x01000000000002*/,
      9895604649984UL /*0x090000000000*/,
      16UL /*0x10*/
    });
    public static readonly BitSet _relationalExpressionNoIn_in_equalityExpressionNoIn4543 = new BitSet(new ulong[3]
    {
      281474976710658UL /*0x01000000000002*/,
      9895604649984UL /*0x090000000000*/,
      16UL /*0x10*/
    });
    public static readonly BitSet _EQ_in_equalityExpressionNoIn4554 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _NEQ_in_equalityExpressionNoIn4562 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _SAME_in_equalityExpressionNoIn4570 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _NSAME_in_equalityExpressionNoIn4578 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _relationalExpressionNoIn_in_equalityExpressionNoIn4589 = new BitSet(new ulong[3]
    {
      281474976710658UL /*0x01000000000002*/,
      9895604649984UL /*0x090000000000*/,
      16UL /*0x10*/
    });
    public static readonly BitSet _equalityExpression_in_bitwiseANDExpression4616 = new BitSet(new ulong[1]
    {
      130UL
    });
    public static readonly BitSet _AND_in_bitwiseANDExpression4622 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _equalityExpression_in_bitwiseANDExpression4627 = new BitSet(new ulong[1]
    {
      130UL
    });
    public static readonly BitSet _equalityExpressionNoIn_in_bitwiseANDExpressionNoIn4648 = new BitSet(new ulong[1]
    {
      130UL
    });
    public static readonly BitSet _AND_in_bitwiseANDExpressionNoIn4654 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _equalityExpressionNoIn_in_bitwiseANDExpressionNoIn4659 = new BitSet(new ulong[1]
    {
      130UL
    });
    public static readonly BitSet _bitwiseANDExpression_in_bitwiseXORExpression4682 = new BitSet(new ulong[3]
    {
      2UL,
      0UL,
      1099511627776UL /*0x010000000000*/
    });
    public static readonly BitSet _XOR_in_bitwiseXORExpression4688 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _bitwiseANDExpression_in_bitwiseXORExpression4693 = new BitSet(new ulong[3]
    {
      2UL,
      0UL,
      1099511627776UL /*0x010000000000*/
    });
    public static readonly BitSet _bitwiseANDExpressionNoIn_in_bitwiseXORExpressionNoIn4716 = new BitSet(new ulong[3]
    {
      2UL,
      0UL,
      1099511627776UL /*0x010000000000*/
    });
    public static readonly BitSet _XOR_in_bitwiseXORExpressionNoIn4722 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _bitwiseANDExpressionNoIn_in_bitwiseXORExpressionNoIn4727 = new BitSet(new ulong[3]
    {
      2UL,
      0UL,
      1099511627776UL /*0x010000000000*/
    });
    public static readonly BitSet _bitwiseXORExpression_in_bitwiseORExpression4749 = new BitSet(new ulong[2]
    {
      2UL,
      70368744177664UL /*0x400000000000*/
    });
    public static readonly BitSet _OR_in_bitwiseORExpression4755 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _bitwiseXORExpression_in_bitwiseORExpression4760 = new BitSet(new ulong[2]
    {
      2UL,
      70368744177664UL /*0x400000000000*/
    });
    public static readonly BitSet _bitwiseXORExpressionNoIn_in_bitwiseORExpressionNoIn4782 = new BitSet(new ulong[2]
    {
      2UL,
      70368744177664UL /*0x400000000000*/
    });
    public static readonly BitSet _OR_in_bitwiseORExpressionNoIn4788 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _bitwiseXORExpressionNoIn_in_bitwiseORExpressionNoIn4793 = new BitSet(new ulong[2]
    {
      2UL,
      70368744177664UL /*0x400000000000*/
    });
    public static readonly BitSet _bitwiseORExpression_in_logicalANDExpression4819 = new BitSet(new ulong[2]
    {
      2UL,
      1048576UL /*0x100000*/
    });
    public static readonly BitSet _LAND_in_logicalANDExpression4825 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _bitwiseORExpression_in_logicalANDExpression4830 = new BitSet(new ulong[2]
    {
      2UL,
      1048576UL /*0x100000*/
    });
    public static readonly BitSet _bitwiseORExpressionNoIn_in_logicalANDExpressionNoIn4851 = new BitSet(new ulong[2]
    {
      2UL,
      1048576UL /*0x100000*/
    });
    public static readonly BitSet _LAND_in_logicalANDExpressionNoIn4857 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _bitwiseORExpressionNoIn_in_logicalANDExpressionNoIn4862 = new BitSet(new ulong[2]
    {
      2UL,
      1048576UL /*0x100000*/
    });
    public static readonly BitSet _logicalANDExpression_in_logicalORExpression4884 = new BitSet(new ulong[2]
    {
      2UL,
      33554432UL /*0x02000000*/
    });
    public static readonly BitSet _LOR_in_logicalORExpression4890 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _logicalANDExpression_in_logicalORExpression4895 = new BitSet(new ulong[2]
    {
      2UL,
      33554432UL /*0x02000000*/
    });
    public static readonly BitSet _logicalANDExpressionNoIn_in_logicalORExpressionNoIn4917 = new BitSet(new ulong[2]
    {
      2UL,
      33554432UL /*0x02000000*/
    });
    public static readonly BitSet _LOR_in_logicalORExpressionNoIn4923 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _logicalANDExpressionNoIn_in_logicalORExpressionNoIn4928 = new BitSet(new ulong[2]
    {
      2UL,
      33554432UL /*0x02000000*/
    });
    public static readonly BitSet _logicalORExpression_in_conditionalExpression4955 = new BitSet(new ulong[2]
    {
      2UL,
      1152921504606846976UL /*0x1000000000000000*/
    });
    public static readonly BitSet _QUE_in_conditionalExpression4961 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _assignmentExpression_in_conditionalExpression4966 = new BitSet(new ulong[1]
    {
      67108864UL /*0x04000000*/
    });
    public static readonly BitSet _COLON_in_conditionalExpression4968 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _assignmentExpression_in_conditionalExpression4973 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _logicalORExpressionNoIn_in_conditionalExpressionNoIn4994 = new BitSet(new ulong[2]
    {
      2UL,
      1152921504606846976UL /*0x1000000000000000*/
    });
    public static readonly BitSet _QUE_in_conditionalExpressionNoIn5000 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _assignmentExpressionNoIn_in_conditionalExpressionNoIn5005 = new BitSet(new ulong[1]
    {
      67108864UL /*0x04000000*/
    });
    public static readonly BitSet _COLON_in_conditionalExpressionNoIn5007 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _assignmentExpressionNoIn_in_conditionalExpressionNoIn5012 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _conditionalExpression_in_assignmentExpression5045 = new BitSet(new ulong[3]
    {
      137438955842UL /*0x2000000942*/,
      140758963191808UL /*0x800500000000*/,
      2199023391872UL /*0x020000021480*/
    });
    public static readonly BitSet _assignmentOperator_in_assignmentExpression5057 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _assignmentExpression_in_assignmentExpression5064 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _set_in_assignmentOperator5079 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _conditionalExpressionNoIn_in_assignmentExpressionNoIn5159 = new BitSet(new ulong[3]
    {
      137438955842UL /*0x2000000942*/,
      140758963191808UL /*0x800500000000*/,
      2199023391872UL /*0x020000021480*/
    });
    public static readonly BitSet _assignmentOperator_in_assignmentExpressionNoIn5171 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _assignmentExpressionNoIn_in_assignmentExpressionNoIn5178 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _assignmentExpression_in_expression5210 = new BitSet(new ulong[1]
    {
      134217730UL /*0x08000002*/
    });
    public static readonly BitSet _COMMA_in_expression5216 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _assignmentExpression_in_expression5222 = new BitSet(new ulong[1]
    {
      134217730UL /*0x08000002*/
    });
    public static readonly BitSet _assignmentExpressionNoIn_in_expressionNoIn5250 = new BitSet(new ulong[1]
    {
      134217730UL /*0x08000002*/
    });
    public static readonly BitSet _COMMA_in_expressionNoIn5256 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _assignmentExpressionNoIn_in_expressionNoIn5262 = new BitSet(new ulong[1]
    {
      134217730UL /*0x08000002*/
    });
    public static readonly BitSet _SEMIC_in_semic5296 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _EOF_in_semic5301 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _RBRACE_in_semic5306 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _EOL_in_semic5313 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _MultiLineComment_in_semic5317 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _block_in_statement5351 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _functionDeclaration_in_statement5362 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _statementTail_in_statement5369 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _variableStatement_in_statementTail5392 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _emptyStatement_in_statementTail5399 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _expressionStatement_in_statementTail5406 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _ifStatement_in_statementTail5413 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _iterationStatement_in_statementTail5420 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _continueStatement_in_statementTail5427 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _breakStatement_in_statementTail5434 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _returnStatement_in_statementTail5441 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _withStatement_in_statementTail5448 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _labelledStatement_in_statementTail5455 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _switchStatement_in_statementTail5462 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _throwStatement_in_statementTail5469 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _tryStatement_in_statementTail5476 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _LBRACE_in_block5506 = new BitSet(new ulong[3]
    {
      5206179079790805024UL,
      11530365135304565296UL,
      440020828200UL
    });
    public static readonly BitSet _statement_in_block5509 = new BitSet(new ulong[3]
    {
      5206179079790805024UL,
      11530365135304565296UL,
      440020828200UL
    });
    public static readonly BitSet _RBRACE_in_block5515 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _VAR_in_variableStatement5545 = new BitSet(new ulong[2]
    {
      0UL,
      32768UL /*0x8000*/
    });
    public static readonly BitSet _variableDeclaration_in_variableStatement5549 = new BitSet(new ulong[3]
    {
      140737622573056UL /*0x800008000000*/,
      2305843043573432320UL /*0x2000000800000000*/,
      32UL /*0x20*/
    });
    public static readonly BitSet _COMMA_in_variableStatement5555 = new BitSet(new ulong[2]
    {
      0UL,
      32768UL /*0x8000*/
    });
    public static readonly BitSet _variableDeclaration_in_variableStatement5561 = new BitSet(new ulong[3]
    {
      140737622573056UL /*0x800008000000*/,
      2305843043573432320UL /*0x2000000800000000*/,
      32UL /*0x20*/
    });
    public static readonly BitSet _semic_in_variableStatement5569 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _Identifier_in_variableDeclaration5593 = new BitSet(new ulong[1]
    {
      2050UL
    });
    public static readonly BitSet _ASSIGN_in_variableDeclaration5599 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _assignmentExpression_in_variableDeclaration5604 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _Identifier_in_variableDeclarationNoIn5632 = new BitSet(new ulong[1]
    {
      2050UL
    });
    public static readonly BitSet _ASSIGN_in_variableDeclarationNoIn5638 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _assignmentExpressionNoIn_in_variableDeclarationNoIn5643 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _SEMIC_in_emptyStatement5668 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _expression_in_expressionStatement5693 = new BitSet(new ulong[3]
    {
      140737622573056UL /*0x800008000000*/,
      2305843043573432320UL /*0x2000000800000000*/,
      32UL /*0x20*/
    });
    public static readonly BitSet _semic_in_expressionStatement5695 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _IF_in_ifStatement5724 = new BitSet(new ulong[2]
    {
      0UL,
      67108864UL /*0x04000000*/
    });
    public static readonly BitSet _LPAREN_in_ifStatement5726 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _expression_in_ifStatement5728 = new BitSet(new ulong[3]
    {
      0UL,
      0UL,
      1UL
    });
    public static readonly BitSet _RPAREN_in_ifStatement5732 = new BitSet(new ulong[3]
    {
      5206179079790805024UL,
      9224522126090871344UL,
      440020828200UL
    });
    public static readonly BitSet _statement_in_ifStatement5736 = new BitSet(new ulong[1]
    {
      35184372088834UL /*0x200000000002*/
    });
    public static readonly BitSet _ELSE_in_ifStatement5744 = new BitSet(new ulong[3]
    {
      5206179079790805024UL,
      9224522126090871344UL,
      440020828200UL
    });
    public static readonly BitSet _statement_in_ifStatement5748 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _doStatement_in_iterationStatement5778 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _whileStatement_in_iterationStatement5787 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _forStatement_in_iterationStatement5797 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _DO_in_doStatement5816 = new BitSet(new ulong[3]
    {
      5206179079790805024UL,
      9224522126090871344UL,
      440020828200UL
    });
    public static readonly BitSet _statement_in_doStatement5818 = new BitSet(new ulong[3]
    {
      0UL,
      0UL,
      137438953472UL /*0x2000000000*/
    });
    public static readonly BitSet _WHILE_in_doStatement5820 = new BitSet(new ulong[2]
    {
      0UL,
      67108864UL /*0x04000000*/
    });
    public static readonly BitSet _LPAREN_in_doStatement5822 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _expression_in_doStatement5824 = new BitSet(new ulong[3]
    {
      0UL,
      0UL,
      1UL
    });
    public static readonly BitSet _RPAREN_in_doStatement5826 = new BitSet(new ulong[3]
    {
      140737622573056UL /*0x800008000000*/,
      2305843043573432320UL /*0x2000000800000000*/,
      32UL /*0x20*/
    });
    public static readonly BitSet _semic_in_doStatement5828 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _WHILE_in_whileStatement5848 = new BitSet(new ulong[2]
    {
      0UL,
      67108864UL /*0x04000000*/
    });
    public static readonly BitSet _LPAREN_in_whileStatement5851 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _expression_in_whileStatement5854 = new BitSet(new ulong[3]
    {
      0UL,
      0UL,
      1UL
    });
    public static readonly BitSet _RPAREN_in_whileStatement5856 = new BitSet(new ulong[3]
    {
      5206179079790805024UL,
      9224522126090871344UL,
      440020828200UL
    });
    public static readonly BitSet _statement_in_whileStatement5859 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _FOR_in_forStatement5878 = new BitSet(new ulong[2]
    {
      0UL,
      67108864UL /*0x04000000*/
    });
    public static readonly BitSet _LPAREN_in_forStatement5881 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      27133018152UL
    });
    public static readonly BitSet _forControl_in_forStatement5886 = new BitSet(new ulong[3]
    {
      0UL,
      0UL,
      1UL
    });
    public static readonly BitSet _RPAREN_in_forStatement5891 = new BitSet(new ulong[3]
    {
      5206179079790805024UL,
      9224522126090871344UL,
      440020828200UL
    });
    public static readonly BitSet _statement_in_forStatement5896 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _forControlVar_in_forControl5915 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _forControlExpression_in_forControl5924 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _forControlSemic_in_forControl5933 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _VAR_in_forControlVar5961 = new BitSet(new ulong[2]
    {
      0UL,
      32768UL /*0x8000*/
    });
    public static readonly BitSet _variableDeclarationNoIn_in_forControlVar5965 = new BitSet(new ulong[3]
    {
      134217728UL /*0x08000000*/,
      256UL /*0x0100*/,
      32UL /*0x20*/
    });
    public static readonly BitSet _IN_in_forControlVar5979 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _expression_in_forControlVar5983 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _COMMA_in_forControlVar6008 = new BitSet(new ulong[2]
    {
      0UL,
      32768UL /*0x8000*/
    });
    public static readonly BitSet _variableDeclarationNoIn_in_forControlVar6014 = new BitSet(new ulong[3]
    {
      134217728UL /*0x08000000*/,
      0UL,
      32UL /*0x20*/
    });
    public static readonly BitSet _SEMIC_in_forControlVar6025 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083560UL
    });
    public static readonly BitSet _expression_in_forControlVar6031 = new BitSet(new ulong[3]
    {
      0UL,
      0UL,
      32UL /*0x20*/
    });
    public static readonly BitSet _SEMIC_in_forControlVar6039 = new BitSet(new ulong[3]
    {
      4629718052072587298UL /*0x4040100A00000022*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _expression_in_forControlVar6044 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _expressionNoIn_in_forControlExpression6083 = new BitSet(new ulong[3]
    {
      0UL,
      256UL /*0x0100*/,
      32UL /*0x20*/
    });
    public static readonly BitSet _IN_in_forControlExpression6100 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _expression_in_forControlExpression6104 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _SEMIC_in_forControlExpression6127 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083560UL
    });
    public static readonly BitSet _expression_in_forControlExpression6133 = new BitSet(new ulong[3]
    {
      0UL,
      0UL,
      32UL /*0x20*/
    });
    public static readonly BitSet _SEMIC_in_forControlExpression6141 = new BitSet(new ulong[3]
    {
      4629718052072587298UL /*0x4040100A00000022*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _expression_in_forControlExpression6146 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _SEMIC_in_forControlSemic6182 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083560UL
    });
    public static readonly BitSet _expression_in_forControlSemic6188 = new BitSet(new ulong[3]
    {
      0UL,
      0UL,
      32UL /*0x20*/
    });
    public static readonly BitSet _SEMIC_in_forControlSemic6196 = new BitSet(new ulong[3]
    {
      4629718052072587298UL /*0x4040100A00000022*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _expression_in_forControlSemic6201 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _CONTINUE_in_continueStatement6235 = new BitSet(new ulong[3]
    {
      140737622573056UL /*0x800008000000*/,
      2305843043573465088UL /*0x2000000800008000*/,
      32UL /*0x20*/
    });
    public static readonly BitSet _Identifier_in_continueStatement6243 = new BitSet(new ulong[3]
    {
      140737622573056UL /*0x800008000000*/,
      2305843043573432320UL /*0x2000000800000000*/,
      32UL /*0x20*/
    });
    public static readonly BitSet _semic_in_continueStatement6250 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _BREAK_in_breakStatement6280 = new BitSet(new ulong[3]
    {
      140737622573056UL /*0x800008000000*/,
      2305843043573465088UL /*0x2000000800008000*/,
      32UL /*0x20*/
    });
    public static readonly BitSet _Identifier_in_breakStatement6288 = new BitSet(new ulong[3]
    {
      140737622573056UL /*0x800008000000*/,
      2305843043573432320UL /*0x2000000800000000*/,
      32UL /*0x20*/
    });
    public static readonly BitSet _semic_in_breakStatement6295 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _RETURN_in_returnStatement6325 = new BitSet(new ulong[3]
    {
      4629858789695160352UL /*0x4040900A08000020*/,
      2306993132809527824UL,
      18543083560UL
    });
    public static readonly BitSet _expression_in_returnStatement6333 = new BitSet(new ulong[3]
    {
      140737622573056UL /*0x800008000000*/,
      2305843043573432320UL /*0x2000000800000000*/,
      32UL /*0x20*/
    });
    public static readonly BitSet _semic_in_returnStatement6339 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _WITH_in_withStatement6360 = new BitSet(new ulong[2]
    {
      0UL,
      67108864UL /*0x04000000*/
    });
    public static readonly BitSet _LPAREN_in_withStatement6363 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _expression_in_withStatement6368 = new BitSet(new ulong[3]
    {
      0UL,
      0UL,
      1UL
    });
    public static readonly BitSet _RPAREN_in_withStatement6370 = new BitSet(new ulong[3]
    {
      5206179079790805024UL,
      9224522126090871344UL,
      440020828200UL
    });
    public static readonly BitSet _statement_in_withStatement6375 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _SWITCH_in_switchStatement6402 = new BitSet(new ulong[2]
    {
      0UL,
      67108864UL /*0x04000000*/
    });
    public static readonly BitSet _LPAREN_in_switchStatement6404 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _expression_in_switchStatement6406 = new BitSet(new ulong[3]
    {
      0UL,
      0UL,
      1UL
    });
    public static readonly BitSet _RPAREN_in_switchStatement6410 = new BitSet(new ulong[2]
    {
      0UL,
      2097152UL /*0x200000*/
    });
    public static readonly BitSet _LBRACE_in_switchStatement6415 = new BitSet(new ulong[2]
    {
      17181966336UL /*0x0400200000*/,
      2305843009213693952UL /*0x2000000000000000*/
    });
    public static readonly BitSet _defaultClause_in_switchStatement6422 = new BitSet(new ulong[2]
    {
      17181966336UL /*0x0400200000*/,
      2305843009213693952UL /*0x2000000000000000*/
    });
    public static readonly BitSet _caseClause_in_switchStatement6428 = new BitSet(new ulong[2]
    {
      17181966336UL /*0x0400200000*/,
      2305843009213693952UL /*0x2000000000000000*/
    });
    public static readonly BitSet _RBRACE_in_switchStatement6435 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _CASE_in_caseClause6458 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _expression_in_caseClause6461 = new BitSet(new ulong[1]
    {
      67108864UL /*0x04000000*/
    });
    public static readonly BitSet _COLON_in_caseClause6465 = new BitSet(new ulong[3]
    {
      5206179079790805026UL,
      9224522126090871344UL,
      440020828200UL
    });
    public static readonly BitSet _statement_in_caseClause6469 = new BitSet(new ulong[3]
    {
      5206179079790805026UL,
      9224522126090871344UL,
      440020828200UL
    });
    public static readonly BitSet _DEFAULT_in_defaultClause6494 = new BitSet(new ulong[1]
    {
      67108864UL /*0x04000000*/
    });
    public static readonly BitSet _COLON_in_defaultClause6497 = new BitSet(new ulong[3]
    {
      5206179079790805026UL,
      9224522126090871344UL,
      440020828200UL
    });
    public static readonly BitSet _statement_in_defaultClause6501 = new BitSet(new ulong[3]
    {
      5206179079790805026UL,
      9224522126090871344UL,
      440020828200UL
    });
    public static readonly BitSet _Identifier_in_labelledStatement6528 = new BitSet(new ulong[1]
    {
      67108864UL /*0x04000000*/
    });
    public static readonly BitSet _COLON_in_labelledStatement6530 = new BitSet(new ulong[3]
    {
      5206179079790805024UL,
      9224522126090871344UL,
      440020828200UL
    });
    public static readonly BitSet _statement_in_labelledStatement6534 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _THROW_in_throwStatement6560 = new BitSet(new ulong[3]
    {
      4629718052072587296UL /*0x4040100A00000020*/,
      1150089236095504UL,
      18543083528UL
    });
    public static readonly BitSet _expression_in_throwStatement6567 = new BitSet(new ulong[3]
    {
      140737622573056UL /*0x800008000000*/,
      2305843043573432320UL /*0x2000000800000000*/,
      32UL /*0x20*/
    });
    public static readonly BitSet _semic_in_throwStatement6571 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _TRY_in_tryStatement6596 = new BitSet(new ulong[2]
    {
      0UL,
      2097152UL /*0x200000*/
    });
    public static readonly BitSet _block_in_tryStatement6601 = new BitSet(new ulong[1]
    {
      144115188080050176UL /*0x0200000000400000*/
    });
    public static readonly BitSet _catchClause_in_tryStatement6610 = new BitSet(new ulong[1]
    {
      144115188080050178UL /*0x0200000000400002*/
    });
    public static readonly BitSet _finallyClause_in_tryStatement6617 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _finallyClause_in_tryStatement6627 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _CATCH_in_catchClause6647 = new BitSet(new ulong[2]
    {
      0UL,
      67108864UL /*0x04000000*/
    });
    public static readonly BitSet _LPAREN_in_catchClause6650 = new BitSet(new ulong[2]
    {
      0UL,
      32768UL /*0x8000*/
    });
    public static readonly BitSet _Identifier_in_catchClause6655 = new BitSet(new ulong[3]
    {
      0UL,
      0UL,
      1UL
    });
    public static readonly BitSet _RPAREN_in_catchClause6657 = new BitSet(new ulong[2]
    {
      0UL,
      2097152UL /*0x200000*/
    });
    public static readonly BitSet _block_in_catchClause6660 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _FINALLY_in_finallyClause6678 = new BitSet(new ulong[2]
    {
      0UL,
      2097152UL /*0x200000*/
    });
    public static readonly BitSet _block_in_finallyClause6681 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _FUNCTION_in_functionDeclaration6713 = new BitSet(new ulong[2]
    {
      0UL,
      32768UL /*0x8000*/
    });
    public static readonly BitSet _Identifier_in_functionDeclaration6718 = new BitSet(new ulong[2]
    {
      0UL,
      67108864UL /*0x04000000*/
    });
    public static readonly BitSet _formalParameterList_in_functionDeclaration6728 = new BitSet(new ulong[2]
    {
      0UL,
      69206016UL /*0x04200000*/
    });
    public static readonly BitSet _functionBody_in_functionDeclaration6737 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _FUNCTION_in_functionExpression6764 = new BitSet(new ulong[2]
    {
      0UL,
      67141632UL /*0x04008000*/
    });
    public static readonly BitSet _Identifier_in_functionExpression6769 = new BitSet(new ulong[2]
    {
      0UL,
      67108864UL /*0x04000000*/
    });
    public static readonly BitSet _formalParameterList_in_functionExpression6776 = new BitSet(new ulong[2]
    {
      0UL,
      69206016UL /*0x04200000*/
    });
    public static readonly BitSet _functionBody_in_functionExpression6780 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _LPAREN_in_formalParameterList6805 = new BitSet(new ulong[3]
    {
      0UL,
      32768UL /*0x8000*/,
      1UL
    });
    public static readonly BitSet _Identifier_in_formalParameterList6811 = new BitSet(new ulong[3]
    {
      134217728UL /*0x08000000*/,
      0UL,
      1UL
    });
    public static readonly BitSet _COMMA_in_formalParameterList6817 = new BitSet(new ulong[2]
    {
      0UL,
      32768UL /*0x8000*/
    });
    public static readonly BitSet _Identifier_in_formalParameterList6821 = new BitSet(new ulong[3]
    {
      134217728UL /*0x08000000*/,
      0UL,
      1UL
    });
    public static readonly BitSet _RPAREN_in_formalParameterList6832 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _LBRACE_in_functionBody6859 = new BitSet(new ulong[3]
    {
      5206179079790805024UL,
      11530365135304565296UL,
      440020828200UL
    });
    public static readonly BitSet _sourceElement_in_functionBody6862 = new BitSet(new ulong[3]
    {
      5206179079790805024UL,
      11530365135304565296UL,
      440020828200UL
    });
    public static readonly BitSet _RBRACE_in_functionBody6869 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _sourceElement_in_program6898 = new BitSet(new ulong[3]
    {
      5206179079790805026UL,
      9224522126090871344UL,
      440020828200UL
    });
    public static readonly BitSet _functionDeclaration_in_sourceElement6939 = new BitSet(new ulong[1]
    {
      2UL
    });
    public static readonly BitSet _statement_in_sourceElement6948 = new BitSet(new ulong[1]
    {
      2UL
    });
  }
}
