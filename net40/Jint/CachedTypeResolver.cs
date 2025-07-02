// Decompiled with JetBrains decompiler
// Type: Jint.CachedTypeResolver
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;

#nullable disable
namespace Jint;

public class CachedTypeResolver : ITypeResolver
{
  private readonly Dictionary<string, Type> _cache = new Dictionary<string, Type>();
  private readonly ReaderWriterLock _lock = new ReaderWriterLock();
  private static CachedTypeResolver _default;

  public static CachedTypeResolver Default
  {
    get
    {
      lock (typeof (CachedTypeResolver))
        return CachedTypeResolver._default ?? (CachedTypeResolver._default = new CachedTypeResolver());
    }
  }

  public Type ResolveType(string fullname)
  {
    this._lock.AcquireReaderLock(-1);
    try
    {
      if (this._cache.ContainsKey(fullname))
        return this._cache[fullname];
      Type type = (Type) null;
      foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
      {
        type = assembly.GetType(fullname, false, false);
        if (type != (Type) null)
          break;
      }
      this._lock.UpgradeToWriterLock(-1);
      this._cache.Add(fullname, type);
      return type;
    }
    finally
    {
      this._lock.ReleaseLock();
    }
  }
}
