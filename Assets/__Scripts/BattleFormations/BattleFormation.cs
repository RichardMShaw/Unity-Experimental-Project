using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Project/Battles/Formation")]
public class BattleFormation : ScriptableObject
{
  public List<Formation> formations;

  public Formation GetFormation(List<BattleCharacter> list){
    var len = list.Count - 1;
    foreach(var formation in formations){
      if(len < formation.formationPositions.Count){
        return formation;
      }
    }
    return formations[formations.Count-1];
  }
}

[Serializable]
public struct Formation 
{
  public List<FormationPosition> formationPositions;
}

[Serializable]
public struct FormationPosition
{
  public Vector3 position;
  public Vector3 rotation;
  public Vector3 scale;
}