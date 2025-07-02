// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.element.BarcodeDrawer
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.interfaces;
using iTextSharp.text.pdf.qrcode;
using iTextSharp.tool.xml.css;
using iTextSharp.tool.xml.xtra.xfa.util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.util;
using System.util.zlib;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.element;

public class BarcodeDrawer : AbstractDrawer
{
  public static string CODE128 = "code128";
  public static string CODE128A = "code128a";
  public static string CODE128B = "code128b";
  public static string CODE128C = "code128c";
  public static string PDF417 = "pdf417";
  public static string CODE30F9 = "code3Of9";
  public static string CODE30F9EXT = "code3Of9extended";
  public static string CODE2OF5INTER = "code2of5interleaved";
  public static string QRCODE = "QRCode";
  public static string DATA_MATRIX = "dataMatrix";
  private BaseColor barcodeColor = BaseColor.BLACK;
  private BaseColor textColor = BaseColor.BLACK;
  protected Barcode barcode;
  protected BarcodePDF417 pdf417Barcode;
  protected BarcodeQRCode qrBarcode;
  protected BarcodeDatamatrix datamatrixBarcode;
  protected float width;
  protected static float DEFAULT_MODULE_HEIGHT = CssUtils.GetInstance().ParsePxInCmMmPcToPt("5mm");
  protected static float DEFAULT_MODULE_WIDTH = CssUtils.GetInstance().ParsePxInCmMmPcToPt("0.25mm");
  protected float moduleHeight = BarcodeDrawer.DEFAULT_MODULE_HEIGHT;
  protected float moduleWidth = BarcodeDrawer.DEFAULT_MODULE_WIDTH;
  private int? errorCorrectionLevel = new int?();

  public BarcodeDrawer(IDictionary<string, string> attributes, string code, float width)
  {
    this.width = width;
    code = code.Replace("￼", "\t");
    string str1 = "";
    float? nullable1 = new float?();
    float? nullable2 = new float?(3f);
    string str2 = (string) null;
    if (attributes != null)
    {
      attributes.TryGetValue("type", out str1);
      attributes.TryGetValue("checksum", out str2);
      string s1;
      attributes.TryGetValue(nameof (errorCorrectionLevel), out s1);
      this.errorCorrectionLevel = XFAUtil.ParseInt(s1);
      string s2;
      if (attributes.TryGetValue("dataLength", out s2) && !string.IsNullOrEmpty(s2))
        nullable1 = XFAUtil.ParseFloat(s2);
      string str3;
      if (attributes.TryGetValue(nameof (moduleHeight), out str3))
        this.moduleHeight = CssUtils.GetInstance().ParsePxInCmMmPcToPt(str3);
      string str4;
      if (attributes.TryGetValue(nameof (moduleWidth), out str4))
        this.moduleWidth = CssUtils.GetInstance().ParsePxInCmMmPcToPt(str4);
      string s3;
      if (attributes.TryGetValue("wideNarrowRatio", out s3))
      {
        if (!string.IsNullOrEmpty(s3))
        {
          try
          {
            if (s3.Contains(":"))
            {
              string[] strArray = s3.Split(':');
              if (strArray.Length == 2)
              {
                float? nullable3 = XFAUtil.ParseFloat(strArray[0]);
                float? nullable4 = XFAUtil.ParseFloat(strArray[1]);
                if (nullable3.HasValue)
                {
                  float? nullable5 = nullable3;
                  if (((double) nullable5.GetValueOrDefault() <= 0.0 ? 0 : (nullable5.HasValue ? 1 : 0)) != 0)
                  {
                    if (nullable4.HasValue)
                    {
                      float? nullable6 = nullable4;
                      if (((double) nullable6.GetValueOrDefault() <= 0.0 ? 0 : (nullable6.HasValue ? 1 : 0)) != 0)
                      {
                        float? nullable7 = nullable3;
                        float? nullable8 = nullable4;
                        nullable2 = nullable7.HasValue & nullable8.HasValue ? new float?(nullable7.GetValueOrDefault() / nullable8.GetValueOrDefault()) : new float?();
                      }
                    }
                  }
                }
              }
            }
            else
            {
              nullable2 = XFAUtil.ParseFloat(s3);
              if (nullable2.HasValue)
              {
                float? nullable9 = nullable2;
                if (((double) nullable9.GetValueOrDefault() > 0.0 ? 0 : (nullable9.HasValue ? 1 : 0)) == 0)
                  goto label_20;
              }
              nullable2 = new float?(3f);
            }
          }
          catch (Exception ex)
          {
            nullable2 = new float?(3f);
          }
        }
      }
    }
label_20:
    if (Util.EqualsIgnoreCase(str1, BarcodeDrawer.PDF417))
    {
      if (code.Length > 0)
      {
        byte[] numArray = Encoding.UTF8.GetBytes(code);
        string str5 = (string) null;
        attributes?.TryGetValue("dataPrep", out str5);
        this.pdf417Barcode = new BarcodePDF417();
        if (this.errorCorrectionLevel.HasValue)
        {
          this.pdf417Barcode.Options |= 16 /*0x10*/;
          this.pdf417Barcode.ErrorLevel = this.errorCorrectionLevel.Value;
        }
        if ("flateCompress".Equals(str5))
        {
          MemoryStream memoryStream = new MemoryStream();
          ZDeflaterOutputStream zdeflaterOutputStream = new ZDeflaterOutputStream((Stream) memoryStream);
          new MemoryStream(numArray).WriteTo((Stream) zdeflaterOutputStream);
          zdeflaterOutputStream.Finish();
          long length = memoryStream.Length;
          byte[] buffer = memoryStream.GetBuffer();
          numArray = new byte[length + 2L];
          numArray[0] = (byte) 129;
          numArray[1] = (byte) 1;
          Array.Copy((Array) buffer, 0L, (Array) numArray, 2L, length);
        }
        this.pdf417Barcode.Text = numArray;
      }
    }
    else if (Util.EqualsIgnoreCase(BarcodeDrawer.QRCODE, str1))
    {
      ErrorCorrectionLevel errorCorrectionLevel1 = (ErrorCorrectionLevel) null;
      if (this.errorCorrectionLevel.HasValue)
      {
        int? errorCorrectionLevel2 = this.errorCorrectionLevel;
        ref int? local = ref errorCorrectionLevel2;
        int valueOrDefault = local.GetValueOrDefault();
        if (local.HasValue)
        {
          switch (valueOrDefault)
          {
            case 0:
              errorCorrectionLevel1 = ErrorCorrectionLevel.L;
              break;
            case 1:
              errorCorrectionLevel1 = ErrorCorrectionLevel.M;
              break;
            case 2:
              errorCorrectionLevel1 = ErrorCorrectionLevel.Q;
              break;
            case 3:
              errorCorrectionLevel1 = ErrorCorrectionLevel.H;
              break;
          }
        }
      }
      IDictionary<EncodeHintType, object> dictionary = (IDictionary<EncodeHintType, object>) new Dictionary<EncodeHintType, object>();
      if (errorCorrectionLevel1 != null)
        dictionary.Add(EncodeHintType.ERROR_CORRECTION, (object) errorCorrectionLevel1);
      if (code != null && code.Length != 0)
        this.qrBarcode = new BarcodeQRCode(code, 1, 1, dictionary);
    }
    else if (Util.EqualsIgnoreCase(str1, BarcodeDrawer.DATA_MATRIX))
    {
      this.datamatrixBarcode = new BarcodeDatamatrix();
      this.datamatrixBarcode.ForceSquareSize = true;
      this.datamatrixBarcode.Generate(code);
    }
    else if (Util.EqualsIgnoreCase(str1, BarcodeDrawer.CODE128) || Util.EqualsIgnoreCase(str1, BarcodeDrawer.CODE128A) || Util.EqualsIgnoreCase(str1, BarcodeDrawer.CODE128B) || Util.EqualsIgnoreCase(str1, BarcodeDrawer.CODE128C))
    {
      this.barcode = (Barcode) new Barcode128();
      string str6 = str1.Substring(BarcodeDrawer.CODE128.Length);
      Barcode128.Barcode128CodeSet barcode128CodeSet = (Barcode128.Barcode128CodeSet) 1;
      if ("A".Equals(str6))
        barcode128CodeSet = (Barcode128.Barcode128CodeSet) 0;
      else if ("C".Equals(str6))
        barcode128CodeSet = (Barcode128.Barcode128CodeSet) 2;
      ((Barcode128) this.barcode).CodeSet = barcode128CodeSet;
      string str7 = code.Length != 0 ? code : "1";
      while (nullable1.HasValue)
      {
        float length = (float) str7.Length;
        float? nullable10 = nullable1;
        if (((double) length >= (double) nullable10.GetValueOrDefault() ? 0 : (nullable10.HasValue ? 1 : 0)) != 0)
          str7 += str7;
        else
          break;
      }
      if (nullable1.HasValue)
        str7 = str7.Substring(0, (int) nullable1.Value);
      this.barcode.Code = str7;
      this.barcode.X = this.barcode.X * width / this.barcode.BarcodeSize.Width;
    }
    else if (Util.EqualsIgnoreCase(str1, BarcodeDrawer.CODE30F9) || Util.EqualsIgnoreCase(str1, BarcodeDrawer.CODE30F9EXT))
    {
      this.barcode = (Barcode) new Barcode39();
      if (Util.EqualsIgnoreCase(str1, BarcodeDrawer.CODE30F9EXT))
      {
        this.barcode.Extended = true;
        try
        {
          Barcode39.GetCode39Ex(code);
        }
        catch (ArgumentException ex)
        {
          code = "";
        }
      }
      else
      {
        code = code.ToUpper();
        try
        {
          Barcode39.GetBarsCode39(code);
        }
        catch (ArgumentException ex)
        {
          code = "";
        }
      }
      float num = (float) ((nullable1.HasValue ? (double) nullable1.Value : (double) code.Length) + 2.0);
      if ("auto".Equals(str2))
      {
        this.barcode.GenerateChecksum = true;
        ++num;
      }
      this.barcode.X = width / (float) ((double) num * (6.0 + 3.0 * (double) nullable2.Value) + ((double) num - 1.0));
    }
    else if (Util.EqualsIgnoreCase(BarcodeDrawer.CODE2OF5INTER, str1))
    {
      this.barcode = (Barcode) new BarcodeInter25();
      float num1 = nullable1.HasValue ? nullable1.Value : (float) code.Length;
      Barcode barcode = this.barcode;
      double num2 = (double) width;
      float num3 = num1;
      float? nullable11 = nullable2;
      float? nullable12 = nullable11.HasValue ? new float?(2f * nullable11.GetValueOrDefault()) : new float?();
      float? nullable13 = nullable12.HasValue ? new float?(3f + nullable12.GetValueOrDefault()) : new float?();
      float? nullable14 = nullable13.HasValue ? new float?(num3 * nullable13.GetValueOrDefault()) : new float?();
      float? nullable15 = nullable14.HasValue ? new float?(nullable14.GetValueOrDefault() + 6f) : new float?();
      float? nullable16 = nullable2;
      double num4 = (double) (nullable15.HasValue & nullable16.HasValue ? new float?(nullable15.GetValueOrDefault() + nullable16.GetValueOrDefault()) : new float?()).Value;
      double num5 = num2 / num4;
      barcode.X = (float) num5;
    }
    else
      this.barcode = (Barcode) new Barcode128();
    if (this.barcode == null)
      return;
    if (code.Length > 1 && code.StartsWith("*") && code.EndsWith("*"))
      code = code.Substring(1, code.Length - 2);
    if (code.Length == 0)
    {
      this.barcode = (Barcode) null;
    }
    else
    {
      this.barcode.Code = code;
      this.barcode.N = nullable2.Value;
      this.barcode.Font = (BaseFont) null;
    }
  }

  public virtual float BarcodeWidth
  {
    get
    {
      if (this.barcode != null)
        return this.barcode.BarcodeSize.Width;
      if (this.pdf417Barcode != null)
        return this.pdf417Barcode.GetBarcodeSize().Width * this.moduleWidth;
      if (this.qrBarcode != null)
        return this.qrBarcode.GetBarcodeSize().Width * this.moduleWidth;
      return this.datamatrixBarcode != null ? (float) this.datamatrixBarcode.Width * this.moduleWidth : 0.0f;
    }
  }

  public virtual float BarcodeHeight
  {
    get
    {
      if (this.barcode != null)
        return this.barcode.BarcodeSize.Height;
      if (this.pdf417Barcode != null)
        return this.pdf417Barcode.GetBarcodeSize().Height * this.moduleHeight;
      if (this.qrBarcode != null)
        return this.qrBarcode.GetBarcodeSize().Height * this.moduleWidth;
      return this.datamatrixBarcode != null ? (float) this.datamatrixBarcode.Height * this.moduleHeight : 0.0f;
    }
  }

  public virtual float BarHeight
  {
    set
    {
      if (this.barcode != null)
        this.barcode.BarHeight = value;
      else if (this.pdf417Barcode != null)
      {
        float num = 6f;
        value -= num;
        this.pdf417Barcode.Options |= 2;
        this.pdf417Barcode.CodeColumns = (int) ((double) this.width / (double) this.moduleWidth) / 17 - 4;
        this.moduleHeight = value / this.pdf417Barcode.GetBarcodeSize().Height;
        if ((double) this.moduleHeight <= (double) this.moduleWidth * 15.0)
          return;
        this.moduleHeight = BarcodeDrawer.DEFAULT_MODULE_HEIGHT;
        this.pdf417Barcode.Options = this.pdf417Barcode.Options & -3 | 4;
        this.pdf417Barcode.CodeRows = (int) ((double) value / (double) this.moduleHeight);
        this.moduleWidth = this.width / this.pdf417Barcode.GetBarcodeSize().Width;
      }
      else if (this.qrBarcode != null)
      {
        this.moduleWidth = Math.Min(this.moduleWidth, this.width / this.qrBarcode.GetBarcodeSize().Width);
      }
      else
      {
        if (this.datamatrixBarcode == null)
          return;
        this.moduleWidth = Math.Min(this.moduleWidth, this.width / (float) this.datamatrixBarcode.Width);
      }
    }
  }

  public override void Draw(PdfContentByte canvas, XFARectangle borderArea)
  {
    if (this.barcode != null)
    {
      if (canvas.IsTagged())
        canvas.OpenMCBlock((IAccessibleElement) this);
      this.barcode.PlaceBarcode(canvas, this.barcodeColor, this.textColor);
      if (!canvas.IsTagged())
        return;
      canvas.CloseMCBlock((IAccessibleElement) this);
    }
    else if (this.pdf417Barcode != null)
    {
      if (canvas.IsTagged())
        canvas.OpenMCBlock((IAccessibleElement) this);
      this.pdf417Barcode.PlaceBarcode(canvas, this.barcodeColor, this.moduleHeight, this.moduleWidth);
      if (!canvas.IsTagged())
        return;
      canvas.CloseMCBlock((IAccessibleElement) this);
    }
    else if (this.qrBarcode != null)
    {
      if (canvas.IsTagged())
        canvas.OpenMCBlock((IAccessibleElement) this);
      this.qrBarcode.PlaceBarcode(canvas, this.barcodeColor, this.moduleWidth);
      if (!canvas.IsTagged())
        return;
      canvas.CloseMCBlock((IAccessibleElement) this);
    }
    else
    {
      if (this.datamatrixBarcode == null)
        return;
      if (canvas.IsTagged())
        canvas.OpenMCBlock((IAccessibleElement) this);
      this.datamatrixBarcode.PlaceBarcode(canvas, this.barcodeColor, this.moduleHeight, this.moduleWidth);
      if (!canvas.IsTagged())
        return;
      canvas.CloseMCBlock((IAccessibleElement) this);
    }
  }

  public override bool IsEmpty()
  {
    return this.barcode == null && this.pdf417Barcode == null && this.qrBarcode == null && this.datamatrixBarcode == null;
  }

  public virtual bool BarcodeHasTextOnIt
  {
    get => this.pdf417Barcode == null && this.qrBarcode == null && this.datamatrixBarcode == null;
  }
}
