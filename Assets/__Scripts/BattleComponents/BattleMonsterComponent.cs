using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BattleMonsterComponent : MonoBehaviour
{
  public BattleMonster monster;

  [Header("Components")]
  [SerializeField]
  public Transform spriteTransform;
  public SpriteRenderer spriteRenderer;

  [Header("Event Channels")]
  [SerializeField]
  private BattleMonsterEventChannel pointerEnter;
  [SerializeField]
  private BattleMonsterEventChannel pointerExit;
  [SerializeField]
  private BattleMonsterEventChannel pointerDown;
  [Header("Unity Events")]
  [SerializeField]
  private UnityEvent showCursor;
  public void OnLoadSprite()
  {
    var spriteData = monster.spriteData;
    spriteRenderer.sprite = spriteData.sprite;
    var spriteDataTransform = spriteData.transfrom;
    spriteTransform.position = spriteDataTransform.position;
    spriteTransform.rotation = spriteDataTransform.rotation;
    spriteTransform.localScale = spriteDataTransform.scale;
  }
  public void OnPointerEnter()
  {
    pointerEnter.RaiseEvent(monster);
  }

  public void OnPointerExit()
  {
    pointerExit.RaiseEvent(monster);
  }
  public void OnPointerDown()
  {
    pointerDown.RaiseEvent(monster);
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

  public void OnShowCursor(BattleMonster _monster){
    if(monster == _monster){
      showCursor.Invoke();
    }
  }
}
