// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.positioner.Positioner
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.awt.geom;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.interfaces;
using iTextSharp.tool.xml.css;
using iTextSharp.tool.xml.xtra.xfa.element;
using iTextSharp.tool.xml.xtra.xfa.js;
using iTextSharp.tool.xml.xtra.xfa.resolver;
using iTextSharp.tool.xml.xtra.xfa.tags;
using iTextSharp.tool.xml.xtra.xfa.util;
using Jint.Native;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.util;
using System.util.collections;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.positioner;

public abstract class Positioner : JsContainer, IAccessibleElement
{
  protected XFATemplateTag template;
  protected DataTag data;
  public XFARectangle contentArea;
  protected Positioner parent;
  protected internal List<Positioner> childElements = new List<Positioner>();
  protected BreakConditions breakConditions;
  protected KeepConditions keepConditions;
  protected OverflowConditions overflowConditions;
  protected AffineTransform transformation = new AffineTransform();
  internal PdfName role;
  protected AccessibleElementId id;
  protected Dictionary<PdfName, PdfObject> accessibleAttributes;
  internal PdfContentByte canvas;
  protected bool isEmpty = true;
  protected bool isContentTagged;
  protected bool isTagged;
  protected int? startPageNumber = new int?();
  protected int? startSheetNumber = new int?();
  protected int? startAbsPageNumber = new int?();
  protected int? endPageNumber = new int?();
  protected int? endAbsPageNumber = new int?();
  protected IFormNode assistTag;
  protected bool layoutOutOfDate;
  protected HashSet2<Tag> overflowedContentAreas;
  protected Dictionary<string, Positioner> immediateChildren = new Dictionary<string, Positioner>();
  protected internal PositionResult.State positionState;
  public bool buildNextInstance;

  internal Positioner(string className, JsNode prototype = null)
    : base(className, prototype)
  {
  }

  public Positioner(
    XFATemplateTag templateTag,
    DataTag dataTag,
    FlattenerContext flattenerContext,
    JsNode parentNode,
    string prototypeName = null)
    : base(templateTag, parentNode, prototypeName)
  {
    this.template = templateTag;
    this.flattenerContext = flattenerContext;
    this.parent = parentNode is Positioner ? (Positioner) parentNode : (Positioner) null;
    this.data = dataTag;
    this.protoTemplate = JsNode.UNIVERSAL_PROTOTYPE_ROOT.GetChild(templateTag.Name, "");
    if (this.parent != null)
    {
      this.startPageNumber = this.parent.StartPageNumber;
      this.startSheetNumber = this.parent.StartSheetNumber;
      this.startAbsPageNumber = this.parent.startAbsPageNumber;
    }
    Tag child = this.template.GetChild("keep", "");
    if (child == null)
      return;
    this.keepConditions = new KeepConditions(child);
  }

  public virtual int? GetIndependentRotation()
  {
    int? independentRotation = new int?();
    string s;
    if (this.parent != null && LayoutManager.rowLayout.Equals(this.parent.GetLayout()) && (s = this.RetrieveAttribute("rotate")) != null)
      independentRotation = new int?(int.Parse(s));
    return independentRotation;
  }

  public virtual void Place(float? x, float? y)
  {
    if (this.parent != null)
    {
      Tag tag = (Tag) null;
      string layout = this.parent.GetLayout();
      if (LayoutManager.tbLayout.Equals(layout) || LayoutManager.tblrLayout.Equals(layout))
        tag = this.template.GetChild("overflow", "") ?? this.template.GetChild("break", "");
      if (tag != null || this.parent.OverflowConditions != null)
        this.overflowConditions = new OverflowConditions(tag, this.flattenerContext, this.parent.OverflowConditions, this);
    }
    this.InitContentArea(x, y);
    bool flag = false;
    TableLayoutManager tableLayoutManager = (TableLayoutManager) null;
    if (LayoutManager.tableLayout.Equals(this.GetLayout()))
    {
      tableLayoutManager = new TableLayoutManager(this);
      if (TableLayoutManager.IsDynamicTableLayout(this.RetrieveAttribute("columnWidths")))
        flag = true;
      else
        tableLayoutManager.PreprocessHorizontalCellLayout();
    }
    this.ApplyMargins(this.contentArea);
    this.InitLayout();
    if (flag)
    {
      tableLayoutManager.PreprocessHorizontalCellLayout();
      this.Relayout(true);
    }
    this.AdjustLayout();
    this.layoutOutOfDate = false;
  }

  public override void DefineOwnProperty(Descriptor currentDescriptor)
  {
    if (currentDescriptor is ValueDescriptor && currentDescriptor.Get((JsDictionaryObject) this) is JsString && this.immediateChildren != null && this.immediateChildren.ContainsKey(currentDescriptor.Name))
    {
      Positioner immediateChild = this.immediateChildren[currentDescriptor.Name];
      if (immediateChild is DrawPositioner && immediateChild.GetRawValue() is string && !immediateChild.GetRawValue().Equals(currentDescriptor.Get((JsDictionaryObject) this).Value))
        immediateChild.SetRawValue(currentDescriptor.Get((JsDictionaryObject) this).Value);
      immediateChild.DefineOwnProperty(currentDescriptor);
    }
    else
      base.DefineOwnProperty(currentDescriptor);
  }

  public override JsInstance this[string name]
  {
    set
    {
      switch (value)
      {
        case null:
        case JsString _:
          if (this.immediateChildren != null && this.immediateChildren.ContainsKey(name))
          {
            Positioner immediateChild = this.immediateChildren[name];
            if (immediateChild is DrawPositioner && immediateChild.GetRawValue() is string && (value == null || !immediateChild.GetRawValue().Equals(value.Value)))
              immediateChild.SetRawValue(value == null ? (object) null : value.Value);
            immediateChild[name] = value;
            return;
          }
          break;
      }
      base[name] = value;
    }
  }

  public virtual void Place() => this.Place(new float?(), new float?());

  public virtual void InitContentArea(float? parentLlx, float? parentUry)
  {
    float? llx1 = new float?(0.0f);
    if (!LayoutManager.rowLayout.Equals(this.GetLayout()))
    {
      llx1 = XFAUtil.ParsePxInCmMmPcToPt(this.RetrieveAttribute("x"));
      if (!llx1.HasValue)
        llx1 = new float?(0.0f);
    }
    float? ury1 = XFAUtil.ParsePxInCmMmPcToPt(this.RetrieveAttribute("y"));
    if (!ury1.HasValue)
      ury1 = new float?(0.0f);
    float? pxInCmMmPcToPt1 = XFAUtil.ParsePxInCmMmPcToPt(this.RetrieveAttribute("w"));
    float? h = XFAUtil.ParsePxInCmMmPcToPt(this.RetrieveAttribute("h"));
    string layout = this.GetLayout();
    if (LayoutManager.positionLayout.Equals(layout) && h.HasValue && this.parent == this.flattenerContext.DomPositioner)
    {
      float? nullable = h;
      float height = this.flattenerContext.Document.PageSize.Height;
      if (((double) nullable.GetValueOrDefault() <= (double) height ? 0 : (nullable.HasValue ? 1 : 0)) != 0)
        h = new float?();
    }
    this.contentArea = new XFARectangle(llx1, ury1, pxInCmMmPcToPt1, h);
    if (!pxInCmMmPcToPt1.HasValue)
    {
      this.InitMinWContentAreaProperty();
      this.contentArea.MaxW = XFAUtil.ParsePxInCmMmPcToPt(this.RetrieveAttribute("maxW"));
    }
    if (!h.HasValue)
    {
      this.contentArea.MinH = XFAUtil.ParsePxInCmMmPcToPt(this.RetrieveAttribute("minH"));
      this.contentArea.MaxH = XFAUtil.ParsePxInCmMmPcToPt(this.RetrieveAttribute("maxH"));
    }
    string str = (string) null;
    XFARectangle xfaRectangle = (XFARectangle) null;
    Positioner positioner = (Positioner) null;
    if (this.parent != null)
    {
      str = this.parent.GetLayout();
      positioner = this.parent.GetPreviousPositionerInLayout(this, layout);
      xfaRectangle = this.parent.GetContentArea();
      parentLlx = xfaRectangle.Llx;
      parentUry = xfaRectangle.Ury;
    }
    float? nullable1;
    if (LayoutManager.tbLayout.Equals(str))
    {
      if (positioner != null)
      {
        XFARectangle bbox = positioner.GetBBox();
        XFARectangle contentArea = this.contentArea;
        float? ury2 = bbox.Ury;
        float? height = bbox.Height;
        float? nullable2 = ury2.HasValue & height.HasValue ? new float?(ury2.GetValueOrDefault() - height.GetValueOrDefault()) : new float?();
        contentArea.Ury = nullable2;
      }
      else
        this.contentArea.Ury = xfaRectangle.Ury;
      this.contentArea.Llx = new float?(0.0f);
    }
    else if (LayoutManager.tableLayout.Equals(str) || LayoutManager.rowLayout.Equals(layout))
    {
      if (positioner != null)
      {
        XFARectangle bbox = positioner.GetBBox();
        XFARectangle contentArea = this.contentArea;
        float? ury3 = bbox.Ury;
        float? height = bbox.Height;
        float? nullable3 = ury3.HasValue & height.HasValue ? new float?(ury3.GetValueOrDefault() - height.GetValueOrDefault()) : new float?();
        contentArea.Ury = nullable3;
        this.contentArea.Llx = new float?(0.0f);
      }
      else
        this.contentArea.Ury = parentUry;
    }
    else if (LayoutManager.rowLayout.Equals(str))
    {
      this.contentArea.Ury = xfaRectangle.Ury;
      if (this is SubFormPositioner && this.childElements.Count > 1)
      {
        if (LayoutManager.tbLayout.Equals(layout))
        {
          float? pxInCmMmPcToPt2 = XFAUtil.ParsePxInCmMmPcToPt(this.template.RetrieveAttribute("w"));
          IFormNode formNode = (IFormNode) this.parent.parent ?? this.parent.template.RetrieveParent();
          if (formNode != null)
          {
            float? nthColumnWidth = TableLayoutManager.GetNthColumnWidth(formNode.RetrieveAttribute("columnWidths"), this.parent.childElements.IndexOf(this));
            if (!pxInCmMmPcToPt2.HasValue || nthColumnWidth.HasValue && (double) Math.Abs(pxInCmMmPcToPt2.Value - nthColumnWidth.Value) > 0.001)
            {
              int num1 = 0;
              int num2 = 0;
              foreach (Positioner childElement in this.childElements)
              {
                if (childElement.RetrieveAttribute("w") == null)
                  ++num1;
                else if ((double) Math.Abs(XFAUtil.ParsePxInCmMmPcToPt(childElement.RetrieveAttribute("w")).GetValueOrDefault() - TableLayoutManager.GetNthColumnWidth(formNode.RetrieveAttribute("columnWidths"), this.parent.childElements.IndexOf(this)).GetValueOrDefault()) > 0.0001)
                  ++num2;
              }
              if (num1 == this.childElements.Count || num2 != 0)
                this.contentArea.Height = new float?();
            }
          }
        }
        else if (!LayoutManager.positionLayout.Equals(layout))
          this.contentArea.Height = new float?();
      }
    }
    else if (Util.EqualsIgnoreCase(LayoutManager.tblrLayout, str))
    {
      if (positioner != null)
      {
        XFARectangle bbox1 = positioner.GetBBox();
        float? nullable4 = this.contentArea.Width;
        if (!nullable4.HasValue && this.RetrieveAttribute("columnWidths") != null)
        {
          List<float?> numArray = XFAUtil.ParseNumArray(this.RetrieveAttribute("columnWidths"));
          if (numArray != null)
          {
            foreach (float? nullable5 in numArray)
            {
              if (nullable5.HasValue)
              {
                if (!nullable4.HasValue)
                {
                  nullable4 = nullable5;
                }
                else
                {
                  float? nullable6 = nullable4;
                  float? nullable7 = nullable5;
                  nullable4 = nullable6.HasValue & nullable7.HasValue ? new float?(nullable6.GetValueOrDefault() + nullable7.GetValueOrDefault()) : new float?();
                }
              }
            }
          }
        }
        if (xfaRectangle.Width.HasValue && nullable4.HasValue)
        {
          float? llx2 = bbox1.Llx;
          float? width1 = bbox1.Width;
          float? nullable8 = llx2.HasValue & width1.HasValue ? new float?(llx2.GetValueOrDefault() + width1.GetValueOrDefault()) : new float?();
          float? nullable9 = nullable4;
          float? nullable10 = nullable8.HasValue & nullable9.HasValue ? new float?(nullable8.GetValueOrDefault() + nullable9.GetValueOrDefault()) : new float?();
          float? llx3 = xfaRectangle.Llx;
          float? nullable11 = nullable10.HasValue & llx3.HasValue ? new float?(nullable10.GetValueOrDefault() - llx3.GetValueOrDefault()) : new float?();
          float? width2 = xfaRectangle.Width;
          float? nullable12 = nullable11.HasValue & width2.HasValue ? new float?(nullable11.GetValueOrDefault() - width2.GetValueOrDefault()) : new float?();
          if (((double) nullable12.GetValueOrDefault() >= 0.01 ? 0 : (nullable12.HasValue ? 1 : 0)) == 0)
          {
            float? nullable13 = bbox1.Ury;
            double num3 = (double) nullable13.Value;
            nullable13 = bbox1.Height;
            double num4 = (double) nullable13.Value;
            float num5 = (float) (num3 - num4);
            for (int index = this.parent.Children.IndexOf(this) - 2; index >= 0; --index)
            {
              Positioner child = this.parent.Children[index];
              if (!child.IsHidden() && !child.IsInactive())
              {
                XFARectangle bbox2 = child.GetBBox();
                float num6 = bbox2.Ury.Value - bbox2.Height.Value;
                if ((double) num5 > (double) num6)
                  num5 = num6;
              }
            }
            this.contentArea.Ury = new float?(num5);
            this.contentArea.Llx = new float?(0.0f);
            goto label_68;
          }
        }
        this.contentArea.Ury = bbox1.Ury;
        XFARectangle contentArea = this.contentArea;
        float? llx4 = bbox1.Llx;
        nullable1 = bbox1.Width;
        float? nullable14 = llx4.HasValue & nullable1.HasValue ? new float?(llx4.GetValueOrDefault() + nullable1.GetValueOrDefault()) : new float?();
        nullable1 = parentLlx;
        float? nullable15 = nullable14.HasValue & nullable1.HasValue ? new float?(nullable14.GetValueOrDefault() - nullable1.GetValueOrDefault()) : new float?();
        contentArea.Llx = nullable15;
      }
      else
      {
        this.contentArea.Ury = xfaRectangle.Ury;
        this.contentArea.Llx = new float?(0.0f);
      }
    }
    else if (parentUry.HasValue)
    {
      float? ury4 = this.contentArea.Ury;
      if (ury4.HasValue)
      {
        XFARectangle contentArea = this.contentArea;
        float? nullable16 = parentUry;
        nullable1 = ury4;
        float? nullable17 = nullable16.HasValue & nullable1.HasValue ? new float?(nullable16.GetValueOrDefault() - nullable1.GetValueOrDefault()) : new float?();
        contentArea.Ury = nullable17;
      }
    }
label_68:
    if (!parentLlx.HasValue)
      return;
    float? llx5 = this.contentArea.Llx;
    if (!llx5.HasValue)
      return;
    XFARectangle contentArea1 = this.contentArea;
    float? nullable18 = parentLlx;
    nullable1 = llx5;
    float? nullable19 = nullable18.HasValue & nullable1.HasValue ? new float?(nullable18.GetValueOrDefault() + nullable1.GetValueOrDefault()) : new float?();
    contentArea1.Llx = nullable19;
  }

  protected virtual void InitMinWContentAreaProperty()
  {
    this.contentArea.MinW = XFAUtil.ParsePxInCmMmPcToPt(this.RetrieveAttribute("minW"));
  }

  protected virtual void Move(float dx, float dy)
  {
    foreach (Positioner childElement in this.childElements)
      childElement.Move(dx, dy);
    if (this.contentArea == null)
      return;
    XFARectangle contentArea1 = this.contentArea;
    float? llx = this.contentArea.Llx;
    float num1 = dx;
    float? nullable1 = llx.HasValue ? new float?(llx.GetValueOrDefault() + num1) : new float?();
    contentArea1.Llx = nullable1;
    XFARectangle contentArea2 = this.contentArea;
    float? ury = this.contentArea.Ury;
    float num2 = dy;
    float? nullable2 = ury.HasValue ? new float?(ury.GetValueOrDefault() + num2) : new float?();
    contentArea2.Ury = nullable2;
  }

  private IList<Positioner> GetChildPositionersInScriptExecutionOrder(string activity, string @ref)
  {
    return (IList<Positioner>) new List<Positioner>((IEnumerable<Positioner>) this.childElements);
  }

  private void CollectPositionersInStraightExecutionOrderRecursively(List<Positioner> executionOrder)
  {
    foreach (Positioner childElement in this.childElements)
      childElement.CollectPositionersInStraightExecutionOrderRecursively(executionOrder);
    executionOrder.Add(this);
  }

  public override void ExecEvent(string activity, string @ref)
  {
    Positioner currentNode1 = this.flattenerContext.CurrentNode;
    this.flattenerContext.CurrentNode = this;
    if ("ready".Equals(activity) && "$form".Equals(@ref))
    {
      List<Positioner> executionOrder = new List<Positioner>();
      this.CollectPositionersInStraightExecutionOrderRecursively(executionOrder);
      for (int index1 = 0; index1 < executionOrder.Count; ++index1)
      {
        if (executionOrder[index1].GetScriptsByActivity(activity, @ref) != null)
        {
          int index2 = index1 + 1;
          for (int index3 = executionOrder.Count - 1; index2 < index3; --index3)
          {
            Positioner positioner = executionOrder[index2];
            executionOrder[index2] = executionOrder[index3];
            executionOrder[index3] = positioner;
            ++index2;
          }
          break;
        }
      }
      foreach (Positioner positioner in executionOrder)
      {
        Positioner currentNode2 = this.flattenerContext.CurrentNode;
        this.flattenerContext.CurrentNode = positioner;
        positioner.ExecOwnEvent(activity, @ref);
        this.flattenerContext.CurrentNode = currentNode2;
      }
    }
    else
    {
      foreach (JsContainer jsContainer in (IEnumerable<Positioner>) this.GetChildPositionersInScriptExecutionOrder(activity, @ref))
        jsContainer.ExecEvent(activity, @ref);
      base.ExecEvent(activity, @ref);
    }
    this.flattenerContext.CurrentNode = currentNode1;
  }

  public override object ExecCalculate()
  {
    Positioner currentNode = this.flattenerContext.CurrentNode;
    this.flattenerContext.CurrentNode = this;
    foreach (JsContainer jsContainer in (IEnumerable<Positioner>) this.GetChildPositionersInScriptExecutionOrder((string) null, (string) null))
      jsContainer.ExecCalculate();
    object obj = base.ExecCalculate();
    this.flattenerContext.CurrentNode = currentNode;
    return obj;
  }

  public override void ExecValidate()
  {
    Positioner currentNode = this.flattenerContext.CurrentNode;
    this.flattenerContext.CurrentNode = this;
    foreach (JsContainer jsContainer in (IEnumerable<Positioner>) this.GetChildPositionersInScriptExecutionOrder((string) null, (string) null))
      jsContainer.ExecValidate();
    base.ExecValidate();
    this.flattenerContext.CurrentNode = currentNode;
  }

  public virtual FlattenerContext FlattenerContext => this.flattenerContext;

  public override IList<ScriptString> GetScriptsByActivity(string activity, string @ref)
  {
    List<ScriptString> scriptsByActivity = (List<ScriptString>) null;
    foreach (Tag child1 in (IEnumerable<Tag>) this.template.GetChildren("event"))
    {
      string str1 = (string) null;
      child1.Attributes.TryGetValue(nameof (activity), out str1);
      string str2 = (string) null;
      child1.Attributes.TryGetValue(nameof (@ref), out str2);
      if ((str1 == null || Util.EqualsIgnoreCase(str1, activity)) && (@ref == null || "undefined".Equals(@ref) || @ref.Equals(str2)))
      {
        foreach (Tag child2 in (IEnumerable<Tag>) child1.GetChildren("script"))
        {
          string type;
          child2.Attributes.TryGetValue("contentType", out type);
          string content1 = "";
          IList<string> content2 = ((XFATemplateTag) child2).Content;
          if (content2 != null)
          {
            foreach (string str3 in (IEnumerable<string>) content2)
              content1 += str3;
          }
          if (scriptsByActivity == null)
            scriptsByActivity = new List<ScriptString>();
          scriptsByActivity.Add(new ScriptString(content1, type));
        }
      }
    }
    return (IList<ScriptString>) scriptsByActivity;
  }

  protected override IList<ScriptString> GetCalculationScripts()
  {
    List<ScriptString> calculationScripts = (List<ScriptString>) null;
    Tag child1 = this.template.GetChild("calculate", "");
    if (child1 != null)
    {
      foreach (Tag child2 in (IEnumerable<Tag>) child1.GetChildren("script"))
      {
        string type = (string) null;
        child2.Attributes.TryGetValue("contentType", out type);
        string content1 = "";
        IList<string> content2 = ((XFATemplateTag) child2).Content;
        if (content2 != null)
        {
          foreach (string str in (IEnumerable<string>) content2)
            content1 += str;
        }
        if (calculationScripts == null)
          calculationScripts = new List<ScriptString>();
        calculationScripts.Add(new ScriptString(content1, type));
      }
    }
    return (IList<ScriptString>) calculationScripts;
  }

  protected override IList<ScriptString> GetValidateScripts()
  {
    List<ScriptString> validateScripts = (List<ScriptString>) null;
    Tag child1 = this.template.GetChild("validate", "");
    if (child1 != null)
    {
      foreach (Tag child2 in (IEnumerable<Tag>) child1.GetChildren("script"))
      {
        string type = (string) null;
        child2.Attributes.TryGetValue("contentType", out type);
        string content1 = "";
        IList<string> content2 = ((XFATemplateTag) child2).Content;
        if (content2 != null)
        {
          foreach (string str in (IEnumerable<string>) content2)
            content1 += str;
        }
        if (validateScripts == null)
          validateScripts = new List<ScriptString>();
        validateScripts.Add(new ScriptString(content1, type));
      }
    }
    return (IList<ScriptString>) validateScripts;
  }

  protected virtual void InitLayout()
  {
    this.assistTag = this.RetrieveChild("assist");
    if (this.assistTag != null)
    {
      string str = (string) null;
      this.assistTag.RetrieveAttributes().TryGetValue("role", out str);
      if (str != null)
      {
        PdfName role = this.parent != null ? this.parent.role : (PdfName) null;
        switch (str)
        {
          case "Table":
            this.role = PdfName.TABLE;
            break;
          case "TR":
            if (PdfName.TABLE.Equals((object) role))
            {
              this.role = PdfName.TR;
              break;
            }
            break;
          case "TF":
            if (PdfName.TABLE.Equals((object) role))
            {
              this.role = PdfName.TFOOT;
              break;
            }
            break;
          case "TH":
            if (PdfName.TABLE.Equals((object) role))
            {
              this.role = PdfName.THEAD;
              break;
            }
            break;
          case "TD":
            if (PdfName.TR.Equals((object) role) || PdfName.THEAD.Equals((object) role) || PdfName.TFOOT.Equals((object) role))
            {
              this.role = PdfName.TD;
              break;
            }
            break;
          case "UL":
            this.role = PdfName.DIV;
            break;
          default:
            this.role = new PdfName(str);
            break;
        }
      }
    }
    object ownProperty = this.GetOwnProperty("layout");
    if (this.role != null)
      return;
    if (LayoutManager.tableLayout.Equals(ownProperty))
      this.role = PdfName.TABLE;
    else if (LayoutManager.rowLayout.Equals(ownProperty))
    {
      this.role = PdfName.TR;
    }
    else
    {
      string layout = this.parent != null ? this.parent.GetLayout() : (string) null;
      if (LayoutManager.rowLayout.Equals(layout))
        this.role = PdfName.TD;
      else
        this.role = PdfName.DIV;
    }
  }

  public abstract Positioner CheckOverflowing(
    XFARectangle parentBoundingBox,
    PageArea currentPageArea,
    bool breakableStatus,
    float bottomMargin);

  public abstract Positioner Position(
    PdfContentByte canvas,
    XFARectangle parentBoundingBox,
    PageArea currentPageArea,
    bool breakableStatus,
    float bottomMargin);

  public virtual void DrawBorder(PdfContentByte canvas, XFARectangle parentBoundingBox)
  {
    if (!this.IsBackgroundOrBorderExist)
      return;
    XFARectangle xfaRectangle = (XFARectangle) this.contentArea.Clone();
    this.UnapplyMargins(xfaRectangle);
    this.DrawBorder(canvas, xfaRectangle, parentBoundingBox);
  }

  public virtual void DrawBorder(
    PdfContentByte canvas,
    XFARectangle rec,
    XFARectangle parentBoundingBox)
  {
    BorderDrawer borderDrawer = new BorderDrawer(this.GetBorder());
    if (parentBoundingBox != null)
    {
      XFARectangle xfaRectangle = parentBoundingBox;
      if (!this.transformation.IsIdentity())
      {
        float[] numArray = new float[4]
        {
          xfaRectangle.Llx.Value,
          xfaRectangle.Ury.Value - xfaRectangle.Height.Value,
          xfaRectangle.Llx.Value + xfaRectangle.Width.Value,
          xfaRectangle.Ury.Value
        };
        try
        {
          this.transformation.InverseTransform(numArray, 0, numArray, 0, 2);
          xfaRectangle = new XFARectangle(new float?((double) numArray[0] < (double) numArray[2] ? numArray[0] : numArray[2]), new float?((double) numArray[3] > (double) numArray[1] ? numArray[3] : numArray[1]), new float?(Math.Abs(numArray[2] - numArray[0])), new float?(Math.Abs(numArray[3] - numArray[1])));
        }
        catch (Exception ex)
        {
        }
      }
      float num1 = xfaRectangle.Ury.Value - xfaRectangle.Height.Value;
      float num2 = rec.Ury.Value - rec.Height.Value;
      if (XFAUtil.Gte(rec.Ury.Value, num1) && XFAUtil.Lte(num2, xfaRectangle.Ury.Value))
      {
        float a = this.IsPositionedPartially() ? Math.Max(rec.Ury.Value, xfaRectangle.Ury.Value) : Math.Min(rec.Ury.Value, xfaRectangle.Ury.Value);
        float b = Math.Max(num2, num1);
        if (XFAUtil.Gte(a, b))
        {
          float num3 = a - b;
          rec.Ury = new float?(a);
          rec.Height = new float?(num3);
        }
      }
    }
    rec = rec.ApplyTransformation(this.transformation);
    borderDrawer.Draw(canvas, rec);
  }

  public override object FetchDataNode(bool createNewIfNotExists)
  {
    if (this.data != null && this.data.Node != null)
      return (object) this.data.Node;
    object rawValue = this.GetRawValue();
    if (!createNewIfNotExists || rawValue is string && ((string) rawValue).Length == 0)
      return (object) null;
    DataTag dataTag = this.FetchDataTagRecursively();
    return dataTag == null ? (object) null : (object) dataTag.Node;
  }

  public virtual DataTag FetchDataTagRecursively()
  {
    if (this.data != null)
      return this.data;
    DataTag dataTag;
    if (this.parent == null || (dataTag = this.parent.FetchDataTagRecursively()) == null)
      return (DataTag) null;
    string tag = this.RetrieveName();
    IFormNode formNode = this.RetrieveChild("bind");
    string input;
    if (formNode != null && (input = formNode.RetrieveAttribute("ref")) != null)
      tag = Regex.Replace(Regex.Replace(input, "^\\$", ""), "^\\.", "");
    if (tag == null)
      return dataTag;
    this.data = new DataTag(tag);
    this.data.Parent = (Tag) dataTag;
    dataTag.AddChild((Tag) this.data);
    JsNode child = !(this is FieldPositioner) ? (JsNode) new JsDataGroup(this.data, dataTag.Node) : (JsNode) new JsDataValue(this.data, dataTag.Node);
    child.DefineProperty("value", this.GetRawValue());
    this.data.Node = child;
    dataTag.Node.AddChild((JsTree) child);
    return this.data;
  }

  public virtual object GetRawValue()
  {
    object ownProperty = this.GetOwnProperty("rawValue");
    return ownProperty != null && !this.IsUndefined(ownProperty) && (!(ownProperty is double d) || !double.IsNaN(d) && !double.IsInfinity((double) ownProperty)) ? ownProperty : (object) null;
  }

  public virtual void SetRawValue(object rawValue)
  {
    this.DefineProperty(nameof (rawValue), rawValue);
  }

  public virtual string GetLayout() => this.GetProperty("layout")?.ToString();

  public virtual XFARectangle GetContentArea() => this.contentArea;

  public override void AddChild(JsTree child)
  {
    if (child is Positioner)
    {
      this.childElements.Add((Positioner) child);
      if (!this.immediateChildren.ContainsKey(child.RetrieveName()))
        this.immediateChildren[child.RetrieveName()] = (Positioner) child;
    }
    base.AddChild(child);
  }

  public virtual IList<Positioner> Children => (IList<Positioner>) this.childElements;

  public virtual void RemoveChild(int index)
  {
    Positioner childElement = this.childElements[index];
    this.childElements.RemoveAt(index);
    Positioner positioner;
    if (!this.immediateChildren.TryGetValue(childElement.RetrieveName(), out positioner) || positioner != childElement)
      return;
    this.immediateChildren.Remove(childElement.RetrieveName());
  }

  public virtual XFARectangle GetBBox()
  {
    XFARectangle rectangle = (XFARectangle) this.contentArea.Clone();
    this.UnapplyMargins(rectangle);
    if (this.transformation.Type == 0)
      return rectangle;
    float[] numArray = new float[4]
    {
      rectangle.Llx.Value,
      rectangle.Ury.Value - rectangle.Height.Value,
      rectangle.Llx.Value + rectangle.Width.Value,
      rectangle.Ury.Value
    };
    this.transformation.Transform(numArray, 0, numArray, 0, 2);
    return new XFARectangle(new float?((double) numArray[0] < (double) numArray[2] ? numArray[0] : numArray[2]), new float?((double) numArray[3] > (double) numArray[1] ? numArray[3] : numArray[1]), new float?(Math.Abs(numArray[2] - numArray[0])), new float?(Math.Abs(numArray[3] - numArray[1])));
  }

  public virtual Positioner Parent
  {
    get => this.parent;
    set => this.parent = value;
  }

  public virtual BreakConditions BreakConditions
  {
    get => this.breakConditions;
    set => this.breakConditions = value;
  }

  public virtual KeepConditions KeepConditions => this.keepConditions;

  public abstract bool IsBreakable { get; }

  public virtual XFATemplateTag Template => this.template;

  public virtual DataTag Data
  {
    get => this.data;
    set => this.data = value;
  }

  public virtual PdfContentByte Canvas
  {
    get => this.canvas;
    set => this.canvas = value;
  }

  public virtual int? StartPageNumber
  {
    get => this.startPageNumber;
    set => this.startPageNumber = value;
  }

  public virtual int? StartAbsPageNumber
  {
    get => this.startAbsPageNumber;
    set => this.startAbsPageNumber = value;
  }

  public virtual int? StartSheetNumber => this.startSheetNumber;

  public virtual int? EndPageNumber
  {
    get => this.endPageNumber;
    set => this.endPageNumber = value;
  }

  public virtual int? EndAbsPageNumber
  {
    get => this.endAbsPageNumber;
    set => this.endAbsPageNumber = value;
  }

  public virtual string Name => this.RetrieveName();

  public virtual PositionResult.State PositionState
  {
    get => this.positionState;
    set => this.positionState = value;
  }

  public virtual string GetTemplateId() => this.GetOwnProperty("id")?.ToString();

  public virtual OverflowConditions OverflowConditions => this.overflowConditions;

  public virtual bool IsCurrentPageContentAreaOverflowed(PageArea pageArea)
  {
    if (this.overflowedContentAreas == null || pageArea == null)
      return false;
    ContentArea currentContentArea = pageArea.CurrentContentArea;
    return currentContentArea != null && this.overflowedContentAreas.Contains(currentContentArea.Template);
  }

  public virtual void AddOverflowedPageContentArea(PageArea pageArea)
  {
    if (pageArea == null)
      return;
    ContentArea currentContentArea = pageArea.CurrentContentArea;
    if (currentContentArea == null)
      return;
    if (this.overflowedContentAreas == null)
      this.overflowedContentAreas = new HashSet2<Tag>();
    this.overflowedContentAreas.Add(currentContentArea.Template);
  }

  public virtual AffineTransform Transformation
  {
    get => this.transformation;
    set => this.transformation = value;
  }

  protected virtual bool SupportLegacyPlusPrint => false;

  public virtual bool LayoutOutOfDate
  {
    get => this.layoutOutOfDate;
    set => this.layoutOutOfDate = value;
  }

  public virtual bool IsVisible()
  {
    if (this.flattenerContext.ViewMode != XFAFlattener.ViewMode.ALL)
    {
      object ownProperty = this.GetOwnProperty("relevant");
      bool flag = this.flattenerContext.IsLegacyPlusPrint();
      if (ownProperty != null && (!flag || flag && this.SupportLegacyPlusPrint))
      {
        string str = ownProperty.ToString();
        if (str.Contains("print") && (this.flattenerContext.ViewMode == XFAFlattener.ViewMode.PRINT && str.Contains("-print") || this.flattenerContext.ViewMode == XFAFlattener.ViewMode.SCREEN && !str.Contains("-print")))
          return false;
      }
    }
    object property = this.GetProperty("presence");
    return property == null || property.ToString().Equals("visible");
  }

  public virtual bool IsInvisible() => "invisible".Equals(this.GetProperty("presence"));

  public virtual void AdjustLayout()
  {
    this.AdjustContentArea();
    foreach (Positioner childElement in this.childElements)
    {
      if (childElement is SubFormPositioner && !childElement.IsHidden() && !childElement.IsInactive())
        ((SubFormPositioner) childElement).ApplyAlignment();
    }
    this.ApplyRotation();
    if (this.parent == null)
      return;
    Positioner positionerInLayout = this.parent.GetPreviousPositionerInLayout(this, this.GetLayout());
    XFARectangle bbox1 = this.GetBBox();
    XFARectangle contentArea = this.parent.GetContentArea();
    string layout = this.parent.GetLayout();
    if (this.template.Parent != null && this.template.Parent.Parent == null)
      return;
    if (LayoutManager.tbLayout.Equals(layout))
    {
      float num;
      if (positionerInLayout != null)
      {
        XFARectangle bbox2 = positionerInLayout.GetBBox();
        num = bbox2.Ury.Value - bbox2.Height.Value;
      }
      else
        num = contentArea.Ury.Value;
      this.ApplyTranslation(0.0f, num - bbox1.Ury.Value);
    }
    else
    {
      if (LayoutManager.rowLayout.Equals(layout) || !Util.EqualsIgnoreCase(LayoutManager.tblrLayout, layout))
        return;
      if (positionerInLayout != null)
      {
        XFARectangle bbox3 = positionerInLayout.GetBBox();
        if (!contentArea.Width.HasValue)
          return;
        float? llx1 = bbox3.Llx;
        float? width1 = bbox3.Width;
        float? nullable1 = llx1.HasValue & width1.HasValue ? new float?(llx1.GetValueOrDefault() + width1.GetValueOrDefault()) : new float?();
        float? width2 = bbox1.Width;
        float? nullable2 = nullable1.HasValue & width2.HasValue ? new float?(nullable1.GetValueOrDefault() + width2.GetValueOrDefault()) : new float?();
        float? llx2 = contentArea.Llx;
        float? nullable3 = nullable2.HasValue & llx2.HasValue ? new float?(nullable2.GetValueOrDefault() - llx2.GetValueOrDefault()) : new float?();
        float? width3 = contentArea.Width;
        float? nullable4 = nullable3.HasValue & width3.HasValue ? new float?(nullable3.GetValueOrDefault() - width3.GetValueOrDefault()) : new float?();
        if (((double) nullable4.GetValueOrDefault() >= 0.01 ? 0 : (nullable4.HasValue ? 1 : 0)) != 0)
          return;
        float num1 = bbox3.Ury.Value - bbox3.Height.Value;
        for (int index = this.parent.Children.IndexOf(this) - 2; index >= 0; --index)
        {
          Positioner child = this.parent.Children[index];
          if (!child.IsHidden() && !child.IsInactive())
          {
            XFARectangle bbox4 = child.GetBBox();
            float num2 = bbox4.Ury.Value - bbox4.Height.Value;
            if ((double) num1 > (double) num2)
              num1 = num2;
          }
        }
        this.ApplyTranslation(contentArea.Llx.Value - bbox1.Llx.Value, num1 - bbox1.Ury.Value);
      }
      else
        this.ApplyTranslation(contentArea.Llx.Value - bbox1.Llx.Value, contentArea.Ury.Value - bbox1.Ury.Value);
    }
  }

  protected virtual void ApplyRotation()
  {
    IDictionary<string, string> attributes = this.template.Attributes;
    if (attributes == null)
      return;
    string str1 = LayoutManager.positionLayout;
    if (this.parent != null)
      str1 = this.parent.GetLayout();
    XFARectangle rectangle = (XFARectangle) this.contentArea.Clone();
    this.UnapplyMargins(rectangle);
    float num1 = rectangle.Llx.Value;
    float num2 = rectangle.Ury.Value;
    string str2;
    if (attributes.TryGetValue("anchorType", out str2) && str2 != null && !str1.Equals(LayoutManager.tbLayout) && !str1.Equals(LayoutManager.tblrLayout) && !str1.Equals(LayoutManager.rowLayout))
    {
      if (this.contentArea.Width.HasValue)
      {
        if (str2.Contains("center".Replace('c', 'C')))
          num1 = rectangle.Llx.Value + rectangle.Width.Value / 2f;
        else if (str2.Contains("right".Replace('r', 'R')))
          num1 = rectangle.Llx.Value + rectangle.Width.Value;
      }
      if (this.contentArea.Height.HasValue)
      {
        if (str2.Contains("middle"))
          num2 = rectangle.Ury.Value - rectangle.Height.Value / 2f;
        else if (str2.Contains("bottom"))
          num2 = rectangle.Ury.Value - rectangle.Height.Value;
      }
      float xtr = rectangle.Llx.Value - num1;
      float ytr = rectangle.Ury.Value - num2;
      if (!this.template.Attributes.ContainsKey("y"))
        ytr = 0.0f;
      this.ApplyTranslation(xtr, ytr);
    }
    if (!attributes.ContainsKey("rotate"))
      return;
    float? nullable = XFAUtil.ParseFloat(attributes["rotate"]);
    if (!nullable.HasValue || this.parent != null && LayoutManager.rowLayout.Equals(this.parent.GetLayout()))
      return;
    this.transformation.Concatenate(AffineTransform.GetRotateInstance(Positioner.ConvertToRadians((double) nullable.Value), (double) num1, (double) num2));
  }

  private static double ConvertToRadians(double angle) => Math.PI / 180.0 * angle;

  public virtual void ApplyTranslation(float xtr, float ytr)
  {
    xtr = (float) Math.Round((double) xtr * 1000.0) / 1000f;
    ytr = (float) Math.Round((double) ytr * 1000.0) / 1000f;
    if ((double) xtr == 0.0 && (double) ytr == 0.0)
      return;
    AffineTransform translateInstance = AffineTransform.GetTranslateInstance((double) xtr, (double) ytr);
    translateInstance.Concatenate(this.transformation);
    this.transformation = translateInstance;
  }

  public virtual void ApplyTransformationToRectangle(XFARectangle bbox)
  {
    this.ApplyTransformationToRectangle(bbox, false);
  }

  public virtual void ApplyTransformationToRectangle(XFARectangle bbox, bool inverse)
  {
    if (this.transformation.IsIdentity())
      return;
    float[] numArray = new float[4]
    {
      bbox.Llx.Value,
      bbox.Ury.Value - bbox.Height.Value,
      bbox.Llx.Value + bbox.Width.Value,
      bbox.Ury.Value
    };
    try
    {
      if (inverse)
        this.transformation.InverseTransform(numArray, 0, numArray, 0, 2);
      else
        this.transformation.Transform(numArray, 0, numArray, 0, 2);
      bbox.Llx = new float?((double) numArray[0] < (double) numArray[2] ? numArray[0] : numArray[2]);
      bbox.Ury = new float?((double) numArray[3] > (double) numArray[1] ? numArray[3] : numArray[1]);
      bbox.Width = new float?(Math.Abs(numArray[2] - numArray[0]));
      bbox.Height = new float?(Math.Abs(numArray[3] - numArray[1]));
    }
    catch (Exception ex)
    {
    }
  }

  protected internal bool DoesNotFitContentArea(float bottomMargin, float contentAreaBottom)
  {
    XFARectangle absoluteBbox = this.GetAbsoluteBbox(true);
    float num = absoluteBbox.Height.HasValue ? absoluteBbox.Height.Value : 0.0f;
    return (double) absoluteBbox.Ury.Value - (double) num - (double) contentAreaBottom < -(double) XFAUtil.DEVIATION - (double) bottomMargin;
  }

  protected virtual Positioner FindNextBreakableElement(int startFrom)
  {
    int index = startFrom;
    int count = this.parent.Children.Count;
    if (index < count)
    {
      string layout = this.parent.GetLayout();
      if (LayoutManager.tbLayout.Equals(layout) || LayoutManager.tblrLayout.Equals(layout) || LayoutManager.rowLayout.Equals(layout) || LayoutManager.tableLayout.Equals(layout))
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
        if (positioner != null)
        {
          if (this.keepConditions != null && !this.keepConditions.Next.Equals("none"))
            return positioner.FindNextBreakableElement(index + 1);
          if (positioner.KeepConditions != null && !positioner.KeepConditions.Previous.Equals("none"))
            return positioner.FindNextBreakableElement();
          XFARectangle bbox1 = this.GetBBox();
          XFARectangle bbox2 = positioner.GetBBox();
          float b = bbox1.Ury.Value - bbox1.Height.Value;
          float a = bbox2.Ury.Value - bbox2.Height.Value;
          if (XFAUtil.Equal(bbox1.Ury.Value, bbox2.Ury.Value) && XFAUtil.Lte(a, b))
            return positioner.FindNextBreakableElement();
        }
      }
    }
    return this;
  }

  protected virtual Positioner FindNextBreakableElement()
  {
    return this.parent != null ? this.FindNextBreakableElement(this.parent.Children.IndexOf(this) + 1) : this;
  }

  protected abstract void AdjustContentArea();

  public virtual void AdjustContentAreaHeight(float newHeight)
  {
    if (this.contentArea.Height.HasValue)
    {
      this.UnapplyMargins(this.contentArea);
      this.contentArea.Height = new float?(newHeight);
      this.ApplyMargins(this.contentArea);
    }
    else
      this.contentArea.Height = new float?(newHeight);
  }

  public abstract void Relayout(bool forceLayout);

  protected internal virtual void AdjustContentAreaUry(float ury)
  {
    if (this.contentArea.Ury.HasValue)
    {
      this.UnapplyMargins(this.contentArea);
      float num1 = this.contentArea.Ury.Value;
      this.contentArea.Ury = new float?(ury);
      XFARectangle contentArea = this.contentArea;
      float? height = this.contentArea.Height;
      float num2 = num1 - ury;
      float? nullable = height.HasValue ? new float?(height.GetValueOrDefault() - num2) : new float?();
      contentArea.Height = nullable;
      this.ApplyMargins(this.contentArea);
    }
    else
      this.contentArea.Ury = new float?(ury);
  }

  protected virtual bool IsPositionedPartially() => false;

  public virtual Positioner GetPreviousPositionerInLayout(Positioner childPositioner, string layout)
  {
    return this.GetLastPositionerBeforeInd(this.childElements.IndexOf(childPositioner), layout);
  }

  public virtual Positioner GetLastPositionerInLayout(string layout)
  {
    return this.GetLastPositionerBeforeInd(this.childElements.Count, layout);
  }

  public virtual XFARectangle GetAbsoluteBbox() => this.GetAbsoluteBbox(false);

  public virtual XFARectangle GetAbsoluteBbox(bool ignorePagenationTransformation)
  {
    AffineTransform finalTransformation = this.GetFinalTransformation(ignorePagenationTransformation);
    if (finalTransformation.IsIdentity())
      return this.GetBBox();
    XFARectangle rectangle = (XFARectangle) this.contentArea.Clone();
    this.UnapplyMargins(rectangle);
    float[] numArray = new float[4]
    {
      rectangle.Llx.Value,
      rectangle.Ury.Value - rectangle.Height.Value,
      rectangle.Llx.Value + rectangle.Width.Value,
      rectangle.Ury.Value
    };
    finalTransformation.Transform(numArray, 0, numArray, 0, 2);
    return new XFARectangle(new float?((double) numArray[0] < (double) numArray[2] ? numArray[0] : numArray[2]), new float?((double) numArray[3] > (double) numArray[1] ? numArray[3] : numArray[1]), new float?(Math.Abs(numArray[2] - numArray[0])), new float?(Math.Abs(numArray[3] - numArray[1])));
  }

  public virtual AffineTransform GetFinalTransformation(bool ignorePagenationTransformation)
  {
    Positioner parent = this.parent;
    AffineTransform finalTransformation = new AffineTransform(this.transformation);
    for (; parent != null && (!ignorePagenationTransformation || parent.parent != null); parent = parent.parent)
      finalTransformation.preConcatenate(parent.Transformation);
    return finalTransformation;
  }

  protected virtual Positioner GetLastPositionerBeforeInd(int childIndex, string childLayout)
  {
    Positioner positionerBeforeInd = (Positioner) null;
    for (int index = childIndex - 1; index >= 0; --index)
    {
      Positioner positioner = this.childElements[index];
      if (!positioner.IsHidden() && !positioner.IsInactive())
      {
        if (positioner is SubformSetPositioner && LayoutManager.rowLayout.Equals(childLayout))
        {
          positioner = positioner.GetLastPositionerInLayout(childLayout);
          if (positioner == null)
            continue;
        }
        positionerBeforeInd = positioner;
        break;
      }
    }
    if (positionerBeforeInd == null && this is SubformSetPositioner && this.parent != null)
      positionerBeforeInd = this.parent.GetPreviousPositionerInLayout(this, childLayout);
    return positionerBeforeInd;
  }

  protected virtual void SavePosState(PdfContentByte canvas)
  {
    if (canvas.IsTagged() && this.isTagged)
      canvas.OpenMCBlock((IAccessibleElement) this);
    if (this.transformation.IsIdentity())
      return;
    canvas.SaveState();
    canvas.Transform(this.transformation);
  }

  protected virtual void RestorePosState(PdfContentByte canvas)
  {
    if (!this.transformation.IsIdentity())
      canvas.RestoreState();
    if (!canvas.IsTagged() || !this.isTagged)
      return;
    canvas.CloseMCBlock((IAccessibleElement) this);
  }

  private IFormNode GetBorder() => this.RetrieveChild("border");

  public override object GetFormattedValue() => this.GetRawValue();

  protected virtual string GetAlternateText()
  {
    string alternateText = "";
    if (this.assistTag != null)
    {
      IFormNode formNode = this.assistTag.RetrieveChild("speak");
      if (formNode != null)
      {
        IDictionary<string, string> dictionary = formNode.RetrieveAttributes();
        if (dictionary == null)
        {
          IList<string> content = ((XFATemplateTag) formNode).Content;
          if (content != null && content.Count > 0)
            alternateText = content[0];
        }
        else
        {
          string str1 = (string) null;
          dictionary.TryGetValue("disable", out str1);
          if (!"1".Equals(str1))
          {
            string toolTipText = this.GetToolTipText(this.assistTag);
            string speakText = this.GetSpeakText(this.assistTag);
            string str2 = this.template.RetrieveAttribute("name") ?? "";
            string captionText = this.GetCaptionText();
            string str3 = (string) null;
            dictionary.TryGetValue("priority", out str3);
            alternateText = !"caption".Equals(str3) ? (!"name".Equals(str3) ? (!"toolTip".Equals(str3) ? this.GetAltText(speakText, toolTipText, captionText, str2) : this.GetAltText(toolTipText, speakText, captionText, str2)) : this.GetAltText(str2, speakText, toolTipText, captionText)) : this.GetAltText(captionText, speakText, toolTipText, str2);
          }
        }
      }
    }
    return alternateText;
  }

  public float GetBottomInset()
  {
    IFormNode formNode = this.RetrieveChild("margin");
    return formNode != null ? CssUtils.GetInstance().ParsePxInCmMmPcToPt(formNode.RetrieveAttribute("bottomInset"), "pt") : 0.0f;
  }

  public virtual void ApplyMargins(XFARectangle rectangle)
  {
    IFormNode formNode = this.RetrieveChild("margin");
    if (formNode == null)
      return;
    float pxInCmMmPcToPt1 = CssUtils.GetInstance().ParsePxInCmMmPcToPt(formNode.RetrieveAttribute("topInset"), "pt");
    float pxInCmMmPcToPt2 = CssUtils.GetInstance().ParsePxInCmMmPcToPt(formNode.RetrieveAttribute("rightInset"), "pt");
    float pxInCmMmPcToPt3 = CssUtils.GetInstance().ParsePxInCmMmPcToPt(formNode.RetrieveAttribute("leftInset"), "pt");
    float pxInCmMmPcToPt4 = CssUtils.GetInstance().ParsePxInCmMmPcToPt(formNode.RetrieveAttribute("bottomInset"), "pt");
    float[] numArray = new float[4]
    {
      pxInCmMmPcToPt1,
      pxInCmMmPcToPt2,
      pxInCmMmPcToPt4,
      pxInCmMmPcToPt3
    };
    int? independentRotation = this.GetIndependentRotation();
    if (independentRotation.HasValue)
    {
      int? nullable1 = independentRotation;
      int? nullable2 = nullable1.HasValue ? new int?(nullable1.GetValueOrDefault() % 180) : new int?();
      if ((nullable2.GetValueOrDefault() != 90 ? 0 : (nullable2.HasValue ? 1 : 0)) != 0)
      {
        int num1 = 0;
        while (true)
        {
          int num2 = num1;
          int? nullable3 = independentRotation;
          int? nullable4 = nullable3.HasValue ? new int?(nullable3.GetValueOrDefault() / 90) : new int?();
          if ((num2 >= nullable4.GetValueOrDefault() ? 0 : (nullable4.HasValue ? 1 : 0)) != 0)
          {
            numArray = new float[4]
            {
              numArray[3],
              numArray[0],
              numArray[1],
              numArray[2]
            };
            ++num1;
          }
          else
            break;
        }
      }
    }
    XFARectangle.ApplyMargins(rectangle, this.IsPositionedPartially() ? 0.0f : numArray[0], numArray[1], numArray[2], numArray[3], false);
  }

  public virtual XFARectangle UnapplyMargins(XFARectangle rectangle)
  {
    IFormNode formNode = this.RetrieveChild("margin");
    if (formNode != null)
    {
      float pxInCmMmPcToPt1 = CssUtils.GetInstance().ParsePxInCmMmPcToPt(formNode.RetrieveAttribute("topInset"), "pt");
      float pxInCmMmPcToPt2 = CssUtils.GetInstance().ParsePxInCmMmPcToPt(formNode.RetrieveAttribute("rightInset"), "pt");
      float pxInCmMmPcToPt3 = CssUtils.GetInstance().ParsePxInCmMmPcToPt(formNode.RetrieveAttribute("leftInset"), "pt");
      float pxInCmMmPcToPt4 = CssUtils.GetInstance().ParsePxInCmMmPcToPt(formNode.RetrieveAttribute("bottomInset"), "pt");
      float[] numArray = new float[4]
      {
        pxInCmMmPcToPt1,
        pxInCmMmPcToPt2,
        pxInCmMmPcToPt4,
        pxInCmMmPcToPt3
      };
      int? independentRotation = this.GetIndependentRotation();
      if (independentRotation.HasValue)
      {
        int? nullable1 = independentRotation;
        int? nullable2 = nullable1.HasValue ? new int?(nullable1.GetValueOrDefault() % 180) : new int?();
        if ((nullable2.GetValueOrDefault() != 90 ? 0 : (nullable2.HasValue ? 1 : 0)) != 0)
        {
          int num1 = 0;
          while (true)
          {
            int num2 = num1;
            int? nullable3 = independentRotation;
            int? nullable4 = nullable3.HasValue ? new int?(nullable3.GetValueOrDefault() / 90) : new int?();
            if ((num2 >= nullable4.GetValueOrDefault() ? 0 : (nullable4.HasValue ? 1 : 0)) != 0)
            {
              numArray = new float[4]
              {
                numArray[3],
                numArray[0],
                numArray[1],
                numArray[2]
              };
              ++num1;
            }
            else
              break;
          }
        }
      }
      XFARectangle.ApplyMargins(rectangle, this.IsPositionedPartially() ? 0.0f : numArray[0], numArray[1], numArray[2], numArray[3], true);
    }
    return rectangle;
  }

  public virtual PdfObject GetAccessibleAttribute(PdfName key)
  {
    PdfObject accessibleAttribute = (PdfObject) null;
    if (this.accessibleAttributes != null)
      this.accessibleAttributes.TryGetValue(key, out accessibleAttribute);
    return accessibleAttribute;
  }

  public virtual void SetAccessibleAttribute(PdfName key, PdfObject value)
  {
    if (this.accessibleAttributes == null)
      this.accessibleAttributes = new Dictionary<PdfName, PdfObject>();
    this.accessibleAttributes[key] = value;
  }

  public virtual Dictionary<PdfName, PdfObject> GetAccessibleAttributes()
  {
    return this.accessibleAttributes;
  }

  public virtual PdfName Role
  {
    get => this.role;
    set => this.role = value;
  }

  public virtual AccessibleElementId ID
  {
    get
    {
      if (this.id == null)
        this.id = new AccessibleElementId();
      return this.id;
    }
    set => this.id = value;
  }

  public virtual bool IsInline => PdfName.ARTIFACT.Equals((object) this.role);

  public virtual bool IsEmpty() => this.isEmpty;

  public virtual bool IsContentTagged() => this.isContentTagged;

  protected virtual string GetCaptionText() => "";

  private string GetTagContent(IFormNode parentTag, string tagName)
  {
    IFormNode formNode = parentTag.RetrieveChild(tagName);
    if (formNode == null)
      return "";
    IList<string> stringList = formNode.RetrieveContent();
    return stringList == null || stringList.Count == 0 ? "" : stringList[0];
  }

  private string GetToolTipText(IFormNode assistTag) => this.GetTagContent(assistTag, "toolTip");

  private string GetSpeakText(IFormNode assistTag) => this.GetTagContent(assistTag, "speak");

  private string GetAltText(string s1, string s2, string s3, string s4)
  {
    string[] strArray = new string[4]{ s1, s2, s3, s4 };
    foreach (string altText in strArray)
    {
      if (altText != null && altText.Length != 0)
        return altText;
    }
    return "";
  }

  protected internal virtual bool IsBackgroundOrBorderExist
  {
    get
    {
      IFormNode border = this.GetBorder();
      return border != null && !BorderDrawer.IsEmpty(border);
    }
  }

  public float? X
  {
    set
    {
      if (this.contentArea != null)
        this.contentArea.Llx = value;
      this.DefineProperty("x", (object) ((!value.HasValue ? "null" : value.Value.ToString((IFormatProvider) CultureInfo.InvariantCulture)) + "pt"));
    }
  }

  public float? Width
  {
    set
    {
      if (this.contentArea != null)
        this.contentArea.Width = value;
      this.DefineProperty("w", (object) ((!value.HasValue ? "null" : value.Value.ToString((IFormatProvider) CultureInfo.InvariantCulture)) + "pt"));
    }
  }

  protected virtual void UpdatePageNumbers()
  {
    if (!this.startPageNumber.HasValue)
      this.startPageNumber = this.flattenerContext.CurrentPageNumber;
    if (!this.startAbsPageNumber.HasValue)
      this.startAbsPageNumber = this.flattenerContext.CurrentAbsPageNumber;
    if (!this.startSheetNumber.HasValue)
      this.startSheetNumber = this.flattenerContext.CurrentSheetNumber;
    this.endPageNumber = this.flattenerContext.CurrentPageNumber;
    this.endAbsPageNumber = this.flattenerContext.CurrentAbsPageNumber;
  }

  public class PositionedLayoutComparator : Comparer<Positioner>
  {
    public override int Compare(Positioner o1, Positioner o2)
    {
      if (o1.IsHidden() || o1.IsInactive())
        return o2.IsHidden() || o2.IsInactive() ? 0 : 1;
      if (o2.IsHidden() || o2.IsInactive())
        return -1;
      XFARectangle bbox1 = o1.GetBBox();
      XFARectangle bbox2 = o2.GetBBox();
      bool flag1 = o1.IsVisible() && XFAUtil.Gt(bbox1.Height.Value, 0.0f) && XFAUtil.Gt(bbox1.Width.Value, 0.0f);
      bool flag2 = o2.IsVisible() && XFAUtil.Gt(bbox2.Height.Value, 0.0f) && XFAUtil.Gt(bbox2.Width.Value, 0.0f);
      if (flag1 && flag2)
      {
        float b1 = Math.Min(bbox1.Height.Value / 2.2f, bbox2.Height.Value / 2.2f);
        float a1 = bbox1.Ury.Value - bbox1.Height.Value;
        float b2 = bbox2.Ury.Value - bbox2.Height.Value;
        if (!XFAUtil.Gte(bbox1.Ury.Value, b2) || !XFAUtil.Lte(a1, bbox2.Ury.Value))
          return XFAUtil.Gt(bbox1.Ury.Value, bbox2.Ury.Value) ? -1 : 1;
        if (XFAUtil.Gt(Math.Abs(a1 - b2), b1))
          return (double) a1 > (double) b2 ? -1 : 1;
        if (XFAUtil.Gt(Math.Abs(bbox1.Ury.Value - bbox2.Ury.Value), b1))
          return (double) bbox1.Ury.Value > (double) bbox2.Ury.Value ? -1 : 1;
        float a2 = bbox1.Llx.Value + bbox1.Width.Value;
        float b3 = bbox2.Llx.Value + bbox2.Width.Value;
        if (!XFAUtil.Gte(a2, bbox2.Llx.Value) || !XFAUtil.Lte(bbox1.Llx.Value, b3))
          return XFAUtil.Lt(bbox1.Llx.Value, bbox2.Llx.Value) ? -1 : 1;
        if (!XFAUtil.Equal(a2, b3))
          return (double) a2 < (double) b3 ? -1 : 1;
        if (!XFAUtil.Equal(bbox1.Llx.Value, bbox2.Llx.Value))
          return (double) bbox1.Llx.Value < (double) bbox2.Llx.Value ? -1 : 1;
        if (!XFAUtil.Equal(a1, b2))
          return (double) a1 > (double) b2 ? -1 : 1;
        if (XFAUtil.Equal(bbox1.Ury.Value, bbox2.Ury.Value))
          return 0;
        float? ury1 = bbox1.Ury;
        float? ury2 = bbox2.Ury;
        return ((double) ury1.GetValueOrDefault() <= (double) ury2.GetValueOrDefault() ? 0 : (ury1.HasValue & ury2.HasValue ? 1 : 0)) != 0 ? -1 : 1;
      }
      if (flag1)
        return -1;
      return flag2 ? 1 : 0;
    }
  }

  public class RowLayoutComparator : Comparer<Positioner>
  {
    public override int Compare(Positioner o1, Positioner o2)
    {
      if (o1 is ContentPositioner)
      {
        if (o2 is SubFormPositioner)
          return 1;
      }
      else if (o2 is ContentPositioner)
        return -1;
      return 0;
    }
  }
}
