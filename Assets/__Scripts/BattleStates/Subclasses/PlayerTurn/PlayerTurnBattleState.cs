using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Project/Battle State/Player Turn/Player Turn")]
public class PlayerTurnBattleState : BattleState
{
  public BattleState subState;

  public override void OnBattleHeroSelect(BattleHero hero)
  {

  }

}
