// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.element.LineDrawer
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.text.pdf;
using iTextSharp.text.pdf.interfaces;
using iTextSharp.tool.xml.xtra.xfa.format;
using iTextSharp.tool.xml.xtra.xfa.tags;
using iTextSharp.tool.xml.xtra.xfa.util;
using System.Collections.Generic;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.element;

public class LineDrawer : BorderDrawer
{
  protected LineDrawer.Slope slope;

  public LineDrawer(IFormNode border)
    : base(border)
  {
    IDictionary<string, string> dictionary = border.RetrieveAttributes();
    if (dictionary == null || !dictionary.ContainsKey(nameof (slope)))
      return;
    string str = dictionary[nameof (slope)];
    if ("\\".Equals(str))
    {
      this.slope = LineDrawer.Slope.TOP_TO_BOTTOM;
    }
    else
    {
      if (!"/".Equals(str))
        return;
      this.slope = LineDrawer.Slope.BOTTOM_TO_TOP;
    }
  }

  protected override void InitBorderEdges(bool empty)
  {
    this.borderEdges = (IList<FormattingElement>) new List<FormattingElement>();
    this.borderEdges.Add(new FormattingElement());
  }

  protected override void SetBorderEdgePoints(float llx, float lly, float urx, float ury)
  {
    if (this.borderEdges.Count != 1)
      return;
    FormattingElement borderEdge = this.borderEdges[0];
    if (this.slope == LineDrawer.Slope.TOP_TO_BOTTOM)
    {
      borderEdge.SetRectanglePoints(new float?(llx), new float?(ury), new float?(urx), new float?(lly));
    }
    else
    {
      if (this.slope != LineDrawer.Slope.BOTTOM_TO_TOP)
        return;
      borderEdge.SetRectanglePoints(new float?(llx), new float?(lly), new float?(urx), new float?(ury));
    }
  }

  public override void Draw(PdfContentByte canvas, XFARectangle borderArea)
  {
    if (this.borderEdges == null)
      return;
    this.UpdateBorderLinesPoints(borderArea);
    bool flag = false;
    FormattingElement borderEdge = this.borderEdges[0];
    if ("visible".Equals(borderEdge.Presence))
    {
      if (!flag)
      {
        canvas.SaveState();
        if (canvas.IsTagged())
          canvas.OpenMCBlock((IAccessibleElement) this);
        flag = true;
      }
      canvas.SetLineWidth(borderEdge.Thickness.Value);
      canvas.SetColorStroke(borderEdge.Color);
      this.SetLineCap(canvas, borderEdge);
      this.SetLineDash(canvas, borderEdge);
      canvas.MoveTo(borderEdge.X1.Value, borderEdge.Y1.Value);
      canvas.LineTo(borderEdge.X2.Value, borderEdge.Y2.Value);
      canvas.Stroke();
    }
    if (!flag)
      return;
    canvas.RestoreState();
    if (!canvas.IsTagged())
      return;
    canvas.CloseMCBlock((IAccessibleElement) this);
  }

  public override bool IsEmpty()
  {
    if (this.borderEdges != null)
    {
      foreach (FormattingElement borderEdge in (IEnumerable<FormattingElement>) this.borderEdges)
      {
        if ("visible".Equals(borderEdge.Presence))
          return false;
      }
    }
    return true;
  }

  private void SetLineCap(PdfContentByte canvas, FormattingElement fe)
  {
    if (FormattingElement.CapType.BUTT.Equals(fe.Cap))
      canvas.SetLineCap(0);
    else if (FormattingElement.CapType.ROUND.Equals(fe.Cap))
    {
      canvas.SetLineCap(1);
    }
    else
    {
      if (!FormattingElement.CapType.SQUARE.Equals(fe.Cap))
        return;
      canvas.SetLineCap(2);
    }
  }

  protected enum Slope
  {
    TOP_TO_BOTTOM,
    BOTTOM_TO_TOP,
  }
}
