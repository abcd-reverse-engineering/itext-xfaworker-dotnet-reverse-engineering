// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.positioner.FieldPositioner
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.text;
using iTextSharp.text.log;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using iTextSharp.tool.xml.xtra.xfa.bind;
using iTextSharp.tool.xml.xtra.xfa.element;
using iTextSharp.tool.xml.xtra.xfa.js;
using iTextSharp.tool.xml.xtra.xfa.pipe;
using iTextSharp.tool.xml.xtra.xfa.resolver;
using iTextSharp.tool.xml.xtra.xfa.tags;
using iTextSharp.tool.xml.xtra.xfa.util;
using Jint.Delegates;
using Jint.Native;
using System;
using System.Collections.Generic;
using System.Text;
using System.util;
using System.util.collections;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.positioner;

public class FieldPositioner : ContentPositioner
{
  private static readonly ILogger LOGGER = LoggerFactory.GetLogger(typeof (FieldPositioner));
  private IDictionary<string, JsContent> displayItemElements = (IDictionary<string, JsContent>) new Dictionary<string, JsContent>();
  private IList<string> boundItemValues = (IList<string>) new List<string>();

  internal FieldPositioner(string className, JsNode prototype)
    : base(className, prototype)
  {
    this.DefineProperty("clearItems", (object) this.IGlobal.FunctionClass.New<FieldPositioner>(new JintFunc<FieldPositioner, JsInstance[], JsInstance>(this.ClearItemsJsFunc)));
    this.DefineProperty("addItem", (object) this.IGlobal.FunctionClass.New<FieldPositioner>(new JintFunc<FieldPositioner, JsInstance[], JsInstance>(this.AddItemJsFunc)));
    this.DefineProperty("getDisplayItem", (object) this.IGlobal.FunctionClass.New<FieldPositioner>(new JintFunc<FieldPositioner, JsInstance[], JsInstance>(this.GetDisplayItemJsFunc)));
    this.DefineProperty("getSaveItem", (object) this.IGlobal.FunctionClass.New<FieldPositioner>(new JintFunc<FieldPositioner, JsInstance[], JsInstance>(this.GetSaveItemJsFunc)));
    this.DefineOwnProperty((Descriptor) new PropertyDescriptor<FieldPositioner>((Jint.Native.IGlobal) this.IGlobal, (JsDictionaryObject) this, "fontColor", new JintFunc<FieldPositioner, JsInstance>(this.FontColorGetJsProp), new JintFunc<FieldPositioner, JsInstance[], JsInstance>(this.FontColorSetJsProp)));
    this.DefineOwnProperty((Descriptor) new PropertyDescriptor<FieldPositioner>((Jint.Native.IGlobal) this.IGlobal, (JsDictionaryObject) this, "selectedIndex", new JintFunc<FieldPositioner, JsInstance>(this.SelectedIndexJsProp), new JintFunc<FieldPositioner, JsInstance[], JsInstance>(this.SelectedIndexJsPropSetter)));
    this.DefineOwnProperty((Descriptor) new PropertyDescriptor<FieldPositioner>((Jint.Native.IGlobal) this.IGlobal, (JsDictionaryObject) this, "length", new JintFunc<FieldPositioner, JsInstance>(this.LengthJsProp)));
  }

  public FieldPositioner(
    XFATemplateTag templateTag,
    DataTag dataTag,
    JsNode parent,
    FlattenerContext flattenerContext)
    : base(templateTag, dataTag, flattenerContext, parent, "field")
  {
  }

  public override void DefineOwnProperty(Descriptor currentDescriptor)
  {
    object rawValue = this.GetRawValue();
    base.DefineOwnProperty(currentDescriptor);
    if (!"rawValue".Equals(currentDescriptor.Name) || !(currentDescriptor is ValueDescriptor))
      return;
    this.PropagateValueToParentIfNeeded(currentDescriptor.Get((JsDictionaryObject) this).Value, rawValue);
  }

  public override JsInstance this[string name]
  {
    set
    {
      object rawValue = this.GetRawValue();
      base[name] = value;
      if (!"rawValue".Equals(name))
        return;
      this.PropagateValueToParentIfNeeded(value.Value, rawValue);
    }
  }

  protected override void PutCallback(string name, JsInstance value)
  {
    base.PutCallback(name, value);
    if (!"rawValue".Equals(name) || !(value is JsString) || !"".Equals(value.ToString()) || FormBuilder.IsNoneDataRef(this.template))
      return;
    this.DefineProperty("rawValue", (object) null);
  }

  public override bool IsBreakable
  {
    get
    {
      return (this.keepConditions == null || this.keepConditions != null && this.keepConditions.Intact.Equals("none")) && !(this.uiElement is BarcodeElement);
    }
  }

  public virtual void ClearItems()
  {
    if (this.HasOwnProperty("items"))
    {
      object property = this.GetProperty("items");
      if (property is JintJsNodeList)
      {
        this.Delete("items");
        JintJsNodeList nodes = this.GetNodes();
        for (int i = nodes.Length - 1; i >= 0; --i)
        {
          if (nodes.GetItem(i) == ((JsArray) property).get(0) || nodes.get(i) == ((JsArray) property).get(1))
            nodes.Delete(i.ToString());
        }
      }
    }
    this.boundItemValues.Clear();
    this.displayItemElements.Clear();
  }

  public virtual JsInstance ClearItemsJsFunc(FieldPositioner target, JsInstance[] parameters)
  {
    target.ClearItems();
    return (JsInstance) JsNull.Instance;
  }

  private DataTag CreateDisplayItemsTag()
  {
    DataTag displayItemsTag = new DataTag("items");
    displayItemsTag.Attributes["save"] = "0";
    displayItemsTag.Attributes["presence"] = "visible";
    displayItemsTag.Attributes["id"] = "items";
    return displayItemsTag;
  }

  private DataTag CreateBoundItemsTag()
  {
    DataTag boundItemsTag = new DataTag("items");
    boundItemsTag.Attributes["save"] = "1";
    boundItemsTag.Attributes["presence"] = "hidden";
    boundItemsTag.Attributes["id"] = "items";
    return boundItemsTag;
  }

  public virtual void AddItem(string value, object boundValue)
  {
    if (!this.HasOwnProperty("items"))
    {
      JsNode child1 = new JsNode((Tag) this.CreateDisplayItemsTag(), (JsNode) this, this.IGlobal.JintJsXfaElementConstructor.ItemsJsObject);
      JsNode child2 = new JsNode((Tag) this.CreateBoundItemsTag(), (JsNode) this, this.IGlobal.JintJsXfaElementConstructor.ItemsJsObject);
      this.AddChild((JsTree) child1);
      this.AddChild((JsTree) child2);
    }
    JintJsNodeList property = (JintJsNodeList) this.GetProperty("items");
    JsNode parent1 = (JsNode) property.get(0);
    JsNode parent2 = (JsNode) property.get(1);
    JsContent child3 = new JsContent("text", parent1, (JsNode) this.IGlobal.JintJsXfaElementConstructor.TextJsObject, value);
    parent1.AddChild((JsTree) child3);
    if (this.IsUndefined(boundValue) || !(boundValue is string) || ((string) boundValue).Length == 0)
      boundValue = (object) value;
    JsContent child4 = new JsContent("text", parent2, (JsNode) this.IGlobal.JintJsXfaElementConstructor.TextJsObject, (string) boundValue);
    parent2.AddChild((JsTree) child4);
    this.displayItemElements[(string) boundValue] = child3;
    this.boundItemValues.Add((string) boundValue);
  }

  public virtual JsInstance AddItemJsFunc(FieldPositioner target, JsInstance[] parameters)
  {
    if (parameters.Length == 1)
      target.AddItem(parameters[0].ToString(), (object) JsUndefined.Instance);
    else if (parameters.Length == 2)
      target.AddItem(parameters[0].ToString(), (object) parameters[1].ToString());
    return (JsInstance) JsNull.Instance;
  }

  public virtual string GetDisplayItem(int index)
  {
    if (index >= this.boundItemValues.Count)
      return (string) null;
    string boundItemValue = this.boundItemValues[index];
    return !this.displayItemElements.ContainsKey(boundItemValue) ? (string) null : this.displayItemElements[boundItemValue].GetStringProperty("value");
  }

  public virtual JsInstance GetDisplayItemJsFunc(FieldPositioner target, JsInstance[] parameters)
  {
    return (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, (object) target.GetDisplayItem(parameters[0].ToInteger()));
  }

  public virtual string GetSaveItem(int index)
  {
    return index < this.boundItemValues.Count ? this.boundItemValues[index] : (string) null;
  }

  public virtual JsInstance GetSaveItemJsFunc(FieldPositioner target, JsInstance[] parameters)
  {
    return (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, (object) target.GetSaveItem(parameters[0].ToInteger()));
  }

  public virtual void SetSelectedIndex(int index)
  {
    if (index == -1)
    {
      this.ClearItems();
    }
    else
    {
      if (index < 0 || index >= this.boundItemValues.Count)
        return;
      this.SetRawValue((object) this.boundItemValues[index]);
    }
  }

  private JsInstance SelectedIndexJsPropSetter(FieldPositioner target, JsInstance[] parameters)
  {
    target.SetSelectedIndex(parameters[0].ToInteger());
    return (JsInstance) JsNull.Instance;
  }

  public virtual int GetSelectedIndex()
  {
    object rawValue = this.GetRawValue();
    return rawValue is string ? this.boundItemValues.IndexOf((string) rawValue) : -1;
  }

  private JsInstance SelectedIndexJsProp(FieldPositioner target)
  {
    return (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, (object) target.GetSelectedIndex());
  }

  public virtual int GetLength() => this.boundItemValues.Count;

  private JsInstance LengthJsProp(FieldPositioner target)
  {
    return (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, (object) target.GetLength());
  }

  public virtual string FontColor
  {
    get
    {
      IFormNode formNode1 = this.RetrieveChild("font");
      if (formNode1 != null)
      {
        IFormNode formNode2 = formNode1.RetrieveChild("fill");
        if (formNode2 != null)
        {
          IFormNode formNode3 = formNode2.RetrieveChild("color");
          if (formNode3 != null)
            return formNode3.RetrieveAttribute("value");
        }
      }
      return (string) null;
    }
    set
    {
      JsInstance result1;
      this.TryGetProperty("font", out result1);
      JsInstance result2;
      ((JsDictionaryObject) result1).TryGetProperty("fill", out result2);
      JsInstance result3;
      ((JsDictionaryObject) result2).TryGetProperty("color", out result3);
      ((JintJsObject) result3).DefineProperty(nameof (value), (object) value);
    }
  }

  private JsInstance FontColorGetJsProp(FieldPositioner target)
  {
    return (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, (object) target.FontColor);
  }

  private JsInstance FontColorSetJsProp(FieldPositioner target, JsInstance[] parameters)
  {
    if (parameters.Length > 0)
      target.FontColor = parameters[0].ToString();
    return (JsInstance) JsNull.Instance;
  }

  public override void AddChild(Tag tag)
  {
    if ("items".Equals(tag.Name))
    {
      if (this.HasOwnProperty("items"))
        return;
      JsNode jsNode1 = new JsNode((Tag) this.CreateDisplayItemsTag(), (JsNode) this, this.IGlobal.JintJsXfaElementConstructor.ItemsJsObject);
      JsNode jsNode2 = new JsNode((Tag) this.CreateBoundItemsTag(), (JsNode) this, this.IGlobal.JintJsXfaElementConstructor.ItemsJsObject);
      IList<Tag> children1 = tag.Parent.GetChildren("items");
      if (children1.Count > 0 && children1[0] != null)
      {
        IList<Tag> children2 = children1[0].Children;
        for (int index = 0; index < children2.Count; ++index)
        {
          Tag tag1 = children2[index];
          JsContent child1 = new JsContent(tag1, jsNode1, (JsNode) this.IGlobal.JintJsXfaElementConstructor.GetNotNullXfaPrototype(tag1.Name));
          jsNode1.AddChild((JsTree) child1);
          bool flag = false;
          if (children1.Count == 2 && children1[1] != null)
          {
            IList<Tag> children3 = children1[1].Children;
            if (index < children3.Count)
            {
              XFATemplateTag xfaTemplateTag = (XFATemplateTag) children3[index];
              JsContent child2 = new JsContent((Tag) xfaTemplateTag, jsNode1, (JsNode) this.IGlobal.JintJsXfaElementConstructor.GetNotNullXfaPrototype(xfaTemplateTag.Name));
              jsNode2.AddChild((JsTree) child2);
              IList<string> content = xfaTemplateTag.Content;
              string key = "";
              if (content != null && content.Count > 0 && content[0] != null)
                key = content[0];
              this.displayItemElements[key] = child1;
              this.boundItemValues.Add(key);
              flag = true;
            }
          }
          if (!flag)
          {
            this.displayItemElements[child1.GetStringProperty("value")] = child1;
            this.boundItemValues.Add(child1.GetStringProperty("value"));
            jsNode2.AddChild((JsTree) new JsContent(tag1, jsNode2, (JsNode) this.IGlobal.JintJsXfaElementConstructor.GetNotNullXfaPrototype(tag1.Name)));
          }
        }
      }
      this.AddChild((JsTree) jsNode1);
      this.AddChild((JsTree) jsNode2);
    }
    else
      base.AddChild(tag);
  }

  public override string ClassName => "field";

  public override void InitValues()
  {
    object rawValue1 = (object) null;
    if (this.IsCheckButtonInsideRadioButtonList())
    {
      if (this.data != null && !this.data.Fictive && (this.data.RichText == null || this.data.RichText.Count == 0))
      {
        rawValue1 = (object) this.data.Value;
        if (rawValue1 is string && ((string) rawValue1).Length == 0)
          rawValue1 = (object) null;
        else
          this.inputParsingPattern = this.data.CanonizationPattern;
      }
      object rawValue2 = (object) null;
      if (rawValue1 == null && this.parent.Data != null && !this.parent.Data.Fictive)
      {
        DataTag data = this.parent.Data;
        if (data.RichText == null || data.RichText.Count == 0)
        {
          rawValue2 = (object) data.Value;
          if (this.CorrespondsToOnValue(rawValue2))
            rawValue1 = rawValue2;
          this.inputParsingPattern = data.CanonizationPattern;
        }
      }
      if (rawValue1 != null)
        this.SetRawValue(rawValue1);
      else if (rawValue2 == null)
        base.InitValues();
    }
    else if (this.data != null && !this.data.Fictive)
    {
      object rawValue3;
      if (this.data.RichText != null && this.data.RichText.Count > 0)
      {
        rawValue3 = (object) this.data.RichText;
      }
      else
      {
        IList<Tag> children = this.data.GetChildren("value");
        if (children.Count > 0)
        {
          StringBuilder stringBuilder = new StringBuilder();
          foreach (Tag tag in (IEnumerable<Tag>) children)
          {
            if (tag is DataTag)
            {
              string str = ((DataTag) tag).Value;
              if (stringBuilder.Length != 0 && str != null && str.Length != 0)
                stringBuilder.Append("\n");
              if (str != null && str.Length != 0)
                stringBuilder.Append(str);
            }
          }
          rawValue3 = (object) stringBuilder.ToString();
        }
        else
          rawValue3 = (object) this.data.Value;
        if (rawValue3 is string && ((string) rawValue3).Length == 0)
          rawValue3 = (object) null;
        this.inputParsingPattern = this.data.CanonizationPattern;
      }
      this.SetRawValue(rawValue3);
    }
    else
      base.InitValues();
    this.ApplySetPropertyTags();
  }

  internal bool CorrespondsToOnValue(object rawValue)
  {
    if (rawValue == null)
      return false;
    string onValue1 = CheckButtonElement.GetOnValue((IFormNode) this.template);
    bool onValue2 = rawValue is string && rawValue.Equals((object) onValue1);
    if (!onValue2 && rawValue is double)
    {
      if (onValue1 != null)
      {
        try
        {
          double num = double.Parse(onValue1);
          onValue2 = (double) rawValue == num;
        }
        catch (FormatException ex)
        {
        }
      }
    }
    return onValue2;
  }

  protected internal bool IsCheckButtonInsideRadioButtonList()
  {
    bool flag = false;
    if (this.parent is ExclGroupPositioner)
    {
      Tag child = this.template.GetChild("ui", "", false);
      if (child != null && child.Children != null && child.Children.Count > 0 && Util.EqualsIgnoreCase(child.Children[0].Name, "checkButton"))
        flag = true;
    }
    return flag;
  }

  protected override XFARectangle GetTextArea()
  {
    return this.contentElement == null ? this.GetElementArea(this.contentArea) : this.contentElement.GetElementRec();
  }

  protected override TextElement CreateChoiceListTextContentElement(
    IFormNode uiElementTag,
    XFARectangle textElementRect)
  {
    if (this.template == null)
      return this.CreateTextContentElement();
    string str1 = uiElementTag.RetrieveAttribute("open");
    if ("multiSelect".Equals(str1) || "always".Equals(str1))
    {
      HashSet2<string> hashSet2 = new HashSet2<string>();
      object rawValue = this.GetRawValue();
      string str2 = (string) null;
      if (rawValue is string && ((string) rawValue).Length != 0)
      {
        IList<string> stringList = (IList<string>) new List<string>((IEnumerable<string>) ((string) rawValue).Split('\n'));
        if (stringList.Count > 0)
          str2 = stringList[0];
        foreach (string str3 in (IEnumerable<string>) stringList)
          hashSet2.Add(str3);
      }
      Phrase phrase1 = new Phrase(new Chunk("choice list item"));
      TextElement textElement = new TextElement((IFormNode) this.template, (JsNode) this, textElementRect, this.document, (IList<IElement>) new List<IElement>()
      {
        (IElement) phrase1
      }, this.flattenerContext);
      textElement.CreateColumnText(textElementRect);
      Font font = textElement.TextDrawer.GetContent()[0].Chunks[0].Font;
      float leading = font.Size * 1.2f;
      int num1 = 0;
      float? height1 = this.GetTextArea().Height;
      float size1 = font.Size;
      if (((double) height1.GetValueOrDefault() < (double) size1 ? 0 : (height1.HasValue ? 1 : 0)) != 0)
      {
        int num2 = num1;
        float? height2 = this.GetTextArea().Height;
        float size2 = font.Size;
        float? nullable = height2.HasValue ? new float?(height2.GetValueOrDefault() - size2) : new float?();
        float num3 = leading;
        int num4 = 1 + (int) (nullable.HasValue ? new float?(nullable.GetValueOrDefault() / num3) : new float?()).Value;
        num1 = num2 + num4;
      }
      int num5 = str2 != null ? this.boundItemValues.IndexOf(str2) : -1;
      int num6 = num5 != -1 ? num5 : Math.Min(num1 - 1, this.boundItemValues.Count - 1);
      int num7 = num5 != -1 ? num6 - num1 + 1 : 0;
      if (num7 < 0)
      {
        int num8 = -num7;
        num7 += num8;
        num6 += num8;
      }
      BaseColor itemSelectionColor = new BaseColor(155, 192 /*0xC0*/, 218);
      TabSettings tabSettings = new TabSettings(new List<TabStop>()
      {
        new TabStop(textElementRect.Width.Value, (IDrawInterface) new FieldPositioner.ItemsBackgroundDrawInterface(leading, itemSelectionColor, font))
      }, 1f);
      IList<IElement> richText = (IList<IElement>) new List<IElement>();
      int num9 = 0;
      for (int index = num7; index <= num6 && index < this.boundItemValues.Count; ++index)
      {
        string boundItemValue = this.boundItemValues[index];
        JsContent jsContent = (JsContent) null;
        this.displayItemElements.TryGetValue(boundItemValue, out jsContent);
        string originalText = jsContent != null ? jsContent.GetStringProperty("value") : boundItemValue;
        if (originalText.Length > 0)
        {
          Phrase phrase2 = new Phrase();
          Chunk chunk = new Chunk(TextDrawer.GetMaxSingleLineText(originalText, textElementRect, (JsNode) this, this.document.PageSize, this.flattenerContext));
          if (hashSet2.Contains(this.boundItemValues[index - num9]))
            chunk.SetBackground(itemSelectionColor, 0.0f, leading - font.Size, 0.0f, 0.0f);
          phrase2.Add((IElement) chunk);
          if (hashSet2.Contains(this.boundItemValues[index - num9]))
          {
            phrase2.TabSettings = tabSettings;
            phrase2.Add((IElement) new Chunk(Chunk.TABBING)
            {
              Attributes = {
                ["TABSETTINGS"] = (object) tabSettings
              }
            });
          }
          phrase2.Add((IElement) new Chunk("\n"));
          richText.Add((IElement) phrase2);
        }
        else
        {
          ++num6;
          ++num9;
        }
      }
      return new TextElement((IFormNode) this.template, (JsNode) this, textElementRect, this.document, richText, this.flattenerContext);
    }
    object formattedValue = this.GetFormattedValue();
    if (!(formattedValue is string))
      return this.CreateTextContentElement();
    string key = (string) formattedValue;
    JsContent jsContent1 = (JsContent) null;
    this.displayItemElements.TryGetValue(key, out jsContent1);
    string plainText = jsContent1 != null ? jsContent1.GetStringProperty("value") : key;
    return new TextElement((IFormNode) this.template, (JsNode) this, textElementRect, this.document, plainText, this.flattenerContext);
  }

  protected override bool SupportLegacyPlusPrint => this.uiElement is ButtonElement;

  private void PropagateValueToParentIfNeeded(object value, object prevValue)
  {
    if (!this.IsCheckButtonInsideRadioButtonList())
      return;
    ((ExclGroupPositioner) this.parent).ValueResolver.PropagateValueFromChildToParent(value, prevValue, this);
  }

  private void ApplySetPropertyTags()
  {
    foreach (IFormNode retrieveChild in (IEnumerable<IFormNode>) this.template.RetrieveChildren("setProperty"))
    {
      string dataRef = retrieveChild.RetrieveAttribute("ref");
      string str1 = retrieveChild.RetrieveAttribute("target");
      if (str1 != null && dataRef != null && this.data != null)
      {
        IList<Tag> dataList = (IList<Tag>) new List<Tag>();
        DataBindReference fromSom = DataBindReference.CreateFromSom(dataRef);
        DataTreeResolver.FillDataList(dataList, fromSom, 0, this.data, false, new DataTreeResolverContext());
        string str2 = str1.Replace(".#", ".");
        if (dataList.Count > 0 && dataList[0] is DataTag)
        {
          string str3 = ((DataTag) dataList[0]).Value;
          StringBuilder stringBuilder = new StringBuilder();
          stringBuilder.Append("resolveNode").Append("(\"").Append(str2).Append("\")").Append(".value=").Append("\"").Append(str3).Append("\"").Append(";");
          try
          {
            this.EvaluateScript(stringBuilder.ToString());
          }
          catch (Exception ex)
          {
            FieldPositioner.LOGGER.Error("Could not evaluate <setProperty> declaration with generated script: " + (object) stringBuilder, ex);
          }
        }
      }
    }
  }

  private class ItemsBackgroundDrawInterface : IDrawInterface
  {
    private float leading;
    private BaseColor itemSelectionColor;
    private Font itemsFont;

    public ItemsBackgroundDrawInterface(
      float leading,
      BaseColor itemSelectionColor,
      Font itemsFont)
    {
      this.leading = leading;
      this.itemSelectionColor = itemSelectionColor;
      this.itemsFont = itemsFont;
    }

    public void Draw(PdfContentByte canvas, float llx, float lly, float urx, float ury, float y)
    {
      canvas.SaveState();
      canvas.SetColorFill(this.itemSelectionColor);
      canvas.Rectangle(llx, lly - (this.leading - this.itemsFont.Size), urx - llx, this.leading);
      canvas.Fill();
      canvas.RestoreState();
    }
  }
}
