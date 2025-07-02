// Decompiled with JetBrains decompiler
// Type: Jint.Native.ClrFunction
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using Jint.Expressions;
using System;
using System.Reflection;

#nullable disable
namespace Jint.Native;

[Serializable]
public class ClrFunction : JsFunction
{
  public Delegate Delegate { get; set; }

  public ParameterInfo[] Parameters { get; set; }

  public ClrFunction(Delegate d, JsObject prototype)
    : base(prototype)
  {
    this.Delegate = d;
    this.Parameters = d.Method.GetParameters();
  }

  public override JsInstance Execute(
    IJintVisitor visitor,
    JsDictionaryObject that,
    JsInstance[] parameters)
  {
    object[] objArray = new object[this.Delegate.Method.GetParameters().Length];
    for (int index = 0; index < parameters.Length; ++index)
      objArray[index] = !typeof (JsInstance).IsAssignableFrom(this.Parameters[index].ParameterType) || !this.Parameters[index].ParameterType.IsInstanceOfType((object) parameters[index]) ? (!this.Parameters[index].ParameterType.IsInstanceOfType(parameters[index].Value) ? visitor.Global.Marshaller.MarshalJsValue<object>(parameters[index]) : parameters[index].Value) : (object) parameters[index];
    object obj;
    try
    {
      obj = this.Delegate.DynamicInvoke(objArray);
    }
    catch (TargetInvocationException ex)
    {
      throw ex.InnerException;
    }
    catch (Exception ex)
    {
      if (ex.InnerException is JsException)
        throw ex.InnerException;
      throw;
    }
    if (obj != null)
    {
      if (typeof (JsInstance).IsInstanceOfType(obj))
        visitor.Return((JsInstance) obj);
      else
        visitor.Return((JsInstance) visitor.Global.WrapClr(obj));
    }
    else
      visitor.Return((JsInstance) JsUndefined.Instance);
    return (JsInstance) null;
  }

  public override string ToString()
  {
    return string.Format("function {0}() { [native code] }", (object) this.Delegate.Method.Name);
  }
}
