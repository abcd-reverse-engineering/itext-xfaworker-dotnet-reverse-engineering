// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsArray
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// MVID: D599AAB6-B4A3-421F-BBC0-F95E613590FD
// Assembly location: C:\Users\Manager\AppData\Local\Temp\Jumoxal\65d368a2f0\lib\net40\Jint.dll

using Jint.Marshal;
using System;
using System.Collections.Generic;

#nullable disable
namespace Jint.Native;

[Serializable]
public class JsArray : JsObject
{
  private int length;
  protected SortedList<int, JsInstance> m_data = new SortedList<int, JsInstance>();

  public JsArray(JsObject prototype)
    : base(prototype)
  {
  }

  private JsArray(SortedList<int, JsInstance> data, int len, JsObject prototype)
    : base(prototype)
  {
    this.m_data = data;
    this.length = len;
  }

  public override bool IsClr => false;

  public override string Class => "Array";

  public override bool ToBoolean() => this.Length > 0;

  public override int Length
  {
    get => this.length;
    set => this.setLength(value);
  }

  public override JsInstance this[string index]
  {
    get
    {
      int result;
      return int.TryParse(index, out result) ? this.get(result) : base[index];
    }
    set
    {
      int result;
      if (int.TryParse(index, out result))
        this.put(result, value);
      else
        base[index] = value;
    }
  }

  public override JsInstance this[JsInstance key]
  {
    get
    {
      double number = key.ToNumber();
      int i = (int) number;
      return (double) i == number && i >= 0 ? this.get(i) : base[key.ToString()];
    }
    set
    {
      double number = key.ToNumber();
      int i = (int) number;
      if ((double) i == number && i >= 0)
        this.put(i, value);
      else
        base[key.ToString()] = value;
    }
  }

  public override void DefineOwnProperty(Descriptor d)
  {
    int result;
    if (int.TryParse(d.Name, out result))
      this.put(result, d.Get((JsDictionaryObject) this));
    else
      base.DefineOwnProperty(d);
  }

  public JsInstance get(int i)
  {
    JsInstance jsInstance;
    return !this.m_data.TryGetValue(i, out jsInstance) || jsInstance == null ? (JsInstance) JsUndefined.Instance : jsInstance;
  }

  public JsInstance put(int i, JsInstance value)
  {
    if (i >= this.length)
      this.length = i + 1;
    return this.m_data[i] = value;
  }

  private void setLength(int newLength)
  {
    if (newLength < 0)
      throw new ArgumentOutOfRangeException("New length is out of range");
    if (newLength < this.length)
    {
      int keyOrNext = this.FindKeyOrNext(newLength);
      if (keyOrNext >= 0)
      {
        for (int index = this.m_data.Count - 1; index >= keyOrNext; --index)
          this.m_data.RemoveAt(index);
      }
    }
    this.length = newLength;
  }

  public override bool TryGetProperty(string key, out JsInstance result)
  {
    result = (JsInstance) JsUndefined.Instance;
    int result1;
    return int.TryParse(key, out result1) ? this.m_data.TryGetValue(Convert.ToInt32(result1), out result) : base.TryGetProperty(key, out result);
  }

  private int FindKeyOrNext(int key)
  {
    int num1 = 0;
    int num2 = this.m_data.Count - 1;
    int index = 0;
    while (num1 <= num2)
    {
      int key1 = this.m_data.Keys[index];
      if (key1 == key)
        return index;
      if (key1 > key)
        num2 = index - 1;
      else
        num1 = index + 1;
      index = (num1 + num2) / 2;
    }
    return num1 >= this.m_data.Count ? -1 : num1;
  }

  private int FindKeyOrPrev(int key)
  {
    int num = 0;
    int keyOrPrev = this.m_data.Count - 1;
    int index = 0;
    while (num <= keyOrPrev)
    {
      int key1 = this.m_data.Keys[index];
      if (key1 == key)
        return index;
      if (key1 > key)
        keyOrPrev = index - 1;
      else
        num = index + 1;
      index = (num + keyOrPrev) / 2;
    }
    return keyOrPrev;
  }

  public override void Delete(JsInstance key)
  {
    double number = key.ToNumber();
    int key1 = (int) number;
    if ((double) key1 == number)
      this.m_data.Remove(key1);
    else
      base.Delete(key.ToString());
  }

  public override void Delete(string key)
  {
    int result;
    if (int.TryParse(key, out result))
      this.m_data.Remove(result);
    else
      base.Delete(key);
  }

  [RawJsMethod]
  public JsArray concat(IGlobal global, JsInstance[] args)
  {
    SortedList<int, JsInstance> data = new SortedList<int, JsInstance>((IDictionary<int, JsInstance>) this.m_data);
    int length = this.length;
    foreach (JsInstance inst in args)
    {
      if (inst is JsArray)
      {
        foreach (KeyValuePair<int, JsInstance> keyValuePair in ((JsArray) inst).m_data)
          data.Add(keyValuePair.Key + length, keyValuePair.Value);
        length += ((JsDictionaryObject) inst).Length;
      }
      else if (global.ArrayClass.HasInstance(inst as JsObject))
      {
        JsObject jsObject = (JsObject) inst;
        for (int index = 0; index < jsObject.Length; ++index)
        {
          JsInstance result;
          if (jsObject.TryGetProperty(index.ToString(), out result))
            data.Add(length + index, result);
        }
      }
      else
      {
        data.Add(length, inst);
        ++length;
      }
    }
    return new JsArray(data, length, global.ArrayClass.PrototypeProperty);
  }

  [RawJsMethod]
  public JsString join(IGlobal global, JsInstance separator)
  {
    if (this.length == 0)
      return global.StringClass.New();
    string separator1 = separator == JsUndefined.Instance ? "," : separator.ToString();
    string[] strArray = new string[this.length];
    for (int key = 0; key < this.length; ++key)
    {
      JsInstance jsInstance;
      strArray[key] = !this.m_data.TryGetValue(key, out jsInstance) || jsInstance == JsNull.Instance || jsInstance == JsUndefined.Instance ? "" : jsInstance.ToString();
    }
    return global.StringClass.New(string.Join(separator1, strArray));
  }

  public override string ToString()
  {
    List<JsInstance> jsInstanceList = new List<JsInstance>(this.GetValues());
    string[] strArray = new string[jsInstanceList.Count];
    for (int index = 0; index < jsInstanceList.Count; ++index)
    {
      if (jsInstanceList[index] != null)
        strArray[index] = jsInstanceList[index].ToString();
    }
    return string.Join(",", strArray);
  }

  private IEnumerable<string> baseGetKeys() => base.GetKeys();

  public override IEnumerable<string> GetKeys()
  {
    IList<int> keys = this.m_data.Keys;
    for (int i = 0; i < keys.Count; ++i)
      yield return keys[i].ToString();
    foreach (string key in this.baseGetKeys())
      yield return key;
  }

  private IEnumerable<JsInstance> baseGetValues() => base.GetValues();

  public override IEnumerable<JsInstance> GetValues()
  {
    IList<JsInstance> vals = this.m_data.Values;
    for (int i = 0; i < vals.Count; ++i)
      yield return vals[i];
    foreach (JsInstance val in this.baseGetValues())
      yield return val;
  }

  public override bool HasOwnProperty(string key)
  {
    int result;
    if (!int.TryParse(key, out result))
      return base.HasOwnProperty(key);
    return result >= 0 && result < this.length && this.m_data.ContainsKey(result);
  }

  public override double ToNumber() => (double) this.Length;

  public override bool Equals(object obj) => this == obj;
}
