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

  public override void OnBattleHeroSkillSlotSelect(SkillSlot skillSlot)
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
