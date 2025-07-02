// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.pipe.ConfigPipeline
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.tool.xml.pipeline;
using iTextSharp.tool.xml.xtra.xfa.resolver;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.pipe;

public class ConfigPipeline(IPipeline next) : AbstractPipeline(next)
{
  private Tag configRoot;
  private Tag presentNode;
  private Tag acrobatNode;
  private Tag acrobatCommonNode;

  public virtual IPipeline Init(IWorkerContext context)
  {
    ConfigResolver configResolver = new ConfigResolver();
    context.Put(this.GetContextKey(), (ICustomContext) configResolver);
    return base.Init(context);
  }

  public virtual IPipeline Open(IWorkerContext context, Tag t, ProcessObject po)
  {
    string name = t.Name;
    if ("config".Equals(name) && this.configRoot == null)
      this.configRoot = t;
    else if ("present".Equals(name) && t.Parent == this.configRoot)
      this.presentNode = t;
    else if ("acrobat".Equals(name) && t.Parent == this.configRoot)
      this.acrobatNode = t;
    else if ("common".Equals(name) && t.Parent == this.acrobatNode)
      this.acrobatCommonNode = t;
    return this.GetNext();
  }

  public virtual IPipeline Content(
    IWorkerContext ctx,
    Tag currentTag,
    string text,
    ProcessObject po)
  {
    if ("locale".Equals(currentTag.Name) && currentTag.Parent == this.acrobatCommonNode)
    {
      string defaultAcrobatLocale = text;
      ((ConfigResolver) this.GetLocalContext(ctx)).SetDefaultAcrobatLocale(defaultAcrobatLocale);
    }
    return base.Content(ctx, currentTag, text, po);
  }
}
