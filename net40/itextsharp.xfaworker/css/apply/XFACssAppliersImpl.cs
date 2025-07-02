// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.css.apply.XFACssAppliersImpl
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.text;
using iTextSharp.tool.xml.html;

#nullable disable
namespace iTextSharp.tool.xml.css.apply;

public class XFACssAppliersImpl : CssAppliersImpl
{
  public XFACssAppliersImpl()
  {
    this.PutCssApplier(typeof (Paragraph), (ICssApplier) new XFAParagraphCssApplier((CssAppliers) this));
  }

  public XFACssAppliersImpl(IFontProvider fontProvider)
    : this()
  {
    ((ChunkCssApplier) this.GetCssApplier(typeof (Chunk))).FontProvider = fontProvider;
  }
}
