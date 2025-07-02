// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.css.apply.XFAParagraphCssApplier
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.text;
using iTextSharp.tool.xml.html;
using iTextSharp.tool.xml.pdfelement;
using iTextSharp.tool.xml.pipeline.html;
using System;
using System.Collections.Generic;

#nullable disable
namespace iTextSharp.tool.xml.css.apply;

public class XFAParagraphCssApplier(CssAppliers appliers) : ParagraphCssApplier(appliers)
{
  public virtual Paragraph Apply(
    Paragraph p,
    Tag t,
    IMarginMemory configuration,
    IPageSizeContainable psc,
    HtmlPipelineContext ctx)
  {
    if (p is XFAParagraph)
      ((XFAParagraph) p).UserStyles = (Dictionary<string, string>) t.CSS;
    Paragraph paragraph = base.Apply(p, t, configuration, psc, ctx);
    string str;
    if (t.CSS.TryGetValue("text-indent", out str) && !string.IsNullOrEmpty(str))
    {
      float pxInCmMmPcToPt = CssUtils.GetInstance().ParsePxInCmMmPcToPt(str, "pt");
      if ((double) pxInCmMmPcToPt > 0.0)
        paragraph.FirstLineIndent = pxInCmMmPcToPt;
      else if ((double) pxInCmMmPcToPt < 0.0)
      {
        paragraph.IndentationLeft += Math.Abs(pxInCmMmPcToPt);
        paragraph.FirstLineIndent = pxInCmMmPcToPt;
      }
    }
    return paragraph;
  }
}
