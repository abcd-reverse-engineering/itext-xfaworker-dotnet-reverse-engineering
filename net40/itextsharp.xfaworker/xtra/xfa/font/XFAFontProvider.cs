// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.font.XFAFontProvider
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml.xtra.xfa.util;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.font;

public class XFAFontProvider : FontFactoryImp
{
  private IDictionary<string, BaseFont> fonts = (IDictionary<string, BaseFont>) new Dictionary<string, BaseFont>();
  private IDictionary<string, BaseFont> unicodeFonts = (IDictionary<string, BaseFont>) new Dictionary<string, BaseFont>();
  private IDictionary<string, string> fontNamesMap = (IDictionary<string, string>) new Dictionary<string, string>();
  private IDictionary<string, PdfDictionary> fontDescriptors = (IDictionary<string, PdfDictionary>) new Dictionary<string, PdfDictionary>();
  private XFAFontSettings fontSettings;

  public XFAFontProvider(PRAcroForm acroForm)
    : this(acroForm, (XFAFontSettings) null)
  {
  }

  public XFAFontProvider(PRAcroForm acroForm, XFAFontSettings fontSettings)
  {
    this.fontSettings = fontSettings;
    if (fontSettings != null && fontSettings.FontsPath != null && fontSettings.FontsPath.Length > 0)
      this.RegisterDirectory(fontSettings.FontsPath, true);
    if (acroForm == null)
      return;
    PdfDictionary asDict = ((PdfDictionary) acroForm).GetAsDict(PdfName.DR)?.GetAsDict(PdfName.FONT);
    if (asDict == null)
      return;
    this.AddFonts(asDict);
  }

  public virtual void AddFonts(PdfDictionary fontsDict)
  {
    foreach (PdfName key1 in fontsDict.Keys)
    {
      PdfObject pdfObject1 = fontsDict.Get(key1);
      if (pdfObject1 is PRIndirectReference)
      {
        List<PdfDictionary> pdfDictionaryList = new List<PdfDictionary>(1);
        PdfDictionary pdfObject2 = (PdfDictionary) PdfReader.GetPdfObject(pdfObject1);
        if (pdfObject2 != null)
        {
          PdfDictionary asDict1 = pdfObject2.GetAsDict(PdfName.FONTDESCRIPTOR);
          if (asDict1 == null)
          {
            PdfArray asArray = pdfObject2.GetAsArray(PdfName.DESCENDANTFONTS);
            if (asArray != null)
            {
              for (int index = 0; index < ((PdfObject) asArray).Length; ++index)
              {
                PdfDictionary asDict2 = asArray.GetAsDict(0).GetAsDict(PdfName.FONTDESCRIPTOR);
                if (asDict2 != null)
                  pdfDictionaryList.Add(asDict2);
              }
            }
          }
          else
            pdfDictionaryList.Add(asDict1);
        }
        BaseFont baseFont1 = BaseFont.CreateFont((PRIndirectReference) pdfObject1);
        string key2 = (string) null;
        if (baseFont1 != null)
        {
          key2 = baseFont1.FamilyFontName[0][3];
          if (this.fontSettings != null && this.fontSettings.FontsPath != null && this.fontSettings.EmbedExternalFonts)
          {
            BaseFont baseFont2 = (BaseFont) null;
            foreach (PdfDictionary pdfDictionary in pdfDictionaryList)
            {
              string fontName = pdfDictionary.GetAsString(PdfName.FONTFAMILY).ToUnicodeString() ?? key2;
              try
              {
                baseFont2 = this.GetBaseFont(fontName, baseFont1.Encoding, true, true);
                if (baseFont2 == null)
                {
                  if (this.fontSettings.FontSubstitutionMap != null)
                  {
                    fontName = this.fontSettings.GetSubstitutedFontName(fontName);
                    if (fontName != null)
                      baseFont2 = this.GetBaseFont(fontName, baseFont1.Encoding, true, true);
                  }
                }
              }
              catch (Exception ex)
              {
              }
              if (baseFont2 != null)
              {
                baseFont1 = baseFont2;
                if (fontName != null && key2 != null)
                  this.fontNamesMap[key2] = fontName;
              }
            }
          }
          this.fonts[key2] = baseFont1;
        }
        foreach (PdfDictionary pdfDictionary in pdfDictionaryList)
        {
          string key3 = pdfDictionary.GetAsString(PdfName.FONTFAMILY)?.ToUnicodeString() ?? key2.Substring(key2.IndexOf('+') + 1).Substring(key2.ToLower().IndexOf("bold") + 1).Substring(key2.ToLower().IndexOf("italic") + 1).Substring(key2.ToLower().IndexOf("normal") + 1);
          this.fontDescriptors[key3] = pdfDictionary;
          PRStream prStream = (PRStream) PdfReader.GetPdfObject(pdfDictionary.Get(PdfName.FONTFILE2)) ?? (PRStream) PdfReader.GetPdfObject(pdfDictionary.Get(PdfName.FONTFILE3));
          if (prStream != null)
          {
            try
            {
              string str = key1.ToString();
              BaseFont font = BaseFont.CreateFont(str.Substring(1, str.Length - 1) + ".ttf", "Identity-H", true, false, PdfReader.GetStreamBytes(prStream), (byte[]) null);
              string key4 = font.FullFontName[0][3];
              this.unicodeFonts[key4] = font;
              this.unicodeFonts[key4.ToLower()] = font;
            }
            catch (Exception ex)
            {
            }
          }
          if (key3 != null && key2 != null)
            this.fontNamesMap[key2] = key3;
        }
      }
    }
  }

  public virtual IList<BaseFont> GetAcroFormFontsList(bool unicodeFonts)
  {
    IList<BaseFont> acroFormFontsList = (IList<BaseFont>) new List<BaseFont>();
    if (unicodeFonts)
    {
      foreach (BaseFont baseFont in (IEnumerable<BaseFont>) this.unicodeFonts.Values)
        acroFormFontsList.Add(baseFont);
    }
    else
    {
      foreach (BaseFont baseFont in (IEnumerable<BaseFont>) this.fonts.Values)
        acroFormFontsList.Add(baseFont);
    }
    return acroFormFontsList;
  }

  public virtual Font GetFont(
    string fontname,
    string encoding,
    bool embedded,
    float size,
    int style,
    BaseColor color)
  {
    XFAFont font = (XFAFont) base.GetFont(fontname, encoding, size, style);
    font.Color = color;
    return (Font) font;
  }

  public virtual Font GetFont(string fontname, string encoding, float size, int style)
  {
    if (fontname == null)
      return (Font) new XFAFont((Font.FontFamily) -1, size, style, (IFontProvider) this);
    string str = this.ResolveFontName(fontname);
    StyleWrapper wrapper = new StyleWrapper().SetStyle(style);
    wrapper.StyleName = this.GetStyleString(new int?(style));
    IDictionary<string, BaseFont> searchIn = this.fonts;
    if (encoding.Equals("Identity-H"))
    {
      searchIn = this.unicodeFonts;
      BaseFont unicodeBaseFont = this.GetUnicodeBaseFont(str, size, style);
      string key = (string) null;
      if (unicodeBaseFont != null)
        key = unicodeBaseFont.FullFontName[0][3];
      if (key != null && !this.unicodeFonts.ContainsKey(key))
        this.unicodeFonts[key] = unicodeBaseFont;
    }
    BaseFont bf = this.GetBaseFont(str, wrapper, searchIn);
    if (bf == null && this.fontSettings != null)
    {
      if (this.fontSettings.FontsPath != null)
      {
        try
        {
          bf = this.GetBaseFont(str, encoding, this.fontSettings.EmbedExternalFonts, true) ?? this.GetBaseFont(this.fontSettings.GetSubstitutedFontName(str), encoding, this.fontSettings.EmbedExternalFonts, true);
        }
        catch (Exception ex)
        {
        }
      }
    }
    return (Font) new XFAFont(bf, size, wrapper.Style, (IFontProvider) this);
  }

  public virtual BaseFont GetBaseFont(
    string typeFaceValue,
    StyleWrapper wrapper,
    IDictionary<string, BaseFont> searchIn,
    bool searchThroughFontFamilies)
  {
    if (searchIn == null)
      searchIn = this.fonts;
    int style1 = wrapper.Style;
    int style2 = wrapper.Style;
    BaseFont baseFont1 = (BaseFont) null;
    bool flag1 = (style1 & 1) == 0 && (style1 & 2) == 0;
    bool flag2 = style1 == -1;
    List<string> matchingFonts = this.GetMatchingFonts(typeFaceValue, searchIn, searchThroughFontFamilies, false);
    matchingFonts.AddRange((IEnumerable<string>) this.GetMatchingFonts(typeFaceValue, searchIn, searchThroughFontFamilies, true));
    foreach (string key in matchingFonts)
    {
      BaseFont baseFont2 = searchIn[key];
      if (flag2 && key.ToLower().Equals(typeFaceValue.ToLower()))
        return baseFont2;
      float fontDescriptor1 = baseFont2.GetFontDescriptor(4, 1000f);
      float fontDescriptor2 = baseFont2.GetFontDescriptor(23, 1000f);
      if ((double) fontDescriptor2 == 0.0)
        fontDescriptor2 = baseFont2.GetFontDescriptor(21, 1000f);
      bool flag3 = (double) fontDescriptor2 != 0.0 ? (double) fontDescriptor2 > 500.0 : key.ToLower().Contains("bold");
      if (!flag3 && baseFont2.Subfamily.Equals("Bold"))
        flag3 = true;
      bool flag4 = (double) fontDescriptor1 != 0.0;
      if ((flag1 || flag2) && !flag3 && !flag4 || !flag1 && !flag2 && flag3 == ((style1 & 1) != 0) && flag4 == ((style1 & 2) != 0))
      {
        if (style1 != -1)
        {
          if (flag3 && (style1 & 1) != 0)
            style1 = style1 & -2 | XFAFont.BOLD_FONT_FAMILY;
          if (flag4 && (style1 & 2) != 0)
            style1 = style1 & -3 | XFAFont.ITALIC_FONT_FAMILY;
          wrapper.SetStyle(style1);
        }
        return baseFont2;
      }
      if (baseFont1 == null)
      {
        baseFont1 = baseFont2;
        style2 = wrapper.Style;
        if (style2 != -1)
        {
          if (flag3 && (style1 & 1) != 0)
          {
            style2 &= -2;
            style2 |= XFAFont.BOLD_FONT_FAMILY;
          }
          if (flag4 && (style1 & 2) != 0)
          {
            style2 &= -3;
            style2 |= XFAFont.ITALIC_FONT_FAMILY;
          }
        }
      }
    }
    wrapper.SetStyle(style2);
    return baseFont1;
  }

  private List<string> GetMatchingFonts(
    string typeFaceValue,
    IDictionary<string, BaseFont> searchIn,
    bool searchThroughFontFamilies,
    bool fontFaceEqualityStrip)
  {
    List<string> matchingFonts = new List<string>();
    foreach (XFAFontProvider.ComparableKey comparableKey in this.GetComparableKeySet((IEnumerable<string>) searchIn.Keys))
    {
      string key = comparableKey.Key;
      bool flag = false;
      if (searchThroughFontFamilies)
      {
        string str;
        if (this.fontNamesMap.TryGetValue(key, out str))
          flag = str != null && str.ToLower().Equals(typeFaceValue.ToLower());
      }
      else
        flag = !fontFaceEqualityStrip ? key.Trim().Equals(typeFaceValue.Trim(), StringComparison.InvariantCultureIgnoreCase) : XFAFontProvider.IsFontFacesEqual(key, typeFaceValue);
      if (flag)
        matchingFonts.Add(key);
    }
    return matchingFonts;
  }

  public virtual BaseFont GetBaseFont(
    string typeFaceValue,
    StyleWrapper wrapper,
    IDictionary<string, BaseFont> searchIn)
  {
    BaseFont baseFont = (BaseFont) null;
    if (wrapper.Style != -1 && (wrapper.Style & 1) != 0 && !typeFaceValue.ToLower(CultureInfo.InvariantCulture).Contains("bold"))
      baseFont = this.GetBaseFont(typeFaceValue + " Bold", wrapper, searchIn, true);
    if (baseFont == null)
      baseFont = this.GetBaseFont(typeFaceValue, wrapper, searchIn, true);
    if (baseFont == null)
      baseFont = this.GetBaseFont(typeFaceValue, wrapper, searchIn, false);
    if (baseFont == null && this.fontSettings != null)
    {
      string substitutedFontName = this.fontSettings.GetSubstitutedFontName(typeFaceValue);
      if (!string.IsNullOrEmpty(substitutedFontName))
        baseFont = this.GetBaseFont(substitutedFontName, wrapper, searchIn, true) ?? this.GetBaseFont(substitutedFontName, wrapper, searchIn, false);
    }
    return baseFont;
  }

  private BaseFont GetUnicodeBaseFont(string fontName, float size, int style)
  {
    string str1 = fontName;
    string styleString = this.GetStyleString(new int?(style));
    if (!string.IsNullOrEmpty(styleString))
      str1 = $"{str1} {styleString}";
    string lower = str1.ToLower();
    BaseFont unicodeBaseFont;
    if (!this.unicodeFonts.TryGetValue(lower, out unicodeBaseFont))
      unicodeBaseFont = this.CreateUnicodeBaseFont(fontName, size, style);
    if (unicodeBaseFont == null && this.fontSettings != null)
    {
      string substitutedFontName = this.fontSettings.GetSubstitutedFontName(fontName);
      if (!string.IsNullOrEmpty(substitutedFontName))
        unicodeBaseFont = this.CreateUnicodeBaseFont(substitutedFontName, size, style);
    }
    PdfDictionary pdfDictionary;
    if (unicodeBaseFont == null && this.fontDescriptors.TryGetValue(fontName, out pdfDictionary) && pdfDictionary != null)
    {
      PdfNumber asNumber = pdfDictionary.GetAsNumber(PdfName.FLAGS);
      int intValue = asNumber == null ? 0 : asNumber.IntValue;
      string str2 = "Liberation";
      string str3 = (intValue & 1) == 0 ? ((intValue & 2) == 0 ? str2 + "Sans" : str2 + "Serif") : str2 + "Mono";
      switch (style)
      {
        case 1:
          str3 += "Bold";
          break;
        case 2:
          str3 += "Italic";
          break;
        case 3:
          str3 += "BoldItalic";
          break;
      }
      string str4 = str3 + ".ttf";
      try
      {
        Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("iTextSharp.tool.xml.xtra.xfa.font." + str4);
        if (manifestResourceStream != null)
          unicodeBaseFont = BaseFont.CreateFont(str4, "Identity-H", true, true, XFAUtil.InputStreamToByteArray(manifestResourceStream), (byte[]) null, true, false);
      }
      catch (IOException ex)
      {
      }
    }
    if (unicodeBaseFont != null && !this.unicodeFonts.ContainsKey(lower))
      this.unicodeFonts[lower] = unicodeBaseFont;
    return unicodeBaseFont;
  }

  private BaseFont CreateUnicodeBaseFont(string fontName, float size, int style)
  {
    BaseFont unicodeBaseFont = (BaseFont) null;
    Font font = (Font) null;
    try
    {
      font = base.GetFont(fontName, "Identity-H", true, size, style, (BaseColor) null);
    }
    catch
    {
    }
    if (font != null)
      unicodeBaseFont = font.BaseFont;
    return unicodeBaseFont;
  }

  private string ResolveFontName(string fontname)
  {
    if (fontname.StartsWith("'") && fontname.EndsWith("'"))
      fontname = fontname.Substring(1, fontname.Length - 2);
    string str;
    return this.fontNamesMap.TryGetValue(fontname, out str) && !string.IsNullOrEmpty(str) ? str : fontname;
  }

  private static string TrimFontName(string fontName)
  {
    fontName = fontName.ToLower();
    string str = "";
    for (int index = 0; index < fontName.Length; ++index)
    {
      char ch = fontName[index];
      switch (ch)
      {
        case ' ':
        case '-':
          goto label_4;
        default:
          str += (string) (object) ch;
          continue;
      }
    }
label_4:
    return str;
  }

  private static bool IsFontFacesEqual(string s1, string s2)
  {
    return XFAFontProvider.TrimFontName(s1).Equals(XFAFontProvider.TrimFontName(s2));
  }

  private string GetStyleString(int? style)
  {
    string styleString = "";
    int? nullable1 = style;
    if ((nullable1.GetValueOrDefault() != -1 ? 1 : (!nullable1.HasValue ? 1 : 0)) != 0)
    {
      int? nullable2 = style;
      int? nullable3 = nullable2.HasValue ? new int?(nullable2.GetValueOrDefault() & 1) : new int?();
      if ((nullable3.GetValueOrDefault() != 0 ? 1 : (!nullable3.HasValue ? 1 : 0)) != 0)
      {
        int? nullable4 = style;
        int? nullable5 = nullable4.HasValue ? new int?(nullable4.GetValueOrDefault() & 2) : new int?();
        if ((nullable5.GetValueOrDefault() != 0 ? 1 : (!nullable5.HasValue ? 1 : 0)) != 0)
        {
          styleString = "bold italic";
          goto label_8;
        }
      }
      int? nullable6 = style;
      int? nullable7 = nullable6.HasValue ? new int?(nullable6.GetValueOrDefault() & 1) : new int?();
      if ((nullable7.GetValueOrDefault() != 0 ? 1 : (!nullable7.HasValue ? 1 : 0)) != 0)
      {
        styleString = "bold";
      }
      else
      {
        int? nullable8 = style;
        int? nullable9 = nullable8.HasValue ? new int?(nullable8.GetValueOrDefault() & 2) : new int?();
        if ((nullable9.GetValueOrDefault() != 0 ? 1 : (!nullable9.HasValue ? 1 : 0)) != 0)
          styleString = "italic";
      }
    }
label_8:
    return styleString;
  }

  private IEnumerable<XFAFontProvider.ComparableKey> GetComparableKeySet(IEnumerable<string> keySet)
  {
    List<XFAFontProvider.ComparableKey> comparableKeySet = new List<XFAFontProvider.ComparableKey>();
    foreach (string key in keySet)
      comparableKeySet.Add(new XFAFontProvider.ComparableKey(key));
    comparableKeySet.Sort();
    return (IEnumerable<XFAFontProvider.ComparableKey>) comparableKeySet;
  }

  private class ComparableKey : IComparable
  {
    private string key;
    private string compareKey;

    public ComparableKey(string key)
    {
      this.key = key;
      this.compareKey = key.ToLower();
    }

    public virtual string Key => this.key;

    public virtual int CompareTo(object o)
    {
      string compareKey1 = this.compareKey;
      if (!(o is XFAFontProvider.ComparableKey))
        return -1;
      string compareKey2 = ((XFAFontProvider.ComparableKey) o).compareKey;
      return this.PrepareKeyForCompaing(compareKey1).CompareTo(this.PrepareKeyForCompaing(compareKey2));
    }

    private string PrepareKeyForCompaing(string lowerCaseKey)
    {
      if ((lowerCaseKey.Contains("bold") || lowerCaseKey.Contains("black")) && (lowerCaseKey.Contains("italic") || lowerCaseKey.Contains("oblique")))
        return "d.bold.italic." + lowerCaseKey;
      if (lowerCaseKey.Contains("bold") || lowerCaseKey.Contains("black"))
        return "c.bold." + lowerCaseKey;
      return lowerCaseKey.Contains("italic") || lowerCaseKey.Contains("oblique") ? "b.italic." + lowerCaseKey : "a.regular." + lowerCaseKey;
    }

    public override string ToString() => this.PrepareKeyForCompaing(this.compareKey);
  }
}
