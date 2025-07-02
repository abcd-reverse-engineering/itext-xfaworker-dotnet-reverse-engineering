﻿// Decompiled with JetBrains decompiler
// Type: Jint.JintEngine
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using Antlr.Runtime;
using Jint.Debugger;
using Jint.Delegates;
using Jint.Expressions;
using Jint.Native;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
using System.Security.Permissions;
using System.Text;

#nullable disable
namespace Jint;

[Serializable]
public class JintEngine
{
  protected ExecutionVisitor visitor;
  private PermissionSet permissionSet;

  [DebuggerStepThrough]
  public JintEngine()
    : this(Options.Strict | Options.Ecmascript5)
  {
  }

  [DebuggerStepThrough]
  public JintEngine(Options options)
  {
    this.visitor = new ExecutionVisitor(options);
    JintEngine.InitGlobal(this.visitor.Global);
    this.AllowClr = true;
    this.permissionSet = new PermissionSet(PermissionState.None);
    this.MaxRecursions = 400;
    this.BreakPoints = new List<BreakPoint>();
  }

  [DebuggerStepThrough]
  public JintEngine(IGlobal global, JsScope globalScope)
  {
    this.visitor = new ExecutionVisitor(global, globalScope);
    this.AllowClr = true;
    this.permissionSet = new PermissionSet(PermissionState.Unrestricted);
    this.MaxRecursions = 400;
    this.BreakPoints = new List<BreakPoint>();
  }

  [DebuggerStepThrough]
  public JintEngine(ExecutionVisitor visitor)
  {
    this.visitor = visitor;
    this.AllowClr = true;
    this.permissionSet = new PermissionSet(PermissionState.None);
    this.MaxRecursions = 400;
    this.BreakPoints = new List<BreakPoint>();
  }

  public static void InitGlobal(IGlobal Global)
  {
    JsObject jsObject = Global as JsObject;
    jsObject["ToBoolean"] = (JsInstance) Global.FunctionClass.New((Delegate) new JintFunc<object, bool>(Convert.ToBoolean));
    jsObject["ToByte"] = (JsInstance) Global.FunctionClass.New((Delegate) new JintFunc<object, byte>(Convert.ToByte));
    jsObject["ToChar"] = (JsInstance) Global.FunctionClass.New((Delegate) new JintFunc<object, char>(Convert.ToChar));
    jsObject["ToDateTime"] = (JsInstance) Global.FunctionClass.New((Delegate) new JintFunc<object, DateTime>(Convert.ToDateTime));
    jsObject["ToDecimal"] = (JsInstance) Global.FunctionClass.New((Delegate) new JintFunc<object, Decimal>(Convert.ToDecimal));
    jsObject["ToDouble"] = (JsInstance) Global.FunctionClass.New((Delegate) new JintFunc<object, double>(Convert.ToDouble));
    jsObject["ToInt16"] = (JsInstance) Global.FunctionClass.New((Delegate) new JintFunc<object, short>(Convert.ToInt16));
    jsObject["ToInt32"] = (JsInstance) Global.FunctionClass.New((Delegate) new JintFunc<object, int>(Convert.ToInt32));
    jsObject["ToInt64"] = (JsInstance) Global.FunctionClass.New((Delegate) new JintFunc<object, long>(Convert.ToInt64));
    jsObject["ToSByte"] = (JsInstance) Global.FunctionClass.New((Delegate) new JintFunc<object, sbyte>(Convert.ToSByte));
    jsObject["ToSingle"] = (JsInstance) Global.FunctionClass.New((Delegate) new JintFunc<object, float>(Convert.ToSingle));
    jsObject["ToString"] = (JsInstance) Global.FunctionClass.New((Delegate) new JintFunc<object, string>(Convert.ToString));
    jsObject["ToUInt16"] = (JsInstance) Global.FunctionClass.New((Delegate) new JintFunc<object, ushort>(Convert.ToUInt16));
    jsObject["ToUInt32"] = (JsInstance) Global.FunctionClass.New((Delegate) new JintFunc<object, uint>(Convert.ToUInt32));
    jsObject["ToUInt64"] = (JsInstance) Global.FunctionClass.New((Delegate) new JintFunc<object, ulong>(Convert.ToUInt64));
  }

  public IGlobal Global => this.visitor.Global;

  public JsScope GlobalScope => this.visitor.GlobalScope;

  public ExecutionVisitor Visitor => this.visitor;

  public bool AllowClr
  {
    get => this.visitor.AllowClr;
    set => this.visitor.AllowClr = value;
  }

  public static Program Compile(string source, bool debugInformation)
  {
    Program program = (Program) null;
    if (!string.IsNullOrEmpty(source))
    {
      ES3Parser es3Parser = new ES3Parser((ITokenStream) new CommonTokenStream((ITokenSource) new ES3Lexer((ICharStream) new ANTLRStringStream(source))))
      {
        DebugMode = debugInformation
      };
      program = es3Parser.program().value;
      if (es3Parser.Errors != null && es3Parser.Errors.Count > 0)
        throw new JintException(string.Join(Environment.NewLine, es3Parser.Errors.ToArray()));
    }
    return program;
  }

  public static bool HasErrors(string script, out string errors)
  {
    try
    {
      errors = (string) null;
      return JintEngine.Compile(script, false) != null;
    }
    catch (Exception ex)
    {
      errors = ex.Message;
      return true;
    }
  }

  public object Run(string script) => this.Run(script, true);

  public object Run(Program program) => this.Run(program, true);

  public object Run(TextReader reader) => this.Run(reader.ReadToEnd());

  public object Run(TextReader reader, bool unwrap) => this.Run(reader.ReadToEnd(), unwrap);

  public object Run(string script, bool unwrap)
  {
    if (script == null)
      throw new ArgumentException("Script can't be null", nameof (script));
    Program program;
    try
    {
      program = JintEngine.Compile(script, this.DebugMode);
    }
    catch (Exception ex)
    {
      throw new JintException("An unexpected error occured while parsing the script", ex);
    }
    if (program == null)
      return (object) null;
    return this.Run(program, unwrap);
  }

  public object Run(Program program, bool unwrap)
  {
    if (program == null)
      throw new ArgumentException("Script can't be null", "script");
    this.visitor.DebugMode = this.DebugMode;
    this.visitor.MaxRecursions = this.MaxRecursions;
    this.visitor.PermissionSet = this.permissionSet;
    if (this.DebugMode)
      this.visitor.Step += new EventHandler<DebugInformation>(this.OnStep);
    try
    {
      this.visitor.Visit(program);
    }
    catch (SecurityException ex)
    {
      throw;
    }
    catch (JsException ex)
    {
      string message = ex.Message;
      if (ex.Value is JsError)
        message = ex.Value.Value.ToString();
      StringBuilder stringBuilder = new StringBuilder();
      string str = string.Empty;
      if (this.DebugMode)
      {
        while (this.visitor.CallStack.Count > 0)
          stringBuilder.AppendLine(this.visitor.CallStack.Pop());
        if (stringBuilder.Length > 0)
          stringBuilder.Insert(0, $"{Environment.NewLine}------ Stack Trace:{Environment.NewLine}");
      }
      if (this.visitor.CurrentStatement.Source != null)
        str = Environment.NewLine + this.visitor.CurrentStatement.Source.ToString() + Environment.NewLine + this.visitor.CurrentStatement.Source.Code;
      throw new JintException(message + str + (object) stringBuilder, (Exception) ex);
    }
    catch (Exception ex)
    {
      StringBuilder stringBuilder = new StringBuilder();
      string str = string.Empty;
      if (this.DebugMode)
      {
        while (this.visitor.CallStack.Count > 0)
          stringBuilder.AppendLine(this.visitor.CallStack.Pop());
        if (stringBuilder.Length > 0)
          stringBuilder.Insert(0, $"{Environment.NewLine}------ Stack Trace:{Environment.NewLine}");
      }
      if (this.visitor.CurrentStatement != null && this.visitor.CurrentStatement.Source != null)
        str = Environment.NewLine + this.visitor.CurrentStatement.Source.ToString() + Environment.NewLine + this.visitor.CurrentStatement.Source.Code;
      throw new JintException(ex.Message + str + (object) stringBuilder, ex);
    }
    finally
    {
      this.visitor.Step -= new EventHandler<DebugInformation>(this.OnStep);
    }
    if (this.visitor.EvaluationResult == null)
      return (object) null;
    return !unwrap ? (object) this.visitor.EvaluationResult : this.visitor.Global.Marshaller.MarshalJsValue<object>(this.visitor.EvaluationResult);
  }

  public event EventHandler<DebugInformation> Step;

  public event EventHandler<DebugInformation> Break;

  public List<BreakPoint> BreakPoints { get; private set; }

  public bool DebugMode { get; private set; }

  public int MaxRecursions { get; private set; }

  public List<string> WatchList { get; set; }

  public JintEngine SetDebugMode(bool debugMode)
  {
    this.DebugMode = debugMode;
    return this;
  }

  public JintEngine SetMaxRecursions(int maxRecursions)
  {
    this.MaxRecursions = maxRecursions;
    return this;
  }

  public JintEngine SetParameter(string name, object value)
  {
    this.visitor.GlobalScope[name] = (JsInstance) this.visitor.Global.WrapClr(value);
    return this;
  }

  public JintEngine SetParameter(string name, double value)
  {
    this.visitor.GlobalScope[name] = (JsInstance) this.visitor.Global.NumberClass.New(value);
    return this;
  }

  public JintEngine SetParameter(string name, string value)
  {
    if (value == null)
      this.visitor.GlobalScope[name] = (JsInstance) JsNull.Instance;
    else
      this.visitor.GlobalScope[name] = (JsInstance) this.visitor.Global.StringClass.New(value);
    return this;
  }

  public JintEngine SetParameter(string name, int value)
  {
    this.visitor.GlobalScope[name] = (JsInstance) this.visitor.Global.WrapClr((object) value);
    return this;
  }

  public JintEngine SetParameter(string name, bool value)
  {
    this.visitor.GlobalScope[name] = (JsInstance) this.visitor.Global.BooleanClass.New(value);
    return this;
  }

  public JintEngine SetParameter(string name, DateTime value)
  {
    this.visitor.GlobalScope[name] = (JsInstance) this.visitor.Global.DateClass.New(value);
    return this;
  }

  public JintEngine AddPermission(IPermission perm)
  {
    this.permissionSet.AddPermission(perm);
    return this;
  }

  public JintEngine SetFunction(string name, JsFunction function)
  {
    this.visitor.GlobalScope[name] = (JsInstance) function;
    return this;
  }

  public object CallFunction(string name, params object[] args)
  {
    JsInstance result = this.visitor.Result;
    this.visitor.Visit(new Identifier(name));
    object obj = this.CallFunction((JsFunction) this.visitor.Result, args);
    this.visitor.Result = result;
    return obj;
  }

  public object CallFunction(JsFunction function, params object[] args)
  {
    this.visitor.ExecuteFunction(function, (JsDictionaryObject) null, Array.ConvertAll<object, JsInstance>(args, (Converter<object, JsInstance>) (x => this.visitor.Global.Marshaller.MarshalClrValue<object>(x))));
    return this.visitor.Global.Marshaller.MarshalJsValue<object>(this.visitor.Returned);
  }

  public JintEngine SetFunction(string name, Delegate function)
  {
    this.visitor.GlobalScope[name] = (JsInstance) this.visitor.Global.FunctionClass.New(function);
    return this;
  }

  public static string EscapteStringLiteral(string value)
  {
    return value.Replace("\\", "\\\\").Replace("'", "\\'").Replace(Environment.NewLine, "\\r\\n");
  }

  protected void OnStep(object sender, DebugInformation info)
  {
    if (this.Step != null)
      this.Step((object) this, info);
    if (this.Break == null || this.BreakPoints.Find((Predicate<BreakPoint>) (l =>
    {
      if (l.Line <= info.CurrentStatement.Source.Start.Line && (l.Line != info.CurrentStatement.Source.Start.Line || l.Char < info.CurrentStatement.Source.Start.Char) || l.Line >= info.CurrentStatement.Source.Stop.Line && (l.Line != info.CurrentStatement.Source.Stop.Line || l.Char > info.CurrentStatement.Source.Stop.Char))
        return false;
      return string.IsNullOrEmpty(l.Condition) || Convert.ToBoolean(this.Run(l.Condition));
    })) == null)
      return;
    this.Break((object) this, info);
  }

  protected void OnBreak(object sender, DebugInformation info)
  {
    if (this.Break == null)
      return;
    this.Break((object) this, info);
  }

  public JintEngine DisableSecurity()
  {
    this.permissionSet = new PermissionSet(PermissionState.Unrestricted);
    return this;
  }

  public JintEngine EnableSecurity()
  {
    this.permissionSet = new PermissionSet(PermissionState.None);
    return this;
  }

  public void Save(Stream s) => new BinaryFormatter().Serialize(s, (object) this.visitor);

  public static void Load(JintEngine engine, Stream s)
  {
    ExecutionVisitor executionVisitor = (ExecutionVisitor) new BinaryFormatter().Deserialize(s);
    engine.visitor = executionVisitor;
  }

  public static JintEngine Load(Stream s)
  {
    JintEngine engine = new JintEngine();
    JintEngine.Load(engine, s);
    return engine;
  }
}
