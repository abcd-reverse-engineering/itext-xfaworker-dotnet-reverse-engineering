// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsBooleanConstructor
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using Jint.Delegates;
using Jint.Expressions;
using System;

#nullable disable
namespace Jint.Native;

[Serializable]
public class JsBooleanConstructor : JsConstructor
{
  public JsBoolean False { get; private set; }

  public JsBoolean True { get; private set; }

  public JsBooleanConstructor(IGlobal global)
    : base(global)
  {
    this.Name = "Boolean";
    this.DefineOwnProperty(JsFunction.PROTOTYPE, (JsInstance) global.ObjectClass.New((JsFunction) this), PropertyAttributes.ReadOnly | PropertyAttributes.DontEnum | PropertyAttributes.DontDelete);
    this.True = this.New(true);
    this.False = this.New(false);
  }

  public override void InitPrototype(IGlobal global)
  {
    JsObject prototypeProperty = this.PrototypeProperty;
    prototypeProperty.DefineOwnProperty("toString", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new JintFunc<JsDictionaryObject, JsInstance[], JsInstance>(this.ToString2)), PropertyAttributes.DontEnum);
    prototypeProperty.DefineOwnProperty("toLocaleString", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new JintFunc<JsDictionaryObject, JsInstance[], JsInstance>(this.ToString2)), PropertyAttributes.DontEnum);
  }

  public JsBoolean New() => this.New(false);

  public JsBoolean New(bool value) => new JsBoolean(value, this.PrototypeProperty);

  public override JsInstance Execute(
    IJintVisitor visitor,
    JsDictionaryObject that,
    JsInstance[] parameters)
  {
    if (that == null || that as IGlobal == visitor.Global)
    {
      visitor.Return(parameters.Length > 0 ? (JsInstance) new JsBoolean(parameters[0].ToBoolean(), this.PrototypeProperty) : (JsInstance) new JsBoolean(this.PrototypeProperty));
    }
    else
    {
      if (parameters.Length > 0)
        that.Value = (object) parameters[0].ToBoolean();
      else
        that.Value = (object) false;
      visitor.Return((JsInstance) that);
    }
    return (JsInstance) that;
  }

  public JsInstance ToString2(JsDictionaryObject target, JsInstance[] parameters)
  {
    return (JsInstance) this.Global.StringClass.New(target.ToString());
  }
}
