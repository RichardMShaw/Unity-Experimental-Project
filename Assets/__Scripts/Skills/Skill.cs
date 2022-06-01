using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Project/Skill")]
public class Skill : ScriptableObject
{
  public new string name;
  [TextArea(3, 20)]
  public string description;

  [Header("Skill Slot Costs")]
  public int energyCost = 0;
  public List<CostAttribute> flatCosts;
  public List<CostAttribute> currentValuePercentCosts;
  public List<CostAttribute> maxValuePercentCosts;

  [Header("Skill Details")]
  public Scope scope;
  public List<SkillType> skillTypes;
  public List<SkillEffect> skillEffects;
  public bool CanCast(BattleCharacter caster, BattleCharacter target)
  {
    // var restrictions = new Dictionary<Attribute, bool>();
    // foreach (var type in skillTypes)
    // {
    //   foreach (var restriction in type.restrictions)
    //     if (!restrictions.ContainsKey(restriction))
    //     {
    //       restrictions.Add(restriction, true);
    //       if (caster.GetStatValue(restriction) > UnityEngine.Random.Range(0, 99))
    //       {
    //         Debug.Log("Unable to cast skill due to: " + type.name);
    //         return false;
    //       }
    //     }
    // }
    return true;
  }

  public void Cast(BattleCharacter caster, BattleCharacter target)
  {
    if(!CanCast(caster, target)){
      return;
    }
    foreach (var skillEffect in skillEffects)
    {
      skillEffect.Cast(caster, target);
    }
  }

  public void BypassCastCheck(BattleCharacter caster, BattleCharacter target){
    foreach (var skillEffect in skillEffects)
    {
      skillEffect.Cast(caster, target);
    }
  }
}

[Serializable]
public struct CostAttribute {
  public BasicAttribute attribute;
  public int value;
}