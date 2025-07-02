// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.js.JsEvent
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.tool.xml.xtra.xfa.resolver;
using Jint.Delegates;
using Jint.Native;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.js;

public class JsEvent : JsObject
{
  private IGlobal global;
  private JsDoc jsDoc;
  private FlattenerContext flattenerContext;

  public JsEvent(IGlobal global, FlattenerContext flattenerContext)
  {
    this.flattenerContext = flattenerContext;
    this.global = global;
    this.DefineOwnProperty("newText", (JsInstance) JintJsObject.Wrap(global, (object) ""));
    this.DefineOwnProperty((Descriptor) new PropertyDescriptor<JsEvent>(global, (JsDictionaryObject) this, "target", new JintFunc<JsEvent, JsInstance>(this.GetTarget)));
    this.DefineOwnProperty((Descriptor) new PropertyDescriptor<JsEvent>(global, (JsDictionaryObject) this, "change", new JintFunc<JsEvent, JsInstance>(this.GetChange)));
  }

  public virtual void SetNewText(string newText)
  {
    this.DefineOwnProperty(nameof (newText), (JsInstance) JintJsObject.Wrap(this.global, (object) newText));
  }

  public virtual JsObject GetTarget(JsEvent target)
  {
    if (this.jsDoc == null)
      this.jsDoc = new JsDoc(this.global, this.flattenerContext);
    return (JsObject) this.jsDoc;
  }

  public virtual JsObject GetChange(JsEvent target) => (JsObject) this.global.StringClass.New("");
}
