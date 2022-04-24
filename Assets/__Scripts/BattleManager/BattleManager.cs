using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Project/Singletons/Managers/Battle Manager")]
public class BattleManager : ScriptableObject
{
  public Battle battle;

  public BattleFormation formation;
  public List<BattleHero> heroes;

  public List<BattleMonster> monsters;

  public BattleState state;

  public void OnBattleHeroSelect(BattleHero hero)
  {
    state.OnBattleHeroSelect(hero);
  }
  public void OnBattleMonsterSelect(BattleMonster monster)
  {
    state.OnBattleMonsterSelect(monster);
  }

  public void OnLoadBattle(Battle _battle)
  {
    battle = _battle;
    heroes.Clear();
    monsters.Clear();
    foreach (var monster in battle.monsterGroup)
    {
      monsters.Add(new BattleMonster(monster));
    }
  }
}
