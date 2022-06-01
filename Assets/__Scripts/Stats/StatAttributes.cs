using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//A wrapper for Attributes and Stats
[Serializable]
public class StatAttributes
{
  public Dictionary<Attribute, Stat> stats;

  public List<StatAttribute> statAttributes;

  public StatAttributes()
  {
    stats = new Dictionary<Attribute, Stat>();
    statAttributes = new List<StatAttribute>();
  }
  public Stat GetStat(Attribute attribute)
  {
    if (stats.ContainsKey(attribute))
    {
      return stats[attribute];
    }
    var newStat = new Stat(attribute);
    stats.Add(attribute, newStat);
    statAttributes.Add(new StatAttribute(attribute, newStat));
    return newStat;
  }
  public int GetValue(Attribute attribute)
  {
    if (stats.ContainsKey(attribute))
    {
      return stats[attribute].value;
    }
    return attribute.defaultValue;
  }

  public int GetBasicValue(Attribute attribute)
  {
    if (stats.ContainsKey(attribute))
    {
      return stats[attribute].basicValue;
    }
    return attribute.defaultValue;
  }
  public int SetBasicValue(Attribute attribute, int value)
  {
    if (stats.ContainsKey(attribute))
    {
      var stat = stats[attribute];
      stat.basicValue = value;
      return value;
    }
    var newStat = new Stat(attribute);
    stats.Add(attribute, newStat);
    statAttributes.Add(new StatAttribute(attribute, newStat));
    newStat.basicValue = value;
    return newStat.basicValue;
  }

  public int ChangeBasicValue(Attribute attribute, int value)
  {
    if (stats.ContainsKey(attribute))
    {
      var stat = stats[attribute];
      stat.basicValue += value;
      return stat.basicValue;
    }
    var newStat = new Stat(attribute);
    stats.Add(attribute, newStat);
    statAttributes.Add(new StatAttribute(attribute, newStat));
    newStat.basicValue += value;
    return newStat.basicValue;
  }
  public void AddModifier(Attribute attribute, StatModifier modifier)
  {
    if (!stats.ContainsKey(attribute))
    {
      var newStat = new Stat(attribute);
      stats.Add(attribute, newStat);
      statAttributes.Add(new StatAttribute(attribute, newStat));
      newStat.AddModifier(modifier);
      return;
    }
    var stat = stats[attribute];
    stat.AddModifier(modifier);

  }

  public void RemoveModifier(Attribute attribute, StatModifier modifier)
  {
    if (!stats.ContainsKey(attribute))
    {
      return;
    }
    var stat = stats[attribute];
    stat.RemoveModifier(modifier);
  }

  public void AddAttribute(Attribute attribute, int value)
  {
    if (stats.ContainsKey(attribute))
    {
      return;
    }
    var newStat = new Stat(attribute, value);
    stats.Add(attribute, newStat);
    statAttributes.Add(new StatAttribute(attribute, newStat));
  }
  public void AddBasicAttribute(Attribute attribute, int value, int basicValue)
  {
    if (stats.ContainsKey(attribute))
    {
      return;
    }
    var newStat = new Stat(attribute, value, basicValue);
    stats.Add(attribute, newStat);
    statAttributes.Add(new StatAttribute(attribute, newStat));
  }
}

[Serializable]
public struct StatAttribute
{
  public Attribute attribute;
  public Stat stat;

  public StatAttribute(Attribute _attribute, Stat _stat)
  {
    attribute = _attribute;
    stat = _stat;
  }
}

