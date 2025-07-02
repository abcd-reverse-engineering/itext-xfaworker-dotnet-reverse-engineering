// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.config.XFAConfig
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using System.Collections.Generic;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.config;

public abstract class XFAConfig
{
  protected IDictionary<string, object> config = (IDictionary<string, object>) new Dictionary<string, object>();

  public virtual object GetProperty(string key)
  {
    object property;
    this.config.TryGetValue(key, out property);
    return property;
  }

  public virtual void SetProperty(string key, object value) => this.config[key] = value;

  public virtual IDictionary<string, object> PropertyMap => this.config;
}
