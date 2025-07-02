// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.js.JsXfa
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.tool.xml.xtra.xfa.resolver;
using iTextSharp.tool.xml.xtra.xfa.tags;
using Jint;
using Jint.Delegates;
using Jint.Native;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.js;

public class JsXfa : JsNode
{
  private const string FORM_CALC_FUNCTION_PREFIX = "formCalcFunction_";
  public static readonly Dictionary<string, string> formCalcFunc = new Dictionary<string, string>()
  {
    {
      "abs",
      "formCalcFunction_abs"
    },
    {
      "concat",
      "formCalcFunction_concat"
    },
    {
      "date",
      "formCalcFunction_date"
    },
    {
      "datefmt",
      "formCalcFunction_datefmt"
    },
    {
      "exists",
      "formCalcFunction_exists"
    },
    {
      "hasvalue",
      "formCalcFunction_hasvalue"
    },
    {
      "left",
      "formCalcFunction_left"
    },
    {
      "len",
      "formCalcFunction_len"
    },
    {
      "num2date",
      "formCalcFunction_num2date"
    },
    {
      "num2time",
      "formCalcFunction_num2time"
    },
    {
      "num2gmtime",
      "formCalcFunction_num2gmtime"
    },
    {
      "date2num",
      "formCalcFunction_date2num"
    },
    {
      "time",
      "formCalcFunction_time"
    },
    {
      "time2num",
      "formCalcFunction_time2num"
    },
    {
      "timefmt",
      "formCalcFunction_timefmt"
    },
    {
      "replace",
      "formCalcFunction_replace"
    },
    {
      "right",
      "formCalcFunction_right"
    },
    {
      "round",
      "formCalcFunction_round"
    },
    {
      "space",
      "formCalcFunction_space"
    },
    {
      "sum",
      "formCalcFunction_sum"
    },
    {
      "upper",
      "formCalcFunction_upper"
    }
  };

  public JsXfa(FlattenerContext flattenerContext)
    : base("xfa")
  {
    Jint.Native.IGlobal iglobal = (Jint.Native.IGlobal) this.IGlobal;
    this.flattenerContext = flattenerContext;
    this.DefineOwnProperty("xfa", (JsInstance) this);
    this.DefineOwnProperty("layout", (JsInstance) new JsLayout(iglobal, flattenerContext));
    this.DefineOwnProperty("host", (JsInstance) new JsHost(iglobal, flattenerContext.HostConfig, this));
    this.DefineOwnProperty("event", (JsInstance) new JsEvent(iglobal, flattenerContext));
    this.DefineOwnProperty("util", (JsInstance) new JsAcrobatUtil(iglobal, flattenerContext));
    this.DefineProperty("console", (object) new JsConsole(iglobal));
    this.DefineOwnProperty((Descriptor) new PropertyDescriptor<JsNode>((Jint.Native.IGlobal) this.IGlobal, (JsDictionaryObject) this, "record", new JintFunc<JsNode, JsInstance>(this.RecordJsProp)));
    this.DefineOwnProperty((Descriptor) new PropertyDescriptor<JsNode>((Jint.Native.IGlobal) this.IGlobal, (JsDictionaryObject) this, "$record", new JintFunc<JsNode, JsInstance>(this.RecordJsProp)));
    this.DefineProperty("Null", (object) JsNull.Instance);
    this.DefineProperty("app", (object) new JsApp(iglobal, flattenerContext.AppConfig));
    this.DefineOwnProperty((Descriptor) new PropertyDescriptor<JsXfa>((Jint.Native.IGlobal) this.IGlobal, (JsDictionaryObject) this, "$host", new JintFunc<JsXfa, JsInstance>(this.ThisHostJsProp)));
    JsFunction jsFunction1 = this.IGlobal.FunctionClass.New<JsScope>(new JintFunc<JsScope, JsInstance[], JsInstance>(this.AbsJsFunc));
    this.DefineOwnProperty(JsXfa.formCalcFunc["abs"], (JsInstance) jsFunction1, PropertyAttributes.DontDelete);
    JsFunction jsFunction2 = this.IGlobal.FunctionClass.New<JsScope>(new JintFunc<JsScope, JsInstance[], JsInstance>(this.Num2dateJsFunc), 3);
    this.DefineOwnProperty(JsXfa.formCalcFunc["num2date"], (JsInstance) jsFunction2, PropertyAttributes.DontDelete);
    JsFunction jsFunction3 = this.IGlobal.FunctionClass.New<JsScope>(new JintFunc<JsScope, JsInstance[], JsInstance>(this.Date2numJsFunc), 3);
    this.DefineOwnProperty(JsXfa.formCalcFunc["date2num"], (JsInstance) jsFunction3, PropertyAttributes.DontDelete);
    JsFunction jsFunction4 = this.IGlobal.FunctionClass.New<JsScope>(new JintFunc<JsScope, JsInstance[], JsInstance>(this.DateJsFunc), 0);
    this.DefineOwnProperty(JsXfa.formCalcFunc["date"], (JsInstance) jsFunction4, PropertyAttributes.DontDelete);
    JsFunction jsFunction5 = this.IGlobal.FunctionClass.New<JsScope>(new JintFunc<JsScope, JsInstance[], JsInstance>(this.Num2timeJsFunc));
    this.DefineOwnProperty(JsXfa.formCalcFunc["num2time"], (JsInstance) jsFunction5, PropertyAttributes.DontDelete);
    JsFunction jsFunction6 = this.IGlobal.FunctionClass.New<JsScope>(new JintFunc<JsScope, JsInstance[], JsInstance>(this.Num2gmtimeJsFunc));
    this.DefineOwnProperty(JsXfa.formCalcFunc["num2gmtime"], (JsInstance) jsFunction6, PropertyAttributes.DontDelete);
    JsFunction jsFunction7 = this.IGlobal.FunctionClass.New<JsScope>(new JintFunc<JsScope, JsInstance[], JsInstance>(this.Time2numJsFunc));
    this.DefineOwnProperty(JsXfa.formCalcFunc["time2num"], (JsInstance) jsFunction7, PropertyAttributes.DontDelete);
    JsFunction jsFunction8 = this.IGlobal.FunctionClass.New<JsScope>(new JintFunc<JsScope, JsInstance[], JsInstance>(this.TimeJsFunc));
    this.DefineOwnProperty(JsXfa.formCalcFunc["time"], (JsInstance) jsFunction8, PropertyAttributes.DontDelete);
    JsFunction jsFunction9 = this.IGlobal.FunctionClass.New<JsScope>(new JintFunc<JsScope, JsInstance[], JsInstance>(this.TimefmtJsFunc));
    this.DefineOwnProperty(JsXfa.formCalcFunc["timefmt"], (JsInstance) jsFunction9, PropertyAttributes.DontDelete);
    JsFunction jsFunction10 = this.IGlobal.FunctionClass.New<JsScope>(new JintFunc<JsScope, JsInstance[], JsInstance>(this.DateFmtJsFunc), 2);
    this.DefineOwnProperty(JsXfa.formCalcFunc["datefmt"], (JsInstance) jsFunction10, PropertyAttributes.DontDelete);
    JsFunction jsFunction11 = this.IGlobal.FunctionClass.New<JsScope>(new JintFunc<JsScope, JsInstance[], JsInstance>(this.RoundJsFunc));
    this.DefineOwnProperty(JsXfa.formCalcFunc["round"], (JsInstance) jsFunction11, PropertyAttributes.DontDelete);
    JsFunction jsFunction12 = this.IGlobal.FunctionClass.New<JsScope>(new JintFunc<JsScope, JsInstance[], JsInstance>(this.ExistsJsFunc));
    this.DefineOwnProperty(JsXfa.formCalcFunc["exists"], (JsInstance) jsFunction12, PropertyAttributes.DontDelete);
    JsFunction jsFunction13 = this.IGlobal.FunctionClass.New<JsScope>(new JintFunc<JsScope, JsInstance[], JsInstance>(this.HasvalueJsFunc));
    this.DefineOwnProperty(JsXfa.formCalcFunc["hasvalue"], (JsInstance) jsFunction13, PropertyAttributes.DontDelete);
    JsFunction jsFunction14 = this.IGlobal.FunctionClass.New<JsScope>(new JintFunc<JsScope, JsInstance[], JsInstance>(this.UpperJsFunc));
    this.DefineOwnProperty(JsXfa.formCalcFunc["upper"], (JsInstance) jsFunction14, PropertyAttributes.DontDelete);
    JsFunction jsFunction15 = this.IGlobal.FunctionClass.New<JsScope>(new JintFunc<JsScope, JsInstance[], JsInstance>(this.LeftJsFunc), 2);
    this.DefineOwnProperty(JsXfa.formCalcFunc["left"], (JsInstance) jsFunction15, PropertyAttributes.DontDelete);
    JsFunction jsFunction16 = this.IGlobal.FunctionClass.New<JsScope>(new JintFunc<JsScope, JsInstance[], JsInstance>(this.RightJsFunc), 2);
    this.DefineOwnProperty(JsXfa.formCalcFunc["right"], (JsInstance) jsFunction16, PropertyAttributes.DontDelete);
    JsFunction jsFunction17 = this.IGlobal.FunctionClass.New<JsScope>(new JintFunc<JsScope, JsInstance[], JsInstance>(this.ReplaceJsFunc), 3);
    this.DefineOwnProperty(JsXfa.formCalcFunc["replace"], (JsInstance) jsFunction17, PropertyAttributes.DontDelete);
    JsFunction jsFunction18 = this.IGlobal.FunctionClass.New<JsScope>(new JintFunc<JsScope, JsInstance[], JsInstance>(this.SpaceJsFunc));
    this.DefineOwnProperty(JsXfa.formCalcFunc["space"], (JsInstance) jsFunction18, PropertyAttributes.DontDelete);
    JsFunction jsFunction19 = this.IGlobal.FunctionClass.New<JsScope>(new JintFunc<JsScope, JsInstance[], JsInstance>(this.FcImplLenJsFunc));
    this.DefineOwnProperty(JsXfa.formCalcFunc["len"], (JsInstance) jsFunction19, PropertyAttributes.DontDelete);
    this.DefineOwnProperty("fc2jsHelperFuncIsRef", (JsInstance) this.IGlobal.FunctionClass.New<JsScope>(new JintFunc<JsScope, JsInstance[], JsInstance>(this.IsRefJsFunc)), PropertyAttributes.DontDelete);
    this.DefineOwnProperty("fc2jsHelperFuncValueOf", (JsInstance) this.IGlobal.FunctionClass.New<JsScope>(new JintFunc<JsScope, JsInstance[], JsInstance>(this.Fc2jsHelperFuncValueOfJsFunc)), PropertyAttributes.DontDelete);
    this.DefineOwnProperty("fc2jsHelperFuncNumericValueOf", (JsInstance) this.IGlobal.FunctionClass.New<JsScope>(new JintFunc<JsScope, JsInstance[], JsInstance>(this.Fc2jsHelperFuncNumericValueOfJsFunc)), PropertyAttributes.DontDelete);
    this.DefineOwnProperty("fc2jsHelperConcat", (JsInstance) this.IGlobal.FunctionClass.New<JsScope>(new JintFunc<JsScope, JsInstance[], JsInstance>(this.Fc2jsHelperConcatJsFunc)), PropertyAttributes.DontDelete);
    this.DefineOwnProperty("fc2jsHelperNumericSum", (JsInstance) this.IGlobal.FunctionClass.New<JsScope>(new JintFunc<JsScope, JsInstance[], JsInstance>(this.Fc2jsHelperNumericSumJsFunc)), PropertyAttributes.DontDelete);
    this.EvaluateScript("function formCalcFunction_sum() {\n            var sumValue = 0;\n            for (var i = 0; i < arguments.length; i++) {\n               sumValue += fc2jsHelperNumericSum(arguments[i]);\n            }\n            return sumValue;\n        }");
    this.EvaluateScript("function formCalcFunction_concat() {\n            var sumValue = \"\";\n            for (var i = 0; i < arguments.length; i++) {\n               sumValue += fc2jsHelperConcat(arguments[i]);\n            }\n            return sumValue;\n        }");
  }

  public override JsTree ResolveNodeInt(string somExpressions)
  {
    JsTree jsTree = (JsTree) null;
    if (this.flattenerContext.CurrentNode != null)
      jsTree = this.flattenerContext.CurrentNode.SearchNode(somExpressions, true);
    if (jsTree == null)
      jsTree = this.SearchNode(somExpressions, false);
    return jsTree;
  }

  public override JintJsNodeList ResolveNodesInt(string somExpressions)
  {
    return this.SearchNodes(somExpressions, false);
  }

  public virtual string FormCalcFunction_num2date(int? numDays, object picture, object localeName)
  {
    XFATemplateTag template = this.flattenerContext.CurrentNode.Template;
    if (numDays.HasValue)
    {
      int? nullable = numDays;
      if ((nullable.GetValueOrDefault() <= 0 ? 0 : (nullable.HasValue ? 1 : 0)) != 0)
      {
        if (!(localeName is string) || ((string) localeName).Length == 0)
          localeName = template.Attributes.ContainsKey("locale") ? (object) template.Attributes["locale"] : (object) (string) null;
        XFALocale locale = this.flattenerContext.LocaleResolver.GetLocale((string) localeName);
        DateTime date = new DateTime(1900, 1, 1);
        date = date.AddDays((double) (numDays.Value - 1));
        try
        {
          return this.flattenerContext.FormatResolver.FormatDate(date, picture is string ? (string) picture : "D MMM YYYY", locale);
        }
        catch (Exception ex)
        {
        }
        return date.ToString();
      }
    }
    return "";
  }

  public virtual JsInstance Num2dateJsFunc(JsScope target, JsInstance[] parameters)
  {
    return (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, (object) this.FormCalcFunction_num2date(new int?(parameters[0].ToInteger()), parameters[1].ToObject(), parameters.Length > 2 ? parameters[2].ToObject() : (object) null));
  }

  public virtual long? FormCalcFunction_date2num(object date, object format, object localeName)
  {
    if (date is JsNode)
      date = ((JintJsObject) date).GetProperty("rawValue");
    date = JintJsObject.Unwrap(date);
    if (date is string && ((string) date).Length != 0)
    {
      if (!(localeName is string) || ((string) localeName).Length == 0)
      {
        string str;
        this.flattenerContext.CurrentNode.Template.Attributes.TryGetValue("locale", out str);
        localeName = (object) str;
      }
      XFALocale locale = this.flattenerContext.LocaleResolver.GetLocale((string) localeName);
      try
      {
        DateTime? date1 = this.flattenerContext.FormatResolver.ParseDate((string) date, format is string ? (string) format : "MMM D, YYYY", locale);
        DateTime dateTime1 = new DateTime(1900, 1, 1, 0, 0, 0, 0);
        DateTime? nullable1 = date1;
        DateTime dateTime2 = dateTime1;
        long? nullable2 = new long?((long) (nullable1.HasValue ? new TimeSpan?(nullable1.GetValueOrDefault() - dateTime2) : new TimeSpan?()).Value.TotalMilliseconds);
        long? nullable3 = nullable2.HasValue ? new long?(nullable2.GetValueOrDefault() / 1000L) : new long?();
        long? nullable4 = nullable3.HasValue ? new long?(nullable3.GetValueOrDefault() / 60L) : new long?();
        long? nullable5 = nullable4.HasValue ? new long?(nullable4.GetValueOrDefault() / 60L) : new long?();
        long? nullable6 = nullable5.HasValue ? new long?(nullable5.GetValueOrDefault() / 24L) : new long?();
        return nullable6.HasValue ? new long?(nullable6.GetValueOrDefault() + 1L) : new long?();
      }
      catch (Exception ex)
      {
      }
    }
    return new long?();
  }

  public virtual JsInstance Date2numJsFunc(JsScope target, JsInstance[] parameters)
  {
    return (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, (object) this.FormCalcFunction_date2num(JintJsObject.Unwrap((object) parameters[0]), JintJsObject.Unwrap(parameters.Length > 1 ? (object) parameters[1] : (object) (JsInstance) null), JintJsObject.Unwrap(parameters.Length > 2 ? (object) parameters[2] : (object) (JsInstance) null)));
  }

  public virtual string FormCalcFunction_dateFmt(int? pictureNumber, object localeName)
  {
    if (this.flattenerContext.CurrentNode == null)
      return (string) null;
    XFATemplateTag template = this.flattenerContext.CurrentNode.Template;
    if (!(localeName is string) || ((string) localeName).Length == 0)
      localeName = template.Attributes.ContainsKey("locale") ? (object) template.Attributes["locale"] : (object) (string) null;
    XFALocale locale = this.flattenerContext.LocaleResolver.GetLocale((string) localeName);
    ref int? local = ref pictureNumber;
    int valueOrDefault = local.GetValueOrDefault();
    if (local.HasValue)
    {
      switch (valueOrDefault)
      {
        case 0:
        case 2:
          return locale.DatePattern["med"];
        case 1:
          return locale.DatePattern["short"];
        case 3:
          return locale.DatePattern["long"];
        case 4:
          return locale.DatePattern["full"];
      }
    }
    return (string) null;
  }

  public virtual JsInstance DateFmtJsFunc(JsScope target, JsInstance[] parameters)
  {
    return (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, (object) this.FormCalcFunction_dateFmt(new int?(parameters[0].ToInteger()), parameters.Length > 1 ? parameters[1].ToObject() : (object) null));
  }

  public virtual string FormCalcFunction_timefmt(int? pictureNumber, object localeName)
  {
    if (this.flattenerContext.CurrentNode == null)
      return (string) null;
    XFATemplateTag template = this.flattenerContext.CurrentNode.Template;
    if (!(localeName is string) || ((string) localeName).Length == 0)
    {
      string str;
      template.Attributes.TryGetValue("locale", out str);
      localeName = (object) str;
    }
    XFALocale locale = this.flattenerContext.LocaleResolver.GetLocale((string) localeName);
    ref int? local = ref pictureNumber;
    int valueOrDefault = local.GetValueOrDefault();
    if (local.HasValue)
    {
      switch (valueOrDefault)
      {
        case 0:
        case 2:
          return locale.TimePattern["med"];
        case 1:
          return locale.TimePattern["short"];
        case 3:
          return locale.TimePattern["long"];
        case 4:
          return locale.TimePattern["full"];
      }
    }
    return (string) null;
  }

  public virtual JsInstance TimefmtJsFunc(JsScope target, JsInstance[] parameters)
  {
    return (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, (object) this.FormCalcFunction_timefmt(new int?(parameters[0].ToInteger()), parameters.Length > 1 ? (object) parameters[1].ToString() : (object) (string) null));
  }

  public virtual object GetRecord() => (object) this.GetChild("data").RetrieveChildren()[0];

  private JsInstance RecordJsProp(JsNode target)
  {
    return (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, this.GetRecord());
  }

  public virtual int? FormCalcFunction_date()
  {
    DateTime dateTime = new DateTime(1900, 1, 1);
    DateTime today = DateTime.Today;
    int num = 1;
    for (; dateTime.CompareTo(today) < 0; dateTime = dateTime.AddDays(1.0))
      ++num;
    return new int?(num);
  }

  public virtual JsInstance DateJsFunc(JsScope target, JsInstance[] parameters)
  {
    return (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, (object) this.FormCalcFunction_date());
  }

  public virtual long FormCalcFunction_time()
  {
    DateTime dateTime = DateTime.Now;
    dateTime = dateTime.Subtract(dateTime.TimeOfDay);
    dateTime = dateTime.AddMilliseconds(1.0);
    return (long) (DateTime.Now - dateTime).TotalMilliseconds;
  }

  public virtual JsInstance TimeJsFunc(JsScope target, JsInstance[] parameters)
  {
    return (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, (object) this.FormCalcFunction_time());
  }

  public virtual string FormCalcFunction_num2time(object time, object picture, object localeName)
  {
    return this.FormCalcFunction_num2gmtime(time, picture, localeName);
  }

  public virtual JsInstance Num2timeJsFunc(JsScope target, JsInstance[] parameters)
  {
    return (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, (object) this.FormCalcFunction_num2time((object) parameters[0], parameters.Length > 1 ? JintJsObject.Unwrap((object) parameters[1]) : (object) null, parameters.Length > 2 ? JintJsObject.Unwrap((object) parameters[2]) : (object) null));
  }

  public virtual string FormCalcFunction_num2gmtime(object time, object picture, object localeName)
  {
    if (time is JsNode)
      time = ((JintJsObject) time).GetProperty("rawValue");
    time = JintJsObject.Unwrap(time);
    if (!(time is long num) || num <= 0L)
      return "";
    if (!(localeName is string) || ((string) localeName).Length == 0)
    {
      XFATemplateTag template = this.flattenerContext.CurrentNode.Template;
      string str = (string) null;
      template.Attributes.TryGetValue("locale", out str);
      localeName = (object) str;
    }
    XFALocale locale = this.flattenerContext.LocaleResolver.GetLocale((string) localeName);
    DateTime date = DateTime.Now;
    date = date.Subtract(date.TimeOfDay);
    date = date.AddMilliseconds((double) (long) time);
    try
    {
      return this.flattenerContext.FormatResolver.FormatTime(date, picture is string ? (string) picture : "h:MM:SS A", locale);
    }
    catch (Exception ex)
    {
    }
    return date.ToString();
  }

  public virtual JsInstance Num2gmtimeJsFunc(JsScope target, JsInstance[] parameters)
  {
    return (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, (object) this.FormCalcFunction_num2gmtime((object) parameters[0], parameters.Length > 1 ? JintJsObject.Unwrap((object) parameters[1]) : (object) null, parameters.Length > 2 ? JintJsObject.Unwrap((object) parameters[2]) : (object) null));
  }

  public virtual long? FormCalcFunction_time2num(object time, object picture, object localeName)
  {
    if (time is JsNode)
      time = ((JintJsObject) time).GetProperty("rawValue");
    time = JintJsObject.Unwrap(time);
    if (time is string && ((string) time).Length != 0)
    {
      if (!(localeName is string) || ((string) localeName).Length == 0)
      {
        string str;
        this.flattenerContext.CurrentNode.Template.Attributes.TryGetValue("locale", out str);
        localeName = (object) str;
      }
      XFALocale locale = this.flattenerContext.LocaleResolver.GetLocale((string) localeName);
      try
      {
        DateTime? time1 = this.flattenerContext.FormatResolver.ParseTime((string) time, picture is string ? (string) picture : "h:MM:SS A", locale);
        DateTime now = DateTime.Now;
        now.Subtract(now.TimeOfDay);
        DateTime dateTime1 = time1.Value.Subtract(time1.Value.TimeOfDay);
        DateTime? nullable = time1;
        DateTime dateTime2 = dateTime1;
        return new long?((long) (nullable.HasValue ? new TimeSpan?(nullable.GetValueOrDefault() - dateTime2) : new TimeSpan?()).Value.TotalMilliseconds);
      }
      catch (Exception ex)
      {
      }
    }
    return new long?();
  }

  public virtual JsInstance Time2numJsFunc(JsScope target, JsInstance[] parameters)
  {
    return (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, (object) this.FormCalcFunction_time2num((object) parameters[0], parameters.Length > 1 ? (object) parameters[1] : (object) (JsInstance) null, parameters.Length > 2 ? (object) parameters[2] : (object) (JsInstance) null));
  }

  public virtual object FormCalcFunction_abs(object number)
  {
    number = (object) this.Fc2jsHelperFuncNumericValueOf(number);
    double? nullable = new double?();
    if (number is double num)
      nullable = new double?(num);
    else if (number is string)
      nullable = new double?(double.Parse((string) number));
    return nullable.HasValue && !double.IsNaN(nullable.Value) ? (object) Math.Abs(nullable.Value) : number;
  }

  public virtual JsInstance AbsJsFunc(JsScope target, JsInstance[] parameters)
  {
    return (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, this.FormCalcFunction_abs((object) parameters[0]));
  }

  public virtual object FormCalcFunction_round(object number, int i)
  {
    number = (object) this.Fc2jsHelperFuncNumericValueOf(number);
    double? nullable1 = new double?();
    if (number is double num1)
    {
      nullable1 = new double?(num1);
    }
    else
    {
      double result;
      if (number is string && double.TryParse((string) number, out result))
        number = (object) result;
    }
    if (!nullable1.HasValue || double.IsNaN(nullable1.Value))
      return number;
    if (i > 0)
    {
      double? nullable2 = nullable1;
      double num2 = (double) (i * 10);
      nullable1 = nullable2.HasValue ? new double?(nullable2.GetValueOrDefault() * num2) : new double?();
    }
    long num3 = (long) Math.Round(nullable1.Value);
    if (i > 0)
      num3 /= (long) (i * 10);
    return (object) num3;
  }

  public virtual JsInstance RoundJsFunc(JsScope target, JsInstance[] parameters)
  {
    return (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, this.FormCalcFunction_round((object) parameters[0], parameters.Length > 1 ? parameters[1].ToInteger() : 0));
  }

  public virtual object FormCalcFunction_exists(object accessor)
  {
    return (object) (this.ResolveNodeInt((string) accessor) != null);
  }

  public virtual JsInstance ExistsJsFunc(JsScope target, JsInstance[] parameters)
  {
    return (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, this.FormCalcFunction_exists((object) parameters[0].ToString()));
  }

  public virtual bool FormCalcFunction_hasvalue(object obj)
  {
    if (obj is JsNode)
      obj = ((JintJsObject) obj).GetProperty("rawValue");
    return obj is string ? !string.IsNullOrEmpty(((string) obj).Trim()) : obj != null;
  }

  public virtual JsInstance HasvalueJsFunc(JsScope target, JsInstance[] parameters)
  {
    return (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, (object) this.FormCalcFunction_hasvalue((object) parameters[0]));
  }

  public virtual string FormCalcFunction_upper(object obj)
  {
    if (obj is JsNode)
      obj = ((JintJsObject) obj).GetProperty("rawValue");
    return obj is string ? (obj as string).ToUpperInvariant() : (string) null;
  }

  public virtual JsInstance UpperJsFunc(JsScope target, JsInstance[] parameters)
  {
    return (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, (object) this.FormCalcFunction_upper(JintJsObject.Unwrap((object) parameters[0])));
  }

  public virtual string FormCalcFunction_left(object obj, object charNum)
  {
    if (obj is JsNode)
      obj = ((JintJsObject) obj).GetProperty("rawValue");
    if (!(obj is string) || !(charNum is int val2))
      return (string) null;
    string str = (string) obj;
    return str.Substring(0, Math.Min(str.Length, val2));
  }

  public virtual JsInstance LeftJsFunc(JsScope target, JsInstance[] parameters)
  {
    return (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, (object) this.FormCalcFunction_left(JintJsObject.Unwrap((object) parameters[0]), (object) (parameters.Length <= 1 || !(parameters[1] is JsNumber) ? new int?() : new int?(parameters[1].ToInteger()))));
  }

  public virtual string FormCalcFunction_right(object obj, object charNum)
  {
    if (obj is JsNode)
      obj = ((JintJsObject) obj).GetProperty("rawValue");
    if (!(obj is string) || !(charNum is int val2))
      return (string) null;
    string str = (string) obj;
    int length = Math.Min(str.Length, val2);
    return str.Substring(str.Length - length - 1, length);
  }

  public virtual JsInstance RightJsFunc(JsScope target, JsInstance[] parameters)
  {
    return (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, (object) this.FormCalcFunction_right(JintJsObject.Unwrap((object) parameters[0]), (object) (parameters.Length <= 1 || !(parameters[1] is JsNumber) ? new int?() : new int?(parameters[1].ToInteger()))));
  }

  public virtual string FormCalcFunction_replace(
    object source,
    object toReplace,
    object replacement)
  {
    if (source is JsNode)
      source = ((JintJsObject) source).GetProperty("rawValue");
    if (!(source is string) || !(toReplace is string))
      return (string) null;
    if (!(replacement is string))
      replacement = (object) "";
    return ((string) source).Replace((string) toReplace, (string) replacement);
  }

  public virtual JsInstance ReplaceJsFunc(JsScope target, JsInstance[] parameters)
  {
    return (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, (object) this.FormCalcFunction_replace(JintJsObject.Unwrap((object) parameters[0]), JintJsObject.Unwrap(parameters.Length > 1 ? (object) parameters[1] : (object) (JsInstance) null), JintJsObject.Unwrap(parameters.Length > 2 ? (object) parameters[2] : (object) (JsInstance) null)));
  }

  public virtual string FormCalcFunction_space(object numOfSpaces)
  {
    if (numOfSpaces is JsNode)
      numOfSpaces = JintJsObject.Unwrap(((JintJsObject) numOfSpaces).GetProperty("rawValue"));
    if (!(numOfSpaces is int))
      return (string) null;
    StringBuilder stringBuilder = new StringBuilder();
    for (int index = 0; index < (int) numOfSpaces; ++index)
      stringBuilder.Append(" ");
    return stringBuilder.ToString();
  }

  public virtual JsInstance SpaceJsFunc(JsScope target, JsInstance[] parameters)
  {
    return (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, (object) this.FormCalcFunction_space((object) parameters[0].ToInteger()));
  }

  public virtual int? FormCalcFunction_len(object str)
  {
    if (str is JsNode)
      str = ((JintJsObject) str).GetProperty("rawValue");
    return str is string ? new int?(((string) str).Length) : new int?(0);
  }

  public virtual JsInstance FcImplLenJsFunc(JsScope target, JsInstance[] parameters)
  {
    return (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, (object) this.FormCalcFunction_len((object) parameters[0]));
  }

  public virtual JsInstance ThisHostJsProp(JsNode target)
  {
    return (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, this.GetProperty("host"));
  }

  public virtual JsInstance GetThisJs(JsScope target, JsInstance[] parameters)
  {
    return (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, (object) this.Fc2jsHelperConcat((object) parameters[0]));
  }

  public virtual bool IsRef(object obj) => obj is JsNode;

  public virtual JsInstance IsRefJsFunc(JsScope target, JsInstance[] parameters)
  {
    return (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, (object) this.IsRef((object) parameters[0]));
  }

  public virtual object Fc2jsHelperFuncValueOf(object obj)
  {
    return obj is JsNode ? ((JintJsObject) obj).GetProperty("rawValue") : obj;
  }

  public virtual JsInstance Fc2jsHelperFuncValueOfJsFunc(JsScope target, JsInstance[] parameters)
  {
    return (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, this.Fc2jsHelperFuncValueOf((object) parameters[0]));
  }

  public virtual string Fc2jsHelperConcat(object obj)
  {
    string str1 = "";
    switch (obj)
    {
      case string _:
        str1 += (string) obj;
        break;
      case JsNode _:
        str1 += this.Fc2jsHelperConcat(((JintJsObject) obj).GetProperty("rawValue"));
        break;
      case JsArray _:
        for (int i = 0; i < ((JsDictionaryObject) obj).Length; ++i)
          str1 += this.Fc2jsHelperConcat((object) ((JsArray) obj).get(i));
        break;
      case Decimal _:
      case long _:
        if (obj is long)
          obj = (object) Convert.ToDecimal((long) obj);
        string str2;
        try
        {
          str2 = ((Decimal) obj).ToString("", (IFormatProvider) NumberFormatInfo.InvariantInfo);
        }
        catch (Exception ex)
        {
          str2 = (string) null;
        }
        if (str2 != null)
        {
          str1 += str2;
          break;
        }
        break;
      case bool flag:
        str1 = !flag ? str1 + "0" : str1 + "1";
        break;
    }
    return str1;
  }

  public virtual JsInstance Fc2jsHelperConcatJsFunc(JsScope target, JsInstance[] parameters)
  {
    return (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, (object) this.Fc2jsHelperConcat(JintJsObject.Unwrap((object) parameters[0])));
  }

  public virtual double Fc2jsHelperNumericSum(object obj)
  {
    obj = JintJsObject.Unwrap(obj);
    double num = 0.0;
    bool flag1 = false;
    try
    {
      if (obj != null)
      {
        Convert.ToDouble(obj);
        flag1 = true;
      }
    }
    catch (Exception ex)
    {
    }
    if (flag1)
    {
      num += Convert.ToDouble(obj);
    }
    else
    {
      switch (obj)
      {
        case JsNode _:
          num += this.Fc2jsHelperNumericSum(((JintJsObject) obj).GetProperty("rawValue"));
          break;
        case JsArray _:
          for (int i = 0; i < ((JsDictionaryObject) obj).Length; ++i)
            num += this.Fc2jsHelperNumericSum((object) ((JsArray) obj).get(i));
          break;
        case string _:
          double? nullable = new double?();
          try
          {
            double result;
            if (double.TryParse((string) obj, out result))
              nullable = new double?(result);
          }
          catch (Exception ex)
          {
            nullable = new double?();
          }
          if (nullable.HasValue)
          {
            num += nullable.Value;
            break;
          }
          break;
        case bool flag2:
          if (flag2)
          {
            ++num;
            break;
          }
          break;
      }
    }
    return num;
  }

  public virtual JsInstance Fc2jsHelperNumericSumJsFunc(JsScope target, JsInstance[] parameters)
  {
    return (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, (object) this.Fc2jsHelperNumericSum((object) parameters[0]));
  }

  public virtual double Fc2jsHelperFuncNumericValueOf(object obj)
  {
    obj = JintJsObject.Unwrap(obj);
    bool flag1 = false;
    try
    {
      if (obj != null)
      {
        Convert.ToDouble(obj);
        flag1 = true;
      }
    }
    catch (Exception ex)
    {
    }
    if (flag1)
      return Convert.ToDouble(obj);
    switch (obj)
    {
      case JsNode _:
        return this.Fc2jsHelperFuncNumericValueOf(((JintJsObject) obj).GetProperty("rawValue"));
      case JsArray _:
        throw new JintException("Attempt to get value from an array during FormCalc evaluation");
      case string _:
        double? nullable = new double?();
        try
        {
          double result;
          if (double.TryParse((string) obj, out result))
            nullable = new double?(result);
        }
        catch (Exception ex)
        {
          nullable = new double?();
        }
        if (nullable.HasValue)
          return nullable.Value;
        break;
      case bool flag2:
        if (flag2)
          return 1.0;
        break;
    }
    return 0.0;
  }

  public virtual JsInstance Fc2jsHelperFuncNumericValueOfJsFunc(
    JsScope target,
    JsInstance[] parameters)
  {
    return (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, (object) this.Fc2jsHelperFuncNumericValueOf((object) parameters[0]));
  }
}
