using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Project/Event Channels/Battle Monster List")]
public class BattleMonsterListEventChannel : ScriptableObject
{
  public UnityAction<List<BattleMonster>> OnEventRaised;

  public void RaiseEvent(List<BattleMonster> e)
  {
    if (OnEventRaised != null)
    {
      OnEventRaised.Invoke(e);
    }
  }
}