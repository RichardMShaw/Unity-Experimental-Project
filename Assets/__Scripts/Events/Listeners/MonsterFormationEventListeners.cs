using UnityEngine;
using UnityEngine.Events;
public class MonsterFormationEventListeners : MonoBehaviour
{
  [SerializeField] private MonsterFormationEventChannel _channel = default;

  public UnityEvent<MonsterFormation> OnEventRaised;

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

  private void Respond(MonsterFormation e)
  {
    if (OnEventRaised != null)
      OnEventRaised.Invoke(e);
  }

}