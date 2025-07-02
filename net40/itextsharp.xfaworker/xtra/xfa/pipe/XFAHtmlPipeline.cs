// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.pipe.XFAHtmlPipeline
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.tool.xml.html;
using iTextSharp.tool.xml.pipeline.html;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.pipe;

internal class XFAHtmlPipeline(HtmlPipelineContext hpc, IPipeline next) : HtmlPipeline(hpc, next)
{
  protected Tag rootTag;

  public virtual IPipeline Open(IWorkerContext context, Tag t, ProcessObject po)
  {
    if (this.rootTag == null)
      this.rootTag = t;
    return base.Open(context, t, po);
  }

  public void Reset() => this.rootTag = (Tag) null;

  public virtual Tag RootTag => this.rootTag;

  protected virtual void AddStackKeeper(Tag t, HtmlPipelineContext hcc, ITagProcessor tp)
  {
    if (this.rootTag == t)
      return;
    base.AddStackKeeper(t, hcc, tp);
  }
}
