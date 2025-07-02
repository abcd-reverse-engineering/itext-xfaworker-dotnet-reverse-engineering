// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.element.RoundBorderDrawer
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.interfaces;
using iTextSharp.tool.xml.xtra.xfa.tags;
using iTextSharp.tool.xml.xtra.xfa.util;
using System.util;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.element;

public class RoundBorderDrawer : BorderDrawer
{
  private float borderWidth = 1f;
  private string stroke = "solid";
  private BaseColor strokeColor = new BaseColor(0, 0, 0);

  public RoundBorderDrawer(IFormNode border)
    : base(border)
  {
    IFormNode formNode1 = border.RetrieveChild("edge");
    if (formNode1 == null)
      return;
    string str = formNode1.RetrieveAttribute(nameof (stroke));
    if (str != null)
      this.stroke = str;
    IFormNode formNode2 = formNode1.RetrieveChild("color");
    if (formNode2 == null)
      return;
    string xfaColor = formNode2.RetrieveAttribute("value");
    if (xfaColor == null || xfaColor.Length <= 0)
      return;
    this.strokeColor = XFAUtil.ParseXfaColor(xfaColor);
  }

  public override void Draw(PdfContentByte canvas, XFARectangle borderArea)
  {
    this.UpdateBorderLinesPoints(borderArea);
    float num1 = borderArea.Width.Value;
    float num2 = borderArea.Width.Value / 2f;
    if (canvas.IsTagged())
      canvas.OpenMCBlock((IAccessibleElement) this);
    canvas.SaveState();
    canvas.SetLineWidth(this.borderWidth * 0.5f);
    canvas.SetColorFill(new BaseColor((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
    canvas.Circle(borderArea.Llx.Value + num2, borderArea.Ury.Value - num2, num2);
    canvas.Fill();
    canvas.RestoreState();
    if (Util.EqualsIgnoreCase("lowered", this.stroke) || Util.EqualsIgnoreCase("etched", this.stroke) || Util.EqualsIgnoreCase("raised", this.stroke) || Util.EqualsIgnoreCase("embossed", this.stroke))
    {
      canvas.SaveState();
      canvas.SetLineWidth(this.borderWidth * 0.5f);
      canvas.SetColorStroke(new BaseColor(212, 208 /*0xD0*/, 200));
      canvas.Circle(borderArea.Llx.Value + num2, borderArea.Ury.Value - num2, num2 - this.borderWidth * 0.75f);
      canvas.Stroke();
      canvas.SetColorStroke(new BaseColor(128 /*0x80*/, 128 /*0x80*/, 128 /*0x80*/));
      canvas.Arc(borderArea.Llx.Value + this.borderWidth * 0.25f, borderArea.Ury.Value - this.borderWidth * 0.25f, (float) ((double) borderArea.Llx.Value + (double) borderArea.Width.Value - (double) this.borderWidth * 0.25), (float) ((double) borderArea.Ury.Value - (double) borderArea.Height.Value + (double) this.borderWidth * 0.25), (float) (45.0 + 30.0 / (double) num1), (float) (180.0 - 60.0 / (double) num1));
      canvas.Stroke();
      canvas.SetColorStroke(new BaseColor(64 /*0x40*/, 64 /*0x40*/, 64 /*0x40*/));
      canvas.Arc(borderArea.Llx.Value + this.borderWidth * 0.75f, borderArea.Ury.Value - this.borderWidth * 0.75f, (float) ((double) borderArea.Llx.Value + (double) borderArea.Width.Value - (double) this.borderWidth * 0.75), (float) ((double) borderArea.Ury.Value - (double) borderArea.Height.Value + (double) this.borderWidth * 0.75), (float) (45.0 - 30.0 / (double) num1), (float) (180.0 + 60.0 / (double) num1));
      canvas.Stroke();
      canvas.RestoreState();
    }
    else
    {
      canvas.SaveState();
      canvas.SetLineWidth(this.borderWidth * 0.5f);
      canvas.SetColorStroke(this.strokeColor);
      canvas.Circle(borderArea.Llx.Value + num2, borderArea.Ury.Value - num2, num2);
      canvas.Stroke();
      canvas.RestoreState();
    }
    if (!canvas.IsTagged())
      return;
    canvas.CloseMCBlock((IAccessibleElement) this);
  }

  public override bool IsEmpty() => false;
}
