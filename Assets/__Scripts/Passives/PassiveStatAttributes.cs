using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public struct PassiveStatAttributes
{
  public List<PassiveStatAttribute> statAttributes;
  public Dictionary<PassiveAttribute, PassiveStat> stats;
  public void SetValue(PassiveAttribute type, int value)
  {
    if (!stats.ContainsKey(type))
    {
      return;
    }
    var stat = stats[type];
    stat.value = value;
  }

  public int GetValue(PassiveAttribute type)
  {
    if (!stats.ContainsKey(type))
    {
      return type.defaultValue;
    }

    return stats[type].value;
  }
}


public struct PassiveStatAttribute
{
  public PassiveAttribute type;

  public PassiveStat stat;

  public int value
  {
    get
    {
      return stat.value;
    }

    set
    {
      stat.value = value;
    }
  }

  public PassiveStatAttribute(PassiveAttribute _type, PassiveStat _stat)
  {
    type = _type;
    stat = _stat;
  }
}