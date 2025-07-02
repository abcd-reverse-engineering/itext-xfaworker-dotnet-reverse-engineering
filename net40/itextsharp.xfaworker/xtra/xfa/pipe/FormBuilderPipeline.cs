// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.pipe.FormBuilderPipeline
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.text;
using iTextSharp.tool.xml.html;
using iTextSharp.tool.xml.pipeline;
using iTextSharp.tool.xml.pipeline.ctx;
using iTextSharp.tool.xml.xtra.xfa.tags;
using iTextSharp.tool.xml.xtra.xfa.util;
using System.Collections.Generic;
using System.util;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.pipe;

public class FormBuilderPipeline(CssAppliers cssAppliers) : TemplateBuilderPipeline(cssAppliers)
{
  public override IPipeline Open(IWorkerContext context, Tag t, ProcessObject po)
  {
    string name = t.Name;
    if (name[0] == '?')
      this.ProcessInstruction(t);
    XFAFlattenerData xfaFlattenerData = ((ObjectContext<XFAFlattenerData>) this.GetLocalContext(context)).Get();
    if (Util.EqualsIgnoreCase("form", name))
    {
      xfaFlattenerData.TemplateDom = (XFATemplateTag) t;
    }
    else
    {
      string str1;
      t.Attributes.TryGetValue("contentType", out str1);
      string str2;
      t.Attributes.TryGetValue("xmlns", out str2);
      if (Util.EqualsIgnoreCase("exData", name) && Util.EqualsIgnoreCase("text/html", str1))
      {
        xfaFlattenerData.RichTextBlockTag = t;
        IPipeline ipipeline = xfaFlattenerData.RichTextPipeline;
        while ((ipipeline = ipipeline.Init(context)) != null)
          ;
      }
      else if (xfaFlattenerData.RichTextBlockTag == t.Parent && ("http://www.w3.org/1999/xhtml".Equals(str2) || "xhtml".Equals(t.NameSpace)))
        xfaFlattenerData.RichTextHtmlRootTag = t;
    }
    return this.GetNext(context);
  }

  public override IPipeline Close(IWorkerContext context, Tag t, ProcessObject po)
  {
    string name = t.Name;
    string str1;
    t.Attributes.TryGetValue("contentType", out str1);
    if (Util.EqualsIgnoreCase("subform", name) || Util.EqualsIgnoreCase("field", name) || Util.EqualsIgnoreCase("draw", name) || Util.EqualsIgnoreCase("exclGroup", name) || Util.EqualsIgnoreCase("area", name) || Util.EqualsIgnoreCase("subformSet", name))
    {
      if (t is XFATemplateTag)
      {
        IDictionary<string, string> attributes1 = t.Attributes;
        string str2 = (string) null;
        attributes1?.TryGetValue("name", out str2);
        string refValue = str2;
        Tag bind = ((XFATemplateTag) t).Bind;
        if (bind != null)
        {
          IDictionary<string, string> attributes2 = bind.Attributes;
          if (attributes2 != null)
          {
            string str3;
            attributes2.TryGetValue("match", out str3);
            switch (str3)
            {
              case "dataRef":
                attributes2.TryGetValue("ref", out refValue);
                str2 = XFAUtil.CheckSomExpression(refValue);
                break;
            }
          }
        }
        ((XFATemplateTag) t).DataRef = str2;
        ((XFATemplateTag) t).FullDataRef = refValue;
      }
    }
    else if (Util.EqualsIgnoreCase("exData", name) && Util.EqualsIgnoreCase("text/html", str1))
    {
      ((ObjectContext<XFAFlattenerData>) this.GetLocalContext(context)).Get().RichTextBlockTag = (Tag) null;
      IList<IElement> ielementList = ((ObjectContext<IList<IElement>>) ((AbstractPipeline) ((ObjectContext<XFAFlattenerData>) this.GetLocalContext(context)).Get().RichTextPipeline.GetNext().GetNext()).GetLocalContext(context)).Get();
      ((XFATemplateTag) t).RichText = ielementList;
    }
    return this.GetNext(context);
  }
}
