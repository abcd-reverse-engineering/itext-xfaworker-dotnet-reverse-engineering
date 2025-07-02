// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsArguments
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using Jint.Delegates;
using System;

#nullable disable
namespace Jint.Native;

[Serializable]
public class JsArguments : JsObject
{
  public const string CALLEE = "callee";
  protected ValueDescriptor calleeDescriptor;
  private int length;
  private IGlobal global;

  protected JsFunction Callee
  {
    get => this["callee"] as JsFunction;
    set => this["callee"] = (JsInstance) value;
  }

  public JsArguments(IGlobal global, JsFunction callee, JsInstance[] arguments)
    : base(global.ObjectClass.New())
  {
    this.global = global;
    for (int index = 0; index < arguments.Length; ++index)
    {
      ValueDescriptor currentDescriptor = new ValueDescriptor((JsDictionaryObject) this, index.ToString(), arguments[index]);
      currentDescriptor.Enumerable = false;
      this.DefineOwnProperty((Descriptor) currentDescriptor);
    }
    this.length = arguments.Length;
    ValueDescriptor valueDescriptor = new ValueDescriptor((JsDictionaryObject) this, nameof (callee), (JsInstance) callee);
    valueDescriptor.Enumerable = false;
    this.calleeDescriptor = valueDescriptor;
    this.DefineOwnProperty((Descriptor) this.calleeDescriptor);
    PropertyDescriptor<JsArguments> currentDescriptor1 = new PropertyDescriptor<JsArguments>(global, (JsDictionaryObject) this, nameof (length), new JintFunc<JsArguments, JsInstance>(this.GetLength));
    currentDescriptor1.Enumerable = false;
    this.DefineOwnProperty((Descriptor) currentDescriptor1);
  }

  public override bool IsClr => false;

  public override bool ToBoolean() => false;

  public override double ToNumber() => (double) this.Length;

  public override int Length
  {
    get => this.length;
    set => this.length = value;
  }

  public override string Class => "Arguments";

  public JsInstance GetLength(JsArguments target)
  {
    return (JsInstance) this.global.NumberClass.New((double) target.length);
  }
}
