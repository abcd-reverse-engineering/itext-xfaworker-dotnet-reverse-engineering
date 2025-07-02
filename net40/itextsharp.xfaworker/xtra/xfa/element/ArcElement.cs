// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.element.ArcElement
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml.xtra.xfa.tags;
using iTextSharp.tool.xml.xtra.xfa.util;
using System;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.element;

public class ArcElement : ContentElement
{
  private ArcDrawer arcDrawer;

  public ArcElement(IFormNode elementTag, XFARectangle elementRec, Document document)
    : base(elementTag, elementRec, document)
  {
    this.arcDrawer = new ArcDrawer(elementTag);
  }

  public override PositionResult.State Draw(PdfContentByte canvas, XFARectangle parentBoundingBox)
  {
    XFARectangle borderArea = (XFARectangle) this.elementRec.Clone();
    if (parentBoundingBox != null)
    {
      float num1 = Math.Min(borderArea.Ury.Value, parentBoundingBox.Ury.Value);
      float num2 = Math.Max(borderArea.Ury.Value - borderArea.Height.Value, parentBoundingBox.Ury.Value - parentBoundingBox.Height.Value);
      float num3 = num1 - num2;
      borderArea.Ury = new float?(num1);
      borderArea.Height = new float?(num3);
    }
    this.arcDrawer.Draw(canvas, borderArea);
    return PositionResult.State.FULL_CONTENT;
  }

  public override bool IsEmpty() => this.arcDrawer.IsEmpty();

  public override bool IsTagged() => base.IsTagged() && this.arcDrawer.Role != PdfName.ARTIFACT;
}
