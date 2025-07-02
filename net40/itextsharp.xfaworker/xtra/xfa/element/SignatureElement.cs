// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.element.SignatureElement
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml.xtra.xfa.bind;
using iTextSharp.tool.xml.xtra.xfa.resolver;
using iTextSharp.tool.xml.xtra.xfa.tags;
using iTextSharp.tool.xml.xtra.xfa.util;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.util.collections;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.element;

public class SignatureElement : UiElement
{
  private static HashSet2<char> charsToEscape;
  protected FlattenerContext flattenerContext;
  protected List<PRIndirectReference> copiedReferences;
  protected PdfWriter writer;

  public SignatureElement(
    IFormNode elementTag,
    XFARectangle elementRec,
    Document document,
    ContentElement contentElement,
    FlattenerContext flattenerContext)
    : base(elementTag, elementRec, document, contentElement)
  {
    this.flattenerContext = flattenerContext;
  }

  protected override bool IsTextWidget => true;

  public override PositionResult.State Draw(PdfContentByte canvas, XFARectangle parentBoundingBox)
  {
    string pattern = "";
    for (XFATemplateTag xfaTemplateTag = (XFATemplateTag) this.elementTag.RetrieveParent(); !"template".Equals(xfaTemplateTag.Name); xfaTemplateTag = (XFATemplateTag) xfaTemplateTag.Parent)
    {
      string dataRef = xfaTemplateTag.DataRef;
      if (dataRef != null)
      {
        string[] strArray = DataTreeResolver.SplitDataRefItem(dataRef);
        pattern = SignatureElement.RegExEscape($"{strArray[0]}[{strArray[1]}].") + pattern;
      }
      else if ("subform".Equals(xfaTemplateTag.Name))
        pattern = ".*\\." + pattern;
    }
    if (pattern.EndsWith("\\."))
      pattern = pattern.Substring(0, pattern.Length - 2);
    IDictionary<string, PdfDictionary> signatureFields = this.flattenerContext.GetSignatureFields();
    if (signatureFields != null && signatureFields.Count != 0 && this.flattenerContext.Reader != null)
    {
      PdfDictionary pdfDictionary = (PdfDictionary) null;
      foreach (KeyValuePair<string, PdfDictionary> keyValuePair in (IEnumerable<KeyValuePair<string, PdfDictionary>>) signatureFields)
      {
        if (Regex.IsMatch(keyValuePair.Key, pattern))
          pdfDictionary = keyValuePair.Value;
      }
      if (pdfDictionary != null)
      {
        PdfDictionary asDict = pdfDictionary.GetAsDict(PdfName.AP);
        if (asDict != null)
        {
          PdfStream asStream = asDict.GetAsStream(PdfName.N);
          if (asStream != null)
          {
            PdfArray asArray = ((PdfDictionary) asStream).GetAsArray(PdfName.BBOX);
            float num = 0.0f;
            try
            {
              num = asArray.GetAsNumber(3).FloatValue - asArray.GetAsNumber(1).FloatValue;
            }
            catch (Exception ex)
            {
            }
            this.writer = canvas.PdfWriter;
            PdfObject pdfObject = this.CopyObject((PdfObject) asStream);
            this.ApplyMargins(this.elementRec);
            canvas.AddFormXObj((PdfStream) pdfObject, new PdfName(pattern.Replace("\\", "")), 1f, 0.0f, 0.0f, 1f, this.elementRec.Llx.Value, this.elementRec.Ury.Value - num);
            this.UnapplyMargins(this.elementRec);
          }
        }
      }
    }
    return base.Draw(canvas, parentBoundingBox);
  }

  public override bool IsEmpty() => false;

  private static string RegExEscape(string source)
  {
    string str = "";
    for (int index = 0; index < source.Length; ++index)
    {
      char ch = source[index];
      str = !SignatureElement.charsToEscape.Contains(ch) ? str + (object) ch : str + (object) '\\' + (object) ch;
    }
    return str;
  }

  private PdfObject CopyObject(PdfObject @in)
  {
    if (@in == null)
      return (PdfObject) PdfNull.PDFNULL;
    switch (@in.Type)
    {
      case 0:
      case 1:
      case 2:
      case 3:
      case 4:
      case 8:
        return @in;
      case 5:
        return (PdfObject) this.CopyArray((PdfArray) @in);
      case 6:
        return (PdfObject) this.CopyDictionary((PdfDictionary) @in);
      case 7:
        return (PdfObject) this.CopyStream((PRStream) @in);
      case 10:
        return (PdfObject) this.CopyIndirect((PRIndirectReference) @in);
      default:
        if (@in.Type < 0)
        {
          string str = ((PdfLiteral) @in).ToString();
          return str.Equals("true") || str.Equals("false") ? (PdfObject) new PdfBoolean(str) : (PdfObject) new PdfLiteral(str);
        }
        Console.WriteLine("CANNOT COPY type " + (object) @in.Type);
        return (PdfObject) null;
    }
  }

  private PdfDictionary CopyDictionary(PdfDictionary @in)
  {
    PdfDictionary pdfDictionary = new PdfDictionary();
    foreach (PdfName key in @in.Keys)
    {
      PdfObject pdfObject = this.CopyObject(@in.Get(key));
      if (pdfObject != null)
        pdfDictionary.Put(key, pdfObject);
    }
    return pdfDictionary;
  }

  private PdfIndirectReference CopyIndirect(PRIndirectReference @in)
  {
    if (this.copiedReferences == null)
      this.copiedReferences = new List<PRIndirectReference>();
    if (this.copiedReferences.Contains(@in))
      return (PdfIndirectReference) @in;
    PdfIndirectReference indirectReference = this.writer.AddToBody(PdfReader.GetPdfObjectRelease((PdfObject) @in)).IndirectReference;
    this.copiedReferences.Add(@in);
    return indirectReference;
  }

  private PdfArray CopyArray(PdfArray @in)
  {
    PdfArray pdfArray = new PdfArray();
    foreach (PdfObject in1 in @in)
    {
      PdfObject pdfObject = this.CopyObject(in1);
      if (pdfObject != null)
        pdfArray.Add(pdfObject);
    }
    return pdfArray;
  }

  protected virtual PdfStream CopyStream(PRStream @in)
  {
    PRStream prStream = new PRStream(@in, (PdfDictionary) null);
    foreach (PdfName key in ((PdfDictionary) @in).Keys)
    {
      PdfObject pdfObject = this.CopyObject(((PdfDictionary) @in).Get(key));
      if (pdfObject != null)
        ((PdfDictionary) prStream).Put(key, pdfObject);
    }
    return (PdfStream) prStream;
  }

  static SignatureElement()
  {
    HashSet2<char> hashSet2 = new HashSet2<char>();
    hashSet2.Add('\\');
    hashSet2.Add('.');
    hashSet2.Add('[');
    hashSet2.Add(']');
    hashSet2.Add('{');
    hashSet2.Add('}');
    hashSet2.Add('(');
    hashSet2.Add(')');
    hashSet2.Add('*');
    hashSet2.Add('+');
    hashSet2.Add('-');
    hashSet2.Add('?');
    hashSet2.Add('^');
    hashSet2.Add('$');
    hashSet2.Add('|');
    SignatureElement.charsToEscape = hashSet2;
  }
}
