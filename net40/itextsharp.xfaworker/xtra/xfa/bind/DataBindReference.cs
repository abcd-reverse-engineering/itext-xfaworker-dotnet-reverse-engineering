// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.bind.DataBindReference
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.bind;

public class DataBindReference
{
  private string[] referenceParts;

  private DataBindReference(string[] referenceParts) => this.referenceParts = referenceParts;

  public int Size() => this.referenceParts.Length;

  public string GetItem(int idx) => this.referenceParts[idx];

  public static DataBindReference CreateSimple(string @ref)
  {
    return new DataBindReference(new string[1]{ @ref });
  }

  public static DataBindReference CreateFromSom(string dataRef)
  {
    return new DataBindReference(dataRef.Split('.'));
  }
}
