// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.js.JintJsObject
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.tool.xml.xtra.xfa.formcalc;
using Jint;
using Jint.Native;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.js;

public class JintJsObject : JsScope, IJsObject<JsScope>
{
  public virtual JintJsXfaGlobal IGlobal => (JintJsXfaGlobal) this.Visitor.Global;

  public ExecutionVisitor Visitor { get; set; }

  internal JintJsObject(ExecutionVisitor visitor)
    : base(visitor.GlobalScope)
  {
    this.Visitor = visitor;
  }

  protected JintJsObject(JintJsObject prototype)
    : base((JsScope) prototype)
  {
    this.Visitor = prototype.Visitor;
  }

  protected JintJsObject(string prototypeName, ExecutionVisitor visitor = null)
    : base((JsScope) ((JintJsXfaGlobal) (visitor = visitor ?? (ExecutionVisitor) new JintJsXfaExecutionVisitor(Options.Strict | Options.Ecmascript5)).Global).JintJsXfaElementConstructor.GetNotNullXfaPrototype(prototypeName))
  {
    this.Visitor = visitor;
  }

  public virtual string ClassName => "object";

  public virtual void DefineProperty(string key, object value)
  {
    this.DefineOwnProperty(key, (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, value));
  }

  public virtual void DefineConstantProperty(string key, object value)
  {
    this.DefineOwnProperty(key, (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, value), PropertyAttributes.DontDelete);
  }

  public override JsInstance SetAt(
    string index,
    JsInstance value,
    bool defineInGlobalScopeIfNotExist)
  {
    if (index == JsScope.THIS)
    {
      if (this.thisDescriptor != null)
        this.thisDescriptor.Set((JsDictionaryObject) this, value);
      else
        this.DefineOwnProperty(this.thisDescriptor = (Descriptor) new ValueDescriptor((JsDictionaryObject) this, index, value));
    }
    else if (index == JsScope.ARGUMENTS)
    {
      if (this.argumentsDescriptor != null)
        this.argumentsDescriptor.Set((JsDictionaryObject) this, value);
      else
        this.DefineOwnProperty(this.argumentsDescriptor = (Descriptor) new ValueDescriptor((JsDictionaryObject) this, index, value));
    }
    else
    {
      Descriptor descriptor = this.GetDescriptor(index);
      if (descriptor != null && descriptor.Owner == this || descriptor is PropertyDescriptor && (descriptor as PropertyDescriptor).SetFunction != null)
        descriptor.Set((JsDictionaryObject) this, value);
      else if (this.globalScope != null && defineInGlobalScopeIfNotExist)
        this.globalScope.DefineOwnProperty(index, value);
      else
        this.DefineOwnProperty(index, value);
    }
    return value;
  }

  public virtual object GetOwnProperty(string key)
  {
    if (!this.HasOwnProperty(key))
      return (object) null;
    JsInstance result;
    this.TryGetProperty(key, out result);
    return JintJsObject.Unwrap((object) result);
  }

  public virtual object GetProperty(string key)
  {
    JsInstance result;
    this.TryGetProperty(key, out result);
    return JintJsObject.Unwrap((object) result);
  }

  public static object Unwrap(object value)
  {
    switch (value)
    {
      case JsScope _:
        return value;
      case JsArray _:
        return value;
      case JsInstance _:
        return ((JsInstance) value)?.Value;
      default:
        return value;
    }
  }

  public virtual string GetStringProperty(string key)
  {
    object ownProperty = this.GetOwnProperty(key);
    return !(ownProperty is string) ? (string) null : (string) ownProperty;
  }

  public static JsDictionaryObject Wrap(Jint.Native.IGlobal global, object objectValue)
  {
    JsDictionaryObject dictionaryObject = (JsDictionaryObject) JsNull.Instance;
    switch (objectValue)
    {
      case null:
        return dictionaryObject;
      case JsDictionaryObject _:
        dictionaryObject = (JsDictionaryObject) objectValue;
        goto case null;
      case string _:
        return (JsDictionaryObject) global.StringClass.New((string) objectValue);
      default:
        dictionaryObject = (JsDictionaryObject) global.WrapClr(objectValue);
        goto case null;
    }
  }

  public virtual object EvaluateScript(ScriptString script)
  {
    if ("application/x-javascript".Equals(script.type))
      return this.EvaluateScript(script.content);
    string script1 = FormCalc2JavaScriptConverter.Convert(script.content);
    return script1 == null ? (object) null : this.EvaluateScript(script1);
  }

  public virtual object EvaluateScript(string script)
  {
    JintEngine jintEngine = new JintEngine(this.Visitor.Global, this.Visitor.GlobalScope);
    jintEngine.Visitor.EnterScope((JsScope) this);
    try
    {
      return jintEngine.Run(script);
    }
    finally
    {
      while (jintEngine.Visitor.CurrentScope != this)
        jintEngine.Visitor.ExitScope();
      jintEngine.Visitor.ExitScope();
    }
  }

  public virtual bool IsUndefined(object obj) => obj is JsUndefined;

  public override double ToNumber()
  {
    JsInstance result;
    this.TryGetProperty("rawValue", out result);
    return result == null ? JsNull.Instance.ToNumber() : result.ToNumber();
  }

  public override object ToObject()
  {
    JsInstance result;
    this.TryGetProperty("rawValue", out result);
    return result == null ? JsNull.Instance.ToObject() : result.ToObject();
  }

  public override string ToString()
  {
    JsInstance result;
    this.TryGetProperty("rawValue", out result);
    return result == null ? JsNull.Instance.ToString() : result.ToString();
  }

  public override JsInstance ToPrimitive(Jint.Native.IGlobal global)
  {
    JsInstance result;
    this.TryGetProperty("rawValue", out result);
    return result ?? (JsInstance) JsUndefined.Instance;
  }
}
