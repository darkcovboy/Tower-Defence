using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>())
        {
            Debug.Log("враг");
        }
    }
}
