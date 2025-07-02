// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.pipe.LocalePipeline
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.tool.xml.pipeline;
using iTextSharp.tool.xml.xtra.xfa.resolver;
using iTextSharp.tool.xml.xtra.xfa.tags;
using System.Collections.Generic;
using System.Globalization;
using System.util;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.pipe;

public class LocalePipeline : AbstractPipeline
{
  private XFALocale currentLocale;
  private CultureInfo defaultLocale;

  public LocalePipeline(IPipeline next, CultureInfo defaultLocale)
    : base(next)
  {
    this.defaultLocale = defaultLocale;
  }

  public virtual IPipeline Open(IWorkerContext context, Tag t, ProcessObject po)
  {
    string name = t.Name;
    LocaleResolver localContext = (LocaleResolver) this.GetLocalContext(context);
    if (Util.EqualsIgnoreCase("locale", name))
      this.currentLocale = localContext.AddLocale(t.Attributes["name"]);
    return this.GetNext();
  }

  public virtual IPipeline Content(
    IWorkerContext context,
    Tag t,
    string content,
    ProcessObject po)
  {
    if (t is XFATemplateTag && content.Trim().Length > 0)
      ((XFATemplateTag) t).AddContent(content);
    return this.GetNext();
  }

  public virtual IPipeline Close(IWorkerContext context, Tag t, ProcessObject po)
  {
    if (this.currentLocale != null)
    {
      string name = t.Name;
      if (Util.EqualsIgnoreCase("locale", name))
        this.currentLocale = (XFALocale) null;
      else if (Util.EqualsIgnoreCase("monthNames", name))
      {
        string[] strArray = this.CollectStringValues(t, 13);
        strArray[12] = "";
        string str;
        if (t.Attributes.TryGetValue("abbr", out str) && "1".Equals(str))
          this.currentLocale.DateFormatInfo.AbbreviatedMonthNames = strArray;
        else
          this.currentLocale.DateFormatInfo.MonthNames = strArray;
      }
      else if (Util.EqualsIgnoreCase("dayNames", name))
      {
        string[] strArray = this.CollectStringValues(t, 7);
        string str;
        if (t.Attributes.TryGetValue("abbr", out str) && "1".Equals(str))
          this.currentLocale.DateFormatInfo.ShortestDayNames = strArray;
        else
          this.currentLocale.DateFormatInfo.DayNames = strArray;
      }
      else if (Util.EqualsIgnoreCase("meridiemNames", name))
      {
        string[] strArray = this.CollectStringValues(t, 2);
        this.currentLocale.DateFormatInfo.AMDesignator = strArray[0];
        this.currentLocale.DateFormatInfo.PMDesignator = strArray[1];
      }
      else if (!Util.EqualsIgnoreCase("eraNames", name))
      {
        if (Util.EqualsIgnoreCase("datePatterns", name))
          this.CollectNamedValues(t, this.currentLocale.DatePattern);
        else if (Util.EqualsIgnoreCase("timePatterns", name))
          this.CollectNamedValues(t, this.currentLocale.TimePattern);
        else if (Util.EqualsIgnoreCase("numberPatterns", name))
          this.CollectNamedValues(t, this.currentLocale.NumberPattern);
        else if (Util.EqualsIgnoreCase("numberSymbols", name))
        {
          foreach (Tag child in (IEnumerable<Tag>) t.Children)
          {
            XFATemplateTag xfaTemplateTag = child is XFATemplateTag ? (XFATemplateTag) child : (XFATemplateTag) null;
            if (xfaTemplateTag != null && xfaTemplateTag.Content != null && xfaTemplateTag.Content.Count > 0)
            {
              string str1 = xfaTemplateTag.Content[0];
              string str2;
              if (str1.Length > 0 && xfaTemplateTag.Attributes.TryGetValue("name", out str2))
              {
                switch (str2)
                {
                  case "grouping":
                    this.currentLocale.NumberFormatInfo.NumberGroupSeparator = str1;
                    this.currentLocale.NumberFormatInfo.CurrencyGroupSeparator = str1;
                    continue;
                  case "decimal":
                    this.currentLocale.NumberFormatInfo.NumberDecimalSeparator = str1;
                    this.currentLocale.NumberFormatInfo.CurrencyDecimalSeparator = str1;
                    continue;
                  default:
                    continue;
                }
              }
            }
          }
        }
        else if (Util.EqualsIgnoreCase("currencySymbols", name))
        {
          foreach (Tag child in (IEnumerable<Tag>) t.Children)
          {
            XFATemplateTag xfaTemplateTag = child is XFATemplateTag ? (XFATemplateTag) child : (XFATemplateTag) null;
            if (xfaTemplateTag != null && xfaTemplateTag.Content != null && xfaTemplateTag.Content.Count > 0)
            {
              string str3 = xfaTemplateTag.Content[0];
              string str4;
              if (xfaTemplateTag.Attributes.TryGetValue("name", out str4))
              {
                if (str4.Equals("symbol"))
                {
                  this.currentLocale.NumberFormatInfo.CurrencySymbol = str3;
                  break;
                }
                "isoname".Equals(str4);
              }
            }
          }
        }
      }
    }
    return this.GetNext();
  }

  public virtual IPipeline Init(IWorkerContext context)
  {
    LocaleResolver localeResolver = new LocaleResolver();
    localeResolver.SetDefaultLocale(this.defaultLocale);
    context.Put(this.GetContextKey(), (ICustomContext) localeResolver);
    return base.Init(context);
  }

  private string[] CollectStringValues(Tag t, int expectedSize)
  {
    string[] strArray = new string[expectedSize];
    int index = 0;
    foreach (Tag child in (IEnumerable<Tag>) t.Children)
    {
      XFATemplateTag xfaTemplateTag = child is XFATemplateTag ? (XFATemplateTag) child : (XFATemplateTag) null;
      if (xfaTemplateTag != null && xfaTemplateTag.Content != null && xfaTemplateTag.Content.Count > 0)
      {
        strArray[index] = xfaTemplateTag.Content[0];
        ++index;
      }
      if (index >= expectedSize)
        break;
    }
    return strArray;
  }

  private void CollectNamedValues(Tag t, IDictionary<string, string> values)
  {
    foreach (Tag child in (IEnumerable<Tag>) t.Children)
    {
      XFATemplateTag xfaTemplateTag = child is XFATemplateTag ? (XFATemplateTag) child : (XFATemplateTag) null;
      string key;
      if (xfaTemplateTag != null && xfaTemplateTag.Content != null && xfaTemplateTag.Content.Count > 0 && xfaTemplateTag.Attributes.TryGetValue("name", out key) && key != null)
        values[key] = xfaTemplateTag.Content[0];
    }
  }
}
