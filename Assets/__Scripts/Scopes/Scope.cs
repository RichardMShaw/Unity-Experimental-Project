using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : ScriptableObject
{
  public virtual List<BattleCharacter> GetValidTargets(BattleCharacter caster)
  {
    return null;
  }
}