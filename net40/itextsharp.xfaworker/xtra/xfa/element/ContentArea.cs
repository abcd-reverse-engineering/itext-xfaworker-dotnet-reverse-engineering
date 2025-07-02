// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.element.ContentArea
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.tool.xml.xtra.xfa.js;
using iTextSharp.tool.xml.xtra.xfa.util;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.element;

public class ContentArea : JsNode
{
  protected Tag template;
  protected XFARectangle contentArea;
  protected PageArea pageArea;
  protected bool used;

  public ContentArea(Tag templateTag, JsNode parent)
    : base(templateTag, parent, nameof (contentArea))
  {
    this.template = templateTag;
    this.contentArea = XFAUtil.ExtractRectangleFromAttributes(templateTag.Attributes);
  }

  public virtual Tag Template => this.template;

  public virtual string Id => this.GetStringProperty("id");

  public virtual XFARectangle Rect => this.contentArea;

  public virtual PageArea PageArea
  {
    get => this.pageArea;
    set => this.pageArea = value;
  }

  public virtual bool Used
  {
    get => this.used;
    set => this.used = value;
  }
}
