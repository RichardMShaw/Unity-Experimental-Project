using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleBaseState
{
  protected BattleManager _ctx;
  protected BattleStateFactory _factory;
  public BattleBaseState(BattleManager currentContext, BattleStateFactory factory){
    _ctx = currentContext;
    _factory = factory;
  }
  public abstract void EnterState();
  public abstract void ExitState();
  public abstract void OnBattleHeroSelect(BattleHero hero);
  public abstract void OnBattleHeroSkillSlotSelect(SkillSlot skilleSlot);
  public abstract void OnBattleMonsterSelect(BattleMonster monster);

  protected void SwitchState(BattleBaseState newState){
    ExitState();
    _ctx.currentState = newState;
    newState.EnterState();
  }
}