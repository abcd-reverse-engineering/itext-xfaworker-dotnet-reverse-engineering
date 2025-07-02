// Decompiled with JetBrains decompiler
// Type: Jint.PropertyBags.ScopedPropertyBag
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using Jint.Native;
using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace Jint.PropertyBags;

public class ScopedPropertyBag : 
  IPropertyBag,
  IEnumerable<KeyValuePair<string, Descriptor>>,
  IEnumerable
{
  private Dictionary<string, Stack<Descriptor>> bag = new Dictionary<string, Stack<Descriptor>>();
  private Stack<List<Stack<Descriptor>>> scopes = new Stack<List<Stack<Descriptor>>>();
  private List<Stack<Descriptor>> currentScope;

  public void EnterScope()
  {
    this.currentScope = new List<Stack<Descriptor>>();
    this.scopes.Push(this.currentScope);
  }

  public void ExitScope()
  {
    foreach (Stack<Descriptor> descriptorStack in this.currentScope)
      descriptorStack.Pop();
    this.scopes.Pop();
    this.currentScope = this.scopes.Peek();
  }

  public Descriptor Put(string name, Descriptor descriptor)
  {
    Stack<Descriptor> descriptorStack;
    if (!this.bag.TryGetValue(name, out descriptorStack))
    {
      descriptorStack = new Stack<Descriptor>();
      this.bag.Add(name, descriptorStack);
    }
    descriptorStack.Push(descriptor);
    this.currentScope.Add(descriptorStack);
    return descriptor;
  }

  public void Delete(string name)
  {
    Stack<Descriptor> descriptorStack;
    if (!this.bag.TryGetValue(name, out descriptorStack) || !this.currentScope.Contains(descriptorStack))
      return;
    descriptorStack.Pop();
    this.currentScope.Remove(descriptorStack);
  }

  public Descriptor Get(string name)
  {
    Stack<Descriptor> descriptorStack;
    if (!this.bag.TryGetValue(name, out descriptorStack))
      return (Descriptor) null;
    return descriptorStack.Count <= 0 ? (Descriptor) null : descriptorStack.Peek();
  }

  public bool TryGet(string name, out Descriptor descriptor)
  {
    descriptor = this.Get(name);
    return descriptor != null;
  }

  public int Count => this.bag.Count;

  public IEnumerable<Descriptor> Values => throw new NotImplementedException();

  public IEnumerator<KeyValuePair<string, Descriptor>> GetEnumerator()
  {
    throw new NotImplementedException();
  }

  IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();
}
