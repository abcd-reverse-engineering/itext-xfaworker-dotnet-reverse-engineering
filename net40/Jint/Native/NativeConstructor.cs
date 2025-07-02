﻿// Decompiled with JetBrains decompiler
// Type: Jint.Native.NativeConstructor
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

public class NativeConstructor : JsConstructor
{
  private System.Type reflectedType;
  private LinkedList<NativeDescriptor> m_properties = new LinkedList<NativeDescriptor>();
  private INativeIndexer m_indexer;
  private ConstructorInfo[] m_constructors;
  private Marshaller m_marshaller;
  private NativeOverloadImpl<ConstructorInfo, ConstructorImpl> m_overloads;

  public NativeConstructor(System.Type type, IGlobal global)
    : this(type, global, (JsObject) null, global.FunctionClass.PrototypeProperty)
  {
  }

  public NativeConstructor(System.Type type, IGlobal global, JsObject PrototypePrototype)
    : this(type, global, PrototypePrototype, global.FunctionClass.PrototypeProperty)
  {
  }

  public NativeConstructor(
    System.Type type,
    IGlobal global,
    JsObject PrototypePrototype,
    JsObject prototype)
    : base(global, prototype)
  {
    if (type == (System.Type) null)
      throw new ArgumentNullException(nameof (type));
    if (type.IsGenericType && type.ContainsGenericParameters)
      throw new InvalidOperationException("A native constructor can't be built against an open generic");
    this.m_marshaller = global.Marshaller;
    this.reflectedType = type;
    this.Name = type.FullName;
    if (!type.IsAbstract)
      this.m_constructors = type.GetConstructors();
    this.DefineOwnProperty(JsFunction.PROTOTYPE, PrototypePrototype == null ? (JsInstance) this.Global.ObjectClass.New((JsFunction) this) : (JsInstance) this.Global.ObjectClass.New((JsFunction) this, PrototypePrototype), PropertyAttributes.ReadOnly | PropertyAttributes.DontEnum | PropertyAttributes.DontDelete);
    this.m_overloads = new NativeOverloadImpl<ConstructorInfo, ConstructorImpl>(this.m_marshaller, new NativeOverloadImpl<ConstructorInfo, ConstructorImpl>.GetMembersDelegate(this.GetMembers), new NativeOverloadImpl<ConstructorInfo, ConstructorImpl>.WrapMmemberDelegate(this.WrapMember));
    if (type.IsValueType)
      this.m_overloads.DefineCustomOverload(new System.Type[0], new System.Type[0], (ConstructorImpl) Delegate.CreateDelegate(typeof (ConstructorImpl), typeof (NativeConstructor).GetMethod("CreateStruct", BindingFlags.Static | BindingFlags.NonPublic).MakeGenericMethod(type)));
    Dictionary<string, LinkedList<MethodInfo>> dictionary = new Dictionary<string, LinkedList<MethodInfo>>();
    foreach (MethodInfo method in type.GetMethods(BindingFlags.Static | BindingFlags.Public))
    {
      if (!method.ReturnType.IsByRef)
      {
        if (!dictionary.ContainsKey(method.Name))
          dictionary[method.Name] = new LinkedList<MethodInfo>();
        dictionary[method.Name].AddLast(method);
      }
    }
    foreach (KeyValuePair<string, LinkedList<MethodInfo>> keyValuePair in dictionary)
      this.DefineOwnProperty(keyValuePair.Key, (JsInstance) this.ReflectOverload((ICollection<MethodInfo>) keyValuePair.Value));
    foreach (PropertyInfo property in type.GetProperties(BindingFlags.Static | BindingFlags.Public))
      this.DefineOwnProperty((Descriptor) this.Global.Marshaller.MarshalPropertyInfo(property, (JsDictionaryObject) this));
    foreach (FieldInfo field in type.GetFields(BindingFlags.Static | BindingFlags.Public))
      this.DefineOwnProperty((Descriptor) this.Global.Marshaller.MarshalFieldInfo(field, (JsDictionaryObject) this));
    if (type.IsEnum)
    {
      string[] names = Enum.GetNames(type);
      object[] objArray = new object[names.Length];
      Enum.GetValues(type).CopyTo((Array) objArray, 0);
      for (int index = 0; index < names.Length; ++index)
        this.DefineOwnProperty(names[index], (JsInstance) this.Global.ObjectClass.New(objArray[index], this.PrototypeProperty));
    }
    foreach (System.Type nestedType in type.GetNestedTypes(BindingFlags.Public))
      this.DefineOwnProperty(nestedType.Name, this.Global.Marshaller.MarshalClrValue<System.Type>(nestedType), PropertyAttributes.DontEnum);
    LinkedList<MethodInfo> linkedList1 = new LinkedList<MethodInfo>();
    LinkedList<MethodInfo> linkedList2 = new LinkedList<MethodInfo>();
    foreach (PropertyInfo property in type.GetProperties(BindingFlags.Instance | BindingFlags.Public))
    {
      ParameterInfo[] indexParameters = property.GetIndexParameters();
      if (indexParameters == null || indexParameters.Length == 0)
        this.m_properties.AddLast(global.Marshaller.MarshalPropertyInfo(property, (JsDictionaryObject) this));
      else if (property.Name == "Item" && indexParameters.Length == 1)
      {
        if (property.CanRead)
          linkedList1.AddLast(property.GetGetMethod());
        if (property.CanWrite)
          linkedList2.AddLast(property.GetSetMethod());
      }
    }
    if (linkedList1.Count > 0 || linkedList2.Count > 0)
    {
      MethodInfo[] methodInfoArray1 = new MethodInfo[linkedList1.Count];
      linkedList1.CopyTo(methodInfoArray1, 0);
      MethodInfo[] methodInfoArray2 = new MethodInfo[linkedList2.Count];
      linkedList2.CopyTo(methodInfoArray2, 0);
      this.m_indexer = (INativeIndexer) new NativeIndexer(this.m_marshaller, methodInfoArray1, methodInfoArray2);
    }
    if (this.reflectedType.IsArray)
      this.m_indexer = (INativeIndexer) typeof (NativeArrayIndexer<>).MakeGenericType(this.reflectedType.GetElementType()).GetConstructor(new System.Type[1]
      {
        typeof (Marshaller)
      }).Invoke(new object[1]{ (object) this.m_marshaller });
    foreach (FieldInfo field in type.GetFields(BindingFlags.Instance | BindingFlags.Public))
      this.m_properties.AddLast(global.Marshaller.MarshalFieldInfo(field, (JsDictionaryObject) this));
  }

  private JsFunction ReflectOverload(ICollection<MethodInfo> methods)
  {
    if (methods.Count == 0)
      throw new ArgumentException("At least one method is required", nameof (methods));
    if (methods.Count == 1)
    {
      using (IEnumerator<MethodInfo> enumerator = methods.GetEnumerator())
      {
        if (enumerator.MoveNext())
        {
          MethodInfo current = enumerator.Current;
          return current.ContainsGenericParameters ? (JsFunction) new NativeMethodOverload(methods, this.Global.FunctionClass.PrototypeProperty, this.Global) : (JsFunction) new NativeMethod(current, this.Global.FunctionClass.PrototypeProperty, this.Global);
        }
      }
      throw new ApplicationException("Unexpected error");
    }
    return (JsFunction) new NativeMethodOverload(methods, this.Global.FunctionClass.PrototypeProperty, this.Global);
  }

  public override bool IsClr => true;

  public override object Value
  {
    get => (object) this.reflectedType;
    set
    {
    }
  }

  public override void InitPrototype(IGlobal global)
  {
    JsObject prototypeProperty = this.PrototypeProperty;
    Dictionary<string, LinkedList<MethodInfo>> dictionary = new Dictionary<string, LinkedList<MethodInfo>>();
    foreach (MethodInfo method in this.reflectedType.GetMethods(BindingFlags.Instance | BindingFlags.Public))
    {
      if (!method.ReturnType.IsByRef)
      {
        if (!dictionary.ContainsKey(method.Name))
          dictionary[method.Name] = new LinkedList<MethodInfo>();
        dictionary[method.Name].AddLast(method);
      }
    }
    foreach (KeyValuePair<string, LinkedList<MethodInfo>> keyValuePair in dictionary)
      prototypeProperty[keyValuePair.Key] = (JsInstance) this.ReflectOverload((ICollection<MethodInfo>) keyValuePair.Value);
  }

  private static object CreateStruct<T>(IGlobal global, JsInstance[] args) where T : struct
  {
    return (object) default (T);
  }

  public override JsInstance Execute(
    IJintVisitor visitor,
    JsDictionaryObject that,
    JsInstance[] parameters)
  {
    if (that == null || that == JsUndefined.Instance || that == JsNull.Instance || that as IGlobal == visitor.Global)
      throw new JintException($"A constructor '{this.reflectedType.FullName}' should be applied to the object");
    that.Value = that.Value == null ? this.CreateInstance(visitor, parameters) : throw new JintException($"Can't apply the constructor '{this.reflectedType.FullName}' to already initialized '{that.Value.ToString()}'");
    this.SetupNativeProperties(that);
    ((JsObject) that).Indexer = this.m_indexer;
    return (JsInstance) that;
  }

  public override JsObject Construct(
    JsInstance[] parameters,
    System.Type[] genericArgs,
    IJintVisitor visitor)
  {
    return (JsObject) this.Wrap<object>(this.CreateInstance(visitor, parameters));
  }

  private object CreateInstance(IJintVisitor visitor, JsInstance[] parameters)
  {
    ConstructorImpl constructorImpl = this.m_overloads.ResolveOverload(parameters, (System.Type[]) null);
    if (constructorImpl == null)
      throw new JintException($"No matching overload found {this.reflectedType.FullName}({string.Join(",", Array.ConvertAll<JsInstance, string>(parameters, (Converter<JsInstance, string>) (p => p.ToString())))})");
    return constructorImpl(visitor.Global, parameters);
  }

  public void SetupNativeProperties(JsDictionaryObject target)
  {
    if (target == null || target == JsNull.Instance || target == JsUndefined.Instance)
      throw new ArgumentException("A valid js object is required", nameof (target));
    foreach (NativeDescriptor property in this.m_properties)
      target.DefineOwnProperty((Descriptor) new NativeDescriptor(target, property));
  }

  public override JsInstance Wrap<T>(T value)
  {
    if (!this.reflectedType.IsAssignableFrom(value.GetType()))
      throw new JintException($"Attempt to wrap '{typeof (T).FullName}' with '{this.reflectedType.FullName}'");
    JsObject target = this.Global.ObjectClass.New(this.PrototypeProperty);
    target.Value = (object) value;
    target.Indexer = this.m_indexer;
    this.SetupNativeProperties((JsDictionaryObject) target);
    return (JsInstance) target;
  }

  protected ConstructorImpl WrapMember(ConstructorInfo info)
  {
    return this.m_marshaller.WrapConstructor(info, true);
  }

  protected IEnumerable<ConstructorInfo> GetMembers(System.Type[] genericArguments, int argCount)
  {
    return this.m_constructors == null ? (IEnumerable<ConstructorInfo>) new ConstructorInfo[0] : (IEnumerable<ConstructorInfo>) Array.FindAll<ConstructorInfo>(this.m_constructors, (Predicate<ConstructorInfo>) (con => con.GetParameters().Length == argCount));
  }
}
