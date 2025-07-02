// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.positioner.ContentPositioner
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.awt.geom;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.interfaces;
using iTextSharp.tool.xml.xtra.xfa.element;
using iTextSharp.tool.xml.xtra.xfa.js;
using iTextSharp.tool.xml.xtra.xfa.resolver;
using iTextSharp.tool.xml.xtra.xfa.tags;
using iTextSharp.tool.xml.xtra.xfa.util;
using Jint.Native;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.util;
using System.util.collections;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.positioner;

public abstract class ContentPositioner : Positioner
{
  private static readonly HashSet2<string> ALLOWED_UI_ELEMENTS = new HashSet2<string>((IEnumerable<string>) new string[10]
  {
    "textEdit",
    "numericEdit",
    "dateTimeEdit",
    "passwordEdit",
    "imageEdit",
    "checkButton",
    "choiceList",
    "button",
    "signature",
    "barcode"
  });
  protected Document document;
  protected UiElement uiElement;
  protected List<UiElement> uiElements;
  protected ContentElement contentElement;
  protected CaptionElement captionElement;
  protected string inputParsingPattern;
  protected int? originalNumberOfFractionalDigitsInRawValue;

  internal ContentPositioner(string className, JsNode prototype)
    : base(className, prototype)
  {
  }

  public ContentPositioner(
    XFATemplateTag templateTag,
    DataTag dataTag,
    FlattenerContext flattenerContext,
    JsNode parent,
    string prototypeName)
    : base(templateTag, dataTag, flattenerContext, parent, prototypeName)
  {
    this.document = flattenerContext.Document;
    this.InitValues();
  }

  public override Positioner CheckOverflowing(
    XFARectangle parentBoundingBox,
    PageArea currentPageArea,
    bool breakableStatus,
    float bottomMargin)
  {
    return this.CheckOverflowing(parentBoundingBox, currentPageArea, breakableStatus, true);
  }

  public virtual Positioner CheckOverflowing(
    XFARectangle parentBoundingBox,
    PageArea currentPageArea,
    bool breakableStatus,
    bool checkBreakable)
  {
    if (!this.IsVisible() && !this.IsInvisible())
      return (Positioner) null;
    if (breakableStatus && !this.IsCurrentPageContentAreaOverflowed(currentPageArea) && parentBoundingBox != null)
    {
      float num1 = parentBoundingBox.Ury.Value - parentBoundingBox.Height.Value;
      Positioner breakableElement = this.FindNextBreakableElement();
      XFARectangle bbox1 = breakableElement.GetBBox();
      float num2 = bbox1.Height.HasValue ? bbox1.Height.Value : 0.0f;
      float? ury1 = bbox1.Ury;
      float num3 = num2;
      float? nullable1 = ury1.HasValue ? new float?(ury1.GetValueOrDefault() - num3) : new float?();
      float num4 = num1;
      float? nullable2 = nullable1.HasValue ? new float?(nullable1.GetValueOrDefault() - num4) : new float?();
      float num5 = -XFAUtil.DEVIATION;
      if (((double) nullable2.GetValueOrDefault() >= (double) num5 ? 0 : (nullable2.HasValue ? 1 : 0)) != 0)
      {
        if (breakableElement == this)
        {
          if (checkBreakable && this.IsBreakable)
          {
            float? ury2 = bbox1.Ury;
            float num6 = num1;
            float? nullable3 = ury2.HasValue ? new float?(ury2.GetValueOrDefault() - num6) : new float?();
            float num7 = -XFAUtil.DEVIATION;
            if (((double) nullable3.GetValueOrDefault() >= (double) num7 ? 0 : (nullable3.HasValue ? 1 : 0)) == 0)
            {
              XFARectangle xfaRectangle = (XFARectangle) parentBoundingBox.Clone();
              this.ApplyMargins(xfaRectangle);
              this.ApplyTransformationToRectangle(xfaRectangle, true);
              if (this.SimulatePosition(xfaRectangle).GetState() == PositionResult.State.NO_CONTENT)
                return (Positioner) this;
              goto label_15;
            }
          }
          return (Positioner) this;
        }
        if (breakableElement.CheckOverflowing(parentBoundingBox, currentPageArea, breakableStatus, 0.0f) != null)
          return (Positioner) this;
        if (!checkBreakable)
        {
          XFARectangle bbox2 = this.GetBBox();
          float num8 = bbox2.Height.HasValue ? bbox2.Height.Value : 0.0f;
          float? ury3 = bbox2.Ury;
          float num9 = num8;
          float? nullable4 = ury3.HasValue ? new float?(ury3.GetValueOrDefault() - num9) : new float?();
          float num10 = num1;
          float? nullable5 = nullable4.HasValue ? new float?(nullable4.GetValueOrDefault() - num10) : new float?();
          float num11 = -XFAUtil.DEVIATION;
          if (((double) nullable5.GetValueOrDefault() >= (double) num11 ? 0 : (nullable5.HasValue ? 1 : 0)) != 0)
            return (Positioner) this;
        }
      }
label_15:
      if (!this.IsBreakable && this.contentArea != null && this.contentArea.Height.HasValue)
      {
        float? ury4 = this.contentArea.Ury;
        float? height = this.contentArea.Height;
        float? nullable6 = ury4.HasValue & height.HasValue ? new float?(ury4.GetValueOrDefault() - height.GetValueOrDefault()) : new float?();
        float num12 = num1;
        float? nullable7 = nullable6.HasValue ? new float?(nullable6.GetValueOrDefault() - num12) : new float?();
        float num13 = -XFAUtil.DEVIATION;
        if (((double) nullable7.GetValueOrDefault() >= (double) num13 ? 0 : (nullable7.HasValue ? 1 : 0)) != 0)
          return (Positioner) this;
      }
    }
    return (Positioner) null;
  }

  protected override Positioner FindNextBreakableElement(int startFrom)
  {
    Positioner breakableElement = base.FindNextBreakableElement(startFrom);
    if (breakableElement != this || this.parent == null)
      return breakableElement;
    string layout = this.parent.GetLayout();
    if (LayoutManager.positionLayout.Equals(layout))
    {
      int index = startFrom;
      int count = this.parent.Children.Count;
      if (index < count)
      {
        Positioner positioner;
        for (positioner = this.parent.Children[index]; positioner.IsHidden() || positioner.IsInactive(); positioner = this.parent.Children[index])
        {
          ++index;
          if (index >= count)
          {
            positioner = (Positioner) null;
            break;
          }
        }
        if (positioner is ContentPositioner)
        {
          XFARectangle bbox1 = this.GetBBox();
          XFARectangle bbox2 = positioner.GetBBox();
          float a = bbox1.Ury.Value - bbox1.Height.Value;
          float b = bbox2.Ury.Value - bbox2.Height.Value;
          if (XFAUtil.Gte(bbox1.Ury.Value, b) && XFAUtil.Lte(a, bbox2.Ury.Value))
            return positioner.FindNextBreakableElement();
        }
      }
    }
    return (Positioner) this;
  }

  public override Positioner Position(
    PdfContentByte canvas,
    XFARectangle parentBoundingBox,
    PageArea currentPageArea,
    bool breakableStatus,
    float bottomMargin)
  {
    if (this.IsInvisible() && !(canvas is PdfCanvasForInvisibleElements))
      canvas = (PdfContentByte) new PdfCanvasForInvisibleElements(this.flattenerContext);
    Positioner positioner = this.CheckOverflowing(parentBoundingBox, currentPageArea, breakableStatus, false);
    if (positioner != null)
    {
      if (positioner == this && this.IsBreakable && !this.IsEmpty())
      {
        Positioner breakableElement = this.FindNextBreakableElement();
        float contentAreaBottom = parentBoundingBox.Ury.Value - parentBoundingBox.Height.Value;
        this.DoesNotFitContentArea(bottomMargin, contentAreaBottom);
        if (breakableElement != this && PositionResult.State.FULL_CONTENT == this.SimulatePosition((XFARectangle) parentBoundingBox.Clone()).GetState() && !breakableElement.IsBreakable && breakableElement.DoesNotFitContentArea(bottomMargin, contentAreaBottom))
        {
          this.AddOverflowedPageContentArea(currentPageArea);
        }
        else
        {
          int num = (int) this.Position(canvas, parentBoundingBox);
        }
      }
      else
        positioner.AddOverflowedPageContentArea(currentPageArea);
      return (Positioner) this;
    }
    if (this.IsEmpty())
      return (Positioner) null;
    this.flattenerContext.CurrentNode = (Positioner) this;
    this.DrawBorder(canvas, parentBoundingBox);
    this.SavePosState(canvas);
    if (this.captionElement != null)
      this.captionElement.Draw(canvas, (XFARectangle) null);
    if (this.uiElement != null)
    {
      if (canvas.IsTagged() && this.uiElement is CheckButtonElement)
      {
        int currentPageNumber1 = canvas.PdfWriter.CurrentPageNumber;
        int? currentPageNumber2 = this.flattenerContext.CurrentPageNumber;
        if ((currentPageNumber1 != currentPageNumber2.GetValueOrDefault() ? 0 : (currentPageNumber2.HasValue ? 1 : 0)) != 0)
        {
          int num = (int) ((CheckButtonElement) this.uiElement).DrawAsField(canvas, (XFARectangle) null, this.captionElement == null || this.captionElement.CaptionText == null ? this.RetrieveName() : this.captionElement.CaptionText, new Regex("xfa\\[0\\]\\.form\\[0\\]\\.").Replace((string) this.SomExpression, "", 1));
          goto label_18;
        }
      }
      int num1 = (int) this.uiElement.Draw(canvas, (XFARectangle) null);
    }
label_18:
    if (this.uiElements != null)
    {
      foreach (Element uiElement in this.uiElements)
      {
        int num = (int) uiElement.Draw(canvas, (XFARectangle) null);
      }
    }
    if (this.contentElement != null)
    {
      int num2 = (int) this.contentElement.Draw(canvas, (XFARectangle) null);
    }
    this.RestorePosState(canvas);
    this.flattenerContext.CurrentNode = this.parent;
    this.positionState = PositionResult.State.FULL_CONTENT;
    this.UpdatePageNumbers();
    return (Positioner) null;
  }

  protected override void AdjustContentArea()
  {
    List<XFARectangle> rectangles = new List<XFARectangle>();
    XFARectangle contentRect = this.GetContentRect();
    if (contentRect != null)
    {
      XFARectangle.SetUndefinedSizes(contentRect);
      rectangles.Add(contentRect);
      if (this.captionElement != null)
        this.captionElement.FixCaptionAreaByContentArea(contentRect);
    }
    else
    {
      XFARectangle.SetUndefinedSizes(this.contentArea);
      rectangles.Add(this.contentArea);
      if (this.captionElement != null)
        this.captionElement.FixCaptionAreaByParentArea(this.contentArea);
    }
    CaptionElement caption = this.GetCaption();
    XFARectangle xfaRectangle = (XFARectangle) null;
    if (caption != null)
      xfaRectangle = caption.GetElementRec();
    if (xfaRectangle != null)
      rectangles.Add(xfaRectangle);
    this.contentArea = XFARectangle.GetCommonRectangle((IList<XFARectangle>) rectangles);
  }

  public override bool IsEmpty() => !this.IsBackgroundOrBorderExist && this.isEmpty;

  protected override void InitLayout()
  {
    base.InitLayout();
    this.flattenerContext.CurrentNode = (Positioner) this;
    this.CreateCaptionElement();
    this.CreateContentElement();
    this.isEmpty = !this.IsBackgroundOrBorderExist && (this.captionElement == null || this.captionElement.IsEmpty()) && (this.uiElement == null || !(this.uiElement is ImageEditElement) && this.uiElement.IsEmpty()) && this.uiElements == null && (this.contentElement == null || this.contentElement.IsEmpty());
    this.isContentTagged = this.captionElement != null && this.captionElement.IsTagged() || this.uiElement != null && this.uiElement.IsTagged() || this.uiElements != null || this.contentElement != null && this.contentElement.IsTagged();
    this.isTagged = this.isContentTagged && (!PdfName.DIV.Equals((object) this.role) || this.captionElement != null && this.captionElement.IsTagged());
    this.flattenerContext.CurrentNode = this.parent;
  }

  public override void SetRawValue(object rawValue)
  {
    if (rawValue != null && rawValue is string)
      rawValue = this.NormalizeRawValueString((string) rawValue, this.template.GetChild("value", "", false));
    if (this.data != null && this.data.Node is JsDataValue)
      this.data.Node.DefineProperty("value", rawValue);
    this.DefineProperty(nameof (rawValue), rawValue);
  }

  protected virtual object NormalizeRawValueString(string value, Tag valueTag)
  {
    object obj = (object) value;
    string name1 = (string) null;
    this.template.Attributes.TryGetValue("locale", out name1);
    XFALocale locale = this.flattenerContext.LocaleResolver.GetLocale(name1);
    bool flag = false;
    IDictionary<string, string> dictionary = (IDictionary<string, string>) null;
    if (valueTag != null && valueTag.HasChildren())
    {
      Tag child = valueTag.Children[0];
      if (child != null)
      {
        string name2 = child.Name;
        if ("integer".Equals(name2) || "decimal".Equals(name2) || "float".Equals(name2))
        {
          flag = true;
          dictionary = child.Attributes;
        }
      }
    }
    Tag child1 = this.template.GetChild("ui", "", false);
    if (child1 != null && child1.Children != null && child1.Children.Count > 0 && Util.EqualsIgnoreCase(child1.Children[0].Name, "numericEdit"))
      flag = true;
    if (flag)
    {
      FormatResolver.NumberParseResult number = this.flattenerContext.FormatResolver.ParseNumber(value, this.inputParsingPattern, locale);
      if (dictionary != null && dictionary.ContainsKey("fracDigits") && "-1".Equals(dictionary["fracDigits"]) && number != null)
        this.originalNumberOfFractionalDigitsInRawValue = number.GetNumberOfFractionalDigits();
      obj = (object) (Decimal?) number?.GetNumber();
    }
    return obj;
  }

  protected abstract XFARectangle GetTextArea();

  public virtual PositionResult.State Position(
    PdfContentByte canvas,
    XFARectangle parentBoundingBox)
  {
    XFARectangle xfaRectangle1 = (XFARectangle) null;
    float? nullable1 = new float?();
    if (parentBoundingBox != null)
    {
      xfaRectangle1 = (XFARectangle) parentBoundingBox.Clone();
      this.ApplyTransformationToRectangle(xfaRectangle1, true);
      float? ury = xfaRectangle1.Ury;
      float? height = xfaRectangle1.Height;
      nullable1 = ury.HasValue & height.HasValue ? new float?(ury.GetValueOrDefault() - height.GetValueOrDefault()) : new float?();
      this.ApplyMargins(xfaRectangle1);
      if (this.SimulatePosition(xfaRectangle1).GetState() == PositionResult.State.NO_CONTENT)
        return PositionResult.State.NO_CONTENT;
    }
    this.DrawBorder(canvas, parentBoundingBox);
    this.SavePosState(canvas);
    if (this.captionElement != null)
      this.captionElement.Draw(canvas, (XFARectangle) null);
    this.captionElement = (CaptionElement) null;
    XFARectangle xfaRectangle2 = (XFARectangle) null;
    this.positionState = PositionResult.State.FULL_CONTENT;
    if (this.uiElement != null)
    {
      if (canvas.IsTagged() && this.uiElement is CheckButtonElement)
      {
        int currentPageNumber1 = canvas.PdfWriter.CurrentPageNumber;
        int? currentPageNumber2 = this.flattenerContext.CurrentPageNumber;
        if ((currentPageNumber1 != currentPageNumber2.GetValueOrDefault() ? 0 : (currentPageNumber2.HasValue ? 1 : 0)) != 0)
        {
          this.positionState = ((CheckButtonElement) this.uiElement).DrawAsField(canvas, (XFARectangle) null, this.captionElement == null || this.captionElement.CaptionText == null ? this.RetrieveName() : this.captionElement.CaptionText, new Regex("xfa\\[0\\]\\.form\\[0\\]\\.").Replace((string) this.SomExpression, "", 1));
          goto label_10;
        }
      }
      this.positionState = this.uiElement.Draw(canvas, xfaRectangle1);
label_10:
      xfaRectangle2 = this.uiElement.GetElementRec();
    }
    else if (this.contentElement != null)
    {
      this.positionState = this.contentElement.Draw(canvas, xfaRectangle1);
      xfaRectangle2 = this.contentElement.GetElementRec();
    }
    this.RestorePosState(canvas);
    if (xfaRectangle2 != null && xfaRectangle1 != null && (this.positionState == PositionResult.State.CONTENT_PART || this.positionState == PositionResult.State.FULL_CONTENT))
    {
      if (this.positionState == PositionResult.State.FULL_CONTENT)
      {
        float num1 = xfaRectangle2.Ury.Value;
        xfaRectangle2.Ury = nullable1;
        XFARectangle xfaRectangle3 = xfaRectangle2;
        float? height = xfaRectangle2.Height;
        float num2 = num1;
        float? ury = xfaRectangle2.Ury;
        float? nullable2 = ury.HasValue ? new float?(num2 - ury.GetValueOrDefault()) : new float?();
        float? nullable3 = height.HasValue & nullable2.HasValue ? new float?(height.GetValueOrDefault() - nullable2.GetValueOrDefault()) : new float?();
        xfaRectangle3.Height = nullable3;
      }
      this.AdjustContentArea();
    }
    this.UpdatePageNumbers();
    return this.positionState;
  }

  protected virtual PositionResult SimulatePosition(XFARectangle childBoundingBox)
  {
    PositionResult positionResult = new PositionResult(PositionResult.State.FULL_CONTENT);
    try
    {
      if (this.captionElement != null)
        positionResult = this.captionElement.SimulatePosition(childBoundingBox);
      if (positionResult.GetState() == PositionResult.State.FULL_CONTENT)
      {
        if (this.uiElement != null)
          positionResult = this.uiElement.SimulatePosition(childBoundingBox);
        else if (this.contentElement != null)
          positionResult = this.contentElement.SimulatePosition(childBoundingBox);
        if (positionResult.GetState() == PositionResult.State.CONTENT_PART)
        {
          if (positionResult.Rectangle != null)
          {
            if (XFAUtil.Lt(childBoundingBox.Ury.Value - childBoundingBox.Height.Value - positionResult.Rectangle.Ury.Value + positionResult.Rectangle.Height.Value, positionResult.CurrentLeading))
            {
              XFARectangle xfaRectangle = childBoundingBox;
              float? height = childBoundingBox.Height;
              float currentLeading = positionResult.CurrentLeading;
              float? nullable = height.HasValue ? new float?(height.GetValueOrDefault() - currentLeading) : new float?();
              xfaRectangle.Height = nullable;
            }
            if (XFAUtil.Lte(positionResult.Rectangle.Ury.Value, childBoundingBox.Ury.Value - childBoundingBox.Height.Value))
              positionResult.SetState(PositionResult.State.NO_CONTENT);
          }
        }
        else if (positionResult.GetState() == PositionResult.State.FULL_CONTENT)
        {
          if (XFAUtil.Gt(childBoundingBox.Ury.Value - childBoundingBox.Height.Value, positionResult.Rectangle.Ury.Value - positionResult.Rectangle.Height.Value))
          {
            if (XFAUtil.Lt(childBoundingBox.Ury.Value - childBoundingBox.Height.Value - positionResult.Rectangle.Ury.Value + positionResult.Rectangle.Height.Value, positionResult.CurrentLeading))
            {
              if (XFAUtil.Lte(positionResult.Rectangle.Height.Value, 2f * positionResult.CurrentLeading))
                positionResult.SetState(PositionResult.State.NO_CONTENT);
            }
          }
        }
      }
      else
        positionResult.SetState(PositionResult.State.NO_CONTENT);
    }
    catch (Exception ex)
    {
    }
    return positionResult;
  }

  public virtual CaptionElement GetCaption() => this.captionElement;

  protected virtual XFARectangle GetContentRect()
  {
    if (this.uiElement != null)
      return this.uiElement.GetElementRec();
    if (this.uiElements != null)
    {
      List<XFARectangle> rectangles = new List<XFARectangle>();
      foreach (UiElement uiElement in this.uiElements)
        rectangles.Add(uiElement.GetElementRec());
      return XFARectangle.GetCommonRectangle((IList<XFARectangle>) rectangles);
    }
    return this.contentElement != null ? this.contentElement.GetElementRec() : (XFARectangle) null;
  }

  public virtual XFARectangle GetElementArea(XFARectangle originalRec)
  {
    XFARectangle elementArea = (XFARectangle) originalRec.Clone();
    if (this.captionElement != null)
    {
      if (Util.EqualsIgnoreCase("left", this.captionElement.GetPlacement()) || Util.EqualsIgnoreCase("right", this.captionElement.GetPlacement()))
      {
        if (Util.EqualsIgnoreCase("left", this.captionElement.GetPlacement()))
        {
          XFARectangle xfaRectangle = elementArea;
          float? llx = elementArea.Llx;
          float? width = this.captionElement.GetElementRec().Width;
          float? nullable = llx.HasValue & width.HasValue ? new float?(llx.GetValueOrDefault() + width.GetValueOrDefault()) : new float?();
          xfaRectangle.Llx = nullable;
        }
        if (elementArea.Width.HasValue)
        {
          XFARectangle xfaRectangle = elementArea;
          float? width1 = elementArea.Width;
          float? width2 = this.captionElement.GetElementRec().Width;
          float? nullable = width1.HasValue & width2.HasValue ? new float?(width1.GetValueOrDefault() - width2.GetValueOrDefault()) : new float?();
          xfaRectangle.Width = nullable;
        }
        if (elementArea.MinW.HasValue)
        {
          XFARectangle xfaRectangle = elementArea;
          float? minW = elementArea.MinW;
          float? width = this.captionElement.GetElementRec().Width;
          float? nullable = minW.HasValue & width.HasValue ? new float?(minW.GetValueOrDefault() - width.GetValueOrDefault()) : new float?();
          xfaRectangle.MinW = nullable;
        }
        if (elementArea.MaxW.HasValue)
        {
          XFARectangle xfaRectangle = elementArea;
          float? maxW = elementArea.MaxW;
          float? width = this.captionElement.GetElementRec().Width;
          float? nullable = maxW.HasValue & width.HasValue ? new float?(maxW.GetValueOrDefault() - width.GetValueOrDefault()) : new float?();
          xfaRectangle.MaxW = nullable;
        }
      }
      else if (Util.EqualsIgnoreCase("top", this.captionElement.GetPlacement()) || Util.EqualsIgnoreCase("bottom", this.captionElement.GetPlacement()))
      {
        if (Util.EqualsIgnoreCase("top", this.captionElement.GetPlacement()))
        {
          XFARectangle xfaRectangle = elementArea;
          float? ury = elementArea.Ury;
          float? height = this.captionElement.GetElementRec().Height;
          float? nullable = ury.HasValue & height.HasValue ? new float?(ury.GetValueOrDefault() - height.GetValueOrDefault()) : new float?();
          xfaRectangle.Ury = nullable;
        }
        if (elementArea.Height.HasValue)
        {
          XFARectangle xfaRectangle = elementArea;
          float? height1 = elementArea.Height;
          float? height2 = this.captionElement.GetElementRec().Height;
          float? nullable = height1.HasValue & height2.HasValue ? new float?(height1.GetValueOrDefault() - height2.GetValueOrDefault()) : new float?();
          xfaRectangle.Height = nullable;
        }
        if (elementArea.MinH.HasValue)
        {
          XFARectangle xfaRectangle = elementArea;
          float? minH = elementArea.MinH;
          float? height = this.captionElement.GetElementRec().Height;
          float? nullable = minH.HasValue & height.HasValue ? new float?(minH.GetValueOrDefault() - height.GetValueOrDefault()) : new float?();
          xfaRectangle.MinH = nullable;
        }
        if (elementArea.MaxH.HasValue)
        {
          XFARectangle xfaRectangle = elementArea;
          float? maxH = elementArea.MaxH;
          float? height = this.captionElement.GetElementRec().Height;
          float? nullable = maxH.HasValue & height.HasValue ? new float?(maxH.GetValueOrDefault() - height.GetValueOrDefault()) : new float?();
          xfaRectangle.MaxH = nullable;
        }
      }
    }
    return elementArea;
  }

  protected virtual void CreateContentElement()
  {
    IFormNode uiElement = this.GetUiElement(this.RetrieveChild("ui"));
    if (uiElement != null)
    {
      string str1 = uiElement.RetrieveName();
      if (str1.Equals("textEdit", StringComparison.InvariantCultureIgnoreCase) || str1.Equals("numericEdit", StringComparison.InvariantCultureIgnoreCase) || str1.Equals("dateTimeEdit", StringComparison.InvariantCultureIgnoreCase))
      {
        if (this is FieldPositioner)
        {
          IFormNode formNode = uiElement.RetrieveChild("comb");
          if (formNode != null)
          {
            string s = formNode.RetrieveAttribute("numberOfCells");
            if (s != null && s.Length > 0)
            {
              int numberOfCells = int.Parse(s);
              object formattedValue = this.GetFormattedValue();
              string str2 = formattedValue is string ? (string) formattedValue : "";
              XFARectangle xfaRectangle1 = this.GetElementArea(this.contentArea);
              this.uiElements = new List<UiElement>();
              this.uiElements.Add((UiElement) new CombElement(uiElement, (XFARectangle) xfaRectangle1.Clone(), this.document, numberOfCells));
              if (xfaRectangle1.Width.HasValue)
              {
                XFARectangle xfaRectangle2 = xfaRectangle1;
                float? width = xfaRectangle1.Width;
                float num = (float) numberOfCells;
                float? nullable = width.HasValue ? new float?(width.GetValueOrDefault() / num) : new float?();
                xfaRectangle2.Width = nullable;
              }
              int num1 = 0;
              int length = str2.Length;
              if (length < numberOfCells)
              {
                Tag child = this.template.GetChild("para", "", false);
                if (child != null)
                {
                  IDictionary<string, string> attributes = child.Attributes;
                  if (attributes != null)
                  {
                    string str3 = (string) null;
                    attributes.TryGetValue("hAlign", out str3);
                    if ("center".Equals(str3))
                      num1 = (numberOfCells - length) / 2;
                    else if ("right".Equals(str3) || "justify".Equals(str3) || "justifyAll".Equals(str3))
                      num1 = numberOfCells - length;
                  }
                }
              }
              for (int index = 0; index < numberOfCells; ++index)
              {
                TextElement textElement = (TextElement) null;
                if (index >= num1 && length > index - num1)
                {
                  Paragraph paragraph = new Paragraph(str2.Substring(index - num1, 1));
                  List<IElement> richText = new List<IElement>();
                  richText.Add((IElement) paragraph);
                  paragraph.Alignment = 1;
                  textElement = new TextElement((IFormNode) this.template, (JsNode) this, xfaRectangle1, this.document, (IList<IElement>) richText, this.flattenerContext);
                  textElement.CreateColumnText(xfaRectangle1);
                }
                if (textElement != null)
                  this.uiElements.Add((UiElement) new TextEditElement(uiElement, xfaRectangle1, this.document, (ContentElement) textElement)
                  {
                    BorderDrawn = false
                  });
                xfaRectangle1 = (XFARectangle) xfaRectangle1.Clone();
                float num2 = xfaRectangle1.Width.HasValue ? xfaRectangle1.Width.Value : 0.0f;
                XFARectangle xfaRectangle3 = xfaRectangle1;
                float? llx = xfaRectangle1.Llx;
                float num3 = num2;
                float? nullable = llx.HasValue ? new float?(llx.GetValueOrDefault() + num3) : new float?();
                xfaRectangle3.Llx = nullable;
              }
            }
          }
        }
        if (this.uiElements == null)
          this.uiElement = (UiElement) new TextEditElement(uiElement, this.GetElementArea(this.contentArea), this.document, (ContentElement) this.CreateTextContentElement(), this.GetIndependentRotation());
      }
      else if (str1.Equals("passwordEdit", StringComparison.InvariantCultureIgnoreCase))
        this.uiElement = (UiElement) new TextEditElement(uiElement, this.GetElementArea(this.contentArea), this.document, (ContentElement) this.CreateTextContentElement());
      else if (str1.Equals("imageEdit", StringComparison.InvariantCultureIgnoreCase))
      {
        IFormNode formNode = this.RetrieveChild("value");
        IFormNode elementTag = (IFormNode) null;
        IList<IFormNode> formNodeList;
        if (formNode != null && (formNodeList = formNode.RetrieveChildren()) != null && formNodeList.Count > 0)
        {
          elementTag = formNodeList[0];
          if (!Util.EqualsIgnoreCase(elementTag.RetrieveName(), "image"))
            elementTag = (IFormNode) null;
        }
        ImageElement imageElement = elementTag == null ? this.CreateImageContentElement(uiElement) : this.CreateImageContentElement(elementTag);
        this.AdjustContentAreaIfImageElementSizeCalculated(imageElement);
        this.uiElement = (UiElement) new ImageEditElement(uiElement, this.GetElementArea(this.contentArea), this.document, (ContentElement) imageElement);
      }
      else if (str1.Equals("checkButton", StringComparison.InvariantCultureIgnoreCase))
      {
        string hAlign = this.captionElement != null ? (string) null : "right";
        this.uiElement = (UiElement) new CheckButtonElement(uiElement, this.GetElementArea(this.contentArea), this.document, (ContentElement) this.CreateTextContentElement(), hAlign, this.captionElement);
      }
      else if (str1.Equals("choiceList", StringComparison.InvariantCultureIgnoreCase))
      {
        this.uiElement = (UiElement) new ChoiceListElement(uiElement, this.GetElementArea(this.contentArea), this.document);
        XFARectangle xfaRectangle = (XFARectangle) this.uiElement.GetElementRec().Clone();
        this.uiElement.ApplyMargins(xfaRectangle);
        ((ChoiceListElement) this.uiElement).SetContentElement((ContentElement) this.CreateChoiceListTextContentElement(uiElement, xfaRectangle));
      }
      else if (str1.Equals("button", StringComparison.InvariantCultureIgnoreCase))
        this.uiElement = (UiElement) new ButtonElement(uiElement, this.GetElementArea(this.contentArea), this.document, (ContentElement) this.CreateTextContentElement());
      else if (str1.Equals("signature", StringComparison.InvariantCultureIgnoreCase))
        this.uiElement = (UiElement) new SignatureElement(uiElement, this.GetElementArea(this.contentArea), this.document, (ContentElement) this.CreateTextContentElement(), this.flattenerContext);
      else if (str1.Equals("barcode", StringComparison.InvariantCultureIgnoreCase))
        this.uiElement = (UiElement) new BarcodeElement(uiElement, (XFARectangle) this.contentArea.Clone(), this.document, (ContentElement) this.CreateTextContentElement());
    }
    int? independentRotation = this.GetIndependentRotation();
    if (this.uiElement != null && independentRotation.HasValue)
      this.uiElement.IndependentRotateAngle = independentRotation;
    if (this.uiElement != null || this.uiElements != null || this.contentElement != null)
      return;
    IFormNode formNode1 = this.RetrieveChild("value");
    IList<IFormNode> formNodeList1;
    if (formNode1 != null && (formNodeList1 = formNode1.RetrieveChildren()) != null && formNodeList1.Count > 0)
    {
      IFormNode elementTag = formNodeList1[0];
      string str = elementTag.RetrieveName();
      if (Util.EqualsIgnoreCase(str, "rectangle"))
        this.contentElement = (ContentElement) new RectangleElement(elementTag, this.GetElementArea(this.contentArea), this.document);
      else if (Util.EqualsIgnoreCase(str, "line"))
        this.contentElement = (ContentElement) new LineElement(elementTag, this.GetElementArea(this.contentArea), this.document);
      else if (Util.EqualsIgnoreCase(str, "image"))
        this.contentElement = (ContentElement) this.CreateImageContentElement(elementTag);
      if (Util.EqualsIgnoreCase(str, "arc"))
        this.contentElement = (ContentElement) new ArcElement(elementTag, this.GetElementArea(this.contentArea), this.document);
    }
    if (this.contentElement != null)
      return;
    this.contentElement = (ContentElement) this.CreateTextContentElement();
    if (this.contentElement == null)
      return;
    ((TextElement) this.contentElement).CreateColumnText(this.GetTextArea());
  }

  private IFormNode GetUiElement(IFormNode uiParent)
  {
    IFormNode uiElement = (IFormNode) null;
    IList<IFormNode> formNodeList;
    if (uiParent != null && (formNodeList = uiParent.RetrieveChildren()) != null && formNodeList.Count > 0)
    {
      foreach (IFormNode formNode in (IEnumerable<IFormNode>) formNodeList)
      {
        if (ContentPositioner.ALLOWED_UI_ELEMENTS.Contains(formNode.RetrieveName()))
        {
          uiElement = formNode;
          break;
        }
      }
    }
    return uiElement;
  }

  protected virtual void CreateCaptionElement()
  {
    JsNode child = this.GetChild("caption");
    if (!(child is CaptionElement))
      return;
    this.captionElement = (CaptionElement) child;
    this.captionElement.Place(this.contentArea, this.flattenerContext);
  }

  protected virtual TextElement CreateTextContentElement()
  {
    object formattedValue = this.GetFormattedValue();
    TextElement textContentElement = (TextElement) null;
    switch (formattedValue)
    {
      case string _ when ((string) formattedValue).Length != 0:
        textContentElement = new TextElement((IFormNode) this.template, (JsNode) this, this.GetElementArea(this.contentArea), this.document, (string) formattedValue, this.flattenerContext);
        break;
      case IList _:
        textContentElement = new TextElement((IFormNode) this.template, (JsNode) this, this.GetElementArea(this.contentArea), this.document, (IList<IElement>) formattedValue, this.flattenerContext);
        break;
      case JintJsNodeList _:
        List<IElement> richText = new List<IElement>();
        for (int i = 0; i < ((JsDictionaryObject) formattedValue).Length; ++i)
        {
          object obj = ((JintJsNodeList) formattedValue).GetItem(i);
          if (obj is IElement)
            richText.Add((IElement) obj);
        }
        textContentElement = new TextElement((IFormNode) this.template, (JsNode) this, this.GetElementArea(this.contentArea), this.document, (IList<IElement>) richText, this.flattenerContext);
        break;
    }
    if (textContentElement != null && this.role != null && Regex.IsMatch(this.role.ToString(), "^/H[1-6]$"))
    {
      IList<IElement> content = textContentElement.Content;
      if (content.Count > 0 && content[0] is IAccessibleElement)
      {
        ((IAccessibleElement) content[0]).Role = this.role;
        this.role = PdfName.DIV;
      }
    }
    return textContentElement;
  }

  protected virtual TextElement CreateChoiceListTextContentElement(
    IFormNode uiElementTag,
    XFARectangle textElementRect)
  {
    object formattedValue = this.GetFormattedValue();
    if (!(formattedValue is string) || ((string) formattedValue).Length == 0 || this.template == null)
      return this.CreateTextContentElement();
    string plainText = (string) formattedValue;
    return new TextElement((IFormNode) this.template, (JsNode) this, this.GetElementArea(this.contentArea), this.document, plainText, this.flattenerContext);
  }

  protected virtual ImageElement CreateImageContentElement(IFormNode elementTag)
  {
    object rawValue = this.GetRawValue();
    Image img = (Image) null;
    if (rawValue is string)
    {
      string str1 = (string) rawValue;
      if (str1 != null)
      {
        string str2 = "base64";
        string str3 = elementTag.RetrieveAttribute("transferEncoding");
        if (str3 != null)
          str2 = str3;
        try
        {
          if (Util.EqualsIgnoreCase(str2, "base64"))
          {
            byte[] numArray;
            try
            {
              numArray = Convert.FromBase64String(str1);
            }
            catch (Exception ex)
            {
              string s = Regex.Replace(str1, "[\t\n\r ]", "").TrimEnd('=');
              while (s.Length % 4 >= 2)
                s += "=";
              numArray = Convert.FromBase64String(s);
            }
            if (numArray != null)
            {
              if (numArray.Length > 0)
                img = Image.GetInstance(numArray);
            }
          }
          else
            img = Image.GetInstance(Encoding.Default.GetBytes(str1));
        }
        catch (IOException ex)
        {
        }
        catch (BadElementException ex)
        {
        }
        catch (FormatException ex)
        {
        }
      }
    }
    if (img != null)
    {
      string str = this.GetAlternateText();
      if ((str == null || str.Length == 0) && (str == null || str.Length == 0))
        str = "image";
      img.SetAccessibleAttribute(PdfName.ALT, (PdfObject) new PdfString(str));
    }
    return new ImageElement(elementTag, this.GetElementArea(this.contentArea), this.document, img);
  }

  protected virtual void AdjustContentAreaIfImageElementSizeCalculated(ImageElement imageElement)
  {
    if (!this.contentArea.Height.HasValue && imageElement.GetElementRec().Height.HasValue)
      this.contentArea.Height = imageElement.GetElementRec().Height;
    if (this.contentArea.Width.HasValue || !imageElement.GetElementRec().Width.HasValue)
      return;
    this.contentArea.Width = imageElement.GetElementRec().Width;
  }

  public virtual void InitValues()
  {
    object rawValue = (object) null;
    IFormNode formNode1 = this.RetrieveChild("value");
    if (formNode1 != null)
    {
      IFormNode formNode2;
      if ((formNode2 = formNode1.RetrieveChild("exData")) != null)
      {
        if ("text/html".Equals(formNode2.RetrieveAttribute("contentType")))
          rawValue = (object) formNode2.RetrieveRichText();
      }
      else
      {
        IFormNode formNode3;
        if ((formNode3 = formNode1.RetrieveChild("image")) != null)
        {
          string imgRef = formNode3.RetrieveAttribute("href");
          if (imgRef != null)
          {
            PdfObject pdfObject = PdfReader.GetPdfObject(this.flattenerContext.GetImage(imgRef));
            if (pdfObject is PRStream)
            {
              try
              {
                rawValue = (object) Convert.ToBase64String(PdfReader.GetStreamBytes((PRStream) pdfObject));
              }
              catch (Exception ex)
              {
              }
            }
          }
        }
      }
      if (rawValue == null && formNode1.RetrieveChildren().Count != 0)
      {
        IFormNode retrieveChild = formNode1.RetrieveChildren()[0];
        if (retrieveChild != null)
        {
          IList<string> stringList = retrieveChild.RetrieveContent();
          if (stringList != null && stringList.Count > 0)
            rawValue = (object) stringList[0];
        }
      }
    }
    this.SetRawValue(rawValue);
  }

  public override void AdjustContentAreaHeight(float newHeight)
  {
    base.AdjustContentAreaHeight(newHeight);
    this.captionElement = (CaptionElement) null;
    this.contentElement = (ContentElement) null;
    this.uiElement = (UiElement) null;
    this.uiElements = (List<UiElement>) null;
    this.transformation = new AffineTransform();
    this.InitLayout();
    this.AdjustLayout();
  }

  public override void Relayout(bool forceLayout)
  {
    if (!this.layoutOutOfDate && !forceLayout)
      return;
    this.InitContentArea(new float?(), new float?());
    this.ApplyMargins(this.contentArea);
    this.captionElement = (CaptionElement) null;
    this.contentElement = (ContentElement) null;
    this.uiElement = (UiElement) null;
    this.uiElements = (List<UiElement>) null;
    this.transformation = new AffineTransform();
    this.InitLayout();
    this.AdjustLayout();
    this.layoutOutOfDate = false;
  }

  protected override void Move(float dx, float dy)
  {
    base.Move(dx, dy);
    if (this.uiElement != null)
      this.uiElement.Move(dx, dy);
    if (this.uiElements != null)
    {
      foreach (Element uiElement in this.uiElements)
        uiElement.Move(dx, dy);
    }
    if (this.contentElement != null)
      this.contentElement.Move(dx, dy);
    if (this.captionElement == null)
      return;
    this.captionElement.Move(dx, dy);
  }

  protected internal override void AdjustContentAreaUry(float ury)
  {
    XFARectangle xfaRectangle = (XFARectangle) null;
    if (this.uiElement != null)
      xfaRectangle = this.uiElement.GetElementRec();
    else if (this.contentElement != null)
      xfaRectangle = this.contentElement.GetElementRec();
    if (xfaRectangle != null)
    {
      float num1 = xfaRectangle.Height.Value;
      float num2 = xfaRectangle.Ury.Value;
      xfaRectangle.Ury = new float?(ury);
      xfaRectangle.Height = new float?(num1 - (num2 - ury));
    }
    this.AdjustContentArea();
  }

  protected override bool IsPositionedPartially()
  {
    return this.positionState == PositionResult.State.CONTENT_PART || this.positionState == PositionResult.State.FULL_CONTENT;
  }

  public override object GetFormattedValue()
  {
    object data = this.GetRawValue();
    switch (data)
    {
      case IList _:
      case JintJsNodeList _:
        return data;
      default:
        FormatResolver.FormatType? type = new FormatResolver.FormatType?();
        Tag child = this.template.GetChild("value", "", false);
        Tag tag = (Tag) null;
        if (child != null && child.Children != null && child.Children.Count > 0)
        {
          tag = child.Children[0];
          string name = tag.Name;
          if (Util.EqualsIgnoreCase(name, "float"))
            type = new FormatResolver.FormatType?(FormatResolver.FormatType.FLOAT);
          else if (Util.EqualsIgnoreCase(name, "integer"))
            type = new FormatResolver.FormatType?(FormatResolver.FormatType.INTEGER);
          else if (Util.EqualsIgnoreCase(name, "date"))
            type = new FormatResolver.FormatType?(FormatResolver.FormatType.DATE);
          else if (Util.EqualsIgnoreCase(name, "dateTime"))
            type = new FormatResolver.FormatType?(FormatResolver.FormatType.DATE_TIME);
          else if (Util.EqualsIgnoreCase(name, "time"))
            type = new FormatResolver.FormatType?(FormatResolver.FormatType.TIME);
          else if (name.Equals("text") && data is string)
          {
            string str = (string) data;
            IDictionary<string, string> attributes = child.Children[0].Attributes;
            if (attributes != null)
            {
              string s;
              attributes.TryGetValue("maxChars", out s);
              if (s != null)
              {
                int length = Math.Min(int.Parse(s), str.Length);
                data = (object) str.Substring(0, length);
              }
            }
          }
        }
        IFormNode formNode1 = this.RetrieveChild("ui");
        if (formNode1 != null && formNode1.RetrieveChildren() != null && formNode1.RetrieveChildren().Count > 0)
        {
          string str = formNode1.RetrieveChildren()[0].RetrieveName();
          if (Util.EqualsIgnoreCase(str, "numericEdit"))
            type = new FormatResolver.FormatType?(FormatResolver.FormatType.FLOAT);
          else if (Util.EqualsIgnoreCase(str, "dateTimeEdit"))
          {
            type = new FormatResolver.FormatType?(FormatResolver.FormatType.DATE_TIME);
            IFormNode formNode2 = this.RetrieveChild("value");
            if (formNode2 != null)
            {
              if (formNode2.RetrieveChild("date") != null)
                type = new FormatResolver.FormatType?(FormatResolver.FormatType.DATE);
              else if (formNode2.RetrieveChild("time") != null)
                type = new FormatResolver.FormatType?(FormatResolver.FormatType.TIME);
            }
          }
        }
        string pattern = (string) null;
        IFormNode formNode3;
        IFormNode formNode4;
        if ((formNode3 = this.RetrieveChild("format")) != null && (formNode4 = formNode3.RetrieveChild("picture")) != null)
        {
          IList<string> stringList = formNode4.RetrieveContent();
          if (stringList != null && stringList.Count > 0)
            pattern = stringList[0];
        }
        string str1;
        if (data != null || pattern != null)
        {
          string defaultAcrobatLocale;
          this.template.Attributes.TryGetValue("locale", out defaultAcrobatLocale);
          ConfigResolver configResolver = this.flattenerContext.ConfigResolver;
          if (configResolver != null && configResolver.GetDefaultAcrobatLocale() != null)
            defaultAcrobatLocale = configResolver.GetDefaultAcrobatLocale();
          Dictionary<string, string> attributes = (Dictionary<string, string>) null;
          if (tag != null && tag.Attributes != null && tag.Attributes.Count > 0)
          {
            attributes = new Dictionary<string, string>(tag.Attributes);
            if (attributes.ContainsKey("fracDigits") && "-1".Equals(attributes["fracDigits"]) && this.originalNumberOfFractionalDigitsInRawValue.HasValue)
            {
              if (attributes.ContainsKey("fracDigits"))
                attributes["fracDigits"] = this.originalNumberOfFractionalDigitsInRawValue.ToString();
              else
                attributes.Add("fracDigits", this.originalNumberOfFractionalDigitsInRawValue.ToString());
            }
          }
          str1 = this.flattenerContext.FormatResolver.Resolve(data, pattern, this.inputParsingPattern, type, defaultAcrobatLocale, attributes);
        }
        else
          str1 = (string) null;
        return (object) str1 ?? (object) "";
    }
  }

  public override object ExecCalculate()
  {
    object rawValue = base.ExecCalculate();
    if (rawValue != null)
      this.SetRawValue(rawValue);
    return this.GetRawValue();
  }

  protected override string GetCaptionText()
  {
    return this.captionElement == null ? "" : this.captionElement.CaptionText;
  }
}
