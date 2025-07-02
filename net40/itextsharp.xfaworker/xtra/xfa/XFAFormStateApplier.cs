// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.XFAFormStateApplier
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.tool.xml.xtra.xfa.positioner;
using iTextSharp.tool.xml.xtra.xfa.tags;
using System.Collections.Generic;
using System.util.collections;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa;

internal class XFAFormStateApplier
{
  private static readonly HashSet2<string> TAG_WHITE_LIST = new HashSet2<string>((IEnumerable<string>) new string[8]
  {
    "subform",
    "subformSet",
    "pageSet",
    "field",
    "area",
    "exclGroup",
    "draw",
    "pageArea"
  });
  private Positioner formDomPositioner;
  private XFATemplateTag formDom;

  public XFAFormStateApplier(Positioner formDomPositioner, XFATemplateTag formDom)
  {
    this.formDomPositioner = formDomPositioner;
    this.formDom = formDom;
  }

  internal void ApplyFormState()
  {
    this.ApplyFormState(this.formDomPositioner, (XFATemplateTag) this.formDom.RetrieveChildren()[0]);
  }

  private void ApplyFormState(Positioner currentPositioner, XFATemplateTag formStateTag)
  {
    if ("field".Equals(formStateTag.Name) && currentPositioner is FieldPositioner || "draw".Equals(formStateTag.Name) && currentPositioner is DrawPositioner)
    {
      IFormNode formNode1 = formStateTag.RetrieveChild(new string[2]
      {
        "value",
        "integer"
      });
      if (formNode1 != null && formNode1.RetrieveValue() != null)
        currentPositioner.SetRawValue((object) formNode1.RetrieveValue());
      IFormNode formNode2 = formStateTag.RetrieveChild(new string[2]
      {
        "value",
        "text"
      });
      if (formNode2 != null && formNode2.RetrieveValue() != null)
        currentPositioner.SetRawValue((object) formNode2.RetrieveValue());
      IFormNode formNode3 = formStateTag.RetrieveChild(new string[2]
      {
        "value",
        "float"
      });
      if (formNode3 != null && formNode3.RetrieveValue() != null)
        currentPositioner.SetRawValue((object) formNode3.RetrieveValue());
      IFormNode formNode4 = formStateTag.RetrieveChild(new string[2]
      {
        "value",
        "date"
      });
      if (formNode4 != null && formNode4.RetrieveValue() != null)
        currentPositioner.SetRawValue((object) formNode4.RetrieveValue());
    }
    foreach (KeyValuePair<string, string> retrieveAttribute in (IEnumerable<KeyValuePair<string, string>>) formStateTag.RetrieveAttributes())
    {
      if ("presence".Equals(retrieveAttribute.Key))
      {
        bool flag = currentPositioner.IsHidden();
        currentPositioner.DefineProperty(retrieveAttribute.Key, (object) retrieveAttribute.Value);
        if (currentPositioner.IsHidden() != flag)
          this.formDomPositioner.LayoutOutOfDate = true;
      }
      else if ("h".Equals(retrieveAttribute.Key))
        currentPositioner.DefineProperty(retrieveAttribute.Key, (object) retrieveAttribute.Value);
    }
    IDictionary<XFAFormStateApplier.TemplateElementDescriptor, Queue<Positioner>> dictionary = (IDictionary<XFAFormStateApplier.TemplateElementDescriptor, Queue<Positioner>>) new Dictionary<XFAFormStateApplier.TemplateElementDescriptor, Queue<Positioner>>();
    foreach (Positioner child in (IEnumerable<Positioner>) currentPositioner.Children)
    {
      XFAFormStateApplier.TemplateElementDescriptor key = new XFAFormStateApplier.TemplateElementDescriptor((IFormNode) child);
      if (!dictionary.ContainsKey(key))
        dictionary[key] = new Queue<Positioner>();
      dictionary[key].Enqueue(child);
    }
    foreach (Tag child in (IEnumerable<Tag>) formStateTag.Children)
    {
      if (child is XFATemplateTag)
      {
        XFAFormStateApplier.TemplateElementDescriptor key = new XFAFormStateApplier.TemplateElementDescriptor((IFormNode) child);
        Queue<Positioner> positionerQueue;
        if (XFAFormStateApplier.TAG_WHITE_LIST.Contains(key.GetTagName()) && dictionary.TryGetValue(key, out positionerQueue) && positionerQueue != null && positionerQueue.Count > 0)
          this.ApplyFormState(positionerQueue.Dequeue(), (XFATemplateTag) child);
      }
    }
  }

  private class TemplateElementDescriptor
  {
    private string tagName;
    private string xfaName;

    public TemplateElementDescriptor(IFormNode formNode)
    {
      string str = formNode.RetrieveAttribute("name") ?? "";
      this.tagName = formNode.RetrieveTagName() ?? "";
      this.xfaName = str;
    }

    public string GetTagName() => this.tagName;

    public string GetXfaName() => this.xfaName;

    public override bool Equals(object o)
    {
      if (this == o)
        return true;
      if (o == null || this.GetType() != o.GetType())
        return false;
      XFAFormStateApplier.TemplateElementDescriptor elementDescriptor = (XFAFormStateApplier.TemplateElementDescriptor) o;
      if ((this.tagName != null ? (!this.tagName.Equals(elementDescriptor.tagName) ? 1 : 0) : (elementDescriptor.tagName != null ? 1 : 0)) != 0)
        return false;
      return this.xfaName == null ? elementDescriptor.xfaName == null : this.xfaName.Equals(elementDescriptor.xfaName);
    }

    public override int GetHashCode()
    {
      return 31 /*0x1F*/ * (this.tagName != null ? this.tagName.GetHashCode() : 0) + (this.xfaName != null ? this.xfaName.GetHashCode() : 0);
    }
  }
}
