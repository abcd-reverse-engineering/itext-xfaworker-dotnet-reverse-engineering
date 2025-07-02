// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsBoolean
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using System;

#nullable disable
namespace Jint.Native;

[Serializable]
public sealed class JsBoolean : JsObject, ILiteral
{
  private bool value;

  public override object Value => (object) this.value;

  public JsBoolean(JsObject prototype)
    : this(false, prototype)
  {
    this.value = false;
  }

  public JsBoolean(bool boolean, JsObject prototype)
    : base(prototype)
  {
    this.value = boolean;
  }

  public override bool IsClr => false;

  public override string Type => "boolean";

  public override string Class => "Boolean";

  public override bool ToBoolean() => this.value;

  public override string ToString() => !this.value ? "false" : "true";

  public static double BooleanToNumber(bool value) => value ? 1.0 : 0.0;

  public override double ToNumber() => JsBoolean.BooleanToNumber(this.value);
}
