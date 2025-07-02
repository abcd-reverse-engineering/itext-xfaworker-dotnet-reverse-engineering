// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.positioner.TableLayoutManager
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using iTextSharp.tool.xml.xtra.xfa.util;
using System.Collections.Generic;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.positioner;

public class TableLayoutManager : LayoutManager
{
  private List<Positioner> rows = new List<Positioner>();
  private List<float?> colWidths = new List<float?>();
  private Positioner tableNode;

  public TableLayoutManager(Positioner tag)
  {
    this.tableNode = tag;
    string str = tag.RetrieveAttribute("layout");
    if (!LayoutManager.tableLayout.Equals(str))
      return;
    this.ReadRowsRecursively(tag.Children);
    string source = this.tableNode.RetrieveAttribute("columnWidths");
    if (source == null)
      return;
    this.colWidths = XFAUtil.ParseNumArray(source);
  }

  public virtual void PreprocessHorizontalCellLayout()
  {
    this.PreprocessHorizontalCellLayout((Positioner) null);
  }

  public virtual void PreprocessHorizontalCellLayout(Positioner extraRow)
  {
    if (TableLayoutManager.IsDynamicTableLayout(this.tableNode.RetrieveAttribute("columnWidths")))
    {
      this.colWidths = new List<float?>();
      if (this.rows.Count > 0)
      {
        int num1 = 0;
        foreach (Positioner row in this.rows)
        {
          if (row.Children.Count > num1)
            num1 = row.Children.Count;
        }
        for (int index = 0; index < num1; ++index)
        {
          bool flag = true;
          float num2 = 0.0f;
          foreach (Positioner row in this.rows)
          {
            IList<Positioner> children = row.Children;
            if (index < children.Count)
            {
              Positioner positioner = children[index];
              if (!positioner.IsHidden() && !positioner.IsInactive())
              {
                flag = false;
                XFARectangle contentArea = positioner.GetContentArea();
                if (contentArea.Width.HasValue)
                {
                  float? width = contentArea.Width;
                  float num3 = num2;
                  if (((double) width.GetValueOrDefault() <= (double) num3 ? 0 : (width.HasValue ? 1 : 0)) != 0)
                    num2 = contentArea.Width.Value;
                }
              }
            }
          }
          if (!flag)
            this.colWidths.Add(new float?(num2));
        }
      }
    }
    if (this.colWidths.Count <= 0)
      return;
    if (extraRow != null)
    {
      this.rows = new List<Positioner>();
      this.ReadRowsRecursively(extraRow);
    }
    foreach (Positioner row in this.rows)
    {
      int num4 = 0;
      float num5 = 0.0f;
      IList<Positioner> children = row.Children;
      for (int index1 = 0; index1 < children.Count; ++index1)
      {
        Positioner positioner = children[index1];
        if (!positioner.IsHidden() && !positioner.IsInactive())
        {
          string s = positioner.RetrieveAttribute("colSpan");
          if (s == null || s.Length == 0)
            s = "1";
          int? nullable1 = new int?(int.Parse(s));
          float num6 = 0.0f;
          int? nullable2 = nullable1;
          if ((nullable2.GetValueOrDefault() != -1 ? 0 : (nullable2.HasValue ? 1 : 0)) != 0)
          {
            nullable1 = new int?(this.colWidths.Count - num4);
            for (int index2 = index1 + 1; index2 < children.Count; ++index2)
              children[index2].DefineProperty("presence", (object) "hidden");
          }
          int index3 = num4;
          while (true)
          {
            int num7 = index3;
            int? nullable3 = nullable1;
            int? nullable4;
            if ((nullable3.GetValueOrDefault() < 0 ? 0 : (nullable3.HasValue ? 1 : 0)) == 0)
            {
              nullable4 = new int?(this.colWidths.Count);
            }
            else
            {
              int num8 = num4;
              int? nullable5 = nullable1;
              nullable4 = nullable5.HasValue ? new int?(num8 + nullable5.GetValueOrDefault()) : new int?();
            }
            int? nullable6 = nullable4;
            if ((num7 >= nullable6.GetValueOrDefault() ? 0 : (nullable6.HasValue ? 1 : 0)) != 0)
            {
              if (index3 < this.colWidths.Count)
                num6 += this.colWidths[index3].Value;
              ++index3;
            }
            else
              break;
          }
          positioner.X = new float?(num5);
          positioner.Width = new float?(num6);
          num5 += num6;
          num4 += nullable1.Value;
        }
      }
    }
  }

  private void ReadRowsRecursively(Positioner node)
  {
    string str = node.RetrieveAttribute("layout");
    if (LayoutManager.tableLayout.Equals(str))
      return;
    if (LayoutManager.rowLayout.Equals(str))
      this.rows.Add(node);
    else
      this.ReadRowsRecursively(node.Children);
  }

  private void ReadRowsRecursively(IList<Positioner> tagList)
  {
    foreach (Positioner tag in (IEnumerable<Positioner>) tagList)
      this.ReadRowsRecursively(tag);
  }

  public static Positioner GetParentTable(Positioner node)
  {
    Positioner parent = node.Parent;
    return parent != null && !LayoutManager.tableLayout.Equals(parent.RetrieveAttribute("layout")) ? TableLayoutManager.GetParentTable(parent) : parent;
  }

  public static bool IsDynamicTableLayout(string columnWidthsParameter)
  {
    if (columnWidthsParameter == null)
      return true;
    List<float?> numArray = XFAUtil.ParseNumArray(columnWidthsParameter);
    bool flag = true;
    foreach (float? nullable in numArray)
    {
      if (((double) nullable.GetValueOrDefault() != 0.0 ? 1 : (!nullable.HasValue ? 1 : 0)) != 0)
      {
        flag = false;
        break;
      }
    }
    return flag;
  }

  public static float? GetNthColumnWidth(string columnWidthsParameter, int n)
  {
    if (columnWidthsParameter == null)
      return new float?();
    IList<float?> numArray = (IList<float?>) XFAUtil.ParseNumArray(columnWidthsParameter);
    return numArray.Count <= n ? new float?(-1f) : numArray[n];
  }
}
