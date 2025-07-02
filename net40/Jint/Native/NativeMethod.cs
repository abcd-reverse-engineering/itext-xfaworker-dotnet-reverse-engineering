// Decompiled with JetBrains decompiler
// Type: Jint.Native.NativeMethod
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using Jint.Expressions;
using Jint.Marshal;
using System;
using System.Reflection;

#nullable disable
namespace Jint.Native;

public class NativeMethod : JsFunction
{
  private MethodInfo m_nativeMethod;
  private JsMethodImpl m_impl;

  public NativeMethod(JsMethodImpl impl, MethodInfo nativeMethod, JsObject prototype)
    : base(prototype)
  {
    if (impl == null)
      throw new ArgumentNullException(nameof (impl));
    this.m_nativeMethod = nativeMethod;
    this.m_impl = impl;
    if (!(nativeMethod != (MethodInfo) null))
      return;
    this.Name = nativeMethod.Name;
    foreach (ParameterInfo parameter in nativeMethod.GetParameters())
      this.Arguments.Add(parameter.Name);
  }

  public NativeMethod(JsMethodImpl impl, JsObject prototype)
    : this(impl, (MethodInfo) null, prototype)
  {
    foreach (ParameterInfo parameter in impl.Method.GetParameters())
      this.Arguments.Add(parameter.Name);
  }

  public NativeMethod(MethodInfo info, JsObject prototype, IGlobal global)
    : base(prototype)
  {
    if (info == (MethodInfo) null)
      throw new ArgumentNullException(nameof (info));
    if (global == null)
      throw new ArgumentNullException(nameof (global));
    this.m_nativeMethod = info;
    this.m_impl = global.Marshaller.WrapMethod(info, true);
    this.Name = info.Name;
    foreach (ParameterInfo parameter in info.GetParameters())
      this.Arguments.Add(parameter.Name);
  }

  public override bool IsClr => true;

  public MethodInfo GetWrappedMethod() => this.m_nativeMethod;

  public override JsInstance Execute(
    IJintVisitor visitor,
    JsDictionaryObject that,
    JsInstance[] parameters)
  {
    visitor.Return(this.m_impl(visitor.Global, (JsInstance) that, parameters));
    return (JsInstance) that;
  }

  public override JsObject Construct(
    JsInstance[] parameters,
    System.Type[] genericArgs,
    IJintVisitor visitor)
  {
    throw new JintException("This method can't be used as a constructor");
  }

  public override string GetBody() => "[native code]";

  public override JsInstance ToPrimitive(IGlobal global)
  {
    return (JsInstance) global.StringClass.New(this.ToString());
  }
}
