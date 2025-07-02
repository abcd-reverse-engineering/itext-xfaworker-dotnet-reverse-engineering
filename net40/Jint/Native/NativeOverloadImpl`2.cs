﻿// Decompiled with JetBrains decompiler
// Type: Jint.Native.NativeOverloadImpl`2
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace Jint.Native;

public class NativeOverloadImpl<TMemberInfo, TImpl>
  where TMemberInfo : MethodBase
  where TImpl : class
{
  private Dictionary<string, TImpl> m_protoCache = new Dictionary<string, TImpl>();
  private Dictionary<TMemberInfo, TImpl> m_reflectCache = new Dictionary<TMemberInfo, TImpl>();
  private Marshaller m_marshaller;
  private NativeOverloadImpl<TMemberInfo, TImpl>.GetMembersDelegate GetMembers;
  private NativeOverloadImpl<TMemberInfo, TImpl>.WrapMmemberDelegate WrapMember;

  public NativeOverloadImpl(
    Marshaller marshaller,
    NativeOverloadImpl<TMemberInfo, TImpl>.GetMembersDelegate getMembers,
    NativeOverloadImpl<TMemberInfo, TImpl>.WrapMmemberDelegate wrapMember)
  {
    if (marshaller == null)
      throw new ArgumentNullException(nameof (marshaller));
    if (getMembers == null)
      throw new ArgumentNullException(nameof (getMembers));
    if (wrapMember == null)
      throw new ArgumentNullException(nameof (wrapMember));
    this.m_marshaller = marshaller;
    this.GetMembers = getMembers;
    this.WrapMember = wrapMember;
  }

  protected TMemberInfo MatchMethod(Type[] args, IEnumerable<TMemberInfo> members)
  {
    LinkedList<NativeOverloadImpl<TMemberInfo, TImpl>.MethodMatch> linkedList = new LinkedList<NativeOverloadImpl<TMemberInfo, TImpl>.MethodMatch>();
    foreach (TMemberInfo member in members)
      linkedList.AddLast(new NativeOverloadImpl<TMemberInfo, TImpl>.MethodMatch()
      {
        method = member,
        parameters = Array.ConvertAll<ParameterInfo, Type>(member.GetParameters(), (Converter<ParameterInfo, Type>) (p => p.ParameterType)),
        weight = 0
      });
    if (args != null)
    {
      for (int index = 0; index < args.Length; ++index)
      {
        Type type = args[index];
        LinkedListNode<NativeOverloadImpl<TMemberInfo, TImpl>.MethodMatch> next;
        for (LinkedListNode<NativeOverloadImpl<TMemberInfo, TImpl>.MethodMatch> node = linkedList.First; node != null; node = next)
        {
          next = node.Next;
          if (type != (Type) null)
          {
            Type parameter = node.Value.parameters[index];
            if (type.Equals(parameter))
              ++node.Value.weight;
            else if ((!typeof (Delegate).IsAssignableFrom(parameter) || !typeof (JsFunction).IsAssignableFrom(type)) && !this.m_marshaller.IsAssignable(parameter, type))
              linkedList.Remove(node);
          }
          else if (node.Value.parameters[index].IsValueType)
            linkedList.Remove(node);
        }
      }
    }
    NativeOverloadImpl<TMemberInfo, TImpl>.MethodMatch methodMatch1 = (NativeOverloadImpl<TMemberInfo, TImpl>.MethodMatch) null;
    foreach (NativeOverloadImpl<TMemberInfo, TImpl>.MethodMatch methodMatch2 in linkedList)
      methodMatch1 = methodMatch1 == null ? methodMatch2 : (methodMatch1.weight < methodMatch2.weight ? methodMatch2 : methodMatch1);
    return methodMatch1 != null ? methodMatch1.method : default (TMemberInfo);
  }

  protected string MakeKey(Type[] types, Type[] genericArguments)
  {
    return $"<{string.Join(",", Array.ConvertAll<Type, string>(genericArguments ?? new Type[0], (Converter<Type, string>) (t => !(t == (Type) null) ? t.FullName : "<null>")))}>{string.Join(",", Array.ConvertAll<Type, string>(types ?? new Type[0], (Converter<Type, string>) (t => !(t == (Type) null) ? t.FullName : "<null>")))}";
  }

  public void DefineCustomOverload(Type[] args, Type[] generics, TImpl impl)
  {
    this.m_protoCache[this.MakeKey(args, generics)] = impl;
  }

  public TImpl ResolveOverload(JsInstance[] args, Type[] generics)
  {
    Type[] typeArray = Array.ConvertAll<JsInstance, Type>(args, (Converter<JsInstance, Type>) (x => this.m_marshaller.GetInstanceType(x)));
    string key = this.MakeKey(typeArray, generics);
    TImpl impl;
    if (!this.m_protoCache.TryGetValue(key, out impl))
    {
      TMemberInfo memberInfo = this.MatchMethod(typeArray, this.GetMembers(generics, args.Length));
      if ((MethodBase) memberInfo != (MethodBase) null && !this.m_reflectCache.TryGetValue(memberInfo, out impl))
        this.m_reflectCache[memberInfo] = impl = this.WrapMember(memberInfo);
      this.m_protoCache[key] = impl;
    }
    return impl;
  }

  public delegate IEnumerable<TMemberInfo> GetMembersDelegate(Type[] genericArguments, int argCount)
    where TMemberInfo : MethodBase
    where TImpl : class;

  public delegate TImpl WrapMmemberDelegate(TMemberInfo info)
    where TMemberInfo : MethodBase
    where TImpl : class;

  private class MethodMatch
  {
    public TMemberInfo method;
    public int weight;
    public Type[] parameters;
  }
}
