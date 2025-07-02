// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsGlobal
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using Jint.Delegates;
using Jint.Expressions;
using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

#nullable disable
namespace Jint.Native;

[Serializable]
public class JsGlobal : JsObject, IGlobal
{
  private static char[] reservedEncoded = new char[11]
  {
    ';',
    ',',
    '/',
    '?',
    ':',
    '@',
    '&',
    '=',
    '+',
    '$',
    '#'
  };
  private static char[] reservedEncodedComponent = new char[11]
  {
    '-',
    '_',
    '.',
    '!',
    '~',
    '*',
    '\'',
    '(',
    ')',
    '[',
    ']'
  };

  public IJintVisitor Visitor { get; set; }

  public Options Options { get; set; }

  public JsGlobal(ExecutionVisitor visitor, Options options)
    : base((JsObject) JsNull.Instance)
  {
    this.Options = options;
    this.Visitor = (IJintVisitor) visitor;
    this["null"] = (JsInstance) JsNull.Instance;
    JsObject jsObject = new JsObject((JsObject) JsNull.Instance);
    JsFunction prototype = (JsFunction) new JsFunctionWrapper((JintFunc<JsInstance[], JsInstance>) (arguments => (JsInstance) JsUndefined.Instance), jsObject);
    this["Function"] = (JsInstance) (this.FunctionClass = new JsFunctionConstructor((IGlobal) this, (JsObject) prototype));
    this["Object"] = (JsInstance) (this.ObjectClass = new JsObjectConstructor((IGlobal) this, (JsObject) prototype, jsObject));
    this.ObjectClass.InitPrototype((IGlobal) this);
    this["Array"] = (JsInstance) (this.ArrayClass = new JsArrayConstructor((IGlobal) this));
    this["Boolean"] = (JsInstance) (this.BooleanClass = new JsBooleanConstructor((IGlobal) this));
    this["Date"] = (JsInstance) (this.DateClass = new JsDateConstructor((IGlobal) this));
    this["Error"] = (JsInstance) (this.ErrorClass = new JsErrorConstructor((IGlobal) this, "Error"));
    this["EvalError"] = (JsInstance) (this.EvalErrorClass = new JsErrorConstructor((IGlobal) this, "EvalError"));
    this["RangeError"] = (JsInstance) (this.RangeErrorClass = new JsErrorConstructor((IGlobal) this, "RangeError"));
    this["ReferenceError"] = (JsInstance) (this.ReferenceErrorClass = new JsErrorConstructor((IGlobal) this, "ReferenceError"));
    this["SyntaxError"] = (JsInstance) (this.SyntaxErrorClass = new JsErrorConstructor((IGlobal) this, "SyntaxError"));
    this["TypeError"] = (JsInstance) (this.TypeErrorClass = new JsErrorConstructor((IGlobal) this, "TypeError"));
    this["URIError"] = (JsInstance) (this.URIErrorClass = new JsErrorConstructor((IGlobal) this, "URIError"));
    this["Number"] = (JsInstance) (this.NumberClass = new JsNumberConstructor((IGlobal) this));
    this["RegExp"] = (JsInstance) (this.RegExpClass = new JsRegExpConstructor((IGlobal) this));
    this["String"] = (JsInstance) (this.StringClass = new JsStringConstructor((IGlobal) this));
    this["Math"] = (JsInstance) (this.MathClass = new JsMathConstructor((IGlobal) this));
    foreach (JsInstance jsInstance in this.GetValues())
    {
      if (jsInstance is JsConstructor)
        ((JsConstructor) jsInstance).InitPrototype((IGlobal) this);
    }
    this[nameof (NaN)] = this.NumberClass[nameof (NaN)];
    this["Infinity"] = this.NumberClass["POSITIVE_INFINITY"];
    this["undefined"] = (JsInstance) JsUndefined.Instance;
    this[JsScope.THIS] = (JsInstance) this;
    this["eval"] = (JsInstance) new JsFunctionWrapper(new JintFunc<JsInstance[], JsInstance>(this.Eval), this.FunctionClass.PrototypeProperty);
    this["escape"] = (JsInstance) new JsFunctionWrapper(new JintFunc<JsInstance[], JsInstance>(this.Escape), this.FunctionClass.PrototypeProperty);
    this["unescape"] = (JsInstance) new JsFunctionWrapper(new JintFunc<JsInstance[], JsInstance>(this.Unescape), this.FunctionClass.PrototypeProperty);
    this["parseInt"] = (JsInstance) new JsFunctionWrapper(new JintFunc<JsInstance[], JsInstance>(this.ParseInt), this.FunctionClass.PrototypeProperty);
    this["parseFloat"] = (JsInstance) new JsFunctionWrapper(new JintFunc<JsInstance[], JsInstance>(this.ParseFloat), this.FunctionClass.PrototypeProperty);
    this["isNaN"] = (JsInstance) new JsFunctionWrapper(new JintFunc<JsInstance[], JsInstance>(this.IsNaN), this.FunctionClass.PrototypeProperty);
    this["isFinite"] = (JsInstance) new JsFunctionWrapper(new JintFunc<JsInstance[], JsInstance>(this.isFinite), this.FunctionClass.PrototypeProperty);
    this["decodeURI"] = (JsInstance) new JsFunctionWrapper(new JintFunc<JsInstance[], JsInstance>(this.DecodeURI), this.FunctionClass.PrototypeProperty);
    this["encodeURI"] = (JsInstance) new JsFunctionWrapper(new JintFunc<JsInstance[], JsInstance>(this.EncodeURI), this.FunctionClass.PrototypeProperty);
    this["decodeURIComponent"] = (JsInstance) new JsFunctionWrapper(new JintFunc<JsInstance[], JsInstance>(this.DecodeURIComponent), this.FunctionClass.PrototypeProperty);
    this["encodeURIComponent"] = (JsInstance) new JsFunctionWrapper(new JintFunc<JsInstance[], JsInstance>(this.EncodeURIComponent), this.FunctionClass.PrototypeProperty);
    this.Marshaller = new Marshaller((IGlobal) this);
    this.Marshaller.InitTypes();
  }

  public override string Class => "Global";

  public JsObjectConstructor ObjectClass { get; private set; }

  public JsFunctionConstructor FunctionClass { get; private set; }

  public JsArrayConstructor ArrayClass { get; private set; }

  public JsBooleanConstructor BooleanClass { get; private set; }

  public JsDateConstructor DateClass { get; private set; }

  public JsErrorConstructor ErrorClass { get; private set; }

  public JsErrorConstructor EvalErrorClass { get; private set; }

  public JsErrorConstructor RangeErrorClass { get; private set; }

  public JsErrorConstructor ReferenceErrorClass { get; private set; }

  public JsErrorConstructor SyntaxErrorClass { get; private set; }

  public JsErrorConstructor TypeErrorClass { get; private set; }

  public JsErrorConstructor URIErrorClass { get; private set; }

  public JsMathConstructor MathClass { get; private set; }

  public JsNumberConstructor NumberClass { get; private set; }

  public JsRegExpConstructor RegExpClass { get; private set; }

  public JsStringConstructor StringClass { get; private set; }

  public Marshaller Marshaller { get; private set; }

  public JsInstance Escape(JsInstance[] arguments)
  {
    if (arguments.Length < 1 || arguments[0] == JsUndefined.Instance)
      return (JsInstance) this.StringClass.New();
    string str = arguments[0].ToString();
    int num1 = 7;
    if (arguments.Length > 1)
    {
      double number = arguments[1].ToNumber();
      if (number != number || (double) (num1 = (int) number) != number || (num1 & -8) != 0)
        throw new JintException("msg.bad.esc.mask");
    }
    StringBuilder stringBuilder = (StringBuilder) null;
    int index1 = 0;
    for (int length = str.Length; index1 != length; ++index1)
    {
      int num2 = (int) str[index1];
      if (num1 != 0 && (num2 >= 48 /*0x30*/ && num2 <= 57 || num2 >= 65 && num2 <= 90 || num2 >= 97 && num2 <= 122 || num2 == 64 /*0x40*/ || num2 == 42 || num2 == 95 || num2 == 45 || num2 == 46 || (num1 & 4) != 0 && (num2 == 47 || num2 == 43)))
      {
        stringBuilder?.Append((char) num2);
      }
      else
      {
        if (stringBuilder == null)
        {
          stringBuilder = new StringBuilder(length + 3);
          stringBuilder.Append(str);
          stringBuilder.Length = index1;
        }
        int num3;
        if (num2 < 256 /*0x0100*/)
        {
          if (num2 == 32 /*0x20*/ && num1 == 2)
          {
            stringBuilder.Append('+');
            continue;
          }
          stringBuilder.Append('%');
          num3 = 2;
        }
        else
        {
          stringBuilder.Append('%');
          stringBuilder.Append('u');
          num3 = 4;
        }
        for (int index2 = (num3 - 1) * 4; index2 >= 0; index2 -= 4)
        {
          int num4 = 15 & num2 >> index2;
          int num5 = num4 < 10 ? 48 /*0x30*/ + num4 : 55 + num4;
          stringBuilder.Append((char) num5);
        }
      }
    }
    return (JsInstance) this.StringClass.New(stringBuilder == null ? str : stringBuilder.ToString());
  }

  public JsInstance Unescape(JsInstance[] arguments)
  {
    string str = arguments[0].ToString();
    int num1 = str.IndexOf('%');
    if (num1 >= 0)
    {
      int length1 = str.Length;
      char[] charArray = str.ToCharArray();
      int length2 = num1;
      int index1 = num1;
      while (index1 != length1)
      {
        char ch = charArray[index1];
        ++index1;
        if (ch == '%' && index1 != length1)
        {
          int num2;
          int num3;
          if (charArray[index1] == 'u')
          {
            num2 = index1 + 1;
            num3 = index1 + 5;
          }
          else
          {
            num2 = index1;
            num3 = index1 + 2;
          }
          if (num3 <= length1)
          {
            int accumulator = 0;
            for (int index2 = num2; index2 != num3; ++index2)
              accumulator = this.XDigitToInt((int) charArray[index2], accumulator);
            if (accumulator >= 0)
            {
              ch = (char) accumulator;
              index1 = num3;
            }
          }
        }
        charArray[length2] = ch;
        ++length2;
      }
      str = new string(charArray, 0, length2);
    }
    return (JsInstance) this.StringClass.New(str);
  }

  private int XDigitToInt(int c, int accumulator)
  {
    bool flag = false;
    if (c <= 57)
    {
      c -= 48 /*0x30*/;
      if (0 <= c)
        flag = true;
    }
    else if (c <= 70)
    {
      if (65 <= c)
      {
        c -= 55;
        flag = true;
      }
    }
    else if (c <= 102 && 97 <= c)
    {
      c -= 87;
      flag = true;
    }
    return flag ? accumulator << 4 | c : -1;
  }

  public JsInstance Eval(JsInstance[] arguments)
  {
    if ("String" != arguments[0].Class)
      return arguments[0];
    Program program;
    try
    {
      program = JintEngine.Compile(arguments[0].ToString(), this.Visitor.DebugMode);
    }
    catch (Exception ex)
    {
      throw new JsException((JsInstance) this.SyntaxErrorClass.New(ex.Message));
    }
    try
    {
      program.Accept((IStatementVisitor) this.Visitor);
    }
    catch (Exception ex)
    {
      throw new JsException((JsInstance) this.EvalErrorClass.New(ex.Message));
    }
    return this.Visitor.Result;
  }

  public JsInstance ParseInt(JsInstance[] arguments)
  {
    if (arguments.Length < 1 || arguments[0] == JsUndefined.Instance)
      return (JsInstance) JsUndefined.Instance;
    if (arguments[0].IsClr && arguments[0].Value.GetType().IsEnum)
      return (JsInstance) this.NumberClass.New((double) (int) arguments[0].Value);
    string s = arguments[0].ToString().Trim();
    int num = 1;
    int fromBase = 10;
    if (s == string.Empty)
      return this["NaN"];
    if (s.StartsWith("-"))
    {
      s = s.Substring(1);
      num = -1;
    }
    else if (s.StartsWith("+"))
      s = s.Substring(1);
    if (arguments.Length >= 2 && arguments[1] != JsUndefined.Instance && !0.Equals((object) arguments[1]))
      fromBase = Convert.ToInt32(arguments[1].Value);
    if (fromBase == 0)
      fromBase = 10;
    else if (fromBase < 2 || fromBase > 36)
      return this["NaN"];
    if (s.ToLower().StartsWith("0x"))
      fromBase = 16 /*0x10*/;
    try
    {
      if (fromBase != 10)
        return (JsInstance) this.NumberClass.New((double) (num * Convert.ToInt32(s, fromBase)));
      double result;
      return double.TryParse(s, NumberStyles.Any, (IFormatProvider) CultureInfo.InvariantCulture, out result) ? (JsInstance) this.NumberClass.New((double) num * Math.Floor(result)) : this["NaN"];
    }
    catch
    {
      return this["NaN"];
    }
  }

  public JsInstance ParseFloat(JsInstance[] arguments)
  {
    if (arguments.Length < 1 || arguments[0] == JsUndefined.Instance)
      return (JsInstance) JsUndefined.Instance;
    Match match = new Regex("^[\\+\\-\\d\\.e]*", RegexOptions.IgnoreCase).Match(arguments[0].ToString().Trim());
    double result;
    return match.Success && double.TryParse(match.Value, NumberStyles.Float, (IFormatProvider) new CultureInfo("en-US"), out result) ? (JsInstance) this.NumberClass.New(result) : this["NaN"];
  }

  public JsInstance IsNaN(JsInstance[] arguments)
  {
    return arguments.Length < 1 || arguments[0] == JsUndefined.Instance ? (JsInstance) this.BooleanClass.New(false) : (JsInstance) this.BooleanClass.New(double.NaN.Equals(arguments[0].ToNumber()));
  }

  protected JsInstance isFinite(JsInstance[] arguments)
  {
    if (arguments.Length < 1 || arguments[0] == JsUndefined.Instance)
      return (JsInstance) this.BooleanClass.False;
    JsInstance jsInstance = arguments[0];
    return (JsInstance) this.BooleanClass.New(jsInstance != this.NumberClass["NaN"] && jsInstance != this.NumberClass["POSITIVE_INFINITY"] && jsInstance != this.NumberClass["NEGATIVE_INFINITY"]);
  }

  protected JsInstance DecodeURI(JsInstance[] arguments)
  {
    return arguments.Length < 1 || arguments[0] == JsUndefined.Instance ? (JsInstance) this.StringClass.New() : (JsInstance) this.StringClass.New(Uri.UnescapeDataString(arguments[0].ToString().Replace("+", " ")));
  }

  protected JsInstance EncodeURI(JsInstance[] arguments)
  {
    if (arguments.Length < 1 || arguments[0] == JsUndefined.Instance)
      return (JsInstance) this.StringClass.New();
    string str = Uri.EscapeDataString(arguments[0].ToString());
    foreach (char ch in JsGlobal.reservedEncoded)
      str = str.Replace(Uri.EscapeDataString(ch.ToString()), ch.ToString());
    foreach (char ch in JsGlobal.reservedEncodedComponent)
      str = str.Replace(Uri.EscapeDataString(ch.ToString()), ch.ToString());
    return (JsInstance) this.StringClass.New(str.ToUpper());
  }

  protected JsInstance DecodeURIComponent(JsInstance[] arguments)
  {
    return arguments.Length < 1 || arguments[0] == JsUndefined.Instance ? (JsInstance) this.StringClass.New() : (JsInstance) this.StringClass.New(Uri.UnescapeDataString(arguments[0].ToString().Replace("+", " ")));
  }

  protected JsInstance EncodeURIComponent(JsInstance[] arguments)
  {
    if (arguments.Length < 1 || arguments[0] == JsUndefined.Instance)
      return (JsInstance) this.StringClass.New();
    string str = Uri.EscapeDataString(arguments[0].ToString());
    foreach (char ch in JsGlobal.reservedEncodedComponent)
      str = str.Replace(Uri.EscapeDataString(ch.ToString()), ch.ToString().ToUpper());
    return (JsInstance) this.StringClass.New(str);
  }

  [Obsolete]
  public JsObject Wrap(object value)
  {
    switch (Convert.GetTypeCode(value))
    {
      case TypeCode.Object:
        return this.ObjectClass.New(value);
      case TypeCode.Boolean:
        return (JsObject) this.BooleanClass.New((bool) value);
      case TypeCode.Char:
      case TypeCode.String:
        return (JsObject) this.StringClass.New(Convert.ToString(value));
      case TypeCode.SByte:
      case TypeCode.Byte:
      case TypeCode.Int16:
      case TypeCode.UInt16:
      case TypeCode.Int32:
      case TypeCode.UInt32:
      case TypeCode.Int64:
      case TypeCode.UInt64:
      case TypeCode.Single:
      case TypeCode.Double:
      case TypeCode.Decimal:
        return (JsObject) this.NumberClass.New(Convert.ToDouble(value));
      case TypeCode.DateTime:
        return (JsObject) this.DateClass.New((DateTime) value);
      default:
        throw new ArgumentNullException(nameof (value));
    }
  }

  public JsObject WrapClr(object value)
  {
    return (JsObject) this.Marshaller.MarshalClrValue<object>(value);
  }

  public bool HasOption(Options options) => (this.Options & options) == options;

  public JsInstance NaN => this[nameof (NaN)];
}
