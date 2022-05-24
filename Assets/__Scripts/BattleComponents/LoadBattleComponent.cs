using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBattleComponent : MonoBehaviour
{
  public Battle battle;

  [SerializeField]
  private BattleEventChannel loadBattleChannel;

  public void OnLoadBattle()
  {
    loadBattleChannel.RaiseEvent(battle);
  }

}
