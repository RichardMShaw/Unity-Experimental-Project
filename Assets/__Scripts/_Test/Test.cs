using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Project/_Test")]
public class Test : ScriptableObject
{
  public void TestFunction(BattleCharacter character)
  {
    Debug.Log(character.template.name);
  }
}