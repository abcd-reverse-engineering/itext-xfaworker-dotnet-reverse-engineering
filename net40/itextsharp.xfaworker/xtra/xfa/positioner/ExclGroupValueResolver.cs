// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.positioner.ExclGroupValueResolver
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.positioner;

internal class ExclGroupValueResolver
{
  private bool isInPropagationProcess;
  private ExclGroupPositioner exclGroupPositioner;

  public ExclGroupValueResolver(ExclGroupPositioner exclGroupPositioner)
  {
    this.exclGroupPositioner = exclGroupPositioner;
  }

  internal void PropagateValueFromChildToParent(
    object rawValue,
    object prevValue,
    FieldPositioner fieldPositioner)
  {
    if (this.isInPropagationProcess)
      return;
    this.isInPropagationProcess = true;
    if (fieldPositioner.CorrespondsToOnValue(rawValue))
    {
      this.exclGroupPositioner.SetRawValue(rawValue);
      this.PropagateValueToChildren(rawValue);
    }
    else if (fieldPositioner.CorrespondsToOnValue(prevValue))
      this.exclGroupPositioner.SetRawValue((object) "");
    this.isInPropagationProcess = false;
  }

  internal bool PropagateValueFromParentToChildren(object rawValue)
  {
    if (this.isInPropagationProcess)
      return true;
    this.isInPropagationProcess = true;
    bool children = this.PropagateValueToChildren(rawValue);
    this.isInPropagationProcess = false;
    return children;
  }

  private bool PropagateValueToChildren(object rawValue)
  {
    bool children = false;
    foreach (Positioner childElement in this.exclGroupPositioner.childElements)
    {
      if (childElement is FieldPositioner)
      {
        FieldPositioner fieldPositioner = (FieldPositioner) childElement;
        if (fieldPositioner.IsCheckButtonInsideRadioButtonList())
        {
          if (fieldPositioner.CorrespondsToOnValue(rawValue))
          {
            fieldPositioner.SetRawValue(rawValue);
            children = true;
          }
          else
            fieldPositioner.SetRawValue((object) null);
        }
      }
    }
    return children;
  }
}
