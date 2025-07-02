// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.js.JsAcrobatUtil
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.tool.xml.xtra.xfa.resolver;
using Jint.Delegates;
using Jint.Native;
using System;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.js;

public class JsAcrobatUtil : JsObject
{
  private FlattenerContext resolver;
  private IGlobal global;

  public JsAcrobatUtil(IGlobal global, FlattenerContext resolver)
  {
    this.resolver = resolver;
    this.global = global;
    this.DefineOwnProperty("printd", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new JintFunc<JsDictionaryObject, JsInstance[], JsInstance>(this.Printd), 2), PropertyAttributes.DontEnum);
  }

  public virtual JsInstance Printd(JsDictionaryObject target, JsInstance[] parameters)
  {
    try
    {
      return parameters.Length > 1 && parameters[1] is JsDate ? (JsInstance) this.global.StringClass.New(this.resolver.FormatResolver.FormatDate((DateTime) parameters[1].Value, parameters[0].ToString(), this.resolver.LocaleResolver.GetLocale((string) null))) : (JsInstance) this.global.StringClass.New(parameters[1].ToString());
    }
    catch (Exception ex)
    {
      return (JsInstance) JsNull.Instance;
    }
  }
}
