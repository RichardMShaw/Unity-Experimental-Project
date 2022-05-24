using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHeroSelectTargetState : BattleBaseState
{

  public BattleHeroSelectTargetState(BattleManager currentContext, BattleStateFactory factory) : base(currentContext, factory) { }

  public override void EnterState()
  {
  }

  public override void ExitState()
  {
  }

  public override void OnBattleHeroSelect(BattleHero hero)
  {
    _ctx.selectedHero = hero;
    SwitchState(_factory.HeroSkillMenu());
  }

  public override void OnBattleHeroSkillSlotSelect(SkillSlot skillSlot)
  {

  }

  public override void OnBattleMonsterSelect(BattleMonster monster)
  {
    Debug.Log(monster);
  }

}
