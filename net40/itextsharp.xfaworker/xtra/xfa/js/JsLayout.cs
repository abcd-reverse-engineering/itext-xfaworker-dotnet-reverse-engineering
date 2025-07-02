// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.js.JsLayout
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.text.log;
using iTextSharp.tool.xml.css;
using iTextSharp.tool.xml.xtra.xfa.positioner;
using iTextSharp.tool.xml.xtra.xfa.resolver;
using iTextSharp.tool.xml.xtra.xfa.util;
using Jint.Delegates;
using Jint.Native;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.js;

public class JsLayout : JsObject
{
  private static readonly ILogger logger = LoggerFactory.GetLogger(typeof (XFAFlattener));
  private FlattenerContext flattenerContext;
  private IGlobal global;

  public JsLayout(IGlobal global, FlattenerContext flattenerContext)
  {
    this.flattenerContext = flattenerContext;
    this.global = global;
    this.DefineOwnProperty("absPage", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new JintFunc<JsDictionaryObject, JsInstance[], JsInstance>(this.AbsPage), 1), PropertyAttributes.ReadOnly);
    this.DefineOwnProperty("absPageSpan", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new JintFunc<JsDictionaryObject, JsInstance[], JsInstance>(this.AbsPageSpan), 1), PropertyAttributes.ReadOnly);
    this.DefineOwnProperty("h", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new JintFunc<JsDictionaryObject, JsInstance[], JsInstance>(this.H), 1), PropertyAttributes.ReadOnly);
    this.DefineOwnProperty("page", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new JintFunc<JsDictionaryObject, JsInstance[], JsInstance>(this.Page), 1), PropertyAttributes.ReadOnly);
    this.DefineOwnProperty("pageContent", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new JintFunc<JsDictionaryObject, JsInstance[], JsInstance>(this.PageContent), 0), PropertyAttributes.ReadOnly);
    this.DefineOwnProperty("pageCount", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new JintFunc<JsDictionaryObject, JsInstance[], JsInstance>(this.PageCount), 0), PropertyAttributes.ReadOnly);
    this.DefineOwnProperty("pageSpan", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new JintFunc<JsDictionaryObject, JsInstance[], JsInstance>(this.PageSpan), 0), PropertyAttributes.ReadOnly);
    this.DefineOwnProperty("sheet", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new JintFunc<JsDictionaryObject, JsInstance[], JsInstance>(this.Sheet), 1), PropertyAttributes.ReadOnly);
    this.DefineOwnProperty("sheetCount", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new JintFunc<JsDictionaryObject, JsInstance[], JsInstance>(this.SheetCount), 0), PropertyAttributes.ReadOnly);
    this.DefineOwnProperty("w", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new JintFunc<JsDictionaryObject, JsInstance[], JsInstance>(this.W), 1), PropertyAttributes.ReadOnly);
  }

  public virtual JsInstance PageCount(JsDictionaryObject target, JsInstance[] parameters)
  {
    return this.flattenerContext.PageCount.HasValue ? (JsInstance) this.global.NumberClass.New((double) this.flattenerContext.PageCount.Value) : (JsInstance) JsNull.Instance;
  }

  public virtual JsInstance SheetCount(JsDictionaryObject target, JsInstance[] parameters)
  {
    return (JsInstance) this.global.NumberClass.New((double) this.flattenerContext.SheetCount.Value);
  }

  public virtual JsInstance Page(JsDictionaryObject target, JsInstance[] parameters)
  {
    int? nullable1 = new int?();
    object parameter = (object) parameters[0];
    if (parameter is Positioner)
      nullable1 = ((Positioner) parameter).StartPageNumber;
    int? nullable2 = nullable1 ?? this.flattenerContext.CurrentPageNumber;
    return nullable2.HasValue ? (JsInstance) this.global.NumberClass.New((double) nullable2.Value) : (JsInstance) JsNull.Instance;
  }

  public virtual JsInstance Sheet(JsDictionaryObject target, JsInstance[] parameters)
  {
    int? nullable = new int?();
    object parameter = (object) parameters[0];
    if (parameter is Positioner)
      nullable = ((Positioner) parameter).StartSheetNumber;
    return (JsInstance) this.global.NumberClass.New((double) (nullable.HasValue ? new int?(nullable.Value) : this.flattenerContext.CurrentSheetNumber).Value - 1.0);
  }

  public virtual JsInstance AbsPage(JsDictionaryObject target, JsInstance[] parameters)
  {
    int? nullable1 = new int?();
    object parameter = (object) parameters[0];
    if (parameter is Positioner)
      nullable1 = ((Positioner) parameter).StartAbsPageNumber;
    int? nullable2 = nullable1 ?? this.flattenerContext.CurrentAbsPageNumber;
    return nullable2.HasValue ? (JsInstance) this.global.NumberClass.New((double) nullable2.Value) : (JsInstance) JsNull.Instance;
  }

  public virtual JsInstance PageSpan(JsDictionaryObject target, JsInstance[] parameters)
  {
    object parameter = (object) parameters[0];
    if (parameter is Positioner)
    {
      int? startPageNumber = ((Positioner) parameter).StartPageNumber;
      int? endPageNumber = ((Positioner) parameter).EndPageNumber;
      if (endPageNumber.HasValue && startPageNumber.HasValue)
        return (JsInstance) this.global.NumberClass.New((double) (endPageNumber.Value - startPageNumber.Value + 1));
    }
    return (JsInstance) this.global.NumberClass.New(parameter == null ? 1.0 : -1.0);
  }

  public virtual JsInstance AbsPageSpan(JsDictionaryObject target, JsInstance[] parameters)
  {
    object parameter = (object) parameters[0];
    if (parameter is Positioner)
    {
      int? startAbsPageNumber = ((Positioner) parameter).StartAbsPageNumber;
      int? endAbsPageNumber = ((Positioner) parameter).EndAbsPageNumber;
      if (endAbsPageNumber.HasValue && startAbsPageNumber.HasValue)
        return (JsInstance) this.global.NumberClass.New((double) (endAbsPageNumber.Value - startAbsPageNumber.Value + 1));
    }
    return (JsInstance) this.global.NumberClass.New(parameter == null ? 1.0 : -1.0);
  }

  public virtual JsInstance PageContent(JsDictionaryObject target, JsInstance[] parameters)
  {
    JsLayout.logger.Error("pageContent js function is not implemented");
    return (JsInstance) new JintJsNodeList(this.global);
  }

  public virtual JsInstance W(JsDictionaryObject target, JsInstance[] parameters)
  {
    object parameter = (object) parameters[0];
    object obj = (object) parameters[1].ToString();
    float? objectValue = new float?();
    if (parameter is JintJsNodeList)
      parameter = ((JintJsNodeList) parameter).GetItem(0);
    if (parameter is Positioner && ((Positioner) parameter).contentArea != null)
    {
      XFARectangle rectangle = (XFARectangle) ((Positioner) parameter).GetContentArea().Clone();
      ((Positioner) parameter).UnapplyMargins(rectangle);
      objectValue = rectangle.Width;
    }
    if (!objectValue.HasValue)
      objectValue = new float?(1f);
    if (!"pt".Equals(obj))
    {
      float num = 1f / CssUtils.GetInstance().ParsePxInCmMmPcToPt("1", obj.ToString());
      float? nullable = objectValue;
      objectValue = nullable.HasValue ? new float?(num * nullable.GetValueOrDefault()) : new float?();
    }
    return (JsInstance) JintJsObject.Wrap(this.global, (object) objectValue);
  }

  public virtual JsInstance H(JsDictionaryObject target, JsInstance[] parameters)
  {
    object parameter = (object) parameters[0];
    object obj = (object) parameters[1].ToString();
    float? objectValue = new float?();
    if (parameter is JintJsNodeList)
      parameter = ((JintJsNodeList) parameter).GetItem(0);
    if (parameter is Positioner && ((Positioner) parameter).contentArea != null)
    {
      XFARectangle rectangle = (XFARectangle) ((Positioner) parameter).GetContentArea().Clone();
      ((Positioner) parameter).UnapplyMargins(rectangle);
      objectValue = rectangle.Height;
    }
    if (!objectValue.HasValue)
      objectValue = new float?(1f);
    if (!"pt".Equals(obj))
    {
      float num = 1f / CssUtils.GetInstance().ParsePxInCmMmPcToPt("1", obj.ToString());
      float? nullable = objectValue;
      objectValue = nullable.HasValue ? new float?(num * nullable.GetValueOrDefault()) : new float?();
    }
    return (JsInstance) JintJsObject.Wrap(this.global, (object) objectValue);
  }
}
