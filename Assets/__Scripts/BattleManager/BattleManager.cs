using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Project/Singletons/Managers/Battle Manager")]
public class BattleManager : ScriptableObject
{
  public Battle battle;

  public BattleFormation formation;
  public BattleParty<BattleHero> heroes;
  public BattleParty<BattleMonster> monsters;

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
    formation = battle.formation;
    heroes.Initalize();
    monsters.Initalize();
    heroes.Clear();
    monsters.Clear();
    foreach (var hero in battle.heroes)
    {
      heroes.Add(new BattleHero(hero, this));
    }
    foreach (var monster in battle.monsters)
    {
      monsters.Add(new BattleMonster(monster, this));
    }
  }
}

[Serializable]
public struct BattleParty<T> where T : BattleCharacter
{
  [SerializeField]
  private List<T> party;

  [SerializeField]
  private List<BattleCharacter> partyAsBaseClass;

  public List<BattleCharacter> GetPartyAsBaseClass()
  {
    if (partyAsBaseClass == null)
    {
      partyAsBaseClass = new List<BattleCharacter>();
      foreach (var character in party)
      {
        partyAsBaseClass.Add(character);
      }
    }
    return partyAsBaseClass;
  }

  public void Add(T character)
  {
    party.Add(character);
    partyAsBaseClass.Add(character);
  }

  public void Remove(T character)
  {
    party.Remove(character);
    partyAsBaseClass.Remove(character);
  }

  public void Clear()
  {
    party.Clear();
    partyAsBaseClass.Clear();
  }
  public void Initalize()
  {
    if (party == null)
    {
      party = new List<T>();
    }
    if (partyAsBaseClass == null)
    {
      partyAsBaseClass = new List<BattleCharacter>();
    }
  }
}
