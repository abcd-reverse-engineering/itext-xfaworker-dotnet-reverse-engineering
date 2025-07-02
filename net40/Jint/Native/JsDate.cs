// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsDate
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using System;
using System.Globalization;

#nullable disable
namespace Jint.Native;

[Serializable]
public sealed class JsDate : JsObject
{
  internal static long OFFSET_1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Ticks;
  internal static int TICKSFACTOR = 10000;
  private DateTime value;
  public static string FORMAT = "ddd, dd MMM yyyy HH':'mm':'ss 'GMT'zzz";
  public static string FORMATUTC = "ddd, dd MMM yyyy HH':'mm':'ss 'UTC'";
  public static string DATEFORMAT = "ddd, dd MMM yyyy";
  public static string TIMEFORMAT = "HH':'mm':'ss 'GMT'zzz";

  public override object Value
  {
    get => (object) this.value;
    set
    {
      switch (value)
      {
        case DateTime dateTime:
          this.value = dateTime;
          break;
        case double number:
          this.value = JsDateConstructor.CreateDateTime(number);
          break;
      }
    }
  }

  public JsDate(JsObject prototype)
    : base(prototype)
  {
    this.value = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
  }

  public JsDate(DateTime date, JsObject prototype)
    : base(prototype)
  {
    this.value = date;
  }

  public JsDate(double value, JsObject prototype)
    : this(JsDateConstructor.CreateDateTime(value), prototype)
  {
  }

  public override bool IsClr => false;

  public override double ToNumber() => JsDate.DateToDouble(this.value);

  public static double DateToDouble(DateTime date)
  {
    return (double) ((date.ToUniversalTime().Ticks - JsDate.OFFSET_1970) / (long) JsDate.TICKSFACTOR);
  }

  public override string ToString()
  {
    return this.value.ToLocalTime().ToString(JsDate.FORMAT, (IFormatProvider) CultureInfo.InvariantCulture);
  }

  public override object ToObject() => (object) this.value;

  public override string Class => "Date";
}
