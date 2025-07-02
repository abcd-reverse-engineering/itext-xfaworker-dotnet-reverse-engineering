// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.resolver.FormatResolver
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.util;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.resolver;

public class FormatResolver
{
  public static readonly string[] CANONICAL_DATE_PATTERNS = new string[5]
  {
    "yyyy-MM-dd",
    "yyyy-MM",
    "yyyyMMdd",
    "yyyyMM",
    "yyyy"
  };
  public static readonly string[] CANONICAL_TIME_PATTERNS = new string[4]
  {
    "HH:mm:ss.fff",
    "HH:mm:sszzz",
    "HH:mm:ss",
    "HH:mm"
  };
  private FlattenerContext flattenerContext;

  public FormatResolver(FlattenerContext flattenerContext)
  {
    this.flattenerContext = flattenerContext;
  }

  public string Resolve(
    object data,
    string pattern,
    string inputParsingPattern,
    FormatResolver.FormatType? type,
    string localeName,
    Dictionary<string, string> attributes)
  {
    XFALocale locale = this.flattenerContext.LocaleResolver.GetLocale(localeName);
    bool flag = false;
    if (pattern == null)
    {
      flag = true;
      FormatResolver.FormatType? nullable1 = type;
      if ((nullable1.GetValueOrDefault() != FormatResolver.FormatType.FLOAT ? 0 : (nullable1.HasValue ? 1 : 0)) != 0)
      {
        locale.NumberPattern.TryGetValue("numeric", out pattern);
      }
      else
      {
        FormatResolver.FormatType? nullable2 = type;
        if ((nullable2.GetValueOrDefault() != FormatResolver.FormatType.INTEGER ? 0 : (nullable2.HasValue ? 1 : 0)) != 0)
        {
          locale.NumberPattern.TryGetValue("numeric", out pattern);
          if (pattern != null && pattern.Contains("."))
            pattern = pattern.Substring(0, pattern.IndexOf('.'));
        }
        else
        {
          FormatResolver.FormatType? nullable3 = type;
          if ((nullable3.GetValueOrDefault() != FormatResolver.FormatType.DATE ? 0 : (nullable3.HasValue ? 1 : 0)) != 0)
          {
            locale.DatePattern.TryGetValue("med", out pattern);
          }
          else
          {
            FormatResolver.FormatType? nullable4 = type;
            if ((nullable4.GetValueOrDefault() != FormatResolver.FormatType.DATE_TIME ? 0 : (nullable4.HasValue ? 1 : 0)) != 0)
            {
              string str = $"time{{{locale.TimePattern["med"]}}}";
              pattern = $"{$"date{{{locale.DatePattern["med"]}}}"} {str}";
            }
          }
        }
      }
    }
    else
      attributes?.Remove("fracDigits");
    if (data is double)
      data = (object) Convert.ToDecimal((double) data);
    if (string.IsNullOrEmpty(pattern))
    {
      if (data is Decimal num)
      {
        try
        {
          NumberFormatInfo invariantInfo = NumberFormatInfo.InvariantInfo;
          return num.ToString("", (IFormatProvider) invariantInfo);
        }
        catch (Exception ex)
        {
          return data.ToString();
        }
      }
      else
        return data?.ToString();
    }
    else
    {
      FormatResolver.FormatType? nullable = type;
      if ((nullable.GetValueOrDefault() != FormatResolver.FormatType.DATE_TIME ? 0 : (nullable.HasValue ? 1 : 0)) != 0)
        type = new FormatResolver.FormatType?();
      if (inputParsingPattern != null && (inputParsingPattern.Contains("|") || inputParsingPattern.Contains("null") || inputParsingPattern.Contains("zero")))
        inputParsingPattern = (string) null;
      if (inputParsingPattern != null && Regex.IsMatch(inputParsingPattern, "^((num)|(date)|(time)|(text))\\.?\\w*\\{.*\\}$"))
      {
        StringBuilder categorisedPattern = new StringBuilder();
        if (this.NormalizeCategorizedPattern(inputParsingPattern, categorisedPattern, locale).HasValue)
          inputParsingPattern = categorisedPattern.ToString();
      }
      string str = pattern;
      char[] chArray = new char[1]{ '|' };
      foreach (string pattern1 in str.Split(chArray))
      {
        StringBuilder formattedText = new StringBuilder();
        if (this.Format(data, inputParsingPattern, formattedText, pattern1, type, locale, attributes))
          return formattedText.ToString();
      }
      if (data != null && !flag)
        return this.Resolve(data, (string) null, inputParsingPattern, type, localeName, attributes);
      return data?.ToString();
    }
  }

  private bool Format(
    object data,
    string inputParsingPattern,
    StringBuilder formattedText,
    string pattern,
    FormatResolver.FormatType? type,
    XFALocale xfaLocale,
    Dictionary<string, string> attributes)
  {
    string pattern1 = "((num)|(date)|(time)|(text)|(null)|(zero))(\\(\\w+\\))?\\.?\\w*\\{.*?\\}";
    pattern = Regex.Replace(pattern, "datetime\\.([a-z]*)\\{\\}", "date.$1{} time.$1{}").Trim();
    MatchCollection matchCollection = new Regex(pattern1, RegexOptions.IgnoreCase).Matches(pattern);
    bool flag = false;
    int startIndex = 0;
    foreach (Match match in matchCollection)
    {
      if (startIndex != match.Index)
      {
        string pattern2 = pattern.Substring(startIndex, match.Index - startIndex);
        string str = this.SimpleFormat(data, inputParsingPattern, pattern2, type, xfaLocale, attributes);
        if (str != null)
          formattedText.Append(str);
        else
          flag = true;
      }
      string str1 = pattern.Substring(match.Index, match.Length);
      StringBuilder categorisedPattern = new StringBuilder();
      XFALocale xfaLocale1 = (XFALocale) null;
      if (Regex.IsMatch(str1, "^((num)|(date)|(time)|(text)|(null)|(zero))(\\(\\w+\\)).*$"))
      {
        string str2 = Regex.Replace(str1, "((num)|(date)|(time)|(text)|(null)|(zero))\\(", "");
        xfaLocale1 = this.flattenerContext.LocaleResolver.GetLocale(str2.Substring(0, str2.IndexOf(')')));
      }
      FormatResolver.FormatType? nullable1 = this.NormalizeCategorizedPattern(str1, categorisedPattern, xfaLocale1 ?? xfaLocale);
      if (nullable1.HasValue)
        str1 = categorisedPattern.ToString();
      else if (str1.Contains("null"))
      {
        if (data != null && (!(data is string) || ((string) data).Length != 0))
          return false;
        nullable1 = new FormatResolver.FormatType?(FormatResolver.FormatType.FLOAT);
        str1 = categorisedPattern.ToString();
        if (str1.Length == 0)
          return true;
        data = (object) str1;
      }
      else if (str1.Contains("zero"))
      {
        switch (data)
        {
          case Decimal _:
label_19:
            Decimal? nullable2 = !(data is Decimal num) ? (Decimal?) this.ParseNumber(data.ToString(), inputParsingPattern, xfaLocale1 == null ? xfaLocale : xfaLocale1, false)?.GetNumber() : new Decimal?(num);
            if (!nullable2.HasValue || !(nullable2.Value == 0M))
              return false;
            nullable1 = new FormatResolver.FormatType?(FormatResolver.FormatType.FLOAT);
            str1 = categorisedPattern.ToString();
            if (str1.Length == 0)
              return true;
            goto label_24;
          case string _:
            if (((string) data).Length == 0)
              break;
            goto label_19;
        }
        return false;
      }
label_24:
      if (data == null)
        data = (object) "";
      string str3 = this.SimpleFormat(data, inputParsingPattern, str1, new FormatResolver.FormatType?(nullable1.Value), xfaLocale1 ?? xfaLocale, attributes);
      if (str3 != null)
        formattedText.Append(str3);
      else
        flag = true;
      startIndex = match.Index + match.Length;
    }
    if (startIndex < pattern.Length)
    {
      string pattern3 = pattern.Substring(startIndex, pattern.Length - startIndex);
      string str = this.SimpleFormat(data, inputParsingPattern, pattern3, type, xfaLocale, attributes);
      if (str != null)
        formattedText.Append(str);
      else
        flag = true;
    }
    if (!flag)
      return true;
    formattedText.Length = 0;
    return false;
  }

  private string SimpleFormat(
    object data,
    string inputParsingPattern,
    string pattern,
    FormatResolver.FormatType? type,
    XFALocale xfaLocale,
    Dictionary<string, string> attributes)
  {
    try
    {
      string[] strArray = Regex.Split(pattern, "[']");
      string str1 = "";
      bool flag = true;
      string str2 = (string) null;
      for (int index = 0; index < strArray.Length; ++index)
      {
        if (!flag)
        {
          str1 += strArray[index];
          flag = true;
        }
        else
        {
          flag = false;
          string str3 = strArray[index];
          if (str3.Length != 0)
          {
            FormatResolver.FormatType? nullable1 = type;
            FormatResolver.FormatType? nullable2 = nullable1;
            if (((nullable2.GetValueOrDefault() != FormatResolver.FormatType.TEXT ? 0 : (nullable2.HasValue ? 1 : 0)) != 0 || !nullable1.HasValue) && Regex.IsMatch(str3, "^[A|0|O|X|9|\\?|\\*|\\+|\\s|\\-|,|:|\\.]*$"))
            {
              if (str2 == null)
                str2 = data.ToString();
              StringBuilder text = new StringBuilder(str2);
              string str4 = this.FormatText(text, str3, xfaLocale);
              if (str4 == null)
                return (string) null;
              str1 += str4;
              str2 = text.ToString();
            }
            else
            {
              FormatResolver.FormatType? nullable3 = nullable1;
              DateTime? date;
              if (((nullable3.GetValueOrDefault() != FormatResolver.FormatType.DATE ? 0 : (nullable3.HasValue ? 1 : 0)) != 0 || !nullable1.HasValue) && (date = this.ParseDate(data.ToString(), inputParsingPattern, xfaLocale)).HasValue)
              {
                if (str2 != null)
                {
                  if (str2.Length > 0)
                    return (string) null;
                  str2 = (string) null;
                }
                str1 += this.FormatDate(date.Value, str3, xfaLocale);
              }
              else
              {
                FormatResolver.FormatType? nullable4 = nullable1;
                DateTime? time;
                if (((nullable4.GetValueOrDefault() != FormatResolver.FormatType.TIME ? 0 : (nullable4.HasValue ? 1 : 0)) != 0 || !nullable1.HasValue) && (time = this.ParseTime(data.ToString(), inputParsingPattern, xfaLocale)).HasValue)
                {
                  if (str2 != null)
                  {
                    if (str2.Length > 0)
                      return (string) null;
                    str2 = (string) null;
                  }
                  str1 += this.FormatTime(time.Value, str3, xfaLocale);
                }
                else
                {
                  FormatResolver.FormatType? nullable5 = nullable1;
                  if ((nullable5.GetValueOrDefault() != FormatResolver.FormatType.FLOAT ? 0 : (nullable5.HasValue ? 1 : 0)) == 0)
                  {
                    FormatResolver.FormatType? nullable6 = nullable1;
                    if ((nullable6.GetValueOrDefault() != FormatResolver.FormatType.INTEGER ? 0 : (nullable6.HasValue ? 1 : 0)) == 0)
                      return (string) null;
                  }
                  if (str2 != null)
                  {
                    if (str2.Length > 0)
                      return (string) null;
                    str2 = (string) null;
                  }
                  Decimal? nullable7 = !(data is Decimal) ? (Decimal?) this.ParseNumber(data.ToString(), inputParsingPattern, xfaLocale, false)?.GetNumber() : (Decimal?) data;
                  if (!nullable7.HasValue)
                    return (string) null;
                  str1 += this.FormatNumber(nullable7.Value, str3, xfaLocale, attributes);
                }
              }
            }
          }
        }
      }
      return !string.IsNullOrEmpty(str2) ? (string) null : str1;
    }
    catch (Exception ex)
    {
      return (string) null;
    }
  }

  private string FormatNumber(
    Decimal value,
    string pattern,
    XFALocale xfaLocale,
    Dictionary<string, string> attributes)
  {
    NumberFormatInfo numberFormatInfo = xfaLocale.NumberFormatInfo;
    pattern = this.NormalizeNumberFormatPattern(pattern, xfaLocale, numberFormatInfo);
    string str1 = pattern;
    char[] chArray = new char[1]{ '|' };
    foreach (string pattern1 in str1.Split(chArray))
    {
      if (FormatResolver.CanFormatNumberWithPattern(pattern1, value))
      {
        string str2 = (string) pattern1.Clone();
        string formattedNumberIfNedeed;
        try
        {
          int num = -1;
          NumberFormatInfo provider = numberFormatInfo;
          if (attributes != null && attributes.ContainsKey("fracDigits") && (double) this.flattenerContext.XfaVersion <= 3.0)
          {
            num = int.Parse(attributes["fracDigits"]);
            if (num >= 0)
              value = this.TruncateDouble(value, num);
          }
          string format = str2 != "" ? str2 : "N" + Math.Max(0, num).ToString((IFormatProvider) CultureInfo.InvariantCulture);
          formattedNumberIfNedeed = value.ToString(format, (IFormatProvider) provider);
          if (num >= 0)
            formattedNumberIfNedeed = this.AddZeroToFormattedNumberIfNedeed(num, formattedNumberIfNedeed, xfaLocale);
        }
        catch (Exception ex)
        {
          continue;
        }
        return formattedNumberIfNedeed;
      }
    }
    string format1 = this.NormalizeNumberFormatPattern(xfaLocale.NumberPattern["numeric"], xfaLocale, numberFormatInfo);
    return value.ToString(format1, (IFormatProvider) xfaLocale.NumberFormatInfo);
  }

  private Decimal TruncateDouble(Decimal val, int places)
  {
    return Math.Truncate(val * (Decimal) (int) Math.Pow(10.0, (double) places)) / (Decimal) Math.Pow(10.0, (double) places);
  }

  private string AddZeroToFormattedNumberIfNedeed(
    int fracDigits,
    string formattedNumber,
    XFALocale xfaLocale)
  {
    int num1 = 0;
    int num2 = formattedNumber.IndexOf(xfaLocale.NumberFormatInfo.NumberDecimalSeparator);
    if (num2 >= 0)
      num1 = this.FindLastNumericPosition(formattedNumber) - num2;
    if (fracDigits > num1)
    {
      int num3 = fracDigits - num1;
      string str = "";
      if (num1 == 0)
        str += xfaLocale.NumberFormatInfo.NumberDecimalSeparator;
      for (int index = 0; index < num3; ++index)
        str += "0";
      if (char.IsNumber(formattedNumber[formattedNumber.Length - 1]))
      {
        formattedNumber += str;
      }
      else
      {
        int lastNumericPosition = this.FindLastNumericPosition(formattedNumber);
        formattedNumber = formattedNumber.Insert(lastNumericPosition + 1, str);
      }
    }
    return formattedNumber;
  }

  private int FindLastNumericPosition(string formattedNumber)
  {
    for (int index = formattedNumber.Length - 1; index >= 0; --index)
    {
      if (char.IsNumber(formattedNumber[index]))
        return index;
    }
    return -1;
  }

  public virtual string FormatDate(DateTime date, string pattern, XFALocale xfaLocale)
  {
    pattern = this.NormalizeDatePattern(pattern, xfaLocale);
    return date.ToString(pattern, (IFormatProvider) xfaLocale.DateFormatInfo);
  }

  public virtual string FormatTime(DateTime date, string pattern, XFALocale xfaLocale)
  {
    pattern = this.NormalizeTimePattern(pattern, xfaLocale);
    return date.ToString(pattern, (IFormatProvider) xfaLocale.DateFormatInfo);
  }

  private string FormatText(StringBuilder text, string pattern, XFALocale xfaLocale)
  {
    string str1 = "";
    pattern = this.NormalizeTextPattern(pattern, xfaLocale);
    foreach (string input in Regex.Split(pattern, "[,|\\-|:|/|\\.|\\s}]"))
    {
      int length1 = pattern.IndexOf(input);
      int length2 = input.Length;
      string str2 = str1 + pattern.Substring(0, length1);
      pattern = pattern.Substring(length1 + length2, pattern.Length - (length1 + length2));
      MatchCollection matchCollection = new Regex(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(input, "A", "[a-zA-Z]"), "X", "?"), "O", "\\w"), "0", "\\w"), "9", "\\d"), RegexOptions.IgnoreCase).Matches(text.ToString());
      if (matchCollection.Count <= 0)
        return (string) null;
      string str3 = text.ToString().Substring(matchCollection[0].Index, matchCollection[0].Length);
      str1 = str2 + str3;
      text.Remove(0, matchCollection[0].Index + matchCollection[0].Length);
    }
    if (pattern.Length > 0)
    {
      str1 += pattern;
      text.Remove(0, text.Length);
    }
    return str1;
  }

  private string NormalizeDatePattern(string origPattern, XFALocale xfaLocale)
  {
    return origPattern.Replace('Y', 'y').Replace("EEEE", "dddd").Replace("EEE", "ddd").Replace("m", "M").Replace('D', 'd').Replace('A', 'a').Replace("/", "'/'");
  }

  private string NormalizeTimePattern(string origPattern, XFALocale xfaLocale)
  {
    return origPattern.Replace("A", "tt").Replace('Z', 'z').Replace('M', 'm').Replace('S', 's');
  }

  private string NormalizeTextPattern(string origPattern, XFALocale xfaLocale)
  {
    return origPattern.Replace('+', ' ').Replace('*', ' ').Replace('?', ' ');
  }

  private FormatResolver.FormatType? NormalizeCategorizedPattern(
    string origPattern,
    StringBuilder categorisedPattern,
    XFALocale xfaLocale)
  {
    FormatResolver.FormatType? nullable1 = new FormatResolver.FormatType?();
    if (origPattern.Contains("date"))
      nullable1 = new FormatResolver.FormatType?(FormatResolver.FormatType.DATE);
    else if (origPattern.Contains("time"))
      nullable1 = new FormatResolver.FormatType?(FormatResolver.FormatType.TIME);
    else if (origPattern.Contains("num"))
      nullable1 = new FormatResolver.FormatType?(FormatResolver.FormatType.FLOAT);
    else if (origPattern.Contains("text"))
      nullable1 = new FormatResolver.FormatType?(FormatResolver.FormatType.TEXT);
    if (Regex.IsMatch(origPattern, "^((num)|(date)|(time))\\.\\w+\\{\\}$"))
    {
      int startIndex = origPattern.IndexOf('.') + 1;
      int num = origPattern.IndexOf('{');
      string key = origPattern.Substring(startIndex, num - startIndex);
      string str = (string) null;
      FormatResolver.FormatType? nullable2 = nullable1;
      if ((nullable2.GetValueOrDefault() != FormatResolver.FormatType.DATE ? 0 : (nullable2.HasValue ? 1 : 0)) != 0)
      {
        if (Util.EqualsIgnoreCase(key, "default") || Util.EqualsIgnoreCase(key, "medium"))
          xfaLocale.DatePattern.TryGetValue("med", out str);
        else
          xfaLocale.DatePattern.TryGetValue(key, out str);
      }
      else
      {
        FormatResolver.FormatType? nullable3 = nullable1;
        if ((nullable3.GetValueOrDefault() != FormatResolver.FormatType.TIME ? 0 : (nullable3.HasValue ? 1 : 0)) != 0)
        {
          if (Util.EqualsIgnoreCase(key, "default") || Util.EqualsIgnoreCase(key, "medium"))
            xfaLocale.TimePattern.TryGetValue("med", out str);
          else
            xfaLocale.TimePattern.TryGetValue(key, out str);
        }
        else
        {
          FormatResolver.FormatType? nullable4 = nullable1;
          if ((nullable4.GetValueOrDefault() != FormatResolver.FormatType.FLOAT ? 0 : (nullable4.HasValue ? 1 : 0)) != 0)
          {
            if (Util.EqualsIgnoreCase("decimal", key))
              xfaLocale.NumberPattern.TryGetValue("numeric", out str);
            else if (Util.EqualsIgnoreCase("integer", key))
            {
              xfaLocale.NumberPattern.TryGetValue("numeric", out str);
              if (str != null && str.Contains("."))
                str = str.Substring(0, str.IndexOf('.'));
            }
            else
              xfaLocale.NumberPattern.TryGetValue(key, out str);
          }
        }
      }
      if (str != null)
        categorisedPattern.Append(str);
    }
    else
    {
      int startIndex = origPattern.IndexOf('{') + 1;
      int num = origPattern.IndexOf('}');
      string input = origPattern.Substring(startIndex, num - startIndex);
      if (origPattern.StartsWith("null") && Regex.IsMatch(input, "[0-9\\sv]+"))
        input = input.Replace("v", "");
      categorisedPattern.Append(input);
    }
    return nullable1;
  }

  private string NormalizeNumberFormatPattern(
    string origPattern,
    XFALocale locale,
    NumberFormatInfo decimalFormatSymbols)
  {
    string str1 = Regex.Replace(origPattern.Replace('z', '#').Replace('9', '0').Replace('8', '0').Replace("(", "").Replace(")", ""), "s|S", "");
    int num;
    string str2 = (num = str1.IndexOf('.')) < 0 || str1.IndexOf('Z', num) <= -1 ? str1.Replace('Z', '#') : $"{str1.Substring(0, num)}.{str1.Substring(num + 1, str1.Length - num - 1).Replace('Z', '0')}";
    string input = !str2.Contains("$$") ? str2.Replace("$", this.GetCurrencySymbol(locale)) : str2.Replace("$$", this.GetCurrencySymbol(locale));
    if (input.Contains("v"))
    {
      int length = input.IndexOf("v");
      if (length < input.Length - 1)
      {
        char ch = input[length + 1];
        switch (ch)
        {
          case ' ':
          case ',':
          case '.':
            decimalFormatSymbols.NumberDecimalSeparator = ch.ToString();
            break;
        }
        input = (input.Substring(0, length + 1) + input.Substring(length + 2, input.Length - (length + 2))).Replace("v", ".");
      }
      else
        input = input.Substring(0, length) + input.Substring(length + 1, input.Length - (length + 1));
    }
    string pattern = "^([^0#\\.\\,Ee;\\-\\%\\?¤]*[0#\\.\\,Ee;\\-\\%\\?¤ ]*[^0#\\.\\,Ee;\\-\\%\\?¤]*)(\\|[^0#\\.\\,Ee;\\-\\%\\?¤]*[0#\\.\\,Ee;\\-\\%\\?¤ ]*[^0#\\.\\,Ee;\\-\\%\\?¤]*)*$";
    return !Regex.IsMatch(input, pattern) ? "" : input;
  }

  private string GetCurrencySymbol(XFALocale locale)
  {
    string currencySymbol = locale.NumberFormatInfo.CurrencySymbol;
    return currencySymbol.IndexOf('.') > -1 ? currencySymbol.Replace(".", "\\.") : currencySymbol;
  }

  private NumberStyles NormalizeNumberParsePattern(string origPattern, out bool isPercent)
  {
    isPercent = false;
    NumberStyles pattern = NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint;
    if (string.IsNullOrEmpty(origPattern))
      return pattern;
    if (origPattern.IndexOf(',') > -1)
      pattern |= NumberStyles.AllowThousands;
    if (origPattern.IndexOf('$') > -1)
      pattern |= NumberStyles.AllowCurrencySymbol;
    if (origPattern.IndexOf('%') == origPattern.Length - 1)
      isPercent = true;
    return pattern;
  }

  public DateTime? ParseDate(string data, string inputParsingPattern, XFALocale xfaLocale)
  {
    DateTime? nullable = new DateTime?();
    if (inputParsingPattern == null)
      return this.ParseDate(data, xfaLocale);
    try
    {
      inputParsingPattern = this.NormalizeDatePattern(inputParsingPattern, xfaLocale);
      return new DateTime?(DateTime.ParseExact(data.Split()[0], inputParsingPattern, (IFormatProvider) xfaLocale.DateFormatInfo));
    }
    catch (Exception ex)
    {
      return this.ParseDate(data, xfaLocale);
    }
  }

  public DateTime? ParseDate(string data, XFALocale xfaLocale)
  {
    if (data == null || !Regex.IsMatch(data, "^\\d{4}-?((0[1-9])|(1[0-2]))?-?((0[1-9])|([1,2][0-9])|(3[01]))?(T.+)?$"))
      return new DateTime?();
    DateTime? nullable = new DateTime?();
    foreach (string format in FormatResolver.CANONICAL_DATE_PATTERNS)
    {
      try
      {
        int length = data.IndexOf("t", StringComparison.OrdinalIgnoreCase);
        nullable = new DateTime?(DateTime.ParseExact(length != -1 ? data.Substring(0, length) : data, format, (IFormatProvider) xfaLocale.Locale));
        break;
      }
      catch (Exception ex)
      {
      }
    }
    return nullable.HasValue && nullable.Value.Year < 1900 ? new DateTime?() : nullable;
  }

  public virtual DateTime? ParseTime(string data, string inputParsingPattern, XFALocale xfaLocale)
  {
    DateTime? nullable = new DateTime?();
    if (inputParsingPattern == null)
      return this.ParseTime(data, xfaLocale);
    try
    {
      inputParsingPattern = this.NormalizeTimePattern(inputParsingPattern, xfaLocale);
      return new DateTime?(DateTime.ParseExact(data, inputParsingPattern, (IFormatProvider) xfaLocale.DateFormatInfo));
    }
    catch (Exception ex)
    {
      return this.ParseTime(data, xfaLocale);
    }
  }

  public virtual DateTime? ParseTime(string data, XFALocale xfaLocale)
  {
    string s = Regex.Replace(data, "([^+-]*)(\\+|-)(\\d\\d):(\\d\\d)", "$1$2$3$4");
    if (s.IndexOf('T') > -1)
      s = s.Substring(s.IndexOf('T') + 1);
    DateTime? time = new DateTime?();
    foreach (string format in FormatResolver.CANONICAL_TIME_PATTERNS)
    {
      try
      {
        time = new DateTime?(DateTime.ParseExact(s, format, (IFormatProvider) xfaLocale.Locale));
        break;
      }
      catch (Exception ex)
      {
      }
    }
    return time;
  }

  public virtual FormatResolver.NumberParseResult ParseNumber(
    string data,
    string inputParsingPattern,
    XFALocale xfaLocale)
  {
    return this.ParseNumber(data, inputParsingPattern, xfaLocale, true);
  }

  private FormatResolver.NumberParseResult ParseNumber(
    string alternatePattern,
    NumberStyles numberStyles,
    NumberFormatInfo numberFormatInfo,
    string data)
  {
    try
    {
      Decimal? number = new Decimal?(Decimal.Parse(data, numberStyles, (IFormatProvider) numberFormatInfo));
      int? nullable1 = new int?(data.IndexOf(numberFormatInfo.CurrencyDecimalSeparator));
      int? nullable2 = nullable1;
      int? nullable3;
      if ((nullable2.GetValueOrDefault() != -1 ? 0 : (nullable2.HasValue ? 1 : 0)) == 0)
      {
        int length = data.Length;
        int? nullable4 = nullable1;
        int? nullable5 = nullable4.HasValue ? new int?(length - nullable4.GetValueOrDefault()) : new int?();
        nullable3 = nullable5.HasValue ? new int?(nullable5.GetValueOrDefault() - 1) : new int?();
      }
      else
        nullable3 = new int?();
      int? numberOfFractionalDigits = nullable3;
      return new FormatResolver.NumberParseResult(number, numberOfFractionalDigits);
    }
    catch (Exception ex)
    {
      return (FormatResolver.NumberParseResult) null;
    }
  }

  public virtual FormatResolver.NumberParseResult ParseNumber(
    string data,
    string inputParsingPattern,
    XFALocale xfaLocale,
    bool returnZeroIfFailed)
  {
    data = data.Trim();
    if (data.Length == 0)
      return (FormatResolver.NumberParseResult) null;
    if (!string.IsNullOrEmpty(inputParsingPattern))
    {
      string[] strArray = inputParsingPattern.Split('|');
      FormatResolver.NumberParseResult number1 = returnZeroIfFailed ? new FormatResolver.NumberParseResult(new Decimal?(0M), new int?()) : (FormatResolver.NumberParseResult) null;
      bool flag = false;
      foreach (string str1 in strArray)
      {
        if (!str1.StartsWith("zero") && !str1.StartsWith("null"))
        {
          flag = true;
          if (str1 != null && Regex.IsMatch(str1, "^((num)|(date)|(time)|(text))\\.?\\w*\\{.*\\}$"))
          {
            StringBuilder categorisedPattern = new StringBuilder();
            if (this.NormalizeCategorizedPattern(str1, categorisedPattern, xfaLocale).HasValue)
              str1 = categorisedPattern.ToString();
          }
          string str2 = str1.Trim();
          bool isPercent;
          NumberStyles pattern = this.NormalizeNumberParsePattern(str2, out isPercent);
          if (isPercent)
            data = data.Substring(0, data.Length - 1);
          number1 = this.ParseNumber(str2, pattern, xfaLocale.NumberFormatInfo, data);
          if ((pattern & NumberStyles.AllowCurrencySymbol) != NumberStyles.None && data.IndexOf(xfaLocale.NumberFormatInfo.CurrencySymbol) < 0)
            number1 = (FormatResolver.NumberParseResult) null;
          if (number1 == null && (pattern & NumberStyles.AllowCurrencySymbol) != NumberStyles.None)
            number1 = this.ParseNumber(str2, pattern, NumberFormatInfo.InvariantInfo, data);
          if (number1 == null)
          {
            if (returnZeroIfFailed)
            {
              Decimal? number2 = new Decimal?(0M);
              int? numberOfFractionalDigits = new int?();
              FormatResolver.NumberParseResult numberParseResult;
              number1 = numberParseResult = new FormatResolver.NumberParseResult(number2, numberOfFractionalDigits);
            }
            else
              number1 = (FormatResolver.NumberParseResult) null;
          }
          else
            break;
        }
      }
      if (flag)
        return number1;
    }
    return this.ParseNumber(data, returnZeroIfFailed, xfaLocale);
  }

  private FormatResolver.NumberParseResult ParseNumber(
    string data,
    bool returnZeroIfFailed,
    XFALocale xfaLocale)
  {
    CultureInfo provider = xfaLocale.Locale;
    if (Regex.IsMatch(data, "^[\\+|\\-]?[0-9]*\\.*([e|E][\\+|\\-]*[0-9]*)*$") || Regex.IsMatch(data, "^[\\+|\\-]?[0-9]*\\.*[0-9]*([e|E][\\+|\\-]*[0-9]*)*$"))
      provider = CultureInfo.InvariantCulture;
    int? numberOfFractionalDigits = new int?();
    int val2 = data.IndexOf(provider.NumberFormat.NumberDecimalSeparator);
    bool flag = data.ToLower().Contains("e");
    int? nullable1 = new int?(data.IndexOf('-', Math.Max(1, val2)));
    Decimal result;
    Decimal? number = Decimal.TryParse(data, NumberStyles.Any, (IFormatProvider) provider, out result) ? new Decimal?(result) : new Decimal?();
    if (flag)
    {
      int? nullable2 = nullable1;
      if ((nullable2.GetValueOrDefault() >= 0 ? 0 : (nullable2.HasValue ? 1 : 0)) != 0)
      {
        numberOfFractionalDigits = new int?(0);
        goto label_6;
      }
    }
    numberOfFractionalDigits = val2 == -1 ? new int?() : new int?(data.Length - val2 - 1);
label_6:
    if (!number.HasValue && returnZeroIfFailed)
      number = new Decimal?(0M);
    return new FormatResolver.NumberParseResult(number, numberOfFractionalDigits);
  }

  private static bool CanFormatNumberWithPattern(string pattern, Decimal value)
  {
    if (pattern.Contains("%") && !pattern.Contains("."))
    {
      int y = 0;
      for (int index = 0; index < pattern.Length; ++index)
      {
        if (pattern[index] == '#' || pattern[index] == '0')
          ++y;
        else if (pattern[index] == '%')
          break;
      }
      double num = Math.Pow(10.0, (double) y) - 1.0;
      if (value * 100M > (Decimal) num)
        return false;
    }
    return true;
  }

  public enum FormatType
  {
    TEXT,
    FLOAT,
    INTEGER,
    DATE,
    TIME,
    DATE_TIME,
  }

  public class NumberParseResult
  {
    private Decimal? number;
    private int? numberOfFractionalDigits;

    public NumberParseResult(Decimal? number, int? numberOfFractionalDigits)
    {
      this.number = number;
      this.numberOfFractionalDigits = numberOfFractionalDigits;
    }

    public Decimal? GetNumber() => this.number;

    public int? GetNumberOfFractionalDigits() => this.numberOfFractionalDigits;
  }
}
