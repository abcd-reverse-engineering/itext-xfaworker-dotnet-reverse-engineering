// Decompiled with JetBrains decompiler
// Type: Jint.Expressions.BinaryExpression
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using System;
using System.Diagnostics;

#nullable disable
namespace Jint.Expressions;

[Serializable]
public class BinaryExpression : Expression
{
  private Expression leftExpression;
  private Expression rightExpression;
  private BinaryExpressionType type;

  public BinaryExpression(
    BinaryExpressionType type,
    Expression leftExpression,
    Expression rightExpression)
  {
    this.type = type;
    this.leftExpression = leftExpression;
    this.rightExpression = rightExpression;
  }

  public Expression LeftExpression
  {
    get => this.leftExpression;
    set => this.leftExpression = value;
  }

  public Expression RightExpression
  {
    get => this.rightExpression;
    set => this.rightExpression = value;
  }

  public BinaryExpressionType Type
  {
    get => this.type;
    set => this.type = value;
  }

  [DebuggerStepThrough]
  public override void Accept(IStatementVisitor visitor) => visitor.Visit(this);

  public override string ToString()
  {
    return $"{this.Type.ToString()} ({this.leftExpression.ToString()}, {this.rightExpression.ToString()})";
  }
}
