// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.resolver.HrefResolver
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using System;
using System.IO;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.resolver;

public class HrefResolver : IHrefResolver
{
  protected string rootPath;
  protected string currentXdpPath;

  public HrefResolver(string rootPath)
  {
    this.rootPath = rootPath;
    if (rootPath != null)
      return;
    this.rootPath = Directory.GetCurrentDirectory();
  }

  public string Resolve(string path)
  {
    return this.currentXdpPath == null ? new Uri(this.AddSlashToEnding(this.rootPath) + this.RemoveSlashFromBeginning(path)).LocalPath : new Uri(this.AddSlashToEnding(Directory.GetParent(this.RemoveSlashFromEnding(this.currentXdpPath)).FullName) + this.RemoveSlashFromBeginning(path)).LocalPath;
  }

  private string RemoveSlashFromBeginning(string path) => path.TrimStart('\\', '/');

  private string RemoveSlashFromEnding(string path) => path.TrimEnd('\\', '/');

  private string AddSlashToEnding(string path)
  {
    return !path.EndsWith("\\") && !path.EndsWith("/") ? path + "\\" : path;
  }

  public string CurrentXdpPath
  {
    get => this.currentXdpPath;
    set => this.currentXdpPath = value;
  }
}
