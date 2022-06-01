using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Project/Targets/Random Enemy")]
public class RandomEnemyTarget : Target
{
  public override List<BattleCharacter> GetTargets(BattleCharacter caster, BattleCharacter target)
  {
    var result = new List<BattleCharacter>();
    var enemies = target.allies;
    int len = enemies.Count;
    int index = Random.Range(0, len);
    result.Add(enemies[index]);
    return result;
  }
}
