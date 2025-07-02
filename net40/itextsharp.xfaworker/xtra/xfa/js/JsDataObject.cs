// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.js.JsDataObject
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.text.pdf;
using Jint.Native;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.js;

public class JsDataObject : JsObject
{
  private IGlobal global;

  public JsDataObject(IGlobal global, string fileName, PdfDictionary fileSpec)
  {
    this.global = global;
    this.DefineOwnProperty("name", (JsInstance) global.Wrap((object) fileName));
    PdfString asString1 = fileSpec.GetAsString(PdfName.F);
    if (asString1 != null)
      this.DefineOwnProperty("path", (JsInstance) global.Wrap((object) asString1.ToUnicodeString()));
    PdfString asString2 = fileSpec.GetAsString(PdfName.DESC);
    if (asString2 == null)
      return;
    this.DefineOwnProperty("description", (JsInstance) global.Wrap((object) asString2.ToUnicodeString()));
  }
}
