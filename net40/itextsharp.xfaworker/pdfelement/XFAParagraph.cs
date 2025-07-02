// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.pdfelement.XFAParagraph
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.text;
using System.Collections.Generic;

#nullable disable
namespace iTextSharp.tool.xml.pdfelement;

internal class XFAParagraph : Paragraph
{
  private string apiVersion;
  private Dictionary<string, string> userStyles;

  public XFAParagraph()
  {
  }

  public XFAParagraph(float leading)
    : base(leading)
  {
  }

  public XFAParagraph(Chunk chunk)
    : base(chunk)
  {
  }

  public XFAParagraph(float leading, Chunk chunk)
    : base(leading, chunk)
  {
  }

  public XFAParagraph(string str)
    : base(str)
  {
  }

  public XFAParagraph(string str, Font font)
    : base(str, font)
  {
  }

  public XFAParagraph(float leading, string str)
    : base(leading, str)
  {
  }

  public XFAParagraph(float leading, string str, Font font)
    : base(leading, str, font)
  {
  }

  public XFAParagraph(Phrase phrase)
    : base(phrase)
  {
    if (!(phrase is XFAParagraph) || ((XFAParagraph) phrase).userStyles == null)
      return;
    this.userStyles = new Dictionary<string, string>((IDictionary<string, string>) ((XFAParagraph) phrase).userStyles);
  }

  public virtual Paragraph CloneShallow(bool spacingBefore)
  {
    XFAParagraph xfaParagraph = new XFAParagraph();
    this.PopulateProperties((Paragraph) xfaParagraph, spacingBefore);
    if (this.userStyles != null && this.userStyles != null)
      xfaParagraph.userStyles = new Dictionary<string, string>((IDictionary<string, string>) this.userStyles);
    xfaParagraph.apiVersion = this.apiVersion;
    return (Paragraph) xfaParagraph;
  }

  public virtual Dictionary<string, string> UserStyles
  {
    get => this.userStyles;
    set => this.userStyles = value;
  }

  public virtual string GetApiVersion() => this.apiVersion;

  public virtual void SetApiVersion(string apiVersion) => this.apiVersion = apiVersion;
}
