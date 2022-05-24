using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : ScriptableObject
{
  public Battle battle;

  public BattleParty<BattleHero> heroes;
  public BattleParty<BattleMonster> monsters;
  public BattleFormation battleFormation;
  private MonsterFormation monsterFormation;

  //State Management
  public BattleStateFactory stateFactory;
  [Header("State Management")]
  public BattleBaseState currentState;
  public BattleHero selectedHero;
  public SkillSlot selectedSkillSlot;

  [Header("Event Channels")]

  public VoidEventChannel hideUIChannel;
  public VoidEventChannel showBattleUIChannel;
  public BattleHeroListEventChannel loadHeroesChannel;
  public BattleMonsterListEventChannel loadMonstersChannel;
  public MonsterFormationEventChannel loadMonsterFormationChannel;
  public BattleHeroEventChannel loadBattleSkillMenuChannel;
  public VoidEventChannel hideBattleSkillMenuChannel;

  public void OnLoadBattle(Battle _battle)
  {
    battle = _battle;
    battleFormation = battle.formation;
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

    monsterFormation = battleFormation.GetMonsterFormation(monsters.party);
    hideUIChannel.RaiseEvent();
    showBattleUIChannel.RaiseEvent();
    loadHeroesChannel.RaiseEvent(heroes.party);
    loadMonstersChannel.RaiseEvent(monsters.party);
    loadMonsterFormationChannel.RaiseEvent(monsterFormation);
    currentState = stateFactory.HeroMenu();
    currentState.EnterState();
  }
  public void OnBattleHeroSelect(BattleHero hero)
  {
    currentState.OnBattleHeroSelect(hero);
  }
  public void OnBattleMonsterSelect(BattleMonster monster)
  {
    currentState.OnBattleMonsterSelect(monster);
  }

  public void OnBattleHeroSkillSlotSelect(SkillSlot skillSlot){
    currentState.OnBattleHeroSkillSlotSelect(skillSlot);
  }
}

[Serializable]
public struct BattleParty<T> where T : BattleCharacter
{
  public List<T> party;

  [SerializeField]
  private List<BattleCharacter> partyAsBaseClass;
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
}
