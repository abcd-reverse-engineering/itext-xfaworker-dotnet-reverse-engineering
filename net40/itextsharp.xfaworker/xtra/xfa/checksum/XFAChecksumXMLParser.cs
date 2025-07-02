// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.checksum.XFAChecksumXMLParser
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.tool.xml.parser;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.checksum;

public class XFAChecksumXMLParser(bool isHtml, IXMLParserListener listener) : XMLParser(isHtml, listener)
{
  public virtual void StartElement()
  {
    if (this.Memory().GetCurrentTag().StartsWith("?"))
    {
      this.Memory().CurrentAttr("xfa-full-processing-instruction-contents");
      this.Memory().PutCurrentAttrValue("?" + (object) this.Memory().ProcessingInstruction());
    }
    base.StartElement();
  }
}
