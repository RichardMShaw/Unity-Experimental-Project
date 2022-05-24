using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
public class SkillSlotListEventListeners : MonoBehaviour
{
  [SerializeField] private SkillSlotListEventChannel _channel = default;

  public UnityEvent<List<SkillSlot>> OnEventRaised;

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

  private void Respond(List<SkillSlot> e)
  {
    if (OnEventRaised != null)
      OnEventRaised.Invoke(e);
  }

}