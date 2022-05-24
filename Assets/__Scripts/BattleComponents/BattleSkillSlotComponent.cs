using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleSkillSlotComponent : MonoBehaviour
{
  public SkillSlot skillSlot;
  [Header("Components")]
  public TextMeshProUGUI text;

  [Header("Event Channels")]
  public SkillSlotEventChannel skillSlotHover;
  public SkillSlotEventChannel skillSlotSelect;

  public void OnRerender()
  {
    text.text = skillSlot.Name;
  }

  public void SkillSlotSelect()
  {
    skillSlotSelect.RaiseEvent(skillSlot);
  }

  public void SkillSlotHover()
  {
    skillSlotHover.RaiseEvent(skillSlot);
  }
}
