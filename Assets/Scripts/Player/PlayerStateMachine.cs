using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlayerStateMachine : StateMachine<PlayerState>
{
    public event UnityAction Damaged;

    public void ApplyDamage(float damage)
    {
        _health.TakeDamage((int)damage);
        Damaged?.Invoke();
    }

    protected override void OnDied()
    {
        enabled = false;
        _animator.SetTrigger("broken");
    }
}
