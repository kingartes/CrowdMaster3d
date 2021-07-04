using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyTransition : Transition
{
    public PlayerStateMachine Player { get; private set; }

    public void Init(PlayerStateMachine player)
    {
        Player = player;
    }
}
