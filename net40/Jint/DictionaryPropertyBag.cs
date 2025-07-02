// Decompiled with JetBrains decompiler
// Type: Jint.DictionaryPropertyBag
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using Jint.Native;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace Jint;

internal class DictionaryPropertyBag : 
  IPropertyBag,
  IEnumerable<KeyValuePair<string, Descriptor>>,
  IEnumerable
{
  private Dictionary<string, Descriptor> bag = new Dictionary<string, Descriptor>();

  public Descriptor Put(string name, Descriptor descriptor)
  {
    this.bag[name] = descriptor;
    return descriptor;
  }

  public void Delete(string name) => this.bag.Remove(name);

  public Descriptor Get(string name)
  {
    Descriptor descriptor;
    this.TryGet(name, out descriptor);
    return descriptor;
  }

  public bool TryGet(string name, out Descriptor descriptor)
  {
    return this.bag.TryGetValue(name, out descriptor);
  }

  public int Count => this.bag.Count;

  public IEnumerable<Descriptor> Values => (IEnumerable<Descriptor>) this.bag.Values;

  public IEnumerator<KeyValuePair<string, Descriptor>> GetEnumerator()
  {
    return (IEnumerator<KeyValuePair<string, Descriptor>>) this.bag.GetEnumerator();
  }

  IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();
}
