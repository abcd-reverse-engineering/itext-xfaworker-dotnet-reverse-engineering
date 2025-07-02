// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.pipe.TemplateBuilderPipeline
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.text;
using iTextSharp.text.log;
using iTextSharp.tool.xml.css;
using iTextSharp.tool.xml.html;
using iTextSharp.tool.xml.parser;
using iTextSharp.tool.xml.pipeline;
using iTextSharp.tool.xml.pipeline.css;
using iTextSharp.tool.xml.pipeline.ctx;
using iTextSharp.tool.xml.pipeline.html;
using iTextSharp.tool.xml.xtra.xfa.resolver;
using iTextSharp.tool.xml.xtra.xfa.tags;
using iTextSharp.tool.xml.xtra.xfa.util;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.util;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.pipe;

public class TemplateBuilderPipeline : AbstractPipeline
{
  private const string XfaSchema = "http://www.xfa.org/schema/xfa-template/";
  private static readonly ILogger logger = LoggerFactory.GetLogger(typeof (TemplateBuilderPipeline));
  private IPipeline richTextPipeline;
  private IHrefResolver hrefResolver;
  private bool legacyPlusPrint;
  private float xfaVersion = 3.3f;

  public TemplateBuilderPipeline(CssAppliers cssAppliers)
    : base((IPipeline) null)
  {
    HtmlPipelineContext htmlPipelineContext = new HtmlPipelineContext(cssAppliers);
    htmlPipelineContext.SetAcceptUnknown(true).SetTagFactory(RichTextTags.GetRichTextTagProcessorFactory());
    this.richTextPipeline = (IPipeline) new CssResolverPipeline((ICSSResolver) new StyleAttrCSSResolver((ICssInheritanceRules) new XfaCssInheritanceRules(), (ICssFiles) new CssFilesImpl(), CssUtils.GetInstance()), (IPipeline) new HtmlPipeline(htmlPipelineContext, (IPipeline) new LocalContextElementHandlerPipeline((IPipeline) null)));
    this.hrefResolver = (IHrefResolver) null;
  }

  public TemplateBuilderPipeline(CssAppliers cssAppliers, IHrefResolver hrefResolver)
    : this(cssAppliers)
  {
    this.hrefResolver = hrefResolver;
  }

  public float GetXfaVersion() => this.xfaVersion;

  public virtual IPipeline Open(IWorkerContext context, Tag t, ProcessObject po)
  {
    string name = t.Name;
    if (name[0] == '?')
      this.ProcessInstruction(t);
    XFAFlattenerData xfaFlattenerData = ((ObjectContext<XFAFlattenerData>) this.GetLocalContext(context)).Get();
    if (Util.EqualsIgnoreCase("template", name))
    {
      if (xfaFlattenerData.TemplateDom == null)
      {
        xfaFlattenerData.TemplateDom = (XFATemplateTag) t;
        if (t.Attributes != null)
        {
          string url;
          t.Attributes.TryGetValue("xmlns", out url);
          if (url != null && url.StartsWith("http://www.xfa.org/schema/xfa-template/"))
          {
            this.xfaVersion = this.GetVersionFromUrl(url);
            this.legacyPlusPrint = (double) this.xfaVersion < 2.5;
          }
        }
      }
    }
    else if (Util.EqualsIgnoreCase("subform", name) || Util.EqualsIgnoreCase("subformSet", name) || Util.EqualsIgnoreCase("field", name) || Util.EqualsIgnoreCase("draw", name) || Util.EqualsIgnoreCase("exclGroup", name) || Util.EqualsIgnoreCase("area", name))
    {
      if (t is XFATemplateTag && !t.Attributes.ContainsKey("locale") && t.Parent != null && t.Parent.Attributes.ContainsKey("locale"))
        t.Attributes["locale"] = t.Parent.Attributes["locale"];
    }
    else if (xfaFlattenerData.RichTextBlockTag == t.Parent && (t.Attributes.ContainsKey("xmlns") && "http://www.w3.org/1999/xhtml".Equals(t.Attributes["xmlns"]) || "xhtml".Equals(t.NameSpace)))
    {
      xfaFlattenerData.RichTextHtmlRootTag = t;
    }
    else
    {
      string str;
      if (t.Attributes.TryGetValue("contentType", out str) && Util.EqualsIgnoreCase("text/html", str))
      {
        xfaFlattenerData.RichTextBlockTag = t;
        IPipeline ipipeline = xfaFlattenerData.RichTextPipeline;
        while ((ipipeline = ipipeline.Init(context)) != null)
          ;
      }
    }
    return this.GetNext(context);
  }

  public virtual IPipeline Content(
    IWorkerContext context,
    Tag t,
    string content,
    ProcessObject po)
  {
    if (t is XFATemplateTag && content.Trim().Length > 0)
      ((XFATemplateTag) t).AddContent(content);
    return this.GetNext(context);
  }

  public virtual IPipeline Close(IWorkerContext context, Tag t, ProcessObject po)
  {
    string name = t.Name;
    if (Util.EqualsIgnoreCase("subform", name) || Util.EqualsIgnoreCase("field", name) || Util.EqualsIgnoreCase("draw", name) || Util.EqualsIgnoreCase("exclGroup", name) || Util.EqualsIgnoreCase("area", name) || Util.EqualsIgnoreCase("subformSet", name))
    {
      if (t is XFATemplateTag)
      {
        IDictionary<string, string> attributes1 = t.Attributes;
        string str1;
        if (attributes1 == null || !attributes1.TryGetValue("name", out str1))
          str1 = (string) null;
        string refValue = str1;
        Tag bind = ((XFATemplateTag) t).Bind;
        if (bind != null)
        {
          IDictionary<string, string> attributes2 = bind.Attributes;
          if (attributes2 != null)
          {
            string str2;
            attributes2.TryGetValue("match", out str2);
            switch (str2)
            {
              case "dataRef":
                attributes2.TryGetValue("ref", out refValue);
                str1 = XFAUtil.CheckSomExpression(refValue);
                break;
            }
          }
        }
        ((XFATemplateTag) t).DataRef = str1;
        ((XFATemplateTag) t).FullDataRef = refValue;
      }
    }
    else if (t.Attributes.ContainsKey("contentType") && Util.EqualsIgnoreCase("text/html", t.Attributes["contentType"]))
    {
      ((ObjectContext<XFAFlattenerData>) this.GetLocalContext(context)).Get().RichTextBlockTag = (Tag) null;
      IList<IElement> ielementList = ((ObjectContext<IList<IElement>>) ((AbstractPipeline) ((ObjectContext<XFAFlattenerData>) this.GetLocalContext(context)).Get().RichTextPipeline.GetNext().GetNext()).GetLocalContext(context)).Get();
      ((XFATemplateTag) t).RichText = ielementList;
    }
    if (this.hrefResolver != null)
    {
      HrefReference hrefReference = (HrefReference) null;
      string href = (string) null;
      if (t.Attributes != null)
        t.Attributes.TryGetValue("usehref", out href);
      if (href != null)
        hrefReference = new HrefReference(href);
      if (hrefReference != null)
      {
        XFAWorker xfaWorker = (XFAWorker) null;
        string currentXdpPath = this.hrefResolver.CurrentXdpPath;
        try
        {
          xfaWorker = new XFAWorker((IPipeline) this, t, hrefReference.SomExpression);
          XFAWorker.GetWorkerContext().SetCurrentTag((Tag) null);
          XMLParser xmlParser = new XMLParser(false, (IXMLParserListener) xfaWorker);
          string path = this.hrefResolver.Resolve(hrefReference.Path);
          this.hrefResolver.CurrentXdpPath = path;
          xmlParser.Parse((Stream) new BufferedStream((Stream) new FileStream(path, FileMode.Open)), true);
        }
        catch (Exception ex)
        {
          if (TemplateBuilderPipeline.logger.IsLogging((Level) 0))
            TemplateBuilderPipeline.logger.Error($"External XDP fragment processing failed: {ex.Message}\nusehref: {href}", ex);
        }
        finally
        {
          this.hrefResolver.CurrentXdpPath = currentXdpPath;
          if (xfaWorker != null)
            XFAWorker.GetWorkerContext().SetCurrentTag(t);
          hrefReference.SomExpression.Init();
        }
      }
    }
    return this.GetNext(context);
  }

  public virtual IPipeline GetNext(IWorkerContext context)
  {
    XFAFlattenerData xfaFlattenerData = ((ObjectContext<XFAFlattenerData>) this.GetLocalContext(context)).Get();
    return xfaFlattenerData.IsRichText ? xfaFlattenerData.RichTextPipeline : this.GetNext();
  }

  public virtual IPipeline Init(IWorkerContext context)
  {
    context.Put(this.GetContextKey(), (ICustomContext) new ObjectContext<XFAFlattenerData>(new XFAFlattenerData()
    {
      RichTextPipeline = this.richTextPipeline
    }));
    return base.Init(context);
  }

  public virtual bool IsLegacyPlusPrint() => this.legacyPlusPrint;

  public virtual void ProcessInstruction(Tag t)
  {
    if (!"?originalXFAVersion".Equals(t.Name))
      return;
    this.legacyPlusPrint = false;
    if (t.Attributes == null)
      return;
    foreach (string key in (IEnumerable<string>) t.Attributes.Keys)
    {
      if (key.StartsWith("LegacyPlusPrint:") && key.Length == 17)
      {
        if (key[16 /*0x10*/] == '0')
        {
          this.legacyPlusPrint = false;
          break;
        }
        if (key[16 /*0x10*/] == '1')
        {
          this.legacyPlusPrint = true;
          break;
        }
      }
      if (key.StartsWith("http://www.xfa.org/schema/xfa-template/"))
      {
        this.xfaVersion = this.GetVersionFromUrl(key);
        this.legacyPlusPrint = (double) this.xfaVersion < 2.5;
      }
    }
  }

  internal virtual float GetVersionFromUrl(string url)
  {
    try
    {
      return float.Parse(url.Substring("http://www.xfa.org/schema/xfa-template/".Length, url.Length - 1 - "http://www.xfa.org/schema/xfa-template/".Length), (IFormatProvider) CultureInfo.InvariantCulture);
    }
    catch (FormatException ex)
    {
      return 0.0f;
    }
  }
}
