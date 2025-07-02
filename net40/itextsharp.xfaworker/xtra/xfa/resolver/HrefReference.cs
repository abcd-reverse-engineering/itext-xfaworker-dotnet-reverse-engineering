// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.resolver.HrefReference
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.resolver;

public class HrefReference
{
  protected string path;
  protected SomExpression somExpression;

  public HrefReference(string href)
  {
    int? nullable1 = new int?();
    if (href.Contains("#"))
    {
      nullable1 = new int?(href.IndexOf("#"));
      this.somExpression = new SomExpression(href.Substring(nullable1.Value));
    }
    if (nullable1.HasValue)
    {
      int? nullable2 = nullable1;
      if ((nullable2.GetValueOrDefault() <= 0 ? 0 : (nullable2.HasValue ? 1 : 0)) != 0)
        this.path = href.Substring(0, nullable1.Value).Replace("\\", "/");
      else
        this.path = ".";
    }
    else
      this.path = href;
  }

  public string Path => this.path;

  public SomExpression SomExpression
  {
    get => this.somExpression;
    set => this.somExpression = value;
  }

  public override bool Equals(object o)
  {
    if (this == o)
      return true;
    if (!(o is HrefReference))
      return false;
    HrefReference hrefReference = (HrefReference) o;
    return this.path.Equals(hrefReference.path) && (this.somExpression != null ? (!this.somExpression.Equals((object) hrefReference.somExpression) ? 1 : 0) : (hrefReference.somExpression != null ? 1 : 0)) == 0;
  }

  public override int GetHashCode()
  {
    return 31 /*0x1F*/ * this.path.GetHashCode() + (this.somExpression != null ? this.somExpression.GetHashCode() : 0);
  }
}
