// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.element.Element
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml.xtra.xfa.tags;
using iTextSharp.tool.xml.xtra.xfa.util;
using System;
using System.Collections.Generic;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.element;

public abstract class Element
{
  protected IFormNode elementTag;
  protected XFARectangle elementRec;
  protected Document document;
  protected IDictionary<string, string> para = (IDictionary<string, string>) new Dictionary<string, string>();
  protected IDictionary<string, string> attributes = (IDictionary<string, string>) new Dictionary<string, string>();
  protected BorderDrawer borderDrawer;
  protected bool isDrawElement;

  public Element(IFormNode elementTag, XFARectangle elementRec, Document document)
  {
    this.elementTag = elementTag;
    this.elementRec = elementRec;
    this.document = document;
    IFormNode border = elementTag.RetrieveChild("border");
    if (border != null)
    {
      this.borderDrawer = new BorderDrawer(border);
      if (this.borderDrawer.IsEmpty())
        this.borderDrawer = (BorderDrawer) null;
    }
    IFormNode formNode1 = elementTag.RetrieveParent();
    if (formNode1 != null)
    {
      IFormNode formNode2 = formNode1.RetrieveParent();
      if (formNode2 != null)
      {
        IFormNode formNode3 = formNode2.RetrieveChild(nameof (para));
        if (formNode3 != null)
          this.para = formNode3.RetrieveAttributes();
      }
    }
    if (elementTag.RetrieveAttributes() == null)
      return;
    this.attributes = elementTag.RetrieveAttributes();
  }

  public virtual PositionResult.State Draw(PdfContentByte canvas, XFARectangle parentBoundingBox)
  {
    this.DrawBorder(canvas, parentBoundingBox);
    return PositionResult.State.FULL_CONTENT;
  }

  public virtual void DrawBorder(PdfContentByte canvas, XFARectangle parentBoundingBox)
  {
    if (this.borderDrawer == null || this.isDrawElement)
      return;
    XFARectangle rec = (XFARectangle) this.elementRec.Clone();
    this.DrawBorder(canvas, rec, parentBoundingBox);
  }

  public virtual void DrawBorder(
    PdfContentByte canvas,
    XFARectangle rec,
    XFARectangle parentBoundingBox)
  {
    if (this.borderDrawer == null || this.isDrawElement)
      return;
    if (parentBoundingBox != null)
    {
      float num1 = Math.Min(rec.Ury.Value, parentBoundingBox.Ury.Value);
      float num2 = Math.Max(rec.Ury.Value - rec.Height.Value, parentBoundingBox.Ury.Value - parentBoundingBox.Height.Value);
      float num3 = num1 - num2;
      rec.Ury = new float?(num1);
      rec.Height = new float?(num3);
    }
    this.borderDrawer.Draw(canvas, rec);
  }

  public virtual bool IsEmpty() => this.borderDrawer == null || this.borderDrawer.IsEmpty();

  public virtual bool IsTagged() => !this.IsEmpty();

  public virtual XFARectangle GetElementRec() => this.elementRec;

  public virtual PositionResult SimulatePosition(XFARectangle parentBoundingBox)
  {
    return parentBoundingBox != null && this.elementRec.Ury.HasValue && this.elementRec.Height.HasValue && XFAUtil.Lt(this.elementRec.Ury.Value - this.elementRec.Height.Value, parentBoundingBox.Ury.Value - parentBoundingBox.Height.Value) ? new PositionResult(PositionResult.State.NO_CONTENT, this.elementRec) : new PositionResult(PositionResult.State.FULL_CONTENT, this.elementRec);
  }

  public virtual bool IsDrawElement
  {
    set => this.isDrawElement = value;
  }

  public virtual void Move(float dx, float dy)
  {
    if (this.elementRec == null)
      return;
    XFARectangle elementRec1 = this.elementRec;
    float? llx = this.elementRec.Llx;
    float num1 = dx;
    float? nullable1 = llx.HasValue ? new float?(llx.GetValueOrDefault() + num1) : new float?();
    elementRec1.Llx = nullable1;
    XFARectangle elementRec2 = this.elementRec;
    float? ury = this.elementRec.Ury;
    float num2 = dy;
    float? nullable2 = ury.HasValue ? new float?(ury.GetValueOrDefault() + num2) : new float?();
    elementRec2.Ury = nullable2;
  }
}
