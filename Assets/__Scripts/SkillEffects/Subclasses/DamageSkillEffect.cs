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
    foreach (var element in elements)
    {
      elementPower *= caster.GetStatValue(element.powerAttribute) / 100;
    }
    var power = caster.GetStatValue(powerAttribute);
    var defense = target.GetStatValue(defenseAttribute) / 100;
    var rawDamage = power * elementPower * -1;
    foreach (var attack in attacks)
    {
      var accuracy = attack.accuracy;
      var hits = attack.hits;
      var targets = attack.GetTargets(caster, target);
      for (int i = 0; i < hits; i++)
      {
        if (accuracy >= 99 || accuracy > UnityEngine.Random.Range(0, 99))
        {
          foreach (var effect in attack.effects)
          {
            foreach(var t in targets){
              var weakness = 1.0f;
              foreach (var element in elements)
              {
                weakness *= t.GetStatValue(element.weaknessAttribute) / 100; ;
              }
              var potency = effect.potency / 100;
              var damage = rawDamage * weakness * potency;
              if (defense > 1)
              {
                damage /= defense / 100;
              }
              int result = (int)Mathf.Floor(damage);
              var stat = t.GetStat(effect.affectedAttribute ?? affectedAttribute);
              int value = stat.basicValue;
              stat.basicValue += result;
              Debug.Log(result);
              Debug.Log(stat.basicValue);
            }
          }
        }
      }
    }
  }
}

[Serializable]
public struct DamageInstance
{
  public Target targets;
  public List<DamageEffect> effects;
  public int accuracy;
  public int hits;
  public List<BattleCharacter> GetTargets(BattleCharacter caster, BattleCharacter target){
    if(targets == null){
      var list = new List<BattleCharacter>();
      list.Add(target);
      return list;
    }
    return targets.GetTargets(caster, target);
  }
}

[Serializable]
public struct DamageEffect
{
  public BasicAttribute affectedAttribute;

  public int potency;
}