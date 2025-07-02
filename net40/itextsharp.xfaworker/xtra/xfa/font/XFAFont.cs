// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.font.XFAFont
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.text;
using iTextSharp.text.pdf;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.font;

public class XFAFont : Font
{
  public static int BOLD_FONT_FAMILY = 16 /*0x10*/;
  public static int ITALIC_FONT_FAMILY = 32 /*0x20*/;
  public static int STYLE_NORMAL = 64 /*0x40*/;
  public static int WEIGHT_NORMAL = 128 /*0x80*/;
  public static int BOLD_ITALIC_FONT_FAMILY = XFAFont.BOLD_FONT_FAMILY | XFAFont.ITALIC_FONT_FAMILY;
  protected IFontProvider fontProvider;

  public XFAFont(BaseFont bf, float size, int style, BaseColor color, IFontProvider fontProvider)
    : base(bf, size, style, color)
  {
    this.fontProvider = fontProvider;
  }

  public XFAFont(
    Font.FontFamily family,
    float size,
    int style,
    BaseColor color,
    IFontProvider fontProvider)
    : base(family, size, style, color)
  {
    this.fontProvider = fontProvider;
  }

  public XFAFont(BaseFont bf, float size, int style, IFontProvider fontProvider)
    : base(bf, size, style)
  {
    this.fontProvider = fontProvider;
  }

  public XFAFont(Font.FontFamily family, float size, int style, IFontProvider fontProvider)
    : base(family, size, style)
  {
    this.fontProvider = fontProvider;
  }

  public XFAFont(Font.FontFamily family, float size, IFontProvider fontProvider)
    : base(family, size)
  {
    this.fontProvider = fontProvider;
  }

  public virtual Font Difference(Font font) => this.Difference(font, (string) null);

  public virtual Font Difference(Font font, string encoding)
  {
    if (font == null)
      return (Font) this;
    float size = font.Size;
    if ((double) size == -1.0)
      size = this.Size;
    int style = -1;
    int num1 = this.Style;
    int num2 = font.Style;
    if (num1 != -1 || num2 != -1)
    {
      if (num2 == 0)
      {
        style = 0;
      }
      else
      {
        if (num1 == -1)
        {
          num1 = 0;
        }
        else
        {
          if ((num1 & XFAFont.BOLD_FONT_FAMILY) != 0)
            num1 = num1 & ~XFAFont.BOLD_FONT_FAMILY | 1;
          if ((num1 & XFAFont.ITALIC_FONT_FAMILY) != 0)
            num1 = num1 & ~XFAFont.ITALIC_FONT_FAMILY | 2;
        }
        if (num2 == -1)
        {
          num2 = 0;
        }
        else
        {
          if ((num2 & XFAFont.BOLD_FONT_FAMILY) != 0)
            num2 = num2 & ~XFAFont.BOLD_FONT_FAMILY | 1;
          if ((num2 & XFAFont.ITALIC_FONT_FAMILY) != 0)
            num2 = num2 & ~XFAFont.ITALIC_FONT_FAMILY | 2;
        }
        if ((num2 & XFAFont.WEIGHT_NORMAL) != 0)
          num1 &= -2;
        if ((num2 & XFAFont.STYLE_NORMAL) != 0)
          num1 &= -3;
        style = num1 | num2;
      }
    }
    bool flag = false;
    if (style == -1)
    {
      flag = true;
      style = num2 = this.GetStyle(font.BaseFont);
    }
    BaseColor color = font.Color ?? this.Color;
    Font font1 = font.BaseFont == null ? (font.Family == -1 ? (this.BaseFont == null ? (Font) new XFAFont(this.Family, size, style, color, this.fontProvider) : (style != num1 || encoding != null && !encoding.Equals(this.BaseFont.Encoding) ? this.fontProvider.GetFont(this.Familyname, encoding == null ? this.BaseFont.Encoding : encoding, false, size, style, color) : (Font) new XFAFont(this.BaseFont, size, this.Style, color, this.fontProvider))) : (style != num2 ? this.fontProvider.GetFont(font.Familyname, encoding, false, size, style, color) : (Font) new XFAFont(font.Family, size, font.Style, color, this.fontProvider))) : (style != num2 || encoding != null && !encoding.Equals(font.BaseFont.Encoding) ? this.fontProvider.GetFont(font.Familyname, encoding == null ? font.BaseFont.Encoding : encoding, false, size, style, color) : (Font) new XFAFont(font.BaseFont, size, font.Style, color, this.fontProvider));
    if (flag)
      font1.SetStyle(-1);
    return font1;
  }

  private int GetStyle(BaseFont font)
  {
    if (font == null)
      return -1;
    string lower = font.FullFontName[0][3].ToLower();
    int style = 0;
    if (lower.Contains("bold"))
      style |= 1;
    if (lower.Contains("oblique") || lower.Contains("italic"))
      style |= 2;
    return style;
  }

  public virtual string ToString()
  {
    return this.BaseFont != null ? this.BaseFont.PostscriptFontName : $"XFAFont{{fontProvider={(object) this.fontProvider}{(object) '}'}";
  }
}
