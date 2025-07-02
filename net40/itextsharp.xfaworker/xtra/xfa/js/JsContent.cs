// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.js.JsContent
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.tool.xml.xtra.xfa.positioner;
using iTextSharp.tool.xml.xtra.xfa.tags;
using Jint.Native;
using System.Collections.Generic;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.js;

public class JsContent : JsNode
{
  internal JsContent(string className, JsNode prototype)
    : base((JsTree) prototype, className)
  {
  }

  public JsContent(Tag tag, JsNode parent, JsNode prototypeNode)
    : base(tag, parent, prototypeNode)
  {
    string str = "";
    if (tag is XFATemplateTag)
    {
      IList<string> content = ((XFATemplateTag) tag).Content;
      if (content != null && content.Count > 0)
        str = content[0];
    }
    this.DefineProperty("value", (object) str);
  }

  public JsContent(string className, JsNode parent, JsNode prototypeNode, string value)
    : base((Tag) new DataTag(className), parent, prototypeNode)
  {
    this.DefineProperty(nameof (value), (object) value);
  }

  protected override void PutCallback(string name, JsInstance value)
  {
    base.PutCallback(name, value);
    if (!name.Equals(nameof (value)) || !(this.Parent is JsValueNode) || !(this.Parent.Parent is DrawPositioner))
      return;
    ((Positioner) this.Parent.Parent).SetRawValue((object) value);
  }
}
