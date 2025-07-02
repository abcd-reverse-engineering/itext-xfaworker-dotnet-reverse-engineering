// Decompiled with JetBrains decompiler
// Type: Jint.Expressions.JsonExpression
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using System;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
namespace Jint.Expressions;

[Serializable]
public class JsonExpression : Expression
{
  public JsonExpression() => this.Values = new Dictionary<string, Expression>();

  public Dictionary<string, Expression> Values { get; set; }

  [DebuggerStepThrough]
  public override void Accept(IStatementVisitor visitor) => visitor.Visit(this);

  internal void Push(PropertyDeclarationExpression propertyExpression)
  {
    if (propertyExpression.Name == null)
    {
      propertyExpression.Name = propertyExpression.Mode.ToString().ToLower();
      propertyExpression.Mode = PropertyExpressionType.Data;
    }
    if (this.Values.ContainsKey(propertyExpression.Name))
    {
      if (!(this.Values[propertyExpression.Name] is PropertyDeclarationExpression declarationExpression))
        throw new JintException("A property cannot be both an accessor and data");
      switch (propertyExpression.Mode)
      {
        case PropertyExpressionType.Data:
          this.Values[propertyExpression.Name] = propertyExpression.Mode == PropertyExpressionType.Data ? propertyExpression.Expression : throw new JintException("A property cannot be both an accessor and data");
          break;
        case PropertyExpressionType.Get:
          declarationExpression.SetGet(propertyExpression);
          break;
        case PropertyExpressionType.Set:
          declarationExpression.SetSet(propertyExpression);
          break;
      }
    }
    else
    {
      this.Values.Add(propertyExpression.Name, (Expression) propertyExpression);
      switch (propertyExpression.Mode)
      {
        case PropertyExpressionType.Data:
          this.Values[propertyExpression.Name] = (Expression) propertyExpression;
          break;
        case PropertyExpressionType.Get:
          propertyExpression.SetGet(propertyExpression);
          break;
        case PropertyExpressionType.Set:
          propertyExpression.SetSet(propertyExpression);
          break;
      }
    }
  }
}
