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
}