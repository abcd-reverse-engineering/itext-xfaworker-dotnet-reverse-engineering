// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.js.ResourceUtil
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using System;
using System.IO;
using System.Reflection;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa.js;

public static class ResourceUtil
{
  public static Stream GetResourceStream(string key)
  {
    return ResourceUtil.GetResourceStream(key, (Type) null);
  }

  public static Stream GetResourceStream(string key, Type definedClassType)
  {
    Stream resourceStream = (Stream) null;
    try
    {
      resourceStream = (definedClassType != (Type) null ? definedClassType.Assembly : typeof (ResourceUtil).Assembly).GetManifestResourceStream(key);
    }
    catch
    {
    }
    if (resourceStream != null)
      return resourceStream;
    foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
    {
      if (assembly.GetName().Name.ToLower().StartsWith("itext"))
      {
        resourceStream = ResourceUtil.SearchResourceInAssembly(key, (object) assembly);
        if (resourceStream != null)
          return resourceStream;
      }
    }
    return resourceStream;
  }

  private static Stream SearchResourceInAssembly(string key, object obj)
  {
    Stream stream = (Stream) null;
    try
    {
      if ((object) (obj as Assembly) != null)
      {
        stream = ((Assembly) obj).GetManifestResourceStream(key);
        if (stream != null)
          return stream;
      }
      else if (obj is string)
      {
        string str = (string) obj;
        try
        {
          stream = Assembly.LoadFrom(str).GetManifestResourceStream(key);
        }
        catch
        {
        }
        if (stream != null)
          return stream;
        string path2_1 = key.Replace('.', '/');
        string path1 = Path.Combine(str, path2_1);
        if (File.Exists(path1))
          return (Stream) new FileStream(path1, FileMode.Open, FileAccess.Read, FileShare.Read);
        int length = path2_1.LastIndexOf('/');
        if (length >= 0)
        {
          string path2_2 = $"{path2_1.Substring(0, length)}.{path2_1.Substring(length + 1)}";
          string path2 = Path.Combine(str, path2_2);
          if (File.Exists(path2))
            return (Stream) new FileStream(path2, FileMode.Open, FileAccess.Read, FileShare.Read);
        }
      }
    }
    catch
    {
    }
    return stream;
  }
}
