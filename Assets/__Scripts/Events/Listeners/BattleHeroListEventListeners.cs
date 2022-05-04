using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
public class BattleHeroListEventListeners : MonoBehaviour
{
  [SerializeField] private BattleHeroListEventChannel _channel = default;

  public UnityEvent<List<BattleHero>> OnEventRaised;

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

  private void Respond(List<BattleHero> e)
  {
    if (OnEventRaised != null)
      OnEventRaised.Invoke(e);
  }

}