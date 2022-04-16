using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMonsterComponent : MonoBehaviour
{
  public BattleMonster monster;

  [SerializeField]
  private BattleMonsterEventChannel _monsterSelectChannel;

  public void OnMonsterSelect()
  {
    _monsterSelectChannel.RaiseEvent(monster);
  }

}
