using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Project/Event Channels/Battle Monster")]
public class BattleMonsterEventChannel : ScriptableObject
{
  public UnityAction<BattleMonster> OnEventRaised;

  public void RaiseEvent(BattleMonster e)
  {
    if (OnEventRaised != null)
    {
      OnEventRaised.Invoke(e);
    }
  }
}