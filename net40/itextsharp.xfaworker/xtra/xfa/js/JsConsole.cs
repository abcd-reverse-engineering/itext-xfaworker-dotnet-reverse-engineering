// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.js.JsConsole
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using Jint.Delegates;
using Jint.Native;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.js;

public class JsConsole : JsObject
{
  public JsConsole(IGlobal global)
  {
    this.DefineOwnProperty("println", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new JintFunc<JsDictionaryObject, JsInstance[], JsInstance>(this.PrintlnJsFunc), 1), PropertyAttributes.DontEnum);
  }

  public virtual JsInstance PrintlnJsFunc(JsDictionaryObject target, JsInstance[] parameters)
  {
    return (JsInstance) JsNull.Instance;
  }
}
