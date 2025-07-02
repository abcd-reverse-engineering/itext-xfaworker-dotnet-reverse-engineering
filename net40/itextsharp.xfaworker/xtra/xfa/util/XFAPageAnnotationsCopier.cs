// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.util.XFAPageAnnotationsCopier
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.awt.geom;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.util;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.util;

public class XFAPageAnnotationsCopier
{
  private IDictionary<RefKey, XFAPageAnnotationsCopier.IndirectReferences> indirects = (IDictionary<RefKey, XFAPageAnnotationsCopier.IndirectReferences>) new Dictionary<RefKey, XFAPageAnnotationsCopier.IndirectReferences>();
  private PdfWriter writer;
  private bool flatten;
  private static HashSet<PdfName> supportedAnnotationTypes = new HashSet<PdfName>()
  {
    PdfName.LINE
  };

  public XFAPageAnnotationsCopier(PdfWriter writer, bool flatten)
  {
    this.writer = writer;
    this.flatten = flatten;
  }

  public void CopySupportedAnnotations(PdfReader reader, int pageNum)
  {
    PdfDictionary pageN = reader.GetPageN(pageNum);
    PdfObject pdfObject1 = PdfReader.GetPdfObject(pageN.Get(PdfName.ANNOTS), (PdfObject) pageN);
    if (pdfObject1 == null || !pdfObject1.IsArray())
      return;
    PdfArray origPageAnnots = (PdfArray) pdfObject1;
    IList<PdfIndirectReference> annotsToCopy = (IList<PdfIndirectReference>) new List<PdfIndirectReference>();
    for (int index = 0; index < origPageAnnots.Size; ++index)
    {
      PdfIndirectReference asIndirectObject = origPageAnnots.GetAsIndirectObject(index);
      if (asIndirectObject != null)
      {
        PdfObject pdfObject2 = PdfReader.GetPdfObject((PdfObject) asIndirectObject);
        if (pdfObject2 != null && pdfObject2.IsDictionary())
        {
          PdfName asName = ((PdfDictionary) pdfObject2).GetAsName(PdfName.SUBTYPE);
          if (XFAPageAnnotationsCopier.supportedAnnotationTypes.Contains(asName))
            annotsToCopy.Add(asIndirectObject);
        }
      }
    }
    if (annotsToCopy.Count == 0)
      return;
    if (this.flatten)
      this.FlattenAnnots(annotsToCopy);
    else
      this.CopyAnnots(pageNum, origPageAnnots, annotsToCopy);
  }

  private void CopyAnnots(
    int pageNum,
    PdfArray origPageAnnots,
    IList<PdfIndirectReference> annotsToCopy)
  {
    IDictionary<RefKey, PdfDictionary> dictionary = (IDictionary<RefKey, PdfDictionary>) new Dictionary<RefKey, PdfDictionary>();
    for (int index = 0; index < annotsToCopy.Count; ++index)
    {
      try
      {
        PdfIndirectReference indirectReference = annotsToCopy[index];
        PdfDictionary pdfDictionary = this.CopyDictionary((PdfDictionary) PdfReader.GetPdfObject((PdfObject) indirectReference), true);
        PdfNumber asNumber = pdfDictionary.GetAsNumber(PdfName.F);
        int num1 = 0;
        if (asNumber != null)
          num1 = asNumber.IntValue;
        int num2 = num1 | 4;
        pdfDictionary.Put(PdfName.F, (PdfObject) new PdfNumber(num2));
        dictionary[new RefKey(indirectReference)] = pdfDictionary;
      }
      catch (IOException ex)
      {
      }
      catch (BadPdfFormatException ex)
      {
      }
    }
    PdfArray pdfArray = new PdfArray();
    PdfIndirectReference pageReference = this.writer.GetPageReference(pageNum);
    for (int index = 0; index < origPageAnnots.Size; ++index)
    {
      PdfIndirectReference asIndirectObject1 = origPageAnnots.GetAsIndirectObject(index);
      if (asIndirectObject1 != null)
      {
        PdfObject pdfObject = PdfReader.GetPdfObject((PdfObject) asIndirectObject1);
        if (pdfObject != null && pdfObject.IsDictionary())
        {
          PdfDictionary pdfDictionary1 = (PdfDictionary) pdfObject;
          PdfName asName = pdfDictionary1.GetAsName(PdfName.SUBTYPE);
          if (PdfName.POPUP.Equals((object) asName))
          {
            PdfIndirectReference asIndirectObject2 = pdfDictionary1.GetAsIndirectObject(PdfName.PARENT);
            PdfDictionary pdfDictionary2;
            dictionary.TryGetValue(new RefKey(asIndirectObject2), out pdfDictionary2);
            if (pdfDictionary2 != null)
            {
              PdfDictionary pdfDictionary3 = (PdfDictionary) null;
              try
              {
                pdfDictionary3 = this.CopyDictionary(pdfDictionary1, true);
              }
              catch (IOException ex)
              {
              }
              catch (BadPdfFormatException ex)
              {
              }
              if (pdfDictionary3 != null)
              {
                PdfIndirectReference indirectReference1 = this.writer.PdfIndirectReference;
                PdfIndirectReference indirectReference2 = this.writer.PdfIndirectReference;
                pdfDictionary3.Put(PdfName.PARENT, (PdfObject) indirectReference2);
                pdfDictionary2.Put(PdfName.POPUP, (PdfObject) indirectReference1);
                pdfDictionary3.Put(PdfName.P, (PdfObject) pageReference);
                pdfDictionary2.Put(PdfName.P, (PdfObject) pageReference);
                dictionary.Remove(new RefKey(asIndirectObject2));
                try
                {
                  this.writer.AddToBody((PdfObject) pdfDictionary2, indirectReference2);
                  this.writer.AddToBody((PdfObject) pdfDictionary3, indirectReference1);
                  pdfArray.Add((PdfObject) indirectReference2);
                  pdfArray.Add((PdfObject) indirectReference1);
                }
                catch (IOException ex)
                {
                }
              }
            }
          }
        }
      }
    }
    foreach (PdfDictionary pdfDictionary in (IEnumerable<PdfDictionary>) dictionary.Values)
    {
      PdfIndirectReference indirectReference = this.writer.PdfIndirectReference;
      pdfDictionary.Put(PdfName.P, (PdfObject) pageReference);
      try
      {
        this.writer.AddToBody((PdfObject) pdfDictionary, indirectReference);
        pdfArray.Add((PdfObject) indirectReference);
      }
      catch (IOException ex)
      {
      }
    }
    this.writer.AddPageDictEntry(PdfName.ANNOTS, (PdfObject) pdfArray);
  }

  private void FlattenAnnots(IList<PdfIndirectReference> annotsToCopy)
  {
    for (int index = 0; index < annotsToCopy.Count; ++index)
    {
      try
      {
        PdfDictionary pdfObject1 = (PdfDictionary) PdfReader.GetPdfObject((PdfObject) annotsToCopy[index]);
        PdfNumber asNumber = pdfObject1.GetAsNumber(PdfName.F);
        int intValue = asNumber != null ? asNumber.IntValue : 0;
        if ((intValue & 4) != 0)
        {
          if ((intValue & 2) == 0)
          {
            PdfObject pdfObject2 = pdfObject1.Get(PdfName.AP);
            if (pdfObject2 != null)
            {
              PdfObject pdfObject3 = (pdfObject2 is PdfIndirectReference ? (PdfDictionary) PdfReader.GetPdfObject(pdfObject2) : (PdfDictionary) pdfObject2).Get(PdfName.N);
              if (pdfObject3.IsIndirect())
                pdfObject3 = PdfReader.GetPdfObject(pdfObject3);
              PdfStream inObj = (PdfStream) null;
              if (pdfObject3.IsStream())
                inObj = (PdfStream) pdfObject3;
              else if (pdfObject3.IsDictionary())
              {
                PdfName asName = pdfObject1.GetAsName(PdfName.AS);
                if (asName != null)
                {
                  PdfObject pdfObject4 = ((PdfDictionary) pdfObject3).Get(asName);
                  if (pdfObject4 is PdfIndirectReference)
                  {
                    PdfObject pdfObject5 = PdfReader.GetPdfObject(pdfObject4);
                    if (pdfObject5.IsStream())
                      inObj = (PdfStream) pdfObject5;
                  }
                }
              }
              if (inObj != null)
              {
                if (inObj is PRStream)
                {
                  PdfStream pdfStream = this.CopyStream((PRStream) inObj);
                  ((PdfDictionary) pdfStream).Put(PdfName.SUBTYPE, (PdfObject) PdfName.FORM);
                  Rectangle normalizedRectangle1 = PdfReader.GetNormalizedRectangle(pdfObject1.GetAsArray(PdfName.RECT));
                  Rectangle normalizedRectangle2 = PdfReader.GetNormalizedRectangle(((PdfDictionary) pdfStream).GetAsArray(PdfName.BBOX));
                  PdfContentByte directContent = this.writer.DirectContent;
                  if (((PdfDictionary) pdfStream).GetAsArray(PdfName.MATRIX) != null)
                  {
                    if (!Util.ArraysAreEqual<double>(new double[6]
                    {
                      1.0,
                      0.0,
                      0.0,
                      1.0,
                      0.0,
                      0.0
                    }, ((PdfDictionary) pdfStream).GetAsArray(PdfName.MATRIX).AsDoubleArray()))
                    {
                      double[] matrix = ((PdfDictionary) pdfStream).GetAsArray(PdfName.MATRIX).AsDoubleArray();
                      Rectangle rectangle = this.TransformBBoxByMatrix(normalizedRectangle2, matrix);
                      directContent.AddFormXObj(pdfStream, new PdfName("Annot_" + (object) index), normalizedRectangle1.Width / rectangle.Width, 0.0f, 0.0f, normalizedRectangle1.Height / rectangle.Height, normalizedRectangle1.Left, normalizedRectangle1.Bottom);
                      continue;
                    }
                  }
                  float num1 = -normalizedRectangle2.Bottom;
                  float num2 = -normalizedRectangle2.Left;
                  directContent.AddFormXObj(pdfStream, new PdfName("Annot_" + (object) index), normalizedRectangle1.Width / normalizedRectangle2.Width, 0.0f, 0.0f, normalizedRectangle1.Height / normalizedRectangle2.Height, normalizedRectangle1.Left + num2, normalizedRectangle1.Bottom + num1);
                }
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
      }
    }
  }

  private PdfDictionary CopyDictionary(PdfDictionary obj) => this.CopyDictionary(obj, false);

  private PdfDictionary CopyDictionary(PdfDictionary obj, bool isAnnotDict)
  {
    PdfDictionary pdfDictionary = new PdfDictionary(obj.Size);
    foreach (PdfName key in obj.Keys)
    {
      if (!isAnnotDict || !key.Equals((object) PdfName.P) && !key.Equals((object) PdfName.PARENT) && !key.Equals((object) PdfName.POPUP))
      {
        PdfObject pdfObject = this.CopyObject(obj.Get(key));
        if (pdfObject != null)
          pdfDictionary.Put(key, pdfObject);
      }
    }
    return pdfDictionary;
  }

  private PdfStream CopyStream(PRStream inObj)
  {
    PRStream prStream = new PRStream(inObj, (PdfDictionary) null);
    foreach (PdfName key in ((PdfDictionary) inObj).Keys)
    {
      PdfObject pdfObject = this.CopyObject(((PdfDictionary) inObj).Get(key));
      if (pdfObject != null)
        ((PdfDictionary) prStream).Put(key, pdfObject);
    }
    return (PdfStream) prStream;
  }

  private PdfArray CopyArray(PdfArray inObj)
  {
    PdfArray pdfArray = new PdfArray(inObj.Size);
    foreach (PdfObject inObj1 in inObj)
    {
      PdfObject pdfObject = this.CopyObject(inObj1);
      if (pdfObject != null)
        pdfArray.Add(pdfObject);
    }
    return pdfArray;
  }

  private PdfObject CopyObject(PdfObject inObj)
  {
    if (inObj == null)
      return (PdfObject) PdfNull.PDFNULL;
    switch (inObj.Type)
    {
      case 0:
      case 1:
      case 2:
      case 3:
      case 4:
      case 8:
        return inObj;
      case 5:
        return (PdfObject) this.CopyArray((PdfArray) inObj);
      case 6:
        return (PdfObject) this.CopyDictionary((PdfDictionary) inObj);
      case 7:
        return (PdfObject) this.CopyStream((PRStream) inObj);
      case 10:
        return (PdfObject) this.CopyIndirect((PRIndirectReference) inObj);
      default:
        if (inObj.Type >= 0)
          return (PdfObject) null;
        string str = ((PdfLiteral) inObj).ToString();
        return str.Equals("true") || str.Equals("false") ? (PdfObject) new PdfBoolean(str) : (PdfObject) new PdfLiteral(str);
    }
  }

  private PdfIndirectReference CopyIndirect(PRIndirectReference inObj)
  {
    RefKey key = new RefKey((PdfIndirectReference) inObj);
    XFAPageAnnotationsCopier.IndirectReferences indirectReferences;
    this.indirects.TryGetValue(key, out indirectReferences);
    PdfIndirectReference indirectReference;
    if (indirectReferences != null)
    {
      indirectReference = indirectReferences.GetRef();
      if (indirectReferences.GetCopied())
        return indirectReference;
    }
    else
    {
      indirectReference = this.writer.PdfIndirectReference;
      indirectReferences = new XFAPageAnnotationsCopier.IndirectReferences(indirectReference);
      this.indirects[key] = indirectReferences;
    }
    PdfObject pdfObject = this.CopyObject(PdfReader.GetPdfObjectRelease((PdfObject) inObj));
    indirectReferences.SetCopied();
    if (pdfObject != null)
    {
      this.writer.AddToBody(pdfObject, indirectReference);
      return indirectReference;
    }
    this.indirects.Remove(key);
    return (PdfIndirectReference) null;
  }

  private Rectangle TransformBBoxByMatrix(Rectangle bBox, double[] matrix)
  {
    float[] numArray1 = new float[4];
    float[] numArray2 = new float[4];
    Point point1 = this.TransformPoint((double) bBox.Left, (double) bBox.Bottom, matrix);
    numArray1[0] = (float) point1.x;
    numArray2[0] = (float) point1.y;
    Point point2 = this.TransformPoint((double) bBox.Right, (double) bBox.Top, matrix);
    numArray1[1] = (float) point2.x;
    numArray2[1] = (float) point2.y;
    Point point3 = this.TransformPoint((double) bBox.Left, (double) bBox.Top, matrix);
    numArray1[2] = (float) point3.x;
    numArray2[2] = (float) point3.y;
    Point point4 = this.TransformPoint((double) bBox.Right, (double) bBox.Bottom, matrix);
    numArray1[3] = (float) point4.x;
    numArray2[3] = (float) point4.y;
    return new Rectangle(Utilities.Min(numArray1), Utilities.Min(numArray2), Utilities.Max(numArray1), Utilities.Max(numArray2));
  }

  private Point TransformPoint(double x, double y, double[] matrix)
  {
    return new Point()
    {
      x = matrix[0] * x + matrix[2] * y + matrix[4],
      y = matrix[1] * x + matrix[3] * y + matrix[5]
    };
  }

  private class IndirectReferences
  {
    private PdfIndirectReference theRef;
    private bool hasCopied;

    internal IndirectReferences(PdfIndirectReference r)
    {
      this.theRef = r;
      this.hasCopied = false;
    }

    internal void SetCopied() => this.hasCopied = true;

    internal bool GetCopied() => this.hasCopied;

    internal PdfIndirectReference GetRef() => this.theRef;

    public override string ToString()
    {
      string str = "";
      if (this.hasCopied)
        str += " Copied";
      return this.GetRef().ToString() + str;
    }
  }
}
