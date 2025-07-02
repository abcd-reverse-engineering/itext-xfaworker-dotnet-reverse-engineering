// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.element.BreakConditions
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.tool.xml.xtra.xfa.js;
using iTextSharp.tool.xml.xtra.xfa.positioner;
using System;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.element;

public class BreakConditions
{
  protected string type;
  protected string target;
  protected bool startNew;
  protected string subType;
  protected SubFormPositioner positioner;
  protected ScriptString script;
  protected SubFormPositioner currentAttachedPositioner;

  public BreakConditions(
    string subType,
    string type,
    string target,
    bool startNew,
    SubFormPositioner positioner,
    ScriptString script)
  {
    this.subType = subType;
    this.startNew = startNew;
    this.target = target;
    this.type = type;
    this.positioner = positioner;
    this.script = script;
    this.currentAttachedPositioner = positioner;
  }

  public BreakConditions(BreakConditions other, SubFormPositioner newPositioner)
    : this(other.subType, other.type, other.target, other.startNew, other.positioner, other.script)
  {
    this.currentAttachedPositioner = newPositioner;
  }

  public virtual string Type => this.type;

  public virtual bool StartNew => this.startNew;

  public virtual string SubType => this.subType;

  public virtual string Target
  {
    get => this.target;
    set => this.target = value;
  }

  public virtual SubFormPositioner Positioner => this.positioner;

  public virtual bool Evaluate()
  {
    if (this.script == null)
      return true;
    try
    {
      return this.positioner.EvaluateScript(this.script) is bool script && script;
    }
    catch (Exception ex)
    {
      return false;
    }
  }

  public static bool TargetsEqual(BreakConditions a, BreakConditions b)
  {
    if (a == null && b == null)
      return true;
    if (a == null || b == null)
      return false;
    string type1 = a.Type;
    string type2 = b.Type;
    string target1 = a.Target;
    string target2 = b.Target;
    return BreakConditions.StringsEqual(type1, type2) && BreakConditions.StringsEqual(target1, target2);
  }

  private static bool StringsEqual(string str1, string str2)
  {
    return str1 != null ? str1.Equals(str2) : str2 == null;
  }
}
