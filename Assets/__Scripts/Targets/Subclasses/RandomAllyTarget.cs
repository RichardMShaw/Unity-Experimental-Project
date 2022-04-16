using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Project/Targets/Random Ally")]
public class RandomAllyTarget : Target
{
  public override List<BattleCharacter> GetTargets(BattleCharacter caster, BattleCharacter target)
  {
    var result = new List<BattleCharacter>();
    var allies = caster.allies;
    int len = allies.Count;
    int index = Random.Range(0, len - 1);
    result.Add(allies[index]);
    return result;
  }
}
