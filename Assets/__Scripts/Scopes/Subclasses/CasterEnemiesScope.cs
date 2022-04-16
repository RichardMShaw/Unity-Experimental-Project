using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Project/Scope/Enemies")]
public class CasterEnemiesScope : Scope
{
  public override List<BattleCharacter> GetValidTargets(BattleCharacter caster)
  {
    return caster.enemies;
  }
}
