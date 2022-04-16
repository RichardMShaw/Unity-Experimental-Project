using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class MouseInput : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
  public UnityEvent _onPointerEnterRaised;
  public UnityEvent _onPointerExitRaised;
  public UnityEvent _onPointerDownRaised;
  public void OnPointerEnter(PointerEventData e){
    if (_onPointerEnterRaised != null)
      _onPointerEnterRaised.Invoke();
  }

  public void OnPointerExit(PointerEventData e){
    if (_onPointerExitRaised != null)
      _onPointerExitRaised.Invoke();
  }

  public void OnPointerDown(PointerEventData e){
    if (_onPointerDownRaised != null)
      _onPointerDownRaised.Invoke();

  }

}
