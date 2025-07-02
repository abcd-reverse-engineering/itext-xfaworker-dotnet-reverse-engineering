// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.resolver.SomExpressionNode
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.tool.xml.xtra.xfa.tags;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.resolver;

public abstract class SomExpressionNode
{
  public string reference;

  protected SomExpressionNode(string reference) => this.reference = reference;

  public virtual bool Match(string reference) => this.reference.Equals(reference);

  public abstract bool Match(IFormNode node);

  public override bool Equals(object o)
  {
    return this == o || o is SomExpressionNode && this.reference.Equals(((SomExpressionNode) o).reference);
  }

  public override int GetHashCode() => this.reference.GetHashCode();
}
