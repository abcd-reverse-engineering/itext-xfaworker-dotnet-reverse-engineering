// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsNull
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace Jint.Native;

[Serializable]
public class JsNull : JsObject
{
  public static JsNull Instance = new JsNull();

  public override bool IsClr => false;

  public override string Type => "null";

  public override string Class => "Object";

  public override int Length
  {
    get => 0;
    set
    {
    }
  }

  public override bool ToBoolean() => false;

  public override double ToNumber() => 0.0;

  public override string ToString() => "null";

  public override Descriptor GetDescriptor(string index) => (Descriptor) null;

  public override IEnumerable<string> GetKeys() => (IEnumerable<string>) new string[0];

  public override object Value
  {
    get => (object) null;
    set
    {
    }
  }

  public override void DefineOwnProperty(Descriptor value)
  {
  }

  public override bool HasProperty(string key) => false;

  public override bool HasOwnProperty(string key) => false;

  public override JsInstance this[string index]
  {
    get => (JsInstance) JsUndefined.Instance;
    set
    {
    }
  }
}
