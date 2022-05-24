using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleHeroComponent : MonoBehaviour
{
  public BattleHero hero;

  [Header("Event Channels")]
  public BattleHeroEventChannel heroSelect;

  [Header("Component Config")]
  public TextMeshProUGUI heroName;
  public TextMesh health;
  public TextMesh energy;


  public void OnHeroSelect()
  {
    heroSelect.RaiseEvent(hero);
  }

  public void UpdateUI()
  {
    heroName.text = hero.name;
  }

}
