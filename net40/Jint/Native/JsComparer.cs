// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsComparer
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using Jint.Expressions;
using System;
using System.Collections.Generic;

#nullable disable
namespace Jint.Native;

[Serializable]
public class JsComparer : IComparer<JsInstance>
{
  public IJintVisitor Visitor { get; set; }

  public JsFunction Function { get; set; }

  public JsComparer(IJintVisitor visitor, JsFunction function)
  {
    this.Visitor = visitor;
    this.Function = function;
  }

  public int Compare(JsInstance x, JsInstance y)
  {
    this.Visitor.Result = (JsInstance) this.Function;
    new MethodCall(new List<Expression>()
    {
      (Expression) new ValueExpression((object) x, TypeCode.Object),
      (Expression) new ValueExpression((object) y, TypeCode.Object)
    }).Accept((IStatementVisitor) this.Visitor);
    return Math.Sign(this.Visitor.Result.ToNumber());
  }
}
