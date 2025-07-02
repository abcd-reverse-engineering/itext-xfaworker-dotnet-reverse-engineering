// Decompiled with JetBrains decompiler
// Type: iTextSharp.tool.xml.xtra.xfa.SettableLatch
// Assembly: itextsharp.xfaworker, Version=5.5.13.2, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: 91262044-DE4C-4E8C-AEF3-8C45032F8C31
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\itextsharp.xfaworker.dll

using System;
using System.Threading;

#nullable disable
namespace iTextSharp.tool.xml.xtra.xfa;

public class SettableLatch
{
  private int locks;
  private int interrups;
  private object _lock;

  public SettableLatch()
  {
    this._lock = new object();
    this.locks = 0;
    this.interrups = 0;
  }

  public virtual void Set(int runs)
  {
    lock (this._lock)
    {
      try
      {
        this.locks = runs;
        this.interrups = 0;
      }
      finally
      {
        Monitor.PulseAll(this._lock);
      }
    }
  }

  public virtual int Get()
  {
    lock (this._lock)
    {
      try
      {
        return this.locks;
      }
      finally
      {
        Monitor.PulseAll(this._lock);
      }
    }
  }

  public virtual void Decrement()
  {
    lock (this._lock)
    {
      try
      {
        --this.locks;
      }
      finally
      {
        Monitor.PulseAll(this._lock);
      }
    }
  }

  public virtual void IncrementInterrups()
  {
    lock (this._lock)
    {
      try
      {
        ++this.interrups;
      }
      finally
      {
        Monitor.PulseAll(this._lock);
      }
    }
  }

  public virtual void Await()
  {
    lock (this._lock)
    {
      while (this.locks > 0 && this.interrups != this.locks)
        Monitor.Wait(this._lock);
    }
  }

  public virtual void Await(long ms)
  {
    DateTime dateTime = DateTime.Now.AddMilliseconds((double) ms);
    lock (this._lock)
    {
      while (this.locks > 0 && this.interrups != this.locks && DateTime.Now < dateTime)
        Monitor.Wait(this._lock, 1);
    }
  }
}
