// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.positioner.ExclGroupPositioner
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.tool.xml.xtra.xfa.js;
using iTextSharp.tool.xml.xtra.xfa.resolver;
using iTextSharp.tool.xml.xtra.xfa.tags;
using Jint.Native;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.positioner;

public class ExclGroupPositioner : SubFormPositioner
{
  private ExclGroupValueResolver valueResolver;

  public ExclGroupPositioner(
    XFATemplateTag templateTag,
    DataTag dataTag,
    FlattenerContext flattenerContext,
    JsNode parent,
    string prototypeName = null)
    : base(templateTag, dataTag, flattenerContext, parent, prototypeName ?? "exclGroup")
  {
    this.SetRawValue((object) "");
    this.valueResolver = new ExclGroupValueResolver(this);
  }

  internal ExclGroupValueResolver ValueResolver => this.valueResolver;

  public override void DefineOwnProperty(Descriptor currentDescriptor)
  {
    if (this.valueResolver != null && "rawValue".Equals(currentDescriptor.Name) && currentDescriptor is ValueDescriptor && !this.valueResolver.PropagateValueFromParentToChildren(currentDescriptor.Get((JsDictionaryObject) this).Value))
      currentDescriptor.Set((JsDictionaryObject) this, (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, (object) ""));
    base.DefineOwnProperty(currentDescriptor);
  }

  public override JsInstance this[string name]
  {
    set
    {
      if (this.valueResolver != null && "rawValue".Equals(name) && !this.valueResolver.PropagateValueFromParentToChildren(value.Value))
        value = (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, (object) "");
      base[name] = value;
    }
  }

  protected override void InitMinWContentAreaProperty()
  {
    bool flag = true;
    foreach (JsNode childElement in this.childElements)
    {
      if (childElement.RetrieveAttribute("minW") == null)
        flag = false;
    }
    if (flag)
      return;
    base.InitMinWContentAreaProperty();
  }

  public override string ClassName => "exclGroup";

  public override bool IsBreakable => this.parent == null || this.parent.IsBreakable;
}
