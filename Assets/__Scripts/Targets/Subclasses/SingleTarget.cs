using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Project/Targets/Single")]
public class SingleTarget : Target
{
  public override List<BattleCharacter> GetTargets(BattleCharacter caster, BattleCharacter target)
  {
    var result = new List<BattleCharacter>();
    result.Add(target);
    return result;
  }
}
