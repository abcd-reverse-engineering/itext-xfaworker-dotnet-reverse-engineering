// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.element.CaptionElement
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.text.pdf;
using iTextSharp.tool.xml.xtra.xfa.js;
using iTextSharp.tool.xml.xtra.xfa.resolver;
using iTextSharp.tool.xml.xtra.xfa.tags;
using iTextSharp.tool.xml.xtra.xfa.util;
using System.util;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.element;

public class CaptionElement(Tag tag, JsNode parent) : JsNode(tag, parent, "caption")
{
  private XFARectangle elementRec;
  private TextDrawer textDrawer;
  private string captionText;

  public virtual PositionResult Draw(PdfContentByte canvas, XFARectangle parentBoundingBox)
  {
    return this.textDrawer != null ? this.textDrawer.Draw(canvas, parentBoundingBox, false) : (PositionResult) null;
  }

  public virtual string CaptionText
  {
    get
    {
      if (this.captionText != null)
        return this.captionText;
      return this.textDrawer != null ? this.textDrawer.GetContentAsString() : (string) null;
    }
  }

  public virtual TextDrawer TextDrawer => this.textDrawer;

  public virtual bool IsEmpty() => this.textDrawer == null || this.textDrawer.IsEmpty();

  public virtual string GetPlacement() => (string) this.GetOwnProperty("placement") ?? "left";

  public virtual float? GetReserve()
  {
    float? reserve = XFAUtil.parseFloatToPt(this.RetrieveAttribute("reserve"));
    if (reserve.HasValue && XFAUtil.Lte(reserve.Value, 0.0f))
      reserve = new float?();
    return reserve;
  }

  public virtual void FixCaptionAreaByContentArea(XFARectangle rec)
  {
    string placement = this.GetPlacement();
    if (placement.Equals("left") || Util.EqualsIgnoreCase(placement, "right"))
    {
      if (Util.EqualsIgnoreCase(placement, "right"))
      {
        XFARectangle elementRec = this.elementRec;
        float? llx = rec.Llx;
        float? width = rec.Width;
        float? nullable = llx.HasValue & width.HasValue ? new float?(llx.GetValueOrDefault() + width.GetValueOrDefault()) : new float?();
        elementRec.Llx = nullable;
        if (this.textDrawer != null)
          this.textDrawer.CreateColumnText(this.elementRec);
      }
      if (!this.elementRec.Height.HasValue)
        return;
      float a = this.elementRec.Ury.Value - this.elementRec.Height.Value;
      if (rec.Height.HasValue && !XFAUtil.Lt(a, rec.Ury.Value - rec.Height.Value))
        return;
      XFARectangle xfaRectangle = rec;
      float? ury = rec.Ury;
      float num = a;
      float? nullable1 = ury.HasValue ? new float?(ury.GetValueOrDefault() - num) : new float?();
      xfaRectangle.Height = nullable1;
    }
    else
    {
      if (!placement.EndsWith("top") && !Util.EqualsIgnoreCase(placement, "bottom"))
        return;
      if (Util.EqualsIgnoreCase(placement, "bottom"))
      {
        XFARectangle elementRec = this.elementRec;
        float? ury = this.elementRec.Ury;
        float? height = rec.Height;
        float? nullable = ury.HasValue & height.HasValue ? new float?(ury.GetValueOrDefault() - height.GetValueOrDefault()) : new float?();
        elementRec.Ury = nullable;
        if (this.textDrawer != null)
          this.textDrawer.CreateColumnText(this.elementRec);
      }
      if (!this.elementRec.Width.HasValue)
        return;
      float a = this.elementRec.Llx.Value + this.elementRec.Width.Value;
      if (rec.Width.HasValue && !XFAUtil.Gt(a, rec.Llx.Value + rec.Width.Value))
        return;
      XFARectangle xfaRectangle = rec;
      float num = a;
      float? llx = rec.Llx;
      float? nullable2 = llx.HasValue ? new float?(num - llx.GetValueOrDefault()) : new float?();
      xfaRectangle.Width = nullable2;
    }
  }

  public virtual void FixCaptionAreaByParentArea(XFARectangle contentArea)
  {
    string placement = this.GetPlacement();
    if (Util.EqualsIgnoreCase(placement, "right"))
    {
      if (!contentArea.Llx.HasValue || !contentArea.Width.HasValue || !this.elementRec.Width.HasValue)
        return;
      float? width1 = contentArea.Width;
      float? width2 = this.elementRec.Width;
      if (((double) width1.GetValueOrDefault() <= (double) width2.GetValueOrDefault() ? 0 : (width1.HasValue & width2.HasValue ? 1 : 0)) == 0)
        return;
      XFARectangle elementRec = this.elementRec;
      float? llx = contentArea.Llx;
      float? width3 = contentArea.Width;
      float? nullable1 = llx.HasValue & width3.HasValue ? new float?(llx.GetValueOrDefault() + width3.GetValueOrDefault()) : new float?();
      float? width4 = this.elementRec.Width;
      float? nullable2 = nullable1.HasValue & width4.HasValue ? new float?(nullable1.GetValueOrDefault() - width4.GetValueOrDefault()) : new float?();
      elementRec.Llx = nullable2;
      if (this.textDrawer == null)
        return;
      this.textDrawer.CreateColumnText(this.elementRec);
    }
    else
    {
      if (!Util.EqualsIgnoreCase(placement, "bottom") || !contentArea.Ury.HasValue || !contentArea.Height.HasValue || !this.elementRec.Height.HasValue)
        return;
      float? height1 = contentArea.Height;
      float? height2 = this.elementRec.Height;
      if (((double) height1.GetValueOrDefault() <= (double) height2.GetValueOrDefault() ? 0 : (height1.HasValue & height2.HasValue ? 1 : 0)) == 0)
        return;
      XFARectangle elementRec = this.elementRec;
      float? ury = contentArea.Ury;
      float? height3 = contentArea.Height;
      float? nullable3 = ury.HasValue & height3.HasValue ? new float?(ury.GetValueOrDefault() - height3.GetValueOrDefault()) : new float?();
      float? height4 = this.elementRec.Height;
      float? nullable4 = nullable3.HasValue & height4.HasValue ? new float?(nullable3.GetValueOrDefault() + height4.GetValueOrDefault()) : new float?();
      elementRec.Ury = nullable4;
      if (this.textDrawer == null)
        return;
      this.textDrawer.CreateColumnText(this.elementRec);
    }
  }

  public virtual void Place(XFARectangle contentArea, FlattenerContext flattenerContext)
  {
    this.elementRec = contentArea;
    string placement = this.GetPlacement();
    float? reserve = this.GetReserve();
    XFARectangle rec = this.elementRec.Clone() as XFARectangle;
    bool flag = false;
    JsNode parentNode = this.GetParentNode();
    if (parentNode != null)
    {
      IFormNode formNode = parentNode.RetrieveChild("ui");
      if (formNode != null && formNode.RetrieveChild("button") != null)
        flag = true;
    }
    if (!flag)
    {
      if (Util.EqualsIgnoreCase(placement, "top") || Util.EqualsIgnoreCase(placement, "bottom"))
      {
        rec.Height = reserve;
        if (!reserve.HasValue)
        {
          rec.MinH = new float?();
          rec.MaxH = new float?();
        }
      }
      else
      {
        rec.Width = reserve;
        if (!reserve.HasValue)
        {
          rec.MinW = new float?();
          rec.MaxW = new float?();
        }
      }
    }
    if (reserve.HasValue)
    {
      float? nullable = reserve;
      if (((double) nullable.GetValueOrDefault() <= 0.0 ? 0 : (nullable.HasValue ? 1 : 0)) == 0)
        goto label_13;
    }
    this.CreateTextDrawer(flattenerContext);
    if (this.textDrawer != null)
      this.textDrawer.CreateColumnText(rec);
label_13:
    if (!reserve.HasValue)
    {
      if (Util.EqualsIgnoreCase(placement, "top") || Util.EqualsIgnoreCase(placement, "bottom"))
      {
        if (!rec.Height.HasValue)
          rec.Height = new float?(flattenerContext.GetFont((IFormNode) this, "Identity-H").Size);
      }
      else if (!rec.Width.HasValue)
        rec.Width = new float?(0.0f);
    }
    this.elementRec = rec;
  }

  private void CreateTextDrawer(FlattenerContext flattenerContext)
  {
    IFormNode formNode1 = this.RetrieveChild("value");
    string str1 = (string) null;
    if (formNode1 != null)
    {
      string str2 = flattenerContext.GetFontNode((IFormNode) this)?.RetrieveAttribute("size");
      if (str2 == null || !"0".Equals(str2))
      {
        IFormNode formNode2 = formNode1.RetrieveChild("text");
        str1 = formNode2 == null ? formNode1.RetrieveAttribute("text") : formNode2.RetrieveValue();
      }
    }
    if (str1 != null)
    {
      this.captionText = str1;
      this.textDrawer = new TextDrawer((JsNode) this, new XFARectangle(flattenerContext.Document.PageSize), this.captionText, flattenerContext);
    }
    if (formNode1 == null)
      return;
    IFormNode formNode3 = formNode1.RetrieveChild("exData");
    if (formNode3 == null)
      return;
    switch (formNode3.RetrieveAttribute("contentType"))
    {
      case "text/html":
        this.textDrawer = new TextDrawer((JsNode) this, new XFARectangle(flattenerContext.Document.PageSize), formNode3.RetrieveRichText(), flattenerContext, true);
        break;
    }
  }

  public virtual bool IsTagged() => !this.IsEmpty();

  public virtual XFARectangle GetElementRec() => this.elementRec;

  public virtual PositionResult SimulatePosition(XFARectangle parentBoundingBox)
  {
    if (parentBoundingBox != null && this.elementRec.Ury.HasValue && this.elementRec.Height.HasValue)
    {
      float? ury1 = this.elementRec.Ury;
      float? height1 = this.elementRec.Height;
      float? nullable1 = ury1.HasValue & height1.HasValue ? new float?(ury1.GetValueOrDefault() - height1.GetValueOrDefault()) : new float?();
      float? ury2 = parentBoundingBox.Ury;
      float? nullable2 = nullable1.HasValue & ury2.HasValue ? new float?(nullable1.GetValueOrDefault() - ury2.GetValueOrDefault()) : new float?();
      float? height2 = parentBoundingBox.Height;
      float? nullable3 = nullable2.HasValue & height2.HasValue ? new float?(nullable2.GetValueOrDefault() + height2.GetValueOrDefault()) : new float?();
      if (((double) nullable3.GetValueOrDefault() >= -0.01 ? 0 : (nullable3.HasValue ? 1 : 0)) != 0)
        return new PositionResult(PositionResult.State.NO_CONTENT);
    }
    return new PositionResult(PositionResult.State.FULL_CONTENT);
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
