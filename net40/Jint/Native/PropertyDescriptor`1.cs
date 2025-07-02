// Decompiled with JetBrains decompiler
// Type: Jint.Native.PropertyDescriptor`1
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using Jint.Delegates;
using System;

#nullable disable
namespace Jint.Native;

[Serializable]
public class PropertyDescriptor<T> : PropertyDescriptor where T : JsInstance
{
  public PropertyDescriptor(
    IGlobal global,
    JsDictionaryObject owner,
    string name,
    JintFunc<T, JsInstance> get)
    : base(global, owner, name)
  {
    this.GetFunction = global.FunctionClass.New<T>(get);
  }

  public PropertyDescriptor(
    IGlobal global,
    JsDictionaryObject owner,
    string name,
    JintFunc<T, JsInstance> get,
    JintFunc<T, JsInstance[], JsInstance> set)
    : this(global, owner, name, get)
  {
    this.SetFunction = global.FunctionClass.New<T>(set);
  }
}
