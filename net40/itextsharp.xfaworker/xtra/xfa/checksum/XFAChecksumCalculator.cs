// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.checksum.XFAChecksumCalculator
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.xmp.impl;
using System;
using System.Security.Cryptography;
using System.Text;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.checksum;

public class XFAChecksumCalculator
{
  public static string Calculate(string normalizedTemplate, string normalizedDatasets)
  {
    if (normalizedTemplate != null)
    {
      if (normalizedDatasets != null)
      {
        try
        {
          return Encoding.UTF8.GetString(Base64.Encode(SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(normalizedTemplate + normalizedDatasets))));
        }
        catch (Exception ex)
        {
          return "";
        }
      }
    }
    return "";
  }
}
