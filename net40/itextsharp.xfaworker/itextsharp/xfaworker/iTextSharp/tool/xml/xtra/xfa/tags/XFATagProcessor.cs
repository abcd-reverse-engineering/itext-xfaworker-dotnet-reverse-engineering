// Decompiled with JetBrains decompiler
// Type: itextsharp.xfaworker.iTextSharp.tool.xml.xtra.xfa.tags.XFATagProcessor
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.tool.xml.exceptions;
using iTextSharp.tool.xml.html;
using System;

#nullable disable
namespace itextsharp.xfaworker.iTextSharp.tool.xml.xtra.xfa.tags;

internal class XFATagProcessor : DefaultTagProcessorFactory
{
  protected virtual ITagProcessor Load(string className)
  {
    try
    {
      return base.Load(className);
    }
    catch (NoTagProcessorException ex1)
    {
      try
      {
        return (ITagProcessor) Activator.CreateInstance((string) null, className).Unwrap();
      }
      catch (Exception ex2)
      {
        throw new NoTagProcessorException(string.Format(LocaleMessages.GetInstance().GetMessage("tag.noprocessor"), (object) className), ex2);
      }
    }
  }
}
