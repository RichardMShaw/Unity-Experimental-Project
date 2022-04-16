using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Project/Targets/Random")]
public class RandomTarget : Target
{
  public override List<BattleCharacter> GetTargets(BattleCharacter caster, BattleCharacter target)
  {
    var result = new List<BattleCharacter>();
    int alliesCount = caster.allies.Count;
    int len = alliesCount;
    len += caster.enemies.Count;
    int index = Random.Range(0, len);
    if (index > alliesCount - 1)
    {
      result.Add(caster.enemies[index - alliesCount]);
    }
    else
    {
      result.Add(caster.allies[index]);
    }
    return result;
  }
}
