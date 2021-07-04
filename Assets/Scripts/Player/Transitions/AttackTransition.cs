using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTransition : PlayerTransition
{
    public void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            NeedTransit = true;
        }
    }
}
