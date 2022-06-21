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
  [HideInInspector]
  public BattleManager battleManager;

  [Header("Flags")]
  public bool unkillable;
  public bool removeable;
  public bool knockedOut;
  public bool Targetable {
    get {
      return !knockedOut;
    }
  }

  [Header("Stats")]
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

  public virtual int SetStatBasicValue(Attribute attribute, int value)
  {
    return stats.SetBasicValue(attribute, value);
  }

  public virtual int ChangeStatBasicValue(Attribute attribute, int value)
  {
    int newVal = stats.ChangeBasicValue(attribute, value);
    return newVal;
  }

  public void Initalize(CharacterTemplate template, BattleManager _battleManager)
  {
    battleManager = _battleManager;
    unkillable = template.unkillable;
    removeable = template.removeable;
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