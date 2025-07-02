// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsNumber
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using System;
using System.Globalization;

#nullable disable
namespace Jint.Native;

[Serializable]
public sealed class JsNumber : JsObject, ILiteral
{
  private double value;

  public override object Value => (object) this.value;

  public JsNumber(JsObject prototype)
    : this(0.0, prototype)
  {
  }

  public JsNumber(double num, JsObject prototype)
    : base(prototype)
  {
    this.value = num;
  }

  public JsNumber(int num, JsObject prototype)
    : base(prototype)
  {
    this.value = (double) num;
  }

  public override bool IsClr => false;

  public static bool NumberToBoolean(double value) => value != 0.0;

  public override bool ToBoolean() => JsNumber.NumberToBoolean(this.value);

  public override double ToNumber() => this.value;

  public override string ToString()
  {
    return this.value.ToString((IFormatProvider) CultureInfo.InvariantCulture).ToLower();
  }

  public override object ToObject() => (object) this.value;

  public override bool Equals(object obj)
  {
    return obj is JsNumber && (obj as JsNumber).value == this.value;
  }

  public override string Class => "Number";

  public override string Type => "number";
}
