using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHeroSkillMenuState : BattleBaseState
{
  public BattleHeroSkillMenuState(BattleManager currentContext, BattleStateFactory factory) : base(currentContext, factory) { }
  public override void EnterState()
  {
    if (_ctx.selectedHero == null)
    {
      SwitchState(_factory.HeroMenu());
      return;
    }
    _ctx.loadBattleSkillMenuChannel.RaiseEvent(_ctx.selectedHero);
  }

  public override void ExitState()
  {
    _ctx.hideBattleSkillMenuChannel.RaiseEvent();
  }

  public override void OnBattleHeroSelect(BattleHero hero)
  {
    if(_ctx.selectedHero == hero){
      SwitchState(_factory.HeroMenu());
      return;
    }
    _ctx.selectedHero = hero;
    SwitchState(_factory.HeroSkillMenu());
  }

  public override void OnBattleHeroSkillSlotSelect(SkillSlot skillSlot)
  {
    _ctx.selectedSkillSlot = skillSlot;
    SwitchState(_factory.HeroSelectTarget());
  }


  public override void OnBattleMonsterSelect(BattleMonster monster)
  {

  }
}