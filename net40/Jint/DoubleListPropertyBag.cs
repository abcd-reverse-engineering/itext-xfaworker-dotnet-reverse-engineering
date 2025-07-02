// Decompiled with JetBrains decompiler
// Type: Jint.DoubleListPropertyBag
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using Jint.Native;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace Jint;

internal class DoubleListPropertyBag : 
  IPropertyBag,
  IEnumerable<KeyValuePair<string, Descriptor>>,
  IEnumerable
{
  private IList<string> keys;
  private IList<Descriptor> values;

  public DoubleListPropertyBag()
  {
    this.keys = (IList<string>) new List<string>(5);
    this.values = (IList<Descriptor>) new List<Descriptor>(5);
  }

  public Descriptor Put(string name, Descriptor descriptor)
  {
    lock (this.keys)
    {
      this.keys.Add(name);
      this.values.Add(descriptor);
    }
    return descriptor;
  }

  public void Delete(string name)
  {
    int index = this.keys.IndexOf(name);
    this.keys.RemoveAt(index);
    this.values.RemoveAt(index);
  }

  public Descriptor Get(string name) => this.values[this.keys.IndexOf(name)];

  public bool TryGet(string name, out Descriptor descriptor)
  {
    int index = this.keys.IndexOf(name);
    if (index < 0)
    {
      descriptor = (Descriptor) null;
      return false;
    }
    descriptor = this.values[index];
    return true;
  }

  public int Count => this.keys.Count;

  public IEnumerable<Descriptor> Values => (IEnumerable<Descriptor>) this.values;

  public IEnumerator<KeyValuePair<string, Descriptor>> GetEnumerator()
  {
    for (int i = 0; i < this.keys.Count; ++i)
      yield return new KeyValuePair<string, Descriptor>(this.keys[i], this.values[i]);
  }

  IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();
}
