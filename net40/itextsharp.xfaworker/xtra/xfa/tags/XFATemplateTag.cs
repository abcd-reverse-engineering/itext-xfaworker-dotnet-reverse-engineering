// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.tags.XFATemplateTag
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.text;
using iTextSharp.tool.xml.xtra.xfa.util;
using System.Collections.Generic;
using System.util;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.tags;

public class XFATemplateTag : Tag, IFormNode
{
  private IList<string> content;
  private IList<IElement> richText;
  private string dataRef;
  private string fullDataRef;
  private int minOccur = 1;
  private int maxOccur = 1;
  private int initialOccur = 1;
  private Tag bind;

  public XFATemplateTag(string tag, IDictionary<string, string> attr, string ns)
    : base(tag, attr, ns)
  {
    if (!Util.EqualsIgnoreCase("pageArea", tag) && !Util.EqualsIgnoreCase("pageSet", tag))
      return;
    this.maxOccur = int.MaxValue;
  }

  public XFATemplateTag(string tag)
    : this(tag, (IDictionary<string, string>) new Dictionary<string, string>(), "")
  {
  }

  public virtual void AddContent(string content)
  {
    if (this.content == null)
      this.content = (IList<string>) new List<string>();
    this.content.Add(content);
  }

  public virtual IList<string> Content => this.content;

  public virtual IList<IElement> RichText
  {
    get => this.richText;
    set => this.richText = value;
  }

  public virtual string DataRef
  {
    get => this.dataRef;
    set => this.dataRef = value;
  }

  public virtual string FullDataRef
  {
    get => this.fullDataRef;
    set => this.fullDataRef = value;
  }

  public virtual int MinOccur
  {
    get => this.minOccur;
    set => this.minOccur = value;
  }

  public virtual int MaxOccur
  {
    get => this.maxOccur;
    set => this.maxOccur = value;
  }

  public virtual int InitialOccur => this.initialOccur;

  public virtual Tag Bind
  {
    get => this.bind;
    set => this.bind = value;
  }

  public virtual void AddChild(Tag t)
  {
    base.AddChild(t);
    if ("occur".Equals(t.Name))
      this.RetrieveOccurence(this);
    if (this.bind != null || !"bind".Equals(t.Name))
      return;
    this.bind = t;
  }

  public virtual bool IsHidden()
  {
    IDictionary<string, string> attributes = this.Attributes;
    string str = (string) null;
    attributes?.TryGetValue("presence", out str);
    return attributes != null && str != null && "hidden".Equals(str);
  }

  private void RetrieveOccurence(XFATemplateTag subForm)
  {
    Tag child = subForm.GetChild("occur", "", false);
    if (child == null)
      return;
    IDictionary<string, string> attributes = child.Attributes;
    string s1;
    attributes.TryGetValue("min", out s1);
    int? nullable1 = XFAUtil.ParseInt(s1);
    if (nullable1.HasValue)
    {
      this.minOccur = nullable1.Value;
      if (!Util.EqualsIgnoreCase("pageArea", this.Name))
        this.maxOccur = this.minOccur > 0 ? this.minOccur : 1;
      this.initialOccur = this.minOccur;
    }
    string s2;
    attributes.TryGetValue("max", out s2);
    int? nullable2 = XFAUtil.ParseInt(s2);
    if (nullable2.HasValue)
      this.maxOccur = nullable2.Value;
    string s3;
    attributes.TryGetValue("initial", out s3);
    int? nullable3 = XFAUtil.ParseInt(s3);
    if (nullable3.HasValue)
      this.initialOccur = nullable3.Value;
    if (this.maxOccur != -1)
      return;
    this.maxOccur = int.MaxValue;
  }

  public virtual IFormNode RetrieveChild(string name) => (IFormNode) this.GetChild(name, "");

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

  public virtual IFormNode RetrieveLastChild(string name)
  {
    for (int index = this.Children.Count - 1; index >= 0; --index)
    {
      Tag child = this.Children[index];
      if (child.Name.Equals(name))
        return (IFormNode) child;
    }
    return (IFormNode) null;
  }

  public virtual IList<IFormNode> RetrieveChildren()
  {
    IList<IFormNode> formNodeList = (IList<IFormNode>) new List<IFormNode>();
    foreach (Tag child in (IEnumerable<Tag>) this.Children)
      formNodeList.Add((IFormNode) child);
    return formNodeList;
  }

  public virtual IList<IFormNode> RetrieveChildren(string name)
  {
    IList<IFormNode> formNodeList = (IList<IFormNode>) new List<IFormNode>();
    foreach (Tag child in (IEnumerable<Tag>) this.GetChildren(name))
      formNodeList.Add((IFormNode) child);
    return formNodeList;
  }

  public virtual string RetrieveName() => this.Name;

  public virtual IDictionary<string, string> RetrieveAttributes() => this.Attributes;

  public virtual string RetrieveAttribute(string attributeName)
  {
    if (this.Attributes == null)
      return (string) null;
    string str;
    return !this.Attributes.TryGetValue(attributeName, out str) ? (string) null : str;
  }

  public virtual IFormNode RetrieveParent() => (IFormNode) this.Parent;

  public virtual string RetrieveValue()
  {
    string str = (string) null;
    IList<string> content = this.Content;
    if (content != null && content.Count > 0)
      str = content[0];
    return str;
  }

  public virtual IList<IElement> RetrieveRichText() => this.RichText;

  public virtual IList<string> RetrieveContent() => this.Content;

  public virtual string ClassName => this.Name;

  public virtual string RetrieveTagName() => this.Name;
}
