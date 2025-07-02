// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.js.JsValueNode
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.tool.xml.xtra.xfa.positioner;
using Jint.Native;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.js;

internal class JsValueNode : JsNode
{
  internal JsValueNode(string className, JsNode prototype)
    : base((JsTree) prototype, className)
  {
  }

  public JsValueNode(Tag tag, JsNode parrent)
    : base(tag, parrent, "value")
  {
  }

  protected override void PutCallback(string name, JsInstance value)
  {
    base.PutCallback(name, value);
    if (!name.Equals("text"))
      return;
    if (this.GetParentNode() is ContentPositioner && value is JsContent)
    {
      ((Positioner) this.GetParentNode()).SetRawValue((object) ((JsNode) value).RetrieveValue());
    }
    else
    {
      if (!(this.GetParentNode() is ContentPositioner) || !(value is JsString))
        return;
      this[name] = (JsInstance) new JsContent("text", (JsNode) this, (JsNode) this.IGlobal.JintJsXfaElementConstructor.TextJsObject, ((JsString) value).ToString());
    }
  }
}
