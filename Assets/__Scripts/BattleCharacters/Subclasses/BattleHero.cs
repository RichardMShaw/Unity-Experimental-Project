using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class BattleHero : BattleCharacter
{
  public HeroTemplate template;

  public override string name {
    get {
      return template.name;
    }
  }
  public List<SkillSlot> skillSlots;
  public override List<BattleCharacter> allies
  {
    get
    {
      return battleManager.heroes.GetPartyAsBaseClass();
    }
  }

  public override List<BattleCharacter> enemies
  {
    get
    {
      return battleManager.monsters.GetPartyAsBaseClass();
    }
  }

  public BattleHero(HeroPartySlot hero, BattleManager _battleManager)
  {
    template = hero.template;
    Initalize(template, _battleManager);
    foreach (var basicStat in hero.stats)
    {
      stats.SetBasicValue(basicStat.attribute, basicStat.basicValue);
    }
    skillSlots = new List<SkillSlot>();
    foreach(var skillSlot in hero.skillSlots){
      var copySkillSlot = new SkillSlot(skillSlot);
      skillSlots.Add(copySkillSlot);
    }
  }
}