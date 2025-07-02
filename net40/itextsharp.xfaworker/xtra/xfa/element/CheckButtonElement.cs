// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.element.CheckButtonElement
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.awt.geom;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml.css;
using iTextSharp.tool.xml.xtra.xfa.tags;
using iTextSharp.tool.xml.xtra.xfa.util;
using System;
using System.Collections.Generic;
using System.util;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.element;

public class CheckButtonElement : UiElement
{
  private float size = 10f;
  private string shape = "rectangle";
  private string mark = "default";
  private bool hasEmbossedStyle;
  private float? thickness = new float?(0.5f);
  private string onValue;
  private string hAlign;

  public CheckButtonElement(
    IFormNode elementTag,
    XFARectangle elementRec,
    Document document,
    ContentElement contentElement,
    string hAlign,
    CaptionElement captionElement)
    : base(elementTag, elementRec, document, contentElement)
  {
    this.hAlign = hAlign;
    if (this.hAlign == null)
      this.attributes.TryGetValue(nameof (hAlign), out this.hAlign);
    string str;
    if (this.attributes.TryGetValue(nameof (size), out str) && !string.IsNullOrEmpty(str))
      this.size = CssUtils.GetInstance().ParsePxInCmMmPcToPt(str, "pt");
    if (this.attributes.ContainsKey(nameof (shape)))
    {
      IFormNode border = elementTag.RetrieveChild("border");
      this.shape = this.attributes[nameof (shape)];
      if (border != null && Util.EqualsIgnoreCase("round", this.shape))
        this.borderDrawer = (BorderDrawer) new RoundBorderDrawer(border);
    }
    if (this.borderDrawer != null)
    {
      this.hasEmbossedStyle = this.borderDrawer.HasEmbossedStyle();
      this.thickness = this.borderDrawer.borderEdges[0].Thickness;
    }
    if (this.attributes.ContainsKey(nameof (mark)))
      this.mark = this.attributes[nameof (mark)];
    if (!elementRec.Width.HasValue)
      elementRec.Width = !elementRec.MinW.HasValue ? (!elementRec.MaxW.HasValue ? new float?(this.size) : new float?(Math.Min(elementRec.MaxW.Value, this.size))) : new float?(Math.Max(elementRec.MinW.Value, this.size));
    if (!elementRec.Height.HasValue)
      elementRec.Height = !elementRec.MinH.HasValue ? (!elementRec.MaxH.HasValue ? new float?(this.size) : new float?(Math.Min(elementRec.MaxH.Value, this.size))) : new float?(Math.Max(elementRec.MinH.Value, this.size));
    if (captionElement != null && !captionElement.GetReserve().HasValue)
    {
      elementRec.Height = new float?(this.size);
      elementRec.Width = new float?(this.size);
    }
    this.InitOnValue();
  }

  public override PositionResult.State Draw(PdfContentByte canvas, XFARectangle parentBoundingBox)
  {
    XFARectangle borderArea = (XFARectangle) this.elementRec.Clone();
    string str;
    this.para.TryGetValue("vAlign", out str);
    if (Util.EqualsIgnoreCase("bottom", str))
    {
      XFARectangle xfaRectangle = borderArea;
      float? ury = borderArea.Ury;
      float? height = borderArea.Height;
      float size = this.size;
      float? nullable1 = height.HasValue ? new float?(height.GetValueOrDefault() - size) : new float?();
      float? nullable2 = ury.HasValue & nullable1.HasValue ? new float?(ury.GetValueOrDefault() - nullable1.GetValueOrDefault()) : new float?();
      xfaRectangle.Ury = nullable2;
    }
    else if (Util.EqualsIgnoreCase("middle", str))
    {
      XFARectangle xfaRectangle = borderArea;
      float? ury = borderArea.Ury;
      float? height = borderArea.Height;
      float size = this.size;
      float? nullable3 = height.HasValue ? new float?(height.GetValueOrDefault() - size) : new float?();
      float? nullable4 = nullable3.HasValue ? new float?(nullable3.GetValueOrDefault() / 2f) : new float?();
      float? nullable5 = ury.HasValue & nullable4.HasValue ? new float?(ury.GetValueOrDefault() - nullable4.GetValueOrDefault()) : new float?();
      xfaRectangle.Ury = nullable5;
    }
    if (Util.EqualsIgnoreCase("right", this.hAlign))
    {
      XFARectangle xfaRectangle = borderArea;
      float? llx = borderArea.Llx;
      float? width = borderArea.Width;
      float? nullable6 = llx.HasValue & width.HasValue ? new float?(llx.GetValueOrDefault() + width.GetValueOrDefault()) : new float?();
      float size = this.size;
      float? nullable7 = nullable6.HasValue ? new float?(nullable6.GetValueOrDefault() - size) : new float?();
      xfaRectangle.Llx = nullable7;
    }
    else if (Util.EqualsIgnoreCase("center", this.hAlign))
    {
      XFARectangle xfaRectangle = borderArea;
      float? llx = borderArea.Llx;
      float? width = borderArea.Width;
      float size = this.size;
      float? nullable8 = width.HasValue ? new float?(width.GetValueOrDefault() - size) : new float?();
      float? nullable9 = nullable8.HasValue ? new float?(nullable8.GetValueOrDefault() / 2f) : new float?();
      float? nullable10 = llx.HasValue & nullable9.HasValue ? new float?(llx.GetValueOrDefault() + nullable9.GetValueOrDefault()) : new float?();
      xfaRectangle.Llx = nullable10;
    }
    borderArea.Height = new float?(this.size);
    borderArea.Width = new float?(this.size);
    if (this.borderDrawer != null)
      this.borderDrawer.Draw(canvas, borderArea);
    if (this.onValue != null && this.contentElement is TextElement)
    {
      IList<IElement> content = ((TextElement) this.contentElement).Content;
      if (content.Count == 1 && content[0] is Paragraph && Util.EqualsIgnoreCase(this.onValue, ((Phrase) content[0]).Content))
        new MarkDrawer(this.size, this.shape, this.mark, this.hasEmbossedStyle, this.thickness.Value, this.RetriveMarkColor()).Draw(canvas, borderArea);
    }
    return PositionResult.State.FULL_CONTENT;
  }

  public virtual PositionResult.State DrawAsField(
    PdfContentByte canvas,
    XFARectangle parentBoundingBox,
    string alternateText,
    string name)
  {
    XFARectangle borderArea = (XFARectangle) this.elementRec.Clone();
    string str = (string) null;
    this.para.TryGetValue("vAlign", out str);
    if (Util.EqualsIgnoreCase("bottom", str))
    {
      XFARectangle xfaRectangle = borderArea;
      float? ury = borderArea.Ury;
      float? height = borderArea.Height;
      float size = this.size;
      float? nullable1 = height.HasValue ? new float?(height.GetValueOrDefault() - size) : new float?();
      float? nullable2 = ury.HasValue & nullable1.HasValue ? new float?(ury.GetValueOrDefault() - nullable1.GetValueOrDefault()) : new float?();
      xfaRectangle.Ury = nullable2;
    }
    else if (Util.EqualsIgnoreCase("middle", str))
    {
      XFARectangle xfaRectangle = borderArea;
      float? ury = borderArea.Ury;
      float? height = borderArea.Height;
      float size = this.size;
      float? nullable3 = height.HasValue ? new float?(height.GetValueOrDefault() - size) : new float?();
      float? nullable4 = nullable3.HasValue ? new float?(nullable3.GetValueOrDefault() / 2f) : new float?();
      float? nullable5 = ury.HasValue & nullable4.HasValue ? new float?(ury.GetValueOrDefault() - nullable4.GetValueOrDefault()) : new float?();
      xfaRectangle.Ury = nullable5;
    }
    else
      Util.EqualsIgnoreCase("top", str);
    if (Util.EqualsIgnoreCase("right", this.hAlign))
    {
      XFARectangle xfaRectangle = borderArea;
      float? llx = borderArea.Llx;
      float? width = borderArea.Width;
      float? nullable6 = llx.HasValue & width.HasValue ? new float?(llx.GetValueOrDefault() + width.GetValueOrDefault()) : new float?();
      float size = this.size;
      float? nullable7 = nullable6.HasValue ? new float?(nullable6.GetValueOrDefault() - size) : new float?();
      xfaRectangle.Llx = nullable7;
    }
    else if (Util.EqualsIgnoreCase("center", this.hAlign))
    {
      XFARectangle xfaRectangle = borderArea;
      float? llx = borderArea.Llx;
      float? width = borderArea.Width;
      float size = this.size;
      float? nullable8 = width.HasValue ? new float?(width.GetValueOrDefault() - size) : new float?();
      float? nullable9 = nullable8.HasValue ? new float?(nullable8.GetValueOrDefault() / 2f) : new float?();
      float? nullable10 = llx.HasValue & nullable9.HasValue ? new float?(llx.GetValueOrDefault() + nullable9.GetValueOrDefault()) : new float?();
      xfaRectangle.Llx = nullable10;
    }
    else
      Util.EqualsIgnoreCase("left", this.hAlign);
    borderArea.Height = new float?(this.size);
    borderArea.Width = new float?(this.size);
    Rectangle rectangle = new Rectangle(borderArea.Llx.Value - 1f, (float) ((double) borderArea.Ury.Value - (double) borderArea.Height.Value - 1.0), (float) ((double) borderArea.Llx.Value + (double) borderArea.Width.Value + 1.0), borderArea.Ury.Value + 1f);
    PdfFormField checkBox = PdfFormField.CreateCheckBox(canvas.PdfWriter);
    checkBox.SetWidget(rectangle, PdfAnnotation.HIGHLIGHT_INVERT);
    ((PdfAnnotation) checkBox).Flags = 708;
    checkBox.SetFieldFlags(1);
    ((PdfAnnotation) checkBox).SetPage();
    ((PdfDictionary) checkBox).Put(PdfName.NM, (PdfObject) new PdfString(name));
    ((PdfDictionary) checkBox).Put(PdfName.T, (PdfObject) new PdfString(name));
    ((PdfDictionary) checkBox).Put(PdfName.TU, (PdfObject) new PdfString(alternateText));
    PdfTemplate canvas1 = (PdfTemplate) null;
    if (this.onValue != null && this.contentElement != null && this.contentElement is TextElement)
    {
      IList<IElement> content = ((TextElement) this.contentElement).Content;
      if (content.Count == 1 && content[0] is Paragraph && Util.EqualsIgnoreCase(this.onValue, ((Phrase) content[0]).Content))
      {
        MarkDrawer markDrawer = new MarkDrawer(this.size, this.shape, this.mark, this.hasEmbossedStyle, this.thickness.Value, this.RetriveMarkColor());
        canvas1 = (PdfTemplate) PdfAppearance.CreateAppearance(canvas.PdfWriter, rectangle.Width, rectangle.Height);
        ((PdfContentByte) canvas1).Transform(new AffineTransform(1f, 0.0f, 0.0f, 1f, -rectangle.Left, -rectangle.Bottom));
        ((PdfAnnotation) checkBox).SetAppearance(PdfAnnotation.APPEARANCE_NORMAL, "1", canvas1);
        if (this.borderDrawer != null)
          this.borderDrawer.Draw((PdfContentByte) canvas1, borderArea);
        markDrawer.Draw((PdfContentByte) canvas1, borderArea);
        PdfAppearance.CreateAppearance(canvas.PdfWriter, rectangle.Width, rectangle.Height);
        ((PdfAnnotation) checkBox).SetAppearance(PdfAnnotation.APPEARANCE_NORMAL, "Off", canvas1);
        ((PdfAnnotation) checkBox).AppearanceState = "1";
        checkBox.ValueAsName = "1";
      }
    }
    if (canvas1 == null)
    {
      PdfTemplate appearance1 = (PdfTemplate) PdfAppearance.CreateAppearance(canvas.PdfWriter, rectangle.Width, rectangle.Height);
      ((PdfAnnotation) checkBox).SetAppearance(PdfAnnotation.APPEARANCE_NORMAL, "1", appearance1);
      PdfTemplate appearance2 = (PdfTemplate) PdfAppearance.CreateAppearance(canvas.PdfWriter, rectangle.Width, rectangle.Height);
      ((PdfContentByte) appearance2).Transform(new AffineTransform(1f, 0.0f, 0.0f, 1f, -rectangle.Left, -rectangle.Bottom));
      ((PdfAnnotation) checkBox).SetAppearance(PdfAnnotation.APPEARANCE_NORMAL, "Off", appearance2);
      if (this.borderDrawer != null)
        this.borderDrawer.Draw((PdfContentByte) appearance2, borderArea);
      ((PdfAnnotation) checkBox).AppearanceState = "Off";
      checkBox.ValueAsName = "Off";
    }
    canvas.AddAnnotation((PdfAnnotation) checkBox, true);
    return PositionResult.State.FULL_CONTENT;
  }

  private BaseColor RetriveMarkColor()
  {
    IFormNode formNode = this.elementTag.RetrieveParent().RetrieveParent().RetrieveChild("font", "fill", "color");
    return formNode != null ? XFAUtil.ParseXfaColor(formNode.RetrieveValue()) : (BaseColor) null;
  }

  public override bool IsEmpty()
  {
    if (this.onValue != null && this.contentElement is TextElement)
    {
      IList<IElement> content = ((TextElement) this.contentElement).Content;
      if (content.Count == 1 && content[0] is Paragraph && this.onValue.Equals(((Phrase) content[0]).Content))
        return false;
    }
    return this.borderDrawer == null || this.borderDrawer.IsEmpty();
  }

  protected override bool IsTextWidget => false;

  private void InitOnValue()
  {
    IFormNode checkButtonField = this.elementTag.RetrieveParent();
    if (checkButtonField != null)
      checkButtonField = checkButtonField.RetrieveParent();
    this.onValue = CheckButtonElement.GetOnValue(checkButtonField);
  }

  public static string GetOnValue(IFormNode checkButtonField)
  {
    if (checkButtonField == null)
      return (string) null;
    IFormNode formNode = checkButtonField.RetrieveChild("items");
    if (formNode != null && formNode.RetrieveChildren().Count != 0)
    {
      IFormNode retrieveChild = formNode.RetrieveChildren()[0];
      if (retrieveChild != null)
      {
        IList<string> stringList = retrieveChild.RetrieveContent();
        if (stringList != null && stringList.Count == 1)
          return stringList[0];
      }
    }
    return (string) null;
  }
}
