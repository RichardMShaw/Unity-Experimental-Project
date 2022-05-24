using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleHeroBasicStatComponent : MonoBehaviour
{
  public BattleHeroComponent parent;
  public BasicAttribute attribute;
  public TextMeshProUGUI valueText;

  public void OnRerender()
  {
    var hero = parent.hero;
    var stat = hero.GetStat(attribute);
    var max = stat.value;
    var current = stat.basicValue;
    valueText.text = $"{current}/{max}";
  }

}
