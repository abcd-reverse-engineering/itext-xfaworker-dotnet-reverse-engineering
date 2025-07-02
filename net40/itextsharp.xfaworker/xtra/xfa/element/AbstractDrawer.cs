// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.element.AbstractDrawer
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.interfaces;
using iTextSharp.tool.xml.xtra.xfa.util;
using System.Collections.Generic;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.element;

public abstract class AbstractDrawer : IAccessibleElement
{
  protected PdfName role = PdfName.ARTIFACT;
  protected AccessibleElementId id = new AccessibleElementId();
  protected Dictionary<PdfName, PdfObject> accessibleAttributes;

  public abstract void Draw(PdfContentByte canvas, XFARectangle borderArea);

  public abstract bool IsEmpty();

  public virtual PdfObject GetAccessibleAttribute(PdfName key)
  {
    PdfObject accessibleAttribute = (PdfObject) null;
    if (this.accessibleAttributes != null)
      this.accessibleAttributes.TryGetValue(key, out accessibleAttribute);
    return accessibleAttribute;
  }

  public virtual void SetAccessibleAttribute(PdfName key, PdfObject value)
  {
    if (this.accessibleAttributes == null)
      this.accessibleAttributes = new Dictionary<PdfName, PdfObject>();
    this.accessibleAttributes[key] = value;
  }

  public virtual Dictionary<PdfName, PdfObject> GetAccessibleAttributes()
  {
    return this.accessibleAttributes;
  }

  public virtual PdfName Role
  {
    get => this.role;
    set => this.role = value;
  }

  public virtual AccessibleElementId ID
  {
    get
    {
      if (this.id == null)
        this.id = new AccessibleElementId();
      return this.id;
    }
    set => this.id = value;
  }

  public virtual bool IsInline => true;
}
