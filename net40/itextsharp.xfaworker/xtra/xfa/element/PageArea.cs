// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.element.PageArea
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml.css;
using iTextSharp.tool.xml.xtra.xfa.js;
using iTextSharp.tool.xml.xtra.xfa.positioner;
using iTextSharp.tool.xml.xtra.xfa.resolver;
using iTextSharp.tool.xml.xtra.xfa.tags;
using iTextSharp.tool.xml.xtra.xfa.util;
using System;
using System.Collections.Generic;
using System.Globalization;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.element;

public class PageArea : SubFormPositioner
{
  protected int currentContentAreaInd;
  protected internal IList<ContentArea> contentAreas = (IList<ContentArea>) new List<ContentArea>();
  protected Rectangle pageSize;
  private int maxOccur = int.MaxValue;
  private int occured;
  private PageSet parentPageSet;

  public PageArea(
    XFATemplateTag templateTag,
    JsNode parentNode,
    DataTag dataTag,
    FlattenerContext flattenerContext)
    : base(templateTag, dataTag, flattenerContext, parentNode, "pageArea")
  {
    this.maxOccur = this.template.MaxOccur;
    if (parentNode is PageSet)
      this.parentPageSet = (PageSet) parentNode;
    IList<Tag> children = this.template.GetChildren("medium");
    if (children != null && children.Count > 0)
    {
      IDictionary<string, string> attributes = children[0].Attributes;
      string str = XFAUtil.GetAttributeValue("stock", attributes);
      string attributeValue1 = XFAUtil.GetAttributeValue("orientation", attributes);
      if (attributeValue1 != null && !"portrait".Equals(attributeValue1))
        str = $"{str}_{attributeValue1}";
      if (str != null)
      {
        try
        {
          this.pageSize = iTextSharp.text.PageSize.GetRectangle(str);
        }
        catch
        {
        }
      }
      if (this.pageSize == null)
      {
        string attributeValue2 = XFAUtil.GetAttributeValue("short", attributes);
        string attributeValue3 = XFAUtil.GetAttributeValue("long", attributes);
        float pxInCmMmPcToPt1 = CssUtils.GetInstance().ParsePxInCmMmPcToPt(attributeValue2);
        float pxInCmMmPcToPt2 = CssUtils.GetInstance().ParsePxInCmMmPcToPt(attributeValue3);
        if (attributeValue1 == null || "portrait".Equals(attributeValue1))
          this.pageSize = iTextSharp.text.PageSize.GetRectangle($"{pxInCmMmPcToPt1.ToString((IFormatProvider) CultureInfo.InvariantCulture)} {pxInCmMmPcToPt2.ToString((IFormatProvider) CultureInfo.InvariantCulture)}");
        else if ("landscape".Equals(attributeValue1))
          this.pageSize = iTextSharp.text.PageSize.GetRectangle($"{pxInCmMmPcToPt2.ToString((IFormatProvider) CultureInfo.InvariantCulture)} {pxInCmMmPcToPt1.ToString((IFormatProvider) CultureInfo.InvariantCulture)}");
      }
    }
    this.pageSize = this.pageSize != null ? new PdfRectangle(this.pageSize, this.pageSize.Rotation).Rectangle : new Rectangle(0.0f, 0.0f, 0.0f, 0.0f);
    this.Role = PdfName.ARTIFACT;
  }

  public virtual int Occured
  {
    get => this.occured;
    set => this.occured = value;
  }

  public virtual int MaxOccur
  {
    get => this.maxOccur;
    set => this.maxOccur = value;
  }

  public virtual void IncOccured() => ++this.occured;

  public virtual int CurrentContentAreaInd => this.currentContentAreaInd;

  public PageArea SetCurrentContentAreaInd(int currentContentAreaInd)
  {
    this.currentContentAreaInd = currentContentAreaInd;
    return this;
  }

  public virtual PageSet ParentPageSet => this.parentPageSet;

  public override string ClassName => "pageArea";

  public override void InitContentArea(float? parentLlx, float? parentUry)
  {
    if (!parentLlx.HasValue)
      parentLlx = new float?(0.0f);
    if (!parentUry.HasValue)
      parentUry = new float?(this.pageSize.Height);
    this.contentArea = new XFARectangle(parentLlx, parentUry, new float?(this.pageSize.Width), new float?(this.pageSize.Height));
  }

  public virtual Rectangle PageSize => this.pageSize;

  public virtual PageArea SetCurrentContentArea(ContentArea contentArea)
  {
    int num = this.contentAreas.IndexOf(contentArea);
    if (num != -1)
      this.currentContentAreaInd = num;
    return this;
  }

  public virtual ContentArea CurrentContentArea
  {
    get
    {
      return this.currentContentAreaInd != -1 && this.currentContentAreaInd < this.contentAreas.Count ? this.contentAreas[this.currentContentAreaInd] : (ContentArea) null;
    }
  }

  public virtual ContentArea NextContentArea
  {
    get
    {
      int index = this.currentContentAreaInd + 1;
      return index >= this.contentAreas.Count ? (ContentArea) null : this.contentAreas[index];
    }
  }

  public override void AddChild(JsTree child)
  {
    base.AddChild(child);
    if (!(child is ContentArea))
      return;
    ContentArea contentArea = (ContentArea) child;
    contentArea.PageArea = this;
    contentArea.Rect.Llx = new float?(XFAUtil.ReverseX(this.pageSize.Left, contentArea.Rect.Llx));
    contentArea.Rect.Ury = new float?(XFAUtil.ReverseY(this.pageSize.Height, contentArea.Rect.Ury, new float?(0.0f)));
    this.contentAreas.Add(contentArea);
  }

  protected override void PopulateCanvases(PdfContentByte parentCanvas)
  {
    List<PdfContentByte> collection = new List<PdfContentByte>();
    foreach (Positioner childElement in this.childElements)
    {
      if ((childElement.IsVisible() || childElement.IsInvisible()) && !(childElement is SubFormPositioner))
      {
        childElement.Canvas = parentCanvas.GetDuplicate(true);
        if (childElement is DrawPositioner)
          collection.Add(childElement.Canvas);
        else
          this.canvases.Add(childElement.canvas);
      }
    }
    this.canvases.InsertRange(0, (IEnumerable<PdfContentByte>) collection);
    base.PopulateCanvases(parentCanvas);
  }

  public static bool ArePartsOfDifferentPageSets(PageArea first, PageArea second)
  {
    return first?.ParentPageSet != second?.ParentPageSet;
  }
}
