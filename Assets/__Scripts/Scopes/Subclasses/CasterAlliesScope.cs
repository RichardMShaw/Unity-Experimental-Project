using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Project/Scope/Allies")]
public class CasterAlliesScope : Scope
{
  public override List<BattleCharacter> GetValidTargets(BattleCharacter caster)
  {
    return caster.allies;
  }
}
