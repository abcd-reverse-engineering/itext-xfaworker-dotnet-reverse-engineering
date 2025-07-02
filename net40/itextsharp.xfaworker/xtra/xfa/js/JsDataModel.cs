// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.js.JsDataModel
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.js;

public class JsDataModel : JsModel
{
  internal JsDataModel(JsTree prototype, string className = "dataModel")
    : base(prototype, className)
  {
  }

  public JsDataModel(string name, JsNode parent)
    : base("dataModel", parent)
  {
    this.DefineProperty(nameof (name), (object) name);
  }
}
