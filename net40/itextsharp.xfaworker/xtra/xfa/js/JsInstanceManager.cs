// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.js.JsInstanceManager
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.tool.xml.xtra.xfa.positioner;
using iTextSharp.tool.xml.xtra.xfa.resolver;
using iTextSharp.tool.xml.xtra.xfa.tags;
using Jint;
using Jint.Delegates;
using Jint.Native;
using System.Collections.Generic;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.js;

public class JsInstanceManager : JsNode
{
  protected new FlattenerContext flattenerContext;
  protected JsNode parent;
  protected XFATemplateTag template;
  protected int? count = new int?(0);

  internal JsInstanceManager(JsTree prototype, string className = "instanceManager")
    : base(prototype, className)
  {
    this.DefineOwnProperty((Descriptor) new PropertyDescriptor<JsInstanceManager>((Jint.Native.IGlobal) this.IGlobal, (JsDictionaryObject) this, "min", new JintFunc<JsInstanceManager, JsInstance>(this.MinJsProp)));
    this.DefineOwnProperty((Descriptor) new PropertyDescriptor<JsInstanceManager>((Jint.Native.IGlobal) this.IGlobal, (JsDictionaryObject) this, "max", new JintFunc<JsInstanceManager, JsInstance>(this.MaxJsProp)));
    this.DefineOwnProperty((Descriptor) new PropertyDescriptor<JsInstanceManager>((Jint.Native.IGlobal) this.IGlobal, (JsDictionaryObject) this, nameof (count), new JintFunc<JsInstanceManager, JsInstance>(this.CountJsPropGet), new JintFunc<JsInstanceManager, JsInstance[], JsInstance>(this.CountJsPropSet)));
    this.DefineProperty("addInstance", (object) this.IGlobal.FunctionClass.New<JsInstanceManager>(new JintFunc<JsInstanceManager, JsInstance[], JsInstance>(this.AddInstanceJsFunc)));
    this.DefineProperty("setInstances", (object) this.IGlobal.FunctionClass.New<JsInstanceManager>(new JintFunc<JsInstanceManager, JsInstance[], JsInstance>(this.SetInstancesJsFunc)));
    this.DefineProperty("removeInstance", (object) this.IGlobal.FunctionClass.New<JsInstanceManager>(new JintFunc<JsInstanceManager, JsInstance[], JsInstance>(this.RemoveInstanceJsFunc)));
    this.DefineProperty("insertInstance", (object) this.IGlobal.FunctionClass.New<JsInstanceManager>(new JintFunc<JsInstanceManager, JsInstance[], JsInstance>(this.InsertInstanceJsFunc)));
  }

  public JsInstanceManager(XFATemplateTag tag, JsNode parent, FlattenerContext flattenerContext)
    : base(parent, (JsNode) parent.IGlobal.JintJsXfaElementConstructor.InstanceManagerJsObject)
  {
    this.parent = parent;
    this.flattenerContext = flattenerContext;
    this.template = tag;
    string str;
    tag.Attributes.TryGetValue("name", out str);
    if (str == null)
      str = "";
    this.DefineProperty("name", (object) ("_" + str));
  }

  public override string ClassName => "instanceManager";

  public virtual int Min => this.template.MinOccur;

  private JsInstance MinJsProp(JsInstanceManager target)
  {
    return (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, (object) target.Min);
  }

  public virtual int Max => this.template.MaxOccur;

  private JsInstance MaxJsProp(JsInstanceManager target)
  {
    return (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, (object) target.Max);
  }

  public virtual int? Count => this.count;

  public int? IncCount()
  {
    JsInstanceManager jsInstanceManager = this;
    int? count;
    int? nullable = count = jsInstanceManager.count;
    jsInstanceManager.count = nullable.HasValue ? new int?(nullable.GetValueOrDefault() + 1) : new int?();
    return count;
  }

  public int? DecCount()
  {
    JsInstanceManager jsInstanceManager = this;
    int? count;
    int? nullable = count = jsInstanceManager.count;
    jsInstanceManager.count = nullable.HasValue ? new int?(nullable.GetValueOrDefault() - 1) : new int?();
    return count;
  }

  public int? ResetCount() => this.count = new int?(0);

  private JsInstance CountJsPropGet(JsInstanceManager target)
  {
    return (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, (object) target.Count);
  }

  private JsInstance CountJsPropSet(JsInstanceManager target, JsInstance[] param)
  {
    int integer = param[0].ToInteger();
    target.SetInstances(integer);
    return (JsInstance) JsNull.Instance;
  }

  public virtual void SetInstances(int instanceNumber)
  {
    if (!(this.parent is SubFormPositioner))
      return;
    int num1 = instanceNumber;
    int? count1 = this.count;
    if ((num1 >= count1.GetValueOrDefault() ? 0 : (count1.HasValue ? 1 : 0)) != 0)
    {
      for (int index = ((Positioner) this.parent).Children.Count - 1; index >= 0; --index)
      {
        if (((Positioner) this.parent).Children[index].Template == this.template)
          this.RemoveChild(index);
      }
    }
    else
    {
      int num2 = instanceNumber;
      int? count2 = this.count;
      if ((num2 <= count2.GetValueOrDefault() ? 0 : (count2.HasValue ? 1 : 0)) == 0)
        return;
      while (true)
      {
        int? count3 = this.count;
        int num3 = instanceNumber;
        if ((count3.GetValueOrDefault() >= num3 ? 0 : (count3.HasValue ? 1 : 0)) != 0)
          this.AddInstance(true);
        else
          break;
      }
    }
  }

  private JsInstance SetInstancesJsFunc(JsInstanceManager target, JsInstance[] parameters)
  {
    if (parameters.Length == 1)
      target.SetInstances(parameters[0].ToInteger());
    return (JsInstance) JsNull.Instance;
  }

  public virtual void AddInstance(bool bind)
  {
    if (!(this.parent is Positioner))
      return;
    Positioner parent = (Positioner) this.parent;
    Positioner positioner = parent;
    while (bind && positioner.Data == null && positioner.Parent != null)
      positioner = positioner.Parent;
    JsNode jsNode = this.flattenerContext.FormBuilder.AddSubformInstance(this.template, this.parent, bind ? positioner.Data : (DataTag) null);
    if (!(jsNode is Positioner))
      return;
    int index1 = parent.Children.IndexOf((Positioner) jsNode);
    if (index1 == -1)
      return;
    int num = -1;
    for (int index2 = 0; index2 < parent.Children.Count; ++index2)
    {
      Positioner child = parent.Children[index2];
      if (child.Template == this.template)
        num = index2;
      else if (num == -1)
      {
        if (((Positioner) this.parent).Template.Children.IndexOf((Tag) child.Template) > ((Positioner) this.parent).Template.Children.IndexOf((Tag) this.template))
        {
          num = index2 - 1;
          break;
        }
      }
      else
        break;
    }
    if (num == -1 || num == index1)
      return;
    parent.Children.RemoveAt(index1);
    parent.Children.Insert(index1 > num ? num + 1 : num, (Positioner) jsNode);
  }

  public virtual JsInstance AddInstanceJsFunc(JsInstanceManager target, JsInstance[] parameters)
  {
    if (parameters.Length >= 1)
      target.AddInstance(parameters[0].ToBoolean());
    else
      target.AddInstance(false);
    return (JsInstance) JsNull.Instance;
  }

  public virtual void RemoveInstance(int instanceIndex)
  {
    int? count1 = this.count;
    int minOccur = this.template.MinOccur;
    if ((count1.GetValueOrDefault() > minOccur ? 0 : (count1.HasValue ? 1 : 0)) != 0)
      throw new JintException("Operation failed. XFAObject.removeInstance. The element [min] has violated its allowable number of occurrences.");
    JsInstanceManager jsInstanceManager = this;
    int? count2 = jsInstanceManager.count;
    jsInstanceManager.count = count2.HasValue ? new int?(count2.GetValueOrDefault() - 1) : new int?();
    if (!(this.parent is Positioner))
      return;
    int num = 0;
    IList<Positioner> children = ((Positioner) this.parent).Children;
    for (int index = 0; index < children.Count; ++index)
    {
      if (children[index].Template == this.template)
      {
        if (num == instanceIndex)
        {
          this.RemoveChild(index);
          break;
        }
        ++num;
      }
    }
  }

  private JsInstance RemoveInstanceJsFunc(JsInstanceManager target, JsInstance[] parameters)
  {
    int integer = parameters.Length >= 1 ? parameters[0].ToInteger() : 0;
    target.RemoveInstance(integer);
    return (JsInstance) JsNull.Instance;
  }

  private JsInstance InsertInstanceJsFunc(JsInstanceManager target, JsInstance[] parameters)
  {
    int integer = parameters.Length >= 1 ? parameters[0].ToInteger() : 0;
    bool bind = parameters.Length >= 2 && parameters[1].ToBoolean();
    target.InsertInstance(integer, bind);
    return (JsInstance) JsNull.Instance;
  }

  public virtual void InsertInstance(int index, bool bind)
  {
    if (this.parent is Positioner)
    {
      int num1 = 0;
      int index1 = -1;
      IList<Positioner> children = ((Positioner) this.parent).Children;
      for (int index2 = 0; index2 < children.Count; ++index2)
      {
        if (children[index2].Template == this.template)
        {
          if (num1 == index)
          {
            index1 = index2;
            break;
          }
          ++num1;
        }
      }
      if (index1 == -1 && index == num1)
        index1 = children.Count;
      if (index1 < 0)
        throw new JintException("insertInstance: invalid index");
      Positioner positioner = index1 < children.Count ? children[index1] : (Positioner) null;
      Positioner dataPositioner = this.GetDataPositioner(bind);
      JsNode jsNode = this.flattenerContext.FormBuilder.AddSubformInstance(this.template, this.parent, bind ? dataPositioner.Data : (DataTag) null);
      if (jsNode == null)
        return;
      int index3 = children.IndexOf((Positioner) jsNode);
      if (index3 != -1)
        children.RemoveAt(index3);
      children.Insert(index1, (Positioner) jsNode);
      int num2 = this.parent.GetNodes().IndexOfCompareReferences((JsInstance) jsNode);
      int i1 = positioner != null ? this.parent.GetNodes().IndexOfCompareReferences((JsInstance) positioner) : this.parent.GetNodes().Length;
      if (num2 != -1 && i1 != -1)
      {
        for (int i2 = num2; i2 > i1; --i2)
          this.parent.GetNodes().put(i2, (JsInstance) this.parent.GetNodes().GetItem(i2 - 1));
        this.parent.GetNodes().put(i1, (JsInstance) jsNode);
      }
      JsInstance result;
      this.parent.TryGetProperty(jsNode.RetrieveName(), out result);
      if (result is JintJsNodeList)
      {
        if (positioner != null)
        {
          int i3 = ((JintJsNodeList) result).IndexOfCompareReferences((JsInstance) positioner);
          int num3 = ((JintJsNodeList) result).IndexOfCompareReferences((JsInstance) jsNode);
          if (i3 != -1 && num3 != -1)
          {
            for (int i4 = num3; i4 > i3; --i4)
              ((JsArray) result).put(i4, (JsInstance) ((JintJsNodeList) result).GetItem(i4 - 1));
          }
          ((JsArray) result).put(i3, (JsInstance) jsNode);
        }
        else
          ((JintJsNodeList) result).Append((object) jsNode);
      }
    }
    JsInstanceManager jsInstanceManager = this;
    int? count = jsInstanceManager.count;
    jsInstanceManager.count = count.HasValue ? new int?(count.GetValueOrDefault() + 1) : new int?();
  }

  private void RemoveChild(int index)
  {
    Positioner child = ((Positioner) this.parent).Children[index];
    ((Positioner) this.parent).RemoveChild(index);
    int num = this.parent.GetNodes().IndexOfCompareReferences((JsInstance) child);
    if (num != -1)
      this.parent.GetNodes().Delete(num.ToString());
    this.RemoveChildProperty(this.parent, child.Name, child);
  }

  private void RemoveChildProperty(JsNode parent, string childName, Positioner child)
  {
    JsInstance result;
    parent.TryGetProperty(childName, out result);
    if (result is JintJsNodeList)
    {
      JintJsNodeList jintJsNodeList1 = (JintJsNodeList) result;
      JintJsNodeList jintJsNodeList2 = new JintJsNodeList((Jint.Native.IGlobal) this.IGlobal);
      for (int i = 0; i < jintJsNodeList1.Length; ++i)
      {
        object obj = jintJsNodeList1.GetItem(i);
        if (obj != child)
          jintJsNodeList2.Append(obj);
      }
      if (jintJsNodeList2.Length >= jintJsNodeList1.Length)
        return;
      parent.Delete(childName);
      if (jintJsNodeList2.Length > 1)
      {
        parent.DefineProperty(childName, (object) jintJsNodeList2);
      }
      else
      {
        if (jintJsNodeList2.Length != 1)
          return;
        parent.DefineProperty(childName, jintJsNodeList2.GetItem(0));
      }
    }
    else
    {
      if (result != child)
        return;
      parent.Delete(childName);
    }
  }

  private Positioner GetDataPositioner(bool bind)
  {
    Positioner parent = (Positioner) this.parent;
    while (bind && parent.Data == null && parent.Parent != null)
      parent = parent.Parent;
    return parent;
  }
}
