using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyStateMachine : StateMachine<EnemyState>, IDamageable
{
    [SerializeField] private BrokenState _brokenState;

    private float _minDamage;

    public PlayerStateMachine Player { get; private set; }

    public event UnityAction<EnemyStateMachine> Died;

    protected override void OnDied()
    {
        enabled = false;
        _rigidbody.constraints = RigidbodyConstraints.None;
        Died.Invoke(this);
    }
    protected override void Awake()
    {
        base.Awake();
        Player = FindObjectOfType<PlayerStateMachine>();
    }

    public bool ApplyDamage(Rigidbody rigidbody, float force)
    {
        if (force > _minDamage && _currentState != _brokenState)
        {
            _health.TakeDamage((int)force);
            Transit(_brokenState);
            _brokenState.ApplyDamage(rigidbody, force);

            return true;
        }

        return false;
    }

    protected override void EnterState()
    {
        Debug.Log(Player);
        _currentState.Enter(_rigidbody, _animator, Player);
    }
}
