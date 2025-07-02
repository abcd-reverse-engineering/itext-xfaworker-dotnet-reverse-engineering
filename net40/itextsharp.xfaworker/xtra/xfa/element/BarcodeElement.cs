// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.element.BarcodeElement
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.awt.geom;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml.xtra.xfa.tags;
using iTextSharp.tool.xml.xtra.xfa.util;
using System.Collections.Generic;
using System.util;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.element;

public class BarcodeElement : UiElement
{
  private const float TEXT_WIDTH_ADDITION = 5f;
  protected XFARectangle barcodeTextRectangle;
  protected string textLocation = "below";
  protected BarcodeDrawer barcodeDrawer;

  public BarcodeElement(
    IFormNode elementTag,
    XFARectangle elementRec,
    Document document,
    ContentElement contentElement)
    : base(elementTag, elementRec, document, contentElement)
  {
    string str;
    if (this.attributes != null && this.attributes.TryGetValue(nameof (textLocation), out str) && !string.IsNullOrEmpty(str))
      this.textLocation = str.ToLower();
    string code = "";
    if (contentElement is IContentTextElement)
    {
      foreach (IElement ielement in (IEnumerable<IElement>) ((IContentTextElement) contentElement).Content)
      {
        if (ielement is Paragraph)
        {
          Paragraph paragraph = (Paragraph) ielement;
          code += ((Phrase) paragraph).Content;
          paragraph.Alignment = 1;
        }
      }
    }
    this.barcodeDrawer = new BarcodeDrawer(this.attributes, code, elementRec.Width.Value);
    if (!this.barcodeDrawer.IsEmpty())
    {
      this.barcodeDrawer.SetAccessibleAttribute(PdfName.ALT, (PdfObject) new PdfString("Bar code " + code));
      this.barcodeTextRectangle = (XFARectangle) elementRec.Clone();
      XFARectangle barcodeTextRectangle1 = this.barcodeTextRectangle;
      float? llx = this.barcodeTextRectangle.Llx;
      float? nullable1 = llx.HasValue ? new float?(llx.GetValueOrDefault() - 2.5f) : new float?();
      barcodeTextRectangle1.Llx = nullable1;
      this.barcodeTextRectangle.Width = new float?(this.barcodeDrawer.BarcodeWidth + 5f);
      if (contentElement != null)
      {
        this.barcodeTextRectangle.Height = new float?(((IContentTextElement) contentElement).TextDrawer.FlattenerContext.GetFont(elementTag.RetrieveParent().RetrieveParent(), "Identity-H").Size);
        if (Util.EqualsIgnoreCase("below", this.textLocation) || Util.EqualsIgnoreCase("belowEmbedded", this.textLocation))
        {
          ((IContentTextElement) contentElement).TextDrawer.VerticalAlignment = 2;
          XFARectangle barcodeTextRectangle2 = this.barcodeTextRectangle;
          float? ury = elementRec.Ury;
          float? height1 = elementRec.Height;
          float? nullable2 = ury.HasValue & height1.HasValue ? new float?(ury.GetValueOrDefault() - height1.GetValueOrDefault()) : new float?();
          float? height2 = this.barcodeTextRectangle.Height;
          float? nullable3 = nullable2.HasValue & height2.HasValue ? new float?(nullable2.GetValueOrDefault() + height2.GetValueOrDefault()) : new float?();
          barcodeTextRectangle2.Ury = nullable3;
        }
        else if (Util.EqualsIgnoreCase(this.textLocation, "above") || Util.EqualsIgnoreCase("aboveEmbedded", this.textLocation))
          ((IContentTextElement) contentElement).TextDrawer.VerticalAlignment = 0;
        this.ApplyMargins(this.barcodeTextRectangle);
        ((IContentTextElement) contentElement).CreateColumnText(this.barcodeTextRectangle);
        this.UnapplyMargins(this.barcodeTextRectangle);
      }
      float? nullable4 = elementRec.Height;
      if (!nullable4.HasValue)
        nullable4 = new float?(this.barcodeTextRectangle.Height.Value * 3f);
      if (contentElement != null && this.barcodeDrawer.BarcodeHasTextOnIt && (Util.EqualsIgnoreCase(this.textLocation, "below") || Util.EqualsIgnoreCase(this.textLocation, "above")))
      {
        float? nullable5 = nullable4;
        float? height = ((IContentTextElement) contentElement).TextRectangle.Height;
        float? nullable6 = height.HasValue ? new float?(1.5f * height.GetValueOrDefault()) : new float?();
        nullable4 = nullable5.HasValue & nullable6.HasValue ? new float?(nullable5.GetValueOrDefault() - nullable6.GetValueOrDefault()) : new float?();
      }
      this.barcodeDrawer.BarHeight = nullable4.Value;
    }
    else
      this.barcodeDrawer = (BarcodeDrawer) null;
  }

  public override PositionResult.State Draw(PdfContentByte canvas, XFARectangle parentBoundingBox)
  {
    if (canvas != null && this.barcodeDrawer != null && !this.barcodeDrawer.IsEmpty())
    {
      if (this.contentElement != null && this.barcodeTextRectangle != null && !Util.EqualsIgnoreCase("none", this.textLocation) && this.barcodeDrawer.BarcodeHasTextOnIt)
      {
        int num1 = (int) this.contentElement.Draw(canvas, parentBoundingBox);
        canvas.SaveState();
        XFARectangle xfaRectangle1 = (XFARectangle) this.elementRec.Clone();
        XFARectangle xfaRectangle2 = xfaRectangle1;
        float? llx = xfaRectangle1.Llx;
        float? nullable = llx.HasValue ? new float?(llx.GetValueOrDefault() - 2.5f) : new float?();
        xfaRectangle2.Llx = nullable;
        xfaRectangle1.Width = new float?(this.barcodeDrawer.BarcodeWidth + 5f);
        Rectangle rectangle1 = xfaRectangle1.ToRectangle();
        rectangle1.Bottom = rectangle1.Bottom;
        canvas.Rectangle(rectangle1.Left, rectangle1.Bottom, rectangle1.Width, rectangle1.Height);
        Rectangle rectangle2 = ((IContentTextElement) this.contentElement).TextRectangle.ToRectangle();
        if (Util.EqualsIgnoreCase("aboveEmbedded", this.textLocation) || Util.EqualsIgnoreCase("belowEmbedded", this.textLocation))
        {
          float num2 = rectangle1.Width - rectangle2.Width;
          rectangle2.Left += num2 / 2f;
          rectangle2.Right += num2 / 2f;
        }
        else
        {
          rectangle2.Left = rectangle1.Left - 5f;
          rectangle2.Right = rectangle1.Right + 5f;
        }
        canvas.Rectangle(rectangle2.Left, rectangle2.Bottom, rectangle2.Width, rectangle2.Height);
        canvas.EoClip();
        canvas.NewPath();
      }
      else
        canvas.SaveState();
      if (this.barcodeDrawer != null)
      {
        float num = this.elementRec.Ury.Value - this.elementRec.Height.Value;
        if (this.contentElement != null && this.barcodeDrawer.BarcodeHasTextOnIt && Util.EqualsIgnoreCase(this.textLocation, "below"))
          num += 1.5f * ((IContentTextElement) this.contentElement).TextRectangle.Height.Value;
        canvas.Transform(new AffineTransform(1f, 0.0f, 0.0f, 1f, this.elementRec.Llx.Value, num));
        if (!this.barcodeDrawer.BarcodeHasTextOnIt)
          canvas.Transform(new AffineTransform(1f, 0.0f, 0.0f, 1f, (float) (((double) this.elementRec.Width.Value - (double) this.barcodeDrawer.BarcodeWidth) / 2.0), (float) (((double) this.elementRec.Height.Value - (double) this.barcodeDrawer.BarcodeHeight) / 2.0)));
        this.barcodeDrawer.Draw(canvas, parentBoundingBox);
      }
      canvas.RestoreState();
    }
    return PositionResult.State.FULL_CONTENT;
  }

  protected override bool IsTextWidget => true;

  public override bool IsEmpty()
  {
    if (!base.IsEmpty())
      return false;
    return this.barcodeDrawer == null || this.barcodeDrawer.IsEmpty();
  }

  public override bool IsTagged() => !this.IsEmpty() && this.barcodeDrawer.Role != PdfName.ARTIFACT;
}
