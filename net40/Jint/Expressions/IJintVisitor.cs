// Decompiled with JetBrains decompiler
// Type: Jint.Expressions.IJintVisitor
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using Jint.Native;

#nullable disable
namespace Jint.Expressions;

public interface IJintVisitor
{
  bool DebugMode { get; }

  JsInstance Result { get; set; }

  JsDictionaryObject CallTarget { get; }

  IGlobal Global { get; }

  JsInstance Returned { get; }

  JsInstance Return(JsInstance result);

  void ExecuteFunction(JsFunction function, JsDictionaryObject _this, JsInstance[] _parameters);
}
