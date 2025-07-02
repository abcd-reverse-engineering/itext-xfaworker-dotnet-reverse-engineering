// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.element.MarkDrawer
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.interfaces;
using iTextSharp.tool.xml.xtra.xfa.util;
using System.Collections.Generic;
using System.util;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.element;

public class MarkDrawer : AbstractDrawer
{
  private float size;
  private string shape;
  private string mark;
  private bool hasEmbossedStyle;
  private readonly float thickness;
  private readonly BaseColor markColor;
  private Dictionary<char, PdfTemplate> symbols;

  public MarkDrawer(
    float size,
    string shape,
    string mark,
    bool hasLoweredStyle,
    float thickness,
    BaseColor markColor)
  {
    this.size = size;
    this.mark = mark;
    this.shape = shape;
    this.hasEmbossedStyle = hasLoweredStyle;
    this.thickness = thickness;
    this.markColor = markColor;
  }

  public override void Draw(PdfContentByte canvas, XFARectangle rec)
  {
    if (Util.EqualsIgnoreCase("default", this.mark))
      this.DrawDefaultMark(canvas, rec);
    else if (Util.EqualsIgnoreCase("check", this.mark))
      this.DrawCheckMark(canvas, rec);
    else if (Util.EqualsIgnoreCase("circle", this.mark))
      this.DrawCircleMark(canvas, rec);
    else if (Util.EqualsIgnoreCase("cross", this.mark))
      this.DrawCrossMark(canvas, rec);
    else if (Util.EqualsIgnoreCase("diamond", this.mark))
      this.DrawDiamondMark(canvas, rec);
    else if (Util.EqualsIgnoreCase("square", this.mark))
    {
      this.DrawSquareMark(canvas, rec);
    }
    else
    {
      if (!Util.EqualsIgnoreCase("star", this.mark))
        return;
      this.DrawStarMark(canvas, rec);
    }
  }

  public override bool IsEmpty() => false;

  protected virtual void DrawDefaultRectangleMark(PdfContentByte canvas, XFARectangle rec)
  {
    canvas.SetLineWidth(this.thickness);
    float num = !this.hasEmbossedStyle ? this.size - this.thickness * 2f : this.size - this.thickness * 5f;
    canvas.MoveTo(rec.Llx.Value + (float) (((double) rec.Width.Value - (double) num) / 2.0), (float) ((double) rec.Ury.Value - (double) rec.Height.Value + ((double) rec.Height.Value - (double) num) / 2.0));
    canvas.LineTo((float) ((double) rec.Llx.Value + (double) rec.Width.Value - ((double) rec.Width.Value - (double) num) / 2.0), rec.Ury.Value - (float) (((double) rec.Height.Value - (double) num) / 2.0));
    canvas.Stroke();
    canvas.MoveTo(rec.Llx.Value + (float) (((double) rec.Width.Value - (double) num) / 2.0), rec.Ury.Value - (float) (((double) rec.Height.Value - (double) num) / 2.0));
    canvas.LineTo((float) ((double) rec.Llx.Value + (double) rec.Width.Value - ((double) rec.Width.Value - (double) num) / 2.0), (float) ((double) rec.Ury.Value - (double) rec.Height.Value + ((double) rec.Height.Value - (double) num) / 2.0));
    canvas.Stroke();
  }

  protected virtual void DrawDefaultRoundMark(PdfContentByte canvas, XFARectangle rec)
  {
    float size = this.size;
    float num = !this.hasEmbossedStyle ? this.size * 0.25f : this.size * 0.2f;
    canvas.Circle(rec.Llx.Value + this.size / 2f, rec.Ury.Value - this.size / 2f, num);
    canvas.Fill();
  }

  protected virtual void DrawDefaultMark(PdfContentByte canvas, XFARectangle rec)
  {
    if (canvas.IsTagged())
      canvas.OpenMCBlock((IAccessibleElement) this);
    canvas.SaveState();
    if (this.markColor != null)
    {
      canvas.SetColorStroke(this.markColor);
      canvas.SetColorFill(this.markColor);
    }
    if (Util.EqualsIgnoreCase("rectangle", this.shape))
      this.DrawDefaultRectangleMark(canvas, rec);
    else if (Util.EqualsIgnoreCase("round", this.shape))
      this.DrawDefaultRoundMark(canvas, rec);
    canvas.RestoreState();
    if (!canvas.IsTagged())
      return;
    canvas.CloseMCBlock((IAccessibleElement) this);
  }

  protected virtual void DrawCheckMark(PdfContentByte canvas, XFARectangle rec)
  {
    this.DrawSymbolicMark(canvas, rec, '4', 0.7f);
  }

  protected virtual void DrawCircleMark(PdfContentByte canvas, XFARectangle rec)
  {
    this.DrawSymbolicMark(canvas, rec, 'l');
  }

  protected virtual void DrawCrossMark(PdfContentByte canvas, XFARectangle rec)
  {
    this.DrawSymbolicMark(canvas, rec, '6');
  }

  protected virtual void DrawDiamondMark(PdfContentByte canvas, XFARectangle rec)
  {
    this.DrawSymbolicMark(canvas, rec, 'u');
  }

  protected virtual void DrawSquareMark(PdfContentByte canvas, XFARectangle rec)
  {
    this.DrawSymbolicMark(canvas, rec, 'n');
  }

  protected virtual void DrawStarMark(PdfContentByte canvas, XFARectangle rec)
  {
    this.DrawSymbolicMark(canvas, rec, 'H');
  }

  protected virtual void DrawSymbolicMark(PdfContentByte canvas, XFARectangle rec, char symbol)
  {
    this.DrawSymbolicMark(canvas, rec, symbol, 0.8f);
  }

  protected virtual PdfTemplate GetSymbolTemplate(char symbol, PdfWriter writer)
  {
    if (this.symbols == null)
      this.symbols = new Dictionary<char, PdfTemplate>();
    if (!this.symbols.ContainsKey(symbol))
    {
      PdfTemplate template = PdfTemplate.CreateTemplate(writer, 0.0f, 0.0f);
      switch (symbol)
      {
        case '4':
          template.BoundingBox = new Rectangle(29f, -149.849f, 817f, 783.128f);
          ((PdfContentByte) template).MoveTo(119f, 292f);
          ((PdfContentByte) template).CurveTo(95f, 284f, 48f, 251f, 29f, 235f);
          ((PdfContentByte) template).CurveTo(80f, 157f, 154f, 1f, 188f, -104f);
          ((PdfContentByte) template).CurveTo(193f, -120f, 262f, -166f, 272f, -144f);
          ((PdfContentByte) template).CurveTo(372f, 88f, 658f, 602f, 817f, 781f);
          ((PdfContentByte) template).CurveTo(793f, 785f, 737f, 783f, 719f, 778f);
          ((PdfContentByte) template).CurveTo(695f, 771f, 685f, 763f, 668f, 750f);
          ((PdfContentByte) template).CurveTo(576f, 680f, 376f, 372f, (float) byte.MaxValue, 143f);
          ((PdfContentByte) template).CurveTo(241f, 182f, 207f, 236f, 185f, 266f);
          ((PdfContentByte) template).CurveTo(167f, 290f, 140f, 298f, 119f, 292f);
          ((PdfContentByte) template).ClosePath();
          ((PdfContentByte) template).Fill();
          break;
        case '6':
          template.BoundingBox = new Rectangle(29f, 5f, 732f, 698f);
          ((PdfContentByte) template).MoveTo(720f, 672f);
          ((PdfContentByte) template).LineTo(729f, 658f);
          ((PdfContentByte) template).CurveTo(713f, 617f, 556f, 432f, 471f, 345f);
          ((PdfContentByte) template).CurveTo(537f, (float) byte.MaxValue, 695f, 68f, 732f, 34f);
          ((PdfContentByte) template).LineTo(730f, 19f);
          ((PdfContentByte) template).CurveTo(720f, 14f, 604f, 5f, 592f, 5f);
          ((PdfContentByte) template).CurveTo(568f, 5f, 538f, 18f, 495f, 57f);
          ((PdfContentByte) template).CurveTo(470f, 80f, 416f, 141f, 369f, 192f);
          ((PdfContentByte) template).CurveTo(360f, 201f, 343f, 203f, 338f, 196f);
          ((PdfContentByte) template).CurveTo(253f, 89f, 214f, 62f, 194f, 50f);
          ((PdfContentByte) template).CurveTo(158f, 27f, 63f, 12f, 35f, 9f);
          ((PdfContentByte) template).LineTo(29f, 24f);
          ((PdfContentByte) template).CurveTo(59f, 51f, 217f, 239f, 253f, 285f);
          ((PdfContentByte) template).CurveTo(258f, 290f, 260f, 305f, (float) byte.MaxValue, 311f);
          ((PdfContentByte) template).CurveTo(164f, 414f, 108f, 482f, 90f, 514f);
          ((PdfContentByte) template).CurveTo(69f, 551f, 67f, 568f, 74f, 586f);
          ((PdfContentByte) template).CurveTo(82f, 604f, 162f, 687f, 186f, 698f);
          ((PdfContentByte) template).LineTo(200f, 698f);
          ((PdfContentByte) template).CurveTo(229f, 642f, 322f, 514f, 391f, 445f);
          ((PdfContentByte) template).CurveTo(445f, 499f, 518f, 596f, 549f, 645f);
          ((PdfContentByte) template).CurveTo(553f, 652f, 680f, 669f, 720f, 672f);
          ((PdfContentByte) template).ClosePath();
          ((PdfContentByte) template).Fill();
          break;
        case 'H':
          template.BoundingBox = new Rectangle(35f, -13f, 782f, 707f);
          ((PdfContentByte) template).MoveTo(409f, 707f);
          ((PdfContentByte) template).LineTo(494f, 437f);
          ((PdfContentByte) template).LineTo(782f, 437f);
          ((PdfContentByte) template).LineTo(551f, 263f);
          ((PdfContentByte) template).LineTo(640f, -13f);
          ((PdfContentByte) template).LineTo(409f, 157f);
          ((PdfContentByte) template).LineTo(179f, -13f);
          ((PdfContentByte) template).LineTo(269f, 263f);
          ((PdfContentByte) template).LineTo(35f, 437f);
          ((PdfContentByte) template).LineTo(322f, 437f);
          ((PdfContentByte) template).LineTo(409f, 707f);
          ((PdfContentByte) template).ClosePath();
          ((PdfContentByte) template).Fill();
          break;
        case 'l':
          template.BoundingBox = new Rectangle(35f, -14f, 757f, 708f);
          ((PdfContentByte) template).MoveTo(402f, 708f);
          ((PdfContentByte) template).CurveTo(595f, 708f, 757f, 544f, 757f, 347f);
          ((PdfContentByte) template).CurveTo(757f, 148f, 595f, -14f, 396f, -14f);
          ((PdfContentByte) template).CurveTo(196f, -14f, 35f, 148f, 35f, 350f);
          ((PdfContentByte) template).CurveTo(35f, 549f, 198f, 708f, 402f, 708f);
          ((PdfContentByte) template).ClosePath();
          ((PdfContentByte) template).Fill();
          break;
        case 'n':
          template.BoundingBox = new Rectangle(35f, 0.0f, 726f, 691f);
          ((PdfContentByte) template).MoveTo(726f, 0.0f);
          ((PdfContentByte) template).LineTo(35f, 0.0f);
          ((PdfContentByte) template).LineTo(35f, 691f);
          ((PdfContentByte) template).LineTo(726f, 691f);
          ((PdfContentByte) template).LineTo(726f, 0.0f);
          ((PdfContentByte) template).ClosePath();
          ((PdfContentByte) template).Fill();
          break;
        case 'u':
          template.BoundingBox = new Rectangle(35f, -14f, 754f, 705f);
          ((PdfContentByte) template).MoveTo(395f, -14f);
          ((PdfContentByte) template).LineTo(35f, 346f);
          ((PdfContentByte) template).LineTo(395f, 705f);
          ((PdfContentByte) template).LineTo(754f, 346f);
          ((PdfContentByte) template).LineTo(395f, -14f);
          ((PdfContentByte) template).ClosePath();
          ((PdfContentByte) template).Fill();
          break;
      }
      this.symbols[symbol] = template;
    }
    PdfTemplate symbolTemplate;
    this.symbols.TryGetValue(symbol, out symbolTemplate);
    return symbolTemplate;
  }

  protected virtual void DrawSymbolicMark(
    PdfContentByte canvas,
    XFARectangle rec,
    char symbol,
    float fontSizeScaler)
  {
    Paragraph paragraph = (Paragraph) null;
    if (canvas.IsTagged())
    {
      paragraph = new Paragraph();
      canvas.OpenMCBlock((IAccessibleElement) paragraph);
      canvas.OpenMCBlock((IAccessibleElement) this);
    }
    float num1 = this.size * fontSizeScaler;
    PdfTemplate symbolTemplate = this.GetSymbolTemplate(symbol, canvas.PdfWriter);
    float num2 = num1 / 1000f;
    float num3 = symbolTemplate.Width * num2;
    float num4 = symbolTemplate.Height * num2;
    canvas.Fill();
    canvas.AddTemplate(symbolTemplate, num2, 0.0f, 0.0f, num2, (float) ((double) rec.Llx.Value + ((double) rec.Width.Value - (double) num3) / 2.0 - (double) symbolTemplate.BoundingBox.Left * (double) num2), (float) ((double) rec.Ury.Value - ((double) rec.Height.Value + (double) num4) / 2.0 - (double) symbolTemplate.BoundingBox.Bottom * (double) num2));
    if (!canvas.IsTagged())
      return;
    canvas.CloseMCBlock((IAccessibleElement) paragraph);
    canvas.CloseMCBlock((IAccessibleElement) this);
  }
}
