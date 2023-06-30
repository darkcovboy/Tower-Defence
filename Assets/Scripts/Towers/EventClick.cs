using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventClick : MonoBehaviour, IPointerClickHandler
{
    private SpawnPlaceTower _placeTower;

    private void Start()
    {
        _placeTower = GetComponent<SpawnPlaceTower>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _placeTower.OpenPanel();
    }
}
