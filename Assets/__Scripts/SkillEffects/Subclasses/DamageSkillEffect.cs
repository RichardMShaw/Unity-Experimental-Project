using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Project/Skill Effects/Damage")]
public class DamageSkillEffect : SkillEffect
{
  public List<Element> elements;

  public CoreAttribute powerAttribute;

  public CoreAttribute defenseAttribute;

  public BasicAttribute affectedAttribute;

  public List<DamageInstance> attacks;
  public override void Cast(BattleCharacter caster, BattleCharacter target)
  {
    var elementPower = 1.0f;
    var weakness = 1.0f;
    foreach (var element in elements)
    {
      elementPower *= caster.GetStatValue(element.powerAttribute) / 100;
      weakness *= target.GetStatValue(element.weaknessAttribute) / 100;
    }
    var power = caster.GetStatValue(powerAttribute);
    var defense = target.GetStatValue(defenseAttribute) / 100;
    var rawDamage = power * elementPower * weakness * -1;
    foreach (var attack in attacks)
    {
      var accuracy = attack.accuracy;
      if (accuracy > 99 || accuracy > UnityEngine.Random.Range(0, 99))
      {
        foreach (var effect in attack.effects)
        {
          var potency = effect.potency / 100;
          var damage = rawDamage * potency;
          if (defense > 1)
          {
            damage /= defense;
          }
          damage = Mathf.Floor(damage);
          var stat = target.GetStat(effect.overrideAffectedAttribute ?? affectedAttribute);
          int value = stat.basicValue;
          stat.basicValue += (int)damage;
        }
      }
    }
  }
}

[Serializable]
public struct DamageInstance
{
  public List<DamageEffect> effects;
  public int accuracy;
  public int hits;
}

[Serializable]
public struct DamageEffect
{

  public BasicAttribute overrideAffectedAttribute;

  public int potency;
}