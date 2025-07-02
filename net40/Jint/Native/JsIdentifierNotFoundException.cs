// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsIdentifierNotFoundException
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using System;
using System.Runtime.Serialization;

#nullable disable
namespace Jint.Native;

[Serializable]
public class JsIdentifierNotFoundException : JsException
{
  public JsIdentifierNotFoundException()
  {
  }

  public JsIdentifierNotFoundException(JsInstance value)
    : base(value)
  {
  }

  protected JsIdentifierNotFoundException(SerializationInfo info, StreamingContext context)
    : base(info, context)
  {
  }
}
