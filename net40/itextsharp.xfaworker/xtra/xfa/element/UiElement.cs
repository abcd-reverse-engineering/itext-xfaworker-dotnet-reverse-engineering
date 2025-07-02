// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.element.UiElement
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.awt.geom;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml.xtra.xfa.tags;
using iTextSharp.tool.xml.xtra.xfa.util;
using System;
using System.Collections.Generic;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.element;

public abstract class UiElement : Element
{
  protected ContentElement contentElement;
  private float topMargin;
  private float rightMargin;
  private float bottomMargin;
  private float leftMargin;
  protected PositionResult.State positionState;
  protected int? independentRotateAngle;

  public UiElement(IFormNode elementTag, XFARectangle elementRec, Document document)
    : base(elementTag, elementRec, document)
  {
    IFormNode formNode = elementTag.RetrieveChild("margin");
    if (formNode == null)
      return;
    IDictionary<string, string> dictionary = formNode.RetrieveAttributes();
    float? nullable1 = new float?();
    float? nullable2 = new float?();
    float? nullable3 = new float?();
    float? nullable4 = new float?();
    if (dictionary != null)
    {
      nullable1 = XFAUtil.ParseFloat(formNode.RetrieveAttribute("topInset"));
      nullable2 = XFAUtil.ParseFloat(formNode.RetrieveAttribute("rightInset"));
      nullable3 = XFAUtil.ParseFloat(formNode.RetrieveAttribute("leftInset"));
      nullable4 = XFAUtil.ParseFloat(formNode.RetrieveAttribute("bottomInset"));
    }
    if (this.borderDrawer != null && this.IsTextWidget)
    {
      float[] borderThicknesses = this.borderDrawer.GetBorderThicknesses();
      if (borderThicknesses != null && borderThicknesses.Length == 4)
      {
        this.topMargin = borderThicknesses[0];
        this.rightMargin = borderThicknesses[1];
        this.bottomMargin = borderThicknesses[2];
        this.leftMargin = borderThicknesses[3];
      }
    }
    this.topMargin = !nullable1.HasValue ? this.topMargin : nullable1.Value;
    this.rightMargin = !nullable2.HasValue ? this.rightMargin : nullable2.Value;
    this.leftMargin = !nullable3.HasValue ? this.leftMargin : nullable3.Value;
    this.bottomMargin = !nullable4.HasValue ? this.bottomMargin : nullable4.Value;
  }

  public UiElement(
    IFormNode elementTag,
    XFARectangle elementRec,
    Document document,
    ContentElement contentElement)
    : this(elementTag, elementRec, document)
  {
    this.contentElement = contentElement;
  }

  public override PositionResult.State Draw(PdfContentByte canvas, XFARectangle parentBoundingBox)
  {
    PositionResult.State state = base.Draw(canvas, parentBoundingBox);
    if (this.contentElement != null)
    {
      if (this.independentRotateAngle.HasValue)
      {
        canvas.SaveState();
        canvas.Transform(AffineTransform.GetRotateInstance(Math.PI / 180.0 * (double) this.independentRotateAngle.Value, (double) this.elementRec.Llx.Value, (double) this.elementRec.Ury.Value));
      }
      this.ApplyMargins(this.elementRec);
      state = this.contentElement.Draw(canvas, parentBoundingBox);
      this.UnapplyMargins(this.elementRec);
      if (this.independentRotateAngle.HasValue)
        canvas.RestoreState();
    }
    return this.positionState = state;
  }

  public override bool IsEmpty()
  {
    if (!base.IsEmpty())
      return false;
    return this.contentElement == null || this.contentElement.IsEmpty();
  }

  public override bool IsTagged() => this.contentElement != null && this.contentElement.IsTagged();

  public override PositionResult SimulatePosition(XFARectangle parentBoundingBox)
  {
    return this.contentElement != null ? this.contentElement.SimulatePosition(parentBoundingBox) : base.SimulatePosition(parentBoundingBox);
  }

  public virtual void ApplyMargins(XFARectangle rectangle)
  {
    if (this.elementTag.RetrieveChild("margin") == null)
      return;
    bool flag = this.positionState == PositionResult.State.CONTENT_PART || this.positionState == PositionResult.State.FULL_CONTENT;
    XFARectangle.ApplyMargins(rectangle, flag ? 0.0f : this.topMargin, this.rightMargin, this.bottomMargin, this.leftMargin, false);
  }

  public virtual void UnapplyMargins(XFARectangle rectangle)
  {
    if (this.elementTag.RetrieveChild("margin") == null)
      return;
    bool flag = this.positionState == PositionResult.State.CONTENT_PART || this.positionState == PositionResult.State.FULL_CONTENT;
    XFARectangle.ApplyMargins(rectangle, flag ? 0.0f : this.topMargin, this.rightMargin, this.bottomMargin, this.leftMargin, true);
  }

  public virtual ContentElement ContentElement => this.contentElement;

  protected abstract bool IsTextWidget { get; }

  public virtual int? IndependentRotateAngle
  {
    get => this.independentRotateAngle;
    set => this.independentRotateAngle = value;
  }

  public override void Move(float dx, float dy)
  {
    base.Move(dx, dy);
    if (this.contentElement == null)
      return;
    this.contentElement.Move(dx, dy);
  }
}
