using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleSkillSlotComponent : MonoBehaviour
{
  public BattleHero caster;
  public SkillSlot skillSlot;
  [Header("Components")]
  public Button button;
  public TextMeshProUGUI skillName;
  public TextMeshProUGUI skillCosts;

  [Header("Event Channels")]
  public SkillSlotEventChannel skillSlotHover;
  public SkillSlotEventChannel skillSlotSelect;

  public void OnRerender()
  {
    button.interactable = skillSlot.CanCast(caster);
    skillName.text = skillSlot.Name;
    skillCosts.text = $"EP {skillSlot.EnergyCost}";
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
