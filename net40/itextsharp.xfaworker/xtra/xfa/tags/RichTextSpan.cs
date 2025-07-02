// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.tags.RichTextSpan
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.text;
using iTextSharp.tool.xml.exceptions;
using iTextSharp.tool.xml.html;
using iTextSharp.tool.xml.xtra.xfa.bind;
using iTextSharp.tool.xml.xtra.xfa.util;
using System;
using System.Collections.Generic;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.tags;

public class RichTextSpan : Span
{
  private const float DEFAULT_TAB_WIDTH = 36f;
  public const string TEXT = "text";

  public virtual IList<IElement> Content(IWorkerContext ctx, Tag tag, string content)
  {
    string attributeValue = XFAUtil.GetAttributeValue("style", tag.Attributes);
    IList<IElement> ielementList = (IList<IElement>) new List<IElement>(1);
    string s;
    tag.CSS.TryGetValue("xfa-tab-count", out s);
    if (s != null)
    {
      int num = int.Parse(s);
      for (int index = 0; index < num; ++index)
      {
        Chunk chunk = new Chunk(Chunk.SPACETABBING);
        if (index == num - 1)
        {
          Dictionary<string, object> attributes = chunk.Attributes;
          attributes["text"] = (object) content;
          chunk.Attributes = attributes;
        }
        try
        {
          ielementList.Add(((AbstractTagProcessor) this).GetCssAppliers().Apply((IElement) chunk, tag, ((AbstractTagProcessor) this).GetHtmlPipelineContext(ctx)));
        }
        catch (NoCustomContextException ex)
        {
          throw new RuntimeWorkerException((Exception) ex);
        }
      }
      return ielementList;
    }
    foreach (Chunk chunk in "xfa-spacerun:yes".Equals(attributeValue) ? (IEnumerable<Chunk>) HTMLUtils.SanitizeInline(content, true, true) : (IEnumerable<Chunk>) HTMLUtils.SanitizeInline(content, false))
    {
      try
      {
        ielementList.Add(((AbstractTagProcessor) this).GetCssAppliers().Apply((IElement) chunk, tag, ((AbstractTagProcessor) this).GetHtmlPipelineContext(ctx)));
      }
      catch (NoCustomContextException ex)
      {
        throw new RuntimeWorkerException((Exception) ex);
      }
    }
    return ielementList;
  }

  public virtual IList<IElement> End(IWorkerContext ctx, Tag tag, IList<IElement> currentContent)
  {
    IDictionary<string, string> attributes = tag.Attributes;
    if (attributes != null)
    {
      string embedAttributeValue1 = this.FindEmbedAttributeValue("embed", attributes);
      if (embedAttributeValue1 != null)
      {
        EmbeddedElement embeddedElement = new EmbeddedElement(embedAttributeValue1);
        string embedAttributeValue2 = this.FindEmbedAttributeValue("embedType", attributes);
        if (embedAttributeValue2 == null || "som".Equals(embedAttributeValue2))
          embeddedElement.IsUri = false;
        else if ("uri".Equals(embedAttributeValue2))
          embeddedElement.IsUri = true;
        string embedAttributeValue3 = this.FindEmbedAttributeValue("embedMode", attributes);
        if (embedAttributeValue3 == null || "formatted".Equals(embedAttributeValue3))
          embeddedElement.IsRaw = false;
        else if ("raw".Equals(embedAttributeValue3))
          embeddedElement.IsRaw = true;
        Chunk chunk = ((AbstractTagProcessor) this).GetCssAppliers().ChunkCssAplier.Apply(new Chunk("dummy"), tag);
        embeddedElement.Font = chunk.Font;
        embeddedElement.Attributes = (IDictionary<string, object>) chunk.Attributes;
        currentContent.Add((IElement) embeddedElement);
      }
    }
    return ((AbstractTagProcessor) this).CurrentContentToParagraph(currentContent, false, true, tag, ctx);
  }

  private string FindEmbedAttributeValue(
    string nameAttribute,
    IDictionary<string, string> attributes)
  {
    foreach (string key in (IEnumerable<string>) attributes.Keys)
    {
      if (key.EndsWith(nameAttribute))
        return attributes[key];
    }
    return (string) null;
  }
}
