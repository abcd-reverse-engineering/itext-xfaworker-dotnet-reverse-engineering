// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.js.JsContainer
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using Common.Logging;
using iTextSharp.tool.xml.xtra.xfa.positioner;
using iTextSharp.tool.xml.xtra.xfa.tags;
using Jint.Delegates;
using Jint.Native;
using System;
using System.Collections.Generic;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.js;

public class JsContainer : JsNode
{
  public static readonly ILog logger = LogManager.GetLogger(typeof (JsContainer));

  internal JsContainer(JsNode prototype)
    : base((JsTree) prototype, "container")
  {
    this.DefineOwnProperty("execEvent", (JsInstance) this.IGlobal.FunctionClass.New<JsContainer>(new JintFunc<JsContainer, JsInstance[], JsInstance>(this.ExecEventJsFunc)), PropertyAttributes.DontDelete);
    this.DefineOwnProperty("execInitialize", (JsInstance) this.IGlobal.FunctionClass.New<JsContainer>(new JintFunc<JsContainer, JsInstance[], JsInstance>(this.ExecInitializeJsFunc)), PropertyAttributes.DontDelete);
    this.DefineOwnProperty("execCalculate", (JsInstance) this.IGlobal.FunctionClass.New<JsContainer>(new JintFunc<JsContainer, JsInstance[], JsInstance>(this.ExecCalculateJsFunc)), PropertyAttributes.DontDelete);
    this.DefineConstantProperty("presence", (object) "visible");
    this.DefineConstantProperty("layout", (object) LayoutManager.positionLayout);
    this.DefineConstantProperty("rawValue", (object) null);
    this.DefineOwnProperty((Descriptor) new PropertyDescriptor<JsContainer>((Jint.Native.IGlobal) this.IGlobal, (JsDictionaryObject) this, "formattedValue", new JintFunc<JsContainer, JsInstance>(this.FormattedValueJsProp)));
    this.DefineOwnProperty((Descriptor) new PropertyDescriptor<JsContainer>((Jint.Native.IGlobal) this.IGlobal, (JsDictionaryObject) this, "dataNode", new JintFunc<JsContainer, JsInstance>(this.DataNodeJsProp)));
    this.DefineOwnProperty((Descriptor) new PropertyDescriptor<JsContainer>((Jint.Native.IGlobal) this.IGlobal, (JsDictionaryObject) this, "fillColor", new JintFunc<JsContainer, JsInstance>(this.FillColorGetJsProp), new JintFunc<JsContainer, JsInstance[], JsInstance>(this.FillColorSetJsProp)));
    this.DefineOwnProperty((Descriptor) new PropertyDescriptor<JsNode>((Jint.Native.IGlobal) this.IGlobal, (JsDictionaryObject) this, "$", new JintFunc<JsNode, JsInstance>(this.ThisJsProp)));
  }

  internal JsContainer(string className, JsNode prototype)
    : base((JsTree) prototype, className)
  {
  }

  public JsContainer(XFATemplateTag tag, JsNode parent, string prototypeName)
    : base((Tag) tag, parent, prototypeName ?? "container")
  {
  }

  public virtual void ExecEvent(string activity, string @ref) => this.ExecOwnEvent(activity, @ref);

  public virtual void ExecOwnEvent(string activity, string @ref)
  {
    IList<ScriptString> scriptsByActivity = this.GetScriptsByActivity(activity, @ref);
    if (scriptsByActivity == null)
      return;
    foreach (ScriptString script in (IEnumerable<ScriptString>) scriptsByActivity)
    {
      try
      {
        this.flattenerContext.PushJsEventCallStack(this, activity, script.content);
        this.EvaluateScript(script);
      }
      catch (Exception ex)
      {
        string str1 = $"Java Script event evaluation failed\nXFA form element: {this.SomExpression}\n" + "Event '";
        if (@ref != null && @ref.Length > 0 && !@ref.Equals("undefined"))
          str1 = $"{str1}{@ref}: ";
        string str2 = $"{str1}{activity}'";
        JsContainer.logger.Error((object) str2, ex);
      }
      finally
      {
        this.flattenerContext.PopJsEventCallStack();
      }
    }
  }

  public virtual JsInstance ExecEventJsFunc(JsContainer target, JsInstance[] parameters)
  {
    string activity = parameters[0].ToString();
    string @ref = parameters.Length > 1 ? parameters[1].ToString() : (string) null;
    target.ExecEvent(activity, @ref);
    return (JsInstance) JsNull.Instance;
  }

  public virtual void ExecInitialize() => this.ExecEvent("initialize", (string) null);

  public virtual JsInstance ExecInitializeJsFunc(JsContainer target, JsInstance[] parameters)
  {
    target.ExecInitialize();
    return (JsInstance) JsNull.Instance;
  }

  public virtual JsInstance ThisJsProp(JsNode target) => (JsInstance) target;

  public virtual IList<ScriptString> GetScriptsByActivity(string activity, string @ref)
  {
    List<ScriptString> scriptsByActivity = (List<ScriptString>) null;
    JintJsNodeList nodes = this.GetNodes();
    if (nodes != null)
    {
      for (int i = 0; i < nodes.Length; ++i)
      {
        JsNode jsNode = (JsNode) nodes.GetItem(i);
        if ("event".Equals(jsNode.GetProperty("className")))
        {
          string str1 = jsNode.RetrieveAttribute(nameof (activity));
          string str2 = jsNode.RetrieveAttribute(nameof (@ref));
          if ((str1 == null || activity.Equals(str1)) && (@ref == null || "undefined".Equals(@ref) || @ref.Equals(str2)))
          {
            ScriptString scriptString = ScriptString.CreateScriptString((IFormNode) jsNode.GetChild("script"));
            if (scriptString != null)
            {
              if (scriptsByActivity == null)
                scriptsByActivity = new List<ScriptString>();
              scriptsByActivity.Add(scriptString);
            }
          }
        }
      }
    }
    return (IList<ScriptString>) scriptsByActivity;
  }

  public virtual object GetFormattedValue() => (object) "";

  private JsInstance FormattedValueJsProp(JsContainer target)
  {
    return (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, target.GetFormattedValue());
  }

  public virtual object GetDataNode() => this.FetchDataNode(true);

  public virtual object FetchDataNode(bool createNewIfNotExists) => (object) null;

  private JsInstance DataNodeJsProp(JsContainer target)
  {
    return (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, target.GetDataNode());
  }

  public virtual string FillColor
  {
    get
    {
      IFormNode formNode1 = this.RetrieveChild("border");
      if (formNode1 != null)
      {
        IFormNode formNode2 = formNode1.RetrieveChild("fill");
        if (formNode2 != null)
        {
          IFormNode formNode3 = formNode2.RetrieveChild("color");
          if (formNode3 != null)
            return formNode3.RetrieveAttribute("value");
        }
      }
      return (string) null;
    }
    set
    {
      JsInstance result1;
      this.TryGetProperty("border", out result1);
      JsInstance result2;
      ((JsDictionaryObject) result1).TryGetProperty("fill", out result2);
      JsInstance result3;
      ((JsDictionaryObject) result2).TryGetProperty("color", out result3);
      ((JintJsObject) result3).DefineProperty(nameof (value), (object) value);
    }
  }

  private JsInstance FillColorGetJsProp(JsContainer target)
  {
    return (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, (object) target.FillColor);
  }

  private JsInstance FillColorSetJsProp(JsContainer target, JsInstance[] parameters)
  {
    if (parameters.Length > 0)
      target.FillColor = parameters[0].ToString();
    return (JsInstance) JsNull.Instance;
  }

  public virtual object ExecCalculate()
  {
    IList<ScriptString> calculationScripts = this.GetCalculationScripts();
    object obj = (object) null;
    if (calculationScripts != null)
    {
      foreach (ScriptString script in (IEnumerable<ScriptString>) calculationScripts)
      {
        try
        {
          obj = this.EvaluateScript(script);
        }
        catch (Exception ex)
        {
          string str = $"Java Script calculation evaluation failed\nXFA form element: {this.SomExpression}";
          JsContainer.logger.Error((object) str, ex);
        }
        if (obj != null && !(this is SubFormPositioner) && !this.IsUndefined(obj))
        {
          if (obj is JsNode)
            obj = ((JintJsObject) obj).GetProperty("rawValue");
        }
        else
          obj = (object) null;
      }
    }
    return obj;
  }

  public virtual JsInstance ExecCalculateJsFunc(JsContainer target, JsInstance[] parameters)
  {
    target.ExecCalculate();
    return (JsInstance) JsNull.Instance;
  }

  public virtual void ExecValidate()
  {
    IList<ScriptString> validateScripts = this.GetValidateScripts();
    if (validateScripts == null)
      return;
    foreach (ScriptString script in (IEnumerable<ScriptString>) validateScripts)
    {
      try
      {
        this.EvaluateScript(script);
      }
      catch (Exception ex)
      {
        string str = $"Java Script validation evaluation failed\nXFA form element: {this.SomExpression}";
        JsContainer.logger.Error((object) str, ex);
      }
    }
  }

  protected virtual IList<ScriptString> GetCalculationScripts()
  {
    List<ScriptString> calculationScripts = (List<ScriptString>) null;
    JintJsNodeList nodes = this.GetNodes();
    if (nodes != null)
    {
      for (int i = 0; i < nodes.Length; ++i)
      {
        JsNode jsNode = (JsNode) nodes.GetItem(i);
        if ("calculate".Equals(jsNode.GetProperty("className")))
        {
          ScriptString scriptString = ScriptString.CreateScriptString((IFormNode) jsNode.GetChild("script"));
          if (scriptString != null)
          {
            if (calculationScripts == null)
              calculationScripts = new List<ScriptString>();
            calculationScripts.Add(scriptString);
          }
        }
      }
    }
    return (IList<ScriptString>) calculationScripts;
  }

  protected virtual IList<ScriptString> GetValidateScripts()
  {
    List<ScriptString> validateScripts = (List<ScriptString>) null;
    JintJsNodeList nodes = this.GetNodes();
    if (nodes != null)
    {
      for (int i = 0; i < nodes.Length; ++i)
      {
        JsNode jsNode = (JsNode) nodes.GetItem(i);
        if ("validate".Equals(jsNode.GetProperty("className")))
        {
          ScriptString scriptString = ScriptString.CreateScriptString((IFormNode) jsNode.GetChild("script"));
          if (scriptString != null)
          {
            if (validateScripts == null)
              validateScripts = new List<ScriptString>();
            validateScripts.Add(scriptString);
          }
        }
      }
    }
    return (IList<ScriptString>) validateScripts;
  }
}
