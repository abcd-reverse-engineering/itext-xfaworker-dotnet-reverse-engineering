// Decompiled with JetBrains decompiler
// Type: Jint.PropertyBags.HashedPropertyBag
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using Jint.Native;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace Jint.PropertyBags;

public class HashedPropertyBag : 
  IPropertyBag,
  IEnumerable<KeyValuePair<string, Descriptor>>,
  IEnumerable
{
  private Hashtable keys;

  public HashedPropertyBag() => this.keys = new Hashtable();

  public Descriptor Put(string name, Descriptor descriptor)
  {
    this.keys.Add((object) name, (object) descriptor);
    return descriptor;
  }

  public void Delete(string name) => this.keys.Remove((object) name);

  public Descriptor Get(string name) => this.keys[(object) name] as Descriptor;

  public bool TryGet(string name, out Descriptor descriptor)
  {
    descriptor = this.Get(name);
    return descriptor != null;
  }

  public int Count => this.keys.Count;

  public IEnumerable<Descriptor> Values
  {
    get
    {
      foreach (DictionaryEntry de in this.keys)
        yield return de.Value as Descriptor;
    }
  }

  public IEnumerator<KeyValuePair<string, Descriptor>> GetEnumerator()
  {
    foreach (DictionaryEntry de in this.keys)
      yield return new KeyValuePair<string, Descriptor>(de.Key as string, de.Value as Descriptor);
  }

  IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();
}
