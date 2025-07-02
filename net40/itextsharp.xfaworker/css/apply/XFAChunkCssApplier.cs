// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.css.apply.XFAChunkCssApplier
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.tool.xml.pipeline.html;
using iTextSharp.tool.xml.xtra.xfa.font;
using System.Collections.Generic;
using System.util;

#nullable disable
namespace iTextSharp.tool.xml.css.apply;

public class XFAChunkCssApplier : ChunkCssApplier
{
  public XFAChunkCssApplier()
  {
  }

  public XFAChunkCssApplier(IFontProvider fontProvider)
    : base(fontProvider)
  {
  }

  public virtual Chunk Apply(
    Chunk c,
    Tag t,
    IMarginMemory mm,
    IPageSizeContainable psc,
    HtmlPipelineContext ctx)
  {
    base.Apply(c, t, mm, psc, ctx);
    string str;
    if (t.CSS != null && t.CSS.TryGetValue("text-decoration", out str) && Util.EqualsIgnoreCase(str, "none"))
    {
      c.SetUnderline(float.NaN, float.NaN);
      c.Attributes["UNDERLINE"] = (object) null;
    }
    return c;
  }

  public virtual Font ApplyFontStyles(Tag t)
  {
    string str1 = (string) null;
    string str2 = "Cp1252";
    float fontSize = new FontSizeTranslator().GetFontSize(t);
    int num = -1;
    BaseColor baseColor = (BaseColor) null;
    foreach (KeyValuePair<string, string> keyValuePair in (IEnumerable<KeyValuePair<string, string>>) t.CSS)
    {
      string key = keyValuePair.Key;
      string str3 = keyValuePair.Value;
      if (Util.EqualsIgnoreCase("font-weight", key))
      {
        if (this.IsBoldValue(str3))
        {
          if (num != -1)
            num |= 1;
          else
            num = 1;
          num &= ~XFAFont.WEIGHT_NORMAL;
        }
        else
        {
          if (num != -1)
            num &= -2;
          else
            num = 0;
          num |= XFAFont.WEIGHT_NORMAL;
        }
      }
      else if (Util.EqualsIgnoreCase("font-style", key))
      {
        if (Util.EqualsIgnoreCase("italic", str3))
        {
          if (num != -1)
            num |= 2;
          else
            num = 2;
          num &= ~XFAFont.STYLE_NORMAL;
        }
        else
        {
          if (num != -1)
            num &= -3;
          else
            num = 0;
          num |= XFAFont.STYLE_NORMAL;
        }
      }
      else if (Util.EqualsIgnoreCase("font-family", key))
      {
        if (str3.Contains(","))
        {
          string str4 = str3;
          char[] chArray = new char[1]{ ',' };
          foreach (string str5 in str4.Split(chArray))
          {
            string str6 = str5.Trim();
            if (!Util.EqualsIgnoreCase(this.fontProvider.GetFont(str5, "Cp1252", false, -1f, -1, (BaseColor) null).Familyname, "unknown"))
            {
              str1 = str6;
              break;
            }
          }
        }
        else
          str1 = str3;
      }
      else if (Util.EqualsIgnoreCase("color", key))
        baseColor = HtmlUtilities.DecodeColor(str3);
    }
    return this.fontProvider.GetFont(str1, str2, true, fontSize, num, baseColor);
  }
}
