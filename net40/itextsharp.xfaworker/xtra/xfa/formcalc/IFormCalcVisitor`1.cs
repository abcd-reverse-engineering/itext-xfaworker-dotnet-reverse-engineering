// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.formcalc.IFormCalcVisitor`1
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System;
using System.CodeDom.Compiler;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.formcalc;

[GeneratedCode("ANTLR", "4.5.3")]
[CLSCompliant(false)]
public interface IFormCalcVisitor<Result> : IParseTreeVisitor<Result>
{
  Result VisitCompilationUnit([NotNull] FormCalcParser.CompilationUnitContext context);

  Result VisitVariableAssign([NotNull] FormCalcParser.VariableAssignContext context);

  Result VisitVariableDeclarator([NotNull] FormCalcParser.VariableDeclaratorContext context);

  Result VisitVariableDeclaratorId([NotNull] FormCalcParser.VariableDeclaratorIdContext context);

  Result VisitVariableInitializer([NotNull] FormCalcParser.VariableInitializerContext context);

  Result VisitArrayInitializer([NotNull] FormCalcParser.ArrayInitializerContext context);

  Result VisitType([NotNull] FormCalcParser.TypeContext context);

  Result VisitPrimitiveType([NotNull] FormCalcParser.PrimitiveTypeContext context);

  Result VisitVariableModifier([NotNull] FormCalcParser.VariableModifierContext context);

  Result VisitQualifiedNameList([NotNull] FormCalcParser.QualifiedNameListContext context);

  Result VisitMethodBody([NotNull] FormCalcParser.MethodBodyContext context);

  Result VisitQualifiedName([NotNull] FormCalcParser.QualifiedNameContext context);

  Result VisitLiteral([NotNull] FormCalcParser.LiteralContext context);

  Result VisitIntegerLiteral([NotNull] FormCalcParser.IntegerLiteralContext context);

  Result VisitBooleanLiteral([NotNull] FormCalcParser.BooleanLiteralContext context);

  Result VisitBlock([NotNull] FormCalcParser.BlockContext context);

  Result VisitBlockStatement([NotNull] FormCalcParser.BlockStatementContext context);

  Result VisitIfStatement([NotNull] FormCalcParser.IfStatementContext context);

  Result VisitThenStatement([NotNull] FormCalcParser.ThenStatementContext context);

  Result VisitElseIfStatement([NotNull] FormCalcParser.ElseIfStatementContext context);

  Result VisitElseStatement([NotNull] FormCalcParser.ElseStatementContext context);

  Result VisitForUpToStatement([NotNull] FormCalcParser.ForUpToStatementContext context);

  Result VisitForDownToStatement([NotNull] FormCalcParser.ForDownToStatementContext context);

  Result VisitWhileStatement([NotNull] FormCalcParser.WhileStatementContext context);

  Result VisitStatement([NotNull] FormCalcParser.StatementContext context);

  Result VisitParExpression([NotNull] FormCalcParser.ParExpressionContext context);

  Result VisitExpressionList([NotNull] FormCalcParser.ExpressionListContext context);

  Result VisitStatementExpression([NotNull] FormCalcParser.StatementExpressionContext context);

  Result VisitAccessor([NotNull] FormCalcParser.AccessorContext context);

  Result VisitFuncCallExpression([NotNull] FormCalcParser.FuncCallExpressionContext context);

  Result VisitWildcardExpression([NotNull] FormCalcParser.WildcardExpressionContext context);

  Result VisitAssign([NotNull] FormCalcParser.AssignContext context);

  Result VisitNullEqualityExpression(
    [NotNull] FormCalcParser.NullEqualityExpressionContext context);

  Result VisitExpression([NotNull] FormCalcParser.ExpressionContext context);

  Result VisitPrimary([NotNull] FormCalcParser.PrimaryContext context);

  Result VisitOrOperators([NotNull] FormCalcParser.OrOperatorsContext context);

  Result VisitAndOperators([NotNull] FormCalcParser.AndOperatorsContext context);

  Result VisitEqualityOperators([NotNull] FormCalcParser.EqualityOperatorsContext context);

  Result VisitRelationalOperators([NotNull] FormCalcParser.RelationalOperatorsContext context);

  Result VisitNumericOperators([NotNull] FormCalcParser.NumericOperatorsContext context);

  Result VisitArguments([NotNull] FormCalcParser.ArgumentsContext context);
}
