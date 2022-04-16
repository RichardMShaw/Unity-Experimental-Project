using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Project/Event Channels/Battle Character")]
public class BattleCharacterEventChannel : ScriptableObject
{
  public UnityAction<BattleCharacter> OnEventRaised;

  public void RaiseEvent(BattleCharacter e)
  {
    if (OnEventRaised != null)
    {
      OnEventRaised.Invoke(e);
    }
  }
}