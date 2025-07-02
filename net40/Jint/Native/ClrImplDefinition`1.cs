// Decompiled with JetBrains decompiler
// Type: Jint.Native.ClrImplDefinition`1
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using Jint.Delegates;
using Jint.Expressions;
using System;
using System.Reflection;

#nullable disable
namespace Jint.Native;

[Serializable]
public class ClrImplDefinition<T> : JsFunction where T : JsInstance
{
  private Delegate impl;
  private int length;
  private bool hasParameters;

  private ClrImplDefinition(bool hasParameters, JsObject prototype)
    : base(prototype)
  {
    this.hasParameters = hasParameters;
  }

  public ClrImplDefinition(JintFunc<T, JsInstance[], JsInstance> impl, JsObject prototype)
    : this(impl, -1, prototype)
  {
  }

  public ClrImplDefinition(
    JintFunc<T, JsInstance[], JsInstance> impl,
    int length,
    JsObject prototype)
    : this(true, prototype)
  {
    this.impl = (Delegate) impl;
    this.length = length;
  }

  public ClrImplDefinition(JintFunc<T, JsInstance> impl, JsObject prototype)
    : this(impl, -1, prototype)
  {
  }

  public ClrImplDefinition(JintFunc<T, JsInstance> impl, int length, JsObject prototype)
    : this(false, prototype)
  {
    this.impl = (Delegate) impl;
    this.length = length;
  }

  public override JsInstance Execute(
    IJintVisitor visitor,
    JsDictionaryObject that,
    JsInstance[] parameters)
  {
    try
    {
      JsInstance result;
      if (this.hasParameters)
        result = this.impl.DynamicInvoke((object) that, (object) parameters) as JsInstance;
      else
        result = this.impl.DynamicInvoke((object) that) as JsInstance;
      visitor.Return(result);
      return result;
    }
    catch (TargetInvocationException ex)
    {
      throw ex.InnerException;
    }
    catch (ArgumentException ex)
    {
      JsFunction jsFunction = that["constructor"] as JsFunction;
      throw new JsException((JsInstance) visitor.Global.TypeErrorClass.New("incompatible type: " + (jsFunction == null ? "<unknown>" : jsFunction.Name)));
    }
    catch (Exception ex)
    {
      if (ex.InnerException is JsException)
        throw ex.InnerException;
      throw;
    }
  }

  public override int Length => this.length == -1 ? base.Length : this.length;

  public override string ToString()
  {
    return string.Format("function {0}() { [native code] }", (object) this.impl.Method.Name);
  }
}
