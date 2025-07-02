// Decompiled with JetBrains decompiler
// Type: Jint.IPropertyBag
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using Jint.Native;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace Jint;

public interface IPropertyBag : IEnumerable<KeyValuePair<string, Descriptor>>, IEnumerable
{
  Descriptor Put(string name, Descriptor descriptor);

  void Delete(string name);

  Descriptor Get(string name);

  bool TryGet(string name, out Descriptor descriptor);

  int Count { get; }

  IEnumerable<Descriptor> Values { get; }
}
