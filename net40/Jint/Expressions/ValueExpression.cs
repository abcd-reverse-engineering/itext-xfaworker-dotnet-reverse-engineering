// Decompiled with JetBrains decompiler
// Type: Jint.Expressions.ValueExpression
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using System;
using System.Diagnostics;

#nullable disable
namespace Jint.Expressions;

[Serializable]
public class ValueExpression : Expression
{
  private object value;
  private TypeCode typeCode;

  public ValueExpression(object value, TypeCode typeCode)
  {
    this.value = value;
    this.typeCode = typeCode;
  }

  public object Value
  {
    get => this.value;
    set => this.value = value;
  }

  public TypeCode TypeCode
  {
    get => this.typeCode;
    set => this.typeCode = value;
  }

  [DebuggerStepThrough]
  public override void Accept(IStatementVisitor visitor) => visitor.Visit(this);

  public override string ToString() => this.Value.ToString();
}
