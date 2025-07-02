// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.positioner.SubFormPositioner
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.awt.geom;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml.util;
using iTextSharp.tool.xml.xtra.xfa.element;
using iTextSharp.tool.xml.xtra.xfa.js;
using iTextSharp.tool.xml.xtra.xfa.resolver;
using iTextSharp.tool.xml.xtra.xfa.tags;
using iTextSharp.tool.xml.xtra.xfa.util;
using Jint.Delegates;
using Jint.Native;
using System;
using System.Collections.Generic;
using System.util;
using System.util.collections;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.positioner;

public class SubFormPositioner : Positioner
{
  private IList<XFARectangle> internalBoxes = (IList<XFARectangle>) new List<XFARectangle>();
  protected XFARectangle internalBBox;
  protected LinkedList<BreakConditions> breakBefore = new LinkedList<BreakConditions>();
  protected LinkedList<BreakConditions> breakAfter = new LinkedList<BreakConditions>();
  protected BreakConditions breakOverflow;
  protected List<PdfContentByte> canvases;
  protected IList<SubFormPositioner> childUnnamedSubforms = (IList<SubFormPositioner>) new List<SubFormPositioner>();
  public static List<string> breakConditionNodes = new List<string>()
  {
    "break",
    "overflow",
    nameof (breakAfter),
    nameof (breakBefore)
  };

  public SubFormPositioner(string className, JsContainer prototype)
    : base(className, (JsNode) prototype)
  {
    this.DefineOwnProperty((Descriptor) new PropertyDescriptor<SubFormPositioner>((Jint.Native.IGlobal) this.IGlobal, (JsDictionaryObject) this, "instanceManager", new JintFunc<SubFormPositioner, JsInstance>(this.InstanceManagerJsProp)));
    this.DefineOwnProperty((Descriptor) new PropertyDescriptor<SubFormPositioner>((Jint.Native.IGlobal) this.IGlobal, (JsDictionaryObject) this, "instanceIndex", new JintFunc<SubFormPositioner, JsInstance>(this.InstanceIndexJsProp)));
    this.DefineProperty("addInstance", (object) this.IGlobal.FunctionClass.New<SubFormPositioner>(new JintFunc<SubFormPositioner, JsInstance[], JsInstance>(this.AddInstanceJsFunc)));
  }

  public SubFormPositioner(
    XFATemplateTag templateTag,
    DataTag dataTag,
    FlattenerContext flattenerContext,
    JsNode parent,
    string prototypeName = null)
    : base(templateTag, dataTag, flattenerContext, parent, prototypeName ?? "subform")
  {
    string name = this.Name;
    if (!this.HasOwnProperty(name))
      this.DefineProperty(name, (object) this);
    this.isEmpty = !this.IsBackgroundOrBorderExist;
  }

  public override Descriptor GetDescriptor(string index)
  {
    Descriptor descriptor1 = base.GetDescriptor(index);
    if (descriptor1 == null)
    {
      Descriptor descriptor2 = this.ResolveNameFromUnnamedSubformRecursively(index);
      if (descriptor2 != null)
        return descriptor2;
    }
    return descriptor1;
  }

  public virtual Descriptor ResolveNameFromUnnamedSubformRecursively(string name)
  {
    Descriptor descriptor1;
    if (this.properties.TryGet(name, out descriptor1) && descriptor1.Owner == this)
    {
      JsInstance jsInstance = descriptor1.Get((JsDictionaryObject) this);
      if (jsInstance is JintJsNodeList)
      {
        jsInstance = ((JintJsNodeList) jsInstance).GetItem(0) as JsInstance;
        descriptor1 = (Descriptor) new ValueDescriptor((JsDictionaryObject) this, name, jsInstance);
      }
      return !(jsInstance is Positioner) && !(jsInstance is JsInstanceManager) ? (Descriptor) null : descriptor1;
    }
    foreach (SubFormPositioner childUnnamedSubform in (IEnumerable<SubFormPositioner>) this.childUnnamedSubforms)
    {
      Descriptor descriptor2 = childUnnamedSubform.ResolveNameFromUnnamedSubformRecursively(name);
      if (descriptor2 != null)
        return descriptor2;
    }
    return (Descriptor) null;
  }

  public virtual IList<object> ResolveAllFromUnnamedSubformRecursively(string name)
  {
    List<object> objectList = new List<object>();
    Descriptor descriptor;
    if (this.properties.TryGet(name, out descriptor) && descriptor.Owner == this)
    {
      JsInstance jsInstance = descriptor.Get((JsDictionaryObject) this);
      switch (jsInstance)
      {
        case JintJsNodeList _:
          for (int i = 0; i < ((JsDictionaryObject) jsInstance).Length; ++i)
          {
            object obj = ((JintJsNodeList) jsInstance).GetItem(i);
            if (obj != null)
              objectList.Add(obj);
          }
          break;
        case Positioner _:
        case JsInstanceManager _:
          if (!jsInstance.Equals((object) this))
          {
            objectList.Add((object) jsInstance);
            break;
          }
          break;
      }
    }
    foreach (SubFormPositioner childUnnamedSubform in (IEnumerable<SubFormPositioner>) this.childUnnamedSubforms)
    {
      IList<object> collection = childUnnamedSubform.ResolveAllFromUnnamedSubformRecursively(name);
      if (collection != null)
        objectList.AddRange((IEnumerable<object>) collection);
    }
    return (IList<object>) objectList;
  }

  public override void AddChild(JsTree child)
  {
    base.AddChild(child);
    if (!(child is SubFormPositioner) || ((Positioner) child).Template.RetrieveAttribute("name") != null)
      return;
    this.childUnnamedSubforms.Add((SubFormPositioner) child);
  }

  public override string ClassName => "subform";

  public virtual object GetInstanceManager()
  {
    return this.parent == null ? (object) new JsInstanceManager(this.template, (JsNode) this.parent, this.flattenerContext) : (object) this.parent.GetInstanceManagerByTemplate((Tag) this.template);
  }

  public virtual JsInstanceManager GetInstanceManagerByTemplate(XFATemplateTag templateTag)
  {
    return this.GetInstanceManagerByTemplate((Tag) templateTag);
  }

  private JsInstance InstanceManagerJsProp(SubFormPositioner target)
  {
    return (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, target.GetInstanceManager());
  }

  public virtual object GetInstanceIndex()
  {
    int i = 0;
    object ownProperty = this.parent.GetOwnProperty(this.Name);
    if (ownProperty is JintJsNodeList)
    {
      while (i < ((JsDictionaryObject) ownProperty).Length && ((JintJsNodeList) ownProperty).GetItem(i) != this)
        ++i;
    }
    return (object) i;
  }

  private JsInstance InstanceIndexJsProp(SubFormPositioner target)
  {
    return (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, target.GetInstanceIndex());
  }

  public virtual void AddInstance(bool bind)
  {
    if (this.parent == null)
      return;
    this.parent.GetInstanceManagerByTemplate((Tag) this.template)?.AddInstance(bind);
  }

  public virtual JsInstance AddInstanceJsFunc(SubFormPositioner target, JsInstance[] parameters)
  {
    if (parameters.Length == 1)
      target.AddInstance(parameters[0].ToBoolean());
    return (JsInstance) JsNull.Instance;
  }

  protected override void InitLayout()
  {
    base.InitLayout();
    this.CreateBreakConditions();
    Positioner currentNode = this.flattenerContext.CurrentNode;
    this.flattenerContext.CurrentNode = (Positioner) this;
    string layout = this.GetLayout();
    bool flag1 = false;
    bool flag2 = false;
    if (LayoutManager.rowLayout.Equals(layout))
    {
      if (this.role == PdfName.THEAD)
        flag1 = true;
      else if (this.role == PdfName.TFOOT)
        flag2 = true;
    }
    int num = 0;
    bool flag3 = false;
    foreach (Positioner childElement in this.childElements)
    {
      if (!childElement.IsHidden() && !childElement.IsInactive())
      {
        childElement.Place();
        if (this.isEmpty)
          this.isEmpty = childElement.IsEmpty();
        if (!this.isEmpty && childElement.IsContentTagged())
          ++num;
        else if (num < 2 && !childElement.IsEmpty() && childElement.IsContentTagged())
          ++num;
        if (flag1 && childElement.role != PdfName.TR)
        {
          this.role = PdfName.TR;
          childElement.role = PdfName.TH;
        }
        if (flag2 && childElement.role != PdfName.TR)
        {
          this.role = PdfName.TR;
          flag2 = false;
        }
        if (childElement.role == PdfName.DIV || childElement.role == PdfName.SECT)
          flag3 = true;
        this.AddInternalBox(childElement.GetBBox());
      }
    }
    this.isContentTagged = num > 0;
    this.isTagged = !(this is SubformSetPositioner) && (this.role != PdfName.DIV && num > 0 || num > 1);
    if (this.isTagged && this.role == PdfName.DIV && flag3)
      this.role = PdfName.SECT;
    this.flattenerContext.CurrentNode = currentNode;
  }

  public virtual void CreateBreakConditions()
  {
    foreach (string breakConditionNode in SubFormPositioner.breakConditionNodes)
    {
      IFormNode formNode = this.RetrieveChild(breakConditionNode);
      if (formNode != null)
      {
        ScriptString scriptString = ScriptString.CreateScriptString(formNode.RetrieveChild("script"));
        IDictionary<string, string> dictionary = formNode.RetrieveAttributes();
        string str;
        dictionary.TryGetValue("startNew", out str);
        bool startNew = false;
        if (str != null && Util.EqualsIgnoreCase(str, "1"))
          startNew = true;
        if (Util.EqualsIgnoreCase(breakConditionNode, "break"))
        {
          string type;
          dictionary.TryGetValue("before", out type);
          string target;
          dictionary.TryGetValue("beforeTarget", out target);
          if (type != null || target != null)
            this.breakBefore.AddLast(new BreakConditions("before", type, target, startNew, this, scriptString));
          dictionary.TryGetValue("after", out type);
          dictionary.TryGetValue("afterTarget", out target);
          if (type != null || target != null)
            this.breakAfter.AddLast(new BreakConditions("after", type, target, startNew, this, scriptString));
          dictionary.TryGetValue("overflow", out type);
          dictionary.TryGetValue("overflowTarget", out target);
          if (type != null || target != null)
            this.breakOverflow = new BreakConditions("overflow", type, target, false, this, scriptString);
        }
        else
        {
          string type;
          dictionary.TryGetValue("targetType", out type);
          string target;
          dictionary.TryGetValue("target", out target);
          if (type != null || target != null)
          {
            if (Util.EqualsIgnoreCase(breakConditionNode, "breakBefore"))
              this.breakBefore.AddLast(new BreakConditions("before", type, target, startNew, this, scriptString));
            else if (Util.EqualsIgnoreCase(breakConditionNode, "breakAfter"))
              this.breakAfter.AddLast(new BreakConditions("after", type, target, startNew, this, scriptString));
            else
              this.breakOverflow = new BreakConditions("overflow", type, target, false, this, scriptString);
          }
        }
      }
    }
  }

  public override Positioner CheckOverflowing(
    XFARectangle parentBoundingBox,
    PageArea currentPageArea,
    bool breakableStatus,
    float bottomMargin)
  {
    if (this.CheckBreakBeforeCondition(currentPageArea))
    {
      this.PropagateBreakConditions();
      return (Positioner) this;
    }
    XFARectangle xfaRectangle1 = (XFARectangle) null;
    if (parentBoundingBox != null)
    {
      if (breakableStatus && !this.IsCurrentPageContentAreaOverflowed(currentPageArea))
      {
        float contentAreaBottom = parentBoundingBox.Ury.Value - parentBoundingBox.Height.Value;
        if (this.overflowConditions != null)
        {
          TrailerLeaderElement currentTrailer = this.overflowConditions.GetCurrentTrailer();
          if (currentTrailer != null)
          {
            if (currentTrailer.BoundingBox == null)
            {
              Positioner positioner = (Positioner) this.flattenerContext.FormBuilder.BuildSubForm(currentTrailer.FormTag, (DataTag) null, (JsNode) null);
              positioner.Place(new float?(0.0f), new float?(0.0f));
              currentTrailer.BoundingBox = positioner.GetBBox();
            }
            if (currentTrailer.FormTag != this.template)
              contentAreaBottom += currentTrailer.BoundingBox.Height.Value;
          }
        }
        Positioner breakableElement = this.FindNextBreakableElement();
        if (breakableElement == this)
        {
          if (!breakableElement.IsBreakable && this.DoesNotFitContentArea(bottomMargin, contentAreaBottom))
            return (Positioner) this;
          if (this.parent is SubFormPositioner && this.IsBreakable && !this.DoesNotFitContentArea(bottomMargin, contentAreaBottom))
          {
            Positioner positioner = ((SubFormPositioner) this.parent).CheckKeepPreviousForChildPositioner(this.parent.Children.IndexOf((Positioner) this) + 1);
            if (positioner != null && !positioner.IsBreakable && positioner is SubFormPositioner && positioner.DoesNotFitContentArea(bottomMargin, contentAreaBottom))
            {
              positioner.DoesNotFitContentArea(bottomMargin, contentAreaBottom);
              return (Positioner) this;
            }
          }
        }
        else
          return breakableElement is SubFormPositioner && ((SubFormPositioner) breakableElement).CheckBreakBeforeCondition(currentPageArea) ? (this.parent != this.flattenerContext.DomPositioner ? (Positioner) this : (Positioner) null) : (breakableElement.CheckOverflowing(parentBoundingBox, currentPageArea, breakableStatus, 0.0f) != null ? (Positioner) this : (Positioner) null);
      }
      xfaRectangle1 = (XFARectangle) parentBoundingBox.Clone();
      this.ApplyMargins(xfaRectangle1);
      if (this.parent != null)
        this.ApplyTransformationToRectangle(xfaRectangle1, true);
    }
    BreakConditions breakConditions = (BreakConditions) null;
    for (int index = 0; index < this.childElements.Count; ++index)
    {
      Positioner childElement = this.childElements[index];
      Positioner positioner = (Positioner) null;
      if (breakConditions != null && breakConditions.Evaluate())
        positioner = childElement;
      else if (!childElement.IsVisible() && !childElement.IsInvisible())
      {
        this.childElements.RemoveAt(index);
        --index;
        if (!childElement.IsHidden() && !childElement.IsInactive() && childElement is SubFormPositioner && ((SubFormPositioner) childElement).CheckBreakBeforeCondition(currentPageArea))
          positioner = childElement;
        else
          continue;
      }
      else if (xfaRectangle1 != null)
      {
        if (childElement is SubFormPositioner)
          breakConditions = ((SubFormPositioner) childElement).FirstBreakAfter;
        positioner = childElement.CheckOverflowing(xfaRectangle1, currentPageArea, this.IsBreakable, 0.0f);
      }
      if (positioner != null)
      {
        if (childElement == positioner)
        {
          positioner = this.FindHighestNeighbour(childElement);
          XFARectangle xfaRectangle2 = xfaRectangle1;
          float? ury1 = xfaRectangle1.Ury;
          float? ury2 = positioner.GetBBox().Ury;
          float? nullable = ury1.HasValue & ury2.HasValue ? new float?(ury1.GetValueOrDefault() - ury2.GetValueOrDefault()) : new float?();
          xfaRectangle2.Height = nullable;
        }
        if (this.parent != null)
          this.ApplyTransformationToRectangle(xfaRectangle1);
        parentBoundingBox.Ury = xfaRectangle1.Ury;
        this.UnapplyMargins(xfaRectangle1);
        XFARectangle xfaRectangle3 = parentBoundingBox;
        float? ury3 = parentBoundingBox.Ury;
        float? ury4 = xfaRectangle1.Ury;
        float? nullable1 = ury3.HasValue & ury4.HasValue ? new float?(ury3.GetValueOrDefault() - ury4.GetValueOrDefault()) : new float?();
        float? height = xfaRectangle1.Height;
        float? nullable2 = nullable1.HasValue & height.HasValue ? new float?(nullable1.GetValueOrDefault() + height.GetValueOrDefault()) : new float?();
        xfaRectangle3.Height = nullable2;
        return positioner;
      }
      if (!childElement.IsEmpty())
        return (Positioner) null;
      this.childElements.RemoveAt(index);
      --index;
      while (index < -1)
        ++index;
      if (this.flattenerContext.DomPositioner == this && LayoutManager.tblrLayout.Equals(this.GetLayout()))
      {
        XFARectangle rectangle = (XFARectangle) childElement.contentArea.Clone();
        childElement.UnapplyMargins(rectangle);
        this.Move(-rectangle.Width.Value, 0.0f);
      }
    }
    this.isEmpty = !this.IsBackgroundOrBorderExist;
    return (Positioner) null;
  }

  private Positioner CheckKeepPreviousForChildPositioner(int startFrom)
  {
    int count = this.Children.Count;
    for (int index = startFrom; index < count; ++index)
    {
      Positioner child = this.Children[index];
      if (!child.IsHidden() && !child.IsInactive())
      {
        KeepConditions keepConditions = child.KeepConditions;
        if (keepConditions != null && !"none".Equals(keepConditions.Previous))
          return child;
        return child is SubFormPositioner ? ((SubFormPositioner) child).CheckKeepPreviousForChildPositioner(0) : (Positioner) null;
      }
    }
    return this.parent is SubFormPositioner ? ((SubFormPositioner) this.parent).CheckKeepPreviousForChildPositioner(this.parent.Children.IndexOf((Positioner) this) + 1) : (Positioner) null;
  }

  private void PropagateBreakConditions()
  {
    this.breakConditions = (BreakConditions) null;
    if (this.breakBefore == null || this.breakBefore.Count <= 0)
      return;
    this.breakConditions = this.breakBefore.First.Value;
    this.breakBefore.RemoveFirst();
  }

  public override Positioner Position(
    PdfContentByte parentCanvas,
    XFARectangle parentBoundingBox,
    PageArea currentPageArea,
    bool breakableStatus,
    float bottomMargin)
  {
    if (this.IsInvisible() && !(parentCanvas is PdfCanvasForInvisibleElements))
      parentCanvas = (PdfContentByte) new PdfCanvasForInvisibleElements(this.flattenerContext);
    Positioner overflowPositioner = this.CheckOverflowing(parentBoundingBox, currentPageArea, breakableStatus, bottomMargin);
    if (overflowPositioner != null)
    {
      overflowPositioner.AddOverflowedPageContentArea(currentPageArea);
      return overflowPositioner;
    }
    if (this.IsEmpty())
      return (Positioner) null;
    this.flattenerContext.CurrentNode = (Positioner) this;
    if (this.childElements.Count > 0)
    {
      this.SavePosState(parentCanvas);
      string layout = this.GetLayout();
      PdfContentByte pdfContentByte = (PdfContentByte) null;
      Comparer<Positioner> comparator = (Comparer<Positioner>) null;
      if (LayoutManager.positionLayout.Equals(layout))
        comparator = (Comparer<Positioner>) new Positioner.PositionedLayoutComparator();
      else if (LayoutManager.rowLayout.Equals(layout))
        comparator = (Comparer<Positioner>) new Positioner.RowLayoutComparator();
      if (comparator != null)
      {
        if (this.canvases == null)
        {
          this.canvases = new List<PdfContentByte>();
          this.PopulateCanvases(parentCanvas);
          if (this.flattenerContext.DomPositioner != this)
            SortUtil.MergeSort<Positioner>(this.childElements, new Comparison<Positioner>(comparator.Compare));
          if (LayoutManager.positionLayout.Equals(layout))
            this.SortPositionLayout(this.childElements, comparator);
        }
        else
        {
          foreach (PdfContentByte canvase in this.canvases)
            canvase.InheritGraphicState(parentCanvas);
        }
      }
      else
        pdfContentByte = this.IsBackgroundOrBorderExist ? parentCanvas.GetDuplicate(true) : parentCanvas;
      XFARectangle xfaRectangle1 = (XFARectangle) null;
      XFARectangle parentBoundingBox1 = (XFARectangle) null;
      if (parentBoundingBox != null)
      {
        xfaRectangle1 = (XFARectangle) parentBoundingBox.Clone();
        parentBoundingBox1 = (XFARectangle) parentBoundingBox.Clone();
        this.ApplyMargins(xfaRectangle1);
        if (this.parent != null)
          this.ApplyTransformationToRectangle(xfaRectangle1, true);
      }
      BreakConditions breakCondition = (BreakConditions) null;
      HashSet2<PdfContentByte> hashSet2 = new HashSet2<PdfContentByte>();
      int num1 = 0;
      IList<Positioner> positionerList = (IList<Positioner>) new List<Positioner>();
      while (num1 < this.childElements.Count)
      {
        Positioner childElement1 = this.childElements[num1++];
        if (breakCondition != null && this.CheckBreakBeforeCondition(breakCondition, currentPageArea) && !childElement1.IsHidden())
        {
          overflowPositioner = childElement1;
          overflowPositioner.BreakConditions = breakCondition;
          overflowPositioner.AddOverflowedPageContentArea(currentPageArea);
          break;
        }
        if (!childElement1.IsVisible() && !childElement1.IsInvisible())
        {
          this.childElements.RemoveAt(--num1);
          if (!childElement1.IsHidden() && !childElement1.IsInactive() && childElement1 is SubFormPositioner && ((SubFormPositioner) childElement1).CheckBreakBeforeCondition(currentPageArea))
          {
            overflowPositioner = childElement1;
            ((SubFormPositioner) childElement1).PropagateBreakConditions();
          }
          else
            continue;
        }
        else
          overflowPositioner = childElement1.Position(pdfContentByte ?? childElement1.canvas, xfaRectangle1, currentPageArea, this.IsBreakable, this.childElements[this.childElements.Count - 1] == childElement1 ? this.GetBottomInset() + bottomMargin : 0.0f);
        if (overflowPositioner != null)
        {
          if (this.flattenerContext.DomPositioner == this && LayoutManager.tblrLayout.Equals(this.GetLayout()) && childElement1 == overflowPositioner)
          {
            XFARectangle rectangle = (XFARectangle) childElement1.contentArea.Clone();
            childElement1.UnapplyMargins(rectangle);
            this.Move(-rectangle.Llx.Value, 0.0f);
          }
          float? nullable1 = overflowPositioner.GetBBox().Ury;
          Positioner positioner1 = (Positioner) null;
          if (childElement1 == overflowPositioner && overflowPositioner.positionState == PositionResult.State.NO_CONTENT)
            positioner1 = overflowPositioner;
          if (childElement1.canvas != null)
            hashSet2.Add(childElement1.canvas);
          while (num1 < this.childElements.Count)
          {
            Positioner childElement2 = this.childElements[num1++];
            if (childElement2.IsVisible() || childElement2.IsInvisible())
            {
              float b = childElement2.GetBBox().Ury.Value;
              if (XFAUtil.Lt(nullable1.Value, b) && this != this.flattenerContext.DomPositioner)
              {
                XFARectangle parentBoundingBox2 = (XFARectangle) xfaRectangle1.Clone();
                Positioner positioner2 = childElement2.Position(pdfContentByte ?? childElement2.canvas, parentBoundingBox2, currentPageArea, this.IsBreakable, 0.0f);
                float num2 = Math.Min(xfaRectangle1.Ury.Value - xfaRectangle1.Height.Value, parentBoundingBox2.Ury.Value - parentBoundingBox2.Height.Value);
                XFARectangle xfaRectangle2 = xfaRectangle1;
                float? ury = xfaRectangle1.Ury;
                float num3 = num2;
                float? nullable2 = ury.HasValue ? new float?(ury.GetValueOrDefault() - num3) : new float?();
                xfaRectangle2.Height = nullable2;
                if (positioner2 != null)
                {
                  float num4 = positioner2.GetBBox().Ury.Value;
                  if (XFAUtil.Lt(nullable1.Value, num4))
                  {
                    if (overflowPositioner.positionState == PositionResult.State.CONTENT_PART && positioner2.positionState == PositionResult.State.FULL_CONTENT)
                    {
                      positioner2.AdjustContentAreaUry(nullable1.Value);
                    }
                    else
                    {
                      nullable1 = new float?(num4);
                      if (overflowPositioner.positionState == PositionResult.State.FULL_CONTENT)
                        overflowPositioner.AdjustContentAreaUry(nullable1.Value);
                      overflowPositioner = positioner2;
                    }
                  }
                  else
                  {
                    if (overflowPositioner.positionState == PositionResult.State.FULL_CONTENT)
                    {
                      overflowPositioner.AdjustContentAreaUry(num4);
                      nullable1 = new float?(num4);
                    }
                    else
                      positioner2.AdjustContentAreaUry(nullable1.Value);
                    if (positioner2 == childElement2 && positioner2.positionState == PositionResult.State.NO_CONTENT)
                      positioner1 = childElement2;
                  }
                  if (childElement2.canvas != null)
                    hashSet2.Add(childElement2.canvas);
                }
                else
                {
                  XFARectangle bbox = childElement2.GetBBox();
                  if (xfaRectangle1 != null && XFAUtil.Lt(bbox.Ury.Value - bbox.Height.Value, xfaRectangle1.Ury.Value - xfaRectangle1.Height.Value))
                    positionerList.Add(childElement2);
                  else
                    this.childElements.RemoveAt(--num1);
                  if (childElement2.canvas != null)
                    hashSet2.Add(childElement2.canvas);
                }
              }
            }
          }
          foreach (Positioner positioner3 in (IEnumerable<Positioner>) positionerList)
            positioner3.AdjustContentAreaUry(nullable1.Value);
          if (positioner1 != null)
          {
            XFARectangle xfaRectangle3 = xfaRectangle1;
            float? ury1 = xfaRectangle1.Ury;
            float? ury2 = positioner1.GetBBox().Ury;
            float? nullable3 = ury1.HasValue & ury2.HasValue ? new float?(ury1.GetValueOrDefault() - ury2.GetValueOrDefault()) : new float?();
            xfaRectangle3.Height = nullable3;
          }
          if (this.parent != null)
            this.ApplyTransformationToRectangle(xfaRectangle1);
          parentBoundingBox.Ury = xfaRectangle1.Ury;
          this.UnapplyMargins(xfaRectangle1);
          XFARectangle xfaRectangle4 = parentBoundingBox;
          float? ury3 = parentBoundingBox.Ury;
          float? ury4 = xfaRectangle1.Ury;
          float? nullable4 = ury3.HasValue & ury4.HasValue ? new float?(ury3.GetValueOrDefault() - ury4.GetValueOrDefault()) : new float?();
          float? height = xfaRectangle1.Height;
          float? nullable5 = nullable4.HasValue & height.HasValue ? new float?(nullable4.GetValueOrDefault() + height.GetValueOrDefault()) : new float?();
          xfaRectangle4.Height = nullable5;
          this.UpdateOverflowedBreakCondition(overflowPositioner);
          if (breakCondition != null && overflowPositioner.BreakConditions == null)
          {
            overflowPositioner.BreakConditions = breakCondition;
            break;
          }
          break;
        }
        BreakConditions other = (BreakConditions) null;
        if (childElement1 is SubFormPositioner && ((SubFormPositioner) childElement1).FirstBreakAfter != null && ((SubFormPositioner) childElement1).FirstBreakAfter.Evaluate())
        {
          other = ((SubFormPositioner) childElement1).FirstBreakAfter;
          breakCondition = other;
        }
        XFARectangle bbox1 = childElement1.GetBBox();
        if (xfaRectangle1 != null && XFAUtil.Lt(bbox1.Ury.Value - bbox1.Height.Value, xfaRectangle1.Ury.Value - xfaRectangle1.Height.Value))
        {
          positionerList.Add(childElement1);
          if (childElement1.canvas != null)
            hashSet2.Add(childElement1.canvas);
        }
        else
        {
          this.childElements.RemoveAt(--num1);
          if (childElement1 is SubFormPositioner && num1 >= this.childElements.Count && other != null)
          {
            ((SubFormPositioner) childElement1).breakAfter.RemoveFirst();
            this.breakAfter.AddFirst(new BreakConditions(other, this));
          }
        }
      }
      positionerList.Clear();
      if (parentBoundingBox1 != null)
      {
        XFARectangle xfaRectangle5 = parentBoundingBox1;
        float? ury5 = parentBoundingBox1.Ury;
        float? ury6 = parentBoundingBox.Ury;
        float? nullable6 = ury5.HasValue & ury6.HasValue ? new float?(ury5.GetValueOrDefault() - ury6.GetValueOrDefault()) : new float?();
        float? height = parentBoundingBox.Height;
        float? nullable7 = nullable6.HasValue & height.HasValue ? new float?(nullable6.GetValueOrDefault() + height.GetValueOrDefault()) : new float?();
        xfaRectangle5.Height = nullable7;
      }
      if (this.overflowConditions != null && this.overflowConditions.GetCurrentTrailer() != null && this.overflowConditions.GetCurrentTrailer().BoundingBox != null)
      {
        XFARectangle xfaRectangle6 = parentBoundingBox1;
        float? height1 = parentBoundingBox1.Height;
        float? height2 = this.overflowConditions.GetCurrentTrailer().BoundingBox.Height;
        float? nullable = height1.HasValue & height2.HasValue ? new float?(height1.GetValueOrDefault() + height2.GetValueOrDefault()) : new float?();
        xfaRectangle6.Height = nullable;
      }
      this.RestorePosState(parentCanvas);
      this.DrawBorder(parentCanvas, parentBoundingBox1);
      this.SavePosState(parentCanvas);
      if (pdfContentByte == null)
      {
        for (int index = 0; index < this.canvases.Count; ++index)
        {
          PdfContentByte canvase = this.canvases[index];
          if (canvase.InternalBuffer.Size > 0)
          {
            parentCanvas.Add(canvase);
            canvase.Reset(false);
            if (overflowPositioner != null && !hashSet2.Contains(canvase))
            {
              this.canvases.RemoveAt(index);
              --index;
            }
          }
        }
        if (overflowPositioner == null)
        {
          this.canvases.Clear();
          this.canvases = (List<PdfContentByte>) null;
          this.canvas = (PdfContentByte) null;
        }
      }
      else if (this.IsBackgroundOrBorderExist)
        parentCanvas.Add(pdfContentByte);
      this.RestorePosState(parentCanvas);
    }
    else if (this.IsBackgroundOrBorderExist)
      this.DrawBorder(parentCanvas, parentBoundingBox);
    this.flattenerContext.CurrentNode = this.parent;
    this.positionState = overflowPositioner != null ? PositionResult.State.CONTENT_PART : PositionResult.State.FULL_CONTENT;
    this.UpdatePageNumbers();
    return overflowPositioner;
  }

  protected virtual void PopulateCanvases(PdfContentByte parentCanvas)
  {
    foreach (Positioner childElement in this.childElements)
    {
      if ((childElement.IsVisible() || childElement.IsInvisible()) && childElement.canvas == null)
      {
        childElement.canvas = parentCanvas.GetDuplicate(true);
        this.canvases.Add(childElement.canvas);
      }
    }
  }

  protected virtual void AddInternalBox(XFARectangle internalBox)
  {
    this.internalBoxes.Add(internalBox);
  }

  protected override void AdjustContentArea()
  {
    float num1 = this.GetLargestUrx().Value - this.contentArea.Llx.Value;
    float? minW = this.contentArea.MinW;
    if (minW.HasValue)
    {
      float num2 = num1;
      float? nullable = minW;
      if (((double) num2 >= (double) nullable.GetValueOrDefault() ? 0 : (nullable.HasValue ? 1 : 0)) != 0)
        num1 = minW.Value;
    }
    if (!this.contentArea.Width.HasValue)
      this.contentArea.Width = new float?(num1);
    string layout = this.GetLayout();
    if (LayoutManager.rowLayout.Equals(layout))
    {
      this.AdjustContentAreaHeight(this.GetMaxBoxHeight());
    }
    else
    {
      if (!LayoutManager.tbLayout.Equals(layout) && !LayoutManager.tblrLayout.Equals(layout) && this.contentArea.Height.HasValue)
        return;
      float num3 = this.contentArea.Ury.Value - this.GetLowestLly().Value;
      if (this.contentArea.Height.HasValue)
      {
        float num4 = num3;
        float? height = this.contentArea.Height;
        if (((double) num4 <= (double) height.GetValueOrDefault() ? 0 : (height.HasValue ? 1 : 0)) == 0)
          return;
      }
      this.contentArea.Height = new float?(num3);
    }
  }

  public override void AdjustContentAreaHeight(float newHeight)
  {
    base.AdjustContentAreaHeight(newHeight);
    string layout = this.GetLayout();
    if (!LayoutManager.rowLayout.Equals(layout))
      return;
    foreach (Positioner childElement in this.childElements)
    {
      if (!childElement.IsHidden() && !childElement.IsInactive())
        childElement.AdjustContentAreaHeight(newHeight);
    }
  }

  public override void Relayout(bool forceLayout)
  {
    bool forceLayout1 = this.layoutOutOfDate || forceLayout;
    if (forceLayout1)
    {
      this.internalBoxes.Clear();
      this.transformation = new AffineTransform();
      this.InitContentArea(new float?(), new float?());
      this.ApplyMargins(this.contentArea);
    }
    bool flag = false;
    foreach (Positioner childElement in this.childElements)
    {
      if (!childElement.IsHidden() && !childElement.IsInactive())
      {
        flag = flag || childElement.LayoutOutOfDate;
        childElement.Relayout(forceLayout1);
        if (forceLayout1)
          this.AddInternalBox(childElement.GetBBox());
      }
    }
    if (forceLayout1)
    {
      if (this.isEmpty)
      {
        foreach (Positioner childElement in this.childElements)
        {
          if (!childElement.IsHidden() && !childElement.IsInactive() && !childElement.IsEmpty())
          {
            this.isEmpty = false;
            break;
          }
        }
      }
      this.AdjustLayout();
    }
    else if (flag && LayoutManager.rowLayout.Equals(this.GetLayout()))
      this.AdjustContentArea();
    this.layoutOutOfDate = false;
  }

  public virtual void ApplyAlignment()
  {
    Tag child = this.template.GetChild("para", "", false);
    for (int index1 = 0; index1 < this.childElements.Count; ++index1)
    {
      Positioner childElement1 = this.childElements[index1];
      if (!childElement1.IsHidden() && !childElement1.IsInactive())
      {
        Tag tag = child ?? (Tag) childElement1.Template;
        if (tag != null)
        {
          IDictionary<string, string> attributes = tag.Attributes;
          string layout = this.GetLayout();
          bool flag1 = LayoutManager.tblrLayout.Equals(layout) || LayoutManager.tbLayout.Equals(layout) || LayoutManager.rowLayout.Equals(layout);
          bool flag2 = layout.Equals(LayoutManager.tbLayout) || layout.Equals(LayoutManager.tblrLayout);
          if (this.contentArea.Height.HasValue && childElement1.contentArea.Height.HasValue && flag2)
          {
            string str;
            if (!attributes.TryGetValue("vAlign", out str) && tag != childElement1.Template)
              childElement1.Template.Attributes.TryGetValue("vAlign", out str);
            if ("middle".Equals(str))
            {
              this.InitInternalBBox();
              childElement1.ApplyTranslation(0.0f, (float) (-((double) this.contentArea.Height.Value - (double) this.internalBBox.Height.Value) / 2.0));
            }
            else if ("bottom".Equals(str))
            {
              this.InitInternalBBox();
              childElement1.ApplyTranslation(0.0f, (float) -((double) this.contentArea.Height.Value - (double) this.internalBBox.Height.Value));
            }
          }
          if (this.contentArea.Width.HasValue && childElement1.contentArea.Width.HasValue && flag1)
          {
            string str;
            if (!attributes.TryGetValue("hAlign", out str) && tag != childElement1.Template)
              childElement1.Template.Attributes.TryGetValue("hAlign", out str);
            if ("center".Equals(str))
            {
              this.InitInternalBBox();
              childElement1.ApplyTranslation((float) (((double) this.contentArea.Width.Value - (double) this.internalBBox.Width.Value) / 2.0), 0.0f);
            }
            else if ("right".Equals(str))
            {
              if (LayoutManager.tbLayout.Equals(this.GetLayout()))
                childElement1.ApplyTranslation(this.contentArea.Width.Value - childElement1.GetBBox().Width.Value, 0.0f);
              else if (LayoutManager.tblrLayout.Equals(this.GetLayout()))
              {
                float num1 = 0.0f;
                XFARectangle bbox1 = childElement1.GetBBox();
                XFARectangle bbox2 = this.GetBBox();
                List<Positioner> positionerList = new List<Positioner>();
                float num2 = bbox1.Llx.Value - bbox2.Llx.Value;
                for (int index2 = index1; index2 < this.childElements.Count; ++index2)
                {
                  Positioner childElement2 = this.childElements[index2];
                  if (childElement2.contentArea != null && !childElement2.IsHidden() && !childElement2.IsInactive())
                  {
                    XFARectangle bbox3 = childElement2.GetBBox();
                    if ((double) num2 + (double) num1 + (double) bbox3.Width.Value <= (double) bbox2.Width.Value + 0.001)
                    {
                      num1 += bbox3.Width.Value;
                      positionerList.Add(childElement2);
                    }
                    else
                      break;
                  }
                }
                float xtr = bbox2.Width.Value - num2 - num1;
                if (positionerList.Count > 0)
                {
                  foreach (Positioner positioner in positionerList)
                    positioner.ApplyTranslation(xtr, 0.0f);
                }
                else
                {
                  this.InitInternalBBox();
                  childElement1.ApplyTranslation(this.contentArea.Width.Value - this.internalBBox.Width.Value, 0.0f);
                }
              }
              else
              {
                this.InitInternalBBox();
                childElement1.ApplyTranslation(this.contentArea.Width.Value - this.internalBBox.Width.Value, 0.0f);
              }
            }
          }
        }
      }
    }
  }

  public virtual BreakConditions BreakOverflow
  {
    get => this.breakOverflow;
    set => this.breakOverflow = value;
  }

  public virtual BreakConditions FirstBreakAfter
  {
    get
    {
      return this.breakAfter == null || this.breakAfter.Count <= 0 ? (BreakConditions) null : this.breakAfter.First.Value;
    }
  }

  private float? GetLargestUrx()
  {
    float? largestUrx = new float?();
    float? width1 = this.contentArea.Width;
    if (width1.HasValue)
    {
      float? llx = this.contentArea.Llx;
      float? nullable = width1;
      largestUrx = llx.HasValue & nullable.HasValue ? new float?(llx.GetValueOrDefault() + nullable.GetValueOrDefault()) : new float?();
    }
    foreach (XFARectangle internalBox in (IEnumerable<XFARectangle>) this.internalBoxes)
    {
      float? width2 = internalBox.Width;
      if (width2.HasValue)
      {
        float num1 = internalBox.Llx.Value + width2.Value;
        if (!largestUrx.HasValue)
        {
          largestUrx = new float?(num1);
        }
        else
        {
          float num2 = num1;
          float? nullable = largestUrx;
          if (((double) num2 <= (double) nullable.GetValueOrDefault() ? 0 : (nullable.HasValue ? 1 : 0)) != 0)
            largestUrx = new float?(num1);
        }
      }
    }
    if (!largestUrx.HasValue)
      largestUrx = this.contentArea.Llx;
    return largestUrx;
  }

  private float? GetLowestLly()
  {
    float? lowestLly = new float?();
    float? height1 = this.contentArea.Height;
    if (height1.HasValue)
    {
      float? ury = this.contentArea.Ury;
      float? nullable = height1;
      lowestLly = ury.HasValue & nullable.HasValue ? new float?(ury.GetValueOrDefault() - nullable.GetValueOrDefault()) : new float?();
    }
    foreach (XFARectangle internalBox in (IEnumerable<XFARectangle>) this.internalBoxes)
    {
      float? height2 = internalBox.Height;
      if (height2.HasValue)
      {
        float num1 = internalBox.Ury.Value - height2.Value;
        if (!lowestLly.HasValue)
        {
          lowestLly = new float?(num1);
        }
        else
        {
          float num2 = num1;
          float? nullable = lowestLly;
          if (((double) num2 >= (double) nullable.GetValueOrDefault() ? 0 : (nullable.HasValue ? 1 : 0)) != 0)
            lowestLly = new float?(num1);
        }
      }
    }
    if (!lowestLly.HasValue)
      lowestLly = new float?(this.contentArea.Ury.Value);
    return lowestLly;
  }

  private float GetMaxBoxHeight()
  {
    float maxBoxHeight = 0.0f;
    if (this.internalBoxes != null)
    {
      foreach (XFARectangle internalBox in (IEnumerable<XFARectangle>) this.internalBoxes)
      {
        float? height = internalBox.Height;
        float num = maxBoxHeight;
        if (((double) height.GetValueOrDefault() <= (double) num ? 0 : (height.HasValue ? 1 : 0)) != 0)
          maxBoxHeight = internalBox.Height.Value;
      }
    }
    return maxBoxHeight;
  }

  public virtual bool CheckBreakBeforeCondition(PageArea currentPageArea)
  {
    if (this.breakBefore != null && this.breakBefore.Count > 0)
    {
      if (this.CheckBreakBeforeCondition(this.breakBefore.First.Value, currentPageArea))
        return true;
      this.BreakConditions = this.breakBefore.First.Value;
      this.breakBefore.RemoveFirst();
    }
    return false;
  }

  public virtual bool CheckBreakBeforeCondition(
    BreakConditions breakCondition,
    PageArea currentPageArea)
  {
    if (breakCondition != null && breakCondition.Evaluate())
    {
      if (breakCondition.StartNew)
      {
        if (breakCondition.Target == null || this.flattenerContext.PageSet.SearchNode(breakCondition.Target, false) != null)
          return true;
      }
      else if (currentPageArea != null)
      {
        string type = breakCondition.Type;
        string target = breakCondition.Target;
        if (type != null && target != null)
        {
          if (Util.EqualsIgnoreCase("pageArea", type))
          {
            if (target.StartsWith("#"))
            {
              string templateId = currentPageArea.GetTemplateId();
              if (templateId == null || !Util.EqualsIgnoreCase("#" + templateId, target))
                return true;
            }
            else
            {
              JsTree jsTree = this.flattenerContext.PageSet.SearchNodeDown(target);
              if (jsTree is PageArea && ((Positioner) jsTree).Template != currentPageArea.Template)
                return true;
            }
          }
          else if (Util.EqualsIgnoreCase("contentArea", type))
          {
            ContentArea currentContentArea = currentPageArea.CurrentContentArea;
            if (currentContentArea == null)
              return true;
            if (target.StartsWith("#"))
            {
              string id = currentContentArea.Id;
              if (id == null || !Util.EqualsIgnoreCase("#" + id, target))
                return true;
            }
            else
            {
              JsTree jsTree = this.flattenerContext.PageSet.SearchNodeDown(target);
              if (jsTree is ContentArea && ((ContentArea) jsTree).Template != currentContentArea.Template)
                return true;
            }
          }
        }
        else if (type != null)
          return true;
      }
    }
    return false;
  }

  private Positioner FindHighestNeighbour(Positioner breakedPositioner)
  {
    float a = breakedPositioner.GetBBox().Ury.Value;
    for (int index = this.childElements.IndexOf(breakedPositioner) + 1; index < this.childElements.Count; ++index)
    {
      Positioner childElement = this.childElements[index];
      if (!childElement.IsHidden() && !childElement.IsInactive())
      {
        float b = childElement.GetBBox().Ury.Value;
        if (XFAUtil.Lt(a, b))
        {
          a = b;
          breakedPositioner = childElement;
        }
      }
    }
    return breakedPositioner;
  }

  public override bool IsBreakable
  {
    get
    {
      string layout1 = this.GetLayout();
      if (this.keepConditions != null)
        return this.keepConditions.Intact.Equals("none");
      if (LayoutManager.positionLayout.Equals(layout1) || LayoutManager.rowLayout.Equals(layout1))
        return this.parent == null;
      if (!LayoutManager.tbLayout.Equals(layout1) && !LayoutManager.tblrLayout.Equals(layout1) || this.parent == null || this.parent.Parent == null)
        return true;
      string layout2 = this.parent.GetLayout();
      return !LayoutManager.positionLayout.Equals(layout2);
    }
  }

  private void UpdateOverflowedBreakCondition(Positioner overflowPositioner)
  {
    if (overflowPositioner.BreakConditions == null)
    {
      overflowPositioner.BreakConditions = this.breakOverflow;
    }
    else
    {
      if (this.breakOverflow == null || overflowPositioner.BreakConditions.Target != null)
        return;
      overflowPositioner.BreakConditions.Target = this.BreakOverflow.Target;
    }
  }

  private void InitInternalBBox()
  {
    if (this.internalBBox != null)
      return;
    this.internalBBox = XFARectangle.GetCommonRectangle(this.internalBoxes);
  }

  private bool NonBreakablePositionerBBoxContains(Positioner a, Positioner b)
  {
    return a.contentArea != null && b.contentArea != null && a.contentArea.Contains(b.contentArea);
  }

  private void SortPositionLayout(List<Positioner> childElements, Comparer<Positioner> comparator)
  {
    List<Positioner> collection = new List<Positioner>();
    bool[] flagArray = new bool[childElements.Count];
    for (int index1 = 0; index1 < childElements.Count; ++index1)
    {
      if (!flagArray[index1])
      {
        Positioner childElement = childElements[index1];
        for (int index2 = index1 + 1; index2 < childElements.Count; ++index2)
        {
          if (!flagArray[index2] && !childElements[index2].IsBreakable && this.NonBreakablePositionerBBoxContains(childElements[index2], childElement))
          {
            collection.Add(childElements[index2]);
            flagArray[index2] = true;
          }
        }
        collection.Add(childElements[index1]);
        flagArray[index1] = true;
      }
    }
    childElements.Clear();
    childElements.AddRange((IEnumerable<Positioner>) collection);
  }

  protected override bool SupportLegacyPlusPrint => true;
}
