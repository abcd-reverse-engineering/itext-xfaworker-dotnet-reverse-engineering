// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsRegExp
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using System;
using System.Text.RegularExpressions;

#nullable disable
namespace Jint.Native;

[Serializable]
public class JsRegExp : JsObject
{
  private string pattern;
  private RegexOptions options;

  public bool IsGlobal => this["global"].ToBoolean();

  public bool IsIgnoreCase => (this.options & RegexOptions.IgnoreCase) == RegexOptions.IgnoreCase;

  public bool IsMultiline => (this.options & RegexOptions.Multiline) == RegexOptions.Multiline;

  public JsRegExp(JsObject prototype)
    : base(prototype)
  {
  }

  public JsRegExp(string pattern, JsObject prototype)
    : this(pattern, false, false, false, prototype)
  {
  }

  public JsRegExp(string pattern, bool g, bool i, bool m, JsObject prototype)
    : base(prototype)
  {
    this.options = RegexOptions.ECMAScript;
    if (m)
      this.options |= RegexOptions.Multiline;
    if (i)
      this.options |= RegexOptions.IgnoreCase;
    this.pattern = pattern;
  }

  public string Pattern => this.pattern;

  public Regex Regex => new Regex(this.pattern, this.options);

  public RegexOptions Options => this.options;

  public override bool IsClr => false;

  public override object Value => (object) null;

  public override string ToSource() => $"/{this.pattern.ToString()}/";

  public override string ToString()
  {
    return $"/{this.pattern.ToString()}/{(this.IsGlobal ? "g" : string.Empty)}{(this.IsIgnoreCase ? "i" : string.Empty)}{(this.IsMultiline ? "m" : string.Empty)}";
  }

  public override string Class => "RegExp";
}
