// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsInstance
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using Jint.Expressions;
using System;

#nullable disable
namespace Jint.Native;

[Serializable]
public abstract class JsInstance
{
  public const string TYPE_OBJECT = "object";
  public const string TYPE_BOOLEAN = "boolean";
  public const string TYPE_STRING = "string";
  public const string TYPE_NUMBER = "number";
  public const string TYPE_UNDEFINED = "undefined";
  public const string TYPE_NULL = "null";
  public const string TYPE_DESCRIPTOR = "descriptor";
  public const string TYPEOF_FUNCTION = "function";
  public const string CLASS_NUMBER = "Number";
  public const string CLASS_STRING = "String";
  public const string CLASS_BOOLEAN = "Boolean";
  public const string CLASS_OBJECT = "Object";
  public const string CLASS_FUNCTION = "Function";
  public const string CLASS_ARRAY = "Array";
  public const string CLASS_REGEXP = "RegExp";
  public const string CLASS_DATE = "Date";
  public const string CLASS_ERROR = "Error";
  public const string CLASS_ARGUMENTS = "Arguments";
  public const string CLASS_GLOBAL = "Global";
  public const string CLASS_DESCRIPTOR = "Descriptor";
  public const string CLASS_SCOPE = "Scope";
  public static JsInstance[] EMPTY = new JsInstance[0];

  public abstract bool IsClr { get; }

  public abstract object Value { get; set; }

  public PropertyAttributes Attributes { get; set; }

  public virtual JsInstance ToPrimitive(IGlobal global) => (JsInstance) JsUndefined.Instance;

  public virtual bool ToBoolean() => true;

  public virtual double ToNumber() => 0.0;

  public virtual int ToInteger() => (int) this.ToNumber();

  public virtual object ToObject() => this.Value;

  public virtual string ToSource() => this.ToString();

  public override string ToString() => (this.Value ?? (object) this.Class).ToString();

  public override int GetHashCode()
  {
    return this.Value == null ? base.GetHashCode() : this.Value.GetHashCode();
  }

  public abstract string Class { get; }

  public abstract string Type { get; }

  [Obsolete("will be removed in the 1.0 version", true)]
  public virtual object Call(IJintVisitor visitor, string function, params JsInstance[] parameters)
  {
    return function == "toString" ? (object) visitor.Global.StringClass.New(this.ToString()) : (object) JsUndefined.Instance;
  }
}
