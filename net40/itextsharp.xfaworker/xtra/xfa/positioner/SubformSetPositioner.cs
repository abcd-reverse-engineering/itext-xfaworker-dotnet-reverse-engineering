// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.positioner.SubformSetPositioner
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.tool.xml.xtra.xfa.js;
using iTextSharp.tool.xml.xtra.xfa.resolver;
using iTextSharp.tool.xml.xtra.xfa.tags;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.positioner;

public class SubformSetPositioner(
  XFATemplateTag templateTag,
  DataTag dataTag,
  FlattenerContext flattenerContext,
  JsNode parent) : SubFormPositioner(templateTag, dataTag, flattenerContext, parent, "subformSet")
{
  public override string ClassName => "subformSet";

  public override string GetLayout()
  {
    return this.parent != null ? this.parent.GetLayout() : LayoutManager.positionLayout;
  }

  public override bool IsBreakable => this.parent == null || this.parent.IsBreakable;
}
