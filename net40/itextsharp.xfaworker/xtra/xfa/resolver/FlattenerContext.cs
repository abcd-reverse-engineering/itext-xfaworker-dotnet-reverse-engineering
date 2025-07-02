// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.resolver.FlattenerContext
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml.css;
using iTextSharp.tool.xml.xtra.xfa.config;
using iTextSharp.tool.xml.xtra.xfa.element;
using iTextSharp.tool.xml.xtra.xfa.font;
using iTextSharp.tool.xml.xtra.xfa.js;
using iTextSharp.tool.xml.xtra.xfa.pipe;
using iTextSharp.tool.xml.xtra.xfa.positioner;
using iTextSharp.tool.xml.xtra.xfa.tags;
using iTextSharp.tool.xml.xtra.xfa.util;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.util;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.resolver;

public class FlattenerContext : ICustomContext
{
  private const int JS_EVENTS_STACK_SIZE_LIMIT = 100;
  private Stack<FlattenerContext.JsEventsStackEntry> jsEventsStack = new Stack<FlattenerContext.JsEventsStackEntry>();
  private FormatResolver formatResolver;
  private IFontProvider fontProvider;
  private IList<TextDrawer> unresolvedTextDrawers = (IList<TextDrawer>) new List<TextDrawer>();
  private Document document;
  protected int? currentSheetNumber = new int?();
  protected int? currentPageNumber = new int?();
  protected int? currentAbsPageNumber = new int?();
  private int? lastNumberedPage = new int?();
  protected int? pageCount = new int?();
  protected int? sheetCount = new int?();
  private LocaleResolver localeResolver;
  private Positioner domPositioner;
  private Positioner currentNode;
  private XFAFlattener.ViewMode viewMode;
  private bool legacyPlusPrint;
  private Dictionary<string, PdfObject> xfaImages = new Dictionary<string, PdfObject>();
  private FormBuilder formBuilder;
  private IList<string> extraEventList;
  private PdfReader reader;
  private IDictionary<string, PdfDictionary> signatureFields;
  private PageSet pageSet;
  private bool validateLayout;
  private AppConfig appConfig;
  private HostConfig hostConfig;
  private ConfigResolver configResolver;
  private float xfaVersion = 3.3f;
  private IList<JsScript> scriptVariablesToBeEvaluated = (IList<JsScript>) new List<JsScript>();
  private PdfWriter voidPdfWriter = FlattenerContext.CreateDummyPdfWriter();

  public virtual ConfigResolver ConfigResolver
  {
    get => this.configResolver;
    set => this.configResolver = value;
  }

  public virtual float XfaVersion
  {
    get => this.xfaVersion;
    set => this.xfaVersion = value;
  }

  public virtual FormatResolver FormatResolver => this.formatResolver;

  public virtual int? LastNumberedPage => this.lastNumberedPage;

  public virtual void ResetPageNumbers()
  {
    int? nullable = new int?();
    this.currentPageNumber = nullable;
    this.lastNumberedPage = this.currentPageNumber = nullable;
    this.currentSheetNumber = new int?();
    this.currentAbsPageNumber = new int?();
  }

  public virtual int? CurrentPageNumber
  {
    get => this.currentPageNumber;
    set => this.currentPageNumber = value;
  }

  public virtual int? CurrentAbsPageNumber
  {
    get => this.currentAbsPageNumber;
    set => this.currentAbsPageNumber = value;
  }

  public virtual int? CurrentSheetNumber
  {
    get => this.currentSheetNumber;
    set => this.currentSheetNumber = value;
  }

  public virtual void MoveToNextPage(bool numbered)
  {
    if (this.currentPageNumber.HasValue)
    {
      int? currentPageNumber = this.currentPageNumber;
      if ((currentPageNumber.GetValueOrDefault() != 0 ? 1 : (!currentPageNumber.HasValue ? 1 : 0)) != 0)
        this.lastNumberedPage = this.currentPageNumber;
    }
    if (numbered)
    {
      if (!this.lastNumberedPage.HasValue)
      {
        this.currentPageNumber = new int?(1);
      }
      else
      {
        int? lastNumberedPage = this.lastNumberedPage;
        this.currentPageNumber = lastNumberedPage.HasValue ? new int?(lastNumberedPage.GetValueOrDefault() + 1) : new int?();
      }
    }
    else
      this.currentPageNumber = new int?(0);
    if (!this.currentSheetNumber.HasValue)
    {
      this.currentSheetNumber = new int?(1);
    }
    else
    {
      FlattenerContext flattenerContext = this;
      int? currentSheetNumber = flattenerContext.currentSheetNumber;
      flattenerContext.currentSheetNumber = currentSheetNumber.HasValue ? new int?(currentSheetNumber.GetValueOrDefault() + 1) : new int?();
    }
    if (!this.currentAbsPageNumber.HasValue)
    {
      this.currentAbsPageNumber = new int?(1);
    }
    else
    {
      FlattenerContext flattenerContext = this;
      int? currentAbsPageNumber = flattenerContext.currentAbsPageNumber;
      flattenerContext.currentAbsPageNumber = currentAbsPageNumber.HasValue ? new int?(currentAbsPageNumber.GetValueOrDefault() + 1) : new int?();
    }
  }

  public int? PageCount
  {
    get => this.pageCount;
    set => this.pageCount = value;
  }

  public int? SheetCount
  {
    get => this.sheetCount;
    set => this.sheetCount = value;
  }

  public virtual Positioner DomPositioner
  {
    get => this.domPositioner;
    set => this.domPositioner = value;
  }

  public virtual LocaleResolver LocaleResolver
  {
    get => this.localeResolver;
    set => this.localeResolver = value;
  }

  public virtual XFAFlattener.ViewMode ViewMode
  {
    get => this.viewMode;
    set => this.viewMode = value;
  }

  public virtual AppConfig AppConfig
  {
    get => this.appConfig;
    set => this.appConfig = value;
  }

  public virtual HostConfig HostConfig
  {
    get => this.hostConfig;
    set => this.hostConfig = value;
  }

  public virtual Document Document
  {
    get => this.document;
    set => this.document = value;
  }

  public virtual Positioner CurrentNode
  {
    get => this.currentNode;
    set => this.currentNode = value;
  }

  public virtual FormBuilder FormBuilder
  {
    get => this.formBuilder;
    set => this.formBuilder = value;
  }

  public IList<string> ExtraEventList
  {
    get => this.extraEventList;
    set => this.extraEventList = value;
  }

  public virtual PdfReader Reader
  {
    get => this.reader;
    set => this.reader = value;
  }

  public virtual PageSet PageSet
  {
    get => this.pageSet;
    set => this.pageSet = value;
  }

  public virtual bool ValidateLayout
  {
    get => this.validateLayout;
    set => this.validateLayout = value;
  }

  public virtual IFontProvider FontProvider => this.fontProvider;

  public PdfWriter GetVoidPdfWriter() => this.voidPdfWriter;

  public FlattenerContext(IFontProvider fontProvider, Document document, PdfArray xfaImagesArr)
  {
    this.formatResolver = new FormatResolver(this);
    this.fontProvider = fontProvider;
    this.document = document;
    if (xfaImagesArr == null)
      return;
    string key = (string) null;
    foreach (PdfObject pdfObject in xfaImagesArr)
    {
      if (pdfObject.IsString())
        key = pdfObject.ToString();
      else if (pdfObject.IsIndirect())
      {
        try
        {
          this.xfaImages[key] = pdfObject;
        }
        catch (Exception ex)
        {
          Console.Error.Write(ex.StackTrace);
        }
      }
      else
        key = (string) null;
    }
  }

  public virtual Positioner ResolvePositioner(string somExpressions)
  {
    JsTree jsTree = (JsTree) null;
    if (this.currentNode != null)
      jsTree = this.currentNode.ResolveNode(somExpressions);
    if (jsTree == null)
      jsTree = this.domPositioner.SearchNodeDown(somExpressions);
    return !(jsTree is Positioner) ? (Positioner) null : (Positioner) jsTree;
  }

  public virtual Font GetFont(IFormNode node, string encoding)
  {
    return this.CreateFont(this.GetFontNode(node), encoding);
  }

  public virtual IFormNode GetFontNode(IFormNode node)
  {
    IFormNode fontNode = node.RetrieveChild("font");
    if (fontNode == null)
    {
      IFormNode formNode = node.RetrieveParent();
      if (formNode != null)
        fontNode = formNode.RetrieveChild("font");
    }
    if (fontNode != null)
    {
      string somExpressions = fontNode.RetrieveAttribute("use");
      if (somExpressions != null)
      {
        JsNode jsNode = (JsNode) this.domPositioner.SearchNodeDown(somExpressions);
        if (jsNode != null)
          fontNode = (IFormNode) jsNode;
      }
    }
    return fontNode;
  }

  private Font CreateFont(IFormNode fontNode, string encoding)
  {
    Font font = (Font) null;
    if (fontNode != null)
    {
      string str1 = fontNode.RetrieveAttribute("typeface");
      string str2 = fontNode.RetrieveAttribute("size");
      string str3 = fontNode.RetrieveAttribute("weight");
      string str4 = fontNode.RetrieveAttribute("posture");
      if (str1 == null)
        str1 = "Courier";
      if (str2 == null)
        str2 = "10";
      int num = -1;
      if (Util.EqualsIgnoreCase("bold", str3) && Util.EqualsIgnoreCase("italic", str4))
        num = 3;
      else if (Util.EqualsIgnoreCase("italic", str4))
        num = 2;
      else if (Util.EqualsIgnoreCase("bold", str3))
        num = 1;
      BaseColor baseColor = BaseColor.BLACK;
      IFormNode formNode1 = fontNode.RetrieveChild("fill");
      if (formNode1 != null)
      {
        IFormNode formNode2 = formNode1.RetrieveChild("color");
        if (formNode2 != null)
        {
          string xfaColor = formNode2.RetrieveAttribute("value");
          if (xfaColor != null)
            baseColor = XFAUtil.ParseXfaColor(xfaColor);
        }
      }
      font = !encoding.Equals("Identity-H") ? this.fontProvider.GetFont(str1, "Cp1252", false, CssUtils.GetInstance().ParsePxInCmMmPcToPt(str2, "pt"), num, baseColor) : this.fontProvider.GetFont(str1, "Identity-H", false, CssUtils.GetInstance().ParsePxInCmMmPcToPt(str2, "pt"), num, baseColor);
    }
    if (font == null)
      font = (Font) new XFAFont((Font.FontFamily) 0, float.Parse("10", (IFormatProvider) CultureInfo.InvariantCulture), this.fontProvider);
    return font;
  }

  public virtual void AddUnresolvedTextDrawer(TextDrawer textDrawer)
  {
    this.unresolvedTextDrawers.Add(textDrawer);
  }

  public virtual void DrawUnresolvedTextDrawers()
  {
    foreach (TextDrawer unresolvedTextDrawer in (IEnumerable<TextDrawer>) this.unresolvedTextDrawers)
      unresolvedTextDrawer.ResolveEmbeddedElementsAndDraw(true);
  }

  public virtual PdfObject GetImage(string imgRef)
  {
    PdfObject image = (PdfObject) null;
    this.xfaImages.TryGetValue(imgRef, out image);
    return image;
  }

  public virtual bool IsLegacyPlusPrint() => this.legacyPlusPrint;

  public void SetLegacyPlusPrint(bool legacyPlusPrint) => this.legacyPlusPrint = legacyPlusPrint;

  public virtual IDictionary<string, PdfDictionary> GetSignatureFields()
  {
    if (this.signatureFields == null && this.reader != null)
    {
      this.signatureFields = (IDictionary<string, PdfDictionary>) new Dictionary<string, PdfDictionary>();
      AcroFields acroFields = this.reader.AcroFields;
      if (acroFields.Fields != null)
      {
        foreach (string signatureName in acroFields.GetSignatureNames())
        {
          AcroFields.Item obj = (AcroFields.Item) null;
          acroFields.Fields.TryGetValue(signatureName, out obj);
          if (obj != null)
            this.signatureFields[signatureName] = obj.GetWidget(0);
        }
      }
    }
    return this.signatureFields;
  }

  public virtual void AddScriptVariableToBeEvaluated(JsScript script)
  {
    if (this.scriptVariablesToBeEvaluated != null)
      this.scriptVariablesToBeEvaluated.Add(script);
    else
      script.Evaluate();
  }

  public virtual void EvaluateScriptVariables()
  {
    foreach (JsScript jsScript in (IEnumerable<JsScript>) this.scriptVariablesToBeEvaluated)
      jsScript.Evaluate();
    this.scriptVariablesToBeEvaluated = (IList<JsScript>) null;
  }

  public void PushJsEventCallStack(JsContainer eventOwner, string activity, string script)
  {
    FlattenerContext.JsEventsStackEntry eventsStackEntry = new FlattenerContext.JsEventsStackEntry(eventOwner, activity, script);
    bool flag = this.jsEventsStack.Count > 100 && this.jsEventsStack.Contains(eventsStackEntry);
    this.jsEventsStack.Push(eventsStackEntry);
    if (flag)
      throw new InvalidOperationException("JS recursive event calls stack overflow.");
  }

  public void PopJsEventCallStack() => this.jsEventsStack.Pop();

  private static PdfWriter CreateDummyPdfWriter()
  {
    Document document = new Document();
    PdfWriter instance = PdfWriter.GetInstance(document, (Stream) new MemoryStream());
    document.Open();
    document.NewPage();
    return instance;
  }

  private class JsEventsStackEntry
  {
    private readonly JsContainer eventOwner;
    private readonly string activity;
    private readonly string script;

    internal JsEventsStackEntry(JsContainer eventOwner, string activity, string script)
    {
      this.eventOwner = eventOwner;
      this.activity = activity;
      this.script = script;
    }

    public override bool Equals(object o)
    {
      if (this == o)
        return true;
      if (o == null || this.GetType() != o.GetType())
        return false;
      FlattenerContext.JsEventsStackEntry eventsStackEntry = (FlattenerContext.JsEventsStackEntry) o;
      if ((this.eventOwner == null ? (eventsStackEntry.eventOwner == null ? 1 : 0) : (this.eventOwner.Equals((object) eventsStackEntry.eventOwner) ? 1 : 0)) == 0 || (this.activity == null ? (eventsStackEntry.activity == null ? 1 : 0) : (this.activity.Equals(eventsStackEntry.activity) ? 1 : 0)) == 0)
        return false;
      return this.script != null ? this.script.Equals(eventsStackEntry.script) : eventsStackEntry.script == null;
    }

    public override int GetHashCode()
    {
      object[] objArray = new object[3]
      {
        (object) this.eventOwner,
        (object) this.activity,
        (object) this.script
      };
      int hashCode = 1;
      foreach (object obj in objArray)
        hashCode = 31 /*0x1F*/ * hashCode + (obj == null ? 0 : obj.GetHashCode());
      return hashCode;
    }
  }
}
