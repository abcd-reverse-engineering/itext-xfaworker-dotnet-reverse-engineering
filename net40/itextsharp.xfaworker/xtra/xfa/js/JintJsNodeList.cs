// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.js.JintJsNodeList
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.tool.xml.xtra.xfa.positioner;
using iTextSharp.tool.xml.xtra.xfa.tags;
using Jint.Delegates;
using Jint.Native;
using System.Collections.Generic;
using System.Text.RegularExpressions;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.js;

public class JintJsNodeList : JsArray
{
  private readonly IGlobal global;
  protected SubFormPositioner currentNode;

  public JintJsNodeList(IGlobal global)
    : base(global.ArrayClass.PrototypeProperty)
  {
    this.global = global;
    this.DefineOwnProperty("item", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new JintFunc<JsDictionaryObject, JsInstance[], JsInstance>(this.ItemJsFunc), 1), PropertyAttributes.DontEnum);
    this.DefineOwnProperty("append", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new JintFunc<JsDictionaryObject, JsInstance[], JsInstance>(this.AppendJsFunc), 1), PropertyAttributes.DontEnum);
    this.DefineOwnProperty((Descriptor) new PropertyDescriptor<JintJsNodeList>(global, (JsDictionaryObject) this, "instanceManager", new JintFunc<JintJsNodeList, JsInstance>(this.InstanceManagerJsProp)));
  }

  public JintJsNodeList(IGlobal global, object[] objects)
    : this(global)
  {
    foreach (object objectValue in objects)
      this.put(this.Length, (JsInstance) JintJsObject.Wrap(global, objectValue));
    if (objects.Length <= 0 || !(objects[0] is SubFormPositioner))
      return;
    this.currentNode = (SubFormPositioner) objects[0];
  }

  public virtual JsInstance ItemJsFunc(JsDictionaryObject target, JsInstance[] parameters)
  {
    return this[parameters[0]];
  }

  public virtual object GetItem(int i) => (object) this.get(i);

  public virtual JsInstance AppendJsFunc(JsDictionaryObject target, JsInstance[] parameters)
  {
    this.Append((object) parameters[0]);
    return (JsInstance) JsNull.Instance;
  }

  public virtual void Append(object obj)
  {
    long length = (long) this.Length;
    this.put(this.Length, (JsInstance) JintJsObject.Wrap(this.global, obj));
    if (length != 0L || !(obj is SubFormPositioner))
      return;
    this.currentNode = (SubFormPositioner) obj;
  }

  public virtual void Insert(int index, object obj)
  {
    if (index < this.Length)
    {
      for (int length = this.Length; length > index; --length)
        this.put(length, (JsInstance) JintJsObject.Wrap(this.global, this.GetItem(length - 1)));
      this.put(index, (JsInstance) JintJsObject.Wrap(this.global, obj));
    }
    this.put(index, (JsInstance) JintJsObject.Wrap(this.global, obj));
  }

  public virtual object InstanceManager
  {
    get => this.currentNode != null ? this.currentNode.GetInstanceManager() : (object) null;
  }

  private JsInstance InstanceManagerJsProp(JintJsNodeList target)
  {
    return (JsInstance) JintJsObject.Wrap(this.global, this.InstanceManager);
  }

  public override double ToNumber()
  {
    JsNode jsNode = (JsNode) null;
    string somExpressions = (string) null;
    if (this.Length > 1)
    {
      for (int i = 0; i < this.Length; ++i)
      {
        object obj = this.GetItem(i);
        if (obj is JsNode)
        {
          string input = (string) ((JsTree) obj).SomExpression;
          if (input != null && Regex.IsMatch(input, "^.*\\[\\d+\\]$"))
          {
            int startIndex = input.LastIndexOf(".") + 1;
            input = input.Substring(startIndex, input.LastIndexOf("[") - startIndex);
          }
          if (i == 0)
          {
            somExpressions = input;
            jsNode = (JsNode) ((JsTree) obj).Parent;
            continue;
          }
          if (somExpressions.Equals(input))
            continue;
        }
        jsNode = (JsNode) null;
        somExpressions = (string) null;
        break;
      }
      if (somExpressions != null && jsNode != null && jsNode is Positioner && ((Positioner) jsNode).FlattenerContext.CurrentNode != null)
        return ((Positioner) jsNode).FlattenerContext.CurrentNode.ResolveNode(somExpressions).ToNumber();
    }
    return base.ToNumber();
  }

  public virtual int IndexOfCompareReferences(JsInstance obj)
  {
    foreach (KeyValuePair<int, JsInstance> keyValuePair in this.m_data)
    {
      if (keyValuePair.Value == obj)
        return keyValuePair.Key;
    }
    return -1;
  }

  public override JsInstance this[string s]
  {
    set
    {
      for (int i = 0; i < this.Length; ++i)
      {
        if (!"readOnly".Equals(((IFormNode) this.GetItem(i)).RetrieveAttribute("access")))
        {
          ((JsDictionaryObject) this.GetItem(i))[s] = value;
          break;
        }
      }
    }
  }

  public override bool TryGetProperty(string name, out JsInstance result)
  {
    JsInstance result1;
    bool property = base.TryGetProperty(name, out result1);
    if (result1 == JsUndefined.Instance && this.Length > 0)
    {
      object obj = (object) this.get(0);
      if (obj is JsDictionaryObject)
      {
        result = ((JsDictionaryObject) obj)[name];
        return result != JsUndefined.Instance;
      }
    }
    result = result1;
    return property;
  }
}
