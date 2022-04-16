using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEffect : ScriptableObject
{
  public virtual void Cast(BattleCharacter caster, BattleCharacter target)
  {
    return;
  }
}