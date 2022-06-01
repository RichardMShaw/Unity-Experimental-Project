using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Project/Event Channels/Skill")]
public class SkillEventChannel : ScriptableObject
{
  public UnityAction<Skill> OnEventRaised;

  public void RaiseEvent(Skill e)
  {
    if (OnEventRaised != null)
    {
      OnEventRaised.Invoke(e);
    }
  }
}