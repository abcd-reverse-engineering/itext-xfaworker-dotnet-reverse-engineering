// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.bind.EmbeddedElement
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.text;
using iTextSharp.tool.xml.xtra.xfa.positioner;
using System.Collections.Generic;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.bind;

public class EmbeddedElement : IElement
{
  private bool isUri;
  private bool isRaw;
  private string embedValue;
  private Font font;
  private Positioner positioner;
  private IDictionary<string, object> attributes;

  public EmbeddedElement(string embedValue) => this.embedValue = embedValue;

  public virtual string EmbedValue => this.embedValue;

  public virtual bool IsUri
  {
    get => this.isUri;
    set => this.isUri = value;
  }

  public virtual bool IsRaw
  {
    get => this.isRaw;
    set => this.isRaw = value;
  }

  public virtual Font Font
  {
    get => this.font;
    set => this.font = value;
  }

  public virtual bool Process(IElementListener listener) => false;

  public virtual int Type => 666;

  public virtual bool IsContent() => false;

  public virtual bool IsNestable() => false;

  public virtual IList<Chunk> Chunks
  {
    get
    {
      IList<Chunk> chunks = (IList<Chunk>) new List<Chunk>();
      chunks.Add(new Chunk("\u200B", this.font));
      return chunks;
    }
  }

  public virtual IDictionary<string, object> Attributes
  {
    get => this.attributes;
    set => this.attributes = value;
  }

  public virtual Positioner Positioner
  {
    get => this.positioner;
    set => this.positioner = value;
  }
}
