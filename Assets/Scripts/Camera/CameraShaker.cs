﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    [SerializeField] private PlayerStateMachine _player;
    [SerializeField] private float _shakeSpeed;
    [SerializeField] private int _shakeRange;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _player.Damaged += OnPlayerDamaged;
    }

    private void OnDisable()
    {
        _player.Damaged -= OnPlayerDamaged;
    }

    private void OnPlayerDamaged()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {
        int shakeRange = _shakeRange;
        Quaternion targetRotation;
        
        while (shakeRange != 0)
        {
            targetRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, shakeRange);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _shakeSpeed * Time.deltaTime);

            if (transform.rotation == targetRotation)
                shakeRange = (Mathf.Abs(shakeRange) - 1) * -1;

            yield return new WaitForEndOfFrame();
        }

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
        _coroutine = null;
    }
}
