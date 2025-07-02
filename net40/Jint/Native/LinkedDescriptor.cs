// Decompiled with JetBrains decompiler
// Type: Jint.Native.LinkedDescriptor
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

#nullable disable
namespace Jint.Native;

internal class LinkedDescriptor : Descriptor
{
  private Descriptor d;
  private JsDictionaryObject m_that;

  public LinkedDescriptor(
    JsDictionaryObject owner,
    string name,
    Descriptor source,
    JsDictionaryObject that)
    : base(owner, name)
  {
    if (source.isReference)
    {
      LinkedDescriptor linkedDescriptor = source as LinkedDescriptor;
      this.d = linkedDescriptor.d;
      this.m_that = linkedDescriptor.m_that;
    }
    else
      this.d = source;
    this.Enumerable = true;
    this.Writable = true;
    this.Configurable = true;
    this.m_that = that;
  }

  public JsDictionaryObject targetObject => this.m_that;

  public override bool isReference => true;

  public override bool isDeleted
  {
    get => this.d.isDeleted;
    protected set
    {
    }
  }

  public override Descriptor Clone()
  {
    LinkedDescriptor linkedDescriptor = new LinkedDescriptor(this.Owner, this.Name, (Descriptor) this, this.targetObject);
    linkedDescriptor.Writable = this.Writable;
    linkedDescriptor.Configurable = this.Configurable;
    linkedDescriptor.Enumerable = this.Enumerable;
    return (Descriptor) linkedDescriptor;
  }

  public override JsInstance Get(JsDictionaryObject that) => this.d.Get(that);

  public override void Set(JsDictionaryObject that, JsInstance value) => this.d.Set(that, value);

  internal override DescriptorType DescriptorType => DescriptorType.Value;
}
