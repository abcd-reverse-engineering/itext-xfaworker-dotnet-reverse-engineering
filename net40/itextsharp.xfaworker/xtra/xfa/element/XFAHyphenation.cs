// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.element.XFAHyphenation
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.text.pdf;
using iTextSharp.text.pdf.hyphenation;
using iTextSharp.tool.xml.xtra.xfa.resolver;
using iTextSharp.tool.xml.xtra.xfa.tags;
using iTextSharp.tool.xml.xtra.xfa.util;
using System.Collections.Generic;
using System.Globalization;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.element;

public class XFAHyphenation : IHyphenationEvent
{
  public const string WORD_CHARACTER_COUNT = "wordCharacterCount";
  public const string REMAIN_CHARACTER_COUNT = "remainCharacterCount";
  public const string PUSH_CHARACTER_COUNT = "pushCharacterCount";
  public const string EXCLUDE_ALL_CAPS = "excludeAllCaps";
  public const string EXCLUDE_INITIAL_CAP = "excludeInitialCap";
  protected Hyphenator hyphenator;
  protected string post;
  protected XFALocale locale;
  protected int wordCharacterCount = 7;
  protected int remainCharacterCount = 3;
  protected int pushCharacterCount = 3;
  protected bool excludeAllCaps;
  protected bool excludeInitialCap;

  public XFAHyphenation()
  {
  }

  public XFAHyphenation(
    XFALocale locale,
    IFormNode hyphenationNode,
    FlattenerContext flattenerContext)
  {
    this.locale = locale;
    string somExpressions = hyphenationNode.RetrieveAttribute("use");
    if (somExpressions != null)
      hyphenationNode = (IFormNode) flattenerContext.DomPositioner.SearchNodeDown(somExpressions);
    if (hyphenationNode != null)
    {
      this.wordCharacterCount = XFAUtil.ParseInt(hyphenationNode.RetrieveAttribute(nameof (wordCharacterCount)), new int?(this.wordCharacterCount)).Value;
      this.remainCharacterCount = XFAUtil.ParseInt(hyphenationNode.RetrieveAttribute(nameof (remainCharacterCount)), new int?(this.remainCharacterCount)).Value;
      this.pushCharacterCount = XFAUtil.ParseInt(hyphenationNode.RetrieveAttribute(nameof (pushCharacterCount)), new int?(this.pushCharacterCount)).Value;
      if (1.Equals((object) XFAUtil.ParseInt(hyphenationNode.RetrieveAttribute(nameof (excludeAllCaps)))))
        this.excludeAllCaps = true;
      if (1.Equals((object) XFAUtil.ParseInt(hyphenationNode.RetrieveAttribute(nameof (excludeInitialCap)))))
        this.excludeInitialCap = true;
    }
    this.hyphenator = new Hyphenator(locale.Locale.TwoLetterISOLanguageName, new RegionInfo(locale.Locale.LCID).TwoLetterISORegionName, this.remainCharacterCount, this.pushCharacterCount);
  }

  private bool IsAllCaps(string str) => str.ToUpper(this.locale.Locale).Equals(str);

  private bool IsInitialCap(string str)
  {
    if (string.IsNullOrEmpty(str))
      return false;
    string str1 = str.Substring(0, 1);
    return str1.ToUpper(this.locale.Locale).Equals(str1) && !this.IsAllCaps(str);
  }

  private bool ContainsDigit(string str)
  {
    for (int index = 0; index < str.Length; ++index)
    {
      if (str[index] >= '0' && str[index] <= '9')
        return true;
    }
    return false;
  }

  public virtual string HyphenSymbol => "-";

  public virtual string GetHyphenatedWordPre(
    string word,
    BaseFont font,
    float fontSize,
    float remainingWidth)
  {
    if (this.ContainsDigit(word) || this.excludeAllCaps && this.IsAllCaps(word) || this.excludeInitialCap && this.IsInitialCap(word))
    {
      this.post = word;
      return "";
    }
    this.post = word;
    string hyphenSymbol = this.HyphenSymbol;
    float widthPoint = font.GetWidthPoint(hyphenSymbol, fontSize);
    if ((double) widthPoint > (double) remainingWidth)
      return "";
    Hyphenation hyphenation = this.hyphenator != null ? this.hyphenator.Hyphenate(word) : this.HyphenateBasedOnSoftHyphens(word);
    if (hyphenation == null)
      return "";
    int length = hyphenation.Length;
    int num1 = 0;
    while (num1 < length && (double) font.GetWidthPoint(hyphenation.GetPreHyphenText(num1), fontSize) + (double) widthPoint <= (double) remainingWidth)
      ++num1;
    int num2 = num1 - 1;
    if (num2 < 0)
      return "";
    this.post = hyphenation.GetPostHyphenText(num2);
    return hyphenation.GetPreHyphenText(num2) + hyphenSymbol;
  }

  public virtual string HyphenatedWordPost => this.post;

  private Hyphenation HyphenateBasedOnSoftHyphens(string word)
  {
    char ch = '\u00AD';
    IList<int?> nullableList = (IList<int?>) new List<int?>();
    int num;
    for (int index = -1; (num = word.IndexOf(ch, index + 1)) > 0; index = num)
      nullableList.Add(new int?(num));
    int index1 = 0;
    int index2 = nullableList.Count - 1;
    while (index1 < nullableList.Count && word.Substring(0, nullableList[index1].Value).Replace(ch.ToString(), "").Length < this.pushCharacterCount)
      ++index1;
    for (; index2 >= 0; --index2)
    {
      string str = word;
      int? nullable = nullableList[index2];
      int startIndex = (nullable.HasValue ? new int?(nullable.GetValueOrDefault() + 1) : new int?()).Value;
      if (str.Substring(startIndex).Replace(ch.ToString(), "").Length >= this.remainCharacterCount)
        break;
    }
    if (index1 > index2)
      return (Hyphenation) null;
    int[] numArray = new int[index2 - index1 + 1];
    for (int index3 = index1; index3 <= index2; ++index3)
      numArray[index3 - index1] = nullableList[index3].Value;
    return new Hyphenation(word, numArray);
  }
}
