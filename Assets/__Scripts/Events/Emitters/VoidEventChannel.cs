using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Project/Event Channels/Void")]
public class VoidEventChannel : ScriptableObject
{
  public UnityAction OnEventRaised;

  public void RaiseEvent()
  {
    if (OnEventRaised != null)
    {
      OnEventRaised.Invoke();
    }
  }
}
