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

  public override int SetStatBasicValue(Attribute attribute, int value)
  {
    if(!unkillable && attribute == BasicAttribute.Health && value < 1){
      knockedOut = true;
      battleManager.BattleHeroKnockout(this);
    }
    return stats.SetBasicValue(attribute, value);
  }

  public override int ChangeStatBasicValue(Attribute attribute, int value)
  {
    int newVal = stats.ChangeBasicValue(attribute, value);
    if (!unkillable && attribute == BasicAttribute.Health && newVal < 1)
    {
      knockedOut = true;
      battleManager.BattleHeroKnockout(this);
    }
    return newVal;
  }

  public BattleHero(HeroPartySlot hero, BattleManager _battleManager)
  {
    template = hero.template;
    Initalize(template, _battleManager);
    knockedOut = hero.knockedOut;
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