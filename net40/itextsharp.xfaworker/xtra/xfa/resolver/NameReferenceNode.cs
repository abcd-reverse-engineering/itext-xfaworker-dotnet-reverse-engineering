// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.resolver.NameReferenceNode
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.tool.xml.xtra.xfa.tags;
using iTextSharp.tool.xml.xtra.xfa.util;
using System.Collections.Generic;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.resolver;

public class NameReferenceNode(string reference) : SomExpressionNode(reference)
{
  public override bool Match(IFormNode node)
  {
    if (node != null)
    {
      XFAUtil.NameIndexPair nameIndexPair = XFAUtil.SplitNameIndexPair(this.reference);
      bool flag = nameIndexPair.name.Equals(node.RetrieveAttribute("name"));
      if (nameIndexPair.index == XFAUtil.MATCH_ALL_NODES)
        return flag;
      if (flag && node.RetrieveParent() != null)
      {
        IList<IFormNode> formNodeList = node.RetrieveParent().RetrieveChildren();
        int num = 0;
        foreach (IFormNode formNode in (IEnumerable<IFormNode>) formNodeList)
        {
          if (nameIndexPair.name.Equals(formNode.RetrieveAttribute("name")))
          {
            if (num == nameIndexPair.index)
              return node == formNode;
            ++num;
          }
          if (node == formNode)
            return false;
        }
      }
    }
    return false;
  }
}
