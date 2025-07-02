// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.js.JsNode
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.text;
using iTextSharp.tool.xml.xtra.xfa.element;
using iTextSharp.tool.xml.xtra.xfa.positioner;
using iTextSharp.tool.xml.xtra.xfa.tags;
using Jint;
using Jint.Delegates;
using Jint.Native;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.js;

public class JsNode : JsTree, IFormNode
{
  public static Tag UNIVERSAL_PROTOTYPE_ROOT;
  protected Tag tag;
  protected Tag protoTemplate;
  protected IDictionary<Tag, JsInstanceManager> instanceManagerByTemplate = (IDictionary<Tag, JsInstanceManager>) new Dictionary<Tag, JsInstanceManager>();
  private List<JsNode> addAfterMeList;

  static JsNode()
  {
    try
    {
      JsNode.UNIVERSAL_PROTOTYPE_ROOT = XFAWorker.ParseTemplatePart(ResourceUtil.GetResourceStream("iTextSharp.tool.xml.xtra.xfa.js.prototype.xml"), Encoding.UTF8);
    }
    catch (Exception ex)
    {
    }
  }

  internal JsNode(JsTree prototype, string className = "node")
    : base((JintJsObject) prototype, className)
  {
    this.DefineOwnProperty((Descriptor) new PropertyDescriptor<JsNode>((Jint.Native.IGlobal) this.IGlobal, (JsDictionaryObject) this, "isNull", new JintFunc<JsNode, JsInstance>(this.IsNullJsProp)));
    this.DefineOwnProperty((Descriptor) new PropertyDescriptor<JsNode>((Jint.Native.IGlobal) this.IGlobal, (JsDictionaryObject) this, "isContainer", new JintFunc<JsNode, JsInstance>(this.IsContainerJsProp)));
    this.DefineOwnProperty((Descriptor) new PropertyDescriptor<JsNode>((Jint.Native.IGlobal) this.IGlobal, (JsDictionaryObject) this, "oneOfChild", new JintFunc<JsNode, JsInstance>(this.GetOneChildJs), new JintFunc<JsNode, JsInstance[], JsInstance>(this.SetOneChildJs)));
    this.DefineProperty("loadXML", (object) this.IGlobal.FunctionClass.New<JsNode>(new JintFunc<JsNode, JsInstance[], JsInstance>(this.LoadXmlJsFunc), 1));
    this.DefineProperty("isPropertySpecified", (object) this.IGlobal.FunctionClass.New<JsNode>(new JintFunc<JsNode, JsInstance[], JsInstance>(this.IsPropertySpecifiedJsFunc), 1));
  }

  public JsNode(string className)
    : base(className ?? (className = "node"), (JsTree) null)
  {
  }

  private void ConstructFromTag(Tag tag, JsNode parent)
  {
    this.tag = tag;
    if (parent != null)
    {
      this.flattenerContext = parent.flattenerContext;
      if (parent.protoTemplate != null)
        this.protoTemplate = parent.protoTemplate.GetChild(tag.Name, "");
    }
    string str = (string) null;
    if (tag.Attributes.TryGetValue("name", out str) && !string.IsNullOrEmpty(str))
      this.DefineProperty("name", (object) str);
    foreach (KeyValuePair<string, string> attribute in (IEnumerable<KeyValuePair<string, string>>) tag.Attributes)
      this.DefineProperty(attribute.Key, (object) attribute.Value);
  }

  public override void DefineOwnProperty(Descriptor currentDescriptor)
  {
    base.DefineOwnProperty(currentDescriptor);
    this.PutCallback(currentDescriptor.Name, currentDescriptor is ValueDescriptor ? currentDescriptor.Get((JsDictionaryObject) this) : (JsInstance) null);
  }

  public override JsInstance this[string index]
  {
    set
    {
      base[index] = value;
      this.PutCallback(index, value);
    }
  }

  protected virtual void PutCallback(string name, JsInstance value)
  {
    if (this.flattenerContext == null || !this.flattenerContext.ValidateLayout)
      return;
    JsTree jsTree = (JsTree) this;
    while (true)
    {
      switch (jsTree)
      {
        case null:
        case Positioner _:
          goto label_4;
        default:
          jsTree = jsTree.Parent;
          continue;
      }
    }
label_4:
    if (jsTree == null)
      return;
    if (name.Equals("presence"))
      this.flattenerContext.DomPositioner.LayoutOutOfDate = true;
    else
      ((Positioner) jsTree).LayoutOutOfDate = true;
  }

  public JsNode(Tag tag, JsNode parent, JsNode prototype)
    : base((JsTree) prototype, (JsTree) parent)
  {
    this.ConstructFromTag(tag, parent);
    if (tag.Name.Equals(prototype.RetrieveAttribute("className")))
      return;
    this.DefineConstantProperty("className", (object) tag.Name);
  }

  public JsNode(JsNode parent, JsNode prototype)
    : base((JsTree) prototype, (JsTree) parent)
  {
  }

  public JsNode(Tag tag, JsNode parent, string prototypeName)
    : base(prototypeName, (JsTree) parent)
  {
    this.ConstructFromTag(tag, parent);
    if (tag.Name.Equals(prototypeName))
      return;
    this.DefineConstantProperty("className", (object) tag.Name);
  }

  public JsNode(Tag tag, JsNode parent)
    : this(tag, parent, "node")
  {
  }

  public JsNode(string name, JsNode parent)
    : base("node", (JsTree) parent)
  {
    this.tag = (Tag) null;
    if (parent != null && parent.protoTemplate != null)
    {
      this.protoTemplate = parent.protoTemplate.GetChild(name, "");
      this.flattenerContext = parent.flattenerContext;
    }
    if (name == null)
      return;
    this.DefineProperty(nameof (name), (object) name);
  }

  public override bool TryGetProperty(string name, out JsInstance result)
  {
    JsInstance result1;
    bool property = base.TryGetProperty(name, out result1);
    if (!this.HasOwnProperty(name) && !"event".Equals(name))
    {
      Tag child;
      if (this.tag != null && (child = this.tag.GetChild(name, "")) != null)
      {
        result = (JsInstance) this.AddChild(child, true);
        if (result != null)
          return true;
      }
      result = this.GetPrototypeObject(name);
      if (result != null)
        return true;
    }
    result = result1;
    return property;
  }

  protected virtual JsInstance GetPrototypeObject(string name)
  {
    Tag child1;
    if (this.protoTemplate == null || (child1 = this.protoTemplate.GetChild(name, "")) == null)
      return (JsInstance) null;
    JsNode child2 = !"occur".Equals(name) || !(this is Positioner) ? new JsNode(child1.Name, this) : (JsNode) new JsOccur((Positioner) this);
    this.AddChild((JsTree) child2);
    return (JsInstance) child2;
  }

  public virtual bool IsNull()
  {
    object obj;
    if (this.HasOwnProperty("rawValue"))
    {
      JsInstance result;
      this.TryGetProperty("rawValue", out result);
      obj = JintJsObject.Unwrap((object) result);
    }
    else
      obj = this.GetOwnProperty("value");
    return obj == null || string.IsNullOrEmpty(obj.ToString());
  }

  private JsInstance IsNullJsProp(JsNode target)
  {
    return (JsInstance) this.IGlobal.BooleanClass.New(target.IsNull());
  }

  public virtual bool IsContainer() => this is SubFormPositioner;

  private JsInstance IsContainerJsProp(JsNode target)
  {
    return (JsInstance) this.IGlobal.BooleanClass.New(target.IsContainer());
  }

  public virtual bool IsPropertySpecified(string propertyName)
  {
    return this.RetrieveAttribute(propertyName) != null;
  }

  private JsInstance IsPropertySpecifiedJsFunc(JsNode target, JsInstance[] parameters)
  {
    return (JsInstance) this.IGlobal.BooleanClass.New(target.IsPropertySpecified(parameters[0].ToString()));
  }

  public virtual JsNode GetOneChild()
  {
    IList<IFormNode> formNodeList = this.RetrieveChildren();
    return formNodeList.Count != 1 || !(formNodeList[0] is JsNode) ? (JsNode) null : (JsNode) formNodeList[0];
  }

  private JsInstance GetOneChildJs(JsNode target) => (JsInstance) target.GetOneChild();

  private JsInstance SetOneChildJs(JsNode target, JsInstance[] parameters)
  {
    throw new JintException("Not implemented");
  }

  public void LoadXML(string xml, bool ignoreRootNode, bool overrideCurrentInformation)
  {
    if ("exData".Equals(this.RetrieveName()))
    {
      try
      {
        XFAWorker.RichTextParseResult richTextPart = XFAWorker.ParseRichTextPart((Stream) new MemoryStream(Encoding.UTF8.GetBytes(xml)), this.flattenerContext.FontProvider, Encoding.UTF8);
        Tag richTextRootTag = richTextPart.RichTextRootTag;
        IList<IElement> richTextElements = richTextPart.RichTextElements;
        ((XFATemplateTag) this.tag).RichText = richTextElements;
        ((Positioner) this.Parent.Parent).SetRawValue((object) richTextElements);
        this.tag.Children.Clear();
        this.tag.Children.Add(richTextRootTag);
        this.Delete(richTextRootTag.Name);
        this.Delete("nodes");
        this.AddChild(richTextRootTag);
      }
      catch (Exception ex)
      {
      }
    }
    else
    {
      try
      {
        Tag templatePart = XFAWorker.ParseTemplatePart((Stream) new MemoryStream(Encoding.UTF8.GetBytes(xml)), Encoding.UTF8);
        if (!"image".Equals(templatePart.Name) || !"value".Equals(this.RetrieveName()))
          return;
        templatePart.Parent = this.tag;
        this.tag.Children.Clear();
        this.tag.Children.Add(templatePart);
        this.Delete(templatePart.Name);
        this.Delete("nodes");
        this.AddChild(templatePart);
        if (!(this.Parent is ContentPositioner))
          return;
        ((ContentPositioner) this.Parent).InitValues();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }
    }
  }

  private JsInstance LoadXmlJsFunc(JsNode target, JsInstance[] parameters)
  {
    bool boolean1 = this.ConvertParameterToBoolean(parameters, 1);
    bool boolean2 = this.ConvertParameterToBoolean(parameters, 2);
    target.LoadXML(parameters[0].ToString(), boolean1, boolean2);
    return (JsInstance) JsNull.Instance;
  }

  private bool ConvertParameterToBoolean(JsInstance[] parameters, int index)
  {
    if (parameters.Length >= index + 1)
    {
      try
      {
        if (parameters[index] is JsBoolean parameter)
          return parameter.ToBoolean();
      }
      catch (FormatException ex)
      {
        return false;
      }
    }
    return false;
  }

  public virtual JsNode AddChild(Tag tag, bool addAllChildren)
  {
    string name = tag.Name;
    JsNode child = (JsNode) null;
    if ("text".Equals(name) || "script".Equals(name) || "image".Equals(name))
    {
      child = (JsNode) new JsContent(tag, this, (JsNode) this.IGlobal.JintJsXfaElementConstructor.GetXfaPrototype(name));
      if ("text".Equals(name) && this is JsValueNode && this.GetParentNode() is ContentPositioner)
        child.DefineProperty("value", ((Positioner) this.GetParentNode()).GetRawValue());
    }
    else if (addAllChildren && "value".Equals(name) && this is ContentPositioner)
      child = (JsNode) new JsValueNode(tag, this);
    else if ("contentArea".Equals(name))
      child = (JsNode) new ContentArea(tag, this);
    else if ("caption".Equals(name))
    {
      child = (JsNode) new CaptionElement(tag, this);
    }
    else
    {
      JsNode prototype = (JsNode) this.IGlobal.JintJsXfaElementConstructor.GetXfaPrototype(name);
      if (name.Equals("proto"))
        addAllChildren = true;
      else if (prototype == null && addAllChildren)
        prototype = this.IGlobal.JintJsXfaElementConstructor.JsNodeObject;
      else if (prototype == null && tag.Attributes.ContainsKey("id"))
      {
        addAllChildren = true;
        prototype = this.IGlobal.JintJsXfaElementConstructor.JsNodeObject;
      }
      if (prototype != null)
        child = new JsNode(tag, this, prototype);
    }
    if (child != null)
    {
      foreach (Tag tag1 in tag)
      {
        if ("variables".Equals(name))
        {
          this.AddVariable(tag1);
          child.AddVariable(tag1);
        }
        else
          child.AddChild(tag1, addAllChildren);
      }
      if (addAllChildren && !child.Tag.Attributes.ContainsKey("name"))
        child.DefineProperty("name", (object) name);
      this.AddChild((JsTree) child);
    }
    return child;
  }

  public virtual void AddChild(Tag tag) => this.AddChild(tag, false);

  public virtual void AddVariable(Tag variableTag)
  {
    if ("text".Equals(variableTag.Name))
      this.AddChild((JsTree) new JsContent(variableTag, this, (JsNode) this.IGlobal.JintJsXfaElementConstructor.TextJsObject));
    else if ("script".Equals(variableTag.Name))
    {
      this.AddChild((JsTree) new JsScript(variableTag, this, (JsNode) this.IGlobal.JintJsXfaElementConstructor.ScriptJsObject));
    }
    else
    {
      if (!"manifest".Equals(variableTag.Name))
        return;
      this.AddChild((JsTree) new JsManifest(variableTag, this));
    }
  }

  public virtual JintJsNodeList GetNodes()
  {
    object ownProperty = this.GetOwnProperty("nodes");
    return ownProperty is JintJsNodeList ? (JintJsNodeList) ownProperty : (JintJsNodeList) null;
  }

  public virtual JsNode GetChild(string name)
  {
    object ownProperty = this.GetOwnProperty(name);
    switch (ownProperty)
    {
      case JsNode _:
        return (JsNode) ownProperty;
      case JintJsNodeList _:
        if (((JsDictionaryObject) ownProperty).Length > 0)
        {
          object child = ((JintJsNodeList) ownProperty).GetItem(0);
          if (child is JsNode)
            return (JsNode) child;
          break;
        }
        break;
    }
    return (JsNode) null;
  }

  public virtual Tag Tag => this.tag;

  public virtual JsNode GetParentNode()
  {
    return this.Parent is JsNode ? (JsNode) this.Parent : (JsNode) null;
  }

  public virtual void AddAfterMe(JsNode node)
  {
    if (this.addAfterMeList == null)
      this.addAfterMeList = new List<JsNode>();
    this.addAfterMeList.Add(node);
  }

  public override void AddChild(JsTree child)
  {
    base.AddChild(child);
    if (!(child is JsNode) || ((JsNode) child).addAfterMeList == null)
      return;
    foreach (JsTree addAfterMe in ((JsNode) child).addAfterMeList)
      this.AddChild(addAfterMe);
    ((JsNode) child).addAfterMeList.Clear();
    ((JsNode) child).addAfterMeList = (List<JsNode>) null;
  }

  public virtual IFormNode RetrieveChild(string name)
  {
    IFormNode formNode;
    return !this.HasOwnProperty(name) && this.tag is XFATemplateTag && (formNode = ((XFATemplateTag) this.tag).RetrieveLastChild(name)) != null ? formNode : (IFormNode) this.GetChild(name);
  }

  public virtual IFormNode RetrieveChild(params string[] path)
  {
    IFormNode formNode = (IFormNode) this;
    foreach (string name in path)
    {
      formNode = formNode.RetrieveChild(name);
      if (formNode == null)
        break;
    }
    return formNode;
  }

  public virtual IList<IFormNode> RetrieveChildren()
  {
    JintJsNodeList nodes = this.GetNodes();
    int length = nodes != null ? nodes.Length : 0;
    List<IFormNode> formNodeList = new List<IFormNode>(length);
    for (int i = 0; i < length; ++i)
      formNodeList.Add((IFormNode) nodes.get(i));
    return (IList<IFormNode>) formNodeList;
  }

  public virtual IList<IFormNode> RetrieveChildren(string name)
  {
    JintJsNodeList nodes = this.GetNodes();
    int length = nodes != null ? nodes.Length : 0;
    IList<IFormNode> formNodeList = (IList<IFormNode>) new List<IFormNode>();
    for (int i = 0; i < length; ++i)
    {
      object obj = (object) nodes.get(i);
      if (((JsTree) obj).RetrieveName().Equals(name))
        formNodeList.Add((IFormNode) obj);
    }
    return formNodeList;
  }

  public override string RetrieveName()
  {
    string str = this.GetStringProperty("name");
    if (str == null && this.tag != null)
      this.tag.Attributes.TryGetValue("name", out str);
    if (str == null && this.tag != null)
      str = this.tag.Name;
    return str;
  }

  public virtual IDictionary<string, string> RetrieveAttributes()
  {
    IDictionary<string, string> dictionary = (IDictionary<string, string>) new Dictionary<string, string>();
    foreach (KeyValuePair<string, JsInstance> keyValuePair in (JsDictionaryObject) this)
    {
      object obj = JintJsObject.Unwrap((object) keyValuePair.Value);
      if (obj is string)
        dictionary[keyValuePair.Key] = obj.ToString();
    }
    return dictionary;
  }

  public virtual string RetrieveAttribute(string attributeName)
  {
    object obj = this.HasOwnProperty(attributeName) ? JintJsObject.Unwrap((object) this[attributeName]) : (object) null;
    return obj is string ? (string) obj : (string) null;
  }

  public virtual IFormNode RetrieveParent() => (IFormNode) this.Parent;

  public virtual string RetrieveValue() => this.GetStringProperty("value");

  public virtual IList<IElement> RetrieveRichText()
  {
    return this.tag is XFATemplateTag ? ((XFATemplateTag) this.tag).RichText : (IList<IElement>) null;
  }

  public virtual IList<string> RetrieveContent()
  {
    return (IList<string>) new ReadOnlyCollection<string>((IList<string>) new string[1]
    {
      this.RetrieveValue()
    });
  }

  public virtual bool IsHidden()
  {
    object obj = (object) this.RetrieveAttribute("presence");
    return obj != null && obj.ToString().Equals("hidden");
  }

  public virtual bool IsInactive()
  {
    object obj = (object) this.RetrieveAttribute("presence");
    return obj != null && obj.ToString().Equals("inactive");
  }

  public JsInstanceManager GetInstanceManagerByTemplate(Tag templateTag)
  {
    JsInstanceManager managerByTemplate;
    this.instanceManagerByTemplate.TryGetValue(templateTag, out managerByTemplate);
    return managerByTemplate;
  }

  public void AddInstanceManagerForTemplate(Tag tag, JsInstanceManager instanceManager)
  {
    this.instanceManagerByTemplate.Add(tag, instanceManager);
  }

  public virtual Tag ProtoTemplate
  {
    set => this.protoTemplate = value;
    get => this.protoTemplate;
  }

  public virtual string RetrieveTagName() => this.tag == null ? (string) null : this.tag.Name;
}
