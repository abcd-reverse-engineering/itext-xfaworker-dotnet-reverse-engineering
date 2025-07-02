// Decompiled with JetBrains decompiler
// Type: Jint.Native.Descriptor
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using System;

#nullable disable
namespace Jint.Native;

[Serializable]
public abstract class Descriptor
{
  public Descriptor(JsDictionaryObject owner, string name)
  {
    this.Owner = owner;
    this.Name = name;
  }

  public string Name { get; set; }

  public bool Enumerable { get; set; }

  public bool Configurable { get; set; }

  public bool Writable { get; set; }

  public JsDictionaryObject Owner { get; set; }

  public virtual bool isDeleted { get; protected set; }

  public abstract bool isReference { get; }

  public virtual void Delete() => this.isDeleted = true;

  public bool IsClr => false;

  public abstract Descriptor Clone();

  public abstract JsInstance Get(JsDictionaryObject that);

  public abstract void Set(JsDictionaryObject that, JsInstance value);

  internal abstract DescriptorType DescriptorType { get; }

  internal static Descriptor ToPropertyDesciptor(
    IGlobal global,
    JsDictionaryObject owner,
    string name,
    JsInstance jsInstance)
  {
    JsObject jsObject = !(jsInstance.Class != "Object") ? (JsObject) jsInstance : throw new JsException((JsInstance) global.TypeErrorClass.New("The target object has to be an instance of an object"));
    if ((jsObject.HasProperty("value") || jsObject.HasProperty("writable")) && (jsObject.HasProperty("set") || jsObject.HasProperty("get")))
      throw new JsException((JsInstance) global.TypeErrorClass.New("The property cannot be both writable and have get/set accessors or cannot have both a value and an accessor defined"));
    JsInstance result = (JsInstance) null;
    Descriptor propertyDesciptor = !jsObject.HasProperty("value") ? (Descriptor) new PropertyDescriptor(global, owner, name) : (Descriptor) new ValueDescriptor(owner, name, jsObject["value"]);
    if (jsObject.TryGetProperty("enumerable", out result))
      propertyDesciptor.Enumerable = result.ToBoolean();
    if (jsObject.TryGetProperty("configurable", out result))
      propertyDesciptor.Configurable = result.ToBoolean();
    if (jsObject.TryGetProperty("writable", out result))
      propertyDesciptor.Writable = result.ToBoolean();
    if (jsObject.TryGetProperty("get", out result))
      ((PropertyDescriptor) propertyDesciptor).GetFunction = result is JsFunction ? (JsFunction) result : throw new JsException((JsInstance) global.TypeErrorClass.New("The getter has to be a function"));
    if (jsObject.TryGetProperty("set", out result))
      ((PropertyDescriptor) propertyDesciptor).SetFunction = result is JsFunction ? (JsFunction) result : throw new JsException((JsInstance) global.TypeErrorClass.New("The setter has to be a function"));
    return propertyDesciptor;
  }
}
