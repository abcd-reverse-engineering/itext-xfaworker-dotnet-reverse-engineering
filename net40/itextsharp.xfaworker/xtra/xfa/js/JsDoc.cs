// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.js.JsDoc
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.text.pdf;
using iTextSharp.tool.xml.xtra.xfa.resolver;
using Jint.Delegates;
using Jint.Native;
using System;
using System.Collections.Generic;
using System.Text;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.js;

public class JsDoc : JsObject
{
  private IGlobal global;
  private FlattenerContext flattenerContext;
  private IList<JsDataObject> jsDataObjects;
  private JsArray jsInfo;

  public JsDoc(IGlobal global, FlattenerContext flattenerContext)
  {
    this.flattenerContext = flattenerContext;
    this.global = global;
    this.DefineOwnProperty("getDataObject", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new JintFunc<JsDictionaryObject, JsInstance[], JsInstance>(this.GetDataObject), 1), PropertyAttributes.ReadOnly);
    this.DefineOwnProperty((Descriptor) new PropertyDescriptor<JsDoc>(global, (JsDictionaryObject) this, "dataObjects", new JintFunc<JsDoc, JsInstance>(this.GetDataObjects)));
    this.DefineOwnProperty((Descriptor) new PropertyDescriptor<JsDoc>(global, (JsDictionaryObject) this, "metadata", new JintFunc<JsDoc, JsInstance>(this.GetMetadata)));
    this.DefineOwnProperty((Descriptor) new PropertyDescriptor<JsDoc>(global, (JsDictionaryObject) this, "info", new JintFunc<JsDoc, JsInstance>(this.GetInfo)));
  }

  public JsDataObject GetDataObject(JsDictionaryObject target, JsInstance[] parameters)
  {
    string str = parameters[0].ToString();
    this.EnsureDataObjectsInited();
    foreach (JsDataObject jsDataObject in (IEnumerable<JsDataObject>) this.jsDataObjects)
    {
      if (jsDataObject["name"].Value.Equals((object) str))
        return jsDataObject;
    }
    throw new Exception("TypeError: Invalid argument type.");
  }

  public virtual JsObject GetDataObjects(JsDoc target)
  {
    this.EnsureDataObjectsInited();
    JsArray dataObjects = new JsArray(this.global.ArrayClass.PrototypeProperty);
    for (int index = 0; index < this.jsDataObjects.Count; ++index)
      dataObjects.put(index, (JsInstance) this.jsDataObjects[index]);
    return (JsObject) dataObjects;
  }

  public virtual JsInstance GetMetadata(JsDoc target)
  {
    return (JsInstance) this.global.Wrap((object) Encoding.UTF8.GetString(this.flattenerContext.Reader.Metadata));
  }

  public virtual JsArray GetInfo(JsDoc target)
  {
    if (this.jsInfo == null)
    {
      this.jsInfo = new JsArray(this.global.ArrayClass.PrototypeProperty);
      PdfReader reader = this.flattenerContext.Reader;
      if (reader != null)
      {
        foreach (KeyValuePair<string, string> keyValuePair in reader.Info)
          this.jsInfo.DefineOwnProperty(keyValuePair.Key, (JsInstance) this.global.Wrap((object) keyValuePair.Value), PropertyAttributes.DontEnum);
      }
    }
    return this.jsInfo;
  }

  private void EnsureDataObjectsInited()
  {
    if (this.jsDataObjects != null)
      return;
    this.jsDataObjects = (IList<JsDataObject>) new List<JsDataObject>();
    PdfReader reader = this.flattenerContext.Reader;
    if (reader == null)
      return;
    PdfDictionary asDict = reader.Catalog.GetAsDict(PdfName.NAMES);
    if (asDict == null)
      return;
    PdfObject pdfObject = PdfReader.GetPdfObject(asDict.Get(PdfName.EMBEDDEDFILES));
    if (pdfObject == null || !pdfObject.IsDictionary())
      return;
    this.ProcessEFNameTree((PdfDictionary) pdfObject);
  }

  private void ProcessEFNameTree(PdfDictionary embeddedFilesNameTreeRoot)
  {
    PdfObject pdfObject1 = PdfReader.GetPdfObject(embeddedFilesNameTreeRoot.Get(PdfName.KIDS));
    if (pdfObject1 != null && pdfObject1.IsArray())
    {
      foreach (PdfObject pdfObject2 in (PdfArray) pdfObject1)
      {
        PdfObject pdfObject3 = PdfReader.GetPdfObject(pdfObject2);
        if (pdfObject3 != null && pdfObject3.IsDictionary())
          this.ProcessEFNameTree((PdfDictionary) pdfObject3);
      }
    }
    else
      this.ProcessEFNameTreeLeafNode(embeddedFilesNameTreeRoot);
  }

  private void ProcessEFNameTreeLeafNode(PdfDictionary kidDict)
  {
    PdfObject pdfObject1 = PdfReader.GetPdfObject(kidDict.Get(PdfName.NAMES));
    if (pdfObject1 == null || !pdfObject1.IsArray())
      return;
    PdfArray pdfArray1 = (PdfArray) pdfObject1;
    int num1 = 0;
    while (num1 < pdfArray1.Size)
    {
      PdfArray pdfArray2 = pdfArray1;
      int num2 = num1;
      int num3 = num2 + 1;
      PdfString asString = pdfArray2.GetAsString(num2);
      PdfArray pdfArray3 = pdfArray1;
      int num4 = num3;
      num1 = num4 + 1;
      PdfObject pdfObject2 = PdfReader.GetPdfObject(pdfArray3.GetPdfObject(num4));
      if (pdfObject2 != null && pdfObject2.IsDictionary())
        this.jsDataObjects.Add(new JsDataObject(this.global, asString.ToUnicodeString(), (PdfDictionary) pdfObject2));
    }
  }
}
