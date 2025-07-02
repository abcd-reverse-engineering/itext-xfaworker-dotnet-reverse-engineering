// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.js.JintJsXfaGlobal
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using Jint;
using Jint.Native;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.js;

public class JintJsXfaGlobal : JsGlobal
{
  public JintJsXfaElementConstructor JintJsXfaElementConstructor { get; set; }

  public JintJsXfaGlobal(ExecutionVisitor visitor, Options options)
    : base(visitor, options)
  {
    this.JintJsXfaElementConstructor = new JintJsXfaElementConstructor((IGlobal) this);
  }
}
