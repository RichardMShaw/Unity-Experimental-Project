using UnityEngine;
using UnityEngine.Events;
public class SkillSlotEventListeners : MonoBehaviour
{
  [SerializeField] private SkillSlotEventChannel _channel = default;

  public UnityEvent<SkillSlot> OnEventRaised;

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

  private void Respond(SkillSlot e)
  {
    if (OnEventRaised != null)
      OnEventRaised.Invoke(e);
  }

}