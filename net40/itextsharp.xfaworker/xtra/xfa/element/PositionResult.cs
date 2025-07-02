// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.element.PositionResult
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.tool.xml.xtra.xfa.util;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.element;

public class PositionResult
{
  private PositionResult.State state;
  private XFARectangle rectangle;
  private float currentLeading;

  public PositionResult(PositionResult.State state) => this.state = state;

  public PositionResult(PositionResult.State state, XFARectangle rectangle)
  {
    this.state = state;
    this.rectangle = rectangle;
  }

  public PositionResult(PositionResult.State state, XFARectangle rectangle, float currentLeading)
  {
    this.state = state;
    this.rectangle = rectangle;
    this.currentLeading = currentLeading;
  }

  public PositionResult()
    : this(PositionResult.State.CONTENT_PART)
  {
  }

  public virtual PositionResult.State GetState() => this.state;

  public virtual void SetState(PositionResult.State state) => this.state = state;

  public virtual float CurrentLeading
  {
    get => this.currentLeading;
    set => this.currentLeading = value;
  }

  public virtual XFARectangle Rectangle
  {
    get => this.rectangle;
    set => this.rectangle = value;
  }

  public enum State
  {
    NO_CONTENT,
    CONTENT_PART,
    FULL_CONTENT,
  }
}
