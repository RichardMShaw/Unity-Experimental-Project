using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BattleMonster : BattleCharacter
{
  public MonsterTemplate template;

  public override string name
  {
    get
    {
      return template.name;
    }
  }

  public override SpriteData spriteData
  {
    get
    {
      return template.spriteData;
    }
  }
  public override List<BattleCharacter> allies
  {
    get
    {
      return battleManager.monsters.GetPartyAsBaseClass();
    }
  }

  public override List<BattleCharacter> enemies
  {
    get
    {
      return battleManager.heroes.GetPartyAsBaseClass();
    }
  }
  public override int SetStatBasicValue(Attribute attribute, int value)
  {
    if (!unkillable && attribute == BasicAttribute.Health && value < 1)
    {
      knockedOut = true;
      battleManager.BattleMonsterKnockout(this);
    }
    return stats.SetBasicValue(attribute, value);
  }

  public override int ChangeStatBasicValue(Attribute attribute, int value)
  {
    int newVal = stats.ChangeBasicValue(attribute, value);
    if (!unkillable && attribute == BasicAttribute.Health && newVal < 1)
    {
      knockedOut = true;
      battleManager.BattleMonsterKnockout(this);
    }
    return newVal;
  }
  public BattleMonster(MonsterTemplate monster, BattleManager _battleManager)
  {
    template = monster;
    Initalize(template, _battleManager);
  }
}
