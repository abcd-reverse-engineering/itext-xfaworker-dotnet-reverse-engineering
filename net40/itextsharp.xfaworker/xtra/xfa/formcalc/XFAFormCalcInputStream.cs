// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.formcalc.XFAFormCalcInputStream
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using Antlr4.Runtime;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.formcalc;

public class XFAFormCalcInputStream(string input) : AntlrInputStream(input)
{
  public virtual int La(int i)
  {
    if (i == 0)
      return 0;
    if (i < 0)
    {
      ++i;
      if (this.p + i - 1 < 0)
        return -1;
    }
    return this.p + i - 1 >= this.n ? -1 : (int) char.ToLowerInvariant(this.data[this.p + i - 1]);
  }
}
