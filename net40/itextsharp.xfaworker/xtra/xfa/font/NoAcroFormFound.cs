// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.font.NoAcroFormFound
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.tool.xml.exceptions;
using System;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.font;

public class NoAcroFormFound : RuntimeWorkerException
{
  public NoAcroFormFound()
  {
  }

  public NoAcroFormFound(string message, Exception cause)
    : base(message, cause)
  {
  }

  public NoAcroFormFound(string message)
    : base(message)
  {
  }

  public NoAcroFormFound(Exception cause)
    : base(cause)
  {
  }
}
