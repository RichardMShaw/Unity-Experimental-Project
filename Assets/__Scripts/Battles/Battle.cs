using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Project/Battles/Battle")]
public class Battle : ScriptableObject
{
  public CameraSetting cameraSetting;
  public BattleFormation formation;

  public List<MonsterTemplate> monsterGroup;

}
