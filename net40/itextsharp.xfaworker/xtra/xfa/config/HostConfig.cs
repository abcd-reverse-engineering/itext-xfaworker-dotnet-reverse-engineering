// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.config.HostConfig
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using System.Globalization;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.config;

public class HostConfig : XFAConfig
{
  public const string XFA_HOST_NAME = "name";
  public const string XFA_HOST_VERSION = "version";
  public const string XFA_HOST_LANGUAGE = "language";

  public HostConfig()
  {
    this.config["name"] = (object) "Acrobat";
    this.config["version"] = (object) 11.006;
    this.config["language"] = (object) $"{CultureInfo.CurrentCulture.TwoLetterISOLanguageName}_{new RegionInfo(CultureInfo.CurrentCulture.LCID).TwoLetterISORegionName}";
  }
}
