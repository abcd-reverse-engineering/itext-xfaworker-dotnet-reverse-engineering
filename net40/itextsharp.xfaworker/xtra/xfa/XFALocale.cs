// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.XFALocale
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using System;
using System.Collections.Generic;
using System.Globalization;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa;

public class XFALocale
{
  private DateTimeFormatInfo dateFormatInfo;
  private NumberFormatInfo numberFormatInfo;
  private IDictionary<string, string> datePattern = (IDictionary<string, string>) new Dictionary<string, string>();
  private IDictionary<string, string> timePattern = (IDictionary<string, string>) new Dictionary<string, string>();
  private IDictionary<string, string> numberPattern = (IDictionary<string, string>) new Dictionary<string, string>();
  private string name;
  private CultureInfo locale;

  public XFALocale(string name, CultureInfo defaultLocale)
  {
    this.name = name;
    this.locale = (CultureInfo) null;
    if (name != null && !"ambient".Equals(name) && name.Contains("_"))
    {
      string str1 = name.Substring(0, name.IndexOf('_'));
      string str2 = name.Substring(name.IndexOf('_') + 1);
      try
      {
        this.locale = new CultureInfo($"{str1}-{str2}");
      }
      catch (Exception ex)
      {
        this.locale = (CultureInfo) null;
      }
    }
    if (this.locale == null)
      this.locale = (CultureInfo) defaultLocale.Clone();
    this.dateFormatInfo = this.locale.DateTimeFormat;
    this.numberFormatInfo = this.locale.NumberFormat;
    this.datePattern["full"] = "EEEE D MMMM YYYY";
    this.datePattern["long"] = "D MMMM YYYY";
    this.datePattern["med"] = "D MMM YYYY";
    this.datePattern["short"] = "DD/MM/YY";
    this.timePattern["full"] = "h:MM:SS A Z";
    this.timePattern["long"] = "h:MM:SS A Z";
    this.timePattern["med"] = "h:MM:SS A";
    this.timePattern["short"] = "h:MM A";
    this.numberPattern["numeric"] = "z,zz9.zzz";
  }

  public virtual DateTimeFormatInfo DateFormatInfo => this.dateFormatInfo;

  public virtual NumberFormatInfo NumberFormatInfo => this.numberFormatInfo;

  public virtual IDictionary<string, string> DatePattern => this.datePattern;

  public virtual IDictionary<string, string> TimePattern => this.timePattern;

  public virtual IDictionary<string, string> NumberPattern => this.numberPattern;

  public virtual string Name => this.name;

  public virtual CultureInfo Locale => this.locale;
}
