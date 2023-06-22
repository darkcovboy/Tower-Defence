using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventClick : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    private SpawnPlaceTower _placeTower;

    private void Start()
    {
        _placeTower = GetComponent<SpawnPlaceTower>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("SomethingDown");
        //_placeTower.OpenPanel();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("SomethingUp");
        //_placeTower.ClosePanel();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("SomethingClick");
        _placeTower.OpenPanel();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("SomethingEnter");
        //_placeTower.OpenPanel();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("SomethingExit");
        //_placeTower.ClosePanel();
    }
}
