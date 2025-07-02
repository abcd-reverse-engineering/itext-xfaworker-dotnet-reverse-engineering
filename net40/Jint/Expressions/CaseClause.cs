// Decompiled with JetBrains decompiler
// Type: Jint.Expressions.CaseClause
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using System;

#nullable disable
namespace Jint.Expressions;

[Serializable]
public class CaseClause
{
  public Expression Expression { get; set; }

  public BlockStatement Statements { get; private set; }

  public CaseClause() => this.Statements = new BlockStatement();
}
