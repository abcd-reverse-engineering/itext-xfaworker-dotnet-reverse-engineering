// Decompiled with JetBrains decompiler
// Type: Jint.Expressions.PropertyDeclarationExpression
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using System;
using System.Diagnostics;

#nullable disable
namespace Jint.Expressions;

[Serializable]
public class PropertyDeclarationExpression : Expression
{
  public string Name { get; set; }

  public Expression Expression { get; set; }

  public PropertyExpressionType Mode { get; set; }

  public Expression GetExpression { get; set; }

  public Expression SetExpression { get; set; }

  [DebuggerStepThrough]
  public override void Accept(IStatementVisitor visitor) => visitor.Visit(this);

  internal void SetSet(PropertyDeclarationExpression propertyExpression)
  {
    this.SetExpression = propertyExpression.Expression;
  }

  internal void SetGet(PropertyDeclarationExpression propertyExpression)
  {
    this.GetExpression = propertyExpression.Expression;
  }
}
