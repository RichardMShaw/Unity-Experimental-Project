using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Project/Skill Effects/Attack")]
public class AttackSkillEffect : SkillEffect
{
  public List<Element> elements;
  public CoreAttribute powerAttribute;
  public CoreAttribute defenseAttribute;
  public BasicAttribute affectedAttribute;
  public List<Attack> attacks;

  private void ApplyAttackEffect(BattleCharacter caster, BattleCharacter target, AttackEffect attackEffect)
  {
    var power = caster.GetStatValue(attackEffect.powerAttribute ?? powerAttribute);
    var defense = target.GetStatValue(attackEffect.defenseAttribute ?? defenseAttribute) / 100.0f;
    var basicAttribute = attackEffect.affectedAttribute ?? affectedAttribute;
    var effectElements = attackEffect.elements.Count > 0 ? attackEffect.elements : elements;
    var elementPower = 1.0f;
    foreach (var element in effectElements)
    {
      elementPower *= (caster.GetStatValue(element.powerAttribute) / 100.0f) * (target.GetStatValue(element.weaknessAttribute) / 100.0f);
    }
    var totalPower = power * elementPower * (attackEffect.potency / 100.0f);
    totalPower = totalPower / defense;
    target.ChangeStatBasicValue(basicAttribute, (int)-totalPower);
  }

  private bool SuccessfulHit(BattleCharacter caster, BattleCharacter target, Attack attack)
  {
    var accuracy = attack.accuracy;
    if (accuracy >= 100)
    {
      return true;
    }
    var rng = UnityEngine.Random.Range(0, 99);
    if (accuracy < rng)
    {
      return false;
    }
    return true;
  }

  private void AttackTarget(BattleCharacter caster, BattleCharacter target, Attack attack)
  {
    if (SuccessfulHit(caster, target, attack))
    {
      foreach (var effect in attack.effects)
      {
        ApplyAttackEffect(caster, target, effect);
      }
    }
  }
  public override void Cast(BattleCharacter caster, BattleCharacter mainTarget)
  {
    
    foreach (var attack in attacks)
    {
      var len = attack.hits;
      for (int i = 0; i < len; i++)
      {
        var targets = attack.GetTargets(caster, mainTarget);
        foreach (var target in targets)
        {
          AttackTarget(caster, target, attack);
        }
      }
    }
    // var elementPower = 1.0f;
    // foreach (var element in elements)
    // {
    //   elementPower *= caster.GetStatValue(element.powerAttribute) / 100.0f;
    // }
    // var power = caster.GetStatValue(powerAttribute);
    // var rawDamage = power * elementPower * -1;
    // foreach (var attack in attacks)
    // {
    //   var accuracy = attack.accuracy;
    //   var hits = attack.hits;
    //   var targets = attack.GetTargets(caster, mainTarget);
    //   for (int i = 0; i < hits; i++)
    //   {
    //     if (accuracy >= 99 || accuracy > UnityEngine.Random.Range(0, 99))
    //     {
    //       foreach (var effect in attack.effects)
    //       {
    //         foreach(var target in targets){
    //           var defense = target.GetStatValue(defenseAttribute) / 100.0f;
    //           var weakness = 1.0f;
    //           foreach (var element in elements)
    //           {
    //             weakness *= target.GetStatValue(element.weaknessAttribute) / 100.0f; ;
    //           }
    //           var potency = effect.potency / 100.0f;
    //           var damage = rawDamage * weakness * potency;
    //           if (defense > 1)
    //           {
    //             damage /= defense / 100.0f;
    //           }
    //           int result = (int)Mathf.Floor(damage);
    //           var stat = target.GetStat(effect.affectedAttribute ?? affectedAttribute);
    //           int value = stat.basicValue;
    //           stat.basicValue += result;
    //         }
    //       }
    //     }
    //   }
    // }
  }
}

[Serializable]
public struct Attack
{
  public Target targets;
  public int accuracy;
  public int hits;
  public List<AttackEffect> effects;
  public List<BattleCharacter> GetTargets(BattleCharacter caster, BattleCharacter target)
  {
    if (targets == null)
    {
      var list = new List<BattleCharacter>();
      list.Add(target);
      return list;
    }
    return targets.GetTargets(caster, target);
  }
}

[Serializable]
public struct AttackEffect
{
  public CoreAttribute powerAttribute;
  public CoreAttribute defenseAttribute;
  public BasicAttribute affectedAttribute;
  public List<Element> elements;
  public int potency;
}