// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsConstructor
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using System;

#nullable disable
namespace Jint.Native;

[Serializable]
public abstract class JsConstructor : JsFunction
{
  public IGlobal Global { get; set; }

  public JsConstructor(IGlobal global)
    : base(global)
  {
    this.Global = global;
  }

  protected JsConstructor(IGlobal global, JsObject prototype)
    : base(prototype)
  {
    this.Global = global;
  }

  public abstract void InitPrototype(IGlobal global);

  public virtual JsInstance Wrap<T>(T value)
  {
    return (JsInstance) new JsObject((object) value, this.PrototypeProperty);
  }

  public override string GetBody() => "[native ctor]";
}
