using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHeroMenuState : BattleBaseState
{

  public BattleHeroMenuState(BattleManager currentContext, BattleStateFactory factory) : base(currentContext, factory) { }

  public override void EnterState()
  {
    _ctx.unselectBattleHero.RaiseEvent();
    _ctx.selectedHero = null;
  }

  public override void ExitState()
  {
  }

  public override void OnBattleHeroSelect(BattleHero hero)
  {
    _ctx.selectedHero = hero;
    _ctx.selectBattleHero.RaiseEvent(hero);
    SwitchState(_factory.HeroSkillMenu());
  }

  public override void OnBattleHeroStopHover(BattleHero hero)
  {
    _ctx.hideBattleHeroHighlight.RaiseEvent(hero);
  }
  public override void OnBattleHeroHover(BattleHero hero)
  {
    _ctx.showBattleHeroHighlight.RaiseEvent(hero);
  }

  public override void OnBattleHeroSkillSlotSelect(SkillSlot skillSlot)
  {

  }
  public override void OnBattleMonsterStopHover(BattleMonster monster)
  {

  }
  public override void OnBattleMonsterHover(BattleMonster monster)
  {

  }
  public override void OnBattleMonsterSelect(BattleMonster monster)
  {

  }
  public override void OnSkillQueueComplete()
  {

  }

}
