using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleHeroStatBarComponent : MonoBehaviour
{
  public BattleHeroComponent parent;
  public BasicAttribute attribute;
  public Slider slider;
  public TextMeshProUGUI value;
  public Image fill;
  public Color fullColor;
  public Gradient gradient;
  public void OnUpdate()
  {
    var hero = parent.hero;
    slider.maxValue = hero.GetStatValue(attribute);
    slider.value = hero.GetStatBasicValue(attribute);
    value.text = slider.value.ToString();
    fill.color = gradient.Evaluate(slider.normalizedValue);
  }

}
