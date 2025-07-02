// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.element.XFAFontSelector
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.text;
using iTextSharp.text.error_messages;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.element;

public class XFAFontSelector : FontSelector
{
  protected internal static readonly char[] symbolBytesToUni;
  protected internal static readonly char[] zapfDingbatsToUni;
  protected List<Chunk> chunkList;

  static XFAFontSelector()
  {
    byte[] numArray = new byte[256 /*0x0100*/];
    for (int index = 0; index < 256 /*0x0100*/; ++index)
      numArray[index] = (byte) index;
    XFAFontSelector.symbolBytesToUni = PdfEncodings.ConvertToString(numArray, "Symbol").ToCharArray();
    XFAFontSelector.zapfDingbatsToUni = PdfEncodings.ConvertToString(numArray, "ZapfDingbats").ToCharArray();
  }

  public virtual Phrase Process(string text)
  {
    if (this.GetSize() == 0)
      throw new IndexOutOfRangeException(MessageLocalization.GetComposedMessage("no.font.is.defined", new object[0]));
    char[] charArray = text.ToCharArray();
    int length = charArray.Length;
    StringBuilder sb = new StringBuilder();
    Phrase phrase = new Phrase();
    this.currentFont = (Font) null;
    this.chunkList = new List<Chunk>();
    for (int k = 0; k < length; ++k)
    {
      Chunk chunk = this.ProcessChar(charArray, k, sb, phrase);
      if (chunk != null)
        this.AddChunk(chunk, (ITextElementArray) phrase);
    }
    if (this.currentFont == null)
      this.currentFont = this.GetFont(0);
    Chunk chunk1;
    if (sb.Length > 0)
    {
      chunk1 = new Chunk(sb.ToString(), this.currentFont);
      sb.Length = 0;
    }
    else
      chunk1 = (Chunk) null;
    this.AddChunk(chunk1, (ITextElementArray) phrase);
    return phrase;
  }

  protected virtual Chunk ProcessChar(char[] cc, int k, StringBuilder sb, Phrase ret)
  {
    Chunk chunk1 = (Chunk) null;
    char ch = cc[k];
    if (ch == '\u2029')
      sb.Append('\n');
    Chunk chunk2;
    if (ch == '\t')
    {
      Chunk chunk3 = new Chunk(Chunk.SPACETABBING);
      if (sb.Length > 0)
      {
        chunk1 = new Chunk(sb.ToString(), this.currentFont);
        sb.Length = 0;
      }
      if (this.currentFont != null)
      {
        if (chunk1 != null)
          this.AddChunk(chunk1, (ITextElementArray) ret);
        chunk3.Font = this.currentFont;
        ret.Add((IElement) chunk3);
      }
      else
      {
        if (chunk1 != null)
          this.chunkList.Add(chunk1);
        this.chunkList.Add(chunk3);
      }
      chunk2 = (Chunk) null;
    }
    else
      chunk2 = base.ProcessChar(cc, k, sb);
    return chunk2;
  }

  protected virtual Chunk ProcessChar(char[] cc, int k, StringBuilder sb)
  {
    Chunk chunk = (Chunk) null;
    char ch1 = cc[k];
    switch (ch1)
    {
      case '\n':
      case '\r':
        sb.Append(ch1);
        break;
      default:
        if (Utilities.IsSurrogatePair(cc, k))
        {
          int utf32 = Utilities.ConvertToUtf32(cc, k);
          for (int index = 0; index < this.GetSize(); ++index)
          {
            Font font = this.GetFont(index);
            if (!"Symbol".Equals(font.BaseFont.Encoding) && !"ZapfDingbats".Equals(font.BaseFont.Encoding) && (font.BaseFont.CharExists(utf32) || char.GetUnicodeCategory(char.ConvertFromUtf32(utf32), 0) == UnicodeCategory.Format))
            {
              if (this.currentFont != font)
              {
                if (sb.Length > 0 && this.currentFont != null)
                {
                  chunk = new Chunk(sb.ToString(), this.currentFont);
                  sb.Length = 0;
                }
                this.currentFont = font;
              }
              sb.Append(ch1);
              sb.Append(cc[++k]);
              break;
            }
          }
          break;
        }
        for (int index = 0; index < this.GetSize(); ++index)
        {
          Font font = this.GetFont(index);
          char[] chArray = (char[]) null;
          if ("Symbol".Equals(font.BaseFont.Encoding))
            chArray = XFAFontSelector.symbolBytesToUni;
          else if ("ZapfDingbats".Equals(font.BaseFont.Encoding))
            chArray = XFAFontSelector.zapfDingbatsToUni;
          char ch2 = ch1;
          if (chArray == null || ch2 < 'Ā' && (ch2 = chArray[(int) ch1 & (int) byte.MaxValue]) != char.MinValue)
          {
            bool flag = font.BaseFont.CharExists((int) ch2) || char.GetUnicodeCategory(ch2) == UnicodeCategory.Format;
            char similarFallbackChar;
            if (!flag && (similarFallbackChar = XFAFontSelector.GetSimilarFallbackChar(ch2)) > char.MinValue)
            {
              ch2 = similarFallbackChar;
              flag = true;
            }
            if (flag)
            {
              if (this.currentFont != font)
              {
                if (sb.Length > 0 && this.currentFont != null)
                {
                  chunk = new Chunk(sb.ToString(), this.currentFont);
                  sb.Length = 0;
                }
                this.currentFont = font;
              }
              sb.Append(ch2);
              break;
            }
          }
        }
        break;
    }
    return chunk;
  }

  protected virtual void AddChunk(Chunk chunk, ITextElementArray resultantChunk)
  {
    foreach (Chunk chunk1 in this.chunkList)
    {
      chunk1.Font = this.currentFont;
      resultantChunk.Add((IElement) chunk1);
    }
    this.chunkList.Clear();
    if (chunk == null)
      return;
    resultantChunk.Add((IElement) chunk);
  }

  private static char GetSimilarFallbackChar(char uniC) => uniC == '‐' ? '-' : char.MinValue;
}
