// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsClrMethodInfo
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using System;

#nullable disable
namespace Jint.Native;

[Serializable]
public class JsClrMethodInfo : JsObject
{
  public const string TYPEOF = "clrMethodInfo";
  private string value;

  public JsClrMethodInfo()
  {
  }

  public JsClrMethodInfo(string method) => this.value = method;

  public override bool ToBoolean() => false;

  public override double ToNumber() => 0.0;

  public override string ToString() => string.Empty;

  public override string Class => "clrMethodInfo";

  public override object Value => (object) this.value;
}
