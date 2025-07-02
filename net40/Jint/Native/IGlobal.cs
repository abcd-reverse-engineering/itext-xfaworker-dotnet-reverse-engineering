// Decompiled with JetBrains decompiler
// Type: Jint.Native.IGlobal
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using Jint.Expressions;

#nullable disable
namespace Jint.Native;

public interface IGlobal
{
  bool HasOption(Options options);

  JsArrayConstructor ArrayClass { get; }

  JsBooleanConstructor BooleanClass { get; }

  JsDateConstructor DateClass { get; }

  JsErrorConstructor ErrorClass { get; }

  JsErrorConstructor EvalErrorClass { get; }

  JsFunctionConstructor FunctionClass { get; }

  JsInstance IsNaN(JsInstance[] arguments);

  JsMathConstructor MathClass { get; }

  JsNumberConstructor NumberClass { get; }

  JsObjectConstructor ObjectClass { get; }

  JsInstance ParseFloat(JsInstance[] arguments);

  JsInstance ParseInt(JsInstance[] arguments);

  JsErrorConstructor RangeErrorClass { get; }

  JsErrorConstructor ReferenceErrorClass { get; }

  JsRegExpConstructor RegExpClass { get; }

  JsStringConstructor StringClass { get; }

  JsErrorConstructor SyntaxErrorClass { get; }

  JsErrorConstructor TypeErrorClass { get; }

  JsErrorConstructor URIErrorClass { get; }

  JsObject Wrap(object value);

  JsObject WrapClr(object value);

  JsInstance NaN { get; }

  IJintVisitor Visitor { get; }

  Marshaller Marshaller { get; }
}
