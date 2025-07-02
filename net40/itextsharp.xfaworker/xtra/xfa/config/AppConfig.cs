// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.config.AppConfig
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.config;

public class AppConfig : XFAConfig
{
  public const string APP_VIEWER_TYPE = "viewerType";
  public const string APP_VIEWER_VERSION = "viewerVersion";
  public const string APP_VIEWER_VARIATION = "viewerVariation";

  public AppConfig()
  {
    this.config["viewerType"] = (object) "Exchange-Pro";
    this.config["viewerVersion"] = (object) 11;
    this.config["viewerVariation"] = (object) "Full";
  }
}
