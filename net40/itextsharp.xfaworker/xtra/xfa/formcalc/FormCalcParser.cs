// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.formcalc.FormCalcParser
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System;
using System.CodeDom.Compiler;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.formcalc;

[GeneratedCode("ANTLR", "4.5.3")]
[CLSCompliant(false)]
public class FormCalcParser : Parser
{
  public const int T__0 = 1;
  public const int T__1 = 2;
  public const int T__2 = 3;
  public const int T__3 = 4;
  public const int T__4 = 5;
  public const int T__5 = 6;
  public const int T__6 = 7;
  public const int T__7 = 8;
  public const int T__8 = 9;
  public const int T__9 = 10;
  public const int T__10 = 11;
  public const int T__11 = 12;
  public const int T__12 = 13;
  public const int T__13 = 14;
  public const int T__14 = 15;
  public const int T__15 = 16 /*0x10*/;
  public const int T__16 = 17;
  public const int T__17 = 18;
  public const int T__18 = 19;
  public const int T__19 = 20;
  public const int T__20 = 21;
  public const int T__21 = 22;
  public const int T__22 = 23;
  public const int T__23 = 24;
  public const int T__24 = 25;
  public const int T__25 = 26;
  public const int T__26 = 27;
  public const int T__27 = 28;
  public const int T__28 = 29;
  public const int T__29 = 30;
  public const int T__30 = 31 /*0x1F*/;
  public const int T__31 = 32 /*0x20*/;
  public const int T__32 = 33;
  public const int T__33 = 34;
  public const int T__34 = 35;
  public const int T__35 = 36;
  public const int T__36 = 37;
  public const int T__37 = 38;
  public const int T__38 = 39;
  public const int T__39 = 40;
  public const int T__40 = 41;
  public const int T__41 = 42;
  public const int T__42 = 43;
  public const int T__43 = 44;
  public const int T__44 = 45;
  public const int T__45 = 46;
  public const int T__46 = 47;
  public const int T__47 = 48 /*0x30*/;
  public const int T__48 = 49;
  public const int T__49 = 50;
  public const int T__50 = 51;
  public const int T__51 = 52;
  public const int T__52 = 53;
  public const int T__53 = 54;
  public const int T__54 = 55;
  public const int T__55 = 56;
  public const int T__56 = 57;
  public const int T__57 = 58;
  public const int T__58 = 59;
  public const int T__59 = 60;
  public const int T__60 = 61;
  public const int T__61 = 62;
  public const int HexLiteral = 63 /*0x3F*/;
  public const int DecimalLiteral = 64 /*0x40*/;
  public const int OctalLiteral = 65;
  public const int FloatingPointLiteral = 66;
  public const int CharacterLiteral = 67;
  public const int StringLiteral = 68;
  public const int Identifier = 69;
  public const int COMMENT = 70;
  public const int WS = 71;
  public const int LINE_COMMENT = 72;
  public const int RULE_compilationUnit = 0;
  public const int RULE_variableAssign = 1;
  public const int RULE_variableDeclarator = 2;
  public const int RULE_variableDeclaratorId = 3;
  public const int RULE_variableInitializer = 4;
  public const int RULE_arrayInitializer = 5;
  public const int RULE_type = 6;
  public const int RULE_primitiveType = 7;
  public const int RULE_variableModifier = 8;
  public const int RULE_qualifiedNameList = 9;
  public const int RULE_methodBody = 10;
  public const int RULE_qualifiedName = 11;
  public const int RULE_literal = 12;
  public const int RULE_integerLiteral = 13;
  public const int RULE_booleanLiteral = 14;
  public const int RULE_block = 15;
  public const int RULE_blockStatement = 16 /*0x10*/;
  public const int RULE_ifStatement = 17;
  public const int RULE_thenStatement = 18;
  public const int RULE_elseIfStatement = 19;
  public const int RULE_elseStatement = 20;
  public const int RULE_forUpToStatement = 21;
  public const int RULE_forDownToStatement = 22;
  public const int RULE_whileStatement = 23;
  public const int RULE_statement = 24;
  public const int RULE_parExpression = 25;
  public const int RULE_expressionList = 26;
  public const int RULE_statementExpression = 27;
  public const int RULE_accessor = 28;
  public const int RULE_funcCallExpression = 29;
  public const int RULE_wildcardExpression = 30;
  public const int RULE_assign = 31 /*0x1F*/;
  public const int RULE_nullEqualityExpression = 32 /*0x20*/;
  public const int RULE_expression = 33;
  public const int RULE_primary = 34;
  public const int RULE_orOperators = 35;
  public const int RULE_andOperators = 36;
  public const int RULE_equalityOperators = 37;
  public const int RULE_relationalOperators = 38;
  public const int RULE_numericOperators = 39;
  public const int RULE_arguments = 40;
  public static readonly string[] ruleNames = new string[41]
  {
    "compilationUnit",
    "variableAssign",
    "variableDeclarator",
    "variableDeclaratorId",
    "variableInitializer",
    "arrayInitializer",
    "type",
    "primitiveType",
    "variableModifier",
    "qualifiedNameList",
    "methodBody",
    "qualifiedName",
    "literal",
    "integerLiteral",
    "booleanLiteral",
    "block",
    "blockStatement",
    "ifStatement",
    "thenStatement",
    "elseIfStatement",
    "elseStatement",
    "forUpToStatement",
    "forDownToStatement",
    "whileStatement",
    "statement",
    "parExpression",
    "expressionList",
    "statementExpression",
    "accessor",
    "funcCallExpression",
    "wildcardExpression",
    "assign",
    "nullEqualityExpression",
    "expression",
    "primary",
    "orOperators",
    "andOperators",
    "equalityOperators",
    "relationalOperators",
    "numericOperators",
    "arguments"
  };
  private static readonly string[] _LiteralNames = new string[63 /*0x3F*/]
  {
    null,
    "'='",
    "'var'",
    "'{'",
    "','",
    "'}'",
    "'['",
    "']'",
    "'boolean'",
    "'char'",
    "'byte'",
    "'short'",
    "'int'",
    "'long'",
    "'float'",
    "'double'",
    "'.'",
    "'null'",
    "'true'",
    "'false'",
    "'do'",
    "'end'",
    "'if'",
    "'endif'",
    "'then'",
    "'elseif'",
    "'else'",
    "'for'",
    "'upto'",
    "'step'",
    "'endfor'",
    "'downto'",
    "'while'",
    "'endwhile'",
    "'return'",
    "'break'",
    "'continue'",
    "';'",
    "'('",
    "')'",
    "'[*]'",
    "'++'",
    "'--'",
    "'+'",
    "'-'",
    "'|'",
    "'or'",
    "'&'",
    "'and'",
    "'=='",
    "'<>'",
    "'eq'",
    "'ne'",
    "'<='",
    "'>='",
    "'<'",
    "'>'",
    "'le'",
    "'ge'",
    "'lt'",
    "'gt'",
    "'*'",
    "'/'"
  };
  private static readonly string[] _SymbolicNames = new string[73]
  {
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    null,
    nameof (HexLiteral),
    nameof (DecimalLiteral),
    nameof (OctalLiteral),
    nameof (FloatingPointLiteral),
    nameof (CharacterLiteral),
    nameof (StringLiteral),
    nameof (Identifier),
    nameof (COMMENT),
    nameof (WS),
    nameof (LINE_COMMENT)
  };
  public static readonly IVocabulary DefaultVocabulary = (IVocabulary) new Antlr4.Runtime.Vocabulary(FormCalcParser._LiteralNames, FormCalcParser._SymbolicNames);
  [Obsolete("Use Vocabulary instead.")]
  public static readonly string[] tokenNames = FormCalcParser.GenerateTokenNames(FormCalcParser.DefaultVocabulary, FormCalcParser._SymbolicNames.Length);
  public static readonly string _serializedATN = "\u0003꽯茠䞝띜䢀ᘅᤜꬷ\u0003JƖ\u0004\u0002\t\u0002\u0004\u0003\t\u0003\u0004\u0004\t\u0004\u0004\u0005\t\u0005\u0004\u0006\t\u0006\u0004\a\t\a\u0004\b\t\b\u0004\t\t\t\u0004\n\t\n\u0004\v\t\v\u0004\f\t\f\u0004\r\t\r\u0004\u000E\t\u000E\u0004\u000F\t\u000F\u0004\u0010\t\u0010\u0004\u0011\t\u0011\u0004\u0012\t\u0012\u0004\u0013\t\u0013\u0004\u0014\t\u0014\u0004\u0015\t\u0015\u0004\u0016\t\u0016\u0004\u0017\t\u0017\u0004\u0018\t\u0018\u0004\u0019\t\u0019\u0004\u001A\t\u001A\u0004\u001B\t\u001B\u0004\u001C\t\u001C\u0004\u001D\t\u001D\u0004\u001E\t\u001E\u0004\u001F\t\u001F\u0004 \t \u0004!\t!\u0004\"\t\"\u0004#\t#\u0004$\t$\u0004%\t%\u0004&\t&\u0004'\t'\u0004(\t(\u0004)\t)\u0004*\t*\u0003\u0002\a\u0002V\n\u0002\f\u0002\u000E\u0002Y\v\u0002\u0003\u0003\u0003\u0003\u0003\u0003\u0003\u0003\u0003\u0004\u0003\u0004\a\u0004a\n\u0004\f\u0004\u000E\u0004d\v\u0004\u0003\u0005\u0003\u0005\u0003\u0005\u0003\u0006\u0003\u0006\u0005\u0006k\n\u0006\u0003\a\u0003\a\u0003\a\u0003\a\a\aq\n\a\f\a\u000E\at\v\a\u0003\a\u0005\aw\n\a\u0005\ay\n\a\u0003\a\u0003\a\u0003\b\u0003\b\u0003\b\a\b\u0080\n\b\f\b\u000E\b\u0083\v\b\u0003\t\u0003\t\u0003\n\u0003\n\u0003\v\u0003\v\u0003\v\a\v\u008C\n\v\f\v\u000E\v\u008F\v\v\u0003\f\u0003\f\u0003\r\u0003\r\u0003\r\a\r\u0096\n\r\f\r\u000E\r\u0099\v\r\u0003\u000E\u0003\u000E\u0003\u000E\u0003\u000E\u0003\u000E\u0003\u000E\u0005\u000E¡\n\u000E\u0003\u000F\u0003\u000F\u0003\u0010\u0003\u0010\u0003\u0011\u0003\u0011\a\u0011©\n\u0011\f\u0011\u000E\u0011¬\v\u0011\u0003\u0011\u0003\u0011\u0003\u0012\u0003\u0012\u0003\u0013\u0003\u0013\u0003\u0013\u0003\u0013\a\u0013¶\n\u0013\f\u0013\u000E\u0013\u00B9\v\u0013\u0003\u0013\u0005\u0013\u00BC\n\u0013\u0003\u0013\u0003\u0013\u0003\u0014\u0003\u0014\a\u0014Â\n\u0014\f\u0014\u000E\u0014Å\v\u0014\u0003\u0015\u0003\u0015\u0003\u0015\u0003\u0015\u0003\u0016\u0003\u0016\a\u0016Í\n\u0016\f\u0016\u000E\u0016Ð\v\u0016\u0003\u0017\u0003\u0017\u0003\u0017\u0005\u0017Õ\n\u0017\u0003\u0017\u0003\u0017\u0003\u0017\u0003\u0017\u0005\u0017Û\n\u0017\u0003\u0017\u0003\u0017\u0003\u0017\u0003\u0017\u0003\u0018\u0003\u0018\u0003\u0018\u0005\u0018ä\n\u0018\u0003\u0018\u0003\u0018\u0003\u0018\u0003\u0018\u0005\u0018ê\n\u0018\u0003\u0018\u0003\u0018\u0003\u0018\u0003\u0018\u0003\u0019\u0003\u0019\u0003\u0019\u0003\u0019\u0003\u0019\u0003\u0019\u0003\u001A\u0003\u001A\u0003\u001A\u0003\u001A\u0003\u001A\u0003\u001A\u0003\u001A\u0005\u001Aý\n\u001A\u0003\u001A\u0003\u001A\u0005\u001Aā\n\u001A\u0003\u001A\u0003\u001A\u0005\u001Aą\n\u001A\u0003\u001A\u0003\u001A\u0005\u001Aĉ\n\u001A\u0003\u001B\u0003\u001B\u0003\u001B\u0003\u001B\u0003\u001C\u0003\u001C\u0003\u001C\a\u001CĒ\n\u001C\f\u001C\u000E\u001Cĕ\v\u001C\u0003\u001D\u0003\u001D\u0003\u001E\u0003\u001E\u0003\u001E\u0003\u001E\u0003\u001E\u0003\u001E\u0005\u001Eğ\n\u001E\u0003\u001E\u0003\u001E\u0003\u001E\u0003\u001E\u0003\u001E\u0003\u001E\a\u001Eħ\n\u001E\f\u001E\u000E\u001EĪ\v\u001E\u0003\u001F\u0003\u001F\u0003\u001F\u0005\u001Fį\n\u001F\u0003\u001F\u0003\u001F\u0003 \u0003 \u0003 \u0003 \u0003 \u0005 ĸ\n \a ĺ\n \f \u000E Ľ\v \u0003!\u0003!\u0005!Ł\n!\u0003!\u0003!\u0003!\u0003\"\u0003\"\u0005\"ň\n\"\u0003\"\u0003\"\u0003\"\u0003\"\u0003\"\u0003\"\u0003\"\u0005\"ő\n\"\u0005\"œ\n\"\u0003#\u0003#\u0003#\u0003#\u0003#\u0003#\u0003#\u0003#\u0003#\u0003#\u0003#\u0005#Š\n#\u0003#\u0003#\u0003#\u0003#\u0003#\u0003#\u0003#\u0003#\u0003#\u0003#\u0003#\u0003#\u0003#\u0003#\u0003#\u0003#\u0003#\u0003#\u0003#\u0003#\u0003#\u0003#\u0003#\u0003#\u0003#\u0003#\u0003#\a#Ž\n#\f#\u000E#ƀ\v#\u0003$\u0003$\u0005$Ƅ\n$\u0003%\u0003%\u0003&\u0003&\u0003'\u0003'\u0003(\u0003(\u0003)\u0003)\u0003*\u0003*\u0005*ƒ\n*\u0003*\u0003*\u0003*\u0002\u0002\u0004:D+\u0002\u0002\u0004\u0002\u0006\u0002\b\u0002\n\u0002\f\u0002\u000E\u0002\u0010\u0002\u0012\u0002\u0014\u0002\u0016\u0002\u0018\u0002\u001A\u0002\u001C\u0002\u001E\u0002 \u0002\"\u0002$\u0002&\u0002(\u0002*\u0002,\u0002.\u00020\u00022\u00024\u00026\u00028\u0002:\u0002<\u0002>\u0002@\u0002B\u0002D\u0002F\u0002H\u0002J\u0002L\u0002N\u0002P\u0002R\u0002\u0002\f\u0003\u0002\n\u0011\u0003\u0002AC\u0003\u0002\u0014\u0015\u0003\u0002+.\u0003\u0002+,\u0003\u0002/0\u0003\u000212\u0003\u000236\u0003\u00027>\u0004\u0002-.?@ƫ\u0002W\u0003\u0002\u0002\u0002\u0004Z\u0003\u0002\u0002\u0002\u0006^\u0003\u0002\u0002\u0002\be\u0003\u0002\u0002\u0002\nj\u0003\u0002\u0002\u0002\fl\u0003\u0002\u0002\u0002\u000E|\u0003\u0002\u0002\u0002\u0010\u0084\u0003\u0002\u0002\u0002\u0012\u0086\u0003\u0002\u0002\u0002\u0014\u0088\u0003\u0002\u0002\u0002\u0016\u0090\u0003\u0002\u0002\u0002\u0018\u0092\u0003\u0002\u0002\u0002\u001A \u0003\u0002\u0002\u0002\u001C¢\u0003\u0002\u0002\u0002\u001E¤\u0003\u0002\u0002\u0002 ¦\u0003\u0002\u0002\u0002\"¯\u0003\u0002\u0002\u0002$±\u0003\u0002\u0002\u0002&¿\u0003\u0002\u0002\u0002(Æ\u0003\u0002\u0002\u0002*Ê\u0003\u0002\u0002\u0002,Ñ\u0003\u0002\u0002\u0002.à\u0003\u0002\u0002\u00020ï\u0003\u0002\u0002\u00022Ĉ\u0003\u0002\u0002\u00024Ċ\u0003\u0002\u0002\u00026Ď\u0003\u0002\u0002\u00028Ė\u0003\u0002\u0002\u0002:Ę\u0003\u0002\u0002\u0002<ī\u0003\u0002\u0002\u0002>Ĳ\u0003\u0002\u0002\u0002@ŀ\u0003\u0002\u0002\u0002BŒ\u0003\u0002\u0002\u0002Dş\u0003\u0002\u0002\u0002Fƃ\u0003\u0002\u0002\u0002Hƅ\u0003\u0002\u0002\u0002JƇ\u0003\u0002\u0002\u0002LƉ\u0003\u0002\u0002\u0002NƋ\u0003\u0002\u0002\u0002Pƍ\u0003\u0002\u0002\u0002RƏ\u0003\u0002\u0002\u0002TV\u00052\u001A\u0002UT\u0003\u0002\u0002\u0002VY\u0003\u0002\u0002\u0002WU\u0003\u0002\u0002\u0002WX\u0003\u0002\u0002\u0002X\u0003\u0003\u0002\u0002\u0002YW\u0003\u0002\u0002\u0002Z[\u0005\u0006\u0004\u0002[\\\a\u0003\u0002\u0002\\]\u0005\n\u0006\u0002]\u0005\u0003\u0002\u0002\u0002^b\u0005\b\u0005\u0002_a\u0005\b\u0005\u0002`_\u0003\u0002\u0002\u0002ad\u0003\u0002\u0002\u0002b`\u0003\u0002\u0002\u0002bc\u0003\u0002\u0002\u0002c\a\u0003\u0002\u0002\u0002db\u0003\u0002\u0002\u0002ef\a\u0004\u0002\u0002fg\u0005F$\u0002g\t\u0003\u0002\u0002\u0002hk\u0005\f\a\u0002ik\u0005D#\u0002jh\u0003\u0002\u0002\u0002ji\u0003\u0002\u0002\u0002k\v\u0003\u0002\u0002\u0002lx\a\u0005\u0002\u0002mr\u0005\n\u0006\u0002no\a\u0006\u0002\u0002oq\u0005\n\u0006\u0002pn\u0003\u0002\u0002\u0002qt\u0003\u0002\u0002\u0002rp\u0003\u0002\u0002\u0002rs\u0003\u0002\u0002\u0002sv\u0003\u0002\u0002\u0002tr\u0003\u0002\u0002\u0002uw\a\u0006\u0002\u0002vu\u0003\u0002\u0002\u0002vw\u0003\u0002\u0002\u0002wy\u0003\u0002\u0002\u0002xm\u0003\u0002\u0002\u0002xy\u0003\u0002\u0002\u0002yz\u0003\u0002\u0002\u0002z{\a\a\u0002\u0002{\r\u0003\u0002\u0002\u0002|\u0081\u0005\u0010\t\u0002}~\a\b\u0002\u0002~\u0080\a\t\u0002\u0002\u007F}\u0003\u0002\u0002\u0002\u0080\u0083\u0003\u0002\u0002\u0002\u0081\u007F\u0003\u0002\u0002\u0002\u0081\u0082\u0003\u0002\u0002\u0002\u0082\u000F\u0003\u0002\u0002\u0002\u0083\u0081\u0003\u0002\u0002\u0002\u0084\u0085\t\u0002\u0002\u0002\u0085\u0011\u0003\u0002\u0002\u0002\u0086\u0087\a\u0004\u0002\u0002\u0087\u0013\u0003\u0002\u0002\u0002\u0088\u008D\u0005\u0018\r\u0002\u0089\u008A\a\u0006\u0002\u0002\u008A\u008C\u0005\u0018\r\u0002\u008B\u0089\u0003\u0002\u0002\u0002\u008C\u008F\u0003\u0002\u0002\u0002\u008D\u008B\u0003\u0002\u0002\u0002\u008D\u008E\u0003\u0002\u0002\u0002\u008E\u0015\u0003\u0002\u0002\u0002\u008F\u008D\u0003\u0002\u0002\u0002\u0090\u0091\u0005 \u0011\u0002\u0091\u0017\u0003\u0002\u0002\u0002\u0092\u0097\aG\u0002\u0002\u0093\u0094\a\u0012\u0002\u0002\u0094\u0096\aG\u0002\u0002\u0095\u0093\u0003\u0002\u0002\u0002\u0096\u0099\u0003\u0002\u0002\u0002\u0097\u0095\u0003\u0002\u0002\u0002\u0097\u0098\u0003\u0002\u0002\u0002\u0098\u0019\u0003\u0002\u0002\u0002\u0099\u0097\u0003\u0002\u0002\u0002\u009A¡\u0005\u001C\u000F\u0002\u009B¡\aD\u0002\u0002\u009C¡\aE\u0002\u0002\u009D¡\aF\u0002\u0002\u009E¡\u0005\u001E\u0010\u0002\u009F¡\a\u0013\u0002\u0002 \u009A\u0003\u0002\u0002\u0002 \u009B\u0003\u0002\u0002\u0002 \u009C\u0003\u0002\u0002\u0002 \u009D\u0003\u0002\u0002\u0002 \u009E\u0003\u0002\u0002\u0002 \u009F\u0003\u0002\u0002\u0002¡\u001B\u0003\u0002\u0002\u0002¢£\t\u0003\u0002\u0002£\u001D\u0003\u0002\u0002\u0002¤¥\t\u0004\u0002\u0002¥\u001F\u0003\u0002\u0002\u0002¦ª\a\u0016\u0002\u0002§©\u0005\"\u0012\u0002¨§\u0003\u0002\u0002\u0002©¬\u0003\u0002\u0002\u0002ª¨\u0003\u0002\u0002\u0002ª«\u0003\u0002\u0002\u0002«\u00AD\u0003\u0002\u0002\u0002¬ª\u0003\u0002\u0002\u0002\u00AD®\a\u0017\u0002\u0002®!\u0003\u0002\u0002\u0002¯°\u00052\u001A\u0002°#\u0003\u0002\u0002\u0002±\u00B2\a\u0018\u0002\u0002\u00B2\u00B3\u00054\u001B\u0002\u00B3·\u0005&\u0014\u0002´¶\u0005(\u0015\u0002µ´\u0003\u0002\u0002\u0002¶\u00B9\u0003\u0002\u0002\u0002·µ\u0003\u0002\u0002\u0002·¸\u0003\u0002\u0002\u0002¸»\u0003\u0002\u0002\u0002\u00B9·\u0003\u0002\u0002\u0002º\u00BC\u0005*\u0016\u0002»º\u0003\u0002\u0002\u0002»\u00BC\u0003\u0002\u0002\u0002\u00BC\u00BD\u0003\u0002\u0002\u0002\u00BD\u00BE\a\u0019\u0002\u0002\u00BE%\u0003\u0002\u0002\u0002¿Ã\a\u001A\u0002\u0002ÀÂ\u00052\u001A\u0002ÁÀ\u0003\u0002\u0002\u0002ÂÅ\u0003\u0002\u0002\u0002ÃÁ\u0003\u0002\u0002\u0002ÃÄ\u0003\u0002\u0002\u0002Ä'\u0003\u0002\u0002\u0002ÅÃ\u0003\u0002\u0002\u0002ÆÇ\a\u001B\u0002\u0002ÇÈ\u00054\u001B\u0002ÈÉ\u0005&\u0014\u0002É)\u0003\u0002\u0002\u0002ÊÎ\a\u001C\u0002\u0002ËÍ\u00052\u001A\u0002ÌË\u0003\u0002\u0002\u0002ÍÐ\u0003\u0002\u0002\u0002ÎÌ\u0003\u0002\u0002\u0002ÎÏ\u0003\u0002\u0002\u0002Ï+\u0003\u0002\u0002\u0002ÐÎ\u0003\u0002\u0002\u0002ÑÔ\a\u001D\u0002\u0002ÒÕ\u0005\u0004\u0003\u0002ÓÕ\u0005@!\u0002ÔÒ\u0003\u0002\u0002\u0002ÔÓ\u0003\u0002\u0002\u0002ÕÖ\u0003\u0002\u0002\u0002Ö×\a\u001E\u0002\u0002×Ú\u0005D#\u0002ØÙ\a\u001F\u0002\u0002ÙÛ\u0005D#\u0002ÚØ\u0003\u0002\u0002\u0002ÚÛ\u0003\u0002\u0002\u0002ÛÜ\u0003\u0002\u0002\u0002ÜÝ\a\u0016\u0002\u0002ÝÞ\u00052\u001A\u0002Þß\a \u0002\u0002ß-\u0003\u0002\u0002\u0002àã\a\u001D\u0002\u0002áä\u0005\u0004\u0003\u0002âä\u0005@!\u0002ãá\u0003\u0002\u0002\u0002ãâ\u0003\u0002\u0002\u0002äå\u0003\u0002\u0002\u0002åæ\a!\u0002\u0002æé\u0005D#\u0002çè\a\u001F\u0002\u0002èê\u0005D#\u0002éç\u0003\u0002\u0002\u0002éê\u0003\u0002\u0002\u0002êë\u0003\u0002\u0002\u0002ëì\a\u0016\u0002\u0002ìí\u00052\u001A\u0002íî\a \u0002\u0002î/\u0003\u0002\u0002\u0002ïð\a\"\u0002\u0002ðñ\u00054\u001B\u0002ñò\a\u0016\u0002\u0002òó\u00052\u001A\u0002óô\a#\u0002\u0002ô1\u0003\u0002\u0002\u0002õĉ\u0005 \u0011\u0002öĉ\u0005$\u0013\u0002÷ĉ\u0005,\u0017\u0002øĉ\u0005.\u0018\u0002ùĉ\u00050\u0019\u0002úü\a$\u0002\u0002ûý\u0005D#\u0002üû\u0003\u0002\u0002\u0002üý\u0003\u0002\u0002\u0002ýĉ\u0003\u0002\u0002\u0002þĀ\a%\u0002\u0002ÿā\aG\u0002\u0002Āÿ\u0003\u0002\u0002\u0002Āā\u0003\u0002\u0002\u0002āĉ\u0003\u0002\u0002\u0002ĂĄ\a&\u0002\u0002ăą\aG\u0002\u0002Ąă\u0003\u0002\u0002\u0002Ąą\u0003\u0002\u0002\u0002ąĉ\u0003\u0002\u0002\u0002Ćĉ\a'\u0002\u0002ćĉ\u00058\u001D\u0002Ĉõ\u0003\u0002\u0002\u0002Ĉö\u0003\u0002\u0002\u0002Ĉ÷\u0003\u0002\u0002\u0002Ĉø\u0003\u0002\u0002\u0002Ĉù\u0003\u0002\u0002\u0002Ĉú\u0003\u0002\u0002\u0002Ĉþ\u0003\u0002\u0002\u0002ĈĂ\u0003\u0002\u0002\u0002ĈĆ\u0003\u0002\u0002\u0002Ĉć\u0003\u0002\u0002\u0002ĉ3\u0003\u0002\u0002\u0002Ċċ\a(\u0002\u0002ċČ\u0005D#\u0002Čč\a)\u0002\u0002č5\u0003\u0002\u0002\u0002Ďē\u0005D#\u0002ďĐ\a\u0006\u0002\u0002ĐĒ\u0005D#\u0002đď\u0003\u0002\u0002\u0002Ēĕ\u0003\u0002\u0002\u0002ēđ\u0003\u0002\u0002\u0002ēĔ\u0003\u0002\u0002\u0002Ĕ7\u0003\u0002\u0002\u0002ĕē\u0003\u0002\u0002\u0002Ėė\u0005D#\u0002ė9\u0003\u0002\u0002\u0002Ęę\b\u001E\u0001\u0002ęĞ\u0005F$\u0002Ěě\a\b\u0002\u0002ěĜ\u0005D#\u0002Ĝĝ\a\t\u0002\u0002ĝğ\u0003\u0002\u0002\u0002ĞĚ\u0003\u0002\u0002\u0002Ğğ\u0003\u0002\u0002\u0002ğĨ\u0003\u0002\u0002\u0002Ġġ\f\u0004\u0002\u0002ġĢ\a\u0012\u0002\u0002Ģħ\u0005:\u001E\u0005ģĤ\f\u0003\u0002\u0002Ĥĥ\a\u0012\u0002\u0002ĥħ\u0005<\u001F\u0002ĦĠ\u0003\u0002\u0002\u0002Ħģ\u0003\u0002\u0002\u0002ħĪ\u0003\u0002\u0002\u0002ĨĦ\u0003\u0002\u0002\u0002Ĩĩ\u0003\u0002\u0002\u0002ĩ;\u0003\u0002\u0002\u0002ĪĨ\u0003\u0002\u0002\u0002īĬ\u0005:\u001E\u0002ĬĮ\a(\u0002\u0002ĭį\u00056\u001C\u0002Įĭ\u0003\u0002\u0002\u0002Įį\u0003\u0002\u0002\u0002įİ\u0003\u0002\u0002\u0002İı\a)\u0002\u0002ı=\u0003\u0002\u0002\u0002Ĳĳ\u0005:\u001E\u0002ĳĻ\a*\u0002\u0002Ĵĵ\a\u0012\u0002\u0002ĵķ\u0005:\u001E\u0002Ķĸ\a*\u0002\u0002ķĶ\u0003\u0002\u0002\u0002ķĸ\u0003\u0002\u0002\u0002ĸĺ\u0003\u0002\u0002\u0002ĹĴ\u0003\u0002\u0002\u0002ĺĽ\u0003\u0002\u0002\u0002ĻĹ\u0003\u0002\u0002\u0002Ļļ\u0003\u0002\u0002\u0002ļ?\u0003\u0002\u0002\u0002ĽĻ\u0003\u0002\u0002\u0002ľŁ\u0005:\u001E\u0002ĿŁ\u0005<\u001F\u0002ŀľ\u0003\u0002\u0002\u0002ŀĿ\u0003\u0002\u0002\u0002Łł\u0003\u0002\u0002\u0002łŃ\a\u0003\u0002\u0002Ńń\u0005D#\u0002ńA\u0003\u0002\u0002\u0002Ņň\u0005:\u001E\u0002ņň\u0005<\u001F\u0002ŇŅ\u0003\u0002\u0002\u0002Ňņ\u0003\u0002\u0002\u0002ňŉ\u0003\u0002\u0002\u0002ŉŊ\u0005L'\u0002Ŋŋ\a\u0013\u0002\u0002ŋœ\u0003\u0002\u0002\u0002Ōō\a\u0013\u0002\u0002ōŐ\u0005L'\u0002Ŏő\u0005:\u001E\u0002ŏő\u0005<\u001F\u0002ŐŎ\u0003\u0002\u0002\u0002Őŏ\u0003\u0002\u0002\u0002őœ\u0003\u0002\u0002\u0002ŒŇ\u0003\u0002\u0002\u0002ŒŌ\u0003\u0002\u0002\u0002œC\u0003\u0002\u0002\u0002Ŕŕ\b#\u0001\u0002ŕŠ\u0005<\u001F\u0002ŖŠ\u0005B\"\u0002ŗŠ\u0005\u0006\u0004\u0002ŘŠ\u0005\u0004\u0003\u0002řŠ\u0005:\u001E\u0002ŚŠ\u0005@!\u0002śŠ\u00054\u001B\u0002ŜŠ\u0005> \u0002ŝŞ\t\u0005\u0002\u0002ŞŠ\u0005D#\aşŔ\u0003\u0002\u0002\u0002şŖ\u0003\u0002\u0002\u0002şŗ\u0003\u0002\u0002\u0002şŘ\u0003\u0002\u0002\u0002şř\u0003\u0002\u0002\u0002şŚ\u0003\u0002\u0002\u0002şś\u0003\u0002\u0002\u0002şŜ\u0003\u0002\u0002\u0002şŝ\u0003\u0002\u0002\u0002Šž\u0003\u0002\u0002\u0002šŢ\f\u000F\u0002\u0002Ţţ\u0005P)\u0002ţŤ\u0005D#\u0010ŤŽ\u0003\u0002\u0002\u0002ťŦ\f\u0006\u0002\u0002Ŧŧ\u0005N(\u0002ŧŨ\u0005D#\aŨŽ\u0003\u0002\u0002\u0002ũŪ\f\u0005\u0002\u0002Ūū\u0005L'\u0002ūŬ\u0005D#\u0006ŬŽ\u0003\u0002\u0002\u0002ŭŮ\f\u0004\u0002\u0002Ůů\u0005J&\u0002ůŰ\u0005D#\u0005ŰŽ\u0003\u0002\u0002\u0002űŲ\f\u0003\u0002\u0002Ųų\u0005H%\u0002ųŴ\u0005D#\u0004ŴŽ\u0003\u0002\u0002\u0002ŵŶ\f\v\u0002\u0002Ŷŷ\a\b\u0002\u0002ŷŸ\u0005D#\u0002ŸŹ\a\t\u0002\u0002ŹŽ\u0003\u0002\u0002\u0002źŻ\f\b\u0002\u0002ŻŽ\t\u0006\u0002\u0002żš\u0003\u0002\u0002\u0002żť\u0003\u0002\u0002\u0002żũ\u0003\u0002\u0002\u0002żŭ\u0003\u0002\u0002\u0002żű\u0003\u0002\u0002\u0002żŵ\u0003\u0002\u0002\u0002żź\u0003\u0002\u0002\u0002Žƀ\u0003\u0002\u0002\u0002žż\u0003\u0002\u0002\u0002žſ\u0003\u0002\u0002\u0002ſE\u0003\u0002\u0002\u0002ƀž\u0003\u0002\u0002\u0002ƁƄ\u0005\u001A\u000E\u0002ƂƄ\aG\u0002\u0002ƃƁ\u0003\u0002\u0002\u0002ƃƂ\u0003\u0002\u0002\u0002ƄG\u0003\u0002\u0002\u0002ƅƆ\t\a\u0002\u0002ƆI\u0003\u0002\u0002\u0002Ƈƈ\t\b\u0002\u0002ƈK\u0003\u0002\u0002\u0002ƉƊ\t\t\u0002\u0002ƊM\u0003\u0002\u0002\u0002Ƌƌ\t\n\u0002\u0002ƌO\u0003\u0002\u0002\u0002ƍƎ\t\v\u0002\u0002ƎQ\u0003\u0002\u0002\u0002ƏƑ\a(\u0002\u0002Ɛƒ\u00056\u001C\u0002ƑƐ\u0003\u0002\u0002\u0002Ƒƒ\u0003\u0002\u0002\u0002ƒƓ\u0003\u0002\u0002\u0002ƓƔ\a)\u0002\u0002ƔS\u0003\u0002\u0002\u0002)Wbjrvx\u0081\u008D\u0097 ª·»ÃÎÔÚãéüĀĄĈēĞĦĨĮķĻŀŇŐŒşżžƃƑ";
  public static readonly ATN _ATN = new ATNDeserializer().Deserialize(FormCalcParser._serializedATN.ToCharArray());

  private static string[] GenerateTokenNames(IVocabulary vocabulary, int length)
  {
    string[] tokenNames = new string[length];
    for (int index = 0; index < tokenNames.Length; ++index)
    {
      tokenNames[index] = vocabulary.GetLiteralName(index);
      if (tokenNames[index] == null)
        tokenNames[index] = vocabulary.GetSymbolicName(index);
      if (tokenNames[index] == null)
        tokenNames[index] = "<INVALID>";
    }
    return tokenNames;
  }

  [Obsolete]
  public virtual string[] TokenNames => FormCalcParser.tokenNames;

  [NotNull]
  public virtual IVocabulary Vocabulary => FormCalcParser.DefaultVocabulary;

  public virtual string GrammarFileName => "FormCalc.g4";

  public virtual string[] RuleNames => FormCalcParser.ruleNames;

  public virtual string SerializedAtn => FormCalcParser._serializedATN;

  public FormCalcParser(ITokenStream input)
    : base(input)
  {
    ((Recognizer<IToken, ParserATNSimulator>) this)._interp = new ParserATNSimulator((Parser) this, FormCalcParser._ATN);
  }

  [RuleVersion(0)]
  public FormCalcParser.CompilationUnitContext compilationUnit()
  {
    FormCalcParser.CompilationUnitContext compilationUnitContext = new FormCalcParser.CompilationUnitContext(this._ctx, ((Recognizer<IToken, ParserATNSimulator>) this).State);
    this.EnterRule((ParserRuleContext) compilationUnitContext, 0, 0);
    try
    {
      this.EnterOuterAlt((ParserRuleContext) compilationUnitContext, 1);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 85;
      this._errHandler.Sync((Parser) this);
      int num = ((IIntStream) this._input).La(1);
      while (true)
      {
        if ((num & -64) != 0 || (1L << num & -9223338514494652412L) == 0L)
          goto label_4;
label_2:
        ((Recognizer<IToken, ParserATNSimulator>) this).State = 82;
        this.statement();
        ((Recognizer<IToken, ParserATNSimulator>) this).State = 87;
        this._errHandler.Sync((Parser) this);
        num = ((IIntStream) this._input).La(1);
        continue;
label_4:
        if ((num - 64 /*0x40*/ & -64) == 0)
        {
          if ((1L << num - 64 /*0x40*/ & 63L /*0x3F*/) != 0L)
            goto label_2;
          break;
        }
        break;
      }
    }
    catch (RecognitionException ex)
    {
      compilationUnitContext.exception = ex;
      this._errHandler.ReportError((Parser) this, ex);
      this._errHandler.Recover((Parser) this, ex);
    }
    finally
    {
      this.ExitRule();
    }
    return compilationUnitContext;
  }

  [RuleVersion(0)]
  public FormCalcParser.VariableAssignContext variableAssign()
  {
    FormCalcParser.VariableAssignContext variableAssignContext = new FormCalcParser.VariableAssignContext(this._ctx, ((Recognizer<IToken, ParserATNSimulator>) this).State);
    this.EnterRule((ParserRuleContext) variableAssignContext, 2, 1);
    try
    {
      this.EnterOuterAlt((ParserRuleContext) variableAssignContext, 1);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 88;
      this.variableDeclarator();
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 89;
      this.Match(1);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 90;
      this.variableInitializer();
    }
    catch (RecognitionException ex)
    {
      variableAssignContext.exception = ex;
      this._errHandler.ReportError((Parser) this, ex);
      this._errHandler.Recover((Parser) this, ex);
    }
    finally
    {
      this.ExitRule();
    }
    return variableAssignContext;
  }

  [RuleVersion(0)]
  public FormCalcParser.VariableDeclaratorContext variableDeclarator()
  {
    FormCalcParser.VariableDeclaratorContext declaratorContext = new FormCalcParser.VariableDeclaratorContext(this._ctx, ((Recognizer<IToken, ParserATNSimulator>) this).State);
    this.EnterRule((ParserRuleContext) declaratorContext, 4, 2);
    try
    {
      this.EnterOuterAlt((ParserRuleContext) declaratorContext, 1);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 92;
      this.variableDeclaratorId();
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 96 /*0x60*/;
      this._errHandler.Sync((Parser) this);
      int num = ((Recognizer<IToken, ParserATNSimulator>) this).Interpreter.AdaptivePredict(this._input, 1, this._ctx);
      while (true)
      {
        switch (num)
        {
          case 0:
          case 2:
            goto label_7;
          case 1:
            ((Recognizer<IToken, ParserATNSimulator>) this).State = 93;
            this.variableDeclaratorId();
            break;
        }
        ((Recognizer<IToken, ParserATNSimulator>) this).State = 98;
        this._errHandler.Sync((Parser) this);
        num = ((Recognizer<IToken, ParserATNSimulator>) this).Interpreter.AdaptivePredict(this._input, 1, this._ctx);
      }
    }
    catch (RecognitionException ex)
    {
      declaratorContext.exception = ex;
      this._errHandler.ReportError((Parser) this, ex);
      this._errHandler.Recover((Parser) this, ex);
    }
    finally
    {
      this.ExitRule();
    }
label_7:
    return declaratorContext;
  }

  [RuleVersion(0)]
  public FormCalcParser.VariableDeclaratorIdContext variableDeclaratorId()
  {
    FormCalcParser.VariableDeclaratorIdContext declaratorIdContext = new FormCalcParser.VariableDeclaratorIdContext(this._ctx, ((Recognizer<IToken, ParserATNSimulator>) this).State);
    this.EnterRule((ParserRuleContext) declaratorIdContext, 6, 3);
    try
    {
      this.EnterOuterAlt((ParserRuleContext) declaratorIdContext, 1);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 99;
      this.Match(2);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 100;
      this.primary();
    }
    catch (RecognitionException ex)
    {
      declaratorIdContext.exception = ex;
      this._errHandler.ReportError((Parser) this, ex);
      this._errHandler.Recover((Parser) this, ex);
    }
    finally
    {
      this.ExitRule();
    }
    return declaratorIdContext;
  }

  [RuleVersion(0)]
  public FormCalcParser.VariableInitializerContext variableInitializer()
  {
    FormCalcParser.VariableInitializerContext initializerContext = new FormCalcParser.VariableInitializerContext(this._ctx, ((Recognizer<IToken, ParserATNSimulator>) this).State);
    this.EnterRule((ParserRuleContext) initializerContext, 8, 4);
    try
    {
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 104;
      switch (((IIntStream) this._input).La(1))
      {
        case 2:
        case 17:
        case 18:
        case 19:
        case 38:
        case 41:
        case 42:
        case 43:
        case 44:
        case 63 /*0x3F*/:
        case 64 /*0x40*/:
        case 65:
        case 66:
        case 67:
        case 68:
        case 69:
          this.EnterOuterAlt((ParserRuleContext) initializerContext, 2);
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 103;
          this.expression(0);
          break;
        case 3:
          this.EnterOuterAlt((ParserRuleContext) initializerContext, 1);
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 102;
          this.arrayInitializer();
          break;
        default:
          throw new NoViableAltException((Parser) this);
      }
    }
    catch (RecognitionException ex)
    {
      initializerContext.exception = ex;
      this._errHandler.ReportError((Parser) this, ex);
      this._errHandler.Recover((Parser) this, ex);
    }
    finally
    {
      this.ExitRule();
    }
    return initializerContext;
  }

  [RuleVersion(0)]
  public FormCalcParser.ArrayInitializerContext arrayInitializer()
  {
    FormCalcParser.ArrayInitializerContext initializerContext = new FormCalcParser.ArrayInitializerContext(this._ctx, ((Recognizer<IToken, ParserATNSimulator>) this).State);
    this.EnterRule((ParserRuleContext) initializerContext, 10, 5);
    try
    {
      this.EnterOuterAlt((ParserRuleContext) initializerContext, 1);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 106;
      this.Match(3);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 118;
      int num1 = ((IIntStream) this._input).La(1);
      if ((num1 & -64) == 0 && (1L << num1 & -9223338776627118068L /*0x80001E40000E000C*/) != 0L || (num1 - 64 /*0x40*/ & -64) == 0 && (1L << num1 - 64 /*0x40*/ & 63L /*0x3F*/) != 0L)
      {
        ((Recognizer<IToken, ParserATNSimulator>) this).State = 107;
        this.variableInitializer();
        ((Recognizer<IToken, ParserATNSimulator>) this).State = 112 /*0x70*/;
        this._errHandler.Sync((Parser) this);
        int num2 = ((Recognizer<IToken, ParserATNSimulator>) this).Interpreter.AdaptivePredict(this._input, 3, this._ctx);
        while (true)
        {
          switch (num2)
          {
            case 0:
            case 2:
              goto label_6;
            case 1:
              ((Recognizer<IToken, ParserATNSimulator>) this).State = 108;
              this.Match(4);
              ((Recognizer<IToken, ParserATNSimulator>) this).State = 109;
              this.variableInitializer();
              break;
          }
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 114;
          this._errHandler.Sync((Parser) this);
          num2 = ((Recognizer<IToken, ParserATNSimulator>) this).Interpreter.AdaptivePredict(this._input, 3, this._ctx);
        }
label_6:
        ((Recognizer<IToken, ParserATNSimulator>) this).State = 116;
        if (((IIntStream) this._input).La(1) == 4)
        {
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 115;
          this.Match(4);
        }
      }
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 120;
      this.Match(5);
    }
    catch (RecognitionException ex)
    {
      initializerContext.exception = ex;
      this._errHandler.ReportError((Parser) this, ex);
      this._errHandler.Recover((Parser) this, ex);
    }
    finally
    {
      this.ExitRule();
    }
    return initializerContext;
  }

  [RuleVersion(0)]
  public FormCalcParser.TypeContext type()
  {
    FormCalcParser.TypeContext typeContext = new FormCalcParser.TypeContext(this._ctx, ((Recognizer<IToken, ParserATNSimulator>) this).State);
    this.EnterRule((ParserRuleContext) typeContext, 12, 6);
    try
    {
      this.EnterOuterAlt((ParserRuleContext) typeContext, 1);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 122;
      this.primitiveType();
      ((Recognizer<IToken, ParserATNSimulator>) this).State = (int) sbyte.MaxValue;
      this._errHandler.Sync((Parser) this);
      for (int index = ((IIntStream) this._input).La(1); index == 6; index = ((IIntStream) this._input).La(1))
      {
        ((Recognizer<IToken, ParserATNSimulator>) this).State = 123;
        this.Match(6);
        ((Recognizer<IToken, ParserATNSimulator>) this).State = 124;
        this.Match(7);
        ((Recognizer<IToken, ParserATNSimulator>) this).State = 129;
        this._errHandler.Sync((Parser) this);
      }
    }
    catch (RecognitionException ex)
    {
      typeContext.exception = ex;
      this._errHandler.ReportError((Parser) this, ex);
      this._errHandler.Recover((Parser) this, ex);
    }
    finally
    {
      this.ExitRule();
    }
    return typeContext;
  }

  [RuleVersion(0)]
  public FormCalcParser.PrimitiveTypeContext primitiveType()
  {
    FormCalcParser.PrimitiveTypeContext primitiveTypeContext = new FormCalcParser.PrimitiveTypeContext(this._ctx, ((Recognizer<IToken, ParserATNSimulator>) this).State);
    this.EnterRule((ParserRuleContext) primitiveTypeContext, 14, 7);
    try
    {
      this.EnterOuterAlt((ParserRuleContext) primitiveTypeContext, 1);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 130;
      int num = ((IIntStream) this._input).La(1);
      if ((num & -64) != 0 || (1L << num & 65280L) == 0L)
        this._errHandler.RecoverInline((Parser) this);
      else
        this.Consume();
    }
    catch (RecognitionException ex)
    {
      primitiveTypeContext.exception = ex;
      this._errHandler.ReportError((Parser) this, ex);
      this._errHandler.Recover((Parser) this, ex);
    }
    finally
    {
      this.ExitRule();
    }
    return primitiveTypeContext;
  }

  [RuleVersion(0)]
  public FormCalcParser.VariableModifierContext variableModifier()
  {
    FormCalcParser.VariableModifierContext variableModifierContext = new FormCalcParser.VariableModifierContext(this._ctx, ((Recognizer<IToken, ParserATNSimulator>) this).State);
    this.EnterRule((ParserRuleContext) variableModifierContext, 16 /*0x10*/, 8);
    try
    {
      this.EnterOuterAlt((ParserRuleContext) variableModifierContext, 1);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 132;
      this.Match(2);
    }
    catch (RecognitionException ex)
    {
      variableModifierContext.exception = ex;
      this._errHandler.ReportError((Parser) this, ex);
      this._errHandler.Recover((Parser) this, ex);
    }
    finally
    {
      this.ExitRule();
    }
    return variableModifierContext;
  }

  [RuleVersion(0)]
  public FormCalcParser.QualifiedNameListContext qualifiedNameList()
  {
    FormCalcParser.QualifiedNameListContext qualifiedNameListContext = new FormCalcParser.QualifiedNameListContext(this._ctx, ((Recognizer<IToken, ParserATNSimulator>) this).State);
    this.EnterRule((ParserRuleContext) qualifiedNameListContext, 18, 9);
    try
    {
      this.EnterOuterAlt((ParserRuleContext) qualifiedNameListContext, 1);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 134;
      this.qualifiedName();
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 139;
      this._errHandler.Sync((Parser) this);
      for (int index = ((IIntStream) this._input).La(1); index == 4; index = ((IIntStream) this._input).La(1))
      {
        ((Recognizer<IToken, ParserATNSimulator>) this).State = 135;
        this.Match(4);
        ((Recognizer<IToken, ParserATNSimulator>) this).State = 136;
        this.qualifiedName();
        ((Recognizer<IToken, ParserATNSimulator>) this).State = 141;
        this._errHandler.Sync((Parser) this);
      }
    }
    catch (RecognitionException ex)
    {
      qualifiedNameListContext.exception = ex;
      this._errHandler.ReportError((Parser) this, ex);
      this._errHandler.Recover((Parser) this, ex);
    }
    finally
    {
      this.ExitRule();
    }
    return qualifiedNameListContext;
  }

  [RuleVersion(0)]
  public FormCalcParser.MethodBodyContext methodBody()
  {
    FormCalcParser.MethodBodyContext methodBodyContext = new FormCalcParser.MethodBodyContext(this._ctx, ((Recognizer<IToken, ParserATNSimulator>) this).State);
    this.EnterRule((ParserRuleContext) methodBodyContext, 20, 10);
    try
    {
      this.EnterOuterAlt((ParserRuleContext) methodBodyContext, 1);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 142;
      this.block();
    }
    catch (RecognitionException ex)
    {
      methodBodyContext.exception = ex;
      this._errHandler.ReportError((Parser) this, ex);
      this._errHandler.Recover((Parser) this, ex);
    }
    finally
    {
      this.ExitRule();
    }
    return methodBodyContext;
  }

  [RuleVersion(0)]
  public FormCalcParser.QualifiedNameContext qualifiedName()
  {
    FormCalcParser.QualifiedNameContext qualifiedNameContext = new FormCalcParser.QualifiedNameContext(this._ctx, ((Recognizer<IToken, ParserATNSimulator>) this).State);
    this.EnterRule((ParserRuleContext) qualifiedNameContext, 22, 11);
    try
    {
      this.EnterOuterAlt((ParserRuleContext) qualifiedNameContext, 1);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 144 /*0x90*/;
      this.Match(69);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 149;
      this._errHandler.Sync((Parser) this);
      for (int index = ((IIntStream) this._input).La(1); index == 16 /*0x10*/; index = ((IIntStream) this._input).La(1))
      {
        ((Recognizer<IToken, ParserATNSimulator>) this).State = 145;
        this.Match(16 /*0x10*/);
        ((Recognizer<IToken, ParserATNSimulator>) this).State = 146;
        this.Match(69);
        ((Recognizer<IToken, ParserATNSimulator>) this).State = 151;
        this._errHandler.Sync((Parser) this);
      }
    }
    catch (RecognitionException ex)
    {
      qualifiedNameContext.exception = ex;
      this._errHandler.ReportError((Parser) this, ex);
      this._errHandler.Recover((Parser) this, ex);
    }
    finally
    {
      this.ExitRule();
    }
    return qualifiedNameContext;
  }

  [RuleVersion(0)]
  public FormCalcParser.LiteralContext literal()
  {
    FormCalcParser.LiteralContext literalContext = new FormCalcParser.LiteralContext(this._ctx, ((Recognizer<IToken, ParserATNSimulator>) this).State);
    this.EnterRule((ParserRuleContext) literalContext, 24, 12);
    try
    {
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 158;
      switch (((IIntStream) this._input).La(1))
      {
        case 17:
          this.EnterOuterAlt((ParserRuleContext) literalContext, 6);
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 157;
          this.Match(17);
          break;
        case 18:
        case 19:
          this.EnterOuterAlt((ParserRuleContext) literalContext, 5);
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 156;
          this.booleanLiteral();
          break;
        case 63 /*0x3F*/:
        case 64 /*0x40*/:
        case 65:
          this.EnterOuterAlt((ParserRuleContext) literalContext, 1);
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 152;
          this.integerLiteral();
          break;
        case 66:
          this.EnterOuterAlt((ParserRuleContext) literalContext, 2);
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 153;
          this.Match(66);
          break;
        case 67:
          this.EnterOuterAlt((ParserRuleContext) literalContext, 3);
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 154;
          this.Match(67);
          break;
        case 68:
          this.EnterOuterAlt((ParserRuleContext) literalContext, 4);
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 155;
          this.Match(68);
          break;
        default:
          throw new NoViableAltException((Parser) this);
      }
    }
    catch (RecognitionException ex)
    {
      literalContext.exception = ex;
      this._errHandler.ReportError((Parser) this, ex);
      this._errHandler.Recover((Parser) this, ex);
    }
    finally
    {
      this.ExitRule();
    }
    return literalContext;
  }

  [RuleVersion(0)]
  public FormCalcParser.IntegerLiteralContext integerLiteral()
  {
    FormCalcParser.IntegerLiteralContext integerLiteralContext = new FormCalcParser.IntegerLiteralContext(this._ctx, ((Recognizer<IToken, ParserATNSimulator>) this).State);
    this.EnterRule((ParserRuleContext) integerLiteralContext, 26, 13);
    try
    {
      this.EnterOuterAlt((ParserRuleContext) integerLiteralContext, 1);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 160 /*0xA0*/;
      int num = ((IIntStream) this._input).La(1);
      if ((num - 63 /*0x3F*/ & -64) != 0 || (1L << num - 63 /*0x3F*/ & 7L) == 0L)
        this._errHandler.RecoverInline((Parser) this);
      else
        this.Consume();
    }
    catch (RecognitionException ex)
    {
      integerLiteralContext.exception = ex;
      this._errHandler.ReportError((Parser) this, ex);
      this._errHandler.Recover((Parser) this, ex);
    }
    finally
    {
      this.ExitRule();
    }
    return integerLiteralContext;
  }

  [RuleVersion(0)]
  public FormCalcParser.BooleanLiteralContext booleanLiteral()
  {
    FormCalcParser.BooleanLiteralContext booleanLiteralContext = new FormCalcParser.BooleanLiteralContext(this._ctx, ((Recognizer<IToken, ParserATNSimulator>) this).State);
    this.EnterRule((ParserRuleContext) booleanLiteralContext, 28, 14);
    try
    {
      this.EnterOuterAlt((ParserRuleContext) booleanLiteralContext, 1);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 162;
      switch (((IIntStream) this._input).La(1))
      {
        case 18:
        case 19:
          this.Consume();
          break;
        default:
          this._errHandler.RecoverInline((Parser) this);
          break;
      }
    }
    catch (RecognitionException ex)
    {
      booleanLiteralContext.exception = ex;
      this._errHandler.ReportError((Parser) this, ex);
      this._errHandler.Recover((Parser) this, ex);
    }
    finally
    {
      this.ExitRule();
    }
    return booleanLiteralContext;
  }

  [RuleVersion(0)]
  public FormCalcParser.BlockContext block()
  {
    FormCalcParser.BlockContext blockContext = new FormCalcParser.BlockContext(this._ctx, ((Recognizer<IToken, ParserATNSimulator>) this).State);
    this.EnterRule((ParserRuleContext) blockContext, 30, 15);
    try
    {
      this.EnterOuterAlt((ParserRuleContext) blockContext, 1);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 164;
      this.Match(20);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 168;
      this._errHandler.Sync((Parser) this);
      for (int index = ((IIntStream) this._input).La(1); (index & -64) == 0 && (1L << index & -9223338514494652412L) != 0L || (index - 64 /*0x40*/ & -64) == 0 && (1L << index - 64 /*0x40*/ & 63L /*0x3F*/) != 0L; index = ((IIntStream) this._input).La(1))
      {
        ((Recognizer<IToken, ParserATNSimulator>) this).State = 165;
        this.blockStatement();
        ((Recognizer<IToken, ParserATNSimulator>) this).State = 170;
        this._errHandler.Sync((Parser) this);
      }
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 171;
      this.Match(21);
    }
    catch (RecognitionException ex)
    {
      blockContext.exception = ex;
      this._errHandler.ReportError((Parser) this, ex);
      this._errHandler.Recover((Parser) this, ex);
    }
    finally
    {
      this.ExitRule();
    }
    return blockContext;
  }

  [RuleVersion(0)]
  public FormCalcParser.BlockStatementContext blockStatement()
  {
    FormCalcParser.BlockStatementContext statementContext = new FormCalcParser.BlockStatementContext(this._ctx, ((Recognizer<IToken, ParserATNSimulator>) this).State);
    this.EnterRule((ParserRuleContext) statementContext, 32 /*0x20*/, 16 /*0x10*/);
    try
    {
      this.EnterOuterAlt((ParserRuleContext) statementContext, 1);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 173;
      this.statement();
    }
    catch (RecognitionException ex)
    {
      statementContext.exception = ex;
      this._errHandler.ReportError((Parser) this, ex);
      this._errHandler.Recover((Parser) this, ex);
    }
    finally
    {
      this.ExitRule();
    }
    return statementContext;
  }

  [RuleVersion(0)]
  public FormCalcParser.IfStatementContext ifStatement()
  {
    FormCalcParser.IfStatementContext statementContext = new FormCalcParser.IfStatementContext(this._ctx, ((Recognizer<IToken, ParserATNSimulator>) this).State);
    this.EnterRule((ParserRuleContext) statementContext, 34, 17);
    try
    {
      this.EnterOuterAlt((ParserRuleContext) statementContext, 1);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 175;
      this.Match(22);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 176 /*0xB0*/;
      this.parExpression();
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 177;
      this.thenStatement();
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 181;
      this._errHandler.Sync((Parser) this);
      for (int index = ((IIntStream) this._input).La(1); index == 25; index = ((IIntStream) this._input).La(1))
      {
        ((Recognizer<IToken, ParserATNSimulator>) this).State = 178;
        this.elseIfStatement();
        ((Recognizer<IToken, ParserATNSimulator>) this).State = 183;
        this._errHandler.Sync((Parser) this);
      }
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 185;
      if (((IIntStream) this._input).La(1) == 26)
      {
        ((Recognizer<IToken, ParserATNSimulator>) this).State = 184;
        this.elseStatement();
      }
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 187;
      this.Match(23);
    }
    catch (RecognitionException ex)
    {
      statementContext.exception = ex;
      this._errHandler.ReportError((Parser) this, ex);
      this._errHandler.Recover((Parser) this, ex);
    }
    finally
    {
      this.ExitRule();
    }
    return statementContext;
  }

  [RuleVersion(0)]
  public FormCalcParser.ThenStatementContext thenStatement()
  {
    FormCalcParser.ThenStatementContext statementContext = new FormCalcParser.ThenStatementContext(this._ctx, ((Recognizer<IToken, ParserATNSimulator>) this).State);
    this.EnterRule((ParserRuleContext) statementContext, 36, 18);
    try
    {
      this.EnterOuterAlt((ParserRuleContext) statementContext, 1);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 189;
      this.Match(24);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 193;
      this._errHandler.Sync((Parser) this);
      int num = ((IIntStream) this._input).La(1);
      while (true)
      {
        if ((num & -64) != 0 || (1L << num & -9223338514494652412L) == 0L)
          goto label_4;
label_2:
        ((Recognizer<IToken, ParserATNSimulator>) this).State = 190;
        this.statement();
        ((Recognizer<IToken, ParserATNSimulator>) this).State = 195;
        this._errHandler.Sync((Parser) this);
        num = ((IIntStream) this._input).La(1);
        continue;
label_4:
        if ((num - 64 /*0x40*/ & -64) == 0)
        {
          if ((1L << num - 64 /*0x40*/ & 63L /*0x3F*/) != 0L)
            goto label_2;
          break;
        }
        break;
      }
    }
    catch (RecognitionException ex)
    {
      statementContext.exception = ex;
      this._errHandler.ReportError((Parser) this, ex);
      this._errHandler.Recover((Parser) this, ex);
    }
    finally
    {
      this.ExitRule();
    }
    return statementContext;
  }

  [RuleVersion(0)]
  public FormCalcParser.ElseIfStatementContext elseIfStatement()
  {
    FormCalcParser.ElseIfStatementContext statementContext = new FormCalcParser.ElseIfStatementContext(this._ctx, ((Recognizer<IToken, ParserATNSimulator>) this).State);
    this.EnterRule((ParserRuleContext) statementContext, 38, 19);
    try
    {
      this.EnterOuterAlt((ParserRuleContext) statementContext, 1);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 196;
      this.Match(25);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 197;
      this.parExpression();
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 198;
      this.thenStatement();
    }
    catch (RecognitionException ex)
    {
      statementContext.exception = ex;
      this._errHandler.ReportError((Parser) this, ex);
      this._errHandler.Recover((Parser) this, ex);
    }
    finally
    {
      this.ExitRule();
    }
    return statementContext;
  }

  [RuleVersion(0)]
  public FormCalcParser.ElseStatementContext elseStatement()
  {
    FormCalcParser.ElseStatementContext statementContext = new FormCalcParser.ElseStatementContext(this._ctx, ((Recognizer<IToken, ParserATNSimulator>) this).State);
    this.EnterRule((ParserRuleContext) statementContext, 40, 20);
    try
    {
      this.EnterOuterAlt((ParserRuleContext) statementContext, 1);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 200;
      this.Match(26);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 204;
      this._errHandler.Sync((Parser) this);
      int num = ((IIntStream) this._input).La(1);
      while (true)
      {
        if ((num & -64) != 0 || (1L << num & -9223338514494652412L) == 0L)
          goto label_4;
label_2:
        ((Recognizer<IToken, ParserATNSimulator>) this).State = 201;
        this.statement();
        ((Recognizer<IToken, ParserATNSimulator>) this).State = 206;
        this._errHandler.Sync((Parser) this);
        num = ((IIntStream) this._input).La(1);
        continue;
label_4:
        if ((num - 64 /*0x40*/ & -64) == 0)
        {
          if ((1L << num - 64 /*0x40*/ & 63L /*0x3F*/) != 0L)
            goto label_2;
          break;
        }
        break;
      }
    }
    catch (RecognitionException ex)
    {
      statementContext.exception = ex;
      this._errHandler.ReportError((Parser) this, ex);
      this._errHandler.Recover((Parser) this, ex);
    }
    finally
    {
      this.ExitRule();
    }
    return statementContext;
  }

  [RuleVersion(0)]
  public FormCalcParser.ForUpToStatementContext forUpToStatement()
  {
    FormCalcParser.ForUpToStatementContext statement = new FormCalcParser.ForUpToStatementContext(this._ctx, ((Recognizer<IToken, ParserATNSimulator>) this).State);
    this.EnterRule((ParserRuleContext) statement, 42, 21);
    try
    {
      this.EnterOuterAlt((ParserRuleContext) statement, 1);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 207;
      this.Match(27);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 210;
      switch (((IIntStream) this._input).La(1))
      {
        case 2:
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 208 /*0xD0*/;
          this.variableAssign();
          break;
        case 17:
        case 18:
        case 19:
        case 63 /*0x3F*/:
        case 64 /*0x40*/:
        case 65:
        case 66:
        case 67:
        case 68:
        case 69:
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 209;
          this.assign();
          break;
        default:
          throw new NoViableAltException((Parser) this);
      }
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 212;
      this.Match(28);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 213;
      this.expression(0);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 216;
      if (((IIntStream) this._input).La(1) == 29)
      {
        ((Recognizer<IToken, ParserATNSimulator>) this).State = 214;
        this.Match(29);
        ((Recognizer<IToken, ParserATNSimulator>) this).State = 215;
        this.expression(0);
      }
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 218;
      this.Match(20);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 219;
      this.statement();
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 220;
      this.Match(30);
    }
    catch (RecognitionException ex)
    {
      statement.exception = ex;
      this._errHandler.ReportError((Parser) this, ex);
      this._errHandler.Recover((Parser) this, ex);
    }
    finally
    {
      this.ExitRule();
    }
    return statement;
  }

  [RuleVersion(0)]
  public FormCalcParser.ForDownToStatementContext forDownToStatement()
  {
    FormCalcParser.ForDownToStatementContext statement = new FormCalcParser.ForDownToStatementContext(this._ctx, ((Recognizer<IToken, ParserATNSimulator>) this).State);
    this.EnterRule((ParserRuleContext) statement, 44, 22);
    try
    {
      this.EnterOuterAlt((ParserRuleContext) statement, 1);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 222;
      this.Match(27);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 225;
      switch (((IIntStream) this._input).La(1))
      {
        case 2:
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 223;
          this.variableAssign();
          break;
        case 17:
        case 18:
        case 19:
        case 63 /*0x3F*/:
        case 64 /*0x40*/:
        case 65:
        case 66:
        case 67:
        case 68:
        case 69:
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 224 /*0xE0*/;
          this.assign();
          break;
        default:
          throw new NoViableAltException((Parser) this);
      }
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 227;
      this.Match(31 /*0x1F*/);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 228;
      this.expression(0);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 231;
      if (((IIntStream) this._input).La(1) == 29)
      {
        ((Recognizer<IToken, ParserATNSimulator>) this).State = 229;
        this.Match(29);
        ((Recognizer<IToken, ParserATNSimulator>) this).State = 230;
        this.expression(0);
      }
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 233;
      this.Match(20);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 234;
      this.statement();
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 235;
      this.Match(30);
    }
    catch (RecognitionException ex)
    {
      statement.exception = ex;
      this._errHandler.ReportError((Parser) this, ex);
      this._errHandler.Recover((Parser) this, ex);
    }
    finally
    {
      this.ExitRule();
    }
    return statement;
  }

  [RuleVersion(0)]
  public FormCalcParser.WhileStatementContext whileStatement()
  {
    FormCalcParser.WhileStatementContext statementContext = new FormCalcParser.WhileStatementContext(this._ctx, ((Recognizer<IToken, ParserATNSimulator>) this).State);
    this.EnterRule((ParserRuleContext) statementContext, 46, 23);
    try
    {
      this.EnterOuterAlt((ParserRuleContext) statementContext, 1);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 237;
      this.Match(32 /*0x20*/);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 238;
      this.parExpression();
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 239;
      this.Match(20);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 240 /*0xF0*/;
      this.statement();
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 241;
      this.Match(33);
    }
    catch (RecognitionException ex)
    {
      statementContext.exception = ex;
      this._errHandler.ReportError((Parser) this, ex);
      this._errHandler.Recover((Parser) this, ex);
    }
    finally
    {
      this.ExitRule();
    }
    return statementContext;
  }

  [RuleVersion(0)]
  public FormCalcParser.StatementContext statement()
  {
    FormCalcParser.StatementContext statementContext = new FormCalcParser.StatementContext(this._ctx, ((Recognizer<IToken, ParserATNSimulator>) this).State);
    this.EnterRule((ParserRuleContext) statementContext, 48 /*0x30*/, 24);
    try
    {
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 262;
      this._errHandler.Sync((Parser) this);
      switch (((Recognizer<IToken, ParserATNSimulator>) this).Interpreter.AdaptivePredict(this._input, 22, this._ctx))
      {
        case 1:
          this.EnterOuterAlt((ParserRuleContext) statementContext, 1);
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 243;
          this.block();
          break;
        case 2:
          this.EnterOuterAlt((ParserRuleContext) statementContext, 2);
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 244;
          this.ifStatement();
          break;
        case 3:
          this.EnterOuterAlt((ParserRuleContext) statementContext, 3);
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 245;
          this.forUpToStatement();
          break;
        case 4:
          this.EnterOuterAlt((ParserRuleContext) statementContext, 4);
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 246;
          this.forDownToStatement();
          break;
        case 5:
          this.EnterOuterAlt((ParserRuleContext) statementContext, 5);
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 247;
          this.whileStatement();
          break;
        case 6:
          this.EnterOuterAlt((ParserRuleContext) statementContext, 6);
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 248;
          this.Match(34);
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 250;
          this._errHandler.Sync((Parser) this);
          if (((Recognizer<IToken, ParserATNSimulator>) this).Interpreter.AdaptivePredict(this._input, 19, this._ctx) == 1)
          {
            ((Recognizer<IToken, ParserATNSimulator>) this).State = 249;
            this.expression(0);
            break;
          }
          break;
        case 7:
          this.EnterOuterAlt((ParserRuleContext) statementContext, 7);
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 252;
          this.Match(35);
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 254;
          this._errHandler.Sync((Parser) this);
          if (((Recognizer<IToken, ParserATNSimulator>) this).Interpreter.AdaptivePredict(this._input, 20, this._ctx) == 1)
          {
            ((Recognizer<IToken, ParserATNSimulator>) this).State = 253;
            this.Match(69);
            break;
          }
          break;
        case 8:
          this.EnterOuterAlt((ParserRuleContext) statementContext, 8);
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 256 /*0x0100*/;
          this.Match(36);
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 258;
          this._errHandler.Sync((Parser) this);
          if (((Recognizer<IToken, ParserATNSimulator>) this).Interpreter.AdaptivePredict(this._input, 21, this._ctx) == 1)
          {
            ((Recognizer<IToken, ParserATNSimulator>) this).State = 257;
            this.Match(69);
            break;
          }
          break;
        case 9:
          this.EnterOuterAlt((ParserRuleContext) statementContext, 9);
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 260;
          this.Match(37);
          break;
        case 10:
          this.EnterOuterAlt((ParserRuleContext) statementContext, 10);
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 261;
          this.statementExpression();
          break;
      }
    }
    catch (RecognitionException ex)
    {
      statementContext.exception = ex;
      this._errHandler.ReportError((Parser) this, ex);
      this._errHandler.Recover((Parser) this, ex);
    }
    finally
    {
      this.ExitRule();
    }
    return statementContext;
  }

  [RuleVersion(0)]
  public FormCalcParser.ParExpressionContext parExpression()
  {
    FormCalcParser.ParExpressionContext expressionContext = new FormCalcParser.ParExpressionContext(this._ctx, ((Recognizer<IToken, ParserATNSimulator>) this).State);
    this.EnterRule((ParserRuleContext) expressionContext, 50, 25);
    try
    {
      this.EnterOuterAlt((ParserRuleContext) expressionContext, 1);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 264;
      this.Match(38);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 265;
      this.expression(0);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 266;
      this.Match(39);
    }
    catch (RecognitionException ex)
    {
      expressionContext.exception = ex;
      this._errHandler.ReportError((Parser) this, ex);
      this._errHandler.Recover((Parser) this, ex);
    }
    finally
    {
      this.ExitRule();
    }
    return expressionContext;
  }

  [RuleVersion(0)]
  public FormCalcParser.ExpressionListContext expressionList()
  {
    FormCalcParser.ExpressionListContext expressionListContext = new FormCalcParser.ExpressionListContext(this._ctx, ((Recognizer<IToken, ParserATNSimulator>) this).State);
    this.EnterRule((ParserRuleContext) expressionListContext, 52, 26);
    try
    {
      this.EnterOuterAlt((ParserRuleContext) expressionListContext, 1);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 268;
      this.expression(0);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 273;
      this._errHandler.Sync((Parser) this);
      for (int index = ((IIntStream) this._input).La(1); index == 4; index = ((IIntStream) this._input).La(1))
      {
        ((Recognizer<IToken, ParserATNSimulator>) this).State = 269;
        this.Match(4);
        ((Recognizer<IToken, ParserATNSimulator>) this).State = 270;
        this.expression(0);
        ((Recognizer<IToken, ParserATNSimulator>) this).State = 275;
        this._errHandler.Sync((Parser) this);
      }
    }
    catch (RecognitionException ex)
    {
      expressionListContext.exception = ex;
      this._errHandler.ReportError((Parser) this, ex);
      this._errHandler.Recover((Parser) this, ex);
    }
    finally
    {
      this.ExitRule();
    }
    return expressionListContext;
  }

  [RuleVersion(0)]
  public FormCalcParser.StatementExpressionContext statementExpression()
  {
    FormCalcParser.StatementExpressionContext expressionContext = new FormCalcParser.StatementExpressionContext(this._ctx, ((Recognizer<IToken, ParserATNSimulator>) this).State);
    this.EnterRule((ParserRuleContext) expressionContext, 54, 27);
    try
    {
      this.EnterOuterAlt((ParserRuleContext) expressionContext, 1);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 276;
      this.expression(0);
    }
    catch (RecognitionException ex)
    {
      expressionContext.exception = ex;
      this._errHandler.ReportError((Parser) this, ex);
      this._errHandler.Recover((Parser) this, ex);
    }
    finally
    {
      this.ExitRule();
    }
    return expressionContext;
  }

  [RuleVersion(0)]
  public FormCalcParser.AccessorContext accessor() => this.accessor(0);

  private FormCalcParser.AccessorContext accessor(int _p)
  {
    ParserRuleContext ctx = this._ctx;
    int state = ((Recognizer<IToken, ParserATNSimulator>) this).State;
    FormCalcParser.AccessorContext accessorContext = new FormCalcParser.AccessorContext(this._ctx, state);
    int num1 = 56;
    this.EnterRecursionRule((ParserRuleContext) accessorContext, 56, 28, _p);
    try
    {
      this.EnterOuterAlt((ParserRuleContext) accessorContext, 1);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 279;
      this.primary();
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 284;
      this._errHandler.Sync((Parser) this);
      if (((Recognizer<IToken, ParserATNSimulator>) this).Interpreter.AdaptivePredict(this._input, 24, this._ctx) == 1)
      {
        ((Recognizer<IToken, ParserATNSimulator>) this).State = 280;
        this.Match(6);
        ((Recognizer<IToken, ParserATNSimulator>) this).State = 281;
        this.expression(0);
        ((Recognizer<IToken, ParserATNSimulator>) this).State = 282;
        this.Match(7);
      }
      this._ctx.stop = this._input.Lt(-1);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 294;
      this._errHandler.Sync((Parser) this);
      int num2 = ((Recognizer<IToken, ParserATNSimulator>) this).Interpreter.AdaptivePredict(this._input, 26, this._ctx);
      while (true)
      {
        switch (num2)
        {
          case 0:
          case 2:
            goto label_17;
          case 1:
            if (this._parseListeners != null)
              this.TriggerExitRuleEvent();
            ((Recognizer<IToken, ParserATNSimulator>) this).State = 292;
            this._errHandler.Sync((Parser) this);
            switch (((Recognizer<IToken, ParserATNSimulator>) this).Interpreter.AdaptivePredict(this._input, 25, this._ctx))
            {
              case 1:
                accessorContext = new FormCalcParser.AccessorContext(ctx, state);
                this.PushNewRecursionContext((ParserRuleContext) accessorContext, num1, 28);
                ((Recognizer<IToken, ParserATNSimulator>) this).State = 286;
                if (((Recognizer<IToken, ParserATNSimulator>) this).Precpred((RuleContext) this._ctx, 2))
                {
                  ((Recognizer<IToken, ParserATNSimulator>) this).State = 287;
                  this.Match(16 /*0x10*/);
                  ((Recognizer<IToken, ParserATNSimulator>) this).State = 288;
                  this.accessor(3);
                  break;
                }
                goto label_8;
              case 2:
                accessorContext = new FormCalcParser.AccessorContext(ctx, state);
                this.PushNewRecursionContext((ParserRuleContext) accessorContext, num1, 28);
                ((Recognizer<IToken, ParserATNSimulator>) this).State = 289;
                if (((Recognizer<IToken, ParserATNSimulator>) this).Precpred((RuleContext) this._ctx, 1))
                {
                  ((Recognizer<IToken, ParserATNSimulator>) this).State = 290;
                  this.Match(16 /*0x10*/);
                  ((Recognizer<IToken, ParserATNSimulator>) this).State = 291;
                  this.funcCallExpression();
                  break;
                }
                goto label_11;
            }
            break;
        }
        ((Recognizer<IToken, ParserATNSimulator>) this).State = 296;
        this._errHandler.Sync((Parser) this);
        num2 = ((Recognizer<IToken, ParserATNSimulator>) this).Interpreter.AdaptivePredict(this._input, 26, this._ctx);
      }
label_8:
      throw new FailedPredicateException((Parser) this, "Precpred(_ctx, 2)");
label_11:
      throw new FailedPredicateException((Parser) this, "Precpred(_ctx, 1)");
    }
    catch (RecognitionException ex)
    {
      accessorContext.exception = ex;
      this._errHandler.ReportError((Parser) this, ex);
      this._errHandler.Recover((Parser) this, ex);
    }
    finally
    {
      this.UnrollRecursionContexts(ctx);
    }
label_17:
    return accessorContext;
  }

  [RuleVersion(0)]
  public FormCalcParser.FuncCallExpressionContext funcCallExpression()
  {
    FormCalcParser.FuncCallExpressionContext expressionContext = new FormCalcParser.FuncCallExpressionContext(this._ctx, ((Recognizer<IToken, ParserATNSimulator>) this).State);
    this.EnterRule((ParserRuleContext) expressionContext, 58, 29);
    try
    {
      this.EnterOuterAlt((ParserRuleContext) expressionContext, 1);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 297;
      this.accessor(0);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 298;
      this.Match(38);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 300;
      int num = ((IIntStream) this._input).La(1);
      if ((num & -64) == 0 && (1L << num & -9223338776627118076L /*0x80001E40000E0004*/) != 0L || (num - 64 /*0x40*/ & -64) == 0 && (1L << num - 64 /*0x40*/ & 63L /*0x3F*/) != 0L)
      {
        ((Recognizer<IToken, ParserATNSimulator>) this).State = 299;
        this.expressionList();
      }
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 302;
      this.Match(39);
    }
    catch (RecognitionException ex)
    {
      expressionContext.exception = ex;
      this._errHandler.ReportError((Parser) this, ex);
      this._errHandler.Recover((Parser) this, ex);
    }
    finally
    {
      this.ExitRule();
    }
    return expressionContext;
  }

  [RuleVersion(0)]
  public FormCalcParser.WildcardExpressionContext wildcardExpression()
  {
    FormCalcParser.WildcardExpressionContext expressionContext = new FormCalcParser.WildcardExpressionContext(this._ctx, ((Recognizer<IToken, ParserATNSimulator>) this).State);
    this.EnterRule((ParserRuleContext) expressionContext, 60, 30);
    try
    {
      this.EnterOuterAlt((ParserRuleContext) expressionContext, 1);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 304;
      this.accessor(0);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 305;
      this.Match(40);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 313;
      this._errHandler.Sync((Parser) this);
      int num = ((Recognizer<IToken, ParserATNSimulator>) this).Interpreter.AdaptivePredict(this._input, 29, this._ctx);
      while (true)
      {
        switch (num)
        {
          case 0:
          case 2:
            goto label_8;
          case 1:
            ((Recognizer<IToken, ParserATNSimulator>) this).State = 306;
            this.Match(16 /*0x10*/);
            ((Recognizer<IToken, ParserATNSimulator>) this).State = 307;
            this.accessor(0);
            ((Recognizer<IToken, ParserATNSimulator>) this).State = 309;
            this._errHandler.Sync((Parser) this);
            if (((Recognizer<IToken, ParserATNSimulator>) this).Interpreter.AdaptivePredict(this._input, 28, this._ctx) == 1)
            {
              ((Recognizer<IToken, ParserATNSimulator>) this).State = 308;
              this.Match(40);
              break;
            }
            break;
        }
        ((Recognizer<IToken, ParserATNSimulator>) this).State = 315;
        this._errHandler.Sync((Parser) this);
        num = ((Recognizer<IToken, ParserATNSimulator>) this).Interpreter.AdaptivePredict(this._input, 29, this._ctx);
      }
    }
    catch (RecognitionException ex)
    {
      expressionContext.exception = ex;
      this._errHandler.ReportError((Parser) this, ex);
      this._errHandler.Recover((Parser) this, ex);
    }
    finally
    {
      this.ExitRule();
    }
label_8:
    return expressionContext;
  }

  [RuleVersion(0)]
  public FormCalcParser.AssignContext assign()
  {
    FormCalcParser.AssignContext assignContext = new FormCalcParser.AssignContext(this._ctx, ((Recognizer<IToken, ParserATNSimulator>) this).State);
    this.EnterRule((ParserRuleContext) assignContext, 62, 31 /*0x1F*/);
    try
    {
      this.EnterOuterAlt((ParserRuleContext) assignContext, 1);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 318;
      this._errHandler.Sync((Parser) this);
      switch (((Recognizer<IToken, ParserATNSimulator>) this).Interpreter.AdaptivePredict(this._input, 30, this._ctx))
      {
        case 1:
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 316;
          this.accessor(0);
          break;
        case 2:
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 317;
          this.funcCallExpression();
          break;
      }
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 320;
      this.Match(1);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 321;
      this.expression(0);
    }
    catch (RecognitionException ex)
    {
      assignContext.exception = ex;
      this._errHandler.ReportError((Parser) this, ex);
      this._errHandler.Recover((Parser) this, ex);
    }
    finally
    {
      this.ExitRule();
    }
    return assignContext;
  }

  [RuleVersion(0)]
  public FormCalcParser.NullEqualityExpressionContext nullEqualityExpression()
  {
    FormCalcParser.NullEqualityExpressionContext expressionContext = new FormCalcParser.NullEqualityExpressionContext(this._ctx, ((Recognizer<IToken, ParserATNSimulator>) this).State);
    this.EnterRule((ParserRuleContext) expressionContext, 64 /*0x40*/, 32 /*0x20*/);
    try
    {
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 336;
      this._errHandler.Sync((Parser) this);
      switch (((Recognizer<IToken, ParserATNSimulator>) this).Interpreter.AdaptivePredict(this._input, 33, this._ctx))
      {
        case 1:
          this.EnterOuterAlt((ParserRuleContext) expressionContext, 1);
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 325;
          this._errHandler.Sync((Parser) this);
          switch (((Recognizer<IToken, ParserATNSimulator>) this).Interpreter.AdaptivePredict(this._input, 31 /*0x1F*/, this._ctx))
          {
            case 1:
              ((Recognizer<IToken, ParserATNSimulator>) this).State = 323;
              this.accessor(0);
              break;
            case 2:
              ((Recognizer<IToken, ParserATNSimulator>) this).State = 324;
              this.funcCallExpression();
              break;
          }
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 327;
          this.equalityOperators();
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 328;
          this.Match(17);
          break;
        case 2:
          this.EnterOuterAlt((ParserRuleContext) expressionContext, 2);
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 330;
          this.Match(17);
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 331;
          this.equalityOperators();
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 334;
          this._errHandler.Sync((Parser) this);
          switch (((Recognizer<IToken, ParserATNSimulator>) this).Interpreter.AdaptivePredict(this._input, 32 /*0x20*/, this._ctx))
          {
            case 1:
              ((Recognizer<IToken, ParserATNSimulator>) this).State = 332;
              this.accessor(0);
              break;
            case 2:
              ((Recognizer<IToken, ParserATNSimulator>) this).State = 333;
              this.funcCallExpression();
              break;
          }
          break;
      }
    }
    catch (RecognitionException ex)
    {
      expressionContext.exception = ex;
      this._errHandler.ReportError((Parser) this, ex);
      this._errHandler.Recover((Parser) this, ex);
    }
    finally
    {
      this.ExitRule();
    }
    return expressionContext;
  }

  [RuleVersion(0)]
  public FormCalcParser.ExpressionContext expression() => this.expression(0);

  private FormCalcParser.ExpressionContext expression(int _p)
  {
    ParserRuleContext ctx = this._ctx;
    int state = ((Recognizer<IToken, ParserATNSimulator>) this).State;
    FormCalcParser.ExpressionContext expressionContext = new FormCalcParser.ExpressionContext(this._ctx, state);
    int num1 = 66;
    this.EnterRecursionRule((ParserRuleContext) expressionContext, 66, 33, _p);
    try
    {
      this.EnterOuterAlt((ParserRuleContext) expressionContext, 1);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 349;
      this._errHandler.Sync((Parser) this);
      switch (((Recognizer<IToken, ParserATNSimulator>) this).Interpreter.AdaptivePredict(this._input, 34, this._ctx))
      {
        case 1:
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 339;
          this.funcCallExpression();
          break;
        case 2:
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 340;
          this.nullEqualityExpression();
          break;
        case 3:
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 341;
          this.variableDeclarator();
          break;
        case 4:
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 342;
          this.variableAssign();
          break;
        case 5:
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 343;
          this.accessor(0);
          break;
        case 6:
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 344;
          this.assign();
          break;
        case 7:
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 345;
          this.parExpression();
          break;
        case 8:
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 346;
          this.wildcardExpression();
          break;
        case 9:
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 347;
          int num2 = ((IIntStream) this._input).La(1);
          if ((num2 & -64) != 0 || (1L << num2 & 32985348833280L /*0x1E0000000000*/) == 0L)
            this._errHandler.RecoverInline((Parser) this);
          else
            this.Consume();
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 348;
          this.expression(5);
          break;
      }
      this._ctx.stop = this._input.Lt(-1);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 380;
      this._errHandler.Sync((Parser) this);
      int num3 = ((Recognizer<IToken, ParserATNSimulator>) this).Interpreter.AdaptivePredict(this._input, 36, this._ctx);
      while (true)
      {
        switch (num3)
        {
          case 0:
          case 2:
            goto label_45;
          case 1:
            if (this._parseListeners != null)
              this.TriggerExitRuleEvent();
            ((Recognizer<IToken, ParserATNSimulator>) this).State = 378;
            this._errHandler.Sync((Parser) this);
            switch (((Recognizer<IToken, ParserATNSimulator>) this).Interpreter.AdaptivePredict(this._input, 35, this._ctx))
            {
              case 1:
                expressionContext = new FormCalcParser.ExpressionContext(ctx, state);
                this.PushNewRecursionContext((ParserRuleContext) expressionContext, num1, 33);
                ((Recognizer<IToken, ParserATNSimulator>) this).State = 351;
                if (((Recognizer<IToken, ParserATNSimulator>) this).Precpred((RuleContext) this._ctx, 13))
                {
                  ((Recognizer<IToken, ParserATNSimulator>) this).State = 352;
                  this.numericOperators();
                  ((Recognizer<IToken, ParserATNSimulator>) this).State = 353;
                  this.expression(14);
                  break;
                }
                goto label_19;
              case 2:
                expressionContext = new FormCalcParser.ExpressionContext(ctx, state);
                this.PushNewRecursionContext((ParserRuleContext) expressionContext, num1, 33);
                ((Recognizer<IToken, ParserATNSimulator>) this).State = 355;
                if (((Recognizer<IToken, ParserATNSimulator>) this).Precpred((RuleContext) this._ctx, 4))
                {
                  ((Recognizer<IToken, ParserATNSimulator>) this).State = 356;
                  this.relationalOperators();
                  ((Recognizer<IToken, ParserATNSimulator>) this).State = 357;
                  this.expression(5);
                  break;
                }
                goto label_22;
              case 3:
                expressionContext = new FormCalcParser.ExpressionContext(ctx, state);
                this.PushNewRecursionContext((ParserRuleContext) expressionContext, num1, 33);
                ((Recognizer<IToken, ParserATNSimulator>) this).State = 359;
                if (((Recognizer<IToken, ParserATNSimulator>) this).Precpred((RuleContext) this._ctx, 3))
                {
                  ((Recognizer<IToken, ParserATNSimulator>) this).State = 360;
                  this.equalityOperators();
                  ((Recognizer<IToken, ParserATNSimulator>) this).State = 361;
                  this.expression(4);
                  break;
                }
                goto label_25;
              case 4:
                expressionContext = new FormCalcParser.ExpressionContext(ctx, state);
                this.PushNewRecursionContext((ParserRuleContext) expressionContext, num1, 33);
                ((Recognizer<IToken, ParserATNSimulator>) this).State = 363;
                if (((Recognizer<IToken, ParserATNSimulator>) this).Precpred((RuleContext) this._ctx, 2))
                {
                  ((Recognizer<IToken, ParserATNSimulator>) this).State = 364;
                  this.andOperators();
                  ((Recognizer<IToken, ParserATNSimulator>) this).State = 365;
                  this.expression(3);
                  break;
                }
                goto label_28;
              case 5:
                expressionContext = new FormCalcParser.ExpressionContext(ctx, state);
                this.PushNewRecursionContext((ParserRuleContext) expressionContext, num1, 33);
                ((Recognizer<IToken, ParserATNSimulator>) this).State = 367;
                if (((Recognizer<IToken, ParserATNSimulator>) this).Precpred((RuleContext) this._ctx, 1))
                {
                  ((Recognizer<IToken, ParserATNSimulator>) this).State = 368;
                  this.orOperators();
                  ((Recognizer<IToken, ParserATNSimulator>) this).State = 369;
                  this.expression(2);
                  break;
                }
                goto label_31;
              case 6:
                expressionContext = new FormCalcParser.ExpressionContext(ctx, state);
                this.PushNewRecursionContext((ParserRuleContext) expressionContext, num1, 33);
                ((Recognizer<IToken, ParserATNSimulator>) this).State = 371;
                if (((Recognizer<IToken, ParserATNSimulator>) this).Precpred((RuleContext) this._ctx, 9))
                {
                  ((Recognizer<IToken, ParserATNSimulator>) this).State = 372;
                  this.Match(6);
                  ((Recognizer<IToken, ParserATNSimulator>) this).State = 373;
                  this.expression(0);
                  ((Recognizer<IToken, ParserATNSimulator>) this).State = 374;
                  this.Match(7);
                  break;
                }
                goto label_34;
              case 7:
                expressionContext = new FormCalcParser.ExpressionContext(ctx, state);
                this.PushNewRecursionContext((ParserRuleContext) expressionContext, num1, 33);
                ((Recognizer<IToken, ParserATNSimulator>) this).State = 376;
                if (((Recognizer<IToken, ParserATNSimulator>) this).Precpred((RuleContext) this._ctx, 6))
                {
                  ((Recognizer<IToken, ParserATNSimulator>) this).State = 377;
                  switch (((IIntStream) this._input).La(1))
                  {
                    case 41:
                    case 42:
                      this.Consume();
                      break;
                    default:
                      this._errHandler.RecoverInline((Parser) this);
                      break;
                  }
                }
                else
                  goto label_37;
                break;
            }
            break;
        }
        ((Recognizer<IToken, ParserATNSimulator>) this).State = 382;
        this._errHandler.Sync((Parser) this);
        num3 = ((Recognizer<IToken, ParserATNSimulator>) this).Interpreter.AdaptivePredict(this._input, 36, this._ctx);
      }
label_19:
      throw new FailedPredicateException((Parser) this, "Precpred(_ctx, 13)");
label_22:
      throw new FailedPredicateException((Parser) this, "Precpred(_ctx, 4)");
label_25:
      throw new FailedPredicateException((Parser) this, "Precpred(_ctx, 3)");
label_28:
      throw new FailedPredicateException((Parser) this, "Precpred(_ctx, 2)");
label_31:
      throw new FailedPredicateException((Parser) this, "Precpred(_ctx, 1)");
label_34:
      throw new FailedPredicateException((Parser) this, "Precpred(_ctx, 9)");
label_37:
      throw new FailedPredicateException((Parser) this, "Precpred(_ctx, 6)");
    }
    catch (RecognitionException ex)
    {
      expressionContext.exception = ex;
      this._errHandler.ReportError((Parser) this, ex);
      this._errHandler.Recover((Parser) this, ex);
    }
    finally
    {
      this.UnrollRecursionContexts(ctx);
    }
label_45:
    return expressionContext;
  }

  [RuleVersion(0)]
  public FormCalcParser.PrimaryContext primary()
  {
    FormCalcParser.PrimaryContext primaryContext = new FormCalcParser.PrimaryContext(this._ctx, ((Recognizer<IToken, ParserATNSimulator>) this).State);
    this.EnterRule((ParserRuleContext) primaryContext, 68, 34);
    try
    {
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 385;
      switch (((IIntStream) this._input).La(1))
      {
        case 17:
        case 18:
        case 19:
        case 63 /*0x3F*/:
        case 64 /*0x40*/:
        case 65:
        case 66:
        case 67:
        case 68:
          this.EnterOuterAlt((ParserRuleContext) primaryContext, 1);
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 383;
          this.literal();
          break;
        case 69:
          this.EnterOuterAlt((ParserRuleContext) primaryContext, 2);
          ((Recognizer<IToken, ParserATNSimulator>) this).State = 384;
          this.Match(69);
          break;
        default:
          throw new NoViableAltException((Parser) this);
      }
    }
    catch (RecognitionException ex)
    {
      primaryContext.exception = ex;
      this._errHandler.ReportError((Parser) this, ex);
      this._errHandler.Recover((Parser) this, ex);
    }
    finally
    {
      this.ExitRule();
    }
    return primaryContext;
  }

  [RuleVersion(0)]
  public FormCalcParser.OrOperatorsContext orOperators()
  {
    FormCalcParser.OrOperatorsContext operatorsContext = new FormCalcParser.OrOperatorsContext(this._ctx, ((Recognizer<IToken, ParserATNSimulator>) this).State);
    this.EnterRule((ParserRuleContext) operatorsContext, 70, 35);
    try
    {
      this.EnterOuterAlt((ParserRuleContext) operatorsContext, 1);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 387;
      switch (((IIntStream) this._input).La(1))
      {
        case 45:
        case 46:
          this.Consume();
          break;
        default:
          this._errHandler.RecoverInline((Parser) this);
          break;
      }
    }
    catch (RecognitionException ex)
    {
      operatorsContext.exception = ex;
      this._errHandler.ReportError((Parser) this, ex);
      this._errHandler.Recover((Parser) this, ex);
    }
    finally
    {
      this.ExitRule();
    }
    return operatorsContext;
  }

  [RuleVersion(0)]
  public FormCalcParser.AndOperatorsContext andOperators()
  {
    FormCalcParser.AndOperatorsContext operatorsContext = new FormCalcParser.AndOperatorsContext(this._ctx, ((Recognizer<IToken, ParserATNSimulator>) this).State);
    this.EnterRule((ParserRuleContext) operatorsContext, 72, 36);
    try
    {
      this.EnterOuterAlt((ParserRuleContext) operatorsContext, 1);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 389;
      switch (((IIntStream) this._input).La(1))
      {
        case 47:
        case 48 /*0x30*/:
          this.Consume();
          break;
        default:
          this._errHandler.RecoverInline((Parser) this);
          break;
      }
    }
    catch (RecognitionException ex)
    {
      operatorsContext.exception = ex;
      this._errHandler.ReportError((Parser) this, ex);
      this._errHandler.Recover((Parser) this, ex);
    }
    finally
    {
      this.ExitRule();
    }
    return operatorsContext;
  }

  [RuleVersion(0)]
  public FormCalcParser.EqualityOperatorsContext equalityOperators()
  {
    FormCalcParser.EqualityOperatorsContext operatorsContext = new FormCalcParser.EqualityOperatorsContext(this._ctx, ((Recognizer<IToken, ParserATNSimulator>) this).State);
    this.EnterRule((ParserRuleContext) operatorsContext, 74, 37);
    try
    {
      this.EnterOuterAlt((ParserRuleContext) operatorsContext, 1);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 391;
      int num = ((IIntStream) this._input).La(1);
      if ((num & -64) != 0 || (1L << num & 8444249301319680L /*0x1E000000000000*/) == 0L)
        this._errHandler.RecoverInline((Parser) this);
      else
        this.Consume();
    }
    catch (RecognitionException ex)
    {
      operatorsContext.exception = ex;
      this._errHandler.ReportError((Parser) this, ex);
      this._errHandler.Recover((Parser) this, ex);
    }
    finally
    {
      this.ExitRule();
    }
    return operatorsContext;
  }

  [RuleVersion(0)]
  public FormCalcParser.RelationalOperatorsContext relationalOperators()
  {
    FormCalcParser.RelationalOperatorsContext operatorsContext = new FormCalcParser.RelationalOperatorsContext(this._ctx, ((Recognizer<IToken, ParserATNSimulator>) this).State);
    this.EnterRule((ParserRuleContext) operatorsContext, 76, 38);
    try
    {
      this.EnterOuterAlt((ParserRuleContext) operatorsContext, 1);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 393;
      int num = ((IIntStream) this._input).La(1);
      if ((num & -64) != 0 || (1L << num & 2296835809958952960L /*0x1FE0000000000000*/) == 0L)
        this._errHandler.RecoverInline((Parser) this);
      else
        this.Consume();
    }
    catch (RecognitionException ex)
    {
      operatorsContext.exception = ex;
      this._errHandler.ReportError((Parser) this, ex);
      this._errHandler.Recover((Parser) this, ex);
    }
    finally
    {
      this.ExitRule();
    }
    return operatorsContext;
  }

  [RuleVersion(0)]
  public FormCalcParser.NumericOperatorsContext numericOperators()
  {
    FormCalcParser.NumericOperatorsContext operatorsContext = new FormCalcParser.NumericOperatorsContext(this._ctx, ((Recognizer<IToken, ParserATNSimulator>) this).State);
    this.EnterRule((ParserRuleContext) operatorsContext, 78, 39);
    try
    {
      this.EnterOuterAlt((ParserRuleContext) operatorsContext, 1);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 395;
      int num = ((IIntStream) this._input).La(1);
      if ((num & -64) != 0 || (1L << num & 6917555415920148480L /*0x6000180000000000*/) == 0L)
        this._errHandler.RecoverInline((Parser) this);
      else
        this.Consume();
    }
    catch (RecognitionException ex)
    {
      operatorsContext.exception = ex;
      this._errHandler.ReportError((Parser) this, ex);
      this._errHandler.Recover((Parser) this, ex);
    }
    finally
    {
      this.ExitRule();
    }
    return operatorsContext;
  }

  [RuleVersion(0)]
  public FormCalcParser.ArgumentsContext arguments()
  {
    FormCalcParser.ArgumentsContext argumentsContext = new FormCalcParser.ArgumentsContext(this._ctx, ((Recognizer<IToken, ParserATNSimulator>) this).State);
    this.EnterRule((ParserRuleContext) argumentsContext, 80 /*0x50*/, 40);
    try
    {
      this.EnterOuterAlt((ParserRuleContext) argumentsContext, 1);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 397;
      this.Match(38);
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 399;
      int num = ((IIntStream) this._input).La(1);
      if ((num & -64) == 0 && (1L << num & -9223338776627118076L /*0x80001E40000E0004*/) != 0L || (num - 64 /*0x40*/ & -64) == 0 && (1L << num - 64 /*0x40*/ & 63L /*0x3F*/) != 0L)
      {
        ((Recognizer<IToken, ParserATNSimulator>) this).State = 398;
        this.expressionList();
      }
      ((Recognizer<IToken, ParserATNSimulator>) this).State = 401;
      this.Match(39);
    }
    catch (RecognitionException ex)
    {
      argumentsContext.exception = ex;
      this._errHandler.ReportError((Parser) this, ex);
      this._errHandler.Recover((Parser) this, ex);
    }
    finally
    {
      this.ExitRule();
    }
    return argumentsContext;
  }

  public virtual bool Sempred(RuleContext _localctx, int ruleIndex, int predIndex)
  {
    switch (ruleIndex)
    {
      case 28:
        return this.accessor_sempred((FormCalcParser.AccessorContext) _localctx, predIndex);
      case 33:
        return this.expression_sempred((FormCalcParser.ExpressionContext) _localctx, predIndex);
      default:
        return true;
    }
  }

  private bool accessor_sempred(FormCalcParser.AccessorContext _localctx, int predIndex)
  {
    switch (predIndex)
    {
      case 0:
        return ((Recognizer<IToken, ParserATNSimulator>) this).Precpred((RuleContext) this._ctx, 2);
      case 1:
        return ((Recognizer<IToken, ParserATNSimulator>) this).Precpred((RuleContext) this._ctx, 1);
      default:
        return true;
    }
  }

  private bool expression_sempred(FormCalcParser.ExpressionContext _localctx, int predIndex)
  {
    switch (predIndex)
    {
      case 2:
        return ((Recognizer<IToken, ParserATNSimulator>) this).Precpred((RuleContext) this._ctx, 13);
      case 3:
        return ((Recognizer<IToken, ParserATNSimulator>) this).Precpred((RuleContext) this._ctx, 4);
      case 4:
        return ((Recognizer<IToken, ParserATNSimulator>) this).Precpred((RuleContext) this._ctx, 3);
      case 5:
        return ((Recognizer<IToken, ParserATNSimulator>) this).Precpred((RuleContext) this._ctx, 2);
      case 6:
        return ((Recognizer<IToken, ParserATNSimulator>) this).Precpred((RuleContext) this._ctx, 1);
      case 7:
        return ((Recognizer<IToken, ParserATNSimulator>) this).Precpred((RuleContext) this._ctx, 9);
      case 8:
        return ((Recognizer<IToken, ParserATNSimulator>) this).Precpred((RuleContext) this._ctx, 6);
      default:
        return true;
    }
  }

  public class CompilationUnitContext(ParserRuleContext parent, int invokingState) : 
    ParserRuleContext(parent, invokingState)
  {
    public FormCalcParser.StatementContext[] statement()
    {
      return this.GetRuleContexts<FormCalcParser.StatementContext>();
    }

    public FormCalcParser.StatementContext statement(int i)
    {
      return this.GetRuleContext<FormCalcParser.StatementContext>(i);
    }

    public virtual int RuleIndex => 0;

    public virtual void EnterRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.EnterCompilationUnit(this);
    }

    public virtual void ExitRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.ExitCompilationUnit(this);
    }

    public virtual TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
    {
      return visitor is IFormCalcVisitor<TResult> formCalcVisitor ? formCalcVisitor.VisitCompilationUnit(this) : visitor.VisitChildren((IRuleNode) this);
    }
  }

  public class VariableAssignContext(ParserRuleContext parent, int invokingState) : ParserRuleContext(parent, invokingState)
  {
    public FormCalcParser.VariableDeclaratorContext variableDeclarator()
    {
      return this.GetRuleContext<FormCalcParser.VariableDeclaratorContext>(0);
    }

    public FormCalcParser.VariableInitializerContext variableInitializer()
    {
      return this.GetRuleContext<FormCalcParser.VariableInitializerContext>(0);
    }

    public virtual int RuleIndex => 1;

    public virtual void EnterRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.EnterVariableAssign(this);
    }

    public virtual void ExitRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.ExitVariableAssign(this);
    }

    public virtual TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
    {
      return visitor is IFormCalcVisitor<TResult> formCalcVisitor ? formCalcVisitor.VisitVariableAssign(this) : visitor.VisitChildren((IRuleNode) this);
    }
  }

  public class VariableDeclaratorContext(ParserRuleContext parent, int invokingState) : 
    ParserRuleContext(parent, invokingState)
  {
    public FormCalcParser.VariableDeclaratorIdContext[] variableDeclaratorId()
    {
      return this.GetRuleContexts<FormCalcParser.VariableDeclaratorIdContext>();
    }

    public FormCalcParser.VariableDeclaratorIdContext variableDeclaratorId(int i)
    {
      return this.GetRuleContext<FormCalcParser.VariableDeclaratorIdContext>(i);
    }

    public virtual int RuleIndex => 2;

    public virtual void EnterRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.EnterVariableDeclarator(this);
    }

    public virtual void ExitRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.ExitVariableDeclarator(this);
    }

    public virtual TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
    {
      return visitor is IFormCalcVisitor<TResult> formCalcVisitor ? formCalcVisitor.VisitVariableDeclarator(this) : visitor.VisitChildren((IRuleNode) this);
    }
  }

  public class VariableDeclaratorIdContext(ParserRuleContext parent, int invokingState) : 
    ParserRuleContext(parent, invokingState)
  {
    public FormCalcParser.PrimaryContext primary()
    {
      return this.GetRuleContext<FormCalcParser.PrimaryContext>(0);
    }

    public virtual int RuleIndex => 3;

    public virtual void EnterRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.EnterVariableDeclaratorId(this);
    }

    public virtual void ExitRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.ExitVariableDeclaratorId(this);
    }

    public virtual TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
    {
      return visitor is IFormCalcVisitor<TResult> formCalcVisitor ? formCalcVisitor.VisitVariableDeclaratorId(this) : visitor.VisitChildren((IRuleNode) this);
    }
  }

  public class VariableInitializerContext(ParserRuleContext parent, int invokingState) : 
    ParserRuleContext(parent, invokingState)
  {
    public FormCalcParser.ArrayInitializerContext arrayInitializer()
    {
      return this.GetRuleContext<FormCalcParser.ArrayInitializerContext>(0);
    }

    public FormCalcParser.ExpressionContext expression()
    {
      return this.GetRuleContext<FormCalcParser.ExpressionContext>(0);
    }

    public virtual int RuleIndex => 4;

    public virtual void EnterRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.EnterVariableInitializer(this);
    }

    public virtual void ExitRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.ExitVariableInitializer(this);
    }

    public virtual TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
    {
      return visitor is IFormCalcVisitor<TResult> formCalcVisitor ? formCalcVisitor.VisitVariableInitializer(this) : visitor.VisitChildren((IRuleNode) this);
    }
  }

  public class ArrayInitializerContext(ParserRuleContext parent, int invokingState) : 
    ParserRuleContext(parent, invokingState)
  {
    public FormCalcParser.VariableInitializerContext[] variableInitializer()
    {
      return this.GetRuleContexts<FormCalcParser.VariableInitializerContext>();
    }

    public FormCalcParser.VariableInitializerContext variableInitializer(int i)
    {
      return this.GetRuleContext<FormCalcParser.VariableInitializerContext>(i);
    }

    public virtual int RuleIndex => 5;

    public virtual void EnterRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.EnterArrayInitializer(this);
    }

    public virtual void ExitRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.ExitArrayInitializer(this);
    }

    public virtual TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
    {
      return visitor is IFormCalcVisitor<TResult> formCalcVisitor ? formCalcVisitor.VisitArrayInitializer(this) : visitor.VisitChildren((IRuleNode) this);
    }
  }

  public class TypeContext(ParserRuleContext parent, int invokingState) : ParserRuleContext(parent, invokingState)
  {
    public FormCalcParser.PrimitiveTypeContext primitiveType()
    {
      return this.GetRuleContext<FormCalcParser.PrimitiveTypeContext>(0);
    }

    public virtual int RuleIndex => 6;

    public virtual void EnterRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.EnterType(this);
    }

    public virtual void ExitRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.ExitType(this);
    }

    public virtual TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
    {
      return visitor is IFormCalcVisitor<TResult> formCalcVisitor ? formCalcVisitor.VisitType(this) : visitor.VisitChildren((IRuleNode) this);
    }
  }

  public class PrimitiveTypeContext(ParserRuleContext parent, int invokingState) : ParserRuleContext(parent, invokingState)
  {
    public virtual int RuleIndex => 7;

    public virtual void EnterRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.EnterPrimitiveType(this);
    }

    public virtual void ExitRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.ExitPrimitiveType(this);
    }

    public virtual TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
    {
      return visitor is IFormCalcVisitor<TResult> formCalcVisitor ? formCalcVisitor.VisitPrimitiveType(this) : visitor.VisitChildren((IRuleNode) this);
    }
  }

  public class VariableModifierContext(ParserRuleContext parent, int invokingState) : 
    ParserRuleContext(parent, invokingState)
  {
    public virtual int RuleIndex => 8;

    public virtual void EnterRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.EnterVariableModifier(this);
    }

    public virtual void ExitRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.ExitVariableModifier(this);
    }

    public virtual TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
    {
      return visitor is IFormCalcVisitor<TResult> formCalcVisitor ? formCalcVisitor.VisitVariableModifier(this) : visitor.VisitChildren((IRuleNode) this);
    }
  }

  public class QualifiedNameListContext(ParserRuleContext parent, int invokingState) : 
    ParserRuleContext(parent, invokingState)
  {
    public FormCalcParser.QualifiedNameContext[] qualifiedName()
    {
      return this.GetRuleContexts<FormCalcParser.QualifiedNameContext>();
    }

    public FormCalcParser.QualifiedNameContext qualifiedName(int i)
    {
      return this.GetRuleContext<FormCalcParser.QualifiedNameContext>(i);
    }

    public virtual int RuleIndex => 9;

    public virtual void EnterRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.EnterQualifiedNameList(this);
    }

    public virtual void ExitRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.ExitQualifiedNameList(this);
    }

    public virtual TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
    {
      return visitor is IFormCalcVisitor<TResult> formCalcVisitor ? formCalcVisitor.VisitQualifiedNameList(this) : visitor.VisitChildren((IRuleNode) this);
    }
  }

  public class MethodBodyContext(ParserRuleContext parent, int invokingState) : ParserRuleContext(parent, invokingState)
  {
    public FormCalcParser.BlockContext block()
    {
      return this.GetRuleContext<FormCalcParser.BlockContext>(0);
    }

    public virtual int RuleIndex => 10;

    public virtual void EnterRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.EnterMethodBody(this);
    }

    public virtual void ExitRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.ExitMethodBody(this);
    }

    public virtual TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
    {
      return visitor is IFormCalcVisitor<TResult> formCalcVisitor ? formCalcVisitor.VisitMethodBody(this) : visitor.VisitChildren((IRuleNode) this);
    }
  }

  public class QualifiedNameContext(ParserRuleContext parent, int invokingState) : ParserRuleContext(parent, invokingState)
  {
    public ITerminalNode[] Identifier() => this.GetTokens(69);

    public ITerminalNode Identifier(int i) => this.GetToken(69, i);

    public virtual int RuleIndex => 11;

    public virtual void EnterRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.EnterQualifiedName(this);
    }

    public virtual void ExitRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.ExitQualifiedName(this);
    }

    public virtual TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
    {
      return visitor is IFormCalcVisitor<TResult> formCalcVisitor ? formCalcVisitor.VisitQualifiedName(this) : visitor.VisitChildren((IRuleNode) this);
    }
  }

  public class LiteralContext(ParserRuleContext parent, int invokingState) : ParserRuleContext(parent, invokingState)
  {
    public FormCalcParser.IntegerLiteralContext integerLiteral()
    {
      return this.GetRuleContext<FormCalcParser.IntegerLiteralContext>(0);
    }

    public ITerminalNode FloatingPointLiteral() => this.GetToken(66, 0);

    public ITerminalNode CharacterLiteral() => this.GetToken(67, 0);

    public ITerminalNode StringLiteral() => this.GetToken(68, 0);

    public FormCalcParser.BooleanLiteralContext booleanLiteral()
    {
      return this.GetRuleContext<FormCalcParser.BooleanLiteralContext>(0);
    }

    public virtual int RuleIndex => 12;

    public virtual void EnterRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.EnterLiteral(this);
    }

    public virtual void ExitRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.ExitLiteral(this);
    }

    public virtual TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
    {
      return visitor is IFormCalcVisitor<TResult> formCalcVisitor ? formCalcVisitor.VisitLiteral(this) : visitor.VisitChildren((IRuleNode) this);
    }
  }

  public class IntegerLiteralContext(ParserRuleContext parent, int invokingState) : ParserRuleContext(parent, invokingState)
  {
    public ITerminalNode HexLiteral() => this.GetToken(63 /*0x3F*/, 0);

    public ITerminalNode OctalLiteral() => this.GetToken(65, 0);

    public ITerminalNode DecimalLiteral() => this.GetToken(64 /*0x40*/, 0);

    public virtual int RuleIndex => 13;

    public virtual void EnterRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.EnterIntegerLiteral(this);
    }

    public virtual void ExitRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.ExitIntegerLiteral(this);
    }

    public virtual TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
    {
      return visitor is IFormCalcVisitor<TResult> formCalcVisitor ? formCalcVisitor.VisitIntegerLiteral(this) : visitor.VisitChildren((IRuleNode) this);
    }
  }

  public class BooleanLiteralContext(ParserRuleContext parent, int invokingState) : ParserRuleContext(parent, invokingState)
  {
    public virtual int RuleIndex => 14;

    public virtual void EnterRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.EnterBooleanLiteral(this);
    }

    public virtual void ExitRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.ExitBooleanLiteral(this);
    }

    public virtual TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
    {
      return visitor is IFormCalcVisitor<TResult> formCalcVisitor ? formCalcVisitor.VisitBooleanLiteral(this) : visitor.VisitChildren((IRuleNode) this);
    }
  }

  public class BlockContext(ParserRuleContext parent, int invokingState) : ParserRuleContext(parent, invokingState)
  {
    public FormCalcParser.BlockStatementContext[] blockStatement()
    {
      return this.GetRuleContexts<FormCalcParser.BlockStatementContext>();
    }

    public FormCalcParser.BlockStatementContext blockStatement(int i)
    {
      return this.GetRuleContext<FormCalcParser.BlockStatementContext>(i);
    }

    public virtual int RuleIndex => 15;

    public virtual void EnterRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.EnterBlock(this);
    }

    public virtual void ExitRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.ExitBlock(this);
    }

    public virtual TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
    {
      return visitor is IFormCalcVisitor<TResult> formCalcVisitor ? formCalcVisitor.VisitBlock(this) : visitor.VisitChildren((IRuleNode) this);
    }
  }

  public class BlockStatementContext(ParserRuleContext parent, int invokingState) : ParserRuleContext(parent, invokingState)
  {
    public FormCalcParser.StatementContext statement()
    {
      return this.GetRuleContext<FormCalcParser.StatementContext>(0);
    }

    public virtual int RuleIndex => 16 /*0x10*/;

    public virtual void EnterRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.EnterBlockStatement(this);
    }

    public virtual void ExitRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.ExitBlockStatement(this);
    }

    public virtual TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
    {
      return visitor is IFormCalcVisitor<TResult> formCalcVisitor ? formCalcVisitor.VisitBlockStatement(this) : visitor.VisitChildren((IRuleNode) this);
    }
  }

  public class IfStatementContext(ParserRuleContext parent, int invokingState) : ParserRuleContext(parent, invokingState)
  {
    public FormCalcParser.ParExpressionContext parExpression()
    {
      return this.GetRuleContext<FormCalcParser.ParExpressionContext>(0);
    }

    public FormCalcParser.ThenStatementContext thenStatement()
    {
      return this.GetRuleContext<FormCalcParser.ThenStatementContext>(0);
    }

    public FormCalcParser.ElseIfStatementContext[] elseIfStatement()
    {
      return this.GetRuleContexts<FormCalcParser.ElseIfStatementContext>();
    }

    public FormCalcParser.ElseIfStatementContext elseIfStatement(int i)
    {
      return this.GetRuleContext<FormCalcParser.ElseIfStatementContext>(i);
    }

    public FormCalcParser.ElseStatementContext elseStatement()
    {
      return this.GetRuleContext<FormCalcParser.ElseStatementContext>(0);
    }

    public virtual int RuleIndex => 17;

    public virtual void EnterRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.EnterIfStatement(this);
    }

    public virtual void ExitRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.ExitIfStatement(this);
    }

    public virtual TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
    {
      return visitor is IFormCalcVisitor<TResult> formCalcVisitor ? formCalcVisitor.VisitIfStatement(this) : visitor.VisitChildren((IRuleNode) this);
    }
  }

  public class ThenStatementContext(ParserRuleContext parent, int invokingState) : ParserRuleContext(parent, invokingState)
  {
    public FormCalcParser.StatementContext[] statement()
    {
      return this.GetRuleContexts<FormCalcParser.StatementContext>();
    }

    public FormCalcParser.StatementContext statement(int i)
    {
      return this.GetRuleContext<FormCalcParser.StatementContext>(i);
    }

    public virtual int RuleIndex => 18;

    public virtual void EnterRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.EnterThenStatement(this);
    }

    public virtual void ExitRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.ExitThenStatement(this);
    }

    public virtual TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
    {
      return visitor is IFormCalcVisitor<TResult> formCalcVisitor ? formCalcVisitor.VisitThenStatement(this) : visitor.VisitChildren((IRuleNode) this);
    }
  }

  public class ElseIfStatementContext(ParserRuleContext parent, int invokingState) : 
    ParserRuleContext(parent, invokingState)
  {
    public FormCalcParser.ParExpressionContext parExpression()
    {
      return this.GetRuleContext<FormCalcParser.ParExpressionContext>(0);
    }

    public FormCalcParser.ThenStatementContext thenStatement()
    {
      return this.GetRuleContext<FormCalcParser.ThenStatementContext>(0);
    }

    public virtual int RuleIndex => 19;

    public virtual void EnterRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.EnterElseIfStatement(this);
    }

    public virtual void ExitRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.ExitElseIfStatement(this);
    }

    public virtual TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
    {
      return visitor is IFormCalcVisitor<TResult> formCalcVisitor ? formCalcVisitor.VisitElseIfStatement(this) : visitor.VisitChildren((IRuleNode) this);
    }
  }

  public class ElseStatementContext(ParserRuleContext parent, int invokingState) : ParserRuleContext(parent, invokingState)
  {
    public FormCalcParser.StatementContext[] statement()
    {
      return this.GetRuleContexts<FormCalcParser.StatementContext>();
    }

    public FormCalcParser.StatementContext statement(int i)
    {
      return this.GetRuleContext<FormCalcParser.StatementContext>(i);
    }

    public virtual int RuleIndex => 20;

    public virtual void EnterRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.EnterElseStatement(this);
    }

    public virtual void ExitRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.ExitElseStatement(this);
    }

    public virtual TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
    {
      return visitor is IFormCalcVisitor<TResult> formCalcVisitor ? formCalcVisitor.VisitElseStatement(this) : visitor.VisitChildren((IRuleNode) this);
    }
  }

  public class ForUpToStatementContext(ParserRuleContext parent, int invokingState) : 
    ParserRuleContext(parent, invokingState)
  {
    public FormCalcParser.ExpressionContext[] expression()
    {
      return this.GetRuleContexts<FormCalcParser.ExpressionContext>();
    }

    public FormCalcParser.ExpressionContext expression(int i)
    {
      return this.GetRuleContext<FormCalcParser.ExpressionContext>(i);
    }

    public FormCalcParser.StatementContext statement()
    {
      return this.GetRuleContext<FormCalcParser.StatementContext>(0);
    }

    public FormCalcParser.VariableAssignContext variableAssign()
    {
      return this.GetRuleContext<FormCalcParser.VariableAssignContext>(0);
    }

    public FormCalcParser.AssignContext assign()
    {
      return this.GetRuleContext<FormCalcParser.AssignContext>(0);
    }

    public virtual int RuleIndex => 21;

    public virtual void EnterRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.EnterForUpToStatement(this);
    }

    public virtual void ExitRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.ExitForUpToStatement(this);
    }

    public virtual TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
    {
      return visitor is IFormCalcVisitor<TResult> formCalcVisitor ? formCalcVisitor.VisitForUpToStatement(this) : visitor.VisitChildren((IRuleNode) this);
    }
  }

  public class ForDownToStatementContext(ParserRuleContext parent, int invokingState) : 
    ParserRuleContext(parent, invokingState)
  {
    public FormCalcParser.ExpressionContext[] expression()
    {
      return this.GetRuleContexts<FormCalcParser.ExpressionContext>();
    }

    public FormCalcParser.ExpressionContext expression(int i)
    {
      return this.GetRuleContext<FormCalcParser.ExpressionContext>(i);
    }

    public FormCalcParser.StatementContext statement()
    {
      return this.GetRuleContext<FormCalcParser.StatementContext>(0);
    }

    public FormCalcParser.VariableAssignContext variableAssign()
    {
      return this.GetRuleContext<FormCalcParser.VariableAssignContext>(0);
    }

    public FormCalcParser.AssignContext assign()
    {
      return this.GetRuleContext<FormCalcParser.AssignContext>(0);
    }

    public virtual int RuleIndex => 22;

    public virtual void EnterRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.EnterForDownToStatement(this);
    }

    public virtual void ExitRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.ExitForDownToStatement(this);
    }

    public virtual TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
    {
      return visitor is IFormCalcVisitor<TResult> formCalcVisitor ? formCalcVisitor.VisitForDownToStatement(this) : visitor.VisitChildren((IRuleNode) this);
    }
  }

  public class WhileStatementContext(ParserRuleContext parent, int invokingState) : ParserRuleContext(parent, invokingState)
  {
    public FormCalcParser.ParExpressionContext parExpression()
    {
      return this.GetRuleContext<FormCalcParser.ParExpressionContext>(0);
    }

    public FormCalcParser.StatementContext statement()
    {
      return this.GetRuleContext<FormCalcParser.StatementContext>(0);
    }

    public virtual int RuleIndex => 23;

    public virtual void EnterRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.EnterWhileStatement(this);
    }

    public virtual void ExitRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.ExitWhileStatement(this);
    }

    public virtual TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
    {
      return visitor is IFormCalcVisitor<TResult> formCalcVisitor ? formCalcVisitor.VisitWhileStatement(this) : visitor.VisitChildren((IRuleNode) this);
    }
  }

  public class StatementContext(ParserRuleContext parent, int invokingState) : ParserRuleContext(parent, invokingState)
  {
    public FormCalcParser.BlockContext block()
    {
      return this.GetRuleContext<FormCalcParser.BlockContext>(0);
    }

    public FormCalcParser.IfStatementContext ifStatement()
    {
      return this.GetRuleContext<FormCalcParser.IfStatementContext>(0);
    }

    public FormCalcParser.ForUpToStatementContext forUpToStatement()
    {
      return this.GetRuleContext<FormCalcParser.ForUpToStatementContext>(0);
    }

    public FormCalcParser.ForDownToStatementContext forDownToStatement()
    {
      return this.GetRuleContext<FormCalcParser.ForDownToStatementContext>(0);
    }

    public FormCalcParser.WhileStatementContext whileStatement()
    {
      return this.GetRuleContext<FormCalcParser.WhileStatementContext>(0);
    }

    public FormCalcParser.ExpressionContext expression()
    {
      return this.GetRuleContext<FormCalcParser.ExpressionContext>(0);
    }

    public ITerminalNode Identifier() => this.GetToken(69, 0);

    public FormCalcParser.StatementExpressionContext statementExpression()
    {
      return this.GetRuleContext<FormCalcParser.StatementExpressionContext>(0);
    }

    public virtual int RuleIndex => 24;

    public virtual void EnterRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.EnterStatement(this);
    }

    public virtual void ExitRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.ExitStatement(this);
    }

    public virtual TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
    {
      return visitor is IFormCalcVisitor<TResult> formCalcVisitor ? formCalcVisitor.VisitStatement(this) : visitor.VisitChildren((IRuleNode) this);
    }
  }

  public class ParExpressionContext(ParserRuleContext parent, int invokingState) : ParserRuleContext(parent, invokingState)
  {
    public FormCalcParser.ExpressionContext expression()
    {
      return this.GetRuleContext<FormCalcParser.ExpressionContext>(0);
    }

    public virtual int RuleIndex => 25;

    public virtual void EnterRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.EnterParExpression(this);
    }

    public virtual void ExitRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.ExitParExpression(this);
    }

    public virtual TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
    {
      return visitor is IFormCalcVisitor<TResult> formCalcVisitor ? formCalcVisitor.VisitParExpression(this) : visitor.VisitChildren((IRuleNode) this);
    }
  }

  public class ExpressionListContext(ParserRuleContext parent, int invokingState) : ParserRuleContext(parent, invokingState)
  {
    public FormCalcParser.ExpressionContext[] expression()
    {
      return this.GetRuleContexts<FormCalcParser.ExpressionContext>();
    }

    public FormCalcParser.ExpressionContext expression(int i)
    {
      return this.GetRuleContext<FormCalcParser.ExpressionContext>(i);
    }

    public virtual int RuleIndex => 26;

    public virtual void EnterRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.EnterExpressionList(this);
    }

    public virtual void ExitRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.ExitExpressionList(this);
    }

    public virtual TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
    {
      return visitor is IFormCalcVisitor<TResult> formCalcVisitor ? formCalcVisitor.VisitExpressionList(this) : visitor.VisitChildren((IRuleNode) this);
    }
  }

  public class StatementExpressionContext(ParserRuleContext parent, int invokingState) : 
    ParserRuleContext(parent, invokingState)
  {
    public FormCalcParser.ExpressionContext expression()
    {
      return this.GetRuleContext<FormCalcParser.ExpressionContext>(0);
    }

    public virtual int RuleIndex => 27;

    public virtual void EnterRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.EnterStatementExpression(this);
    }

    public virtual void ExitRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.ExitStatementExpression(this);
    }

    public virtual TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
    {
      return visitor is IFormCalcVisitor<TResult> formCalcVisitor ? formCalcVisitor.VisitStatementExpression(this) : visitor.VisitChildren((IRuleNode) this);
    }
  }

  public class AccessorContext(ParserRuleContext parent, int invokingState) : ParserRuleContext(parent, invokingState)
  {
    public FormCalcParser.PrimaryContext primary()
    {
      return this.GetRuleContext<FormCalcParser.PrimaryContext>(0);
    }

    public FormCalcParser.ExpressionContext expression()
    {
      return this.GetRuleContext<FormCalcParser.ExpressionContext>(0);
    }

    public FormCalcParser.AccessorContext[] accessor()
    {
      return this.GetRuleContexts<FormCalcParser.AccessorContext>();
    }

    public FormCalcParser.AccessorContext accessor(int i)
    {
      return this.GetRuleContext<FormCalcParser.AccessorContext>(i);
    }

    public FormCalcParser.FuncCallExpressionContext funcCallExpression()
    {
      return this.GetRuleContext<FormCalcParser.FuncCallExpressionContext>(0);
    }

    public virtual int RuleIndex => 28;

    public virtual void EnterRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.EnterAccessor(this);
    }

    public virtual void ExitRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.ExitAccessor(this);
    }

    public virtual TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
    {
      return visitor is IFormCalcVisitor<TResult> formCalcVisitor ? formCalcVisitor.VisitAccessor(this) : visitor.VisitChildren((IRuleNode) this);
    }
  }

  public class FuncCallExpressionContext(ParserRuleContext parent, int invokingState) : 
    ParserRuleContext(parent, invokingState)
  {
    public FormCalcParser.AccessorContext accessor()
    {
      return this.GetRuleContext<FormCalcParser.AccessorContext>(0);
    }

    public FormCalcParser.ExpressionListContext expressionList()
    {
      return this.GetRuleContext<FormCalcParser.ExpressionListContext>(0);
    }

    public virtual int RuleIndex => 29;

    public virtual void EnterRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.EnterFuncCallExpression(this);
    }

    public virtual void ExitRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.ExitFuncCallExpression(this);
    }

    public virtual TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
    {
      return visitor is IFormCalcVisitor<TResult> formCalcVisitor ? formCalcVisitor.VisitFuncCallExpression(this) : visitor.VisitChildren((IRuleNode) this);
    }
  }

  public class WildcardExpressionContext(ParserRuleContext parent, int invokingState) : 
    ParserRuleContext(parent, invokingState)
  {
    public FormCalcParser.AccessorContext[] accessor()
    {
      return this.GetRuleContexts<FormCalcParser.AccessorContext>();
    }

    public FormCalcParser.AccessorContext accessor(int i)
    {
      return this.GetRuleContext<FormCalcParser.AccessorContext>(i);
    }

    public virtual int RuleIndex => 30;

    public virtual void EnterRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.EnterWildcardExpression(this);
    }

    public virtual void ExitRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.ExitWildcardExpression(this);
    }

    public virtual TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
    {
      return visitor is IFormCalcVisitor<TResult> formCalcVisitor ? formCalcVisitor.VisitWildcardExpression(this) : visitor.VisitChildren((IRuleNode) this);
    }
  }

  public class AssignContext(ParserRuleContext parent, int invokingState) : ParserRuleContext(parent, invokingState)
  {
    public FormCalcParser.ExpressionContext expression()
    {
      return this.GetRuleContext<FormCalcParser.ExpressionContext>(0);
    }

    public FormCalcParser.AccessorContext accessor()
    {
      return this.GetRuleContext<FormCalcParser.AccessorContext>(0);
    }

    public FormCalcParser.FuncCallExpressionContext funcCallExpression()
    {
      return this.GetRuleContext<FormCalcParser.FuncCallExpressionContext>(0);
    }

    public virtual int RuleIndex => 31 /*0x1F*/;

    public virtual void EnterRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.EnterAssign(this);
    }

    public virtual void ExitRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.ExitAssign(this);
    }

    public virtual TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
    {
      return visitor is IFormCalcVisitor<TResult> formCalcVisitor ? formCalcVisitor.VisitAssign(this) : visitor.VisitChildren((IRuleNode) this);
    }
  }

  public class NullEqualityExpressionContext(ParserRuleContext parent, int invokingState) : 
    ParserRuleContext(parent, invokingState)
  {
    public FormCalcParser.EqualityOperatorsContext equalityOperators()
    {
      return this.GetRuleContext<FormCalcParser.EqualityOperatorsContext>(0);
    }

    public FormCalcParser.AccessorContext accessor()
    {
      return this.GetRuleContext<FormCalcParser.AccessorContext>(0);
    }

    public FormCalcParser.FuncCallExpressionContext funcCallExpression()
    {
      return this.GetRuleContext<FormCalcParser.FuncCallExpressionContext>(0);
    }

    public virtual int RuleIndex => 32 /*0x20*/;

    public virtual void EnterRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.EnterNullEqualityExpression(this);
    }

    public virtual void ExitRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.ExitNullEqualityExpression(this);
    }

    public virtual TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
    {
      return visitor is IFormCalcVisitor<TResult> formCalcVisitor ? formCalcVisitor.VisitNullEqualityExpression(this) : visitor.VisitChildren((IRuleNode) this);
    }
  }

  public class ExpressionContext(ParserRuleContext parent, int invokingState) : ParserRuleContext(parent, invokingState)
  {
    public FormCalcParser.FuncCallExpressionContext funcCallExpression()
    {
      return this.GetRuleContext<FormCalcParser.FuncCallExpressionContext>(0);
    }

    public FormCalcParser.NullEqualityExpressionContext nullEqualityExpression()
    {
      return this.GetRuleContext<FormCalcParser.NullEqualityExpressionContext>(0);
    }

    public FormCalcParser.VariableDeclaratorContext variableDeclarator()
    {
      return this.GetRuleContext<FormCalcParser.VariableDeclaratorContext>(0);
    }

    public FormCalcParser.ExpressionContext[] expression()
    {
      return this.GetRuleContexts<FormCalcParser.ExpressionContext>();
    }

    public FormCalcParser.ExpressionContext expression(int i)
    {
      return this.GetRuleContext<FormCalcParser.ExpressionContext>(i);
    }

    public FormCalcParser.NumericOperatorsContext numericOperators()
    {
      return this.GetRuleContext<FormCalcParser.NumericOperatorsContext>(0);
    }

    public FormCalcParser.VariableAssignContext variableAssign()
    {
      return this.GetRuleContext<FormCalcParser.VariableAssignContext>(0);
    }

    public FormCalcParser.AccessorContext accessor()
    {
      return this.GetRuleContext<FormCalcParser.AccessorContext>(0);
    }

    public FormCalcParser.AssignContext assign()
    {
      return this.GetRuleContext<FormCalcParser.AssignContext>(0);
    }

    public FormCalcParser.ParExpressionContext parExpression()
    {
      return this.GetRuleContext<FormCalcParser.ParExpressionContext>(0);
    }

    public FormCalcParser.WildcardExpressionContext wildcardExpression()
    {
      return this.GetRuleContext<FormCalcParser.WildcardExpressionContext>(0);
    }

    public FormCalcParser.RelationalOperatorsContext relationalOperators()
    {
      return this.GetRuleContext<FormCalcParser.RelationalOperatorsContext>(0);
    }

    public FormCalcParser.EqualityOperatorsContext equalityOperators()
    {
      return this.GetRuleContext<FormCalcParser.EqualityOperatorsContext>(0);
    }

    public FormCalcParser.AndOperatorsContext andOperators()
    {
      return this.GetRuleContext<FormCalcParser.AndOperatorsContext>(0);
    }

    public FormCalcParser.OrOperatorsContext orOperators()
    {
      return this.GetRuleContext<FormCalcParser.OrOperatorsContext>(0);
    }

    public virtual int RuleIndex => 33;

    public virtual void EnterRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.EnterExpression(this);
    }

    public virtual void ExitRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.ExitExpression(this);
    }

    public virtual TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
    {
      return visitor is IFormCalcVisitor<TResult> formCalcVisitor ? formCalcVisitor.VisitExpression(this) : visitor.VisitChildren((IRuleNode) this);
    }
  }

  public class PrimaryContext(ParserRuleContext parent, int invokingState) : ParserRuleContext(parent, invokingState)
  {
    public FormCalcParser.LiteralContext literal()
    {
      return this.GetRuleContext<FormCalcParser.LiteralContext>(0);
    }

    public ITerminalNode Identifier() => this.GetToken(69, 0);

    public virtual int RuleIndex => 34;

    public virtual void EnterRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.EnterPrimary(this);
    }

    public virtual void ExitRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.ExitPrimary(this);
    }

    public virtual TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
    {
      return visitor is IFormCalcVisitor<TResult> formCalcVisitor ? formCalcVisitor.VisitPrimary(this) : visitor.VisitChildren((IRuleNode) this);
    }
  }

  public class OrOperatorsContext(ParserRuleContext parent, int invokingState) : ParserRuleContext(parent, invokingState)
  {
    public virtual int RuleIndex => 35;

    public virtual void EnterRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.EnterOrOperators(this);
    }

    public virtual void ExitRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.ExitOrOperators(this);
    }

    public virtual TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
    {
      return visitor is IFormCalcVisitor<TResult> formCalcVisitor ? formCalcVisitor.VisitOrOperators(this) : visitor.VisitChildren((IRuleNode) this);
    }
  }

  public class AndOperatorsContext(ParserRuleContext parent, int invokingState) : ParserRuleContext(parent, invokingState)
  {
    public virtual int RuleIndex => 36;

    public virtual void EnterRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.EnterAndOperators(this);
    }

    public virtual void ExitRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.ExitAndOperators(this);
    }

    public virtual TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
    {
      return visitor is IFormCalcVisitor<TResult> formCalcVisitor ? formCalcVisitor.VisitAndOperators(this) : visitor.VisitChildren((IRuleNode) this);
    }
  }

  public class EqualityOperatorsContext(ParserRuleContext parent, int invokingState) : 
    ParserRuleContext(parent, invokingState)
  {
    public virtual int RuleIndex => 37;

    public virtual void EnterRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.EnterEqualityOperators(this);
    }

    public virtual void ExitRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.ExitEqualityOperators(this);
    }

    public virtual TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
    {
      return visitor is IFormCalcVisitor<TResult> formCalcVisitor ? formCalcVisitor.VisitEqualityOperators(this) : visitor.VisitChildren((IRuleNode) this);
    }
  }

  public class RelationalOperatorsContext(ParserRuleContext parent, int invokingState) : 
    ParserRuleContext(parent, invokingState)
  {
    public virtual int RuleIndex => 38;

    public virtual void EnterRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.EnterRelationalOperators(this);
    }

    public virtual void ExitRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.ExitRelationalOperators(this);
    }

    public virtual TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
    {
      return visitor is IFormCalcVisitor<TResult> formCalcVisitor ? formCalcVisitor.VisitRelationalOperators(this) : visitor.VisitChildren((IRuleNode) this);
    }
  }

  public class NumericOperatorsContext(ParserRuleContext parent, int invokingState) : 
    ParserRuleContext(parent, invokingState)
  {
    public virtual int RuleIndex => 39;

    public virtual void EnterRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.EnterNumericOperators(this);
    }

    public virtual void ExitRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.ExitNumericOperators(this);
    }

    public virtual TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
    {
      return visitor is IFormCalcVisitor<TResult> formCalcVisitor ? formCalcVisitor.VisitNumericOperators(this) : visitor.VisitChildren((IRuleNode) this);
    }
  }

  public class ArgumentsContext(ParserRuleContext parent, int invokingState) : ParserRuleContext(parent, invokingState)
  {
    public FormCalcParser.ExpressionListContext expressionList()
    {
      return this.GetRuleContext<FormCalcParser.ExpressionListContext>(0);
    }

    public virtual int RuleIndex => 40;

    public virtual void EnterRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.EnterArguments(this);
    }

    public virtual void ExitRule(IParseTreeListener listener)
    {
      if (!(listener is IFormCalcListener formCalcListener))
        return;
      formCalcListener.ExitArguments(this);
    }

    public virtual TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor)
    {
      return visitor is IFormCalcVisitor<TResult> formCalcVisitor ? formCalcVisitor.VisitArguments(this) : visitor.VisitChildren((IRuleNode) this);
    }
  }
}
