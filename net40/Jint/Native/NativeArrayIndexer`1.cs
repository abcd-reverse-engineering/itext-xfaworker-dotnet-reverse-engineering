// Decompiled with JetBrains decompiler
// Type: Jint.Native.NativeArrayIndexer`1
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using System;

#nullable disable
namespace Jint.Native;

internal class NativeArrayIndexer<T> : INativeIndexer
{
  private Marshaller m_marshller;

  public NativeArrayIndexer(Marshaller marshaller)
  {
    this.m_marshller = marshaller != null ? marshaller : throw new ArgumentNullException(nameof (marshaller));
  }

  public JsInstance get(JsInstance that, JsInstance index)
  {
    return this.m_marshller.MarshalClrValue<T>(this.m_marshller.MarshalJsValue<T[]>(that)[this.m_marshller.MarshalJsValue<int>(index)]);
  }

  public void set(JsInstance that, JsInstance index, JsInstance value)
  {
    this.m_marshller.MarshalJsValue<T[]>(that)[this.m_marshller.MarshalJsValue<int>(index)] = this.m_marshller.MarshalJsValue<T>(value);
  }
}
