using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Project/Event Channels/Battle Hero")]
public class BattleHeroEventChannel : ScriptableObject
{
  public UnityAction<BattleHero> OnEventRaised;

  public void RaiseEvent(BattleHero e)
  {
    if (OnEventRaised != null)
    {
      OnEventRaised.Invoke(e);
    }
  }
}