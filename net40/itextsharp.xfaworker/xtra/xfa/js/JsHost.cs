// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.js.JsHost
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.tool.xml.xtra.xfa.config;
using iTextSharp.tool.xml.xtra.xfa.positioner;
using Jint.Delegates;
using Jint.Native;
using System;
using System.Collections.Generic;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.js;

public class JsHost : JsObject
{
  private IGlobal global;
  private HostConfig hostConfig;
  private JsXfa xfa;

  public JsHost(IGlobal global, HostConfig hostConfig, JsXfa xfa)
  {
    this.global = global;
    this.hostConfig = hostConfig;
    this.xfa = xfa;
    this.DefineOwnProperty("setFocus", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new JintFunc<JsDictionaryObject, JsInstance[], JsInstance>(this.SetFocus)), PropertyAttributes.DontEnum);
    JsFunction jsFunction = global.FunctionClass.New<JsDictionaryObject>(new JintFunc<JsDictionaryObject, JsInstance[], JsInstance>(this.MessageBox));
    this.DefineOwnProperty("messageBox", (JsInstance) jsFunction, PropertyAttributes.DontEnum);
    global.FunctionClass.New<JsDictionaryObject>(new JintFunc<JsDictionaryObject, JsInstance[], JsInstance>(this.ResetData));
    this.DefineOwnProperty("resetData", (JsInstance) jsFunction, PropertyAttributes.DontEnum);
    foreach (KeyValuePair<string, object> property in (IEnumerable<KeyValuePair<string, object>>) hostConfig.PropertyMap)
      this.DefineOwnProperty(property.Key, (JsInstance) global.Wrap(property.Value));
  }

  public virtual JsInstance SetFocus(JsDictionaryObject target, JsInstance[] parameters)
  {
    return (JsInstance) JsNull.Instance;
  }

  public virtual JsInstance MessageBox(JsDictionaryObject target, JsInstance[] parameters)
  {
    return (JsInstance) JsNull.Instance;
  }

  public virtual JsInstance ResetData(JsDictionaryObject target, JsInstance[] parameters)
  {
    if (parameters.Length <= 0 || !(parameters[0] is JsString) || (parameters[0] as JsString).Length <= 0)
      throw new ArgumentException("Resetting all fields in the form is not supported yet");
    JsTree jsTree = this.xfa.ResolveNode(parameters[0].ToString());
    if (jsTree is Positioner)
      ((Positioner) jsTree).SetRawValue((object) null);
    return (JsInstance) JsNull.Instance;
  }
}
