// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.tags.DataTag
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.text;
using iTextSharp.tool.xml.xtra.xfa.js;
using System.Collections.Generic;
using System.util.collections;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.tags;

public class DataTag : Tag
{
  private string value = "";
  private HashSet2<XFATemplateTag> usedBy = new HashSet2<XFATemplateTag>();
  private IList<IElement> richText;
  private string canonizationPattern;
  private JsNode node;
  private bool fictive;

  public DataTag(string tag)
    : base(tag)
  {
  }

  public DataTag(string tag, IDictionary<string, string> attr)
    : base(tag, attr)
  {
  }

  public DataTag(string key, string value)
    : base(key)
  {
    this.value = value;
  }

  public static DataTag CreateEmpty() => new DataTag("");

  public virtual string Value
  {
    get => this.value;
    set => this.value = value;
  }

  public virtual JsNode Node
  {
    get => this.node;
    set => this.node = value;
  }

  public virtual string CanonizationPattern
  {
    get => this.canonizationPattern;
    set => this.canonizationPattern = value;
  }

  public virtual bool IsUsedBy(XFATemplateTag templateTag)
  {
    return templateTag != null && this.usedBy.Contains(templateTag);
  }

  public virtual void AddUsedBy(XFATemplateTag templateTag)
  {
    if (templateTag == null)
      return;
    this.usedBy.Add(templateTag);
  }

  public virtual void RemoveUsedBy(XFATemplateTag templateTag)
  {
    if (templateTag == null)
      return;
    this.usedBy.Remove(templateTag);
  }

  public virtual bool IsUsedByAnyoneExcept(params XFATemplateTag[] except)
  {
    return this.usedBy.Count > except.Length;
  }

  public virtual IList<IElement> RichText
  {
    get => this.richText;
    set => this.richText = value;
  }

  public virtual bool Fictive => this.fictive;

  public virtual void SetFictive() => this.fictive = true;
}
