// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.format.FormattingElement
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.text;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.format;

public class FormattingElement
{
  private string handedness = FormattingElement.HandednessType.EVEN;
  private string cap = FormattingElement.CapType.SQUARE;
  private string stroke = FormattingElement.StrokeType.SOLID;
  private string presence = "visible";
  private float? thickness = new float?(0.5f);
  private BaseColor color = BaseColor.BLACK;
  private float? x1;
  private float? y1;
  private float? x2;
  private float? y2;

  public FormattingElement()
  {
  }

  public FormattingElement(float? x1, float? y1, float? x2, float? y2)
  {
    this.x1 = x1;
    this.y1 = y1;
    this.x2 = x2;
    this.y2 = y2;
  }

  public virtual string Handedness
  {
    get => this.handedness;
    set => this.handedness = value;
  }

  public virtual string Cap
  {
    get => this.cap;
    set => this.cap = value;
  }

  public virtual string Stroke
  {
    get => this.stroke;
    set => this.stroke = value;
  }

  public virtual string Presence
  {
    get => this.presence;
    set => this.presence = value;
  }

  public virtual float? Thickness
  {
    get
    {
      float? thickness = this.thickness;
      return ((double) thickness.GetValueOrDefault() >= 0.0 ? 0 : (thickness.HasValue ? 1 : 0)) != 0 ? new float?(0.0f) : this.thickness;
    }
    set => this.thickness = value;
  }

  public virtual BaseColor Color
  {
    get => this.color;
    set => this.color = value;
  }

  public virtual float? X1
  {
    get => this.x1;
    set => this.x1 = value;
  }

  public virtual float? Y1
  {
    get => this.y1;
    set => this.y1 = value;
  }

  public virtual float? X2
  {
    get => this.x2;
    set => this.x2 = value;
  }

  public virtual float? Y2
  {
    get => this.y2;
    set => this.y2 = value;
  }

  public virtual void SetRectanglePoints(float? x1, float? y1, float? x2, float? y2)
  {
    this.x1 = x1;
    this.y1 = y1;
    this.x2 = x2;
    this.y2 = y2;
  }

  public static class HandednessType
  {
    public static string LEFT = "left";
    public static string EVEN = "even";
    public static string RIGHT = "right";
  }

  public static class CapType
  {
    public static string SQUARE = "square";
    public static string BUTT = "butt";
    public static string ROUND = "round";
  }

  public static class StrokeType
  {
    public static string SOLID = "solid";
    public static string DASH_DOT = "dashDot";
    public static string DASH_DOT_DOT = "dashDotDot";
    public static string DASHED = "dashed";
    public static string DOTTED = "dotted";
    public static string EMBOSSED = "embossed";
    public static string ETCHED = "etched";
    public static string LOWERED = "lowered";
    public static string RAISED = "raised";
  }
}
