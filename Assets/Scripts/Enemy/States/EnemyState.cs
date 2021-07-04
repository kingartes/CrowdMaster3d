using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState : State
{
    public PlayerStateMachine Player { get; private set; }

    public void Enter(Rigidbody rigidbody, Animator animator, PlayerStateMachine player)
    {
        Player = player;
        base.Enter(rigidbody, animator);
    }

    public new EnemyState GetNextState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit)
            {
                return (EnemyState)transition.TargetState;
            }
        }

        return null;
    }

    protected override void OnTransitionEnable(Transition transition)
    {
        base.OnTransitionEnable(transition);
        ((EnemyTransition)transition).Init(Player);
    }
}
