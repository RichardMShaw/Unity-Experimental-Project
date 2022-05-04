using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleHeroComponent : MonoBehaviour
{
  public BattleHero hero;

  [Header("Event Channels")]
  [SerializeField]

  [Header("Component Config")]
  public TextMeshProUGUI heroName;
  public TextMesh health;
  public TextMesh energy;

  private BattleHeroEventChannel _heroSelect;

  public void OnMonsterSelect()
  {
    _heroSelect.RaiseEvent(hero);
  }

  public void UpdateUI()
  {
    Debug.Log(hero.name);
    heroName.text = hero.name;

  }

}
