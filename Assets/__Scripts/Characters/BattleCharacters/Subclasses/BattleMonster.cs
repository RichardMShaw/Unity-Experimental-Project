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
  public BattleMonster(MonsterTemplate monster, BattleManager _battleManager)
  {
    template = monster;
    Initalize(template, _battleManager);
  }
}
