// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.js.IJsObject`1
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.js;

public interface IJsObject<JsEngineNativeType>
{
  void DefineProperty(string key, object value);

  void DefineConstantProperty(string key, object value);

  object GetOwnProperty(string key);

  object GetProperty(string key);

  object EvaluateScript(string script);

  bool IsUndefined(object obj);
}
