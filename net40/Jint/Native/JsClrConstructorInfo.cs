// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsClrConstructorInfo
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using System;
using System.Reflection;

#nullable disable
namespace Jint.Native;

[Serializable]
public class JsClrConstructorInfo : JsObject
{
  public const string TYPEOF = "clrMethodInfo";
  private ConstructorInfo value;

  public JsClrConstructorInfo() => this.value = (ConstructorInfo) null;

  public JsClrConstructorInfo(ConstructorInfo clr) => this.value = clr;

  public override bool ToBoolean() => false;

  public override double ToNumber() => 0.0;

  public override string ToString() => this.value.Name;

  public override string Class => "clrMethodInfo";

  public override object Value => (object) this.value;
}
