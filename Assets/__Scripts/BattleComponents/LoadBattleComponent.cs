using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBattleComponent : MonoBehaviour
{
  public Battle battle;

  [SerializeField]
  private BattleEventChannel _loadBattleChannel;

  public void OnLoadBattle()
  {
    _loadBattleChannel.RaiseEvent(battle);
  }

}
