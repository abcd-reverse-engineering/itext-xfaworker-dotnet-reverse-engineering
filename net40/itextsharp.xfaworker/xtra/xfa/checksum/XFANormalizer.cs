// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.checksum.XFANormalizer
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.tool.xml.css.apply;
using iTextSharp.tool.xml.html;
using iTextSharp.tool.xml.parser;
using iTextSharp.tool.xml.xtra.xfa.pipe;
using System.Collections.Generic;
using System.IO;
using System.Text;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.checksum;

public class XFANormalizer
{
  public const string PROCESSING_INSTRUCTION_CONTENTS = "xfa-full-processing-instruction-contents";
  private StringBuilder sb = new StringBuilder();
  private StringBuilder contentBuilder = new StringBuilder();

  public static string GetNormalizedXml(MemoryStream inputStream)
  {
    inputStream.Position = 0L;
    TemplateBuilderPipeline pipeline = new TemplateBuilderPipeline((CssAppliers) new XFACssAppliersImpl());
    XFANormalizer normalizer = new XFANormalizer();
    XFAChecksumXMLParser checksumXmlParser = new XFAChecksumXMLParser(false, (IXMLParserListener) new ChecksumXFAWorker((IPipeline) pipeline, normalizer));
    checksumXmlParser.SetDecodeSpecialChars(false);
    try
    {
      checksumXmlParser.Parse((Stream) inputStream, true);
      return normalizer.GetResult();
    }
    catch (IOException ex)
    {
    }
    return (string) null;
  }

  public void Start(Tag t)
  {
    this.sb.Append((object) this.contentBuilder);
    this.contentBuilder.Length = 0;
    string str1 = t.NameSpace.Length > 0 ? $"{t.NameSpace}:{t.Name}" : t.Name;
    this.sb.Append("<");
    if (!t.Name.StartsWith("?"))
    {
      this.sb.Append(str1);
      foreach (KeyValuePair<string, string> attribute in (IEnumerable<KeyValuePair<string, string>>) t.Attributes)
      {
        this.sb.Append(" ").Append(attribute.Key);
        this.sb.Append("=\"").Append(attribute.Value).Append("\"");
      }
    }
    else
    {
      string str2;
      if (t.Attributes.TryGetValue("xfa-full-processing-instruction-contents", out str2) && str2 != null && str2.Length > 0)
        this.sb.Append(str2);
    }
    this.sb.Append(">");
  }

  public void Content(string content) => this.contentBuilder.Append(content);

  public void End(Tag t)
  {
    this.sb.Append((object) this.contentBuilder);
    this.contentBuilder.Length = 0;
    string str = t.NameSpace.Length > 0 ? $"{t.NameSpace}:{t.Name}" : t.Name;
    if (t.Name.StartsWith("?"))
      return;
    this.sb.Append("</").Append(str).Append(">");
  }

  public string GetResult() => this.sb.ToString();
}
