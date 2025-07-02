// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.element.ChoiceListElement
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.text;
using iTextSharp.tool.xml.xtra.xfa.tags;
using iTextSharp.tool.xml.xtra.xfa.util;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.element;

public class ChoiceListElement(IFormNode elementTag, XFARectangle elementRec, Document document) : 
  UiElement(elementTag, elementRec, document)
{
  public virtual void SetContentElement(ContentElement contentElement)
  {
    this.contentElement = contentElement;
    if (!(this.contentElement is IContentTextElement))
      return;
    this.ApplyMargins(this.elementRec);
    ((IContentTextElement) this.contentElement).CreateColumnText(this.elementRec);
    this.UnapplyMargins(this.elementRec);
  }

  protected override bool IsTextWidget => true;
}
