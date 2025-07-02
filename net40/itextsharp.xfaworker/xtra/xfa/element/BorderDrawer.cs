// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.element.BorderDrawer
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
using System;
using System.Collections.Generic;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.element;

public class BorderDrawer : AbstractDrawer
{
  private const int TOP = 0;
  private const int RIGHT = 1;
  private const int BOTTOM = 2;
  private const int LEFT = 3;
  private const int TOP_LEFT = 0;
  private const int TOP_RIGHT = 1;
  private const int BOTTOM_RIGHT = 2;
  private const int BOTTOM_LEFT = 3;
  protected bool? fill = new bool?(false);
  protected BaseColor fillColor = BaseColor.WHITE;
  protected internal IList<FormattingElement> borderEdges;
  protected IList<CornerFormattingElement> borderCorners;
  private bool hasLoweredStyle;
  private bool hasEmbossedStyle;
  private bool hasEtchedStyle;
  private bool hasRaisedStyle;
  private bool hasOtherStyle;
  protected IFormNode borderNode;
  protected bool isCombElementBorder;
  protected int? combElementCellsNumber = new int?();

  public BorderDrawer(IFormNode border)
  {
    this.borderNode = border;
    this.AddBorderLines(border);
    this.CalculateStyle();
  }

  public static bool IsEmpty(IFormNode border)
  {
    string attributeValue = XFAUtil.GetAttributeValue("presence", border.RetrieveAttributes());
    if (attributeValue == null || "visible".Equals(attributeValue))
    {
      bool flag1 = false;
      if (border.RetrieveChild("fill") != null)
        flag1 = true;
      IList<IFormNode> formNodeList1 = border.RetrieveChildren("edge");
      int count = formNodeList1.Count;
      IList<IFormNode> formNodeList2 = border.RetrieveChildren("corner");
      int length = count + formNodeList2.Count;
      string[] strArray1 = new string[length];
      string[] strArray2 = new string[length];
      string[] strArray3 = new string[length];
      string[] strArray4 = new string[length];
      for (int index = 0; index < formNodeList1.Count; ++index)
      {
        IDictionary<string, string> dictionary = formNodeList1[index].RetrieveAttributes();
        if (dictionary != null)
        {
          dictionary.TryGetValue("presence", out strArray1[index]);
          dictionary.TryGetValue("thickness", out strArray2[index]);
          dictionary.TryGetValue("stroke", out strArray3[index]);
          strArray4[index] = "1pt";
        }
      }
      for (int index = 0; index < formNodeList2.Count; ++index)
      {
        IDictionary<string, string> dictionary = formNodeList2[index].RetrieveAttributes();
        if (dictionary != null)
        {
          dictionary.TryGetValue("presence", out strArray1[formNodeList1.Count + index]);
          dictionary.TryGetValue("thickness", out strArray2[formNodeList1.Count + index]);
          dictionary.TryGetValue("stroke", out strArray3[formNodeList1.Count + index]);
          dictionary.TryGetValue("radius", out strArray4[formNodeList1.Count + index]);
        }
      }
      bool flag2 = false;
      foreach (string str in strArray3)
      {
        if (!FormattingElement.StrokeType.LOWERED.Equals(str) && !FormattingElement.StrokeType.EMBOSSED.Equals(str) && !FormattingElement.StrokeType.ETCHED.Equals(str) && !FormattingElement.StrokeType.RAISED.Equals(str))
          flag2 = true;
      }
      if (flag1)
        return false;
      if (flag2)
      {
        if (length <= 0)
          return false;
        for (int index = 0; index < length; ++index)
        {
          float num1 = 0.5f;
          if (strArray2[index] != null)
            num1 = CssUtils.GetInstance().ParsePxInCmMmPcToPt(strArray2[index], "pt");
          float num2 = 0.0f;
          if (strArray4[index] != null)
            num2 = CssUtils.GetInstance().ParsePxInCmMmPcToPt(strArray4[index], "pt");
          if ((strArray1[index] == null || "visible".Equals(strArray1[index])) && (double) num1 > 0.001 && (double) num2 != 0.0)
            return false;
        }
      }
      else if (length == 0 || !"hidden".Equals(strArray1[0]))
        return false;
    }
    return true;
  }

  public override void Draw(PdfContentByte canvas, XFARectangle borderArea)
  {
    if (this.fill.Value)
    {
      if (canvas.IsTagged())
        canvas.OpenMCBlock((IAccessibleElement) this);
      canvas.SaveState();
      canvas.SetColorFill(this.fillColor);
      if (this.borderCorners == null)
      {
        canvas.Rectangle(borderArea.Llx.Value, borderArea.Ury.Value - borderArea.Height.Value, borderArea.Width.Value, borderArea.Height.Value);
      }
      else
      {
        canvas.SetColorStroke(new BaseColor(0, (int) byte.MaxValue, 0));
        float num1 = borderArea.Width.Value;
        float num2 = borderArea.Height.Value;
        float num3 = borderArea.Llx.Value;
        float num4 = borderArea.Ury.Value;
        float num5 = (float) (4.0 * (Math.Sqrt(2.0) - 1.0) / 3.0);
        canvas.NewPath();
        float num6 = this.borderCorners[0].Radius.Value;
        bool flag1 = "round".Equals(this.borderCorners[0].Join);
        bool flag2 = "1".Equals(this.borderCorners[0].Inverted);
        canvas.MoveTo(num3, num4 - num6);
        if ((double) num6 != 0.0)
        {
          if (flag1 && flag2)
            canvas.CurveTo(num3 + num6 * num5, num4 - num6, num3 + num6, num4 - num5 * num6, num3 + num6, num4);
          else if (flag1)
          {
            canvas.CurveTo(num3, num4 + num6 * (num5 - 1f), num3 + num6 * (1f - num5), num4, num3 + num6, num4);
          }
          else
          {
            if (flag2)
              canvas.LineTo(num3 + num6, num4 - num6);
            else
              canvas.LineTo(num3, num4);
            canvas.LineTo(num3 + num6, num4);
          }
        }
        float num7 = this.borderCorners[1].Radius.Value;
        bool flag3 = "round".Equals(this.borderCorners[1].Join);
        bool flag4 = "1".Equals(this.borderCorners[1].Inverted);
        canvas.LineTo(num3 + num1 - num7, num4);
        if ((double) num7 != 0.0)
        {
          if (flag3 && flag4)
            canvas.CurveTo(num3 + num1 - num7, num4 - num7 * num5, (float) ((double) num3 + (double) num1 - (double) num7 * (double) num5), num4 - num7, num3 + num1, num4 - num7);
          else if (flag3)
          {
            canvas.CurveTo((float) ((double) num3 + (double) num1 + (double) num7 * ((double) num5 - 1.0)), num4, num3 + num1, num4 + num7 * (num5 - 1f), num3 + num1, num4 - num7);
          }
          else
          {
            if (flag4)
              canvas.LineTo(num3 + num1 - num7, num4 - num7);
            else
              canvas.LineTo(num3 + num1, num4);
            canvas.LineTo(num3 + num1, num4 - num7);
          }
        }
        float num8 = this.borderCorners[2].Radius.Value;
        bool flag5 = "round".Equals(this.borderCorners[2].Join);
        bool flag6 = "1".Equals(this.borderCorners[2].Inverted);
        canvas.LineTo(num3 + num1, num4 - num2 + num8);
        if ((double) num8 != 0.0)
        {
          if (flag5 && flag6)
            canvas.CurveTo((float) ((double) num3 + (double) num1 - (double) num8 * (double) num5), num4 - num2 + num8, num3 + num1 - num8, (float) ((double) num4 - (double) num2 + (double) num8 * (double) num5), num3 + num1 - num8, num4 - num2);
          else if (flag5)
          {
            canvas.CurveTo(num3 + num1, (float) ((double) num4 - (double) num2 + (double) num8 * (1.0 - (double) num5)), (float) ((double) num3 + (double) num1 + (double) num8 * ((double) num5 - 1.0)), num4 - num2, num3 + num1 - num8, num4 - num2);
          }
          else
          {
            if (flag6)
              canvas.LineTo(num3 + num1 - num8, num4 - num2 + num8);
            else
              canvas.LineTo(num3 + num1, num4 - num2);
            canvas.LineTo(num3 + num1 - num8, num4 - num2);
          }
        }
        float num9 = this.borderCorners[3].Radius.Value;
        bool flag7 = "round".Equals(this.borderCorners[3].Join);
        bool flag8 = "1".Equals(this.borderCorners[3].Inverted);
        canvas.LineTo(num3 + num9, num4 - num2);
        if ((double) num9 != 0.0)
        {
          if (flag7 && flag8)
            canvas.CurveTo(num3 + num9, (float) ((double) num4 - (double) num2 + (double) num9 * (double) num5), num3 + num9 * num5, num4 - num2 + num9, num3, num4 - num2 + num9);
          else if (flag7)
          {
            canvas.CurveTo(num3 + num9 * (1f - num5), num4 - num2, num3, (float) ((double) num4 - (double) num2 + (double) num9 * (1.0 - (double) num5)), num3, num4 - num2 + num9);
          }
          else
          {
            if (flag8)
              canvas.LineTo(num3 + num9, num4 - num2 + num9);
            else
              canvas.LineTo(num3, num4 - num2);
            canvas.LineTo(num3, num4 - num2 + num9);
          }
        }
        canvas.ClosePath();
      }
      canvas.Fill();
      canvas.RestoreState();
      if (canvas.IsTagged())
        canvas.CloseMCBlock((IAccessibleElement) this);
    }
    if (this.borderEdges == null)
      return;
    this.UpdateBorderLinesPoints(borderArea);
    if (this.hasOtherStyle)
    {
      bool saveState1 = false;
      if (this.borderEdges != null)
      {
        bool saveState2 = this.DrawEdge(this.borderEdges[0], canvas, saveState1);
        bool saveState3 = this.DrawEdge(this.borderEdges[2], canvas, saveState2);
        bool saveState4 = this.DrawEdge(this.borderEdges[3], canvas, saveState3);
        saveState1 = this.DrawEdge(this.borderEdges[1], canvas, saveState4);
        if (this.isCombElementBorder && "right".Equals(this.borderNode.RetrieveAttribute("hand")))
          saveState1 = this.DrawCombElementLines(this.borderEdges[2], this.borderEdges[1], canvas, saveState1);
      }
      if (this.borderCorners != null)
      {
        bool saveState5 = this.DrawCorner(this.borderCorners[3], canvas, saveState1);
        bool saveState6 = this.DrawCorner(this.borderCorners[2], canvas, saveState5);
        bool saveState7 = this.DrawCorner(this.borderCorners[1], canvas, saveState6);
        saveState1 = this.DrawCorner(this.borderCorners[0], canvas, saveState7);
      }
      if (!saveState1)
        return;
      canvas.RestoreState();
      if (!canvas.IsTagged())
        return;
      canvas.CloseMCBlock((IAccessibleElement) this);
    }
    else
    {
      if ("hidden".Equals(this.borderEdges[0].Presence))
        return;
      if (this.hasEmbossedStyle)
        this.DrawEmbossed(canvas, borderArea, BaseColor.GRAY, BaseColor.BLACK, BaseColor.GRAY, BaseColor.BLACK);
      else if (this.hasEtchedStyle)
        this.DrawEmbossed(canvas, borderArea, BaseColor.GRAY, BaseColor.WHITE, BaseColor.GRAY, BaseColor.WHITE);
      else if (this.hasLoweredStyle)
      {
        this.DrawEmbossed(canvas, borderArea, BaseColor.BLACK, BaseColor.GRAY, new BaseColor(212, 208 /*0xD0*/, 200), BaseColor.BLACK);
      }
      else
      {
        if (!this.hasRaisedStyle)
          return;
        this.DrawEmbossed(canvas, borderArea, BaseColor.BLACK, BaseColor.WHITE, BaseColor.GRAY, BaseColor.BLACK);
      }
    }
  }

  private void DrawEmbossed(
    PdfContentByte canvas,
    XFARectangle borderArea,
    BaseColor color1,
    BaseColor color2,
    BaseColor color3,
    BaseColor color4)
  {
    float num1 = this.borderEdges[0].Thickness.Value;
    float num2 = borderArea.Width.Value;
    float num3 = borderArea.Height.Value;
    float num4 = borderArea.Llx.Value;
    float num5 = borderArea.Ury.Value;
    if (canvas.IsTagged())
      canvas.OpenMCBlock((IAccessibleElement) this);
    canvas.SaveState();
    canvas.SetLineWidth(0.0f);
    canvas.SetColorFill(color1);
    canvas.MoveTo(num4, num5 - num3);
    canvas.LineTo(num4 + num1, num5 - num3 + num1);
    canvas.LineTo(num4 + num1, num5 - num1);
    canvas.LineTo(num4, num5);
    canvas.ClosePath();
    canvas.Fill();
    canvas.MoveTo(num4 + num1, num5 - num1);
    canvas.LineTo(num4 + num2 - num1, num5 - num1);
    canvas.LineTo(num4 + num2, num5);
    canvas.LineTo(num4, num5);
    canvas.ClosePath();
    canvas.Fill();
    canvas.SetColorFill(color2);
    canvas.MoveTo(num4 + num1, num5 - num3 + num1);
    canvas.LineTo(num4 + num1 * 2f, (float) ((double) num5 - (double) num3 + (double) num1 * 2.0));
    canvas.LineTo(num4 + num1 * 2f, num5 - num1 * 2f);
    canvas.LineTo(num4 + num1, num5 - num1);
    canvas.ClosePath();
    canvas.Fill();
    canvas.MoveTo(num4 + num1 * 2f, num5 - num1 * 2f);
    canvas.LineTo(num4 + num1, num5 - num1);
    canvas.LineTo(num4 + num2 - num1, num5 - num1);
    canvas.LineTo((float) ((double) num4 + (double) num2 - (double) num1 * 2.0), num5 - num1 * 2f);
    canvas.ClosePath();
    canvas.Fill();
    canvas.SetColorFill(color3);
    canvas.MoveTo(num4 + num2 - num1, num5 - num3 + num1);
    canvas.LineTo(num4 + num2 - num1, num5 - num1);
    canvas.LineTo((float) ((double) num4 + (double) num2 - (double) num1 * 2.0), num5 - num1 * 2f);
    canvas.LineTo((float) ((double) num4 + (double) num2 - (double) num1 * 2.0), (float) ((double) num5 - (double) num3 + (double) num1 * 2.0));
    canvas.ClosePath();
    canvas.Fill();
    canvas.MoveTo(num4 + num1, num5 - num3 + num1);
    canvas.LineTo(num4 + num2 - num1, num5 - num3 + num1);
    canvas.LineTo((float) ((double) num4 + (double) num2 - (double) num1 * 2.0), (float) ((double) num5 - (double) num3 + (double) num1 * 2.0));
    canvas.LineTo(num4 + num1 * 2f, (float) ((double) num5 - (double) num3 + (double) num1 * 2.0));
    canvas.ClosePath();
    canvas.Fill();
    canvas.SetColorFill(color4);
    canvas.MoveTo(num4 + num2, num5 - num3);
    canvas.LineTo(num4 + num2 - num1, num5 - num3 + num1);
    canvas.LineTo(num4 + num2 - num1, num5 - num1);
    canvas.LineTo(num4 + num2, num5);
    canvas.ClosePath();
    canvas.Fill();
    canvas.MoveTo(num4 + num1, num5 - num3 + num1);
    canvas.LineTo(num4, num5 - num3);
    canvas.LineTo(num4 + num2, num5 - num3);
    canvas.LineTo(num4 + num2 - num1, num5 - num3 + num1);
    canvas.ClosePath();
    canvas.Fill();
    canvas.RestoreState();
    if (!canvas.IsTagged())
      return;
    canvas.CloseMCBlock((IAccessibleElement) this);
  }

  protected virtual bool DrawEdge(FormattingElement fe, PdfContentByte canvas, bool saveState)
  {
    if ("visible".Equals(fe.Presence))
    {
      float? thickness = fe.Thickness;
      if (((double) thickness.GetValueOrDefault() <= 0.001 ? 0 : (thickness.HasValue ? 1 : 0)) != 0)
      {
        if (!saveState)
        {
          canvas.SaveState();
          if (canvas.IsTagged())
            canvas.OpenMCBlock((IAccessibleElement) this);
          saveState = true;
        }
        canvas.SetLineWidth(fe.Thickness.Value);
        canvas.SetColorStroke(fe.Color);
        this.SetLineDash(canvas, fe);
        float num1 = Math.Min(fe.X1.Value, fe.X2.Value);
        float num2 = Math.Max(fe.X1.Value, fe.X2.Value);
        float num3 = Math.Min(fe.Y1.Value, fe.Y2.Value);
        float num4 = Math.Max(fe.Y1.Value, fe.Y2.Value);
        canvas.MoveTo(num1, num3);
        canvas.LineTo(num2, num4);
        canvas.Stroke();
      }
    }
    return saveState;
  }

  protected virtual bool DrawCombElementLines(
    FormattingElement bottom,
    FormattingElement vertical,
    PdfContentByte canvas,
    bool saveState)
  {
    if ("visible".Equals(bottom.Presence))
    {
      float? thickness = bottom.Thickness;
      if (((double) thickness.GetValueOrDefault() <= 0.001 ? 0 : (thickness.HasValue ? 1 : 0)) != 0)
      {
        if (!saveState)
        {
          canvas.SaveState();
          if (canvas.IsTagged())
            canvas.OpenMCBlock((IAccessibleElement) this);
          saveState = true;
        }
        canvas.SetLineWidth(bottom.Thickness.Value);
        canvas.SetColorStroke(bottom.Color);
        this.SetLineDash(canvas, bottom);
        int num1 = 1;
        while (true)
        {
          int num2 = num1;
          int? elementCellsNumber = this.combElementCellsNumber;
          if ((num2 >= elementCellsNumber.GetValueOrDefault() ? 0 : (elementCellsNumber.HasValue ? 1 : 0)) != 0)
          {
            float num3 = Math.Min(bottom.X1.Value, bottom.X2.Value) + Math.Abs(bottom.X1.Value - bottom.X2.Value) * (float) num1 / (float) this.combElementCellsNumber.Value;
            float num4 = num3;
            float num5 = Math.Min(vertical.Y1.Value, vertical.Y2.Value);
            float num6 = Math.Max(vertical.Y1.Value, vertical.Y2.Value);
            canvas.MoveTo(num3, num5);
            canvas.LineTo(num4, num6);
            ++num1;
          }
          else
            break;
        }
        canvas.Stroke();
      }
    }
    return saveState;
  }

  protected virtual bool DrawCorner(
    CornerFormattingElement fe,
    PdfContentByte canvas,
    bool saveState)
  {
    if ("visible".Equals(fe.Presence))
    {
      float? thickness = fe.Thickness;
      if (((double) thickness.GetValueOrDefault() <= 0.001 ? 0 : (thickness.HasValue ? 1 : 0)) != 0)
      {
        if (!saveState)
        {
          canvas.SaveState();
          if (canvas.IsTagged())
            canvas.OpenMCBlock((IAccessibleElement) this);
          saveState = true;
        }
        if ("round".Equals(fe.Join))
        {
          canvas.SetLineWidth(fe.Thickness.Value);
          canvas.SetColorStroke(fe.Color);
          this.SetLineDash(canvas, (FormattingElement) fe);
          canvas.SaveState();
          canvas.Rectangle(fe.CenterX.Value, fe.CenterY.Value, (float) (((double) fe.X1.Value - (double) fe.X2.Value) * 2.0), (float) (((double) fe.Y1.Value - (double) fe.Y2.Value) * 2.0));
          canvas.Clip();
          canvas.NewPath();
          canvas.SetLineWidth(fe.Thickness.Value);
          canvas.SetColorStroke(fe.Color);
          this.SetLineDash(canvas, (FormattingElement) fe);
          canvas.Circle(fe.CenterX.Value, fe.CenterY.Value, fe.Radius.Value);
          canvas.Stroke();
          canvas.RestoreState();
          if (fe.IsInverted())
          {
            canvas.MoveTo(fe.X1.Value, fe.CenterY.Value);
            canvas.LineTo(fe.X1.Value, fe.Y2.Value);
            canvas.Stroke();
            canvas.MoveTo(fe.CenterX.Value, fe.Y1.Value);
            canvas.LineTo(fe.X2.Value, fe.Y1.Value);
            canvas.Stroke();
          }
        }
        else
        {
          canvas.SetLineWidth(fe.Thickness.Value);
          canvas.SetColorStroke(fe.Color);
          this.SetLineDash(canvas, (FormattingElement) fe);
          canvas.MoveTo(fe.X1.Value, fe.Y2.Value);
          canvas.LineTo(fe.X1.Value, fe.Y1.Value);
          canvas.LineTo(fe.X2.Value, fe.Y1.Value);
          canvas.Stroke();
        }
      }
    }
    return saveState;
  }

  public override bool IsEmpty()
  {
    if (this.fill.Value)
      return false;
    if (this.borderEdges != null)
    {
      if (this.hasOtherStyle)
      {
        foreach (FormattingElement borderEdge in (IEnumerable<FormattingElement>) this.borderEdges)
        {
          if ("visible".Equals(borderEdge.Presence))
          {
            float? thickness = borderEdge.Thickness;
            if (((double) thickness.GetValueOrDefault() <= 0.001 ? 0 : (thickness.HasValue ? 1 : 0)) != 0)
              return false;
          }
        }
      }
      else if (!"hidden".Equals(this.borderEdges[0].Presence))
        return false;
    }
    if (this.borderCorners != null)
    {
      foreach (CornerFormattingElement borderCorner in (IEnumerable<CornerFormattingElement>) this.borderCorners)
      {
        if ("visible".Equals(borderCorner.Presence))
        {
          float? thickness = borderCorner.Thickness;
          if (((double) thickness.GetValueOrDefault() <= 0.001 ? 0 : (thickness.HasValue ? 1 : 0)) != 0)
          {
            float? radius = borderCorner.Radius;
            if (((double) radius.GetValueOrDefault() != 0.0 ? 1 : (!radius.HasValue ? 1 : 0)) != 0)
              return false;
          }
        }
      }
    }
    return true;
  }

  public virtual float[] GetBorderThicknesses()
  {
    float[] borderThicknesses = (float[]) null;
    if (this.borderEdges != null && this.borderEdges.Count == 4)
    {
      borderThicknesses = new float[4];
      borderThicknesses[0] = borderThicknesses[1] = borderThicknesses[2] = borderThicknesses[3] = 0.0f;
      FormattingElement borderEdge1 = this.borderEdges[0];
      if (FormattingElement.StrokeType.LOWERED.Equals(borderEdge1.Stroke) || FormattingElement.StrokeType.ETCHED.Equals(borderEdge1.Stroke) || FormattingElement.StrokeType.RAISED.Equals(borderEdge1.Stroke) || FormattingElement.StrokeType.EMBOSSED.Equals(borderEdge1.Stroke))
      {
        float[] numArray1 = borderThicknesses;
        float[] numArray2 = borderThicknesses;
        float[] numArray3 = borderThicknesses;
        float[] numArray4 = borderThicknesses;
        float? thickness = borderEdge1.Thickness;
        double num1;
        float num2 = (float) (num1 = (double) thickness.Value * 4.0);
        numArray4[3] = (float) num1;
        double num3;
        float num4 = (float) (num3 = (double) num2);
        numArray3[2] = (float) num3;
        double num5;
        float num6 = (float) (num5 = (double) num4);
        numArray2[1] = (float) num5;
        double num7 = (double) num6;
        numArray1[0] = (float) num7;
      }
      else
      {
        int index = 0;
        foreach (FormattingElement borderEdge2 in (IEnumerable<FormattingElement>) this.borderEdges)
        {
          borderThicknesses[index] = !"visible".Equals(borderEdge2.Presence) ? 0.0f : borderEdge2.Thickness.Value * 2f;
          ++index;
        }
      }
    }
    return borderThicknesses;
  }

  public virtual bool HasEmbossedStyle()
  {
    return this.hasEmbossedStyle || this.hasEtchedStyle || this.hasLoweredStyle || this.hasRaisedStyle;
  }

  protected virtual void UpdateBorderLinesPoints(XFARectangle rec)
  {
    float llx = rec.Llx.Value;
    float? height = rec.Height;
    float lly = rec.Ury.Value - (height.HasValue ? height.Value : 0.0f);
    float? width = rec.Width;
    float urx = rec.Llx.Value + (width.HasValue ? width.Value : 0.0f);
    float ury = rec.Ury.Value;
    this.SetBorderEdgePoints(llx, lly, urx, ury);
    this.SetBorderCornerPoints(llx, lly, urx, ury);
  }

  protected virtual void SetBorderEdgePoints(float llx, float lly, float urx, float ury)
  {
    if (this.borderEdges == null)
      return;
    float? nullable1 = new float?(0.0f);
    float? nullable2 = new float?(0.0f);
    float? nullable3 = new float?(0.0f);
    float? nullable4 = new float?(0.0f);
    if (this.borderCorners != null)
    {
      nullable1 = this.borderCorners[0].Radius;
      nullable2 = this.borderCorners[1].Radius;
      nullable3 = this.borderCorners[2].Radius;
      nullable4 = this.borderCorners[3].Radius;
    }
    this.borderEdges[0].SetRectanglePoints(new float?(llx), new float?(ury), new float?(urx), new float?(ury));
    this.borderEdges[1].SetRectanglePoints(new float?(urx), new float?(ury), new float?(urx), new float?(lly));
    this.borderEdges[2].SetRectanglePoints(new float?(urx), new float?(lly), new float?(llx), new float?(lly));
    this.borderEdges[3].SetRectanglePoints(new float?(llx), new float?(lly), new float?(llx), new float?(ury));
    float? nullable5 = nullable1;
    float? nullable6;
    float? nullable7;
    if (((double) nullable5.GetValueOrDefault() != 0.0 ? 1 : (!nullable5.HasValue ? 1 : 0)) != 0)
    {
      FormattingElement borderEdge1 = this.borderEdges[0];
      nullable6 = this.borderEdges[0].X1;
      nullable7 = nullable1;
      float? nullable8 = nullable6.HasValue & nullable7.HasValue ? new float?(nullable6.GetValueOrDefault() + nullable7.GetValueOrDefault()) : new float?();
      borderEdge1.X1 = nullable8;
      FormattingElement borderEdge2 = this.borderEdges[3];
      float? y2 = this.borderEdges[3].Y2;
      float? nullable9 = nullable1;
      float? nullable10 = y2.HasValue & nullable9.HasValue ? new float?(y2.GetValueOrDefault() - nullable9.GetValueOrDefault()) : new float?();
      borderEdge2.Y2 = nullable10;
    }
    else
    {
      FormattingElement borderEdge3 = this.borderEdges[0];
      float? x1 = this.borderEdges[0].X1;
      float? thickness1 = this.borderEdges[3].Thickness;
      float? nullable11 = thickness1.HasValue ? new float?(thickness1.GetValueOrDefault() / 2f) : new float?();
      float? nullable12 = x1.HasValue & nullable11.HasValue ? new float?(x1.GetValueOrDefault() - nullable11.GetValueOrDefault()) : new float?();
      borderEdge3.X1 = nullable12;
      FormattingElement borderEdge4 = this.borderEdges[3];
      float? y2 = this.borderEdges[3].Y2;
      float? thickness2 = this.borderEdges[0].Thickness;
      float? nullable13 = thickness2.HasValue ? new float?(thickness2.GetValueOrDefault() / 2f) : new float?();
      float? nullable14 = y2.HasValue & nullable13.HasValue ? new float?(y2.GetValueOrDefault() + nullable13.GetValueOrDefault()) : new float?();
      borderEdge4.Y2 = nullable14;
    }
    float? nullable15 = nullable2;
    if (((double) nullable15.GetValueOrDefault() != 0.0 ? 1 : (!nullable15.HasValue ? 1 : 0)) != 0)
    {
      FormattingElement borderEdge5 = this.borderEdges[0];
      float? x2 = this.borderEdges[0].X2;
      float? nullable16 = nullable2;
      float? nullable17 = x2.HasValue & nullable16.HasValue ? new float?(x2.GetValueOrDefault() - nullable16.GetValueOrDefault()) : new float?();
      borderEdge5.X2 = nullable17;
      FormattingElement borderEdge6 = this.borderEdges[1];
      float? y1 = this.borderEdges[1].Y1;
      float? nullable18 = nullable2;
      float? nullable19 = y1.HasValue & nullable18.HasValue ? new float?(y1.GetValueOrDefault() - nullable18.GetValueOrDefault()) : new float?();
      borderEdge6.Y1 = nullable19;
    }
    else
    {
      FormattingElement borderEdge7 = this.borderEdges[0];
      float? x2 = this.borderEdges[0].X2;
      float? thickness3 = this.borderEdges[1].Thickness;
      float? nullable20 = thickness3.HasValue ? new float?(thickness3.GetValueOrDefault() / 2f) : new float?();
      float? nullable21 = x2.HasValue & nullable20.HasValue ? new float?(x2.GetValueOrDefault() + nullable20.GetValueOrDefault()) : new float?();
      borderEdge7.X2 = nullable21;
      FormattingElement borderEdge8 = this.borderEdges[1];
      float? y1 = this.borderEdges[1].Y1;
      float? thickness4 = this.borderEdges[0].Thickness;
      float? nullable22 = thickness4.HasValue ? new float?(thickness4.GetValueOrDefault() / 2f) : new float?();
      float? nullable23 = y1.HasValue & nullable22.HasValue ? new float?(y1.GetValueOrDefault() + nullable22.GetValueOrDefault()) : new float?();
      borderEdge8.Y1 = nullable23;
    }
    float? nullable24 = nullable3;
    if (((double) nullable24.GetValueOrDefault() != 0.0 ? 1 : (!nullable24.HasValue ? 1 : 0)) != 0)
    {
      FormattingElement borderEdge9 = this.borderEdges[2];
      float? x1 = this.borderEdges[2].X1;
      float? nullable25 = nullable3;
      float? nullable26 = x1.HasValue & nullable25.HasValue ? new float?(x1.GetValueOrDefault() - nullable25.GetValueOrDefault()) : new float?();
      borderEdge9.X1 = nullable26;
      FormattingElement borderEdge10 = this.borderEdges[1];
      float? y2 = this.borderEdges[1].Y2;
      float? nullable27 = nullable3;
      float? nullable28 = y2.HasValue & nullable27.HasValue ? new float?(y2.GetValueOrDefault() + nullable27.GetValueOrDefault()) : new float?();
      borderEdge10.Y2 = nullable28;
    }
    else
    {
      FormattingElement borderEdge11 = this.borderEdges[2];
      float? x1 = this.borderEdges[2].X1;
      float? thickness5 = this.borderEdges[1].Thickness;
      float? nullable29 = thickness5.HasValue ? new float?(thickness5.GetValueOrDefault() / 2f) : new float?();
      float? nullable30 = x1.HasValue & nullable29.HasValue ? new float?(x1.GetValueOrDefault() + nullable29.GetValueOrDefault()) : new float?();
      borderEdge11.X1 = nullable30;
      FormattingElement borderEdge12 = this.borderEdges[1];
      float? y2 = this.borderEdges[1].Y2;
      float? thickness6 = this.borderEdges[2].Thickness;
      float? nullable31 = thickness6.HasValue ? new float?(thickness6.GetValueOrDefault() / 2f) : new float?();
      float? nullable32 = y2.HasValue & nullable31.HasValue ? new float?(y2.GetValueOrDefault() - nullable31.GetValueOrDefault()) : new float?();
      borderEdge12.Y2 = nullable32;
    }
    float? nullable33 = nullable4;
    if (((double) nullable33.GetValueOrDefault() != 0.0 ? 1 : (!nullable33.HasValue ? 1 : 0)) != 0)
    {
      FormattingElement borderEdge13 = this.borderEdges[2];
      float? x2 = this.borderEdges[2].X2;
      float? nullable34 = nullable4;
      float? nullable35 = x2.HasValue & nullable34.HasValue ? new float?(x2.GetValueOrDefault() + nullable34.GetValueOrDefault()) : new float?();
      borderEdge13.X2 = nullable35;
      FormattingElement borderEdge14 = this.borderEdges[3];
      float? y1 = this.borderEdges[3].Y1;
      float? nullable36 = nullable4;
      float? nullable37 = y1.HasValue & nullable36.HasValue ? new float?(y1.GetValueOrDefault() + nullable36.GetValueOrDefault()) : new float?();
      borderEdge14.Y1 = nullable37;
    }
    else
    {
      FormattingElement borderEdge15 = this.borderEdges[2];
      float? x2 = this.borderEdges[2].X2;
      nullable6 = this.borderEdges[3].Thickness;
      float? nullable38;
      if (!nullable6.HasValue)
      {
        nullable7 = new float?();
        nullable38 = nullable7;
      }
      else
        nullable38 = new float?(nullable6.GetValueOrDefault() / 2f);
      nullable6 = nullable38;
      float? nullable39;
      if (!(x2.HasValue & nullable6.HasValue))
      {
        nullable7 = new float?();
        nullable39 = nullable7;
      }
      else
        nullable39 = new float?(x2.GetValueOrDefault() - nullable6.GetValueOrDefault());
      borderEdge15.X2 = nullable39;
      FormattingElement borderEdge16 = this.borderEdges[3];
      float? y1 = this.borderEdges[3].Y1;
      nullable6 = this.borderEdges[2].Thickness;
      float? nullable40;
      if (!nullable6.HasValue)
      {
        nullable7 = new float?();
        nullable40 = nullable7;
      }
      else
        nullable40 = new float?(nullable6.GetValueOrDefault() / 2f);
      nullable6 = nullable40;
      float? nullable41;
      if (!(y1.HasValue & nullable6.HasValue))
      {
        nullable7 = new float?();
        nullable41 = nullable7;
      }
      else
        nullable41 = new float?(y1.GetValueOrDefault() - nullable6.GetValueOrDefault());
      borderEdge16.Y1 = nullable41;
    }
  }

  protected virtual void SetBorderCornerPoints(float llx, float lly, float urx, float ury)
  {
    if (this.borderCorners == null)
      return;
    float? nullable1 = new float?(0.0f);
    float? nullable2 = new float?(0.0f);
    float? nullable3 = new float?(0.0f);
    float? nullable4 = new float?(0.0f);
    if (this.borderEdges != null)
    {
      nullable1 = this.borderEdges[0].Thickness;
      nullable2 = this.borderEdges[1].Thickness;
      nullable3 = this.borderEdges[2].Thickness;
      nullable4 = this.borderEdges[3].Thickness;
    }
    float? radius1 = this.borderCorners[0].Radius;
    float? nullable5 = radius1;
    float? nullable6;
    if (((double) nullable5.GetValueOrDefault() != 0.0 ? 1 : (!nullable5.HasValue ? 1 : 0)) != 0)
    {
      if (!this.borderCorners[0].IsInverted())
      {
        CornerFormattingElement borderCorner1 = this.borderCorners[0];
        float? x1 = new float?(llx);
        float? y1 = new float?(ury);
        float num1 = llx;
        nullable6 = radius1;
        float? x2 = nullable6.HasValue ? new float?(num1 + nullable6.GetValueOrDefault()) : new float?();
        float num2 = ury;
        float? nullable7 = radius1;
        float? y2 = nullable7.HasValue ? new float?(num2 - nullable7.GetValueOrDefault()) : new float?();
        borderCorner1.SetRectanglePoints(x1, y1, x2, y2);
        CornerFormattingElement borderCorner2 = this.borderCorners[0];
        float num3 = llx;
        float? nullable8 = radius1;
        float? centerX = nullable8.HasValue ? new float?(num3 + nullable8.GetValueOrDefault()) : new float?();
        float num4 = ury;
        float? nullable9 = radius1;
        float? centerY = nullable9.HasValue ? new float?(num4 - nullable9.GetValueOrDefault()) : new float?();
        borderCorner2.SetCenter(centerX, centerY);
      }
      else
      {
        CornerFormattingElement borderCorner = this.borderCorners[0];
        float num5 = llx;
        float? nullable10 = radius1;
        float? x1 = nullable10.HasValue ? new float?(num5 + nullable10.GetValueOrDefault()) : new float?();
        float num6 = ury;
        float? nullable11 = radius1;
        float? y1 = nullable11.HasValue ? new float?(num6 - nullable11.GetValueOrDefault()) : new float?();
        float num7 = llx;
        float? nullable12 = nullable4;
        float? nullable13 = nullable12.HasValue ? new float?(nullable12.GetValueOrDefault() / 2f) : new float?();
        float? x2 = nullable13.HasValue ? new float?(num7 - nullable13.GetValueOrDefault()) : new float?();
        float num8 = ury;
        float? nullable14 = nullable1;
        float? nullable15 = nullable14.HasValue ? new float?(nullable14.GetValueOrDefault() / 2f) : new float?();
        float? y2 = nullable15.HasValue ? new float?(num8 + nullable15.GetValueOrDefault()) : new float?();
        borderCorner.SetRectanglePoints(x1, y1, x2, y2);
        this.borderCorners[0].SetCenter(new float?(llx), new float?(ury));
      }
    }
    float? radius2 = this.borderCorners[1].Radius;
    float? nullable16 = radius2;
    if (((double) nullable16.GetValueOrDefault() != 0.0 ? 1 : (!nullable16.HasValue ? 1 : 0)) != 0)
    {
      if (!this.borderCorners[1].IsInverted())
      {
        CornerFormattingElement borderCorner3 = this.borderCorners[1];
        float? x1 = new float?(urx);
        float? y1 = new float?(ury);
        float num9 = urx;
        float? nullable17 = radius2;
        float? x2 = nullable17.HasValue ? new float?(num9 - nullable17.GetValueOrDefault()) : new float?();
        float num10 = ury;
        float? nullable18 = radius2;
        float? y2 = nullable18.HasValue ? new float?(num10 - nullable18.GetValueOrDefault()) : new float?();
        borderCorner3.SetRectanglePoints(x1, y1, x2, y2);
        CornerFormattingElement borderCorner4 = this.borderCorners[1];
        float num11 = urx;
        float? nullable19 = radius2;
        float? centerX = nullable19.HasValue ? new float?(num11 - nullable19.GetValueOrDefault()) : new float?();
        float num12 = ury;
        float? nullable20 = radius2;
        float? centerY = nullable20.HasValue ? new float?(num12 - nullable20.GetValueOrDefault()) : new float?();
        borderCorner4.SetCenter(centerX, centerY);
      }
      else
      {
        CornerFormattingElement borderCorner = this.borderCorners[1];
        float num13 = urx;
        float? nullable21 = radius2;
        float? x1 = nullable21.HasValue ? new float?(num13 - nullable21.GetValueOrDefault()) : new float?();
        float num14 = ury;
        float? nullable22 = radius2;
        float? y1 = nullable22.HasValue ? new float?(num14 - nullable22.GetValueOrDefault()) : new float?();
        float num15 = urx;
        float? nullable23 = nullable2;
        float? nullable24 = nullable23.HasValue ? new float?(nullable23.GetValueOrDefault() / 2f) : new float?();
        float? x2 = nullable24.HasValue ? new float?(num15 + nullable24.GetValueOrDefault()) : new float?();
        float num16 = ury;
        float? nullable25 = nullable1;
        float? nullable26;
        if (!nullable25.HasValue)
        {
          nullable6 = new float?();
          nullable26 = nullable6;
        }
        else
          nullable26 = new float?(nullable25.GetValueOrDefault() / 2f);
        float? nullable27 = nullable26;
        float? y2;
        if (!nullable27.HasValue)
        {
          nullable6 = new float?();
          y2 = nullable6;
        }
        else
          y2 = new float?(num16 + nullable27.GetValueOrDefault());
        borderCorner.SetRectanglePoints(x1, y1, x2, y2);
        this.borderCorners[1].SetCenter(new float?(urx), new float?(ury));
      }
    }
    float? radius3 = this.borderCorners[2].Radius;
    float? nullable28 = radius3;
    float? nullable29;
    if (((double) nullable28.GetValueOrDefault() != 0.0 ? 1 : (!nullable28.HasValue ? 1 : 0)) != 0)
    {
      if (!this.borderCorners[2].IsInverted())
      {
        CornerFormattingElement borderCorner5 = this.borderCorners[2];
        float? x1 = new float?(urx);
        float? y1 = new float?(lly);
        float num17 = urx;
        nullable29 = radius3;
        float? x2;
        if (!nullable29.HasValue)
        {
          nullable6 = new float?();
          x2 = nullable6;
        }
        else
          x2 = new float?(num17 - nullable29.GetValueOrDefault());
        float num18 = lly;
        nullable29 = radius3;
        float? y2;
        if (!nullable29.HasValue)
        {
          nullable6 = new float?();
          y2 = nullable6;
        }
        else
          y2 = new float?(num18 + nullable29.GetValueOrDefault());
        borderCorner5.SetRectanglePoints(x1, y1, x2, y2);
        CornerFormattingElement borderCorner6 = this.borderCorners[2];
        float num19 = urx;
        nullable29 = radius3;
        float? centerX;
        if (!nullable29.HasValue)
        {
          nullable6 = new float?();
          centerX = nullable6;
        }
        else
          centerX = new float?(num19 - nullable29.GetValueOrDefault());
        float num20 = lly;
        nullable29 = radius3;
        float? centerY;
        if (!nullable29.HasValue)
        {
          nullable6 = new float?();
          centerY = nullable6;
        }
        else
          centerY = new float?(num20 + nullable29.GetValueOrDefault());
        borderCorner6.SetCenter(centerX, centerY);
      }
      else
      {
        CornerFormattingElement borderCorner = this.borderCorners[2];
        float num21 = urx;
        float? nullable30 = radius3;
        float? x1;
        if (!nullable30.HasValue)
        {
          nullable6 = new float?();
          x1 = nullable6;
        }
        else
          x1 = new float?(num21 - nullable30.GetValueOrDefault());
        float num22 = lly;
        float? nullable31 = radius3;
        float? y1;
        if (!nullable31.HasValue)
        {
          nullable6 = new float?();
          y1 = nullable6;
        }
        else
          y1 = new float?(num22 + nullable31.GetValueOrDefault());
        float num23 = urx;
        float? nullable32 = nullable2;
        float? nullable33;
        if (!nullable32.HasValue)
        {
          nullable6 = new float?();
          nullable33 = nullable6;
        }
        else
          nullable33 = new float?(nullable32.GetValueOrDefault() / 2f);
        float? nullable34 = nullable33;
        float? x2;
        if (!nullable34.HasValue)
        {
          nullable6 = new float?();
          x2 = nullable6;
        }
        else
          x2 = new float?(num23 + nullable34.GetValueOrDefault());
        float num24 = lly;
        float? nullable35 = nullable3;
        float? nullable36;
        if (!nullable35.HasValue)
        {
          nullable6 = new float?();
          nullable36 = nullable6;
        }
        else
          nullable36 = new float?(nullable35.GetValueOrDefault() / 2f);
        float? nullable37 = nullable36;
        float? y2;
        if (!nullable37.HasValue)
        {
          nullable6 = new float?();
          y2 = nullable6;
        }
        else
          y2 = new float?(num24 - nullable37.GetValueOrDefault());
        borderCorner.SetRectanglePoints(x1, y1, x2, y2);
        this.borderCorners[2].SetCenter(new float?(urx), new float?(lly));
      }
    }
    float? radius4 = this.borderCorners[3].Radius;
    nullable29 = radius4;
    if (((double) nullable29.GetValueOrDefault() != 0.0 ? 1 : (!nullable29.HasValue ? 1 : 0)) == 0)
      return;
    if (!this.borderCorners[3].IsInverted())
    {
      CornerFormattingElement borderCorner7 = this.borderCorners[3];
      float? x1 = new float?(llx);
      float? y1 = new float?(lly);
      float num25 = llx;
      nullable29 = radius4;
      float? x2;
      if (!nullable29.HasValue)
      {
        nullable6 = new float?();
        x2 = nullable6;
      }
      else
        x2 = new float?(num25 + nullable29.GetValueOrDefault());
      float num26 = lly;
      nullable29 = radius4;
      float? y2;
      if (!nullable29.HasValue)
      {
        nullable6 = new float?();
        y2 = nullable6;
      }
      else
        y2 = new float?(num26 + nullable29.GetValueOrDefault());
      borderCorner7.SetRectanglePoints(x1, y1, x2, y2);
      CornerFormattingElement borderCorner8 = this.borderCorners[3];
      float num27 = llx;
      nullable29 = radius4;
      float? centerX;
      if (!nullable29.HasValue)
      {
        nullable6 = new float?();
        centerX = nullable6;
      }
      else
        centerX = new float?(num27 + nullable29.GetValueOrDefault());
      float num28 = lly;
      nullable29 = radius4;
      float? centerY;
      if (!nullable29.HasValue)
      {
        nullable6 = new float?();
        centerY = nullable6;
      }
      else
        centerY = new float?(num28 + nullable29.GetValueOrDefault());
      borderCorner8.SetCenter(centerX, centerY);
    }
    else
    {
      CornerFormattingElement borderCorner = this.borderCorners[3];
      float num29 = llx;
      nullable29 = radius4;
      float? x1;
      if (!nullable29.HasValue)
      {
        nullable6 = new float?();
        x1 = nullable6;
      }
      else
        x1 = new float?(num29 + nullable29.GetValueOrDefault());
      float num30 = lly;
      nullable29 = radius4;
      float? y1;
      if (!nullable29.HasValue)
      {
        nullable6 = new float?();
        y1 = nullable6;
      }
      else
        y1 = new float?(num30 + nullable29.GetValueOrDefault());
      float num31 = llx;
      nullable29 = nullable4;
      float? nullable38;
      if (!nullable29.HasValue)
      {
        nullable6 = new float?();
        nullable38 = nullable6;
      }
      else
        nullable38 = new float?(nullable29.GetValueOrDefault() / 2f);
      nullable29 = nullable38;
      float? x2;
      if (!nullable29.HasValue)
      {
        nullable6 = new float?();
        x2 = nullable6;
      }
      else
        x2 = new float?(num31 - nullable29.GetValueOrDefault());
      float num32 = lly;
      nullable29 = nullable3;
      float? nullable39;
      if (!nullable29.HasValue)
      {
        nullable6 = new float?();
        nullable39 = nullable6;
      }
      else
        nullable39 = new float?(nullable29.GetValueOrDefault() / 2f);
      nullable29 = nullable39;
      float? y2;
      if (!nullable29.HasValue)
      {
        nullable6 = new float?();
        y2 = nullable6;
      }
      else
        y2 = new float?(num32 - nullable29.GetValueOrDefault());
      borderCorner.SetRectanglePoints(x1, y1, x2, y2);
      this.borderCorners[3].SetCenter(new float?(llx), new float?(lly));
    }
  }

  private void AddBorderLines(IFormNode border)
  {
    if (border == null)
      return;
    string attributeValue1 = XFAUtil.GetAttributeValue("presence", border.RetrieveAttributes());
    if (attributeValue1 != null && !"visible".Equals(attributeValue1))
      return;
    IFormNode formNode1 = border.RetrieveChild("fill");
    if (formNode1 != null)
    {
      string attributeValue2 = XFAUtil.GetAttributeValue("presence", formNode1.RetrieveAttributes());
      if (attributeValue2 == null || "visible".Equals(attributeValue2))
      {
        this.fill = new bool?(true);
        IFormNode formNode2 = formNode1.RetrieveChild("color");
        if (formNode2 != null)
        {
          IDictionary<string, string> dictionary = formNode2.RetrieveAttributes();
          if (dictionary != null)
          {
            string xfaColor;
            dictionary.TryGetValue("value", out xfaColor);
            if (xfaColor != null && xfaColor.Length > 0)
              this.fillColor = XFAUtil.ParseXfaColor(xfaColor);
          }
        }
      }
    }
    IList<IFormNode> formNodeList1 = border.RetrieveChildren("edge");
    IList<IFormNode> formNodeList2 = border.RetrieveChildren("corner");
    if (formNodeList1 != null && formNodeList1.Count > 0)
    {
      if (formNodeList1.Count == 1)
      {
        formNodeList1.Add(formNodeList1[0]);
        formNodeList1.Add(formNodeList1[0]);
        formNodeList1.Add(formNodeList1[0]);
      }
      else if (formNodeList1.Count == 2)
      {
        formNodeList1.Add(formNodeList1[0]);
        formNodeList1.Add(formNodeList1[1]);
      }
      else if (formNodeList1.Count == 3)
        formNodeList1.Add(formNodeList1[1]);
      int count = formNodeList1.Count;
      string[] strArray1 = new string[count];
      string[] strArray2 = new string[count];
      string[] strArray3 = new string[count];
      BaseColor[] baseColorArray = new BaseColor[count];
      for (int index = 0; index < count; ++index)
      {
        IDictionary<string, string> dictionary1 = formNodeList1[index].RetrieveAttributes();
        if (dictionary1 != null)
        {
          dictionary1.TryGetValue("presence", out strArray1[index]);
          dictionary1.TryGetValue("thickness", out strArray2[index]);
          dictionary1.TryGetValue("stroke", out strArray3[index]);
        }
        IFormNode formNode3 = formNodeList1[index].RetrieveChild("color");
        if (formNode3 != null)
        {
          IDictionary<string, string> dictionary2 = formNode3.RetrieveAttributes();
          if (dictionary2 != null)
          {
            string xfaColor = (string) null;
            dictionary2.TryGetValue("value", out xfaColor);
            if (xfaColor != null && xfaColor.Length > 0)
              baseColorArray[index] = XFAUtil.ParseXfaColor(xfaColor);
          }
        }
      }
      this.InitBorderEdges(false);
      int index1 = 0;
      foreach (FormattingElement borderEdge in (IEnumerable<FormattingElement>) this.borderEdges)
      {
        string str1 = strArray1[index1];
        if (str1 != null)
          borderEdge.Presence = str1;
        string str2 = strArray2[index1];
        if (str2 != null)
          borderEdge.Thickness = new float?(CssUtils.GetInstance().ParsePxInCmMmPcToPt(str2, "pt"));
        string str3 = strArray3[index1];
        if (str3 != null)
          borderEdge.Stroke = str3;
        BaseColor baseColor = baseColorArray[index1];
        if (baseColor != null)
          borderEdge.Color = baseColor;
        ++index1;
        if (index1 == count)
          index1 = 0;
      }
    }
    else if (formNodeList2 == null || formNodeList2.Count == 0)
      this.InitBorderEdges(false);
    else
      this.InitBorderEdges(true);
    if (formNodeList2 != null && formNodeList2.Count > 0)
    {
      if (formNodeList2.Count == 1)
      {
        formNodeList2.Add(formNodeList2[0]);
        formNodeList2.Add(formNodeList2[0]);
        formNodeList2.Add(formNodeList2[0]);
      }
      else if (formNodeList2.Count == 2)
      {
        formNodeList2.Add(formNodeList2[0]);
        formNodeList2.Add(formNodeList2[1]);
      }
      else if (formNodeList2.Count == 3)
        formNodeList2.Add(formNodeList2[1]);
      int count = formNodeList2.Count;
      string[] strArray4 = new string[count];
      string[] strArray5 = new string[count];
      string[] strArray6 = new string[count];
      BaseColor[] baseColorArray = new BaseColor[count];
      string[] strArray7 = new string[count];
      string[] strArray8 = new string[count];
      string[] strArray9 = new string[count];
      for (int index = 0; index < count; ++index)
      {
        IDictionary<string, string> dictionary3 = formNodeList2[index].RetrieveAttributes();
        if (dictionary3 != null)
        {
          dictionary3.TryGetValue("presence", out strArray4[index]);
          dictionary3.TryGetValue("thickness", out strArray5[index]);
          dictionary3.TryGetValue("stroke", out strArray6[index]);
          dictionary3.TryGetValue("radius", out strArray7[index]);
          dictionary3.TryGetValue("join", out strArray8[index]);
          dictionary3.TryGetValue("inverted", out strArray9[index]);
        }
        IFormNode formNode4 = formNodeList2[index].RetrieveChild("color");
        if (formNode4 != null)
        {
          IDictionary<string, string> dictionary4 = formNode4.RetrieveAttributes();
          if (dictionary4 != null)
          {
            string xfaColor = (string) null;
            dictionary4.TryGetValue("value", out xfaColor);
            if (xfaColor != null && xfaColor.Length > 0)
              baseColorArray[index] = XFAUtil.ParseXfaColor(xfaColor);
          }
        }
      }
      this.borderCorners = (IList<CornerFormattingElement>) new List<CornerFormattingElement>();
      this.InitBorderCorners();
      int index2 = 0;
      foreach (CornerFormattingElement borderCorner in (IEnumerable<CornerFormattingElement>) this.borderCorners)
      {
        string str4 = strArray4[index2];
        if (str4 != null)
          borderCorner.Presence = str4;
        string str5 = strArray5[index2];
        if (str5 != null)
          borderCorner.Thickness = new float?(CssUtils.GetInstance().ParsePxInCmMmPcToPt(str5, "pt"));
        string str6 = strArray6[index2];
        if (str6 != null)
          borderCorner.Stroke = str6;
        string str7 = strArray7[index2];
        if (str7 != null)
          borderCorner.Radius = new float?(CssUtils.GetInstance().ParsePxInCmMmPcToPt(str7, "pt"));
        string str8 = strArray9[index2];
        if (str8 != null)
          borderCorner.Inverted = str8;
        string str9 = strArray8[index2];
        if (str9 != null)
          borderCorner.Join = str9;
        BaseColor baseColor = baseColorArray[index2];
        if (baseColor != null)
          borderCorner.Color = baseColor;
        ++index2;
        if (index2 == count)
          index2 = 0;
      }
    }
    if (!this.IgnoreCorners())
      return;
    this.borderCorners = (IList<CornerFormattingElement>) null;
  }

  private bool IgnoreCorners()
  {
    if (this.borderCorners == null)
      return false;
    float num = this.borderEdges[0].Thickness.Value;
    string stroke = this.borderEdges[0].Stroke;
    BaseColor color = this.borderEdges[0].Color;
    string presence1 = this.borderEdges[0].Presence;
    for (int index = 1; index < this.borderEdges.Count; ++index)
    {
      if (!stroke.Equals(this.borderEdges[index].Stroke) || !color.Equals((object) this.borderEdges[index].Color) || !presence1.Equals(this.borderEdges[index].Presence) || (double) Math.Abs(num - this.borderEdges[index].Thickness.Value) >= 0.0005)
        return false;
    }
    string presence2 = this.borderCorners[0].Presence;
    for (int index = 0; index < this.borderCorners.Count; ++index)
    {
      if ("1".Equals(this.borderCorners[index].Inverted) || "round".Equals(this.borderCorners[index].Join) || !stroke.Equals(this.borderCorners[index].Stroke) || !color.Equals((object) this.borderCorners[index].Color) || !presence2.Equals(this.borderCorners[index].Presence) || (double) Math.Abs(num - this.borderCorners[index].Thickness.Value) >= 0.0005)
        return false;
    }
    return true;
  }

  protected virtual void InitBorderEdges(bool empty)
  {
    this.borderEdges = (IList<FormattingElement>) new List<FormattingElement>();
    this.borderEdges.Add(new FormattingElement());
    this.borderEdges.Add(new FormattingElement());
    this.borderEdges.Add(new FormattingElement());
    this.borderEdges.Add(new FormattingElement());
    if (!empty)
      return;
    foreach (FormattingElement borderEdge in (IEnumerable<FormattingElement>) this.borderEdges)
      borderEdge.Thickness = new float?(0.0f);
  }

  protected virtual void InitBorderCorners()
  {
    this.borderCorners = (IList<CornerFormattingElement>) new List<CornerFormattingElement>();
    this.borderCorners.Add(new CornerFormattingElement());
    this.borderCorners.Add(new CornerFormattingElement());
    this.borderCorners.Add(new CornerFormattingElement());
    this.borderCorners.Add(new CornerFormattingElement());
  }

  protected virtual void CalculateStyle()
  {
    if (this.borderEdges == null)
      return;
    foreach (FormattingElement borderEdge in (IEnumerable<FormattingElement>) this.borderEdges)
    {
      if (FormattingElement.StrokeType.LOWERED.Equals(borderEdge.Stroke))
        this.hasLoweredStyle = true;
      else if (FormattingElement.StrokeType.EMBOSSED.Equals(borderEdge.Stroke))
        this.hasEmbossedStyle = true;
      else if (FormattingElement.StrokeType.ETCHED.Equals(borderEdge.Stroke))
        this.hasEtchedStyle = true;
      else if (FormattingElement.StrokeType.RAISED.Equals(borderEdge.Stroke))
        this.hasRaisedStyle = true;
      else
        this.hasOtherStyle = true;
    }
    if (this.borderCorners != null)
    {
      foreach (CornerFormattingElement borderCorner in (IEnumerable<CornerFormattingElement>) this.borderCorners)
      {
        if (FormattingElement.StrokeType.LOWERED.Equals(borderCorner.Stroke))
          this.hasLoweredStyle = true;
        else if (FormattingElement.StrokeType.EMBOSSED.Equals(borderCorner.Stroke))
          this.hasEmbossedStyle = true;
        else if (FormattingElement.StrokeType.ETCHED.Equals(borderCorner.Stroke))
          this.hasEtchedStyle = true;
        else if (FormattingElement.StrokeType.RAISED.Equals(borderCorner.Stroke))
        {
          this.hasRaisedStyle = true;
        }
        else
        {
          float? radius = borderCorner.Radius;
          if (((double) radius.GetValueOrDefault() <= 0.0 ? 0 : (radius.HasValue ? 1 : 0)) != 0)
            this.hasOtherStyle = true;
        }
      }
    }
    if (!this.hasOtherStyle)
      return;
    this.hasLoweredStyle = false;
    this.hasEmbossedStyle = false;
    this.hasEtchedStyle = false;
    this.hasRaisedStyle = false;
    foreach (FormattingElement borderEdge in (IEnumerable<FormattingElement>) this.borderEdges)
    {
      if (FormattingElement.StrokeType.LOWERED.Equals(borderEdge.Stroke) || FormattingElement.StrokeType.EMBOSSED.Equals(borderEdge.Stroke) || FormattingElement.StrokeType.ETCHED.Equals(borderEdge.Stroke) || FormattingElement.StrokeType.RAISED.Equals(borderEdge.Stroke))
        borderEdge.Stroke = FormattingElement.StrokeType.SOLID;
    }
    if (this.borderCorners == null)
      return;
    foreach (FormattingElement borderCorner in (IEnumerable<CornerFormattingElement>) this.borderCorners)
    {
      if (FormattingElement.StrokeType.LOWERED.Equals(borderCorner.Stroke) || FormattingElement.StrokeType.EMBOSSED.Equals(borderCorner.Stroke) || FormattingElement.StrokeType.ETCHED.Equals(borderCorner.Stroke) || FormattingElement.StrokeType.RAISED.Equals(borderCorner.Stroke))
        borderCorner.Stroke = FormattingElement.StrokeType.SOLID;
    }
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

  public virtual void SetCombElementBorder(int combElementCellsNumber)
  {
    this.isCombElementBorder = true;
    this.combElementCellsNumber = new int?(combElementCellsNumber);
  }
}
