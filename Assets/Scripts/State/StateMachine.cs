using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody), typeof(Animator), typeof(HealthContainer))]
public abstract class StateMachine<StateType> : MonoBehaviour where StateType : State
{
    [SerializeField] private StateType _firstState;

    protected Rigidbody _rigidbody;
    protected Animator _animator;
    protected HealthContainer _health;

    protected StateType _currentState;

    private void OnEnable()
    {
        _health.Died += OnDied;
    }

    private void OnDisable()
    {
        _health.Died -= OnDied;
    }

    protected abstract void OnDied();

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _health = GetComponent<HealthContainer>();
    }

    private void Start()
    {
        _currentState = _firstState;
        EnterState();
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        StateType nextState = (StateType)_currentState.GetNextState();

        if (nextState != null)
            Transit(nextState);
    }

    protected void Transit(StateType nextState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = nextState;

        if (_currentState != null)
            EnterState();
    }

    protected virtual void EnterState()
    {
        _currentState.Enter(_rigidbody, _animator);
    }
}
