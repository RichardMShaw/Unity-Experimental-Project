using UnityEngine;
using UnityEngine.Events;
public class PositionMonsterEventListeners : MonoBehaviour
{
  [SerializeField] private PositionMonsterEventChannel _channel = default;

  public UnityEvent<PositionMonster> OnEventRaised;

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

  private void Respond(PositionMonster e)
  {
    if (OnEventRaised != null)
      OnEventRaised.Invoke(e);
  }

}