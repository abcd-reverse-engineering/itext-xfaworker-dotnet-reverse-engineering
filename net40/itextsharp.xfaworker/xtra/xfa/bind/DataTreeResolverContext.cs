// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.bind.DataTreeResolverContext
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.tool.xml.xtra.xfa.tags;
using System.Collections.Generic;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.bind;

public class DataTreeResolverContext
{
  private IList<DataTag> fictiveDataTags = (IList<DataTag>) new List<DataTag>();

  public IList<DataTag> GetFictiveDataTags() => this.fictiveDataTags;
}
