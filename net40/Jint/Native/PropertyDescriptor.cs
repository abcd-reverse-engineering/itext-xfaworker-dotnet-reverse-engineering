// Decompiled with JetBrains decompiler
// Type: Jint.Native.PropertyDescriptor
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using System;

#nullable disable
namespace Jint.Native;

[Serializable]
public class PropertyDescriptor : Descriptor
{
  private IGlobal global;

  public PropertyDescriptor(IGlobal global, JsDictionaryObject owner, string name)
    : base(owner, name)
  {
    this.global = global;
    this.Enumerable = false;
  }

  public JsFunction GetFunction { get; set; }

  public JsFunction SetFunction { get; set; }

  public override bool isReference => false;

  public override Descriptor Clone()
  {
    PropertyDescriptor propertyDescriptor = new PropertyDescriptor(this.global, this.Owner, this.Name);
    propertyDescriptor.Enumerable = this.Enumerable;
    propertyDescriptor.Configurable = this.Configurable;
    propertyDescriptor.Writable = this.Writable;
    propertyDescriptor.GetFunction = this.GetFunction;
    propertyDescriptor.SetFunction = this.SetFunction;
    return (Descriptor) propertyDescriptor;
  }

  public override JsInstance Get(JsDictionaryObject that)
  {
    this.global.Visitor.ExecuteFunction(this.GetFunction, that, JsInstance.EMPTY);
    return this.global.Visitor.Returned;
  }

  public override void Set(JsDictionaryObject that, JsInstance value)
  {
    if (this.SetFunction == null)
      throw new JsException((JsInstance) this.global.TypeErrorClass.New());
    this.global.Visitor.ExecuteFunction(this.SetFunction, that, new JsInstance[1]
    {
      value
    });
  }

  internal override DescriptorType DescriptorType => DescriptorType.Accessor;
}
