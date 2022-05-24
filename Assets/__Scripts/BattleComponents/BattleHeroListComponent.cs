using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHeroListComponent : MonoBehaviour
{
  public GameObject heroPrefab;

  public VoidEventChannel rerenderBattleHeroChannel;
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

    rerenderBattleHeroChannel.RaiseEvent();
  }

}
