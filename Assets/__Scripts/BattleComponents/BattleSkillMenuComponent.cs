using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSkillMenuComponent : MonoBehaviour
{
  public GameObject battleSkillSlotPrefab;
  public VoidEventChannel rerenderBattleSkillSlotChannel;
  public void LoadSkillSlots(BattleHero hero)
  {
    foreach (Transform child in transform)
    {
      Destroy(child.gameObject);
    }
    foreach (var skillSlot in hero.skillSlots)
    {
      GameObject gameObject = Instantiate(battleSkillSlotPrefab);
      gameObject.transform.SetParent(this.transform);
      gameObject.transform.localScale = new Vector3(1, 1, 1);
      BattleSkillSlotComponent gameObjectComponent = gameObject.GetComponent<BattleSkillSlotComponent>();
      gameObjectComponent.skillSlot = skillSlot;
      rerenderBattleSkillSlotChannel.RaiseEvent();
    }
  }
}
