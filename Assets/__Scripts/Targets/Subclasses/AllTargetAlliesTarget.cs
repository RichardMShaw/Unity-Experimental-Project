using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Project/Targets/All Target Allies")]
public class AllTargetAlliesTarget : Target
{
  public override List<BattleCharacter> GetTargets(BattleCharacter caster, BattleCharacter target)
  {
    return target.allies;
  }
}
