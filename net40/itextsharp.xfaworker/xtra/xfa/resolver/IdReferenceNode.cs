// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.resolver.IdReferenceNode
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.tool.xml.xtra.xfa.tags;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.resolver;

public class IdReferenceNode : SomExpressionNode
{
  protected readonly string id;

  public IdReferenceNode(string reference)
    : base(reference)
  {
    int length = reference.IndexOf("#");
    this.id = reference.Substring(0, length);
    if (length + 1 >= reference.Length)
      return;
    this.id += reference.Substring(length + 1);
  }

  public override bool Equals(object o)
  {
    return this == o || o is IdReferenceNode && base.Equals(o) && this.id.Equals(((IdReferenceNode) o).id);
  }

  public override int GetHashCode() => 31 /*0x1F*/ * base.GetHashCode() + this.id.GetHashCode();

  public override bool Match(IFormNode node)
  {
    return node != null && this.id.Equals(node.RetrieveAttribute("id"));
  }
}
