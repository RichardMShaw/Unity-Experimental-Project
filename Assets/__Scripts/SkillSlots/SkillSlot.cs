using System;
using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;

[Serializable]
public class SkillSlot
{
  public Skill skill;

  public string Name
  {
    get { return skill.name; }
  }

  public int EnergyCost {
    get{
      return skill.energyCost;
    }
  }

  public SkillSlot(Skill _skill)
  {
    skill = _skill;
  }
  public SkillSlot(SkillSlot skillSlot)
  {
    skill = skillSlot.skill;
  }

  public bool AttemptCast(BattleCharacter caster)
  {
    int energyCost = skill.energyCost;
    if (energyCost > 0)
    {
      int value = caster.GetStatBasicValue(BasicAttribute.Energy);
      if (value < energyCost)
      {
        return false;
      }
    }
    var costs = skill.flatCosts;
    foreach (var cost in costs)
    {
      var attribute = cost.attribute;
      int value = caster.GetStatBasicValue(attribute);
      if (value < cost.value)
      {
        return false;
      }
    }
    costs = skill.currentValuePercentCosts;
    foreach (var cost in costs)
    {
      var attribute = cost.attribute;
      int value = caster.GetStatBasicValue(attribute);
      int costValue = (int)Math.Ceiling(value * (cost.value / 100.0f));
      if (value < cost.value)
      {
        return false;
      }
    }
    costs = skill.maxValuePercentCosts;
    foreach (var cost in costs)
    {
      var attribute = cost.attribute;
      int maxValue = (int)caster.GetStatValue(attribute);
      int value = caster.GetStatBasicValue(attribute);
      int costValue = (int)Math.Ceiling(maxValue * (cost.value / 100.0f));
      if (value < cost.value)
      {
        return false;
      }
    }
    return true;
  }

  private void ApplyCost(BattleCharacter caster)
  {
    int energyCost = skill.energyCost;
    if (energyCost > 0)
    {
      int value = caster.GetStatBasicValue(BasicAttribute.Energy);
      caster.SetStatBasicValue(BasicAttribute.Energy, value - energyCost);
    }
    var costs = skill.flatCosts;
    foreach (var cost in costs)
    {
      var attribute = cost.attribute;
      int value = caster.GetStatBasicValue(attribute);
      caster.SetStatBasicValue(attribute, value - cost.value);
    }
    costs = skill.currentValuePercentCosts;
    foreach (var cost in costs)
    {
      var attribute = cost.attribute;
      int value = caster.GetStatBasicValue(attribute);
      int costValue = (int)Math.Ceiling(value * (cost.value / 100.0f));
      caster.SetStatBasicValue(attribute, value - costValue);
    }
    costs = skill.maxValuePercentCosts;
    foreach (var cost in costs)
    {
      var attribute = cost.attribute;
      int maxValue = (int)caster.GetStatValue(attribute);
      int value = caster.GetStatBasicValue(attribute);
      int costValue = (int)Math.Ceiling(maxValue * (cost.value / 100.0f));
      caster.SetStatBasicValue(attribute, value - costValue);
    }
  }

  public void Cast(BattleCharacter caster, BattleCharacter target)
  {
    if (!AttemptCast(caster) || !skill.AttemptCast(caster, target))
    {
      return;
    }
    ApplyCost(caster);
    skill.BypassAttempt(caster, target);
  }
}