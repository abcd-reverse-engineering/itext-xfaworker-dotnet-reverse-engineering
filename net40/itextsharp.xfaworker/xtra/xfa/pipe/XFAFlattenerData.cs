// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.pipe.XFAFlattenerData
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.tool.xml.xtra.xfa.tags;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.pipe;

public class XFAFlattenerData
{
  private XFATemplateTag templateDom;
  private Tag richTextBlockTag;
  private Tag richTextHtmlRootTag;
  private bool oneHtmlRootTagAdded;
  private IPipeline richTextPipeline;

  public virtual XFATemplateTag TemplateDom
  {
    get => this.templateDom;
    set => this.templateDom = value;
  }

  public virtual Tag RichTextBlockTag
  {
    get => this.richTextBlockTag;
    set
    {
      if (value != null)
      {
        this.oneHtmlRootTagAdded = false;
        this.richTextHtmlRootTag = (Tag) null;
      }
      this.richTextBlockTag = value;
    }
  }

  public virtual Tag RichTextHtmlRootTag
  {
    set
    {
      if (this.richTextHtmlRootTag != null)
        this.oneHtmlRootTagAdded = true;
      else
        this.richTextHtmlRootTag = value;
    }
  }

  public virtual bool IsRichText
  {
    get
    {
      return this.richTextBlockTag != null && this.richTextHtmlRootTag != null && !this.oneHtmlRootTagAdded;
    }
  }

  public virtual IPipeline RichTextPipeline
  {
    get => this.richTextPipeline;
    set => this.richTextPipeline = value;
  }
}
