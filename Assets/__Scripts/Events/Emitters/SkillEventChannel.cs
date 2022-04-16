using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Project/Event Channels/Skill")]
public class SkillEventChannel : ScriptableObject
{
  public UnityAction<SkillEventData> OnEventRaised;

  public void RaiseEvent(SkillEventData e)
  {
    if (OnEventRaised != null)
    {
      OnEventRaised.Invoke(e);
    }
  }
}