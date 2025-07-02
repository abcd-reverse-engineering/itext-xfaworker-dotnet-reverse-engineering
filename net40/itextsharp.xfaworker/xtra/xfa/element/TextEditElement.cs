// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.element.TextEditElement
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.awt.geom;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml.xtra.xfa.tags;
using iTextSharp.tool.xml.xtra.xfa.util;
using System;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.element;

public class TextEditElement : UiElement
{
  protected bool isBorderDrawn = true;

  public TextEditElement(
    IFormNode elementTag,
    XFARectangle elementRec,
    Document document,
    ContentElement contentElement)
    : this(elementTag, elementRec, document, contentElement, new int?())
  {
  }

  public TextEditElement(
    IFormNode elementTag,
    XFARectangle elementRec,
    Document document,
    ContentElement contentElement,
    int? textIndependentRotateAngle)
    : base(elementTag, elementRec, document, contentElement)
  {
    this.independentRotateAngle = textIndependentRotateAngle;
    if (!(this.contentElement is IContentTextElement))
      return;
    this.ApplyMargins(this.elementRec);
    if (textIndependentRotateAngle.HasValue)
    {
      int? nullable1 = textIndependentRotateAngle;
      int? nullable2 = nullable1.HasValue ? new int?(nullable1.GetValueOrDefault() % 180) : new int?();
      if ((nullable2.GetValueOrDefault() != 90 ? 0 : (nullable2.HasValue ? 1 : 0)) != 0)
      {
        float? width = this.elementRec.Width;
        this.elementRec.Width = this.elementRec.Height;
        this.elementRec.Height = width;
      }
    }
    ((IContentTextElement) this.contentElement).CreateColumnText(this.elementRec);
    if (textIndependentRotateAngle.HasValue)
    {
      int? nullable3 = textIndependentRotateAngle;
      int? nullable4 = nullable3.HasValue ? new int?(nullable3.GetValueOrDefault() % 180) : new int?();
      if ((nullable4.GetValueOrDefault() != 90 ? 0 : (nullable4.HasValue ? 1 : 0)) != 0)
      {
        float? width = this.elementRec.Width;
        this.elementRec.Width = this.elementRec.Height;
        this.elementRec.Height = width;
      }
    }
    this.UnapplyMargins(this.elementRec);
  }

  public override PositionResult.State Draw(PdfContentByte canvas, XFARectangle parentBoundingBox)
  {
    if (this.isBorderDrawn)
      this.DrawBorder(canvas, parentBoundingBox);
    PositionResult.State state = PositionResult.State.FULL_CONTENT;
    if (this.contentElement != null)
    {
      this.ApplyMargins(this.elementRec);
      if (this.independentRotateAngle.HasValue)
      {
        canvas.SaveState();
        canvas.Transform(AffineTransform.GetRotateInstance(Math.PI * (double) this.independentRotateAngle.Value / 180.0, (double) this.elementRec.Llx.Value, (double) this.elementRec.Ury.Value));
        int? independentRotateAngle1 = this.independentRotateAngle;
        int? nullable1 = independentRotateAngle1.HasValue ? new int?(independentRotateAngle1.GetValueOrDefault() % 360) : new int?();
        ref int? local = ref nullable1;
        int valueOrDefault = local.GetValueOrDefault();
        if (local.HasValue)
        {
          switch (valueOrDefault)
          {
            case 90:
              canvas.Transform(AffineTransform.GetTranslateInstance(-(double) this.elementRec.Height.Value, 0.0));
              break;
            case 180:
              canvas.Transform(AffineTransform.GetTranslateInstance(-(double) this.elementRec.Width.Value, (double) this.elementRec.Height.Value));
              break;
            case 270:
              canvas.Transform(AffineTransform.GetTranslateInstance(0.0, (double) this.elementRec.Width.Value));
              break;
          }
        }
        int? independentRotateAngle2 = this.independentRotateAngle;
        int? nullable2 = independentRotateAngle2.HasValue ? new int?(independentRotateAngle2.GetValueOrDefault() % 180) : new int?();
        if ((nullable2.GetValueOrDefault() != 90 ? 0 : (nullable2.HasValue ? 1 : 0)) != 0)
        {
          float? width = this.elementRec.Width;
          this.elementRec.Width = this.elementRec.Height;
          this.elementRec.Height = width;
        }
      }
      state = this.contentElement.Draw(canvas, parentBoundingBox);
      if (this.independentRotateAngle.HasValue)
      {
        canvas.RestoreState();
        int? independentRotateAngle = this.independentRotateAngle;
        int? nullable = independentRotateAngle.HasValue ? new int?(independentRotateAngle.GetValueOrDefault() % 180) : new int?();
        if ((nullable.GetValueOrDefault() != 90 ? 0 : (nullable.HasValue ? 1 : 0)) != 0)
        {
          float? width = this.elementRec.Width;
          this.elementRec.Width = this.elementRec.Height;
          this.elementRec.Height = width;
        }
      }
      this.UnapplyMargins(this.elementRec);
    }
    return this.positionState = state;
  }

  protected override bool IsTextWidget => true;

  public virtual bool BorderDrawn
  {
    set => this.isBorderDrawn = value;
  }
}
