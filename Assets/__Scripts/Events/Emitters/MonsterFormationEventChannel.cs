using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Project/Event Channels/Monster Formation")]
public class MonsterFormationEventChannel : ScriptableObject
{
  public UnityAction<MonsterFormation> OnEventRaised;

  public void RaiseEvent(MonsterFormation e)
  {
    if (OnEventRaised != null)
    {
      OnEventRaised.Invoke(e);
    }
  }
}