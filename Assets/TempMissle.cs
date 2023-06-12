using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempMissle : MonoBehaviour
{
    [SerializeField] private Transform _point;

    private void Update()
    {
        transform.LookAt(_point);
    }
}
