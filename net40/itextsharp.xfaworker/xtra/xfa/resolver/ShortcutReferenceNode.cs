// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.resolver.ShortcutReferenceNode
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.tool.xml.xtra.xfa.tags;
using System.Collections.Concurrent;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.resolver;

public class ShortcutReferenceNode : SomExpressionNode
{
  protected static readonly ConcurrentDictionary<string, string> shortcuts = new ConcurrentDictionary<string, string>();
  protected string shortcut;

  static ShortcutReferenceNode() => ShortcutReferenceNode.shortcuts["$template"] = "template";

  public ShortcutReferenceNode(string reference)
    : base(reference)
  {
    ShortcutReferenceNode.shortcuts.TryGetValue(reference, out this.shortcut);
  }

  public override bool Match(IFormNode node)
  {
    return node != null && this.shortcut.Equals(node.ClassName);
  }

  public override bool Equals(object o)
  {
    return this == o || o is ShortcutReferenceNode && base.Equals(o) && this.shortcut.Equals(((ShortcutReferenceNode) o).shortcut);
  }

  public override int GetHashCode()
  {
    return 31 /*0x1F*/ * base.GetHashCode() + this.shortcut.GetHashCode();
  }
}
