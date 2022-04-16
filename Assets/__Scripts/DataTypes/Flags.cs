using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class Flags
{

  public bool refreshDictionary;

  private bool initalized
  {
    get
    {
      return (dictionaryFlags != null);
    }
  }
  public List<Flag> values;

  private Dictionary<string, DictionaryFlag> dictionaryFlags;
  public object Save()
  {
    if (refreshDictionary || !initalized)
    {
      updateDictionary();
    }
    return values;
  }

  public void Load(object rawData)
  {
    values = (List<Flag>)rawData;
    updateDictionary();
  }

  private void updateDictionary()
  {
    if (dictionaryFlags == null)
    {
      dictionaryFlags = new Dictionary<string, DictionaryFlag>();
    }
    else
    {
      dictionaryFlags.Clear();
    }
    int len = values.Count;
    for (int i = 0; i < len; i++)
    {
      Flag flag = values[i];
      dictionaryFlags.Add(flag.key, new DictionaryFlag(flag, i));
    }
    refreshDictionary = false;

  }

  public int Get(string key)
  {
    if (refreshDictionary || !initalized)
    {
      updateDictionary();
    }
    if (!dictionaryFlags.ContainsKey(key))
    {
      dictionaryFlags.Add(key, new DictionaryFlag(key, 0, dictionaryFlags.Count));
    }
    return dictionaryFlags[key].value;
  }

  public void Set(Flag flag)
  {
    if (refreshDictionary || !initalized)
    {
      updateDictionary();
    }
    if (!dictionaryFlags.ContainsKey(flag.key))
    {
      dictionaryFlags.Add(flag.key, new DictionaryFlag(flag, dictionaryFlags.Count));
      values.Add(flag);
      return;
    }
    int index = dictionaryFlags[flag.key].index;
    dictionaryFlags[flag.key] = new DictionaryFlag(flag, index);
    values[index] = flag;
  }
  public void Set(string key, int value)
  {
    if (refreshDictionary || !initalized)
    {
      updateDictionary();
    }
    if (!dictionaryFlags.ContainsKey(key))
    {
      dictionaryFlags.Add(key, new DictionaryFlag(key, value, dictionaryFlags.Count));
      values.Add(new Flag(key, value));
      return;
    }
    int index = dictionaryFlags[key].index;
    dictionaryFlags[key] = new DictionaryFlag(key, value, index);
    values[index] = new Flag(key, value);

  }

  private struct DictionaryFlag
  {
    public string key;
    public int value;
    public int index;
    public DictionaryFlag(string _key, int _value, int _index)
    {
      key = _key;
      value = _value;
      index = _index;
    }

    public DictionaryFlag(Flag _flag, int _index)
    {
      key = _flag.key;
      value = _flag.value;
      index = _index;
    }
  }
}

[Serializable]
public struct Flag
{
  public string key;
  public int value;
  public Flag(string _key, int _value)
  {
    key = _key;
    value = _value;
  }
}