using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Project/Scope/Any")]
public class AnyScope : Scope
{
  public override List<BattleCharacter> GetValidTargets(BattleCharacter caster)
  {
    var result = new List<BattleCharacter>();
    var allies = caster.allies;
    int len = allies.Count;
    for (int i = 0; i < len; i++)
    {
      result.Add(allies[i]);
    }
    var enemies = caster.enemies;
    len = enemies.Count;
    for (int i = 0; i < len; i++)
    {
      result.Add(enemies[i]);
    }
    return result;
  }
}
