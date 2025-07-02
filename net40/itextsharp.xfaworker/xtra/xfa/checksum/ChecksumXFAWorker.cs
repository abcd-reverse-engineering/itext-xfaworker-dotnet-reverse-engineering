// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.checksum.ChecksumXFAWorker
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using System.Collections.Generic;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.checksum;

public class ChecksumXFAWorker : XFAWorker
{
  private XFANormalizer xfaNormalizer;

  public ChecksumXFAWorker(IPipeline pipeline, XFANormalizer normalizer)
    : base(pipeline)
  {
    this.xfaNormalizer = normalizer;
  }

  public override void StartElement(string tag, IDictionary<string, string> attr, string ns)
  {
    this.xfaNormalizer.Start(base.CreateTag(tag, attr, ns));
    base.StartElement(tag, attr, ns);
  }

  public override void EndElement(string tag, string ns)
  {
    this.xfaNormalizer.End(XMLWorker.GetLocalWC().GetCurrentTag());
    base.EndElement(tag, ns);
  }

  public virtual void Text(string text)
  {
    base.Text(text);
    this.xfaNormalizer.Content(text);
  }
}
