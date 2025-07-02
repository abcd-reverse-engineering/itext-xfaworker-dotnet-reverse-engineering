// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.js.JintJsXfaElementConstructor
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.tool.xml.xtra.xfa.positioner;
using Jint;
using Jint.Native;
using System.Collections.Generic;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.js;

public class JintJsXfaElementConstructor(IGlobal global) : JsConstructor(global)
{
  public Dictionary<string, JintJsObject> nodes = new Dictionary<string, JintJsObject>();

  public JintJsObject JsObject { get; protected set; }

  public JsTree JsTreeObject { get; protected set; }

  public JsNode JsNodeObject { get; protected set; }

  public JsContent TextJsObject { get; protected set; }

  public JsContent ScriptJsObject { get; protected set; }

  public JsNode CaptionJsObject { get; protected set; }

  public JsNode PagesetJsObject { get; protected set; }

  public JsContainer JsContainerObject { get; protected set; }

  public JsContainer DrawJsObject { get; protected set; }

  public JsContainer FieldJsObject { get; protected set; }

  public SubFormPositioner SubformJsObject { get; protected set; }

  public JsNode ItemsJsObject { get; protected set; }

  public JsNode ImageJsObject { get; protected set; }

  public JsDataGroup DataGroupJsObject { get; protected set; }

  public JsDataModel DataModelJsObject { get; protected set; }

  public JsDataValue DataValueJsObject { get; protected set; }

  public JsModel ModelJsObject { get; protected set; }

  public JsInstanceManager InstanceManagerJsObject { get; protected set; }

  public JsOccur OccurJsObject { get; protected set; }

  public override void InitPrototype(IGlobal global)
  {
    this.JsObject = new JintJsObject((ExecutionVisitor) global.Visitor);
    this.nodes.Add("tree", (JintJsObject) (this.JsTreeObject = new JsTree(this.JsObject, "tree")));
    this.nodes.Add("node", (JintJsObject) (this.JsNodeObject = new JsNode(this.JsTreeObject)));
    this.nodes.Add("xfa", (JintJsObject) new JsNode(this.JsTreeObject, "xfa"));
    this.nodes.Add("form", (JintJsObject) new JsNode(this.JsTreeObject, "form"));
    this.nodes.Add("container", (JintJsObject) (this.JsContainerObject = new JsContainer(this.JsNodeObject)));
    this.nodes.Add("dataGroup", (JintJsObject) (this.DataGroupJsObject = new JsDataGroup((JsTree) this.JsNodeObject)));
    this.nodes.Add("dataValue", (JintJsObject) (this.DataValueJsObject = new JsDataValue((JsTree) this.JsNodeObject)));
    this.nodes.Add("model", (JintJsObject) (this.ModelJsObject = new JsModel(this.JsNodeObject)));
    this.nodes.Add("dataModel", (JintJsObject) (this.DataModelJsObject = new JsDataModel((JsTree) this.ModelJsObject)));
    this.nodes.Add("caption", (JintJsObject) (this.CaptionJsObject = new JsNode((JsTree) this.JsNodeObject, "caption")));
    this.nodes.Add("pageSet", (JintJsObject) (this.PagesetJsObject = new JsNode((JsTree) this.JsNodeObject, "pageSet")));
    this.nodes.Add("text", (JintJsObject) (this.TextJsObject = new JsContent("text", this.JsNodeObject)));
    this.nodes.Add("script", (JintJsObject) (this.ScriptJsObject = new JsContent("script", this.JsNodeObject)));
    this.nodes.Add("draw", (JintJsObject) (this.DrawJsObject = new JsContainer("draw", (JsNode) this.JsContainerObject)));
    this.nodes.Add("field", (JintJsObject) (this.FieldJsObject = (JsContainer) new FieldPositioner("field", (JsNode) this.JsContainerObject)));
    this.nodes.Add("subform", (JintJsObject) (this.SubformJsObject = new SubFormPositioner("subform", this.JsContainerObject)));
    this.nodes.Add("subformSet", (JintJsObject) (this.SubformJsObject = new SubFormPositioner("subformSet", this.JsContainerObject)));
    this.nodes.Add("exclGroup", (JintJsObject) (this.SubformJsObject = new SubFormPositioner("exclGroup", this.JsContainerObject)));
    this.nodes.Add("area", (JintJsObject) (this.SubformJsObject = new SubFormPositioner("area", this.JsContainerObject)));
    this.nodes.Add("pageArea", (JintJsObject) (this.SubformJsObject = new SubFormPositioner("pageArea", this.JsContainerObject)));
    this.nodes.Add("instanceManager", (JintJsObject) (this.InstanceManagerJsObject = new JsInstanceManager((JsTree) this.JsNodeObject)));
    this.OccurJsObject = new JsOccur((JsTree) this.JsNodeObject);
    this.nodes.Add("manifest", (JintJsObject) new JsManifest("manifest", this.JsNodeObject));
    this.nodes.Add("contentArea", (JintJsObject) new JsNode((JsTree) this.JsNodeObject, "contentArea"));
    this.nodes.Add("image", (JintJsObject) (this.ImageJsObject = new JsNode((JsTree) this.JsNodeObject, "image")));
    this.nodes.Add("items", (JintJsObject) (this.ItemsJsObject = new JsNode((JsTree) this.JsNodeObject, "items")));
    this.nodes.Add("proto", (JintJsObject) new JsNode((JsTree) this.JsNodeObject, "proto"));
    this.nodes.Add("variables", (JintJsObject) new JsNode((JsTree) this.JsNodeObject, "variables"));
  }

  public bool HasXfaPrototype(string className) => this.nodes.ContainsKey(className);

  public JintJsObject GetXfaPrototype(string className)
  {
    JintJsObject jintJsObject;
    return this.nodes.TryGetValue(className, out jintJsObject) ? jintJsObject : (JintJsObject) null;
  }

  public JintJsObject GetNotNullXfaPrototype(string className)
  {
    JintJsObject jintJsObject;
    return this.nodes.TryGetValue(className, out jintJsObject) ? jintJsObject : (JintJsObject) this.JsNodeObject;
  }
}
