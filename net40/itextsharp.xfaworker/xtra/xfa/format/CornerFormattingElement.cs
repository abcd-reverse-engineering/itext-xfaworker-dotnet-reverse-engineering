// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.format.CornerFormattingElement
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.format;

public class CornerFormattingElement : FormattingElement
{
  private string join = "square";
  private string inverted = "0";
  private float? radius = new float?(0.0f);
  private float? centerX;
  private float? centerY;

  public virtual string Join
  {
    get => this.join;
    set => this.join = value;
  }

  public virtual string Inverted
  {
    get => this.inverted;
    set => this.inverted = value;
  }

  public virtual bool IsInverted() => "1".Equals(this.Inverted);

  public virtual float? Radius
  {
    get => this.radius;
    set => this.radius = value;
  }

  public virtual float? CenterX => this.centerX;

  public virtual float? CenterY => this.centerY;

  public virtual void SetCenter(float? centerX, float? centerY)
  {
    this.centerX = centerX;
    this.centerY = centerY;
  }

  public override float? Thickness
  {
    get
    {
      float? thickness = base.Thickness;
      float? radius1 = this.Radius;
      float? nullable = radius1.HasValue ? new float?(radius1.GetValueOrDefault() * 2f) : new float?();
      if (((double) thickness.GetValueOrDefault() <= (double) nullable.GetValueOrDefault() ? 0 : (thickness.HasValue & nullable.HasValue ? 1 : 0)) == 0)
        return base.Thickness;
      float? radius2 = this.Radius;
      return !radius2.HasValue ? new float?() : new float?(radius2.GetValueOrDefault() * 2f);
    }
  }
}
