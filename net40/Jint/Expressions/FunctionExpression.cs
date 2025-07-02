// Decompiled with JetBrains decompiler
// Type: Jint.Expressions.FunctionExpression
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using System;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
namespace Jint.Expressions;

[Serializable]
public class FunctionExpression : Expression, IFunctionDeclaration
{
  public List<string> Parameters { get; set; }

  public Statement Statement { get; set; }

  public string Name { get; set; }

  public FunctionExpression() => this.Parameters = new List<string>();

  [DebuggerStepThrough]
  public override void Accept(IStatementVisitor visitor) => visitor.Visit(this);
}
