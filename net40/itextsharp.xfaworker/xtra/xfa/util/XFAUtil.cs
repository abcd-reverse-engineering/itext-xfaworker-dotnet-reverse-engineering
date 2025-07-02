// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.util.XFAUtil
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.text;
using iTextSharp.tool.xml.css;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.util;

public static class XFAUtil
{
  public static readonly float DEVIATION = 0.1f;
  public static readonly int MATCH_ALL_NODES = -1;
  public static readonly CssUtils cssUtils = CssUtils.GetInstance();

  public static string GetAttributeValue(
    string attributeName,
    IDictionary<string, string> attributes)
  {
    string str = (string) null;
    return attributes != null && attributes.TryGetValue(attributeName, out str) ? str : (string) null;
  }

  public static float? ParseFloat(string s)
  {
    float? nullable = new float?();
    if (s != null)
    {
      try
      {
        nullable = new float?(float.Parse(s, (IFormatProvider) CultureInfo.InvariantCulture));
      }
      catch (FormatException ex)
      {
        nullable = new float?(XFAUtil.cssUtils.ParsePxInCmMmPcToPt(s));
      }
    }
    return nullable;
  }

  public static float? ParsePxInCmMmPcToPt(string length)
  {
    if (length == null)
      return new float?();
    try
    {
      return new float?(XFAUtil.cssUtils.ParsePxInCmMmPcToPt(length, "in"));
    }
    catch (FormatException ex)
    {
      return new float?();
    }
  }

  public static float? ParsePercent(string s)
  {
    if (!s.EndsWith("%"))
      return new float?();
    float? percent = new float?();
    try
    {
      percent = new float?(float.Parse(s.Substring(0, s.Length - 1), (IFormatProvider) CultureInfo.InvariantCulture));
    }
    catch (FormatException ex)
    {
    }
    return percent;
  }

  public static float? parseFloatToPt(string s)
  {
    float? floatToPt = new float?();
    if (s != null)
    {
      try
      {
        floatToPt = new float?(float.Parse(s));
      }
      catch (FormatException ex)
      {
        floatToPt = new float?(XFAUtil.cssUtils.ParsePxInCmMmPcToPt(s, "pt"));
      }
    }
    return floatToPt;
  }

  public static int? ParseInt(string s)
  {
    int? nullable = new int?();
    if (s != null)
    {
      try
      {
        nullable = new int?(int.Parse(s));
      }
      catch (FormatException ex)
      {
        nullable = new int?();
      }
    }
    return nullable;
  }

  public static int? ParseInt(string s, int? defaultValue)
  {
    int? nullable = new int?();
    if (s != null)
    {
      try
      {
        nullable = new int?(int.Parse(s));
      }
      catch (FormatException ex)
      {
        nullable = new int?();
      }
    }
    return nullable ?? defaultValue;
  }

  public static float ReverseX(float originX, float? x)
  {
    return !x.HasValue ? originX : originX + x.Value;
  }

  public static float ReverseY(float originY, float? y, float? heigth)
  {
    if (!heigth.HasValue && y.HasValue)
      return originY - y.Value;
    if (!y.HasValue && heigth.HasValue)
      return originY - heigth.Value;
    return !y.HasValue && !heigth.HasValue ? originY : originY - y.Value - heigth.Value;
  }

  public static XFARectangle ExtractRectangleFromAttributes(IDictionary<string, string> attributes)
  {
    XFARectangle rectangleFromAttributes;
    try
    {
      string str;
      float? llx = XFAUtil.ParsePxInCmMmPcToPt(attributes.TryGetValue("x", out str) ? str : (string) null);
      if (!llx.HasValue)
        llx = new float?(0.0f);
      float? ury = XFAUtil.ParsePxInCmMmPcToPt(attributes.TryGetValue("y", out str) ? str : (string) null);
      if (!ury.HasValue)
        ury = new float?(0.0f);
      float? pxInCmMmPcToPt1 = XFAUtil.ParsePxInCmMmPcToPt(attributes.TryGetValue("w", out str) ? str : (string) null);
      float? pxInCmMmPcToPt2 = XFAUtil.ParsePxInCmMmPcToPt(attributes.TryGetValue("h", out str) ? str : (string) null);
      rectangleFromAttributes = new XFARectangle(llx, ury, pxInCmMmPcToPt1, pxInCmMmPcToPt2);
      if (!pxInCmMmPcToPt1.HasValue)
      {
        float? pxInCmMmPcToPt3 = XFAUtil.ParsePxInCmMmPcToPt(attributes.TryGetValue("minW", out str) ? str : (string) null);
        rectangleFromAttributes.MinW = pxInCmMmPcToPt3;
        float? pxInCmMmPcToPt4 = XFAUtil.ParsePxInCmMmPcToPt(attributes.TryGetValue("maxW", out str) ? str : (string) null);
        rectangleFromAttributes.MaxW = pxInCmMmPcToPt4;
      }
      if (!pxInCmMmPcToPt2.HasValue)
      {
        float? pxInCmMmPcToPt5 = XFAUtil.ParsePxInCmMmPcToPt(attributes.TryGetValue("minH", out str) ? str : (string) null);
        rectangleFromAttributes.MinH = pxInCmMmPcToPt5;
        float? pxInCmMmPcToPt6 = XFAUtil.ParsePxInCmMmPcToPt(attributes.TryGetValue("maxH", out str) ? str : (string) null);
        rectangleFromAttributes.MaxH = pxInCmMmPcToPt6;
      }
    }
    catch (Exception ex)
    {
      throw;
    }
    return rectangleFromAttributes;
  }

  public static void SetMinAsDefault(XFARectangle contentArea)
  {
    float? height = contentArea.Height;
    float? minH = contentArea.MinH;
    if (!height.HasValue && minH.HasValue)
      contentArea.Height = minH;
    float? width = contentArea.Width;
    float? minW = contentArea.MinW;
    if (width.HasValue || !minW.HasValue)
      return;
    contentArea.Width = minW;
  }

  public static string CheckSomExpression(string refValue)
  {
    string str = (string) null;
    if (!string.IsNullOrEmpty(refValue))
    {
      string[] strArray = Regex.Split(refValue, "\\.");
      str = strArray[strArray.Length - 1];
    }
    return str;
  }

  public static List<float?> ParseNumArray(string source)
  {
    List<float?> numbers = new List<float?>();
    string str = source + " ";
    if (source.Length > 0)
    {
      string s = "";
      for (int index = 0; index < str.Length; ++index)
      {
        char ch = str.ToCharArray()[index];
        if (ch != ' ')
        {
          s += (string) (object) ch;
        }
        else
        {
          XFAUtil.AddNumberToList(s, numbers);
          s = "";
        }
      }
    }
    return numbers;
  }

  public static BaseColor ParseXfaColor(string xfaColor)
  {
    BaseColor xfaColor1 = (BaseColor) null;
    if (xfaColor != null)
    {
      List<float?> numArray = XFAUtil.ParseNumArray(xfaColor.Replace(",", " "));
      if (numArray.Count > 2)
        xfaColor1 = new BaseColor(Convert.ToInt32((object) numArray[0]) & (int) byte.MaxValue, Convert.ToInt32((object) numArray[1]) & (int) byte.MaxValue, Convert.ToInt32((object) numArray[2]) & (int) byte.MaxValue);
    }
    return xfaColor1;
  }

  public static bool Lt(float a, float b) => (double) b - (double) a > (double) XFAUtil.DEVIATION;

  public static bool Gt(float a, float b) => (double) a - (double) b > (double) XFAUtil.DEVIATION;

  public static bool Lte(float a, float b)
  {
    float num = b - a;
    return (double) num > (double) XFAUtil.DEVIATION || (double) num > -(double) XFAUtil.DEVIATION;
  }

  public static bool Gte(float a, float b)
  {
    float num = a - b;
    return (double) num > (double) XFAUtil.DEVIATION || (double) num > -(double) XFAUtil.DEVIATION;
  }

  public static bool Equal(float a, float b)
  {
    return (double) Math.Abs(a - b) < (double) XFAUtil.DEVIATION;
  }

  private static void AddNumberToList(string s, List<float?> numbers)
  {
    s = s.Replace(" ", "");
    if (s.Length <= 0)
      return;
    float pxInCmMmPcToPt = CssUtils.GetInstance().ParsePxInCmMmPcToPt(s, "pt");
    numbers.Add(new float?(pxInCmMmPcToPt));
  }

  public static byte[] InputStreamToByteArray(Stream stream)
  {
    using (MemoryStream memoryStream = new MemoryStream(stream.CanSeek ? (int) stream.Length : 0))
    {
      byte[] buffer = new byte[4096 /*0x1000*/];
      int count;
      do
      {
        count = stream.Read(buffer, 0, buffer.Length);
        memoryStream.Write(buffer, 0, count);
      }
      while (count != 0);
      return memoryStream.ToArray();
    }
  }

  public static XFAUtil.NameIndexPair SplitNameIndexPair(string nameIndexPair)
  {
    int index = 0;
    if (Regex.IsMatch(nameIndexPair, "^.+\\[(\\d+|\\*)\\]$"))
    {
      string s = Regex.Replace(Regex.Replace(nameIndexPair, ".+\\[", ""), "\\]$", "");
      nameIndexPair = Regex.Replace(nameIndexPair, "\\[(\\d+|\\*)\\]$", "");
      if (!s.Equals("*"))
      {
        try
        {
          index = int.Parse(s);
        }
        catch (FormatException ex)
        {
        }
      }
      else
        index = XFAUtil.MATCH_ALL_NODES;
    }
    return new XFAUtil.NameIndexPair(nameIndexPair, index);
  }

  public class NameIndexPair
  {
    public string name;
    public int index;

    public NameIndexPair(string name, int index)
    {
      this.name = name;
      this.index = index;
    }
  }
}
