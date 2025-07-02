// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.html.RichTextTags
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.tool.xml.xtra.xfa.tags;
using itextsharp.xfaworker.iTextSharp.tool.xml.xtra.xfa.tags;

#nullable disable
namespace iTextSharp.tool.xml.html;

public class RichTextTags
{
  private const string defaultpackage = "iTextSharp.tool.xml.html.";
  private const string dummyTagProcessor = "iTextSharp.tool.xml.html.DummyTagProcessor";
  private const string headers = "iTextSharp.tool.xml.html.Header";
  private const string span = "iTextSharp.tool.xml.html.Span";
  private const string nonSanitized = "iTextSharp.tool.xml.html.NonSanitizedTag";
  private const string paragraph = "iTextSharp.tool.xml.html.ParaGraph";

  public static ITagProcessorFactory GetRichTextTagProcessorFactory()
  {
    ITagProcessorFactory processorFactory = RichTextTags.GetXfaHtmlTagProcessorFactory();
    ((DefaultTagProcessorFactory) processorFactory).AddProcessor("span", typeof (RichTextSpan).FullName);
    ((DefaultTagProcessorFactory) processorFactory).AddProcessor("p", typeof (RichTextParagraph).FullName);
    ((DefaultTagProcessorFactory) processorFactory).AddProcessor("div", typeof (RichTextParagraph).FullName);
    ((DefaultTagProcessorFactory) processorFactory).AddProcessor("br", typeof (RichTextBreak).FullName);
    return processorFactory;
  }

  public static ITagProcessorFactory GetXfaHtmlTagProcessorFactory()
  {
    DefaultTagProcessorFactory processorFactory = (DefaultTagProcessorFactory) new XFATagProcessor();
    processorFactory.AddProcessor("xml", "iTextSharp.tool.xml.html.DummyTagProcessor");
    processorFactory.AddProcessor("!doctype", "iTextSharp.tool.xml.html.DummyTagProcessor");
    processorFactory.AddProcessor("html", "iTextSharp.tool.xml.html.DummyTagProcessor");
    processorFactory.AddProcessor("head", "iTextSharp.tool.xml.html.DummyTagProcessor");
    processorFactory.AddProcessor("meta", "iTextSharp.tool.xml.html.DummyTagProcessor");
    processorFactory.AddProcessor("object", "iTextSharp.tool.xml.html.DummyTagProcessor");
    processorFactory.AddProcessor("title", "iTextSharp.tool.xml.html.head.Title");
    processorFactory.AddProcessor("link", "iTextSharp.tool.xml.html.head.Link");
    processorFactory.AddProcessor("style", "iTextSharp.tool.xml.html.head.Style");
    processorFactory.AddProcessor("body", "iTextSharp.tool.xml.html.Body");
    processorFactory.AddProcessor("div", "iTextSharp.tool.xml.html.Div");
    processorFactory.AddProcessor("a", "iTextSharp.tool.xml.html.Anchor");
    processorFactory.AddProcessor("table", "iTextSharp.tool.xml.html.table.Table");
    processorFactory.AddProcessor("tr", "iTextSharp.tool.xml.html.table.TableRow");
    processorFactory.AddProcessor("td", "iTextSharp.tool.xml.html.table.TableData");
    processorFactory.AddProcessor("th", "iTextSharp.tool.xml.html.table.TableData");
    processorFactory.AddProcessor("caption", "iTextSharp.tool.xml.html.ParaGraph");
    processorFactory.AddProcessor("p", "iTextSharp.tool.xml.html.ParaGraph");
    processorFactory.AddProcessor("dt", "iTextSharp.tool.xml.html.ParaGraph");
    processorFactory.AddProcessor("dd", "iTextSharp.tool.xml.html.ParaGraph");
    processorFactory.AddProcessor("br", "iTextSharp.tool.xml.html.Break");
    processorFactory.AddProcessor("span", "iTextSharp.tool.xml.html.Span");
    processorFactory.AddProcessor("small", "iTextSharp.tool.xml.html.Span");
    processorFactory.AddProcessor("big", "iTextSharp.tool.xml.html.Span");
    processorFactory.AddProcessor("s", "iTextSharp.tool.xml.html.Span");
    processorFactory.AddProcessor("strike", "iTextSharp.tool.xml.html.Span");
    processorFactory.AddProcessor("del", "iTextSharp.tool.xml.html.Span");
    processorFactory.AddProcessor("sub", "iTextSharp.tool.xml.html.Span");
    processorFactory.AddProcessor("sup", "iTextSharp.tool.xml.html.Span");
    processorFactory.AddProcessor("b", "iTextSharp.tool.xml.html.Span");
    processorFactory.AddProcessor("strong", "iTextSharp.tool.xml.html.Span");
    processorFactory.AddProcessor("i", "iTextSharp.tool.xml.html.Span");
    processorFactory.AddProcessor("cite", "iTextSharp.tool.xml.html.Span");
    processorFactory.AddProcessor("em", "iTextSharp.tool.xml.html.Span");
    processorFactory.AddProcessor("address", "iTextSharp.tool.xml.html.Span");
    processorFactory.AddProcessor("dfn", "iTextSharp.tool.xml.html.Span");
    processorFactory.AddProcessor("var", "iTextSharp.tool.xml.html.Span");
    processorFactory.AddProcessor("pre", "iTextSharp.tool.xml.html.NonSanitizedTag");
    processorFactory.AddProcessor("tt", "iTextSharp.tool.xml.html.NonSanitizedTag");
    processorFactory.AddProcessor("code", "iTextSharp.tool.xml.html.NonSanitizedTag");
    processorFactory.AddProcessor("kbd", "iTextSharp.tool.xml.html.NonSanitizedTag");
    processorFactory.AddProcessor("samp", "iTextSharp.tool.xml.html.NonSanitizedTag");
    processorFactory.AddProcessor("u", "iTextSharp.tool.xml.html.Span");
    processorFactory.AddProcessor("ins", "iTextSharp.tool.xml.html.Span");
    processorFactory.AddProcessor("img", "iTextSharp.tool.xml.html.Image");
    processorFactory.AddProcessor("ul", "iTextSharp.tool.xml.html.OrderedUnorderedList");
    processorFactory.AddProcessor("ol", "iTextSharp.tool.xml.html.OrderedUnorderedList");
    processorFactory.AddProcessor("li", "iTextSharp.tool.xml.html.OrderedUnorderedListItem");
    processorFactory.AddProcessor("h1", "iTextSharp.tool.xml.html.Header");
    processorFactory.AddProcessor("h2", "iTextSharp.tool.xml.html.Header");
    processorFactory.AddProcessor("h3", "iTextSharp.tool.xml.html.Header");
    processorFactory.AddProcessor("h4", "iTextSharp.tool.xml.html.Header");
    processorFactory.AddProcessor("h5", "iTextSharp.tool.xml.html.Header");
    processorFactory.AddProcessor("h6", "iTextSharp.tool.xml.html.Header");
    processorFactory.AddProcessor("hr", "iTextSharp.tool.xml.html.HorizontalRule");
    processorFactory.AddProcessor("label", "iTextSharp.tool.xml.html.Span");
    return (ITagProcessorFactory) processorFactory;
  }
}
