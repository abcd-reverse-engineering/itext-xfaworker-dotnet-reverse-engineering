// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.pipe.XdpPipeline
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.tool.xml.pipeline;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.pipe;

public class XdpPipeline : AbstractPipeline
{
  private const string XDP = "xdp";
  private const string LOCALE_SET = "localeSet";
  private const string TEMPLATE = "template";
  private const string FORM = "form";
  private const string DATA_SET = "datasets";
  private const string PDF = "pdf";
  private LocalePipeline localePipeline;
  private TemplateBuilderPipeline templateBuilderPipeline;
  private FormBuilderPipeline formBuilderPipeline;
  private DataPipeline dataPipeline;
  private PdfPipeline pdfPipeline;
  private bool xdpOpen;
  private XdpPipeline.CurrentPipeline currentPipeline = XdpPipeline.CurrentPipeline.none;
  private bool wasLocale;
  private bool wasTemplate;
  private bool wasForm;
  private bool wasPdf;

  public virtual bool WasLocale => this.wasLocale;

  public virtual bool WasTemplate => this.wasTemplate;

  public virtual bool WasForm => this.wasForm;

  public virtual bool WasPdf => this.wasPdf;

  public XdpPipeline(
    LocalePipeline localePipeline,
    TemplateBuilderPipeline templateBuilderPipeline,
    FormBuilderPipeline formBuilderPipeline,
    DataPipeline dataPipeline,
    PdfPipeline pdfPipeline)
    : base((IPipeline) null)
  {
    this.localePipeline = localePipeline;
    this.templateBuilderPipeline = templateBuilderPipeline;
    this.formBuilderPipeline = formBuilderPipeline;
    this.dataPipeline = dataPipeline;
    this.pdfPipeline = pdfPipeline;
  }

  public virtual IPipeline Open(IWorkerContext context, Tag t, ProcessObject po)
  {
    if (!this.xdpOpen)
    {
      if (t.Name.Equals("xdp"))
        this.xdpOpen = true;
    }
    else
    {
      switch (this.currentPipeline)
      {
        case XdpPipeline.CurrentPipeline.localePipeline:
          return (IPipeline) this.localePipeline;
        case XdpPipeline.CurrentPipeline.templatePipeline:
          return (IPipeline) this.templateBuilderPipeline;
        case XdpPipeline.CurrentPipeline.formPipeline:
          return (IPipeline) this.formBuilderPipeline;
        case XdpPipeline.CurrentPipeline.dataPipeline:
          return (IPipeline) this.dataPipeline;
        case XdpPipeline.CurrentPipeline.pdfPipeline:
          return (IPipeline) this.pdfPipeline;
        case XdpPipeline.CurrentPipeline.none:
          if (t.Parent.Parent == null && t.Parent.Name.Equals("xdp"))
          {
            if (t.Name.Equals("localeSet"))
            {
              this.wasLocale = true;
              IPipeline ipipeline = (IPipeline) this.localePipeline;
              do
                ;
              while ((ipipeline = ipipeline.Init(context)) != null);
              this.currentPipeline = XdpPipeline.CurrentPipeline.localePipeline;
              return (IPipeline) this.localePipeline;
            }
            if (t.Name.Equals("template"))
            {
              this.wasTemplate = true;
              IPipeline ipipeline = (IPipeline) this.templateBuilderPipeline;
              do
                ;
              while ((ipipeline = ipipeline.Init(context)) != null);
              this.currentPipeline = XdpPipeline.CurrentPipeline.templatePipeline;
              return (IPipeline) this.templateBuilderPipeline;
            }
            if (t.Name.Equals("form"))
            {
              this.wasForm = true;
              IPipeline ipipeline = (IPipeline) this.formBuilderPipeline;
              do
                ;
              while ((ipipeline = ipipeline.Init(context)) != null);
              this.currentPipeline = XdpPipeline.CurrentPipeline.formPipeline;
              return (IPipeline) this.formBuilderPipeline;
            }
            if (t.Name.Equals("datasets"))
            {
              IPipeline ipipeline = (IPipeline) this.dataPipeline;
              do
                ;
              while ((ipipeline = ipipeline.Init(context)) != null);
              this.currentPipeline = XdpPipeline.CurrentPipeline.dataPipeline;
              return (IPipeline) this.dataPipeline;
            }
            if (t.Name.Equals("pdf"))
            {
              IPipeline ipipeline = (IPipeline) this.pdfPipeline;
              do
                ;
              while ((ipipeline = ipipeline.Init(context)) != null);
              this.currentPipeline = XdpPipeline.CurrentPipeline.pdfPipeline;
              return (IPipeline) this.pdfPipeline;
            }
            break;
          }
          break;
      }
    }
    return (IPipeline) null;
  }

  public virtual IPipeline Content(IWorkerContext context, Tag t, string text, ProcessObject po)
  {
    switch (this.currentPipeline)
    {
      case XdpPipeline.CurrentPipeline.localePipeline:
        return (IPipeline) this.localePipeline;
      case XdpPipeline.CurrentPipeline.templatePipeline:
        return (IPipeline) this.templateBuilderPipeline;
      case XdpPipeline.CurrentPipeline.formPipeline:
        return (IPipeline) this.formBuilderPipeline;
      case XdpPipeline.CurrentPipeline.dataPipeline:
        return (IPipeline) this.dataPipeline;
      case XdpPipeline.CurrentPipeline.pdfPipeline:
        return (IPipeline) this.pdfPipeline;
      default:
        return (IPipeline) null;
    }
  }

  public virtual IPipeline Close(IWorkerContext context, Tag t, ProcessObject po)
  {
    if (this.xdpOpen)
    {
      switch (this.currentPipeline)
      {
        case XdpPipeline.CurrentPipeline.localePipeline:
          if (t.Parent.Parent == null && t.Parent.Name.Equals("xdp"))
            this.currentPipeline = XdpPipeline.CurrentPipeline.none;
          return (IPipeline) this.localePipeline;
        case XdpPipeline.CurrentPipeline.templatePipeline:
          if (t.Parent.Parent == null && t.Parent.Name.Equals("xdp"))
            this.currentPipeline = XdpPipeline.CurrentPipeline.none;
          return (IPipeline) this.templateBuilderPipeline;
        case XdpPipeline.CurrentPipeline.formPipeline:
          if (t.Parent.Parent == null && t.Parent.Name.Equals("xdp"))
            this.currentPipeline = XdpPipeline.CurrentPipeline.none;
          return (IPipeline) this.formBuilderPipeline;
        case XdpPipeline.CurrentPipeline.dataPipeline:
          if (t.Parent.Parent == null && t.Parent.Name.Equals("xdp"))
            this.currentPipeline = XdpPipeline.CurrentPipeline.none;
          return (IPipeline) this.dataPipeline;
        case XdpPipeline.CurrentPipeline.pdfPipeline:
          if (t.Parent.Parent == null && t.Parent.Name.Equals("xdp"))
            this.currentPipeline = XdpPipeline.CurrentPipeline.none;
          return (IPipeline) this.pdfPipeline;
        default:
          if (t.Name.Equals("xdp") && t.Parent == null)
          {
            this.xdpOpen = false;
            break;
          }
          break;
      }
    }
    return (IPipeline) null;
  }

  private enum CurrentPipeline
  {
    localePipeline,
    templatePipeline,
    formPipeline,
    dataPipeline,
    pdfPipeline,
    none,
  }
}
