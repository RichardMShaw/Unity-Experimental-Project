using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BattleCharacter
{
  public CharacterTemplate template;

  public StatAttributes stats;

  public List<BattleCharacter> allies;

  public List<BattleCharacter> enemies;

  public Stat GetStat(Attribute attribute)
  {
    return stats.GetStat(attribute);
  }
  public float GetStatValue(Attribute attribute)
  {
    return stats.GetValue(attribute);
  }

  public int GetStatBasicValue(Attribute attribute)
  {
    return stats.GetBasicValue(attribute);
  }

  public void initalizer(CharacterTemplate template)
  {
    stats = new StatAttributes();
    foreach (var stat in template.basicStats)
    {
      stats.AddBasicAttribute(stat.attribute, stat.value, stat.basicValue);
    }
    foreach (var stat in template.coreStats)
    {
      stats.AddAttribute(stat.attribute, stat.value);
    }
    foreach (var element in template.elementStats)
    {
      stats.AddAttribute(element.element.powerAttribute, element.power);
      stats.AddAttribute(element.element.weaknessAttribute, element.weakness);
    }

  }
}