using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    private Rigidbody rb;

    public float moveSpeed;
    public float damageAmount;
    private bool hasDamaged;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * moveSpeed;
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Pakin");
        if (other.CompareTag("Enemy") && !hasDamaged)
        {
            other.GetComponent<EnemyHealthController>().TakeDamage((int)damageAmount);
            hasDamaged = true;
            Destroy(gameObject);
        }
    }
}
