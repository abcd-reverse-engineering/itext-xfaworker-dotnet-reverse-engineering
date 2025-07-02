// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.element.TrailerLeaderElement
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.tool.xml.xtra.xfa.tags;
using iTextSharp.tool.xml.xtra.xfa.util;
using System;
using System.Collections.Generic;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.element;

public class TrailerLeaderElement
{
  private XFATemplateTag formTag;
  private int occured;
  private int maxOccur = int.MaxValue;
  private XFARectangle boundingBox;

  public TrailerLeaderElement(XFATemplateTag formTag)
  {
    this.formTag = formTag;
    Tag child = formTag.GetChild("occur", "", false);
    if (child != null)
    {
      IDictionary<string, string> attributes = child.Attributes;
      string s = (string) null;
      attributes.TryGetValue("max", out s);
      if (s != null)
      {
        if (s.Length > 0)
        {
          try
          {
            this.maxOccur = int.Parse(s);
          }
          catch (FormatException ex)
          {
          }
        }
      }
      if (this.maxOccur == -1)
        this.maxOccur = int.MaxValue;
    }
    this.maxOccur = formTag.MaxOccur;
  }

  public virtual XFATemplateTag FormTag => this.formTag;

  public virtual bool IncrementOccur()
  {
    ++this.occured;
    return this.maxOccur > this.occured;
  }

  public virtual XFARectangle BoundingBox
  {
    get => this.boundingBox;
    set => this.boundingBox = value;
  }
}
