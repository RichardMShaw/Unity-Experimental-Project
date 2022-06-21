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

  //Config
  private Coroutine slideCoroutine;
  private Coroutine rotateCoroutine;
  private Coroutine removeCoroutine;

  private static WaitForSeconds waitRemove = new WaitForSeconds(1f);
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

  public void OnMove(PositionMonster monsterPosition)
  {
    if (monster == monsterPosition.monster)
    {
      if (slideCoroutine != null)
      {
        StopCoroutine(slideCoroutine);
      }
      if (rotateCoroutine != null)
      {
        StopCoroutine(rotateCoroutine);
      }
      slideCoroutine = StartCoroutine(Slide(monsterPosition));
      rotateCoroutine = StartCoroutine(Rotate(monsterPosition.rotation));
    }
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

  public void OnShowCursor(BattleMonster _monster)
  {
    if (monster == _monster)
    {
      showCursor.Invoke();
    }
  }

  public void OnRemove(BattleMonster _monster)
  {
    if (monster == _monster)
    {
      if (slideCoroutine != null)
      {
        StopCoroutine(slideCoroutine);
      }
      if (rotateCoroutine != null)
      {
        StopCoroutine(rotateCoroutine);
      }
      if (removeCoroutine != null)
      {
        StopCoroutine(removeCoroutine);
      }
      removeCoroutine = StartCoroutine(Remove());
    }
  }

  IEnumerator Slide(PositionMonster target)
  {
    while (Vector3.Distance(transform.position, target.position) > 0.005f)
    {
      transform.position = Vector3.Lerp(transform.position, target.position, 15 * Time.deltaTime);
      transform.localScale = Vector3.Lerp(transform.localScale, target.scale, 15 * Time.deltaTime);
      yield return null;
    }
    
    transform.position = target.position;
    transform.localScale = target.scale;
  }

  IEnumerator Rotate(Quaternion target)
  {
    while (Mathf.DeltaAngle(transform.rotation.x, target.x) > 0.3f
    || Mathf.DeltaAngle(transform.rotation.y, target.y) > 0.3f
    || Mathf.DeltaAngle(transform.rotation.z, target.z) > 0.3f)
    {
      transform.rotation = Quaternion.Lerp(transform.rotation, target, 15 * Time.deltaTime);
      yield return null;
    }
    transform.rotation = target;
  }
  IEnumerator Remove()
  {
    var col = spriteRenderer.color;
    while (col.a > 0.01f)
    {
      col.a = Mathf.Lerp(col.a, 0, 7 * Time.deltaTime);
      spriteRenderer.color = col;
      yield return null;
    }
    yield return waitRemove;
    Destroy(gameObject);
  }
}
