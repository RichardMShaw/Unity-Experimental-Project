using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Project/Event Channels/Battle Hero List")]
public class BattleHeroListEventChannel : ScriptableObject
{
  public UnityAction<List<BattleHero>> OnEventRaised;

  public void RaiseEvent(List<BattleHero> e)
  {
    if (OnEventRaised != null)
    {
      OnEventRaised.Invoke(e);
    }
  }
}