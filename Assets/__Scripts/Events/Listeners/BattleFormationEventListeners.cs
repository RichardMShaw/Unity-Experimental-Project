using UnityEngine;
using UnityEngine.Events;
public class BattleFormationEventListeners : MonoBehaviour
{
  [SerializeField] private BattleFormationEventChannel _channel = default;

  public UnityEvent<BattleFormation> OnEventRaised;

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

  private void Respond(BattleFormation e)
  {
    if (OnEventRaised != null)
      OnEventRaised.Invoke(e);
  }

}