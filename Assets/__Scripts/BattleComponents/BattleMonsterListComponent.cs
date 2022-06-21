using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMonsterListComponent : MonoBehaviour
{
  public GameObject monsterPrefab;

  [Header("Event Channels")]
  public VoidEventChannel updateBattleMonsterChannel;
  public PositionMonsterEventChannel positionMonsterEventChannel;
  public PositionMonsterEventChannel moveMonsterEventChannel;
  private List<BattleMonster> monsterParty;

  public void ChangeMonsterFormation(MonsterFormation formation){
    var positions = formation.formationPositions;
    int len = positions.Count;
    for (int i = 0; i < len; i++)
    {
      var monster = monsterParty[i];
      var position = positions[i];
      moveMonsterEventChannel.RaiseEvent(new PositionMonster(monster, position));
    }
  }
  public void LoadMonsters(List<BattleMonster> monsters)
  {
    monsterParty = monsters;
    foreach (Transform child in transform)
    {
      Destroy(child.gameObject);
    }
    foreach (var monster in monsters)
    {
      GameObject monsterObj = Instantiate(monsterPrefab);
      monsterObj.transform.SetParent(this.transform);
      monsterObj.transform.localScale = new Vector3(1, 1, 1);
      BattleMonsterComponent monsterComponent = monsterObj.GetComponent<BattleMonsterComponent>();
      monsterComponent.monster = monster;
    }
    updateBattleMonsterChannel.RaiseEvent();
  }

  public void LoadMonsterFormation(MonsterFormation formation)
  {
    var positions = formation.formationPositions;
    int len = positions.Count;
    for (int i = 0; i < len; i++)
    {
      var monster = monsterParty[i];
      var position = positions[i];
      positionMonsterEventChannel.RaiseEvent(new PositionMonster(monster, position));
    }
  }

}
