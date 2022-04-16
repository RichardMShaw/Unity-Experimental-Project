using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : ScriptableObject
{
  public virtual List<BattleCharacter> GetTargets(BattleCharacter caster, BattleCharacter target)
  {
    return null;
  }
}