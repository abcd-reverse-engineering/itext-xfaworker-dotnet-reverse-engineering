// Decompiled with JetBrains decompiler
// Type: Jint.Native.NativeGenericType
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using System;

#nullable disable
namespace Jint.Native;

internal class NativeGenericType : JsObject
{
  private System.Type m_reflectedType;

  public NativeGenericType(System.Type reflectedType, JsObject prototype)
    : base(prototype)
  {
    if (reflectedType == (System.Type) null)
      throw new ArgumentNullException(nameof (reflectedType));
  }

  public override object Value
  {
    get => (object) this.m_reflectedType;
    set => this.m_reflectedType = (System.Type) value;
  }

  private JsConstructor MakeType(System.Type[] args, IGlobal global)
  {
    return global.Marshaller.MarshalType(this.m_reflectedType.MakeGenericType(args));
  }
}
