using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Project/Event Channels/Battle")]
public class BattleEventChannel : ScriptableObject
{
  public UnityAction<Battle> OnEventRaised;

  public void RaiseEvent(Battle e)
  {
    if (OnEventRaised != null)
    {
      OnEventRaised.Invoke(e);
    }
  }
}