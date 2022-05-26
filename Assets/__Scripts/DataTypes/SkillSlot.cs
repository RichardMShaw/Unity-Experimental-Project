using System;
using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;

[Serializable]
public struct SkillSlot
{
  public Skill skill;

  public string Name
  {
    get { return skill.name; }
  }

  public SkillSlot(Skill _skill)
  {
    skill = _skill;
  }
  public SkillSlot(SkillSlot skillSlot)
  {
    skill = skillSlot.skill;
  }

  public bool AttemptCast(BattleCharacter caster, BattleCharacter target){
    var costs = skill.costs;
    foreach(var cost in costs){
      var attribute = cost.attribute;
      int value = caster.GetStatBasicValue(attribute);
      if(cost.percentOfCurrentValue){
        if(cost.percentOfMaxValue){
          Debug.Log($"Skill: {skill.name} | Percent Of Max Value is being overriden by Percent of Current Value.");
        }
        int costValue = (int)Math.Ceiling(value * (cost.cost / 100.0f)); 
      } else if(cost.percentOfMaxValue){

      } else{

      }
    }
    return true;
  }

  public void Cast(BattleCharacter caster, BattleCharacter target){
    if(!AttemptCast(caster, target) || !skill.AttemptCast(caster,target)){
      return;
    }
    skill.BypassAttempt(caster,target);
  }
}