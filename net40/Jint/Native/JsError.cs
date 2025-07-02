// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsError
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using System;

#nullable disable
namespace Jint.Native;

[Serializable]
public class JsError : JsObject
{
  private IGlobal global;

  private string message
  {
    get => this[nameof (message)].ToString();
    set => this[nameof (message)] = (JsInstance) this.global.StringClass.New(value);
  }

  public override bool IsClr => false;

  public override object Value => (object) this.message;

  public JsError(IGlobal global)
    : this(global, string.Empty)
  {
  }

  public JsError(IGlobal global, string message)
    : base(global.ErrorClass.PrototypeProperty)
  {
    this.global = global;
    this.message = message;
  }

  public override string Class => "Error";

  public override string ToString() => this.Value.ToString();
}
