// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.js.JsManifest
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.tool.xml.xtra.xfa.tags;
using Jint.Delegates;
using Jint.Native;
using System.Collections.Generic;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.js;

public class JsManifest : JsNode
{
  internal JsManifest(string className, JsNode prototype)
    : base((JsTree) prototype, className)
  {
    this.DefineOwnProperty("evaluate", (JsInstance) this.IGlobal.FunctionClass.New<JsManifest>(new JintFunc<JsManifest, JsInstance[], JsInstance>(this.EvaluateJsFunc)), PropertyAttributes.DontDelete);
  }

  public JsManifest(Tag tag, JsNode parent)
    : base(tag, parent, "manifest")
  {
  }

  public JintJsNodeList Evaluate()
  {
    JintJsNodeList jintJsNodeList = new JintJsNodeList((Jint.Native.IGlobal) this.IGlobal);
    foreach (IFormNode retrieveChild in (IEnumerable<IFormNode>) ((XFATemplateTag) this.tag).RetrieveChildren("ref"))
    {
      string somExpressions = retrieveChild.RetrieveValue();
      JsTree jsTree1 = (JsTree) this;
      while (jsTree1.Parent != null)
        jsTree1 = jsTree1.Parent;
      JsTree jsTree2 = jsTree1.StrictSearchNode(somExpressions);
      if (jsTree2 != null)
        jintJsNodeList.Append((object) jsTree2);
    }
    return jintJsNodeList;
  }

  public virtual JsInstance EvaluateJsFunc(JsManifest target, JsInstance[] parameters)
  {
    return (JsInstance) target.Evaluate();
  }
}
