// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.font.XFAFontSettings
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using System.Collections.Generic;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.font;

public class XFAFontSettings
{
  private string fontsPath;
  private IDictionary<string, string> fontSubstitutionMap;
  private bool embedExternalFonts;
  private bool useDocumentNotXFAFonts;

  public XFAFontSettings(string fontsPath) => this.fontsPath = fontsPath;

  public XFAFontSettings(string fontsPath, bool embedExternalFonts)
  {
    this.fontsPath = fontsPath;
    this.embedExternalFonts = embedExternalFonts;
  }

  public XFAFontSettings(IDictionary<string, string> fontSubstitutionMap)
  {
    this.fontSubstitutionMap = fontSubstitutionMap;
  }

  public XFAFontSettings(string fontsPath, IDictionary<string, string> fontSubstitutionMap)
  {
    this.fontsPath = fontsPath;
    this.fontSubstitutionMap = fontSubstitutionMap;
  }

  public XFAFontSettings(bool useDocumentNotXFAFonts)
  {
    this.useDocumentNotXFAFonts = useDocumentNotXFAFonts;
  }

  public XFAFontSettings(
    IDictionary<string, string> fontSubstitutionMap,
    bool useDocumentNotXFAFonts)
  {
    this.fontSubstitutionMap = fontSubstitutionMap;
    this.useDocumentNotXFAFonts = useDocumentNotXFAFonts;
  }

  public XFAFontSettings(
    string fontsPath,
    bool embedExternalFonts,
    IDictionary<string, string> fontSubstitutionMap)
  {
    this.fontsPath = fontsPath;
    this.fontSubstitutionMap = fontSubstitutionMap;
    this.embedExternalFonts = embedExternalFonts;
  }

  public XFAFontSettings(
    string fontsPath,
    bool embedExternalFonts,
    IDictionary<string, string> fontSubstitutionMap,
    bool useDocumentNotXFAFonts)
  {
    this.fontsPath = fontsPath;
    this.fontSubstitutionMap = fontSubstitutionMap;
    this.embedExternalFonts = embedExternalFonts;
    this.useDocumentNotXFAFonts = useDocumentNotXFAFonts;
  }

  public virtual string GetSubstitutedFontName(string fontName)
  {
    string substitutedFontName = (string) null;
    if (this.fontSubstitutionMap != null)
      this.fontSubstitutionMap.TryGetValue(fontName, out substitutedFontName);
    return substitutedFontName;
  }

  public virtual string FontsPath
  {
    get => this.fontsPath;
    set => this.fontsPath = value;
  }

  public virtual IDictionary<string, string> FontSubstitutionMap
  {
    get => this.fontSubstitutionMap;
    set => this.fontSubstitutionMap = value;
  }

  public virtual bool EmbedExternalFonts
  {
    get => this.embedExternalFonts;
    set => this.embedExternalFonts = value;
  }

  public virtual bool UseDocumentNotXFAFonts
  {
    get => this.useDocumentNotXFAFonts;
    set => this.useDocumentNotXFAFonts = value;
  }
}
