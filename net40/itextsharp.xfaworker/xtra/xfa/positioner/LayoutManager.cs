// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.positioner.LayoutManager
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.tool.xml.xtra.xfa.tags;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.positioner;

public class LayoutManager
{
  public static readonly string tableLayout = "table";
  public static readonly string rowLayout = "row";
  public static readonly string tbLayout = "tb";
  public static readonly string tblrLayout = "lr-tb";
  public static readonly string positionLayout = "position";

  public static string GetLayout(IFormNode tag)
  {
    string layout = LayoutManager.positionLayout;
    if (tag != null)
    {
      string str = tag.RetrieveAttribute("layout");
      layout = str == null ? LayoutManager.positionLayout : str.ToLower();
    }
    return layout;
  }
}
