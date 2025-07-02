// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.js.JsDataValue
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.tool.xml.xtra.xfa.tags;
using System.Collections.Generic;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.js;

public class JsDataValue : JsNode
{
  protected string name;

  internal JsDataValue(JsTree prototype, string className = "dataValue")
    : base(prototype, className)
  {
  }

  public JsDataValue(string name, string value, JsNode parent)
    : base("dataValue", parent)
  {
    this.name = name;
    this.DefineProperty(nameof (name), (object) name);
    this.DefineProperty(nameof (value), (object) value);
  }

  public JsDataValue(DataTag tag, JsNode parent)
    : base("dataValue", parent)
  {
    this.name = tag.Name;
    this.DefineProperty(nameof (name), (object) tag.Name);
    this.DefineProperty("value", tag.Value.Length == 0 ? (object) (string) null : (object) tag.Value);
    foreach (KeyValuePair<string, string> attribute in (IEnumerable<KeyValuePair<string, string>>) tag.Attributes)
      this.AddChild((JsTree) new JsDataValue(attribute.Key, attribute.Value, (JsNode) this));
  }

  public override string RetrieveName() => this.name;
}
