// Decompiled with JetBrains decompiler
// Type: DVTA.DataTableToCsv
// Assembly: DVTA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6397275E-3082-406A-A289-EF4607C10E7B
// Assembly location: C:\Users\SUDEEPA\Downloads\dvta_modified\Release\DVTA.exe

using System;
using System.Data;
using System.IO;
using System.Text;

#nullable disable
namespace DVTA
{
  public static class DataTableToCsv
  {
    public static void WriteToCsvFile(this DataTable dataTable, string filePath)
    {
      StringBuilder stringBuilder = new StringBuilder();
      foreach (object column in (InternalDataCollectionBase) dataTable.Columns)
        stringBuilder.Append(column.ToString() + ",");
      stringBuilder.Replace(",", Environment.NewLine, stringBuilder.Length - 1, 1);
      foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
      {
        foreach (object obj in row.ItemArray)
          stringBuilder.Append("\"" + obj.ToString() + "\",");
        stringBuilder.Replace(",", Environment.NewLine, stringBuilder.Length - 1, 1);
      }
      File.WriteAllText(filePath, stringBuilder.ToString());
    }
  }
}
