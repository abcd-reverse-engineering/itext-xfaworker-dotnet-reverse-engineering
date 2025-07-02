// Decompiled with JetBrains decompiler
// Type: Jint.Expressions.TernaryExpression
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using System;
using System.Diagnostics;

#nullable disable
namespace Jint.Expressions;

[Serializable]
public class TernaryExpression : Expression
{
  private Expression leftExpression;
  private Expression middleExpression;
  private Expression rightExpression;

  public TernaryExpression(
    Expression leftExpression,
    Expression middleExpression,
    Expression rightExpression)
  {
    this.leftExpression = leftExpression;
    this.middleExpression = middleExpression;
    this.rightExpression = rightExpression;
  }

  public Expression LeftExpression
  {
    get => this.leftExpression;
    set => this.leftExpression = value;
  }

  public Expression MiddleExpression
  {
    get => this.middleExpression;
    set => this.middleExpression = value;
  }

  public Expression RightExpression
  {
    get => this.rightExpression;
    set => this.rightExpression = value;
  }

  [DebuggerStepThrough]
  public override void Accept(IStatementVisitor visitor) => visitor.Visit(this);

  public override string ToString()
  {
    return $"{this.leftExpression.ToString()} ({this.middleExpression.ToString()}, {this.rightExpression.ToString()})";
  }
}
