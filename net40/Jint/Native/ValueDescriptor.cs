// Decompiled with JetBrains decompiler
// Type: Jint.Native.ValueDescriptor
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using System;

#nullable disable
namespace Jint.Native;

[Serializable]
public class ValueDescriptor : Descriptor
{
  private JsInstance value;

  public ValueDescriptor(JsDictionaryObject owner, string name)
    : base(owner, name)
  {
    this.Enumerable = true;
    this.Writable = true;
    this.Configurable = true;
  }

  public ValueDescriptor(JsDictionaryObject owner, string name, JsInstance value)
    : this(owner, name)
  {
    this.Set((JsDictionaryObject) null, value);
  }

  public override bool isReference => false;

  public override Descriptor Clone()
  {
    ValueDescriptor valueDescriptor = new ValueDescriptor(this.Owner, this.Name, this.value);
    valueDescriptor.Enumerable = this.Enumerable;
    valueDescriptor.Configurable = this.Configurable;
    valueDescriptor.Writable = this.Writable;
    return (Descriptor) valueDescriptor;
  }

  public override JsInstance Get(JsDictionaryObject that)
  {
    return this.value ?? (JsInstance) JsUndefined.Instance;
  }

  public override void Set(JsDictionaryObject that, JsInstance value)
  {
    if (!this.Writable)
      throw new JintException("This property is not writable");
    this.value = value;
  }

  internal override DescriptorType DescriptorType => DescriptorType.Value;
}
