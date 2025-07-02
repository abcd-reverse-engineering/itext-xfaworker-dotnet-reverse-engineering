// Decompiled with JetBrains decompiler
// Type: Jint.ExecutionVisitor
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using Jint.Debugger;
using Jint.Expressions;
using Jint.Native;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using System.Security.Permissions;
using System.Text;

#nullable disable
namespace Jint;

public class ExecutionVisitor : IStatementVisitor, IJintVisitor
{
  protected internal ITypeResolver typeResolver;
  protected Stack<JsScope> Scopes = new Stack<JsScope>();
  protected bool exit;
  protected JsInstance returnInstance;
  protected int recursionLevel;
  private StringBuilder typeFullname = new StringBuilder();
  private string lastIdentifier = string.Empty;
  private ExecutionVisitor.ResultInfo lastResult;
  private Stack<ExecutionVisitor.ResultInfo> stackResults = new Stack<ExecutionVisitor.ResultInfo>();
  protected ContinueStatement continueStatement;
  protected BreakStatement breakStatement;

  public IGlobal Global { get; protected set; }

  public JsScope GlobalScope { get; protected set; }

  public event EventHandler<DebugInformation> Step;

  public Stack<string> CallStack { get; set; }

  public Statement CurrentStatement { get; set; }

  public bool DebugMode { get; set; }

  public int MaxRecursions { get; set; }

  public JsInstance Returned => this.returnInstance;

  public bool AllowClr { get; set; }

  public PermissionSet PermissionSet { get; set; }

  public JsInstance EvaluationResult { get; private set; }

  public JsDictionaryObject CallTarget => this.lastResult.baseObject;

  public JsInstance Result
  {
    get => this.lastResult.result;
    set
    {
      this.lastResult.result = value;
      this.lastResult.baseObject = (JsDictionaryObject) null;
    }
  }

  public void SetResult(JsInstance value, JsDictionaryObject baseObject)
  {
    this.lastResult.result = value;
    this.lastResult.baseObject = baseObject;
  }

  public ExecutionVisitor(Options options)
  {
    this.typeResolver = (ITypeResolver) CachedTypeResolver.Default;
    this.Global = (IGlobal) new JsGlobal(this, options);
    this.GlobalScope = new JsScope((JsDictionaryObject) (this.Global as JsObject));
    this.MaxRecursions = 500;
    this.PermissionSet = new PermissionSet(PermissionState.Unrestricted);
    this.EnterScope(this.GlobalScope);
    this.CallStack = new Stack<string>();
  }

  public ExecutionVisitor(IGlobal GlobalObject, JsScope Scope)
  {
    if (GlobalObject == null)
      throw new ArgumentNullException(nameof (GlobalObject));
    if (Scope == null)
      throw new ArgumentNullException(nameof (Scope));
    this.typeResolver = (ITypeResolver) CachedTypeResolver.Default;
    this.Global = GlobalObject;
    this.GlobalScope = Scope.Global;
    this.MaxRecursions = 500;
    this.EnterScope(Scope);
    this.CallStack = new Stack<string>();
  }

  public void OnStep(DebugInformation info)
  {
    if (this.Step == null || info.CurrentStatement == null || info.CurrentStatement.Source == null)
      return;
    this.Step((object) this, info);
  }

  public DebugInformation CreateDebugInformation(Statement statement)
  {
    DebugInformation debugInformation = new DebugInformation();
    debugInformation.CurrentStatement = statement;
    debugInformation.CallStack = this.CallStack;
    debugInformation.Locals = (JsDictionaryObject) new JsObject((JsObject) JsNull.Instance);
    this.DebugMode = false;
    foreach (string key in this.CurrentScope.GetKeys())
      debugInformation.Locals[key] = this.CurrentScope[key];
    this.DebugMode = true;
    return debugInformation;
  }

  public JsScope CurrentScope => this.Scopes.Peek();

  protected void EnterScope(JsDictionaryObject scope)
  {
    this.Scopes.Push(new JsScope(this.CurrentScope, scope));
  }

  public void EnterScope(JsScope scope) => this.Scopes.Push(scope);

  public void ExitScope() => this.Scopes.Pop();

  public void Visit(Program program)
  {
    this.typeFullname = new StringBuilder();
    this.exit = false;
    this.lastIdentifier = string.Empty;
    foreach (Statement statement in program.Statements)
    {
      this.CurrentStatement = statement;
      if (this.DebugMode)
        this.OnStep(this.CreateDebugInformation(statement));
      this.Result = (JsInstance) null;
      statement.Accept((IStatementVisitor) this);
      if (this.exit)
      {
        this.exit = false;
        break;
      }
    }
  }

  public void Visit(AssignmentExpression statement)
  {
    switch (statement.AssignmentOperator)
    {
      case AssignmentOperator.Assign:
        statement.Right.Accept((IStatementVisitor) this);
        break;
      case AssignmentOperator.Multiply:
        new BinaryExpression(BinaryExpressionType.Times, statement.Left, statement.Right).Accept((IStatementVisitor) this);
        break;
      case AssignmentOperator.Divide:
        new BinaryExpression(BinaryExpressionType.Div, statement.Left, statement.Right).Accept((IStatementVisitor) this);
        break;
      case AssignmentOperator.Modulo:
        new BinaryExpression(BinaryExpressionType.Modulo, statement.Left, statement.Right).Accept((IStatementVisitor) this);
        break;
      case AssignmentOperator.Add:
        new BinaryExpression(BinaryExpressionType.Plus, statement.Left, statement.Right).Accept((IStatementVisitor) this);
        break;
      case AssignmentOperator.Substract:
        new BinaryExpression(BinaryExpressionType.Minus, statement.Left, statement.Right).Accept((IStatementVisitor) this);
        break;
      case AssignmentOperator.ShiftLeft:
        new BinaryExpression(BinaryExpressionType.LeftShift, statement.Left, statement.Right).Accept((IStatementVisitor) this);
        break;
      case AssignmentOperator.ShiftRight:
        new BinaryExpression(BinaryExpressionType.RightShift, statement.Left, statement.Right).Accept((IStatementVisitor) this);
        break;
      case AssignmentOperator.UnsignedRightShift:
        new BinaryExpression(BinaryExpressionType.UnsignedRightShift, statement.Left, statement.Right).Accept((IStatementVisitor) this);
        break;
      case AssignmentOperator.And:
        new BinaryExpression(BinaryExpressionType.BitwiseAnd, statement.Left, statement.Right).Accept((IStatementVisitor) this);
        break;
      case AssignmentOperator.Or:
        new BinaryExpression(BinaryExpressionType.BitwiseOr, statement.Left, statement.Right).Accept((IStatementVisitor) this);
        break;
      case AssignmentOperator.XOr:
        new BinaryExpression(BinaryExpressionType.BitwiseXOr, statement.Left, statement.Right).Accept((IStatementVisitor) this);
        break;
      default:
        throw new NotSupportedException();
    }
    JsInstance result = this.Result;
    if (!(statement.Left is MemberExpression left))
      left = new MemberExpression(statement.Left, (Expression) null);
    this.Assign(left, result);
    this.Result = result;
    this.EvaluationResult = this.Result;
  }

  public void Assign(MemberExpression left, JsInstance value)
  {
    Descriptor result = (Descriptor) null;
    if (!(left.Member is IAssignable))
      throw new JintException("The left member of an assignment must be a member");
    this.EnsureIdentifierIsDefined((object) value);
    if (left.Previous != null)
    {
      left.Previous.Accept((IStatementVisitor) this);
      if (!(this.Result is JsDictionaryObject dictionaryObject) || dictionaryObject == JsUndefined.Instance)
        throw new JintException("Attempt to assign to an undefined variable.");
    }
    else
    {
      dictionaryObject = (JsDictionaryObject) this.CurrentScope;
      this.CurrentScope.TryGetDescriptor(((Identifier) left.Member).Text, out result);
    }
    if (left.Member is Identifier)
    {
      string text = ((Identifier) left.Member).Text;
      if (left.Previous == null && dictionaryObject is JsScope)
        this.Result = ((JsScope) dictionaryObject).SetAt(text, value, true);
      else
        this.Result = dictionaryObject[text] = value;
    }
    else
    {
      (left.Member as Indexer).Index.Accept((IStatementVisitor) this);
      if (dictionaryObject is JsObject)
      {
        JsObject that = dictionaryObject as JsObject;
        if (that.Indexer != null)
        {
          that.Indexer.set((JsInstance) that, this.Result, value);
          this.Result = value;
          return;
        }
      }
      this.Result = dictionaryObject[this.Result] = value;
    }
  }

  public void Visit(CommaOperatorStatement statement)
  {
    foreach (Statement statement1 in statement.Statements)
    {
      if (this.DebugMode)
        this.OnStep(this.CreateDebugInformation(statement1));
      statement1.Accept((IStatementVisitor) this);
      if (this.StopStatementFlow())
        break;
    }
  }

  public void Visit(BlockStatement statement)
  {
    Statement currentStatement = this.CurrentStatement;
    foreach (Statement statement1 in statement.Statements)
    {
      this.CurrentStatement = statement1;
      if (this.DebugMode)
        this.OnStep(this.CreateDebugInformation(statement1));
      this.Result = (JsInstance) null;
      statement1.Accept((IStatementVisitor) this);
      if (this.StopStatementFlow())
        return;
    }
    this.CurrentStatement = currentStatement;
  }

  public void Visit(ContinueStatement statement) => this.continueStatement = statement;

  public void Visit(BreakStatement statement) => this.breakStatement = statement;

  public void Visit(DoWhileStatement statement)
  {
    do
    {
      statement.Statement.Accept((IStatementVisitor) this);
      this.ResetContinueIfPresent(statement.Label);
      if (this.StopStatementFlow())
      {
        if (this.breakStatement == null || !(statement.Label == this.breakStatement.Label))
          break;
        this.breakStatement = (BreakStatement) null;
        break;
      }
      statement.Condition.Accept((IStatementVisitor) this);
      this.EnsureIdentifierIsDefined((object) this.Result);
    }
    while (this.Result.ToBoolean());
  }

  public void Visit(EmptyStatement statement)
  {
  }

  public void Visit(ExpressionStatement statement)
  {
    statement.Expression.Accept((IStatementVisitor) this);
  }

  public void Visit(ForEachInStatement statement)
  {
    string empty = string.Empty;
    string index1;
    if (statement.InitialisationStatement is VariableDeclarationStatement)
    {
      int num = ((VariableDeclarationStatement) statement.InitialisationStatement).Global ? 1 : 0;
      index1 = ((VariableDeclarationStatement) statement.InitialisationStatement).Identifier;
    }
    else
    {
      if (!(statement.InitialisationStatement is Identifier))
        throw new NotSupportedException("Only variable declaration are allowed in a for in loop");
      index1 = ((Identifier) statement.InitialisationStatement).Text;
    }
    statement.Expression.Accept((IStatementVisitor) this);
    JsDictionaryObject result = this.Result as JsDictionaryObject;
    if (this.Result.Value is IEnumerable)
    {
      foreach (object obj in (IEnumerable) this.Result.Value)
      {
        this.CurrentScope[index1] = (JsInstance) this.Global.WrapClr(obj);
        statement.Statement.Accept((IStatementVisitor) this);
        this.ResetContinueIfPresent(statement.Label);
        if (this.StopStatementFlow())
        {
          if (this.breakStatement == null || !(statement.Label == this.breakStatement.Label))
            break;
          this.breakStatement = (BreakStatement) null;
          break;
        }
        this.ResetContinueIfPresent(statement.Label);
      }
    }
    else
    {
      List<string> stringList = result != null ? new List<string>(result.GetKeys()) : throw new InvalidOperationException("The property can't be enumerated");
      for (int index2 = 0; index2 < stringList.Count; ++index2)
      {
        string str = stringList[index2];
        this.CurrentScope[index1] = (JsInstance) this.Global.StringClass.New(str);
        statement.Statement.Accept((IStatementVisitor) this);
        this.ResetContinueIfPresent(statement.Label);
        if (this.StopStatementFlow())
        {
          if (this.breakStatement == null || !(statement.Label == this.breakStatement.Label))
            break;
          this.breakStatement = (BreakStatement) null;
          break;
        }
        this.ResetContinueIfPresent(statement.Label);
      }
    }
  }

  public void Visit(WithStatement statement)
  {
    statement.Expression.Accept((IStatementVisitor) this);
    if (!(this.Result is JsDictionaryObject))
      throw new JsException((JsInstance) this.Global.StringClass.New("Invalid expression in 'with' statement"));
    this.EnterScope((JsDictionaryObject) this.Result);
    try
    {
      statement.Statement.Accept((IStatementVisitor) this);
    }
    finally
    {
      this.ExitScope();
    }
  }

  public void Visit(ForStatement statement)
  {
    JsInstance evaluationResult1 = this.EvaluationResult;
    if (statement.InitialisationStatement != null)
      statement.InitialisationStatement.Accept((IStatementVisitor) this);
    if (statement.ConditionExpression != null)
      statement.ConditionExpression.Accept((IStatementVisitor) this);
    else
      this.Result = (JsInstance) this.Global.BooleanClass.New(true);
    this.EnsureIdentifierIsDefined((object) this.Result);
    this.EvaluationResult = evaluationResult1;
    while (this.Result.ToBoolean())
    {
      statement.Statement.Accept((IStatementVisitor) this);
      this.ResetContinueIfPresent(statement.Label);
      if (this.StopStatementFlow())
      {
        if (this.breakStatement == null || !(statement.Label == this.breakStatement.Label))
          break;
        this.breakStatement = (BreakStatement) null;
        break;
      }
      JsInstance evaluationResult2 = this.EvaluationResult;
      if (statement.IncrementExpression != null)
        statement.IncrementExpression.Accept((IStatementVisitor) this);
      if (statement.ConditionExpression != null)
        statement.ConditionExpression.Accept((IStatementVisitor) this);
      else
        this.Result = (JsInstance) this.Global.BooleanClass.New(true);
      this.EvaluationResult = evaluationResult2;
    }
  }

  public JsFunction CreateFunction(IFunctionDeclaration functionDeclaration)
  {
    JsFunction function = this.Global.FunctionClass.New();
    function.Statement = functionDeclaration.Statement;
    function.Name = functionDeclaration.Name;
    function.Scope = this.CurrentScope;
    function.Arguments = functionDeclaration.Parameters;
    if (this.HasOption(Options.Strict))
    {
      foreach (string str in function.Arguments)
      {
        if (str == "eval" || str == "arguments")
          throw new JsException((JsInstance) this.Global.StringClass.New("The parameters do not respect strict mode"));
      }
    }
    return function;
  }

  public void Visit(FunctionDeclarationStatement statement)
  {
    JsFunction function = this.CreateFunction((IFunctionDeclaration) statement);
    this.CurrentScope.DefineOwnProperty(statement.Name, (JsInstance) function);
  }

  public void Visit(IfStatement statement)
  {
    JsInstance evaluationResult = this.EvaluationResult;
    statement.Expression.Accept((IStatementVisitor) this);
    this.EnsureIdentifierIsDefined((object) this.Result);
    this.EvaluationResult = evaluationResult;
    if (this.Result.ToBoolean())
    {
      statement.Then.Accept((IStatementVisitor) this);
    }
    else
    {
      if (statement.Else == null)
        return;
      statement.Else.Accept((IStatementVisitor) this);
    }
  }

  public void Visit(ReturnStatement statement)
  {
    this.returnInstance = (JsInstance) null;
    if (statement.Expression != null)
    {
      statement.Expression.Accept((IStatementVisitor) this);
      this.Return(this.Result);
    }
    this.exit = true;
  }

  public JsInstance Return(JsInstance instance)
  {
    this.returnInstance = instance;
    return this.returnInstance;
  }

  public void Visit(SwitchStatement statement)
  {
    this.CurrentStatement = statement.Expression;
    int count = statement.CaseClauses.Count;
    bool flag = false;
    int index = 0;
    while (true)
    {
      if (statement.DefaultStatements != null && (index == count && !flag || index == statement.DefaultClauseIndex && flag))
      {
        statement.DefaultStatements.Accept((IStatementVisitor) this);
        if (!this.exit)
        {
          if (this.breakStatement == null)
          {
            flag = true;
            index = statement.DefaultClauseIndex;
          }
          else
            goto label_5;
        }
        else
          break;
      }
      if (index != count)
      {
        CaseClause caseClause = statement.CaseClauses[index];
        this.CurrentStatement = (Statement) caseClause.Expression;
        if (flag)
        {
          caseClause.Statements.Accept((IStatementVisitor) this);
          if (this.exit)
            goto label_8;
        }
        else
        {
          JsInstance evaluationResult = this.EvaluationResult;
          new BinaryExpression(BinaryExpressionType.Equal, (Expression) statement.Expression, caseClause.Expression).Accept((IStatementVisitor) this);
          this.EvaluationResult = evaluationResult;
          if (this.Result.ToBoolean())
          {
            caseClause.Statements.Accept((IStatementVisitor) this);
            flag = true;
            if (this.exit)
              goto label_11;
          }
        }
        if (this.breakStatement == null)
          ++index;
        else
          goto label_15;
      }
      else
        goto label_3;
    }
    return;
label_5:
    this.breakStatement = (BreakStatement) null;
    return;
label_3:
    return;
label_8:
    return;
label_11:
    return;
label_15:
    this.breakStatement = (BreakStatement) null;
  }

  public void Visit(ThrowStatement statement)
  {
    this.Result = (JsInstance) JsUndefined.Instance;
    if (statement.Expression != null)
      statement.Expression.Accept((IStatementVisitor) this);
    throw new JsException(this.Result);
  }

  public void Visit(TryStatement statement)
  {
    try
    {
      statement.Statement.Accept((IStatementVisitor) this);
    }
    catch (Exception ex)
    {
      if (statement.Catch != null)
      {
        if (!(ex is JsException jsException))
          jsException = new JsException((JsInstance) this.Global.ErrorClass.New(ex.Message));
        if (statement.Catch.Identifier != null)
          this.Assign(new MemberExpression((Expression) new PropertyExpression(statement.Catch.Identifier), (Expression) null), jsException.Value);
        statement.Catch.Statement.Accept((IStatementVisitor) this);
      }
      else
        throw;
    }
    finally
    {
      if (statement.Finally != null)
      {
        JsObject jsObject = new JsObject();
        statement.Finally.Statement.Accept((IStatementVisitor) this);
      }
    }
  }

  public void Visit(VariableDeclarationStatement statement)
  {
    JsInstance evaluationResult = this.EvaluationResult;
    this.Result = (JsInstance) JsUndefined.Instance;
    if (statement.Expression != null)
    {
      statement.Expression.Accept((IStatementVisitor) this);
      if (statement.Global)
        throw new InvalidOperationException("Cant declare a global variable");
      if (!this.CurrentScope.HasOwnProperty(statement.Identifier))
        this.CurrentScope.DefineOwnProperty(statement.Identifier, this.Result);
      else
        this.CurrentScope[statement.Identifier] = this.Result;
    }
    else if (!this.CurrentScope.HasOwnProperty(statement.Identifier))
      this.CurrentScope.DefineOwnProperty(statement.Identifier, (JsInstance) JsUndefined.Instance);
    this.EvaluationResult = evaluationResult;
  }

  public void Visit(WhileStatement statement)
  {
    JsInstance evaluationResult1 = this.EvaluationResult;
    statement.Condition.Accept((IStatementVisitor) this);
    this.EvaluationResult = evaluationResult1;
    this.EnsureIdentifierIsDefined((object) this.Result);
    while (this.Result.ToBoolean())
    {
      statement.Statement.Accept((IStatementVisitor) this);
      this.ResetContinueIfPresent(statement.Label);
      if (this.StopStatementFlow())
      {
        if (this.breakStatement == null || !(statement.Label == this.breakStatement.Label))
          break;
        this.breakStatement = (BreakStatement) null;
        break;
      }
      JsInstance evaluationResult2 = this.EvaluationResult;
      statement.Condition.Accept((IStatementVisitor) this);
      this.EvaluationResult = evaluationResult2;
    }
  }

  public void Visit(NewExpression expression)
  {
    this.Result = (JsInstance) null;
    expression.Expression.Accept((IStatementVisitor) this);
    if (this.Result == JsUndefined.Instance && this.typeFullname.Length > 0 && expression.Generics.Count > 0)
    {
      string str = this.typeFullname.ToString();
      this.typeFullname = new StringBuilder();
      Type[] typeArray = new Type[expression.Generics.Count];
      try
      {
        int index = 0;
        foreach (Statement generic in expression.Generics)
        {
          generic.Accept((IStatementVisitor) this);
          typeArray[index] = this.Global.Marshaller.MarshalJsValue<Type>(this.Result);
          ++index;
        }
      }
      catch (Exception ex)
      {
        throw new JintException("A type parameter is required", ex);
      }
      this.Result = this.Global.Marshaller.MarshalClrValue<Type>(this.typeResolver.ResolveType($"{str}`{(object) typeArray.Length}").MakeGenericType(typeArray));
    }
    JsFunction jsFunction = this.Result != null && this.Result is JsFunction ? (JsFunction) this.Result : throw new JsException((JsInstance) this.Global.ErrorClass.New("Function expected."));
    JsInstance[] parameters = new JsInstance[expression.Arguments.Count];
    for (int index = 0; index < expression.Arguments.Count; ++index)
    {
      expression.Arguments[index].Accept((IStatementVisitor) this);
      parameters[index] = this.Result;
    }
    this.Result = (JsInstance) jsFunction.Construct(parameters, (Type[]) null, (IJintVisitor) this);
  }

  public void Visit(TernaryExpression expression)
  {
    this.Result = (JsInstance) null;
    expression.LeftExpression.Accept((IStatementVisitor) this);
    JsInstance result = this.Result;
    this.Result = (JsInstance) null;
    this.EnsureIdentifierIsDefined((object) result);
    if (result.ToBoolean())
      expression.MiddleExpression.Accept((IStatementVisitor) this);
    else
      expression.RightExpression.Accept((IStatementVisitor) this);
  }

  public static bool IsNullOrUndefined(JsInstance o)
  {
    if (o == JsUndefined.Instance || o == JsNull.Instance)
      return true;
    return o.IsClr && o.Value == null;
  }

  public JsBoolean Compare(JsInstance x, JsInstance y)
  {
    if (x.IsClr && y.IsClr)
      return (x.Value is Decimal || y.Value is Decimal) && (x.Value is double || y.Value is double) ? this.Global.BooleanClass.New(Convert.ToDecimal(x.Value) == Convert.ToDecimal(y.Value)) : this.Global.BooleanClass.New(x.Value.Equals(y.Value));
    if (x.IsClr)
      return this.Compare(x.ToPrimitive(this.Global), y);
    if (y.IsClr)
      return this.Compare(x, y.ToPrimitive(this.Global));
    if (x.Type == y.Type)
    {
      if (x == JsUndefined.Instance || x == JsNull.Instance)
        return this.Global.BooleanClass.True;
      if (x.Type == "number")
        return x.ToNumber() == double.NaN || y.ToNumber() == double.NaN || x.ToNumber() != y.ToNumber() ? this.Global.BooleanClass.False : this.Global.BooleanClass.True;
      if (x.Type == "string")
        return this.Global.BooleanClass.New(x.ToString() == y.ToString());
      if (x.Type == "boolean")
        return this.Global.BooleanClass.New(x.ToBoolean() == y.ToBoolean());
      return x.Type == "object" ? this.Global.BooleanClass.New(x == y) : this.Global.BooleanClass.New(x.Value.Equals(y.Value));
    }
    if (x == JsNull.Instance && y == JsUndefined.Instance || x == JsUndefined.Instance && y == JsNull.Instance)
      return this.Global.BooleanClass.True;
    if (x.Type == "number" && y.Type == "string" || x.Type == "string" && y.Type == "number" || x.Type == "boolean" || y.Type == "boolean")
      return this.Global.BooleanClass.New(x.ToNumber() == y.ToNumber());
    if (y.Type == "object" && (x.Type == "string" || x.Type == "number"))
      return this.Compare(x, y.ToPrimitive(this.Global));
    return x.Type == "object" && (y.Type == "string" || y.Type == "number") ? this.Compare(x.ToPrimitive(this.Global), y) : this.Global.BooleanClass.False;
  }

  public bool CompareTo(JsInstance x, JsInstance y, out int result)
  {
    result = 0;
    if (x.IsClr && y.IsClr)
    {
      if (!(x.Value is IComparable comparable) || y.Value == null || comparable.GetType() != y.Value.GetType())
        return false;
      result = comparable.CompareTo(y.Value);
    }
    else if (x is JsString && y is JsString)
    {
      result = string.Compare(x.ToString(), y.ToString(), StringComparison.Ordinal);
    }
    else
    {
      double number1 = x.ToNumber();
      double number2 = y.ToNumber();
      if (double.IsNaN(number1) || double.IsNaN(number2))
        return false;
      result = number1 >= number2 ? (number1 != number2 ? 1 : 0) : -1;
    }
    return true;
  }

  public void Visit(BinaryExpression expression)
  {
    expression.LeftExpression.Accept((IStatementVisitor) this);
    this.EnsureIdentifierIsDefined((object) this.Result);
    JsInstance result1 = this.Result;
    if (expression.Type == BinaryExpressionType.And && !result1.ToBoolean())
      this.Result = result1;
    else if (expression.Type == BinaryExpressionType.Or && result1.ToBoolean())
    {
      this.Result = result1;
    }
    else
    {
      expression.RightExpression.Accept((IStatementVisitor) this);
      this.EnsureIdentifierIsDefined((object) this.Result);
      JsInstance result2 = this.Result;
      switch (expression.Type)
      {
        case BinaryExpressionType.And:
          this.Result = !result1.ToBoolean() ? (JsInstance) this.Global.BooleanClass.False : result2;
          break;
        case BinaryExpressionType.Or:
          this.Result = !result1.ToBoolean() ? result2 : result1;
          break;
        case BinaryExpressionType.NotEqual:
          this.Result = (JsInstance) this.Global.BooleanClass.New(!this.Compare(result1, result2).ToBoolean());
          break;
        case BinaryExpressionType.LesserOrEqual:
          int result3;
          this.Result = !this.CompareTo(result1, result2, out result3) || result3 > 0 ? (JsInstance) this.Global.BooleanClass.False : (JsInstance) this.Global.BooleanClass.True;
          break;
        case BinaryExpressionType.GreaterOrEqual:
          int result4;
          this.Result = !this.CompareTo(result1, result2, out result4) || result4 < 0 ? (JsInstance) this.Global.BooleanClass.False : (JsInstance) this.Global.BooleanClass.True;
          break;
        case BinaryExpressionType.Lesser:
          int result5;
          this.Result = !this.CompareTo(result1, result2, out result5) || result5 >= 0 ? (JsInstance) this.Global.BooleanClass.False : (JsInstance) this.Global.BooleanClass.True;
          break;
        case BinaryExpressionType.Greater:
          int result6;
          this.Result = !this.CompareTo(result1, result2, out result6) || result6 <= 0 ? (JsInstance) this.Global.BooleanClass.False : (JsInstance) this.Global.BooleanClass.True;
          break;
        case BinaryExpressionType.Equal:
          this.Result = (JsInstance) this.Compare(result1, result2);
          break;
        case BinaryExpressionType.Minus:
          this.Result = (JsInstance) this.Global.NumberClass.New(result1.ToNumber() - result2.ToNumber());
          break;
        case BinaryExpressionType.Plus:
          this.Result = result1.Class == "String" || result2.Class == "String" ? (JsInstance) this.Global.StringClass.New(result1.ToString() + result2.ToString()) : (JsInstance) this.Global.NumberClass.New(result1.ToNumber() + result2.ToNumber());
          break;
        case BinaryExpressionType.Modulo:
          this.Result = result2 == this.Global.NumberClass["NEGATIVE_INFINITY"] || result2 == this.Global.NumberClass["POSITIVE_INFINITY"] ? this.Global.NumberClass["POSITIVE_INFINITY"] : (result2.ToNumber() != 0.0 ? (JsInstance) this.Global.NumberClass.New(result1.ToNumber() % result2.ToNumber()) : this.Global.NumberClass["NaN"]);
          break;
        case BinaryExpressionType.Div:
          double number1 = result2.ToNumber();
          double number2 = result1.ToNumber();
          this.Result = result2 == this.Global.NumberClass["NEGATIVE_INFINITY"] || result2 == this.Global.NumberClass["POSITIVE_INFINITY"] ? (JsInstance) this.Global.NumberClass.New(0.0) : (number1 != 0.0 ? (JsInstance) this.Global.NumberClass.New(number2 / number1) : (number2 != 0.0 ? (number2 > 0.0 ? this.Global.NumberClass["POSITIVE_INFINITY"] : this.Global.NumberClass["NEGATIVE_INFINITY"]) : this.Global.NumberClass["NaN"]));
          break;
        case BinaryExpressionType.Times:
          this.Result = (JsInstance) this.Global.NumberClass.New(result1.ToNumber() * result2.ToNumber());
          break;
        case BinaryExpressionType.Pow:
          this.Result = (JsInstance) this.Global.NumberClass.New(Math.Pow(result1.ToNumber(), result2.ToNumber()));
          break;
        case BinaryExpressionType.BitwiseAnd:
          this.Result = result1 == JsUndefined.Instance || result2 == JsUndefined.Instance ? (JsInstance) this.Global.NumberClass.New(0.0) : (JsInstance) this.Global.NumberClass.New((double) (Convert.ToInt64(result1.ToNumber()) & Convert.ToInt64(result2.ToNumber())));
          break;
        case BinaryExpressionType.BitwiseOr:
          this.Result = result1 != JsUndefined.Instance ? (result2 != JsUndefined.Instance ? (JsInstance) this.Global.NumberClass.New((double) (Convert.ToInt64(result1.ToNumber()) | Convert.ToInt64(result2.ToNumber()))) : (JsInstance) this.Global.NumberClass.New((double) Convert.ToInt64(result1.ToNumber()))) : (result2 != JsUndefined.Instance ? (JsInstance) this.Global.NumberClass.New((double) Convert.ToInt64(result2.ToNumber())) : (JsInstance) this.Global.NumberClass.New(1.0));
          break;
        case BinaryExpressionType.BitwiseXOr:
          this.Result = result1 != JsUndefined.Instance ? (result2 != JsUndefined.Instance ? (JsInstance) this.Global.NumberClass.New((double) (Convert.ToInt64(result1.ToNumber()) ^ Convert.ToInt64(result2.ToNumber()))) : (JsInstance) this.Global.NumberClass.New((double) Convert.ToInt64(result1.ToNumber()))) : (result2 != JsUndefined.Instance ? (JsInstance) this.Global.NumberClass.New((double) Convert.ToInt64(result2.ToNumber())) : (JsInstance) this.Global.NumberClass.New(1.0));
          break;
        case BinaryExpressionType.Same:
          this.Result = !(result1.Type != result2.Type) ? (!(result1 is JsUndefined) ? (!(result1 is JsNull) ? (!(result1.Type == "number") ? (!(result1.Type == "string") ? (!(result1.Type == "boolean") ? (result1 != result2 ? (JsInstance) this.Global.BooleanClass.False : (JsInstance) this.Global.BooleanClass.True) : (JsInstance) this.Global.BooleanClass.New(result1.ToBoolean() == result2.ToBoolean())) : (JsInstance) this.Global.BooleanClass.New(result1.ToString() == result2.ToString())) : (result1 == this.Global.NumberClass["NaN"] || result2 == this.Global.NumberClass["NaN"] ? (JsInstance) this.Global.BooleanClass.False : (result1.ToNumber() != result2.ToNumber() ? (JsInstance) this.Global.BooleanClass.False : (JsInstance) this.Global.BooleanClass.True))) : (JsInstance) this.Global.BooleanClass.True) : (JsInstance) this.Global.BooleanClass.True) : (JsInstance) this.Global.BooleanClass.False;
          break;
        case BinaryExpressionType.NotSame:
          new BinaryExpression(BinaryExpressionType.Same, expression.LeftExpression, expression.RightExpression).Accept((IStatementVisitor) this);
          this.Result = (JsInstance) this.Global.BooleanClass.New(!this.Result.ToBoolean());
          break;
        case BinaryExpressionType.LeftShift:
          this.Result = result1 != JsUndefined.Instance ? (result2 != JsUndefined.Instance ? (JsInstance) this.Global.NumberClass.New((double) (Convert.ToInt64(result1.ToNumber()) << (int) Convert.ToUInt16(result2.ToNumber()))) : (JsInstance) this.Global.NumberClass.New((double) Convert.ToInt64(result1.ToNumber()))) : (JsInstance) this.Global.NumberClass.New(0.0);
          break;
        case BinaryExpressionType.RightShift:
          this.Result = result1 != JsUndefined.Instance ? (result2 != JsUndefined.Instance ? (JsInstance) this.Global.NumberClass.New((double) (Convert.ToInt64(result1.ToNumber()) >> (int) Convert.ToUInt16(result2.ToNumber()))) : (JsInstance) this.Global.NumberClass.New((double) Convert.ToInt64(result1.ToNumber()))) : (JsInstance) this.Global.NumberClass.New(0.0);
          break;
        case BinaryExpressionType.UnsignedRightShift:
          this.Result = result1 != JsUndefined.Instance ? (result2 != JsUndefined.Instance ? (JsInstance) this.Global.NumberClass.New((double) (Convert.ToInt64(result1.ToNumber()) >> (int) Convert.ToUInt16(result2.ToNumber()))) : (JsInstance) this.Global.NumberClass.New((double) Convert.ToInt64(result1.ToNumber()))) : (JsInstance) this.Global.NumberClass.New(0.0);
          break;
        case BinaryExpressionType.InstanceOf:
          JsFunction jsFunction = result2 as JsFunction;
          JsObject inst = result1 as JsObject;
          if (jsFunction == null)
            throw new JsException((JsInstance) this.Global.TypeErrorClass.New("Right argument should be a function: " + expression.RightExpression.ToString()));
          if (inst == null)
            throw new JsException((JsInstance) this.Global.TypeErrorClass.New("Left argument should be an object: " + expression.LeftExpression.ToString()));
          this.Result = (JsInstance) this.Global.BooleanClass.New(jsFunction.HasInstance(inst));
          break;
        case BinaryExpressionType.In:
          if (result2 is ILiteral)
            throw new JsException((JsInstance) this.Global.ErrorClass.New("Cannot apply 'in' operator to the specified member."));
          this.Result = (JsInstance) this.Global.BooleanClass.New(((JsDictionaryObject) result2).HasProperty(result1));
          break;
        default:
          throw new NotSupportedException("Unkown binary operator");
      }
      this.EvaluationResult = this.Result;
    }
  }

  public void Visit(UnaryExpression expression)
  {
    switch (expression.Type)
    {
      case UnaryExpressionType.TypeOf:
        try
        {
          expression.Expression.Accept((IStatementVisitor) this);
        }
        catch (JsIdentifierNotFoundException ex)
        {
          this.Result = (JsInstance) null;
        }
        this.Result = this.Result != null ? (!(this.Result is JsNull) ? (!(this.Result is JsFunction) ? (JsInstance) this.Global.StringClass.New(this.Result.Type) : (JsInstance) this.Global.StringClass.New("function")) : (JsInstance) this.Global.StringClass.New("object")) : (JsInstance) this.Global.StringClass.New(JsUndefined.Instance.Type);
        break;
      case UnaryExpressionType.Not:
        expression.Expression.Accept((IStatementVisitor) this);
        this.EnsureIdentifierIsDefined((object) this.Result);
        this.Result = (JsInstance) this.Global.BooleanClass.New(!this.Result.ToBoolean());
        break;
      case UnaryExpressionType.Negate:
        expression.Expression.Accept((IStatementVisitor) this);
        this.EnsureIdentifierIsDefined((object) this.Result);
        this.Result = (JsInstance) this.Global.NumberClass.New(-this.Result.ToNumber());
        break;
      case UnaryExpressionType.Positive:
        expression.Expression.Accept((IStatementVisitor) this);
        this.EnsureIdentifierIsDefined((object) this.Result);
        this.Result = (JsInstance) this.Global.NumberClass.New(this.Result.ToNumber());
        break;
      case UnaryExpressionType.PrefixPlusPlus:
        expression.Expression.Accept((IStatementVisitor) this);
        this.EnsureIdentifierIsDefined((object) this.Result);
        JsInstance jsInstance1 = (JsInstance) this.Global.NumberClass.New(this.Result.ToNumber() + 1.0);
        if (!(expression.Expression is MemberExpression left1))
          left1 = new MemberExpression(expression.Expression, (Expression) null);
        this.Assign(left1, jsInstance1);
        break;
      case UnaryExpressionType.PrefixMinusMinus:
        expression.Expression.Accept((IStatementVisitor) this);
        this.EnsureIdentifierIsDefined((object) this.Result);
        JsInstance jsInstance2 = (JsInstance) this.Global.NumberClass.New(this.Result.ToNumber() - 1.0);
        if (!(expression.Expression is MemberExpression left2))
          left2 = new MemberExpression(expression.Expression, (Expression) null);
        this.Assign(left2, jsInstance2);
        break;
      case UnaryExpressionType.PostfixPlusPlus:
        expression.Expression.Accept((IStatementVisitor) this);
        this.EnsureIdentifierIsDefined((object) this.Result);
        JsInstance result1 = this.Result;
        if (!(expression.Expression is MemberExpression left3))
          left3 = new MemberExpression(expression.Expression, (Expression) null);
        this.Assign(left3, (JsInstance) this.Global.NumberClass.New(result1.ToNumber() + 1.0));
        this.Result = result1;
        break;
      case UnaryExpressionType.PostfixMinusMinus:
        expression.Expression.Accept((IStatementVisitor) this);
        this.EnsureIdentifierIsDefined((object) this.Result);
        JsInstance result2 = this.Result;
        if (!(expression.Expression is MemberExpression left4))
          left4 = new MemberExpression(expression.Expression, (Expression) null);
        this.Assign(left4, (JsInstance) this.Global.NumberClass.New(result2.ToNumber() - 1.0));
        this.Result = result2;
        break;
      case UnaryExpressionType.Delete:
        if (!(expression.Expression is MemberExpression expression1))
          throw new NotImplementedException("delete");
        expression1.Previous.Accept((IStatementVisitor) this);
        this.EnsureIdentifierIsDefined((object) this.Result);
        JsInstance result3 = this.Result;
        string index = (string) null;
        if (expression1.Member is PropertyExpression)
          index = ((Identifier) expression1.Member).Text;
        if (expression1.Member is Indexer)
        {
          ((Indexer) expression1.Member).Index.Accept((IStatementVisitor) this);
          index = this.Result.ToString();
        }
        if (string.IsNullOrEmpty(index))
          throw new JsException((JsInstance) this.Global.TypeErrorClass.New());
        try
        {
          ((JsDictionaryObject) result3).Delete(index);
        }
        catch (JintException ex)
        {
          throw new JsException((JsInstance) this.Global.TypeErrorClass.New());
        }
        this.Result = result3;
        break;
      case UnaryExpressionType.Void:
        expression.Expression.Accept((IStatementVisitor) this);
        this.Result = (JsInstance) JsUndefined.Instance;
        break;
      case UnaryExpressionType.Inv:
        expression.Expression.Accept((IStatementVisitor) this);
        this.EnsureIdentifierIsDefined((object) this.Result);
        this.Result = (JsInstance) this.Global.NumberClass.New(0.0 - this.Result.ToNumber() - 1.0);
        break;
    }
    this.EvaluationResult = this.Result;
  }

  public void Visit(ValueExpression expression)
  {
    switch (expression.TypeCode)
    {
      case TypeCode.Boolean:
        this.Result = (JsInstance) this.Global.BooleanClass.New((bool) expression.Value);
        break;
      case TypeCode.Int32:
      case TypeCode.Single:
      case TypeCode.Double:
        this.Result = (JsInstance) this.Global.NumberClass.New(Convert.ToDouble(expression.Value));
        break;
      case TypeCode.String:
        this.Result = (JsInstance) this.Global.StringClass.New((string) expression.Value);
        break;
      default:
        this.Result = expression.Value as JsInstance;
        break;
    }
    this.EvaluationResult = this.Result;
  }

  public void Visit(FunctionExpression fe)
  {
    this.Result = (JsInstance) this.CreateFunction((IFunctionDeclaration) fe);
  }

  public void Visit(Statement expression) => throw new NotImplementedException();

  public void Visit(MemberExpression expression)
  {
    if (expression.Previous != null)
    {
      try
      {
        expression.Previous.Accept((IStatementVisitor) this);
      }
      catch (JsIdentifierNotFoundException ex)
      {
        throw new JsException(ex.Value);
      }
    }
    expression.Member.Accept((IStatementVisitor) this);
    if (this.Result != JsUndefined.Instance || this.typeFullname.Length <= 0)
      return;
    this.EnsureClrAllowed();
    Type type = this.typeResolver.ResolveType(this.typeFullname.ToString());
    if (!(type != (Type) null))
      return;
    this.Result = (JsInstance) this.Global.WrapClr((object) type);
    this.typeFullname = new StringBuilder();
  }

  public void EnsureIdentifierIsDefined(object value)
  {
    if (value == null)
      throw new JsException((JsInstance) this.Global.ReferenceErrorClass.New(this.lastIdentifier + " is not defined"));
  }

  public void Visit(Indexer indexer)
  {
    this.EnsureIdentifierIsDefined((object) this.Result);
    JsDictionaryObject result = (JsDictionaryObject) this.Result;
    indexer.Index.Accept((IStatementVisitor) this);
    if (result.IsClr)
      this.EnsureClrAllowed();
    if (result.Class == "String")
      this.SetResult((JsInstance) this.Global.StringClass.New(result.ToString()[Convert.ToInt32(this.Result.ToNumber())].ToString()), result);
    else if (result is JsObject && ((JsObject) result).Indexer != null)
      this.SetResult(((JsObject) result).Indexer.get((JsInstance) result, this.Result), result);
    else
      this.SetResult(result[this.Result], result);
    this.EvaluationResult = this.Result;
  }

  public void Visit(MethodCall methodCall)
  {
    JsDictionaryObject callTarget = this.CallTarget;
    JsInstance result = this.Result;
    if ((result == JsUndefined.Instance || this.Result == null) && string.IsNullOrEmpty(this.lastIdentifier))
      throw new JsException((JsInstance) this.Global.TypeErrorClass.New("Method isn't defined"));
    Type[] genericParameters = (Type[]) null;
    if (methodCall.Generics.Count > 0)
    {
      genericParameters = new Type[methodCall.Generics.Count];
      try
      {
        int index = 0;
        foreach (Statement generic in methodCall.Generics)
        {
          generic.Accept((IStatementVisitor) this);
          genericParameters[index] = this.Global.Marshaller.MarshalJsValue<Type>(this.Result);
          ++index;
        }
      }
      catch (Exception ex)
      {
        throw new JintException("A type parameter is required", ex);
      }
    }
    JsInstance[] parameters = new JsInstance[methodCall.Arguments.Count];
    if (methodCall.Arguments.Count > 0)
    {
      for (int index = 0; index < methodCall.Arguments.Count; ++index)
      {
        methodCall.Arguments[index].Accept((IStatementVisitor) this);
        parameters[index] = this.Result;
      }
    }
    JsFunction function = result is JsFunction ? (JsFunction) result : throw new JsException((JsInstance) this.Global.ErrorClass.New("Function expected."));
    if (this.DebugMode)
    {
      string str = function.Name + "(";
      string[] strArray = new string[parameters.Length];
      for (int index = 0; index < parameters.Length; ++index)
        strArray[index] = parameters[index] == null ? "null" : parameters[index].ToSource();
      this.CallStack.Push(str + string.Join(", ", strArray) + ")");
    }
    this.returnInstance = (JsInstance) JsUndefined.Instance;
    JsInstance[] jsInstanceArray = new JsInstance[parameters.Length];
    parameters.CopyTo((Array) jsInstanceArray, 0);
    JsInstance evaluationResult = this.EvaluationResult;
    this.ExecuteFunction(function, callTarget, parameters, genericParameters);
    this.EvaluationResult = evaluationResult;
    for (int index = 0; index < jsInstanceArray.Length; ++index)
    {
      if (jsInstanceArray[index] != parameters[index])
      {
        if (methodCall.Arguments[index] is MemberExpression && ((MemberExpression) methodCall.Arguments[index]).Member is IAssignable)
          this.Assign((MemberExpression) methodCall.Arguments[index], parameters[index]);
        else if (methodCall.Arguments[index] is Identifier)
          this.Assign(new MemberExpression(methodCall.Arguments[index], (Expression) null), parameters[index]);
      }
    }
    if (this.DebugMode)
      this.CallStack.Pop();
    this.Result = this.returnInstance;
    this.EvaluationResult = this.returnInstance;
    this.returnInstance = (JsInstance) JsUndefined.Instance;
  }

  public void ExecuteFunction(
    JsFunction function,
    JsDictionaryObject that,
    JsInstance[] parameters)
  {
    this.ExecuteFunction(function, that, parameters, (Type[]) null);
  }

  public void ExecuteFunction(
    JsFunction function,
    JsDictionaryObject that,
    JsInstance[] parameters,
    Type[] genericParameters)
  {
    if (function == null)
      return;
    if (this.recursionLevel++ > this.MaxRecursions)
      throw new JsException((JsInstance) this.Global.ErrorClass.New("Too many recursions in the script."));
    JsArguments that1 = new JsArguments(this.Global, function, parameters);
    JsScope jsScope = new JsScope(function.Scope ?? this.GlobalScope);
    jsScope.ParentScope = function.Scope ?? this.GlobalScope;
    for (int index = 0; index < function.Arguments.Count; ++index)
    {
      if (index < parameters.Length)
        jsScope.DefineOwnProperty((Descriptor) new LinkedDescriptor((JsDictionaryObject) jsScope, function.Arguments[index], that1.GetDescriptor(index.ToString()), (JsDictionaryObject) that1));
      else
        jsScope.DefineOwnProperty((Descriptor) new ValueDescriptor((JsDictionaryObject) jsScope, function.Arguments[index], (JsInstance) JsUndefined.Instance));
    }
    if (this.HasOption(Options.Strict))
      jsScope.DefineOwnProperty(JsScope.ARGUMENTS, (JsInstance) that1);
    else
      that1.DefineOwnProperty(JsScope.ARGUMENTS, (JsInstance) that1);
    if (that != null)
      jsScope.DefineOwnProperty(JsScope.THIS, (JsInstance) that);
    else
      jsScope.DefineOwnProperty(JsScope.THIS, (JsInstance) (that = (JsDictionaryObject) (this.Global as JsObject)));
    this.EnterScope(jsScope);
    try
    {
      this.PermissionSet.PermitOnly();
      this.Result = genericParameters == null || genericParameters.Length <= 0 ? function.Execute((IJintVisitor) this, that, parameters) : function.Execute((IJintVisitor) this, that, parameters, genericParameters);
      if (!this.exit)
        return;
      this.exit = false;
    }
    finally
    {
      this.ExitScope();
      CodeAccessPermission.RevertPermitOnly();
      --this.recursionLevel;
    }
  }

  private bool HasOption(Options options) => this.Global.HasOption(options);

  public void Visit(PropertyExpression expression)
  {
    if (!(this.Result is JsDictionaryObject result1) || result1 == JsUndefined.Instance || result1 == JsNull.Instance)
      throw new JsException((JsInstance) this.Global.TypeErrorClass.New($"An object is required: {this.lastIdentifier} while resolving property {expression.Text}"));
    this.Result = (JsInstance) null;
    string index = this.lastIdentifier = expression.Text;
    JsInstance result2 = (JsInstance) null;
    if (result1 != null && result1.TryGetProperty(index, out result2))
    {
      this.SetResult(result2, result1);
      this.EvaluationResult = this.Result;
    }
    else
    {
      if (this.Result == null && this.typeFullname.Length > 0)
        this.typeFullname.Append('.').Append(index);
      this.SetResult((JsInstance) JsUndefined.Instance, result1);
      this.EvaluationResult = this.Result;
    }
  }

  public void Visit(PropertyDeclarationExpression expression)
  {
    JsDictionaryObject result = this.Result as JsDictionaryObject;
    switch (expression.Mode)
    {
      case PropertyExpressionType.Data:
        expression.Expression.Accept((IStatementVisitor) this);
        result.DefineOwnProperty((Descriptor) new ValueDescriptor(result, expression.Name, this.Result));
        break;
      case PropertyExpressionType.Get:
      case PropertyExpressionType.Set:
        JsFunction jsFunction1 = (JsFunction) null;
        JsFunction jsFunction2 = (JsFunction) null;
        if (expression.GetExpression != null)
        {
          expression.GetExpression.Accept((IStatementVisitor) this);
          jsFunction1 = (JsFunction) this.Result;
        }
        if (expression.SetExpression != null)
        {
          expression.SetExpression.Accept((IStatementVisitor) this);
          jsFunction2 = (JsFunction) this.Result;
        }
        JsDictionaryObject dictionaryObject = result;
        PropertyDescriptor propertyDescriptor = new PropertyDescriptor(this.Global, result, expression.Name);
        propertyDescriptor.GetFunction = jsFunction1;
        propertyDescriptor.SetFunction = jsFunction2;
        propertyDescriptor.Enumerable = true;
        PropertyDescriptor currentDescriptor = propertyDescriptor;
        dictionaryObject.DefineOwnProperty((Descriptor) currentDescriptor);
        break;
    }
  }

  public void Visit(Identifier expression)
  {
    this.Result = (JsInstance) null;
    string index = this.lastIdentifier = expression.Text;
    Descriptor result = (Descriptor) null;
    for (JsScope jsScope = this.CurrentScope; jsScope != null; jsScope = jsScope.ParentScope)
    {
      if (jsScope.TryGetDescriptor(index, out result))
      {
        if (!result.isReference)
        {
          this.SetResult(result.Get((JsDictionaryObject) this.CurrentScope), (JsDictionaryObject) this.CurrentScope);
        }
        else
        {
          LinkedDescriptor linkedDescriptor = result as LinkedDescriptor;
          this.SetResult(linkedDescriptor.Get((JsDictionaryObject) this.CurrentScope), linkedDescriptor.targetObject);
        }
        if (this.Result != null)
        {
          this.EvaluationResult = this.Result;
          return;
        }
      }
    }
    if (index == "null")
      this.Result = (JsInstance) JsNull.Instance;
    if (index == "undefined")
      this.Result = (JsInstance) JsUndefined.Instance;
    this.EvaluationResult = this.Result;
    if (this.Result == null)
      throw new JsIdentifierNotFoundException((JsInstance) this.Global.TypeErrorClass.New($"{index} is not defined"));
  }

  private void EnsureClrAllowed()
  {
    if (!this.AllowClr)
      throw new SecurityException("Use of Clr is not allowed");
  }

  public void Visit(JsonExpression json)
  {
    JsObject jsObject = this.Global.ObjectClass.New();
    foreach (KeyValuePair<string, Expression> keyValuePair in json.Values)
    {
      this.Result = (JsInstance) jsObject;
      keyValuePair.Value.Accept((IStatementVisitor) this);
    }
    this.Result = (JsInstance) jsObject;
  }

  protected void ResetContinueIfPresent(string label)
  {
    if (this.continueStatement == null || !(this.continueStatement.Label == label))
      return;
    this.continueStatement = (ContinueStatement) null;
  }

  protected bool StopStatementFlow()
  {
    return this.exit || this.breakStatement != null || this.continueStatement != null;
  }

  public void Visit(ArrayDeclaration expression)
  {
    JsArray jsArray = this.Global.ArrayClass.New();
    int count = expression.Parameters.Count;
    for (int index = 0; index < expression.Parameters.Count; ++index)
    {
      expression.Parameters[index].Accept((IStatementVisitor) this);
      jsArray[index.ToString()] = this.Result;
    }
    this.Result = (JsInstance) jsArray;
  }

  public void Visit(RegexpExpression expression)
  {
    this.Result = (JsInstance) this.Global.RegExpClass.New(expression.Regexp, expression.Options.Contains("g"), expression.Options.Contains("i"), expression.Options.Contains("m"));
  }

  public void OnDeserialization(object sender)
  {
    this.typeResolver = (ITypeResolver) new CachedTypeResolver();
  }

  private struct ResultInfo
  {
    public JsDictionaryObject baseObject;
    public JsInstance result;
  }
}
