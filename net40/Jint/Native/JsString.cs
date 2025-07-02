// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsString
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using System;
using System.Globalization;

#nullable disable
namespace Jint.Native;

[Serializable]
public sealed class JsString : JsObject, ILiteral
{
  private string value;

  public override object Value => (object) this.value;

  public JsString(JsObject prototype)
    : base(prototype)
  {
    this.value = string.Empty;
  }

  public JsString(string str, JsObject prototype)
    : base(prototype)
  {
    this.value = str;
  }

  public static bool StringToBoolean(string value)
  {
    switch (value)
    {
      case null:
        return false;
      case "true":
        return true;
      default:
        if (value.Length <= 0)
          return false;
        goto case "true";
    }
  }

  public override bool IsClr => false;

  public override bool ToBoolean() => JsString.StringToBoolean(this.value);

  public static double StringToNumber(string value)
  {
    switch (value)
    {
      case null:
        return double.NaN;
      case "":
        return 0.0;
      default:
        double result;
        return double.TryParse(value, NumberStyles.Float, (IFormatProvider) CultureInfo.InvariantCulture, out result) ? result : double.NaN;
    }
  }

  public override double ToNumber() => JsString.StringToNumber(this.value);

  public override string ToSource() => this.value != null ? $"'{this.ToString()}'" : "null";

  public override string ToString() => this.value.ToString();

  public override string Class => "String";

  public override string Type => "string";

  public override int GetHashCode() => this.value.GetHashCode();

  public override bool Equals(object obj)
  {
    return obj is JsString && this.value == ((JsString) obj).value;
  }
}
