using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class BattleCharacter
{
  public virtual string name
  {
    get
    {
      return "";
    }
  }

  public virtual SpriteData spriteData
  {
    get
    {
      return null;
    }
  }
  public BattleManager battleManager;
  public StatAttributes stats;


  public virtual List<BattleCharacter> allies
  {
    get
    {
      return null;
    }
  }

  public virtual List<BattleCharacter> enemies
  {
    get
    {
      return null;
    }
  }

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

  public int SetStatBasicValue(Attribute attribute, int value)
  {
    return stats.SetBasicValue(attribute, value);
  }

  public int ChangeStatBasicValue(Attribute attribute, int value)
  {
    int newVal = stats.ChangeBasicValue(attribute, value);
    // if(newVal < 1 && BasicAttribute.Health == attribute){

    // }
    return newVal;
  }

  public void Initalize(CharacterTemplate template, BattleManager _battleManager)
  {
    battleManager = _battleManager;
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