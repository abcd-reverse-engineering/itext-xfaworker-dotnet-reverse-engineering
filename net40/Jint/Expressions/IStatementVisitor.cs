// Decompiled with JetBrains decompiler
// Type: Jint.Expressions.IStatementVisitor
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

#nullable disable
namespace Jint.Expressions;

public interface IStatementVisitor
{
  void Visit(Program expression);

  void Visit(AssignmentExpression expression);

  void Visit(BlockStatement expression);

  void Visit(BreakStatement expression);

  void Visit(ContinueStatement expression);

  void Visit(DoWhileStatement expression);

  void Visit(EmptyStatement expression);

  void Visit(ExpressionStatement expression);

  void Visit(ForEachInStatement expression);

  void Visit(ForStatement expression);

  void Visit(FunctionDeclarationStatement expression);

  void Visit(IfStatement expression);

  void Visit(ReturnStatement expression);

  void Visit(SwitchStatement expression);

  void Visit(WithStatement expression);

  void Visit(ThrowStatement expression);

  void Visit(TryStatement expression);

  void Visit(VariableDeclarationStatement expression);

  void Visit(WhileStatement expression);

  void Visit(ArrayDeclaration expression);

  void Visit(CommaOperatorStatement expression);

  void Visit(FunctionExpression expression);

  void Visit(MemberExpression expression);

  void Visit(MethodCall expression);

  void Visit(Indexer expression);

  void Visit(PropertyExpression expression);

  void Visit(PropertyDeclarationExpression expression);

  void Visit(Identifier expression);

  void Visit(JsonExpression expression);

  void Visit(NewExpression expression);

  void Visit(BinaryExpression expression);

  void Visit(TernaryExpression expression);

  void Visit(UnaryExpression expression);

  void Visit(ValueExpression expression);

  void Visit(RegexpExpression expression);

  void Visit(Statement expression);
}
