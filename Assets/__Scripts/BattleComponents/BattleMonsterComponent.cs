using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMonsterComponent : MonoBehaviour
{
  public BattleMonster monster;

  [Header("Event Channels")]
  [SerializeField]
  private BattleMonsterEventChannel _monsterSelect;

  public void OnMonsterSelect()
  {
    _monsterSelect.RaiseEvent(monster);
  }

}
