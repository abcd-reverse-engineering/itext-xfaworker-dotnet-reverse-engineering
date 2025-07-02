// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.element.OverflowConditions
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.tool.xml.xtra.xfa.js;
using iTextSharp.tool.xml.xtra.xfa.positioner;
using iTextSharp.tool.xml.xtra.xfa.resolver;
using iTextSharp.tool.xml.xtra.xfa.tags;
using System.Collections.Generic;
using System.util;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.element;

public class OverflowConditions
{
  private IList<TrailerLeaderElement> leader;
  private IList<TrailerLeaderElement> trailer;
  private Positioner leaderParent;
  private Positioner trailerParent;

  public OverflowConditions(
    Tag tag,
    FlattenerContext referenceResolver,
    OverflowConditions parent,
    Positioner parentPositioner)
  {
    string str1 = (string) null;
    string str2 = (string) null;
    if (tag != null)
    {
      if (Util.EqualsIgnoreCase(tag.Name, "break"))
      {
        tag.Attributes.TryGetValue("overflowLeader", out str1);
        tag.Attributes.TryGetValue("overflowTrailer", out str2);
      }
      else if (Util.EqualsIgnoreCase(tag.Name, "overflow"))
      {
        tag.Attributes.TryGetValue(nameof (leader), out str1);
        tag.Attributes.TryGetValue(nameof (trailer), out str2);
      }
      this.leaderParent = parentPositioner;
    }
    if (!string.IsNullOrEmpty(str1))
    {
      string str3 = str1;
      char[] chArray = new char[1]{ ' ' };
      foreach (string somExpressions in str3.Split(chArray))
      {
        JsNode jsNode = (JsNode) parentPositioner.ResolveNode(somExpressions);
        if (jsNode != null)
        {
          XFATemplateTag tag1 = (XFATemplateTag) jsNode.Tag;
          if (tag1 != null)
          {
            if (this.leader == null)
              this.leader = (IList<TrailerLeaderElement>) new List<TrailerLeaderElement>();
            this.leader.Add(new TrailerLeaderElement(tag1));
          }
        }
      }
    }
    else if (parent != null)
    {
      bool flag = false;
      if (parent.leader != null)
      {
        foreach (TrailerLeaderElement trailerLeaderElement in (IEnumerable<TrailerLeaderElement>) parent.leader)
        {
          if (trailerLeaderElement.FormTag == parentPositioner.Template)
          {
            flag = true;
            break;
          }
        }
      }
      if (!flag)
      {
        this.leader = parent.leader;
        this.leaderParent = parent.leaderParent;
      }
    }
    if (!string.IsNullOrEmpty(str2))
    {
      string str4 = str2;
      char[] chArray = new char[1]{ ' ' };
      foreach (string expression in str4.Split(chArray))
      {
        IFormNode formTag = new SomExpression(expression).ResolveNode((IFormNode) parentPositioner.Template, true);
        if (formTag is XFATemplateTag)
        {
          if (this.trailer == null)
            this.trailer = (IList<TrailerLeaderElement>) new List<TrailerLeaderElement>();
          this.trailer.Add(new TrailerLeaderElement((XFATemplateTag) formTag));
        }
      }
      this.trailerParent = parentPositioner;
    }
    else
    {
      if (parent == null)
        return;
      this.trailer = parent.trailer;
      this.trailerParent = parent.trailerParent;
    }
  }

  public virtual TrailerLeaderElement GetCurrentLeader()
  {
    return this.leader != null && this.leader.Count > 0 ? this.leader[0] : (TrailerLeaderElement) null;
  }

  public virtual TrailerLeaderElement GetNextLeader()
  {
    TrailerLeaderElement nextLeader = (TrailerLeaderElement) null;
    if (this.leader != null && this.leader.Count > 0)
      nextLeader = this.GetNextElement(this.leader);
    return nextLeader;
  }

  public virtual TrailerLeaderElement GetCurrentTrailer()
  {
    return this.trailer != null && this.trailer.Count > 0 ? this.trailer[0] : (TrailerLeaderElement) null;
  }

  public virtual TrailerLeaderElement GetNextTrailer()
  {
    TrailerLeaderElement nextTrailer = (TrailerLeaderElement) null;
    if (this.trailer != null && this.trailer.Count > 0)
      nextTrailer = this.GetNextElement(this.trailer);
    return nextTrailer;
  }

  public virtual Positioner LeaderParent
  {
    get => this.leaderParent;
    set => this.leaderParent = value;
  }

  public virtual Positioner TrailerParent
  {
    get => this.trailerParent;
    set => this.trailerParent = value;
  }

  private TrailerLeaderElement GetNextElement(IList<TrailerLeaderElement> elementList)
  {
    TrailerLeaderElement nextElement = elementList[0];
    if (!nextElement.IncrementOccur())
    {
      elementList.RemoveAt(0);
      if (elementList.Count > 0)
        return this.GetNextElement(elementList);
      nextElement = (TrailerLeaderElement) null;
    }
    return nextElement;
  }
}
