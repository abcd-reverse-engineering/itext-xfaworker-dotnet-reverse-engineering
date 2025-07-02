// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.tags.IFormNode
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.text;
using System.Collections.Generic;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.tags;

public interface IFormNode
{
  IFormNode RetrieveChild(string name);

  IFormNode RetrieveChild(params string[] path);

  IList<IFormNode> RetrieveChildren();

  IList<IFormNode> RetrieveChildren(string name);

  string RetrieveName();

  string RetrieveTagName();

  IDictionary<string, string> RetrieveAttributes();

  string RetrieveAttribute(string attributeName);

  IFormNode RetrieveParent();

  string RetrieveValue();

  IList<IElement> RetrieveRichText();

  IList<string> RetrieveContent();

  string ClassName { get; }

  bool IsHidden();
}
