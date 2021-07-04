using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Range Ability", menuName = "Player/Abilities/Range", order = 51)]
public class RangeAbility : Ability
{
    [SerializeField] private Projectile _projectile;
    [SerializeField] private float _force;

    public override event UnityAction AbilityEnded;

    public override void UseAbility(AttackState attackState)
    {
        Projectile projectile = Instantiate(_projectile, attackState.ShootPoint.position, Quaternion.identity);
        Vector3 projectileDirection = attackState.transform.forward.normalized * _force;
        projectile.GetComponent<Rigidbody>().AddForce(projectileDirection, ForceMode.Force);
        AbilityEnded?.Invoke();
    }
}
