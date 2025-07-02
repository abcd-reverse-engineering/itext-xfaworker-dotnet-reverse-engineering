// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.formcalc.FormCalc2JavaScriptConverter
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using iTextSharp.tool.xml.xtra.xfa.js;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.formcalc;

public class FormCalc2JavaScriptConverter : FormCalcBaseVisitor<string>
{
  public override string VisitIfStatement(FormCalcParser.IfStatementContext ctx)
  {
    string str = "if " + this.Visit((IParseTree) ctx.parExpression());
    FormCalcParser.ThenStatementContext statementContext1 = ctx.thenStatement();
    if (statementContext1 != null)
      str += this.Visit((IParseTree) statementContext1);
    foreach (FormCalcParser.ElseIfStatementContext statementContext2 in ctx.elseIfStatement())
      str += this.Visit((IParseTree) statementContext2);
    FormCalcParser.ElseStatementContext statementContext3 = ctx.elseStatement();
    if (statementContext3 != null)
      str += this.Visit((IParseTree) statementContext3);
    return $"{str}{(!str.EndsWith("\n") ? "\n" : "")}}}\n";
  }

  public override string VisitThenStatement(FormCalcParser.ThenStatementContext ctx)
  {
    string str = " {\n";
    foreach (FormCalcParser.StatementContext statementContext in ctx.statement())
      str += this.Visit((IParseTree) statementContext);
    return str;
  }

  public override string VisitElseIfStatement(FormCalcParser.ElseIfStatementContext ctx)
  {
    string str = "\n} else if " + this.Visit((IParseTree) ctx.parExpression());
    FormCalcParser.ThenStatementContext statementContext = ctx.thenStatement();
    if (statementContext != null)
      str += this.Visit((IParseTree) statementContext);
    return str;
  }

  public override string VisitElseStatement(FormCalcParser.ElseStatementContext ctx)
  {
    string str = "\n} else {\n";
    foreach (FormCalcParser.StatementContext statementContext in ctx.statement())
      str += this.Visit((IParseTree) statementContext);
    return str;
  }

  public override string VisitForUpToStatement(FormCalcParser.ForUpToStatementContext ctx)
  {
    string str1 = "for (";
    if (ctx.variableAssign() != null)
      str1 += this.Visit((IParseTree) ctx.variableAssign());
    else if (ctx.assign() != null && ctx.assign().accessor() != null)
      str1 = $"{str1 + this.VisitAccessor(ctx.assign().accessor()) + " = "}fc2jsHelperFuncValueOf({this.VisitExpression(ctx.assign().expression())})";
    string str2 = str1 + ";";
    string str3 = (string) null;
    if (ctx.variableAssign() != null)
    {
      FormCalcParser.PrimaryContext primaryContext = ctx.variableAssign().variableDeclarator().variableDeclaratorId(0).primary();
      if (primaryContext != null)
        str3 = ((RuleContext) primaryContext).GetText();
    }
    else if (ctx.assign() != null)
      str3 = ((RuleContext) ctx.assign().accessor()).GetText();
    IList<FormCalcParser.ExpressionContext> expressionContextList = (IList<FormCalcParser.ExpressionContext>) ctx.expression();
    string str4 = $"{str2} {str3} < {this.Visit((IParseTree) expressionContextList[0])}" + ";";
    string str5;
    if (expressionContextList.Count > 1)
      str5 = $"{str4}{str3} = {str3} + {this.Visit((IParseTree) expressionContextList[1])}";
    else
      str5 = $"{str4}{str3} = {str3} + 1";
    string str6 = str5 + ") {\n";
    if (ctx.statement() != null)
      str6 += this.Visit((IParseTree) ctx.statement());
    return str6 + "}\n";
  }

  public override string VisitForDownToStatement(FormCalcParser.ForDownToStatementContext ctx)
  {
    string str1 = "for (";
    if (ctx.variableAssign() != null)
      str1 += this.Visit((IParseTree) ctx.variableAssign());
    else if (ctx.assign() != null && ctx.assign().accessor() != null)
      str1 = $"{str1 + this.VisitAccessor(ctx.assign().accessor()) + " = "}fc2jsHelperFuncValueOf({this.VisitExpression(ctx.assign().expression())})";
    string str2 = str1 + ";";
    string str3 = (string) null;
    if (ctx.variableAssign() != null)
    {
      FormCalcParser.PrimaryContext primaryContext = ctx.variableAssign().variableDeclarator().variableDeclaratorId(0).primary();
      if (primaryContext != null)
        str3 = ((RuleContext) primaryContext).GetText();
    }
    else if (ctx.assign() != null)
      str3 = ((RuleContext) ctx.assign().accessor()).GetText();
    IList<FormCalcParser.ExpressionContext> expressionContextList = (IList<FormCalcParser.ExpressionContext>) ctx.expression();
    string str4 = $"{str2} {str3} > {this.Visit((IParseTree) expressionContextList[0])}" + ";";
    string str5;
    if (expressionContextList.Count > 1)
      str5 = $"{str4}{str3} = {str3} - {this.Visit((IParseTree) expressionContextList[1])}";
    else
      str5 = $"{str4}{str3} = {str3} - 1";
    string str6 = str5 + ") {\n";
    if (ctx.statement() != null)
      str6 += this.Visit((IParseTree) ctx.statement());
    return str6 + "}\n";
  }

  public override string VisitWhileStatement(FormCalcParser.WhileStatementContext ctx)
  {
    return $"while {this.Visit((IParseTree) ctx.parExpression())} {{\n{this.Visit((IParseTree) ctx.statement())}}}\n";
  }

  public override string VisitStatementExpression(FormCalcParser.StatementExpressionContext context)
  {
    return base.VisitStatementExpression(context) + ";\n";
  }

  public override string VisitExpression(FormCalcParser.ExpressionContext ctx)
  {
    if (ctx.numericOperators() == null)
      return base.VisitExpression(ctx);
    return $"fc2jsHelperFuncNumericValueOf({this.Visit((IParseTree) ctx.expression()[0])}) {this.Visit((IParseTree) ctx.numericOperators())} fc2jsHelperFuncNumericValueOf({this.Visit((IParseTree) ctx.expression()[1])})";
  }

  public override string VisitWildcardExpression(FormCalcParser.WildcardExpressionContext ctx)
  {
    return $"resolveNodes({FormCalc2JavaScriptConverter.WrapAccessor(base.VisitWildcardExpression(ctx))})";
  }

  public override string VisitVariableDeclarator(FormCalcParser.VariableDeclaratorContext ctx)
  {
    string str1 = "";
    string str2 = "var ";
    foreach (FormCalcParser.VariableDeclaratorIdContext declaratorIdContext in ctx.variableDeclaratorId())
    {
      str1 = str1 + str2 + this.Visit((IParseTree) declaratorIdContext.primary());
      str2 = ", ";
    }
    return str1;
  }

  public override string VisitVariableInitializer(FormCalcParser.VariableInitializerContext ctx)
  {
    return ctx.expression() != null ? $"fc2jsHelperFuncValueOf({this.Visit((IParseTree) ctx.expression())})" : base.VisitVariableInitializer(ctx);
  }

  public override string VisitFuncCallExpression(FormCalcParser.FuncCallExpressionContext ctx)
  {
    string str1 = base.VisitFuncCallExpression(ctx);
    int startIndex = str1.IndexOf("(");
    int num1 = str1.LastIndexOf('.', startIndex);
    int num2 = num1 != -1 ? num1 + 1 : 0;
    string lowerInvariant = str1.Substring(num2, startIndex - num2).ToLowerInvariant();
    if (!JsXfa.formCalcFunc.ContainsKey(lowerInvariant))
      return str1;
    string str2 = JsXfa.formCalcFunc[lowerInvariant];
    return "exists".Equals(lowerInvariant) ? $"{str1.Substring(0, num2)}{str2}({FormCalc2JavaScriptConverter.WrapAccessor(str1.Substring(startIndex + 1, str1.Length - 1 - startIndex - 1))})" : $"{str1.Substring(0, num2)}{str2}({str1.Substring(startIndex + 1, str1.Length - 1 - startIndex - 1)})";
  }

  public override string VisitParExpression(FormCalcParser.ParExpressionContext context)
  {
    return base.VisitParExpression(context);
  }

  public virtual string VisitTerminal(ITerminalNode node) => ((IParseTree) node).GetText();

  protected virtual string AggregateResult(string aggregate, string nextResult)
  {
    return aggregate == null ? nextResult : aggregate + nextResult;
  }

  public override string VisitOrOperators(FormCalcParser.OrOperatorsContext context) => "||";

  public override string VisitAndOperators(FormCalcParser.AndOperatorsContext context) => "&&";

  public override string VisitEqualityOperators(FormCalcParser.EqualityOperatorsContext ctx)
  {
    return base.VisitEqualityOperators(ctx).Replace("<>", "!=").Replace("ne", "!=").Replace("eq", "==");
  }

  public override string VisitRelationalOperators(FormCalcParser.RelationalOperatorsContext ctx)
  {
    return base.VisitRelationalOperators(ctx).Replace("le", "<=").Replace("ge", ">=").Replace("lt", "<").Replace("gt", ">");
  }

  public override string VisitAssign(FormCalcParser.AssignContext ctx)
  {
    string str1 = ctx.accessor() == null ? this.Visit((IParseTree) ctx.funcCallExpression()) : this.Visit((IParseTree) ctx.accessor());
    string str2 = this.Visit((IParseTree) ctx.expression());
    if ("this".Equals(str1))
      str1 = "$";
    string str3 = "fc2jsTempVar" + (object) Math.Round(new Random().NextDouble() * 100000.0);
    return $"var {str3} = typeof({str1}) == \"undefined\" ? null : {str1}; " + $"fc2jsHelperFuncIsRef({str3}) ? {str3}.rawValue = fc2jsHelperFuncValueOf({str2}) : {str1} = fc2jsHelperFuncValueOf({str2})";
  }

  public override string VisitNullEqualityExpression(
    FormCalcParser.NullEqualityExpressionContext ctx)
  {
    return $"fc2jsHelperFuncValueOf({(ctx.accessor() != null ? this.Visit((IParseTree) ctx.accessor()) : this.Visit((IParseTree) ctx.funcCallExpression()))}) {this.Visit((IParseTree) ctx.equalityOperators())} null";
  }

  public static string WrapAccessor(string accessor)
  {
    if (accessor.StartsWith("\""))
      return accessor;
    string[] strArray = Regex.Split(accessor, "[\\[|\\]]");
    bool flag = false;
    string str1 = "\"";
    foreach (string str2 in strArray)
    {
      if (flag)
      {
        str1 = !"*".Equals(str2) ? $"{str1}[\" + {str2} + \"]" : str1 + "[*]";
        flag = false;
      }
      else
      {
        str1 += str2;
        flag = true;
      }
    }
    return str1 + "\"";
  }

  public static string Convert(string formCalcScript)
  {
    return new FormCalc2JavaScriptConverter().Visit((IParseTree) new FormCalcParser((ITokenStream) new CommonTokenStream((ITokenSource) new FormCalcLexer((ICharStream) new XFAFormCalcInputStream(formCalcScript)))).compilationUnit());
  }
}
