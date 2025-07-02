// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.bind.DataTreeResolver
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.tool.xml.xtra.xfa.js;
using iTextSharp.tool.xml.xtra.xfa.tags;
using System;
using System.Collections.Generic;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.bind;

public class DataTreeResolver
{
  public static void FillDataList(
    IList<Tag> dataList,
    DataBindReference reference,
    int dataStructureIndex,
    DataTag dataTag,
    bool createIfNotExist,
    DataTreeResolverContext context)
  {
    if (dataStructureIndex >= reference.Size())
      return;
    string[] strArray = DataTreeResolver.SplitDataRefItem(reference.GetItem(dataStructureIndex));
    int index = 0;
    if (!"*".Equals(strArray[1]))
    {
      try
      {
        index = int.Parse(strArray[1]);
      }
      catch (Exception ex)
      {
      }
    }
    string str = strArray[0];
    Tag childDataTag1 = (Tag) DataTreeResolver.GetChildDataTag(dataTag, str, index, false);
    if (childDataTag1 == null && dataStructureIndex < 2 && !str.Equals(dataTag.Name))
      childDataTag1 = (Tag) DataTreeResolver.GetChildDataTag((DataTag) dataTag.Parent, str, index, true);
    if (childDataTag1 == null)
    {
      int count = dataList.Count;
      DataTreeResolver.FillDataList(dataList, reference, dataStructureIndex + 1, dataTag, createIfNotExist, context);
      if (dataList.Count != count || !createIfNotExist || !DataTreeResolver.IsValidToCreateDataNode(dataTag, str))
        return;
      DataTag tag = new DataTag(str);
      tag.SetFictive();
      context.GetFictiveDataTags().Add(tag);
      dataTag.AddChild((Tag) tag);
      if (dataTag.Node != null)
      {
        JsDataGroup child = new JsDataGroup(tag, dataTag.Node);
        tag.Node = (JsNode) child;
        child.DefineProperty("value", (object) null);
        dataTag.Node.AddChild((JsTree) child);
      }
      Tag childDataTag2 = (Tag) DataTreeResolver.GetChildDataTag(dataTag, str, index, false);
      if (childDataTag2 == null)
        return;
      if (dataStructureIndex == reference.Size() - 1)
        dataList.Add(childDataTag2);
      else
        DataTreeResolver.FillDataList(dataList, reference, dataStructureIndex + 1, (DataTag) childDataTag2, createIfNotExist, context);
    }
    else
    {
      IList<Tag> children = childDataTag1.Parent.GetChildren(strArray[0]);
      int count = children.Count;
      if (count <= 0)
        return;
      if ("*".Equals(strArray[1]))
      {
        if (dataStructureIndex == reference.Size() - 1)
        {
          foreach (Tag tag in (IEnumerable<Tag>) children)
            dataList.Add(tag);
        }
        else
        {
          foreach (Tag tag in (IEnumerable<Tag>) children)
            DataTreeResolver.FillDataList(dataList, reference, dataStructureIndex + 1, (DataTag) tag, false, context);
        }
      }
      else
      {
        DataTag dataTag1 = count <= index ? (DataTag) children[count - 1] : (DataTag) children[index];
        if (dataStructureIndex == reference.Size() - 1)
          dataList.Add((Tag) dataTag1);
        else
          DataTreeResolver.FillDataList(dataList, reference, dataStructureIndex + 1, dataTag1, createIfNotExist, context);
      }
    }
  }

  private static bool IsValidToCreateDataNode(DataTag dataTag, string dataRefItem)
  {
    if (dataTag.Node == null || dataTag.Node.ProtoTemplate == null)
      return true;
    Queue<Tag> tagQueue = new Queue<Tag>((IEnumerable<Tag>) dataTag.Node.ProtoTemplate.Children);
    while (tagQueue.Count != 0)
    {
      Tag tag = tagQueue.Dequeue();
      if (tag.Name.Equals(dataRefItem))
      {
        string str;
        tag.Parent.Attributes.TryGetValue("dd:model", out str);
        if (!tag.Parent.Name.Equals("group") || !tag.Parent.NameSpace.Equals("dd") || !"choice".Equals(str))
          return true;
        bool flag = false;
        foreach (Tag child in (IEnumerable<Tag>) tag.Parent.Children)
        {
          if (dataTag.GetChild(child.Name, "") != null)
            flag = true;
        }
        return !flag;
      }
      if (tag.Name.Equals("group") && tag.NameSpace.Equals("dd"))
      {
        foreach (Tag child in (IEnumerable<Tag>) tag.Children)
          tagQueue.Enqueue(child);
      }
    }
    return false;
  }

  public static string[] SplitDataRefItem(string dataRefItem)
  {
    string[] strArray1 = new string[2]{ "", "" };
    bool flag = false;
    for (int index = 0; index < dataRefItem.Length; ++index)
    {
      char ch = dataRefItem[index];
      switch (ch)
      {
        case '[':
          flag = true;
          break;
        case ']':
          flag = false;
          break;
        default:
          if (flag)
          {
            string[] strArray2;
            (strArray2 = strArray1)[1] = strArray2[1] + (object) ch;
            break;
          }
          string[] strArray3;
          (strArray3 = strArray1)[0] = strArray3[0] + (object) ch;
          break;
      }
    }
    if (strArray1[1].Length == 0)
      strArray1[1] = "0";
    return strArray1;
  }

  private static DataTag GetChildDataTag(
    DataTag dataTag,
    string name,
    int index,
    bool recursively)
  {
    if (dataTag == null)
      return (DataTag) null;
    Tag childDataTag = (Tag) null;
    IList<Tag> children = dataTag.GetChildren(name);
    if (children != null && children.Count > index)
      childDataTag = children[index];
    if (childDataTag != null || !recursively)
      return (DataTag) childDataTag;
    return name.Equals(dataTag.Name) || dataTag.Fictive ? (DataTag) null : DataTreeResolver.GetChildDataTag((DataTag) dataTag.Parent, name, index, true);
  }
}
