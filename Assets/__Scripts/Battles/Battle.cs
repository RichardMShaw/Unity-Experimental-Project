using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Project/Battles/Battle")]
public class Battle : ScriptableObject
{
  public CameraSetting cameraSetting;
  public BattleFormation formation;
  public HeroParty heroParty;
  public List<MonsterTemplate> monsterParty;

  public List<MonsterTemplate> monsters
  {
    get
    {
      return monsterParty;
    }
  }
  public List<HeroPartySlot> heroes
  {
    get
    {
      return heroParty.heroes;
    }
  }

}
