// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.js.JsOccur
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.tool.xml.xtra.xfa.positioner;
using iTextSharp.tool.xml.xtra.xfa.tags;
using Jint.Delegates;
using Jint.Native;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.js;

public class JsOccur : JsNode
{
  private XFATemplateTag templateTag;

  internal JsOccur(JsTree prototype, string className = "occur")
    : base(prototype, className)
  {
    this.DefineOwnProperty((Descriptor) new PropertyDescriptor<JsOccur>((Jint.Native.IGlobal) this.IGlobal, (JsDictionaryObject) this, "min", new JintFunc<JsOccur, JsInstance>(this.MinJsPropGet), new JintFunc<JsOccur, JsInstance[], JsInstance>(this.MinJsPropSet)));
    this.DefineOwnProperty((Descriptor) new PropertyDescriptor<JsOccur>((Jint.Native.IGlobal) this.IGlobal, (JsDictionaryObject) this, "max", new JintFunc<JsOccur, JsInstance>(this.MaxJsPropGet), new JintFunc<JsOccur, JsInstance[], JsInstance>(this.MaxJsPropSet)));
  }

  public JsOccur(Positioner parent)
    : base((JsNode) parent, (JsNode) parent.IGlobal.JintJsXfaElementConstructor.OccurJsObject)
  {
    this.templateTag = parent.Tag is XFATemplateTag ? (XFATemplateTag) parent.Tag : (XFATemplateTag) null;
  }

  public virtual int? Min
  {
    get => this.templateTag == null ? new int?() : new int?(this.templateTag.MinOccur);
    set
    {
      if (this.templateTag == null || !value.HasValue)
        return;
      this.templateTag.MinOccur = value.Value;
    }
  }

  private JsInstance MinJsPropGet(JsOccur target)
  {
    return (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, (object) target.Min);
  }

  private JsInstance MinJsPropSet(JsOccur target, JsInstance[] param)
  {
    int integer = param[0].ToInteger();
    target.Min = new int?(integer);
    return (JsInstance) JsNull.Instance;
  }

  public virtual int? Max
  {
    get => this.templateTag == null ? new int?() : new int?(this.templateTag.MaxOccur);
    set
    {
      if (this.templateTag == null || !value.HasValue)
        return;
      this.templateTag.MaxOccur = value.Value;
    }
  }

  private JsInstance MaxJsPropGet(JsOccur target)
  {
    return (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, (object) target.Max);
  }

  private JsInstance MaxJsPropSet(JsOccur target, JsInstance[] param)
  {
    int integer = param[0].ToInteger();
    target.Max = new int?(integer);
    return (JsInstance) JsNull.Instance;
  }
}
