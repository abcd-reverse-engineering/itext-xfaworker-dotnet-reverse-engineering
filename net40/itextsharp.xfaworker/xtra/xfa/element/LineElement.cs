// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.element.LineElement
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml.xtra.xfa.tags;
using iTextSharp.tool.xml.xtra.xfa.util;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.element;

public class LineElement : ContentElement
{
  protected LineDrawer lineDrawer;

  public LineElement(IFormNode elementTag, XFARectangle elementRec, Document document)
    : base(elementTag, elementRec, document)
  {
    this.lineDrawer = new LineDrawer(elementTag);
  }

  public override PositionResult.State Draw(PdfContentByte canvas, XFARectangle parentBoundingBox)
  {
    this.lineDrawer.Draw(canvas, this.elementRec);
    return PositionResult.State.FULL_CONTENT;
  }

  public override bool IsEmpty() => this.lineDrawer.IsEmpty();

  public override bool IsTagged() => base.IsTagged() && this.lineDrawer.Role != PdfName.ARTIFACT;
}
