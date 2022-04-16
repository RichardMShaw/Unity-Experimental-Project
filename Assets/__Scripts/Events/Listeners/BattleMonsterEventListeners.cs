using UnityEngine;
using UnityEngine.Events;
public class BattleMonsterEventListeners : MonoBehaviour
{
  [SerializeField] private BattleMonsterEventChannel _channel = default;

  public UnityEvent<BattleMonster> OnEventRaised;

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

  private void Respond(BattleMonster e)
  {
    if (OnEventRaised != null)
      OnEventRaised.Invoke(e);
  }

}