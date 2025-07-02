// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.js.JsForm
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using Jint.Delegates;
using Jint.Native;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.js;

public class JsForm : JsNode
{
  public JsForm(JsXfa xfa)
    : base("form", (JsNode) xfa)
  {
    this.DefineOwnProperty("createNode", (JsInstance) this.IGlobal.FunctionClass.New<JsDictionaryObject>(new JintFunc<JsDictionaryObject, JsInstance[], JsInstance>(this.CreateNode), 2), PropertyAttributes.DontDelete);
  }

  public override void AddChild(JsTree child)
  {
    if (child is JsInstanceManager)
      return;
    base.AddChild(child);
  }

  public JsNode CreateNode(JsDictionaryObject target, JsInstance[] parameters)
  {
    JsNode node = parameters[1] != null ? new JsNode(parameters[1].ToString(), (JsNode) null) : new JsNode((JsTree) null);
    node.DefineOwnProperty("className", parameters[0]);
    return node;
  }
}
