// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsApplyFunction
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using Jint.Expressions;
using System;

#nullable disable
namespace Jint.Native;

[Serializable]
public class JsApplyFunction : JsFunction
{
  public JsApplyFunction(JsFunctionConstructor constructor)
    : base(constructor.PrototypeProperty)
  {
    this.DefineOwnProperty("length", (JsInstance) constructor.Global.NumberClass.New(2.0), PropertyAttributes.ReadOnly);
  }

  public override JsInstance Execute(
    IJintVisitor visitor,
    JsDictionaryObject that,
    JsInstance[] parameters)
  {
    if (!(that is JsFunction function))
      throw new ArgumentException("the target of call() must be a function");
    JsDictionaryObject _this = parameters.Length < 1 || parameters[0] == JsUndefined.Instance || parameters[0] == JsNull.Instance ? visitor.Global as JsDictionaryObject : parameters[0] as JsDictionaryObject;
    JsInstance[] _parameters;
    if (parameters.Length >= 2 && parameters[1] != JsNull.Instance)
    {
      _parameters = parameters[1] is JsObject parameter ? new JsInstance[parameter.Length] : throw new JsException((JsInstance) visitor.Global.TypeErrorClass.New("second argument must be an array"));
      for (int index = 0; index < parameter.Length; ++index)
        _parameters[index] = parameter[index.ToString()];
    }
    else
      _parameters = JsInstance.EMPTY;
    visitor.ExecuteFunction(function, _this, _parameters);
    return visitor.Result;
  }
}
