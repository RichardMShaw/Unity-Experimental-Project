using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroListComponent : MonoBehaviour
{
  public GameObject heroPrefab;

  public VoidEventChannel UpdateHeroUI;
  public void LoadHeroes(List<BattleHero> heroes)
  {
    foreach (Transform child in transform)
    {
      Destroy(child.gameObject);
    }
    foreach (var hero in heroes)
    {
      GameObject heroObj = Instantiate(heroPrefab);
      heroObj.transform.SetParent(this.transform);
      heroObj.transform.localScale = new Vector3(1, 1, 1);
      BattleHeroComponent heroComponent = heroObj.GetComponent<BattleHeroComponent>();
      heroComponent.hero = hero;
    }

    UpdateHeroUI.RaiseEvent();
  }

}
