// Decompiled with JetBrains decompiler
// Type: Jint.Native.NativeTypeConstructor
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using System;

#nullable disable
namespace Jint.Native;

internal class NativeTypeConstructor : NativeConstructor
{
  protected NativeTypeConstructor(IGlobal global, JsObject typePrototype)
    : base(typeof (System.Type), global, typePrototype, typePrototype)
  {
    this.DefineOwnProperty(JsFunction.PROTOTYPE, (JsInstance) typePrototype);
  }

  public static NativeTypeConstructor CreateNativeTypeConstructor(IGlobal global)
  {
    JsObject typePrototype = global != null ? (JsObject) global.FunctionClass.New() : throw new ArgumentNullException(nameof (global));
    NativeTypeConstructor target = new NativeTypeConstructor(global, typePrototype);
    target.InitPrototype(global);
    target.SetupNativeProperties((JsDictionaryObject) target);
    return target;
  }

  public override JsInstance Wrap<T>(T value)
  {
    if ((object) value == null)
      throw new ArgumentNullException(nameof (value));
    if ((object) ((object) value as System.Type) != null)
    {
      NativeConstructor target = new NativeConstructor((object) value as System.Type, this.Global, (JsObject) null, this.PrototypeProperty);
      target.InitPrototype(this.Global);
      this.SetupNativeProperties((JsDictionaryObject) target);
      return (JsInstance) target;
    }
    throw new JintException($"Attempt to wrap '{value.GetType().FullName}' with '{typeof (System.Type).FullName}'");
  }

  public JsInstance WrapSpecialType(System.Type value, JsObject prototypePropertyPrototype)
  {
    if (value == (System.Type) null)
      throw new ArgumentNullException(nameof (value));
    NativeConstructor target = new NativeConstructor(value, this.Global, prototypePropertyPrototype, this.PrototypeProperty);
    target.InitPrototype(this.Global);
    this.SetupNativeProperties((JsDictionaryObject) target);
    return (JsInstance) target;
  }
}
