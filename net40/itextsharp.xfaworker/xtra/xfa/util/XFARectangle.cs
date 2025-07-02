// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.util.XFARectangle
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.awt.geom;
using iTextSharp.text;
using System;
using System.Collections.Generic;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.util;

public class XFARectangle : ICloneable
{
  private static float MIN_VALUE = 1E-06f;
  private float? h;
  private float? minH;
  private float? maxH;
  private float? w;
  private float? minW;
  private float? maxW;
  private float? ury;
  private float? llx;

  public static XFARectangle GetCommonRectangle(IList<XFARectangle> rectangles)
  {
    float? nullable1 = new float?(float.MinValue);
    float? nullable2 = new float?(float.MaxValue);
    float? nullable3 = new float?(float.MaxValue);
    float? nullable4 = new float?(float.MinValue);
    foreach (XFARectangle rectangle in (IEnumerable<XFARectangle>) rectangles)
    {
      XFARectangle xfaRectangle = (XFARectangle) rectangle.Clone();
      if (!xfaRectangle.Height.HasValue)
        xfaRectangle.Height = new float?(0.0f);
      if (!xfaRectangle.Width.HasValue)
        xfaRectangle.Width = new float?(0.0f);
      float? ury1 = xfaRectangle.Ury;
      float? nullable5 = nullable1;
      if (((double) ury1.GetValueOrDefault() <= (double) nullable5.GetValueOrDefault() ? 0 : (ury1.HasValue & nullable5.HasValue ? 1 : 0)) != 0)
        nullable1 = xfaRectangle.Ury;
      float? llx1 = xfaRectangle.Llx;
      float? nullable6 = nullable2;
      if (((double) llx1.GetValueOrDefault() >= (double) nullable6.GetValueOrDefault() ? 0 : (llx1.HasValue & nullable6.HasValue ? 1 : 0)) != 0)
        nullable2 = xfaRectangle.Llx;
      float? ury2 = xfaRectangle.Ury;
      float? height1 = xfaRectangle.Height;
      float? nullable7 = ury2.HasValue & height1.HasValue ? new float?(ury2.GetValueOrDefault() - height1.GetValueOrDefault()) : new float?();
      float? nullable8 = nullable3;
      if (((double) nullable7.GetValueOrDefault() >= (double) nullable8.GetValueOrDefault() ? 0 : (nullable7.HasValue & nullable8.HasValue ? 1 : 0)) != 0)
      {
        float? ury3 = xfaRectangle.Ury;
        float? height2 = xfaRectangle.Height;
        nullable3 = ury3.HasValue & height2.HasValue ? new float?(ury3.GetValueOrDefault() - height2.GetValueOrDefault()) : new float?();
      }
      float? llx2 = xfaRectangle.Llx;
      float? width1 = xfaRectangle.Width;
      float? nullable9 = llx2.HasValue & width1.HasValue ? new float?(llx2.GetValueOrDefault() + width1.GetValueOrDefault()) : new float?();
      float? nullable10 = nullable4;
      if (((double) nullable9.GetValueOrDefault() <= (double) nullable10.GetValueOrDefault() ? 0 : (nullable9.HasValue & nullable10.HasValue ? 1 : 0)) != 0)
      {
        float? llx3 = xfaRectangle.Llx;
        float? width2 = xfaRectangle.Width;
        nullable4 = llx3.HasValue & width2.HasValue ? new float?(llx3.GetValueOrDefault() + width2.GetValueOrDefault()) : new float?();
      }
    }
    float? llx = nullable2;
    float? ury = nullable1;
    float? nullable11 = nullable4;
    float? nullable12 = nullable2;
    float? w = nullable11.HasValue & nullable12.HasValue ? new float?(nullable11.GetValueOrDefault() - nullable12.GetValueOrDefault()) : new float?();
    float? nullable13 = nullable1;
    float? nullable14 = nullable3;
    float? h = nullable13.HasValue & nullable14.HasValue ? new float?(nullable13.GetValueOrDefault() - nullable14.GetValueOrDefault()) : new float?();
    return new XFARectangle(llx, ury, w, h);
  }

  public static void ApplyMargins(
    XFARectangle rec,
    float topIndent,
    float rightIndent,
    float bottomIndent,
    float leftIndent,
    bool reverse)
  {
    float? llx = rec.Llx;
    float? ury = rec.Ury;
    float? width = rec.Width;
    float? minW = rec.MinW;
    float? maxW = rec.MaxW;
    float? height = rec.Height;
    float? minH = rec.MinH;
    float? maxH = rec.MaxH;
    float? nullable1;
    if (llx.HasValue)
    {
      if (reverse)
      {
        XFARectangle xfaRectangle = rec;
        nullable1 = llx;
        float num = leftIndent;
        float? nullable2 = nullable1.HasValue ? new float?(nullable1.GetValueOrDefault() - num) : new float?();
        xfaRectangle.Llx = nullable2;
      }
      else
      {
        XFARectangle xfaRectangle = rec;
        float? nullable3 = llx;
        float num = leftIndent;
        float? nullable4 = nullable3.HasValue ? new float?(nullable3.GetValueOrDefault() + num) : new float?();
        xfaRectangle.Llx = nullable4;
      }
      if ((double) Math.Abs(rec.Llx.Value) < (double) XFARectangle.MIN_VALUE)
        rec.Llx = new float?(0.0f);
    }
    if (ury.HasValue)
    {
      if (reverse)
      {
        XFARectangle xfaRectangle = rec;
        float? nullable5 = ury;
        float num = topIndent;
        float? nullable6 = nullable5.HasValue ? new float?(nullable5.GetValueOrDefault() + num) : new float?();
        xfaRectangle.Ury = nullable6;
      }
      else
      {
        XFARectangle xfaRectangle = rec;
        float? nullable7 = ury;
        float num = topIndent;
        float? nullable8 = nullable7.HasValue ? new float?(nullable7.GetValueOrDefault() - num) : new float?();
        xfaRectangle.Ury = nullable8;
      }
      if ((double) Math.Abs(rec.Ury.Value) < (double) XFARectangle.MIN_VALUE)
        rec.Ury = new float?(0.0f);
    }
    if (width.HasValue)
    {
      if (reverse)
      {
        XFARectangle xfaRectangle = rec;
        float? nullable9 = width;
        float num = rightIndent + leftIndent;
        float? nullable10 = nullable9.HasValue ? new float?(nullable9.GetValueOrDefault() + num) : new float?();
        xfaRectangle.Width = nullable10;
      }
      else
      {
        XFARectangle xfaRectangle = rec;
        float? nullable11 = width;
        float num = rightIndent + leftIndent;
        float? nullable12 = nullable11.HasValue ? new float?(nullable11.GetValueOrDefault() - num) : new float?();
        xfaRectangle.Width = nullable12;
      }
      if ((double) Math.Abs(rec.Width.Value) < (double) XFARectangle.MIN_VALUE)
        rec.Width = new float?(0.0f);
    }
    if (minW.HasValue)
    {
      if (reverse)
      {
        XFARectangle xfaRectangle = rec;
        float? nullable13 = minW;
        float num = rightIndent + leftIndent;
        float? nullable14 = nullable13.HasValue ? new float?(nullable13.GetValueOrDefault() + num) : new float?();
        xfaRectangle.MinW = nullable14;
      }
      else
      {
        XFARectangle xfaRectangle = rec;
        float? nullable15 = minW;
        float num = rightIndent + leftIndent;
        float? nullable16 = nullable15.HasValue ? new float?(nullable15.GetValueOrDefault() - num) : new float?();
        xfaRectangle.MinW = nullable16;
      }
      if ((double) Math.Abs(rec.MinW.Value) < (double) XFARectangle.MIN_VALUE)
        rec.MinW = new float?(0.0f);
    }
    if (maxW.HasValue)
    {
      if (reverse)
      {
        XFARectangle xfaRectangle = rec;
        float? nullable17 = maxW;
        float num = rightIndent + leftIndent;
        float? nullable18 = nullable17.HasValue ? new float?(nullable17.GetValueOrDefault() + num) : new float?();
        xfaRectangle.MaxW = nullable18;
      }
      else
      {
        XFARectangle xfaRectangle = rec;
        float? nullable19 = maxW;
        float num = rightIndent + leftIndent;
        float? nullable20 = nullable19.HasValue ? new float?(nullable19.GetValueOrDefault() - num) : new float?();
        xfaRectangle.MaxW = nullable20;
      }
      if ((double) Math.Abs(rec.MaxW.Value) < (double) XFARectangle.MIN_VALUE)
        rec.MaxW = new float?(0.0f);
    }
    if (height.HasValue)
    {
      if (reverse)
      {
        XFARectangle xfaRectangle = rec;
        float? nullable21 = height;
        float num = topIndent + bottomIndent;
        float? nullable22 = nullable21.HasValue ? new float?(nullable21.GetValueOrDefault() + num) : new float?();
        xfaRectangle.Height = nullable22;
      }
      else
      {
        XFARectangle xfaRectangle = rec;
        float? nullable23 = height;
        float num = topIndent + bottomIndent;
        float? nullable24 = nullable23.HasValue ? new float?(nullable23.GetValueOrDefault() - num) : new float?();
        xfaRectangle.Height = nullable24;
      }
      if ((double) Math.Abs(rec.Height.Value) < (double) XFARectangle.MIN_VALUE)
        rec.Height = new float?(0.0f);
    }
    if (minH.HasValue)
    {
      if (reverse)
      {
        XFARectangle xfaRectangle = rec;
        float? nullable25 = minH;
        float num = topIndent + bottomIndent;
        float? nullable26 = nullable25.HasValue ? new float?(nullable25.GetValueOrDefault() + num) : new float?();
        xfaRectangle.MinH = nullable26;
      }
      else
      {
        XFARectangle xfaRectangle = rec;
        float? nullable27 = minH;
        float num = topIndent + bottomIndent;
        float? nullable28 = nullable27.HasValue ? new float?(nullable27.GetValueOrDefault() - num) : new float?();
        xfaRectangle.MinH = nullable28;
      }
      if ((double) Math.Abs(rec.MinH.Value) < (double) XFARectangle.MIN_VALUE)
        rec.MinH = new float?(0.0f);
    }
    if (!maxH.HasValue)
      return;
    if (reverse)
    {
      XFARectangle xfaRectangle = rec;
      float? nullable29 = maxH;
      float num = topIndent + bottomIndent;
      float? nullable30 = nullable29.HasValue ? new float?(nullable29.GetValueOrDefault() + num) : new float?();
      xfaRectangle.MaxH = nullable30;
    }
    else
    {
      XFARectangle xfaRectangle = rec;
      float? nullable31 = maxH;
      float num = topIndent + bottomIndent;
      float? nullable32;
      if (!nullable31.HasValue)
      {
        nullable1 = new float?();
        nullable32 = nullable1;
      }
      else
        nullable32 = new float?(nullable31.GetValueOrDefault() - num);
      xfaRectangle.MaxH = nullable32;
    }
    nullable1 = rec.MaxH;
    if ((double) Math.Abs(nullable1.Value) >= (double) XFARectangle.MIN_VALUE)
      return;
    rec.MaxH = new float?(0.0f);
  }

  public static void SetUndefinedSizes(XFARectangle contentArea)
  {
    float? height = contentArea.Height;
    float? minH = contentArea.MinH;
    if (!height.HasValue)
      contentArea.Height = !minH.HasValue ? new float?(0.0f) : minH;
    float? width = contentArea.Width;
    float? minW = contentArea.MinW;
    if (width.HasValue)
      return;
    if (minW.HasValue)
      contentArea.Width = minW;
    else
      contentArea.Width = new float?(0.0f);
  }

  public XFARectangle(float? llx, float? ury, float? w, float? h)
  {
    this.llx = llx;
    this.ury = ury;
    this.w = w;
    this.h = h;
  }

  public XFARectangle(int llx, int ury, int w, int h)
    : this(new float?((float) llx), new float?((float) ury), new float?((float) w), new float?((float) h))
  {
  }

  public XFARectangle(
    float? llx,
    float? ury,
    float? w,
    float? minW,
    float? maxW,
    float? h,
    float? minH,
    float? maxH)
    : this(llx, ury, w, h)
  {
    this.minW = minW;
    this.maxW = maxW;
    this.minH = minH;
    this.maxH = maxH;
  }

  public XFARectangle(Rectangle rectangle)
    : this(new float?(rectangle.Left), new float?(rectangle.Bottom), new float?(rectangle.Width), new float?(rectangle.Height))
  {
  }

  public virtual float? Height
  {
    get => this.h;
    set => this.h = value;
  }

  public virtual float? MinH
  {
    get => this.minH;
    set => this.minH = value;
  }

  public virtual float? MaxH
  {
    get => this.maxH;
    set => this.maxH = value;
  }

  public virtual float? Width
  {
    get => this.w;
    set => this.w = value;
  }

  public virtual float? MinW
  {
    get => this.minW;
    set => this.minW = value;
  }

  public virtual float? MaxW
  {
    get => this.maxW;
    set => this.maxW = value;
  }

  public virtual float? Ury
  {
    get => this.ury;
    set => this.ury = value;
  }

  public virtual float? Llx
  {
    get => this.llx;
    set => this.llx = value;
  }

  public virtual Rectangle ToRectangle()
  {
    if (!this.llx.HasValue || !this.ury.HasValue || !this.w.HasValue || !this.h.HasValue)
      throw new Exception("Cannot create a com.itextpdf.text.Rectangle if some parameters are 'null'");
    double num1 = (double) this.llx.Value;
    float? ury = this.ury;
    float? h = this.h;
    double num2 = (double) (ury.HasValue & h.HasValue ? new float?(ury.GetValueOrDefault() - h.GetValueOrDefault()) : new float?()).Value;
    float? llx = this.llx;
    float? w = this.w;
    double num3 = (double) (llx.HasValue & w.HasValue ? new float?(llx.GetValueOrDefault() + w.GetValueOrDefault()) : new float?()).Value;
    double num4 = (double) this.ury.Value;
    return new Rectangle((float) num1, (float) num2, (float) num3, (float) num4);
  }

  public virtual object Clone()
  {
    return (object) new XFARectangle(this.llx, this.ury, this.w, this.minW, this.maxW, this.h, this.minH, this.maxH);
  }

  public virtual XFARectangle ApplyTransformation(AffineTransform transformation)
  {
    float[] numArray = new float[4]
    {
      this.Llx.Value,
      this.Ury.Value - this.Height.Value,
      this.Llx.Value + this.Width.Value,
      this.Ury.Value
    };
    transformation.Transform(numArray, 0, numArray, 0, 2);
    return new XFARectangle(new float?((double) numArray[0] < (double) numArray[2] ? numArray[0] : numArray[2]), new float?((double) numArray[3] > (double) numArray[1] ? numArray[3] : numArray[1]), new float?(Math.Abs(numArray[2] - numArray[0])), new float?(Math.Abs(numArray[3] - numArray[1])));
  }

  public bool Contains(XFARectangle other, float padding)
  {
    if (this.llx.HasValue && other.llx.HasValue)
    {
      float? llx1 = other.llx;
      float? llx2 = this.llx;
      float num1 = padding;
      float? nullable1 = llx2.HasValue ? new float?(llx2.GetValueOrDefault() + num1) : new float?();
      if (((double) llx1.GetValueOrDefault() <= (double) nullable1.GetValueOrDefault() ? 0 : (llx1.HasValue & nullable1.HasValue ? 1 : 0)) != 0 && this.w.HasValue && other.w.HasValue)
      {
        float? llx3 = other.llx;
        float? w1 = other.w;
        float? nullable2 = llx3.HasValue & w1.HasValue ? new float?(llx3.GetValueOrDefault() + w1.GetValueOrDefault()) : new float?();
        float? llx4 = this.llx;
        float? w2 = this.w;
        float? nullable3 = llx4.HasValue & w2.HasValue ? new float?(llx4.GetValueOrDefault() + w2.GetValueOrDefault()) : new float?();
        float num2 = padding;
        float? nullable4 = nullable3.HasValue ? new float?(nullable3.GetValueOrDefault() - num2) : new float?();
        if (((double) nullable2.GetValueOrDefault() >= (double) nullable4.GetValueOrDefault() ? 0 : (nullable2.HasValue & nullable4.HasValue ? 1 : 0)) != 0 && this.ury.HasValue && other.ury.HasValue)
        {
          float? ury1 = other.ury;
          float? ury2 = this.ury;
          float num3 = padding;
          float? nullable5 = ury2.HasValue ? new float?(ury2.GetValueOrDefault() - num3) : new float?();
          if (((double) ury1.GetValueOrDefault() >= (double) nullable5.GetValueOrDefault() ? 0 : (ury1.HasValue & nullable5.HasValue ? 1 : 0)) != 0 && this.h.HasValue && other.h.HasValue)
          {
            float? ury3 = this.ury;
            float? h1 = this.h;
            float? nullable6 = ury3.HasValue & h1.HasValue ? new float?(ury3.GetValueOrDefault() - h1.GetValueOrDefault()) : new float?();
            float num4 = padding;
            float? nullable7 = nullable6.HasValue ? new float?(nullable6.GetValueOrDefault() + num4) : new float?();
            float? ury4 = other.ury;
            float? h2 = other.h;
            float? nullable8 = ury4.HasValue & h2.HasValue ? new float?(ury4.GetValueOrDefault() - h2.GetValueOrDefault()) : new float?();
            return (double) nullable7.GetValueOrDefault() < (double) nullable8.GetValueOrDefault() && nullable7.HasValue & nullable8.HasValue;
          }
        }
      }
    }
    return false;
  }

  public bool Contains(XFARectangle other) => this.Contains(other, XFAUtil.DEVIATION);
}
