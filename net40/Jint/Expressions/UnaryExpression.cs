// Decompiled with JetBrains decompiler
// Type: Jint.Expressions.UnaryExpression
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using System;
using System.Diagnostics;

#nullable disable
namespace Jint.Expressions;

[Serializable]
public class UnaryExpression : Expression
{
  private Expression expression;
  private UnaryExpressionType type;

  public UnaryExpression(UnaryExpressionType type, Expression expression)
  {
    this.type = type;
    this.expression = expression;
  }

  public Expression Expression
  {
    get => this.expression;
    set => this.expression = value;
  }

  public UnaryExpressionType Type
  {
    get => this.type;
    set => this.type = value;
  }

  [DebuggerStepThrough]
  public override void Accept(IStatementVisitor visitor) => visitor.Visit(this);
}
