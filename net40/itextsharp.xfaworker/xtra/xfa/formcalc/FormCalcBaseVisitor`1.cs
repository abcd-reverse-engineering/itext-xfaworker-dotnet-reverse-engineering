// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.formcalc.FormCalcBaseVisitor`1
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
public class FormCalcBaseVisitor<Result> : 
  AbstractParseTreeVisitor<Result>,
  IFormCalcVisitor<Result>,
  IParseTreeVisitor<Result>
{
  public virtual Result VisitCompilationUnit([NotNull] FormCalcParser.CompilationUnitContext context)
  {
    return this.VisitChildren((IRuleNode) context);
  }

  public virtual Result VisitVariableAssign([NotNull] FormCalcParser.VariableAssignContext context)
  {
    return this.VisitChildren((IRuleNode) context);
  }

  public virtual Result VisitVariableDeclarator([NotNull] FormCalcParser.VariableDeclaratorContext context)
  {
    return this.VisitChildren((IRuleNode) context);
  }

  public virtual Result VisitVariableDeclaratorId([NotNull] FormCalcParser.VariableDeclaratorIdContext context)
  {
    return this.VisitChildren((IRuleNode) context);
  }

  public virtual Result VisitVariableInitializer([NotNull] FormCalcParser.VariableInitializerContext context)
  {
    return this.VisitChildren((IRuleNode) context);
  }

  public virtual Result VisitArrayInitializer([NotNull] FormCalcParser.ArrayInitializerContext context)
  {
    return this.VisitChildren((IRuleNode) context);
  }

  public virtual Result VisitType([NotNull] FormCalcParser.TypeContext context)
  {
    return this.VisitChildren((IRuleNode) context);
  }

  public virtual Result VisitPrimitiveType([NotNull] FormCalcParser.PrimitiveTypeContext context)
  {
    return this.VisitChildren((IRuleNode) context);
  }

  public virtual Result VisitVariableModifier([NotNull] FormCalcParser.VariableModifierContext context)
  {
    return this.VisitChildren((IRuleNode) context);
  }

  public virtual Result VisitQualifiedNameList([NotNull] FormCalcParser.QualifiedNameListContext context)
  {
    return this.VisitChildren((IRuleNode) context);
  }

  public virtual Result VisitMethodBody([NotNull] FormCalcParser.MethodBodyContext context)
  {
    return this.VisitChildren((IRuleNode) context);
  }

  public virtual Result VisitQualifiedName([NotNull] FormCalcParser.QualifiedNameContext context)
  {
    return this.VisitChildren((IRuleNode) context);
  }

  public virtual Result VisitLiteral([NotNull] FormCalcParser.LiteralContext context)
  {
    return this.VisitChildren((IRuleNode) context);
  }

  public virtual Result VisitIntegerLiteral([NotNull] FormCalcParser.IntegerLiteralContext context)
  {
    return this.VisitChildren((IRuleNode) context);
  }

  public virtual Result VisitBooleanLiteral([NotNull] FormCalcParser.BooleanLiteralContext context)
  {
    return this.VisitChildren((IRuleNode) context);
  }

  public virtual Result VisitBlock([NotNull] FormCalcParser.BlockContext context)
  {
    return this.VisitChildren((IRuleNode) context);
  }

  public virtual Result VisitBlockStatement([NotNull] FormCalcParser.BlockStatementContext context)
  {
    return this.VisitChildren((IRuleNode) context);
  }

  public virtual Result VisitIfStatement([NotNull] FormCalcParser.IfStatementContext context)
  {
    return this.VisitChildren((IRuleNode) context);
  }

  public virtual Result VisitThenStatement([NotNull] FormCalcParser.ThenStatementContext context)
  {
    return this.VisitChildren((IRuleNode) context);
  }

  public virtual Result VisitElseIfStatement([NotNull] FormCalcParser.ElseIfStatementContext context)
  {
    return this.VisitChildren((IRuleNode) context);
  }

  public virtual Result VisitElseStatement([NotNull] FormCalcParser.ElseStatementContext context)
  {
    return this.VisitChildren((IRuleNode) context);
  }

  public virtual Result VisitForUpToStatement([NotNull] FormCalcParser.ForUpToStatementContext context)
  {
    return this.VisitChildren((IRuleNode) context);
  }

  public virtual Result VisitForDownToStatement([NotNull] FormCalcParser.ForDownToStatementContext context)
  {
    return this.VisitChildren((IRuleNode) context);
  }

  public virtual Result VisitWhileStatement([NotNull] FormCalcParser.WhileStatementContext context)
  {
    return this.VisitChildren((IRuleNode) context);
  }

  public virtual Result VisitStatement([NotNull] FormCalcParser.StatementContext context)
  {
    return this.VisitChildren((IRuleNode) context);
  }

  public virtual Result VisitParExpression([NotNull] FormCalcParser.ParExpressionContext context)
  {
    return this.VisitChildren((IRuleNode) context);
  }

  public virtual Result VisitExpressionList([NotNull] FormCalcParser.ExpressionListContext context)
  {
    return this.VisitChildren((IRuleNode) context);
  }

  public virtual Result VisitStatementExpression([NotNull] FormCalcParser.StatementExpressionContext context)
  {
    return this.VisitChildren((IRuleNode) context);
  }

  public virtual Result VisitAccessor([NotNull] FormCalcParser.AccessorContext context)
  {
    return this.VisitChildren((IRuleNode) context);
  }

  public virtual Result VisitFuncCallExpression([NotNull] FormCalcParser.FuncCallExpressionContext context)
  {
    return this.VisitChildren((IRuleNode) context);
  }

  public virtual Result VisitWildcardExpression([NotNull] FormCalcParser.WildcardExpressionContext context)
  {
    return this.VisitChildren((IRuleNode) context);
  }

  public virtual Result VisitAssign([NotNull] FormCalcParser.AssignContext context)
  {
    return this.VisitChildren((IRuleNode) context);
  }

  public virtual Result VisitNullEqualityExpression(
    [NotNull] FormCalcParser.NullEqualityExpressionContext context)
  {
    return this.VisitChildren((IRuleNode) context);
  }

  public virtual Result VisitExpression([NotNull] FormCalcParser.ExpressionContext context)
  {
    return this.VisitChildren((IRuleNode) context);
  }

  public virtual Result VisitPrimary([NotNull] FormCalcParser.PrimaryContext context)
  {
    return this.VisitChildren((IRuleNode) context);
  }

  public virtual Result VisitOrOperators([NotNull] FormCalcParser.OrOperatorsContext context)
  {
    return this.VisitChildren((IRuleNode) context);
  }

  public virtual Result VisitAndOperators([NotNull] FormCalcParser.AndOperatorsContext context)
  {
    return this.VisitChildren((IRuleNode) context);
  }

  public virtual Result VisitEqualityOperators([NotNull] FormCalcParser.EqualityOperatorsContext context)
  {
    return this.VisitChildren((IRuleNode) context);
  }

  public virtual Result VisitRelationalOperators([NotNull] FormCalcParser.RelationalOperatorsContext context)
  {
    return this.VisitChildren((IRuleNode) context);
  }

  public virtual Result VisitNumericOperators([NotNull] FormCalcParser.NumericOperatorsContext context)
  {
    return this.VisitChildren((IRuleNode) context);
  }

  public virtual Result VisitArguments([NotNull] FormCalcParser.ArgumentsContext context)
  {
    return this.VisitChildren((IRuleNode) context);
  }
}
