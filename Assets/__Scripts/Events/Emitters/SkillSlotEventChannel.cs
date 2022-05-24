using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Project/Event Channels/Skill Slot")]
public class SkillSlotEventChannel : ScriptableObject
{
  public UnityAction<SkillSlot> OnEventRaised;

  public void RaiseEvent(SkillSlot e)
  {
    if (OnEventRaised != null)
    {
      OnEventRaised.Invoke(e);
    }
  }
}