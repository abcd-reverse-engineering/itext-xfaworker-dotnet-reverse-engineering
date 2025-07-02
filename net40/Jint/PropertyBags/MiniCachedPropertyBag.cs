// Decompiled with JetBrains decompiler
// Type: Jint.PropertyBags.MiniCachedPropertyBag
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using Jint.Native;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace Jint.PropertyBags;

public class MiniCachedPropertyBag : 
  IPropertyBag,
  IEnumerable<KeyValuePair<string, Descriptor>>,
  IEnumerable
{
  private IPropertyBag bag;
  private Descriptor lastAccessed;

  public MiniCachedPropertyBag() => this.bag = (IPropertyBag) new DictionaryPropertyBag();

  public Descriptor Put(string name, Descriptor descriptor)
  {
    this.bag.Put(name, descriptor);
    return this.lastAccessed = descriptor;
  }

  public void Delete(string name)
  {
    this.bag.Delete(name);
    if (this.lastAccessed == null || !(this.lastAccessed.Name == name))
      return;
    this.lastAccessed = (Descriptor) null;
  }

  public Descriptor Get(string name)
  {
    if (this.lastAccessed != null && this.lastAccessed.Name == name)
      return this.lastAccessed;
    Descriptor descriptor = this.bag.Get(name);
    if (descriptor != null)
      this.lastAccessed = descriptor;
    return descriptor;
  }

  public bool TryGet(string name, out Descriptor descriptor)
  {
    if (this.lastAccessed != null && this.lastAccessed.Name == name)
    {
      descriptor = this.lastAccessed;
      return true;
    }
    bool flag = this.bag.TryGet(name, out descriptor);
    if (flag)
      this.lastAccessed = descriptor;
    return flag;
  }

  public int Count => this.bag.Count;

  public IEnumerable<Descriptor> Values => this.bag.Values;

  public IEnumerator<KeyValuePair<string, Descriptor>> GetEnumerator() => this.bag.GetEnumerator();

  IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();
}
