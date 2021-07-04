using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaAccumulator : MonoBehaviour
{
    [SerializeField] private float _accumulationTime;
    [SerializeField] private float _tapTime;
    [SerializeField] private Ability _ability;
    [SerializeField] private Ability _ultimateAbility;
    [SerializeField] private Ability _tapAbility;

    private float _staminaValue;

    public void StartAccumulate()
    {
        _staminaValue = 0;
    }

    private void Update()
    {
        _staminaValue += Time.deltaTime;
    }

    public Ability GetAbility()
    {
        if (_staminaValue < _tapTime)
            return _tapAbility;
        if (_staminaValue > _accumulationTime)
            return _ultimateAbility;
        return _ability;
    }
}
