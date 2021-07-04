using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _lifetime;
    private Rigidbody _rigidbody;
    

    public void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Destroy(this.gameObject, _lifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamageable damageable))
        {
            damageable.ApplyDamage(_rigidbody, _damage);
            Destroy(this.gameObject);
        }
    }
}
