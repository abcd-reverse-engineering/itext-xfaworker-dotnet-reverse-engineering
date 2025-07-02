// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsObjectConstructor
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using Jint.Delegates;
using Jint.Expressions;
using System;

#nullable disable
namespace Jint.Native;

[Serializable]
public class JsObjectConstructor : JsConstructor
{
  public JsObjectConstructor(IGlobal global, JsObject prototype, JsObject rootPrototype)
    : base(global)
  {
    this.Name = "Object";
    this.DefineOwnProperty(JsFunction.PROTOTYPE, (JsInstance) rootPrototype, PropertyAttributes.ReadOnly | PropertyAttributes.DontEnum | PropertyAttributes.DontDelete);
  }

  public override void InitPrototype(IGlobal global)
  {
    JsObject prototypeProperty = this.PrototypeProperty;
    prototypeProperty.DefineOwnProperty("constructor", (JsInstance) this, PropertyAttributes.DontEnum);
    prototypeProperty.DefineOwnProperty("toString", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new JintFunc<JsDictionaryObject, JsInstance[], JsInstance>(this.ToStringImpl)), PropertyAttributes.DontEnum);
    prototypeProperty.DefineOwnProperty("toLocaleString", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new JintFunc<JsDictionaryObject, JsInstance[], JsInstance>(this.ToStringImpl)), PropertyAttributes.DontEnum);
    prototypeProperty.DefineOwnProperty("valueOf", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new JintFunc<JsDictionaryObject, JsInstance[], JsInstance>(this.ValueOfImpl)), PropertyAttributes.DontEnum);
    prototypeProperty.DefineOwnProperty("hasOwnProperty", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new JintFunc<JsDictionaryObject, JsInstance[], JsInstance>(this.HasOwnPropertyImpl)), PropertyAttributes.DontEnum);
    prototypeProperty.DefineOwnProperty("isPrototypeOf", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new JintFunc<JsDictionaryObject, JsInstance[], JsInstance>(this.IsPrototypeOfImpl)), PropertyAttributes.DontEnum);
    prototypeProperty.DefineOwnProperty("propertyIsEnumerable", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new JintFunc<JsDictionaryObject, JsInstance[], JsInstance>(this.PropertyIsEnumerableImpl)), PropertyAttributes.DontEnum);
    prototypeProperty.DefineOwnProperty("getPrototypeOf", (JsInstance) new JsFunctionWrapper(new JintFunc<JsInstance[], JsInstance>(this.GetPrototypeOfImpl), global.FunctionClass.PrototypeProperty), PropertyAttributes.DontEnum);
    if (!global.HasOption(Options.Ecmascript5))
      return;
    prototypeProperty.DefineOwnProperty("defineProperty", (JsInstance) new JsFunctionWrapper(new JintFunc<JsInstance[], JsInstance>(this.DefineProperty), global.FunctionClass.PrototypeProperty), PropertyAttributes.DontEnum);
    prototypeProperty.DefineOwnProperty("__lookupGetter__", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new JintFunc<JsDictionaryObject, JsInstance[], JsInstance>(((JsDictionaryObject) this).GetGetFunction)), PropertyAttributes.DontEnum);
    prototypeProperty.DefineOwnProperty("__lookupSetter__", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new JintFunc<JsDictionaryObject, JsInstance[], JsInstance>(((JsDictionaryObject) this).GetSetFunction)), PropertyAttributes.DontEnum);
  }

  public JsObject New(JsFunction constructor)
  {
    JsObject owner = new JsObject(this.PrototypeProperty);
    JsObject jsObject = owner;
    ValueDescriptor valueDescriptor = new ValueDescriptor((JsDictionaryObject) owner, JsFunction.CONSTRUCTOR, (JsInstance) constructor);
    valueDescriptor.Enumerable = false;
    ValueDescriptor currentDescriptor = valueDescriptor;
    jsObject.DefineOwnProperty((Descriptor) currentDescriptor);
    return owner;
  }

  public JsObject New(JsFunction constructor, JsObject Prototype)
  {
    JsObject owner = new JsObject(Prototype);
    JsObject jsObject = owner;
    ValueDescriptor valueDescriptor = new ValueDescriptor((JsDictionaryObject) owner, JsFunction.CONSTRUCTOR, (JsInstance) constructor);
    valueDescriptor.Enumerable = false;
    ValueDescriptor currentDescriptor = valueDescriptor;
    jsObject.DefineOwnProperty((Descriptor) currentDescriptor);
    return owner;
  }

  public JsObject New(object value) => new JsObject(value, this.PrototypeProperty);

  public JsObject New(object value, JsObject prototype) => new JsObject(value, prototype);

  public JsObject New() => this.New((object) null);

  public JsObject New(JsObject prototype) => new JsObject(prototype);

  public override JsInstance Execute(
    IJintVisitor visitor,
    JsDictionaryObject that,
    JsInstance[] parameters)
  {
    if (parameters.Length <= 0)
      return (JsInstance) this.New((JsFunction) this);
    switch (parameters[0].Class)
    {
      case "String":
        return (JsInstance) this.Global.StringClass.New(parameters[0].ToString());
      case "Number":
        return (JsInstance) this.Global.NumberClass.New(parameters[0].ToNumber());
      case "Boolean":
        return (JsInstance) this.Global.BooleanClass.New(parameters[0].ToBoolean());
      default:
        return parameters[0];
    }
  }

  public JsInstance ToStringImpl(JsDictionaryObject target, JsInstance[] parameters)
  {
    return (JsInstance) this.Global.StringClass.New($"[object {target.Class}]");
  }

  public JsInstance ValueOfImpl(JsDictionaryObject target, JsInstance[] parameters)
  {
    return (JsInstance) target;
  }

  public JsInstance HasOwnPropertyImpl(JsDictionaryObject target, JsInstance[] parameters)
  {
    return (JsInstance) this.Global.BooleanClass.New(target.HasOwnProperty(parameters[0]));
  }

  public JsInstance IsPrototypeOfImpl(JsDictionaryObject target, JsInstance[] parameters)
  {
    if (target.Class != "Object")
      return (JsInstance) this.Global.BooleanClass.False;
    do
    {
      this.IsPrototypeOf(target);
      if (target == null)
        return (JsInstance) this.Global.BooleanClass.True;
    }
    while (target != this);
    return (JsInstance) this.Global.BooleanClass.True;
  }

  public JsInstance PropertyIsEnumerableImpl(JsDictionaryObject target, JsInstance[] parameters)
  {
    return !this.HasOwnProperty(parameters[0]) ? (JsInstance) this.Global.BooleanClass.False : (JsInstance) this.Global.BooleanClass.New((target[parameters[0]].Attributes & PropertyAttributes.DontEnum) == PropertyAttributes.None);
  }

  public JsInstance GetPrototypeOfImpl(JsInstance[] parameters)
  {
    if (parameters[0].Class != "Object")
      throw new JsException((JsInstance) this.Global.TypeErrorClass.New());
    if (!(parameters[0] is JsObject jsObject))
      jsObject = (JsObject) JsUndefined.Instance;
    if (!(jsObject[JsFunction.CONSTRUCTOR] is JsObject instance))
      instance = (JsObject) JsUndefined.Instance;
    return instance[JsFunction.PROTOTYPE];
  }

  public JsInstance DefineProperty(JsInstance[] parameters)
  {
    JsInstance parameter = parameters[0];
    if (!(parameter is JsDictionaryObject))
      throw new JsException((JsInstance) this.Global.TypeErrorClass.New());
    string name = parameters[1].ToString();
    Descriptor propertyDesciptor = Descriptor.ToPropertyDesciptor(this.Global, (JsDictionaryObject) parameter, name, parameters[2]);
    ((JsDictionaryObject) parameter).DefineOwnProperty(propertyDesciptor);
    return parameter;
  }
}
