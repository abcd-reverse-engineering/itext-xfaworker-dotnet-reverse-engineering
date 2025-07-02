// Decompiled with JetBrains decompiler
// Type: Jint.Expressions.Indexer
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using System;
using System.Diagnostics;

#nullable disable
namespace Jint.Expressions;

[Serializable]
public class Indexer : Expression, IAssignable
{
  public Indexer()
  {
  }

  public Indexer(Expression index) => this.Index = index;

  public Expression Index { get; set; }

  public override string ToString() => $"[{this.Index.ToString()}]{base.ToString()}";

  [DebuggerStepThrough]
  public override void Accept(IStatementVisitor visitor) => visitor.Visit(this);
}
