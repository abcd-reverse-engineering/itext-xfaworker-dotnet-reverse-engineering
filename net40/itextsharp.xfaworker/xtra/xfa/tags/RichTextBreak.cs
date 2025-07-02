// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.tags.RichTextBreak
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.text;
using iTextSharp.tool.xml.exceptions;
using iTextSharp.tool.xml.html;
using iTextSharp.tool.xml.pipeline.html;
using System;
using System.Collections.Generic;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.tags;

public class RichTextBreak : Break
{
  public virtual IList<IElement> End(IWorkerContext ctx, Tag tag, IList<IElement> currentContent)
  {
    IList<IElement> ielementList = (IList<IElement>) new List<IElement>(1);
    try
    {
      HtmlPipelineContext htmlPipelineContext = ((AbstractTagProcessor) this).GetHtmlPipelineContext(ctx);
      Chunk chunk = (Chunk) ((AbstractTagProcessor) this).GetCssAppliers().Apply((IElement) new Chunk("\n"), tag, htmlPipelineContext);
      ielementList.Add((IElement) chunk);
    }
    catch (NoCustomContextException ex)
    {
      throw new RuntimeWorkerException(LocaleMessages.GetInstance().GetMessage("customcontext.404"), (Exception) ex);
    }
    return ielementList;
  }
}
