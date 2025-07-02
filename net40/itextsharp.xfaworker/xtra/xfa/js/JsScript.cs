// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.js.JsScript
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using Common.Logging;
using iTextSharp.tool.xml.xtra.xfa.tags;
using System;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.js;

public class JsScript : JsContent
{
  public static readonly ILog logger = LogManager.GetLogger(typeof (JsScript));

  public JsScript(Tag tag, JsNode parent, JsNode prototypeNode)
    : base(tag, parent, prototypeNode)
  {
    if (this.flattenerContext != null)
      this.flattenerContext.AddScriptVariableToBeEvaluated(this);
    else
      this.Evaluate();
  }

  public virtual void Evaluate()
  {
    ScriptString scriptString = ScriptString.CreateScriptString((IFormNode) this);
    if (scriptString == null)
      return;
    try
    {
      this.EvaluateScript(scriptString);
    }
    catch (Exception ex)
    {
      string str = "Java Script variable evaluation";
      string stringProperty = this.GetStringProperty("name");
      if (this.GetParentNode() != null)
        str = $"{str}\nXFA form element: {this.GetParentNode().SomExpression}";
      if (stringProperty != null && stringProperty.Length > 0)
        str = $"{str}\nVariable name: {stringProperty}";
      JsScript.logger.Error((object) str, ex);
    }
  }
}
