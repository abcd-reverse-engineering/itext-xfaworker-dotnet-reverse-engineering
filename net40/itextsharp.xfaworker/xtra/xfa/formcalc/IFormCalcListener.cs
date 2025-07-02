// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.formcalc.IFormCalcListener
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System;
using System.CodeDom.Compiler;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.formcalc;

[CLSCompliant(false)]
[GeneratedCode("ANTLR", "4.5.3")]
public interface IFormCalcListener : IParseTreeListener
{
  void EnterCompilationUnit([NotNull] FormCalcParser.CompilationUnitContext context);

  void ExitCompilationUnit([NotNull] FormCalcParser.CompilationUnitContext context);

  void EnterVariableAssign([NotNull] FormCalcParser.VariableAssignContext context);

  void ExitVariableAssign([NotNull] FormCalcParser.VariableAssignContext context);

  void EnterVariableDeclarator([NotNull] FormCalcParser.VariableDeclaratorContext context);

  void ExitVariableDeclarator([NotNull] FormCalcParser.VariableDeclaratorContext context);

  void EnterVariableDeclaratorId([NotNull] FormCalcParser.VariableDeclaratorIdContext context);

  void ExitVariableDeclaratorId([NotNull] FormCalcParser.VariableDeclaratorIdContext context);

  void EnterVariableInitializer([NotNull] FormCalcParser.VariableInitializerContext context);

  void ExitVariableInitializer([NotNull] FormCalcParser.VariableInitializerContext context);

  void EnterArrayInitializer([NotNull] FormCalcParser.ArrayInitializerContext context);

  void ExitArrayInitializer([NotNull] FormCalcParser.ArrayInitializerContext context);

  void EnterType([NotNull] FormCalcParser.TypeContext context);

  void ExitType([NotNull] FormCalcParser.TypeContext context);

  void EnterPrimitiveType([NotNull] FormCalcParser.PrimitiveTypeContext context);

  void ExitPrimitiveType([NotNull] FormCalcParser.PrimitiveTypeContext context);

  void EnterVariableModifier([NotNull] FormCalcParser.VariableModifierContext context);

  void ExitVariableModifier([NotNull] FormCalcParser.VariableModifierContext context);

  void EnterQualifiedNameList([NotNull] FormCalcParser.QualifiedNameListContext context);

  void ExitQualifiedNameList([NotNull] FormCalcParser.QualifiedNameListContext context);

  void EnterMethodBody([NotNull] FormCalcParser.MethodBodyContext context);

  void ExitMethodBody([NotNull] FormCalcParser.MethodBodyContext context);

  void EnterQualifiedName([NotNull] FormCalcParser.QualifiedNameContext context);

  void ExitQualifiedName([NotNull] FormCalcParser.QualifiedNameContext context);

  void EnterLiteral([NotNull] FormCalcParser.LiteralContext context);

  void ExitLiteral([NotNull] FormCalcParser.LiteralContext context);

  void EnterIntegerLiteral([NotNull] FormCalcParser.IntegerLiteralContext context);

  void ExitIntegerLiteral([NotNull] FormCalcParser.IntegerLiteralContext context);

  void EnterBooleanLiteral([NotNull] FormCalcParser.BooleanLiteralContext context);

  void ExitBooleanLiteral([NotNull] FormCalcParser.BooleanLiteralContext context);

  void EnterBlock([NotNull] FormCalcParser.BlockContext context);

  void ExitBlock([NotNull] FormCalcParser.BlockContext context);

  void EnterBlockStatement([NotNull] FormCalcParser.BlockStatementContext context);

  void ExitBlockStatement([NotNull] FormCalcParser.BlockStatementContext context);

  void EnterIfStatement([NotNull] FormCalcParser.IfStatementContext context);

  void ExitIfStatement([NotNull] FormCalcParser.IfStatementContext context);

  void EnterThenStatement([NotNull] FormCalcParser.ThenStatementContext context);

  void ExitThenStatement([NotNull] FormCalcParser.ThenStatementContext context);

  void EnterElseIfStatement([NotNull] FormCalcParser.ElseIfStatementContext context);

  void ExitElseIfStatement([NotNull] FormCalcParser.ElseIfStatementContext context);

  void EnterElseStatement([NotNull] FormCalcParser.ElseStatementContext context);

  void ExitElseStatement([NotNull] FormCalcParser.ElseStatementContext context);

  void EnterForUpToStatement([NotNull] FormCalcParser.ForUpToStatementContext context);

  void ExitForUpToStatement([NotNull] FormCalcParser.ForUpToStatementContext context);

  void EnterForDownToStatement([NotNull] FormCalcParser.ForDownToStatementContext context);

  void ExitForDownToStatement([NotNull] FormCalcParser.ForDownToStatementContext context);

  void EnterWhileStatement([NotNull] FormCalcParser.WhileStatementContext context);

  void ExitWhileStatement([NotNull] FormCalcParser.WhileStatementContext context);

  void EnterStatement([NotNull] FormCalcParser.StatementContext context);

  void ExitStatement([NotNull] FormCalcParser.StatementContext context);

  void EnterParExpression([NotNull] FormCalcParser.ParExpressionContext context);

  void ExitParExpression([NotNull] FormCalcParser.ParExpressionContext context);

  void EnterExpressionList([NotNull] FormCalcParser.ExpressionListContext context);

  void ExitExpressionList([NotNull] FormCalcParser.ExpressionListContext context);

  void EnterStatementExpression([NotNull] FormCalcParser.StatementExpressionContext context);

  void ExitStatementExpression([NotNull] FormCalcParser.StatementExpressionContext context);

  void EnterAccessor([NotNull] FormCalcParser.AccessorContext context);

  void ExitAccessor([NotNull] FormCalcParser.AccessorContext context);

  void EnterFuncCallExpression([NotNull] FormCalcParser.FuncCallExpressionContext context);

  void ExitFuncCallExpression([NotNull] FormCalcParser.FuncCallExpressionContext context);

  void EnterWildcardExpression([NotNull] FormCalcParser.WildcardExpressionContext context);

  void ExitWildcardExpression([NotNull] FormCalcParser.WildcardExpressionContext context);

  void EnterAssign([NotNull] FormCalcParser.AssignContext context);

  void ExitAssign([NotNull] FormCalcParser.AssignContext context);

  void EnterNullEqualityExpression(
    [NotNull] FormCalcParser.NullEqualityExpressionContext context);

  void ExitNullEqualityExpression(
    [NotNull] FormCalcParser.NullEqualityExpressionContext context);

  void EnterExpression([NotNull] FormCalcParser.ExpressionContext context);

  void ExitExpression([NotNull] FormCalcParser.ExpressionContext context);

  void EnterPrimary([NotNull] FormCalcParser.PrimaryContext context);

  void ExitPrimary([NotNull] FormCalcParser.PrimaryContext context);

  void EnterOrOperators([NotNull] FormCalcParser.OrOperatorsContext context);

  void ExitOrOperators([NotNull] FormCalcParser.OrOperatorsContext context);

  void EnterAndOperators([NotNull] FormCalcParser.AndOperatorsContext context);

  void ExitAndOperators([NotNull] FormCalcParser.AndOperatorsContext context);

  void EnterEqualityOperators([NotNull] FormCalcParser.EqualityOperatorsContext context);

  void ExitEqualityOperators([NotNull] FormCalcParser.EqualityOperatorsContext context);

  void EnterRelationalOperators([NotNull] FormCalcParser.RelationalOperatorsContext context);

  void ExitRelationalOperators([NotNull] FormCalcParser.RelationalOperatorsContext context);

  void EnterNumericOperators([NotNull] FormCalcParser.NumericOperatorsContext context);

  void ExitNumericOperators([NotNull] FormCalcParser.NumericOperatorsContext context);

  void EnterArguments([NotNull] FormCalcParser.ArgumentsContext context);

  void ExitArguments([NotNull] FormCalcParser.ArgumentsContext context);
}
