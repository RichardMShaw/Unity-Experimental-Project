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
    var skillQueueSlot = new SkillQueueSlot(_ctx.selectedHero, hero, _ctx.selectedSkillSlot);
    _ctx.clearSkillQueueChannel.RaiseEvent();
    _ctx.enqueueSkillChannel.RaiseEvent(skillQueueSlot);
    SwitchState(_factory.HeroSkill());
  }

  public override void OnBattleHeroSkillSlotSelect(SkillSlot skillSlot)
  {

  }

  public override void OnBattleMonsterSelect(BattleMonster monster)
  {
    var skillQueueSlot = new SkillQueueSlot(_ctx.selectedHero, monster, _ctx.selectedSkillSlot);
    _ctx.clearSkillQueueChannel.RaiseEvent();
    _ctx.enqueueSkillChannel.RaiseEvent(skillQueueSlot);
    SwitchState(_factory.HeroSkill());
  }
  public override void OnSkillQueueComplete()
  {

  }

}
