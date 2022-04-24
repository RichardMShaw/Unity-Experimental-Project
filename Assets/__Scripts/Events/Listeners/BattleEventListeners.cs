using UnityEngine;
using UnityEngine.Events;
public class BattleEventListeners : MonoBehaviour
{
  [SerializeField] private BattleEventChannel _channel = default;

  public UnityEvent<Battle> OnEventRaised;

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

  private void Respond(Battle e)
  {
    if (OnEventRaised != null)
      OnEventRaised.Invoke(e);
  }

}