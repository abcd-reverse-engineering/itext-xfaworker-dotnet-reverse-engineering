// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsFunctionWrapper
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using Jint.Delegates;
using Jint.Expressions;
using System;

#nullable disable
namespace Jint.Native;

[Serializable]
public class JsFunctionWrapper : JsFunction
{
  public JintFunc<JsInstance[], JsInstance> Delegate { get; set; }

  public JsFunctionWrapper(JintFunc<JsInstance[], JsInstance> d, JsObject prototype)
    : base(prototype)
  {
    this.Delegate = d;
  }

  public override JsInstance Execute(
    IJintVisitor visitor,
    JsDictionaryObject that,
    JsInstance[] parameters)
  {
    try
    {
      JsInstance jsInstance = this.Delegate(parameters);
      visitor.Return(jsInstance == null ? (JsInstance) JsUndefined.Instance : jsInstance);
      return (JsInstance) that;
    }
    catch (Exception ex)
    {
      if (ex.InnerException is JsException)
        throw ex.InnerException;
      throw;
    }
  }

  public override string ToString()
  {
    return $"function {this.Delegate.Method.Name}() {{ [native code] }}";
  }
}
