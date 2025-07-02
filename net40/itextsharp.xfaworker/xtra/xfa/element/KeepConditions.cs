// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.element.KeepConditions
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using System.Collections.Generic;
using System.util;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.element;

public class KeepConditions
{
  protected string intact = "none";
  protected string next = "none";
  protected string previous = "none";

  public KeepConditions(Tag tag)
  {
    if (Util.EqualsIgnoreCase("draw", tag.Name))
      this.intact = "contentArea";
    IDictionary<string, string> attributes = tag.Attributes;
    if (attributes == null)
      return;
    string str;
    if (attributes.TryGetValue(nameof (intact), out str) && str != null)
      this.intact = str;
    if (attributes.TryGetValue(nameof (next), out str) && str != null)
      this.next = str;
    if (!attributes.TryGetValue(nameof (previous), out str) || str == null)
      return;
    this.previous = str;
  }

  public virtual string Intact => this.intact;

  public virtual string Next => this.next;

  public virtual string Previous => this.previous;
}
