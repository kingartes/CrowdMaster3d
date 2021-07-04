using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour, IDamageable
{
    [SerializeField] private float _explosiveRadius;
    [SerializeField] private float _explosiveForce;

    public bool ApplyDamage(Rigidbody rigidbody, float force)
    {
        Collider[] appliedObjects = Physics.OverlapSphere(transform.position, _explosiveRadius);
        Debug.Log(appliedObjects.Length);
        foreach(var collider in appliedObjects)
        {
            Rigidbody item = collider.GetComponent<Rigidbody>();
            if (item)
            {
                item.AddExplosionForce(_explosiveForce, transform.position, _explosiveRadius);
            }
        }
        Destroy(this.gameObject);
        return true;
    }
}
