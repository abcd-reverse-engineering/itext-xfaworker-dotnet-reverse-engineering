// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.js.JintJsXfaExecutionVisitor
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using Jint;
using Jint.Native;
using System.Collections.Generic;
using System.Security;
using System.Security.Permissions;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.js;

internal class JintJsXfaExecutionVisitor : ExecutionVisitor
{
  public JintJsXfaExecutionVisitor(Options options)
    : base(options)
  {
    this.typeResolver = (ITypeResolver) CachedTypeResolver.Default;
    this.Global = (IGlobal) new JintJsXfaGlobal((ExecutionVisitor) this, options);
    ((JintJsXfaGlobal) this.Global).JintJsXfaElementConstructor.InitPrototype(this.Global);
    this.GlobalScope = new JsScope((JsDictionaryObject) (this.Global as JsObject));
    this.MaxRecursions = 500;
    this.PermissionSet = new PermissionSet(PermissionState.Unrestricted);
    this.ExitScope();
    this.EnterScope(this.GlobalScope);
    this.CallStack = new Stack<string>();
    JintEngine.InitGlobal(this.Global);
  }
}
