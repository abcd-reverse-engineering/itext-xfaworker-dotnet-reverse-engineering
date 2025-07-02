// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.element.PageSet
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.tool.xml.xtra.xfa.js;
using iTextSharp.tool.xml.xtra.xfa.resolver;
using iTextSharp.tool.xml.xtra.xfa.tags;
using Jint.Native;
using System.Collections.Generic;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.element;

public class PageSet : JsNode
{
  protected PageArea currentPageArea;
  protected new FlattenerContext flattenerContext;

  public PageSet(XFATemplateTag pageSetTag, JsNode parentNode, FlattenerContext flattenerContext)
    : base((Tag) pageSetTag, parentNode, "pageSet")
  {
    this.flattenerContext = flattenerContext;
  }

  public override string ClassName => "pageSet";

  public virtual PageArea SetCurrentPageArea(PageArea currentPageArea)
  {
    PageArea currentPageArea1 = this.currentPageArea;
    this.currentPageArea = currentPageArea;
    if (currentPageArea1 != null && currentPageArea1.Template != currentPageArea.Template && currentPageArea.Occured > 0)
    {
      this.GetNewInstanceOfCurrentPageArea();
      this.currentPageArea.Occured = 0;
    }
    return this.currentPageArea;
  }

  public virtual PageArea CurrentPageArea => this.currentPageArea;

  public virtual ContentArea NextContentArea(BreakConditions breakConditions)
  {
    if (breakConditions != null)
    {
      if ("pageArea".Equals(breakConditions.Type))
        return (ContentArea) null;
      if (breakConditions.Target != null)
      {
        JsTree jsTree = this.currentPageArea != null ? this.currentPageArea.SearchNode(breakConditions.Target, true) : this.SearchNode(breakConditions.Target, false);
        return jsTree is ContentArea ? (ContentArea) jsTree : (ContentArea) null;
      }
    }
    return this.currentPageArea == null ? (ContentArea) null : this.currentPageArea.NextContentArea;
  }

  public virtual PageArea NextPageArea(
    BreakConditions breakConditions,
    ContentArea nextContentArea,
    int pageNumber)
  {
    PageArea pageArea = this.NextPageArea(breakConditions, nextContentArea, pageNumber, true, false, (PageArea) null);
    if (pageArea != null)
      this.IncPageAreaOccur(pageArea);
    return pageArea;
  }

  public virtual PageArea NextBlankPageArea(PageArea previousPageArea, int pageNumber)
  {
    PageArea childPageArea = previousPageArea == null || !this.IsDuplexPagination() ? (PageArea) null : previousPageArea.ParentPageSet.GetChildPageAreas()[0];
    PageArea pageArea = this.NextPageArea((BreakConditions) null, (ContentArea) null, pageNumber, true, true, childPageArea);
    if (pageArea != null)
      this.IncPageAreaOccur(pageArea);
    return pageArea;
  }

  public virtual bool IsDuplexPagination()
  {
    return "duplexPaginated".Equals(this.RetrieveAttribute("relation"));
  }

  public virtual PageArea GetNewInstanceOfCurrentPageArea()
  {
    this.GetInstanceManagerByTemplate((Tag) this.currentPageArea.Template)?.DecCount();
    IList<PageArea> pageAreaList = PageSet.FilterPageAreasOnly(this.RetrieveChildren(this.currentPageArea.RetrieveName()));
    int num = pageAreaList != null ? pageAreaList.IndexOf(this.currentPageArea) : -1;
    PageArea ofCurrentPageArea;
    if (num != -1 && num + 1 < pageAreaList.Count)
    {
      ofCurrentPageArea = pageAreaList[num + 1];
      ofCurrentPageArea.Occured = this.currentPageArea.Occured;
      ofCurrentPageArea.MaxOccur = this.currentPageArea.MaxOccur;
      ofCurrentPageArea.SetCurrentContentAreaInd(this.currentPageArea.CurrentContentAreaInd);
      this.currentPageArea = ofCurrentPageArea;
    }
    else
    {
      ofCurrentPageArea = (PageArea) this.flattenerContext.FormBuilder.BuildSubForm(this.currentPageArea.Template, this.currentPageArea.Data, (JsNode) this);
      ofCurrentPageArea.Occured = this.currentPageArea.Occured;
      ofCurrentPageArea.MaxOccur = this.currentPageArea.MaxOccur;
      ofCurrentPageArea.SetCurrentContentAreaInd(this.currentPageArea.CurrentContentAreaInd);
      JintJsNodeList ownProperty = (JintJsNodeList) this.GetOwnProperty("nodes");
      int i1 = 0;
      int i2 = 0;
      if (ownProperty != null)
      {
        for (; i1 < ownProperty.Length; ++i1)
        {
          object obj = ownProperty.GetItem(i1);
          switch (obj)
          {
            case PageArea _:
              if (this.currentPageArea == obj)
              {
                ownProperty.Insert(i1 + 1, (object) ofCurrentPageArea);
                JintJsNodeList all = this.currentPageArea.GetAll();
                if (all.Length > 1)
                {
                  for (; i2 < all.Length; ++i2)
                  {
                    if (this.currentPageArea == all.GetItem(i2))
                      all.Insert(i2 + 1, (object) ofCurrentPageArea);
                  }
                }
                else
                {
                  all.Append((object) ofCurrentPageArea);
                  this.DefineProperty(this.currentPageArea.Name, (object) all);
                }
                this.currentPageArea = ofCurrentPageArea;
                goto label_19;
              }
              break;
            case PageSet _:
              if (((PageSet) obj).CurrentPageArea == this.currentPageArea)
              {
                ofCurrentPageArea = ((PageSet) obj).GetNewInstanceOfCurrentPageArea();
                if (ofCurrentPageArea != null)
                {
                  this.currentPageArea = ofCurrentPageArea;
                  goto label_19;
                }
                break;
              }
              break;
          }
        }
      }
    }
label_19:
    return ofCurrentPageArea;
  }

  public virtual PageArea FindPageAreaWithLastPagePosition()
  {
    JintJsNodeList ownProperty = (JintJsNodeList) this.GetOwnProperty("nodes");
    for (int i = 0; i < ownProperty.Length; ++i)
    {
      object obj = (object) ownProperty.get(i);
      if (obj is PageArea)
      {
        PageArea lastPagePosition = (PageArea) obj;
        if ("last".Equals(lastPagePosition.RetrieveAttribute("pagePosition")))
          return lastPagePosition;
      }
    }
    return (PageArea) null;
  }

  private PageArea NextPageArea(
    BreakConditions breakConditions,
    ContentArea nextContentArea,
    int pageNumber,
    bool fallbackToCurrentPageArea,
    bool blankArea,
    PageArea startFrom)
  {
    if (breakConditions != null && !"contentArea".Equals(breakConditions.Type) && breakConditions.Target != null)
    {
      JsTree currentPageArea = this.SearchNode(breakConditions.Target, false);
      if (currentPageArea is PageArea && this.PageAreaSatisfiesAllConditionsToBeSelected((PageArea) currentPageArea, pageNumber, breakConditions, blankArea))
        return this.SetCurrentPageArea((PageArea) currentPageArea).SetCurrentContentAreaInd(0);
    }
    if (nextContentArea != null && this.PageAreaSatisfiesAllConditionsToBeSelected(nextContentArea.PageArea, pageNumber, breakConditions, blankArea))
      return this.SetCurrentPageArea(nextContentArea.PageArea).SetCurrentContentArea(nextContentArea);
    JintJsNodeList ownProperty = (JintJsNodeList) this.GetOwnProperty("nodes");
    List<object> objectList = new List<object>();
    if (ownProperty != null)
    {
      for (int i = 0; i < ownProperty.Length; ++i)
        objectList.Add(ownProperty.GetItem(i));
    }
    PageArea pageArea1 = startFrom == null ? (!this.IsDuplexPagination() ? this.currentPageArea : (this.currentPageArea != null ? this.currentPageArea.ParentPageSet.GetChildPageAreas()[0] : (PageArea) null)) : startFrom;
    bool flag = pageArea1 == null;
    PageArea currentPageArea1 = (PageArea) null;
    for (int index = 0; index < objectList.Count; ++index)
    {
      object obj1 = objectList[index];
      switch (obj1)
      {
        case PageArea _:
          if (pageArea1 != null && this.ContainsOwnPageArea(pageArea1))
          {
            if (pageArea1 == obj1)
            {
              if (this.PageAreaSatisfiesAllConditionsToBeSelected((PageArea) obj1, pageNumber, breakConditions, blankArea))
              {
                currentPageArea1 = (PageArea) obj1;
                goto label_26;
              }
              pageArea1 = (PageArea) null;
              for (int i = 0; i < ownProperty.Length; ++i)
              {
                object obj2 = ownProperty.GetItem(i);
                if (obj2 != obj1)
                  objectList.Add(obj2);
                else
                  break;
              }
              break;
            }
            break;
          }
          PageArea pageArea2 = (PageArea) obj1;
          if (this.PageAreaSatisfiesAllConditionsToBeSelected(pageArea2, pageNumber, breakConditions, blankArea))
          {
            currentPageArea1 = pageArea2;
            goto label_26;
          }
          break;
        case PageSet _:
          if (flag || pageArea1 != null && ((PageSet) obj1).ContainsOwnPageArea(pageArea1))
          {
            flag = true;
            PageArea pageArea3 = ((PageSet) obj1).NextPageArea(breakConditions, (ContentArea) null, pageNumber, false, blankArea, pageArea1);
            if (pageArea3 != null)
            {
              currentPageArea1 = pageArea3;
              goto label_26;
            }
            break;
          }
          break;
      }
    }
label_26:
    if (currentPageArea1 != null)
      return this.SetCurrentPageArea(currentPageArea1).SetCurrentContentAreaInd(0);
    if (!fallbackToCurrentPageArea || this.currentPageArea == null)
      return (PageArea) null;
    this.currentPageArea.SetCurrentContentAreaInd(0);
    return this.currentPageArea;
  }

  private bool ContainsOwnPageArea(PageArea pageArea)
  {
    return this.GetNodes().IndexOfCompareReferences((JsInstance) pageArea) >= 0;
  }

  private bool PageAreaSatisfiesAllConditionsToBeSelected(
    PageArea pageArea,
    int pageNumber,
    BreakConditions breakConditions,
    bool blankArea)
  {
    return this.CheckOccurRequirement(pageArea) && this.CheckPageNumberRequirement(breakConditions, pageArea, pageNumber) && (pageArea.contentAreas.Count > 0 || blankArea) && PageSet.CheckBlankPageRequirement(pageArea, blankArea);
  }

  private static bool CheckBlankPageRequirement(PageArea area, bool blankArea)
  {
    return !blankArea || !"notBlank".Equals(area.RetrieveAttribute("blankOrNotBlank"));
  }

  private bool CheckOccurRequirement(PageArea pageArea)
  {
    return this.currentPageArea == null || this.currentPageArea.Template != pageArea.Template || pageArea.Occured < pageArea.MaxOccur;
  }

  private void IncPageAreaOccur(PageArea pageArea)
  {
    foreach (PageArea childPageArea in pageArea.ParentPageSet.GetChildPageAreas())
    {
      if (childPageArea.Template == pageArea.Template)
        childPageArea.IncOccured();
    }
  }

  private List<PageArea> GetChildPageAreas()
  {
    List<PageArea> childPageAreas = new List<PageArea>();
    JintJsNodeList nodes = this.GetNodes();
    if (nodes != null)
    {
      for (int i = 0; i < nodes.Length; ++i)
      {
        if (nodes.GetItem(i) is PageArea)
          childPageAreas.Add((PageArea) nodes.GetItem(i));
      }
    }
    return childPageAreas;
  }

  private bool CheckPageNumberRequirement(
    BreakConditions breakConditions,
    PageArea pageArea,
    int pageNumber)
  {
    if (breakConditions == null || breakConditions.Target == null)
    {
      string str = pageArea.RetrieveAttribute("pagePosition");
      if ("first".Equals(str) && pageNumber != 1 || "only".Equals(str) && pageArea.Occured != 0)
        return false;
    }
    if (this.IsDuplexPagination() && (breakConditions == null || !breakConditions.StartNew && !PageArea.ArePartsOfDifferentPageSets(this.currentPageArea, pageArea)))
    {
      string str = pageArea.RetrieveAttribute("oddOrEven");
      if ("odd".Equals(str) && pageNumber % 2 != 1 || "even".Equals(str) && pageNumber % 2 != 0)
        return false;
    }
    if (this.IsDuplexPagination() && breakConditions != null)
    {
      string str = pageArea.RetrieveAttribute("oddOrEven");
      if ("pageOdd".Equals(breakConditions.Type) && "even".Equals(str) || "pageEven".Equals(breakConditions.Type) && "odd".Equals(str))
        return false;
    }
    return true;
  }

  private static IList<PageArea> FilterPageAreasOnly(IList<IFormNode> nodes)
  {
    List<PageArea> pageAreaList = new List<PageArea>();
    foreach (IFormNode node in (IEnumerable<IFormNode>) nodes)
    {
      if (node is PageArea)
        pageAreaList.Add((PageArea) node);
    }
    return (IList<PageArea>) pageAreaList;
  }
}
