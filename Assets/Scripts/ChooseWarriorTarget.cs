using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseWarriorTarget : MonoBehaviour
{
    [SerializeField] private FlagChoice _choice;
    [SerializeField] private GameObject _flagObject;

    public void Init(ref BarracksTower barracksTower)
    {
        _choice.Init(ref barracksTower);
    }

    public void Close()
    {
        _choice.Deactivate();
        _flagObject.Deactivate();
    }
}
