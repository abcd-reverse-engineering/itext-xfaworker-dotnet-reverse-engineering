// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.resolver.SomExpression
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.tool.xml.xtra.xfa.tags;
using System.Collections.Generic;
using System.Text.RegularExpressions;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.resolver;

public class SomExpression
{
  protected string expression;
  protected Stack<SomExpressionNode> nodePath;

  public SomExpression(string expression)
  {
    this.expression = expression;
    this.Init();
  }

  public void Init()
  {
    string[] strArray;
    if (Regex.IsMatch(this.expression, "^#?som\\(.*\\)"))
    {
      this.expression = Regex.Replace(Regex.Replace(this.expression, "^#?som\\(", ""), "\\)$", "");
      strArray = this.expression.Split('.');
    }
    else
      strArray = this.expression.Split('.');
    this.nodePath = new Stack<SomExpressionNode>();
    int length = strArray.Length;
    if (length == 1 && strArray[0].StartsWith("#"))
    {
      this.nodePath.Push((SomExpressionNode) new IdReferenceNode(strArray[0]));
    }
    else
    {
      for (int index = length - 1; index >= 0; --index)
      {
        string reference = strArray[index];
        if (reference.StartsWith("#"))
          this.nodePath.Push((SomExpressionNode) new ClassNameReferenceNode(reference));
        else if (reference.StartsWith("$"))
          this.nodePath.Push((SomExpressionNode) new ShortcutReferenceNode(reference));
        else
          this.nodePath.Push((SomExpressionNode) new NameReferenceNode(reference));
      }
    }
  }

  public Stack<SomExpressionNode> NodePath => this.nodePath;

  public string Expression => this.expression;

  public bool Match(string reference)
  {
    return this.nodePath != null && this.nodePath.Count > 0 && this.nodePath.Peek().Match(reference);
  }

  public bool Match(IFormNode node)
  {
    return this.nodePath != null && this.nodePath.Count > 0 && this.nodePath.Peek().Match(node);
  }

  public bool MatchAndPop(IFormNode node)
  {
    if (this.nodePath == null || this.nodePath.Count <= 0 || !this.nodePath.Peek().Match(node))
      return false;
    this.nodePath.Pop();
    return true;
  }

  public IFormNode ResolveNode(IFormNode rootNode) => this.ResolveNode(rootNode, false);

  public IFormNode ResolveNode(IFormNode rootNode, bool up)
  {
    if (this.nodePath.Count == 0)
      return rootNode;
    foreach (IFormNode retrieveChild in (IEnumerable<IFormNode>) rootNode.RetrieveChildren())
    {
      if (this.MatchAndPop(retrieveChild))
      {
        IFormNode formNode = this.ResolveNode(retrieveChild);
        if (formNode != null)
          return formNode;
        break;
      }
    }
    return up ? this.ResolveNode(rootNode.RetrieveParent(), false) : (IFormNode) null;
  }

  public override bool Equals(object o)
  {
    return this == o || o is SomExpression && this.nodePath.Equals((object) ((SomExpression) o).nodePath);
  }

  public override int GetHashCode() => this.nodePath.GetHashCode();
}
