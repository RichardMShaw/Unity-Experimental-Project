using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Project/Skill")]
public class Skill : ScriptableObject
{
  public new string name;
  [TextArea(3, 20)]
  public string description;

  public Scope scope;
  public List<SkillType> skillTypes;

  public List<SkillEffect> skillEffects;
  public void AttemptCast(BattleCharacter caster, BattleCharacter target)
  {
    var restrictions = new Dictionary<Attribute, bool>();
    foreach (var type in skillTypes)
    {
      foreach (var restriction in type.restrictions)
        if (!restrictions.ContainsKey(restriction))
        {
          restrictions.Add(restriction, true);
          if (caster.GetStatValue(restriction) > Random.Range(0, 99))
          {
            return;
          }
        }
    }
    Cast(caster, target);
  }

  public void Cast(BattleCharacter caster, BattleCharacter target)
  {
    foreach (var skillEffect in skillEffects)
    {
      skillEffect.Cast(caster, target);
    }
  }
}