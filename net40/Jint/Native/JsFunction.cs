// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsFunction
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using Jint.Expressions;
using System;
using System.Collections.Generic;

#nullable disable
namespace Jint.Native;

[Serializable]
public class JsFunction : JsObject
{
  public static string CALL = "call";
  public static string APPLY = "apply";
  public static string CONSTRUCTOR = "constructor";
  public static string PROTOTYPE = "prototype";

  public string Name { get; set; }

  public Statement Statement { get; set; }

  public List<string> Arguments { get; set; }

  public JsScope Scope { get; set; }

  public JsFunction(IGlobal global, Statement statement)
    : this(global.FunctionClass.PrototypeProperty)
  {
    this.Statement = statement;
  }

  public JsFunction(IGlobal global)
    : this(global.FunctionClass.PrototypeProperty)
  {
  }

  public JsFunction(JsObject prototype)
    : base(prototype)
  {
    this.Arguments = new List<string>();
    this.Statement = (Statement) new EmptyStatement();
    this.DefineOwnProperty(JsFunction.PROTOTYPE, (JsInstance) JsNull.Instance, PropertyAttributes.DontEnum);
  }

  public override int Length
  {
    get => this.Arguments.Count;
    set
    {
    }
  }

  public JsObject PrototypeProperty
  {
    get => this[JsFunction.PROTOTYPE] as JsObject;
    set => this[JsFunction.PROTOTYPE] = (JsInstance) value;
  }

  public virtual bool HasInstance(JsObject inst)
  {
    return inst != null && inst != JsNull.Instance && inst != JsNull.Instance && this.PrototypeProperty.IsPrototypeOf((JsDictionaryObject) inst);
  }

  public virtual JsObject Construct(
    JsInstance[] parameters,
    System.Type[] genericArgs,
    IJintVisitor visitor)
  {
    JsObject _this = visitor.Global.ObjectClass.New(this.PrototypeProperty);
    visitor.ExecuteFunction(this, (JsDictionaryObject) _this, parameters);
    return visitor.Result is JsObject result ? result : _this;
  }

  public override bool IsClr => false;

  public override object Value
  {
    get => (object) null;
    set
    {
    }
  }

  public virtual JsInstance Execute(
    IJintVisitor visitor,
    JsDictionaryObject that,
    JsInstance[] parameters)
  {
    this.Statement.Accept((IStatementVisitor) visitor);
    return (JsInstance) that;
  }

  public virtual JsInstance Execute(
    IJintVisitor visitor,
    JsDictionaryObject that,
    JsInstance[] parameters,
    System.Type[] genericArguments)
  {
    throw new JintException("This method can't be called as a generic");
  }

  public override string Class => "Function";

  public override string ToSource()
  {
    return $"function {this.Name} ( {string.Join(", ", this.Arguments.ToArray())} ) {{ {this.GetBody()} }}";
  }

  public virtual string GetBody() => "/* js code */";

  public override string ToString() => this.ToSource();

  public override bool ToBoolean() => true;

  public override double ToNumber() => 1.0;
}
