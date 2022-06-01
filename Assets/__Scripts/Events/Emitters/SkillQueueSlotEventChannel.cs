using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Project/Event Channels/Skill Queue Slot")]
public class SkillQueueSlotEventChannel : ScriptableObject
{
  public UnityAction<SkillQueueSlot> OnEventRaised;

  public void RaiseEvent(SkillQueueSlot e)
  {
    if (OnEventRaised != null)
    {
      OnEventRaised.Invoke(e);
    }
  }
}