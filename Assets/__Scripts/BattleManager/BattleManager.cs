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
  #nullable enable
  public BattleHero? selectedHero;
  public SkillSlot? selectedSkillSlot;
  #nullable disable

  [Header("Event Channels")]

  public VoidEventChannel hideUIChannel;
  public VoidEventChannel showBattleUIChannel;
  public BattleHeroListEventChannel loadHeroesChannel;
  public BattleMonsterListEventChannel loadMonstersChannel;
  public MonsterFormationEventChannel loadMonsterFormationChannel;
  public BattleHeroEventChannel loadBattleSkillMenuChannel;
  public VoidEventChannel hideBattleSkillMenuChannel;
  public SkillQueueSlotEventChannel enqueueSkillChannel;
  public VoidEventChannel processSkillQueueChannel;
  public VoidEventChannel clearSkillQueueChannel;
  public VoidEventChannel updateBattleMonsterHealthBar;
  public VoidEventChannel updateBattleHeroStatBars;
  public BattleHeroEventChannel hideBattleHeroHighlight;
  public BattleHeroEventChannel showBattleHeroHighlight;
  public BattleHeroEventChannel selectBattleHero;
  public VoidEventChannel unselectBattleHero;
  public BattleMonsterEventChannel onShowBattleMonsterCursor;
  public BattleMonsterEventChannel onHideBattleMonsterCursor;
  public BattleHeroEventChannel battleHeroKnockoutChannel;
  public BattleHeroEventChannel battleHeroReviveChannel;
  public BattleMonsterEventChannel battleMonsterKnockoutChannel;
  public BattleMonsterEventChannel battleMonsterReviveChannel;
  public BattleMonsterEventChannel battleMonsterRemove;
  public MonsterFormationEventChannel changeMonsterFormationChannel;

  public void BattleMonsterRemove(BattleMonster monster){
    battleMonsterRemove.RaiseEvent(monster);
    monsters.Remove(monster);
    changeMonsterFormationChannel.RaiseEvent(battleFormation.GetMonsterFormation(monsters.party));
  }
  public void BattleMonsterKnockout(BattleMonster monster){
    battleMonsterKnockoutChannel.RaiseEvent(monster);
    if(monster.removeable){
      BattleMonsterRemove(monster);
    }
  }
  public void BattleMonsterRevive(BattleMonster monster){
    battleMonsterReviveChannel.RaiseEvent(monster);
  }
  public void BattleHeroRevive(BattleHero hero)
  {
    battleHeroReviveChannel.RaiseEvent(hero);
  }
  public void BattleHeroKnockout(BattleHero hero){
    battleHeroKnockoutChannel.RaiseEvent(hero);
  }
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

  public void OnBattleHeroStopHover(BattleHero hero)
  {
    currentState.OnBattleHeroStopHover(hero);
  }
  public void OnBattleHeroHover(BattleHero hero)
  {
    currentState.OnBattleHeroHover(hero);
  }
  public void OnBattleMonsterSelect(BattleMonster monster)
  {
    currentState.OnBattleMonsterSelect(monster);
  }
  public void OnBattleMonsterStopHover(BattleMonster monster)
  {
    currentState.OnBattleMonsterStopHover(monster);
  }
  public void OnBattleMonsterHover(BattleMonster monster)
  {
    currentState.OnBattleMonsterHover(monster);
  }
  public void OnBattleHeroSkillSlotSelect(SkillSlot skillSlot){
    currentState.OnBattleHeroSkillSlotSelect(skillSlot);
  }

  public void OnSkillQueueCompletle(){
    currentState.OnSkillQueueComplete();
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
