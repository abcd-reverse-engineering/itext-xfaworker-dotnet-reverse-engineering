// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.element.ArcDrawer
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.interfaces;
using iTextSharp.tool.xml.css;
using iTextSharp.tool.xml.xtra.xfa.format;
using iTextSharp.tool.xml.xtra.xfa.tags;
using iTextSharp.tool.xml.xtra.xfa.util;
using System.Collections.Generic;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.element;

public class ArcDrawer : AbstractDrawer
{
  protected bool fill;
  protected BaseColor fillColor = BaseColor.BLACK;
  protected IDictionary<string, string> attributes = (IDictionary<string, string>) new Dictionary<string, string>();
  protected FormattingElement fe;
  protected float startAngle;
  protected float sweepAngle = 360f;
  protected bool circular;
  private bool hasLoweredStyle;
  private bool hasEmbossedStyle;
  private bool hasEtchedStyle;
  private bool hasRaisedStyle;
  private bool hasOtherStyle;

  public ArcDrawer(IFormNode arc)
  {
    if (arc.RetrieveAttributes() != null)
    {
      this.attributes = arc.RetrieveAttributes();
      string s1 = (string) null;
      this.attributes.TryGetValue(nameof (startAngle), out s1);
      if (s1 != null)
        this.startAngle = XFAUtil.ParseFloat(s1).Value;
      string s2 = (string) null;
      this.attributes.TryGetValue(nameof (sweepAngle), out s2);
      if (s2 != null)
        this.sweepAngle = XFAUtil.ParseFloat(s2).Value;
      string str = (string) null;
      this.attributes.TryGetValue(nameof (circular), out str);
      if ("1".Equals(str))
        this.circular = true;
    }
    IFormNode formNode1 = arc.RetrieveChild(nameof (fill));
    if (formNode1 != null)
    {
      this.fill = true;
      IFormNode formNode2 = formNode1.RetrieveChild("color");
      if (formNode2 != null)
      {
        string xfaColor = formNode2.RetrieveAttribute("value");
        if (xfaColor != null && xfaColor.Length > 0)
          this.fillColor = XFAUtil.ParseXfaColor(xfaColor);
      }
    }
    IFormNode formNode3 = arc.RetrieveChild("edge");
    string str1 = (string) null;
    string str2 = (string) null;
    BaseColor baseColor = (BaseColor) null;
    if (formNode3 != null)
    {
      IDictionary<string, string> dictionary = formNode3.RetrieveAttributes();
      if (dictionary != null)
      {
        dictionary.TryGetValue("thickness", out str1);
        dictionary.TryGetValue("stroke", out str2);
      }
      IFormNode formNode4 = formNode3.RetrieveChild("color");
      if (formNode4 != null)
      {
        string xfaColor = formNode4.RetrieveAttribute("value");
        if (xfaColor != null && xfaColor.Length > 0)
          baseColor = XFAUtil.ParseXfaColor(xfaColor);
      }
    }
    this.fe = new FormattingElement();
    if (str1 != null)
      this.fe.Thickness = new float?(CssUtils.GetInstance().ParsePxInCmMmPcToPt(str1, "pt"));
    if (str2 != null)
      this.fe.Stroke = str2;
    if (baseColor != null)
      this.fe.Color = baseColor;
    if (FormattingElement.StrokeType.LOWERED.Equals(this.fe.Stroke))
      this.hasLoweredStyle = true;
    else if (FormattingElement.StrokeType.EMBOSSED.Equals(this.fe.Stroke))
      this.hasEmbossedStyle = true;
    else if (FormattingElement.StrokeType.ETCHED.Equals(this.fe.Stroke))
      this.hasEtchedStyle = true;
    else if (FormattingElement.StrokeType.RAISED.Equals(this.fe.Stroke))
      this.hasRaisedStyle = true;
    else
      this.hasOtherStyle = true;
  }

  public override void Draw(PdfContentByte canvas, XFARectangle borderArea)
  {
    this.InitArcRectangle(borderArea);
    if (this.fill)
    {
      if (canvas.IsTagged())
        canvas.OpenMCBlock((IAccessibleElement) this);
      canvas.SaveState();
      canvas.SetColorFill(this.fillColor);
      canvas.Arc(this.fe.X1.Value, this.fe.Y1.Value, this.fe.X2.Value, this.fe.Y2.Value, this.startAngle, this.sweepAngle);
      canvas.Fill();
      canvas.RestoreState();
      if (canvas.IsTagged())
        canvas.CloseMCBlock((IAccessibleElement) this);
    }
    if (this.hasEmbossedStyle || this.hasEtchedStyle || this.hasRaisedStyle)
      return;
    float? thickness = this.fe.Thickness;
    if (((double) thickness.GetValueOrDefault() <= 0.001 ? 0 : (thickness.HasValue ? 1 : 0)) != 0)
    {
      canvas.SaveState();
      if (canvas.IsTagged())
        canvas.OpenMCBlock((IAccessibleElement) this);
      canvas.SetLineWidth(this.fe.Thickness.Value);
      canvas.SetColorStroke(this.fe.Color);
      this.SetLineDash(canvas, this.fe);
      float num1 = this.fe.X1.Value;
      float num2 = this.fe.X2.Value;
      if ((double) num1 != (double) num2)
      {
        num1 -= this.fe.Thickness.Value / 2f;
        num2 += this.fe.Thickness.Value / 2f;
      }
      float num3 = this.fe.Y1.Value;
      float num4 = this.fe.Y2.Value;
      if ((double) num3 != (double) num4)
      {
        num3 += this.fe.Thickness.Value / 2f;
        num4 -= this.fe.Thickness.Value / 2f;
      }
      canvas.Arc(num1, num3, num2, num4, this.startAngle, this.sweepAngle);
      canvas.Stroke();
    }
    canvas.RestoreState();
    if (!canvas.IsTagged())
      return;
    canvas.CloseMCBlock((IAccessibleElement) this);
  }

  protected virtual void SetLineDash(PdfContentByte canvas, FormattingElement fe)
  {
    if (fe.Stroke == null || FormattingElement.StrokeType.SOLID.Equals(fe.Stroke))
      canvas.SetLineDash(0.0f);
    else if (FormattingElement.StrokeType.DOTTED.Equals(fe.Stroke))
      canvas.SetLineDash(fe.Thickness.Value, fe.Thickness.Value * 2f, 0.0f);
    else if (FormattingElement.StrokeType.DASHED.Equals(fe.Stroke))
      canvas.SetLineDash(fe.Thickness.Value * 5f, fe.Thickness.Value * 1f, 0.0f);
    else if (FormattingElement.StrokeType.DASH_DOT.Equals(fe.Stroke))
    {
      float[] numArray = new float[4]
      {
        3f * fe.Thickness.Value,
        2f * fe.Thickness.Value,
        1f * fe.Thickness.Value,
        2f * fe.Thickness.Value
      };
      canvas.SetLineDash(numArray, 0.0f);
    }
    else
    {
      if (!FormattingElement.StrokeType.DASH_DOT_DOT.Equals(fe.Stroke))
        return;
      float[] numArray = new float[6]
      {
        3f * fe.Thickness.Value,
        2f * fe.Thickness.Value,
        1f * fe.Thickness.Value,
        2f * fe.Thickness.Value,
        1f * fe.Thickness.Value,
        2f * fe.Thickness.Value
      };
      canvas.SetLineDash(numArray, 0.0f);
    }
  }

  public virtual void InitArcRectangle(XFARectangle arcArea)
  {
    float? nullable1 = arcArea.Llx;
    float? nullable2 = arcArea.Ury;
    float? llx = arcArea.Llx;
    float? width1 = arcArea.Width;
    float? nullable3 = llx.HasValue & width1.HasValue ? new float?(llx.GetValueOrDefault() + width1.GetValueOrDefault()) : new float?();
    float? ury = arcArea.Ury;
    float? height1 = arcArea.Height;
    float? nullable4 = ury.HasValue & height1.HasValue ? new float?(ury.GetValueOrDefault() - height1.GetValueOrDefault()) : new float?();
    if (this.circular)
    {
      float? width2 = arcArea.Width;
      float? height2 = arcArea.Height;
      if (((double) width2.GetValueOrDefault() <= (double) height2.GetValueOrDefault() ? 0 : (width2.HasValue & height2.HasValue ? 1 : 0)) != 0)
      {
        float? width3 = arcArea.Width;
        float? height3 = arcArea.Height;
        float? nullable5 = width3.HasValue & height3.HasValue ? new float?(width3.GetValueOrDefault() - height3.GetValueOrDefault()) : new float?();
        float? nullable6 = nullable5.HasValue ? new float?(nullable5.GetValueOrDefault() / 2f) : new float?();
        float? nullable7 = nullable1;
        float? nullable8 = nullable6;
        nullable1 = nullable7.HasValue & nullable8.HasValue ? new float?(nullable7.GetValueOrDefault() + nullable8.GetValueOrDefault()) : new float?();
        float? nullable9 = nullable3;
        float? nullable10 = nullable6;
        nullable3 = nullable9.HasValue & nullable10.HasValue ? new float?(nullable9.GetValueOrDefault() - nullable10.GetValueOrDefault()) : new float?();
      }
      else
      {
        float? width4 = arcArea.Width;
        float? height4 = arcArea.Height;
        float? nullable11 = width4.HasValue & height4.HasValue ? new float?(width4.GetValueOrDefault() - height4.GetValueOrDefault()) : new float?();
        float? nullable12 = nullable11.HasValue ? new float?(nullable11.GetValueOrDefault() / 2f) : new float?();
        float? nullable13 = nullable2;
        float? nullable14 = nullable12;
        nullable2 = nullable13.HasValue & nullable14.HasValue ? new float?(nullable13.GetValueOrDefault() - nullable14.GetValueOrDefault()) : new float?();
        float? nullable15 = nullable4;
        float? nullable16 = nullable12;
        nullable4 = nullable15.HasValue & nullable16.HasValue ? new float?(nullable15.GetValueOrDefault() + nullable16.GetValueOrDefault()) : new float?();
      }
    }
    string str = (string) null;
    this.attributes.TryGetValue("hand", out str);
    float num1 = 0.0f;
    if ("right".Equals(str))
      num1 = this.fe.Thickness.Value;
    else if (str == null || "even".Equals(str))
      num1 = this.fe.Thickness.Value / 2f;
    FormattingElement fe = this.fe;
    float? nullable17 = nullable1;
    float num2 = num1;
    float? x1 = nullable17.HasValue ? new float?(nullable17.GetValueOrDefault() + num2) : new float?();
    float? nullable18 = nullable2;
    float num3 = num1;
    float? y1 = nullable18.HasValue ? new float?(nullable18.GetValueOrDefault() - num3) : new float?();
    float? nullable19 = nullable3;
    float num4 = num1;
    float? x2 = nullable19.HasValue ? new float?(nullable19.GetValueOrDefault() - num4) : new float?();
    float? nullable20 = nullable4;
    float num5 = num1;
    float? y2 = nullable20.HasValue ? new float?(nullable20.GetValueOrDefault() + num5) : new float?();
    fe.SetRectanglePoints(x1, y1, x2, y2);
  }

  public override bool IsEmpty() => false;
}
