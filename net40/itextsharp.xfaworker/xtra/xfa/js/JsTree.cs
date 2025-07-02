// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.js.JsTree
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.tool.xml.xtra.xfa.positioner;
using iTextSharp.tool.xml.xtra.xfa.resolver;
using iTextSharp.tool.xml.xtra.xfa.util;
using Jint.Delegates;
using Jint.Native;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text.RegularExpressions;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.js;

public class JsTree : JintJsObject
{
  protected internal static readonly ConcurrentDictionary<string, string> shortcuts = new ConcurrentDictionary<string, string>();
  protected FlattenerContext flattenerContext;

  static JsTree()
  {
    JsTree.shortcuts["$xfa"] = "xfa";
    JsTree.shortcuts["$data"] = "xfa.datasets.data";
    JsTree.shortcuts["$template"] = "xfa.template";
    JsTree.shortcuts["$connectionSet"] = "xfa.connectionSet";
    JsTree.shortcuts["$form"] = "xfa.form";
    JsTree.shortcuts["$layout"] = "xfa.layout";
    JsTree.shortcuts["$host"] = "xfa.host";
    JsTree.shortcuts["$dataWindow"] = "xfa.dataWindow";
    JsTree.shortcuts["$event"] = "xfa.event";
    JsTree.shortcuts["!"] = "xfa.datasets.";
    JsTree.shortcuts["$record"] = "xfa.data";
  }

  internal JsTree(JintJsObject prototype, string className)
    : base(prototype)
  {
    this.DefineConstantProperty(nameof (className), (object) className);
    this.DefineConstantProperty("name", (object) className);
    this.DefineProperty("resolveNode", (object) this.IGlobal.FunctionClass.New<JsTree>(new JintFunc<JsTree, JsInstance[], JsInstance>(this.ResolveNodeJsFunc), 1));
    this.DefineProperty("resolveNodes", (object) this.IGlobal.FunctionClass.New<JsTree>(new JintFunc<JsTree, JsInstance[], JsInstance>(this.ResolveNodesJsFunc), 1));
    this.DefineOwnProperty((Descriptor) new PropertyDescriptor<JsTree>((Jint.Native.IGlobal) this.IGlobal, (JsDictionaryObject) this, "all", new JintFunc<JsTree, JsInstance>(this.AllJsProp)));
    this.DefineOwnProperty((Descriptor) new PropertyDescriptor<JsTree>((Jint.Native.IGlobal) this.IGlobal, (JsDictionaryObject) this, "index", new JintFunc<JsTree, JsInstance>(this.IndexJsProp)));
    this.DefineOwnProperty((Descriptor) new PropertyDescriptor<JsTree>((Jint.Native.IGlobal) this.IGlobal, (JsDictionaryObject) this, "somExpression", new JintFunc<JsTree, JsInstance>(this.SomExpressionJsProp)));
    this.DefineOwnProperty((Descriptor) new PropertyDescriptor<JsScope>((Jint.Native.IGlobal) this.IGlobal, (JsDictionaryObject) this, "parent", new JintFunc<JsScope, JsInstance>(this.ParentJsProperty)));
  }

  protected JsTree(JsTree prototype)
    : base((JintJsObject) prototype)
  {
  }

  protected JsTree(JsTree prototype, JsTree parent)
    : base((JintJsObject) prototype)
  {
    this.Parent = parent;
    this.DefineProperty("nodes", (object) new JintJsNodeList((Jint.Native.IGlobal) this.IGlobal));
  }

  protected JsTree(string className, JsTree parent)
    : base(className, parent?.Visitor)
  {
    this.Parent = parent;
    this.DefineProperty("nodes", (object) new JintJsNodeList((Jint.Native.IGlobal) this.IGlobal));
  }

  public virtual JsTree Parent
  {
    get => (JsTree) this.ParentScope;
    set => this.ParentScope = (JsScope) value;
  }

  public JsInstance ParentJsProperty(JsScope target)
  {
    JsTree prototype = target.GetPrototype<JsTree>();
    return prototype == null ? (JsInstance) null : (JsInstance) prototype.Parent;
  }

  public virtual JintJsNodeList GetAll()
  {
    JintJsNodeList all = (JintJsNodeList) null;
    if (this.Parent != null)
    {
      string key = this.RetrieveName();
      object ownProperty = key != null ? this.Parent.GetOwnProperty(key) : (object) null;
      switch (ownProperty)
      {
        case JintJsNodeList _:
          all = (JintJsNodeList) ownProperty;
          break;
        case JsTree _:
          all = new JintJsNodeList((Jint.Native.IGlobal) this.IGlobal);
          all.Append(ownProperty);
          break;
      }
    }
    return all;
  }

  private JsInstance AllJsProp(JsTree target) => (JsInstance) target.GetAll();

  public virtual object Index
  {
    get
    {
      int index = 0;
      if (this.Parent != null)
      {
        string key = this.RetrieveName();
        object ownProperty = key != null ? this.Parent.GetOwnProperty(key) : (object) null;
        if (ownProperty is JintJsNodeList)
        {
          JintJsNodeList jintJsNodeList = (JintJsNodeList) ownProperty;
          int num = jintJsNodeList.IndexOfCompareReferences((JsInstance) this);
          index = num != -1 ? num : jintJsNodeList.Length;
        }
      }
      return (object) index;
    }
  }

  private JsInstance IndexJsProp(JsTree target)
  {
    return (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, target.Index);
  }

  public virtual object SomExpression
  {
    get
    {
      object property = this.GetProperty("name");
      string somExpression = $"{(property is string ? (object) property.ToString() : (object) this.RetrieveName())}[{this.Index}]";
      if (this.Parent != null)
        somExpression = $"{this.Parent.SomExpression}.{somExpression}";
      return (object) somExpression;
    }
  }

  private JsInstance SomExpressionJsProp(JsTree target)
  {
    return (JsInstance) JintJsObject.Wrap((Jint.Native.IGlobal) this.IGlobal, target.SomExpression);
  }

  public override bool HasProperty(string key)
  {
    bool flag = base.HasProperty(key);
    return !flag && this.Parent != null ? this.Parent.HasOwnProperty(key) : flag;
  }

  public override JsInstance GetGetFunction(JsDictionaryObject target, JsInstance[] parameters)
  {
    JsInstance getFunction = base.GetGetFunction(target, parameters);
    return target is JsTree && (getFunction == null || getFunction == JsUndefined.Instance) && ((JsTree) target).Parent != null ? this.GetGetFunction((JsDictionaryObject) ((JsTree) target).Parent, parameters) : getFunction;
  }

  public override JsInstance GetSetFunction(JsDictionaryObject target, JsInstance[] parameters)
  {
    JsInstance setFunction = base.GetSetFunction(target, parameters);
    return target is JsTree && (setFunction == null || setFunction == JsUndefined.Instance) && ((JsTree) target).Parent != null ? this.GetSetFunction((JsDictionaryObject) ((JsTree) target).Parent, parameters) : setFunction;
  }

  public virtual void AddChild(JsTree child)
  {
    JintJsNodeList jintJsNodeList1 = (JintJsNodeList) this.GetOwnProperty("nodes");
    if (jintJsNodeList1 == null)
    {
      jintJsNodeList1 = new JintJsNodeList((Jint.Native.IGlobal) this.IGlobal);
      this.DefineProperty("nodes", (object) jintJsNodeList1);
    }
    jintJsNodeList1.Append((object) child);
    string str = child.RetrieveName();
    if (str == null)
    {
      object property = child.GetProperty("name");
      if (property is string)
        str = property.ToString();
    }
    object ownProperty = this.GetOwnProperty(str);
    if (ownProperty != null && ownProperty != this)
    {
      switch (ownProperty)
      {
        case JintJsNodeList _:
          ((JintJsNodeList) ownProperty).Append((object) child);
          break;
        case JsTree _:
          this.Delete(str);
          JintJsNodeList jintJsNodeList2 = new JintJsNodeList((Jint.Native.IGlobal) this.IGlobal, new object[1]
          {
            ownProperty
          });
          jintJsNodeList2.Append((object) child);
          this.DefineProperty(str, (object) jintJsNodeList2);
          break;
        case string _:
          this.DefineProperty(str, (object) child);
          break;
      }
    }
    else
      this.DefineProperty(str, (object) child);
  }

  public virtual JsTree ResolveNode(string somExpressions) => this.ResolveNodeInt(somExpressions);

  public virtual JsInstance ResolveNodeJsFunc(JsTree target, JsInstance[] parameters)
  {
    return (JsInstance) target.ResolveNode(parameters[0].ToString()) ?? (JsInstance) JsNull.Instance;
  }

  public virtual JsInstance ResolveNodesJsFunc(JsTree target, JsInstance[] parameters)
  {
    return (JsInstance) target.ResolveNodes(parameters[0].ToString()) ?? (JsInstance) JsNull.Instance;
  }

  public virtual JsTree ResolveNodeInt(string somExpressions)
  {
    return this.SearchNode(somExpressions, true);
  }

  public virtual JsTree SearchNodeDown(string somExpressions)
  {
    return this.SearchNode(somExpressions, false);
  }

  public virtual JintJsNodeList ResolveNodes(string somExpressions)
  {
    return this.ResolveNodesInt(somExpressions);
  }

  public virtual JintJsNodeList ResolveNodesInt(string somExpressions)
  {
    return this.SearchNodes(somExpressions, true);
  }

  public virtual JsTree SearchNode(string somExpressions, bool up)
  {
    Stack<string> somExpression = JsTree.SplitSOM(somExpressions);
    if (somExpression != null)
      return this.SearchNodeByName(somExpression, up, false, (int) this.Index);
    somExpressions = somExpressions.Replace("#", "");
    return this.SearchNodeById(somExpressions, up);
  }

  public JsTree StrictSearchNode(string somExpressions)
  {
    Stack<string> somExpression = JsTree.SplitSOM(somExpressions);
    return somExpression != null ? this.StrictSearchNodeByName(somExpression) : (JsTree) null;
  }

  protected virtual JintJsNodeList SearchNodes(string somExpressions, bool up)
  {
    JintJsNodeList jintJsNodeList1 = new JintJsNodeList((Jint.Native.IGlobal) this.IGlobal);
    IList<JsTree> jsTreeList1 = (IList<JsTree>) new List<JsTree>();
    jsTreeList1.Add(this);
    Stack<string> stringStack = JsTree.SplitSOM(somExpressions);
    if (stringStack != null && "this".Equals(stringStack.Peek()) && this is JsXfa && this.flattenerContext != null && this.flattenerContext.CurrentNode != null)
    {
      stringStack.Pop();
      jsTreeList1.Clear();
      jsTreeList1.Add((JsTree) this.flattenerContext.CurrentNode);
    }
    if (stringStack != null && "parent".Equals(stringStack.Peek()))
    {
      stringStack.Pop();
      List<JsTree> jsTreeList2 = new List<JsTree>();
      foreach (JsTree jsTree in (IEnumerable<JsTree>) jsTreeList1)
        jsTreeList2.Add(jsTree.Parent);
      jsTreeList1.Clear();
      foreach (JsTree jsTree in jsTreeList2)
        jsTreeList1.Add(jsTree);
    }
    if (stringStack != null)
    {
      bool currentNodeIsMatched = false;
      while (stringStack.Count != 0)
      {
        string nameIndexPair1 = stringStack.Pop();
        string nameKey = "name";
        if (nameIndexPair1.StartsWith("#"))
        {
          nameIndexPair1 = nameIndexPair1.Replace("#", "");
          nameKey = "className";
        }
        XFAUtil.NameIndexPair nameIndexPair2 = XFAUtil.SplitNameIndexPair(nameIndexPair1);
        string name = nameIndexPair2.name;
        int index1 = nameIndexPair2.index;
        for (int index2 = 0; index2 < jsTreeList1.Count; ++index2)
        {
          JsTree jsTree = jsTreeList1[index2];
          JintJsNodeList jintJsNodeList2 = jsTree.SearchNodesByName(name, nameKey, up, currentNodeIsMatched);
          if (jintJsNodeList2 != null)
          {
            if (index1 != XFAUtil.MATCH_ALL_NODES)
            {
              if (jintJsNodeList2.Length > index1)
                jsTreeList1[index2] = (JsTree) jintJsNodeList2.GetItem(index1);
            }
            else
            {
              jsTreeList1.RemoveAt(index2);
              for (int i = 0; i < jintJsNodeList2.Length; ++i)
              {
                jsTreeList1.Insert(index2, (JsTree) jintJsNodeList2.GetItem(i));
                ++index2;
              }
              --index2;
            }
          }
          else
          {
            object property = jsTree.GetProperty(name);
            if (property != null)
            {
              if (property is JintJsNodeList)
              {
                foreach (KeyValuePair<string, JsInstance> keyValuePair in (JsDictionaryObject) property)
                {
                  object obj = (object) keyValuePair;
                  if (obj != null)
                    jintJsNodeList1.Append(obj);
                }
              }
              else
                jintJsNodeList1.Append(jsTree.GetProperty(name));
            }
            jsTreeList1.RemoveAt(index2);
            --index2;
          }
        }
        if (jsTreeList1.Count != 0)
        {
          up = false;
          currentNodeIsMatched = true;
        }
        else
          break;
      }
      foreach (JsTree jsTree in (IEnumerable<JsTree>) jsTreeList1)
        jintJsNodeList1.Append((object) jsTree);
    }
    else
    {
      somExpressions = somExpressions.Replace("#", "");
      if (somExpressions.EndsWith("[*]"))
      {
        JintJsNodeList jintJsNodeList3 = this.SearchNodesById(somExpressions.Substring(0, somExpressions.Length - 3));
        if (jintJsNodeList3 != null)
        {
          for (int i = 0; i < jintJsNodeList3.Length; ++i)
            jintJsNodeList1.Append((object) jintJsNodeList3.get(i));
        }
      }
      else
      {
        JsTree jsTree = this.SearchNodeById(somExpressions, up);
        if (jsTree != null)
          jintJsNodeList1.Append((object) jsTree);
      }
    }
    return jintJsNodeList1;
  }

  protected virtual object GetNamePropertyByNameKey(string nameKey)
  {
    object propertyByNameKey = this.GetProperty(nameKey);
    if (nameKey.Equals("name") && !(propertyByNameKey is string))
      propertyByNameKey = (object) this.RetrieveName();
    return propertyByNameKey;
  }

  protected virtual JsTree SearchNodeByName(
    Stack<string> somExpression,
    bool up,
    bool currentNodeIsMatched,
    int parentNodeIndex)
  {
    if (somExpression.Count == 0)
      return this;
    Stack<string> somExpression1 = new Stack<string>((IEnumerable<string>) new Stack<string>((IEnumerable<string>) somExpression));
    string nameIndexPair1 = somExpression1.Pop().Trim();
    string str = "name";
    if (nameIndexPair1.StartsWith("#"))
    {
      nameIndexPair1 = nameIndexPair1.Replace("#", "");
      str = "className";
    }
    else
    {
      if (!currentNodeIsMatched && nameIndexPair1.Equals(this.GetNamePropertyByNameKey(str)) || nameIndexPair1.Length == 0 || nameIndexPair1.Equals("$") || nameIndexPair1.Equals("this"))
        return this.SearchNodeByName(somExpression1, false, true, (int) this.Index);
      if (nameIndexPair1.Equals("parent") && this.Parent != null)
        return this.Parent.SearchNodeByName(somExpression1, false, true, (int) this.Index);
      if (nameIndexPair1.Equals("dataNode") && this is JsContainer && ((JsContainer) this).FetchDataNode(false) is JsTree)
        return ((JsTree) ((JsContainer) this).FetchDataNode(false)).SearchNodeByName(somExpression1, false, true, (int) this.Index);
      if (nameIndexPair1.Equals("record") && this is JsXfa)
        return ((JsTree) ((JsXfa) this).GetRecord()).SearchNodeByName(somExpression1, false, true, (int) this.Index);
    }
    XFAUtil.NameIndexPair nameIndexPair2 = XFAUtil.SplitNameIndexPair(nameIndexPair1);
    string name = nameIndexPair2.name;
    int index1 = nameIndexPair2.index;
    JintJsNodeList ownProperty = (JintJsNodeList) this.GetOwnProperty("nodes");
    List<JsTree> jsTreeList = new List<JsTree>();
    if (ownProperty != null)
    {
      this.TryGetProperty(name, out JsInstance _);
      for (int i = 0; i < ownProperty.Length; ++i)
      {
        object obj = (object) ownProperty.get(i);
        if ((obj is JsDataGroup || obj is JsDataValue) && str.Equals("name") && name.Equals(((JsTree) obj).RetrieveName()) || obj is JsTree && name.Equals(((JintJsObject) obj).GetProperty(str)))
          jsTreeList.Add((JsTree) obj);
      }
    }
    if (this is SubFormPositioner)
    {
      foreach (object obj in (IEnumerable<object>) ((SubFormPositioner) this).ResolveAllFromUnnamedSubformRecursively(name))
      {
        if (obj is JsTree && !jsTreeList.Contains((JsTree) obj))
          jsTreeList.Add((JsTree) obj);
      }
    }
    int index2 = (int) this.Index;
    if (jsTreeList.Count > 0)
    {
      if (index1 == XFAUtil.MATCH_ALL_NODES)
      {
        JsTree jsTree1 = (JsTree) null;
        foreach (JsTree jsTree2 in jsTreeList)
        {
          int index3 = (int) jsTree2.Index;
          if (jsTree1 == null || parentNodeIndex == index3)
            jsTree1 = jsTree2.SearchNodeByName(somExpression1, false, true, index2);
          if (parentNodeIndex == index3)
          {
            if (jsTree1 != null)
              break;
          }
        }
        if (jsTree1 != null)
          return jsTree1;
      }
      else
        return index1 < jsTreeList.Count ? jsTreeList[index1].SearchNodeByName(somExpression1, false, true, index2) : jsTreeList[jsTreeList.Count - 1].SearchNodeByName(somExpression1, false, false, index2);
    }
    else if (up)
    {
      object parent = (object) this.Parent;
      if (parent is JsTree)
        return name.Equals(((JintJsObject) parent).GetProperty(str)) && ((JsTree) parent).Index.Equals((object) index1) ? ((JsTree) parent).SearchNodeByName(somExpression1, false, false, index2) : ((JsTree) parent).SearchNodeByName(somExpression, up, false, index2);
    }
    else if (ownProperty != null)
    {
      for (int i = 0; i < ownProperty.Length; ++i)
      {
        object obj = (object) ownProperty.get(i);
        if (obj is JsTree)
        {
          JsTree jsTree = ((JsTree) obj).SearchNodeByName(somExpression, up, false, index2);
          if (jsTree != null)
            return jsTree;
        }
      }
    }
    return (JsTree) null;
  }

  protected JsTree StrictSearchNodeByName(Stack<string> somExpression)
  {
    if (somExpression.Count == 0)
      return this;
    Stack<string> somExpression1 = new Stack<string>((IEnumerable<string>) new Stack<string>((IEnumerable<string>) somExpression));
    string nameIndexPair1 = somExpression1.Pop().Trim();
    string key = "name";
    if (nameIndexPair1.StartsWith("#"))
    {
      nameIndexPair1 = nameIndexPair1.Replace("#", "");
      key = "className";
    }
    else if (nameIndexPair1.Equals("dataNode") && this is JsContainer && ((JsContainer) this).FetchDataNode(true) is JsTree)
      return ((JsTree) ((JsContainer) this).FetchDataNode(true)).StrictSearchNodeByName(somExpression1);
    XFAUtil.NameIndexPair nameIndexPair2 = XFAUtil.SplitNameIndexPair(nameIndexPair1);
    string name = nameIndexPair2.name;
    int index = nameIndexPair2.index;
    if (name.Equals("xfa") && this is JsXfa && index == 0)
      return this.StrictSearchNodeByName(somExpression1);
    JintJsNodeList ownProperty = (JintJsNodeList) this.GetOwnProperty("nodes");
    List<JsTree> jsTreeList = new List<JsTree>();
    if (ownProperty != null)
    {
      this.TryGetProperty(name, out JsInstance _);
      for (int i = 0; i < ownProperty.Length; ++i)
      {
        object obj = (object) ownProperty.get(i);
        if (obj is JsTree && name.Equals(((JintJsObject) obj).GetProperty(key)))
          jsTreeList.Add((JsTree) obj);
      }
    }
    return jsTreeList.Count > 0 && index != -1 && jsTreeList[index] != null ? jsTreeList[index].StrictSearchNodeByName(somExpression1) : (JsTree) null;
  }

  public static Stack<string> SplitSOM(string somExpression)
  {
    string[] strArray;
    if (Regex.IsMatch(somExpression, "^som\\(.*\\)$"))
    {
      somExpression = Regex.Replace(Regex.Replace(somExpression, "^som\\(", ""), "\\)$", "");
      strArray = somExpression.Split('.');
    }
    else
    {
      strArray = somExpression.Split('.');
      if (strArray.Length == 1 && strArray[0].StartsWith("#"))
        return (Stack<string>) null;
    }
    Stack<string> stringStack = new Stack<string>();
    for (int index = strArray.Length - 1; index >= 0; --index)
    {
      string key = strArray[index];
      if (JsTree.shortcuts.ContainsKey(key))
      {
        foreach (string str in new Stack<string>((IEnumerable<string>) JsTree.SplitSOM(JsTree.shortcuts[key])))
          stringStack.Push(str);
      }
      else
        stringStack.Push(key);
    }
    return stringStack;
  }

  public virtual JsTree SearchNodeByClassName(string nodeName)
  {
    JintJsNodeList jintJsNodeList = this.SearchNodesByName(nodeName, "className", false, false);
    return jintJsNodeList != null ? (JsTree) jintJsNodeList.GetItem(0) : (JsTree) null;
  }

  protected virtual JintJsNodeList SearchNodesByName(
    string nodeName,
    string nameKey,
    bool up,
    bool currentNodeIsMatched)
  {
    JintJsNodeList jintJsNodeList1 = new JintJsNodeList((Jint.Native.IGlobal) this.IGlobal);
    if (nodeName.Length == 0 || !currentNodeIsMatched && nodeName.Equals(this.GetProperty(nameKey)) || nodeName.Equals("$"))
      jintJsNodeList1.Append((object) this);
    else if (this is JsXfa && "record".Equals(nodeName) && "name".Equals(nameKey))
    {
      jintJsNodeList1.Append(((JsXfa) this).GetRecord());
    }
    else
    {
      JintJsNodeList ownProperty = (JintJsNodeList) this.GetOwnProperty("nodes");
      if (ownProperty != null)
      {
        this.TryGetProperty(nodeName, out JsInstance _);
        for (int i = 0; i < ownProperty.Length; ++i)
        {
          object obj = (object) ownProperty.get(i);
          if (obj is JsTree && nodeName.Equals(((JsTree) obj).GetNamePropertyByNameKey(nameKey)))
            jintJsNodeList1.Append(obj);
        }
      }
      if (jintJsNodeList1.Length == 0 && this is SubFormPositioner && nameKey.Equals("name"))
      {
        foreach (object obj in (IEnumerable<object>) ((SubFormPositioner) this).ResolveAllFromUnnamedSubformRecursively(nodeName))
        {
          if (obj is JsTree)
            jintJsNodeList1.Append(obj);
        }
      }
      if (jintJsNodeList1.Length == 0)
      {
        if (up)
        {
          object parent = (object) this.Parent;
          if (parent is JsTree)
            return ((JsTree) parent).SearchNodesByName(nodeName, nameKey, up, false);
        }
        else if (ownProperty != null && !currentNodeIsMatched)
        {
          for (int i1 = 0; i1 < ownProperty.Length; ++i1)
          {
            object node = (object) ownProperty.get(i1);
            if (node is JsTree && (!(this is JsXfa) || !JsTree.IsDataDomNode((JsTree) node)))
            {
              JintJsNodeList jintJsNodeList2 = ((JsTree) node).SearchNodesByName(nodeName, nameKey, up, false);
              if (jintJsNodeList2 != null)
              {
                for (int i2 = 0; i2 < jintJsNodeList2.Length; ++i2)
                  jintJsNodeList1.Append(jintJsNodeList2.GetItem(i2));
              }
            }
          }
        }
      }
    }
    return jintJsNodeList1.Length <= 0 ? (JintJsNodeList) null : jintJsNodeList1;
  }

  protected virtual JsTree SearchNodeById(string nodeId, bool up)
  {
    if (nodeId.Equals(this["id"].ToString()))
      return this;
    if (this.GetOwnProperty("nodes") is JintJsNodeList ownProperty)
    {
      for (int i = 0; i < ownProperty.Length; ++i)
      {
        object obj1 = (object) ownProperty.get(i);
        if (obj1 is JsTree && nodeId.Equals(((JsDictionaryObject) obj1)["id"].ToString()))
          return (JsTree) obj1;
        if (!up && obj1 is JsTree)
        {
          object obj2 = (object) ((JsTree) obj1).SearchNodeById(nodeId, false);
          if (obj2 != null)
            return (JsTree) obj2;
        }
      }
    }
    return up && this.Parent != null ? this.Parent.SearchNodeById(nodeId, false) : (JsTree) null;
  }

  protected virtual JintJsNodeList SearchNodesById(string nodeId)
  {
    JintJsNodeList jintJsNodeList = new JintJsNodeList((Jint.Native.IGlobal) this.IGlobal);
    JintJsNodeList ownProperty = (JintJsNodeList) this.GetOwnProperty("nodes");
    if (ownProperty != null)
    {
      for (int i = 0; i < ownProperty.Length; ++i)
      {
        object obj = (object) ownProperty.get(i);
        if (obj is JsTree && nodeId.Equals(((JintJsObject) obj).GetOwnProperty("id")))
          jintJsNodeList.Append(obj);
      }
    }
    return jintJsNodeList;
  }

  public virtual string RetrieveName() => (string) this.GetProperty("name");

  private static bool IsDataDomNode(JsTree node)
  {
    switch (node)
    {
      case JsDataModel _:
      case JsDataGroup _:
        return true;
      default:
        return node is JsDataValue;
    }
  }
}
