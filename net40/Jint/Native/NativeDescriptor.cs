// Decompiled with JetBrains decompiler
// Type: Jint.Native.NativeDescriptor
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using Jint.Marshal;

#nullable disable
namespace Jint.Native;

public class NativeDescriptor : Descriptor
{
  private JsGetter getter;
  private JsSetter setter;

  public NativeDescriptor(JsDictionaryObject owner, string name, JsGetter getter)
    : base(owner, name)
  {
    this.getter = getter;
    this.Writable = false;
  }

  public NativeDescriptor(JsDictionaryObject owner, string name, JsGetter getter, JsSetter setter)
    : base(owner, name)
  {
    this.getter = getter;
    this.setter = setter;
  }

  public NativeDescriptor(JsDictionaryObject owner, NativeDescriptor src)
    : base(owner, src.Name)
  {
    this.getter = src.getter;
    this.setter = src.setter;
    this.Writable = src.Writable;
    this.Configurable = src.Configurable;
    this.Enumerable = src.Enumerable;
  }

  public override bool isReference => false;

  public override Descriptor Clone() => (Descriptor) new NativeDescriptor(this.Owner, this);

  public override JsInstance Get(JsDictionaryObject that)
  {
    return this.getter == null ? (JsInstance) JsUndefined.Instance : this.getter(that);
  }

  public override void Set(JsDictionaryObject that, JsInstance value)
  {
    if (this.setter == null)
      return;
    this.setter(that, value);
  }

  internal override DescriptorType DescriptorType => DescriptorType.Clr;
}
