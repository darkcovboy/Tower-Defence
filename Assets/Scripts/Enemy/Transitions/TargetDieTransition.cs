using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDieTransition : Transition
{
    private void Update()
    {
        //if (Target == null)
        //{
        //    NeedTransit = true;
        //}
        if (Target.gameObject.activeSelf == false)
        {
            NeedTransit = true;
        }
    }
}
