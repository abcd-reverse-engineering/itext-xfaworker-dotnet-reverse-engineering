// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.js.JsApp
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.tool.xml.xtra.xfa.config;
using Jint.Delegates;
using Jint.Native;
using System.Collections.Generic;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.js;

public class JsApp : JsObject
{
  private IGlobal global;
  private AppConfig appConfig;

  public JsApp(IGlobal global, AppConfig appConfig)
  {
    this.global = global;
    this.appConfig = appConfig;
    this.DefineOwnProperty((Descriptor) new PropertyDescriptor<JsApp>(global, (JsDictionaryObject) this, "plugIns", new JintFunc<JsApp, JsInstance>(this.PlugInsJsProp)));
    foreach (KeyValuePair<string, object> property in (IEnumerable<KeyValuePair<string, object>>) appConfig.PropertyMap)
      this.DefineOwnProperty(property.Key, (JsInstance) global.Wrap(property.Value));
  }

  public virtual JsInstance PlugInsJsProp(JsApp target)
  {
    return (JsInstance) JintJsObject.Wrap(this.global, (object) new object[0]);
  }
}
