// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsUndefined
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using System;

#nullable disable
namespace Jint.Native;

[Serializable]
public class JsUndefined : JsObject
{
  public static JsUndefined Instance;

  public override int Length
  {
    get => 0;
    set
    {
    }
  }

  public override bool IsClr => false;

  public override Descriptor GetDescriptor(string index) => (Descriptor) null;

  public override string Class => "Object";

  public override string Type => "undefined";

  public override string ToString() => "undefined";

  public override object ToObject() => (object) null;

  public override bool ToBoolean() => false;

  public override double ToNumber() => double.NaN;

  static JsUndefined()
  {
    JsUndefined jsUndefined = new JsUndefined();
    jsUndefined.Attributes = PropertyAttributes.DontEnum | PropertyAttributes.DontDelete;
    JsUndefined.Instance = jsUndefined;
  }
}
