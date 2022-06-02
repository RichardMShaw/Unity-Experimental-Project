using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHeroSkillState : BattleBaseState
{

  public BattleHeroSkillState(BattleManager currentContext, BattleStateFactory factory) : base(currentContext, factory) { }

  public override void EnterState()
  {
    _ctx.selectedHero = null;
    _ctx.selectedSkillSlot = null;
    _ctx.processSkillQueueChannel.RaiseEvent();
  }

  public override void ExitState()
  {
  }

  public override void OnBattleHeroSelect(BattleHero hero)
  {
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
    _ctx.updateBattleMonsterHealthBar.RaiseEvent();
    _ctx.updateBattleHeroStatBars.RaiseEvent();
    SwitchState(_factory.HeroMenu());
  }

}
