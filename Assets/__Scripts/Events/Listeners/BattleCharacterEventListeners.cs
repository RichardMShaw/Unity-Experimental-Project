using UnityEngine;
using UnityEngine.Events;
public class BattleCharacterEventListeners : MonoBehaviour
{
  [SerializeField] private BattleCharacterEventChannel _channel = default;

  public UnityEvent<BattleCharacter> OnEventRaised;

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

  private void Respond(BattleCharacter e)
  {
    if (OnEventRaised != null)
      OnEventRaised.Invoke(e);
  }

}