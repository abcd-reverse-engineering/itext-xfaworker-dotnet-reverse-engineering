// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.XFAFlattener
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iText.License;
using iTextSharp.awt.geom;
using iTextSharp.license;
using iTextSharp.text;
using iTextSharp.text.log;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml.css.apply;
using iTextSharp.tool.xml.exceptions;
using iTextSharp.tool.xml.html;
using iTextSharp.tool.xml.parser;
using iTextSharp.tool.xml.pipeline.ctx;
using iTextSharp.tool.xml.xtra.xfa.checksum;
using iTextSharp.tool.xml.xtra.xfa.config;
using iTextSharp.tool.xml.xtra.xfa.element;
using iTextSharp.tool.xml.xtra.xfa.font;
using iTextSharp.tool.xml.xtra.xfa.js;
using iTextSharp.tool.xml.xtra.xfa.pipe;
using iTextSharp.tool.xml.xtra.xfa.positioner;
using iTextSharp.tool.xml.xtra.xfa.resolver;
using iTextSharp.tool.xml.xtra.xfa.tags;
using iTextSharp.tool.xml.xtra.xfa.util;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.util;
using System.util.collections;
using System.Xml;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa;

public class XFAFlattener : CssAppliersAware
{
  private static readonly ILogger logger = LoggerFactory.GetLogger(typeof (XFAFlattener));
  private static int checkEveryN = 20;
  private static string productName = "xfaworker";
  private static int productMajor = 5;
  private static int productMinor = 5;
  private static readonly HashSet2<string> entries = new HashSet2<string>((IEnumerable<string>) new string[9]
  {
    "preamble",
    "config",
    "template",
    "connectionSets",
    "localeSet",
    "xmpmeta",
    "postamble",
    "datasets",
    "form"
  });
  private XFAFontSettings fontSettings;
  private XFAFontProvider fontProvider;
  private XFATemplateTag formDom;
  private XFATemplateTag templateDom;
  private CssAppliers cssAppliers;
  private LocaleResolver localeResolver;
  private CultureInfo defaultLocale = new CultureInfo("en-US");
  private IHrefResolver hrefResolver = (IHrefResolver) new iTextSharp.tool.xml.xtra.xfa.resolver.HrefResolver((string) null);
  private int counter;
  private LicenseKeyProduct product;
  private SubFormPositioner formDomPositioner;
  private PdfWriter writer;
  private Document document;
  private PdfReader reader;
  private PdfArray xfaImagesArr;
  private FlattenerContext flattenerContext;
  private XFAFlattener.ViewMode viewMode;
  private JsXfa jsXfa;
  private PageSet pageSet;
  private IList<string> extraEventList;
  private bool addStaticContent;
  private XFAPageAnnotationsCopier pageAnnotationsCopier;
  private AppConfig appConfig;
  private HostConfig hostConfig;
  private bool applyFormState;
  private bool flatteningIsCompleted;

  public XFAFlattener(Document document, PdfWriter writer)
  {
    this.document = document;
    this.writer = writer;
    this.product = new LicenseKeyProduct(XFAFlattener.productName, XFAFlattener.productMajor, XFAFlattener.productMinor, new LicenseKeyProductFeature[0]);
  }

  public XFAFlattener(Document document, PdfWriter writer, string fontsPath)
    : this(document, writer)
  {
    this.fontSettings = new XFAFontSettings(fontsPath);
  }

  public XFAFlattener(
    Document document,
    PdfWriter writer,
    string fontsPath,
    IDictionary<string, string> fontsMap)
    : this(document, writer, fontsPath)
  {
    this.fontSettings = new XFAFontSettings(fontsPath, false, fontsMap);
  }

  public XFAFlattener(Document document, PdfWriter writer, XFAFontSettings fontSettings)
    : this(document, writer)
  {
    this.fontSettings = fontSettings;
  }

  public virtual void Flatten(PdfReader reader) => this.Flatten(reader, false);

  public virtual void Flatten(PdfReader reader, bool extractXdpStreamsConcurrently)
  {
    this.Flatten(reader, extractXdpStreamsConcurrently, true);
  }

  public virtual void Flatten(
    PdfReader reader,
    bool extractXdpStreamsConcurrently,
    bool closeFlattenedDocument)
  {
    this.Flatten(reader, extractXdpStreamsConcurrently, closeFlattenedDocument, (DataPipeline) null);
  }

  protected void Flatten(
    PdfReader reader,
    bool extractXdpStreamsConcurrently,
    bool closeFlattenedDocument,
    DataPipeline dataPipeline)
  {
    try
    {
      if (this.flatteningIsCompleted)
        throw new XFAFlattenerUnexpectedUsageException("The flatten method can only be called once in a single instance of the XFAFlattener class.");
      PdfObject directObject = ((PdfDictionary) this.InitFlattener(reader)).GetDirectObject(PdfName.XFA);
      PdfDictionary info = this.writer.Info;
      PdfDictionary asDict = reader.Trailer.GetAsDict(PdfName.INFO);
      PdfName[] pdfNameArray = new PdfName[4]
      {
        PdfName.TITLE,
        PdfName.AUTHOR,
        PdfName.SUBJECT,
        PdfName.KEYWORDS
      };
      foreach (PdfName pdfName in pdfNameArray)
      {
        if (!info.Contains(pdfName))
        {
          PdfObject pdfObject = asDict.Get(pdfName);
          if (pdfObject != null)
            info.Put(pdfName, pdfObject);
        }
      }
      IDictionary<string, MemoryStream> map = (IDictionary<string, MemoryStream>) new Dictionary<string, MemoryStream>();
      string normalizedTemplate = (string) null;
      string normalizedDatasets = (string) null;
      if (directObject is PdfArray)
      {
        if (extractXdpStreamsConcurrently)
        {
          int num = 0;
          IList<XFAFlattener.ExtractStreamRunner> extractStreamRunnerList = (IList<XFAFlattener.ExtractStreamRunner>) new List<XFAFlattener.ExtractStreamRunner>();
          SettableLatch sl = new SettableLatch();
          foreach (PdfObject pdfObject in (PdfArray) directObject)
          {
            if (pdfObject is PdfString)
            {
              string key = pdfObject.ToString();
              if (XFAFlattener.entries.Contains(key))
                extractStreamRunnerList.Add(new XFAFlattener.ExtractStreamRunner(key, num + 1, reader, (PdfArray) directObject, sl, map));
            }
            ++num;
          }
          sl.Set(extractStreamRunnerList.Count);
          foreach (XFAFlattener.ExtractStreamRunner extractStreamRunner in (IEnumerable<XFAFlattener.ExtractStreamRunner>) extractStreamRunnerList)
            new Thread(new ThreadStart(extractStreamRunner.Run)).Start();
          sl.Await();
        }
        else
        {
          int num = 0;
          PdfArray pdfArray = (PdfArray) directObject;
          foreach (PdfObject pdfObject in pdfArray)
          {
            if (pdfObject is PdfString)
            {
              string key = pdfObject.ToString();
              if (XFAFlattener.entries.Contains(key))
              {
                PdfObject pdfObject2 = pdfArray[num + 1];
                try
                {
                  map[key] = XFAFlattener.GetStreamContents(reader, pdfObject2);
                }
                catch (IOException ex)
                {
                  Console.Out.WriteLine((object) ex);
                }
              }
            }
            ++num;
          }
        }
        if (this.localeResolver == null && map.ContainsKey("localeSet"))
        {
          LocalePipeline pipeline = new LocalePipeline((IPipeline) null, this.defaultLocale);
          new XMLParser(false, (IXMLParserListener) new XFAWorker((IPipeline) pipeline)).Parse((Stream) map["localeSet"], true);
          try
          {
            this.localeResolver = (LocaleResolver) XFAWorker.GetWorkerContext().Get(pipeline.GetContextKey());
          }
          catch (NoCustomContextException ex)
          {
            throw new RuntimeWorkerException((Exception) ex);
          }
          map.Remove("localeSet");
        }
        if (this.templateDom == null && map.ContainsKey("template"))
        {
          TemplateBuilderPipeline pipeline = new TemplateBuilderPipeline(this.cssAppliers);
          XMLParser xmlParser = new XMLParser(false, (IXMLParserListener) new XFAWorker((IPipeline) pipeline));
          byte[] buffer = map["template"].GetBuffer();
          xmlParser.Parse((Stream) map["template"], true);
          try
          {
            this.templateDom = ((ObjectContext<XFAFlattenerData>) XFAWorker.GetWorkerContext().Get(pipeline.GetContextKey())).Get().TemplateDom;
          }
          catch (NoCustomContextException ex)
          {
            throw new RuntimeWorkerException((Exception) ex);
          }
          normalizedTemplate = XFANormalizer.GetNormalizedXml(new MemoryStream(buffer));
          map.Remove("template");
          this.flattenerContext.SetLegacyPlusPrint(pipeline.IsLegacyPlusPrint());
          this.flattenerContext.XfaVersion = pipeline.GetXfaVersion();
        }
        if (this.formDom == null && map.ContainsKey("form"))
        {
          FormBuilderPipeline pipeline = new FormBuilderPipeline(this.cssAppliers);
          new XMLParser(false, (IXMLParserListener) new XFAWorker((IPipeline) pipeline)).Parse((Stream) map["form"], true);
          try
          {
            this.formDom = ((ObjectContext<XFAFlattenerData>) XFAWorker.GetWorkerContext().Get(pipeline.GetContextKey())).Get().TemplateDom;
          }
          catch (NoCustomContextException ex)
          {
            throw new RuntimeWorkerException((Exception) ex);
          }
          map.Remove("form");
        }
        if (dataPipeline == null && map.ContainsKey("datasets"))
        {
          dataPipeline = new DataPipeline((IPipeline) null, this.cssAppliers, (JsNode) this.jsXfa);
          XMLParser xmlParser = new XMLParser(false, (IXMLParserListener) new XFAWorker((IPipeline) dataPipeline));
          byte[] buffer = map["datasets"].GetBuffer();
          xmlParser.Parse((Stream) map["datasets"], true);
          normalizedDatasets = XFANormalizer.GetNormalizedXml(new MemoryStream(buffer));
          map.Remove("datasets");
        }
        if (map.ContainsKey("config"))
        {
          ConfigPipeline pipeline = new ConfigPipeline((IPipeline) null);
          new XMLParser(false, (IXMLParserListener) new XFAWorker((IPipeline) pipeline)).Parse((Stream) map["config"], true);
          try
          {
            this.flattenerContext.ConfigResolver = (ConfigResolver) XFAWorker.GetWorkerContext().Get(pipeline.GetContextKey());
          }
          catch (NoCustomContextException ex)
          {
            throw new RuntimeWorkerException((Exception) ex);
          }
          map.Remove("config");
        }
      }
      else if (directObject is PdfStream)
      {
        DataPipeline dataPipeline1 = this.ProcessXDP((Stream) new MemoryStream(PdfReader.GetStreamBytes((PRStream) directObject)));
        if (dataPipeline == null)
          dataPipeline = dataPipeline1;
      }
      string str;
      if (this.templateDom.Attributes.TryGetValue("baseProfile", out str) && Util.EqualsIgnoreCase("interactiveForms", str))
        this.addStaticContent = true;
      if (this.formDom != null && normalizedTemplate != null && normalizedDatasets != null && this.formDom.RetrieveAttribute("checksum") != null)
        this.applyFormState = XFAChecksumCalculator.Calculate(normalizedTemplate, normalizedDatasets).Equals(this.formDom.RetrieveAttribute("checksum"));
      this.Flatten(dataPipeline, closeFlattenedDocument);
    }
    finally
    {
      this.flatteningIsCompleted = true;
      XFAWorker.CloseWorkerContext();
    }
  }

  public virtual void Flatten(Stream xdpStream) => this.Flatten(xdpStream, true);

  public virtual void Flatten(Stream xdpStream, bool closeFlattenedDocument)
  {
    try
    {
      if (this.flatteningIsCompleted)
        throw new XFAFlattenerUnexpectedUsageException("The flatten method can only be called once in a single instance of the XFAFlattener class.");
      this.InitFlattener((PdfReader) null);
      DataPipeline dataPipeline = this.ProcessXDP(xdpStream);
      if (this.flattenerContext.Reader != null)
      {
        this.reader = this.flattenerContext.Reader;
        this.Flatten(this.reader, false, closeFlattenedDocument, dataPipeline);
      }
      else
        this.Flatten(dataPipeline, closeFlattenedDocument);
    }
    finally
    {
      this.flatteningIsCompleted = true;
      XFAWorker.CloseWorkerContext();
    }
  }

  public virtual void Flatten(XmlDocument xdpData) => this.Flatten(xdpData, true);

  public virtual void Flatten(XmlDocument xdpData, bool closeFlattenedDocument)
  {
    try
    {
      if (this.flatteningIsCompleted)
        throw new XFAFlattenerUnexpectedUsageException("The flatten method can only be called once in a single instance of the XFAFlattener class.");
      this.InitFlattener((PdfReader) null);
      byte[] buffer;
      try
      {
        buffer = XfaForm.SerializeDoc((XmlNode) xdpData);
      }
      catch (Exception ex)
      {
        return;
      }
      this.Flatten(this.ProcessXDP((Stream) new MemoryStream(buffer)), closeFlattenedDocument);
    }
    finally
    {
      this.flatteningIsCompleted = true;
      XFAWorker.CloseWorkerContext();
    }
  }

  public virtual void SetCssAppliers(CssAppliers cssAppliers) => this.cssAppliers = cssAppliers;

  public virtual CssAppliers GetCssAppliers() => this.cssAppliers;

  public virtual XFAFlattener.ViewMode GetViewMode() => this.viewMode;

  public virtual void SetViewMode(XFAFlattener.ViewMode viewMode) => this.viewMode = viewMode;

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

  public virtual CultureInfo GetDefaultLocale() => this.defaultLocale;

  public virtual void SetDefaultLocale(CultureInfo defaultLocale)
  {
    this.defaultLocale = defaultLocale;
  }

  public IList<string> GetExtraEventList() => this.extraEventList;

  public void SetExtraEventList(IList<string> extraEventList)
  {
    this.extraEventList = extraEventList;
  }

  public IHrefResolver HrefResolver
  {
    get => this.hrefResolver;
    set => this.hrefResolver = value;
  }

  [Obsolete]
  public XFAFlattener()
  {
    this.product = new LicenseKeyProduct(XFAFlattener.productName, XFAFlattener.productMajor, XFAFlattener.productMinor, new LicenseKeyProductFeature[0]);
  }

  [Obsolete]
  public XFAFlattener(string fontsPath)
    : this()
  {
    this.fontSettings = new XFAFontSettings(fontsPath);
  }

  [Obsolete]
  public XFAFlattener(string fontsPath, Dictionary<string, string> fontsMap)
    : this(fontsPath)
  {
    this.fontSettings = new XFAFontSettings((IDictionary<string, string>) fontsMap);
  }

  [Obsolete]
  public XFAFlattener(CssAppliers cssAppliers)
  {
    this.cssAppliers = cssAppliers;
    this.product = new LicenseKeyProduct(XFAFlattener.productName, XFAFlattener.productMajor, XFAFlattener.productMinor, new LicenseKeyProductFeature[0]);
  }

  [Obsolete]
  public XFAFlattener(CssAppliers cssAppliers, string fontsPath)
    : this(cssAppliers)
  {
    this.fontSettings = new XFAFontSettings(fontsPath);
  }

  [Obsolete]
  public XFAFlattener(
    CssAppliers cssAppliers,
    string fontsPath,
    Dictionary<string, string> fontsMap)
    : this(cssAppliers, fontsPath)
  {
    this.fontSettings = new XFAFontSettings((IDictionary<string, string>) fontsMap);
  }

  [Obsolete]
  [MethodImpl(MethodImplOptions.Synchronized)]
  public virtual void Flatten(
    PdfReader reader,
    Document document,
    PdfWriter writer,
    bool extractXdpStreamsConcurrently)
  {
    this.document = document;
    this.writer = writer;
    this.Flatten(reader, extractXdpStreamsConcurrently);
  }

  [Obsolete]
  [MethodImpl(MethodImplOptions.Synchronized)]
  public virtual void Flatten(PdfReader reader, Document document, PdfWriter writer)
  {
    this.Flatten(reader, document, writer, true);
  }

  [Obsolete]
  [MethodImpl(MethodImplOptions.Synchronized)]
  public virtual void Flatten(Stream xdpStream, Document document, PdfWriter writer)
  {
    this.document = document;
    this.writer = writer;
    this.Flatten(xdpStream);
  }

  [Obsolete]
  [MethodImpl(MethodImplOptions.Synchronized)]
  public virtual void Flatten(XmlDocument xdpData, Document document, PdfWriter writer)
  {
    this.document = document;
    this.writer = writer;
    this.Flatten(xdpData);
  }

  [Obsolete]
  public virtual void Dispose()
  {
  }

  private PRAcroForm InitFlattener(PdfReader reader)
  {
    if (this.counter == 0)
      LicenseKey.ScheduledCheck((LicenseKeyProduct) this.product);
    else if (this.counter == XFAFlattener.checkEveryN)
      this.counter = -1;
    ++this.counter;
    PRAcroForm acroForm = (PRAcroForm) null;
    if (reader != null)
    {
      acroForm = reader.AcroForm;
      if (acroForm == null)
        throw new NoAcroFormFound();
      PdfDictionary asDict1 = reader.Catalog.GetAsDict(PdfName.NAMES);
      if (asDict1 != null)
      {
        PdfDictionary asDict2 = asDict1.GetAsDict(new PdfName("XFAImages"));
        if (asDict2 != null)
          this.xfaImagesArr = asDict2.GetAsArray(PdfName.NAMES);
      }
    }
    this.fontProvider = new XFAFontProvider(acroForm, this.fontSettings);
    if (this.fontSettings != null && this.fontSettings.UseDocumentNotXFAFonts)
    {
      for (int index = 1; index <= reader.NumberOfPages; ++index)
      {
        PdfDictionary pageResources = reader.GetPageResources(index);
        if (pageResources != null)
        {
          PdfDictionary asDict = pageResources.GetAsDict(PdfName.FONT);
          if (asDict != null)
            this.fontProvider.AddFonts(asDict);
        }
      }
    }
    this.cssAppliers = (CssAppliers) new XFACssAppliersImpl();
    this.cssAppliers.ChunkCssAplier = (ChunkCssApplier) new XFAChunkCssApplier((IFontProvider) this.fontProvider);
    this.flattenerContext = new FlattenerContext((IFontProvider) this.fontProvider, this.document, this.xfaImagesArr);
    this.reader = reader;
    this.flattenerContext.Reader = reader;
    if (this.hostConfig == null)
      this.hostConfig = new HostConfig();
    this.flattenerContext.HostConfig = this.hostConfig;
    if (this.appConfig == null)
      this.appConfig = new AppConfig();
    this.flattenerContext.AppConfig = this.appConfig;
    this.jsXfa = new JsXfa(this.flattenerContext);
    this.applyFormState = false;
    return acroForm;
  }

  protected virtual DataPipeline ProcessXDP(Stream bin)
  {
    TemplateBuilderPipeline templateBuilderPipeline = new TemplateBuilderPipeline(this.cssAppliers, this.hrefResolver);
    FormBuilderPipeline formBuilderPipeline = new FormBuilderPipeline(this.cssAppliers);
    DataPipeline dataPipeline = new DataPipeline((IPipeline) null, this.cssAppliers, (JsNode) this.jsXfa);
    LocalePipeline localePipeline = new LocalePipeline((IPipeline) null, this.defaultLocale);
    XdpPipeline pipeline = new XdpPipeline(localePipeline, templateBuilderPipeline, formBuilderPipeline, dataPipeline, new PdfPipeline((IPipeline) null, this.flattenerContext));
    new XMLParser(false, (IXMLParserListener) new XFAWorker((IPipeline) pipeline)).Parse(bin, true);
    try
    {
      if (pipeline.WasLocale)
        this.localeResolver = (LocaleResolver) XFAWorker.GetWorkerContext().Get(localePipeline.GetContextKey());
      if (pipeline.WasTemplate)
      {
        this.templateDom = ((ObjectContext<XFAFlattenerData>) XFAWorker.GetWorkerContext().Get(templateBuilderPipeline.GetContextKey())).Get().TemplateDom;
        this.flattenerContext.SetLegacyPlusPrint(templateBuilderPipeline.IsLegacyPlusPrint());
        this.flattenerContext.XfaVersion = templateBuilderPipeline.GetXfaVersion();
      }
      if (pipeline.WasForm)
        this.formDom = ((ObjectContext<XFAFlattenerData>) XFAWorker.GetWorkerContext().Get(formBuilderPipeline.GetContextKey())).Get().TemplateDom;
    }
    catch (NoCustomContextException ex)
    {
      throw new RuntimeWorkerException((Exception) ex);
    }
    return dataPipeline;
  }

  protected virtual void Flatten(DataPipeline dataPipeline, bool closeFlattenDocument)
  {
    if (dataPipeline == null)
      dataPipeline = new DataPipeline((IPipeline) null, this.cssAppliers, (JsNode) this.jsXfa);
    if (dataPipeline.DataDom == null)
    {
      dataPipeline.DataDom = new DataTag(Guid.NewGuid().ToString());
      JsDataModel jsDataModel = new JsDataModel("datasets", (JsNode) this.jsXfa);
      dataPipeline.SetDatasetsNodeDom(jsDataModel);
      DataTag tag = new DataTag("data");
      JsDataGroup child = new JsDataGroup(tag, (JsNode) jsDataModel);
      tag.Node = (JsNode) child;
      jsDataModel.AddChild((JsTree) child);
      dataPipeline.DataNodeDom = (JsNode) child;
    }
    this.jsXfa.AddChild((JsTree) dataPipeline.DataNodeDom);
    this.jsXfa.DefineProperty("$data", (object) dataPipeline.DataNodeDom);
    this.jsXfa.AddChild((JsTree) dataPipeline.DatasetsNodeDom);
    if (this.localeResolver == null)
    {
      this.localeResolver = new LocaleResolver();
      this.localeResolver.SetDefaultLocale(this.defaultLocale);
    }
    this.flattenerContext.LocaleResolver = this.localeResolver;
    JsForm jsForm = new JsForm(this.jsXfa);
    FormBuilder formBuilder = new FormBuilder((XFATemplateTag) this.templateDom.GetChild("subform", ""), dataPipeline.DataDom, (JsNode) jsForm, this.flattenerContext);
    this.flattenerContext.FormBuilder = formBuilder;
    this.formDomPositioner = (SubFormPositioner) formBuilder.FormDom;
    jsForm.AddChild((JsTree) this.formDomPositioner);
    this.jsXfa.AddChild((JsTree) jsForm);
    this.flattenerContext.EvaluateScriptVariables();
    if (!"template".Equals(this.formDomPositioner.RetrieveName()))
    {
      JsTemplate child = new JsTemplate((JsNode) this.jsXfa);
      child.DefineProperty(this.formDomPositioner.RetrieveName(), (object) this.formDomPositioner);
      this.jsXfa.AddChild((JsTree) child);
    }
    this.pageSet = (PageSet) this.formDomPositioner.SearchNodeByClassName("pageSet");
    try
    {
      if (this.pageSet != null)
      {
        this.flattenerContext.PageSet = this.pageSet;
        this.flattenerContext.DomPositioner = (Positioner) this.formDomPositioner;
        if (this.writer.IsTagged())
        {
          string str1 = (string) this.formDomPositioner.GetOwnProperty("locale") ?? "en_US";
          this.document.AddLanguage(str1);
          this.document.SetAccessibleAttribute(PdfName.LANG, (PdfObject) new PdfString(str1));
          PdfDictionary info = this.writer.Info;
          if (!info.Contains(PdfName.TITLE))
          {
            string str2 = this.formDomPositioner.Name ?? "untitled";
            info.Put(PdfName.TITLE, (PdfObject) new PdfString(str2));
          }
          this.writer.ViewerPreferences = 131072 /*0x020000*/;
        }
        this.writer.CreateXmpMetadata();
        this.flattenerContext.ViewMode = this.viewMode;
        this.flattenerContext.ExtraEventList = this.extraEventList;
        this.PlaceFormDom();
        this.PositionElements();
        while (this.addStaticContent && this.writer.CurrentPageNumber <= this.reader.NumberOfPages)
          this.ProcessBreak();
      }
      if (!closeFlattenDocument)
        return;
      this.document.Close();
    }
    catch (DocumentException ex)
    {
      Console.Out.WriteLine(ex.ToString());
    }
    catch (IOException ex)
    {
      Console.Out.WriteLine(ex.ToString());
    }
  }

  private static MemoryStream GetStreamContents(PdfReader reader, PdfObject pdfObject2)
  {
    byte[] buffer = (byte[]) null;
    if (pdfObject2.IsIndirect())
      buffer = XFAFlattener.GetStreamFromIndirectReference(reader, (PdfIndirectReference) pdfObject2);
    else if (pdfObject2 is PRStream)
      buffer = PdfReader.GetStreamBytes((PRStream) pdfObject2);
    else if (pdfObject2.IsStream())
      throw new Exception("PdfStream not found");
    return new MemoryStream(buffer, 0, buffer.Length, false, true);
  }

  private static byte[] GetStreamFromIndirectReference(PdfReader reader, PdfIndirectReference ir)
  {
    int number = ir.Number;
    return PdfReader.GetStreamBytes((PRStream) reader.GetPdfObject(number));
  }

  private void UpdatePageNumber(Positioner pageArea)
  {
    this.flattenerContext.MoveToNextPage(pageArea == null || !"0".Equals(pageArea.RetrieveAttribute("numbered")));
  }

  private void PositionElements()
  {
    if (this.formDomPositioner == null)
      return;
    List<Positioner> pageAreas = new List<Positioner>();
    if (this.pageSet.CurrentPageArea == null)
      return;
    this.UpdatePageNumber((Positioner) this.pageSet.CurrentPageArea);
    XFARectangle parentBoundingBox = (XFARectangle) this.pageSet.CurrentPageArea.CurrentContentArea.Rect.Clone();
    float ytr1 = parentBoundingBox.Ury.Value;
    this.formDomPositioner.ApplyTranslation(0.0f, ytr1);
    AffineTransform affineTransform = (AffineTransform) this.formDomPositioner.Transformation.Clone();
    this.formDomPositioner.ApplyTranslation(parentBoundingBox.Llx.Value, 0.0f);
    parentBoundingBox.Ury = new float?(parentBoundingBox.Ury.Value - ytr1);
    Positioner positioner1 = this.formDomPositioner.Position(this.writer.DirectContent, parentBoundingBox, this.pageSet.CurrentPageArea, true, 0.0f);
    BreakConditions breakConditions1 = (BreakConditions) null;
    BreakConditions breakConditions2 = (BreakConditions) null;
    for (; positioner1 != null; positioner1 = this.formDomPositioner.Position(this.writer.DirectContent, parentBoundingBox, this.pageSet.CurrentPageArea, true, 0.0f))
    {
      breakConditions2 = positioner1 is SubFormPositioner ? ((SubFormPositioner) positioner1).FirstBreakAfter : (BreakConditions) null;
      if (positioner1.OverflowConditions != null)
      {
        TrailerLeaderElement currentTrailer = positioner1.OverflowConditions.GetCurrentTrailer();
        if (currentTrailer != null)
        {
          Positioner trailerParent = positioner1.OverflowConditions.TrailerParent;
          XFARectangle absoluteBbox1 = trailerParent.GetAbsoluteBbox();
          XFARectangle absoluteBbox2 = positioner1.GetAbsoluteBbox();
          Positioner positioner2 = trailerParent;
          while (positioner2.Data == null && positioner2.Parent != null)
            positioner2 = positioner2.Parent;
          DataTag data = positioner2.Data;
          Positioner positioner3 = (Positioner) this.flattenerContext.FormBuilder.BuildSubformInstance(currentTrailer.FormTag, (JsNode) null, data, true);
          positioner3.Place(absoluteBbox1.Llx, absoluteBbox2.Ury);
          if (positioner3.IsVisible() || positioner3.IsInvisible())
            positioner3.Position(this.writer.DirectContent, (XFARectangle) null, (PageArea) null, false, 0.0f);
          positioner1.OverflowConditions.GetNextTrailer();
        }
      }
      float ytr2 = ytr1 + parentBoundingBox.Ury.Value - this.pageSet.CurrentPageArea.CurrentContentArea.Rect.Ury.Value;
      BreakConditions breakConditions3 = breakConditions1;
      breakConditions1 = positioner1.BreakConditions;
      positioner1.BreakConditions = (BreakConditions) null;
      ContentArea contentArea = this.pageSet.NextContentArea(breakConditions1);
      if (contentArea == null || contentArea.PageArea != this.pageSet.CurrentPageArea || this.pageSet.CurrentPageArea.CurrentContentArea == contentArea)
      {
        bool flag1 = false;
        bool flag2 = false;
        if (!this.writer.PageEmpty || breakConditions1 != null && breakConditions1.Evaluate() && this.writer.PageNumber > 1 && breakConditions1.Target != null && breakConditions3 != null && !BreakConditions.TargetsEqual(breakConditions3, breakConditions1) || breakConditions1 != null && breakConditions1.Evaluate() && this.writer.PageNumber == 1 && "before".Equals(breakConditions1.SubType) && (breakConditions1.Target == null || "pageArea".Equals(breakConditions1.Type) && breakConditions1.StartNew && this.pageSet.CurrentPageArea != null && !this.pageSet.CurrentPageArea.RetrieveName().Equals(breakConditions1.Target)) || breakConditions1 != null && breakConditions1.Evaluate() && breakConditions3 != null && breakConditions3.Evaluate() && "before".Equals(breakConditions1.SubType) && "after".Equals(breakConditions3.SubType) && !BreakConditions.TargetsEqual(breakConditions3, breakConditions1) || breakConditions1 != null && breakConditions1.Evaluate() && breakConditions3 != null && breakConditions3.Evaluate() && "before".Equals(breakConditions1.SubType) && "before".Equals(breakConditions3.SubType) && breakConditions1.Positioner == breakConditions3.Positioner)
          this.ProcessNewPageArea(pageAreas);
        else if (this.writer.PageNumber == 1)
        {
          this.flattenerContext.ResetPageNumbers();
          flag1 = true;
        }
        else
        {
          flag2 = true;
          if (breakConditions1 != null && breakConditions3 != null && pageAreas.Contains((Positioner) this.pageSet.CurrentPageArea))
            this.pageSet.GetNewInstanceOfCurrentPageArea();
        }
        PageArea currentPageArea = this.pageSet.CurrentPageArea;
        PageArea second;
        if (flag2)
        {
          this.pageSet.NextPageArea(breakConditions3, contentArea, this.writer.CurrentPageNumber);
          second = this.pageSet.GetNewInstanceOfCurrentPageArea();
        }
        else
          second = this.pageSet.NextPageArea(breakConditions1, contentArea, this.writer.CurrentPageNumber + 1);
        bool flag3 = breakConditions1 != null && breakConditions1.Target != null && this.pageSet.IsDuplexPagination() && (breakConditions1.StartNew || PageArea.ArePartsOfDifferentPageSets(currentPageArea, second)) && ("odd".Equals(second.RetrieveAttribute("oddOrEven")) && this.writer.CurrentPageNumber % 2 == 1 || "even".Equals(second.RetrieveAttribute("oddOrEven")) && this.writer.CurrentPageNumber % 2 == 0);
        bool flag4 = breakConditions1 != null && breakConditions1.Evaluate() && ("pageOdd".Equals(breakConditions1.Type) && this.writer.CurrentPageNumber % 2 == 1 || "pageEven".Equals(breakConditions1.Type) && this.writer.CurrentPageNumber % 2 == 0);
        if ((flag3 || flag4) && this.pageSet.IsDuplexPagination())
        {
          PageArea pageArea = this.pageSet.NextBlankPageArea(currentPageArea, this.writer.CurrentPageNumber + 1);
          if (pageArea != null)
          {
            this.pageSet.SetCurrentPageArea(pageArea);
            this.ProcessBreak();
            this.UpdatePageNumber((Positioner) pageArea);
            this.ProcessNewPageArea(pageAreas);
          }
          --second.Occured;
          this.pageSet.NextPageArea(breakConditions1, contentArea, this.writer.CurrentPageNumber + 1);
        }
        int pageNumber = this.writer.PageNumber;
        this.ProcessBreak();
        if (this.writer.PageNumber > pageNumber || flag1)
          this.UpdatePageNumber((Positioner) this.pageSet.CurrentPageArea);
      }
      else
        this.pageSet.CurrentPageArea.SetCurrentContentArea(contentArea);
      if (this.pageSet.CurrentPageArea != null)
      {
        parentBoundingBox = (XFARectangle) this.pageSet.CurrentPageArea.CurrentContentArea.Rect.Clone();
        if (positioner1.OverflowConditions != null)
        {
          TrailerLeaderElement currentLeader = positioner1.OverflowConditions.GetCurrentLeader();
          if (currentLeader != null)
          {
            Positioner leaderParent = positioner1.OverflowConditions.LeaderParent;
            if (leaderParent.PositionState == PositionResult.State.CONTENT_PART || LayoutManager.positionLayout.Equals(leaderParent.GetLayout()))
            {
              float num1;
              if (positioner1.Parent != null)
              {
                XFARectangle absoluteBbox = positioner1.Parent.GetAbsoluteBbox(true);
                positioner1.Parent.ApplyMargins(absoluteBbox);
                num1 = absoluteBbox.Llx.Value;
              }
              else
                num1 = leaderParent.GetAbsoluteBbox(true).Llx.Value;
              Positioner positioner4 = leaderParent;
              while (positioner4.Data == null && positioner4.Parent != null)
                positioner4 = positioner4.Parent;
              DataTag data = positioner4.Data;
              Positioner extraRow = (Positioner) null;
              try
              {
                extraRow = (Positioner) this.flattenerContext.FormBuilder.BuildSubformInstance(currentLeader.FormTag, (JsNode) null, data, true);
              }
              catch (Exception ex)
              {
                XFAFlattener.logger.Warn("Building leader positioner went wrong. Please check your form for irregularities.");
              }
              if (extraRow != null)
              {
                if (LayoutManager.tableLayout.Equals(leaderParent.GetLayout()))
                  new TableLayoutManager(leaderParent).PreprocessHorizontalCellLayout(extraRow);
                extraRow.DefineProperty("y", (object) null);
                extraRow.DefineProperty("x", (object) null);
                Positioner positioner5 = extraRow;
                float? llx = parentBoundingBox.Llx;
                float num2 = num1;
                float? x = llx.HasValue ? new float?(llx.GetValueOrDefault() + num2) : new float?();
                float? ury = parentBoundingBox.Ury;
                float num3 = ytr2;
                float? y = ury.HasValue ? new float?(ury.GetValueOrDefault() + num3) : new float?();
                positioner5.Place(x, y);
                extraRow.Parent = leaderParent;
                extraRow.ExecEvent("initialize", (string) null);
                extraRow.ExecCalculate();
                extraRow.ExecEvent("ready", "$form");
                extraRow.ExecEvent("ready", "$layout");
                if (extraRow.IsVisible() || extraRow.IsInvisible())
                  extraRow.Position(this.writer.DirectContent, (XFARectangle) null, (PageArea) null, false, 0.0f);
                if (!extraRow.IsHidden() && !extraRow.IsInactive())
                  ytr2 -= extraRow.GetBBox().Height.Value;
                positioner1.OverflowConditions.GetNextLeader();
              }
            }
          }
        }
        if (!positioner1.IsHidden() && !positioner1.IsInactive())
          ytr2 += parentBoundingBox.Ury.Value - (positioner1.GetAbsoluteBbox(true).Ury.Value + ytr1);
        parentBoundingBox.Ury = new float?(parentBoundingBox.Ury.Value - ytr1 - ytr2);
        this.formDomPositioner.Transformation = affineTransform;
        this.formDomPositioner.ApplyTranslation(0.0f, ytr2);
        affineTransform = (AffineTransform) this.formDomPositioner.Transformation.Clone();
        this.formDomPositioner.ApplyTranslation(parentBoundingBox.Llx.Value, 0.0f);
        ytr1 += ytr2;
      }
      else
        break;
    }
    this.NormalizePageCount();
    int? pageCount1 = this.flattenerContext.PageCount;
    if ((pageCount1.GetValueOrDefault() <= 1 ? 0 : (pageCount1.HasValue ? 1 : 0)) != 0 && this.writer.PageEmpty && breakConditions1 == null && this.flattenerContext.CurrentPageNumber.HasValue)
    {
      FlattenerContext flattenerContext1 = this.flattenerContext;
      int? pageCount2 = this.flattenerContext.PageCount;
      int? nullable1 = pageCount2.HasValue ? new int?(pageCount2.GetValueOrDefault() - 1) : new int?();
      flattenerContext1.PageCount = nullable1;
      FlattenerContext flattenerContext2 = this.flattenerContext;
      int? sheetCount = this.flattenerContext.SheetCount;
      int? nullable2 = sheetCount.HasValue ? new int?(sheetCount.GetValueOrDefault() - 1) : new int?();
      flattenerContext2.SheetCount = nullable2;
    }
    else
    {
      if (this.writer.PageEmpty)
        this.writer.DirectContent.InternalBuffer.Append("%blank page");
      if (this.pageSet.CurrentPageArea != null)
        this.ProcessNewPageArea(pageAreas);
    }
    if (this.pageSet.IsDuplexPagination() && this.writer.PageNumber % 2 != 0)
    {
      PageArea lastPagePosition = this.pageSet.FindPageAreaWithLastPagePosition();
      bool flag = false;
      if (lastPagePosition != null)
      {
        this.pageSet.SetCurrentPageArea(lastPagePosition);
        flag = true;
      }
      else if (breakConditions2 != null)
      {
        this.pageSet.NextPageArea(breakConditions2, (ContentArea) null, this.writer.CurrentPageNumber + 1);
        flag = true;
      }
      if (flag)
      {
        this.UpdatePageNumber((Positioner) this.pageSet.CurrentPageArea);
        this.NormalizePageCount();
        this.ProcessBreak();
        this.ProcessNewPageArea(pageAreas);
      }
    }
    this.flattenerContext.ResetPageNumbers();
    this.FlushPageAreas(pageAreas);
    this.flattenerContext.CurrentPageNumber = this.flattenerContext.PageCount;
    this.flattenerContext.CurrentSheetNumber = new int?(this.writer.PageNumber);
    this.flattenerContext.CurrentAbsPageNumber = new int?(this.writer.PageNumber);
    this.flattenerContext.DrawUnresolvedTextDrawers();
    this.formDomPositioner = (SubFormPositioner) null;
  }

  private void NormalizePageCount()
  {
    this.flattenerContext.PageCount = new int?(!this.flattenerContext.CurrentPageNumber.HasValue || this.flattenerContext.CurrentPageNumber.Value == 0 ? (!this.flattenerContext.LastNumberedPage.HasValue ? this.writer.PageNumber : this.flattenerContext.LastNumberedPage.Value) : this.flattenerContext.CurrentPageNumber.Value);
    this.flattenerContext.SheetCount = new int?(this.writer.PageNumber);
  }

  private void FlushPageAreas(List<Positioner> pageAreas)
  {
    for (int index = 0; index < pageAreas.Count; ++index)
    {
      Positioner pageArea = pageAreas[index];
      this.UpdatePageNumber(pageArea);
      pageArea.ExecEvent("initialize", (string) null);
      pageArea.ExecCalculate();
      pageArea.ExecEvent("ready", (string) null);
      pageArea.ExecEvent("docReady", (string) null);
      pageArea.ExecValidate();
      if (this.extraEventList != null)
      {
        foreach (string extraEvent in (IEnumerable<string>) this.extraEventList)
          pageArea.ExecEvent(extraEvent, (string) null);
      }
      pageArea.Place();
      pageArea.Position(pageArea.Canvas, (XFARectangle) null, (PageArea) null, false, 0.0f);
    }
    pageAreas.Clear();
  }

  private void ProcessNewPageArea(List<Positioner> pageAreas)
  {
    SubFormPositioner subFormPositioner = this.EnsurePageAreaNotRepeated(pageAreas);
    PdfTemplate template = this.writer.DirectContentUnder.CreateTemplate(this.pageSet.CurrentPageArea.CurrentContentArea != null ? this.pageSet.CurrentPageArea.CurrentContentArea.Rect.Width.Value : this.writer.PageSize.Width, this.pageSet.CurrentPageArea.CurrentContentArea != null ? this.pageSet.CurrentPageArea.CurrentContentArea.Rect.Height.Value : this.writer.PageSize.Height);
    template.BoundingBox = this.writer.PageSize;
    this.writer.DirectContentUnder.AddTemplate(template, 0.0f, 0.0f, true);
    subFormPositioner.Canvas = (PdfContentByte) template;
    subFormPositioner.StartPageNumber = this.flattenerContext.CurrentPageNumber;
    subFormPositioner.StartAbsPageNumber = this.flattenerContext.CurrentAbsPageNumber;
    pageAreas.Add((Positioner) subFormPositioner);
    this.AddWatermark();
  }

  private SubFormPositioner EnsurePageAreaNotRepeated(List<Positioner> pageAreas)
  {
    SubFormPositioner subFormPositioner = (SubFormPositioner) this.pageSet.CurrentPageArea;
    while (pageAreas.Contains((Positioner) subFormPositioner))
      subFormPositioner = (SubFormPositioner) this.pageSet.GetNewInstanceOfCurrentPageArea();
    return subFormPositioner;
  }

  private void ProcessBreak()
  {
    if (!this.document.IsOpen())
      this.document.Open();
    if (this.pageSet.CurrentPageArea == null)
      return;
    this.document.SetPageSize(this.pageSet.CurrentPageArea.PageSize);
    this.document.NewPage();
    if (this.addStaticContent && this.writer.CurrentPageNumber <= this.reader.NumberOfPages)
      this.AddStaticPageContent();
    this.pageSet.GetInstanceManagerByTemplate((Tag) this.pageSet.CurrentPageArea.Template)?.DecCount();
    Positioner positioner = (Positioner) this.flattenerContext.FormBuilder.BuildSubForm(this.pageSet.CurrentPageArea.Template, this.pageSet.CurrentPageArea.Data, (JsNode) this.pageSet);
    positioner.StartPageNumber = this.flattenerContext.CurrentPageNumber;
    positioner.StartAbsPageNumber = this.flattenerContext.CurrentAbsPageNumber;
    positioner.ExecEvent("initialize", (string) null);
    positioner.ExecEvent("ready", (string) null);
    positioner.ExecEvent("docReady", (string) null);
    positioner.ExecValidate();
    if (this.extraEventList == null)
      return;
    foreach (string extraEvent in (IEnumerable<string>) this.extraEventList)
      positioner.ExecEvent(extraEvent, (string) null);
  }

  private void AddStaticPageContent()
  {
    PdfImportedPage importedPage = this.writer.GetImportedPage(this.reader, this.writer.CurrentPageNumber);
    if (this.pageAnnotationsCopier == null)
      this.pageAnnotationsCopier = new XFAPageAnnotationsCopier(this.writer, true);
    int num = importedPage.Rotation % 360;
    if (num != 0)
    {
      Point2D point2D1 = (Point2D) new Point((double) ((PdfTemplate) importedPage).BoundingBox.Left, (double) ((PdfTemplate) importedPage).BoundingBox.Bottom);
      Point2D point2D2 = (Point2D) new Point((double) ((PdfTemplate) importedPage).BoundingBox.Right, (double) ((PdfTemplate) importedPage).BoundingBox.Top);
      AffineTransform rotateInstance = AffineTransform.GetRotateInstance(Math.PI / 180.0 * (double) -num);
      Point2D point2D3 = rotateInstance.Transform(point2D1, (Point2D) null);
      Point2D point2D4 = rotateInstance.Transform(point2D2, (Point2D) null);
      Rectangle rectangle = new Rectangle((float) point2D3.GetX(), (float) point2D3.GetY(), (float) point2D4.GetX(), (float) point2D4.GetY());
      rectangle.Normalize();
      AffineTransform affineTransform = new AffineTransform(1f, 0.0f, 0.0f, 1f, -rectangle.Left, -rectangle.Bottom);
      affineTransform.Concatenate(rotateInstance);
      double[] numArray = new double[6];
      affineTransform.GetMatrix(numArray);
      ((PdfTemplate) importedPage).SetMatrix((float) numArray[0], (float) numArray[1], (float) numArray[2], (float) numArray[3], (float) numArray[4], (float) numArray[5]);
    }
    this.writer.DirectContent.AddTemplate((PdfTemplate) importedPage, 0.0f, 0.0f);
    this.pageAnnotationsCopier.CopySupportedAnnotations(this.reader, this.writer.CurrentPageNumber);
  }

  private void AddWatermark()
  {
    if (!this.IsTrialLicense())
      return;
    string str = "TRIAL VERSION";
    PdfContentByte directContent = this.writer.DirectContent;
    directContent.SaveState();
    Rectangle pageSize = this.writer.PageSize;
    float num1 = (float) Math.Sqrt((double) pageSize.Width * (double) pageSize.Width + (double) pageSize.Height * (double) pageSize.Height);
    float num2 = num1 / 10f;
    float d = pageSize.Height / pageSize.Width;
    directContent.ConcatCTM(AffineTransform.GetRotateInstance(Math.Atan((double) d)));
    directContent.BeginText();
    directContent.SetGState(new PdfGState()
    {
      FillOpacity = 0.5f
    });
    directContent.SetRGBColorFill((int) byte.MaxValue, 0, 0);
    BaseFont font = BaseFont.CreateFont("Helvetica-Bold", "Cp1252", false);
    directContent.SetFontAndSize(font, num2);
    float effectiveStringWidth = directContent.GetEffectiveStringWidth(str, false);
    float ascentPoint = font.GetAscentPoint(str, num2);
    float descentPoint = font.GetDescentPoint(str, num2);
    directContent.MoveText((float) (((double) num1 - (double) effectiveStringWidth) / 2.0), (float) (-((double) ascentPoint + (double) descentPoint) / 2.0));
    directContent.ShowText(str);
    directContent.EndText();
    directContent.RestoreState();
  }

  private void PlaceFormDom()
  {
    this.pageSet.NextPageArea((BreakConditions) null, (ContentArea) null, 1);
    this.ProcessBreak();
    this.formDomPositioner.ExecEvent("initialize", (string) null);
    this.formDomPositioner.ExecCalculate();
    this.formDomPositioner.ExecEvent("ready", "$form");
    this.formDomPositioner.ExecEvent("docReady", (string) null);
    this.formDomPositioner.ExecValidate();
    if (this.extraEventList != null)
    {
      foreach (string extraEvent in (IEnumerable<string>) this.extraEventList)
        this.formDomPositioner.ExecEvent(extraEvent, (string) null);
    }
    if (this.applyFormState && this.formDom.Children.Count > 0 && this.formDom.Children[0] is XFATemplateTag)
      new XFAFormStateApplier((Positioner) this.formDomPositioner, this.formDom).ApplyFormState();
    this.formDomPositioner.Place();
    this.flattenerContext.ValidateLayout = true;
    this.formDomPositioner.ExecEvent("ready", "$layout");
    this.flattenerContext.ValidateLayout = false;
    this.formDomPositioner.Relayout(false);
  }

  private bool IsTrialLicense()
  {
    try
    {
      string str = LicenseKey.GetLicenseeInfoForVersion("7.1")[3];
      return str == null || str.Trim().Length == 0;
    }
    catch (Exception ex)
    {
      return false;
    }
  }

  public enum ViewMode
  {
    ALL,
    PRINT,
    SCREEN,
  }

  private class ExtractStreamRunner
  {
    private int index;
    private PdfReader reader;
    private PdfArray asArray;
    private SettableLatch latch;
    private string key;
    private IDictionary<string, MemoryStream> map;

    public ExtractStreamRunner(
      string key,
      int index,
      PdfReader reader,
      PdfArray asArray,
      SettableLatch sl,
      IDictionary<string, MemoryStream> map)
    {
      this.key = key;
      this.index = index;
      this.reader = reader;
      this.asArray = asArray;
      this.latch = sl;
      this.map = map;
    }

    public virtual void Run()
    {
      PdfObject pdfObject2 = this.asArray[this.index];
      try
      {
        lock (this.reader)
          this.map[this.key] = XFAFlattener.GetStreamContents(this.reader, pdfObject2);
      }
      catch (IOException ex)
      {
        Console.Out.WriteLine((object) ex);
      }
      finally
      {
        this.latch.Decrement();
      }
    }
  }
}
