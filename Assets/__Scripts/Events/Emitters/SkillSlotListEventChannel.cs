using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Project/Event Channels/Skill Slot List")]
public class SkillSlotListEventChannel : ScriptableObject
{
  public UnityAction<List<SkillSlot>> OnEventRaised;

  public void RaiseEvent(List<SkillSlot> e)
  {
    if (OnEventRaised != null)
    {
      OnEventRaised.Invoke(e);
    }
  }
}