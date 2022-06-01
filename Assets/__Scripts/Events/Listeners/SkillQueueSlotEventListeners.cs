using UnityEngine;
using UnityEngine.Events;
public class SkillQueueSlotEventListeners : MonoBehaviour
{
  [SerializeField] private SkillQueueSlotEventChannel _channel = default;

  public UnityEvent<SkillQueueSlot> OnEventRaised;

  private void OnEnable()
  {
    if (_channel != null)
      _channel.OnEventRaised += Respond;
  }

  private void OnDisable()
  {
    if (_channel != null)
      _channel.OnEventRaised -= Respond;
  }

  private void Respond(SkillQueueSlot e)
  {
    if (OnEventRaised != null)
      OnEventRaised.Invoke(e);
  }

}