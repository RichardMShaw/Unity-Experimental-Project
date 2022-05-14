using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMonsterComponent : MonoBehaviour
{
  public BattleMonster monster;

  [Header("Config")]
  [SerializeField]
  public Transform spriteTransform;
  public SpriteRenderer spriteRenderer;

  [Header("Event Channels")]
  [SerializeField]
  private BattleMonsterEventChannel _monsterSelect;

  public void OnRerenderSprite()
  {
    var spriteData = monster.spriteData;
    spriteRenderer.sprite = spriteData.sprite;
    var spriteDataTransform = spriteData.transfrom;
    spriteTransform.position = spriteDataTransform.position;
    spriteTransform.rotation = spriteDataTransform.rotation;
    spriteTransform.localScale = spriteDataTransform.scale;
  }

  public void OnMonsterSelect()
  {
    _monsterSelect.RaiseEvent(monster);
  }

  public void OnPositionMonster(PositionMonster monsterPosition)
  {
    if (monster == monsterPosition.monster)
    {
      transform.position = monsterPosition.position;
      transform.rotation = monsterPosition.rotation;
      transform.localScale = monsterPosition.scale;
    }
  }
}
