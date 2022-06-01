using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleMonsterStatBarComponent : MonoBehaviour
{
  public BattleMonsterComponent parent;
  public BasicAttribute attribute;
  public Slider slider;
  public Image fill;
  public Color fullColor;
  public Gradient gradient;
  public TextMeshProUGUI counter;
  public void OnUpdate()
  {
    var monster = parent.monster;
    slider.maxValue = monster.GetStatValue(attribute);
    int value = monster.GetStatBasicValue(attribute);
    slider.value = value;
    counter.text = value.ToString();
    var color = gradient.Evaluate(slider.normalizedValue);
    counter.color = color;
    fill.color = color;
  }

}
