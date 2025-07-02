// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.pipe.PdfPipeline
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.text.log;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml.pipeline;
using iTextSharp.tool.xml.xtra.xfa.resolver;
using System;
using System.IO;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.pipe;

public class PdfPipeline : AbstractPipeline
{
  private static readonly ILogger logger = LoggerFactory.GetLogger(typeof (PdfPipeline));
  protected readonly FlattenerContext flattenerContext;

  public PdfPipeline(IPipeline next, FlattenerContext flattenerContext)
    : base(next)
  {
    this.flattenerContext = flattenerContext;
  }

  public virtual IPipeline Init(IWorkerContext context)
  {
    context.Put(this.GetContextKey(), (ICustomContext) this.flattenerContext);
    return base.Init(context);
  }

  public virtual IPipeline Open(IWorkerContext context, Tag t, ProcessObject po)
  {
    return base.Open(context, t, po);
  }

  public virtual IPipeline Content(
    IWorkerContext ctx,
    Tag currentTag,
    string text,
    ProcessObject po)
  {
    try
    {
      if ("chunk".Equals(currentTag.Name, StringComparison.OrdinalIgnoreCase))
      {
        if (currentTag.Parent != null)
        {
          if ("document".Equals(currentTag.Parent.Name, StringComparison.OrdinalIgnoreCase))
            this.flattenerContext.Reader = new PdfReader((Stream) new MemoryStream(Convert.FromBase64String(text)));
        }
      }
    }
    catch (IOException ex)
    {
      if (PdfPipeline.logger.IsLogging((Level) 0))
        PdfPipeline.logger.Error("", (Exception) ex);
      throw new PipelineException((Exception) ex);
    }
    return base.Content(ctx, currentTag, text, po);
  }

  public virtual IPipeline Close(IWorkerContext context, Tag t, ProcessObject po)
  {
    return base.Close(context, t, po);
  }
}
