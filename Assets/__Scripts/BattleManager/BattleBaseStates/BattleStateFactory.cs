using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BattleStateFactory
{
  [SerializeField]
  private BattleManager _context;

  public BattleStateFactory(BattleManager currentContext)
  {
    _context = currentContext;
  }
  public BattleBaseState HeroMenu()
  {
    return new BattleHeroMenuState(_context, this);
  }
  public BattleBaseState HeroSkillMenu()
  {
    return new BattleHeroSkillMenuState(_context, this);
  }
  public BattleBaseState HeroSelectTarget()
  {
    return new BattleHeroSelectTargetState(_context, this);
  }
  public BattleBaseState HeroSkill()
  {
    return new BattleHeroSkillState(_context, this);
  }
}