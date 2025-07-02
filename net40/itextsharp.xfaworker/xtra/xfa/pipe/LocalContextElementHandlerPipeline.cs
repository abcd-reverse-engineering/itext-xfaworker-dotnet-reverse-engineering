// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.pipe.LocalContextElementHandlerPipeline
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.text;
using iTextSharp.tool.xml.pipeline;
using iTextSharp.tool.xml.pipeline.ctx;
using System.Collections.Generic;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.pipe;

public class LocalContextElementHandlerPipeline(IPipeline next) : AbstractPipeline(next)
{
  public virtual IPipeline Init(IWorkerContext context)
  {
    context.Put(this.GetContextKey(), (ICustomContext) new ObjectContext<IList<IElement>>((IList<IElement>) new List<IElement>()));
    return base.Init(context);
  }

  public virtual IPipeline Open(IWorkerContext context, Tag t, ProcessObject po)
  {
    this.Consume(po, ((ObjectContext<IList<IElement>>) this.GetLocalContext(context)).Get());
    return base.Open(context, t, po);
  }

  public virtual IPipeline Content(
    IWorkerContext ctx,
    Tag currentTag,
    string text,
    ProcessObject po)
  {
    this.Consume(po, ((ObjectContext<IList<IElement>>) this.GetLocalContext(ctx)).Get());
    return base.Content(ctx, currentTag, text, po);
  }

  public virtual IPipeline Close(IWorkerContext context, Tag t, ProcessObject po)
  {
    this.Consume(po, ((ObjectContext<IList<IElement>>) this.GetLocalContext(context)).Get());
    return base.Close(context, t, po);
  }

  private void Consume(ProcessObject po, IList<IElement> list)
  {
    if (!po.ContainsWritable())
      return;
    IWritable iwritable;
    while ((iwritable = po.Poll()) != null)
    {
      if (iwritable is WritableElement)
      {
        foreach (IElement element in (IEnumerable<IElement>) ((WritableElement) iwritable).Elements())
          list.Add(element);
      }
    }
  }
}
