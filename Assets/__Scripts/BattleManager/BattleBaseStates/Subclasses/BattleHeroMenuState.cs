using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHeroMenuState : BattleBaseState
{

  public BattleHeroMenuState(BattleManager currentContext, BattleStateFactory factory) : base(currentContext, factory) { }

  public override void EnterState()
  {
    _ctx.selectedHero = null;
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

  }

}
