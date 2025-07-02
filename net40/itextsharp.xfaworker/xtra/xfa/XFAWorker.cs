// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.XFAWorker
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.text;
using iTextSharp.text.log;
using iTextSharp.tool.xml.css;
using iTextSharp.tool.xml.css.apply;
using iTextSharp.tool.xml.exceptions;
using iTextSharp.tool.xml.html;
using iTextSharp.tool.xml.parser;
using iTextSharp.tool.xml.pipeline;
using iTextSharp.tool.xml.pipeline.css;
using iTextSharp.tool.xml.pipeline.ctx;
using iTextSharp.tool.xml.pipeline.html;
using iTextSharp.tool.xml.xtra.xfa.pipe;
using iTextSharp.tool.xml.xtra.xfa.resolver;
using iTextSharp.tool.xml.xtra.xfa.tags;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa;

public class XFAWorker(IPipeline pipeline) : XMLWorker(pipeline, false)
{
  private static readonly ILogger logger = LoggerFactory.GetLogger(typeof (XFAWorker));
  protected SomExpression somExpession;
  protected Tag parentTag;
  protected Tag currentFragmentTag;
  protected Tag rootParsedTag;

  public XFAWorker(IPipeline pipeline, Tag parentTag, SomExpression somExpression)
    : this(pipeline)
  {
    this.somExpession = somExpression;
    this.parentTag = parentTag;
  }

  public virtual void Init()
  {
    IPipeline ipipeline = this.rootpPipe;
    if (this.parentTag != null)
      return;
    try
    {
      do
        ;
      while ((ipipeline = ipipeline.Init(XMLWorker.GetLocalWC())) != null);
    }
    catch (PipelineException ex)
    {
      throw new RuntimeWorkerException((Exception) ex);
    }
  }

  protected virtual Tag CreateTag(string tag, IDictionary<string, string> attr, string ns)
  {
    return (Tag) new XFATemplateTag(tag, attr, ns);
  }

  public virtual void Close()
  {
  }

  public static IWorkerContext GetWorkerContext() => XMLWorker.GetLocalWC();

  public static void CloseWorkerContext() => XMLWorker.CloseLocalWC();

  public static Tag ParseTemplatePart(Stream templateStream, Encoding encoding)
  {
    XFAWorker xfaWorker = new XFAWorker((IPipeline) new TemplateBuilderPipeline((CssAppliers) null));
    new XMLParser(false, (IXMLParserListener) xfaWorker).Parse(templateStream, encoding);
    return xfaWorker.rootParsedTag;
  }

  public static XFAWorker.RichTextParseResult ParseRichTextPart(
    Stream richTextStream,
    IFontProvider fontProvider,
    Encoding encoding)
  {
    CssAppliers cssAppliers = (CssAppliers) new XFACssAppliersImpl();
    cssAppliers.ChunkCssAplier = (ChunkCssApplier) new XFAChunkCssApplier(fontProvider);
    HtmlPipelineContext hpc = new HtmlPipelineContext(cssAppliers);
    hpc.SetAcceptUnknown(true).SetTagFactory(RichTextTags.GetRichTextTagProcessorFactory());
    CssResolverPipeline pipeline = new CssResolverPipeline((ICSSResolver) new StyleAttrCSSResolver((ICssInheritanceRules) new XfaCssInheritanceRules(), (ICssFiles) new CssFilesImpl(), CssUtils.GetInstance()), (IPipeline) new XFAHtmlPipeline(hpc, (IPipeline) new LocalContextElementHandlerPipeline((IPipeline) null)));
    new XMLParser(false, (IXMLParserListener) new XFAWorker((IPipeline) pipeline)).Parse(richTextStream, encoding);
    XFAHtmlPipeline next = (XFAHtmlPipeline) ((AbstractPipeline) pipeline).GetNext();
    IList<IElement> richTextElements = ((ObjectContext<IList<IElement>>) ((AbstractPipeline) ((AbstractPipeline) next).GetNext()).GetLocalContext(XFAWorker.GetWorkerContext())).Get();
    return new XFAWorker.RichTextParseResult(next.RootTag, richTextElements);
  }

  public virtual void StartElement(string tag, IDictionary<string, string> attr, string ns)
  {
    Tag tag1 = base.CreateTag(tag, attr, ns);
    IWorkerContext localWc = XMLWorker.GetLocalWC();
    if (localWc.GetCurrentTag() != null)
      localWc.GetCurrentTag().AddChild(tag1);
    localWc.SetCurrentTag(tag1);
    if (this.rootParsedTag == null)
      this.rootParsedTag = tag1;
    if (this.somExpession != null && this.somExpession.MatchAndPop((IFormNode) tag1) && this.somExpession.NodePath.Count == 0)
    {
      this.currentFragmentTag = tag1;
      this.parentTag.Children.Clear();
      foreach (KeyValuePair<string, string> attribute in (IEnumerable<KeyValuePair<string, string>>) tag1.Attributes)
      {
        if (!this.parentTag.Attributes.ContainsKey(attribute.Key))
          this.parentTag.Attributes.Add(attribute.Key, attribute.Value);
      }
      ((XFATemplateTag) this.parentTag).Bind = (Tag) null;
      localWc.SetCurrentTag(this.parentTag);
      if (XFAWorker.logger.IsLogging((Level) 3))
      {
        string str;
        this.currentFragmentTag.Attributes.TryGetValue("name", out str);
        XFAWorker.logger.Debug($"Usehref: {str} resolved!");
      }
    }
    IPipeline ipipeline = this.rootpPipe;
    ProcessObject processObject = new ProcessObject();
    try
    {
      do
        ;
      while ((ipipeline = ipipeline.Open(localWc, tag1, processObject)) != null);
    }
    catch (PipelineException ex)
    {
      throw new RuntimeWorkerException((Exception) ex);
    }
  }

  public virtual void EndElement(string tag, string ns)
  {
    string str = !this.parseHtml ? tag : tag.ToLower();
    IWorkerContext localWc = XMLWorker.GetLocalWC();
    if (localWc.GetCurrentTag() != null && !str.Equals(localWc.GetCurrentTag().Name))
      throw new RuntimeWorkerException(string.Format(LocaleMessages.GetInstance().GetMessage("tag.invalidnesting"), (object) str, (object) localWc.GetCurrentTag().Name));
    if (this.parentTag == localWc.GetCurrentTag())
      localWc.SetCurrentTag(this.currentFragmentTag);
    IPipeline ipipeline = this.rootpPipe;
    ProcessObject processObject = new ProcessObject();
    try
    {
      do
        ;
      while ((ipipeline = ipipeline.Close(localWc, localWc.GetCurrentTag(), processObject)) != null);
    }
    catch (PipelineException ex)
    {
      throw new RuntimeWorkerException((Exception) ex);
    }
    finally
    {
      if (localWc.GetCurrentTag() != null)
        localWc.SetCurrentTag(localWc.GetCurrentTag().Parent);
    }
  }

  protected virtual bool IgnoreCdata() => false;

  public class RichTextParseResult
  {
    protected Tag richTextRootTag;
    protected IList<IElement> richTextElements;

    public RichTextParseResult(Tag richTextRootTag, IList<IElement> richTextElements)
    {
      this.richTextRootTag = richTextRootTag;
      this.richTextElements = richTextElements;
    }

    public virtual Tag RichTextRootTag => this.richTextRootTag;

    public virtual IList<IElement> RichTextElements => this.richTextElements;
  }
}
