using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Project/Event Channels/Battle Formation")]
public class BattleFormationEventChannel : ScriptableObject
{
  public UnityAction<BattleFormation> OnEventRaised;

  public void RaiseEvent(BattleFormation e)
  {
    if (OnEventRaised != null)
    {
      OnEventRaised.Invoke(e);
    }
  }
}