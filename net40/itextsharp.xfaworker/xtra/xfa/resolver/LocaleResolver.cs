// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.resolver.LocaleResolver
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using System.Collections.Generic;
using System.Globalization;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.resolver;

public class LocaleResolver : ICustomContext
{
  private IDictionary<string, XFALocale> locales = (IDictionary<string, XFALocale>) new Dictionary<string, XFALocale>();
  private CultureInfo defaultLocale;

  public virtual XFALocale AddLocale(string name)
  {
    XFALocale xfaLocale1;
    if (this.locales.TryGetValue(name, out xfaLocale1) && xfaLocale1 != null)
      return xfaLocale1;
    XFALocale xfaLocale2 = new XFALocale(name, this.defaultLocale);
    this.locales[name] = xfaLocale2;
    return xfaLocale2;
  }

  public virtual XFALocale GetLocale(string name)
  {
    XFALocale locale = (XFALocale) null;
    if (name != null)
    {
      this.locales.TryGetValue(name, out locale);
      if (locale == null)
      {
        this.locales.TryGetValue(this.defaultLocale.Name, out locale);
        if (locale == null)
          locale = new XFALocale(name, this.defaultLocale);
        this.locales[name] = locale;
      }
    }
    else
      locale = new XFALocale((string) null, this.defaultLocale);
    return locale;
  }

  public virtual void SetDefaultLocale(CultureInfo defaultLocale)
  {
    this.defaultLocale = defaultLocale;
  }
}
