// Decompiled with JetBrains decompiler
// Type: Jint.Expressions.CommaOperatorStatement
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using System;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
namespace Jint.Expressions;

[Serializable]
public class CommaOperatorStatement : Expression
{
  public List<Statement> Statements { get; set; }

  public CommaOperatorStatement() => this.Statements = new List<Statement>();

  [DebuggerStepThrough]
  public override void Accept(IStatementVisitor visitor) => visitor.Visit(this);

  private class StatementInfo
  {
    public int index { get; private set; }

    public Statement statement { get; private set; }

    public StatementInfo(int i, Statement s)
    {
      this.index = i;
      this.statement = s;
    }
  }
}
