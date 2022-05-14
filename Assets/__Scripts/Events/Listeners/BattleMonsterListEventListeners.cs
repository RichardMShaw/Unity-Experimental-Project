using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
public class BattleMonsterListEventListeners : MonoBehaviour
{
  [SerializeField] private BattleMonsterListEventChannel _channel = default;

  public UnityEvent<List<BattleMonster>> OnEventRaised;

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

  private void Respond(List<BattleMonster> e)
  {
    if (OnEventRaised != null)
      OnEventRaised.Invoke(e);
  }

}