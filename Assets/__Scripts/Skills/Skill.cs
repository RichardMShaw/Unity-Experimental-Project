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
  public List<CostAttribute> costs; 
  public Scope scope;
  public List<SkillType> skillTypes;
  public List<SkillEffect> skillEffects;
  public bool AttemptCast(BattleCharacter caster, BattleCharacter target)
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
    // foreach(var cost in costs){
    //   if(caster.GetStatBasicValue(cost.attribute) < cost.cost){
    //     Debug.Log("Not enough: " + cost.attribute.name);
    //     return false;
    //   }
    // }
    return true;
  }

  public void Cast(BattleCharacter caster, BattleCharacter target)
  {
    if(!AttemptCast(caster, target)){
      return;
    }
    // foreach (var cost in costs)
    // {
    //   var stat = caster.GetStat(cost.attribute);
    //   stat.basicValue -= cost.cost;
    // }
    foreach (var skillEffect in skillEffects)
    {
      skillEffect.Cast(caster, target);
    }
  }

  public void BypassAttempt(BattleCharacter caster, BattleCharacter target){
    foreach (var skillEffect in skillEffects)
    {
      skillEffect.Cast(caster, target);
    }
  }
}

[Serializable]
public struct CostAttribute {
  public BasicAttribute attribute;

  public int cost;

  public bool percentOfCurrentValue;

  public bool percentOfMaxValue;
}