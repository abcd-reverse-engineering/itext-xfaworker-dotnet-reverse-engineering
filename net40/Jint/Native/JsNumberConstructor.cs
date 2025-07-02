// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsNumberConstructor
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using Jint.Delegates;
using Jint.Expressions;
using System;
using System.Globalization;

#nullable disable
namespace Jint.Native;

[Serializable]
public class JsNumberConstructor : JsConstructor
{
  private static char[] rDigits = new char[36]
  {
    '0',
    '1',
    '2',
    '3',
    '4',
    '5',
    '6',
    '7',
    '8',
    '9',
    'A',
    'B',
    'C',
    'D',
    'E',
    'F',
    'G',
    'H',
    'I',
    'J',
    'K',
    'L',
    'M',
    'N',
    'O',
    'P',
    'Q',
    'R',
    'S',
    'T',
    'U',
    'V',
    'W',
    'X',
    'Y',
    'Z'
  };

  public JsNumberConstructor(IGlobal global)
    : base(global)
  {
    this.Name = "Number";
    this.DefineOwnProperty(JsFunction.PROTOTYPE, (JsInstance) global.ObjectClass.New((JsFunction) this), PropertyAttributes.ReadOnly | PropertyAttributes.DontEnum | PropertyAttributes.DontDelete);
    this.DefineOwnProperty("MAX_VALUE", (JsInstance) this.New(double.MaxValue));
    this.DefineOwnProperty("MIN_VALUE", (JsInstance) this.New(double.MinValue));
    this.DefineOwnProperty("NaN", (JsInstance) this.New(double.NaN));
    this.DefineOwnProperty("NEGATIVE_INFINITY", (JsInstance) this.New(double.NegativeInfinity));
    this.DefineOwnProperty("POSITIVE_INFINITY", (JsInstance) this.New(double.PositiveInfinity));
  }

  public override void InitPrototype(IGlobal global)
  {
    JsObject prototypeProperty = this.PrototypeProperty;
    prototypeProperty.DefineOwnProperty("toString", (JsInstance) global.FunctionClass.New<JsInstance>(new JintFunc<JsInstance, JsInstance[], JsInstance>(this.ToStringImpl), 1), PropertyAttributes.DontEnum);
    prototypeProperty.DefineOwnProperty("toLocaleString", (JsInstance) global.FunctionClass.New<JsInstance>(new JintFunc<JsInstance, JsInstance[], JsInstance>(this.ToLocaleStringImpl)), PropertyAttributes.DontEnum);
    prototypeProperty.DefineOwnProperty("toFixed", (JsInstance) global.FunctionClass.New<JsInstance>(new JintFunc<JsInstance, JsInstance[], JsInstance>(this.ToFixedImpl)), PropertyAttributes.DontEnum);
    prototypeProperty.DefineOwnProperty("toExponential", (JsInstance) global.FunctionClass.New<JsInstance>(new JintFunc<JsInstance, JsInstance[], JsInstance>(this.ToExponentialImpl)), PropertyAttributes.DontEnum);
    prototypeProperty.DefineOwnProperty("toPrecision", (JsInstance) global.FunctionClass.New<JsInstance>(new JintFunc<JsInstance, JsInstance[], JsInstance>(this.ToPrecisionImpl)), PropertyAttributes.DontEnum);
  }

  public JsNumber New(double value) => new JsNumber(value, this.PrototypeProperty);

  public JsNumber New() => this.New(0.0);

  public override JsInstance Execute(
    IJintVisitor visitor,
    JsDictionaryObject that,
    JsInstance[] parameters)
  {
    if (that == null || that as IGlobal == visitor.Global)
      return parameters.Length > 0 ? visitor.Return((JsInstance) this.New(parameters[0].ToNumber())) : visitor.Return((JsInstance) this.New(0.0));
    if (parameters.Length > 0)
      that.Value = (object) parameters[0].ToNumber();
    else
      that.Value = (object) 0;
    return visitor.Return((JsInstance) that);
  }

  public JsInstance ToLocaleStringImpl(JsInstance target, JsInstance[] parameters)
  {
    return this.ToStringImpl(target, new JsInstance[0]);
  }

  public JsInstance ToStringImpl(JsInstance target, JsInstance[] parameters)
  {
    if (target == this["NaN"])
      return (JsInstance) this.Global.StringClass.New("NaN");
    if (target == this["NEGATIVE_INFINITY"])
      return (JsInstance) this.Global.StringClass.New("-Infinity");
    if (target == this["POSITIVE_INFINITY"])
      return (JsInstance) this.Global.StringClass.New("Infinity");
    int num1 = 10;
    if (parameters.Length > 0 && parameters[0] != JsUndefined.Instance)
      num1 = (int) parameters[0].ToNumber();
    long number = (long) target.ToNumber();
    if (num1 == 10)
      return (JsInstance) this.Global.StringClass.New(target.ToNumber().ToString((IFormatProvider) CultureInfo.InvariantCulture).ToLower());
    long num2 = Math.Abs(number);
    char[] chArray = new char[63 /*0x3F*/];
    int length;
    for (length = 0; length <= 64 /*0x40*/ && num2 != 0L; ++length)
    {
      chArray[chArray.Length - length - 1] = JsNumberConstructor.rDigits[num2 % (long) num1];
      num2 /= (long) num1;
    }
    if (number < 0L)
      chArray[chArray.Length - length++ - 1] = '-';
    return (JsInstance) this.Global.StringClass.New(new string(chArray, chArray.Length - length, length).ToLower());
  }

  public JsInstance ToFixedImpl(JsInstance target, JsInstance[] parameters)
  {
    int num = 0;
    if (parameters.Length > 0)
      num = Convert.ToInt32(parameters[0].ToNumber());
    if (num > 20 || num < 0)
      throw new JsException((JsInstance) this.Global.SyntaxErrorClass.New("Fraction Digits must be greater than 0 and lesser than 20"));
    return target == this.Global.NaN ? (JsInstance) this.Global.StringClass.New(target.ToString()) : (JsInstance) this.Global.StringClass.New(target.ToNumber().ToString("f" + (object) num, (IFormatProvider) CultureInfo.InvariantCulture));
  }

  public JsInstance ToExponentialImpl(JsInstance target, JsInstance[] parameters)
  {
    if (double.IsInfinity(target.ToNumber()) || double.IsNaN(target.ToNumber()))
      return this.ToStringImpl(target, new JsInstance[0]);
    int count = 16 /*0x10*/;
    if (parameters.Length > 0)
      count = Convert.ToInt32(parameters[0].ToNumber());
    if (count > 20 || count < 0)
      throw new JsException((JsInstance) this.Global.SyntaxErrorClass.New("Fraction Digits must be greater than 0 and lesser than 20"));
    string format = $"#.{new string('0', count)}e+0";
    return (JsInstance) this.Global.StringClass.New(target.ToNumber().ToString(format, (IFormatProvider) CultureInfo.InvariantCulture));
  }

  public JsInstance ToPrecisionImpl(JsInstance target, JsInstance[] parameters)
  {
    if (double.IsInfinity(target.ToNumber()) || double.IsNaN(target.ToNumber()))
      return this.ToStringImpl(target, new JsInstance[0]);
    if (parameters.Length == 0)
      throw new JsException((JsInstance) this.Global.SyntaxErrorClass.New("precision missing"));
    if (parameters[0] == JsUndefined.Instance)
      return this.ToStringImpl(target, new JsInstance[0]);
    int num1 = 0;
    if (parameters.Length > 0)
      num1 = Convert.ToInt32(parameters[0].ToNumber());
    if (num1 < 1 || num1 > 21)
      throw new JsException((JsInstance) this.Global.RangeErrorClass.New("precision must be between 1 and 21"));
    string str = target.ToNumber().ToString("e23", (IFormatProvider) CultureInfo.InvariantCulture);
    int num2 = str.IndexOfAny(new char[2]{ '.', 'e' });
    int num3 = num2 == -1 ? str.Length : num2;
    int num4 = num1 - num3;
    int num5 = num4 < 1 ? 1 : num4;
    return (JsInstance) this.Global.StringClass.New(target.ToNumber().ToString("f" + (object) num5, (IFormatProvider) CultureInfo.InvariantCulture));
  }
}
