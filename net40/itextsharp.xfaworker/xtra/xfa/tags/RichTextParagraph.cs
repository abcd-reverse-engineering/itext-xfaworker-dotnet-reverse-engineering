// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.tags.RichTextParagraph
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.text;
using iTextSharp.text.pdf.draw;
using iTextSharp.tool.xml.exceptions;
using iTextSharp.tool.xml.html;
using iTextSharp.tool.xml.html.pdfelement;
using iTextSharp.tool.xml.pdfelement;
using iTextSharp.tool.xml.pipeline.html;
using System;
using System.Collections.Generic;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.tags;

public class RichTextParagraph : ParaGraph
{
  public virtual IList<IElement> Content(IWorkerContext ctx, Tag tag, string content)
  {
    IList<Chunk> chunkList = (IList<Chunk>) HTMLUtils.Sanitize(content, false);
    IList<IElement> ielementList = (IList<IElement>) new List<IElement>(1);
    foreach (Chunk chunk in (IEnumerable<Chunk>) chunkList)
    {
      HtmlPipelineContext htmlPipelineContext;
      try
      {
        htmlPipelineContext = ((AbstractTagProcessor) this).GetHtmlPipelineContext(ctx);
      }
      catch (NoCustomContextException ex)
      {
        throw new RuntimeWorkerException((Exception) ex);
      }
      ielementList.Add(((AbstractTagProcessor) this).GetCssAppliers().Apply((IElement) chunk, tag, htmlPipelineContext));
    }
    return ielementList;
  }

  public virtual IList<IElement> End(IWorkerContext ctx, Tag tag, IList<IElement> currentContent)
  {
    string apiVersion = RichTextParagraph.DetermineApiVersion(tag);
    IList<IElement> ielementList = (IList<IElement>) new List<IElement>(1);
    foreach (IElement ielement in (IEnumerable<IElement>) ((AbstractTagProcessor) this).CurrentContentToParagraph(currentContent, true, true, tag, ctx))
    {
      if (ielement is XFAParagraph)
        ((XFAParagraph) ielement).SetApiVersion(apiVersion);
      ielementList.Add(ielement);
    }
    return ielementList;
  }

  public virtual IList<IElement> CurrentContentToParagraph(
    IList<IElement> currentContent,
    bool addNewLines,
    bool applyCSS,
    Tag tag,
    IWorkerContext ctx)
  {
    try
    {
      IList<IElement> paragraph1 = (IList<IElement>) new List<IElement>();
      if (addNewLines)
      {
        Paragraph paragraph2 = ((AbstractTagProcessor) this).CreateParagraph();
        ((Phrase) paragraph2).MultipliedLeading = 1.2f;
        foreach (IElement ielement in (IEnumerable<IElement>) currentContent)
        {
          if (ielement is LineSeparator)
          {
            try
            {
              HtmlPipelineContext htmlPipelineContext = ((AbstractTagProcessor) this).GetHtmlPipelineContext(ctx);
              Chunk chunk = (Chunk) ((AbstractTagProcessor) this).GetCssAppliers().Apply((IElement) new Chunk(Chunk.NEWLINE), tag, htmlPipelineContext);
              ((Phrase) paragraph2).Add((IElement) chunk);
            }
            catch (NoCustomContextException ex)
            {
              throw new RuntimeWorkerException(LocaleMessages.GetInstance().GetMessage("customcontext.404"), (Exception) ex);
            }
          }
          ((Phrase) paragraph2).Add(ielement);
        }
        if (applyCSS)
          paragraph2 = (Paragraph) ((AbstractTagProcessor) this).GetCssAppliers().Apply((IElement) paragraph2, tag, ((AbstractTagProcessor) this).GetHtmlPipelineContext(ctx));
        paragraph1.Add((IElement) paragraph2);
      }
      else
      {
        NoNewLineParagraph newLineParagraph1 = new NoNewLineParagraph(float.NaN);
        ((Phrase) newLineParagraph1).MultipliedLeading = 1.2f;
        foreach (IElement ielement in (IEnumerable<IElement>) currentContent)
          ((Phrase) newLineParagraph1).Add(ielement);
        NoNewLineParagraph newLineParagraph2 = (NoNewLineParagraph) ((AbstractTagProcessor) this).GetCssAppliers().Apply((IElement) newLineParagraph1, tag, ((AbstractTagProcessor) this).GetHtmlPipelineContext(ctx));
        paragraph1.Add((IElement) newLineParagraph2);
      }
      return paragraph1;
    }
    catch (NoCustomContextException ex)
    {
      throw new RuntimeWorkerException(LocaleMessages.GetInstance().GetMessage("customcontext.404"), (Exception) ex);
    }
  }

  protected virtual Paragraph CreateParagraph() => (Paragraph) new XFAParagraph(float.NaN);

  private static string DetermineApiVersion(Tag tag)
  {
    Tag tag1 = tag;
    while (tag1 != null && !"body".Equals(tag1.Name))
      tag1 = tag1.Parent;
    string apiVersion = (string) null;
    if (tag1 != null && "body".Equals(tag1.Name))
      tag1.Attributes.TryGetValue("xfa:APIVersion", out apiVersion);
    return apiVersion;
  }
}
