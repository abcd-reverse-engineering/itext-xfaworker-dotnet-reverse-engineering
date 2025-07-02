// Decompiled with JetBrains decompiler
// Type: Jint.Native.NativeMethodOverload
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using Jint.Expressions;
using Jint.Marshal;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace Jint.Native;

public class NativeMethodOverload : JsFunction
{
  private Marshaller m_marshaller;
  private NativeOverloadImpl<MethodInfo, JsMethodImpl> m_overloads;
  private LinkedList<MethodInfo> m_methods = new LinkedList<MethodInfo>();
  private LinkedList<MethodInfo> m_generics = new LinkedList<MethodInfo>();

  public NativeMethodOverload(ICollection<MethodInfo> methods, JsObject prototype, IGlobal global)
    : base(prototype)
  {
    this.m_marshaller = global != null ? global.Marshaller : throw new ArgumentNullException(nameof (global));
    using (IEnumerator<MethodInfo> enumerator = methods.GetEnumerator())
    {
      if (enumerator.MoveNext())
        this.Name = enumerator.Current.Name;
    }
    foreach (MethodInfo method in (IEnumerable<MethodInfo>) methods)
    {
      if (method.IsGenericMethodDefinition)
        this.m_generics.AddLast(method);
      else if (!method.ContainsGenericParameters)
        this.m_methods.AddLast(method);
    }
    this.m_overloads = new NativeOverloadImpl<MethodInfo, JsMethodImpl>(this.m_marshaller, new NativeOverloadImpl<MethodInfo, JsMethodImpl>.GetMembersDelegate(this.GetMembers), new NativeOverloadImpl<MethodInfo, JsMethodImpl>.WrapMmemberDelegate(this.WrapMember));
  }

  public override bool IsClr => true;

  public override object Value
  {
    get => (object) true;
    set
    {
    }
  }

  public override JsInstance Execute(
    IJintVisitor visitor,
    JsDictionaryObject that,
    JsInstance[] parameters)
  {
    return this.Execute(visitor, that, parameters, (System.Type[]) null);
  }

  public override JsInstance Execute(
    IJintVisitor visitor,
    JsDictionaryObject that,
    JsInstance[] parameters,
    System.Type[] genericArguments)
  {
    if (this.m_generics.Count == 0 && genericArguments != null && genericArguments.Length > 0)
      return base.Execute(visitor, that, parameters, genericArguments);
    visitor.Return((this.m_overloads.ResolveOverload(parameters, genericArguments) ?? throw new JintException($"No matching overload found {this.Name}<{genericArguments}>"))(visitor.Global, (JsInstance) that, parameters));
    return (JsInstance) that;
  }

  protected JsMethodImpl WrapMember(MethodInfo info) => this.m_marshaller.WrapMethod(info, true);

  protected IEnumerable<MethodInfo> GetMembers(System.Type[] genericArguments, int argCount)
  {
    if (genericArguments != null && genericArguments.Length > 0)
    {
      foreach (MethodInfo item in this.m_generics)
      {
        if (item.GetGenericArguments().Length == genericArguments.Length && item.GetParameters().Length == argCount)
        {
          MethodInfo m = (MethodInfo) null;
          try
          {
            m = item.MakeGenericMethod(genericArguments);
          }
          catch
          {
          }
          if (m != (MethodInfo) null)
            yield return m;
        }
      }
    }
    foreach (MethodInfo item in this.m_methods)
    {
      ParameterInfo[] parameters = item.GetParameters();
      if (parameters.Length == argCount)
        yield return item;
    }
  }

  public override string GetBody() => "[native overload]";
}
