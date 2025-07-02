// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.css.XfaCssInheritanceRules
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

#nullable disable
namespace iTextSharp.tool.xml.css;

public class XfaCssInheritanceRules : DefaultCssInheritanceRules
{
  public virtual bool InheritCssSelector(Tag tag, string key)
  {
    return "p".Equals(tag.Name) && key.Contains("margin") || base.InheritCssSelector(tag, key);
  }
}
