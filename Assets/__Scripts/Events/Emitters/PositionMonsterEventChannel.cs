using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Project/Event Channels/Position Monster")]
public class PositionMonsterEventChannel : ScriptableObject
{
  public UnityAction<PositionMonster> OnEventRaised;

  public void RaiseEvent(PositionMonster e)
  {
    if (OnEventRaised != null)
    {
      OnEventRaised.Invoke(e);
    }
  }
}