
using System;
using System.Collections.Generic;
using UnityEngine;
public struct PositionMonster
{
  public BattleMonster monster;

  public MonsterFormationPosition pos;

  public Vector3 position {
    get {
      return pos.position;
    }
  }

  public Quaternion rotation
  {
    get
    {
      return pos.rotation;
    }
  }

  public Vector3 scale
  {
    get
    {
      return pos.scale;
    }
  }

  public PositionMonster(BattleMonster _monster, MonsterFormationPosition _pos){
    monster = _monster;
    pos = _pos;
  }
}
