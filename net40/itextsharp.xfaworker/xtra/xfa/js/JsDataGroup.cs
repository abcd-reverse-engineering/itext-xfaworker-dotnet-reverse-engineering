// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.js.JsDataGroup
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.tool.xml.xtra.xfa.tags;
using Jint.Native;
using System.Collections.Generic;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.js;

public class JsDataGroup : JsNode
{
  protected string name;

  internal JsDataGroup(JsTree prototype, string className = "dataGroup")
    : base(prototype, className)
  {
  }

  public JsDataGroup(DataTag tag, JsNode parent)
    : base(tag.Name, parent)
  {
    this.name = tag.Name;
    this.tag = (Tag) tag;
    this.DefineProperty(nameof (name), (object) tag.Name);
    foreach (KeyValuePair<string, string> attribute in (IEnumerable<KeyValuePair<string, string>>) tag.Attributes)
    {
      if (!"xfa:dataNode".Equals(attribute.Key))
        this.AddChild((JsTree) new JsDataValue(attribute.Key, attribute.Value, (JsNode) this));
    }
  }

  private JsDataGroup(string name, JsNode parent)
    : this(new DataTag(name), parent)
  {
  }

  public override string RetrieveName() => this.name;

  protected override JsInstance GetPrototypeObject(string name) => (JsInstance) null;
}
