// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.pipe.DataPipeline
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.text;
using iTextSharp.tool.xml.css;
using iTextSharp.tool.xml.html;
using iTextSharp.tool.xml.pipeline;
using iTextSharp.tool.xml.pipeline.css;
using iTextSharp.tool.xml.pipeline.ctx;
using iTextSharp.tool.xml.pipeline.html;
using iTextSharp.tool.xml.xtra.xfa.js;
using iTextSharp.tool.xml.xtra.xfa.tags;
using System.Collections.Generic;
using System.util;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.pipe;

public class DataPipeline : AbstractPipeline
{
  private DataTag dataDom;
  private JsNode jsXfa;
  private JsNode dataNodeDom;
  private JsDataModel datasetsNodeDom;
  private DataTag currentEntry;
  private bool isData;
  private Stack<DataTag> dataTagsStack = new Stack<DataTag>();
  private IPipeline richTextPipeline;
  private XFAHtmlPipeline xfaHtmlPipeline;
  private Tag richTextStartTag;
  private XFATemplateTag dataDescription;

  public DataPipeline(IPipeline next, CssAppliers cssAppliers, JsNode jsXfa)
    : base(next)
  {
    this.jsXfa = jsXfa;
    HtmlPipelineContext hpc = new HtmlPipelineContext(cssAppliers);
    hpc.SetAcceptUnknown(true).SetTagFactory(RichTextTags.GetRichTextTagProcessorFactory());
    this.xfaHtmlPipeline = new XFAHtmlPipeline(hpc, (IPipeline) new LocalContextElementHandlerPipeline((IPipeline) null));
    this.richTextPipeline = (IPipeline) new CssResolverPipeline((ICSSResolver) new StyleAttrCSSResolver((ICssInheritanceRules) new XfaCssInheritanceRules(), (ICssFiles) new CssFilesImpl(), CssUtils.GetInstance()), (IPipeline) this.xfaHtmlPipeline);
  }

  public virtual DataTag DataDom
  {
    get => this.dataDom;
    set => this.dataDom = value;
  }

  public virtual IPipeline Open(IWorkerContext context, Tag t, ProcessObject po)
  {
    if (Util.EqualsIgnoreCase(t.Name, "datasets") && Util.EqualsIgnoreCase(t.NameSpace, "xfa"))
      this.datasetsNodeDom = new JsDataModel("datasets", this.jsXfa);
    else if (Util.EqualsIgnoreCase(t.Name, "dataDescription") && Util.EqualsIgnoreCase(t.NameSpace, "dd"))
      this.dataDescription = (XFATemplateTag) t;
    else if (Util.EqualsIgnoreCase(t.Name, "data") && Util.EqualsIgnoreCase(t.NameSpace, "xfa"))
    {
      this.isData = true;
      DataTag tag = new DataTag(t.Name, t.Attributes);
      this.dataTagsStack.Push(tag);
      this.dataNodeDom = (JsNode) new JsDataGroup(tag, (JsNode) this.datasetsNodeDom);
      this.datasetsNodeDom.AddChild((JsTree) this.dataNodeDom);
      tag.Node = this.dataNodeDom;
    }
    else if (this.isData)
    {
      DataTag dataTag = new DataTag(t.Name, t.Attributes);
      if (this.dataDom == null)
      {
        this.dataDom = dataTag;
        JsDataGroup child = new JsDataGroup(this.dataDom, this.dataNodeDom);
        this.dataNodeDom.AddChild((JsTree) child);
        this.dataDom.Node = (JsNode) child;
      }
      else if (!((DataContext) this.GetLocalContext(context)).IsRichText)
      {
        string str;
        if (t.Attributes.TryGetValue("xmlns", out str) && Util.EqualsIgnoreCase("http://www.w3.org/1999/xhtml", str))
        {
          this.richTextStartTag = t;
          this.xfaHtmlPipeline.Reset();
          ((DataContext) this.GetLocalContext(context)).IsRichText = true;
          IPipeline ipipeline = ((DataContext) this.GetLocalContext(context)).RichTextPipeline;
          while ((ipipeline = ipipeline.Init(context)) != null)
            ;
        }
        else
        {
          DataTag tag = this.dataTagsStack.Peek();
          tag.AddChild((Tag) dataTag);
          if (tag.Node == null)
          {
            DataTag parent = (DataTag) tag.Parent;
            JsDataGroup child = new JsDataGroup(tag, parent.Node);
            tag.Node = (JsNode) child;
            parent.Node.AddChild((JsTree) child);
          }
        }
      }
      if (!((DataContext) this.GetLocalContext(context)).IsRichText)
      {
        this.currentEntry = dataTag;
        this.dataTagsStack.Push(this.currentEntry);
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
    if (this.currentEntry != null)
      this.currentEntry.Value = content;
    return this.GetNext(context);
  }

  public virtual IPipeline Close(IWorkerContext context, Tag t, ProcessObject po)
  {
    if (this.isData)
    {
      string str;
      if (t.Attributes.TryGetValue("xmlns", out str) && t == this.richTextStartTag && Util.EqualsIgnoreCase("http://www.w3.org/1999/xhtml", str))
      {
        this.richTextStartTag = (Tag) null;
        ((DataContext) this.GetLocalContext(context)).IsRichText = false;
        this.currentEntry.RichText = ((ObjectContext<IList<IElement>>) ((AbstractPipeline) ((DataContext) this.GetLocalContext(context)).RichTextPipeline.GetNext().GetNext()).GetLocalContext(context)).Get();
      }
      else if (this.dataTagsStack.Count > 0 && Util.EqualsIgnoreCase(t.Name, this.dataTagsStack.Peek().Name))
      {
        DataTag tag = this.dataTagsStack.Pop();
        if (tag.Node == null)
        {
          JsNode node = ((DataTag) tag.Parent).Node;
          JsDataValue child = new JsDataValue(tag, node);
          tag.Node = (JsNode) child;
          node.AddChild((JsTree) child);
        }
        foreach (KeyValuePair<string, string> attribute in (IEnumerable<KeyValuePair<string, string>>) tag.Attributes)
        {
          DataTag dataTag = new DataTag(attribute.Key, attribute.Value);
          tag.AddChild((Tag) dataTag);
        }
        this.currentEntry = this.dataTagsStack.Count > 0 ? this.dataTagsStack.Peek() : (DataTag) null;
      }
      if (this.isData && Util.EqualsIgnoreCase(t.Name, "data") && Util.EqualsIgnoreCase(t.NameSpace, "xfa") && this.dataTagsStack.Count == 0)
        this.isData = false;
    }
    else if (Util.EqualsIgnoreCase(t.Name, "dataDescription") && Util.EqualsIgnoreCase(t.NameSpace, "dd") && this.dataNodeDom != null && this.dataDom != null)
    {
      string name = this.dataDom.Name;
      this.ApplyDataDescriptionTemplate(this.dataNodeDom.GetChild(name), (XFATemplateTag) t.GetChild(name, ""));
    }
    return this.GetNext(context);
  }

  private void ApplyDataDescriptionTemplate(JsNode dataNode, XFATemplateTag dataDescriptionNode)
  {
    if (dataNode == null || dataDescriptionNode == null)
      return;
    dataNode.ProtoTemplate = (Tag) dataDescriptionNode;
    Queue<Tag> tagQueue = new Queue<Tag>((IEnumerable<Tag>) dataDescriptionNode.Children);
    while (tagQueue.Count != 0)
    {
      Tag dataDescriptionNode1 = tagQueue.Dequeue();
      if (Util.EqualsIgnoreCase("group", dataDescriptionNode1.Name) && Util.EqualsIgnoreCase("dd", dataDescriptionNode1.NameSpace))
      {
        foreach (Tag child in (IEnumerable<Tag>) dataDescriptionNode1.Children)
          tagQueue.Enqueue(child);
      }
      else
      {
        foreach (JsNode retrieveChild in (IEnumerable<IFormNode>) dataNode.RetrieveChildren(dataDescriptionNode1.Name))
          this.ApplyDataDescriptionTemplate(retrieveChild, (XFATemplateTag) dataDescriptionNode1);
      }
    }
  }

  public virtual JsNode DataNodeDom
  {
    get => this.dataNodeDom;
    set => this.dataNodeDom = value;
  }

  public virtual JsNode DatasetsNodeDom => (JsNode) this.datasetsNodeDom;

  public void SetDatasetsNodeDom(JsDataModel datasetsNodeDom)
  {
    this.datasetsNodeDom = datasetsNodeDom;
  }

  public virtual IPipeline Init(IWorkerContext context)
  {
    context.Put(this.GetContextKey(), (ICustomContext) new DataContext()
    {
      RichTextPipeline = this.richTextPipeline
    });
    return base.Init(context);
  }

  public virtual IPipeline GetNext(IWorkerContext context)
  {
    DataContext localContext = (DataContext) this.GetLocalContext(context);
    return localContext.IsRichText ? localContext.RichTextPipeline : this.GetNext();
  }
}
