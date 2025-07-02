// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.element.TextElement
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml.xtra.xfa.js;
using iTextSharp.tool.xml.xtra.xfa.resolver;
using iTextSharp.tool.xml.xtra.xfa.tags;
using iTextSharp.tool.xml.xtra.xfa.util;
using System.Collections.Generic;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.element;

public class TextElement : ContentElement, IContentTextElement
{
  protected TextDrawer textDrawer;

  public virtual void CreateColumnText(XFARectangle rec) => this.textDrawer.CreateColumnText(rec);

  public virtual IList<IElement> Content => this.textDrawer.GetContent();

  public virtual XFARectangle TextRectangle => this.textDrawer.GetTextRectangle();

  public virtual TextDrawer TextDrawer => this.textDrawer;

  public TextElement(
    IFormNode elementTag,
    JsNode node,
    XFARectangle elementRec,
    Document document,
    string plainText,
    FlattenerContext flattenerContext)
    : base(elementTag, elementRec, document)
  {
    this.textDrawer = new TextDrawer(node, new XFARectangle(this.document.PageSize), plainText, flattenerContext);
    if (!this.textDrawer.AutoSize || !"field".Equals(elementTag.ClassName))
      return;
    IFormNode formNode1 = elementTag.RetrieveChild("ui");
    if (formNode1 == null)
      return;
    IFormNode formNode2 = formNode1.RetrieveChild("textEdit");
    if (formNode2 == null || !"1".Equals(formNode2.RetrieveAttribute("multiLine")))
      return;
    this.textDrawer.AutoSizeLimit = 12f;
  }

  public TextElement(
    IFormNode elementTag,
    JsNode node,
    XFARectangle elementRec,
    Document document,
    IList<IElement> richText,
    FlattenerContext flattenerContext)
    : base(elementTag, elementRec, document)
  {
    this.textDrawer = new TextDrawer(node, new XFARectangle(this.document.PageSize), richText, flattenerContext);
  }

  public override PositionResult.State Draw(PdfContentByte canvas, XFARectangle parentBoundingBox)
  {
    return this.textDrawer.Draw(canvas, parentBoundingBox, false).GetState();
  }

  public override PositionResult SimulatePosition(XFARectangle parentBoundingBox)
  {
    return this.textDrawer.Draw((PdfContentByte) null, parentBoundingBox, true);
  }

  public override bool IsEmpty() => this.textDrawer.IsEmpty();

  public override bool IsTagged() => true;

  public override void Move(float dx, float dy)
  {
    base.Move(dx, dy);
    if (this.textDrawer == null || this.textDrawer.initRect == null)
      return;
    XFARectangle initRect1 = this.textDrawer.initRect;
    float? llx = this.textDrawer.initRect.Llx;
    float num1 = dx;
    float? nullable1 = llx.HasValue ? new float?(llx.GetValueOrDefault() + num1) : new float?();
    initRect1.Llx = nullable1;
    XFARectangle initRect2 = this.textDrawer.initRect;
    float? ury = this.textDrawer.initRect.Ury;
    float num2 = dy;
    float? nullable2 = ury.HasValue ? new float?(ury.GetValueOrDefault() + num2) : new float?();
    initRect2.Ury = nullable2;
  }
}
