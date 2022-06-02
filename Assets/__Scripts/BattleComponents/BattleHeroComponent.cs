using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleHeroComponent : MonoBehaviour
{
  public BattleHero hero;

  [Header("Event Channels")]
  public BattleHeroEventChannel pointerEnter;
  public BattleHeroEventChannel pointerExit;
  public BattleHeroEventChannel pointerDown;

  [Header("Component Config")]
  public RawImage background;
  public GameObject hightlightFrame;
  public TextMeshProUGUI heroName;
  public Color normal;
  public Color select;
  public void OnDeselect()
  {
    background.color = normal;
  }

  public void OnSelect(BattleHero _hero){
    if(hero == _hero){
      background.color = select;
      return;
    }
    background.color = normal;
  }
  public void OnHightlight(BattleHero _hero)
  {
    if(hero == _hero){
      hightlightFrame.SetActive(true);
      return;
    }
    hightlightFrame.SetActive(false);
  }

  public void OnPointerEnter()
  {
    pointerEnter.RaiseEvent(hero);
  }
  public void OnPointerExit()
  {
    pointerExit.RaiseEvent(hero);
  }
  public void OnPointerDown()
  {
    pointerDown.RaiseEvent(hero);
  }

  public void OnUpdate()
  {
    heroName.text = hero.name;
  }

}
