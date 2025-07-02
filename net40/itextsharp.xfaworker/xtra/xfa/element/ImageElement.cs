// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.element.ImageElement
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.interfaces;
using iTextSharp.tool.xml.xtra.xfa.tags;
using iTextSharp.tool.xml.xtra.xfa.util;
using System;
using System.IO;
using System.Text;
using System.util;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.element;

public class ImageElement : ContentElement
{
  private Image img;

  public ImageElement(
    IFormNode elementTag,
    XFARectangle elementRec,
    Document document,
    string data)
    : base(elementTag, elementRec, document)
  {
    string str = "base64";
    if (this.attributes.ContainsKey("transferEncoding"))
      str = this.attributes["transferEncoding"];
    try
    {
      if (data != null)
      {
        if (Util.EqualsIgnoreCase(str, "base64"))
        {
          byte[] numArray = Convert.FromBase64String(data);
          if (numArray != null)
          {
            if (numArray.Length > 0)
              this.img = Image.GetInstance(numArray);
          }
        }
        else
          this.img = Image.GetInstance(Encoding.Default.GetBytes(data));
      }
    }
    catch (IOException ex)
    {
    }
    catch (BadElementException ex)
    {
    }
    catch (FormatException ex)
    {
    }
    this.ApplyAspect();
  }

  public ImageElement(IFormNode elementTag, XFARectangle elementRec, Document document, Image img)
    : base(elementTag, elementRec, document)
  {
    this.img = img;
    this.ApplyAspect();
  }

  private void ApplyAspect()
  {
    string str = "fit";
    if (this.attributes.ContainsKey("aspect"))
      str = this.attributes["aspect"];
    float? nullable1 = this.elementRec.Width;
    float? nullable2 = this.elementRec.Height;
    if (this.img == null)
      return;
    if (this.img.DpiX != 0 && this.img.DpiY != 0 || this.img is ImgRaw)
    {
      float num1 = this.img.DpiX != 0 ? (float) this.img.DpiX : 96f;
      float num2 = this.img.DpiY != 0 ? (float) this.img.DpiY : 96f;
      this.img.ScaleAbsoluteWidth((float) ((double) this.img.ScaledWidth / (double) num1 * 72.0));
      this.img.ScaleAbsoluteHeight((float) ((double) this.img.ScaledHeight / (double) num2 * 72.0));
    }
    if (Util.EqualsIgnoreCase(str, "actual"))
      this.img.SetAbsolutePosition(this.elementRec.Llx.Value, this.elementRec.Ury.Value - this.img.ScaledHeight);
    else if (Util.EqualsIgnoreCase(str, "fit"))
    {
      if (nullable1.HasValue && nullable2.HasValue)
        this.img.ScaleToFit(nullable1.Value, nullable2.Value);
      else if (nullable1.HasValue)
        this.img.ScaleToFit(nullable1.Value, this.img.ScaledHeight);
      else if (nullable2.HasValue)
        this.img.ScaleToFit(this.img.ScaledWidth, nullable2.Value);
      this.img.SetAbsolutePosition(this.elementRec.Llx.Value, this.elementRec.Ury.Value - this.img.ScaledHeight);
    }
    else if (Util.EqualsIgnoreCase(str, "none"))
    {
      if (nullable1.HasValue)
        this.img.ScaleAbsoluteWidth(nullable1.Value);
      if (nullable2.HasValue)
        this.img.ScaleAbsoluteHeight(nullable2.Value);
      this.img.SetAbsolutePosition(this.elementRec.Llx.Value, this.elementRec.Ury.Value - this.img.ScaledHeight);
    }
    else if (Util.EqualsIgnoreCase(str, "width"))
    {
      float num3 = nullable1.Value / ((Rectangle) this.img).Width;
      float num4 = nullable2.Value / ((Rectangle) this.img).Height;
      float? nullable3 = nullable2;
      float num5 = num3 / num4;
      nullable2 = nullable3.HasValue ? new float?(nullable3.GetValueOrDefault() * num5) : new float?();
      this.img.ScaleToFit(nullable1.Value, nullable2.Value);
      this.img.SetAbsolutePosition(this.elementRec.Llx.Value, this.elementRec.Ury.Value - nullable2.Value);
    }
    else if (Util.EqualsIgnoreCase(str, "height"))
    {
      float num6 = nullable1.Value / ((Rectangle) this.img).Width;
      float num7 = nullable2.Value / ((Rectangle) this.img).Height;
      float? nullable4 = nullable1;
      float num8 = num7 / num6;
      nullable1 = nullable4.HasValue ? new float?(nullable4.GetValueOrDefault() * num8) : new float?();
      this.img.ScaleToFit(nullable1.Value, nullable2.Value);
      this.img.SetAbsolutePosition(this.elementRec.Llx.Value, this.elementRec.Ury.Value - nullable2.Value);
    }
    if (!nullable1.HasValue)
      this.elementRec.Width = new float?(this.img.ScaledWidth);
    if (nullable2.HasValue)
      return;
    this.elementRec.Height = new float?(this.img.ScaledHeight);
  }

  public override PositionResult.State Draw(PdfContentByte canvas, XFARectangle parentBoundingBox)
  {
    if (this.img != null)
    {
      canvas.SaveState();
      canvas.Rectangle(this.elementRec.Llx.Value, this.elementRec.Ury.Value - this.elementRec.Height.Value, this.elementRec.Width.Value, this.elementRec.Height.Value);
      canvas.EoClip();
      canvas.NewPath();
      if (canvas.IsTagged())
        canvas.OpenMCBlock((IAccessibleElement) this.img);
      canvas.AddImage(this.img);
      if (canvas.IsTagged())
        canvas.CloseMCBlock((IAccessibleElement) this.img);
      canvas.RestoreState();
    }
    return PositionResult.State.FULL_CONTENT;
  }

  public override bool IsEmpty() => this.img == null;

  public override void Move(float dx, float dy)
  {
    base.Move(dx, dy);
    if (this.img == null)
      return;
    this.img.SetAbsolutePosition(this.img.AbsoluteX + dx, this.img.AbsoluteY + dy);
  }
}
