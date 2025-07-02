// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.element.TextDrawer
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.interfaces;
using iTextSharp.tool.xml.css;
using iTextSharp.tool.xml.pdfelement;
using iTextSharp.tool.xml.xtra.xfa.bind;
using iTextSharp.tool.xml.xtra.xfa.font;
using iTextSharp.tool.xml.xtra.xfa.js;
using iTextSharp.tool.xml.xtra.xfa.positioner;
using iTextSharp.tool.xml.xtra.xfa.resolver;
using iTextSharp.tool.xml.xtra.xfa.tags;
using iTextSharp.tool.xml.xtra.xfa.util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.util;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.element;

public class TextDrawer : AbstractDrawer
{
  public const int VERTICAL_ALIGN_UNDEFIND = -1;
  public const int VERTICAL_ALIGN_TOP = 0;
  public const int VERTICAL_ALIGN_MIDDLE = 1;
  public const int VERTICAL_ALIGN_BOTTOM = 2;
  public const float HEIGHT_ADDITION_EPS = 0.005f;
  protected readonly JsNode parentNode;
  protected readonly XFARectangle pageSize;
  protected readonly FlattenerContext flattenerContext;
  protected readonly List<IElement> content = new List<IElement>();
  protected ColumnText box;
  protected XFARectangle textRectangle;
  protected XFARectangle externalBoxRef;
  protected internal XFARectangle initRect;
  protected int verticalAlignment = -1;
  protected bool resolved = true;
  private float verticalAlignShift;
  private float widthAddition;
  private float heightAddition;
  private bool ignoreEmbeddedElement;
  private bool isRTL;
  private bool isAutoSize;
  private float autoSizeLimit = 144f;
  private string autoSizePlainText;
  private float marginHeightAddition;
  private static float MAX_MARGIN_HEIGHT_ADDITION = 1.05f;

  public TextDrawer(
    JsNode parentNode,
    XFARectangle pageSize,
    string plainText,
    FlattenerContext flattenerContext)
    : this(parentNode, pageSize, flattenerContext, false)
  {
    if (string.IsNullOrEmpty(plainText))
      return;
    Font font1 = flattenerContext.GetFont((IFormNode) parentNode, FontFactory.DefaultEncoding);
    if ((double) font1.Size == 0.0)
    {
      this.isAutoSize = true;
      this.autoSizePlainText = plainText;
    }
    Font font2 = flattenerContext.GetFont((IFormNode) parentNode, "Identity-H");
    this.InitBasedOnPlainTextAndFonts(plainText, font1, font2);
  }

  protected virtual void InitBasedOnPlainTextAndFonts(string plainText, Font f1, Font f2)
  {
    this.content.Clear();
    if (plainText == null || plainText.Length <= 0)
      return;
    FontSelector fontSelector = (FontSelector) new XFAFontSelector();
    if (f1 != null)
      fontSelector.AddFont(f1);
    if (f2 != null)
      fontSelector.AddFont(f2);
    Phrase phrase = fontSelector.Process(plainText);
    foreach (Chunk chunk in (IEnumerable<Chunk>) phrase.Chunks)
      this.CheckForUnderlineAndLineThrough(chunk);
    Paragraph paragraph = (Paragraph) new XFAParagraph(phrase);
    this.isRTL = this.IsRightToLeft(paragraph);
    ((Phrase) paragraph).Leading = float.NaN;
    this.ApplyParagraphStyles(paragraph);
    this.ApplyContainerStyles();
    this.content.Add((IElement) paragraph);
  }

  protected virtual void ReInitAutoSizeText()
  {
    Font font1 = this.flattenerContext.GetFont((IFormNode) this.parentNode, "Cp1252");
    font1.Size = 12f;
    Font font2 = this.flattenerContext.GetFont((IFormNode) this.parentNode, "Identity-H");
    font2.Size = 12f;
    this.InitBasedOnPlainTextAndFonts(this.autoSizePlainText, font1, font2);
  }

  public TextDrawer(
    JsNode parentNode,
    XFARectangle pageSize,
    IList<IElement> richText,
    FlattenerContext flattenerContext)
    : this(parentNode, pageSize, flattenerContext, false)
  {
    this.ProcessRichText(richText);
    this.ApplyContainerStyles();
  }

  public TextDrawer(
    JsNode parentNode,
    XFARectangle pageSize,
    IList<IElement> richText,
    FlattenerContext flattenerContext,
    bool ignoreEmbeddedElement)
    : this(parentNode, pageSize, flattenerContext, ignoreEmbeddedElement)
  {
    this.ProcessRichText(richText);
    this.ApplyContainerStyles();
  }

  private TextDrawer(
    JsNode parentNode,
    XFARectangle pageSize,
    FlattenerContext flattenerContext,
    bool ignoreEmbeddedElement)
  {
    this.role = PdfName.DIV;
    this.parentNode = parentNode;
    this.pageSize = pageSize;
    this.flattenerContext = flattenerContext;
    this.ignoreEmbeddedElement = ignoreEmbeddedElement;
  }

  public static string GetMaxSingleLineText(
    string originalText,
    XFARectangle textArea,
    JsNode node,
    Rectangle pageSize,
    FlattenerContext flattenerContext)
  {
    int length1 = 0;
    int num = originalText.Length;
    while (length1 < num)
    {
      int length2 = (length1 + num + 1) / 2;
      string plainText = originalText.Substring(0, length2);
      TextDrawer textDrawer = new TextDrawer(node, new XFARectangle(pageSize), plainText, flattenerContext);
      textDrawer.CreateColumnText(textArea);
      if (textDrawer.box.LinesWritten == 1)
        length1 = length2;
      else
        num = length2 - 1;
    }
    return originalText.Substring(0, length1);
  }

  public virtual IList<IElement> GetContent() => (IList<IElement>) this.content;

  public virtual FlattenerContext FlattenerContext => this.flattenerContext;

  public virtual string GetContentAsString()
  {
    StringBuilder stringBuilder = new StringBuilder();
    foreach (IElement ielement in this.content)
    {
      foreach (Chunk chunk in (IEnumerable<Chunk>) ielement.Chunks)
        stringBuilder.Append(chunk.Content);
    }
    return stringBuilder.ToString();
  }

  public virtual void CreateColumnText(XFARectangle rec)
  {
    this.initRect = (XFARectangle) rec.Clone();
    this.externalBoxRef = rec;
    this.box = (ColumnText) null;
    this.verticalAlignShift = 0.0f;
    this.widthAddition = 0.0f;
    this.heightAddition = 0.0f;
    if (this.content.Count > 0)
    {
      float? ury = rec.Ury;
      float? nullable1 = rec.Height;
      if (!nullable1.HasValue && this.isAutoSize)
        nullable1 = rec.MinH;
      float? nullable2 = new float?(0.0f);
      if (!nullable1.HasValue)
      {
        float? maxH = rec.MaxH;
        if (!maxH.HasValue)
        {
          nullable2 = new float?(float.MinValue);
          if (this.isAutoSize)
          {
            this.ReInitAutoSizeText();
            this.isAutoSize = false;
          }
        }
        else
        {
          float? nullable3 = ury;
          float? nullable4 = maxH;
          nullable2 = nullable3.HasValue & nullable4.HasValue ? new float?(nullable3.GetValueOrDefault() - nullable4.GetValueOrDefault()) : new float?();
        }
      }
      else
      {
        float? nullable5 = ury;
        float? nullable6 = nullable1;
        nullable2 = nullable5.HasValue & nullable6.HasValue ? new float?(nullable5.GetValueOrDefault() - nullable6.GetValueOrDefault()) : new float?();
      }
      float? llx = rec.Llx;
      float? nullable7 = rec.Width;
      if (!nullable7.HasValue && this.isAutoSize)
        nullable7 = rec.MinW;
      float? nullable8 = new float?(0.0f);
      float? nullable9;
      if (!nullable7.HasValue)
      {
        float? nullable10 = rec.MaxW;
        if (!nullable10.HasValue)
        {
          nullable10 = new float?(Math.Max(this.pageSize.Width.Value, this.pageSize.Height.Value));
          if (this.isAutoSize)
          {
            this.ReInitAutoSizeText();
            this.isAutoSize = false;
          }
        }
        float? nullable11 = llx;
        float? nullable12 = nullable10;
        nullable9 = nullable11.HasValue & nullable12.HasValue ? new float?(nullable11.GetValueOrDefault() + nullable12.GetValueOrDefault()) : new float?();
      }
      else
      {
        float? nullable13 = llx;
        float? nullable14 = nullable7;
        nullable9 = nullable13.HasValue & nullable14.HasValue ? new float?(nullable13.GetValueOrDefault() + nullable14.GetValueOrDefault()) : new float?();
      }
      this.box = new ColumnText((PdfContentByte) null);
      if (this.isRTL)
        this.box.RunDirection = 3;
      this.box.UseAscender = true;
      this.box.InheritGraphicState = true;
      float size = 0.0f;
      float num1 = 0.2f;
      Font font = (Font) null;
      foreach (IElement p in this.content)
      {
        if (this.isAutoSize && p is Phrase)
        {
          if (font == null && ((Phrase) p).Font != null)
          {
            font = ((Phrase) p).Font;
            BaseFont baseFont = font.BaseFont ?? font.GetCalculatedBaseFont(false);
            float num2 = baseFont.GetFontDescriptor(8, 1f) - baseFont.GetFontDescriptor(6, 1f);
            size = (ury.Value - nullable2.Value) / num2;
            if ((double) size > 4.0)
            {
              if ((double) size > (double) this.autoSizeLimit)
                size = this.autoSizeLimit;
              num1 = Math.Max((float) (((double) size - 4.0) / 19.5), 0.2f);
            }
          }
          TextDrawer.ChangeFontSize((Phrase) p, size);
        }
        if (nullable7.HasValue && p is Paragraph)
        {
          Paragraph paragraph = (Paragraph) p;
          float? nullable15 = nullable7;
          float num3 = paragraph.IndentationLeft + paragraph.IndentationRight;
          if (((double) nullable15.GetValueOrDefault() >= (double) num3 ? 0 : (nullable15.HasValue ? 1 : 0)) != 0)
          {
            float indentationLeft = paragraph.IndentationLeft;
            float indentationRight = paragraph.IndentationRight;
            float num4 = indentationLeft + indentationRight;
            paragraph.IndentationLeft = nullable7.Value * indentationLeft / num4;
            paragraph.IndentationRight = nullable7.Value * indentationRight / num4;
          }
        }
      }
      float num5 = ury.Value;
      bool flag1 = false;
      float f = float.NaN;
      bool flag2 = false;
      bool flag3 = false;
      try
      {
        int num6 = 2;
label_35:
        while (true)
        {
          int num7 = num6;
          int linesWritten = this.box.LinesWritten;
          this.box.SetSimpleColumn(llx.Value, nullable2.Value - this.marginHeightAddition, nullable9.Value, ury.Value);
          this.box.FilledWidth = 0.0f;
          this.box.SetText((Phrase) null);
          this.box.AddElement((IElement) this.GetEmpty());
          foreach (IElement ielement in this.content)
            this.box.AddElement(ielement);
          this.box.AddElement((IElement) this.GetEmpty());
          num6 = this.box.Go(true);
          if (!this.isAutoSize)
          {
            if (!float.IsNaN(f))
            {
              float filledWidth = this.box.FilledWidth;
              float? nullable16 = nullable7;
              float? nullable17 = nullable16.HasValue ? new float?(filledWidth - nullable16.GetValueOrDefault()) : new float?();
              float num8 = f;
              if (((double) nullable17.GetValueOrDefault() <= (double) num8 ? 0 : (nullable17.HasValue ? 1 : 0)) != 0 || (!ColumnText.HasMoreText(num7) || ColumnText.HasMoreText(num6)) && linesWritten <= this.box.LinesWritten)
              {
                float? nullable18 = nullable9;
                float num9 = f;
                nullable9 = nullable18.HasValue ? new float?(nullable18.GetValueOrDefault() - num9) : new float?();
                num6 = num7;
                flag1 = false;
              }
            }
            if (nullable7.HasValue && float.IsNaN(f))
            {
              f = 0.5f;
              if (ColumnText.HasMoreText(num6) && nullable1.HasValue && this.box.LinesWritten == 1)
                f = 3f;
              float? nullable19 = nullable9;
              float num10 = f;
              nullable9 = nullable19.HasValue ? new float?(nullable19.GetValueOrDefault() + num10) : new float?();
              flag1 = true;
            }
            else
            {
              if (!flag2 && this.box.IsWordSplit())
              {
                bool flag4 = false;
                foreach (IElement ielement in this.content)
                {
                  if (ielement is Paragraph)
                  {
                    Paragraph paragraph = (Paragraph) ielement;
                    if ((double) paragraph.IndentationRight != 0.0)
                    {
                      flag4 = true;
                      paragraph.IndentationRight = 0.0f;
                    }
                  }
                }
                if (flag4)
                {
                  flag2 = true;
                  continue;
                }
              }
              if (!flag3)
              {
                if ((num6 & 2) != 0)
                {
                  if (this.parentNode is Positioner)
                    this.marginHeightAddition = Math.Max(0.0f, Math.Min(TextDrawer.MAX_MARGIN_HEIGHT_ADDITION, ((Positioner) this.parentNode).GetBottomInset()));
                  flag3 = true;
                }
                else
                  goto label_72;
              }
              else
                goto label_72;
            }
          }
          else
            break;
        }
        if ((num6 & 2) != 0)
        {
          if ((double) size - (double) num1 >= 4.0)
          {
            size -= num1;
            using (List<IElement>.Enumerator enumerator = this.content.GetEnumerator())
            {
              while (enumerator.MoveNext())
              {
                IElement current = enumerator.Current;
                if (current is Phrase)
                  TextDrawer.ChangeFontSize((Phrase) current, size);
              }
              goto label_35;
            }
          }
        }
      }
      catch (DocumentException ex)
      {
      }
label_72:
      float num11 = this.box.YLine + this.box.Descender;
      this.box.YLine = num5;
      this.box.SetText((Phrase) null);
      this.box.AddElement((IElement) this.GetEmpty());
      foreach (IElement ielement in this.content)
        this.box.AddElement(ielement);
      this.box.AddElement((IElement) this.GetEmpty());
      float? nullable20;
      if (!rec.Height.HasValue)
      {
        if (rec.MinH.HasValue)
        {
          XFARectangle xfaRectangle = rec;
          nullable20 = rec.MinH;
          float num12 = num5 - num11;
          float? nullable21 = ((double) nullable20.GetValueOrDefault() <= (double) num12 ? 0 : (nullable20.HasValue ? 1 : 0)) != 0 ? rec.MinH : new float?(num5 - num11);
          xfaRectangle.Height = nullable21;
        }
        else
          rec.Height = new float?(num5 - num11);
        this.heightAddition = 1f / 1000f;
      }
      nullable20 = rec.Width;
      if (!nullable20.HasValue)
      {
        nullable20 = rec.MinW;
        if (nullable20.HasValue)
        {
          XFARectangle xfaRectangle = rec;
          nullable20 = rec.MinW;
          float filledWidth = this.box.FilledWidth;
          float? nullable22 = ((double) nullable20.GetValueOrDefault() <= (double) filledWidth ? 0 : (nullable20.HasValue ? 1 : 0)) != 0 ? rec.MinW : new float?(this.box.FilledWidth);
          xfaRectangle.Width = nullable22;
        }
        else
          rec.Width = new float?(this.box.FilledWidth);
        this.widthAddition = 0.005f;
      }
      else if (flag1)
      {
        double filledWidth = (double) this.box.FilledWidth;
        nullable20 = rec.Width;
        double num13 = (double) nullable20.Value;
        this.widthAddition = (float) (filledWidth - num13 + 0.004999999888241291);
      }
      if (this.verticalAlignment != -1 && this.verticalAlignment != 0)
      {
        float num14 = num5 - num11;
        nullable20 = rec.Height;
        this.verticalAlignShift = nullable20.Value - num14;
        if ((double) this.verticalAlignShift > 0.0)
        {
          if (this.verticalAlignment == 1)
          {
            nullable20 = ury;
            float num15 = this.verticalAlignShift / 2f;
            ury = nullable20.HasValue ? new float?(nullable20.GetValueOrDefault() - num15) : new float?();
            this.verticalAlignShift /= 2f;
          }
          else if (this.verticalAlignment == 2)
          {
            nullable20 = ury;
            float verticalAlignShift = this.verticalAlignShift;
            ury = nullable20.HasValue ? new float?(nullable20.GetValueOrDefault() - verticalAlignShift) : new float?();
          }
        }
        else
          this.verticalAlignShift = 0.0f;
      }
      this.textRectangle = new XFARectangle(llx, ury, new float?(this.box.FilledWidth), new float?(num5 - num11));
      this.externalBoxRef = rec;
    }
    else
    {
      XFAUtil.SetMinAsDefault(rec);
      this.textRectangle = new XFARectangle(rec.Llx, rec.Ury, rec.Width, rec.Height);
    }
  }

  private static void ChangeFontSize(Phrase p, float size)
  {
    for (int index = 0; index < ((List<IElement>) p).Count; ++index)
    {
      IElement p1 = ((List<IElement>) p)[index];
      switch (p1)
      {
        case Chunk _:
          ((Chunk) p1).Font.Size = size;
          break;
        case Phrase _:
          TextDrawer.ChangeFontSize((Phrase) p1, size);
          break;
      }
    }
  }

  public override void Draw(PdfContentByte canvas, XFARectangle borderArea)
  {
    this.Draw(canvas, borderArea, false);
  }

  public virtual PositionResult Draw(
    PdfContentByte canvas,
    XFARectangle parentBoundingBox,
    bool simulate)
  {
    PositionResult positionResult = new PositionResult(PositionResult.State.FULL_CONTENT, this.externalBoxRef);
    if (canvas != null && canvas.IsTagged() && this.IsEmpty())
    {
      Chunk chunk = new Chunk();
      Paragraph p = (Paragraph) new XFAParagraph(chunk);
      ((Phrase) p).Leading = float.NaN;
      this.ApplyParagraphStyles(p);
      this.content.Add((IElement) p);
      this.ApplyContainerStyles();
      canvas.OpenMCBlock((IAccessibleElement) p);
      canvas.OpenMCBlock((IAccessibleElement) chunk);
      canvas.CloseMCBlock((IAccessibleElement) chunk);
      canvas.CloseMCBlock((IAccessibleElement) p);
      return positionResult;
    }
    if (this.box == null)
      return new PositionResult(PositionResult.State.NO_CONTENT);
    if (!this.resolved)
    {
      this.ResolveEmbeddedElements();
      if (this.resolved)
        this.CreateColumnText(this.initRect);
    }
    ColumnText columnText1 = simulate ? ColumnText.Duplicate(this.box) : this.box;
    float num1 = this.externalBoxRef.Ury.Value - this.verticalAlignShift;
    if (parentBoundingBox != null && XFAUtil.Lt(this.externalBoxRef.Ury.Value - this.externalBoxRef.Height.Value, parentBoundingBox.Ury.Value - parentBoundingBox.Height.Value))
      columnText1.SetSimpleColumn(this.externalBoxRef.Llx.Value, parentBoundingBox.Ury.Value - parentBoundingBox.Height.Value - this.marginHeightAddition, this.externalBoxRef.Llx.Value + this.externalBoxRef.Width.Value + this.widthAddition, num1);
    else
      columnText1.SetSimpleColumn(this.externalBoxRef.Llx.Value, this.externalBoxRef.Ury.Value - this.externalBoxRef.Height.Value - this.heightAddition - this.marginHeightAddition, this.externalBoxRef.Llx.Value + this.externalBoxRef.Width.Value + this.widthAddition, num1);
    if (!simulate)
    {
      if (this.resolved)
      {
        columnText1.Canvas = canvas;
      }
      else
      {
        PdfTemplate template = canvas.CreateTemplate(this.externalBoxRef.Width.Value, this.externalBoxRef.Height.Value);
        template.SetMatrix(1f, 0.0f, 0.0f, 1f, -this.externalBoxRef.Llx.Value, -this.externalBoxRef.Ury.Value + this.externalBoxRef.Height.Value);
        template.BoundingBox = new Rectangle(this.externalBoxRef.Llx.Value, this.externalBoxRef.Ury.Value - this.pageSize.Height.Value, this.externalBoxRef.Llx.Value + this.pageSize.Width.Value, this.externalBoxRef.Ury.Value);
        if (canvas.IsTagged())
          canvas.OpenMCBlock((IAccessibleElement) this);
        canvas.AddTemplate(template, this.externalBoxRef.Llx.Value, this.externalBoxRef.Ury.Value - this.externalBoxRef.Height.Value, true);
        if (canvas.IsTagged())
          canvas.CloseMCBlock((IAccessibleElement) this);
        columnText1.Canvas = (PdfContentByte) template;
      }
    }
    else
      columnText1.Canvas = (PdfContentByte) null;
    if (!this.resolved)
    {
      if (!simulate)
      {
        this.flattenerContext.AddUnresolvedTextDrawer(this);
        return positionResult;
      }
    }
    try
    {
      if ((columnText1.Go(simulate) & 1) == 0)
      {
        if (!simulate)
        {
          ColumnText columnText2 = ColumnText.Duplicate(columnText1);
          columnText2.SetSimpleColumn(this.externalBoxRef.Llx.Value, this.externalBoxRef.Ury.Value, this.externalBoxRef.Llx.Value + this.externalBoxRef.Width.Value, this.externalBoxRef.Ury.Value);
          columnText2.Go(true);
          float num2 = columnText1.YLine - columnText1.CurrentLeading + columnText2.CurrentLeading;
          this.externalBoxRef.Ury = new float?(num2);
          XFARectangle externalBoxRef = this.externalBoxRef;
          float? height = this.externalBoxRef.Height;
          float num3 = num1 - num2;
          float? nullable = height.HasValue ? new float?(height.GetValueOrDefault() - num3) : new float?();
          externalBoxRef.Height = nullable;
          columnText1.SetSimpleColumn(this.externalBoxRef.ToRectangle());
        }
        else
          positionResult.CurrentLeading = columnText1.CurrentLeading;
        PositionResult.State state = columnText1.LinesWritten == 0 ? PositionResult.State.NO_CONTENT : PositionResult.State.CONTENT_PART;
        positionResult.SetState(state);
      }
      else if (simulate)
        positionResult.CurrentLeading = columnText1.CurrentLeading;
    }
    catch (DocumentException ex)
    {
      positionResult.SetState(PositionResult.State.NO_CONTENT);
    }
    return positionResult;
  }

  public override bool IsEmpty()
  {
    if (this.box != null)
    {
      foreach (IElement ielement in this.content)
      {
        if (ielement is Phrase && !((Phrase) ielement).IsEmpty() || ielement is List && !((List) ielement).IsEmpty())
          return false;
      }
    }
    return true;
  }

  public virtual void ResolveEmbeddedElementsAndDraw(bool forceDraw)
  {
    this.ResolveEmbeddedElements();
    if (!this.resolved && !forceDraw)
      return;
    PdfContentByte canvas = this.box.Canvas;
    this.CreateColumnText(this.initRect);
    this.box.SetSimpleColumn(this.externalBoxRef.Llx.Value, this.externalBoxRef.Ury.Value - this.externalBoxRef.Height.Value - this.heightAddition, this.externalBoxRef.Llx.Value + this.externalBoxRef.Width.Value + this.widthAddition, this.externalBoxRef.Ury.Value - this.verticalAlignShift);
    this.box.Canvas = canvas;
    this.box.Go();
  }

  private void ResolveEmbeddedElements()
  {
    this.resolved = true;
    Font font1 = this.flattenerContext.GetFont((IFormNode) this.parentNode, FontFactory.DefaultEncoding);
    Font font2 = this.flattenerContext.GetFont((IFormNode) this.parentNode, "Identity-H");
    foreach (IElement ielement in this.content)
    {
      if (ielement is Paragraph)
      {
        Paragraph currentParagraph = (Paragraph) ielement;
        for (int index1 = 0; index1 < ((List<IElement>) currentParagraph).Count; ++index1)
        {
          if (((List<IElement>) currentParagraph)[index1] is EmbeddedElement)
          {
            EmbeddedElement textElement = (EmbeddedElement) ((List<IElement>) currentParagraph)[index1];
            List<IElement> ielementList = (List<IElement>) null;
            if (index1 != ((List<IElement>) currentParagraph).Count - 1)
              ielementList = new List<IElement>((IEnumerable<IElement>) ((List<IElement>) currentParagraph).GetRange(index1 + 1, ((List<IElement>) currentParagraph).Count - (index1 + 1)));
            int num = ((List<IElement>) currentParagraph).Count - index1;
            for (int index2 = 0; index2 < num; ++index2)
              ((List<IElement>) currentParagraph).RemoveAt(index1);
            this.ProcessTextElement((IElement) textElement, currentParagraph, font1, font2);
            index1 = ((List<IElement>) currentParagraph).Count - 1;
            if (ielementList != null)
              ((Phrase) currentParagraph).AddAll<IElement>((ICollection<IElement>) ielementList);
          }
        }
      }
    }
  }

  public virtual XFARectangle GetTextRectangle() => this.textRectangle;

  public virtual int VerticalAlignment
  {
    get => this.verticalAlignment;
    set => this.verticalAlignment = value;
  }

  private Paragraph ProcessTextElement(
    IElement textElement,
    Paragraph currentParagraph,
    Font f1,
    Font f2)
  {
    Font font1 = f1 != null ? f1.Difference(((Phrase) currentParagraph).Font) : ((Phrase) currentParagraph).Font;
    Font font2 = ((XFAFont) f2)?.Difference(((Phrase) currentParagraph).Font, "Identity-H");
    FontSelector fontSelector = (FontSelector) new XFAFontSelector();
    Phrase phrase = (Phrase) null;
    IDictionary<string, object> dictionary1 = (IDictionary<string, object>) null;
    IDictionary<PdfName, PdfObject> dictionary2 = (IDictionary<PdfName, PdfObject>) null;
    PdfName pdfName = (PdfName) null;
    switch (textElement)
    {
      case EmbeddedElement _:
        if (!this.ignoreEmbeddedElement)
        {
          EmbeddedElement embeddedElement = (EmbeddedElement) textElement;
          dictionary1 = embeddedElement.Attributes;
          if (embeddedElement.IsRaw)
          {
            Positioner positioner = embeddedElement.Positioner;
            if (positioner == null && embeddedElement.IsUri)
            {
              positioner = this.flattenerContext.ResolvePositioner(embeddedElement.EmbedValue);
              if (positioner != null)
              {
                embeddedElement = new EmbeddedElement(((EmbeddedElement) textElement).EmbedValue);
                embeddedElement.IsRaw = true;
                Font font3 = ((EmbeddedElement) textElement).Font;
                Font font4 = font1 != null ? font1.Difference(font3) : font3;
                embeddedElement.Font = font4 == null ? ((EmbeddedElement) textElement).Font : font4;
                embeddedElement.Attributes = dictionary1;
                embeddedElement.Positioner = positioner;
              }
            }
            object richText = (object) null;
            if (positioner != null)
            {
              object rawValue = positioner.GetRawValue();
              positioner.ExecEvent("ready", (string) null);
              positioner.ExecEvent("docReady", (string) null);
              positioner.ExecValidate();
              if (this.flattenerContext.ExtraEventList != null)
              {
                foreach (string extraEvent in (IEnumerable<string>) this.flattenerContext.ExtraEventList)
                  positioner.ExecEvent(extraEvent, (string) null);
              }
              richText = positioner.GetFormattedValue();
              if ("".Equals(richText))
                richText = (object) null;
              positioner.SetRawValue(rawValue);
            }
            if (richText == null)
            {
              this.resolved = false;
              ((Phrase) currentParagraph).Add((IElement) embeddedElement);
              break;
            }
            if (richText is string)
            {
              Font font5 = embeddedElement.Font;
              Font font6 = font1 != null ? font1.Difference(font5) : font5;
              if (font6 != null)
                fontSelector.AddFont(font6);
              if (font2 != null)
                fontSelector.AddFont(((XFAFont) font2).Difference(font5, "Identity-H"));
              phrase = fontSelector.Process((string) richText);
            }
            if (richText is IList)
            {
              this.ProcessRichText((IList<IElement>) richText);
              break;
            }
            break;
          }
          break;
        }
        break;
      case Chunk _:
        Chunk chunk1 = (Chunk) textElement;
        dictionary1 = (IDictionary<string, object>) chunk1.Attributes;
        dictionary2 = (IDictionary<PdfName, PdfObject>) chunk1.GetAccessibleAttributes();
        Font font7 = chunk1.Font;
        Font font8 = font1 != null ? font1.Difference(font7) : font7;
        if (dictionary1 != null && dictionary1.ContainsKey("TAB"))
        {
          Chunk c = new Chunk(chunk1);
          c.Font = font8;
          this.CheckForUnderlineAndLineThrough(c);
          ((Phrase) currentParagraph).Add((IElement) c);
          break;
        }
        pdfName = chunk1.Role;
        if (font8 != null)
          fontSelector.AddFont(font8);
        if (font2 != null)
        {
          Font font9 = ((XFAFont) font2).Difference(font7, "Identity-H");
          fontSelector.AddFont(font9);
        }
        phrase = fontSelector.Process(chunk1.Content);
        break;
      case Paragraph _:
        return this.ProcessParagraph((Paragraph) textElement, currentParagraph, f1, f2);
    }
    if (phrase != null)
    {
      foreach (Chunk chunk2 in (IEnumerable<Chunk>) phrase.Chunks)
      {
        if (dictionary1 != null)
          chunk2.Attributes = new Dictionary<string, object>(dictionary1);
        if (dictionary2 != null)
        {
          foreach (KeyValuePair<PdfName, PdfObject> keyValuePair in (IEnumerable<KeyValuePair<PdfName, PdfObject>>) dictionary2)
            chunk2.SetAccessibleAttribute(keyValuePair.Key, keyValuePair.Value);
        }
        if (pdfName != null)
          chunk2.Role = pdfName;
        this.CheckForUnderlineAndLineThrough(chunk2);
        ((Phrase) currentParagraph).Add((IElement) chunk2);
      }
    }
    return (Paragraph) null;
  }

  private void ProcessRichText(IList<IElement> richText)
  {
    Font font1 = this.flattenerContext.GetFont((IFormNode) this.parentNode, FontFactory.DefaultEncoding);
    Font font2 = this.flattenerContext.GetFont((IFormNode) this.parentNode, "Identity-H");
    this.isRTL = this.IsRightToLeft(richText);
    Paragraph paragraph1 = (Paragraph) null;
    bool flag = true;
    foreach (IElement textElement in (IEnumerable<IElement>) richText)
    {
      switch (textElement)
      {
        case Phrase _:
          Phrase currentPhrase = (Phrase) textElement;
          if (currentPhrase is Paragraph)
          {
            Paragraph paragraph2 = this.ProcessParagraph((Paragraph) currentPhrase, paragraph1, font1, font2);
            paragraph1 = (Paragraph) null;
            if (((Phrase) paragraph2).Trim())
            {
              flag = true;
            }
            else
            {
              if (flag)
              {
                flag = false;
                continue;
              }
              paragraph2 = (Paragraph) new XFAParagraph(float.NaN);
              this.ProcessTextElement((IElement) new Chunk("\n"), paragraph2, font1, font2);
            }
            this.ApplyParagraphStyles(paragraph2);
            this.content.Add((IElement) paragraph2);
            continue;
          }
          if (paragraph1 == null)
            paragraph1 = (Paragraph) new XFAParagraph(float.NaN);
          using (List<IElement>.Enumerator enumerator = ((List<IElement>) currentPhrase).GetEnumerator())
          {
            while (enumerator.MoveNext())
              this.ProcessTextElement(enumerator.Current, paragraph1, font1, font2);
            continue;
          }
        case Chunk _ when "\n".Equals(((Chunk) textElement).Content):
          if (paragraph1 != null && ((Phrase) paragraph1).Trim())
          {
            this.ApplyParagraphStyles(paragraph1);
            this.content.Add((IElement) paragraph1);
            paragraph1 = (Paragraph) null;
            flag = false;
            continue;
          }
          paragraph1 = (Paragraph) null;
          if (flag)
          {
            flag = false;
            continue;
          }
          Paragraph paragraph3 = (Paragraph) new XFAParagraph(float.NaN);
          this.ProcessTextElement(textElement, paragraph3, font1, font2);
          this.ApplyParagraphStyles(paragraph3);
          this.content.Add((IElement) paragraph3);
          continue;
        case List _:
          this.AddParagraphToContent(paragraph1);
          paragraph1 = (Paragraph) null;
          if (this.parentNode is DrawPositioner || this.parentNode is FieldPositioner && (double) this.flattenerContext.XfaVersion >= 3.2999999523162842)
          {
            this.content.Add((IElement) this.ProcessList((List) textElement, font1, font2));
            continue;
          }
          if (this.parentNode is FieldPositioner)
          {
            Paragraph currentParagraph = new Paragraph(float.NaN);
            foreach (IElement ielement in ((List) textElement).Items)
            {
              if (ielement is ListItem)
              {
                foreach (IElement chunk in (IEnumerable<Chunk>) ielement.Chunks)
                  this.ProcessTextElement(chunk, currentParagraph, font1, font2);
              }
            }
            this.content.Add((IElement) currentParagraph);
            continue;
          }
          continue;
        default:
          continue;
      }
    }
    this.AddParagraphToContent(paragraph1);
  }

  private void AddParagraphToContent(Paragraph currentParagraph)
  {
    if (currentParagraph == null || !((Phrase) currentParagraph).Trim())
      return;
    this.ApplyParagraphStyles(currentParagraph);
    this.content.Add((IElement) currentParagraph);
  }

  private List ProcessList(List list, Font f1, Font f2)
  {
    List list1 = list.CloneShallow();
    foreach (IElement normalizeNestedList in (IEnumerable<IElement>) this.NormalizeNestedLists(list))
    {
      if (normalizeNestedList is List)
        list1.Add((IElement) this.ProcessList((List) normalizeNestedList, f1, f2));
      else if (normalizeNestedList is ListItem)
      {
        Paragraph paragraph = this.ProcessParagraph((Paragraph) normalizeNestedList, (Paragraph) null, f1, f2);
        ListItem listItem1;
        if (paragraph is ListItem)
        {
          listItem1 = (ListItem) paragraph;
        }
        else
        {
          listItem1 = new ListItem();
          ((Phrase) listItem1).Add((IElement) paragraph);
        }
        ListItem listItem2 = (ListItem) normalizeNestedList;
        if (listItem2.ListSymbol != null)
          listItem1.ListSymbol = listItem2.ListSymbol;
        ((Phrase) listItem1).MultipliedLeading = 1.2f;
        list1.Add((IElement) listItem1);
      }
    }
    return list1;
  }

  private IList<IElement> NormalizeNestedLists(List list)
  {
    IList<IElement> ielementList = (IList<IElement>) new List<IElement>();
    foreach (IElement ielement1 in list.Items)
    {
      if (!(ielement1 is ListItem))
      {
        ielementList.Add(ielement1);
      }
      else
      {
        ListItem listItem1 = (ListItem) ielement1;
        ListItem listItem2 = (ListItem) ((Paragraph) listItem1).CloneShallow(true);
        ielementList.Add((IElement) listItem2);
        for (int index1 = 0; index1 < ((List<IElement>) listItem1).Count; ++index1)
        {
          IElement ielement2 = ((List<IElement>) listItem1)[index1];
          if (!(ielement2 is List))
          {
            ((Phrase) listItem2).Add(ielement2);
          }
          else
          {
            ielementList.Add(ielement2);
            if (index1 + 1 < ((List<IElement>) listItem1).Count)
            {
              listItem2 = (ListItem) ((Paragraph) listItem1).CloneShallow(true);
              ielementList.Add((IElement) listItem2);
              try
              {
                char ch = ' ';
                Font font1 = listItem1.ListSymbol.Font;
                int num = 1;
                Font font2 = new Font(font1.BaseFont, (float) num, font1.Style, font1.Color);
                double widthPoint = (double) font2.GetCalculatedBaseFont(true).GetWidthPoint((int) ch, font2.CalculatedSize);
                char[] chArray = new char[(int) ((double) listItem1.ListSymbol.GetWidthPoint() / widthPoint)];
                for (int index2 = 0; index2 < chArray.Length; ++index2)
                  chArray[index2] = ch;
                listItem2.ListSymbol = new Chunk(new string(chArray))
                {
                  Font = font2
                };
              }
              catch (Exception ex)
              {
                listItem2.ListSymbol = new Chunk("");
              }
            }
          }
        }
      }
    }
    return ielementList;
  }

  private Paragraph ProcessParagraph(
    Paragraph currentPhrase,
    Paragraph currentParagraph,
    Font f1,
    Font f2)
  {
    this.AddParagraphToContent(currentParagraph);
    currentParagraph = currentPhrase.CloneShallow(true);
    currentParagraph.ID = (AccessibleElementId) null;
    bool flag1 = true;
    bool flag2 = false;
    foreach (IElement textElement in (List<IElement>) currentPhrase)
    {
      if (textElement is Chunk)
      {
        Chunk chunk = (Chunk) textElement;
        if ((((List<IElement>) currentPhrase)[0] != textElement || !"\n".Equals(chunk.Content) || (double) this.flattenerContext.XfaVersion != 2.5999999046325684 || TextDrawer.GetXFAApiVersion(currentPhrase) != null) && (this.content.Count != 0 || !((Phrase) currentParagraph).IsEmpty() || !"\n".Equals(chunk.Content)) && (!flag1 || !chunk.IsWhitespace()))
        {
          if ("\n".Equals(chunk.Content))
          {
            flag1 = true;
          }
          else
          {
            flag1 = false;
            if (!flag2 || !chunk.IsWhitespace())
            {
              if (flag2 && chunk.Content.StartsWith("."))
                ((List<IElement>) currentParagraph)[((List<IElement>) currentParagraph).Count - 1] = (IElement) new Chunk(' ', chunk.Font);
              flag2 = chunk.IsWhitespace();
            }
            else
              continue;
          }
        }
        else
          continue;
      }
      else
      {
        flag1 = false;
        flag2 = false;
      }
      Paragraph paragraph = this.ProcessTextElement(textElement, currentParagraph, f1, f2);
      if (paragraph != null)
        currentParagraph = paragraph;
    }
    if (((List<IElement>) currentParagraph).Count == 0 && (double) this.flattenerContext.XfaVersion == 2.5999999046325684 && TextDrawer.GetXFAApiVersion(currentParagraph) == null)
      this.ProcessTextElement((IElement) new Chunk("\n"), currentParagraph, f1, f2);
    return currentParagraph;
  }

  public virtual void ApplyParagraphStyles(Paragraph p)
  {
    Dictionary<string, string> dictionary = (Dictionary<string, string>) null;
    if (p is XFAParagraph)
      dictionary = ((XFAParagraph) p).UserStyles;
    if (dictionary == null)
      dictionary = new Dictionary<string, string>();
    string str1;
    if (!dictionary.TryGetValue("xfa-tab-stops", out str1))
      dictionary.TryGetValue("tab-stops", out str1);
    string str2 = (string) null;
    dictionary.TryGetValue("tab-interval", out str2);
    XFALocale locale = this.flattenerContext.LocaleResolver.GetLocale(this.parentNode.GetStringProperty("locale"));
    IFormNode formNode = this.parentNode.RetrieveChild("para");
    if (formNode != null)
    {
      IFormNode hyphenationNode = formNode.RetrieveChild("hyphenation");
      if (hyphenationNode != null && !"0".Equals(hyphenationNode.RetrieveAttribute("hyphenate")))
      {
        XFAHyphenation xfaHyphenation = new XFAHyphenation(locale, hyphenationNode, this.flattenerContext);
        ((Phrase) p).Hyphenation = (IHyphenationEvent) xfaHyphenation;
        foreach (Chunk chunk in (IEnumerable<Chunk>) ((Phrase) p).Chunks)
          chunk.SetHyphenation((IHyphenationEvent) xfaHyphenation);
      }
    }
    foreach (Chunk chunk in (IEnumerable<Chunk>) ((Phrase) p).Chunks)
    {
      if (chunk.Content.Contains("\u00AD"))
        chunk.SetHyphenation((IHyphenationEvent) new XFAHyphenation());
    }
    if (formNode != null)
    {
      if (p.Alignment == -1)
      {
        object obj = (object) formNode.RetrieveAttribute("hAlign");
        if ("center".Equals(obj))
          p.Alignment = 1;
        else if ("right".Equals(obj))
          p.Alignment = 2;
        else if ("justify".Equals(obj))
          p.Alignment = 3;
        else if ("justifyAll".Equals(obj))
          p.Alignment = 8;
      }
      if (!dictionary.ContainsKey("line-height") && (!((Phrase) p).HasLeading() || (double) ((Phrase) p).Leading == 0.0 && (double) Math.Abs(((Phrase) p).MultipliedLeading - 1.2f) < 9.9999997473787516E-05))
      {
        string str3 = formNode.RetrieveAttribute("lineHeight");
        if (str3 != null && str3.Length != 0)
        {
          float pxInCmMmPcToPt = CssUtils.GetInstance().ParsePxInCmMmPcToPt(str3, "pt");
          if ((double) pxInCmMmPcToPt > 0.00050000002374872565)
            ((Phrase) p).Leading = pxInCmMmPcToPt;
        }
      }
      if (!dictionary.ContainsKey("text-indent"))
      {
        string str4 = formNode.RetrieveAttribute("textIndent");
        if (str4 != null && str4.Length != 0)
        {
          float pxInCmMmPcToPt = CssUtils.GetInstance().ParsePxInCmMmPcToPt(str4, "pt");
          if ((double) pxInCmMmPcToPt > 0.0)
            p.FirstLineIndent = pxInCmMmPcToPt;
          else if ((double) pxInCmMmPcToPt < 0.0)
          {
            p.IndentationLeft += Math.Abs(pxInCmMmPcToPt);
            p.FirstLineIndent = pxInCmMmPcToPt;
          }
        }
      }
      if (!dictionary.ContainsKey("margin-left"))
      {
        string str5 = formNode.RetrieveAttribute("marginLeft");
        if (str5 != null && str5.Length != 0)
        {
          float pxInCmMmPcToPt = CssUtils.GetInstance().ParsePxInCmMmPcToPt(str5, "pt");
          if (!this.isRTL)
            p.IndentationLeft += pxInCmMmPcToPt;
          else
            p.IndentationRight += pxInCmMmPcToPt;
        }
      }
      if (!dictionary.ContainsKey("margin-right"))
      {
        string str6 = formNode.RetrieveAttribute("marginRight");
        if (str6 != null && str6.Length != 0)
        {
          float pxInCmMmPcToPt = CssUtils.GetInstance().ParsePxInCmMmPcToPt(str6, "pt");
          if (!this.isRTL)
            p.IndentationRight += pxInCmMmPcToPt;
          else
            p.IndentationLeft += pxInCmMmPcToPt;
        }
      }
      if (!dictionary.ContainsKey("margin-top"))
      {
        string str7 = formNode.RetrieveAttribute("spaceAbove");
        if (str7 != null && str7.Length != 0)
        {
          float pxInCmMmPcToPt = CssUtils.GetInstance().ParsePxInCmMmPcToPt(str7, "pt");
          p.SpacingBefore += pxInCmMmPcToPt;
        }
      }
      if (!dictionary.ContainsKey("margin-bottom"))
      {
        string str8 = formNode.RetrieveAttribute("spaceBelow");
        if (str8 != null && str8.Length != 0)
        {
          float pxInCmMmPcToPt = CssUtils.GetInstance().ParsePxInCmMmPcToPt(str8, "pt");
          p.SpacingAfter += pxInCmMmPcToPt;
        }
      }
    }
    if (this.isRTL)
    {
      switch (p.Alignment)
      {
        case 1:
        case 3:
        case 8:
          break;
        case 2:
          p.Alignment = 0;
          break;
        default:
          p.Alignment = 2;
          break;
      }
    }
    if (dictionary.ContainsKey("text-valign"))
    {
      string str9 = dictionary["text-valign"];
      if ("middle".Equals(str9))
        this.verticalAlignment = 1;
      else if ("bottom".Equals(str9))
        this.verticalAlignment = 2;
    }
    if (this.isRTL)
    {
      float? nullable1 = new float?();
      if (dictionary.ContainsKey("margin-left"))
      {
        string str10;
        dictionary.TryGetValue("margin-left", out str10);
        if (!string.IsNullOrEmpty(str10))
        {
          nullable1 = new float?(CssUtils.GetInstance().ParsePxInCmMmPcToPt(str10, "pt"));
          p.IndentationLeft -= nullable1.Value;
        }
      }
      float? nullable2 = new float?();
      if (dictionary.ContainsKey("margin-right"))
      {
        string str11;
        dictionary.TryGetValue("margin-right", out str11);
        if (!string.IsNullOrEmpty(str11))
        {
          nullable2 = new float?(CssUtils.GetInstance().ParsePxInCmMmPcToPt(str11, "pt"));
          p.IndentationRight -= nullable2.Value;
        }
      }
      if (nullable1.HasValue)
        p.IndentationRight += nullable1.Value;
      if (nullable2.HasValue)
        p.IndentationLeft += nullable2.Value;
    }
    if (!((Phrase) p).HasLeading())
      ((Phrase) p).MultipliedLeading = 1.2f;
    TabSettings tabSettings = (TabSettings) null;
    if (str2 != null)
      tabSettings = new TabSettings(CssUtils.GetInstance().ParsePxInCmMmPcToPt(str2));
    if (str1 != null)
    {
      string[] strArray = str1.Split(' ');
      List<TabStop> tabStopList = new List<TabStop>();
      for (int index = 0; index < strArray.Length / 2; ++index)
      {
        string str12 = strArray[index * 2];
        char ch = '.';
        TabStop.Alignment alignment;
        if (Util.EqualsIgnoreCase("left", str12) || Util.EqualsIgnoreCase("after", str12))
          alignment = (TabStop.Alignment) 0;
        else if (Util.EqualsIgnoreCase("right", str12) || Util.EqualsIgnoreCase("before", str12))
          alignment = (TabStop.Alignment) 1;
        else if (Util.EqualsIgnoreCase("center", str12))
          alignment = (TabStop.Alignment) 2;
        else if (Util.EqualsIgnoreCase("decimal", str12))
        {
          alignment = (TabStop.Alignment) 3;
          ch = locale.NumberFormatInfo.NumberDecimalSeparator[0];
        }
        else
          break;
        string str13 = strArray[index * 2 + 1];
        float pxInCmMmPcToPt = CssUtils.GetInstance().ParsePxInCmMmPcToPt(str13);
        tabStopList.Add(new TabStop(pxInCmMmPcToPt, alignment, ch));
      }
      if (tabSettings != null)
      {
        tabSettings.TabStops = tabStopList;
        ((Phrase) p).TabSettings = tabSettings;
      }
      else
        ((Phrase) p).TabSettings = new TabSettings(tabStopList, 36f);
    }
    else
    {
      if (tabSettings == null)
        return;
      ((Phrase) p).TabSettings = tabSettings;
    }
  }

  private void ApplyContainerStyles()
  {
    if (this.verticalAlignment != -1)
      return;
    IFormNode formNode = this.parentNode.RetrieveChild("para");
    if (this.verticalAlignment != -1 || formNode == null)
      return;
    this.verticalAlignment = 0;
    string str = formNode.RetrieveAttribute("vAlign");
    if ("middle".Equals(str))
    {
      this.verticalAlignment = 1;
    }
    else
    {
      if (!"bottom".Equals(str))
        return;
      this.verticalAlignment = 2;
    }
  }

  private void CheckForUnderlineAndLineThrough(Chunk c)
  {
    IFormNode formNode = this.parentNode.RetrieveChild("font");
    if (formNode == null && this.parentNode is CaptionElement && this.parentNode.Parent != null)
      formNode = ((JsNode) this.parentNode.Parent).RetrieveChild("font");
    if (formNode != null && (c.Attributes == null || !c.Attributes.ContainsKey("CHAR_SPACING")))
    {
      string str = formNode.RetrieveAttribute("letterSpacing");
      if (str != null)
      {
        float num = !CssUtils.GetInstance().IsRelativeValue(str) ? CssUtils.GetInstance().ParsePxInCmMmPcToPt(str) : CssUtils.GetInstance().ParseRelativeValue(str, c.Font.Size);
        if ((double) num != 0.0)
          c.SetCharacterSpacing(num);
      }
    }
    if (c.Attributes != null && c.Attributes.ContainsKey("UNDERLINE"))
    {
      if (c.Attributes["UNDERLINE"] != null)
        return;
      c.Attributes.Remove("UNDERLINE");
    }
    else
    {
      if (formNode == null)
        return;
      if ("1".Equals(formNode.RetrieveAttribute("underline")))
        c.SetUnderline(0.75f, (float) (-(double) c.Font.Size / 8.0));
      if ("1".Equals(formNode.RetrieveAttribute("lineThrough")))
        c.SetUnderline(0.3f, c.Font.Size / 3f);
      string s = formNode.RetrieveAttribute("fontHorizontalScale");
      if (s == null || "100%".Equals(s))
        return;
      float? percent = XFAUtil.ParsePercent(s);
      if (!percent.HasValue)
        return;
      c.SetHorizontalScaling(percent.Value / 100f);
    }
  }

  private XFAParagraph GetEmpty()
  {
    XFAParagraph empty = new XFAParagraph();
    ((Phrase) empty).Add("");
    ((Phrase) empty).Chunks[0].Role = (PdfName) null;
    empty.Role = (PdfName) null;
    return empty;
  }

  private bool IsRightToLeft(string text)
  {
    return new Regex("\\p{IsArabic}|\\p{IsHebrew}|\\p{IsSyriac}|\\p{IsThaana}").Match(text).Success;
  }

  private bool IsRightToLeft(Chunk chunk) => this.IsRightToLeft(chunk.ToString());

  private bool IsRightToLeft(Paragraph paragraph)
  {
    foreach (Chunk chunk in (IEnumerable<Chunk>) ((Phrase) paragraph).Chunks)
    {
      if (this.IsRightToLeft(chunk))
        return true;
    }
    return false;
  }

  private bool IsRightToLeft(IList<IElement> elementList)
  {
    foreach (IElement element in (IEnumerable<IElement>) elementList)
    {
      foreach (Chunk chunk in (IEnumerable<Chunk>) element.Chunks)
      {
        if (this.IsRightToLeft(chunk))
          return true;
      }
    }
    return false;
  }

  public virtual bool AutoSize => this.isAutoSize;

  public virtual float AutoSizeLimit
  {
    get => this.autoSizeLimit;
    set => this.autoSizeLimit = value;
  }

  private static string GetXFAApiVersion(Paragraph paragraph)
  {
    return paragraph is XFAParagraph ? ((XFAParagraph) paragraph).GetApiVersion() : (string) null;
  }
}
