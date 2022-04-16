using UnityEngine;
using UnityEngine.Events;
public class BattleHeroEventListeners : MonoBehaviour
{
  [SerializeField] private BattleHeroEventChannel _channel = default;

  public UnityEvent<BattleHero> OnEventRaised;

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

  private void Respond(BattleHero e)
  {
    if (OnEventRaised != null)
      OnEventRaised.Invoke(e);
  }

}