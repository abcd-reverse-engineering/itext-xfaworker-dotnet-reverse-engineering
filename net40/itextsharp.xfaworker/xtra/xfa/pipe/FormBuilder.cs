// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.pipe.FormBuilder
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.tool.xml.xtra.xfa.bind;
using iTextSharp.tool.xml.xtra.xfa.element;
using iTextSharp.tool.xml.xtra.xfa.js;
using iTextSharp.tool.xml.xtra.xfa.positioner;
using iTextSharp.tool.xml.xtra.xfa.resolver;
using iTextSharp.tool.xml.xtra.xfa.tags;
using Jint.Native;
using System;
using System.Collections.Generic;
using System.util;
using System.util.collections;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.pipe;

public class FormBuilder
{
  private XFATemplateTag templateDom;
  private DataTag dataDom;
  private JsNode formNode;
  private JsNode formDom;
  private FlattenerContext flattenerContext;
  private IDictionary<XFATemplateTag, XFATemplateTag> bindedParentTags = (IDictionary<XFATemplateTag, XFATemplateTag>) new LinkedDictionary<XFATemplateTag, XFATemplateTag>();
  private IDictionary<string, string> truncatedDataRefs = (IDictionary<string, string>) new LinkedDictionary<string, string>();
  private DataTreeResolverContext dataTreeResolverContext = new DataTreeResolverContext();

  public FormBuilder(
    XFATemplateTag templateDom,
    DataTag dataDom,
    JsNode formNode,
    FlattenerContext flattenerContext)
  {
    this.templateDom = templateDom;
    this.dataDom = dataDom;
    this.formNode = formNode;
    this.flattenerContext = flattenerContext;
    string dataRef = this.templateDom.DataRef;
    if (dataDom == null || string.IsNullOrEmpty(dataRef) || dataRef.Equals(dataDom.Name))
      return;
    Tag child = this.dataDom.GetChild(dataRef, "", true);
    if (child == null)
      return;
    this.dataDom = (DataTag) child;
  }

  private string TruncDataRef(string dataRef)
  {
    if (!dataRef.EndsWith("[*]"))
      return dataRef;
    string str;
    if (!this.truncatedDataRefs.TryGetValue(dataRef, out str))
    {
      str = dataRef.Replace("[*]", "");
      this.truncatedDataRefs[dataRef] = str;
    }
    return str;
  }

  private DataTag FindDataTagInParents(DataTag dataTag, string dataRef)
  {
    if (dataRef.Equals(dataTag.Name))
      return dataTag;
    return dataTag.Parent != null ? this.FindDataTagInParents((DataTag) dataTag.Parent, dataRef) : (DataTag) null;
  }

  private XFATemplateTag GetBindedParentTag(XFATemplateTag templateTag, DataTag dataTag)
  {
    XFATemplateTag bindedParentTag = (XFATemplateTag) null;
    if (!this.bindedParentTags.TryGetValue(templateTag, out bindedParentTag))
    {
      XFATemplateTag parent = (XFATemplateTag) templateTag.Parent;
      if (parent == null || "template".Equals(parent.Name))
        return this.templateDom;
      for (; parent != this.templateDom; parent = (XFATemplateTag) parent.Parent)
      {
        string dataRef1 = parent.DataRef;
        if (!string.IsNullOrEmpty(dataRef1))
        {
          string dataRef2 = this.TruncDataRef(dataRef1);
          if ((Tag) this.FindDataTagInParents(dataTag, dataRef2) != null)
            break;
        }
      }
      bindedParentTag = parent;
      this.bindedParentTags[templateTag] = bindedParentTag;
    }
    return bindedParentTag;
  }

  private void MarkDataTagAsUsed(
    DataTag dataTag,
    XFATemplateTag templateTag,
    XFATemplateTag parentTag)
  {
    if (parentTag == null)
      parentTag = this.GetBindedParentTag(templateTag, dataTag);
    dataTag.AddUsedBy(parentTag);
    if (parentTag == templateTag)
      return;
    dataTag.AddUsedBy(templateTag);
  }

  private void UndoMarkDataTagAsUsed(
    DataTag dataTag,
    XFATemplateTag templateTag,
    XFATemplateTag parentTag)
  {
    if (parentTag == null)
      parentTag = this.GetBindedParentTag(templateTag, dataTag);
    dataTag.RemoveUsedBy(parentTag);
    if (parentTag == templateTag)
      return;
    dataTag.RemoveUsedBy(templateTag);
  }

  private void UndoMarkDataTagAsUsed(Positioner positioner)
  {
    if (positioner.Data != null)
      this.UndoMarkDataTagAsUsed(this.GetFirstNonFictiveParent(positioner.Data), positioner.Template, (XFATemplateTag) null);
    foreach (Positioner child in (IEnumerable<Positioner>) positioner.Children)
      this.UndoMarkDataTagAsUsed(child);
  }

  private int MatchFieldsByFullDataRefRecursively(XFATemplateTag templateTag, string fullDataRef)
  {
    int num = 0;
    foreach (Tag templateTag1 in (Tag) templateTag)
    {
      if (("field".Equals(templateTag1.Name) || "exclGroup".Equals(templateTag1.Name)) && fullDataRef.Equals(((XFATemplateTag) templateTag1).FullDataRef))
        ++num;
      else if ("subform".Equals(templateTag1.Name) || "exclGroup".Equals(templateTag1.Name))
      {
        Tag bind = ((XFATemplateTag) templateTag1).Bind;
        if (bind != null)
        {
          string str;
          bind.Attributes.TryGetValue("match", out str);
          if ("none".Equals(str))
            num += this.MatchFieldsByFullDataRefRecursively((XFATemplateTag) templateTag1, fullDataRef);
        }
        else if (!templateTag1.Attributes.ContainsKey("name"))
          num += this.MatchFieldsByFullDataRefRecursively((XFATemplateTag) templateTag1, fullDataRef);
      }
      else if ("subformSet".Equals(templateTag1.Name) || "area".Equals(templateTag1.Name))
        num += this.MatchFieldsByFullDataRefRecursively((XFATemplateTag) templateTag1, fullDataRef);
    }
    return num;
  }

  public virtual JsNode BuildSubForm(
    XFATemplateTag templateTag,
    DataTag dataTag,
    JsNode parentForm)
  {
    return this.BuildSubForm(templateTag, dataTag, parentForm, true);
  }

  public virtual JsNode BuildSubForm(
    XFATemplateTag templateTag,
    DataTag dataTag,
    JsNode parentForm,
    bool lastSubformInSeries)
  {
    string dataRef1 = templateTag.DataRef;
    string str1 = (string) null;
    templateTag.Attributes.TryGetValue("relation", out str1);
    JsInstanceManager jsInstanceManager = (JsInstanceManager) null;
    if (parentForm != null)
    {
      jsInstanceManager = parentForm.GetInstanceManagerByTemplate((Tag) templateTag);
      if (jsInstanceManager == null)
      {
        jsInstanceManager = new JsInstanceManager(templateTag, parentForm, this.flattenerContext);
        parentForm.AddChild((JsTree) jsInstanceManager);
        parentForm.AddInstanceManagerForTemplate((Tag) templateTag, jsInstanceManager);
      }
    }
    if ("subform".Equals(templateTag.Name) || "pageArea".Equals(templateTag.Name) || FormBuilder.IsOrderedSubformSet(templateTag))
    {
      if (jsInstanceManager != null)
      {
        int? count = jsInstanceManager.Count;
        int max = jsInstanceManager.Max;
        if ((count.GetValueOrDefault() < max ? 0 : (count.HasValue ? 1 : 0)) != 0)
          goto label_7;
      }
      if (templateTag.MinOccur <= templateTag.MaxOccur)
      {
        if (jsInstanceManager != null)
        {
          jsInstanceManager.IncCount();
          goto label_24;
        }
        goto label_24;
      }
label_7:
      bool flag = false;
      IList<Tag> children = templateTag.Parent.Children;
      int num = children.IndexOf((Tag) templateTag);
      if (num != -1)
      {
        List<Tag> returnDataList = new List<Tag>();
        for (int index = num + 1; index < children.Count; ++index)
        {
          if (templateTag.FullDataRef != null && templateTag.FullDataRef.Equals(((XFATemplateTag) children[index]).FullDataRef))
          {
            this.GetDataList((XFATemplateTag) children[index], (DataTag) dataTag.Parent, (IList<Tag>) returnDataList);
            if (returnDataList.Count != 0)
            {
              flag = true;
              break;
            }
          }
        }
      }
      if (!flag && parentForm is Positioner)
      {
        Positioner positioner = (Positioner) parentForm;
        if (parentForm.Parent is SubFormPositioner)
          jsInstanceManager = ((SubFormPositioner) parentForm.Parent).GetInstanceManagerByTemplate(positioner.Template);
        if (!parentForm.HasOwnProperty("name") || positioner.Data == null || positioner.Data.Fictive)
        {
          int? count = jsInstanceManager.Count;
          int max = jsInstanceManager.Max;
          if ((count.GetValueOrDefault() >= max ? 0 : (count.HasValue ? 1 : 0)) != 0)
          {
            List<Tag> returnDataList = new List<Tag>();
            this.GetDataList(templateTag, (DataTag) dataTag.Parent, (IList<Tag>) returnDataList);
            if (returnDataList.Count != 0)
              positioner.buildNextInstance = true;
          }
        }
      }
      return (JsNode) null;
    }
label_24:
    string name = templateTag.Name;
    JsNode jsNode;
    if (Util.EqualsIgnoreCase(name, "exclGroup"))
      jsNode = (JsNode) new ExclGroupPositioner(templateTag, (DataTag) null, this.flattenerContext, parentForm);
    else if (Util.EqualsIgnoreCase(name, "area"))
      jsNode = (JsNode) new AreaPositioner(templateTag, (DataTag) null, this.flattenerContext, parentForm);
    else if (Util.EqualsIgnoreCase(name, "subform"))
      jsNode = (JsNode) new SubFormPositioner(templateTag, (DataTag) null, this.flattenerContext, parentForm);
    else if (Util.EqualsIgnoreCase(name, "subformSet"))
    {
      jsNode = (JsNode) new SubformSetPositioner(templateTag, (DataTag) null, this.flattenerContext, parentForm);
    }
    else
    {
      switch (name)
      {
        case "pageSet":
          jsNode = (JsNode) new PageSet(templateTag, parentForm, this.flattenerContext);
          break;
        case "pageArea":
          jsNode = (JsNode) new PageArea(templateTag, parentForm, (DataTag) null, this.flattenerContext);
          break;
        default:
          parentForm.AddChild((Tag) templateTag);
          return (JsNode) null;
      }
    }
    if (jsNode is Positioner)
    {
      if (dataRef1 == null)
      {
        ((Positioner) jsNode).Data = dataTag;
      }
      else
      {
        string str2 = this.TruncDataRef(dataRef1);
        if (dataTag != null && str2.Equals(dataTag.Name))
        {
          ((Positioner) jsNode).Data = dataTag;
          this.MarkDataTagAsUsed(this.GetFirstNonFictiveParent(dataTag), templateTag, (XFATemplateTag) null);
        }
      }
    }
    if (name.Equals("subformSet") && ("choice".Equals(str1) || "unordered".Equals(str1)))
    {
      HashSet2<Tag> hashSet2 = new HashSet2<Tag>();
      string str3;
      templateTag.Attributes.TryGetValue("relation", out str3);
      bool flag = "choice".Equals((object) ((object) templateTag).Equals((object) str3));
      if (dataTag != null)
      {
        foreach (Tag potentialAncestor in (IEnumerable<Tag>) new List<Tag>((IEnumerable<Tag>) dataTag.Children))
        {
          int? count = jsInstanceManager.Count;
          int max = jsInstanceManager.Max;
          if ((count.GetValueOrDefault() < max ? 0 : (count.HasValue ? 1 : 0)) == 0)
          {
            LinkedList<FormBuilder.DescendantSubformSetCandidate> linkedList = new LinkedList<FormBuilder.DescendantSubformSetCandidate>();
            foreach (Tag child in (IEnumerable<Tag>) templateTag.Children)
              linkedList.AddLast(new FormBuilder.DescendantSubformSetCandidate(child, child));
            ISet<Tag> tagSet = (ISet<Tag>) new HashSet<Tag>();
            while (linkedList.Count > 0)
            {
              FormBuilder.DescendantSubformSetCandidate subformSetCandidate = linkedList.First.Value;
              linkedList.RemoveFirst();
              if (!tagSet.Contains(subformSetCandidate.subformSetChild))
              {
                Tag descendant = subformSetCandidate.descendant;
                if ("subform".Equals(descendant.Name) || "subformSet".Equals(descendant.Name) || "field".Equals(descendant.Name))
                {
                  jsNode.GetInstanceManagerByTemplate(descendant)?.ResetCount();
                  IList<Tag> returnDataList = (IList<Tag>) new List<Tag>();
                  this.GetDataList((XFATemplateTag) descendant, dataTag, returnDataList);
                  if (returnDataList.Count > 0 && FormBuilder.IsDescendantOf(returnDataList[0], potentialAncestor))
                  {
                    bool onlyOneInstance = flag && returnDataList[0] == potentialAncestor;
                    this.BuildSubformInstance((XFATemplateTag) subformSetCandidate.subformSetChild, jsNode, dataTag, onlyOneInstance);
                    hashSet2.Add(subformSetCandidate.subformSetChild);
                    jsInstanceManager.IncCount();
                    tagSet.Add(subformSetCandidate.subformSetChild);
                  }
                  else if (FormBuilder.IsNoneDataRef((XFATemplateTag) descendant))
                  {
                    foreach (Tag child in (IEnumerable<Tag>) descendant.Children)
                      linkedList.AddLast(new FormBuilder.DescendantSubformSetCandidate(child, subformSetCandidate.subformSetChild));
                  }
                }
              }
            }
          }
          else
            break;
        }
      }
      if ("unordered".Equals(str1))
      {
        foreach (Tag subformTag in (Tag) templateTag)
        {
          if (("subform".Equals(subformTag.Name) || "subformSet".Equals(subformTag.Name)) && !hashSet2.Contains(subformTag))
          {
            hashSet2.Add(subformTag);
            this.BuildSubformInstance((XFATemplateTag) subformTag, jsNode, dataTag, false);
            jsInstanceManager.IncCount();
          }
        }
      }
      int? count1 = jsInstanceManager.Count;
      if ((count1.GetValueOrDefault() != 0 ? 0 : (count1.HasValue ? 1 : 0)) != 0 && templateTag.MinOccur > 0)
      {
        foreach (Tag tag in (Tag) templateTag)
        {
          jsNode.GetInstanceManagerByTemplate(tag)?.ResetCount();
          if ("subform".Equals(tag.Name) || "subformSet".Equals(tag.Name))
          {
            this.BuildSubformInstance((XFATemplateTag) tag, jsNode, dataTag, false);
            jsInstanceManager.IncCount();
            break;
          }
        }
      }
    }
    else
    {
      foreach (Tag tag in (Tag) templateTag)
      {
        jsNode.GetInstanceManagerByTemplate(tag)?.ResetCount();
        if ("subform".Equals(tag.Name) || "subformSet".Equals(tag.Name) || "area".Equals(tag.Name) || "exclGroup".Equals(tag.Name) || "pageSet".Equals(tag.Name) || "pageArea".Equals(tag.Name))
          this.BuildSubformInstance((XFATemplateTag) tag, jsNode, dataTag, false);
        else if ("field".Equals(tag.Name) || "draw".Equals(tag.Name))
        {
          IList<Tag> returnDataList = (IList<Tag>) new List<Tag>();
          bool flag = false;
          XFATemplateTag bindedParentTag = dataTag != null ? this.GetBindedParentTag((XFATemplateTag) tag, dataTag) : (XFATemplateTag) null;
          if (bindedParentTag != null && "exclGroup".Equals(bindedParentTag.Name))
          {
            IFormNode formNode = ((IFormNode) tag).RetrieveChild("ui");
            if (formNode != null && formNode.RetrieveChildren() != null && formNode.RetrieveChildren().Count > 0 && Util.EqualsIgnoreCase(formNode.RetrieveChildren()[0].RetrieveName(), "checkButton"))
              flag = true;
          }
          this.GetDataList((XFATemplateTag) tag, dataTag, returnDataList);
          if ("field".Equals(tag.Name) && returnDataList.Count == 0 && ((XFATemplateTag) tag).MinOccur > 0)
            this.GetDataList((XFATemplateTag) tag, dataTag, returnDataList, true);
          if (!flag && returnDataList.Count > 0)
          {
            string fullDataRef = ((XFATemplateTag) tag).FullDataRef;
            DataTag dataTag1 = (DataTag) returnDataList[0];
            string dataRef2 = ((XFATemplateTag) tag).DataRef;
            if (((XFATemplateTag) tag).MinOccur != 0 || dataTag1 != null && this.TruncDataRef(dataRef2).Equals(dataTag1.Name))
            {
              JsNode child = this.BuildField((XFATemplateTag) tag, dataTag1, jsNode, this.flattenerContext);
              this.MarkDataTagAsUsed(this.GetFirstNonFictiveParent(dataTag1), (XFATemplateTag) tag, bindedParentTag);
              jsNode.AddChild((JsTree) child);
              if (returnDataList.Count > 1 && this.MatchFieldsByFullDataRefRecursively(bindedParentTag, fullDataRef) <= 1 && jsNode is Positioner)
                ((Positioner) jsNode).buildNextInstance = true;
            }
          }
          else if (((XFATemplateTag) tag).MinOccur != 0)
            jsNode.AddChild((JsTree) this.BuildField((XFATemplateTag) tag, (DataTag) null, jsNode, this.flattenerContext));
        }
        else if (((XFATemplateTag) tag).MinOccur != 0)
          jsNode.AddChild(tag);
      }
    }
    if (jsNode is Positioner && ((Positioner) jsNode).buildNextInstance)
    {
      if (lastSubformInSeries)
      {
        JsNode node = this.BuildSubForm(templateTag, dataTag, parentForm);
        if (node != null)
          jsNode.AddAfterMe(node);
        else if (parentForm is SubFormPositioner && FormBuilder.IsNoneDataRef(((Positioner) parentForm).Template))
          ((Positioner) parentForm).buildNextInstance = true;
      }
      ((Positioner) jsNode).buildNextInstance = false;
    }
    return jsNode;
  }

  private DataTag GetFirstNonFictiveParent(DataTag tag)
  {
    while (tag != null && tag.Fictive)
      tag = (DataTag) tag.Parent;
    return tag;
  }

  public virtual JsNode AddSubformInstance(
    XFATemplateTag subformTag,
    JsNode parent,
    DataTag parentDataTag)
  {
    JsNode jsNode = this.BuildSubformInstance(subformTag, parent, parentDataTag, true);
    this.bindedParentTags.Clear();
    return jsNode;
  }

  public JsNode BuildSubformInstance(
    XFATemplateTag subformTag,
    JsNode parent,
    DataTag parentDataTag,
    bool onlyOneInstance)
  {
    bool flag = !onlyOneInstance && this.IsZeroOccurance(subformTag);
    IList<Tag> returnDataList = (IList<Tag>) new List<Tag>();
    bool dataList = this.GetDataList(subformTag, parentDataTag, returnDataList);
    int num1 = 0;
    int maxOccur = subformTag.MaxOccur;
    JsNode jsNode = (JsNode) null;
    if (returnDataList.Count > 0)
    {
      for (int index = 0; index < returnDataList.Count; ++index)
      {
        Tag tag = returnDataList[index];
        string fullDataRef = subformTag.FullDataRef;
        XFATemplateTag bindedParentTag = this.GetBindedParentTag(subformTag, parentDataTag);
        jsNode = this.BuildSubForm(subformTag, (DataTag) tag, parent, index == returnDataList.Count - 1);
        if ((!flag || !(jsNode is Positioner) || this.HasNonEmptyDataTag((Positioner) jsNode)) && jsNode != null)
        {
          parent?.AddChild((JsTree) jsNode);
          ++num1;
          if (onlyOneInstance || returnDataList.Count > 1 && this.MatchFieldsByFullDataRefRecursively(bindedParentTag, fullDataRef) > 1)
            break;
        }
      }
    }
    else
    {
      DataTag dataTag1 = dataList ? parentDataTag : DataTag.CreateEmpty();
      if (returnDataList.Count == 0 && !flag && !Util.EqualsIgnoreCase("subformSet", subformTag.Name))
      {
        this.GetDataList(subformTag, parentDataTag, returnDataList, true);
        if (returnDataList.Count > 0)
          dataTag1 = (DataTag) returnDataList[0];
      }
      this.dataTreeResolverContext = new DataTreeResolverContext();
      jsNode = this.BuildSubForm(subformTag, dataTag1, parent);
      if (flag && jsNode is SubFormPositioner && !this.HasNonEmptyDataTag((Positioner) jsNode))
      {
        ((JsInstanceManager) ((SubFormPositioner) jsNode).GetInstanceManager()).DecCount();
        this.UndoMarkDataTagAsUsed((Positioner) jsNode);
        IList<DataTag> fictiveDataTags = this.dataTreeResolverContext.GetFictiveDataTags();
        for (int index = 0; index < fictiveDataTags.Count; ++index)
        {
          DataTag dataTag2 = fictiveDataTags[index];
          if (dataTag2.Parent != null)
            dataTag2.Parent.Children.Remove((Tag) dataTag2);
          if (dataTag2.Node != null && dataTag2.Node.GetParentNode() != null)
          {
            dataTag2.Node.GetParentNode().Delete(dataTag2.Name);
            int num2 = dataTag2.Node.GetParentNode().GetNodes().IndexOfCompareReferences((JsInstance) dataTag2.Node);
            if (num2 != -1)
              dataTag2.Node.GetParentNode().GetNodes().Delete(num2.ToString());
          }
        }
      }
      else if (jsNode != null)
      {
        parent?.AddChild((JsTree) jsNode);
        ++num1;
      }
    }
    for (int index = num1; index < Math.Max(subformTag.MinOccur, subformTag.InitialOccur) && (num1 < subformTag.MinOccur || !(jsNode is Positioner) || !this.HasNonEmptyDataTag((Positioner) jsNode)); ++index)
    {
      jsNode = this.BuildSubForm(subformTag, DataTag.CreateEmpty(), parent);
      if (jsNode != null)
      {
        ++num1;
        parent?.AddChild((JsTree) jsNode);
      }
      if (onlyOneInstance)
        break;
    }
    if (jsNode is PageArea && maxOccur < int.MaxValue)
      ((PageArea) jsNode).MaxOccur = maxOccur;
    return jsNode;
  }

  private void RemoveFictiveDataRecursively(DataTag dataTag)
  {
    IList<Tag> tagList = (IList<Tag>) new List<Tag>();
    foreach (Tag tag in (Tag) dataTag)
    {
      if (((DataTag) tag).Fictive)
      {
        if (dataTag.Node != null)
          dataTag.Node.Delete(tag.Name);
      }
      else
      {
        this.RemoveFictiveDataRecursively((DataTag) tag);
        tagList.Add(tag);
      }
    }
    if (tagList.Count == dataTag.Children.Count)
      return;
    dataTag.Children.Clear();
    foreach (Tag tag in (IEnumerable<Tag>) tagList)
      dataTag.Children.Add(tag);
  }

  private bool IsZeroOccurance(XFATemplateTag subformTag)
  {
    string dataRef = subformTag.DataRef;
    int minOccur = subformTag.MinOccur;
    return dataRef != null && minOccur == 0;
  }

  private bool IsZeroOccuranceRecursively(XFATemplateTag subformTag)
  {
    if (this.IsZeroOccurance(subformTag))
      return true;
    XFATemplateTag parent = (XFATemplateTag) subformTag.Parent;
    return parent != null && this.IsZeroOccurance(parent);
  }

  public static bool IsNoneDataRef(XFATemplateTag tag)
  {
    IFormNode formNode = tag.RetrieveChild("bind");
    return formNode != null && "none".Equals(formNode.RetrieveAttribute("match"));
  }

  private bool HasNonEmptyDataTag(Positioner formTag)
  {
    IFormNode formNode;
    bool flag = formTag.Data != null && !formTag.Data.Fictive && formTag.Template != null && (formNode = formTag.Template.RetrieveChild("bind")) != null && "global".Equals(formNode.RetrieveAttribute("match"));
    if (!flag && formTag.Data != null && !formTag.Data.Fictive && formTag.Template != null && formTag is FieldPositioner)
    {
      DataTag data = formTag.Data;
      XFATemplateTag template = formTag.Template;
      return !formTag.Data.IsUsedByAnyoneExcept(template, this.GetBindedParentTag(template, data)) || !this.IsZeroOccuranceRecursively(formTag.Template);
    }
    if (!flag && formTag.Data != null && !formTag.Data.Fictive && formTag.Template != null && formTag.Template.DataRef != null && !FormBuilder.IsNoneDataRef(formTag.Template) && this.TruncDataRef(formTag.Template.DataRef).Equals(formTag.Data.Name))
      return true;
    foreach (Positioner child in (IEnumerable<Positioner>) formTag.Children)
    {
      if (this.HasNonEmptyDataTag(child))
        return true;
    }
    return false;
  }

  private JsNode BuildField(
    XFATemplateTag templateTag,
    DataTag dataTag,
    JsNode parentForm,
    FlattenerContext flattenerContext)
  {
    Tag bind = templateTag.Bind;
    if (bind != null && dataTag != null)
    {
      Tag child = bind.GetChild("picture", "");
      if (child is XFATemplateTag && ((XFATemplateTag) child).Content != null)
      {
        string str = ((XFATemplateTag) child).Content[0];
        if (!string.IsNullOrEmpty(str) && dataTag.CanonizationPattern == null)
          dataTag.CanonizationPattern = str;
      }
    }
    JsNode jsNode = !"field".Equals(templateTag.Name) ? (JsNode) new DrawPositioner(templateTag, (DataTag) null, flattenerContext, parentForm) : (JsNode) new FieldPositioner(templateTag, dataTag, parentForm, flattenerContext);
    foreach (Tag tag in (Tag) templateTag)
      jsNode.AddChild(tag);
    return jsNode;
  }

  public virtual JsNode FormDom
  {
    get
    {
      if (this.formDom == null)
      {
        this.formDom = this.BuildSubForm(this.templateDom, this.dataDom, this.formNode);
        this.bindedParentTags.Clear();
      }
      return this.formDom;
    }
  }

  private bool GetDataList(XFATemplateTag templateTag, DataTag dataTag, IList<Tag> returnDataList)
  {
    return this.GetDataList(templateTag, dataTag, returnDataList, false);
  }

  private bool GetDataList(
    XFATemplateTag templateTag,
    DataTag dataTag,
    IList<Tag> returnDataList,
    bool createIfNotExist)
  {
    IList<Tag> dataList = (IList<Tag>) new List<Tag>();
    string str1 = (string) null;
    bool flag1 = true;
    bool flag2 = "area".Equals(templateTag.Name);
    bool flag3 = false;
    if (dataTag != null && !flag2)
    {
      bool flag4 = false;
      string str2 = templateTag.RetrieveAttribute("name");
      if (str2 != null && str2.Length > 0)
        str1 = str2;
      Tag bind = templateTag.Bind;
      if (bind != null)
      {
        flag1 = false;
        IDictionary<string, string> attributes = bind.Attributes;
        string str3;
        if (attributes.TryGetValue("match", out str3) && "dataRef".Equals(str3))
        {
          string str4;
          if (attributes.TryGetValue("ref", out str4) && !string.IsNullOrEmpty(str4))
          {
            flag4 = true;
            str1 = str4;
            if (str1.StartsWith("$record"))
            {
              str1 = str1.Substring(1 + "record".Length);
              while (dataTag.Parent != null)
                dataTag = (DataTag) dataTag.Parent;
            }
            else if (str1.StartsWith("$data"))
            {
              if (templateTag.Parent != null && ((XFATemplateTag) templateTag.Parent).FullDataRef != null && str1.StartsWith(((XFATemplateTag) templateTag.Parent).FullDataRef))
              {
                str1 = str1.Substring(((XFATemplateTag) templateTag.Parent).FullDataRef.Length);
              }
              else
              {
                str1 = str1.Substring(1 + "data".Length);
                dataTag = this.dataDom;
              }
            }
            else if (str1.StartsWith("$"))
              str1 = str1.Substring(1);
            else if (str1.StartsWith("!"))
              str1 = str1.Substring(1);
            else if (str1.StartsWith($"{"xfa"}.{"datasets"}."))
              str1 = str1.Substring("xfa".Length + 1 + "datasets".Length + 1);
          }
        }
        else if ("global".Equals(str3))
          flag3 = true;
        else if ("none".Equals(str3))
        {
          str1 = (string) null;
          flag2 = true;
        }
        else if (!string.IsNullOrEmpty(str1))
          str1 += "[*]";
      }
      else if (!string.IsNullOrEmpty(str1))
        str1 += "[*]";
      if (flag3)
      {
        Tag tag = (Tag) null;
        if (this.dataDom != null)
          tag = this.dataDom.GetChild(str1, "", true);
        if (tag != null)
          dataList.Add(tag);
      }
      else if (!string.IsNullOrEmpty(str1))
      {
        if (str1.StartsWith("."))
          str1 = str1.Substring(1);
        DataBindReference reference = !flag4 ? DataBindReference.CreateSimple(str1) : DataBindReference.CreateFromSom(str1);
        DataTreeResolver.FillDataList(dataList, reference, 0, dataTag, createIfNotExist, this.dataTreeResolverContext);
      }
    }
    if (str1 != null)
    {
      XFATemplateTag bindedParentTag = this.GetBindedParentTag(templateTag, dataTag);
      int index = 0;
      for (int count = dataList.Count; index < count; ++index)
      {
        Tag tag = dataList[index];
        Tag nonFictiveParent = (Tag) this.GetFirstNonFictiveParent((DataTag) tag);
        if (!((DataTag) nonFictiveParent).IsUsedBy(bindedParentTag))
          returnDataList.Add(tag);
        else if (!str1.Contains("[*]"))
          returnDataList.Add(tag);
        else if (!((DataTag) nonFictiveParent).IsUsedBy(templateTag) && !str1.EndsWith("[*]"))
        {
          bool flag5 = false;
          foreach (Tag child in (IEnumerable<Tag>) templateTag.Parent.Children)
          {
            if (((DataTag) nonFictiveParent).IsUsedBy((XFATemplateTag) child))
            {
              flag5 = true;
              break;
            }
          }
          if (!flag5)
            returnDataList.Add(tag);
        }
      }
    }
    return returnDataList.Count != 0 || flag1 || flag2;
  }

  private static bool IsOrderedSubformSet(XFATemplateTag tag)
  {
    string str = (string) null;
    tag.Attributes.TryGetValue("relation", out str);
    return (str == null || "ordered".Equals(str)) && "subformSet".Equals(tag.Name);
  }

  private static bool IsDescendantOf(Tag tag, Tag potentialAncestor)
  {
    while (tag != null && tag != potentialAncestor)
      tag = tag.Parent;
    return tag == potentialAncestor;
  }

  private class DescendantSubformSetCandidate
  {
    public Tag descendant;
    public Tag subformSetChild;

    public DescendantSubformSetCandidate(Tag descendant, Tag subformSetChild)
    {
      this.descendant = descendant;
      this.subformSetChild = subformSetChild;
    }
  }
}
