using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Project/Targets/All Allies")]
public class AllAlliesTarget : Target
{
  public override List<BattleCharacter> GetTargets(BattleCharacter caster, BattleCharacter target)
  {
    return caster.allies;
  }
}
