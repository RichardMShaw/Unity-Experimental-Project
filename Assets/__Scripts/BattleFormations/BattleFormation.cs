using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Project/Battles/Monster Formation")]
public class BattleFormation : ScriptableObject
{
  public List<MonsterFormation> formations;

  public MonsterFormation GetMonsterFormation(List<BattleMonster> list){
    var len = list.Count - 1;
    foreach(var formation in formations){
      if(len < formation.Count){
        return formation;
      }
    }
    return formations[formations.Count-1];
  }
}

[Serializable]
public struct MonsterFormation 
{
  public List<MonsterFormationPosition> formationPositions;

  public int Count {
    get {
      return formationPositions.Count;
    }
  }
}

[Serializable]
public struct MonsterFormationPosition
{
  public Vector3 position;
  public Quaternion rotation;
  public Vector3 scale;
}