// Decompiled with JetBrains decompiler
// Type: Jint.Debugger.SourceCodeDescriptor
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using System;

#nullable disable
namespace Jint.Debugger;

[Serializable]
public class SourceCodeDescriptor
{
  protected SourceCodeDescriptor.Location start;
  protected SourceCodeDescriptor.Location stop;

  public SourceCodeDescriptor.Location Start
  {
    get => this.start;
    set => this.start = value;
  }

  public SourceCodeDescriptor.Location Stop
  {
    get => this.stop;
    set => this.stop = value;
  }

  public string Code { get; private set; }

  public SourceCodeDescriptor(
    int startLine,
    int startChar,
    int stopLine,
    int stopChar,
    string code)
  {
    this.Code = code;
    this.Start = new SourceCodeDescriptor.Location(startLine, startChar);
    this.Stop = new SourceCodeDescriptor.Location(stopLine, stopChar);
  }

  public override string ToString()
  {
    return $"Line: {(object) this.Start.Line} Char: {(object) this.Start.Char}";
  }

  [Serializable]
  public class Location
  {
    private int line;
    private int _Char;

    public Location(int line, int c)
    {
      this.line = line;
      this._Char = c;
    }

    public int Line
    {
      get => this.line;
      set => this.line = value;
    }

    public int Char
    {
      get => this._Char;
      set => this._Char = value;
    }
  }
}
