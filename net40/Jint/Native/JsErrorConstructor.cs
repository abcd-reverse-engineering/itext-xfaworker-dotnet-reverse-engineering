// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsErrorConstructor
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using Jint.Delegates;
using Jint.Expressions;
using System;

#nullable disable
namespace Jint.Native;

[Serializable]
public class JsErrorConstructor : JsConstructor
{
  private string errorType;

  public JsErrorConstructor(IGlobal global, string errorType)
    : base(global)
  {
    this.errorType = errorType;
    this.Name = errorType;
    this.DefineOwnProperty(JsFunction.PROTOTYPE, (JsInstance) global.ObjectClass.New((JsFunction) this), PropertyAttributes.ReadOnly | PropertyAttributes.DontEnum | PropertyAttributes.DontDelete);
  }

  public override void InitPrototype(IGlobal global)
  {
    JsObject prototypeProperty = this.PrototypeProperty;
    prototypeProperty.DefineOwnProperty("name", (JsInstance) global.StringClass.New(this.errorType), PropertyAttributes.ReadOnly | PropertyAttributes.DontEnum | PropertyAttributes.DontDelete);
    prototypeProperty.DefineOwnProperty("toString", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new JintFunc<JsDictionaryObject, JsInstance[], JsInstance>(this.ToStringImpl)), PropertyAttributes.DontEnum);
    prototypeProperty.DefineOwnProperty("toLocaleString", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new JintFunc<JsDictionaryObject, JsInstance[], JsInstance>(this.ToStringImpl)), PropertyAttributes.DontEnum);
  }

  public JsError New(string message)
  {
    JsError jsError = new JsError(this.Global);
    jsError[nameof (message)] = (JsInstance) this.Global.StringClass.New(message);
    return jsError;
  }

  public JsError New() => this.New(string.Empty);

  public override JsInstance Execute(
    IJintVisitor visitor,
    JsDictionaryObject that,
    JsInstance[] parameters)
  {
    if (that == null || that as IGlobal == visitor.Global)
    {
      visitor.Return(parameters.Length > 0 ? (JsInstance) this.New(parameters[0].ToString()) : (JsInstance) this.New());
    }
    else
    {
      if (parameters.Length > 0)
        that.Value = (object) parameters[0].ToString();
      else
        that.Value = (object) string.Empty;
      visitor.Return((JsInstance) that);
    }
    return (JsInstance) that;
  }

  public JsInstance ToStringImpl(JsDictionaryObject target, JsInstance[] parameters)
  {
    return (JsInstance) this.Global.StringClass.New($"{(object) target["name"]}: {(object) target["message"]}");
  }

  public override JsObject Construct(
    JsInstance[] parameters,
    System.Type[] genericArgs,
    IJintVisitor visitor)
  {
    return parameters == null || parameters.Length <= 0 ? (JsObject) visitor.Global.ErrorClass.New() : (JsObject) visitor.Global.ErrorClass.New(parameters[0].ToString());
  }
}
