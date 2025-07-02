// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsScope
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace Jint.Native;

[Serializable]
public class JsScope : JsDictionaryObject
{
  protected Descriptor thisDescriptor;
  protected Descriptor argumentsDescriptor;
  protected JsScope globalScope;
  private JsDictionaryObject bag;
  public static string THIS = "this";
  public static string ARGUMENTS = "arguments";

  public JsScope()
    : base((JsDictionaryObject) JsNull.Instance)
  {
    this.globalScope = (JsScope) null;
    this[JsScope.THIS] = (JsInstance) this;
  }

  public JsScope(JsScope outer)
    : base((JsDictionaryObject) outer)
  {
    this.globalScope = outer != null ? outer.Global : throw new ArgumentNullException(nameof (outer));
    this[JsScope.THIS] = (JsInstance) this;
  }

  public JsScope(JsScope outer, JsDictionaryObject bag)
    : base((JsDictionaryObject) outer)
  {
    if (outer == null)
      throw new ArgumentNullException(nameof (outer));
    if (bag == null)
      throw new ArgumentNullException(nameof (bag));
    this.globalScope = outer.Global;
    this.bag = bag;
    this[JsScope.THIS] = (JsInstance) this;
  }

  public T GetPrototype<T>() where T : JsScope
  {
    JsScope prototype = this;
    while (true)
    {
      switch (prototype)
      {
        case null:
        case T _:
          goto label_3;
        default:
          prototype = prototype.Prototype as JsScope;
          continue;
      }
    }
label_3:
    return (T) prototype;
  }

  public JsScope(JsDictionaryObject bag)
    : base((JsDictionaryObject) JsNull.Instance)
  {
    this.bag = bag;
    this[JsScope.THIS] = (JsInstance) this;
  }

  public override string Class => "Scope";

  public override string Type => "object";

  public JsScope Global => this.globalScope ?? this;

  public override JsInstance this[string index]
  {
    get
    {
      if (index == JsScope.THIS && this.thisDescriptor != null)
        return this.thisDescriptor.Get((JsDictionaryObject) this);
      return index == JsScope.ARGUMENTS && this.argumentsDescriptor != null ? this.argumentsDescriptor.Get((JsDictionaryObject) this) : base[index];
    }
    set => this.SetAt(index, value, false);
  }

  public virtual JsInstance SetAt(
    string index,
    JsInstance value,
    bool defineInGlobalScopeIfNotExist)
  {
    if (index == JsScope.THIS)
    {
      if (this.thisDescriptor != null)
        this.thisDescriptor.Set((JsDictionaryObject) this, value);
      else
        this.DefineOwnProperty(this.thisDescriptor = (Descriptor) new ValueDescriptor((JsDictionaryObject) this, index, value));
    }
    else if (index == JsScope.ARGUMENTS)
    {
      if (this.argumentsDescriptor != null)
        this.argumentsDescriptor.Set((JsDictionaryObject) this, value);
      else
        this.DefineOwnProperty(this.argumentsDescriptor = (Descriptor) new ValueDescriptor((JsDictionaryObject) this, index, value));
    }
    else
    {
      Descriptor descriptor = this.GetDescriptor(index);
      if (descriptor != null)
        descriptor.Set((JsDictionaryObject) this, value);
      else if (this.globalScope != null && defineInGlobalScopeIfNotExist)
        this.globalScope.DefineOwnProperty(index, value);
      else
        this.DefineOwnProperty(index, value);
    }
    return value;
  }

  public override Descriptor GetDescriptor(string index)
  {
    Descriptor descriptor1;
    Descriptor descriptor2;
    if ((descriptor1 = base.GetDescriptor(index)) != null && descriptor1.Owner == this || this.bag == null || (descriptor2 = this.bag.GetDescriptor(index)) == null)
      return descriptor1;
    Descriptor currentDescriptor = (Descriptor) new LinkedDescriptor((JsDictionaryObject) this, descriptor2.Name, descriptor2, this.bag);
    this.DefineOwnProperty(currentDescriptor);
    return currentDescriptor;
  }

  public override IEnumerable<string> GetKeys()
  {
    if (this.bag != null)
    {
      foreach (string key in this.bag.GetKeys())
      {
        if (this.baseGetDescriptor(key) == null)
          yield return key;
      }
    }
    foreach (string key in this.baseGetKeys())
      yield return key;
  }

  private Descriptor baseGetDescriptor(string key) => base.GetDescriptor(key);

  private IEnumerable<string> baseGetKeys() => base.GetKeys();

  public override IEnumerable<JsInstance> GetValues()
  {
    foreach (string key in this.GetKeys())
      yield return this[key];
  }

  public override bool IsClr => this.bag != null && this.bag.IsClr;

  public override object Value
  {
    get => this.bag == null ? (object) null : this.bag.Value;
    set
    {
      if (this.bag == null)
        return;
      this.bag.Value = value;
    }
  }

  public JsScope ParentScope { get; set; }
}
