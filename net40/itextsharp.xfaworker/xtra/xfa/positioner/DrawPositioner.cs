// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.positioner.DrawPositioner
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.tool.xml.xtra.xfa.js;
using iTextSharp.tool.xml.xtra.xfa.resolver;
using iTextSharp.tool.xml.xtra.xfa.tags;
using iTextSharp.tool.xml.xtra.xfa.util;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.positioner;

public class DrawPositioner(
  XFATemplateTag templateTag,
  DataTag dataTag,
  FlattenerContext flattenerContext,
  JsNode parent) : ContentPositioner(templateTag, dataTag, flattenerContext, parent, "draw")
{
  public override bool IsBreakable
  {
    get
    {
      if (this.keepConditions == null || !this.keepConditions.Intact.Equals("none"))
        return false;
      if (this.parent == null || this.parent.Parent == null)
        return true;
      string layout = this.parent.GetLayout();
      return !LayoutManager.positionLayout.Equals(layout);
    }
  }

  public override string ClassName => "draw";

  protected override XFARectangle GetTextArea() => this.contentArea;

  protected override void CreateContentElement()
  {
    base.CreateContentElement();
    if (this.uiElement == null)
      return;
    this.uiElement.IsDrawElement = true;
  }
}
